import * as readline from 'readline';

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});

let loggedInUser: User | null = null;

interface User {
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string;
  password: string;
  gender: string;
}

const registeredUsers: User[] = [];

// Initial menu options
const initialMenu = (): void => {
  console.log('Welcome! Please select an option:');
  console.log('1. Register');
  console.log('2. Login');
  console.log('3. Exit');

  rl.question('Enter your choice: ', (choice: string) => {
    if (choice === '1') {
      register();
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

// Register function
const register = (): void => {
  console.log('Registration:');
  
  rl.question('First name: ', (firstName: string) => {
    rl.question('Last name: ', (lastName: string) => {
      rl.question('Email: ', (email: string) => {
        rl.question('Phone number: ', (phoneNumber: string) => {
          rl.question('Password: ', (password: string) => {
            rl.question('Confirm password: ', (confirmPassword: string) => {
              rl.question('Gender: ', (gender: string) => {
                // Perform registration logic here
                const newUser: User = {
                  firstName,
                  lastName,
                  email,
                  phoneNumber,
                  password,
                  gender
                };

                registeredUsers.push(newUser);
                console.log('Registration successful!');

                redirectMenu();
              });
            });
          });
        });
      });
    });
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
  
  rl.question('Email: ', (email: string) => {
    rl.question('Password: ', (password: string) => {
      // Perform login logic here
      const user = registeredUsers.find(
        (u) => u.email === email && u.password === password
      );

      if (user) {
        console.log('Login successful!');
        loggedInUser = user;

        loggedInMenu();
      } else {
        console.log('Invalid email or password. Please try again.');
        login();
      }
    });
  });
};

// Logged-in menu options
const loggedInMenu = (): void => {
  console.log('1. viewprofile');
  console.log('2. Update Profile');
  console.log('3. Logout');

  rl.question('Enter your choice: ', (choice: string) => {
    if (choice === '') {
         
    } else if (choice === '2') {
      updateProfile();
    } else if (choice === '3') {
      logout();
    } else {
      console.log('Invalid choice. Please try again.');
      loggedInMenu();
    }
  });
};


// Update profile function
const updateProfile = (): void => {
    console.log('Update Profile:');
  
    rl.question('First name: ', (firstName: string) => {
      rl.question('Last name: ', (lastName: string) => {
        rl.question('Email: ', (email: string) => {
          rl.question('Phone number: ', (phoneNumber: string) => {
            rl.question('Password: ', (password: string) => {
              rl.question('Confirm password: ', (confirmPassword: string) => {
                rl.question('Gender: ', (gender: string) => {
                  // Perform update profile logic here
                  loggedInUser = {
                    ...loggedInUser,
                    firstName,
                    lastName,
                    email,
                    phoneNumber,
                    password,
                    gender
                  };
  
                  console.log('Profile updated successfully!');
                  loggedInMenu();
                });
              });
            });
          });
        });
      });
    });
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
