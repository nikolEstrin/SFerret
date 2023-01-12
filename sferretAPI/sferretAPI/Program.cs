using MySqlConnector;
using sferretAPI;
using sferretAPI.Services;
using sferretAPI.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Add services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IWatchListService, WatchListService>();
builder.Services.AddScoped<IPostService, PostService>();

//builder.Services.AddTransient<MySqlConnection>(_ => new MySqlConnection("Server=127.0.0.1:3306;User ID=root;Password=matan2001;Database=sferret"));

builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow All", builder => { builder.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials(); });
});

var app = builder.Build();

app.UseMiddleware(typeof(ExceptionHandle));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Allow All");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
