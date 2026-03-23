using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BuildingBlocks.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse>(ILogger<LoggingBehaviour<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull, IRequest<TResponse>
        where TResponse : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation("Request : {request} - Response : {response}", typeof(TRequest).Name, typeof(TResponse).Name);
            var sw = Stopwatch.StartNew();
            sw.Start();

            var result = await next();

            sw.Stop();
            var elapsedSeconds = sw.Elapsed.Seconds;
            logger.LogInformation("Request : {request} - Response : {response} - TimeTaken : {timetaken}", typeof(TRequest).Name, typeof(TResponse).Name, elapsedSeconds);

            if(elapsedSeconds > 3)
                logger.LogInformation("Performance Bottleneck : Request : {request} - Response : {response}", typeof(TRequest).Name, typeof(TResponse).Name);

            return result;
        }
    }
}
