function Send_User_Credentials() {

    // Perform client-side validation
    if ((document.getElementById("Username").value == "") || (document.getElementById("Password").value == "")) {
        window.alert("Please provide both username and password ..........");
    } else {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                Username: document.getElementById("Username").value,
                Password: document.getElementById("Password").value
            },
            url: "/User/Login",
            success: function (response) {
                window.alert(response.responseText);
                // Optionally redirect to another page or update UI
            },
            failure: function (response) {
                window.alert("Wrong Username or Password!!!");
            }
        });
    }

    
}

function Send_User_Registration(event) {
    event.preventDefault(); // Prevent default form submission

    // Perform client-side validation
    var firstName = document.getElementById("FirstName").value;
    var lastName = document.getElementById("LastName").value;
    var email = document.getElementById("Email").value;
    var username = document.getElementById("Username").value;
    var password = document.getElementById("Password").value;
    if (!firstName || !lastName || !email || !username || !password) {
        window.alert("Please provide all registration details.");
        return;
    }

    // Serialize form data using FormData
    var formData = new FormData();
    formData.append("FirstName", firstName);
    formData.append("LastName", lastName);
    formData.append("Email", email);
    formData.append("Username", username);
    formData.append("Password", password);

    $.ajax({
        type: "POST",
        processData: false, // Prevent jQuery from automatically serializing the data
        contentType: false, // Use FormData content type
        data: formData,
        url: "/Signup",
        success: function (data) {
            window.alert(data.responseText);
            // Optionally redirect to another page or update UI
        },
        error: function (data) {
            if (data.status === 400) {
                window.alert("Username already exists");
            } else {
                window.alert("An error occurred: " + error);
            }
        }
    });
}

// Attach event listeners to form submit buttons
document.getElementById("login").addEventListener("click", Send_User_Credentials);
document.getElementById("register").addEventListener("click", Send_User_Registration);
