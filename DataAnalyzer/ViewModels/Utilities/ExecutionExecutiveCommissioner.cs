using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using System.Collections.Generic;
using System;
using DataAnalyzer.Services.ExecutiveUtilities;

namespace DataAnalyzer.ViewModels.Utilities
{
    internal class ExecutionExecutiveCommissioner : BasePropertyChanged
    {
        private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;
        private readonly MainModel mainModel = BaseSingleton<MainModel>.Instance;
        private readonly ExecutiveUtilitiesRepository executiveUtilities = ExecutiveUtilitiesRepository.Instance;

        private bool displayExcelCreation = false;
        private bool displayClassCreation = false;
        private bool displayNotSupported = true;
        private readonly IReadOnlyDictionary<string, Action> viewDisplayMap;

        public ExecutionExecutiveCommissioner()
        {
            this.viewDisplayMap = new Dictionary<string, Action>()
            {
                { nameof(DisplayExcelCreation), () => this.DisplayExcelCreation = true },
                { nameof(DisplayClassCreation), () => this.DisplayClassCreation = true },
                { nameof(DisplayNotSupported), () => this.DisplayNotSupported = true },
            };
        }

        public bool DisplayNotSupported
        {
            get => this.displayNotSupported;
            set => this.NotifyPropertyChanged(ref this.displayNotSupported, value);
        }

        public bool DisplayExcelCreation
        {
            get => this.displayExcelCreation;
            set => this.NotifyPropertyChanged(ref this.displayExcelCreation, value);
        }

        public bool DisplayClassCreation
        {
            get => this.displayClassCreation;
            set => this.NotifyPropertyChanged(ref this.displayClassCreation, value);
        }

        public void ClearDisplays()
        {
            this.DisplayExcelCreation = false;
            this.DisplayClassCreation = false;
        }

        public void SetDisplay()
        {
            this.ClearDisplays();
            IAggregateExecutives executive = this.executiveUtilities.GetExecutive(this.configurationModel.ImportExportKey);
            this.viewDisplayMap[executive.ExecutionDisplayKey]();
        }
    }
}
