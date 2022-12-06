using BackgroundQueue.Abstractions.Services.QueueServices;
using BackgroundQueue.Concrete.Services.HostedServices;
using BackgroundQueue.Concrete.Services.QueueServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging(x =>
{
    x.AddConsole();
    x.AddDebug();
});

builder.Services.AddSingleton<IMailQueueService, MailQueueService>();

builder.Services.AddHostedService<MailQueueHostedService>();

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
