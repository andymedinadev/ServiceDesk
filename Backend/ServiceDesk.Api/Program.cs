using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder
    .Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddUserSecrets<Program>(optional: true)
    .AddEnvironmentVariables();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ServiceDeskDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAttachmentStorage, AttachmentStorage>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Handlers
builder.Services.AddScoped<CreateTicketHandler>();
builder.Services.AddScoped<UpdateTicketDetailsHandler>();
builder.Services.AddScoped<SetTicketPriorityHandler>();
builder.Services.AddScoped<AssignTicketHandler>();
builder.Services.AddScoped<ChangeTicketStatusHandler>();
builder.Services.AddScoped<AddTicketAttachmentHandler>();
builder.Services.AddScoped<CloseTicketHandler>();

// Validators
builder.Services.AddScoped<IValidator<CreateTicketCommand>, CreateTicketCommandValidator>();
builder.Services.AddScoped<IValidator<CloseTicketCommand>, CloseTicketCommandValidator>();
builder.Services.AddScoped<
    IValidator<UpdateTicketDetailsCommand>,
    UpdateTicketDetailsCommandValidator
>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
