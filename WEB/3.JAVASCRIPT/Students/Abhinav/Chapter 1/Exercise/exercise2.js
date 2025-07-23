document.getElementById("inp1").addEventListener("keydown", function (event) {
    if (event.key === "Enter") 
        {
            const message = this.value.trim()
            if (message !== "") 
            {
            const msgBox = document.createElement("div");
            msgBox.style.width = "fit-content";
            msgBox.style.padding = "10px";
            msgBox.style.backgroundColor = "steelblue";
            msgBox.style.color = "white";
            msgBox.style.borderRadius = "10px";
            msgBox.style.fontFamily = "sans-serif";
            msgBox.style.margin = "10px";
            msgBox.style.marginLeft = "auto";
            msgBox.style.position = "relative";
            msgBox.style.top="580px"
            msgBox.innerText = message;

            const triangle = document.createElement("div");
            triangle.style.width = "0";
            triangle.style.height = "0";
            triangle.style.borderTop = "10px solid transparent";
            triangle.style.borderBottom = "10px solid transparent";
            triangle.style.borderLeft = "10px solid steelblue";
            triangle.style.position = "absolute";
            triangle.style.top = "10px";
            triangle.style.right = "-8px";
            triangle.style.transform="skewX(-530deg)"
            msgBox.appendChild(triangle);
            document.getElementById('chat').appendChild(msgBox);

            this.value = "";
            
        }
    }
});





