using HRDutyContract.DataAccess;
using Microsoft.EntityFrameworkCore;
using HRDutyContract.Application.HRDutyContract.Handlers;
using HRDutyContract.Application.Common.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

//  Register IHRContext for DI
builder.Services.AddScoped<IHRContext>(provider =>
    provider.GetRequiredService<ApplicationDbContext>());

// Add MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetContractsListQueryHandler).Assembly);
});


// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ======= Add CORS =======
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
// =========================

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ======= Use CORS =======
app.UseCors("AllowAll");
// ========================

app.UseAuthorization();

app.MapControllers();

app.Run();
