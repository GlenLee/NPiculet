<%@ Page Title="" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="AdvList.aspx.cs" Inherits="modules.info.AdvList" %>

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
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="Server">
	<asp:GridView ID="list" runat="server" AutoGenerateColumns="False" Width="100%"
		DataKeyNames="Id" OnRowDeleting="list_RowDeleting" AllowPaging="True" CssClass="sui-table table-primary" PageSize="15"
		OnRowCommand="list_RowCommand" OnPageIndexChanging="list_PageIndexChanging">
		<Columns>
			<asp:BoundField DataField="Type" HeaderText="广告位置">
				<HeaderStyle Width="80px" />
				<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="Description" HeaderText="描述" />
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
			<asp:CommandField ShowDeleteButton="True" HeaderText="删除">
				<HeaderStyle Width="50px" />
				<ItemStyle HorizontalAlign="Center" />
			</asp:CommandField>
		</Columns>
		<PagerSettings FirstPageText="第一页" LastPageText="最后页" Mode="NumericFirstLast" NextPageText="上一页" PreviousPageText="下一页" />
	</asp:GridView>

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
