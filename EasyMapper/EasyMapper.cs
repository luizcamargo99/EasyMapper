using System.Reflection;

namespace ApplicationService.Extensions
{
    public static class EasyMapper
    {
        public static T2 MapTo<T1, T2>(this T1 source, T2 destination)
        {
            var propertiesSource = source?.GetProperties();
            var propertiesDestination = destination?.GetProperties();

            for (int i = 0; i < propertiesSource?.Length; i++)
            {
                var propertySource = propertiesSource[i];
                var propertyDestination = propertiesDestination?.FirstOrDefault(p => p.Name == propertySource.Name && p.PropertyType == propertySource.PropertyType);

                if (propertyDestination != null)
                {
                    propertyDestination.SetValue(destination, propertySource.GetValue(source));
                }
            }

            return destination;
        }

        private static PropertyInfo[] GetProperties(this object obj)
        {
            return obj.GetType().GetProperties();
        }
    }
}