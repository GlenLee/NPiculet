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
    
    public partial class shop_category
    {
        public int Id { get; set; }
        public string AppCode { get; set; }
        public string Type { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<int> RootId { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Icon { get; set; }
        public Nullable<int> Depth { get; set; }
        public string Comment { get; set; }
        public Nullable<int> OrderBy { get; set; }
        public Nullable<int> IsEnabled { get; set; }
        public Nullable<int> IsDel { get; set; }
        public string Creator { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}
