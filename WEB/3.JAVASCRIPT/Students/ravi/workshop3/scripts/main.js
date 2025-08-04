var applicantList = [
    { name: "Alex", image: "images/m1.png",  experience: "2 years",location:"thrissur" ,qualification:"btech"},
    { name: "Ameya", image: "./images/m2.png",  experience: "2 years",location:"palakkad" ,qualification:"MCA" },
    { name: "Ommer", image: "./images/m1.png", experience: "4 years",location:"Kochi" ,qualification:"BCA" }
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
        var location=document.createElement('p');
        location.textContent=applicantList[value].location;
        var qualification=document.createElement('p')
        qualification.textContent=applicantList[value].qualification;
        var experience=document.createElement('p');
        experience.textContent=applicantList[value].experience;
        // console.log(item.image);
        cardDiv.appendChild(image);
        cardDiv.appendChild(name);
        cardDiv.appendChild(location);
        cardDiv.appendChild(qualification);
        cardDiv.appendChild(experience);
        
        contentDiv.appendChild(cardDiv);
        
   
   }
    
}
