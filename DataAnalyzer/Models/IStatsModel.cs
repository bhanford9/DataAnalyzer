using DataAnalyzer.Common.DataParameters;
using DataAnalyzer.DataImport.DataObjects;
using DataScraper.DataSources;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataAnalyzer.Models
{
    internal interface IStatsModel : INotifyPropertyChanged
    {
        StatConfigurations.IStatsConfiguration ActiveConfiguration { get; set; }
        IHeirarchalStats HeirarchalStats { get; set; }
        ObservableCollection<string> StatNames { get; }
        ICollection<IStats> Stats { get; }
        IStatAccessorCollection DataAccessorCollection { get; set; }

        void ClearLoadedStats();
        void LoadStatsFromSource(IDataSource source);
        void StructureStats(ApplicationConfigurations.DataConfigurations.IDataConfiguration applicationConfiguration);
    }
}