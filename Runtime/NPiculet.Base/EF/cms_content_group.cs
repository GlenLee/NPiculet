//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace NPiculet.Base.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class cms_content_group
    {
        public int Id { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public string GroupType { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<int> Layer { get; set; }
        public string Path { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public Nullable<int> OrgId { get; set; }
        public int IsEnabled { get; set; }
        public Nullable<decimal> Point { get; set; }
        public string Comment { get; set; }
        public Nullable<int> Sort { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}
