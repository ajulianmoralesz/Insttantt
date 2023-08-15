using Insttantt.Api.Filters;
using Insttantt.DataAccess;
using Insttantt.Application;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(mvcOpts =>
{
    mvcOpts.Filters.Add<ExceptionFilter>();
}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddApplication();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
        {
            Name = "Arnold Julian Morales Zapata",
            Email = "a_julianmorales@hotmail.com"
        },
        Version = "v1",
        Title = "Prueba Tecnica Insttantt",
        Description = "Portafolio de Apis para creación y ejecucion de flujos dinamicos"
    });
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "ApiDocumentation.xml");
    opt.IncludeXmlComments(filePath);
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
