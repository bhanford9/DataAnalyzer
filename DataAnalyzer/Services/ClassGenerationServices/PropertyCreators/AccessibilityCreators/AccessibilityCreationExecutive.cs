using System;
using System.Collections.Generic;

namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.AccessibilityCreators
{
    internal class AccessibilityCreationExecutive : IAccessibilityCreationExecutive
    {
        private readonly IReadOnlyDictionary<string, IAccessibilityCreator> creators;

        public AccessibilityCreationExecutive(IReadOnlyDictionary<string, IAccessibilityCreator> creators)
        {
            this.creators = creators;
        }

        public string Create(string accessibility)
        {
            if (this.creators.TryGetValue(accessibility, out IAccessibilityCreator creator))
            {
                if (creator.IsApplicable(accessibility))
                {
                    return creator.Create(accessibility);
                }

                throw new ArgumentException($"{accessibility} is not a valid accessibility type for creator {creator.GetType().Name}");
            }

            throw new ArgumentException($"{accessibility} is not a registered accessibility type.");
        }
    }
}
