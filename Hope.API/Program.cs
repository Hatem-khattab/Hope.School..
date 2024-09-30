using Hope.DomainEntites;
using Hope.Repositories.IRepository;
using Hope.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddScoped<ISectionTableRepository, SectionTableRepository>();
builder.Services.AddScoped<IStudentsTableRepository, StudentsTableRepository>();
builder.Services.AddScoped<ITeachersTableRepository, TeachersTableRepository>();

builder.Services.AddDbContext<HopeSchoolContext>();

builder.Services.AddDbContext<HopeSchoolContext>(options => options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings").Value));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
