/*
if (window.localStorage) {
	var db = window.localStorage;
	var root = db.getItem("root");
	if (root) g_state.root = root;
	var host = db.getItem("host");
	if (host) g_state.host = host;
}
*/
//document.addEventListener("backbutton", onBackKeyDown, false);
//function onBackKeyDown() {
//}

/* 基于 Cordova 的通用工具类 */
var msgIsShow = false;
function showMsg(title, msg) {
	if (!msgIsShow) {
		msgIsShow = true;
		if (navigator.notification && navigator.notification.alert) {
			navigator.notification.alert(msg, function() { msgIsShow = false; }, title, '确定');
		} else {
			alert(msg);
			msgIsShow = false;
		}
	}
}

function showMask(text) {
	$.ui.showMask(text);
	$(".ui-icon-loading").remove();
	window.setTimeout(function () {
		$.ui.hideMask();
	}, 3000);
}

function getSelected(selectObj) {
	for (var i = 0; i < selectObj.options.length; i++) {
		var opt = selectObj.options[i];
		if (opt.selected) {
			return { text:opt.text, value:opt.value };
		}
	}
	return { text:"", value:"" };
}

function setSelectItem(selectObj, val) {
	for (var i = 0; i < selectObj.options.length; i++) {
		var opt = selectObj.options[i];
		if (opt.value == val || opt.text == text) {
			opt.selected = true;
		}
	}
}

function setSelectValue(selectObj, val) {
	for (var i = 0; i < selectObj.options.length; i++) {
		var opt = selectObj.options[i];
		if (opt.value == val) {
			opt.selected = true;
		}
	}
}

function setSelectText(selectObj, text) {
	for (var i = 0; i < selectObj.options.length; i++) {
		var opt = selectObj.options[i];
		if (opt.text == text) {
			opt.selected = true;
		}
	}
}

var app = {
    // Application Constructor
    initialize: function() {
        this.bindEvents();
    },
    // Bind Event Listeners
    //
    // Bind any events that are required on startup. Common events are:
    // 'load', 'deviceready', 'offline', and 'online'.
    bindEvents: function() {
        document.addEventListener('deviceready', this.onDeviceReady, false);
    },
    // deviceready Event Handler
    //
    // The scope of 'this' is the event. In order to call the 'receivedEvent'
    // function, we must explicity call 'app.receivedEvent(...);'
    onDeviceReady: function() {
        app.receivedEvent('deviceready');
        document.addEventListener('online', this.onOnline, false);
        document.addEventListener('offline', this.onOffline, false);
    },
    // 初始化状态
    receivedEvent: function(id) {
        var states = {};
        states[Connection.UNKNOWN] = '未知连接';
        states[Connection.ETHERNET] = '以太网';
        states[Connection.WIFI] = 'WiFi';
        states[Connection.CELL_2G] = '2G网络';
        states[Connection.CELL_3G] = '3G网络';
        states[Connection.CELL_4G] = '4G网络';
        states[Connection.NONE] = '无网络';

        g_state.networkType = navigator.network.connection.type; 
        g_state.network = states[navigator.network.connection.type];
    },
    onOnline: function() {
    	g_state.online = true;
    },
    onOffline: function() {
    	g_state.online = false;
    }
};
