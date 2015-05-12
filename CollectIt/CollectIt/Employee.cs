
using System;
using System.Collections.Generic;

namespace CollectIt
{

    public class EmployeeComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return String.Compare(x.Name, y.Name, StringComparison.CurrentCulture);
        }
    }


    public class Employee
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }    
}
