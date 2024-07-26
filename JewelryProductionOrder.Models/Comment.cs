using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryProductionOrder.Models
{
	public class Comment
	{
		public int Id { get; set; }
		[StringLength(100)]
		public string Content { get; set; }
		public DateTime CreatedAt { get; set; }
		public string OwnerId { get; set; }
		[ForeignKey("OwnerId")]
		public User Owner { get; set; }
		public int PostId { get; set;}
		[ForeignKey("PostId")]
		public Post Post { get; set; }
	}
}