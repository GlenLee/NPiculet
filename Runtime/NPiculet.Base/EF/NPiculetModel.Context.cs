﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NPiculetEntities : DbContext
    {
        public NPiculetEntities()
            : base("name=NPiculetEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<bas_attachment> bas_attachment { get; set; }
        public virtual DbSet<bas_dict_group> bas_dict_group { get; set; }
        public virtual DbSet<bas_dict_item> bas_dict_item { get; set; }
        public virtual DbSet<bas_notice_info> bas_notice_info { get; set; }
        public virtual DbSet<bas_notice_record> bas_notice_record { get; set; }
        public virtual DbSet<bas_region_info> bas_region_info { get; set; }
        public virtual DbSet<cms_adv_info> cms_adv_info { get; set; }
        public virtual DbSet<cms_content_group> cms_content_group { get; set; }
        public virtual DbSet<cms_content_page> cms_content_page { get; set; }
        public virtual DbSet<cms_friendlinks_info> cms_friendlinks_info { get; set; }
        public virtual DbSet<sys_action_detail> sys_action_detail { get; set; }
        public virtual DbSet<sys_action_log> sys_action_log { get; set; }
        public virtual DbSet<sys_admin_info> sys_admin_info { get; set; }
        public virtual DbSet<sys_app> sys_app { get; set; }
        public virtual DbSet<sys_authorization> sys_authorization { get; set; }
        public virtual DbSet<sys_config> sys_config { get; set; }
        public virtual DbSet<sys_link_user_org> sys_link_user_org { get; set; }
        public virtual DbSet<sys_link_user_role> sys_link_user_role { get; set; }
        public virtual DbSet<sys_member_corporation> sys_member_corporation { get; set; }
        public virtual DbSet<sys_member_data> sys_member_data { get; set; }
        public virtual DbSet<sys_member_info> sys_member_info { get; set; }
        public virtual DbSet<sys_menu> sys_menu { get; set; }
        public virtual DbSet<sys_org_group> sys_org_group { get; set; }
        public virtual DbSet<sys_org_info> sys_org_info { get; set; }
        public virtual DbSet<sys_role_info> sys_role_info { get; set; }
        public virtual DbSet<sys_user_data> sys_user_data { get; set; }
        public virtual DbSet<sys_user_info> sys_user_info { get; set; }
        public virtual DbSet<shop_address> shop_address { get; set; }
        public virtual DbSet<shop_brand> shop_brand { get; set; }
        public virtual DbSet<shop_cart> shop_cart { get; set; }
        public virtual DbSet<shop_category> shop_category { get; set; }
        public virtual DbSet<shop_comment> shop_comment { get; set; }
        public virtual DbSet<shop_commodity> shop_commodity { get; set; }
        public virtual DbSet<shop_commodity_detail> shop_commodity_detail { get; set; }
        public virtual DbSet<shop_commodity_price> shop_commodity_price { get; set; }
        public virtual DbSet<shop_consultation> shop_consultation { get; set; }
        public virtual DbSet<shop_favorite> shop_favorite { get; set; }
        public virtual DbSet<shop_logs> shop_logs { get; set; }
        public virtual DbSet<shop_order> shop_order { get; set; }
        public virtual DbSet<shop_order_flow> shop_order_flow { get; set; }
        public virtual DbSet<shop_order_item> shop_order_item { get; set; }
        public virtual DbSet<shop_packages> shop_packages { get; set; }
        public virtual DbSet<shop_pay_item> shop_pay_item { get; set; }
        public virtual DbSet<shop_pay_list> shop_pay_list { get; set; }
        public virtual DbSet<shop_sale> shop_sale { get; set; }
        public virtual DbSet<shop_service_order> shop_service_order { get; set; }
        public virtual DbSet<shop_supplier_info> shop_supplier_info { get; set; }
    }
}
