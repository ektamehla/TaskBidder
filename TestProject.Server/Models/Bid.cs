namespace TestProject.Server.Models
{
    public class Bid
    {
        public int BidId { get; set; }
        public int JobId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public Job Job { get; set; }
    }
}
