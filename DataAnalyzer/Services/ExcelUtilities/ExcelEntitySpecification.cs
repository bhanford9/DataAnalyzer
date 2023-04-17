using System;

namespace DataAnalyzer.Services.ExcelUtilities
{
    internal abstract class ExcelEntitySpecification : IExcelEntitySpecification
    {
        public abstract string Name { get; }

        public override bool Equals(object obj) 
            => obj is ExcelEntitySpecification specification && this.Name == specification.Name;
        public override int GetHashCode() => HashCode.Combine(this.Name);
    }
}
