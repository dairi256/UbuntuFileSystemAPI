using Spectre.Console; // This gives me the ability to create a nice looking menu.

namespace UbuntuFileSystemAPI.Startup
{
    public class MainMenu
    {

        public void StartupDisplay()
        {
            Console.ForegroundColor = ConsoleColor.Green; // You can change this to however you like, but I prefe green because it's better for my eyes.
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║   Ubuntu File System API v1.0          ║");
            Console.WriteLine("╠════════════════════════════════════════╣");

            Console.WriteLine($"║   Uptime: {AppStatus.GetFormattedUptime(),-25} ║");

        }

        public static class AppStatus
        {
            private static DateTime startTime = DateTime.UtcNow;

            private static TimeSpan GetUptime()
            {
                return DateTime.UtcNow - startTime;
            }

            public static string GetFormattedUptime()
            {
                var uptime = GetUptime();
                if (uptime.TotalSeconds < 1)
                    return "Just started";
                if (uptime.TotalMinutes < 1)
                    return $"{uptime.Seconds}s";
                if (uptime.TotalHours < 1)
                    return $"{uptime.Minutes}m {uptime.Seconds}s";
                if (uptime.TotalDays < 1)
                    return $"{uptime.Hours}h {uptime.Minutes}m";
                return $"{uptime.Days}d {uptime.Hours}h {uptime.Minutes}m";
            }
        }

    }
}
