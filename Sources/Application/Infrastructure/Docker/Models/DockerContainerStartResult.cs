using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.TestingExtensions.Infrastructure.Docker.Models
{
    public class DockerContainerStartResult
    {
        public string ConnectionString { get; }

        public DockerContainerStartResult(string connectionString)
        {
            Guard.StringNotNullOrEmpty(() => connectionString);

            ConnectionString = connectionString;
        }
    }
}