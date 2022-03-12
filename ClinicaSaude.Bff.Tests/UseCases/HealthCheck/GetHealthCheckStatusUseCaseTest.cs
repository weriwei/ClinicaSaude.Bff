using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Dtos.HealthCheck;
using ClinicaSaude.Bff.Borders.Repositories;
using ClinicaSaude.Bff.Borders.Shared;
using ClinicaSaude.Bff.UseCases.HealthCheck;
using FluentAssertions;
using Moq;
using Xunit;

namespace ClinicaSaude.Bff.Tests.UseCases.HealthCheck
{
    public class GetHealthCheckStatusUseCaseTest
    {
        private readonly Mock<IDatabaseRepository> databaseRepository = new();
        private readonly GetHealthCheckStatusUseCase useCase;

        public GetHealthCheckStatusUseCaseTest()
        {
            useCase = new(databaseRepository.Object);
        }

        [Fact(DisplayName = "Retorna status indisponívelquando todas as dependência estão saudáveis")]
        public async Task Execute_ReturnsSuccess_WhenAllDependenciesAreHealth()
        {
            // Arrange
            databaseRepository.Setup(it => it.CheckHealth()).ReturnsAsync(true);

            // Act
            var response = await useCase.Execute();

            // Assert
            response.Status.Should().Be(UseCaseResponseKind.Success);
            response.Result.Activities.Should().HaveCount(1);
            response.Result.Activities.Should().ContainEquivalentOf(new HealthCheckActivity(Name: "Database", Success: true));
        }
        
        // TODO: Adicionar assert após alguma dependência ser adicionada no serviço. Ex: Banco de dados
        // [Fact(DisplayName = "Retorna status indisponível quando qualquer dependência não esta saudável")]
        // public async Task Execute_ReturnsUnavailable_WhenAnyDependencyIsUnhealthy()
        // {
        //     // Arrange
        //     databaseRepository.Setup(it => it.CheckHealth()).ReturnsAsync(false);

        //     // Act
        //     var response = await useCase.Execute();

        //     // Assert
        //     response.Status.Should().Be(UseCaseResponseKind.Unavailable);
        //     response.Result.Activities.Should().HaveCount(1);
        //     response.Result.Activities.Should().ContainEquivalentOf(new HealthCheckActivity(Name: "Database", Success: false));
        // }
    }
}