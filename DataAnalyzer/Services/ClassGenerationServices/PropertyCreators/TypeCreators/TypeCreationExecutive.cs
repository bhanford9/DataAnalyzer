using System;
using System.Collections.Generic;

namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.TypeCreators
{
    internal class TypeCreationExecutive : ITypeCreationExecutive
    {
        private readonly IReadOnlyDictionary<string, ITypeCreator> creators = new Dictionary<string, ITypeCreator>()
        {
            { ClassCreationConstants.BOOL_TYPE_DISPLAY, new BoolCreator() },
            { ClassCreationConstants.INT_TYPE_DISPLAY, new IntCreator() },
            { ClassCreationConstants.DOUBLE_TYPE_DISPLAY, new DoubleCreator() },
            { ClassCreationConstants.STRING_TYPE_DISPLAY, new StringCreator() },
            { ClassCreationConstants.DATE_TIME_TYPE_DISPLAY, new DateTimeCreator() },
        };

        public TypeCreationExecutive(IReadOnlyDictionary<string, ITypeCreator> creators)
        {
            this.creators = creators;
        }

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
