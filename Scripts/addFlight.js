function userValid() {
    var ValidationSummary = "";
    ValidationSummary += flightValidation();
    ValidationSummary += airnamevalidate();
    ValidationSummary += departnamevalidate();
    ValidationSummary += Arrivalvalidate();
    ValidationSummary += dateValidate();
    ValidationSummary += Classvalidate();
    ValidationSummary += PriceValiation();

    //alert("helloooooo");

    if (ValidationSummary != "") {
        //alert(ValidationSummary);
        return false;
    }
    else {
        alert("Information submited successfuly" + "\n");
        return true;
    }
}  

function flightValidation() {
    var txt_flight = document.getElementById("txt_flight").value;
    if (txt_flight === "") {
        document.getElementById("error-messageflight").innerHTML = "Please enter a flight number.";
        return " ";
    } else if (!/^[a-zA-Z0-9\-]+$/.test(txt_flight)) {
        document.getElementById("error-messageflight").innerHTML = "Please enter a valid flight number (letters, numbers, and hyphens only).";
        return " ";
    }
    document.getElementById("error-messageflight").innerHTML = "";
    return "";
}

function airnamevalidate() {
    var drp_arline = document.getElementById("drp_arline");
    var selectedValue = drp_arline.options[drp_arline.selectedIndex].value;
    if (selectedValue == 0) {
        document.getElementById("error-messageAir").innerHTML = "Please select an airline.";
        return "";
    }
    document.getElementById("error-messageAir").innerHTML = "";
    return "";
}

function departnamevalidate() {
    var drp_arline = document.getElementById("drp_from");
    var selectedValue = drp_arline.options[drp_arline.selectedIndex].value;
    if (selectedValue == 0) {
        document.getElementById("error-messagedepart").innerHTML = "Please select an Departure City.";
        return "";
    }
    document.getElementById("error-messagedepart").innerHTML = "";
    return "";
}

function Arrivalvalidate() {
    var drp_arline = document.getElementById("drp_arrival");
    var selectedValue = drp_arline.options[drp_arline.selectedIndex].value;
    if (selectedValue == 0) {
        document.getElementById("error-messageArrival").innerHTML = "Please select an Departure City.";
        return "";
    }
    document.getElementById("error-messageArriva").innerHTML = "";
    return "";
}

function dateValidate() {
    const dateInput = document.getElementById("date_date");
    const errorSpan = document.getElementById("date_error");

    const enteredDate = new Date(dateInput.value);
    const currentDate = new Date();

    if (enteredDate < currentDate) {
        errorSpan.innerHTML = "Please enter a future date";
        return " ";
    } else {
        errorSpan.innerHTML = "";
        return " ";
    }
}

function Classvalidate() {
    var drp_arline = document.getElementById("drp_class");
    var selectedValue = drp_arline.options[drp_arline.selectedIndex].value;
    if (selectedValue == 0) {
        document.getElementById("error-messageClass").innerHTML = "Please select an Class Type.";
        return "";
    }
    document.getElementById("error-messageClass").innerHTML = "";
    return "";
}

function PriceValiation() {
    const priceInput = document.getElementById("txt_prc");
    const errorSpan = document.getElementById("price_error");

    const price = parseFloat(priceInput.value);

    if (isNaN(price) || price <= 0) {
        errorSpan.innerHTML = "Please enter a valid price";
        return " ";
    } else {
        errorSpan.innerHTML = "";
        return " ";
    }
}