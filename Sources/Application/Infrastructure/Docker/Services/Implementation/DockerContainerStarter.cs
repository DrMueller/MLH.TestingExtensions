using System;
using System.Threading.Tasks;
using Mmu.Mlh.TestingExtensions.Infrastructure.Docker.Models;

namespace Mmu.Mlh.TestingExtensions.Infrastructure.Docker.Services.Implementation
{
    internal class DockerContainerStarter : IDockerContainerStarter
    {
        public Task<DockerContainerStartResult> StartMsSqlContainerAsync()
        {
            throw new NotImplementedException();
        }
    }
}
