import * as readline from 'readline';
import {Applicants} from './Applicants';
import {Interview} from './Interview';



const rl = readline.createInterface
({
    input: process.stdin,
    output: process.stdout,
});



const MenuOptions = 
[
    '1. Show Applicants List',
    '2. Schedule Interview',
    '3. Show Scheduled InterviewList',
    '0. Exit'
];

let ExitProgarm = false;

var obj = Interview;

let InterviewList : Interview [] = [];

var localStorage : string = "";

class JobProvider 
{
    constructor()
    {

    }

    ShowMenu()
    {
        console.log("******************************************************* Welcome To Job Portal********************************************************");
        

        MenuOptions.forEach(option => console.log(option));

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
                this.ApplicantList();
                break;

            case "2":
                this.ScheduleInterview();
                break;

            case "3":
                this.ScheduledInterviewList();
                break;

            case '0':
                ExitProgarm = true;
                break; 

            default:
                console.log("Invalid Options");
                break;
        }
    }


    ApplicantList()
    {

        var ApplicantList : Applicants[]=
        [{

             Name: "John Wick",
             JobTitle : "Java Developer",
             Qualification : "Bca",
             Experience : "2 years"
        },

        {
             Name: "Tony Stark",
             JobTitle : "AI & Robotics Engineer",
             Qualification : "PhD in Artificial Intelligence",
             Experience : "7 years"
        },

        {
             Name: "Stephen Strange",
             JobTitle : "Sorcerer Supreme",
             Qualification : "Master Mystic Arts",
             Experience : "4 years"
        }
    ];

        console.log("\n--------------------------------------------------Applicants List-----------------------------------------------\n")

        ApplicantList.forEach(list => 
        {
            console.log("Name :    "    + list.Name  + "JobTiTle :    "    + list.JobTitle +  "      Qualification :      "      +     list.Qualification      +      "      Experience :     "      +        list.Experience   +    "\n")
        }
        )

        console.log("\n------------------------------------------------------------------------------------------------------------\n")
    }





    ScheduleInterview()
    {
        var result : any = this.Auth();

        if(result)
        {
            console.log("-------------------------Interview Schedule------------------");

                rl.question("\n Enter Job Title : " , (JobTitle) => 
                {
                    rl.question("\n Enter Interview Date :", (interviewdate)=>
                    {
                        const DateOfInterview :Date = new Date (interviewdate);

                        rl.question("\n enter interview time :",(Time) =>
                        {
                            rl.question("\n enter interview Mode : ", (ModeOfInterview) =>
                            {
                                const interviewdata : Interview =
                                {
                                    JobTitle,
                                    DateOfInterview,
                                    Time,
                                    ModeOfInterview
                                };

                                InterviewList.push(interviewdata);
                                this.ShowMenu();

                            } );
                            
                        });

                    });

                } );

        }
        else 
        {
            this.Login();
        }

    }


    Login() : any 
    {
        console.log("\nplease login")

        rl.question("\nEnter your Username",(username) => 
        {
            rl.question("\nenter your password" ,  (password) => 
            {
                if (username == "admin" && password == "password" )
                {
                    console.log ("\nLogin successful");

                    localStorage = "admin";

                    this.ScheduleInterview();
                    return true;
                }

                else 
                {
                    console.log('Invalid username or password. Please try again.!!!!!!!!!!!\n');
                    console.log('\x1b[31m%s\x1b[0m', '\u26A0', 'Error: Something went wrong!');
                    this.Login();
                }

            }  );
        });
    }



    Auth() : any 
    {
        if (localStorage)
        {
            return true;
        }
        else 
        {
            return this.Login
        }
    }



      ScheduledInterviewList()  
     {
        InterviewList.forEach((job) =>
        {
            console.log(` \n\n job Title   :   ${job.JobTitle}`);
            console.log(`\n Date of interview   :   ${job.DateOfInterview}`);
            console.log(` \n Time   :   ${job.Time}`);
            console.log(`\n mode of interview   :   ${job.ModeOfInterview}\n\n`);
        } );
     }


        
    }


    

     var jobProviderRef = new JobProvider();
    jobProviderRef.ShowMenu();










