var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSpaStaticFiles(options => options.RootPath = "wwwroot");
builder.Services.AddControllers();

var app = builder.Build();
app.UseSpaStaticFiles();
app.UseSpa(spaBuilder =>
{
    spaBuilder.Options.SourcePath = "wwwroot";
});
app.MapControllers();

app.Run();