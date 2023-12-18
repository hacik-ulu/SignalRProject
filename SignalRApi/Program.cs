using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.EntityFramework;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// CORS POL�CY --> D��ar� a��lan API'�n s�n�rlar�n�/konfig�rasyonlar�n� ayarlar.

// CORS POL�CY konfig�rasyonlar�n�n eklenmesi.
// builder ile api'nin izinlerini/s�n�rlar�n� veriyoruz.
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader() // Herhangi bir ba�l�k
        .AllowAnyMethod() // Herhangi bir metod 
        .SetIsOriginAllowed((host) => true) // Herhangi bir host/sa�lay�c�
        .AllowCredentials(); // Herhangi bir kimlik
    });
});

// SignalR k�t�phanesinin eklenmesi.
builder.Services.AddSignalR();

// Add services to the container.
// Dbcontext'in eklenmesi.
// Auto mapper'�n eklenmesi.
builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// About API
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();

// Booking API
builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<IBookingDal, EfBookingDal>();

// Category API
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();

// Contact API
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();

// Discount API
builder.Services.AddScoped<IDiscountService, DiscountManager>();
builder.Services.AddScoped<IDiscountDal, EfDiscountDal>();

// Feature API
builder.Services.AddScoped<IFeatureService, FeatureManager>();
builder.Services.AddScoped<IFeatureDal, EfFeatureDal>();

// Product API
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EfProductDal>();

// Testimonial API
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();

// SocialMedia API
builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

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

// CorsPolicy'nin kullan�lmas�.
app.UseCors("CorsPolicy");  

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
