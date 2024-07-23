$(document).ready(() => loadData());

const loadData = () => {
    $("#materialTable").DataTable({
        "ajax": { url: '/materialset/getmaterials'},
        "columns": [
            { data: 'name', "width": "20%" },
            { data: 'price', "width": "10%" },
            {
                data: 'id',
                "render": (data) => {
                    return `<div role="group">
                        <a class="btn btn-primary" href="/materialset/addmaterial/${data}"><i class="bi bi-plus-lg"></i></a>
                    </div>`
                }
                }
            //{ data: '' },
            //{ data: '' },
        ]
    });

}