function showForm(buttonVal)
{
    var id=document.getElementById('myTextBox');
    
    var skillButton=document.getElementById('myButton');


    if(buttonVal=="myButton1")
    {
    id.style.display='block';
    skillButton.style.display='block';
    }

    else if(buttonVal=="myButton2")
    {

        var id=document.getElementById('eduTextBox');
        var eduButton=document.getElementById('eduButton');
        id.style.display='block';
        eduButton.style.display='block';
    }

    
}

function add(text)
{
    if(text=="skill")
    {
    var data=document.getElementById('myTextBox').value;
    var textBox=document.getElementById('myTextBox');
    var listId=document.getElementById('skillList');
    var skills=[]
    skills.push(data);
    console.log(skills);
    for(i=0;i<skills.length;i++)
    {
        // Create a new list item
        var li = document.createElement('li');

         // Set the text content of the list item
            li.textContent = skills[i];

             // Append the list item to the list element
             listId.appendChild(li);
             textBox.value='';

    }
}

// else if(text=="edu")
// {

//     var data=document.getElementById('eduTextBox').value;
//     var textBox=document.getElementById('eduTextBox');
//     var listId=document.getElementById('eduList');
//     var edu=[]
//     edu.push(data);
//     console.log(edu);
//     for(i=0;i<edu.length;i++)
//     {
//         // Create a new list item
//         var li = document.createElement('li');

//          // Set the text content of the list item
//             li.textContent = edu[i];

//              // Append the list item to the list element
//              listId.appendChild(li);
//              textBox.value='';

//     }
// }

}