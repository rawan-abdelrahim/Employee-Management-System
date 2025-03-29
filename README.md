# Employee Management System (EMS)

## Overview
The Employee Management System (EMS) is a C# object-oriented console application designed to help a mid-sized company manage its employee records, track performance and promotions, and generate various analytical reports. The system automates employee lifecycle operations—from hiring and promotions to department transfers and terminations—while preserving historical data.

## Objective
Develop a robust EMS that enables a company to:
- Track employee details (ID, name, age, salary, department, employment date, etc.).
- Manage department assignments and transfers.
- Evaluate performance through quarterly ratings and facilitate performance-based promotions.
- Generate comprehensive reports for informed decision-making.

## Scenario
A mid-sized company needs an automated system to manage employee records and monitor their performance, enabling timely promotions and department changes. The system also generates insightful reports to assist management in strategic planning and operational decisions.

## Business Requirements

### 1. Employee Management
- **Employee Data:**  
  - Each employee has a unique ID, name, age, salary, department, and employment date.
- **Employee Operations:**  
  - **Promotion:** Employees are promoted based on their performance ratings and experience. A promotion increases both the salary and job title.
  - **Transfer:** Employees can be transferred between departments.
  - **Termination:** When terminated, employees’ records remain in the system for historical tracking.

### 2. Department Management
- The company operates multiple departments (e.g., HR, IT, Sales, Finance).
- Each department has a name, a department head, and a list of employees.
- Department operations include adding and removing employees, ensuring updates are reflected in employee records.

### 3. Performance & Promotions
- **Quarterly Performance Ratings:**  
  Employees receive performance ratings every quarter.
- **Promotion Criteria:**  
  Consistently high ratings make employees eligible for promotions.
- **Promotion Impact:**  
  Promotions result in an increase in salary and an update of the job title.

### 4. Reports & Analytics
The system generates various reports including:
- A list of employees by department.
- Identification of top-performing employees.
- Analysis of salary distribution.

## System Design & Class Structure
- **Employee Class:**  
  Handles employee-related data and operations, such as promotion, transfer, termination, and performance ratings.
- **Department Class:**  
  Manages department information and operations including adding or removing employees.
- **Company Class:**  
  Integrates employee and department functionalities for overall company management.
- **PerformanceReview Class:**  
  Implements logic for evaluating performance based on quarterly ratings.

### Key Design Principles:
- **Encapsulation:**  
  Employee data and operations are encapsulated within classes to protect and manage state effectively.
- **Composition:**  
  Departments contain lists of employees, ensuring department switching updates employee records.
- **SOLID Principles:**  
  Each class is designed with a single responsibility, making the system modular, maintainable, and scalable.

## Implementation Details
- **Employee Operations:**  
  The Employee class includes methods such as `Promote()`, `TransferDepartment()`, `Terminate()`, and performance rating management.
- **Input Handling & Exception Management:**  
  A dedicated InputService class handles user input with validation and error handling (allowing multiple attempts before terminating the application).
- **Data Storage:**  
  Employee records and performance ratings are stored in in-memory collections with potential for file-based persistence as a future enhancement.

## User Interaction & Menu System
The EMS provides a menu-driven interface that allows users to:
- Add or view employee records.
- Manage department details.
- Add performance ratings.
- Promote employees based on defined criteria.
- Generate various reports (employees by department, top performers, salary distribution).

## Testing & Enhancements (BONUS)
- Comprehensive testing ensures all features work as expected.
- Future enhancements may include:
  - File-based or database persistence.
  - A more user-friendly interface.
  - Additional reporting and analytics features.

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

