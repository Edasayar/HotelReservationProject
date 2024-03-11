using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IStaffDal, EfStaffDal>();

builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IRoomDal, EfRoomDal>();

builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IServicesDal, EfServiceDal>();

builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();

builder.Services.AddScoped<ISubscribeService, SubscribeService>();
builder.Services.AddScoped<ISubscribeDal, EfSubscribeDal>();

builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();

builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IBookingDal, EfBookingDal>();

builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IContactDal, EfContactDal>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(opt=>
{
    opt.AddPolicy("OtelApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("OtelApiCors");
app.UseAuthorization();

app.MapControllers();

app.Run();
