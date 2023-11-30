document.addEventListener("DOMContentLoaded", function () {
    var firstNameInput = document.getElementById("first-name");
    var firstNameError = document.getElementById("firstNameError");
    firstNameInput.addEventListener("blur", function () {
        validateFirstName();
    });

    function validateFirstName() {
        var firstName = firstNameInput.value;

        if (firstName.trim() === "") {

            firstNameError.innerHTML = "First name cannot be empty.";
        }
        else if (!/^[A-Za-z]+$/.test(firstName)) {
            firstNameError.innerHTML = "First name can only contain alphabets.";
        }
        else {
            firstNameError.innerHTML = "";
        }
    }
});

document.addEventListener("DOMContentLoaded", function () {
    var lastNameInput = document.getElementById("last-name");
    var lastNameError = document.getElementById("lastNameError");

    lastNameInput.addEventListener("blur", function () {
        validateLastName();
    });

    function validateLastName() {
        var lastName = lastNameInput.value;

        if (lastName.trim() === "") {

            lastNameError.innerHTML = "Last name cannot be empty.";
        }
        else if (!/^[A-Za-z]+$/.test(lastName)) {
            lastNameError.innerHTML = "last name can only contain alphabets.";
        }
        else {
            lastNameError.innerHTML = "";
        }
    }
});

document.addEventListener("DOMContentLoaded", function () {
    var emailInput = document.getElementById("email");
    var emailError = document.getElementById("emailError");
    

    emailInput.addEventListener("blur", function () {
        validateEmailAddress();
    });

    function validateEmailAddress() {
        var email = emailInput.value;

        if (email.trim() === "") {
            
            emailError.innerHTML = "Email id cannot be empty";
          
        } else if (!/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(email)) {
            
            emailError.innerHTML = "Please enter a valid e-mail id.";
            
        } else {
            
            emailError.innerHTML = "";
           
        }
    }
});

document.addEventListener("DOMContentLoaded", function () {
    var phoneNumberInput = document.getElementById("phone-number");
    var phoneNumberError = document.getElementById("phoneNumberError");
    

   
    phoneNumberInput.addEventListener("blur", function () {
        validatePhoneNumber();
    });

    function validatePhoneNumber() {
        var phoneNumber = phoneNumberInput.value;

        if (phoneNumber.trim() === "") {
            
            phoneNumberError.innerHTML = "Phone number is required.";
           
        } else if (!/^[6-9]\d{9}$/.test(phoneNumber)) {
            // Display an error message in the span tag with red color
            phoneNumberError.innerHTML = "Please enter a valid mobile number.";
            
        } else {
            // Clear the error messages if validation passes
            phoneNumberError.innerHTML = "";
         
        }
    }
});

document.addEventListener("DOMContentLoaded", function () {
    var passwordInput = document.getElementById("password");
    
  
    passwordInput.addEventListener("blur", function () {
        validatePassword();
    });

    function validatePassword() {
        var password = passwordInput.value;

        if (password.trim() === "") {
            passwordError.innerHTML = "Password is required.";
            
        } else if (!/^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/.test(password)) {
            passwordError.innerHTML = "Password should contain at least 8 characters, 1 uppercase letter, 1 special character, and alphabets.";
            
        } else {
            passwordError.innerHTML = "";
           
        }
    }
});
document.addEventListener("DOMContentLoaded", function () {
    var confirmPasswordInput = document.getElementById("confirm-password");
   

    // Attach onblur event listener
    confirmPasswordInput.addEventListener("blur", function () {
        validateConfirmPassword();
    });

    function validateConfirmPassword() {
        var confirmPassword = confirmPasswordInput.value;
        var enterPassword = document.getElementById("password").value;

        if (confirmPassword.trim() === "") {
            
            confirmPasswordError.innerHTML = "Confirm Password is required.";
        } else if (confirmPassword !== enterPassword) {
           
            confirmPasswordError.innerHTML = "Passwords do not match.";
        } else {
            
            confirmPasswordError.innerHTML = "";
        }
    }
    
});

