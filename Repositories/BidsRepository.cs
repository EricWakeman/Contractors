using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Contractor.Models;
using Dapper;

namespace Contractor.Repositories
{
  public class BidsRepository
  {
    private readonly IDbConnection _db;
    internal List<Bid> GetAll()
    {
      var sql = @"SELECT * FROM bids; ";
      return _db.Query<Bid>(sql).ToList();
    }
    internal List<Bid> GetAllByJobId(int jobId)
    {
      var sql = @"SELECT * FROM bids WHERE jobId = @jobId; ";
      return _db.Query<Bid>(sql, jobId).ToList();
    }

    internal List<Bid> GetAllByContractorId(int contractorId)
    {
      var sql = @"SELECT * FROM bids WHERE contractorId = @contractorId; ";
      return _db.Query<Bid>(sql, contractorId).ToList();
    }

    internal Bid GetOne(int id)
    {
      var sql = @"SELECT * FROM bids WHERE id = @id;";
      return _db.QueryFirstOrDefault<Bid>(sql, new { id });
    }

    internal Bid Create(Bid bidData)
    {
      var sql = @"INSERT INTO bids(bidPrice, contractorId, jobId) 
      VALUES(@BidPrice, @ContractorId, @JobId);";
      return _db.ExecuteScalar<Bid>(sql, bidData);
    }

    internal int Update(Bid bidData)
    {
      var sql = @"UPDATE bids 
      SET
      bidPrice = @BidPrice
      WHERE id = @Id;";
      return _db.Execute(sql, bidData);
    }

    internal int Delete(int id)
    {
      var sql = "DELETE FROM bids WHERE id = @id;";
      return _db.Execute(sql, new { id });
    }
  }
}