﻿namespace Catalog.API
{
    public class DatabaseSettingOption
    {
        public const string ConfigureName = "DatabaseSetting";
        public string DatabaseName { get; set; } = string.Empty;
        public string CollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
    }
}
