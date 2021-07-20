using Microsoft.AspNetCore.Mvc;
using Contractor.Services;
using Contractor.Models;
using System.Collections.Generic;

namespace Contractor.Controllers
{
  [ApiController]
  [Route("api/[Controller]")]
  public class ContractorsController : ControllerBase
  {
    private readonly ContractorsService _cs;
    private readonly BidsService _bs;

    public ContractorsController(ContractorsService cs, BidsService bs)
    {
      _cs = cs;
      _bs = bs;
    }

    [HttpGet]
    public ActionResult<List<ContractorModel>> GetAll()
    {
      try
      {
        List<ContractorModel> contractors = _cs.GetAll();
        return contractors;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<ContractorModel> GetOne(int id)
    {
      try
      {
        ContractorModel contractor = _cs.GetOne(id);
        return contractor;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/bids")]

    public ActionResult<List<Bid>> GetAllBids(int id)
    {
      try
      {
        List<Bid> bids = _bs.GetAllByContractorId(id);
        return bids;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<ContractorModel> Create([FromBody] ContractorModel contractorData)
    {
      try
      {
        ContractorModel contractor = _cs.Create(contractorData);
        return contractor;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<ContractorModel> Update([FromBody] ContractorModel contractorData, int id)
    {
      try
      {
        contractorData.Id = id;
        ContractorModel contractor = _cs.Update(contractorData);
        return Ok(contractor);
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
        string result = _cs.Delete(id);
        return Ok(result);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}