using backApiv2.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddMemoryCache(); //em caso de não querer usar redis - simples, mas menos performático, precisa ser bem manipulado

builder.Services.AddSingleton<IConnectionMultiplexer>(config => ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis")!));

// Configure RabbitMQ Connection
builder.Services.AddSingleton<RabbitMQ.Client.IConnectionFactory>(sp =>
{
    var rabbitConfig = builder.Configuration.GetConnectionString("RabbitMQ");
    if (string.IsNullOrEmpty(rabbitConfig)) throw new Exception("Error when try to read RabbitMQ Conn String");
    var factory = new RabbitMQ.Client.ConnectionFactory() { Uri = new Uri(rabbitConfig) };
    return factory;
});

builder.Services.AddSingleton<QueueService>();
//builder.Services.AddHostedService<QueueHostedService>();

builder.Services.AddCors(options =>
{ // Adjust port if necessary
    options.AddPolicy("AllowReactApp", policy => policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowReactApp");
app.UseAuthorization();
app.MapControllers();
app.Run();
