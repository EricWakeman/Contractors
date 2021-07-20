using System;
using System.Collections.Generic;
using Contractor.Models;
using Contractor.Repositories;

namespace Contractor.Services
{
  public class BidsService
  {
    private readonly BidsRepository _br;

    public BidsService(BidsRepository br)
    {
      _br = br;
    }

    internal List<Bid> GetAll()
    {
      List<Bid> bids = _br.GetAll();
      return bids;
    }
    internal List<Bid> GetAllByJobId(int jobId)
    {
      List<Bid> bids = _br.GetAllByJobId(jobId);
      return bids;
    }
    internal List<Bid> GetAllByContractorId(int contractorId)
    {
      List<Bid> bids = _br.GetAllByContractorId(contractorId);
      return bids;
    }

    internal Bid HandleBid(Bid bidData)
    {


      if (bidData.Id == null)
      {
        Bid newBid = _br.Create(bidData);
        return newBid;
      }
      else
      {
        var original = GetOne(bidData.Id);
        bidData.ContractorId = original.ContractorId;
        bidData.JobId = original.JobId;
        int updated = _br.Update(bidData);
        if (updated > 0)
        {
          return bidData;
        }
        else
        {
          throw new Exception("Failed to update");
        }
      }
    }
    internal Bid GetOne(int id)
    {
      var bid = _br.GetOne(id);
      return bid;
    }

    internal string Delete(int id)
    {
      int result = _br.Delete(id);
      if (result > 0)
      {
        return "Successfully Deleted.";
      }
      else
      {
        return "Could Not Delete.";
      }
    }


  }
}