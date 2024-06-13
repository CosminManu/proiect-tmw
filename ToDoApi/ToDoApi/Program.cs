var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();


//app.UseHttpsRedirection(); 
//if you hit 'http' endpoint it automatically sends you to 'https'; good to use http for android endpoints
//https can be used in dev environment, just a bit extra work to configure



app.Run();
