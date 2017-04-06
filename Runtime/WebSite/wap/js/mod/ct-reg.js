define(function (require, exports, module) {

	var util = require("util");

	var reg = {

		init: function () {
			$("#reg-flag").val("1");
		},

		verifycode: function (me) {
			var self = $(me);
			if (self.attr("disabled") != "true") {
				var phone = $("#reg-phone").val();
				var x = /^\d{11}$/ig;
				if (x.test(phone)) {
					self.attr("disabled", "true").removeClass("red").addClass("grey");

					//MemberExist,OK,Fail
					util.post(config.api("reg-verify"), { "phone": phone }, function (data) {
						if (data && data.status == "200") {
							var times = 180;
							var timer = setInterval(function() {
								self.val("已发送" + times--);
								if (times <= 0) {
									clearInterval(timer);
									timer = null;
									self.removeAttr("disabled").removeClass("grey").addClass("red").val("发送验证码");
								}
							}, 1000);
							$("#reg-phone").attr("readonly", "true");
							$("#reg-next").removeAttr("disabled").removeClass("grey").addClass("red");
						} else {
							if (data.message == "MemberExist") {
								alert("此手机已经注册！");
							} else {
								alert("验证短信发送失败！");
							}
							console.log(JSON.stringify(data));
							self.removeAttr("disabled").removeClass("grey").addClass("red");
						}
					});
				} else {
					alert("请填入正确的手机号！");
				}
			}
		},

		next: function (me) {
			var self = $(me);
			if (self.attr("disabled") != "true") {
				var phone = $("#reg-phone").val();
				var verifycode = $("#reg-verify").val();

				if (verifycode.length !== 6) {
					alert("验证码输入错误！");
					return;
				}

				var x = /^\d{11}$/ig;
				if (!x.test(phone)) {
					alert("手机号输入不正确！");
					return;
				}

				util.post(config.api("reg-next"), { "phone": phone, "code": verifycode }, function (data) {
					if (data && data.status == "200") {
						var url = "reg-data.aspx?phone=" + data.phone + "&id=" + data.id;
						window.location.href = url;
					} else {
						alert("验证不正确！");
					}
				});
			}
		},

		dataInit: function () {
			$("#reg-dataflag").val("1");
			$("#phone").val(util.query("phone"));
		},


	};

	module.exports = reg;

});