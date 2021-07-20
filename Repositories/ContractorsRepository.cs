using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Contractor.Models;
using Dapper;

namespace Contractor.Repositories
{
  public class ContractorsRepository
  {
    private readonly IDbConnection _db;

    public ContractorsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<ContractorModel> GetAll()
    {
      var sql = "SELECT * FROM contractors;";
      return _db.Query<ContractorModel>(sql).ToList();
    }

    internal ContractorModel GetOne(int id)
    {
      var sql = "SELECT * FROM contractors WHERE id = @id;";
      return _db.QueryFirstOrDefault<ContractorModel>(sql);
    }

    internal ContractorModel Create(ContractorModel contractorData)
    {
      var sql = "SELECT INTO contractors(name) VALUES(@Name);";
      return _db.ExecuteScalar<ContractorModel>(sql, contractorData);
    }

    internal int Update(ContractorModel contractorData)
    {
      var sql = @"UPDATE contractors SET
      name = @Name
      WHERE id = @Id;";
      return _db.Execute(sql, contractorData);
    }
    internal int Delete(int id)
    {
      var sql = "DELETE FROM contractors WHERE id = @id;";
      return _db.Execute(sql, new { id });
    }

  }
}