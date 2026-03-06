"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var readline = require("readline");
var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});
// Register function
var checkAge = function () {
    rl.question('Enter your age: ', function (age) {
        var a = Number(age);
        if (a >= 18)
            console.log("You are an adult");
        else
            console.log("You are a minor");
    });
};
checkAge();
