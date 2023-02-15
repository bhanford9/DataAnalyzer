namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.AccessibilityCreators
{
    internal class ReadOnlyCreator : AccessibilityCreator
    {
        public override string Create(string accessibility) => "{ get; }"; 
        
        public override bool IsApplicable(string accessibility) => accessibility.Equals(ClassCreationConstants.READ_ONLY);
    }
}
