﻿using Accessories_PC_Nik.Api.ModelsRequest.Worker;
using Accessories_PC_Nik.Api.Validators.Worker;
using Accessories_PC_Nik.Repositories.Contracts.Interface;
using Accessories_PC_Nik.Tests.Generator;
using FluentValidation.TestHelper;
using Moq;
using Xunit;

namespace Accessories_PC_Nik.Api.Tests.ValidatorsTests
{
    /// <summary>
    /// Тесты <see cref="CreateWorkerRequestValidator"/>
    /// Тесты <see cref="EditWorkerRequestValidator"/>
    /// </summary>
    public class WorkerRequestValidatorTests
    {
        private readonly CreateWorkerRequestValidator validatorCreateRequest;
        private readonly EditWorkerRequestValidator validatorEditRequest;

        private readonly Mock<IClientsReadRepository> clientsReadRepositoryMock;
        private readonly Mock<IWorkersReadRepository> workersReadRepositoryMock;

        /// <summary>
        /// Инициализация <see cref="WorkerRequestValidatorTests"/>
        /// </summary>
        public WorkerRequestValidatorTests()
        {
            clientsReadRepositoryMock = new Mock<IClientsReadRepository>();
            workersReadRepositoryMock = new Mock<IWorkersReadRepository>();

            validatorCreateRequest = new CreateWorkerRequestValidator(
                clientsReadRepositoryMock.Object,
                workersReadRepositoryMock.Object);
            validatorEditRequest = new EditWorkerRequestValidator(
                clientsReadRepositoryMock.Object,
                workersReadRepositoryMock.Object);
        }

        /// <summary>
        /// Тест на наличие ошибок
        /// </summary>
        [Fact]
        public async void ValidatorCreateRequestShouldError()
        {
            //Arrange
            var model = new CreateWorkerRequest();

            //Act
            var validation = await validatorCreateRequest.TestValidateAsync(model);

            //Assert
            validation.ShouldHaveAnyValidationError();
        }

        /// <summary>
        /// Тест на отсутствие ошибок
        /// </summary>
        [Fact]
        public async void ValidatorCreateRequestShouldSuccess()
        {
            //Arrange
            var model = DataGeneratorApi.CreateWorkerRequest();

            clientsReadRepositoryMock.Setup(x => x.AnyByIdAsync(model.ClientId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            workersReadRepositoryMock.Setup(x => x.AnyByNumberAsync(model.Number, It.IsAny<CancellationToken>()))
               .ReturnsAsync(false);

            //Act
            var validation = await validatorCreateRequest.TestValidateAsync(model);

            //Assert
            validation.ShouldNotHaveAnyValidationErrors();
        }

        /// <summary>
        /// Тест на наличие ошибок
        /// </summary>
        [Fact]
        public async void ValidatorEditRequestShouldError()
        {
            //Arrange
            var model = new EditWorkerRequest();

            //Act
            var validation = await validatorEditRequest.TestValidateAsync(model);

            //Assert
            validation.ShouldHaveAnyValidationError();
        }

        /// <summary>
        /// Тест на отсутствие ошибок
        /// </summary>
        [Fact]
        public async void ValidatorEditRequestShouldSuccess()
        {
            //Arrange
            var model = DataGeneratorApi.EditWorkerRequest();

            clientsReadRepositoryMock.Setup(x => x.AnyByIdAsync(model.ClientId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            workersReadRepositoryMock.Setup(x => x.AnyByNumberAsync(model.Number, It.IsAny<CancellationToken>()))
               .ReturnsAsync(false);

            //Act
            var validation = await validatorEditRequest.TestValidateAsync(model);

            //Assert
            validation.ShouldNotHaveAnyValidationErrors();
        }
    }
}
