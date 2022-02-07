using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi1.Model;

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
         
        static List<Employee> _employee = null;
        void Initialize()
        {
            _employee = new List<Employee>()
           {
               new Employee() { Id=1, Name="Arav" , Address= "Delhi"},
               new Employee() { Id=2, Name="Rohit" , Address= "Pune"},


           };

        }
        public EmployeeController()
        {
            if (_employee == null)
            {
                Initialize();
            }
        }


        
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employee;
        }

        
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            Employee emp = _employee.Where(x => x.Id == id).FirstOrDefault();
            return emp;
        }
    }
}
