using System.Collections.Generic;
using Contractor.Models;
using Contractor.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contractor.Controllers
{
  [ApiController]
  [Route("api/[Controller]")]
  public class JobsController : ControllerBase
  {
    private readonly JobsService _js;
    private readonly BidsService _bs;

    public JobsController(JobsService js, BidsService bs)
    {
      _js = js;
      _bs = bs;
    }

    [HttpGet]
    public ActionResult<List<Job>> GetAll()
    {
      try
      {
        List<Job> jobs = _js.GetAll();
        return Ok(jobs);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Job> GetOne(int id)
    {
      try
      {
        Job job = _js.GetOne(id);
        return Ok(job);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/bids")]
    public ActionResult<List<Bid>> GetBids(int id)
    {
      try
      {
        List<Bid> bid = _bs.GetAllByJobId(id);
        return Ok(bid);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Job> Create([FromBody] Job jobData)
    {
      try
      {
        Job job = _js.Create(jobData);
        return Ok(job);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Job> Update([FromBody] Job jobData, int id)
    {
      try
      {
        Job job = _js.Update(jobData, id);
        return Ok(job);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        string result = _js.Delete(id);
        return Ok(result);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}