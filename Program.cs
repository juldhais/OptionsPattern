using OptionsPattern.Options;

var builder = WebApplication.CreateBuilder(args);

// add http client service
builder.Services.AddHttpClient();

// add options service
builder.Services.AddOptions();

// configure HalodocUrlOptions value from appsettings
builder.Services.Configure<HalodocUrlOptions>(builder.Configuration.GetSection("HalodocUrlOptions"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();