<%@ Page Title="宣传管理" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="AdvList.aspx.cs" Inherits="modules.info.AdvList" %>
<%@ Register TagPrefix="asp" Namespace="NPiculet.WebControls" Assembly="NPiculet.WebControls" %>

<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="toolbar" runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><a href="AdvEdit.aspx"><i class="sui-icon icon-tb-add"></i>新增</a></li>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="searchbar" runat="Server">
	<ul class="searchbar-wrap">
		<li><asp:DropDownList runat="server" ID="ddlPosition"/></li>
		<%--<li>关键字：<asp:TextBox ID="txtKeywords" runat="server" placeholder="搜索名称或内容"></asp:TextBox></li>--%>
		<li><asp:Button ID="btnSearch" runat="server" Text="搜索" onclick="btnSearch_Click"/></li>
	</ul>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="Server">
	<asp:GridView ID="list" runat="server" AutoGenerateColumns="False" Width="100%"
		DataKeyNames="Id" OnRowDeleting="list_RowDeleting" CssClass="sui-table table-primary">
		<Columns>
			<asp:BoundField DataField="Position" HeaderText="广告位置">
				<HeaderStyle Width="80px" />
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="Title" HeaderText="名称" />
			<asp:BoundField DataField="Url" HeaderText="链接" />
			<asp:TemplateField HeaderText="宣传图" HeaderStyle-Width="80px">
				<ItemStyle HorizontalAlign="Center" />
				<ItemTemplate>
					<a class="thumb-link" href="#" onclick="showImage(this)">
						<img style="height:40px;width:70px;" alt="" src="<%# ResolveClientUrl(Convert.ToString(Eval("Image"))) %>"/>
					</a>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="编辑">
				<HeaderStyle Width="50px" />
				<ItemStyle HorizontalAlign="Center" />
				<ItemTemplate><a href="AdvEdit.aspx?key=<%# Eval("Id") %>">编辑</a></ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="删除">
				<HeaderStyle Width="50px"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center"></ItemStyle>
				<ItemTemplate>
					<asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('确定要删除吗？');">删除</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
	<asp:NPager runat="server" ID="nPager" PageSize="10" OnPageClick="nPager_OnPageClick" />

	<!-- Modal -->
	<div id="modal" tabindex="-1" role="dialog" data-hasfoot="false" class="sui-modal hide fade">
		<div class="modal-dialog">
			<div class="modal-content">
				<div class="modal-body"></div>
			</div>
		</div>
	</div>
	<script>
		function showImage(control) {
			var url = $(control).find('img').attr('src');
			$('.modal-body').html('<img src="' + url + '"/>');
			$('#modal').modal({ width: 800 });
		}
	</script>
</asp:Content>
