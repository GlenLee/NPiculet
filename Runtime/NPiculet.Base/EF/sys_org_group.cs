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
    
    public partial class sys_org_group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string GroupCode { get; set; }
        public string Memo { get; set; }
        public int IsVirtual { get; set; }
        public int IsDel { get; set; }
        public string Creator { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}
