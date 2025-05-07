using ClienteApi.Data;
using ClienteApi.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Servicios 
var conn = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(conn));

builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(opt =>
                {
                    opt.SuppressModelStateInvalidFilter = false;
                });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build 
var app = builder.Build();

//  Pipeline 
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();   
app.UseApiKeyValidation();
app.MapControllers();

app.Run();
