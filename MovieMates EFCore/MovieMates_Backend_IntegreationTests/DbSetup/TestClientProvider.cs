using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using MovieMates_Backend;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using MovieMates_Backend.DAL.Db;
using MovieMates_Backend.DAL;
using Microsoft.Extensions.Configuration;

namespace MovieMates_BackendInteGrationTests.DbSetup
{
    class TestClientProvider : IDisposable
    {
        public TestServer server;
        public HttpClient client { get; private set; }
        //public DatabaseContext context;


        public TestClientProvider(IConfiguration config)
        {
            server = new TestServer(new WebHostBuilder().UseStartup<Startup>().UseEnvironment("Testing"));
            

            //context = server.Host.Services.GetService(typeof(DatabaseContext)) as DatabaseContext;
            //context = server.Host.Services.GetService(new DatabaseContext()) as DatabaseContext;
            client = server.CreateClient();
        }

        public void Dispose()
        {
            server?.Dispose();
            client.Dispose();
        }
    }
}
