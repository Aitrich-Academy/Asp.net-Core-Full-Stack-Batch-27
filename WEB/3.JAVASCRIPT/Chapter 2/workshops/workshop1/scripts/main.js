var jobsList=[

    {jobTitle:"Social Media Assistant",place:"Agency . Paris,France"},
    {jobTitle:"Brand Designer",place:"Agency • San Fransisco, USA"},
    {jobTitle:"Interactive Developer",place:"Agency • Hamburg, Germany"},
    {jobTitle:"Email Marketing",place:"Agency • Madrid, Spain"},
   

]

function loadData()
{
var jobTitle1=document.getElementById("jobTitle1");
var jobTitle2=document.getElementById("jobTitle2");
var jobTitle3=document.getElementById("jobTitle3");
var jobTitle4=document.getElementById("jobTitle4");


var agency1=document.getElementById("agency1");
var agency2=document.getElementById("agency2");
var agency3=document.getElementById("agency3");
var agency4=document.getElementById("agency4");


jobTitle1.innerHTML=jobsList[0].jobTitle;
agency1.innerHTML=jobsList[0].place;

jobTitle2.innerHTML=jobsList[1].jobTitle;
agency2.innerHTML=jobsList[1].place;

jobTitle3.innerHTML=jobsList[2].jobTitle;
agency3.innerHTML=jobsList[2].place;

jobTitle4.innerHTML=jobsList[3].jobTitle;
agency4.innerHTML=jobsList[3].place;


}