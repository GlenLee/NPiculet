define(function(require, exports, module) {

	var util = require("./util.js");
	var db = require("./db.js");

	var lib = {
		//登录并储存状态
		login: function(account, pass) {
			util.postString(config.api("login")
				, { "method": "login", "username": account, "password": pass }
				, function(sessionCode) {
					config.session = sessionCode;
					db.setStorage("session", sessionCode);
				}
			);
		},

		//用户注册
		register: function(data) {
			util.post(config.api("reg")
				, data
				, function(result) {
					showMsg(result);
				}
			);
		}
	};

	module.exports = lib;

	function _getError(m, data) {
		var err = function (ex) {
			util.error(m + "错误：" + api + util.getParmString(data) + (data == null ? "" : " 数据：" + JSON.stringify(data)) + " 提示：" + JSON.stringify(ex));
		};
		return err;
	}

	//用户登录检查
	exports.login = function (account, pass, success, err) {
		util.get(url, { "method": "login", "username": account, "password": pass }, success, err);
	};

    exports.register = function (data, success, err) {
        util.get(url, { "method": "register", "username": username, "password": password, "phone": tel, "sex": sex, "birthday": birthday },
	        success, err);
	};
	
	exports.logout = function () {
		db.clearStorage();
		db.clearSession();
	};

	//获取用户资料
	exports.getUserInfo = function (userId, success) {
		var data = { "method": "getSysUserInfo", id: userId }; //参数
		util.post(api, data, function (d) {
			success(d);
		}, _getError("getSysUserInfo", data));
	};

	//获取当前用户信息
	exports.isLogin = function () {
		return db.getStorage("isLogin");
	};

	//设置当前用户信息
	exports.setCurrentUserInfo = function (user) {
		var val = JSON.stringify(user);
		db.setStorage("userInfo", val);
		console.log("setCurrentUserInfo:" + val);
	};

	//获取当前用户信息
	exports.getCurrentUserInfo = function () {
		var val = db.getStorage("userInfo");
		console.log("getCurrentUserInfo:" + val);
		if (val == null) return { ID: 0, Name: "" };
		return JSON.parse(val);
	};

	//设置当前用户资料
	exports.setCurrentUserData = function () {
		var json = {};
		var val = JSON.stringify(json);
		db.setStorage("userData", val);
		console.log("setCurrentUserData:" + val);
	};

	//获取当前用户资料
	exports.getCurrentUserData = function () {
		var val = db.getStorage("userData");
		console.log("getCurrentUserInfo:" + val);
		return JSON.parse(val);
	};

	//是否自动登录
	exports.getAutoLogin = function () {
		return db.getStorage("autoLogin") == "1" ? true : false;
	};

	//设置自动登录
	exports.setAutoLogin = function (val) {
		db.setStorage("autoLogin", val);
	};

	//设置自动登录
	exports.sign = function (success) {
		var user = exports.getCurrentUserInfo();
		if (user != null) {
			util.post(url, { "m": "sign", "id": user.Id }, success);
		}
	};

	//获取用户信息
	exports.reg = function (account, pass, name, success) {
		util.post(url, { "m": "reg", "account": account, "pass": pass, "name": name }, success);
	};

	exports.getPointRecord = function(success, err) {
		var user = exports.getCurrentUserInfo();
		if (user != null) {
			util.post(url, { "m": "pointrecord", "userid": user.Id }, success);
		}
	};
});
