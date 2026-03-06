"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var readline = require("readline");
var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});
var companies = [
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
    rl.question('Enter First Name: ', function (firstName) {
        rl.question('Enter Last name: ', function (lastName) {
            rl.question('Enter email: ', function (email) {
                rl.question('Enter Phone number: ', function (phoneNumber) {
                    rl.question('Enter Designation: ', function (designation) {
                        rl.question('Enter User id: ', function (userId) {
                            rl.question('Enter Password: ', function (password) {
                                rl.question('Enter Confirm password: ', function (confirmPassword) {
                                    var member = companies.find(function (c) { return c.userId === userId; });
                                    if (!member) {
                                        if (password === confirmPassword) {
                                            var newMember = {
                                                firstName: firstName,
                                                lastName: lastName,
                                                email: email,
                                                phoneNumber: phoneNumber,
                                                designation: designation,
                                                userId: userId,
                                                password: password,
                                                confirmPassword: confirmPassword
                                            };
                                            companies.push(newMember);
                                            console.log('Company member registered successfully!');
                                        }
                                        else {
                                            console.log('password not match with confirm password');
                                        }
                                    }
                                    else {
                                        console.log('UerId already exist!');
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
    rl.question('Enter userId: ', function (userId) {
        rl.question('Enter password: ', function (password) {
            var company = companies.find(function (c) { return c.userId === userId && c.password === password; });
            if (company) {
                console.log('Login successful!');
                listCompanyMember();
            }
            else {
                console.log('Invalid email or password.');
                menu();
            }
        });
    });
}
function menu() {
    console.log('1.REGISTRATION OF COMPANY MEMBER \n 2.LOGIN\n 3.LOG OUT');
    rl.question('Enter your Choice: ', function (choice) {
        switch (choice) {
            case '1':
                registerCompanyMember();
                break;
            case '2':
                login();
                break;
            case '3':
                exit();
                break;
            default:
                console.log('Wrong choice!');
                break;
        }
    });
}
function listCompanyMember() {
    console.log('Members List');
    console.log('----------------------');
    companies.forEach(function (companies) {
        console.log("First name: ".concat(companies.firstName, "\nLast Name: ").concat(companies.lastName, "\nEmail: ").concat(companies.email, "\nPhoneNumber:").concat(companies.phoneNumber, "\n Designation:").concat(companies.designation, "\nUser Id:").concat(companies.userId));
    });
    submenu();
}
function submenu() {
    console.log('----------------------');
    console.log('1.ADD MEMBER\n  2.REMOVE MEMBER\n4.LOG OUT');
    rl.question('Enter your Choice :', function (choice) {
        switch (choice) {
            case "1":
                registerCompanyMember();
                break;
            case "2":
                removeMember();
                break;
            case "4":
                exit();
                break;
            default: console.log('wrong choice');
        }
    });
}
function removeMember() {
    rl.question('Enter User Id: ', function (userId) {
        var index = companies.findIndex(function (company) { return company.userId === userId; });
        if (index !== -1) {
            companies.splice(index, 1);
            console.log("Member removed successfully.");
        }
        else {
            console.log("Member not found.");
        }
        listCompanyMember();
    });
}
function exit() {
    console.log('Exiting the program...');
    rl.close();
    process.exit();
}
menu();
