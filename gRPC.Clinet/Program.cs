using Grpc.Core;
using System;
using System.Threading.Tasks;
using static Dummy.DummyService;

namespace gRPC.Clinet
{
    internal class Program
    {
        const string target = "127.0.0.1:50051";

        static void Main(string[] args)
        {
            Channel channel = new Channel(target, ChannelCredentials.Insecure);

            channel.ConnectAsync().ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    Console.WriteLine("The client connected successfully..");
                }
            });

            DummyServiceClient client = new DummyServiceClient(channel);

            channel.ShutdownAsync().Wait();

            Console.ReadKey();
        }
    }
}
