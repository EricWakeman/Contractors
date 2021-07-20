using Microsoft.AspNetCore.Mvc;
using Contractor.Services;
using System.Collections.Generic;
using Contractor.Models;

namespace Contractor.Controllers
{
  [ApiController]
  [Route("api/[Controller]")]
  public class BidsController : ControllerBase
  {
    private readonly BidsService _bs;

    public BidsController(BidsService bs)
    {
      _bs = bs;
    }
    [HttpGet]
    public ActionResult<List<Bid>> GetBids()
    {
      try
      {
        List<Bid> bids = _bs.GetAll();
        return Ok(bids);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Bid> HandleBid([FromBody] Bid bidData)
    {
      try
      {
        Bid bid = _bs.HandleBid(bidData);
        return Ok(bid);
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
        string result = _bs.Delete(id);
        return Ok(result);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}