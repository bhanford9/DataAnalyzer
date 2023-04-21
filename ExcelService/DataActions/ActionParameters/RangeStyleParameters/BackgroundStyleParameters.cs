using ExcelService.Styles.Colors;
using ExcelService.Styles.Patterns;
using ExcelService.Utilities;

namespace ExcelService.DataActions.ActionParameters.RangeStyleParameters
{
    public class BackgroundStyleParameters : ActionParameters, IBackgroundStyleParameters
    {
        private ColorValue color = new ColorValue(Styles.Colors.Color.Transparent);
        private FillPatternValue pattern = new FillPatternValue();

        public override string Name => "Background Color";

        public bool DoApplyColor { get; set; } = false;

        public override ActionCategory Category => ActionCategory.BackgroundStyle;

        public ColorValue Color
        {
            get => this.color;
            set
            {
                this.color = value;
                this.DoApplyColor = true;
            }
        }

        public FillPatternValue Pattern
        {
            get => this.pattern;
            set
            {
                this.pattern = value;
                this.pattern.DoApply = true;
            }
        }

        public IColumnSpecification ColumnSpecification { get; set; } = new ColumnSpecification();

        public IRowSpecification RowSpecification { get; set; } = new RowSpecification();
    }
}
