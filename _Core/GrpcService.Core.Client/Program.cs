using Grpc.Net.Client;
using GrpcService.Core;
using static GrpcService.Core.Greeter;

GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:49163");

GreeterClient client = new GreeterClient(channel);

Console.WriteLine("Client connected...");

Console.WriteLine("Enter yout name:");

HelloReply result = client.SayHello(new HelloRequest
{
    Name = Console.ReadLine()
});

Console.WriteLine(result.Message);

Console.ReadKey();

channel.ShutdownAsync().Wait();