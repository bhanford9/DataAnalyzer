namespace DataAnalyzer.DataImport.DataObjects.ClassStats;

internal class SimpleProperty : Property, ISimpleProperty
{
    public override int CompareTo(object obj)
    {
        if (obj is  SimpleProperty simpleProperty)
        {
            return this.Name.CompareTo(simpleProperty.Name);
        }

        return -1;
    }
}
