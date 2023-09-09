using BlogApiDemo.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]")] //apiyi web projesinde çağırmak istersek kullanılır
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c = new Context();
            var values = c.Employees.ToList();
            return Ok(values);
        }

        //api ile veri ekleme
        [HttpPost]
        public IActionResult EmployeeAdd(Employee employee)
        {
            using var c = new Context();
            c.Add(employee);
            c.SaveChanges();
            return Ok();
        }
        //api ile idye göre getirme
        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            using var c = new Context();
            var employee = c.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }

        //api ile veri silme işlemi
        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            using var c = new Context();
            var employee = c.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(employee);
                c.SaveChanges();
                return Ok();
            }
        }

        //api ile veri güncelleme işlemi
        [HttpPut("{id}")]
        public IActionResult EmployeeUpdate(Employee employee)
        {
            using var c = new Context();
            var emp = c.Find<Employee>(employee.ID); //idye göre bulur
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                emp.Name = employee.Name;
                c.Update(emp);
                c.SaveChanges();
                return Ok();
            }
        }
    }
}
