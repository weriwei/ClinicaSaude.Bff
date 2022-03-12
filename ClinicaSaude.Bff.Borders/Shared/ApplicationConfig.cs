#nullable disable

using System;

namespace ClinicaSaude.Bff.Borders.Shared
{
    public record ApplicationConfig
    {
        public ConnectionStrings ConnectionStrings { get; init; }
        public AuthenticationConfig Authentication { get; init; }
        public ApiInfo ApiInfo { get; init; }
    }
    
    public record ConnectionStrings
    {
        public string DefaultConnection { get; init; }
    }
    
    public record AuthenticationConfig
    {
        public Uri Authority { get; init; }
        public string Audience { get; init; }
    }

    public record ApiInfo
    {
        public string BuildDate { get; init; }
        public string BuildPipelineNumber { get; init; }
        public string BuildPipelineUrl { get; init; }
        public string BuildRepositoryName { get; init; }
        public string BuildRepositoryUrl { get; init; }
        public string BuildBranchName { get; init; }
        public string BuildBranchUrl { get; init; }
        public string DeploymentDate { get; init; }
        public string DeploymentPipelineNumber { get; init; }
        public string DeploymentPipelineUrl { get; init; }
        public string LogsUrl { get; init; }
    }
}