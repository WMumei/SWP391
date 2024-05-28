namespace JewelryProductionOrder.Models
{
    public class QuotationRequest
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Status {  get; set; }

        //public int CustomerId { get; set; }
        //[ForeignKey("CustomerId")]
        //public User User { get; set; }

        //public int SalesStaffId { get; set; }
        //[ForeignKey("SalesStaffId")]
        //public User user { get; set; }

        //public int ManagerId { get; set; }
        //[ForeignKey("ManagerId")]
        //public User user { get; set; }
    }
}
