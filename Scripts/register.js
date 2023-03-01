function userValid() {
    var ValidationSummary = "";
    ValidationSummary += namevalidate();
    ValidationSummary += usernamevalidate();
    ValidationSummary += emailvalidate();
    ValidationSummary += mobileValidate();
    ValidationSummary += gendervalidate();
    ValidationSummary += PassValiation();

    if (ValidationSummary != "") {
        //alert(ValidationSummary);
        return false;
    }
    else {
        alert("Information submited successfuly" + "\n");
        return true;
    }
}

function namevalidate() {
    var txt_flight = document.getElementById("txt_Name").value;
    if (txt_flight === "") {
        document.getElementById("error-messagename").innerHTML = "Please enter a Name.";
        return " ";
    } else if (!/^[a-zA-Z]+$/.test(txt_flight)) {
        document.getElementById("error-messagename").innerHTML = "Please enter a valid Name (letters only).";
        return " ";
    }
    document.getElementById("error-messagename").innerHTML = "";
    return "";
}

function usernamevalidate() {
    var txt_flight = document.getElementById("txt_user").value;
    if (txt_flight === "") {
        document.getElementById("error-messageusername").innerHTML = "Please enter a Username.";
        return " ";
    } else if (!/^[a-zA-Z0-9\-]+$/.test(txt_flight)) {
        document.getElementById("error-messageusername").innerHTML = "Please enter a valid Username (letters only).";
        return " ";
    }
    document.getElementById("error-messageusername").innerHTML = "";
    return "";
}

function emailvalidate() {
    const emailInput = document.getElementById("txt_Email");
    const errorSpan = document.getElementById("email_error");
    const email = emailInput.value;
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(email)) {
        errorSpan.innerHTML = "Please enter a valid email address";
        return " ";
    } else {
        errorSpan.innerHTML = "";
        return true;
    }
}

function mobileValidate() {
    const mobileInput = document.getElementById("txt_mobile");
    const errorSpan = document.getElementById("mobile_error");
    const mobile = mobileInput.value;
    const mobileRegex = /^[7-9]\d{9}$/;
    if (!mobileRegex.test(mobile)) {
        errorSpan.innerHTML = "Please enter a valid 10-digit mobile number";
        return " ";
    } else {
        errorSpan.innerHTML = "";
        return true;
    }
}

function gendervalidate() {
    const genderRadioList = document.getElementById("rd_gender");
    const errorSpan = document.getElementById("gender_error");

    const selectedGender = genderRadioList.querySelector("input:checked");

    if (!selectedGender) {
        errorSpan.innerHTML = "Please select a gender";
        return " ";
    } else {
        errorSpan.innerHTML = "";
        return true;
    }
}

function PassValiation() {
    const passwordInput = document.getElementById("txt_pass");
    const errorSpan = document.getElementById("pass_error");

    const passwordValue = passwordInput.value;

    if (!passwordValue) {
        errorSpan.innerHTML = "Please enter a password";
        return " ";
    } else if (passwordValue.length < 8) {
        errorSpan.innerHTML = "Password must be at least 8 characters long";
        return " ";
    } else {
        errorSpan.innerHTML = "";
        return true;
    }
}