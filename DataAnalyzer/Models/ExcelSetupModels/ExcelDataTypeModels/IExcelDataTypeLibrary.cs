using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using System.Collections.Generic;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels
{
    internal interface IExcelDataTypeLibrary
    {
        IReadOnlyDictionary<string, ITypeParameter> NamedTypeParameters { get; }

        ITypeParameter GetInstanceByName(string name);
        ICollection<ITypeParameter> GetParameterTypes();
    }
}