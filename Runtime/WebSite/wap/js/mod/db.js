define(function(require, exports, module) {

	exports.db = null;

	var getDb = function() {
		if (!window.openDatabase) {
			console.log("no local Database!");
		} else {
			var dbName      = dbName ? dbName : 'EBBS_APP';  
			var dbVersion   = dbVersion ? dbVersion : '1.0';  
			var dbDesc      = dbDesc ? dbDesc : 'EBBS_APP for User Mobile';  
			var dbSize      = dbSize ? dbSize : (2 * 1024 * 1024);  

			exports.db = openDatabase(dbName, dbVersion, dbDesc, dbSize);   

			return exports.db;  
		}
		return null;
	};

	exports.init = function () {
		var db = getDb();
		if (db != null) {
			db.transaction(function(tx) {
				try {
					tx.executeSql('SELECT key, value FROM AppConfig WHERE key="API-Server-IP" OR key="API-Server-Path"', [], function(tx, results) {
						var length = results.rows.length;
						if (length != 2) {
							console.log("No init. DATA LENGTH:" + length);
							initTable(tx);
						}
					}, function(err) {
						console.log("No init. ERROR:" + JSON.stringify(err));
						//初始化配置表
						initTable(tx);
					});
				} catch (ex) {
					console.log("Init ERROR:" + JSON.stringify(ex));
				}
			}, function (err) {
				console.log("Error processing SQL: " + JSON.stringify(err));
			}, function () {
				console.log("Init db success!");
			});
		}
	};

	function initTable(tx) {
		var g = require("./global.js");
		console.log("Init Table Begin!");
		tx.executeSql('DROP TABLE IF EXISTS AppConfig');
		tx.executeSql('CREATE TABLE IF NOT EXISTS AppConfig (id unique, key, value)');
		tx.executeSql('INSERT INTO AppConfig (id, key, value) VALUES (1, "API-Server-IP", "' + g.config.ip + '")');
		tx.executeSql('INSERT INTO AppConfig (id, key, value) VALUES (2, "API-Server-Path", "' + g.config.path + '")');
		console.log("Init Table End!");
	}

	exports.exist = function () {
	};

	//执行数据操作语句，可传入语句数组
	// query('SELECT * FROM DEMO', [], success, err);
	exports.query = function (sql, args, success, err) {
		var db = getDb();
		if (err == null) {
			err = function (err) {
				console.log("SQL:[" + sql + "] ERROR:" + JSON.stringify(err));
			};
		}
		if (db != null) {
			// tx.executeSql('SELECT * FROM DEMO', [], querySuccess, errorCB);
			// querySuccess(tx, results), errorCB(err)
			db.transaction(function(tx) {
				tx.executeSql(sql, args, success, err);
			}, args, function () {
				console.log("SQL:[" + sql + "] SUCCESS!");
			});
		}
	};

	//执行数据操作语句，可传入语句数组
	exports.execute = function (sql, success, err) {
		var db = getDb();
		if (err == null) {
			err = function (err) {
				console.log("SQL:[" + sql + "] ERROR:" + JSON.stringify(err));
			};
		}
		if (db != null) {
			// db.transaction(populateDB, errorCB, successCB);
			// populateDB(tx), errorCB(err), successCB()
			db.transaction(function(tx) {
				if (typeof(sql) == "string") {
					tx.executeSql(sql);
				}
				if (typeof(sql) == "object" && sql.length >= 1) {
					for (var i = 0; i < sql.length; i++)
						tx.executeSql(sql[i]);
				}					
			}, err, success);
		}
	};

	/* 本地存储操作 */

	exports.setStorage = function (key, value) {
		if (window.localStorage) {
			var storage = window.localStorage;
			if (storage.getItem(key) != null) storage.removeItem(key);
			storage.setItem(key, value);
			return true;
		}
		return false;
	};

	exports.removeStorage = function (key) {
		if (window.localStorage) {
			var storage = window.localStorage;
			storage.removeItem(key);
			return true;
		}
		return false;
	};

	exports.getStorage = function (key) {
		if (window.localStorage) {
			var storage = window.localStorage;
			return storage.getItem(key);
		}
		return null;
	};

	exports.clearStorage = function () {
		if (window.localStorage) {
			var storage = window.localStorage;
			storage.clear();
			return true;
		}
		return false;
	};

	exports.countStorage = function () {
		if (window.localStorage) {
			var storage = window.localStorage;
			return storage.length;
		}
		return false;
	};

	/* 本地 Session 操作 */

	exports.setSession = function (key, value) {
		if (window.localStorage) {
			var storage = window.sessionStorage;
			if (storage.getItem(key) != null) storage.removeItem(key);
			storage.setItem(key, value);
			return true;
		}
		return false;
	};

	exports.removeSession = function (key) {
		if (window.localStorage) {
			var storage = window.sessionStorage;
			storage.removeItem(key);
			return true;
		}
		return false;
	};

	exports.getSession = function (key) {
		if (window.localStorage) {
			var storage = window.sessionStorage;
			return storage.getItem(key);
		}
		return null;
	};

	exports.clearSession = function () {
		if (window.localStorage) {
			var storage = window.sessionStorage;
			storage.clear();
			return true;
		}
		return false;
	};

	exports.countSession = function () {
		if (window.localStorage) {
			var storage = window.sessionStorage;
			return storage.length;
		}
		return false;
	};

});
