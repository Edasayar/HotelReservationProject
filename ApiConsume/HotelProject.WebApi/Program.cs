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

builder.Services.AddScoped<IGuestService, GuestService>();
builder.Services.AddScoped<IGuestDal, EfGuestDal>();

builder.Services.AddScoped<ISendMessageService, SendMessageService>();
builder.Services.AddScoped<ISendMessageDal, EfSendMessageDal>();

builder.Services.AddScoped<IMessageCategoryService, MessageCategoryService>();
builder.Services.AddScoped<IMessageCategoryDal, EfMessageCategoryDal>();

builder.Services.AddScoped<IWorkLocationService, WorkLocationService>();
builder.Services.AddScoped<IWorkLocationDal, EfWorkLocationDal>();

builder.Services.AddScoped<IAppUserService, AppUserService>();
builder.Services.AddScoped<IAppUserDal, EfAppUserDal>();


builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(opt=>
{
    opt.AddPolicy("OtelApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


// api taraf�nda AppUser consume edilirken ili�kili tablolardan dolay� json format�na d�n��t�r�lemedi�i i�in bunu uygulad�k verilerin gelmesini sa�lad�k
builder.Services.AddControllers().AddNewtonsoftJson(opt=> 
opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


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
