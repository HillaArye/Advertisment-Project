using Advertisment;
using Advertisment.Core.Repositories;
using Advertisment.Core.Services;
using Advertisment.Data;
using Advertisment.Data.Repositories;
using Advertisment.Service;
using Advertisment.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IDataContext, DataContext>(); //עבור כל בקשה נוצר מופע חדש
/*builder.Services.AddDbContext<DataContext>();*/ //אותו מופע עבור כל ההרצה
//builder.Services.AddTransient<IDataContext, DataContext>(); //יוצר מופע חדש עבור כל פעם שנדרש (גם אם באותה הבקשה יהיה רשום כמה פעמים יצירת מופע חדש)

builder.Services.AddScoped<IAdverService, AdverService>();
builder.Services.AddScoped<IAdverRepository, AdverRepository>();

builder.Services.AddScoped<IAdvertiserService, AdvertiserService>();
builder.Services.AddScoped<IAdvertiserRepository, AdvertiserRepository>();

builder.Services.AddScoped<IRouteService, RouteService>();
builder.Services.AddScoped<IRouteRepository, RouteRepository>();

builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHappyThursdayMiddleware();

app.MapControllers();

app.Run();
