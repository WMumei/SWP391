

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
                data: { id: "id", lockoutEnd: "lockoutEnd" },
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();
                    if (lockout > today) {
                        return `<div>Locked</div>`
                    } else {
                        return `<div>Not locked</div>`
                    }
                }
            },
            {
                data: { id: "id", lockoutEnd: "lockoutEnd", role: "role" },
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();
                    
                    if (lockout > today) {
                        return `
                        <div class="text-center">
                            <a onclick=LockUnlock('${data.id}') class="btn btn-success text-white" style="cursor:pointer;width:100px;">
                                Unlock
                            </a>
                        </div>`
                    }
                    else {
                        if (data.role == "Admin") {
                            return `<div></div>`
                        } else {
                            return `
                                <div class="text-center">
                                    <a onclick=LockUnlock('${data.id}') class="btn btn-danger text-white" style="cursor:pointer;width:100px;">
                                        Lock
                                    </a>    
                                </div>`
                        }
                    }

                },
            }
        ]
    });
}

function LockUnlock(id) {
    $.ajax({
        type: "POST",
        url: '/user/LockUnlock',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            }
        }
    });
}