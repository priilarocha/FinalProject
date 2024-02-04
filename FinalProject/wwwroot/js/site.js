// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// window.alert("Hello")

function Send_User_Credentials() {
    // This function is called when the user clicks the login button
    // It will send the user's credentials to the server for authentication
    // If the user is authenticated, the server will send back a cookie
    // If the user is not authenticated, the server will send back a 401 error
    // The server will also send back a 400 error if the user does not provide
    // a username and password

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({
            Username: document.getElementById("Username").value,
            Password: document.getElementById("Password").value
        }),
        url: "/User/Login",
        success: function (data) {
            window.alert(data.responseText);
            //document.getElementById("error").innerHTML = data.responseText;
        },
        error: function (data) {
            window.alert("error");
        }
    });
}