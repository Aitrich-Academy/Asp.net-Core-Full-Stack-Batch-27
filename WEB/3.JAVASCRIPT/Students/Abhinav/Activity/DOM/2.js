let btn = null;                 //button golbally

function showButton(text) {                             //btn
    if (!btn) {
        btn = document.createElement("button")
        btn.style.position = "absolute"
        btn.style.top = "820px"
        btn.style.left = "610px"
        btn.style.width = "700px"
        btn.style.height = "40px"
        btn.style.borderRadius = "20px"
        btn.style.cursor = "pointer"
        btn.style.fontFamily = "sans-serif"
        btn.style.fontSize = "30px"
        btn.style.color = "white"
        btn.style.fontWeight="bold"
        btn.style.background = "linear-gradient(to right, #cc0099, #6666ff)"
        document.body.appendChild(btn);
    }
    
    
    btn.innerHTML = text;           //update

    btn.onclick = function () {                 //new window
         window.open("super.html", "_blank")
    }


}
function superradio() {                                 //super btn
    showButton("Continue with Super")
    btn.style.color="silver"
}

function premiumradio() {                           //premium btn
    showButton("Continue with Premium")
    btn.style.color="darkgoldenrod"
    
}
