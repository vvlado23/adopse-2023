$(".Log").addEventListener("onclick", function Login() {
    var password = document.getElementsByClassName("PT").vaue;
    var username = document.getElementsByClassName("UT").value;
    UserAuth.LoginUser(username, password);
})

$(".Reg").addEventListener("onclick", function Register() {
        var email = document.getElementsByClassName("Mail").value;
        var username = document.getElementsByClassName("UT").value;
        var password = document.getElementsByClassName("PT").value;
        UserAuth.RegisterUser(email, username, password);
    })