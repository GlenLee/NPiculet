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
    
    public partial class shop_order_flow
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> SupplierId { get; set; }
        public string SourceOrderCode { get; set; }
        public string OrderType { get; set; }
        public string OrderCode { get; set; }
        public string PayCode { get; set; }
        public string PostCode { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> SuccessDate { get; set; }
        public Nullable<System.DateTime> PayDate { get; set; }
        public Nullable<System.DateTime> SendDate { get; set; }
        public string Address { get; set; }
        public Nullable<decimal> Longitude { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public string Post { get; set; }
        public string Region { get; set; }
        public string Receiver { get; set; }
        public string Tel { get; set; }
        public string Memo { get; set; }
        public string Status { get; set; }
    }
}
