

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/material/getall' },
        "columns": [
            { data: 'id' },
            { data: 'name' },
            { data: 'price' },
            {
                data: "id",
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/material/edit?mid=${data}" class="btn btn-primary mx-2"> Edit </a>
                    </div>`
                },
            },
            {
                data: "id",
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/material/delete?mid=${data}" class="btn btn-danger mx-2"> Delete </a>
                    </div>`
                },
            }
        ]
    });
}
