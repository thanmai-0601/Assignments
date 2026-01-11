const form = document.getElementById("enquiryForm");
const successMessage = document.getElementById("successMessage");

// Handle form submit
form.addEventListener("submit", function (event) {
    event.preventDefault(); // Stop default form submission

    clearErrors();

    let isValid = true;

    // Get form values
    const name = document.getElementById("fullName").value.trim();
    const email = document.getElementById("email").value.trim();
    const mobile = document.getElementById("mobile").value.trim();
    const requestType = document.getElementById("requestType").value;
    const policyType = document.getElementById("policyType").value;
    const message = document.getElementById("message").value.trim();
    const rating = document.querySelector('input[name="rating"]:checked');

    // Validation rules
    if (name === "") {
        showError("nameError", "Name is required");
        isValid = false;
    }

    if (email === "") {
        showError("emailError", "Email is required");
        isValid = false;
    }

    if (!/^\d{10}$/.test(mobile)) {
        showError("mobileError", "Mobile must be exactly 10 digits");
        isValid = false;
    }

    if (requestType === "") {
        showError("requestError", "Select request type");
        isValid = false;
    }

    if (policyType === "") {
        showError("policyError", "Select policy type");
        isValid = false;
    }

    if (message.length < 10) {
        showError("messageError", "Minimum 10 characters required");
        isValid = false;
    }

    if (!rating) {
        showError("ratingError", "Select a rating");
        isValid = false;
    }

    // Success
    if (isValid) {
        successMessage.style.display = "block";
        successMessage.textContent =
            "Thank you! Your enquiry has been successfully submitted.";

        form.reset();

        setTimeout(() => {
            successMessage.style.display = "none";
        }, 4000);
    }
});

// Display error message
function showError(elementId, message) {
    document.getElementById(elementId).textContent = message;
}

// Clear all previous errors
function clearErrors() {
    const errors = document.querySelectorAll(".error");
    errors.forEach(error => {
        error.textContent = "";
    });
}
