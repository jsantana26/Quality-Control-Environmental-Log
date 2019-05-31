using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using AutoMapper;
using QCEL.Dtos;
using QCEL.Models;

namespace QCEL.Controllers.Api
{
    public class SampleLocationsController : ApiController
    {
	    private ApplicationDbContext _context;

	    public SampleLocationsController()
	    {
		    _context = new ApplicationDbContext();
	    }

        // GET: api/SampleLocations
		[HttpGet]
        public IEnumerable<SampleLocationDto> Get()
        {

	        return _context.SampleLocations.ToList().Select(Mapper.Map<SampleLocation, SampleLocationDto>);
        }

        // GET: api/SampleLocations/5
		[HttpGet]
        public IHttpActionResult Get(int id)
        {
	        var sampleLocation = _context.SampleLocations.SingleOrDefault(c => c.Id == id);

	        if (sampleLocation == null)
		        return NotFound();

	        return Ok(Mapper.Map<SampleLocation, SampleLocationDto>(sampleLocation));
        }

        // POST: api/SampleLocations
		[HttpPost]
        public IHttpActionResult CreateSampleLocation(SampleLocationDto sampleLocationDto)
        {
	        if (!ModelState.IsValid)
		        return BadRequest();


	        var sampleLocation = Mapper.Map<SampleLocationDto, SampleLocation>(sampleLocationDto);

	        _context.SampleLocations.Add(sampleLocation);
	        _context.SaveChanges();

	        sampleLocationDto.Id = sampleLocation.Id;

	        return Created(new Uri(Request.RequestUri + "/" + sampleLocation.Id), sampleLocationDto );
        }

        // PUT: api/SampleLocations/5
		[HttpPut]
        public IHttpActionResult UpdateSampleLocation(int id, SampleLocationDto sampleLocationDto)
        {
	        if (!ModelState.IsValid)
		        return BadRequest();

	        var sampleLocationInDb = _context.SampleLocations.SingleOrDefault(c => c.Id == id);

	        if (sampleLocationInDb == null)
		        return NotFound();

	        Mapper.Map(sampleLocationDto, sampleLocationInDb);

	        _context.SaveChanges();

	        return Ok();
        }

        // DELETE: api/SampleLocations/5
		[HttpDelete]
        public IHttpActionResult Delete(int id)
        {
	        var sampleLocationInDb = _context.SampleLocations.SingleOrDefault(c => c.Id == id);

	        if (sampleLocationInDb == null)
		        return NotFound();

	        _context.SampleLocations.Remove(sampleLocationInDb);
	        _context.SaveChanges();

	        return Ok();
        }
    }
}
