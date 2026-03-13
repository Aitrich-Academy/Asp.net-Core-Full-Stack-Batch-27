import * as readline from 'readline';
import { Job } from './jobs';
import { Dashboard } from './dashboard';
import { JobseekerManager } from './jobSeekers';

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout,
    terminal: false
});

export class Authentication {


    showContinuePrompt = false;

    askQuestion(question: string): Promise<string> {



        return new Promise(resolve => {
            rl.question(question, answer => {
                
                resolve(answer);
            });
        });
    }


    async login() {

        const username = await this.askQuestion("Enter your username? ");
        const password = await this.askQuestion("Enter your password? ");
        if (username == 'admin' && password == "admin") {
            this.showMenuItems();
            // rl.close();
        } else {
            console.log("Invalid Username and Password");
            let home = new Dashboard();
                home.showMenuItems()

        }
        // rl.close();
    }


    async showMenuItems() {

        const jobObject = new Job();
        const dashboardObject = new Dashboard();
        const jobseekerObject = new JobseekerManager();

        console.log("");

        console.log("1. Job Providers list");
        console.log("2. Job seekers list");
        console.log("4. Remove Job seeker by company");
        console.log("5. Back to Dashboard");

        console.log("");

        const option = await this.askQuestion("Choose option : ");
        console.log(option);
        switch (+option) {
            case 1:
                jobObject.getAllJobs();
                this.showContinuePrompt = true
                break;

            case 2:
                jobseekerObject.getAllJobseekers();
                this.showContinuePrompt = true
                break;

            case 4:
                const companyName = await this.askQuestion("Enter the company name: ");
                jobseekerObject.removeJobseekerByCompany(companyName);
                this.showContinuePrompt = true;
                break;

            case 5:
                dashboardObject.showMenuItems();
                this.showContinuePrompt = true;
                break;

            default:
                break;
        }

        if (this.showContinuePrompt) {
            const opt = await this.askQuestion("Do you want to continue ( y / n ) : ");
            opt == 'y' ? this.showMenuItems() : rl.close()
        } else {
            rl.close()
        }
    }
}