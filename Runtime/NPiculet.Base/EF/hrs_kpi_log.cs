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
    
    public partial class hrs_kpi_log
    {
        public int Id { get; set; }
        public Nullable<int> KpiId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<decimal> Score { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> ScoreDate { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string Creator { get; set; }
    }
}
