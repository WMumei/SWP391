document.addEventListener('DOMContentLoaded', () => {
    loadMaterial();
    loadCurrentMaterial();
});

const loadMaterial = () => {
    $("#materialTable").DataTable({
        "ajax": { url: '/materialset/getmaterials' },
        "columns": [
            { data: 'name', "width": "50%" },
            { data: 'price', "width": "40%" },
            {
                data: 'id',
                "render": (data) => {
                    return `<div role="group">
                        <a class="btn btn-primary" href="/materialset/addmaterial/${data}"><i class="bi bi-plus-lg"></i></a>
                    </div>`;
                },
                "width": "10%"
            }
        ]
    });
}

const loadCurrentMaterial = () => {
    $("#currentMaterialTable").DataTable({
        "ajax": { url: '/materialset/GetSessionMaterials' },
        "columns": [
            { data: 'material.name', "width": "30%" },
            { data: 'material.price', "width": "18%" },
            { data: 'weight', "width": "18%" },
            { data: 'price', "width": "18%" },
            {
                data: 'material.id',
                "render": (data) => {
                    return `<div class="btn-group" role="group">
                        <a class="btn btn-primary" href="/materialset/updatematerial/id=${data}&weight="><i class="bi bi-pencil"></i></a>
                        <a class="btn btn-danger" href="/materialset/deletematerial/${data}"><i class="bi bi-trash"></i></a>
                    </div>`;
                },
                "width": "15%"
            }
        ]
    });
}