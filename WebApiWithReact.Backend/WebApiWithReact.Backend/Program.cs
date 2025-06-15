var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    // Настройка политики CORS для конкретного маршрута
    options.AddPolicy("AllowSpecificRoute", policy =>
    {
        policy.WithOrigins("http://localhost:5210") // Разрешить запросы с указанного домена
            .AllowAnyMethod() // Разрешить любые HTTP-методы
            .AllowAnyHeader() // Разрешить любые заголовки
            .AllowCredentials(); // Разрешить использование credentials
    });
});

builder.Services.AddSpaStaticFiles(options => options.RootPath = "wwwroot");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowSpecificRoute");

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.UseSpaStaticFiles();
app.UseSpa(spaBuilder =>
{
    spaBuilder.Options.SourcePath = "wwwroot";
});

app.Run();