/* 弹出窗口函数组 */

//初始化窗口大小配置对象
function InitSizeOption(options) {
	if (typeof (options) == 'object' && options != null) {
		options.w = (typeof (options.w) == 'number') ? options.w : screen.width;
		options.h = (typeof (options.h) == 'number') ? options.h : screen.height;
		return options;
	} else {
		return { w: screen.width, h: screen.height };
	}
}

//弹出模态窗口，回调函数的传入参数范例：Callback(val, options);
function OpenModel(url, options, callback) {
	var opts = InitSizeOption(options);

	//自动刷新窗口
	if (url.indexOf('?') > -1) {
		url += '&' + Math.random();
	} else {
		url += '?' + Math.random();
	}

	var val = window.showModalDialog(url, window, 'DialogWidth:' + opts.w + 'px;DialogHeight:' + opts.h + 'px;help:no;status:no;scroll:auto');
	//回调函数
	if (typeof (callback) == 'function')
		callback(val, opts);
	return false;
}
