﻿using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.ViewModels.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.SubModelConversions;
using DataAnalyzer.Services.Enums;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
{
    internal class BorderEditViewModel : EditActionViewModel
    {
        private RowSpecificationViewModel rowSpecification = new();
        private ColumnSpecificationViewModel columnSpecification = new();

        public BorderEditViewModel(ExcelEntityType excelEntityType) : base(excelEntityType)
        {
        }

        public BorderEditViewModel(
            IActionCreationModel actionCreationModel,
            IEditActionViewModel toCopy,
            ExcelEntityType excelEntityType)
          : base(actionCreationModel, toCopy, excelEntityType)
        {
        }

        public ObservableCollection<BorderSettingsViewModel> BorderSettings { get; } = new();

        public BorderSettingsViewModel LeftBorderSettings { get; } = new();
        public BorderSettingsViewModel TopBorderSettings { get; } = new();
        public BorderSettingsViewModel RightBorderSettings { get; } = new();
        public BorderSettingsViewModel BottomBorderSettings { get; } = new();
        public BorderSettingsViewModel AllBorderSettings { get; } = new();
        public BorderSettingsViewModel DiagonalUpBorderSettings { get; } = new();
        public BorderSettingsViewModel DiagonalDownBorderSettings { get; } = new();

        public RowSpecificationViewModel RowSpecification
        {
            get => this.rowSpecification;
            set => this.NotifyPropertyChanged(ref this.rowSpecification, value);
        }

        public ColumnSpecificationViewModel ColumnSpecification
        {
            get => this.columnSpecification;
            set => this.NotifyPropertyChanged(ref this.columnSpecification, value);
        }

        public override void ApplyParameterSettings()
        {
            BorderParameters borderParameters = this.ActionParameters as BorderParameters;

            borderParameters.LeftColor = Color.FromName(this.LeftBorderSettings.ComboBoxColors.SelectedColor);
            borderParameters.TopColor = Color.FromName(this.TopBorderSettings.ComboBoxColors.SelectedColor);
            borderParameters.RightColor = Color.FromName(this.RightBorderSettings.ComboBoxColors.SelectedColor);
            borderParameters.BottomColor = Color.FromName(this.BottomBorderSettings.ComboBoxColors.SelectedColor);
            borderParameters.AllColor = Color.FromName(this.AllBorderSettings.ComboBoxColors.SelectedColor);
            borderParameters.DiagonalUpColor = Color.FromName(this.DiagonalUpBorderSettings.ComboBoxColors.SelectedColor);
            borderParameters.DiagonalDownColor = Color.FromName(this.DiagonalDownBorderSettings.ComboBoxColors.SelectedColor);

            borderParameters.LeftStyle = Enum.Parse<BorderStyle>(this.LeftBorderSettings.SelectedStyle);
            borderParameters.TopStyle = Enum.Parse<BorderStyle>(this.TopBorderSettings.SelectedStyle);
            borderParameters.RightStyle = Enum.Parse<BorderStyle>(this.RightBorderSettings.SelectedStyle);
            borderParameters.BottomStyle = Enum.Parse<BorderStyle>(this.BottomBorderSettings.SelectedStyle);
            borderParameters.AllStyle = Enum.Parse<BorderStyle>(this.AllBorderSettings.SelectedStyle);
            borderParameters.DiagonalUpStyle = Enum.Parse<BorderStyle>(this.DiagonalUpBorderSettings.SelectedStyle);
            borderParameters.DiagonalDownStyle = Enum.Parse<BorderStyle>(this.DiagonalDownBorderSettings.SelectedStyle);

            borderParameters.ColumnSpecification = ColumnSpecificationConversion.ToModel(this.ColumnSpecification);
            borderParameters.RowSpecification = RowSpecificationConversion.ToModel(this.RowSpecification);
        }

        public override IEditActionViewModel GetNewInstance(IActionParameters parameters)
        {
            BorderEditViewModel viewModel = new(this.actionCreationModel, this, this.ExcelEntityType);
            BorderParameters borderParameters = parameters as BorderParameters;
            viewModel.LeftBorderSettings.ComboBoxColors.SelectedColor = borderParameters.LeftColor.Name;
            viewModel.TopBorderSettings.ComboBoxColors.SelectedColor = borderParameters.TopColor.Name;
            viewModel.RightBorderSettings.ComboBoxColors.SelectedColor = borderParameters.RightColor.Name;
            viewModel.BottomBorderSettings.ComboBoxColors.SelectedColor = borderParameters.BottomColor.Name;
            viewModel.AllBorderSettings.ComboBoxColors.SelectedColor = borderParameters.AllColor.Name;
            viewModel.DiagonalUpBorderSettings.ComboBoxColors.SelectedColor = borderParameters.DiagonalUpColor.Name;
            viewModel.DiagonalDownBorderSettings.ComboBoxColors.SelectedColor = borderParameters.DiagonalDownColor.Name;

            viewModel.LeftBorderSettings.SelectedStyle = borderParameters.LeftStyle.ToString();
            viewModel.TopBorderSettings.SelectedStyle = borderParameters.TopStyle.ToString();
            viewModel.RightBorderSettings.SelectedStyle = borderParameters.RightStyle.ToString();
            viewModel.BottomBorderSettings.SelectedStyle = borderParameters.BottomStyle.ToString();
            viewModel.AllBorderSettings.SelectedStyle = borderParameters.AllStyle.ToString();
            viewModel.DiagonalUpBorderSettings.SelectedStyle = borderParameters.DiagonalUpStyle.ToString();
            viewModel.DiagonalDownBorderSettings.SelectedStyle = borderParameters.DiagonalDownStyle.ToString();

            viewModel.LeftBorderSettings.BorderName = "Left Border";
            viewModel.TopBorderSettings.BorderName = "Top Border";
            viewModel.RightBorderSettings.BorderName = "Right Border";
            viewModel.BottomBorderSettings.BorderName = "Bottom Border";
            viewModel.AllBorderSettings.BorderName = "Perimeter Border";
            viewModel.DiagonalUpBorderSettings.BorderName = "Diagonal Up Border";
            viewModel.DiagonalDownBorderSettings.BorderName = "Diagonal Down Border";

            viewModel.BorderSettings.Add(viewModel.LeftBorderSettings);
            viewModel.BorderSettings.Add(viewModel.TopBorderSettings);
            viewModel.BorderSettings.Add(viewModel.RightBorderSettings);
            viewModel.BorderSettings.Add(viewModel.BottomBorderSettings);
            viewModel.BorderSettings.Add(viewModel.AllBorderSettings);
            viewModel.BorderSettings.Add(viewModel.DiagonalUpBorderSettings);
            viewModel.BorderSettings.Add(viewModel.DiagonalDownBorderSettings);

            viewModel.ColumnSpecification = ColumnSpecificationConversion.ToViewModel(borderParameters.ColumnSpecification);
            viewModel.RowSpecification = RowSpecificationConversion.ToViewModel(borderParameters.RowSpecification);

            return viewModel;
        }

        protected override bool InternalIsApplicable(IActionParameters parameters) => parameters is BorderParameters;

        protected override void DoAct() => throw new NotImplementedException();

        protected override void InternalInit(IEditActionViewModel toCopy)
        {
        }
    }
}
