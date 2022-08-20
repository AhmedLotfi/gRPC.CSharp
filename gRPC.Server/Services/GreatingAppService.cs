using Greating;
using Grpc.Core;
using System.Threading.Tasks;
using static Greating.GreatingService;

namespace gRPC.Server.Services
{
    public class GreatingAppService : GreatingServiceBase
    {
        public override Task<GreatingResponse> Great(GreatingRequest request, ServerCallContext context)
        {
            if (string.IsNullOrEmpty(request.Greating.FirstName))
            {
                GreatingResponse response = new GreatingResponse { Result = "FirstName is required!!" };

                return Task.FromResult(response);
            }

            string result = string.Format("Hello: {0}, {1}", request.Greating.FirstName, request.Greating.LastName);

            return Task.FromResult(new GreatingResponse { Result = result });
        }
    }
}
