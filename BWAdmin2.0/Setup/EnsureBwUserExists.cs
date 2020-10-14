using System;
using System.Linq;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace BWAdmin2._0.Setup
{
    public static class BwExistsExtension
    {
        public static IApplicationBuilder EnsureBwUserExists(this IApplicationBuilder app, BwAdminContext context, IConfiguration configuration)
        {
            var bwInfo = configuration.GetSection(BwInfo.Section).Get<BwInfo>();

            if (context.Users.FirstOrDefault(x => x.Username == bwInfo.UserName && !x.IsDeleted) != null) return app;
            var personInfoId = Guid.NewGuid();

            var personInfo = new PersonInfo
            {
                Id = personInfoId,
                BtwNummer = bwInfo.VatNumber,
                Email = bwInfo.Email,
                Name = bwInfo.UserName,
                TelefoonNummer = bwInfo.Phone
            };

            var user = new User
            {
                Id = Guid.NewGuid(),
                IsDeleted = false,
                Username = bwInfo.UserName,
                Password = "testForNow",
                PersonInfoId = personInfoId,
                UserInfo = personInfo
            };

            context.Users.Add(user);
            context.SaveChanges();

            return app;
        }
    }
}
