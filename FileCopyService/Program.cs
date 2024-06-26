using FileCopyService;

var builder = Host.CreateApplicationBuilder(args);
builder.AddRequiredServices();
var host = builder.Build();
host.Run();
