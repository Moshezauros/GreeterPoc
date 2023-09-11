using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcGreeterClient;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7122");
var client = new Greeter.GreeterClient(channel);
Metadata headers = new()
{
    { "requestingUserId", "234" }
};
var reply = await client.SayHelloAsync(
                  new HelloRequest { Name = "GreeterClient" },
                  headers: headers
                  );
Console.WriteLine("Greeting: " + reply.Message);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();