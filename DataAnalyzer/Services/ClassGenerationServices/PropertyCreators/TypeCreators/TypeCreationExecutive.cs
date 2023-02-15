using System;
using System.Collections.Generic;

namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.TypeCreators
{
    internal class TypeCreationExecutive
    {
        private readonly IReadOnlyDictionary<string, ITypeCreator> creators = new Dictionary<string, ITypeCreator>()
        {
            { ClassCreationConstants.BOOL_TYPE, new BoolCreator() },
            { ClassCreationConstants.INT_TYPE, new IntCreator() },
            { ClassCreationConstants.DOUBLE_TYPE, new DoubleCreator() },
            { ClassCreationConstants.STRING_TYPE, new StringCreator() },
            { ClassCreationConstants.DATE_TIME_TYPE, new DateTimeCreator() },
        };

        public string Create(string dataType)
        {
            if (this.creators.TryGetValue(dataType, out ITypeCreator creator))
            {
                if (creator.IsApplicable(dataType))
                {
                    return creator.Create(dataType);
                }

                throw new ArgumentException($"{dataType} is not a valid data type for creator {creator.GetType().Name}");
            }

            throw new ArgumentException($"{dataType} is not a registered data type.");
        }
    }
}
