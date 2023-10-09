using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Common.Utilities
{
    public class PropertyMapper<T1, T2>
    {
        /// <summary>
        /// Maps the properties from one entity to another. Helper class to map single properties. This is to prevent the assignment of a single entity to another entity, when performing an update, this would not work. Use this method instead.
        /// </summary>
        /// <param name="toEntity">The source entity to map TO</param>
        /// <param name="fromEntity">The destination entity to map FROM</param>
        public static void Map(T1 toEntity, T2 fromEntity)
        {            
            if (toEntity != null && fromEntity != null)
            {
                // Get all properties of the entity type
                PropertyInfo[] properties = typeof(T2).GetProperties();

                foreach (var property in properties)
                {
                    // Find the matching property in existingItem by name
                    PropertyInfo existingItemProperty = fromEntity.GetType().GetProperty(property.Name);

                    if (existingItemProperty != null)
                    {
                        // Get the value from entity and set it in existingItem
                        object value = property.GetValue(fromEntity);
                        existingItemProperty.SetValue(toEntity, value);
                    }
                }
            }
        }
    }
}
