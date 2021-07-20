using System;
using System.Collections.Generic;
using Contractor.Models;
using Dapper;
using System.Data;
using System.Linq;

namespace Contractor.Repositories
{
  public class JobsRepository
  {
    private readonly IDbConnection _db;
    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal List<Job> GetAll()
    {
      var sql = "SELECT * FROM jobs;";
      return _db.Query<Job>(sql).ToList();
    }

    internal Job GetOne(int id)
    {
      var sql = "SELECT * FROM jobs WHERE id = @id;";
      return _db.QueryFirstOrDefault(sql, new { id });
    }


    internal Job Create(Job jobData)
    {
      var sql = @"INSERT INTO jobs(title, description) 
      VALUES(@Title, @Description);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, jobData);
      jobData.Id = id;
      return jobData;
    }


    internal int Update(Job jobData)
    {
      var sql = @"UPDATE jobs 
      SET
      title = @Title,
      description = @Description
      WHERE id = @Id; ";

      return _db.Execute(sql, jobData);
    }

    internal int Delete(int id)
    {
      string sql = @"
      DELETE FROM jobs
      WHERE id = @id;";
      return _db.Execute(sql, new { id });
    }
  }
}