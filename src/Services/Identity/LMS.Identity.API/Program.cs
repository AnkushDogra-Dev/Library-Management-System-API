
using LMS.Identity.API.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddIdentityService(builder.Configuration);
builder.Configuration.AddUserSecrets<Program>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

await app.UseIdentityServices();

app.Run();




//1.Controller 2.command  validator  handler reposirtoy dbcontext string ya fir dto jo return krna he. fir handler ke upr ajayega..