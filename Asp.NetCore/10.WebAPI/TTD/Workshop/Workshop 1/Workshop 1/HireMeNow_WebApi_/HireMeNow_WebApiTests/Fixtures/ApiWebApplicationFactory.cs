
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeNow_WebApiTests.Fixtures
{
    public class ApiWebApplicationFactory :WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
           
            return base.CreateHost(builder);
        }
    }
}
