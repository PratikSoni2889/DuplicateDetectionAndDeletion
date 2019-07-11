using System.Collections.Generic;

namespace DuplicateDetectionAndDeletion.ClassLibrary.Models
{
    public class DuplicateSearch
    {
        public string EntityLogicalName { get; set; }
        public string DuplicatedColumnName { get; set; }
        public List<string> ColumnList { get; set; }
    }
}