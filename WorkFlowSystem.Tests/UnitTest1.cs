using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using WorkFlowSystem.Application.DTO;
using WorkFlowSystem.Application.Repositories;
using WorkFlowSystem.Application.Services;
using WorkFlowSystem.Domain.Entities;
using WorkFlowSystem.Infrastructure.Infra;

namespace WorkFlowSystem.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task AddProjectAsync_Should_Save_Project_To_Database()
        {
            // Arrange

            using var context = DbContextFactory.Create();


            IRepository<Project> repository =
                new Repository<Project>(context);


            var service = new ProjectService(repository);


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
