using Greating;
using gRPC.Server.Services;
using Grpc.Core;
using System;
using System.IO;
using gRPCServer = Grpc.Core.Server;

namespace gRPC.Server
{
    internal class Program
    {
        const int Port = 50051;

        static void Main(string[] args)
        {
            gRPCServer server = null;

            try
            {
                server = new gRPCServer()
                {
                    Services = { GreatingService.BindService(new GreatingAppService()) },
                    Ports = {
                        new ServerPort("localhost", Port, ServerCredentials.Insecure)
                    }
                };

                server.Start();

                Console.WriteLine("The server is listening on port: {0}", Port);
                Console.ReadKey();
            }
            catch (IOException ex)
            {
                Console.WriteLine("The server is failed to start, {0}", ex.Message);
            }
            finally
            {
                if (server != null)
                {
                    server.ShutdownAsync().Wait();
                }
            }
        }
    }
}
