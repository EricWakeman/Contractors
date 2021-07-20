using System;
using System.Collections.Generic;
using Contractor.Models;
using Contractor.Repositories;

namespace Contractor.Services
{
  public class ContractorsService
  {
    private readonly ContractorsRepository _cr;

    public ContractorsService(ContractorsRepository cr)
    {
      _cr = cr;
    }

    internal List<ContractorModel> GetAll()
    {
      return _cr.GetAll();
    }

    internal ContractorModel GetOne(int id)
    {
      return _cr.GetOne(id);
    }

    internal ContractorModel Create(ContractorModel contractorData)
    {
      return _cr.Create(contractorData);
    }

    internal ContractorModel Update(ContractorModel contractorData)
    {
      int updated = _cr.Update(contractorData);
      if (updated > 0)
      {
        return contractorData;
      }
      else
      {
        throw new Exception("Could Not Update.");
      }
    }

    internal string Delete(int id)
    {
      int deleted = _cr.Delete(id);
      if (deleted > 0)
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