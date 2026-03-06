import * as readline from 'readline'
const rl=readline.createInterface({
input:process.stdin,
output:process.stdout
});


// Register function
const checkAge = (): void => {
    
    
    rl.question('Enter your age: ', (age: string) => {
      let a:number=Number(age);
      if(a>=18)
        console.log("You are an adult");
    else
    console.log("You are a minor");
      });
  };
  
checkAge();