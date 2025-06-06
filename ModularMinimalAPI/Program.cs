var builder = WebApplication.CreateBuilder(args); 
builder.Services.AddScoped<ILearningActivityService, LearningActivityService>(); 
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(); 
var app = builder.Build(); 
app.UseSwagger(); 
app.UseSwaggerUI(); 
app.RegisterEndpoints(); 
app.Run();