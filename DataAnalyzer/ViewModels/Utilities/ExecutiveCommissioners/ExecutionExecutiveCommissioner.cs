using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using System.Collections.Generic;
using System;
using DataAnalyzer.Services.ExecutiveUtilities;
using DataAnalyzer.Services;

namespace DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners
{
    internal class ExecutionExecutiveCommissioner : BasePropertyChanged, IExecutionExecutiveCommissioner
    {
        private readonly IConfigurationModel configurationModel;
        private readonly IExecutiveUtilitiesRepository executiveUtilities;

        private bool displayExcelCreation = false;
        private bool displayClassCreation = false;
        private bool displayNotSupported = true;
        private readonly IReadOnlyDictionary<string, Action> viewDisplayMap;

        public ExecutionExecutiveCommissioner(
            IConfigurationModel configModel,
            IExecutiveUtilitiesRepository executiveUtilities)
        {
            this.configurationModel = configModel;
            this.executiveUtilities = executiveUtilities;

            // TODO --> might be able to inject
            viewDisplayMap = new Dictionary<string, Action>()
            {
                { nameof(DisplayExcelCreation), () => DisplayExcelCreation = true },
                { nameof(DisplayClassCreation), () => DisplayClassCreation = true },
                { nameof(DisplayNotSupported), () => DisplayNotSupported = true },
            };
        }

        public bool DisplayNotSupported
        {
            get => displayNotSupported;
            set => NotifyPropertyChanged(ref displayNotSupported, value);
        }

        public bool DisplayExcelCreation
        {
            get => displayExcelCreation;
            set => NotifyPropertyChanged(ref displayExcelCreation, value);
        }

        public bool DisplayClassCreation
        {
            get => displayClassCreation;
            set => NotifyPropertyChanged(ref displayClassCreation, value);
        }

        public void ClearDisplays()
        {
            DisplayExcelCreation = false;
            DisplayClassCreation = false;
        }

        public void SetDisplay()
        {
            ClearDisplays();
            IAggregateExecutives executive = executiveUtilities.GetDataOrDefault(configurationModel.ImportExportKey);
            viewDisplayMap[executive.ExecutionDisplayKey]();
        }
    }
}
