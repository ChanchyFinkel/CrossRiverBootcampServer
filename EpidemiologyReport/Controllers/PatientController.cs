using EpidemiologyReport.DB;
using EpidemiologyReport.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EpidemiologyReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        IDAL _dal;
        public PatientController(IDAL dal)
        {
            _dal = dal;
           
        }
        // GET
        [HttpGet("location")]
        public async Task<List<Patient>> Get()
        {
            return await _dal.getAllLocations();   
        }

        // GET
        [HttpGet("{id}/location")]
        public async Task<Patient> Get(int id)
        {
          return  await _dal.getLocationByPatientId(id);
        }

        // GET
        [HttpGet("city/location")]
        public async Task<List<Report>> Get([FromQuery]String city="")
        {
            var r= await _dal.getLocationByCity(city);
            return r;
        }

        // POST
        [HttpPost("location")]
        public async Task<Boolean> Post([FromBody] Patient newPatient)
        {
            return await _dal.addNewLocation(newPatient);
        }

        // DELETE 
        [HttpDelete("location")]
        public async Task<int> Delete([FromBody] Patient deletedLocation)
        {
            return await _dal.DeleteLocation(deletedLocation);
        }
    }
}
