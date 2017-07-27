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
    
    public partial class shop_commodity
    {
        public int Id { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string CategoryType { get; set; }
        public Nullable<int> SupplierId { get; set; }
        public Nullable<int> RootCategoryId { get; set; }
        public Nullable<int> BrandId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Pinyin { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string Thumb { get; set; }
        public string PlaceStartCode { get; set; }
        public string PlaceStartName { get; set; }
        public string PlaceEndCode { get; set; }
        public string PlaceEndName { get; set; }
        public string Image { get; set; }
        public Nullable<int> Stock { get; set; }
        public string Model { get; set; }
        public string Unit { get; set; }
        public string Address { get; set; }
        public string Characteristic { get; set; }
        public string Size { get; set; }
        public Nullable<double> OriginalPrice { get; set; }
        public Nullable<double> CurrentPrice { get; set; }
        public Nullable<int> IsBundling { get; set; }
        public Nullable<double> BundlingPrice { get; set; }
        public Nullable<double> Point { get; set; }
        public Nullable<double> SalePoint { get; set; }
        public Nullable<int> SalesVolume { get; set; }
        public Nullable<int> TotalFavorite { get; set; }
        public Nullable<int> TotalComment { get; set; }
        public Nullable<int> TotalClick { get; set; }
        public Nullable<int> IsPackages { get; set; }
        public Nullable<int> IsLimitTime { get; set; }
        public Nullable<int> IsPriceOff { get; set; }
        public Nullable<int> IsPoint { get; set; }
        public Nullable<int> IsRefund { get; set; }
        public string RefundMemo { get; set; }
        public Nullable<int> IsEnabled { get; set; }
        public Nullable<int> IsDel { get; set; }
        public string Creator { get; set; }
        public Nullable<System.DateTime> LeaveDate { get; set; }
        public Nullable<System.DateTime> ArrivalDate { get; set; }
        public string Reserve { get; set; }
        public string Way { get; set; }
        public string Scenery { get; set; }
        public string Hint { get; set; }
        public string RefundRule { get; set; }
        public string RefundFormula { get; set; }
        public Nullable<double> FuelPrice { get; set; }
        public Nullable<double> AirportPrice { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> OrderBy { get; set; }
    }
}
