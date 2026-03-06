import * as readline from 'readline'
const rl=readline.createInterface({
input:process.stdin,
output:process.stdout
});

const getFruitColor = (): void => {
    
    rl.question('Enter a fruit: ', (fruit: string) => {
        
           
      switch(fruit)
      {
        case 'apple': console.log('RED COLOR');
                  rl.close();
                  break;
        case 'banana': console.log('YELLOW COLOR');
                   rl.close();
                  break;
        case 'grapes': console.log('PURPLE COLOR');
                  rl.close();
                  break;
        case 'kiwi': console.log('GREEN COLOR');
                  rl.close();
                  break;
        case 'strawberry': console.log('RED COLOR');
                  rl.close();
                  break;
        case 'orange': console.log('ORANGE COLOR');
                  rl.close();
                  break;
        case 'plum': console.log('PURPLE COLOR');
                  rl.close();
                  break;
        default: console.log('WRONG CHOICE');
                 rl.close();
                  break;
                  
}
});
        
    }
    getFruitColor();


