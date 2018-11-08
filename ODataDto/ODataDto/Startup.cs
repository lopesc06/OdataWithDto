using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using ODataDto.Entities;
using ODataDto.Models;
using ODataDto.Services.InterfaceImplementations;
using ODataDto.Services.Interfaces;

namespace ODataDto
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<MyDbcontext>(c => c.UseSqlServer("Server=tcp:ttrmajdbserver.database.windows.net,1433;Initial Catalog=ODATA;Persist Security Info=False;User ID=ArturoEscutia;Password=Lopesc_06;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            services.AddOData();
            services.AddTransient<IStudentInfoRepository, StudentInfoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            AutoMapper.Mapper.Initialize(cfg=>{
                cfg.CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.Apellidos, opt => opt.MapFrom(src=> src.Lastname))
                .ForMember(dest => dest.Username, opt=>opt.MapFrom(src => src.Alias));
                cfg.CreateMap<Course, CourseDto>();
            });

            app.UseMvc( b=>{
                b.Select().Expand().Filter().OrderBy().MaxTop(100).Count();
                b.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Student>("Stuudeent");
            builder.EntitySet<Course>("coursess");
            return builder.GetEdmModel();
        }
    }
}
