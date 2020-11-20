using AutoMapper;
using Common.AutoMapper;
using Core.Services.Abstract;
using Core.Services.Concrete;
using Domain.Concrete;
using Domain.Context;
using Domain.Repository;
using Domain.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace News_Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(Startup));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);


            //services.AddAutoMapper((serviceProvider, automapper) => {
            //    automapper.AddProfile(new AutoMapping());
            //    //automapper.AddCollectionMappers();

            //}, typeof(Startup));

            services.AddDbContext<NewsContext>(opt =>
            {
                opt.UseSqlServer(Configuration["ConnectionStr"]);
            });

            services.AddIdentity<User, IdentityRole<int>>()
             .AddEntityFrameworkStores<NewsContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequireDigit = true;//sayı olması zorunlulugu
                opt.Password.RequiredLength = 5;// karakterden az olamaz
                opt.SignIn.RequireConfirmedAccount = false;
                opt.SignIn.RequireConfirmedEmail = false;
                opt.Password.RequireUppercase = false;//büyük harf olma zorunlulugu
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;//?!gibi karakterlerin zorunlulugu
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTWVXYZ0123456789-.@+";

            });

            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddMemoryCache();


            services.AddControllersWithViews();
            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.HttpOnly = false; //cookie javascript tarafından çekilsin diye
                opt.Cookie.Name = "MertCookie";
                opt.Cookie.SameSite = SameSiteMode.Strict; //cookie yi diger siteler erişemesin diye.lax yapsaydık erişilebilirdi.supdomainlerdahil
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;//eger http ile çalışıyorsak http den https ile calısıyorsak https üzerinden calısır
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);

            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=Register}/{id?}");
            });
        }
    }
}
