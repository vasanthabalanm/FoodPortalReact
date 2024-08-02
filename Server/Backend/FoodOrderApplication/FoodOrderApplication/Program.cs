using FoodOrderApplication.Middleware;
using FoodOrderBL.Interface;
using FoodOrderBL.MailHelper;
using FoodOrderBL.Mapper;
using FoodOrderBL.ServiceClass;
using FoodOrderDL.Models;
using FoodOrderDL.Repositories.IRepo;
using FoodOrderDL.Repositories.IServiceRepo;
using FoodOwnerDAL.Repositories.IServiceRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FoodOrderOwnerApplicationContext>();

builder.Services.AddScoped<IApprovedUser, ApprovedUserService>();
builder.Services.AddScoped<IApprovedUserRepo, ApprovedUserRepo>();
builder.Services.AddScoped<IPendingUser, PendingUserService>();
builder.Services.AddScoped<IPendingUserRepo, PendingUserRepo>();

builder.Services.AddTransient<IMailRepo,MailSer>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddTransient<MiddlewareHandler>();

//CORS policy
builder.Services.AddCors(opts =>
{
    opts.AddPolicy("CORSPolicy", options =>
    {
        options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CORSPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<MiddlewareHandler>();

app.MapControllers();

app.Run();
