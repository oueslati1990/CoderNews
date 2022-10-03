using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class PostReqDto
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
    }
}
