using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostsRepository _postsRepo;
        private readonly IUsersRepository _usersRepo;

        public PostsController(IPostsRepository postsRepo , IUsersRepository usersRepo)
        {
            _postsRepo = postsRepo;
            _usersRepo = usersRepo;
        }
        
        /// <summary>
        /// Get all posts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            var result  = await _postsRepo.ListPostsAsync();
            return Ok(result);
        }

        /// <summary>
        /// Get a post by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostById(int id)
        {
            var result = await _postsRepo.GetPostByIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Delete a post
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            await _postsRepo.DeletePostAsync(id);
            return Ok();
        }

        /// <summary>
        /// Create a post
        /// </summary>
        /// <param name="postReq"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreatePost([FromBody] PostReqDto postReq)
        {
            var userReq = await _usersRepo.GetUserAsync(postReq.UserId);
            var post = new Post
            {
                Title = postReq.Title,
                Url = postReq.Url,
                User = userReq,
                AppUserId = postReq.UserId,
                PostedAt = DateTime.Now
            };

            await _postsRepo.CreatePostAsync(post);
            return Ok(post);
        }
    }
}
