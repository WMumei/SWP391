

$(document).ready(function () {
    loadUserTable();
})

function loadUserTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/user/getall' },
        "columns": [
            { data: 'name' },
            { data: 'userName' },
            { data: 'email' },
            { data: 'role' },
            {
                data: "id",
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a href="/user/edit?id=${data}" class="btn btn-primary mx-2"> Edit </a>
                        <a href="/user/delete?id=${data}" class="btn btn-danger mx-2"> Delete </a>
                        </div>`
                },
            }
        ]
    });
}
