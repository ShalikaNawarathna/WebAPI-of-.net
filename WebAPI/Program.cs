using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.Services;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DataBaseSettings>(builder.Configuration.GetSection(nameof(DataBaseSettings)));
builder.Services.AddSingleton<IDataBaseSettings>(Span => Span.GetRequiredService<IOptions<DataBaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("DataBaseSettings:ConnectionString")));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                      });
});
/*builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,

                      policy =>
                      {
                          policy.WithOrigins("https://localhost:44337/api/User"
                                             )
                          .AllowAnyHeader()
                                                  .AllowAnyMethod(); ;
                      });
}

);*/

builder.Services.AddControllers()
 .AddJsonOptions(
 options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepo, UserRepo>();

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
}

//app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run("http://*:5092");
