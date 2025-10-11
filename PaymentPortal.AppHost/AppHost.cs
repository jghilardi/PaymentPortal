var builder = DistributedApplication.CreateBuilder(args);

var paymentPortal = builder.AddProject<Projects.PaymentPortal_API>("paymentportal-api");

builder.AddProject<Projects.PaymentPortal_API>("paymentportal")
       .WithExternalHttpEndpoints()
       .WithReference(paymentPortal)
       .WaitFor(paymentPortal);

builder.Build().Run();
