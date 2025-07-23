const newLocal = "Agency ";
var jobsList=[

    {jobTitle:"Social Media Assistant",place:"Agency . Paris,France"},
    {jobTitle:"Brand Designer",place:"Agency • San Fransisco, USA"},
    {jobTitle:"Interactive Developer",place:"Agency • Hamburg, Germany"},
    {jobTitle:"Email Marketing",place:"Agency • Madrid, Spain"},
    {jobTitle:"Lead Engineer",place:"Agency • Ankara, Turkey"},
    {jobTitle:"Product Designer",place:"Agency • Berlin, Germany"},
    {jobTitle:"Customer Manager",place:"Agency • Berlin, Germany"},
   

]

function loadData()
{
var jobTitle1=document.getElementById("jobTitle1");
var jobTitle2=document.getElementById("jobTitle2");
var jobTitle3=document.getElementById("jobTitle3");
var jobTitle4=document.getElementById("jobTitle4");
var jobTitle5=document.getElementById("jobTitle5");
var jobTitle6=document.getElementById("jobTitle6");
var jobTitle7=document.getElementById("jobTitle7");


var agency1=document.getElementById("agency1");
var agency2=document.getElementById("agency2");
var agency3=document.getElementById("agency3");
var agency4=document.getElementById("agency4");
var agency5=document.getElementById("agency5");
var agency6=document.getElementById("agency6");
var agency7=document.getElementById("agency7");


jobTitle1.innerHTML=jobsList[0].jobTitle;
agency1.innerHTML=jobsList[0].place;

jobTitle2.innerHTML=jobsList[1].jobTitle;
agency2.innerHTML=jobsList[1].place;

jobTitle3.innerHTML=jobsList[2].jobTitle;
agency3.innerHTML=jobsList[2].place;

jobTitle4.innerHTML=jobsList[3].jobTitle;
agency4.innerHTML=jobsList[3].place;

jobTitle5.innerHTML=jobsList[4].jobTitle;
agency5.innerHTML=jobsList[4].place;

jobTitle6.innerHTML=jobsList[5].jobTitle;
agency6.innerHTML=jobsList[5].place;

jobTitle7.innerHTML=jobsList[6].jobTitle;
agency7.innerHTML=jobsList[6].place;

}