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

document.getElementById('cancelButton').onclick = () => {
	window.history.back();
};

document.getElementById('saveButton').onclick = () => {
	// Get the jId query parameter from the URL
	const urlParams = new URLSearchParams(window.location.search);
	const jId = urlParams.get('jId');

	const data = {
		id: 0,
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
	})
};