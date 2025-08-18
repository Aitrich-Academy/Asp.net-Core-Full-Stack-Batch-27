var memberList = [
    { image: "images/manu.png", name: "Manu", job: "Job Role:Java Developer", phone: "Phone:3 year", email: "email:Bangalore" },
    { image: "images/lamiya.png", name: "Lamiya", job: "Job Role:Marketing Executive", phone: "Phone:2 Year", email: "email:Chennai" },
    { image: "images/deepak.png", name: "Alexander", job: "Job Role:HR Manager", phone: "Phone:5 Year", email: "email:Thiruvananthapuram" },
    { image: "images/manu.png", name: "Deepak Roy", job: "Job Role:System Analyst", phone: "Phone:2 Year", email: "email:Calicut" }
];

function companyMembers() {
    const contentDiv = document.getElementById('contentDiv');
    const heading=document.createElement('h1')
    heading.innerHTML="Company Members"
    heading.style.position="absolute"
    heading.style.left="400px"
    heading.style.top="0px"
    document.body.appendChild(heading)

    for (let i = 0; i < memberList.length; i += 2) {
        const row = document.createElement('div');
        row.style.display = "flex";
        row.style.gap = "90px"; 
        row.style.marginTop="100px"
        row.style.marginLeft="100px"

        for (let j = i; j < i + 2 && j < memberList.length; j++) {
            const member = memberList[j];
            
            const card = document.createElement('div');
           
            card.style.padding = "10px";
            card.style.width = "150px";
            card.style.fontFamily = "sans-serif";
            

            const img = document.createElement("img");
            img.src = member.image;
            img.style.width = "100%";

            const name = document.createElement("p");
            name.textContent = "Name: " + member.name;

            const role = document.createElement("p");
            role.style.width="500px"
            role.textContent = member.job;

            const phone = document.createElement("p");
            phone.textContent = member.phone;

            const email = document.createElement("p");
            email.textContent = member.email;

            card.appendChild(img);
            card.appendChild(name);
            card.appendChild(role);
            card.appendChild(phone);
            card.appendChild(email);

            row.appendChild(card);
        }

        contentDiv.appendChild(row);
    }
}

companyMembers();