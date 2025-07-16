var applicantList = [
    { name: "Alex", image: "images/m1.png",  experience: "2 years" },
    { name: "Ameya", image: "./images/m2.png",  experience: "2 years" },
    { name: "Ommer", image: "./images/m1.png", experience: "4 years" },
];
listApplicants();
function listApplicants() {
    var contentDiv = document.getElementById('card');
    var content = document.getElementById('content');
   
   for(let value in applicantList) {

        //creating div for each item in the array
        var cardDiv = document.createElement('p');
        var image = document.createElement('img');
        image.src = applicantList[value].image;
        var name=document.createElement('b');
        name.textContent = applicantList[value].name;
        var experience=document.createElement('p');
        experience.textContent=applicantList[value].experience;
        // console.log(item.image);
        cardDiv.appendChild(image);
        cardDiv.appendChild(name);
        cardDiv.appendChild(experience);
        contentDiv.appendChild(cardDiv);
   
   }
    
}
