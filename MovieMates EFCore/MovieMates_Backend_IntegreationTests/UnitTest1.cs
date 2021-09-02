using Microsoft.Extensions.Configuration;
using MovieMates_Backend.DAL;
using MovieMates_Backend.Entities;
using MovieMates_BackendInteGrationTests.DbSetup;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace MovieMates_Backend_IntegreationTests
{
    public class UnitTest1
    {
        private readonly IConfiguration config;

        //DatabaseContext db;
        public UnitTest1( IConfiguration config)
        {
            this.config = config;
            //db = new DatabaseContext(config, "TestConnStr");
        }


        [Fact]
        public async Task Get()
        {
            using (var client = new TestClientProvider(config).client)
            {
                var response = await client.GetAsync("/api/movie/all");

                string jsonresult = await response.Content.ReadAsStringAsync();
                List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(jsonresult);
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        
        [Fact]
        public async Task Test_Post()
        {
            //using (var context = new TestClientProvider(config).context)
            //{
            //    context.Movies.Add(new Movie { Title = "Dora The Explorer", Description = "Lorem Ipsum", Platform = Platforms.DisneyPlus, IMDb = 8.4, ReleaseYear = new DateTime(2019, 4, 24), RunTime = "3.01", MovieGenres = new List<Genre> { new Genre { GenreName = "Action" } } });
            //    context.SaveChanges();
            //}

            //using (var client = new TestClientProvider().client)
            //{
            //    var response = await client.GetAsync($"/api/movies/all");
            //    //var x = response.EnsureSuccessStatusCode();
            //   // x.StatusCode.Should().Be(HttpStatusCode.OK);

            //    

            //    Assert.Single(movies);
            //}

        }
    }
}
