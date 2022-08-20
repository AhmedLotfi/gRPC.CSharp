using Greating;
using Grpc.Core;
using System;
using System.Threading.Tasks;
using static Dummy.DummyService;
using static Greating.GreatingService;

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

            GreatingServiceClient greatingServiceClient = new GreatingServiceClient(channel);

            Console.WriteLine("Enter first name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter last name:");
            string lastName = Console.ReadLine();

            GreatingResponse resutl = greatingServiceClient.Great(new GreatingRequest
            {
                Greating = new Greating.Greating
                {
                    FirstName = firstName,
                    LastName = lastName
                }
            });

            Console.WriteLine("Greating Result: {0}", resutl);

            channel.ShutdownAsync().Wait();

            Console.ReadKey();
        }
    }
}
