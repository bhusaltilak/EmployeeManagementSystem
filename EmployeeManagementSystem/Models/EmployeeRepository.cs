using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeManagementSystemDbContext _employeeManagementSystemDbContext;

        public EmployeeRepository(EmployeeManagementSystemDbContext employeeManagementSystemDbContext)
        {

            _employeeManagementSystemDbContext = employeeManagementSystemDbContext;
        }
        public void AddEmployee(Employee employee)
        {

            _employeeManagementSystemDbContext.Employees.Add(employee);
            _employeeManagementSystemDbContext.SaveChanges();
        }
        public IEnumerable<Employee> AllEmployee
        {
            get
            {
                return _employeeManagementSystemDbContext.Employees;
            }
        }
        public void DeleteEmployee(int id)
        {

            var employee = _employeeManagementSystemDbContext.Employees.Find(id);

            if (employee == null)
            {
                throw new ArgumentException("employee not found");
            }


            _employeeManagementSystemDbContext.Employees.Remove(employee);
            _employeeManagementSystemDbContext.SaveChanges();

        }

        public Employee? GetEmployeeById(int employeeId)
        {

            return _employeeManagementSystemDbContext.Employees.FirstOrDefault(p => p.EmployeeId == employeeId);
        }

        public void UpdateEmployee(Employee employee)
        {

            var existingEmployee = _employeeManagementSystemDbContext.Employees.FirstOrDefault(p => p.EmployeeId == employee.EmployeeId);
            if (existingEmployee == null)
            {
                throw new ArgumentException("employee not found");
            }


            existingEmployee.Name = employee.Name;
            existingEmployee.Email = employee.Email;
            existingEmployee.ImageUrl = employee.ImageUrl;
            existingEmployee.PhoneNumber = employee.PhoneNumber;
            existingEmployee.Address = employee.Address;

            _employeeManagementSystemDbContext.Entry(existingEmployee).State = EntityState.Modified;
            _employeeManagementSystemDbContext.SaveChanges();
        }
    }

  
}
