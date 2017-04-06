define(function(require, exports, module) {

exports.vibrate = function(m) {
	if (navigator.notification && navigator.notification.vibrate)
		navigator.notification.vibrate(m);
};

});
