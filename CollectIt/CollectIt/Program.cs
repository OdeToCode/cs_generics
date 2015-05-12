using System;
using System.Collections.Generic;

namespace CollectIt
{

    public class DepartmentList : Dictionary<string, List<Department>>
    {
        // ...
    }


    class Program
    {
        static void Main()
        {
            CountEmloyees();
        }

        static void CountEmloyees()
        {
            var employeesByName = new SortedList<string, List<Employee>>();

            employeesByName.Add("Sales", new List<Employee> {new Employee(), new Employee(), new Employee()});
            employeesByName.Add("Engineering", new List<Employee> {new Employee(), new Employee()});

            foreach (var item in employeesByName)
            {
                Console.WriteLine("The count of employees for {0} is {1}",
                    item.Key, item.Value.Count
                    );
            }
        }
    }
}
