using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppUser 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }   
        public string LastName { get; set; }  
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Post> Posts { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }
    }
}