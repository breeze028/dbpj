using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SIMS.WebApi;
using SIMS.WebApi.Data;
using SIMS.WebApi.Services.Student;
using System.Configuration;
using System.Reflection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 配置 MySQL 连接
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("Default"),
        new MySqlServerVersion(new Version(8, 0, 21))  // MySQL 版本，请根据实际情况修改
    )
);

// 以下是 Autofac 依赖注入
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    // 注入 Service 程序集
    string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
    builder.RegisterAssemblyTypes(Assembly.Load(assemblyName))
        .AsImplementedInterfaces()
        .InstancePerDependency();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
