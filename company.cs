using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Employee_Management_System
{
    class Company
    {

        private List<Department> departments;
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty.");
                _name = value;
            }
        }


        public Company(string name)
        {
            Name = name;
            departments = new List<Department>();
        }

        public void AddDepartment(Department department)
        {
            foreach (var d in departments)
            {
                if (d.Name.ToUpper() == department.Name.ToUpper())
                {
                    throw new ArgumentException("Department with this name already exists.");
                }
            }
            departments.Add(department);
        }

        public void RemoveDepartment(string departmentName)
        {
            departments.RemoveAll(d => d.Name == departmentName);
        }

        public void ListDepartments()
        {
            if (departments.Count == 0)
            {
                Console.WriteLine("No departments in the company.");
                return;
            }

            Console.WriteLine("Departments in the company:");
            foreach (var dept in departments)
            {
                Console.WriteLine($"- {dept.Name} (Employee count: {dept.GetEmployeeCount()})");
            }
        }

        public void AddEmployeeToDepartment(Employee employee, string departmentName)
        {
            var department = departments.FirstOrDefault(d => d.Name == departmentName);
            if (department != null)
            {
                department.AddEmployee(employee);
            }
            else
            {
                Console.WriteLine("Department not found.");
            }
        }

        public void TransferEmployee(int employeeId, string fromDepartment, string toDepartment)
        {
            Department fromDept = null;
            Department toDept = null;

            foreach (var dept in departments)
            {
                if (dept.Name == fromDepartment)
                    fromDept = dept;
                if (dept.Name == toDepartment)
                    toDept = dept;
            }

            if (fromDept == null || toDept == null)
            {
                Console.WriteLine("Department not found.");
                return;
            }

            var employee = fromDept.GetEmployeeById(employeeId);
            if (employee != null)
            {
                fromDept.RemoveEmployee(employeeId);
                toDept.AddEmployee(employee);
                Console.WriteLine($"Employee {employee.Name} transferred to {toDepartment} department.");
            }
            else
            {
                Console.WriteLine("Employee not found in current department.");
            }
        }


        public void ListAllEmployees()
        {
            if (departments.Count == 0 || departments.All(d => d.GetEmployeeCount() == 0))
            {
                Console.WriteLine("No employees in the company.");
                return;
            }

            Console.WriteLine("Employees in the company:");
            foreach (var dept in departments)
            {
                dept.ListEmployees();
            }
        }

       
       
    }
}
