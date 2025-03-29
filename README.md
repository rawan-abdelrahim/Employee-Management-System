# Employee Management System (EMS)

## Overview
The Employee Management System (EMS) is a C# object-oriented console application designed for mid-sized companies to manage employee records efficiently. The system tracks employee details, performance, promotions, and department transfers while generating valuable reports for HR and management.

## Features
- **Employee Management**
  - **Record Keeping:** Each employee is uniquely identified and stores details such as name, age, salary, department, employment date, and job title.
  - **Lifecycle Operations:**
    - **Promotion:** Employees can be promoted based on performance ratings and experience, with their salary and job title updated accordingly.
    - **Transfer:** Employees can be transferred between departments.
    - **Termination:** Employee status can be updated to inactive without losing historical data.

- **Performance Management**
  - **Quarterly Ratings:** Employees receive performance ratings on a quarterly basis using a strict format (e.g., `Q1-2025`).
  - **Data Aggregation:** Methods are included to calculate total and average performance scores to support promotion decisions.

- **Reporting & Analytics**
  - Generate reports for employees per department, top performers, and salary distribution.

- **Input Validation**
  - A dedicated `InputService` class handles user input and validation, ensuring data consistency. Users have three attempts to enter valid values before the program terminates.

## Architecture & Design
- **Separation of Concerns:**  
  The project is divided into multiple classes to separate business logic (Employee, Department, etc.) from user input handling (InputService) and application orchestration (Program class).
  
- **SOLID Principles:**  
  The design adheres to SOLID principles ensuring that each class has a single responsibility and that the system is modular and maintainable.

## Project Structure
- `Employee.cs`  
  Contains the Employee class with properties, methods for performance management, promotions, transfers, and termination.
  
- `InputService.cs`  
  Provides generic methods for input gathering and validation.
  
- `Program.cs`  
  The entry point of the application. This class orchestrates the workflow by using InputService to collect user input and create/manage Employee objects.

## Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) (version 5.0 or later recommended)

### Running the Application
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/employee-management-system.git
   cd employee-management-system
   ```
2. Build and run the application using the .NET CLI:
   ```bash
   dotnet run
   ```
3. Follow the on-screen prompts to create an employee, add performance ratings, and explore the system's features.

## Contributing
Contributions are welcome! Feel free to fork the repository and submit pull requests for new features, bug fixes, or improvements.
## Contact

For any questions, suggestions, or issues, please feel free to reach out to our team:

- **Bassel Ahmed**  
  Email: [basselahmed941@gmail.com](mailto:basselahmed941@gmail.com)  
  GitHub: [basselelkosairy](https://github.com/basselelkosairy)  

- **Ahmed Abouelwafa**  
  Email: [hamada.abouelwafa12@gmail.com](mailto:hamada.abouelwafa12@gmail.com)  
  GitHub: [AhmedAbouelwafa](https://github.com/AhmedAbouelwafa)  

- **Rawan Abdelrahim**  
  Email: [rawanabdo7575@gmail.com](mailto:rawanabdo7575@gmail.com)  
  GitHub: [rawan-abdelrahim](https://github.com/rawan-abdelrahim)

- **Aya Ashour**  
  Email: [gnatasour321@gmail.com](mailto:gnatasour321@gmail.com)  
  GitHub: [ayaashour2002](https://github.com/ayaashour2002)

We appreciate your feedback!

