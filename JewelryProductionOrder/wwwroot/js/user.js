﻿

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/user/getall' },
            "columns": [
                { data: 'name' },
                { data: 'userName' },
                { data: 'email' },
                { data: 'role' },
                {
                    data: "email",
                    "render": function (data) {
                        return `<div class="w-75 btn-group" role="group">
                        <a href="/gemstone/edit?id=${data}" class="btn btn-primary mx-2"> Edit </a>
                        <a href="/gemstone/delete?id=${data}" class="btn btn-danger mx-2"> Delete </a>
                        </div>`
                    },
                }
            ]
    });
}
