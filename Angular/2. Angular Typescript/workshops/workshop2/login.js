"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (g && (g = 0, op[0] && (_ = 0)), _) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.Authentication = void 0;
var readline = require("readline");
var jobs_1 = require("./jobs");
var dashboard_1 = require("./dashboard");
var jobSeekers_1 = require("./jobSeekers");
var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout,
    terminal: false
});
var Authentication = /** @class */ (function () {
    function Authentication() {
        this.showContinuePrompt = false;
    }
    Authentication.prototype.askQuestion = function (question) {
        return new Promise(function (resolve) {
            rl.question(question, function (answer) {
                console.log(answer, resolve(answer));
                resolve(answer);
            });
        });
    };
    Authentication.prototype.login = function () {
        return __awaiter(this, void 0, void 0, function () {
            var username, password, home;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.askQuestion("Enter your username? ")];
                    case 1:
                        username = _a.sent();
                        return [4 /*yield*/, this.askQuestion("Enter your password? ")];
                    case 2:
                        password = _a.sent();
                        if (username == 'admin' && password == "admin") {
                            this.showMenuItems();
                            // rl.close();
                        }
                        else {
                            console.log("Invalid Username and Password");
                            home = new dashboard_1.Dashboard();
                            home.showMenuItems();
                        }
                        return [2 /*return*/];
                }
            });
        });
    };
    Authentication.prototype.showMenuItems = function () {
        return __awaiter(this, void 0, void 0, function () {
            var jobObject, dashboardObject, jobseekerObject, option, _a, companyName, opt;
            return __generator(this, function (_b) {
                switch (_b.label) {
                    case 0:
                        jobObject = new jobs_1.Job();
                        dashboardObject = new dashboard_1.Dashboard();
                        jobseekerObject = new jobSeekers_1.JobseekerManager();
                        console.log("");
                        console.log("1. Job Providers list");
                        console.log("2. Job seekers list");
                        console.log("4. Remove Job seeker by company");
                        console.log("5. Back to Dashboard");
                        console.log("");
                        return [4 /*yield*/, this.askQuestion("Choose option : ")];
                    case 1:
                        option = _b.sent();
                        console.log(option);
                        _a = +option;
                        switch (_a) {
                            case 1: return [3 /*break*/, 2];
                            case 2: return [3 /*break*/, 3];
                            case 4: return [3 /*break*/, 4];
                            case 5: return [3 /*break*/, 6];
                        }
                        return [3 /*break*/, 7];
                    case 2:
                        jobObject.getAllJobs();
                        this.showContinuePrompt = true;
                        return [3 /*break*/, 8];
                    case 3:
                        jobseekerObject.getAllJobseekers();
                        this.showContinuePrompt = true;
                        return [3 /*break*/, 8];
                    case 4: return [4 /*yield*/, this.askQuestion("Enter the company name: ")];
                    case 5:
                        companyName = _b.sent();
                        jobseekerObject.removeJobseekerByCompany(companyName);
                        this.showContinuePrompt = true;
                        return [3 /*break*/, 8];
                    case 6:
                        dashboardObject.showMenuItems();
                        this.showContinuePrompt = true;
                        return [3 /*break*/, 8];
                    case 7: return [3 /*break*/, 8];
                    case 8:
                        if (!this.showContinuePrompt) return [3 /*break*/, 10];
                        return [4 /*yield*/, this.askQuestion("Do you want to continue ( y / n ) : ")];
                    case 9:
                        opt = _b.sent();
                        opt == 'y' ? this.showMenuItems() : rl.close();
                        return [3 /*break*/, 11];
                    case 10:
                        rl.close();
                        _b.label = 11;
                    case 11: return [2 /*return*/];
                }
            });
        });
    };
    return Authentication;
}());
exports.Authentication = Authentication;
