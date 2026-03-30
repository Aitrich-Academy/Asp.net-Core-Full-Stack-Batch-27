import * as readline from 'readline';
import {Application} from './Application';
import {Job} from './Job';



const rl = readline.createInterface
({
    input: process.stdin,
    output: process.stdout,
});







const MenuOptions: any[] =
[
    '1. All Jobs',
    '2. My Application',
    '3. Logout',
    '0. Exit'
]



let ExitProgarm = false;


class User 
{
    constructor()
    {
        
    }



     ShowMenu()
    {
        console.log("******************************************************* Welcome ********************************************************");
        

        MenuOptions.forEach((option: any) => console.log(option));

        rl.question("\n Enter your choice : ", (input : string) => 
        {
            this.SelectOption(input);

            if(ExitProgarm)
            {
                rl.close();
            }
            else
            {
                this.ShowMenu();
            }
            
        });


    }




       SelectOption(input : string)
    {
        switch(input)
        {
            case '1':
                this.AllJobs();
                break;

            case "2":
                this.MyApplication();
                break;

            case "3":
                this.LogOut();
                break;

            case '0':
                ExitProgarm = true;
                break; 

            default:
                console.log("Invalid Options");
                break;
        }
    }





     AllJobs() 
    {
        var jobsList : Job[] = 
        [
            {
                Title : "software Developer",
                Department : "IT",
                Description : ".Net Developer"
            }

            ,

            {
                Title : "Accountant",
                Department : "Finance",
                Description : "manages company accounts"
            }

        ];


                console.log("\n--------------------------------------------------Job List-----------------------------------------------\n")


        jobsList.forEach(list => 
        {
            console.log("\n Title :  " + list.Title  +  "   Department : " + list.Department  + "   Description : "+ list.Description  + "\n")
        }
        )


        console.log("\n------------------------------------------------------------------------------------------------------------\n")

    }





    MyApplication()
    {
        var ApplicationList :  Application[] = 
        [
            {
                Name : "Tony Stark",
                JobTitle : "Software Developer",
                Experience : "2 year",
            }

            
           
        ];



                 console.log("\n--------------------------------------------------Application List-----------------------------------------------\n")


        ApplicationList.forEach(list => 
        {
            console.log("\n Name : " + list.Name  +  "JobTitle : " + list.JobTitle + "Experience : "+ list.Experience + "\n")
        }
        )


        console.log("\n------------------------------------------------------------------------------------------------------------\n")




    }





    LogOut()
    {
        console.log("\n Logged out successfully \n")
        this.Login();
    }








    Login () : any
{

    console.log("\n Login \n ")

     rl.question("\n Enter your Username  :  ",(username) => 
        {
            rl.question("\n enter your password  :  " ,  (password) => 
            {
                if (username == "tony" && password == "123" )
                {
                    console.log ("\n Login successful");

                  

                    this.ShowMenu();
                    return true;
                }

                else 
                {
                    console.log('\n Invalid username or password. Please try again.!!!!!!!!!!!\n');
                    console.log('\x1b[31m%s\x1b[0m', '\u26A0', 'Error: Something went wrong!');
                    this.Login();
                }

            }  );
        });
}


}


var useruser = new User ();

useruser.Login();




















