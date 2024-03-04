function Send_User_Credentials() {
    if (!document.getElementById("Username").value || !document.getElementById("Password").value) {
        window.alert("Please provide both username and password");
        return;
    }

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({
            Username: document.getElementById("Username").value,
            Password: document.getElementById("Password").value
        }),
        url: "/User/Login",
        success: function (response) {
            if (response.success) {
                window.alert(response.responseText);
                if (response.redirectToUrl) {
                    window.location.href = response.redirectToUrl;
                }
            } else {
                window.alert(response.responseText);
            }
        },
        error: function (xhr) {
            window.alert("An error occurred: " + xhr.responseText);
        }
    });
}


function Send_User_Registration() {
    if (!document.getElementById("FirstName").value || !document.getElementById("LastName").value || !document.getElementById("Email").value || !document.getElementById("Username").value || !document.getElementById("Password").value) {
        window.alert("Please provide all registration details.");
        return;
    }

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({
            FirstName: document.getElementById("FirstName").value,
            LastName: document.getElementById("LastName").value,
            Email: document.getElementById("Email").value,
            Username: document.getElementById("Username").value,
            Password: document.getElementById("Password").value
        }),
        url: "/User/Register",
        success: function (response) {
            console.log(response); // Log the response for debugging
            if (response.success) {
                window.alert(response.responseText); // Show success message
                if (response.redirectToUrl) {
                    window.location.href = response.redirectToUrl; // Redirect
                }
            } else {
                window.alert(response.responseText); // Show error message
            }
        },

        error: function (xhr) {
            console.log(xhr.status, xhr.statusText); // Add this line for more detailed error info
            window.alert("An error occurred: " + xhr.responseText);
        }
    });
}



// Attach event listeners to form submit buttons
document.getElementById("Login").addEventListener("click", Send_User_Credentials);
document.getElementById("Register").addEventListener("click", Send_User_Registration);
