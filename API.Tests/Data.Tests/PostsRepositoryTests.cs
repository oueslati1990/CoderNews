using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace API.Tests.Data.Tests
{
    public class PostsRepositoryTests
    {
        private readonly DbContextOptionsBuilder<DataContext> _optionsBuilder;
        private readonly DataContext _context;
        public PostsRepositoryTests()
        {
            _optionsBuilder = new DbContextOptionsBuilder<DataContext>()
                                 .UseInMemoryDatabase(Guid.NewGuid().ToString());
            _context = new DataContext(_optionsBuilder.Options);
        }

        [Fact]
        public async Task CreatePostAsync_CreatesPost_ReturnsOnePostInDatabase()
        {
            // Arrange
            var postId = 2;
            var post = new PostDto { Title = "1 st post", Id = postId };

            // Act
            var sut = new PostsRepository(_context);
            await sut.CreatePostAsync(post);

            // Assert
            Assert.Single(_context.Posts);
        }

        [Fact]
        public async Task GetPostByIdAsync_EnterId_ReturnsPost()
        {
            // Arrange
            var postId = 2;
            var post = new PostDto { Title = "1 st post", Id = postId };

            // Act
            var sut = new PostsRepository(_context);
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            var result = await sut.GetPostByIdAsync(postId);

            // Assert
            Assert.Equal(post, result);
        }

        [Fact]
        public async Task DeletePostAsync_EnterId_DatabaseEmpty()
        {
            // Arrange
            var postId = 2;
            var post = new PostDto { Title = "1 st post", Id = postId };

            // Act
            var sut = new PostsRepository(_context);
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            await sut.DeletePostAsync(postId);

            // Assert
            Assert.Equal(0, _context.Posts.Count());
        }

        [Fact]
        public async Task ListPostsAsync_AddTwoPosts_ReturnsTwoPosts()
        {
            // Arrange
            List<PostDto> posts = new List<PostDto>
            {
                new PostDto{Title = "post1"},
                new PostDto{Title = "post2"}
            };

            // Act
            var sut = new PostsRepository(_context);
            _context.Posts.AddRange(posts);
            await _context.SaveChangesAsync();

            var result = await sut.ListPostsAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }
    }
}
