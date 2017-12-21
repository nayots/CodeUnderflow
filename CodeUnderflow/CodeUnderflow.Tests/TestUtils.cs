using AutoMapper;
using CodeUnderflow.Web.Infrastructure.AutoMapper;
using Microsoft.EntityFrameworkCore;
using CodeUnderflow.Data;
using System;
using CodeUnderflow.Web.Data;

namespace CodeUnderflow.Tests
{
    public class TestUtils
    {
        private static bool mapperInitialized;

        public CodeUnderflowDbContext GetDbContext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<CodeUnderflowDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var dbContext = new CodeUnderflowDbContext(dbContextOptions.Options);

            return dbContext;
        }

        public static void InitializeMapper()
        {
            if (mapperInitialized)
            {
                return;
            }

            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());

            mapperInitialized = true;
        }
    }
}