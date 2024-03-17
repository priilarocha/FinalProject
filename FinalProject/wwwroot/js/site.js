// Function to use the Login button to send user credentials to the server
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

// Function to user the Register button to send user registration details to the server
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

// Function to use the Add Game button to send game details to the server
function Send_Game_Data() {
    if (!document.getElementById("Title").value || !document.getElementById("Genre").value) {
        window.alert("Please provide all game details.");
        return;
    }

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({
            Title: document.getElementById("Title").value,
            Genre: document.getElementById("Genre").value,
            ReleaseDate: document.getElementById("ReleaseDate").value,
           // Platform: document.getElementById("Platform").value,
            Description: document.getElementById("Description").value
        }),
        url: "/Games/AddGame", 
        success: function (response) {
            if (response.success) {
                window.alert(response.responseText);
                // If a redirect URL is provided, redirect to it
                if (response.redirectToUrl) {
                    window.location.href = response.redirectToUrl;
                }
            } else {
                window.alert(response.responseText); // Show any error messages
            }
        },
        error: function (xhr) {
            window.alert("An error occurred: " + xhr.responseText);
        }
    });
}

// Attach event listeners to form submit buttons
document.getElementById("Login").addEventListener("click", Send_User_Credentials);
document.getElementById("Register").addEventListener("click", Send_User_Registration);
document.getElementById("AddGame").addEventListener("click", Send_Game_Data);
