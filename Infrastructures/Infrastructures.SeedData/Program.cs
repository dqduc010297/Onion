using ApplicationDomains.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Infrastructures.SeedData
{
    class Program
    {
        public static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            Console.WriteLine("Starting to seed data");

            _serviceProvider = ConfigureService(new ServiceCollection(), args);
            using (var dbContext = _serviceProvider.GetService<ApplicationDbContext>())
            {
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    SeedDataAsync(dbContext).Wait();
                    transaction.Commit();
                    Console.WriteLine("Commit all seed");
                }
            }
            Console.WriteLine("Seed data successfull");
        }

        public static IServiceProvider ConfigureService(IServiceCollection services, string[] args)
        {
            var dbContextFactory = new DesignTimeDbContextFactory();

            services.AddLogging();
            services.AddScoped<ApplicationDbContext>(p => dbContextFactory.CreateDbContext(args));
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options => {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;

                // User settings
                options.User.RequireUniqueEmail = true;
            });
            return services.BuildServiceProvider();
        }
        private static async Task SeedDataAsync(ApplicationDbContext dbContext)
        {
            IdentityResult createSystemUserResult = await SeedUserDataAsync(dbContext);
            if (createSystemUserResult.Succeeded)
            {
                await SeedRoleAsync(dbContext);
            }
        }

        private static async Task<IdentityResult> SeedUserDataAsync(ApplicationDbContext dbContext)
        {
            if(!await dbContext.Set<User>().AnyAsync())
            {
                Console.WriteLine("Start to seed user info");

                var userManagement = _serviceProvider.GetService<UserManager<User>>();
                var user = new User
                {
                    UserName = "system",
                    Email = "system@gmail.com",
                    PhoneNumber = "0909123007",
                    CreatedByUserId = null,
                    CreatedDate = DateTimeOffset.UtcNow,
                    CreatedByUserName = "system",
                    UpdatedByUserId = null,
                    UpdatedDate = DateTimeOffset.UtcNow,
                    UpdatedByUserName = "system",

                    Status = "Active"
                };
                IdentityResult rs =  await userManagement.CreateAsync(user, "Password@1");
                Console.WriteLine("Finished seed user info");
                return rs;
            }
            return null;
        }
        private static async Task SeedRoleAsync(ApplicationDbContext dbContext)
        {
            var roleManagers = _serviceProvider.GetService<RoleManager<Role>>();
            var userManager = _serviceProvider.GetService<UserManager<User>>();
            var systemUser = userManager.FindByNameAsync("system").Result;
            var roleAdmin = new Role
            {
                Name = "Administrator",
                CreatedByUserId = systemUser.Id.ToString(),
                CreatedDate = DateTimeOffset.UtcNow,
                CreatedByUserName = "system",
                ModifiedByUserId = systemUser.Id.ToString(),
                ModifiedDate = DateTimeOffset.UtcNow,
                ModifiedByUserName = "system"
            };
            await roleManagers.CreateAsync(roleAdmin);
            var roleManager = new Role
            {
                Name = "Manager",
                CreatedByUserId = systemUser.Id.ToString(),
                CreatedDate = DateTimeOffset.UtcNow,
                CreatedByUserName = "system",
                ModifiedByUserId = systemUser.Id.ToString(),
                ModifiedDate = DateTimeOffset.UtcNow,
                ModifiedByUserName = "system"
            };
            await roleManagers.CreateAsync(roleManager);
            var roleEmploy = new Role
            {
                Name = "Employees",
                CreatedByUserId = systemUser.Id.ToString(),
                CreatedDate = DateTimeOffset.UtcNow,
                CreatedByUserName = "system",
                ModifiedByUserId = systemUser.Id.ToString(),
                ModifiedDate = DateTimeOffset.UtcNow,
                ModifiedByUserName = "system"
            };
            await roleManagers.CreateAsync(roleEmploy);
        }
    }
}
