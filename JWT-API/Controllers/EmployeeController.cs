using JWT_API.Models;
using JWT_API.Repository;
using JWT_API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT_API.Controllers
{
    [Route("v1/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        
        private readonly IEmployeeRepository _employeeRepository;
        
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentException();
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetAllEmployees(int pageNumber, int pageQuantity)
        {
            var employeesData = _employeeRepository.GetAllEmployee(pageNumber, pageQuantity);
            return Ok(employeesData);
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddEmployee(EmployeeViewModel employeeViewModel)
        {
            var photoStorage = Path.Combine("Storage", employeeViewModel.photo.FileName);

            using Stream FilePath = new FileStream(photoStorage, FileMode.Create);
            employeeViewModel.photo.CopyTo(FilePath);
            
            var employeeData = new Employee(employeeViewModel.name, employeeViewModel.age, photoStorage);
            _employeeRepository.AddEmployee(employeeData);
            return Ok();
        }
        [Authorize]
        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employeeData = _employeeRepository.GetEmployee(id);
            var dataBytes = System.IO.File.ReadAllBytes(employeeData.photo);
            return File(dataBytes, "image/png");
        }
    }
}
