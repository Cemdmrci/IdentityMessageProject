using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Message
	{
		public int MessageId { get; set; }
		public string SenderMail { get; set; }
		public string ReceiverMail { get; set; }
		public string Subject { get; set; }
		public string Content { get; set; }
		public DateTime CreatedAt { get; set; }
		public int AppUserId { get; set; }
		public AppUser AppUser { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
        public bool IsRead { get; set; }
    }
}
