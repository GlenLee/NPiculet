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
    
    public partial class cms_adv_info
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Cover { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Css { get; set; }
        public string Script { get; set; }
        public int Click { get; set; }
        public int IsEnabled { get; set; }
        public Nullable<int> OrderBy { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> Delay { get; set; }
        public string Creator { get; set; }
        public System.DateTime CreateDate { get; set; }
    }
}
