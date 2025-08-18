
document.querySelector("button[type='submit']").addEventListener("click", function(event) {
    // Prevent default form submission
    event.preventDefault();

    // Grab input values
    const fullName = document.getElementById("infname").value.trim();
    const username = document.getElementById("inuname").value.trim();
    const email = document.getElementById("inmail").value.trim();
    const phone = document.getElementById("inphone").value.trim();
    const errorMsg = document.getElementById("error");

    let message = "";

    // Validate full name
    if (fullName === "") {
        message += "Please enter your full name.<br>";
    }

    // Validate username
    if (username === "") {
        message += "Please enter a username.<br>";
    }

    // Validate email format
    const emailPattern = /^[^ ]+@[^ ]+\.[a-z]{2,3}$/;
    if (!emailPattern.test(email)) {
        message += "Please enter a valid email address.<br>";
    }

    // Validate phone number (10 digits)
    const phonePattern = /^[0-9]{10}$/;
    if (!phonePattern.test(phone)) {
        message += "Phone number must be 10 digits.<br>";
    }

    // Display errors or success
    if (message !== "") {
        errorMsg.innerHTML = message;
    } else {
        errorMsg.style.color = "green";
        errorMsg.innerHTML = "Profile updated successfully!";
        // Optionally submit form or perform AJAX call here
    }