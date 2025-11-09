using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryEntityFrameworkSqlServer.Context;
using RepositoryEntityFrameworkSqlServer.Entities;
using RepositoryEntityFrameworkSqlServer.Repositories.Implementations;

namespace Tests.Infraestructura.Out.RepositoryEntityFrameworkSqlServer.Repositories.Implementations
{
    public class TestTicketRepository
    {
        private readonly EntityDbContext _context;
        private readonly ITicketRepositoryPort _repository;

        public TestTicketRepository()
        {
            var options = new DbContextOptionsBuilder<EntityDbContext>()
                .UseInMemoryDatabase(databaseName: $"TestDB_{Guid.NewGuid()}")
                .Options;

            _context = new EntityDbContext(options);
            _repository = new TicketRepository(_context);
        }

        [Fact]
        public async Task AddAsync_Should_Add_New_Ticket()
        {
            // Arrange
            var model = new TicketModel
            {
                Usuario = "Yeimer",
                Estatus = "Abierto",
                FechaCreacion = DateTime.UtcNow
            };

            // Act
            var result = await _repository.AddAsync(model);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Yeimer", result.Usuario);
            Assert.Equal(1, _context.Ticket.Count());
        }

        [Fact]
        public async Task ExistRecordAsync_Should_Return_True_When_Record_Exists()
        {
            // Arrange
            var entity = new TicketEntity
            {
                Usuario = "Carlos",
                Estatus = "Cerrado",
                FechaCreacion = DateTime.UtcNow
            };
            _context.Ticket.Add(entity);
            await _context.SaveChangesAsync();

            // Act
            var exists = await _repository.ExistRecordAsync(entity.Id);

            // Assert
            Assert.True(exists);
        }

        [Fact]
        public async Task GetAsync_Should_Return_Ticket_By_Id()
        {
            // Arrange
            var entity = new TicketEntity
            {
                Usuario = "Laura",
                Estatus = "Pendiente",
                FechaCreacion = DateTime.UtcNow
            };
            _context.Ticket.Add(entity);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAsync(entity.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Laura", result.Usuario);
            Assert.Equal("Pendiente", result.Estatus);
        }

        [Fact]
        public async Task UpdateAsync_Should_Modify_Ticket_Data()
        {
            // Arrange
            var entity = new TicketEntity
            {
                Usuario = "Andres",
                Estatus = "Abierto",
                FechaCreacion = DateTime.UtcNow
            };
            _context.Ticket.Add(entity);
            await _context.SaveChangesAsync();

            _context.Entry(entity).State = EntityState.Detached;

            var updatedModel = new TicketModel
            {
                Id = entity.Id,
                Usuario = "Andres",
                Estatus = "Cerrado",
            };

            // Act
            var result = await _repository.UpdateAsync(updatedModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Cerrado", result.Estatus);
        }

        [Fact]
        public async Task DeleteAsync_Should_Remove_Record()
        {
            // Arrange
            var entity = new TicketEntity
            {
                Usuario = "Daniela",
                Estatus = "Abierto",
                FechaCreacion = DateTime.UtcNow
            };
            _context.Ticket.Add(entity);
            await _context.SaveChangesAsync();

            _context.Entry(entity).State = EntityState.Detached;

            var model = new TicketModel { Id = entity.Id };

            // Act
            await _repository.DeleteAsync(model);

            // Assert
            Assert.Empty(_context.Ticket);
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_Filtered_And_Paginated_Results()
        {
            // Arrange
            _context.Ticket.AddRange(
                new TicketEntity { Usuario = "Yeimer", Estatus = "Abierto", FechaCreacion = DateTime.UtcNow.AddDays(-2) },
                new TicketEntity { Usuario = "Yeimer", Estatus = "Cerrado", FechaCreacion = DateTime.UtcNow.AddDays(-1) },
                new TicketEntity { Usuario = "Pedro", Estatus = "Abierto", FechaCreacion = DateTime.UtcNow }
            );
            await _context.SaveChangesAsync();

            var filter = new TicketFilterModel
            {
                Usuario = "Yeimer",
                Estatus = "Abierto",
                Page = 1,
                PageSize = 5
            };

            // Act
            var result = await _repository.GetAllAsync(filter);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result.Items);
            Assert.Equal("Yeimer", result.Items.First().Usuario);
            Assert.Equal("Abierto", result.Items.First().Estatus);
        }

        [Fact]
        public async Task GetAllAsync_Should_Filter_By_Date_Range()
        {
            // Arrange
            _context.Ticket.AddRange(
                new TicketEntity { Usuario = "A", Estatus = "Abierto", FechaCreacion = DateTime.UtcNow.AddDays(-10) },
                new TicketEntity { Usuario = "B", Estatus = "Abierto", FechaCreacion = DateTime.UtcNow.AddDays(-3) },
                new TicketEntity { Usuario = "C", Estatus = "Abierto", FechaCreacion = DateTime.UtcNow }
            );
            await _context.SaveChangesAsync();

            var filter = new TicketFilterModel
            {
                FechaCreacionDesde = DateTime.UtcNow.AddDays(-5),
                FechaCreacionHasta = DateTime.UtcNow.AddDays(1),
                Page = 1,
                PageSize = 10
            };

            // Act
            var result = await _repository.GetAllAsync(filter);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Items.Count);
        }
    }
}
