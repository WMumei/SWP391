const getCurrentPrice = () => {
    const urlParams = new URLSearchParams(window.location.search);
    const mId = urlParams.get('mId');
    $.ajax({
        url: `/materialset/getCurrentPrice?mId=${mId}`,
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
document.addEventListener('DOMContentLoaded', () => {
    getCurrentPrice();
});