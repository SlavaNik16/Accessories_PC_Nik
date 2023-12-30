using Accessories_PC_Nik.Context.Tests;
using Accessories_PC_Nik.Repositories.Contracts.Interface;
using Accessories_PC_Nik.Repositories.Implementations;
using Accessories_PC_Nik.Tests.Generator;
using FluentAssertions;
using Xunit;

namespace Accessories_PC_Nik.Repositories.Tests.Tests
{
    /// <summary>
    /// ����� ��� <see cref="IClientsReadRepository"/>
    /// </summary>
    public class ClientReadRepositoryTests : AccessoriesContextInMemory
    {
        private readonly IClientsReadRepository clientsReadRepository;

        public ClientReadRepositoryTests()
        {
            clientsReadRepository = new ClientsReadRepository(Reader);
        }

        /// <summary>
        /// ���������� ������ ������ ��������
        /// </summary>
        [Fact]
        public async Task GetAllClientEmpty()
        {
            // Act
            var result = await clientsReadRepository.GetAllAsync(CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEmpty();
        }

        /// <summary>
        /// ���������� ������ ��������
        /// </summary>
        [Fact]
        public async Task GetAllClientsValue()
        {
            //Arrange
            var target = DataGeneratorRepository.Client();
            await Context.Clients.AddRangeAsync(target,
                DataGeneratorRepository.Client(x => x.DeletedAt = DateTimeOffset.UtcNow));
            await UnitOfWork.SaveChangesAsync(CancellationToken);

            // Act
            var result = await clientsReadRepository.GetAllAsync(CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.HaveCount(1)
                .And.ContainSingle(x => x.Id == target.Id);
        }

        /// <summary>
        /// ��������� ������� �� �������������� � ���������� null
        /// </summary>
        [Fact]
        public async Task GetByIdClientNull()
        {
            //Arrange
            var id = Guid.NewGuid();

            // Act
            var result = await clientsReadRepository.GetByIdAsync(id, CancellationToken);

            // Assert
            result.Should().BeNull();
        }

        /// <summary>
        /// ��������� ������� �� �������������� � ���������� ������
        /// </summary>
        [Fact]
        public async Task GetByIdClientValue()
        {
            //Arrange
            var target = DataGeneratorRepository.Client();
            await Context.Clients.AddAsync(target);
            await UnitOfWork.SaveChangesAsync(CancellationToken);

            // Act
            var result = await clientsReadRepository.GetByIdAsync(target.Id, CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEquivalentTo(target);
        }

        /// <summary>
        /// ��������� ������ �������� �� ��������������� � ���������� ������ ���������
        /// </summary>
        [Fact]
        public async Task GetByIdsClientsEmpty()
        {
            //Arrange
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var id3 = Guid.NewGuid();

            // Act
            var result = await clientsReadRepository.GetByIdsAsync(new[] { id1, id2, id3 }, CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEmpty();
        }

        /// <summary>
        /// ��������� ������ �������� �� ��������������� � ���������� ������
        /// </summary>
        [Fact]
        public async Task GetByIdsClientsValue()
        {
            //Arrange
            var target1 = DataGeneratorRepository.Client();
            var target2 = DataGeneratorRepository.Client(x => x.DeletedAt = DateTimeOffset.UtcNow);
            var target3 = DataGeneratorRepository.Client();
            var target4 = DataGeneratorRepository.Client();
            await Context.Clients.AddRangeAsync(target1, target2, target3, target4);
            await UnitOfWork.SaveChangesAsync(CancellationToken);

            // Act
            var result = await clientsReadRepository.GetByIdsAsync(new[] { target1.Id, target2.Id, target4.Id }, CancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.HaveCount(2)
                .And.ContainKey(target1.Id)
                .And.ContainKey(target4.Id);
        }

        /// <summary>
        /// ��������� ������, ���������� �� ����� ������� �� Id, ���������� false
        /// </summary>
        [Fact]
        public async Task AnyByIdClientFalse()
        {
            //Arrange
            var id = Guid.NewGuid();

            // Act
            var result = await clientsReadRepository.AnyByIdAsync(id, CancellationToken);

            // Assert
            result.Should()
                .BeFalse();
        }

        /// <summary>
        /// ��������� ������, ���������� �� ����� ������� �� Id, ���������� true
        /// </summary>
        [Fact]
        public async Task AnyByIdClientTrue()
        {
            //Arrange
            var target = DataGeneratorRepository.Client();
            await Context.Clients.AddAsync(target);
            await UnitOfWork.SaveChangesAsync(CancellationToken);

            // Act
            var result = await clientsReadRepository.AnyByIdAsync(target.Id, CancellationToken);

            // Assert
            result.Should()
                .BeTrue();
        }

        /// <summary>
        /// ��������� ������, ���������� �� ����� ������� - �� ����������
        /// </summary>
        [Fact]
        public async Task AnyByPhoneClientFalse()
        {
            //Arrange
            var target = DataGeneratorRepository.Client();

            // Act
            var result = await clientsReadRepository.AnyByPhoneAsync(target.Phone, CancellationToken);

            // Assert
            result.Should()
                .BeFalse();
        }

        /// <summary>
        /// ��������� ������, ���������� �� ����� ������� - ����������
        /// </summary>
        [Fact]
        public async Task AnyByPhoneClientTrue()
        {
            //Arrange
            var target = DataGeneratorRepository.Client();
            await Context.Clients.AddAsync(target);
            await UnitOfWork.SaveChangesAsync(CancellationToken);

            // Act
            var result = await clientsReadRepository.AnyByPhoneAsync(target.Phone, CancellationToken);

            // Assert
            result.Should()
                .BeTrue();
        }

        /// <summary>
        /// ��������� ������, ���������� �� ����� ����� - �� ����������
        /// </summary>
        [Fact]
        public async Task AnyByEmailClientFalse()
        {
            //Arrange
            var target = DataGeneratorRepository.Client();

            // Act
            var result = await clientsReadRepository.AnyByEmailAsync(target.Email, CancellationToken);

            // Assert
            result.Should()
                .BeFalse();
        }

        /// <summary>
        /// ��������� ������, ���������� �� ����� ����� - ����������
        /// </summary>
        [Fact]
        public async Task AnyByEmailClientTrue()
        {
            //Arrange
            var target = DataGeneratorRepository.Client();
            await Context.Clients.AddAsync(target);
            await UnitOfWork.SaveChangesAsync(CancellationToken);

            // Act
            var result = await clientsReadRepository.AnyByEmailAsync(target.Email, CancellationToken);

            // Assert
            result.Should()
                .BeTrue();
        }
    }
}