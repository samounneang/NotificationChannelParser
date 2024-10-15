namespace NotificationChannelParser
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string InputMessageCase1 = "[BE][FE][Urgent] there is error";
            string InputMessageCase2 = "[BE][QA][HAHA][Urgent] there is error";

            Console.WriteLine($"\nInput: {InputMessageCase1}");
            Console.WriteLine($"Receive channels: {ParseNotificationChannel(InputMessageCase1)}");

            Console.WriteLine($"\nInput: {InputMessageCase2}");
            Console.WriteLine($"Receive channels: {ParseNotificationChannel(InputMessageCase2)}");
            
        }
        static string ParseNotificationChannel(string InputMessage)
        {
            string OutputMessage = string.Empty;
            string ActiveChannel = "BE,FE,QA,Urgent";

            string[] stringParts = InputMessage.Split(']');

            for (int i = 0; i < stringParts.Length - 1; i++)
            {
                if (stringParts[i].StartsWith("["))
                {
                    string channel = stringParts[i].TrimStart('[');
                    OutputMessage += ActiveChannel.Contains(channel) ? $"{channel}, " : "";
                }
            }

            return OutputMessage.Remove(OutputMessage.LastIndexOf(","));
        }
    }
}
