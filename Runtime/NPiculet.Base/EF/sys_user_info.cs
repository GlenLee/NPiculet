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
    
    public partial class sys_user_info
    {
        public int Id { get; set; }
        public string UserSn { get; set; }
        public string Type { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Nullable<int> OrgId { get; set; }
        public Nullable<int> LoginTimes { get; set; }
        public Nullable<System.DateTime> LastLoginDate { get; set; }
        public Nullable<System.DateTime> LastLogoutDate { get; set; }
        public Nullable<int> FailedCount { get; set; }
        public Nullable<System.DateTime> FailedDate { get; set; }
        public Nullable<int> Sort { get; set; }
        public int IsEnabled { get; set; }
        public int IsDel { get; set; }
        public string Updater { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string Creator { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}
