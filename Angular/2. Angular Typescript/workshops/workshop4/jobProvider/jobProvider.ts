import * as readline from 'readline';
const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});
interface Company {
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string;
  designation: string;
  userId: string;
  password: string;
  confirmPassword:string;
}


const companies: Company[] = [
  
    {
      firstName: "John",
      lastName: "Doe",
      email: "john.doe@example.com",
      phoneNumber: "1234567890",
      designation: "Manager",
      userId: "johndoe123",
      password: "password123",
      confirmPassword: "password123",
    },
    {
      firstName: "Jane",
      lastName: "Smith",
      email: "jane.smith@example.com",
      phoneNumber: "9876543210",
      designation: "Supervisor",
      userId: "janesmith456",
      password: "qwerty123",
      confirmPassword: "qwerty123",
    },
    // Add more members as needed...
  ];
  
 
function registerCompanyMember() {
  console.log('Registration');
  console.log('-------------');
  rl.question('Enter First Name: ', (firstName: string) => {
    rl.question('Enter Last name: ', (lastName: string) => {
      rl.question('Enter email: ', (email: string) => {
        rl.question('Enter Phone number: ', (phoneNumber:string) => {
          rl.question('Enter Designation: ', (designation: string) => {
            rl.question('Enter User id: ', (userId: string) => {
              rl.question('Enter Password: ', (password: string) => {
                rl.question('Enter Confirm password: ', (confirmPassword: string) => {
                  const member =companies.find(
                  (c) => c.userId === userId);
                if (!member) {
                  if(password===confirmPassword){
                  const newMember: Company = {
                    firstName,
                    lastName,
                    email,
                    phoneNumber,
                    designation,
                    userId,
                    password,
                    confirmPassword
                  };
                  companies.push(newMember);
                     console.log('Company member registered successfully!');
                }
                else{
                  console.log('password not match with confirm password');
                }
              }
              else{
                console.log('UerId already exist!')
              }
                menu();
               });
              });
            });
          });
        });
      });
    });
});
} 
function login() {
  rl.question('Enter userId: ', (userId: string) => {
    rl.question('Enter password: ', (password: string) => {
      const company =companies.find((c) => c.userId === userId && c.password === password);
      if (company) {
        console.log('Login successful!');
        listCompanyMember();
      } else {
        console.log('Invalid email or password.');
        menu();
      }
       
    });
  });
}
function menu()
{
  console.log('1.REGISTRATION OF COMPANY MEMBER \n 2.LOGIN\n 3.LOG OUT');
  rl.question('Enter your Choice: ', (choice: string) => {
   switch(choice){
  case '1':registerCompanyMember();

      break;
  case '2':login();

      break;
  case '3':exit();
    break;
  default:console.log('Wrong choice!');
    break;
}
});
}
  
function listCompanyMember(){
  console.log('Members List');
  console.log('----------------------');
  companies.forEach((companies) => {
    console.log(`First name: ${companies.firstName}\nLast Name: ${companies.lastName}\nEmail: ${companies.email}\nPhoneNumber:${companies.phoneNumber}\n Designation:${companies.designation}\nUser Id:${companies.userId}`);
  });
  submenu();``
}
function submenu()
{
  console.log('----------------------');
  console.log('1.ADD MEMBER\n  2.REMOVE MEMBER\n4.LOG OUT');
    rl.question('Enter your Choice :',(choice:string) => {
    switch(choice){
      case "1":registerCompanyMember();
               break;
      case "2":removeMember();
               break;
      case "4":exit();
              break;
              default:console.log('wrong choice');
    }
});
}
function removeMember(){
  rl.question('Enter User Id: ', (userId: string) => {
    const index =companies.findIndex((company) => company.userId === userId);
    if (index !== -1) {
      companies.splice(index, 1);
      console.log("Member removed successfully.");
         
    } else {
      console.log("Member not found.");
      
    }
    listCompanyMember();
     
  });

 
}

function exit(): void {
  console.log('Exiting the program...');
  rl.close();
  process.exit();
}

menu();
