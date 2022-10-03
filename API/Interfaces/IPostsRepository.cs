using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IPostsRepository
    {
        Task<IEnumerable<Post>> ListPostsAsync();
        Task<Post> GetPostByIdAsync(int id);
        Task DeletePostAsync(int id);
        Task CreatePostAsync(Post post);
    }
}
