function Send_User_Credentials(event) {
    event.preventDefault(); // Prevent default form submission

    // Perform client-side validation
    var username = document.getElementById("Username").value;
    var password = document.getElementById("Password").value;
    if (!username || !password) {
        window.alert("Please provide both username and password.");
        return;
    }

    // Serialize form data using FormData
    var formData = new FormData();
    formData.append("Username", username);
    formData.append("Password", password);

    $.ajax({
        type: "POST",
        processData: false, // Prevent jQuery from automatically serializing the data
        contentType: false, // Use FormData content type
        data: formData,
        url: "/User/Login",
        success: function (data) {
            window.alert(data.responseText);
            // Optionally redirect to another page or update UI
        },
        error: function (xhr, status, error) {
            if (xhr.status === 401) {
                window.alert("Wrong Username or Password");
            } else {
                window.alert("An error occurred: " + error);
            }
        }
    });
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
        url: "/User/Signup",
        success: function (data) {
            window.alert(data.responseText);
            // Optionally redirect to another page or update UI
        },
        error: function (xhr, status, error) {
            if (xhr.status === 400) {
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
