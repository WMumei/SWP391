document.addEventListener('DOMContentLoaded', () => {
    loadMaterial();
    loadCurrentMaterial();
});

let dataTableMaterial;
let dataTableCurrentMaterial;

const loadMaterial = () => {
    dataTableMaterial = $("#materialTable").DataTable({
        "ajax": { url: '/materialset/getmaterials' },
        "columns": [
            { data: 'name', "width": "50%" },
            { data: 'price', "width": "40%" },
            {
                data: 'id',
                "render": (data) => {
                    return `<div role="group">
                        <button class="btn btn-outline-primary px-2" onclick="addMaterial(${data})"><i class="bi bi-plus-lg"></i></button>
                    </div>`;
                },
                "width": "10%"
            }
        ]
    });
}

const loadCurrentMaterial = () => {
    dataTableCurrentMaterial = $("#currentMaterialTable").DataTable({
        "ajax": { url: '/materialset/GetSessionMaterials' },
        "columns": [
            { data: 'material.name', "width": "30%" },
            { data: 'material.price', "width": "18%" },
            {
                data: null,
                "render": (data) => {
                    return `<div style="display: flex; gap: 3px;">
                        <input style="border: 1px solid #aaa;" class="rounded p-1" type="number" id="weight-${data.material.id}" name="MaterialWeight" value="${data.weight}" min="0" max="999999999">
                        <button class="btn btn-outline-primary" onclick="updateMaterial(${data.material.id})">
                            <i class="bi bi-floppy-fill"></i>
                        </button>
                    </div>`;
                },
                "width": "13%"
            },
            { data: 'price', "width": "18%" },
            {
                data: 'material.id',
                "render": (data) => {
                    return `<div class="btn-group" role="group">
                        <button class="btn btn-outline-danger px-2" onclick="deleteMaterial(${data})"><i class="bi bi-trash-fill"></i></button>
                    </div>`;
                },
                "width": "8%"
            }
        ]
    });
}

const reloadMaterialTables = (data) => {
    reloadPrice();
    dataTableMaterial.ajax.reload(null, false);
    dataTableCurrentMaterial.ajax.reload(null, false);
    if (!data.success) {
        toastr.error(data.message);
    } else {
        toastr.success(data.message);
    }
}

const addMaterial = (id) => {
    $.ajax({
        url: `/materialset/addmaterial/${id}`,
        type: 'POST',
        success: (data) => {
            reloadMaterialTables(data);

        },
        error: (data) => {
            reloadMaterialTables(data);
        }
    });
}

const updateMaterial = (id) => {
    const weight = $(`#weight-${id}`).val();
    const formData = { id, weight };
    $.ajax({
        url: `/materialset/updatematerial`,
        type: 'POST',
        data: formData,
        success: (data) => {
            reloadMaterialTables(data);
        },
        error: (data) => {
            reloadMaterialTables(data);

        }
    });
}

const deleteMaterial = (id) => {
    $.ajax({
        url: `/materialset/deletematerial/${id}`,
        type: 'DELETE',
        success: (data) => {
            reloadMaterialTables(data);

        },
        error: (data) => {
            reloadMaterialTables(data);
        }
    });
}