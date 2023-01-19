using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Context;

namespace webapi.tests
{
    public static class ApiTestContext
    {
        public static WebApiContext GetApiTestContext()
        {
            var options = new DbContextOptionsBuilder<WebApiContext>().UseInMemoryDatabase(databaseName: "AppDb").Options;

            var dbContext = new WebApiContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            return dbContext;
        }
    }
}