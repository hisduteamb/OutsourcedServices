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

}

var app = builder.Build();
{

    // Configure the HTTP request pipeline.

    app.UseDefaultFiles();
    app.UseStaticFiles();

    app.UseHttpsRedirection();

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

