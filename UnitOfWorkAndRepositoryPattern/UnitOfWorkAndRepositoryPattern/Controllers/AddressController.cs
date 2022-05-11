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
    public class AddressController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Address>> GetAll()
        {
            return Ok(_unitOfWork.Addresses.GetAll()); 
        }

        [HttpPost]
        public ActionResult<IEnumerable<Address>> Add(Address address)
        {
            _unitOfWork.Addresses.Add(address);
            _unitOfWork.Save();

            return Created($"address/{address.ID}", address);
        }
    }
}
