using DataAnalyzer.Services.Enums;
using DataAnalyzer.Services.ExecutiveUtilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzerTest.DataProviders
{
    internal class ImportExportKeyProvider : DataProvider
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            ExecutiveUtilitiesRepository repository = ExecutiveUtilitiesRepository.Instance;

            var importTypes = repository.GetImportTypes();
            var importCategoryCombos = importTypes.SelectMany(
                x => repository.GetCategories(x, true).Select(y => (x, y)));
            var importCategoryFlavorCombos = importCategoryCombos.SelectMany(
                x => repository.GetFlavors(x.Item1, x.Item2, true).Select(y => (x.Item1, x.Item2, y)));
            var importCategoryFlaovrExportCombos = Enum.GetValues<ExportType>().SelectMany(
                x => importCategoryFlavorCombos.Select(y => (y.Item1, y.Item2, y.Item3, x)));

            return importCategoryFlaovrExportCombos
                .Select(x => new object[] { x.Item1, x.Item2, x.Item3, x.Item4 })
                .GetEnumerator();
        }
    }
}
