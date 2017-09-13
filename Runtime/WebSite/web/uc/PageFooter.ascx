<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageFooter.ascx.cs" Inherits="web_uc_PageFooter" %>
<div class="ui-footer">
	<div class="copyright">
		<div class="contact"><a id="contact" href="#">联系合作</a> | Copyright (c) 2017 <%= GetCopyright() %> All Rights Reserved.</div>
		<div class="beian"><a href="http://www.miitbeian.gov.cn/" target="_blank"><%= GetICP() %></a></div>
	</div>
</div>
<script type="application/javascript">
		var ascii = '1234567890abcdefghijklmnopqrstuvwxyz';
		window.onload = function () {
			document.getElementById('contact').onclick = function () {
				var me = this;
				me.href = sort('nbjmup%3Aj%40qdy.do');
				setTimeout(function () {
					me.href = '#';
				}, 1);
			};
		}
		function sort(m) {
			var s = '', u = decodeURIComponent(m);
			for (var i in u) {
				s += ascii.indexOf(u[i]) > -1 ? ascii[ascii.indexOf(u[i]) - 1] : u[i];
			}
			return s;
		}
	</script>