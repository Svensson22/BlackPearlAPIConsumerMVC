using SeidoDb.Web;

Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webbuilder =>
    {
        webbuilder.UseStartup<Startup>();
    })
    .Build()
    .Run();

Console.WriteLine("This executes after the webserver has stopped");

//skapa Branch

