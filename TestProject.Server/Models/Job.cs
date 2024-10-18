using System.Security.Cryptography;
using System.Collections.Generic;
namespace TestProject.Server.Models
{
    public class Job
    {
        public int JobId { get; set; }

        //public string _desc;

        //public string Description
        //{
        //    get => _desc;

        //    set
        //    {
        //        _desc = value; if (value.Length > 100)
        //        {
        //            throw new ArgumentException("error");
        //            _desc = value;
        //        }
        //    }
        //}
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string PosterName { get; set; }
        public string ContactInfo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpirationDate { get; set; }

        public List<Bid> Bids { get; set; } = new List<Bid>();
        public int BidCount => Bids.Count;
        public decimal? LowestBid => Bids.Count > 0 ? Bids.Min(b => b.Amount) : (decimal?)null;

    }
}
