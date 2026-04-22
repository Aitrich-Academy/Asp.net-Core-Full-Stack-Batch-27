import * as readline from 'readline';




const rl = readline.createInterface
({
    input: process.stdin,
    output: process.stdout,
});



// function OddOrEven()
// {
//    rl.question("enter a number", function (num)
//    {

//     var num1 = parseInt(num);

//     if (num1 % 2 === 0)
//         {
//             console.log(`${num1} is an even number`)
//         } 


//         else
//         {
//             console.log(`${num1} is an Odd number`)
//         }

//         rl.close();
// });

// }

// OddOrEven();




//////////////////////////////////////////////////////////////////////////////////////////




// function FIndLargest()
// {
//     rl.question("enter first number : " , (num1) =>
    
//     rl.question("enter second number : " , (num2)=>
    
//     rl.question("enter third number : " , (num3) => 
//     {
//         let n1 = parseInt(num1);
//         let n2 = parseInt(num2);
//         let n3 = parseInt(num3);


//         var largest ;

//         if (n1 >= n2 && n1 >= n3)
//         {
//             largest = n1;
//         }


//         else if (n2 >= n3 && n2 >= n3)
//         {
//             largest = n2;
//         }


//         else 
//         {
//             largest = n3
//         }


//         console.log(`largest number is   :   ${largest}`);



//         rl.close();


//     })
    
//     ))
// }

//  FIndLargest();




//////////////////////////////////////////////////////////////////////////////////////


// function Marks()
// {
//     rl.question("\n enter mark : ", function (mark)

//     {
//         var mark1 = parseInt(mark);

//         if(mark1 >= 90)
//         {
//             console.log("\n you got grade A ")
//         }
        
//          else if (mark1 >= 75 )
//          {
//             console.log("\n you got grade B ")
//          }

//          else if (mark1 >= 50 )
//          {
//             console.log("\n you got grade C ")
//          }

//          else
//          {
//             console.log("\n failed ")
//          }
        
//     }

// )
   
// }
// Marks();



/////////////////////////////////////////////////////////////////////////////////////////////






// var num  = function ()
// {
   
//     rl.question("enter a number  "  , function (num1)
// {
//     var num2 = parseInt(num1)

//     console.log("square of the number " + (num2) + " is " + num2 * num2  )


// } )
// }


// num();






/////////////////////////////////////////////////////////////////////////////////////////////








// function RectangleArea(length : number = 10 , width? : number  )
// {

//     let num = rl.question("enter a width : " , function (width)
// {

//    var width1 = parseInt(width);


//     console.log("area of the rectangle = " + length * width1 )
// })
// }

// RectangleArea( );



//////////////////////////////////////////////////////////////////////////////////////////







// function StudentDetails (name : string , age : number , course? :string )
// {
//     console.log ("name: " + name, "age : "+ age, );


//     if (course! == undefined)
//     {
//         console.log("course not specified")
//     }

//     console.log(("Course : " + course))

    
// }


// StudentDetails("brad pitt" , 51 , )


// StudentDetails("reynolds" , 48 , "bcom" )






/////////////////////////////////////////////////////////////////////







function Sum (num1? :number , num2? : number , num3? : number)
{
    rl.question("enter number 1 : " ,  (num1) =>
    rl.question("enter number 2 :" , (num2)=> 
    rl.question("enter number 3 : " , (num3)=>
        {
            var num4 = parseInt(num1);
            var num5 = parseInt(num2);
            var num6 = parseInt(num3);


            console.log("sum of all numbers = " ,num4 + num5 + num6 )


        })));

         
}



Sum()






