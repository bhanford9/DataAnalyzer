using DataAnalyzer.DataImport.DataObjects;
using DataScraper.DataSources;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataAnalyzer.Models
{
    internal interface IStatsModel : INotifyPropertyChanged
    {
        StatConfigurations.IDataConfiguration ActiveConfiguration { get; set; }
        HeirarchalStats HeirarchalStats { get; set; }
        ObservableCollection<string> StatNames { get; }
        ICollection<IStats> Stats { get; }

        void ClearLoadedStats();
        void LoadStatsFromSource(IDataSource source);
        void StructureStats(ApplicationConfigurations.DataConfigurations.IDataConfiguration applicationConfiguration);
    }
}