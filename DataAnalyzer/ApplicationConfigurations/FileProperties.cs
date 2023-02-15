namespace DataAnalyzer.ApplicationConfigurations
{
    internal class FileProperties
    {
        // I originally started creating unique file extensions to be able to recursively search for
        // configurations at runtime and know whether the conifguration applied to the specific instance
        // in code.
        //
        // I think this may be unnecessary because of the way I am defining file paths.

        public const string JSON_FILE_EXTENSION = ".json";
        public const string CONFIGN_FILE_EXTENSION = ".ddpcfg" + JSON_FILE_EXTENSION;

        public const string EXCEL_CONFIG_FILE_EXTENSION = ".ddpecfg" + JSON_FILE_EXTENSION;
        public const string EXCEL_DATA_TYPE_CONFIG_FILE_EXTENSION = ".edtcfg" + JSON_FILE_EXTENSION;

        public const string EXCEL_WORKBOOK_FILE_EXTENSION = ".xlsx";
    }
}
