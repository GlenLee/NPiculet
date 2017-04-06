var config = {
	version: "1.0",
	lang: "zh-cn",

	host: "http://localhost:35160/WebSite/api/",

	session: "",

	api: function(module) {
		return config.host + module + "?rnd=" + Math.random();
	}
};

var page = {
	args: {},
	system: {}
};