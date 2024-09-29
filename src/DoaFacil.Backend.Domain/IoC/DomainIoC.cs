using DoaFacil.Backend.Domain.Notification;
using Microsoft.Extensions.DependencyInjection;

namespace DoaFacil.Backend.Domain.IoC
{
    public static class DomainIoC
    {
        public static void Register(IServiceCollection services) => RegisterNotifications(services);

        private static void RegisterNotifications(IServiceCollection services)
        {
            services
                .AddScoped<NotificationManager>()
                .AddScoped<INotificationReader>(sp => sp.GetRequiredService<NotificationManager>())
                .AddScoped<INotificationWriter>(sp => sp.GetRequiredService<NotificationManager>());
        }
    }
}
