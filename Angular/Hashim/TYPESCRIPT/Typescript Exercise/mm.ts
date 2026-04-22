import * as readline from 'readline';

const r1 = readline.createInterface({
    input:process.stdin,
    output:process.stdout
});

interface User{
    username:string;
    password:string;
}

interface Job{
    id:number;
    title:string;
}

const users:User[] =[
    {username:"user",password:"123"}
];

const jobs:Job[] =[
    {id:1,title:"Software developer"},
    {id:2,title:".Net developer"},
    {id:3,title:"Front-end developer"}
];

let myApplication:Job[] =[];
let loggedUserIn: User| null = null; 

function Menu()
{
    console.log("1. Login");
    console.log("2. Exist");

     r1.question("Choose option: ", (choice) => {

        if (choice === "1") {
            r1.question("Username: ", (u) => {
                r1.question("Password: ", (p) => {

                    const user = users.find(
                        (x) => x.username === u && x.password === p
                    );

                    if (user) {
                        loggedUserIn = user;
                        console.log("\nLogin Successful!");
                        mainMenu();
                    } else {
                        console.log("Invalid Credentials");
                        Menu();
                    }

                });
            });

        } else if (choice === "2") {
            r1.close();
        } else {
            Menu();
        }
    });

}
function mainMenu() {
    console.log("\n----- MAIN MENU -----");
    console.log("1. All Jobs");
    console.log("2. My Applications");
    console.log("3. Logout");
    console.log("4. Exit");

    r1.question("Choose option: ", (choice) => {

        if (choice === "1") {
            showAllJobs();
        }

        else if (choice === "2") {
            showMyApplications();
        }

        else if (choice === "3") {
            loggedUserIn = null;
            console.log("Logged out.");
            Menu();
        }

        else if (choice === "4") {
            r1.close();
        }

        else {
            mainMenu();
        }
    });
}
function showAllJobs() {

    console.log("\nAvailable Jobs:");

    jobs.forEach(j => {
        console.log(`${j.id}. ${j.title}`);
    });

    r1.question("Enter Job id to Apply : ", (id) => {

        const job = jobs.find(j => j.id === Number(id));

        if (Number(id) === 0) {
            mainMenu();
        }
        else if (job) {
            myApplication.push(job);
            console.log("Application Submitted!");
            mainMenu();
        }
        else {
            console.log("Invalid Job id");
            mainMenu();
        }

    });
}
function showMyApplications() {

    console.log("\nMy Applications:");

    if (myApplication.length === 0) {
        console.log("No applications yet.");
    } 
    else {
        myApplication.forEach(job => {
            console.log(`${job.id}. ${job.title}`);
        });
    }

    mainMenu();
}

Menu();