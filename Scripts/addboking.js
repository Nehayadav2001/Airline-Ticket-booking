function bookingValid() {
        var ValidationSummary = "";
    ValidationSummary += validateForm();
 
        if (ValidationSummary != "") {
            alert(ValidationSummary);
            return false;
        }
        else {
            alert("Information submited successfuly" + "\n");
            return true;
        }
}

function validateForm() {
     var name = document.getElementById("txt_Name").value;
      if (name == "") {
        document.getElementById("error-messagename").innerHTML = "Please enter your name";
        return false;
      } else {
            document.getElementById("error-messagename").innerHTML = "";
            return true;
      }
}
