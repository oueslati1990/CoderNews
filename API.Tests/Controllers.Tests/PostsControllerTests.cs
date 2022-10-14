using API.Controllers;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace API.Tests.Controllers.Tests
{
    public class PostsControllerTests
    {
        private readonly PostsController _sut;
        private readonly Mock<IPostsRepository> postsRepoMock = new Mock<IPostsRepository>();
        private readonly Mock<IUsersRepository> usersRepoMock = new Mock<IUsersRepository>();

        public PostsControllerTests()
        {
            _sut = new PostsController(postsRepoMock.Object, usersRepoMock.Object);
        }
        [Fact]
        public async void GetPostById_EnterId_ReturnsTheCorrectPost()
        {
            // Arrange
            var post = new PostDto
            {
                Id = 4,
                Title = "Learn ",
                Url = "kkkk",
                AppUserId = 1,
                PostedAt = DateTime.Now
            };
            postsRepoMock.Setup(x => x.GetPostByIdAsync(4)).ReturnsAsync(post);

            // Act
            ActionResult<PostDto> result = await _sut.GetPostById(4);

            // Assert
            OkObjectResult objectResult = Assert.IsType<OkObjectResult>(result.Result);
            PostDto createdPost = Assert.IsType<PostDto>(objectResult.Value);
            Assert.Equal(post, createdPost);
        }

       

    }
}
