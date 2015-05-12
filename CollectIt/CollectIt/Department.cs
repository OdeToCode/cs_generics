
using System.Collections.Generic;

namespace CollectIt
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DepartmentList : SortedList<string, HashSet<Employee>>
    {
        public DepartmentList Add(string departmentName, Employee employee)
        {
            if (!ContainsKey(departmentName))
            {
                Add(departmentName, new HashSet<Employee>(new EmployeeComparer()));
            }
            this[departmentName].Add(employee);
            return this;
        }
    }
}
