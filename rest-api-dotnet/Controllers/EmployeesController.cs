using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rest_api_dotnet.Data;
using rest_api_dotnet.Models;
using rest_api_dotnet.Models.Entities;

namespace rest_api_dotnet.Controllers
{
    [Route("api/[controller]")]
    /*  [Route("api/[controller]")] this is called an attribute, 
    which says that it is going to be accessed from this particular route, for example, 
    localhost:PORT/api/controllerName, the name of the controller is EmployeesController in this case, 
    the name of the class, so the route for this one would be localhost:PORT/api/employees  */
    [ApiController] // [ApiController] this is called an attribute
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees() 
        {
            var allEmployees = dbContext.Employees.ToList();

            return Ok(allEmployees);
        }

        [HttpGet]
        [Route("{id:guid}")] 
        /* This statement says that we will except an identifier inside the curly braces, 
        the name giving in the route attribe should match the name in the parameter of the method*/
        public IActionResult GetEmployeeById(Guid id) 
        {
            var employee = dbContext.Employees.Find(id);

            if(employee is null) 
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            // Map the AddEmployeeDto and convert it into the entity because the DbContext class only accepts the entities declared
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };

            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();

            return Ok(employeeEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = dbContext.Employees.Find(id);

            if (employee is null)
            {
                return NotFound();
            }

            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;

            dbContext.SaveChanges();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = dbContext.Employees.Find(id);

            if (employee is null)
            {
                return NotFound();
            }

            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
