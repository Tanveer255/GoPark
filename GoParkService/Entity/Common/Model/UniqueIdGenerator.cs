namespace GoParkService.Entity.Common.Model;

public static class UniqueIdGenerator
{
    private static long _lastTimestamp = 0;
    private static int _sequence = 0;
    private static readonly object _lock = new object();

    public static string GenerateId()
    {
        lock (_lock)
        {
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            if (timestamp == _lastTimestamp)
            {
                _sequence++;
            }
            else
            {
                _sequence = 0;
                _lastTimestamp = timestamp;
            }

            return $"{timestamp:D13}-{_sequence:D4}"; // Format: 1678886400000-0001
        }
    }
}
