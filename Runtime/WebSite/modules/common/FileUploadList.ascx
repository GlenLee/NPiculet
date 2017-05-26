<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FileUploadList.ascx.cs" Inherits="modules_common_FileUploadList" %>
<asp:PlaceHolder runat="server" ID="phToolbar" Visible="False">
    <script type="text/javascript" src="<%= ResolveClientUrl("~/modules/js/lib/layer/layer.js")%>"></script>
    <div class="tools">
        <ul class="toolbar">
            <li><a href="#" onclick="return createDir();">
	            <span><img src="<%= ResolveClientUrl("~/modules/images/t01.png") %>"></span>新建目录
            </a></li>
            <li><a id="uploadArrFile">
	            <span><%--onclick="$('#<%= this.fileUpload.ClientID %>').click();return false;" --%>
                <img src="<%= ResolveClientUrl("~/modules/images/t01.png") %>"></span>上传文件
            </a></li>
            <li><asp:LinkButton runat="server" ID="btnDelete" OnClick="btnDel_OnClick" OnClientClick="return confirm('您确定要删除吗？删除后不可恢复！如果您删除的是目录，会导致其下的文件也不可访问！');">
		            <span><img src="<%= ResolveClientUrl("~/modules/images/t03.png") %>"></span>删除
	            </asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton runat="server" ID="btnArchiving" OnClick="btnArchiving_Click" OnClientClick="return confirm('确定要归档吗？归档后不允许再对文件进行修改！');">
	                <span><img src="<%= ResolveClientUrl("~/modules/images/t06.png") %>"></span>归档
                </asp:LinkButton>
			</li>
            <asp:PlaceHolder runat="server" ID="phSendButton" Visible="False">
                <li><a href="<%= SendUrl %>"><span>
                <img src="<%= ResolveClientUrl("~/modules/images/t06.png") %>"></span>提交</a></li>
            </asp:PlaceHolder>
        </ul>
        <%--<asp:FileUpload runat="server" ID="fileUpload" />
        <asp:Button runat="server" ID="btnFileUpload" OnClick="btnFileUpload_OnClick" /> --%>
		<asp:LinkButton runat="server" ID="btnRefresh" OnClick="btnRefresh_OnClick" style="display:none"></asp:LinkButton>
    </div>
    <div id="uploadFileDialog" class="tip">
        <div class="tiptop"><span>创建目录</span><a onclick="$('.tip').hide()"></a></div>
        <div class="tipinfo" style="padding-top: 0px; margin-left: 0px;">
            <div style="padding: 10px;">
                <asp:TextBox ID="txtDirName" runat="server" class="dfinput"></asp:TextBox>
            </div>
            <div class="tipbtn">
                <asp:Button runat="server" ID="btnCreateDir" CssClass="sure" Text="创建" OnClick="btnCreateDir_OnClick" />
                &nbsp;&nbsp;<input name="" type="button" class="sure" value="关闭" onclick="$('.tip').hide()" />&nbsp;
            </div>
        </div>
        <div class="clear"></div>
    </div>
    <script type="text/javascript">
        function createDir() {
            $("#uploadFileDialog").fadeIn(200);
            return false;
        }
        function modify(id) {
            layer.open({
                type: 2,
                title: '修改文件存储信息',
                shadeClose: true,
                shade: false,
                maxmin: true, //开启最大化最小化按钮
                area: ['350px', '230px'],
                content: '<%= ResolveClientUrl("~/modules/common/FileModifyDialog.aspx")%>?key=<%=this._ModuleId%>&id=' + id //iframe的url
            });
        }
    	function loadfiles() {
		    console.log('loadfiles');
		    document.getElementById("<%=this.btnRefresh.ClientID%>").click();
	    }
        $(document).ready(function (e) {
            $("#uploadArrFile").click(function () {
                layer.open({
                    type: 2,
                    title: '文件上传',
                    shadeClose: true,
                    shade: false,
                    maxmin: true, //开启最大化最小化按钮
                    area: ['400px', '300px'],
                    content: '<%= ResolveClientUrl("~/modules/common/FileUploadify.aspx") %>?moduleCode=<%=this._ModuleCode%>&moduleId=<%=this._ModuleId%> &sourceCode=&sourceId=&parentId=<%=this._ParentId%>' //iframe的url
            });
            });
        });
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
</asp:PlaceHolder>
<table class="filetable">
    <thead>
        <tr>
<% if (ShowToolbar) { %>
            <th style="width:30px"><input name="" type="checkbox" value=""></th>
<% } %>
            <th style="width:30%">名称</th>
            <th style="width:180px">修改日期</th>
            <th style="width:80px">类型</th>
            <th style="width:80px">大小</th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        <asp:Repeater runat="server" ID="filelist" OnItemDataBound="filelist_OnItemDataBound">
            <ItemTemplate>
                <tr>
<% if (ShowToolbar) { %>
                    <td><input type="checkbox" runat="server" id="cb" value='<%# Eval("Id") %>' /></td>
<% } %>
                    <td><asp:LinkButton runat="server" ID="filelink" OnClick="filelink_OnClick"></asp:LinkButton></td>
                    <td><%# Eval("CreateDate", "{0:yyyy-MM-dd HH:mm:ss}") %></td>
                    <td><%# GetFileType() %></td>
                    <td class="tdlast"><%# GetFileLength() %></td>
<% if (ShowToolbar) { %>                  
                    <td>
                        <a href="javascript:modify('<%# Eval("Id") %>');">修改</a>
                    </td><% } %>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>
