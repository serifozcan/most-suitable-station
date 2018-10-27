using System;

namespace MostSuitableStation.Utilities
{
    public static class Ensure
    {
        [AttributeUsage(AttributeTargets.Parameter)]
        sealed class ValidatedNotNullAttribute : Attribute { }

        public static void ArgumentNotNull([ValidatedNotNull] object value, string name)
        {
            if (ReferenceEquals(value, null))
            {
                throw new ArgumentNullException(name);
            }
        }
    }
    
}
