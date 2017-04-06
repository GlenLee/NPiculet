define(function(require, exports, module) {

var isCamera = false;
var _success = null;
var _err = null;

function _cameraSuccess(imageData) {
	isCamera = false;
	if (typeof(_success) === "function")
		_success(imageData);
}

function _cameraError(message) {
    isCamera = false;
    console.log('获取照片失败：' + message);
	if (typeof(_err) === "function")
		_err(message);
}

//获取相机拍摄照片
exports.getCamera = function(success, err) {
	if (!isCamera && navigator.camera) {
		isCamera = true;
		_success = success;
		_err = err;
		navigator.camera.getPicture( _cameraSuccess, _cameraError );
	}
};

});
