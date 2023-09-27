using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using MiPortafolio.SHARED;

//FirebaseApp.Create(new AppOptions()
//{
//    Credential = GoogleCredential.FromFile(FireBaseConf.CrearConfiguracionDB())
//});

Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", FireBaseConf.CrearConfiguracionDB());


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

builder.Services.AddSingleton(FirestoreDb.Create("miportafolio-279f1"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseSession();
app.UseAuthorization();

app.MapControllers();

app.Run();
