document.addEventListener('DOMContentLoaded', () => {
    loadGemstone();
    loadCurrentGemstone();
});

let dataTableGemstone;
let dataTableCurrentGemstone;

const loadGemstone = () => {
    dataTableGemstone = $("#gemstoneTable").DataTable({
        "ajax": { url: '/materialset/getgemstones' },
        "columns": [
            { data: 'name', "width": "26%" },
            { data: 'price', "width": "10%" },
            { data: 'weight', "width": "5%" },
            { data: 'carat', "width": "5%" },
            { data: 'color', "width": "10%" },
            { data: 'clarity', "width": "10%" },
            { data: 'cut', "width": "14%" },
            {
                data: 'id',
                "render": (data) => {
                    return `<div role="group">
                        <button class="btn btn-outline-primary px-2" onclick="addGemstone(${data})"><i class="bi bi-plus-lg"></i></button>
                    </div>`;
                },
                "width": "10%"
            }
        ]
    });
}

const loadCurrentGemstone = () => {
    dataTableCurrentGemstone = $("#currentGemstoneTable").DataTable({
        "ajax": { url: '/materialset/getsessiongemstones' },
        "columns": [
            { data: 'name', "width": "26%" },
            { data: 'price', "width": "10%" },
            { data: 'weight', "width": "5%" },
            { data: 'carat', "width": "5%" },
            { data: 'color', "width": "10%" },
            { data: 'clarity', "width": "10%" },
            { data: 'cut', "width": "14%" },
            {
                data: 'id',
                "render": (data) => {
                    return `<div class="btn-group" role="group">
                        <button class="btn btn-outline-danger p-1" onclick="deleteGemstone(${data})"><i class="bi bi-trash"></i></button>
                    </div>`;
                },
                "width": "10%"
            }
        ]
    });
}

const reloadGemstoneTables = (data) => {
    reloadPrice();
    dataTableGemstone.ajax.reload(null, false);
    dataTableCurrentGemstone.ajax.reload(null, false);
    if (!data.success) {
        toastr.error(data.message);
    } else {
        toastr.success(data.message);
    }
}

const addGemstone = (id) => {
    $.ajax({
        url: `/materialset/addgemstone/${id}`,
        type: 'POST',
        success: (data) => {
            reloadGemstoneTables(data);

        },
        error: (data) => {
            reloadGemstoneTables(data);
        }
    });
}

const deleteGemstone = (id) => {
    $.ajax({
        url: `/materialset/deletegemstone/${id}`,
        type: 'DELETE',
        success: (data) => {
            reloadGemstoneTables(data);
        },
        error: (data) => {
            reloadGemstoneTables(data);
        }
    });
}
