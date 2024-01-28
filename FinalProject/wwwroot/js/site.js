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
    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;
    var data = { "username": username, "password": password };
    $.ajax({
        type: "POST",
        url: "/Home/Login.aspx",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            // If the server sends back a 200 status code, then the user is authenticated and we can redirect them to the home page
            if (data.status == 200) {
                document.getElementById("error").innerHTML = "Success!!!";
                //window.location.href = "/Home/Index";
            }
        },
        error: function (data) {
            // If the server sends back a 401 status code, then the user is not authenticated and we should display an error message
            if (data.status == 401) {
                document.getElementById("error").innerHTML = "Invalid username or password";
            }
        }
    });
}