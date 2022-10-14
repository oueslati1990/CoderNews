using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IPostsRepository
    {
        Task<IEnumerable<PostDto>> ListPostsAsync();
        Task<PostDto> GetPostByIdAsync(int id);
        Task DeletePostAsync(int id);
        Task CreatePostAsync(PostDto post);
    }
}
