import * as readline from 'readline';
const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

interface User {
  userName: string;
  firstName: string;
  lastName: string;
  gender: string;
  phoneNumber: string;
  password: string;
}

interface JobsApplied {
  userName: string;
  jobId: number;
  jobTitle: string;
}

interface Jobs {
  jobId: number;
  jobTitle: string;
}

let loggedInUser: User | null = null;
const listJobs: JobsApplied[] = [];
const registeredUsers: User[] = [];
const jobs: Jobs[] = [
  { jobId: 1, jobTitle: 'ASP.Net Full Stack Developer' },
  { jobId: 2, jobTitle: 'JAVA Developer' },
  { jobId: 3, jobTitle: 'Customer Care Executive' },
  { jobId: 4, jobTitle: 'Angular Developer' },
];

// Initial menu options
const initialMenu = (): void => {
  console.log('Welcome! Please select an option:');
  console.log('1. Sign Up');
  console.log('2. Login');
  console.log('3. Exit');

  rl.question('Enter your choice: ', (choice: string) => {
    if (choice === '1') {
      signUp();
    } else if (choice === '2') {
      login();
    } else if (choice === '3') {
      exit();
    } else {
      console.log('Invalid choice. Please try again.');
      initialMenu();
    }
  });
};

// Signup function
const signUp = (): void => {
  console.log('Sign Up Form:');
  rl.question('Username: ', (userName: string) => {
    rl.question('First name: ', (firstName: string) => {
      rl.question('Last name: ', (lastName: string) => {
        rl.question('Gender: ', (gender: string) => {
          rl.question('Phone number: ', (phoneNumber: string) => {
            rl.question('Password: ', (password: string) => {
              rl.question('Confirm password: ', (confirmPassword: string) => {
                if (password !== confirmPassword) {
                  console.log('Passwords do not match. Please try again.');
                  signUp();
                } else {
                  const newUser: User = {
                    userName,
                    firstName,
                    lastName,
                    gender,
                    phoneNumber,
                    password,
                  };

                  registeredUsers.push(newUser);
                  console.log('Signed up successfully!');
                  redirectMenu();
                }
              });
            });
          });
        });
      });
    });
  });
};

// Apply for job function
const applyJob = (): void => {
  if (!loggedInUser) {
    console.log('You need to be logged in to apply for a job.');
    redirectMenu();
    return;
  }

  console.log('Apply Job:');
  rl.question('Enter JobId to apply: ', (jobIdInput: string) => {
    const jobId = parseInt(jobIdInput);
    const selectedJob = jobs.find((job) => job.jobId === jobId);

    if (selectedJob) {
      const newJob: JobsApplied = {
        userName: loggedInUser.userName,
        jobId: selectedJob.jobId,
        jobTitle: selectedJob.jobTitle,
      };

      listJobs.push(newJob);
      console.log('Applied for job successfully!');
    } else {
      console.log('Invalid Job ID. Please try again.');
    }

    redirectMenu();
  });
};

// Redirect to previous menu
const redirectMenu = (): void => {
  rl.question('Redirect to previous menu? (Y/N): ', (choice: string) => {
    if (choice.toLowerCase() === 'y') {
      initialMenu();
    } else if (choice.toLowerCase() === 'n') {
      exit();
    } else {
      console.log('Invalid choice. Exiting...');
      exit();
    }
  });
};

// Login function
const login = (): void => {
  console.log('Login:');

  rl.question('User Name: ', (username: string) => {
    rl.question('Password: ', (password: string) => {
      const user = registeredUsers.find(
        (u) => u.userName === username && u.password === password
      );

      if (user) {
        console.log('Login successful!');
        loggedInUser = user;
        loggedInMenu();
      } else {
        console.log('Invalid userid or password. Please try again.');
        login();
      }
    });
  });
};

// Logged-in menu options
const loggedInMenu = (): void => {
  console.log('1. View Listed Jobs');
  console.log('2. Apply for Job');
  console.log('3. View Applied Jobs');
  console.log('4. Logout');

  rl.question('Enter your choice: ', (choice: string) => {
    if (choice === '1') {
      viewListedJobs();
    } else if (choice === '2') {
      applyJob();
    } else if (choice === '3') {
      viewAppliedJobs();
    } else if (choice === '4') {
      logout();
    } else {
      console.log('Invalid choice. Please try again.');
      loggedInMenu();
    }
  });
};

// View Listed Jobs
const viewListedJobs = (): void => {
  console.log('\n--------------------------------------------------Jobs List-----------------------------------------------\n');
  jobs.forEach((job) => {
    console.log('Job Id:'+job.jobId+'\nJobTitle:'+job.jobTitle);
  });
  console.log('\n------------------------------------------------------------------------------------------------------------\n');
  redirectMenu();
};

// View Applied Jobs
const viewAppliedJobs = (): void => {
  if (!loggedInUser) {
    console.log('You need to be logged in to view applied jobs.');
    redirectMenu();
    return;
  }

  console.log('\n-----------------------------------------Your Applied Jobs-----------------------------------------\n');
  listJobs.filter((job) => job.userName === loggedInUser?.userName)
    listJobs.forEach((job) => {
      console.log('Job Id:'+job.jobId+'\nJobTitle:'+job.jobTitle);
    });
  console.log('\n---------------------------------------------------------------------------------------------------\n');
  redirectMenu();
};

// Logout function
const logout = (): void => {
  console.log('Logging out...');
  loggedInUser = null;
  initialMenu();
};

// Exit function
const exit = (): void => {
  console.log('Exiting...');
  rl.close();
};

// Start the initial menu
initialMenu();
