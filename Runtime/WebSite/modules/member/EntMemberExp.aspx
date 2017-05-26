<%@ Page Title="" Language="C#" MasterPageFile="~/modules/common/Dialog.master" AutoEventWireup="true" CodeFile="EntMemberExp.aspx.cs" Inherits="modules_member_EntMemberExp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
	<style type="text/css">
		.exp, .exp li { list-style-type:none;margin:0;padding:0; }
		.exp { padding:10px; }
		.sel input { margin:5px 10px; }
	</style>
	<script type="text/javascript">
		function cancel() {
			var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
			parent.layer.close(index);
		}
	</script>
	<base target="_self"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="toolbar" Runat="Server">
	<asp:LinkButton runat="server" ID="btnSave" Text="保存" OnClick="btnSave_OnClick"></asp:LinkButton>
	<a href="#" onclick="cancel();">关闭</a>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="content" runat="Server">
	<ul class="exp">
		<li class="sel">
			<asp:RadioButtonList runat="server" ID="symbol" RepeatDirection="Horizontal" RepeatLayout="Flow">
				<asp:ListItem Value="+" Selected="True">加分</asp:ListItem>
				<asp:ListItem Value="-">减分</asp:ListItem>
			</asp:RadioButtonList>
		</li>
		<li>
			本次打分：<asp:TextBox runat="server" ID="number" Width="60px"></asp:TextBox>（在总分基础上增加或减少）
		</li>
		<li>
			证明照片：<asp:FileUpload runat="server" ID="photo" Width="300px"></asp:FileUpload>
		</li>
		<li>
			打分理由：<asp:TextBox runat="server" ID="reson" Width="300px" TextMode="MultiLine" Rows="3"></asp:TextBox>
		</li>
	</ul>
	<asp:GridView runat="server" ID="list" Width="100%" CssClass="sui-table table-primary" AutoGenerateColumns="False"
		DataKeyNames="Image" OnRowDataBound="list_OnRowDataBound">
		<Columns>
			<asp:BoundField HeaderText="时间" DataField="Date" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"/>
			<asp:BoundField HeaderText="操作" DataField="Tag"/>
			<asp:BoundField HeaderText="理由" DataField="Comment"/>
			<asp:HyperLinkField HeaderText="图片" Text="查看" DataNavigateUrlFields="Image" Target="_blank"/>
		</Columns>
		<EmptyDataTemplate>
			<div style="border:1px solid #fff;">
				没有打分日志
			</div>
		</EmptyDataTemplate>
	</asp:GridView>
</asp:Content>
