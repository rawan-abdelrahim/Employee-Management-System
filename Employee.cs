using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System
{
    internal class Employee
    {
        private readonly int _employeeID;
        private string _name;
        private int _age;
        private string _department;
        private decimal _salary;
        private readonly DateTime _employmentDate;
        private string _jobTitle;
        private Dictionary<int, float[]> _performanceRatings;
        private bool _isActive ;
        private DateTime _terminatedDate;

        public Employee(int employeeID, string name, int age, string jobTitle, decimal salary, DateTime employmentDate)
        {
            _employeeID = employeeID;
            Age = age;

            _name = name;
            JobTitle = jobTitle;
            _employmentDate = employmentDate;
            Salary = salary;
            _isActive = true;

        }
        public Employee(int employeeID, string name, int age, string department, decimal salary, DateTime employmentDate, string jobTitle)
        {
            _employeeID = employeeID;
            Name = name;
            Age = age;
            Department = department;
            Salary = salary;
            _employmentDate = employmentDate;
            JobTitle = jobTitle;
            _isActive = true;
            _performanceRatings = new Dictionary<int, float[]>();

        }

        public int EmployeeID => _employeeID;

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

        public int Age
        {
            get => _age;
            set
            {
                if (value < 18)
                    throw new ArgumentException("Age must be 18 or above.");
                _age = value;
            }
        }

        public string Department
        {
            get => _department;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Department cannot be empty.");
                _department = value;
            }
        }

        public decimal Salary
        {
            get => _salary;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Salary cannot be negative.");
                _salary = value;
            }
        }

        public DateTime EmploymentDate => _employmentDate;

        public string JobTitle
        {
            get => _jobTitle;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Job Title cannot be empty.");
                _jobTitle = value;
            }
        }

        public bool IsActive => _isActive;

        public Dictionary<int, float[]> PerformanceRatings => _performanceRatings;

        public void Terminate()
        {
            _isActive = false;
            _terminatedDate = DateTime.Now;
        }

        public DateTime TerminatedDate => _terminatedDate;

        public void AddPerformanceRating(int quarter, float rating, int year)
        {
            if (quarter < 1 || quarter > 4)
                throw new ArgumentException("Invalid quarter. Quarter must be between 1 and 4.");

            if (rating < 1 || rating > 5)
                throw new ArgumentException("Performance rating must be between 1 and 5.");

            if (year.ToString().Length != 4)
                throw new ArgumentException("Year must be a four-digit number.");

            int currentYear = DateTime.Now.Year;

            if (year < _employmentDate.Year)
                throw new ArgumentException($"Year cannot be earlier than the employee's hiring date ({_employmentDate.Year}).");

            if (year > currentYear)
                throw new ArgumentException($"Cannot add ratings for a future year ({year}).");

            if (_performanceRatings == null)
            {
                _performanceRatings = new Dictionary<int, float[]>();
            }

            for (int y = _employmentDate.Year; y <= currentYear; y++)
            {
                if (!_performanceRatings.ContainsKey(y))
                {
                    _performanceRatings[y] = new float[] { 0, 0, 0, 0 }; 
                }
            }

            _performanceRatings[year][quarter - 1] = rating;

            Console.WriteLine($"Performance rating for {year} Q{quarter} set to {rating}.");
        }


        public float[] GetQuarterlyRatings(int year)
        {
            if (!_performanceRatings.ContainsKey(year))
            {
                throw new KeyNotFoundException($"No performance ratings found for year {year}.");
            }

            return _performanceRatings[year];
        }

        public float GetAveragePerformance(int year)
        {
            float totalRate = 0;

            foreach (float rate in _performanceRatings[year])
            {
                totalRate += rate;
            }

            totalRate /= 4;

            return totalRate;
        }
    }
}

