var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
// 1
console.log('..............................................');
console.log();
var Book = /** @class */ (function () {
    function Book() {
    }
    Book.prototype.setdata = function (title, author, price) {
        this.Title = title;
        this.Author = author;
        this.Price = price;
    };
    Book.prototype.DisplayBookDetails = function () {
        console.log('title : ', this.Title);
        console.log('Author : ', this.Author);
        console.log('Price : ', this.Price);
    };
    return Book;
}());
var books = new Book();
books.setdata('Harry potter', 'J.K.Rowling', 999);
books.DisplayBookDetails();
console.log();
console.log('..............................................');
console.log();
/// 2
var Student = /** @class */ (function () {
    function Student(name, course, marks) {
        this.Name = name;
        this.Course = course;
        this.Marks = marks;
    }
    Student.prototype.displayStudentDetails = function () {
        console.log('student name : ', this.Name);
        console.log('Course : ', this.Course);
        console.log('Marks : ', this.Marks);
    };
    return Student;
}());
var students = new Student('student 1', 'course 1', 77);
students.displayStudentDetails();
console.log();
console.log('..............................................');
console.log();
//// 3
var Calculator = /** @class */ (function () {
    function Calculator(a, b) {
        this.A = a;
        this.B = b;
    }
    Calculator.prototype.Add = function () {
        console.log("50 + 30 = ", this.A + this.B);
    };
    Calculator.prototype.Subtract = function () {
        console.log('50 - 30 = ', this.A - this.B);
    };
    Calculator.prototype.Multiply = function () {
        console.log('50 * 30 = ', this.A * this.B);
    };
    return Calculator;
}());
var Calculators = new Calculator(50, 30);
Calculators.Add();
Calculators.Subtract();
Calculators.Multiply();
console.log();
console.log('..............................................');
console.log();
///// 4
var Person = /** @class */ (function () {
    function Person(name, age) {
        this.Age = age;
        this.Name = name;
    }
    Person.prototype.DisplayPerson = function () {
        console.log(this.Name, this.Age);
    };
    return Person;
}());
var Employee = /** @class */ (function (_super) {
    __extends(Employee, _super);
    function Employee(Name, Age, salary) {
        var _this = _super.call(this, Name, Age) || this;
        _this.Salary = salary;
        return _this;
    }
    Employee.prototype.DisplayEmployee = function () {
        console.log('Name : ', this.Name);
        console.log('Age : ', this.Age);
        console.log('Salary : ', this.Salary);
    };
    return Employee;
}(Person));
var emp = new Employee("emp 1", 27, 55000);
emp.DisplayEmployee();
console.log();
console.log('..............................................');
console.log();
////// 5
var BankAccount = /** @class */ (function () {
    function BankAccount() {
        this.Balance = 0;
    }
    BankAccount.prototype.getbalance = function () {
        return this.Balance;
    };
    BankAccount.prototype.Deposit = function (amount) {
        this.Balance = this.Balance + amount;
        console.log("Deposited ".concat(amount, "   Balance = "), this.Balance);
    };
    BankAccount.prototype.Withdraw = function (amount) {
        console.log("withdraw ".concat(amount, "   Balance = "), this.Balance = this.Balance - amount);
    };
    BankAccount.prototype.GetBalance = function () {
        return this.Balance;
    };
    return BankAccount;
}());
var bank = new BankAccount();
bank.GetBalance();
bank.Deposit(500);
bank.Withdraw(200);
console.log();
console.log('..............................................');
console.log();
/////// 6
var Animal = /** @class */ (function () {
    function Animal() {
    }
    Animal.prototype.MakeSound = function () {
    };
    return Animal;
}());
var Dog = /** @class */ (function (_super) {
    __extends(Dog, _super);
    function Dog() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Dog.prototype.MakeSound = function () {
        console.log("dog barks");
    };
    return Dog;
}(Animal));
var Cat = /** @class */ (function (_super) {
    __extends(Cat, _super);
    function Cat() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Cat.prototype.MakeSound = function () {
        console.log("Cat meows");
    };
    return Cat;
}(Animal));
var dogs = new Dog();
var cats = new Cat();
dogs.MakeSound();
cats.MakeSound();
console.log();
console.log('..............................................');
console.log();
var Customer = /** @class */ (function () {
    function Customer(id, name, email) {
        this.id = id;
        this.name = name;
        this.email = email;
    }
    Customer.prototype.DisplayUserDetails = function () {
        console.log('ID : ', this.id);
        console.log('Name : ', this.name);
        console.log('Email', this.email);
    };
    return Customer;
}());
var customer = new Customer(1, 'customer 1', 'customer1@gmail.com');
// console.log(customer);
customer.DisplayUserDetails();
console.log();
console.log('..............................................');
console.log();
///////// 8
var Shape = /** @class */ (function () {
    function Shape() {
    }
    return Shape;
}());
var Circle = /** @class */ (function (_super) {
    __extends(Circle, _super);
    function Circle(radius) {
        var _this = _super.call(this) || this;
        _this.Radius = radius;
        return _this;
    }
    Circle.prototype.CalculateArea = function () {
        console.log('Area of the circle = ', this.Radius * this.Radius * 3.14);
    };
    return Circle;
}(Shape));
var circles = new Circle(5);
circles.CalculateArea();
var Rectangle = /** @class */ (function (_super) {
    __extends(Rectangle, _super);
    function Rectangle(length, width) {
        var _this = _super.call(this) || this;
        _this.Length = length;
        _this.Width = width;
        return _this;
    }
    Rectangle.prototype.CalculateArea = function () {
        console.log('Area of the Rectangle = ', this.Length * this.Width);
    };
    return Rectangle;
}(Shape));
var rectangles = new Rectangle(6, 4);
rectangles.CalculateArea();
console.log();
console.log('..............................................');
console.log();
////////// 9
console.log();
var MathUtility = /** @class */ (function () {
    function MathUtility() {
    }
    MathUtility.Square = function (Num) {
        console.log("sqare of ".concat(Num, " = "), Num * Num);
    };
    return MathUtility;
}());
MathUtility.Square(5);
console.log();
console.log('..............................................');
console.log();
/////////// 10
// class Product 
// {
//     private Price! : number ;
//     Value! : number;
//     constructor(price : number , value : number)
//     {
//         this.Price = price;
//         this.Value = value;
//     }
//     getprice () : number
//     {
//         return this.Price;
//     }
//     setprice (Price:number) : void
//     {
//         this.Price = Price;
//     }
//     SetPrice ()
//     {
//         console.log(this.Price * this.Value)
//     }
//     GetPrice ()
//     {
//     }
// }
