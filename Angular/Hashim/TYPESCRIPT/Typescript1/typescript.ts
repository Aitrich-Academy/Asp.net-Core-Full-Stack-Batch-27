
// 1
console.log('..............................................');
console.log()




class Book 
{
    Title! : string ;

    Author! : string ;

    Price! : number ;

setdata(title:string,author:string,price:number)
{
    this.Title=title;
    this.Author=author;
    this.Price=price;
}

DisplayBookDetails():void
{
    console.log('title : ' ,this.Title);
    console.log('Author : ',this.Author);
    console.log('Price : ',this.Price);
}
}

var books = new Book ();
books.setdata('Harry potter','J.K.Rowling',999)
books.DisplayBookDetails();







console.log()
console.log('..............................................');
console.log()







/// 2


class Student
{
    Name! : string ;

    Course! : string ;

    Marks! : number;


    constructor(name:string,course:string,marks:number)
    {
        this . Name = name;
        this . Course = course;
        this . Marks = marks;
    }


    displayStudentDetails(): void
    {
        console.log('student name : ',this.Name);
        console.log('Course : ',this.Course);
        console.log('Marks : ',this.Marks);
    }
}

var students = new Student('student 1','course 1',77)

students.displayStudentDetails();





console.log()
console.log('..............................................');
console.log()





//// 3



class Calculator 
{
    A! : number;
    
    B! : number;


    constructor(a:number , b:number)
    {
        this.A = a;

        this.B = b;
    }





    Add() : void
    {
        console.log("50 + 30 = ",this.A + this.B)
    }



     Subtract() : void
    {
        console.log('50 - 30 = ',this.A - this.B)
    }



     Multiply() : void
    {
        console.log('50 * 30 = ',this.A * this.B)
    }

}
    var Calculators = new Calculator(50 , 30)


    Calculators.Add() 
    Calculators.Subtract() 
    Calculators.Multiply() 






console.log()
console.log('..............................................');
console.log()




    ///// 4


    class Person 
    {
        Name! : string;

        Age! : number;

        constructor(name:string,age:number)
        {
            this.Age = age;

            this.Name = name;
        }


        DisplayPerson():void
        {
            console.log(this.Name,this.Age)
        }

    }




    class Employee extends Person
    {
        Salary! : number;


        constructor(Name:string , Age:number, salary : number)
        {
            super(Name,Age)

            this.Salary=salary;
        }

        DisplayEmployee() : void
        {
            console.log('Name : ',this.Name)
            console.log('Age : ',this.Age)
            console.log('Salary : ',this.Salary)
        }

    }

        var emp = new Employee ("emp 1" , 27 , 55000);

        emp.DisplayEmployee();

    



console.log()
console.log('..............................................');
console.log()



    ////// 5





    class BankAccount
    {
        private Balance : number=0;


        public getbalance() : number
        {
            return this.Balance;
        }


       



        Deposit(amount:number)
        {
            this.Balance=this.Balance+amount;
            console.log(`Deposited ${amount}   Balance = `, this.Balance )
        }



        Withdraw(amount:number)
        {
            console.log(`withdraw ${amount}   Balance = `,this.Balance = this.Balance - amount)
        }



        GetBalance()
        {
           return this.Balance
        }
    }


   var bank  =  new BankAccount ( );
   bank.GetBalance();

   bank.Deposit(500);

   bank.Withdraw(200);




console.log()
console.log('..............................................');
console.log()




    /////// 6





    class Animal 
    {
        MakeSound()
        {

        }
    }



    class Dog extends Animal
    {
        MakeSound(): void 
        {
            console.log("dog barks")
        }
    }



    class Cat extends Animal
    {
        MakeSound(): void 
        {
            console.log("Cat meows")    
        }
    }



    const dogs = new Dog ();

    const cats = new Cat ();

    dogs.MakeSound();

    cats.MakeSound();




console.log()
console.log('..............................................');
console.log()



    ///////// 7





    interface User
    {
        id : number;

        name : string;

        email : string;

        DisplayUserDetails() : void;
    }


    class Customer implements User
    {
        id: number;

        name: string;

        email: string;

        constructor(id:number,name:string,email:string)
        {
            this.id = id;
            this.name = name;
            this.email = email;
        }

        DisplayUserDetails(): void
        {
            console.log('ID : ',this.id)
            console.log('Name : ',this.name)
            console.log('Email',this.email)
        }

    }


    const customer : User = new Customer(1,'customer 1','customer1@gmail.com')
    

    // console.log(customer);

    customer.DisplayUserDetails()






console.log()
console.log('..............................................');
console.log()

    ///////// 8









abstract class Shape
{
   abstract CalculateArea() :void;
   
    
}


class Circle extends Shape
{
    Radius! : number;


    constructor(radius : number)
    {
        super()
        this.Radius=radius
    }



    CalculateArea(): void 
    {
        console.log('Area of the circle = ',this.Radius*this.Radius*3.14)
    }

}

var circles = new Circle (5);
circles.CalculateArea();


class Rectangle extends Shape
{
    Length! : number;

    Width! : number;


    constructor(length : number , width : number)
    {
        super()
        
        this.Length = length;

        this.Width = width; 
    }


    CalculateArea(): void 
    {
        console.log('Area of the Rectangle = ' , this.Length*this.Width)    
    }

}

var rectangles = new Rectangle (6,4);
  rectangles.CalculateArea();






console.log()
console.log('..............................................');
console.log()







////////// 9



console.log()





class MathUtility
{
   static  Square (Num : number)
    {
        console.log( `sqare of ${Num} = `,Num * Num )
    }
}



MathUtility.Square(5);



console.log()
console.log('..............................................');
console.log()






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














