using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System
{
    internal class Department
    {
        
        private readonly int _departmentID;
        private string _name;
        private List<Employee> _employees;

        public Department(int departmentID, string name)
        {
            _departmentID = departmentID;
            Name = name;
            _employees = new List<Employee>();
        }

        public int DepartmentID => _departmentID;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Department name cannot be empty.");
                _name = value;
            }
        }

        public List<Employee> Employees => _employees;

        public int GetEmployeeCount() => _employees.Count;

        public Employee GetEmployeeById(int employeeId)
        {
            foreach (var employee in _employees)
            {
                if (employee.EmployeeID == employeeId)
                {
                    return employee;
                }
            }
            return null; 
        }


        public void AddEmployeeFromConsole()
        {
            int employeeID = InputService.GetValidInput("Enter Employee ID: ", input =>
            {
                int id = int.Parse(input);
                if (_employees.Any(e => e.EmployeeID == id))
                    throw new ArgumentException("Employee ID already exists.");
                return id;
            });

            string name = InputService.GetValidInput("Enter Name: ", input =>
            {
                if (string.IsNullOrWhiteSpace(input))
                    throw new ArgumentException("Name cannot be empty.");
                return input;
            });

            int age = InputService.GetValidInput("Enter Age: ", input =>
            {
                int a = int.Parse(input);
                if (a < 18)
                    throw new ArgumentException("Age must be 18 or above.");
                return a;
            });

            decimal salary = InputService.GetValidInput("Enter Salary: ", input =>
            {
                decimal s = decimal.Parse(input);
                if (s < 0)
                    throw new ArgumentException("Salary cannot be negative.");
                return s;
            });

            string jobTitle = InputService.GetValidInput("Enter Job Title: ", input =>
            {
                if (string.IsNullOrWhiteSpace(input))
                    throw new ArgumentException("Job Title cannot be empty.");
                return input;
            });

            DateTime employmentDate = DateTime.Now;
            Employee newEmployee = new Employee(employeeID, name, age, Name, salary, employmentDate, jobTitle);
            _employees.Add(newEmployee);
            Console.WriteLine("Employee added successfully!\n");
        }

        public void RemoveEmployee(int employeeId)
        {
            Employee employee = _employees.FirstOrDefault(e => e.EmployeeID == employeeId);

            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            _employees.Remove(employee);
            Console.WriteLine($"Employee {employee.Name} has been removed from {Name} department.");
        }

        public void AddEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            if (_employees.Any(e => e.EmployeeID == employee.EmployeeID))
                throw new ArgumentException("Employee with this ID already exists in the department.");

            _employees.Add(employee);
        }

        public void TransferEmployee(int employeeID, Department newDepartment)
        {
            if (newDepartment == null)
            {
                Console.WriteLine("Invalid department. Please select a valid department.");
                return;
            }

            Employee employee = null;
            foreach (var emp in _employees)
            {
                if (emp.EmployeeID == employeeID)
                {
                    employee = emp;
                    break;
                }
            }

            if (employee == null)
            {
                Console.WriteLine("Employee not found in this department.");
                return;
            }

            if (newDepartment == this)
            {
                Console.WriteLine("Employee is already in this department.");
                return;
            }

            _employees.Remove(employee);
            newDepartment.AddEmployee(employee);
            Console.WriteLine($"Employee {employee.Name} transferred to {newDepartment.Name} department successfully.");
        }


        public void ListEmployees()
        {
            if (_employees.Count == 0)
            {
                Console.WriteLine($"No employees found in {Name} department.");
                return;
            }

            Console.WriteLine($"\n===== Employees in {Name} Department =====");
            foreach (var emp in _employees)
            {
                Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.Name}, Age: {emp.Age}, " +
                                 $"Job Title: {emp.JobTitle}, Salary: {emp.Salary:C}, " +
                                 $"Hire Date: {emp.EmploymentDate:yyyy-MM-dd}, Active: {emp.IsActive}");
            }
        }

        public void ListActiveEmployees()
        {
            var activeEmployees = _employees.Where(e => e.IsActive).ToList();

            if (activeEmployees.Count == 0)
            {
                Console.WriteLine($"No active employees found in {Name} department.");
                return;
            }

            Console.WriteLine($"\n===== Active Employees in {Name} Department =====");
            foreach (var emp in activeEmployees)
            {
                Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.Name}, Job Title: {emp.JobTitle}");
            }
        }

        public void ListTerminatedEmployees()
        {
            var terminatedEmployees = _employees.Where(e => !e.IsActive).ToList();

            if (terminatedEmployees.Count == 0)
            {
                Console.WriteLine($"No terminated employees found in {Name} department.");
                return;
            }

            Console.WriteLine($"\n===== Terminated Employees in {Name} Department =====");
            foreach (var emp in terminatedEmployees)
            {
                Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.Name}, " +
                                $"Termination Date: {emp.TerminatedDate:yyyy-MM-dd}");
            }
        }

     
    }
}
