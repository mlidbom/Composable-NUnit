namespace Composable.Nunit.Test
{
    public interface IPointInTime
    {
           
    }

    public class PointInTime : IPointInTime
    {
        
    }

    public interface ITimeInterval
    {
        
    }
    public class FTimeInterval : ITimeInterval
    {
        
    }

    public static class TimeInterval
    {
        public static bool Contains(this ITimeInterval actual, IPointInTime point)
        {
            return true;
        }
    }
}