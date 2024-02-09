using TestDrivenPipelineHotel.Data;
using TestDrivenPipelineHotel.Data.Interfaces;
using TestDrivenPipelineHotel.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Register repository interfaces with their implementations
builder.Services.AddSingleton<IRoomRepository, RoomRepository>();
builder.Services.AddSingleton<IBookingRepository, BookingRepository>();
builder.Services.AddSingleton<IRoomTypeRepository, RoomTypeRepository>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

//Dirty Seed the FakeDB (Should not be done in prod but in this case I'm leaving it in the code.)
var roomRepository = app.Services.GetRequiredService<IRoomRepository>();
var bookingRepository = app.Services.GetRequiredService<IBookingRepository>();
var roomTypeRepository = app.Services.GetRequiredService<IRoomTypeRepository>();
TestDataInitializer.Initialize(roomRepository, bookingRepository, roomTypeRepository);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
