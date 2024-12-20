namespace Lb_9.Services;

public class NotificationErrorHandler
{
    public string Handle(Exception exception)
    {
        // Логіка обробки помилок
        if (exception is InvalidOperationException)
        {
            return "Operation is not allowed. Check the system configuration.";
        }
        else if (exception is ArgumentNullException)
        {
            return "A required parameter was null. Ensure all fields are provided.";
        }
        else
        {
            return $"An unexpected error occurred: {exception.Message}";
        }
    }
}