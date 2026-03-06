"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var readline = require("readline");
var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});
var gradeCalculator = function () {
    rl.question('Enter Grade: ', function (grade) {
        var g = Number(grade);
        if ((g >= 90) && (g <= 100))
            console.log('A');
        else if ((g >= 80) && (g <= 89))
            console.log('B');
        else if ((g >= 70) && (g <= 79))
            console.log('C');
        else if ((g >= 60) && (g <= 69))
            console.log('D');
        else
            console.log("Failedconsole.log(a);");
    });
};
gradeCalculator();
