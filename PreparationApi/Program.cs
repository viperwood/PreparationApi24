var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddCors(x =>
{
    x.AddPolicy(name:"Politica", polit =>
    {
        polit.WithOrigins().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapControllers();
app.UseCors("Politica");
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.Run();