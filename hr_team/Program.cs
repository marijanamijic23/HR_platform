using hr_team;
using hr_team.Data;
using hr_team.Repository;
using hr_team.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<HrContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseSettings") ??
    throw new InvalidOperationException("Connection string not found."))
);

builder.Services.AddScoped<ICandidateChangeValueService, CandidateChangeValuesService>();
builder.Services.AddScoped<ICandidateGetValuesService, CandidateGetValuesService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<ICandidateSkillService, CandidateSkillService>();
builder.Services.AddScoped<SkillService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
}
);

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

app.MigrateDatabase();

app.Run();
