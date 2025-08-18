function validateUser()
{
    
    var email=document.getElementById("email").value;
    var password=document.getElementById("password").value;
    if(email=="" ||  email==null)
    {
        alert("Please Enter Your Email ");
        return false;
    }
    if(password=="" ||  password==null)
    {
        alert("Please Enter Your Password ");
        return false;
    }
  

}

function loginCheck()
{
    var email=document.getElementById("email").value;
    var password=document.getElementById("password").value;
    event.preventDefault();
    
    
    if(email== "lessile@gmail.com" && password=="1234")
    {
        window.location = "./profile.html";
        
        return true;
    }
    else{
        alert("invalid email or password");
        return false;
    }
}

