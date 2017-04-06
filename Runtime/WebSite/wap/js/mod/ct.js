var ct = window.ct = {
	//注册
	reg: {
		//初始化
		init: function (me) {
			seajs.use("./js/mod/ct-reg", function (reg) {
				reg.init();
			});
		},
		//发送验证码
		verifycode: function (me) {
			seajs.use("./js/mod/ct-reg", function (reg) {
				reg.verifycode(me);
			});
		},
		//注册
		next: function (me) {
			seajs.use("./js/mod/ct-reg", function (reg) {
				//reg.next(me);
				var phone = $("#reg-phone").val();
				var verify = $("#reg-phone-confirm").val();

				if (phone != verify) {
					alert("输入的手机号不一致！");
					return;
				}

				var x = /^\d{11}$/ig;
				if (!x.test(phone)) {
					alert("手机号位数不正确！");
					return;
				}

				util.post(config.api("reg-next"), { "phone": phone, "code": verifycode }, function (data) {
					if (data && data.status == "200") {
						var url = "reg-data.aspx?phone=" + data.phone + "&id=" + data.id;
						window.location.href = url;
					} else {
						alert("注册失败，手机号已存在！");
					}
				});
			});
		},
		//个人信息初始化
		dataInit: function (me) {
			seajs.use("./js/mod/ct-reg", function (reg) {
				reg.dataInit(me);
			});
		}
	}
};