"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var readline = require("readline");
var r1 = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});
var users = [
    { username: "user", password: "123" }
];
var jobs = [
    { id: 1, title: "Software developer" },
    { id: 2, title: ".Net developer" },
    { id: 3, title: "Front-end developer" }
];
var myApplication = [];
var loggedUserIn = null;
function Menu() {
    console.log("1. Login");
    console.log("2. Exist");
    r1.question("Choose option: ", function (choice) {
        if (choice === "1") {
            r1.question("Username: ", function (u) {
                r1.question("Password: ", function (p) {
                    var user = users.find(function (x) { return x.username === u && x.password === p; });
                    if (user) {
                        loggedUserIn = user;
                        console.log("\nLogin Successful!");
                        mainMenu();
                    }
                    else {
                        console.log("Invalid Credentials");
                        Menu();
                    }
                });
            });
        }
        else if (choice === "2") {
            r1.close();
        }
        else {
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
    r1.question("Choose option: ", function (choice) {
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
    jobs.forEach(function (j) {
        console.log("".concat(j.id, ". ").concat(j.title));
    });
    r1.question("Enter Job id to Apply : ", function (id) {
        var job = jobs.find(function (j) { return j.id === Number(id); });
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
        myApplication.forEach(function (job) {
            console.log("".concat(job.id, ". ").concat(job.title));
        });
    }
    mainMenu();
}
Menu();
