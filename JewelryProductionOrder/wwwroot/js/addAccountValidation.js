$(document).ready(function () {
    // Add event listeners to the input fields
    $('#Name').on('input', validateName);
    $('#Password').on('input', validatePassword);
    $('#Email').on('input', validateEmail);

    // Validate name field
    function validateName() {
        var name = $('#Name').val();
        if (name.trim() === '') {
            $('#name-error').text('Name field cannot be left blank');
        } else {
            $('#name-error').text('');
        }
    }

    // Validate password field
    function validatePassword() {
        var password = $('#Password').val();
        var regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,100}$/;
        if (!regex.test(password)) {
            $('#password-error').text('Password must contain at least 1 lowercase character, 1 uppercase character, 1 digit, 1 special character, and be between 6 and 100 characters long');
        } else {
            $('#password-error').text('');
        }
    }

    // Validate email field
    function validateEmail() {
        var email = $('#Email').val();
        var regex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
        if (!regex.test(email)) {
            $('#email-error').text('Invalid email address');
        } else {
            $('#email-error').text('');
        }
    }
});