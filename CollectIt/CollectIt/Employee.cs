
using System;
using System.Collections.Generic;

namespace CollectIt
{

    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(Employee obj)
        {
            return obj.Name.GetHashCode();
        }
    }


    public class Employee
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }    
}
