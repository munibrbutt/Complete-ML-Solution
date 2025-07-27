using SentimentMiddleTier.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddHttpClient<SentimentService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});


// Build the app
var app = builder.Build();

app.UseCors("AllowFrontend");


// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Launches Swagger at /swagger
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Maps [ApiController] endpoints

app.Run();

