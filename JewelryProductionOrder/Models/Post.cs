namespace JewelryProductionOrder.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
        //public int SalesStaffId { get; set; }
        //[ForeignKey("SalesStaffId")]
        //public User user { get; set; }
    }
}
