using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public AppUser User { get; set; }
        public int AppUserId { get; set; }
        public PostDto Post { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
        public string PostedAt { get; set; }
    }
}