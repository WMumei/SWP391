const reloadPrice = () => {
    $.ajax({
        url: `/materialset/getPrice`,
        type: 'GET',
        success: (data) => {
            $("#materialTotal").text(data.materialTotal);
            $("#gemstoneTotal").text(data.gemstoneTotal);
            $("#totalPrice").text(data.setTotal);
        },
        error: (data) => {
            toastr.error("Updating price failed.")
        }
    });
}

document.getElementById('cancelButton').onclick = () => {
    window.history.back();
};


document.getElementById('saveButton').onclick = () => {
    // Get the jId and id query parameters from the URL
    const urlParams = new URLSearchParams(window.location.search);
    const jId = urlParams.get('jId');
    const mId = urlParams.get('mId') || 0; // Default to 0 if id is not present

    const data = {
        mId: mId,
        jId: jId
    };

    // Send POST request
    $.ajax({
        url: `/materialset/upsert`,
        type: 'POST',
        data: data,
        success: (response) => {
            if (response.success) {
                toastr.success(response.message);
                // window.location.href = '/materialset/index';
            } else {
                toastr.error(response.message);
            }
        },
        error: (response) => {
            toastr.error("An error occurred while saving the material set.");
        }
    });
};
document.addEventListener('DOMContentLoaded', () => {
    reloadPrice();
});