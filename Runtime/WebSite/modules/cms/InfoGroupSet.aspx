<%@ Page Title="信息组设置" Language="C#" MasterPageFile="~/modules/ContentPage.master" AutoEventWireup="true" CodeFile="InfoGroupSet.aspx.cs" Inherits="modules_info_InfoGroupSet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
	<script type="text/javascript">
		$(document).ready(function () {
			var v = $('#<%= this.GroupType.ClientID %>').on('change', function (e) {
				if ($(e.target).val() === 'External') {
					$('#externalUrl').show();
				} else {
					$('#externalUrl').hide();
				}
			}).val();
			if (v === 'External')
				$('#externalUrl').show();
		});
	</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" Runat="Server">
	<div class="tools">
		<ul class="toolbar">
			<li><asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click">保存</asp:LinkButton></li>
			<li><asp:LinkButton ID="btnAdd" runat="server" OnClick="btnAdd_Click">新增同级</asp:LinkButton></li>
			<li><asp:LinkButton ID="btnChild" runat="server" OnClick="btnChild_Click">新增下级</asp:LinkButton></li>
			<li><asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" CausesValidation="False" OnClientClick="return confirm('删除栏目也会删除其下所有子数据，确定要继续吗？');">删除</asp:LinkButton></li>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="searchbar" Runat="Server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="content" Runat="Server">
	<table cellpadding="0" cellspacing="2" style="border:0;width:100%;">
		<tr style="vertical-align:top;">
			<td style="width:400px;padding:4px;">
				<div style="width:100%;height:100%;overflow:auto;"><asp:TreeView ID="tree" runat="server" onselectednodechanged="tree_SelectedNodeChanged"></asp:TreeView></div>
			</td>
			<td>
<asp:PlaceHolder ID="editor" runat="server">
				<table class="table table-primary">
					<tr>
						<td class="th">编码</td>
						<td class="td">
							<asp:TextBox ID="GroupCode" runat="server" CssClass="form-control" Width="200px" MaxLength="32"></asp:TextBox>
							<span class="caption">（若不指定，将随机生成一个）</span>
						</td>
					</tr>
					<tr>
						<td class="th">名称</td>
						<td class="td"><asp:TextBox ID="GroupName" runat="server" CssClass="form-control" Width="200px" MaxLength="64"></asp:TextBox>
							<asp:RequiredFieldValidator ID="r1" runat="server" ControlToValidate="GroupName" Display="Dynamic" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
						</td>
					</tr>
					<tr>
						<td class="th">类型</td>
						<td class="td"><asp:DropDownList ID="GroupType" runat="server" CssClass="form-control">
							<asp:ListItem Value="">无</asp:ListItem>
							<asp:ListItem Value="Content">单页</asp:ListItem>
							<asp:ListItem Value="List">列表</asp:ListItem>
							<asp:ListItem Value="Image">图片列表</asp:ListItem>
							<asp:ListItem Value="Picture">照片列表</asp:ListItem>
							<asp:ListItem Value="External">外部链接</asp:ListItem>
						</asp:DropDownList></td>
					</tr>
					<tr id="externalUrl" style="display:none;">
						<td class="th">链接</td>
						<td class="td"><asp:TextBox ID="Url" runat="server" CssClass="form-control" Width="98%" MaxLength="512"></asp:TextBox></td>
					</tr>
					<tr>
						<td class="th">开启</td>
						<td class="td"><asp:CheckBox ID="IsEnabled" runat="server" Text="是否开启" Checked="true" /></td>
					</tr>
					<tr>
						<td class="th">积分</td>
						<td class="td">
							<asp:TextBox ID="Point" runat="server" CssClass="form-control" Width="200px" MaxLength="8" Text="0"></asp:TextBox>
							<asp:RegularExpressionValidator ID="re3" runat="server" ControlToValidate="Point" Display="Dynamic" ErrorMessage="只能是数字" ForeColor="Red" ValidationExpression="\d+(\.\d+)?"></asp:RegularExpressionValidator>
						</td>
					</tr>
					<tr>
						<td class="th">排序</td>
						<td class="td">
							<asp:TextBox ID="Sort" runat="server" CssClass="form-control" Width="200px" MaxLength="8" Text="0"></asp:TextBox>
							<asp:RequiredFieldValidator ID="r2" runat="server" ControlToValidate="Sort" Display="Dynamic" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator ID="re2" runat="server" ControlToValidate="Sort" Display="Dynamic" ErrorMessage="只能是数字" ForeColor="Red" ValidationExpression="\d+"></asp:RegularExpressionValidator>
						</td>
					</tr>
					<tr>
						<td class="th">说明</td>
						<td class="td"><asp:TextBox ID="Comment" runat="server" CssClass="form-control" MaxLength="65535"></asp:TextBox></td>
					</tr>
				</table>
				<asp:HiddenField ID="Id" runat="server" />
				<asp:HiddenField ID="ParentId" runat="server" Value="0" />
				<asp:HiddenField ID="Layer" runat="server" Value="0" />
				<asp:HiddenField ID="Path" runat="server" />
</asp:PlaceHolder>
			</td>
		</tr>
	</table>
</asp:Content>

