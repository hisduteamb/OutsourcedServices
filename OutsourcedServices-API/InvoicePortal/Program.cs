using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Repositories;
using System.Text.Json.Serialization;
using YourNamespace.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    var services = builder.Services;
    var env = builder.Environment;

    builder.Services.AddControllers();

   
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    

    services.AddCors();

    services.AddControllers().AddJsonOptions(x =>
    {
        // serialize enums as strings in api responses (e.g. Role)
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

    }).AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });



    



    services.AddSingleton<GenericRepository>();
    services.AddSingleton<CompanyRepository>();
    services.AddSingleton<ServiceRepository>();
    services.AddSingleton<CompanyServiceRepository>();
    services.AddSingleton<StaffRepository>();
    services.AddSingleton<RootRepository>();
    services.AddSingleton<InvoiceRepository>();

}

var app = builder.Build();
{

    // Configure the HTTP request pipeline.

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", ".NET Sign-up and Verification API"));
    }


    var services = builder.Services;
    var env = builder.Environment;


    app.UseDefaultFiles();
    app.UseStaticFiles();

    app.UseHttpsRedirection();
    app.UseAuthentication();


    app.UseAuthorization();

    app.MapControllers();



    // global cors policy
    app.UseCors(x => x
        .SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());

}

app.Run();

