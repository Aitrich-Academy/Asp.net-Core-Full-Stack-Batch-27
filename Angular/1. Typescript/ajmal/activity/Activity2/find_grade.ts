import * as readline from 'readline'
const rl=readline.createInterface({
input:process.stdin,
output:process.stdout
});



const gradeCalculator = (): void => {
    
    
    rl.question('Enter Grade: ', (grade: string) => {
        
      let g:number=Number(grade);
      
      if((g>=90)&&(g<=100))
        console.log('A');
      else if((g>=80)&&(g<=89))
        console.log('B');
      else if((g>=70)&&(g<=79))
        console.log('C');
      else if((g>=60)&&(g<=69))
        console.log('D');
      else
      console.log("F");
      
});
        
    }
    gradeCalculator();


