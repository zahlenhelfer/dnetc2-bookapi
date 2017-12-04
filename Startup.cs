﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Formatters;
using myBookAPI.Entities;
using Microsoft.EntityFrameworkCore;
using myBookAPI.Services;

namespace myBookAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()));

            //var connection = @"Server=(localdb)\mssqllocaldb;Database=mybookdb;Trusted_Connection=True;ConnectRetryCount=0";
            //services.AddDbContext<BookContext>(options => options.UseSqlServer(connection));

            var connection = Environment.GetEnvironmentVariable("dbConnection");
            services.AddDbContext<BookContext>(options => options.UseSqlite(connection));

            services.AddScoped<IBookRepository, BookRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
          BookContext bookContext)
        {
            bookContext.EnsureSeedDataForContext();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entities.Book, Models.BookDto>();
                cfg.CreateMap<Models.BookForCreationDto, Entities.Book>();
                cfg.CreateMap<Models.BookForUpdateDto, Entities.Book>();
                cfg.CreateMap<Entities.Book, Models.BookForUpdateDto>();
            });
            
            app.UseMvc();
            
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
