document.addEventListener('DOMContentLoaded', () => {
    loadGemstone();
    loadCurrentGemstone();
});

const loadGemstone = () => {
    $("#gemstoneTable").DataTable({
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
                        <a class="btn btn-primary btn-sm" href="/materialset/addgemstone/${data}"><i class="bi bi-plus"></i></a>
                    </div>`;
                },
                "width": "10%"
            }
        ]
    });
}

const loadCurrentGemstone = () => {
    $("#currentGemstoneTable").DataTable({
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
                    return `<div role="group">
                        <a class="btn btn-danger btn-sm" href="/materialset/deletegemstone/${data}"><i class="bi bi-trash"></i></a>
                    </div>`;
                },
                "width": "10%"
            }
        ]
    });
}
