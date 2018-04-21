using System;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace UnitTestPlayground.Orm.EntityFramework
{
    public class ForeignKeyConvention : IStoreModelConvention<AssociationType>
    {
        public void Apply(AssociationType item, DbModel model)
        {
            // Identify a ForeignKey properties (including IAs)
            if (item == null || !item.IsForeignKey)
                return;

            // rename FK columns
            var constraint = item.Constraint;

            if (DoPropertiesHaveDefaultNames(constraint.FromProperties, constraint.ToProperties))
                NormalizeForeignKeyProperties(constraint.FromProperties);

            if (DoPropertiesHaveDefaultNames(constraint.ToProperties, constraint.FromProperties))
                NormalizeForeignKeyProperties(constraint.ToProperties);
        }

        static bool DoPropertiesHaveDefaultNames(ReadOnlyMetadataCollection<EdmProperty> properties, ReadOnlyMetadataCollection<EdmProperty> otherEndProperties)
        {
            if (properties.Count != otherEndProperties.Count)
                return false;

            for (int i = 0; i < properties.Count; ++i)
            {
                if (!properties[i].Name.EndsWith("_" + otherEndProperties[i].Name, StringComparison.OrdinalIgnoreCase))
                    return false;
            }
            return true;
        }

        static void NormalizeForeignKeyProperties(ReadOnlyMetadataCollection<EdmProperty> properties)
        {
            for (int i = 0; i < properties.Count; ++i)
            {
                int underscoreIndex = properties[i].Name.IndexOf('_');
                if (underscoreIndex > 0)
                    properties[i].Name = properties[i].Name.Remove(underscoreIndex, 1);
            }
        }
    }
}