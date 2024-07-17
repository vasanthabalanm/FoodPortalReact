using HotelManageBL.Interface;
using HotelManageBL.Mapper;
using HotelManageBL.ServiceClass;
using HotelManageDL.MailHelper;
using HotelManageDL.Models;
using HotelManageDL.Repositories.IRepo;
using HotelManageDL.Repositories.ServiceRepo;
using HotelManageOrders.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HotelManagingApplicationContext>();

builder.Services.AddScoped<IHotelRepo,HotelRepo>();
builder.Services.AddScoped<IHotel, HotelService>();

builder.Services.AddScoped<IHotelBranchRepo,HotelBranchRepo>();
builder.Services.AddScoped<IHotelBranch, HotelBranchService>();

builder.Services.AddScoped<IMenuDetailRepo,MenuDetailRepo>();
builder.Services.AddScoped<IMenu, MenuService>();

builder.Services.AddScoped<IOrderRepo,OrderRepo>();
builder.Services.AddScoped<IOrder, OrderService>();

builder.Services.AddScoped<IUserViewMenuRepo,UserViewMenusRepo>();
builder.Services.AddScoped<IUserViewMenu,UserViewMenuService>();

builder.Services.AddScoped<IMailRepo, Mailrepo>();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddTransient<MiddlewareHandler>();

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
