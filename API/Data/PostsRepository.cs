using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class PostsRepository : IPostsRepository
    {
        private readonly DataContext _context;

        public PostsRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreatePostAsync(PostDto post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) throw new Exception("No post with this id");

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task<PostDto> GetPostByIdAsync(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<IEnumerable<PostDto>> ListPostsAsync()
        {
            return await _context.Posts.ToListAsync();
        }
    }
}
