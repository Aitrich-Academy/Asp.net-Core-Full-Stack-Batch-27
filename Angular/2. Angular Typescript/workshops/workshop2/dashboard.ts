import * as readline from 'readline';

import { Authentication } from './login';

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

export class Dashboard {

    askQuestion(question: string): Promise<string> {
        return new Promise(resolve => {
            rl.question(question, answer => {
                resolve(answer);
            });
        });
    }

    showMenuItems() {
        console.log();
        
        console.log('1. Login');
        console.log('2. Exit');

        this.selectOption()
    }

    async selectOption() {
        let option = 0;
        let authenticationObj = new Authentication()
    
        
        console.log("");
        const opton = await this.askQuestion("Choose option : ");
            option = +opton;
            switch (+option) {
                case 1:
                    authenticationObj.login();
                    break;
                case 2:
                    console.log('Exit........');
                    break;
                default:
                    break;
            }
            // rl.close();      
    }
}

let dashboard = new Dashboard();
dashboard.showMenuItems()






