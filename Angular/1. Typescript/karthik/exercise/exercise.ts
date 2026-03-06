


import { exit } from 'process';
import * as readline from 'readline' ;

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

let loggedInUser : user | null = null;

interface user {
    email: string;
    firstname: string;
    lastname: string;
    phoneNumber: string;
    password: string;
    gender: string;
}

const registerdUsers: user[] = [];

const initialMenu = (): void => {
    console.log('welcome Select Any Option:');
    console.log('1. Register');
    console.log('2.login');
    console.log('3.All Jobs');
    console.log('4.My Applications');
    console.log('5.LogOut');
    console.log('6.Exit');

    rl.question('Enter your choice.:' , ( choice: string) => {
        if (choice === '1') {
            register();
        }else if (choice === '2'){
            login();
        }else if (choice === '3'){
            alljobs();
        }else if (choice === '4'){
            myapplications();
        }else if (choice === '5'){
            logout();
        }else if (choice === '6'){
            exit();
        }else  {
            console.log('Invalid choice. Please try again.');
            initialMenu();
          }
    });
};


const alljobs = (): void => {
    console.log('Alljobs :'
        ,{
            title: 'Juniour Process Associate',
            companyName : 'Aitrich Technologies',
            description: 'Product designer responsibilities include defining product specifications, creating digital or print drawing and desinging fully-functional products',
            location: 'Indonesia',
            employmentType: 'Full Time',
            experienceLevel: 'Mid Level',
            salaryRange: '$3000 - $5000'
        },
  
        {
            title: 'Customer Service Executive',
            companyName : 'ciinfosys',
            description: 'Product designer responsibilities include defining product specifications, creating digital or print drawing and desinging fully-functional products',
            location: 'Indonesia',
            employmentType: 'Full Time',
            experienceLevel: 'Mid Level',
            salaryRange: '$3000 - $5000'
        },
    );
 initialMenu();
}

const myapplications = (): void => {
    console.log('My Application :'
        ,{
            title: 'Juniour Process Associate',
            companyName : 'Aitrich Technologies',
            description: 'Product designer responsibilities include defining product specifications, creating digital or print drawing and desinging fully-functional products',
            location: 'Indonesia',
            employmentType: 'Full Time',
            experienceLevel: 'Mid Level',
            salaryRange: '$3000 - $5000'
        },
  
        {
            title: 'Customer Service Executive',
            companyName : 'ciinfosys',
            description: 'Product designer responsibilities include defining product specifications, creating digital or print drawing and desinging fully-functional products',
            location: 'Indonesia',
            employmentType: 'Full Time',
            experienceLevel: 'Mid Level',
            salaryRange: '$3000 - $5000'
        },
  
        {
            title: 'Customer Service Executive',
            companyName : 'Infotech',
            description: 'Product designer responsibilities include defining product specifications, creating digital or print drawing and desinging fully-functional products',
            location: 'Indonesia',
            employmentType: 'Full Time',
            experienceLevel: 'Mid Level',
            salaryRange: '$3000 - $5000'
        }
    );
}

const register = (): void => {
    console.log('Registration:');
    
    rl.question('First name: ', (firstname: string) => {
        rl.question('last name:', (lastname: string) =>{
            rl.question('phone Number:', (PhoneNumber: string) =>{
                rl.question('password:', (Password: string) =>{
                    rl.question('cofirm password:', (confirmPassword : string)=> {
                        rl.question('genter:', (gender : string) =>{


                            const NewUser: user = {
                                firstname,
                                lastname,
                                gender,
                                email: '',
                                phoneNumber: '',
                                password: ''
                            };

                            registerdUsers.push(NewUser);
                            console.log('Registration successful!');

                            redirectMenu();
                        })
                    })
                })
            })
        })
    })
};

const redirectMenu = (): void => {
    rl.question('Redirect to previous menu? (Y/N):', (choice : string) => {
        if (choice.toLowerCase() === 'y'){
           initialMenu();
        }else if (choice.toLowerCase() === 'n'){
            exit();
        }else{
            console.log('Invalid choice. Exiting..');
            exit();
        }
    });
};


const login = (): void => {
    console.log('Login:');
    
    rl.question('Email: ', (email: string) => {
      rl.question('Password: ', (password: string) => {
        
        const user = registerdUsers.find(
          (u) => u.email === email && u.password === password
        );
  
        if (user) {
          console.log('Login successful!');
          loggedInUser = user;
  
          loggedInMenu();
        } else {
          console.log('Invalid email or password. Please try again.');
          login();
        }
      });
    });
  };

  const loggedInMenu = () : void => {
    console.log('Logeed-in menu:');
    console.log('2. Logout');

    rl.question('Enter your choice: ', (choice: string) => {
        if (choice === '1'){
        } else if (choice === '2'){
            logout();
        }else{
            console.log('Invalid choice. try again.');
            loggedInMenu();
        }
    });
  };

  const logout = (): void => {
    console.log('Exiting...');
    rl.close();
  };

  initialMenu();




