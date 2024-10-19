using System;
using System.Linq;

namespace NotificationChannelParser
{
    internal class Program
    {
        private static readonly string[] ActiveChannels = { "BE", "FE", "QA", "Urgent" };

        static void Main(string[] args)
        {
            var inputMessages = new[]
            {
                "[BE][FE][Urgent] there is error",
                "[BE][QA][HAHA][Urgent] there is error"
            };

            foreach (var message in inputMessages)
            {
                Console.WriteLine($"\nInput: {message}");
                Console.WriteLine($"Receive channels: {ParseNotificationChannel(message)}");
            }
        }

        static string ParseNotificationChannel(string inputMessage)
        {
            var channels = inputMessage
                .Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(part => ActiveChannels.Contains(part))
                .Distinct();

            return string.Join(", ", channels);
        }
    }
}
