using System;

namespace Contractor.Models
{
  public class Bid
  {
    public int Id { get; set; }
    public decimal BidPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int JobId { get; set; }
    public int ContractorId { get; set; }
    public Job Job { get; set; }
    public ContractorModel Contractor { get; set; }
  }
}