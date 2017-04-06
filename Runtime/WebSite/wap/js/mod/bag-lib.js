define(function(require, exports, module) {

	var util = require("./util");
	var db = require("./db");
	var login = require("./login");

	var lib = {
		//授权管理
		auth: {
			//用户登录
			login: function(account, pass) {
				//登录并获取用户session
				util.post(config.api("login")
					, { "account": account, "pass": pass }
					, function(data) {
						config.session = data;
						db.setStorage("session", data);
					}
				);
			}
		}
	};

	module.exports = lib;
});

	//获取数据列表
	// 参数：module:模块名称，data:参数，success:成功时执行，err:失败时执行
	exports.getdata = function(module, data, success, err) {
		if (data != null)
			data.m = module;
		util.get(url, data, success, err);
	};

	//获取板块列表
	// 参数：{ }
	exports.getBoardList = function(data, success, err) {
		exports.getdata("forumlist", data, success, err);
	};

	//获取置顶帖子列表
	// 参数：{ boardid:版块ID,userId:用户ID }
	exports.getTopTopicList = function(data, success, err) {
		exports.getdata("toplist", data, success, err);
	};

	//获取精华帖子列表
	// 参数：{ boardid:版块ID,userId:用户ID }
	exports.getEliteTopicList = function(data, success, err) {
		exports.getdata("elitelist", data, success, err);
	};

	//获取最新帖子列表
	// 参数：{ boardid:版块ID,userId:用户ID }
	exports.getNewTopicList = function(data, success, err) {
		exports.getdata("newlist", data, success, err);
	};

	//获取帖子内容
	// 参数：{ topicid:帖子ID,userId:用户ID }
	exports.getTopicInfo = function(data, success, err) {
		exports.getdata("topicinfo", data, success, err);
	};

	//获取回复列表
	// 参数：{ topicid:帖子ID,userId:用户ID }
	exports.getReplyList = function(data, success, err) {
		exports.getdata("replylist", data, success, err);
	};

	//获取我的帖子列表
	// 参数：{ userId:用户ID, count:数据条数 }
	exports.getTopicMe = function(data, success, err) {
		exports.getdata("topicme", data, success, err);
	};

	//获取最热帖子列表
	// 参数：{ userId:用户ID, count:数据条数 }
	exports.getTopicHot = function(data, success, err) {
		exports.getdata("topichot", data, success, err);
	};

	//获取我的收藏列表
	// 参数：{ userId:用户ID, count:数据条数 }
	exports.getFavorites = function(data, success, err) {
		exports.getdata("favorites", data, success, err);
	};

	//订阅内容
	exports.subscribe = function(data, success, err) {
		exports.getdata("subscribe", data, success, err);
	};

	//获取订阅
	exports.getSubscribe = function(data, success, err) {
		exports.getdata("getsubscribe", data, success, err);
	};

	//获取问题列表
	exports.getHelpList = function(data, success, err) {
		exports.getdata("helplist", data, success, err);
	};

	//保存回复
	exports.sendReply= function(data, success, err) {
		exports.getdata("savereply", data, success, err);
	};
	//保存帖子
	exports.sendTopic=function(data, success, err) {
		exports.getdata("savetopic", data, success, err);
	};
	//更新帖子查看数
	exports.setViewNum=function(data, success, err) {
		exports.getdata("setviewnum", data, success, err);
	};
	//更新帖子查看数
	exports.setLikeNum=function(data, success, err) {
		exports.getdata("setlikenum", data, success, err);
	};

	//更新帖子查看数
	exports.getMyTopicCount=function(data, success, err) {
		exports.getdata("MyTopicCount", data, success, err);
	};

	//更新帖子查看数
	exports.getHotTopicCount=function(data, success, err) {
		exports.getdata("HotTopicCount", data, success, err);
	};

    exports.setFavorites=function(data, success, err) {
        exports.getdata("setfavorites", data, success, err);
    };

/* 创新工作室 */

	//获取工作室列表
	// 参数：{ }
	exports.getTeamList = function(data, success, err) {
		exports.getdata("team-forum-list", data, success, err);
	};

});
