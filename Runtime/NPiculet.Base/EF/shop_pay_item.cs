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
    
    public partial class shop_pay_item
    {
        public int Id { get; set; }
        public string BranchCode { get; set; }
        public string PayCode { get; set; }
        public Nullable<int> CommodityId { get; set; }
        public Nullable<double> OriginalPrice { get; set; }
        public Nullable<double> CurrentPrice { get; set; }
        public Nullable<double> Amount { get; set; }
        public Nullable<double> Money { get; set; }
    }
}