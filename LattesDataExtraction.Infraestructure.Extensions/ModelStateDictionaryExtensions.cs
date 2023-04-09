using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LattesDataExtraction.Infraestructure.Extensions
{
    public static class ModelStateDictionaryExtensions
    {
        public static ModelStateDictionary AddErrorsFromNotifications(this ModelStateDictionary modelState, IEnumerable<Notification> notifications)
        {
            notifications.ToList().ForEach(notification =>
            {
                modelState.AddModelError(notification.Key, notification.Message);
            });

            return modelState;
        }
    }
}