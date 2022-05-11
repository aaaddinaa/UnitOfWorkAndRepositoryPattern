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
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public EmailController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Email>> GetAll()
        {
            return Ok(_unitOfWork.Emails.GetAll());
        }

        [HttpPost]
        public ActionResult<IEnumerable<Email>> Add(Email email)
        {
            _unitOfWork.Emails.Add(email);
            _unitOfWork.Save();

            return Ok();
        }
    }
}
