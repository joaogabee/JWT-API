using JWT_API.DBContext;
using JWT_API.Models;

namespace JWT_API.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context = new AppDbContext();
    
    public List<Employee> GetAllEmployee(int pageNumber, int pageQuantity)
    {
        return _context.Employees.Skip(pageNumber * pageQuantity).Take(pageQuantity).ToList();
    }

    public void AddEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

    public Employee GetEmployee(int id)
    {
        return _context.Employees.Find(id);
    }
}