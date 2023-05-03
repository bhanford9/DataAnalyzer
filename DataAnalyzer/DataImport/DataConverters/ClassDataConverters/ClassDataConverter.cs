using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.DataImport.DataObjects.ClassStats;
using DataScraper.Data;
using DataScraper.Data.ClassData;
using System;
using System.Linq;
using Analyzer = DataAnalyzer.DataImport.DataObjects.ClassStats;
using Scraper = DataScraper.Data.ClassData;

namespace DataAnalyzer.DataImport.DataConverters.ClassDataConverters
{
    internal class ClassDataConverter : DataConverter<ClassStats, ClassData>, IClassDataConverter
    {
        public override bool IsValidData(IData data) => data is ClassData;

        public override IStats ToAnalyzerStats(IData data)
        {
            ClassData classData = data as ClassData;

            return new ClassStats()
            {
                Name = classData.Name,
                Properties = classData.Properties.Select(ToAnalyzerStats).ToComparableList(),
            };
        }

        private Analyzer.IProperty ToAnalyzerStats(Scraper.IProperty property) =>
            property switch
            {
                Scraper.ISimpleProperty simpleProp => ToAnalyzerStats(simpleProp),
                Scraper.IClassProperty classProp => ToAnalyzerStats(classProp),
                Scraper.ICollectionProperty collectionProp => ToAnalyzerStats(collectionProp),
                _ => throw new ArgumentException("Unexpected property argument"),
            };

        private Analyzer.IProperty ToAnalyzerStats(Scraper.ISimpleProperty property) =>
            new SimpleProperty() { Name = property.Name, };

        private Analyzer.IProperty ToAnalyzerStats(Scraper.IClassProperty property) =>
            new ClassProperty()
            { 
                Name = property.Name,
                Properties = property.Properties.Select(ToAnalyzerStats).ToList(),
            };

        private Analyzer.IProperty ToAnalyzerStats(Scraper.ICollectionProperty property) =>
            new CollectionProperty()
            {
                Name = property.Name,
                Properties = property.Properties.Select(ToAnalyzerStats).ToList(),
            };
    }
}
