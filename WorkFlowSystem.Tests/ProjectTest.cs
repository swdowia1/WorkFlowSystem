using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using WorkFlowSystem.Application.DTO;

using WorkFlowSystem.Application.Services;

using WorkFlowSystem.Infrastructure.Persistence;
using WorkFlowSystem.Tests.KLasy;

namespace WorkFlowSystem.Tests
{
    public class ProjectTest
    {
        [Fact]
        public async Task AddProjectAsync_Should_Save_Project_To_Database()
        {
            // Arrange
             var provider = TestServiceProvider.Create();

            var service = provider.GetRequiredService<ProjectService>();
            var context = provider.GetRequiredService<ApplicationDbContext>();


            var dto = new ProjectDto
            {
                Name = "CRM",

                Description = "System CRM"
            };


            // Act

            await service.AddProjectAsync(dto);


            // Assert

            var project = await context.Projects
                .FirstOrDefaultAsync();


            project.Should().NotBeNull();


            project!.Name
                .Should()
                .Be("CRM");


            project.Description
                .Should()
                .Be("System CRM");
        }
    }
}
