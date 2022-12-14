using ExcelService.Styles.Borders;
using ExcelService.Utilities;

namespace ExcelService.DataActions.ActionParameters.RangeStyleParameters
{
    public class ColumnBorderStyleParameters : ActionParameters
    {
        private Border border = new Border();

        public override string Name => "Column Border";

        public Border Border
        {
            get => this.border;
            set
            {
                this.border = value;
                this.border.DoApply = true;
            }
        }

        public IColumnSpecification ColumnSpecification { get; set; } = new ColumnSpecification();

        public override ActionCategory Category => ActionCategory.ColumnBorderStyle;
    }
}
