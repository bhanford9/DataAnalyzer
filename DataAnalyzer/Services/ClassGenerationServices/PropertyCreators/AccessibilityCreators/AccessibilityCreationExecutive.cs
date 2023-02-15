using System;
using System.Collections.Generic;

namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.AccessibilityCreators
{
    internal class AccessibilityCreationExecutive
    {
        private readonly IReadOnlyDictionary<string, IAccessibilityCreator> creators = new Dictionary<string, IAccessibilityCreator>()
        {
            { ClassCreationConstants.READ_ONLY, new ReadOnlyCreator() },
            { ClassCreationConstants.READ_INIT, new ReadInitCreator() },
            { ClassCreationConstants.READ_PRIVATE_WRITE, new ReadPrivateWriteCreator() },
            { ClassCreationConstants.READ_PROTECTED_WRITE, new ReadProtectedWriteCreator() },
            { ClassCreationConstants.READ_WRITE, new ReadWriteCreator() },
        };

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
