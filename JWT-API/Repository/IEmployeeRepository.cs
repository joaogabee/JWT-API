using JWT_API.Models;

namespace JWT_API.Repository;

public interface IEmployeeRepository
{
    public List<Employee> GetAllEmployee(int pageNumber, int pageQuantity);
    public void AddEmployee(Employee employee);

    public Employee GetEmployee(int id);
}