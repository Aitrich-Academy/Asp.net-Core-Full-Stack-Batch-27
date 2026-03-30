"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var readline = require("readline");
var Interview_1 = require("./Interview");
var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout,
});
var MenuOptions = [
    '1. Show Applicants List',
    '2. Schedule Interview',
    '3. Show Scheduled InterviewList',
    '0. Exit'
];
var ExitProgarm = false;
var obj = Interview_1.Interview;
var InterviewList = [];
var localStorage = "";
var JobProvider = /** @class */ (function () {
    function JobProvider() {
    }
    JobProvider.prototype.ShowMenu = function () {
        var _this = this;
        console.log("******************************************************* Welcome To Job Portal********************************************************");
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
    JobProvider.prototype.SelectOption = function (input) {
        switch (input) {
            case '1':
                this.ApplicantList();
                break;
            case "2":
                this.ScheduleInterview();
                break;
            case "3":
                this.ScheduledInterviewList();
                break;
            case '0':
                ExitProgarm = true;
                break;
            default:
                console.log("Invalid Options");
                break;
        }
    };
    JobProvider.prototype.ApplicantList = function () {
        var ApplicantList = [{
                Name: "John Wick",
                JobTitle: "Java Developer",
                Qualification: "Bca",
                Experience: "2 years"
            },
            {
                Name: "Tony Stark",
                JobTitle: "AI & Robotics Engineer",
                Qualification: "PhD in Artificial Intelligence",
                Experience: "7 years"
            },
            {
                Name: "Stephen Strange",
                JobTitle: "Sorcerer Supreme",
                Qualification: "Master Mystic Arts",
                Experience: "4 years"
            }
        ];
        console.log("\n--------------------------------------------------Applicants List-----------------------------------------------\n");
        ApplicantList.forEach(function (list) {
            console.log("Name :    " + list.Name + "JobTiTle :    " + list.JobTitle + "      Qualification :      " + list.Qualification + "      Experience :     " + list.Experience + "\n");
        });
        console.log("\n------------------------------------------------------------------------------------------------------------\n");
    };
    JobProvider.prototype.ScheduleInterview = function () {
        var _this = this;
        var result = this.Auth();
        if (result) {
            console.log("-------------------------Interview Schedule------------------");
            rl.question("\n Enter Job Title : ", function (JobTitle) {
                rl.question("\n Enter Interview Date :", function (interviewdate) {
                    var DateOfInterview = new Date(interviewdate);
                    rl.question("\n enter interview time :", function (Time) {
                        rl.question("\n enter interview Mode : ", function (ModeOfInterview) {
                            var interviewdata = {
                                JobTitle: JobTitle,
                                DateOfInterview: DateOfInterview,
                                Time: Time,
                                ModeOfInterview: ModeOfInterview
                            };
                            InterviewList.push(interviewdata);
                            _this.ShowMenu();
                        });
                    });
                });
            });
        }
        else {
            this.Login();
        }
    };
    JobProvider.prototype.Login = function () {
        var _this = this;
        console.log("\nplease login");
        rl.question("\nEnter your Username", function (username) {
            rl.question("\nenter your password", function (password) {
                if (username == "admin" && password == "password") {
                    console.log("\nLogin successful");
                    localStorage = "admin";
                    _this.ScheduleInterview();
                    return true;
                }
                else {
                    console.log('Invalid username or password. Please try again.!!!!!!!!!!!\n');
                    console.log('\x1b[31m%s\x1b[0m', '\u26A0', 'Error: Something went wrong!');
                    _this.Login();
                }
            });
        });
    };
    JobProvider.prototype.Auth = function () {
        if (localStorage) {
            return true;
        }
        else {
            return this.Login;
        }
    };
    JobProvider.prototype.ScheduledInterviewList = function () {
        InterviewList.forEach(function (job) {
            console.log(" \n\n job Title   :   ".concat(job.JobTitle));
            console.log("\n Date of interview   :   ".concat(job.DateOfInterview));
            console.log(" \n Time   :   ".concat(job.Time));
            console.log("\n mode of interview   :   ".concat(job.ModeOfInterview, "\n\n"));
        });
    };
    return JobProvider;
}());
var jobProviderRef = new JobProvider();
jobProviderRef.ShowMenu();
