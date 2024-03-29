﻿using System.Threading;
using System.Threading.Tasks;
using Grpc.Net.Client;
using OzonEdu.MerchApi.Grpc;

namespace OzonEdu.MerchApi.GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new MerchApiGrpc.MerchApiGrpcClient(channel);

            var responseMerch = await client.RequestMerchAsync(new MerchRequest{Id = 43}, cancellationToken: CancellationToken.None);
            
            var responseMerchIssueInfo = await client.GetMerchIssuesInfoAsync(new MerchIssueRequest
            {
                MerchName = "T-shirt",
                EmployeeName = "Ivan"
            }, cancellationToken: CancellationToken.None);
        }
    }
}