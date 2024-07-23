

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/gemstone/getall' },
        "columns": [
            { data: 'name' },
            { data: 'price' },
            { data: 'weight' },
            { data: 'carat' },
            { data: 'clarity' },
            { data: 'color' },
            { data: 'cut' },
            {
                data: "id",
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/gemstone/edit?id=${data}" class="btn btn-primary "> Edit </a>
                    <a href="/gemstone/delete?id=${data}" class="btn btn-danger "> Delete </a>
                    </div>`
                },
            }
        ]
    });
}
