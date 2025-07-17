function validateForm()
{
    const name=document.getElementById('name').value.trim()
    const email=document.getElementById('email').value.trim()   
    const phone=document.getElementById('phone').value.trim() 
    const role=document.getElementById('role').value.trim() 
    const location=document.getElementById('location').value.trim() 
    const website=document.getElementById('website').value.trim() 



    const alphaRegex= /^[A-Za-z\s]+$/
    if(name==="")
    {
        alert("PLEASE ENTER YOUR NAME")
        return false
    } else if (!alphaRegex.test(name)) 
    {
        alert("ONLY LETTERS ALLOWED")
        return false
    }

    
    if(email==="")
    {
        alert("PLEASE ENTER YOUR EMAIL")
        return false
    }else if(!validateEmail(email))
    {
        alert("ENTER IN CORRECT FORMAT")
        return false
    }
    

    const phoneRegex = /^[0-9]{10}$/;
    if(phone==="")
    {
        alert("PLEASE ENTER YOUR MOBILE NUMBER")
        return false
    }else if(!phoneRegex.test(phone))
    {
        alert("PHONE NUMBER IS INCORRECT")
        return false
    }

    if(role==="")
    {
        alert("PLEASE ENTER YOUR ROLE")
        return false
    }

    if(location==="")
    {
        alert("PLEASE ENTER YOUR LOCATION")
        return false
    }

    if(website==="")
    {
        alert("PLEASE ENTER YOUR WEBSITE")
        return false
    }


    return true

}

function validateEmail(email) 
{
    const mailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return mailRegex.test(email);
}

