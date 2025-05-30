using Microsoft.Extensions.DependencyInjection;
using Nuta.Backend.Users.Infrastructure.Jobs;
using Quartz;

namespace Nuta.Backend.Users.Infrastructure.DependencyInjection;

internal static class QuartzServiceCollectionExtensions
{
    public static IServiceCollection AddQuartz(this IServiceCollection services)
    {
        services.AddQuartz(quartzConfigurator =>
        {
            quartzConfigurator.ScheduleJob<OutboxProcessorJob>(trigger =>
                trigger.WithIdentity("OutboxProcessorJob")
                    .StartNow()
                    .WithSimpleSchedule(x => x
                        .WithIntervalInSeconds(10)
                        .RepeatForever()));
        });

        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

        return services;
    }
}