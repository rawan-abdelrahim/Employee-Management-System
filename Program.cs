using ConsoleTableExt;

namespace Employee_Management_System
{
    internal class Program
    {
        private static Company company;

        static void Main()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Employee Management System!\n");

            string compName = InputService.GetValidInput("Enter Company Name: ", input => input);
            company = new Company(compName);
            Console.WriteLine($"Company '{compName}' created successfully!\n");

            AddDepartments();

            AddEmployeesToDepartments();

            while (true)
            {
                try
                {
                    DisplayMenu();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private static void AddDepartments()
        {
            Console.Clear();
            Console.WriteLine("Add Departments to the Company\n");

            while (true)
            {
                string deptName = InputService.GetValidInput("Enter Department Name (or type 'done' to finish): ", input => input);

                if (deptName.Equals("done", StringComparison.OrdinalIgnoreCase))
                    break;

                company.AddDepartment(new Department(company.departments.Count + 1, deptName));
                Console.WriteLine($"Department '{deptName}' added successfully!\n");
            }
        }

        private static void AddEmployeesToDepartments()
        {
            Console.Clear();
            Console.WriteLine("Add Employees to Each Department\n");

            foreach (var department in company.departments)
            {
                Console.WriteLine($"\nAdding employees for Department: {department.Name}");

                while (true)
                {
                    string empName = InputService.GetValidInput("Enter Employee Name (or type 'done' to finish): ", input => input);

                    if (empName.Equals("done", StringComparison.OrdinalIgnoreCase))
                        break;

                    int empID = department.Employees.Count + 1;
                    int age = InputService.GetValidInput("Enter Employee Age: ", int.Parse);
                    string position = InputService.GetValidInput("Enter Employee Position: ", input => input);
                    decimal salary = InputService.GetValidInput("Enter Employee Salary: ", decimal.Parse);
                    DateTime dateOfJoining = InputService.GetValidInput("Enter Date of Joining (yyyy-MM-dd): ", DateTime.Parse);

                    Employee newEmployee = new Employee(empID, empName, age, position, salary, dateOfJoining);
                    department.AddEmployee(newEmployee);

                    Console.WriteLine($"Employee '{empName}' added successfully!\n");
                }
            }
        }


        private static void DisplayMenu()
        {
            string[] options = { "Add Employee", "View Employees","Add Department", "View Departments","Promote Employee", "Generate Reports","Manage Performance Ratings", "Exit"
    }; int selectedIndex = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Employee Management System ===");
                Console.WriteLine($"Company: {company.Name}\n");

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"> {options[i]} ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {options[i]} ");
                    }
                }

                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow) selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1;
                if (key == ConsoleKey.DownArrow) selectedIndex = (selectedIndex == options.Length - 1) ? 0 : selectedIndex + 1;
                if (key == ConsoleKey.Enter) break;
            }

            switch (selectedIndex)
            {
                case 0:
                    AddEmployee();
                    break;
                case 1:
                    ViewEmployees();
                    break;
                case 2:
                    AddDepartment();
                    break;
                case 3:
                    ViewDepartments();
                    break;
                case 4:
                    PromoteEmployee();
                    break;
                case 5:
                    GenerateReports();
                    break;
                case 6:
                    ManagePerformanceRatings(); 
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
            }
        }

        private static void AddEmployee()
        {
            Console.Clear();
            Console.WriteLine("Adding Employee");
            string deptName = InputService.GetValidInput("Enter Department Name: ", input => input);
            var department = company.departments.FirstOrDefault(d => d.Name.Equals(deptName, StringComparison.OrdinalIgnoreCase));

            if (department == null)
            {
                Console.WriteLine("Department not found.");
                return;
            }

            department.AddEmployeeFromConsole();
        }

        private static void ViewEmployees()
        {
            Console.Clear();
            company.ListAllEmployees();
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }

        private static void AddDepartment()
        {
            Console.Clear();
            string deptName = InputService.GetValidInput("Enter Department Name: ", input => input);
            company.AddDepartment(new Department(company.departments.Count + 1, deptName));
            Console.WriteLine("Department added successfully.");
            Thread.Sleep(1000);
        }

        private static void ViewDepartments()
        {
            Console.Clear();
            company.ListDepartments();
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }

        private static void PromoteEmployee()
        {
            Console.Clear();
            int empId = InputService.GetValidInput("Enter Employee ID: ", int.Parse);
            int year = InputService.GetValidInput("Enter Year: ", int.Parse);
            var employee = company.departments.SelectMany(d => d.Employees).FirstOrDefault(e => e.EmployeeID == empId);

            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            PerformanceReview review = new PerformanceReview();
            review.PromoteEmployee(employee, year);
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }
        private static void ManagePerformanceRatings()
        {
            Console.Clear();
            Console.WriteLine("=== Manage Performance Ratings ===");

            int empId = InputService.GetValidInput("Enter Employee ID: ", int.Parse);
            var employee = company.departments
                                  .SelectMany(d => d.Employees)
                                  .FirstOrDefault(e => e.EmployeeID == empId);

            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                Console.ReadKey();
                return;
            }

            string[] ratingOptions = { "Add Rating", "View Ratings", "View Average Rating", "Back" };
            int selectedIndex = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Manage Ratings for Employee: {employee.Name}\n");

                for (int i = 0; i < ratingOptions.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"> {ratingOptions[i]} ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {ratingOptions[i]} ");
                    }
                }

                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow) selectedIndex = (selectedIndex == 0) ? ratingOptions.Length - 1 : selectedIndex - 1;
                if (key == ConsoleKey.DownArrow) selectedIndex = (selectedIndex == ratingOptions.Length - 1) ? 0 : selectedIndex + 1;
                if (key == ConsoleKey.Enter) break;
            }

            switch (selectedIndex)
            {
                case 0:
                    AddEmployeeRating(employee);
                    break;
                case 1:
                    ViewEmployeeRatings(employee);
                    break;
                case 2:
                    ViewEmployeeAverageRating(employee);
                    break;
                case 3:
                    return; 
            }
        }
        private static void AddEmployeeRating(Employee employee)
        {
            Console.Clear();
            int quarter = InputService.GetValidInput("Enter Quarter (1-4): ", int.Parse);
            int year = InputService.GetValidInput("Enter Year: ", int.Parse); 
            float rating = InputService.GetValidInput("Enter Rating (1-5): ", float.Parse);

            try
            {
                employee.AddPerformanceRating(quarter, rating, year);
                Console.WriteLine($"Rating added successfully for {employee.Name}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }

        private static void ViewEmployeeRatings(Employee employee)
        {
            Console.Clear();
            int year = InputService.GetValidInput("Enter Year to View Ratings: ", int.Parse);

            try
            {
                float[] ratings = employee.GetQuarterlyRatings(year);
                Console.WriteLine($"\nPerformance Ratings for {employee.Name} in {year}:");
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine($"Q{i + 1}: {ratings[i]:0.0}/5");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }

        private static void ViewEmployeeAverageRating(Employee employee)
        {
            Console.Clear();
            int year = InputService.GetValidInput("Enter Year to View Average Rating: ", int.Parse);

            try
            {
                float avgRating = employee.GetAveragePerformance(year);
                Console.WriteLine($"\nAverage Performance Rating for {employee.Name} in {year}: {avgRating:0.0}/5");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }


        private static void GenerateReports()
        {
            Console.Clear();
            Console.WriteLine("Generating Reports...");
            company.ListAllEmployees();
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }
    }
    
}

