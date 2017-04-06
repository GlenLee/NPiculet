define(function (require, exports, module) {

	var debug = true;		//是否输出调试信息
	var crossdomain = false;	//是否跨域

	////处理异常，参数：{ url: 地址, transmit: 转发, data: 参数 }
	function _getError(m, args, err) {
		if (err == null) {
			err = function (ex) {
				var msg = m + "错误：" + args.url + exports.getParmString(args.data) + (args.data == null ? "" : " 数据：" + JSON.stringify(args.data));
				if (crossdomain && args.transmit) msg += " 转发地址：" + args.transmit;
				msg += " 提示：" + JSON.stringify(ex);
				exports.error(msg);
			};
		}
		return err;
	}

	//显示日志，参数：{ url: 地址, transmit: 转发, data: 参数 }
	function _showCallback(msg, args) {
		if (debug) {
			var m = msg + args.url + exports.getParmString(args.data) + (args.data == null ? "" : " 数据：" + JSON.stringify(args.data));
			if (args.transmit) m += " 转发地址：" + args.transmit;
			exports.log(m);
		}
	}

	//根据 Json 对象，获取URL参数字符串
	exports.getParmString = function (data) {
		if (typeof (data) == "object") {
			var parms = "";
			for (var key in data) {
				parms += parms == "" ? "?" : "&";
				parms += key + "=" + data[key];
			}
			return parms;
		}
		return "";
	};

	//创建 AJAX 配置对象
	function createAjaxOptions(type, json, url, data, success, err) {
		var options = {
			type: type,
			url: url,
			data: data,
			success: success,
			error: err
		};
		if (json) {
			options.dataType = "json";
		}
		/*
		if (config.session) {
			options.headers = {
				"UserSessionCode": config.session
			};
		}
		*/
		return options;
	}

	//以GET方式获取数据
	exports.get = function (url, data, success, err) {
		var d = $.param(data);
		var p = d ? url + ((url.indexOf("?") > -1) ? "&" : "?") + d : url;
		var g = "../js/mod/get.ashx?code=UTF-8&u=" + escape(p);

		_showCallback("util.get 访问：", { url: url, transmit: g, data: data });

		var options = createAjaxOptions("POST", true
			, crossdomain ? g : url
			, data
			, success
			, _getError("util.get", { url: url, transmit: crossdomain ? g : null, data: data }, err)
		);
		$.ajax(options);
	};

	//以POST方式获取数据
	exports.post = function (url, data, success, err) {
		var g = "../js/mod/post.ashx?code=UTF-8&u=" + escape(url);

		_showCallback("util.post 访问：", { url: url, transmit: g, data: data });

		var options = createAjaxOptions("POST", true
			, crossdomain ? g : url
			, data
			, success
			, _getError("util.post", { url: url, transmit: crossdomain ? g : null, data: data }, err)
		);
		$.ajax(options);
	};

	//以GET方式获取数据
	exports.getString = function (url, data, success, err) {
		var d = $.param(data);
		var p = d ? url + ((url.indexOf("?") > -1) ? "&" : "?") + d : url;
		var g = "../js/mod/get.ashx?code=UTF-8&u=" + escape(p);

		_showCallback("util.getString 访问：", { url: url, transmit: g, data: data });

		var options = createAjaxOptions("GET", false
			, crossdomain ? g : url
			, data
			, success
			, _getError("util.getString", { url: url, transmit: crossdomain ? g : null, data: data }, err)
		);
		$.ajax(options);
	};

	//以POST方式获取数据
	exports.postString = function (url, data, success, err) {
		var g = "../js/mod/post.ashx?code=UTF-8&u=" + escape(url);

		_showCallback("util.postString 访问：", { url: url, transmit: g, data: data });

		var options = createAjaxOptions("POST", false
			, crossdomain ? g : url
			, data
			, success
			, _getError("util.postString", { url: url, transmit: crossdomain ? g : null, data: data }, err)
		);
		$.ajax(options);
	};

	//记录日志
	exports.log = function (msg) {
		//将日志记录到本地存储或日志文件
		console.log(msg);
	};

	//记录日志
	exports.error = function (msg) {
		//将日志记录到本地存储或日志文件
		console.error(msg);
	};

	//获取链接地址参数
	exports.queryString = function (name) {
		var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
		var r = window.location.search.substr(1).match(reg);
		if (r != null) return unescape(r[2]); return null;
	};

	//获取链接地址参数
	exports.query = function (name) {
		var url = window.location.search;
		var theRequest = new Object();
		if (url.indexOf("?") != -1) {
			var str = url.substr(1);
			strs = str.split("&");
			for (var i = 0; i < strs.length; i++) {
				if (typeof (name) == "string") {
					return unescape(strs[i].split("=")[1]);
				}
				theRequest[strs[i].split("=")[0]] = unescape(strs[i].split("=")[1]);
			}
		}
		return theRequest;
	};

	//获取日期比较间隔
	exports.getTimeDiff = function (date) {
		try {
			var date1 = new Date(date);
			var date2 = new Date();
			//结束时间
			var date3 = date2.getTime() - date1.getTime();

			//计算出相差天数
			var days = Math.floor(date3 / (24 * 3600 * 1000));

			//计算出小时数
			var leave1 = date3 % (24 * 3600 * 1000);

			//计算天数后剩余的毫秒数
			var hours = Math.floor(leave1 / (3600 * 1000));

			//计算相差分钟数
			var leave2 = leave1 % (3600 * 1000);

			//计算小时数后剩余的毫秒数
			var minutes = Math.floor(leave2 / (60 * 1000));

			//计算相差秒数
			var leave3 = leave2 % (60 * 1000);

			//计算分钟数后剩余的毫秒数
			var seconds = Math.round(leave3 / 1000);

			if (days > 6) {
				return "一周前";
			}
			if (days > 0) {
				return days + "天前";
			}
			if (hours > 0) {
				return hours + "小时前";
			}
			if (minutes > 0) {
				return minutes + "分钟前";
			}
			if (seconds > 0) {
				return seconds + "秒前";
			}
			return date.getYear() + "年" + (date.getMonth() + 1) + "月" + date.getDate(); //.substr(0,date.indexOf(' '));
		} catch (ex) {
			return "";
		}
	};

	exports.left = function (msg, length) {
		if (msg.length > length) {
			return msg.substring(0, length - 1) + "…";
		}
		return msg;
	};

});
