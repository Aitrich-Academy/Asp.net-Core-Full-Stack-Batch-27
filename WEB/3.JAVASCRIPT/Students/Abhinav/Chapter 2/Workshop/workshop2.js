function showForm(val)
{


    if(val=="myButton1")
    {
        var skillId=document.getElementById('myTextBox')
        var skillButton=document.getElementById('myButton')
        skillId.style.display="block"
        skillButton.style.display="block"
    }
    else if(val=="myButton2")
    {
        var eduId=document.getElementById('eduTextBox')
        var eduButton=document.getElementById('eduButton')
        eduId.style.display="block"
        eduButton.style.display="block"
    }
    else if(val=='myButton3')
    {
        var meId=document.getElementById('meTextBox')
        var meButton=document.getElementById('meButton')
        meId.style.display="block"
        meButton.style.display="block"
    }
    else if(val=='myButton4')
    {
        var expId=document.getElementById('expTextBox')
        var expButton=document.getElementById('expButton')
        expId.style.display="block"
        expButton.style.display="block"
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
       
        var li = document.createElement('li');

         li.textContent = skills[i];

        listId.appendChild(li);
        textBox.value='';

    }
    }
    else if(text=="edu")
    {
        var data=document.getElementById('eduTextBox').value
        var textBox=document.getElementById('eduTextBox')
        var listId=document.getElementById('eduList')
        var edu=[]
        edu.push(data)
        console.log(edu)

        for(i=0;i<edu.length;i++)
        {
            var li=document.createElement('li')
            li.textContent=edu[i]
            listId.appendChild(li)
            textBox.value=''
        }
    }
    else if(text=="me")
    {
        var data=document.getElementById('meTextBox').value
        var textBox=document.getElementById('meTextBox')
        var listId=document.getElementById('meList')
        var me=[]
        me.push(data)
        console.log(me)

        for(i=0;i<me.length;i++)
        {
            var li=document.createElement('li')
            li.textContent=me[i]
            listId.appendChild(li)
            textBox.value=''
        }
    }
    else if(text=="exp")
    {
        var data=document.getElementById('expTextBox').value
        var textBox=document.getElementById('expTextBox')
        var listId=document.getElementById('expList')
        var exp=[]
        exp.push(data)
        console.log(exp)

        for(i=0;i<exp.length;i++)
        {
            var li=document.createElement('li')
            li.textContent=exp[i]
            listId.appendChild(li)
            textBox.value=''
        }
    }

}