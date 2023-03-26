using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace MyHermitage.HouseTest
{
    public class MockWebHostingEnv : IHostEnvironment
    {
        public string EnvironmentName { get; set; }
        public string ApplicationName { get; set; }
        public string ContentRootPath { get; set; }
        public IFileProvider ContentRootFileProvider { get; set; }
    }
}
