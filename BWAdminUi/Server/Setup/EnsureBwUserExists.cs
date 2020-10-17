using System;
using System.Linq;
using BWAdminUi.Server.Data;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace BWAdminUi.Server.Setup
{
    public static class BwExistsExtension
    {
        public static IApplicationBuilder EnsureBwUserExists(this IApplicationBuilder app, ApplicationDbContext context, IConfiguration configuration)
        {
            var bwInfo = configuration.GetSection(BwInfo.Section).Get<BwInfo>();

            if (context.AppUsers.FirstOrDefault(x => x.Username == bwInfo.UserName && !x.IsDeleted) != null) return app;
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

            context.AppUsers.Add(user);
            context.SaveChanges();

            return app;
        }
    }
}
