using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Services;
using System.Collections.Generic;
using System;
using DataAnalyzer.Services.Enums;

namespace DataAnalyzer.ViewModels.Utilities
{
    internal class ExecutionExecutiveCommissioner : BasePropertyChanged
    {
        private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;
        private readonly MainModel mainModel = BaseSingleton<MainModel>.Instance;
        private EnumUtilities EnumUtilities = new();

        private bool displayExcelCreation = false;
        private bool displayClassCreation = false;
        private bool displayNotSupported = true;
        private readonly IReadOnlyDictionary<ExecutiveType, Action> viewDisplayMap;
        //private readonly IDictionary<ExecutiveType, IDataStructureSetupViewModel> executiveViewModelMap;

        public ExecutionExecutiveCommissioner()
        {
            this.viewDisplayMap = new Dictionary<ExecutiveType, Action>()
            {
                {
                    ExecutiveType.CreateQueryableExcelReport,
                    () =>
                    {
                        this.DisplayExcelCreation = true;
                        //this.executiveViewModelMap[ExecutiveType.CreateQueryableExcelReport].StartListeners();
                    }
                },
                {
                    ExecutiveType.CsvToCSharpClass,
                    () =>
                    {
                        this.DisplayClassCreation = true;
                        //this.executiveViewModelMap[ExecutiveType.CsvToCSharpClass].StartListeners();
                    }
                },
                {
                    ExecutiveType.NotSupported,
                    () =>
                    {
                        this.DisplayNotSupported = true;
                        //this.executiveViewModelMap[ExecutiveType.NotSupported].StartListeners();
                    }
                },
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

        public void SetDisplay(ExecutiveType type)
        {
            this.ClearDisplays();
            this.viewDisplayMap[type]();
        }
    }
}
