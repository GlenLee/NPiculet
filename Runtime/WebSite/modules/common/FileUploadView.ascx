<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FileUploadView.ascx.cs" Inherits="modules_common_FileUploadView" %>
<asp:Repeater runat="server" ID="list" OnItemDataBound="list_OnItemDataBound">
	<ItemTemplate>
		<asp:LinkButton runat="server" ID="btnDelete" OnClick="btnDelete_OnClick" OnClientClick="return confirm('确定要删除此文件吗？');">[删除]</asp:LinkButton>
		<asp:LinkButton runat="server" ID="filelink" OnClick="filelink_OnClick"></asp:LinkButton><br/>
	</ItemTemplate>
</asp:Repeater>
<script type="text/javascript">
function uploadTmpl(attId) {
	layer.open({
		type: 2,
		title: '文件上传',
		shadeClose: true,
		shade: false,
		maxmin: true, //开启最大化最小化按钮
		area: ['420px', '300px'],
		content: '<%= ResolveClientUrl("~/modules/common/FileTmplUpload.aspx") %>?fid=' + attId
	});
}
</script>