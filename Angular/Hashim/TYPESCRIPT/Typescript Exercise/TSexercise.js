"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var readline = require("readline");
var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout,
});
var MenuOptions = [
    '1. All Jobs',
    '2. My Application',
    '3. Logout',
    '0. Exit'
];
var ExitProgarm = false;
var User = /** @class */ (function () {
    function User() {
    }
    User.prototype.ShowMenu = function () {
        var _this = this;
        console.log("******************************************************* Welcome ********************************************************");
        MenuOptions.forEach(function (option) { return console.log(option); });
        rl.question("\n Enter your choice : ", function (input) {
            _this.SelectOption(input);
            if (ExitProgarm) {
                rl.close();
            }
            else {
                _this.ShowMenu();
            }
        });
    };
    User.prototype.SelectOption = function (input) {
        switch (input) {
            case '1':
                this.AllJobs();
                break;
            case "2":
                this.MyApplication();
                break;
            case "3":
                this.LogOut();
                break;
            case '0':
                ExitProgarm = true;
                break;
            default:
                console.log("Invalid Options");
                break;
        }
    };
    User.prototype.AllJobs = function () {
        var jobsList = [
            {
                Title: "software Developer",
                Department: "IT",
                Description: ".Net Developer"
            },
            {
                Title: "Accountant",
                Department: "Finance",
                Description: "manages company accounts"
            }
        ];
        console.log("\n--------------------------------------------------Job List-----------------------------------------------\n");
        jobsList.forEach(function (list) {
            console.log("\n Title :  " + list.Title + "   Department : " + list.Department + "   Description : " + list.Description + "\n");
        });
        console.log("\n------------------------------------------------------------------------------------------------------------\n");
    };
    User.prototype.MyApplication = function () {
        var ApplicationList = [
            {
                Name: "Tony Stark",
                JobTitle: "Software Developer",
                Experience: "2 year",
            }
        ];
        console.log("\n--------------------------------------------------Application List-----------------------------------------------\n");
        ApplicationList.forEach(function (list) {
            console.log("\n Name : " + list.Name + "JobTitle : " + list.JobTitle + "Experience : " + list.Experience + "\n");
        });
        console.log("\n------------------------------------------------------------------------------------------------------------\n");
    };
    User.prototype.LogOut = function () {
        console.log("\n Logged out successfully \n");
        this.Login();
    };
    User.prototype.Login = function () {
        var _this = this;
        console.log("\n Login \n ");
        rl.question("\n Enter your Username  :  ", function (username) {
            rl.question("\n enter your password  :  ", function (password) {
                if (username == "tony" && password == "123") {
                    console.log("\n Login successful");
                    _this.ShowMenu();
                    return true;
                }
                else {
                    console.log('\n Invalid username or password. Please try again.!!!!!!!!!!!\n');
                    console.log('\x1b[31m%s\x1b[0m', '\u26A0', 'Error: Something went wrong!');
                    _this.Login();
                }
            });
        });
    };
    return User;
}());
var useruser = new User();
useruser.Login();
