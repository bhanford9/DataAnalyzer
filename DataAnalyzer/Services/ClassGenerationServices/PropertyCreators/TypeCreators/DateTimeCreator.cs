using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.TypeCreators
{
    internal class DateTimeCreator : TypeCreator
    {
        // TODO --> may need a way to handle importing a using statement

        public override string Create(string dataType)
        {
            return "DateTime";
        }

        public override bool IsApplicable(string dataType)
        {
            return dataType.Equals(ClassCreationConstants.DATE_TIME_TYPE);
        }
    }
}
