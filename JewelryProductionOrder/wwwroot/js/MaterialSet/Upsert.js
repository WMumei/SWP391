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

// In milliseconds
const waitTime = 750;

const redirect = (mId, jId, redirectId) => {
    if (mId === '0') {
        if (redirectId !== 0) {
            setTimeout(() => {
                window.location.href = `/materialset/details?mId=${redirectId}&jId=${jId}`;
            }, waitTime);
        }
    } else {
        setTimeout(() => {
            window.location.href = `/materialset/details?mId=${mId}&jId=${jId}`;
        }, waitTime);
    }
}

const sendPostRequest = (data, mId, jId) => {
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
}

document.getElementById('saveButton').onclick = () => {
    // Get the jId and mId query parameters from the URL
    const urlParams = new URLSearchParams(window.location.search);
    const mId = urlParams.get('mId'); 
    const jId = urlParams.get('jId');
    //const redirectRequest = urlParams.get('redirectRequest'); 

    const data = {
        mId: mId,
        jId: jId
    };

    if (mId !== '0') {
        // Show SweetAlert confirmation dialog
        swal({
            title: "Notes",
            text: "Saving this set will set the status of any quotations using this set to 'Discontinued'. Do you want to continue?",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        }).then((willSave) => {
            if (willSave) {
                sendPostRequest(data, mId, jId);
            } else {
                toastr.info("Save operation was canceled.");
            }
        });
    } else {
        sendPostRequest(data, mId, jId);
    }
};

document.addEventListener('DOMContentLoaded', () => {
    reloadPrice();
});