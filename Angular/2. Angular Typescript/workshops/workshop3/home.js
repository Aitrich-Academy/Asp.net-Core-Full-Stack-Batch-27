"use strict";
var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
Object.defineProperty(exports, "__esModule", { value: true });
var readline = require("readline");
var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});
var loggedInUser = null;
var registeredUsers = [];
// Initial menu options
var initialMenu = function () {
    console.log('Welcome! Please select an option:');
    console.log('1. Register');
    console.log('2. Login');
    console.log('3. Exit');
    rl.question('Enter your choice: ', function (choice) {
        if (choice === '1') {
            register();
        }
        else if (choice === '2') {
            login();
        }
        else if (choice === '3') {
            exit();
        }
        else {
            console.log('Invalid choice. Please try again.');
            initialMenu();
        }
    });
};
// Register function
var register = function () {
    console.log('Registration:');
    rl.question('First name: ', function (firstName) {
        rl.question('Last name: ', function (lastName) {
            rl.question('Email: ', function (email) {
                rl.question('Phone number: ', function (phoneNumber) {
                    rl.question('Password: ', function (password) {
                        rl.question('Confirm password: ', function (confirmPassword) {
                            rl.question('Gender: ', function (gender) {
                                // Perform registration logic here
                                var newUser = {
                                    firstName: firstName,
                                    lastName: lastName,
                                    email: email,
                                    phoneNumber: phoneNumber,
                                    password: password,
                                    gender: gender
                                };
                                registeredUsers.push(newUser);
                                console.log('Registration successful!');
                                redirectMenu();
                            });
                        });
                    });
                });
            });
        });
    });
};
// Redirect to previous menu
var redirectMenu = function () {
    rl.question('Redirect to previous menu? (Y/N): ', function (choice) {
        if (choice.toLowerCase() === 'y') {
            initialMenu();
        }
        else if (choice.toLowerCase() === 'n') {
            exit();
        }
        else {
            console.log('Invalid choice. Exiting...');
            exit();
        }
    });
};
// Login function
var login = function () {
    console.log('Login:');
    rl.question('Email: ', function (email) {
        rl.question('Password: ', function (password) {
            // Perform login logic here
            var user = registeredUsers.find(function (u) { return u.email === email && u.password === password; });
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
// Logged-in menu options
var loggedInMenu = function () {
    console.log('1. viewprofile');
    console.log('2. Update Profile');
    console.log('3. Logout');
    rl.question('Enter your choice: ', function (choice) {
        if (choice === '1') {
            viewprofile();
        }
        else if (choice === '2') {
            updateProfile();
        }
        else if (choice === '3') {
            logout();
        }
        else {
            console.log('Invalid choice. Please try again.');
            loggedInMenu();
        }
    });
};
//viewprofile
function viewprofile() {
    console.log('MY PROFILE...!');
    registeredUsers.forEach(function (reg) {
        console.log("name  : ".concat(reg.firstName));
        console.log("lastname :".concat(reg.lastName));
        console.log(" email: ".concat(reg.email));
        console.log(" phone number: ".concat(reg.phoneNumber));
        console.log(" gender: ".concat(reg.gender));
    });
}
// Update profile function
var updateProfile = function () {
    console.log('Update Profile:');
    rl.question('First name: ', function (firstName) {
        rl.question('Last name: ', function (lastName) {
            rl.question('Email: ', function (email) {
                rl.question('Phone number: ', function (phoneNumber) {
                    rl.question('Password: ', function (password) {
                        rl.question('Confirm password: ', function (confirmPassword) {
                            rl.question('Gender: ', function (gender) {
                                // Perform update profile logic here
                                loggedInUser = __assign(__assign({}, loggedInUser), { firstName: firstName, lastName: lastName, email: email, phoneNumber: phoneNumber, password: password, gender: gender });
                                console.log('Profile updated successfully!');
                                loggedInMenu();
                            });
                        });
                    });
                });
            });
        });
    });
};
// Logout function
var logout = function () {
    console.log('Logging out...');
    loggedInUser = null;
    initialMenu();
};
// Exit function
var exit = function () {
    console.log('Exiting...');
    rl.close();
};
// Start the initial menu
initialMenu();
