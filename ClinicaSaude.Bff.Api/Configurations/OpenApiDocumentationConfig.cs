using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClinicaSaude.Bff.Borders.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ClinicaSaude.Bff.Api.Configurations
{
    public static class OpenApiDocumentationConfig
    {
        public static IServiceCollection AddOpenApiDocumentation(this IServiceCollection services, ApplicationConfig config)
        {
            services.AddSwaggerGen(c =>
            {
                // Utiliza anotações de referências nulas para enriquecer os tipos gerados na documentação da API.
                c.SupportNonNullableReferenceTypes();
                c.SwaggerDoc(
                    "v1",
                    new() {
                        Title = "ClinicaSaude.Bff",
                        Version = "v1",
                        // Enriquece descrição com informações sobre o projeto, build e delpoy da aplicação.
                        // Mais informações: https://pottencial.sharepoint.com/sites/arquitetura.ti2/SitePages/Como-enriquecer-a-documenta%C3%A7%C3%A3o-do-Swagger.aspx
                        Description = BuildOpenApiDescription(config.ApiInfo),
                    }
                );

                // Encontra arquivos de documentação XML e os utiliza na geração de documentação da API.
                var xmlFiles = Directory
                    .GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly)
                    .ToList();
                xmlFiles.ForEach(xmlFile => c.IncludeXmlComments(xmlFile));

                // Configura métodos de autenticação suportados pela API, para que os mesmos sejam exibidos na documentação.
                var securityDefinitionid = "openIdConnect";
                var scope = config.Authentication.Audience;
                c.AddSecurityDefinition(securityDefinitionid, new()
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new()
                    {
                        ClientCredentials = new()
                        {
                            AuthorizationUrl = config.Authentication.Authority,
                            Scopes = new Dictionary<string, string> { { scope, "" } },
                            TokenUrl = new(config.Authentication.Authority, "/connect/token"),
                        }
                    }
                });
                c.AddSecurityRequirement(new()
                {
                    {
                        new()
                        {
                            Reference = new() { Type = ReferenceType.SecurityScheme, Id = securityDefinitionid }
                        },
                        new[] { scope }
                    }
                });
            });

            return services;
        }

        private static string? BuildOpenApiDescription(ApiInfo? apiInfo)
        {
            if (apiInfo is null)
            {
                return null;
            }
            return @$"### Build
- **Gerado em:** {apiInfo.BuildDate}
- **Pipeline:** [{apiInfo.BuildPipelineNumber}]({apiInfo.BuildPipelineUrl})
- **Branch:** [{apiInfo.BuildBranchName}]({apiInfo.BuildBranchUrl})
### Publicação
- **Gerada em:** {apiInfo.DeploymentDate}
- **Pipeline:** [{apiInfo.DeploymentPipelineNumber}]({apiInfo.DeploymentPipelineUrl})
### Projeto
- **Repositório:** [{apiInfo.BuildRepositoryName}]({apiInfo.BuildRepositoryUrl})
- **[Logs]({apiInfo.LogsUrl})**";
        }
    }
}