<%@ Page Title="积分管理" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="PointSet.aspx.cs" Inherits="modules_system_PointSet" %>
<%@ Register TagPrefix="cc1" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="toolbar" Runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><asp:LinkButton runat="server" ID="btnSave" OnClick="btnSave_OnClick"><i class="sui-icon icon-tb-edit"></i>修改</asp:LinkButton></li>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="searchbar" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
	<asp:GridView ID="list" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="Id,OrgName,Point" CssClass="table table-primary">
		<PagerSettings Mode="NumericFirstLast" />
		<RowStyle HorizontalAlign="Center" />
		<Columns>
			<asp:BoundField DataField="OrgName" HeaderText="名称" />
			<asp:BoundField DataField="Alias" HeaderText="简称" />
			<asp:BoundField DataField="OrgCode" HeaderText="编码" />
			<asp:BoundField DataField="Point" HeaderText="当前积分">
				<HeaderStyle Width="200px" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="积分">
				<HeaderStyle Width="200px"></HeaderStyle>
				<ItemTemplate>
					<asp:TextBox runat="server" ID="point"></asp:TextBox>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
	
	<h4>积分操作日志</h4>
	<asp:GridView ID="pointLogs" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="table table-primary">
		<PagerSettings Mode="NumericFirstLast" />
		<RowStyle HorizontalAlign="Center" />
		<Columns>
			<asp:BoundField HeaderText="操作人" DataField="Creator">
				<HeaderStyle Width="80px"></HeaderStyle>
			</asp:BoundField>
			<asp:BoundField HeaderText="操作" DataField="Tag"/>
			<asp:BoundField HeaderText="积分" DataField="Point"/>
			<asp:BoundField HeaderText="说明" DataField="Comment"/>
			<asp:BoundField HeaderText="时间" DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd HH:mm}">
				<HeaderStyle Width="120px"></HeaderStyle>
			</asp:BoundField>
		</Columns>
	</asp:GridView>
	<cc1:NPager runat="server" ID="nPager" PageSize="10" />
</asp:Content>
