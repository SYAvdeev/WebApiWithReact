var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSpaStaticFiles(options => options.RootPath = "wwwroot");

var app = builder.Build();
app.UseSpaStaticFiles();
app.UseSpa(spaBuilder =>
{
    spaBuilder.Options.SourcePath = "wwwroot";
});

app.Run();