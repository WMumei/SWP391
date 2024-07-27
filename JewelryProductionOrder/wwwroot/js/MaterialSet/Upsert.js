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

// In miliseconds
const waitTime = 750;

const redirect = (mId, jId, redirectId) => {
    if (mId === '0') {
        if (redirectId !== 0) {
            setTimeout(() => {
                window.location.href = `/materialset/details?mId=${redirectId}&jId=${jId}`;
            }, waitTime);
        }
    }
    else {
        setTimeout(() => {
            window.location.href = `/materialset/details?mId=${mId}&jId=${jId}`;
        }, waitTime);
    }
}


document.getElementById('saveButton').onclick = () => {
    // Get the jId and mId query parameters from the URL
    const urlParams = new URLSearchParams(window.location.search);
    const mId = urlParams.get('mId') || 0; // Default to 0 if id is not present
    const jId = urlParams.get('jId');
    //const redirectRequest = urlParams.get('redirectRequest'); 

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
                // Redirect to the material details page after showing the notification
                toastr.success(response.message);
                redirect(mId, jId, response.redirectId);
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