"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var process_1 = require("process");
var readline = require("readline");
var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});
var loggedInUser = null;
var registerdUsers = [];
var initialMenu = function () {
    console.log('welcome Select Any Option:');
    console.log('1. Register');
    console.log('2.login');
    console.log('3.All Jobs');
    console.log('4.My Applications');
    console.log('5.LogOut');
    console.log('6.Exit');
    rl.question('Enter your choice.:', function (choice) {
        if (choice === '1') {
            register();
        }
        else if (choice === '2') {
            login();
        }
        else if (choice === '3') {
            alljobs();
        }
        else if (choice === '4') {
            myapplications();
        }
        else if (choice === '5') {
            logout();
        }
        else if (choice === '6') {
            (0, process_1.exit)();
        }
        else {
            console.log('Invalid choice. Please try again.');
            initialMenu();
        }
    });
};
var alljobs = function () {
    console.log('Alljobs :', {
        title: 'Juniour Process Associate',
        companyName: 'Aitrich Technologies',
        description: 'Product designer responsibilities include defining product specifications, creating digital or print drawing and desinging fully-functional products',
        location: 'Indonesia',
        employmentType: 'Full Time',
        experienceLevel: 'Mid Level',
        salaryRange: '$3000 - $5000'
    }, {
        title: 'Customer Service Executive',
        companyName: 'ciinfosys',
        description: 'Product designer responsibilities include defining product specifications, creating digital or print drawing and desinging fully-functional products',
        location: 'Indonesia',
        employmentType: 'Full Time',
        experienceLevel: 'Mid Level',
        salaryRange: '$3000 - $5000'
    });
    initialMenu();
};
var myapplications = function () {
    console.log('My Application :', {
        title: 'Juniour Process Associate',
        companyName: 'Aitrich Technologies',
        description: 'Product designer responsibilities include defining product specifications, creating digital or print drawing and desinging fully-functional products',
        location: 'Indonesia',
        employmentType: 'Full Time',
        experienceLevel: 'Mid Level',
        salaryRange: '$3000 - $5000'
    }, {
        title: 'Customer Service Executive',
        companyName: 'ciinfosys',
        description: 'Product designer responsibilities include defining product specifications, creating digital or print drawing and desinging fully-functional products',
        location: 'Indonesia',
        employmentType: 'Full Time',
        experienceLevel: 'Mid Level',
        salaryRange: '$3000 - $5000'
    }, {
        title: 'Customer Service Executive',
        companyName: 'Infotech',
        description: 'Product designer responsibilities include defining product specifications, creating digital or print drawing and desinging fully-functional products',
        location: 'Indonesia',
        employmentType: 'Full Time',
        experienceLevel: 'Mid Level',
        salaryRange: '$3000 - $5000'
    });
};
var register = function () {
    console.log('Registration:');
    rl.question('First name: ', function (firstname) {
        rl.question('last name:', function (lastname) {
            rl.question('phone Number:', function (PhoneNumber) {
                rl.question('password:', function (Password) {
                    rl.question('cofirm password:', function (confirmPassword) {
                        rl.question('genter:', function (gender) {
                            var NewUser = {
                                firstname: firstname,
                                lastname: lastname,
                                gender: gender,
                                email: '',
                                phoneNumber: '',
                                password: ''
                            };
                            registerdUsers.push(NewUser);
                            console.log('Registration successful!');
                            redirectMenu();
                        });
                    });
                });
            });
        });
    });
};
var redirectMenu = function () {
    rl.question('Redirect to previous menu? (Y/N):', function (choice) {
        if (choice.toLowerCase() === 'y') {
            initialMenu();
        }
        else if (choice.toLowerCase() === 'n') {
            (0, process_1.exit)();
        }
        else {
            console.log('Invalid choice. Exiting..');
            (0, process_1.exit)();
        }
    });
};
var login = function () {
    console.log('Login:');
    rl.question('Email: ', function (email) {
        rl.question('Password: ', function (password) {
            var user = registerdUsers.find(function (u) { return u.email === email && u.password === password; });
            if (user) {
                console.log('Login successful!');
                loggedInUser = user;
                loggedInMenu();
            }
            else {
                console.log('Invalid email or password. Please try again.');
                login();
            }
        });
    });
};
var loggedInMenu = function () {
    console.log('Logeed-in menu:');
    console.log('2. Logout');
    rl.question('Enter your choice: ', function (choice) {
        if (choice === '1') {
        }
        else if (choice === '2') {
            logout();
        }
        else {
            console.log('Invalid choice. try again.');
            loggedInMenu();
        }
    });
};
var logout = function () {
    console.log('Exiting...');
    rl.close();
};
initialMenu();
