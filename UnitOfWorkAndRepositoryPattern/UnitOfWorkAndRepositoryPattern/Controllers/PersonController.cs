using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkAndRepositoryPattern.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            return Ok(_unitOfWork.People.GetAll());
        }

        [HttpPost]
        public ActionResult<IEnumerable<Person>> Add(Person person)
        {
            _unitOfWork.People.Add(person);
            _unitOfWork.Save();

            return Created($"person/{person.ID}", person);
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetById(int id)
        {
            var result = _unitOfWork.People.GetById(id);

            if(result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete]
        public ActionResult<Person> Remove(Person person)
        {
            _unitOfWork.People.Remove(person);
            _unitOfWork.Save();
           return Ok();
            
        }

    }
}
