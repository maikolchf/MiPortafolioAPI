using Google.Cloud.Firestore;
using MiPortafolio.SHARED;

IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", FireBaseConf.CrearConfiguracionDB(configuration));

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSession(opt =>
//{
//    opt.IdleTimeout = TimeSpan.FromSeconds(10);
//    opt.Cookie.HttpOnly = true;
//    opt.Cookie.IsEssential = true; 
//});

builder.Services.AddSingleton(FirestoreDb.Create(configuration.GetSection("FirebaseConfig")["project_id"])); 


var app = builder.Build();

app.UseCors(opt =>
{
    opt.WithOrigins("http://localhost:4200");
    opt.AllowAnyMethod();
    opt.AllowAnyHeader();
});
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

//app.UseSession();
app.UseAuthorization();

app.MapControllers();

app.Run();
