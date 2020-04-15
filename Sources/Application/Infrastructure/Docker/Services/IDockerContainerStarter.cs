using System.Threading.Tasks;
using Mmu.Mlh.TestingExtensions.Infrastructure.Docker.Models;

namespace Mmu.Mlh.TestingExtensions.Infrastructure.Docker.Services
{
    public interface IDockerContainerStarter
    {
        Task<DockerContainerStartResult> StartMsSqlContainerAsync();
    }
}