using Backend.DataAccessObjects.Comment;
using Backend.DataAccessObjects.Favourite;
using Backend.DataAccessObjects.Movies;
using Backend.DataAccessObjects.User;
using Backend.EFCData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IMoviesInterface, MoviesImplementation>();
builder.Services.AddScoped<IUserInterface, UserImplementation>();
builder.Services.AddScoped<IFavouriteInterface, FavouriteImplementation>();
builder.Services.AddScoped<ICommentInterface, CommentImplementation>();

//if u dont add this addCors it https requests from client side will not work and will give problems
//due to CORS restrictions from web api side. 
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();