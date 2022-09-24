using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public AppUser User {get; set;}
        public int AppUserId { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
        public DateTime PostedAt { get; set; }
    }
}