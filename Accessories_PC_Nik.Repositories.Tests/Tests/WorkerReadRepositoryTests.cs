using Accessories_PC_Nik.Context.Tests;
using Accessories_PC_Nik.Repositories.Contracts.Interface;
using Accessories_PC_Nik.Repositories.Implementations;
using FluentAssertions;
using Xunit;

namespace Accessories_PC_Nik.Repositories.Tests.Tests
{
    /// <summary>
    /// ����� ��� <see cref="IWorkersReadRepository"/>
    /// </summary>
    public class WorkerReadRepositoryTests : AccessoriesContextInMemory
    {
        private readonly IWorkersReadRepository workersReadRepository;

        public WorkerReadRepositoryTests()
        {
            workersReadRepository = new WorkersReadRepository(Reader);
        }

        /// <summary>
        /// ���������� ������ ������ ����������
        /// </summary>
        [Fact]
        public async Task GetAllWorkerEmpty()
        {
            // Act
            var result = await workersReadRepository.GetAllAsync(CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEmpty();
        }

        /// <summary>
        /// ���������� ������ ����������
        /// </summary>
        [Fact]
        public async Task GetAllWorkersValue()
        {
            //Arrange
            var target = TestDataGenerator.Worker();
            await Context.Workers.AddRangeAsync(target,
                TestDataGenerator.Worker(x => x.DeletedAt = DateTimeOffset.UtcNow));
            await UnitOfWork.SaveChangesAsync(CancellationToken);

            // Act
            var result = await workersReadRepository.GetAllAsync(CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.HaveCount(1)
                .And.ContainSingle(x => x.Id == target.Id);
        }

        /// <summary>
        /// ��������� ��������� �� �������������� � ���������� null
        /// </summary>
        [Fact]
        public async Task GetByIdWorkerNull()
        {
            //Arrange
            var id = Guid.NewGuid();

            // Act
            var result = await workersReadRepository.GetByIdAsync(id, CancellationToken);

            // Assert
            result.Should().BeNull();
        }

        /// <summary>
        /// ��������� ��������� �� �������������� � ���������� ������
        /// </summary>
        [Fact]
        public async Task GetByIdWorkerValue()
        {
            //Arrange
            var target = TestDataGenerator.Worker();
            await Context.Workers.AddAsync(target);
            await UnitOfWork.SaveChangesAsync(CancellationToken);

            // Act
            var result = await workersReadRepository.GetByIdAsync(target.Id, CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEquivalentTo(target);
        }

        /// <summary>
        /// ��������� ������, ���������� �� ����� ����� - �� ����������
        /// </summary>
        [Fact]
        public async Task AnyByNumberWorkerFalse()
        {
            //Arrange
            var target = TestDataGenerator.Worker();

            // Act
            var result = await workersReadRepository.AnyByNumberAsync(target.Number, CancellationToken);

            // Assert
            result.Should()
                .BeFalse();
        }

        /// <summary>
        /// ��������� ������, ���������� �� ����� ����� - ����������
        /// </summary>
        [Fact]
        public async Task AnyByNumberWorkerTrue()
        {
            //Arrange
            var target = TestDataGenerator.Worker();
            await Context.Workers.AddAsync(target);
            await UnitOfWork.SaveChangesAsync(CancellationToken);

            // Act
            var result = await workersReadRepository.AnyByNumberAsync(target.Number, CancellationToken);

            // Assert
            result.Should()
                .BeTrue();
        }
    }

}