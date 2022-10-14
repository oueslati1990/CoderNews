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
        public async Task<ActionResult<IEnumerable<PostDto>>> GetPosts()
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
        public async Task<ActionResult<PostDto>> GetPostById(int id)
        {
            var result = await _postsRepo.GetPostByIdAsync(id);
            if (result == null) return NotFound();

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
            try
            {
                await _postsRepo.DeletePostAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
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
            if (!ModelState.IsValid || postReq == null) return BadRequest();

            var userReq = await _usersRepo.GetUserAsync(postReq.UserId);
            if (userReq == null) return NotFound();

            var post = new PostDto
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
