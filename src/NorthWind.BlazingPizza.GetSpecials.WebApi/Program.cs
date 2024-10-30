using NothWind.BlazingPizza.GetSpecials.BusinnesObjects.Interfaces;
using NothWind.BlazingPizza.GetSpecials.Entities.ValueObjectes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Con IoC
builder.Services.AddGetSpecialMainServices(getSpecialOptions =>
    {
        builder.Configuration.GetRequiredSection(GetSpecialsOptions.SectionKey)
        .Bind(getSpecialOptions);
    },
    getSpecialDBOptions =>
    {
        builder.Configuration.GetRequiredSection(GetSpecialsDBOptions.SectionKey)
        .Bind(getSpecialDBOptions);
    }
);

// Sin IoC, antes hay q agregar las mismas referecias que tendria IoC
//builder.Services.AddGetSpecialCoreServices(getSpecialOptions =>
//{
//    builder.Configuration.GetRequiredSection(GetSpecialsOptions.SectionKey)
//    .Bind(getSpecialOptions);
//});
//builder.Services.AddRepositoryServices(getSpecialDBOptions =>
//{
//    builder.Configuration.GetRequiredSection(GetSpecialsDBOptions.SectionKey)
//    .Bind(getSpecialDBOptions);
//});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    });
});

builder.Services.AddDistributedMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet(EndPoint.GetSpecial,
           async (IGetSpecialsController controller) 
           => TypedResults.Ok(await controller.GetSpecialsAsync())
           );

app.InitializeDb();

app.Run();