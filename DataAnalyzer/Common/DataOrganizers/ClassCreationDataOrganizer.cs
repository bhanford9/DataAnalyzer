using DataAnalyzer.ApplicationConfigurations.DataConfigurations.ClassSetupConfigurations;
using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.DataImport.DataObjects.ClassStats;
using DataAnalyzer.StatConfigurations.ClassCreationConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataOrganizers
{
    internal class ClassCreationDataOrganizer : DataOrganizer<ClassCreationConfiguration>, IClassCreationDataOrganizer
    {
        protected override IHeirarchalStats InternalOrganize(ClassCreationConfiguration configuration, ICollection<IStats> data)
        {
            return new HeirarchalStats()
            {
                Values = new List<IStats>()
                {
                    new ClassStats()
                    {
                        Name = configuration.ClassSetupConfiguration.ClassName,
                        Properties = configuration.ClassSetupConfiguration.Properties
                            .Select(AppPropertyToStatProperty)
                            .ToComparableList(), 
                    },
                },
            };
        }

        private IProperty AppPropertyToStatProperty(IPropertySetupConfiguration property) =>
            property switch
            {
                ISimplePropertySetupConfiguration simple => new SimpleProperty()
                {
                    Name = simple.Name
                },
                IClassPropertySetupConfiguration obj => new ClassProperty()
                {
                    Name = obj.Name,
                    Properties = obj.Properties.Select(p => this.AppPropertyToStatProperty(p)).ToList(),
                },
                ICollectionPropertySetupConfiguration list => new CollectionProperty()
                {
                    Name = list.Name,
                    Properties = list.Properties.Select(p => this.AppPropertyToStatProperty(p)).ToList(),
                },
                _ => throw new NotImplementedException(),
            };
}
}
