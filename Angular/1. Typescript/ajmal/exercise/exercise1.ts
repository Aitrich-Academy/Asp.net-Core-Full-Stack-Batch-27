import * as readline from'readline'
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
  });
  
  interface Job {
    id: number;
    jobTitle: string;
    }
  let exitProgram = false;
  const jobs:Job[] = [
    {id:1,jobTitle:'Java Developer'},
    {id:2,jobTitle:'Angular Developer'},
    {id:3,jobTitle:'ASP.Net Full Stack Developer'},
    {id:4,jobTitle:'Product Designer'}
];

  const menuOption=():void=>{
    console.log('1. All Jobs');
    console.log('2. My Applications');
    console.log('3. Logout');
    console.log('4. Exit');
    rl.question("Enter your choice:",(input:string)=>{
      switch (input) {
          case '1':
              jobsList();
              break;
          case '2':
              myApplications();
              break;  
          case '3':
              login();
              break;       
          case '0':
              exitProgram = true;
              break;
          default:
              console.log('Invalid option');
              break;
      }
      });
      }
 
 function jobsList() {
     
      console.log("\n--------------------------------------------------Jobs List-----------------------------------------------\n")
      jobs.forEach(list => {

          console.log(list);
      }

      )
      console.log("\n------------------------------------------------------------------------------------------------------------\n")

  }

  function myApplications() {
    console.log("\n--------------------------------------------------Jobs List-----------------------------------------------\n")
    jobs.forEach(list => {

        console.log(list);
    }

    )
    console.log("\n------------------------------------------------------------------------------------------------------------\n")

  }
   
  function login(): any {
      console.log("please login")
      rl.question('Enter your username: ', (username) => {

          rl.question('Enter your password: ', (password) => {
              if (username == "admin" && password == "admin123") {
                  console.log('Login successful.');
                  this.menuOption();
                  return true;

              } else {
                  console.log('Invalid username or password. Please try again.!!!!!!!!!!!\n');
                  console.log('\x1b[31m%s\x1b[0m', '\u26A0', 'Error: Something went wrong!');
                  this.login();
              }
          });
      });
  }

  function auth(): any {

      if (localStorage) {
          return true;
      }
      else {
          return this.login();
      }
  }


menuOption();



