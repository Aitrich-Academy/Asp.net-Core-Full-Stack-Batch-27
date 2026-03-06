"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var readline = require("readline");
var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout,
});
var loggedInUser = null;
var listJobs = [];
var registeredUsers = [];
var jobs = [
    { jobId: 1, jobTitle: 'ASP.Net Full Stack Developer' },
    { jobId: 2, jobTitle: 'JAVA Developer' },
    { jobId: 3, jobTitle: 'Customer Care Executive' },
    { jobId: 4, jobTitle: 'Angular Developer' },
];
// Initial menu options
var initialMenu = function () {
    console.log('Welcome! Please select an option:');
    console.log('1. Sign Up');
    console.log('2. Login');
    console.log('3. Exit');
    rl.question('Enter your choice: ', function (choice) {
        if (choice === '1') {
            signUp();
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
// Signup function
var signUp = function () {
    console.log('Sign Up Form:');
    rl.question('Username: ', function (userName) {
        rl.question('First name: ', function (firstName) {
            rl.question('Last name: ', function (lastName) {
                rl.question('Gender: ', function (gender) {
                    rl.question('Phone number: ', function (phoneNumber) {
                        rl.question('Password: ', function (password) {
                            rl.question('Confirm password: ', function (confirmPassword) {
                                if (password !== confirmPassword) {
                                    console.log('Passwords do not match. Please try again.');
                                    signUp();
                                }
                                else {
                                    var newUser = {
                                        userName: userName,
                                        firstName: firstName,
                                        lastName: lastName,
                                        gender: gender,
                                        phoneNumber: phoneNumber,
                                        password: password,
                                    };
                                    registeredUsers.push(newUser);
                                    console.log('Signed up successfully!');
                                    redirectMenu();
                                }
                            });
                        });
                    });
                });
            });
        });
    });
};
// Apply for job function
var applyJob = function () {
    if (!loggedInUser) {
        console.log('You need to be logged in to apply for a job.');
        redirectMenu();
        return;
    }
    console.log('Apply Job:');
    rl.question('Enter JobId to apply: ', function (jobIdInput) {
        var jobId = parseInt(jobIdInput);
        var selectedJob = jobs.find(function (job) { return job.jobId === jobId; });
        if (selectedJob) {
            var newJob = {
                userName: loggedInUser.userName,
                jobId: selectedJob.jobId,
                jobTitle: selectedJob.jobTitle,
            };
            listJobs.push(newJob);
            console.log('Applied for job successfully!');
        }
        else {
            console.log('Invalid Job ID. Please try again.');
        }
        redirectMenu();
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
    rl.question('User Name: ', function (username) {
        rl.question('Password: ', function (password) {
            var user = registeredUsers.find(function (u) { return u.userName === username && u.password === password; });
            if (user) {
                console.log('Login successful!');
                loggedInUser = user;
                loggedInMenu();
            }
            else {
                console.log('Invalid userid or password. Please try again.');
                login();
            }
        });
    });
};
// Logged-in menu options
var loggedInMenu = function () {
    console.log('1. View Listed Jobs');
    console.log('2. Apply for Job');
    console.log('3. View Applied Jobs');
    console.log('4. Logout');
    rl.question('Enter your choice: ', function (choice) {
        if (choice === '1') {
            viewListedJobs();
        }
        else if (choice === '2') {
            applyJob();
        }
        else if (choice === '3') {
            viewAppliedJobs();
        }
        else if (choice === '4') {
            logout();
        }
        else {
            console.log('Invalid choice. Please try again.');
            loggedInMenu();
        }
    });
};
// View Listed Jobs
var viewListedJobs = function () {
    console.log('\n--------------------------------------------------Jobs List-----------------------------------------------\n');
    jobs.forEach(function (job) {
        console.log('Job Id:' + job.jobId + '\nJobTitle:' + job.jobTitle);
    });
    console.log('\n------------------------------------------------------------------------------------------------------------\n');
    redirectMenu();
};
// View Applied Jobs
var viewAppliedJobs = function () {
    if (!loggedInUser) {
        console.log('You need to be logged in to view applied jobs.');
        redirectMenu();
        return;
    }
    console.log('\n-----------------------------------------Your Applied Jobs-----------------------------------------\n');
    listJobs.filter(function (job) { return job.userName === (loggedInUser === null || loggedInUser === void 0 ? void 0 : loggedInUser.userName); });
    listJobs.forEach(function (job) {
        console.log('Job Id:' + job.jobId + '\nJobTitle:' + job.jobTitle);
    });
    console.log('\n---------------------------------------------------------------------------------------------------\n');
    redirectMenu();
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
