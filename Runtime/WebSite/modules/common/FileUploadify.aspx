<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileUploadify.aspx.cs" Inherits="modules_common_FileUploadify" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head" runat="server">
    <link href="<%= ResolveClientUrl("~/modules/js/lib/uploadify/uploadify.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%= ResolveClientUrl("~/scripts/lib/jquery-1.11.3.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveClientUrl("~/modules/js/lib/uploadify/jquery.uploadify.min.js") %>" type="text/javascript"></script>
	<style type="text/css">
		.uploadControl { padding:10px; }
		.uploadControl>div { margin:0 auto; }
	</style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div id="fileQueue" class="fileQueue"></div>
        <div class="uploadControl">
            <input type="file" name="file_upload" id="file_upload" />
            <!--<p>
                <input type="button" class="btn" id="btnUpload" onclick="javascript: $('#file_upload').uploadify('upload', '*')" value="上传" />
                <input type="button" class="btn" id="btnCancelUpload" onclick="javascript: $('#file_upload').uploadify('cancel')" value="取消" />
            </p>-->
        </div>
    </form>
    <script>
        $(document).ready(function () {
            $("#file_upload").uploadify({
                'buttonText': '选择文件',                        //按钮文本
                "cancelImg": "<%= ResolveClientUrl("~/modules/js/lib/uploadify/uploadify-cancel.png")%>",
                "swf": "<%= ResolveClientUrl("~/modules/js/lib/uploadify/uploadify.swf")%>",                        //FLash文件路径
                "uploader": "<%= ResolveClientUrl("~/modules/common/FileUploadHandler.ashx")%>", //处理ASHX页面
                'formData': { 'moduleCode': 'pro_project_info', 'moduleId': '<%= Request.QueryString["moduleId"] %>', 'sourceCode': '<%= Request.QueryString["sourceCode"] %>', 'sourceId': '<%= Request.QueryString["sourceId"] %>', 'parentId': '<%= Request.QueryString["parentId"] %>' },         //传参数
                'queueID': 'fileQueue',                        //队列的ID
                'queueSizeLimit': 10,                           //队列最多可上传文件数量，默认为999
                'auto': true,                                 //选择文件后是否自动上传，默认为true
                'multi': true,                                 //是否为多选，默认为true
                'removeCompleted': true,                       //是否完成后移除序列，默认为true
                'fileSizeLimit': '0',                       //单个文件大小，0为无限制，可接受KB,MB,GB等单位的字符串值
                'fileTypeDesc': '招投标资料上传',                 //文件描述
                'fileTypeExts': '*.*',  //上传的文件后缀过滤器
                'onQueueComplete': function (event, data) {    //所有队列完成后事件
	                if (window.parent.loadfiles) {
		                window.parent.loadfiles();
	                } else {
		                window.parent.location = window.parent.location;
	                }
                },
                'onUploadError': function (event, queueId, fileObj, errorObj) {
                    alert(errorObj.type + "：" + errorObj.info);
                }
            });
        });
    </script>
</body>
</html>
