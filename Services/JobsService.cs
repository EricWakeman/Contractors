using System;
using System.Collections.Generic;
using Contractor.Models;
using Contractor.Repositories;

namespace Contractor.Services
{
  public class JobsService
  {
    private readonly JobsRepository _jr;
    public List<Job> GetAll()
    {
      List<Job> jobs = _jr.GetAll();
      return jobs;
    }

    public Job GetOne(int id)
    {
      Job job = _jr.GetOne(id);
      return job;
    }

    public Job Create(Job jobData)
    {
      Job job = _jr.Create(jobData);
      return job;
    }

    public Job Update(Job jobData, int id)
    {
      jobData.Id = id;
      Job original = GetOne(id);
      jobData.Title = jobData.Title != null ? jobData.Title : original.Title;
      jobData.Description = jobData.Description != null ? jobData.Description : original.Description;

      int updated = _jr.Update(jobData);
      if (updated > 0)
      {
        return jobData;
      }
      else
      {
        throw new Exception("Could not Update");
      }

    }

    public string Delete(int id)
    {
      int deleted = _jr.Delete(id);
      if (deleted > 0)
      {
        return "Successfully Deleted.";
      }
      else
      {
        throw new Exception("Could Not Delete.");
      }
    }
  }
}