public class Department
{
    public string Name;
    public string DepartmentHead;
    private List<Employee> employees;

    public Department(string name, string departmentHead)
    {
        Name = name;
        DepartmentHead = departmentHead;
        employees = new List<Employee>();
    }

    public void AddEmployee(Employee employee)
    {
        if (employees.Any( e=> e.ID == employee.ID))
        {
            Console.WriteLine($"Error :Employee with ID {employee.ID} already exists in {Name} department.");
            return;
        }
        employees.Add(employee);
        employee.DepartmentName = Name; 
        Console.WriteLine($"Employee {employee.Name} added to {Name} department.");
    }

    public void RemoveEmployee(int employeeID)
    {
        Employee employee = employees.Find(e => e.ID == employeeID);
        if (employee == null)
        {
            Console.WriteLine($"Employee with ID {employeeID} not found in {Name} department.");
            return;
        }

        employees.Remove(employee);
        Console.WriteLine($" Employee {employee.Name} removed from {Name} department.");
    }

    public void TransferEmployee(int employeeID, Department newDepartment)
    {
        Employee employee = employees.Find(e => e.ID == employeeID);

        if (employee == null)
        {
            Console.WriteLine($"Employee with ID {employeeID} is not in {Name} department.");
            return;
        }

        // Remove from current department
        employees.Remove(employee);

        // Update employee's department name
        employee.DepartmentName = newDepartment.Name;

        // Add to new department
        newDepartment.AddEmployee(employee);

        Console.WriteLine($" Employee {employee.Name} has been transferred to {newDepartment.Name} department.");
    }

    public void ListEmployees()
    {
        Console.WriteLine($"\n Employees in {Name} Department:");
        if (employees.Count == 0)
        {
            Console.WriteLine(" No employees found.");
            return;
        }

        foreach (var emp in employees)
        {
            Console.WriteLine(emp);
        }
    }
    public void ShowTopPerformance()
    {
        Employee emp =employees[0];
        list<Employee> topperformers=new list<Employee>();
        for(int i=0;i<Employees.Count:i++)
        {
            if(Employees[i].getPerformanceRating()>emp.getPerformanceRating())
                emp=Employees[i];
                index=i;
            
        }
        topPrformers.Add(emp);
        for(int i=0;i<2;i++)
        {
             Console.WriteLine($"Top performers is {topPrformers[i].getName()}");
            
        }
}
