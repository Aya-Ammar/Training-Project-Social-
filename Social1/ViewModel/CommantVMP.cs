using Social1.Models;

namespace Social1.ViewModel
{
    public class CommantVMP
    {
        public long Id { get; set; }

        public string Body { get; set; } = null!;

        public DateTime Data { get; set; }

        public long Appuserid { get; set; }

        public long? Postid { get; set; }

      
    }
}
