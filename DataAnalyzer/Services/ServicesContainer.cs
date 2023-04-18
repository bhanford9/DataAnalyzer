using Autofac;
using DataAnalyzer.Services.ClassGenerationServices;
using DataAnalyzer.Services.ClassGenerationServices.PropertyCreators;
using DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.AccessibilityCreators;
using DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.TypeCreators;
using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.Services.ExecutiveUtilities;
using DataAnalyzer.Services.ExecutiveUtilities.Executives;
using DependencyInjectionUtilities;
using System.Collections.Generic;

namespace DataAnalyzer.Services
{
    internal class ServicesContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            // Services.ClassGenerationServices.PropertyCreators.AccessibilityCreators
            builder.Register<IAccessibilityCreationExecutive, AccessibilityCreationExecutive>(_ =>
                new AccessibilityCreationExecutive(new Dictionary<string, IAccessibilityCreator>()
                {
                    { ClassCreationConstants.READ_ONLY, new ReadOnlyCreator() },
                    { ClassCreationConstants.READ_INIT, new ReadInitCreator() },
                    { ClassCreationConstants.READ_PRIVATE_WRITE, new ReadPrivateWriteCreator() },
                    { ClassCreationConstants.READ_PROTECTED_WRITE, new ReadProtectedWriteCreator() },
                }));
            builder.RegisterTypeAncestors<IAccessibilityCreator, IReadInitCreator, ReadInitCreator>();
            builder.RegisterTypeAncestors<IAccessibilityCreator, IReadOnlyCreator, ReadOnlyCreator>();
            builder.RegisterTypeAncestors<IAccessibilityCreator, IReadPrivateWriteCreator, ReadPrivateWriteCreator>();
            builder.RegisterTypeAncestors<IAccessibilityCreator, IReadProtectedWriteCreator, ReadProtectedWriteCreator>();

            // Services.ClassGenerationServices.PropertyCreators.TypeCreators
            builder.Register<ITypeCreationExecutive, TypeCreationExecutive>(_ =>
                new TypeCreationExecutive(new Dictionary<string, ITypeCreator>()
                {
                    { ClassCreationConstants.BOOL_TYPE, new BoolCreator() },
                    { ClassCreationConstants.INT_TYPE, new IntCreator() },
                    { ClassCreationConstants.DOUBLE_TYPE, new DoubleCreator() },
                    { ClassCreationConstants.STRING_TYPE, new StringCreator() },
                    { ClassCreationConstants.DATE_TIME_TYPE, new DateTimeCreator() },
                }));
            builder.RegisterTypeAncestors<ITypeCreator, IBoolCreator, BoolCreator>();
            builder.RegisterTypeAncestors<ITypeCreator, IDateTimeCreator, DateTimeCreator>();
            builder.RegisterTypeAncestors<ITypeCreator, IDoubleCreator, DoubleCreator>();
            builder.RegisterTypeAncestors<ITypeCreator, IIntCreator, IntCreator>();
            builder.RegisterTypeAncestors<ITypeCreator, IStringCreator, StringCreator>();

            // Services.ClassGenerationServices.PropertyCreators
            builder.RegisterType<IPropertyCreator, PropertyCreator>();

            // Services.ClassGenerationServices
            builder.RegisterType<IClassCreator, ClassCreator>();

            // Services.ExcelUtilities
            builder.RegisterTypeAncestors<IExcelEntitySpecification, IExcelWorkbookSpecification, ExcelWorkbookSpecification>();
            builder.RegisterTypeAncestors<IExcelEntitySpecification, IExcelWorksheetSpecification, ExcelWorksheetSpecification>();
            builder.RegisterTypeAncestors<IExcelEntitySpecification, IExcelDataClusterSpecification, ExcelDataClusterSpecification>();
            builder.RegisterTypeAncestors<IExcelEntitySpecification, IExcelRowSpecification, ExcelRowSpecification>();
            builder.RegisterTypeAncestors<IExcelEntitySpecification, IExcelCellSpecification, ExcelCellSpecification>();

            // Services.ExecutiveUtilities.Executives
            builder.RegisterTypeAncestors<IAggregateExecutives, ICsvCSharpClassCreation, CsvCSharpClassCreation>();
            builder.RegisterTypeAncestors<IAggregateExecutives, ICsvTest, CsvTest>();
            builder.RegisterTypeAncestors<IAggregateExecutives, INotSupportedExecutive, NotSupportedExecutive>();
            builder.RegisterTypeAncestors<IAggregateExecutives, IQueryableExcelCreation, QueryableExcelCreation>();

            // Services.ExecutiveUtilities
            builder.RegisterInstance<IExecutiveUtilitiesRepository, ExecutiveUtilitiesRepository>(x =>
            {
                ExecutiveUtilitiesRepository repo = new();
                repo.Initialize();
                return repo;
            });

            // Services
            builder.RegisterType<IImportExportKey, ImportExportKey>();
            builder.RegisterType<IImportKey, ImportKey>();
            builder.RegisterType<ISerializationService, SerializationService>();
        }
    }
}
