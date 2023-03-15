function login() {
    var email = $("#email").val();
    var password = $("#pwd").val();
    //var data = JSON.stringify({
    //    'username': email,
    //    'password': password
    //});

    //const data = { "username": email };
    $.ajax({
        type: "GET",
        url: "/User/Login?username=" + email + "&password=" + password,
        //data: data,  
        //data: JSON.stringify("asf"),
        //data: { username: 'may' },
        contentType: 'application/json',
        success: function (result) {
            if (result == "Failed") {
                alert("Login Failed")
            } else
                if (result == "admin") {
                    window.location.href = "/Admin/Dashboard";
                }
                else {


                    alert("Login successfull")

                    $('#myModalLogin').hide();
                    $('.modal-backdrop').remove()
                    location.reload();
                }
        
    
            
    },
        error: function () {
            alert("Error occured!!")
        }
    });
}

function register() {
    var name = $("#name").val();
    var phone = $("#phone").val();
    var email = $("#regEmail").val();
    var password = $("#regPassword").val();
    var location = $("#location").val();
    var userType = $('input[name="userTypeRadio"]:checked').val();

    var data = JSON.stringify({
        'Name': name,
        'Phone': phone,
        'Email': email,
        'Password': password,
        'Location': location,
        'UserType': userType,
        'ProfileImage': ""
    });

    $.ajax({
        type: "POST",
        url: "/User/Register",
        data: data,
        //data: JSON.stringify("asf"),
        //data: { username: 'may' },
        contentType: 'application/json',
        success: function (data) {
            if (data == true) {
                alert("Registration successfull")
                window.location.reload();
                // $('#myModalRegister').hide();
                //$('.modal-backdrop').remove()

            }
            else
                alert("Operation failed")
        },
        error: function () {
            alert("Error occured!!")
        }
    });
}