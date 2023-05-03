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
            builder.RegisterInstance<IAccessibilityCreationExecutive, AccessibilityCreationExecutive>(_ =>
                new AccessibilityCreationExecutive(new Dictionary<string, IAccessibilityCreator>()
                {
                    { ClassCreationConstants.READ_ONLY, Resolver.Resolve<IReadOnlyCreator>() },
                    { ClassCreationConstants.READ_INIT, Resolver.Resolve<IReadInitCreator>() },
                    { ClassCreationConstants.READ_PRIVATE_WRITE, Resolver.Resolve<IReadPrivateWriteCreator>() },
                    { ClassCreationConstants.READ_PROTECTED_WRITE, Resolver.Resolve<IReadProtectedWriteCreator>() },
                    { ClassCreationConstants.READ_WRITE, Resolver.Resolve<IReadWriteCreator>() },
                }));
            builder.RegisterTypeAncestors<IAccessibilityCreator, IReadInitCreator, ReadInitCreator>();
            builder.RegisterTypeAncestors<IAccessibilityCreator, IReadOnlyCreator, ReadOnlyCreator>();
            builder.RegisterTypeAncestors<IAccessibilityCreator, IReadPrivateWriteCreator, ReadPrivateWriteCreator>();
            builder.RegisterTypeAncestors<IAccessibilityCreator, IReadProtectedWriteCreator, ReadProtectedWriteCreator>();
            builder.RegisterTypeAncestors<IAccessibilityCreator, IReadWriteCreator, ReadWriteCreator>();

            // Services.ClassGenerationServices.PropertyCreators.TypeCreators
            builder.RegisterInstance<ITypeCreationExecutive, TypeCreationExecutive>(_ =>
                new TypeCreationExecutive(new Dictionary<string, ITypeCreator>()
                {
                    { ClassCreationConstants.BOOL_TYPE_DISPLAY, Resolver.Resolve<IBoolCreator>() },
                    { ClassCreationConstants.INT_TYPE_DISPLAY, Resolver.Resolve<IIntCreator>() },
                    { ClassCreationConstants.DOUBLE_TYPE_DISPLAY, Resolver.Resolve<IDoubleCreator>() },
                    { ClassCreationConstants.STRING_TYPE_DISPLAY, Resolver.Resolve<IStringCreator>() },
                    { ClassCreationConstants.DATE_TIME_TYPE_DISPLAY, Resolver.Resolve<IDateTimeCreator>() },
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
            builder.RegisterTypeInstance<IScraperService, ScraperService>();
            builder.RegisterTypeInstance<ISerializationService, SerializationService>();
        }
    }
}
