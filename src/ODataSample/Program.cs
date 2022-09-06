using Microsoft.AspNetCore.OData;
using ODataSample;
using ODataSample.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add DbContext
builder.Services.RegisterDbContext<ODataDbContext>(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.AddDbContext()

builder.Services.AddControllers()
  .AddOData(options =>
  {
    options.AddRouteComponents("odata", ODataDbContext.GetEdmModel());
    options.Select().Filter().Count().OrderBy().Expand();
  });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.ApplyMigration<ODataDbContext>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
