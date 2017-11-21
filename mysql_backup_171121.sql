/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 50625
Source Host           : 127.0.0.1:13366
Source Database       : npiculet

Target Server Type    : MYSQL
Target Server Version : 50625
File Encoding         : 65001

Date: 2017-11-21 17:30:08
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for bas_attachment
-- ----------------------------
DROP TABLE IF EXISTS `bas_attachment`;
CREATE TABLE `bas_attachment` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ModuleCode` varchar(128) DEFAULT NULL,
  `ModuleId` varchar(64) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `Mode` varchar(16) DEFAULT NULL COMMENT '模式：Dir、File',
  `Name` varchar(255) DEFAULT NULL,
  `FileName` varchar(255) NOT NULL,
  `FileType` varchar(32) DEFAULT NULL,
  `FilePath` varchar(255) DEFAULT NULL,
  `FileExt` varchar(16) DEFAULT NULL,
  `Length` int(11) DEFAULT NULL,
  `SourceCode` varchar(128) DEFAULT NULL,
  `SourceId` varchar(128) DEFAULT NULL,
  `Description` longtext,
  `ParentId` int(11) DEFAULT NULL,
  `Layer` int(11) DEFAULT NULL,
  `IsDir` int(11) DEFAULT NULL,
  `IsTmpl` int(11) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bas_attachment
-- ----------------------------

-- ----------------------------
-- Table structure for bas_dataapi_info
-- ----------------------------
DROP TABLE IF EXISTS `bas_dataapi_info`;
CREATE TABLE `bas_dataapi_info` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Type` varchar(16) DEFAULT NULL,
  `Name` varchar(32) DEFAULT NULL,
  `Description` text,
  `Command` text,
  `Path` varchar(255) DEFAULT NULL,
  `SourceAdapter` varchar(255) DEFAULT NULL,
  `OutputProvider` varchar(255) DEFAULT NULL,
  `ExternalUrl` text,
  `Mapping` text,
  `Roles` text,
  `Status` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bas_dataapi_info
-- ----------------------------

-- ----------------------------
-- Table structure for bas_deputy_info
-- ----------------------------
DROP TABLE IF EXISTS `bas_deputy_info`;
CREATE TABLE `bas_deputy_info` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Duty` varchar(16) DEFAULT NULL,
  `Name` varchar(32) DEFAULT NULL,
  `Sex` varchar(8) DEFAULT NULL,
  `Region` varchar(32) DEFAULT NULL,
  `Nation` varchar(32) DEFAULT NULL,
  `NativePlace` varchar(32) DEFAULT NULL,
  `Education` varchar(32) DEFAULT NULL,
  `Party` varchar(128) DEFAULT NULL,
  `Profession` varchar(128) DEFAULT NULL,
  `Org` varchar(255) DEFAULT NULL,
  `Job` varchar(255) DEFAULT NULL,
  `Description` text,
  `Photo` varchar(255) DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bas_deputy_info
-- ----------------------------
INSERT INTO `bas_deputy_info` VALUES ('1', '主任', '测试0', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', null, '~/styles/images/head.jpg', '1', '2017-11-06 20:43:02', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('2', '副主任', '测试1', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '1', '2017-11-06 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('3', '副主任', '测试2', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '2', '2017-11-07 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('4', '副主任', '测试3', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '3', '2017-11-08 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('5', null, '测试4', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '4', '2017-11-09 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('6', null, '测试5', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '5', '2017-11-10 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('7', null, '测试6', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '6', '2017-11-11 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('8', null, '测试7', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '7', '2017-11-12 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('9', null, '测试8', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '8', '2017-11-13 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('10', null, '测试9', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '9', '2017-11-14 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('11', null, '测试10', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '10', '2017-11-15 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('12', null, '测试11', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '11', '2017-11-16 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('13', null, '测试12', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '12', '2017-11-17 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('14', null, '测试13', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '13', '2017-11-18 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('15', null, '测试14', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '14', '2017-11-19 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('16', null, '测试15', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '15', '2017-11-20 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('17', null, '测试16', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '16', '2017-11-21 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('18', null, '测试17', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '17', '2017-11-22 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('19', null, '测试18', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '18', '2017-11-23 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('20', null, '测试19', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '19', '2017-11-24 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('21', null, '测试20', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '20', '2017-11-25 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('22', null, '测试21', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '21', '2017-11-26 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('23', null, '测试22', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '22', '2017-11-27 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('24', null, '测试23', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '23', '2017-11-28 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('25', null, '测试24', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '24', '2017-11-29 20:43:00', '管理员');
INSERT INTO `bas_deputy_info` VALUES ('26', null, '测试25', '男', '红河州代表团', '汉', '昆明', '大学本科', '中国共产党', '无', '无', '无', '', '~/styles/images/head.jpg', '25', '2017-11-30 20:43:00', '管理员');

-- ----------------------------
-- Table structure for bas_dict_group
-- ----------------------------
DROP TABLE IF EXISTS `bas_dict_group`;
CREATE TABLE `bas_dict_group` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Code` varchar(32) NOT NULL COMMENT '字典组编码',
  `Name` varchar(64) NOT NULL COMMENT '字典组名称',
  `DisplayMode` varchar(16) DEFAULT NULL COMMENT '展示方式',
  `Memo` varchar(255) DEFAULT NULL COMMENT '备注',
  `IsEntity` int(11) NOT NULL COMMENT '是否是实体数据表',
  `EntityCode` varchar(128) DEFAULT NULL COMMENT '实体数据表编码',
  `IsDel` int(11) NOT NULL COMMENT '是否已删除',
  `IsEnabled` int(11) NOT NULL COMMENT '是否已启用',
  `Sort` int(11) DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 COMMENT='字典分组';

-- ----------------------------
-- Records of bas_dict_group
-- ----------------------------
INSERT INTO `bas_dict_group` VALUES ('1', 'SystemLog', '系统日志分类', '下拉列表', '类型,日志名称,日志编码', '0', null, '0', '1', null, '管理员', '2017-09-06 00:00:00');
INSERT INTO `bas_dict_group` VALUES ('2', 'EntNature', '企业性质', '下拉列表', '', '0', null, '0', '1', null, '管理员', '2017-09-06 00:00:00');
INSERT INTO `bas_dict_group` VALUES ('3', 'UserType', '用户类型', '下拉列表', '', '0', null, '0', '1', null, '管理员', '2017-09-06 00:00:00');
INSERT INTO `bas_dict_group` VALUES ('4', 'AdPosition', '广告位置', '下拉列表', '', '0', null, '0', '1', null, '管理员', '2017-09-06 00:00:00');
INSERT INTO `bas_dict_group` VALUES ('5', 'FieldType', '字段类型', '下拉列表', '', '0', null, '0', '1', null, '管理员', '2017-10-30 22:18:21');
INSERT INTO `bas_dict_group` VALUES ('6', 'ExtLinkType', '外链类型', '下拉列表', '', '0', null, '0', '1', null, '管理员', '2017-11-03 13:35:16');
INSERT INTO `bas_dict_group` VALUES ('7', 'Region', '所属代表团', '下拉列表', '', '0', null, '1', '1', null, '管理员', '2017-11-04 23:44:14');
INSERT INTO `bas_dict_group` VALUES ('8', 'Duty', '人大职能', '下拉列表', '', '0', null, '1', '1', null, '管理员', '2017-11-06 21:38:43');

-- ----------------------------
-- Table structure for bas_dict_item
-- ----------------------------
DROP TABLE IF EXISTS `bas_dict_item`;
CREATE TABLE `bas_dict_item` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `GroupCode` varchar(32) NOT NULL COMMENT '字典组编码',
  `Code` varchar(32) NOT NULL COMMENT '项编码',
  `Name` varchar(64) NOT NULL COMMENT '属性名称',
  `Value` varchar(255) DEFAULT NULL COMMENT '属性值',
  `Memo` varchar(255) DEFAULT NULL,
  `IsEnabled` int(11) NOT NULL COMMENT '是否已启用',
  `Sort` int(11) DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8 COMMENT='字典项';

-- ----------------------------
-- Records of bas_dict_item
-- ----------------------------
INSERT INTO `bas_dict_item` VALUES ('1', 'EntNature', 'ListedCompany', '国内上市公司', 'ListedCompany', null, '1', '2', '管理员', '2016-03-23 21:00:52');
INSERT INTO `bas_dict_item` VALUES ('2', 'EntNature', 'SOE', '国有企业', 'SOE', null, '1', '3', '管理员', '2016-03-23 21:11:46');
INSERT INTO `bas_dict_item` VALUES ('3', 'EntNature', 'PrivateEnterprise', '私营企业', 'PrivateEnterprise', null, '1', '1', '管理员', '2016-03-23 21:13:35');
INSERT INTO `bas_dict_item` VALUES ('4', 'EntNature', 'JointVenture', '中外合资', 'JointVenture', null, '1', '4', '管理员', '2016-03-23 21:14:45');
INSERT INTO `bas_dict_item` VALUES ('5', 'EntNature', 'HKMT', '港澳台企业', 'HKMT', null, '1', '5', '管理员', '2016-03-23 21:16:01');
INSERT INTO `bas_dict_item` VALUES ('6', 'SystemLog', 'Login', '系统登录', '', '', '1', null, '管理员', '2017-09-04 21:16:01');
INSERT INTO `bas_dict_item` VALUES ('7', 'SystemLog', 'User', '管理用户', '', '', '1', null, '管理员', '2017-09-04 18:14:14');
INSERT INTO `bas_dict_item` VALUES ('8', 'SystemLog', 'Auth', '管理授权', '', '', '1', null, '管理员', '2017-09-04 18:14:30');
INSERT INTO `bas_dict_item` VALUES ('9', 'UserType', '0', '普通用户', '', '', '1', null, '管理员', '2017-09-05 21:54:54');
INSERT INTO `bas_dict_item` VALUES ('10', 'UserType', '1', '管理员', '', '', '1', null, '管理员', '2017-09-05 21:58:54');
INSERT INTO `bas_dict_item` VALUES ('11', 'AdPosition', 'ad.top', '首页顶部广告', '', '', '1', null, '管理员', '2017-09-06 10:18:19');
INSERT INTO `bas_dict_item` VALUES ('12', 'AdPosition', 'ad.lb', '轮播广告', '', '', '1', null, '管理员', '2017-09-06 10:19:08');
INSERT INTO `bas_dict_item` VALUES ('13', 'FieldType', 'Text', '文本', 'text', '', '1', '1', '管理员', '2017-10-30 22:19:14');
INSERT INTO `bas_dict_item` VALUES ('14', 'FieldType', 'Number', '数字', 'number', '', '1', '3', '管理员', '2017-10-30 22:19:44');
INSERT INTO `bas_dict_item` VALUES ('15', 'FieldType', 'Dict', '字典', 'dict', '', '1', '4', '管理员', '2017-10-30 22:19:57');
INSERT INTO `bas_dict_item` VALUES ('16', 'FieldType', 'RadioBox', '单选框', 'radio', '', '1', '5', '管理员', '2017-10-30 22:20:41');
INSERT INTO `bas_dict_item` VALUES ('17', 'FieldType', 'CheckBox', '复选框', 'checkbox', '', '1', '6', '管理员', '2017-10-30 22:20:59');
INSERT INTO `bas_dict_item` VALUES ('18', 'FieldType', 'SelectUserDialog', '选择用户', 'userdialog', '', '1', '7', '管理员', '2017-10-30 22:23:27');
INSERT INTO `bas_dict_item` VALUES ('19', 'FieldType', 'SelectRoleDialog', '选择角色', 'roledialog', '', '1', '8', '管理员', '2017-10-30 22:23:45');
INSERT INTO `bas_dict_item` VALUES ('20', 'FieldType', 'SelectOrgDialog', '选择组织机构', 'orgdialog', '', '1', '9', '管理员', '2017-10-30 22:24:07');
INSERT INTO `bas_dict_item` VALUES ('21', 'FieldType', 'LongText', '长文本', 'longtext', '', '1', '2', '管理员', '2017-11-02 10:00:49');
INSERT INTO `bas_dict_item` VALUES ('22', 'AdPosition', 'ad.middle', '首页中部广告', '', '', '1', null, '管理员', '2017-11-02 10:39:59');
INSERT INTO `bas_dict_item` VALUES ('24', 'ExtLinkType', 'BusinessLink', '业务平台', '', '', '1', '1', '管理员', '2017-11-03 13:36:56');

-- ----------------------------
-- Table structure for bas_notice_info
-- ----------------------------
DROP TABLE IF EXISTS `bas_notice_info`;
CREATE TABLE `bas_notice_info` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Sn` varchar(64) DEFAULT NULL,
  `Title` varchar(128) DEFAULT NULL COMMENT '标题',
  `Content` longtext COMMENT '内容',
  `NoticeType` varchar(64) DEFAULT NULL COMMENT '类型(View查看后完成；Process处理后完成)',
  `NoticeSource` varchar(128) DEFAULT NULL COMMENT '来源（模块名枚举）',
  `Url` varchar(255) DEFAULT NULL COMMENT '跳转地址',
  `SenderId` varchar(64) DEFAULT NULL COMMENT '发送人ID',
  `SenderName` varchar(32) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bas_notice_info
-- ----------------------------

-- ----------------------------
-- Table structure for bas_notice_record
-- ----------------------------
DROP TABLE IF EXISTS `bas_notice_record`;
CREATE TABLE `bas_notice_record` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `NoticeSn` varchar(64) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL COMMENT '目标ID',
  `IsRead` int(11) DEFAULT NULL COMMENT '是否已读',
  `ReadDate` datetime DEFAULT NULL COMMENT '已读时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bas_notice_record
-- ----------------------------

-- ----------------------------
-- Table structure for bas_region_info
-- ----------------------------
DROP TABLE IF EXISTS `bas_region_info`;
CREATE TABLE `bas_region_info` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ParentId` int(11) DEFAULT NULL,
  `Type` varchar(16) DEFAULT NULL COMMENT '类型：Province,City,District',
  `Code` varchar(32) DEFAULT NULL COMMENT '项编码',
  `Name` varchar(64) NOT NULL COMMENT '属性名称',
  `ZipCode` varchar(16) DEFAULT NULL,
  `Level` int(11) DEFAULT NULL,
  `IsEnabled` int(11) NOT NULL COMMENT '是否已启用',
  `Creator` varchar(32) DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='字典项';

-- ----------------------------
-- Records of bas_region_info
-- ----------------------------

-- ----------------------------
-- Table structure for cms_adv_info
-- ----------------------------
DROP TABLE IF EXISTS `cms_adv_info`;
CREATE TABLE `cms_adv_info` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Position` varchar(16) DEFAULT NULL,
  `Title` varchar(255) DEFAULT NULL,
  `Image` varchar(255) DEFAULT NULL,
  `Cover` varchar(255) DEFAULT NULL,
  `Url` text,
  `Description` longtext,
  `Css` text,
  `Script` text,
  `Click` int(11) NOT NULL,
  `IsEnabled` int(11) NOT NULL,
  `Sort` int(11) DEFAULT NULL,
  `StartDate` datetime DEFAULT NULL,
  `EndDate` datetime DEFAULT NULL,
  `Delay` int(11) DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL,
  `CreateDate` datetime NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=50 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of cms_adv_info
-- ----------------------------
INSERT INTO `cms_adv_info` VALUES ('37', 'ad.lb', '轮播广告1', '~/uploads/thumb/201710/HA05W3634959.png', null, 'http://pcx.cn', '演示的数据', '', '', '0', '1', null, null, null, null, '管理员', '2016-08-29 20:53:21');
INSERT INTO `cms_adv_info` VALUES ('46', 'ad.middle', '首页中部广告', '~/uploads/thumb/201711/HB02K4230614.jpg', null, 'http://pcx.cn', '演示的数据', '', '', '0', '1', null, null, null, null, '管理员', '2016-08-29 20:58:37');
INSERT INTO `cms_adv_info` VALUES ('48', 'ad.lb', '轮播广告2', '~/uploads/thumb/201710/HA05W3737793.jpg', null, '', '', '', '', '0', '1', null, null, null, null, '管理员', '2017-10-05 22:37:38');

-- ----------------------------
-- Table structure for cms_content_group
-- ----------------------------
DROP TABLE IF EXISTS `cms_content_group`;
CREATE TABLE `cms_content_group` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `GroupCode` varchar(32) DEFAULT NULL,
  `GroupName` varchar(64) DEFAULT NULL,
  `GroupType` varchar(16) NOT NULL,
  `ParentId` int(11) DEFAULT NULL,
  `Layer` int(11) DEFAULT NULL,
  `Path` longtext,
  `Icon` varchar(128) DEFAULT NULL,
  `Url` varchar(255) DEFAULT NULL,
  `OrgId` int(11) DEFAULT NULL,
  `IsEnabled` int(11) NOT NULL,
  `Point` decimal(12,2) DEFAULT NULL,
  `Comment` text,
  `Sort` int(11) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of cms_content_group
-- ----------------------------
INSERT INTO `cms_content_group` VALUES ('1', 'Home', '首页栏目', '', '0', '0', '', '', '', null, '1', null, '', '10', null);
INSERT INTO `cms_content_group` VALUES ('2', 'Publish', '发布日志', 'List', '1', '0', '', '', '', null, '1', null, '', '1', null);
INSERT INTO `cms_content_group` VALUES ('3', 'News', '本站动态', 'List', '1', '0', '', '', '', null, '1', null, '', '0', null);
INSERT INTO `cms_content_group` VALUES ('4', 'Other', '其他', '', '0', '0', '', '', '', null, '1', null, '', '9999', null);

-- ----------------------------
-- Table structure for cms_content_link
-- ----------------------------
DROP TABLE IF EXISTS `cms_content_link`;
CREATE TABLE `cms_content_link` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PageId` int(11) DEFAULT NULL,
  `GroupCode` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of cms_content_link
-- ----------------------------
INSERT INTO `cms_content_link` VALUES ('1', '15', 'tzgg');
INSERT INTO `cms_content_link` VALUES ('2', '15', 'ImageNews');
INSERT INTO `cms_content_link` VALUES ('3', '15', 'rddt');

-- ----------------------------
-- Table structure for cms_content_page
-- ----------------------------
DROP TABLE IF EXISTS `cms_content_page`;
CREATE TABLE `cms_content_page` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Type` varchar(16) DEFAULT NULL,
  `GroupCode` varchar(32) NOT NULL,
  `OrgId` int(11) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `Title` varchar(256) DEFAULT NULL,
  `SubTitle` varchar(256) DEFAULT NULL,
  `Content` longtext,
  `Thumb` varchar(128) DEFAULT NULL,
  `Source` varchar(128) DEFAULT NULL,
  `Url` varchar(512) DEFAULT NULL,
  `Click` int(11) NOT NULL,
  `IsEnabled` int(11) NOT NULL,
  `Author` varchar(32) DEFAULT NULL,
  `Point` decimal(12,2) DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL,
  `CreateDate` datetime NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of cms_content_page
-- ----------------------------
INSERT INTO `cms_content_page` VALUES ('1', null, 'News', '2', '1', '2.x 版本已发布', null, '<p>+ 升级更好的 EF 支持</p><p>+ 修正 1.x 发现的所有BUG</p><p>+ 更强大的CMS系统，以及支持内容模板<br/></p><p><br/></p>', null, null, null, '0', '1', '管理员', null, '0', '2017-09-12 23:32:02');
INSERT INTO `cms_content_page` VALUES ('2', null, 'News', '2', '1', '前端登录测试用户：user，密码：user', null, null, null, null, null, '2', '1', '管理员', null, '0', '2017-09-12 23:34:35');
INSERT INTO `cms_content_page` VALUES ('3', null, 'Publish', null, '1', 'NPiculet B/S Framework 2.0.1 Release', null, '介绍及源代码请查阅 GitHub', null, null, null, '0', '1', '管理员', null, '0', '2017-10-19 10:38:59');

-- ----------------------------
-- Table structure for cms_content_tmpl
-- ----------------------------
DROP TABLE IF EXISTS `cms_content_tmpl`;
CREATE TABLE `cms_content_tmpl` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(64) DEFAULT NULL,
  `Template` longtext,
  `Sort` int(11) DEFAULT NULL,
  `IsEnabled` int(11) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of cms_content_tmpl
-- ----------------------------
INSERT INTO `cms_content_tmpl` VALUES ('1', '演示模板', '<p>{{DocCode}}<br/></p><hr/><p>{{Content}}</p>', '0', '1', '2017-10-12 10:59:07', '管理员');

-- ----------------------------
-- Table structure for cms_content_tmpl_field
-- ----------------------------
DROP TABLE IF EXISTS `cms_content_tmpl_field`;
CREATE TABLE `cms_content_tmpl_field` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TemplateId` int(11) DEFAULT NULL,
  `Name` varchar(64) DEFAULT NULL,
  `Code` varchar(64) DEFAULT NULL,
  `Type` varchar(16) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of cms_content_tmpl_field
-- ----------------------------
INSERT INTO `cms_content_tmpl_field` VALUES ('1', '1', '档案号', 'DocCode', '', '2017-10-12 11:03:36', '管理员');

-- ----------------------------
-- Table structure for cms_content_tmpl_value
-- ----------------------------
DROP TABLE IF EXISTS `cms_content_tmpl_value`;
CREATE TABLE `cms_content_tmpl_value` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TemplateId` int(11) DEFAULT NULL,
  `FieldId` int(11) DEFAULT NULL,
  `DataId` int(11) DEFAULT NULL,
  `Type` varchar(16) DEFAULT NULL,
  `Value` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of cms_content_tmpl_value
-- ----------------------------

-- ----------------------------
-- Table structure for cms_friendlinks_info
-- ----------------------------
DROP TABLE IF EXISTS `cms_friendlinks_info`;
CREATE TABLE `cms_friendlinks_info` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Type` varchar(16) DEFAULT NULL,
  `Description` longtext,
  `Image` varchar(255) DEFAULT NULL,
  `Url` text,
  `Click` int(11) NOT NULL,
  `IsEnabled` int(11) NOT NULL,
  `Sort` int(11) DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL,
  `CreateDate` datetime NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of cms_friendlinks_info
-- ----------------------------
INSERT INTO `cms_friendlinks_info` VALUES ('8', 'BusinessLink', '外部地址1', null, 'http://pcx.cn', '0', '1', '0', '管理员', '2016-03-30 01:06:52');
INSERT INTO `cms_friendlinks_info` VALUES ('9', 'BusinessLink', '外部地址2', null, 'http://pcx.cn', '0', '1', '1', '管理员', '2016-03-30 01:07:34');
INSERT INTO `cms_friendlinks_info` VALUES ('10', 'BusinessLink', '外部地址3', null, 'http://pcx.cn', '0', '1', '2', '管理员', '2016-03-30 01:08:42');
INSERT INTO `cms_friendlinks_info` VALUES ('11', 'BusinessLink', '外部地址4', '', 'http://pcx.cn', '0', '1', '3', '管理员', '2016-03-30 01:08:42');

-- ----------------------------
-- Table structure for cms_msgboard_group
-- ----------------------------
DROP TABLE IF EXISTS `cms_msgboard_group`;
CREATE TABLE `cms_msgboard_group` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(64) DEFAULT NULL,
  `Code` varchar(64) DEFAULT NULL,
  `Type` varchar(16) DEFAULT NULL,
  `Config` text,
  `CreateDate` datetime DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of cms_msgboard_group
-- ----------------------------
INSERT INTO `cms_msgboard_group` VALUES ('1', '主任信箱', 'zrxx', null, '[{\"Name\":\"测试111\",\"Code\":\"111\",\"Type\":\"radio\",\"Show\":false},{\"Name\":\"测试222\",\"Code\":\"222\",\"Type\":\"dict\",\"Show\":true}]', '2017-10-31 14:58:09', '管理员');
INSERT INTO `cms_msgboard_group` VALUES ('2', '建言献策', 'jyxc', null, '', '2017-11-20 22:16:36', '管理员');
INSERT INTO `cms_msgboard_group` VALUES ('3', '网上信访', 'wsxf', null, '', '2017-11-20 22:16:54', '管理员');

-- ----------------------------
-- Table structure for cms_msgboard_record
-- ----------------------------
DROP TABLE IF EXISTS `cms_msgboard_record`;
CREATE TABLE `cms_msgboard_record` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ReplyId` int(11) DEFAULT NULL,
  `GroupCode` varchar(32) DEFAULT NULL,
  `Author` varchar(32) DEFAULT NULL,
  `IdCard` varchar(32) DEFAULT NULL,
  `Tel` varchar(32) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Ownership` varchar(255) DEFAULT NULL,
  `MsgTitle` varchar(255) DEFAULT NULL,
  `MsgContent` text,
  `IsAnonymous` int(11) DEFAULT NULL,
  `IsPublic` int(11) DEFAULT NULL,
  `Fields` text,
  `Status` int(11) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of cms_msgboard_record
-- ----------------------------

-- ----------------------------
-- Table structure for cms_points_log
-- ----------------------------
DROP TABLE IF EXISTS `cms_points_log`;
CREATE TABLE `cms_points_log` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `ActionType` varchar(32) NOT NULL COMMENT '动作类型',
  `ActionUserId` int(11) DEFAULT NULL COMMENT '动作账号',
  `ActionOrgId` int(11) DEFAULT NULL,
  `TargetCode` varchar(128) DEFAULT NULL COMMENT '目标编码',
  `TargetId` varchar(64) DEFAULT NULL COMMENT '目标ID',
  `IP` varchar(64) DEFAULT NULL,
  `Tag` varchar(128) DEFAULT NULL COMMENT '标签：说明状态的短语',
  `Point` decimal(12,2) DEFAULT NULL,
  `Comment` longtext COMMENT '注释',
  `CreateDate` datetime DEFAULT NULL COMMENT '操作时间',
  `Creator` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='操作日志表';

-- ----------------------------
-- Records of cms_points_log
-- ----------------------------

-- ----------------------------
-- Table structure for hrs_calendar_info
-- ----------------------------
DROP TABLE IF EXISTS `hrs_calendar_info`;
CREATE TABLE `hrs_calendar_info` (
  `Id` int(11) NOT NULL,
  `Year` int(11) DEFAULT NULL,
  `Month` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of hrs_calendar_info
-- ----------------------------

-- ----------------------------
-- Table structure for hrs_calendar_log
-- ----------------------------
DROP TABLE IF EXISTS `hrs_calendar_log`;
CREATE TABLE `hrs_calendar_log` (
  `Id` int(11) NOT NULL,
  `UserId` int(11) DEFAULT NULL,
  `Year` int(11) DEFAULT NULL,
  `Month` int(11) DEFAULT NULL,
  `Day` int(11) DEFAULT NULL,
  `Reason` text,
  `Date` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of hrs_calendar_log
-- ----------------------------

-- ----------------------------
-- Table structure for hrs_kpi_info
-- ----------------------------
DROP TABLE IF EXISTS `hrs_kpi_info`;
CREATE TABLE `hrs_kpi_info` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Type` varchar(16) DEFAULT NULL,
  `ParentId` int(11) DEFAULT NULL,
  `Layer` int(11) DEFAULT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `Description` text,
  `Score` decimal(12,2) DEFAULT NULL,
  `Status` tinyint(1) DEFAULT NULL,
  `IsDel` tinyint(1) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of hrs_kpi_info
-- ----------------------------
INSERT INTO `hrs_kpi_info` VALUES ('1', 'Score', '0', '0', '考勤：全勤', null, '80.00', '1', '0', '2017-06-01 00:00:00', null);
INSERT INTO `hrs_kpi_info` VALUES ('2', 'Score', '0', '0', '加班：一天', null, '125.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('3', 'Score', null, null, '加班：不足半天', null, '45.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('4', 'Score', null, null, '加班：半天', null, '60.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('5', 'Score', null, null, '加班：通宵加班', null, '125.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('6', 'Score', null, null, '制度：提出合理建议', null, '5.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('7', 'Score', null, null, '团队：带领新人', null, '20.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('8', 'Score', null, null, '团队：积极参加活动', null, '5.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('9', 'Score', null, null, '团队：推荐人才', null, '200.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('10', 'Score', null, null, '团队：协作奖励', null, '20.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('11', 'Score', null, null, '团队：突出贡献', null, '0.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('12', 'Score', null, null, '分享：晨会', null, '5.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('13', 'Score', null, null, '分享：培训', null, '15.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('14', 'Score', null, null, '考勤：迟到', null, '-5.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('15', 'Score', null, null, '考勤：旷工', null, '-200.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('16', 'Score', null, null, '考情：临时请假', null, '-5.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('17', 'Score', null, null, '会议：迟到', null, '-5.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('18', 'Score', null, null, '计划：迟交', null, '-5.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('19', 'Score', null, null, '活动：迟到', null, '-2.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('20', 'Score', null, null, '行为：公众场合抽烟', null, '-20.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('21', 'Score', null, null, '请假：月请假3次及以上', null, '-10.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('23', 'KPI', null, null, '项目：计划执行提前20%', null, '10.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('24', 'KPI', null, null, '项目：计划执行提前40%', null, '20.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('25', 'KPI', null, null, '加班：一天', null, '2.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('26', 'KPI', null, null, '加班：半天', null, '1.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('27', 'KPI', null, null, '加班：通宵加班', null, '3.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('28', 'KPI', null, null, '项目：绩效奖金', null, '0.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('29', 'KPI', null, null, '迟交周计划', null, '-1.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('30', 'KPI', null, null, '计划执行延迟20%', null, '-15.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('31', 'KPI', null, null, '计划执行延迟40%', null, '-30.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('32', 'KPI', null, null, '工单：不完备导致谈判被动', null, '-3.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('33', 'KPI', null, null, '工作：代码未提交引起丢失', null, '-10.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('34', 'KPI', null, null, '项目：输出文档未提交', null, '-10.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('35', 'KPI', null, null, '项目：补充缺失文档', null, '-1.00', '1', '0', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_info` VALUES ('36', 'Score', '0', '0', '额外积分', '', null, '0', '0', null, null);
INSERT INTO `hrs_kpi_info` VALUES ('37', 'KPI', '0', '0', '额外绩效', '', null, '0', '0', null, null);
INSERT INTO `hrs_kpi_info` VALUES ('38', 'Score', '0', '0', '兑换积分', '', null, '0', '0', null, null);

-- ----------------------------
-- Table structure for hrs_kpi_log
-- ----------------------------
DROP TABLE IF EXISTS `hrs_kpi_log`;
CREATE TABLE `hrs_kpi_log` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `KpiId` int(11) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `Score` decimal(12,2) DEFAULT NULL,
  `Description` text,
  `ScoreDate` datetime DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=65 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of hrs_kpi_log
-- ----------------------------
INSERT INTO `hrs_kpi_log` VALUES ('2', '1', '2', '80.00', '', '2017-06-01 00:00:00', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('3', '4', '4', '60.00', '', '2017-06-01 00:00:00', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('4', '14', '5', '-5.00', '', '2017-06-01 00:00:00', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('5', '14', '5', '-5.00', '', '2017-06-01 00:00:00', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('6', '4', '3', '60.00', '', '2017-06-01 00:00:00', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('7', '4', '7', '60.00', '', '2017-06-01 00:00:00', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('8', '4', '9', '60.00', '', '2017-06-01 00:00:00', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('9', '4', '8', '60.00', '', '2017-06-01 00:00:00', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('10', '4', '6', '60.00', '', '2017-06-01 00:00:00', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('11', '1', '7', '80.00', '', '2017-06-01 00:00:00', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('12', '1', '9', '80.00', '', '2017-06-01 00:00:00', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('13', '1', '8', '80.00', '', '2017-06-01 00:00:00', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('14', '1', '10', '80.00', '', '2017-06-01 00:00:00', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('17', '4', '5', '60.00', '', '2017-06-01 00:00:00', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('18', '26', '3', '1.00', '', '2017-06-01 00:00:00', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('19', '26', '4', '1.00', '', '2017-06-01 00:00:00', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('20', '26', '5', '1.00', '', '2017-06-01 00:00:00', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('21', '26', '6', '1.00', '', '2017-06-01 00:00:00', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('22', '26', '7', '1.00', '', '2017-06-01 00:00:00', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('23', '26', '8', '1.00', '', '2017-06-01 00:00:00', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('24', '26', '9', '1.00', '', '2017-06-01 00:00:00', '2017-06-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('25', '14', '2', '-10.00', '2次', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('26', '14', '5', '-5.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('27', '2', '4', '125.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('28', '2', '4', '125.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('29', '2', '4', '125.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('30', '2', '5', '125.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('31', '2', '5', '125.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('32', '2', '5', '125.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('33', '2', '6', '125.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('34', '2', '6', '125.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('35', '2', '6', '125.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('36', '2', '7', '125.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('37', '2', '7', '125.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('38', '2', '7', '125.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('39', '2', '10', '125.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('40', '2', '10', '125.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('41', '2', '10', '125.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('42', '1', '8', '80.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('43', '1', '9', '80.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('44', '1', '4', '80.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('45', '1', '7', '80.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('46', '1', '10', '80.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('47', '1', '6', '80.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('48', '36', '2', '280.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('49', '36', '3', '185.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('50', '36', '4', '115.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('51', '36', '5', '55.00', '', '2017-07-01 00:00:00', '2017-07-01 00:00:00', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('52', '36', '7', '135.00', '', '2017-07-01 00:00:00', '2017-09-06 09:52:30', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('53', '36', '9', '125.00', '', '2017-07-01 00:00:00', '2017-09-06 09:53:37', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('54', '36', '8', '55.00', '', '2017-07-01 00:00:00', '2017-09-06 10:00:36', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('55', '14', '2', '-25.00', '迟到5次', '2017-08-01 00:00:00', '2017-09-15 08:22:38', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('56', '14', '3', '-5.00', '', '2017-08-01 00:00:00', '2017-09-15 08:23:03', '管理员');
INSERT INTO `hrs_kpi_log` VALUES ('57', '14', '6', '-5.00', '', '2017-08-01 00:00:00', '2017-09-15 08:25:35', null);
INSERT INTO `hrs_kpi_log` VALUES ('58', '1', '9', '80.00', '', '2017-08-01 00:00:00', '2017-09-15 08:26:05', null);
INSERT INTO `hrs_kpi_log` VALUES ('59', '1', '7', '80.00', '', '2017-08-01 00:00:00', '2017-09-15 08:26:10', null);
INSERT INTO `hrs_kpi_log` VALUES ('60', '1', '10', '80.00', '', '2017-08-01 00:00:00', '2017-09-15 08:26:16', null);
INSERT INTO `hrs_kpi_log` VALUES ('61', '1', '8', '80.00', '', '2017-08-01 00:00:00', '2017-09-15 08:26:26', null);
INSERT INTO `hrs_kpi_log` VALUES ('62', '1', '4', '80.00', '', '2017-08-01 00:00:00', '2017-09-15 08:27:54', null);
INSERT INTO `hrs_kpi_log` VALUES ('63', '1', '5', '80.00', '', '2017-08-01 00:00:00', '2017-09-15 08:27:59', null);
INSERT INTO `hrs_kpi_log` VALUES ('64', '38', '10', '-250.00', '兑换半天休假', '2017-08-01 00:00:00', '2017-09-15 09:45:38', null);

-- ----------------------------
-- Table structure for hrs_kpi_total
-- ----------------------------
DROP TABLE IF EXISTS `hrs_kpi_total`;
CREATE TABLE `hrs_kpi_total` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `KpiId` int(11) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `TotalScore` decimal(12,2) DEFAULT NULL,
  `CurrentScore` decimal(12,2) DEFAULT NULL,
  `UpdateDate` datetime DEFAULT NULL,
  `Updater` varchar(32) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of hrs_kpi_total
-- ----------------------------

-- ----------------------------
-- Table structure for hrs_wages_info
-- ----------------------------
DROP TABLE IF EXISTS `hrs_wages_info`;
CREATE TABLE `hrs_wages_info` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) DEFAULT NULL,
  `Year` int(11) DEFAULT NULL,
  `Month` int(11) DEFAULT NULL,
  `BaseWages` decimal(12,2) DEFAULT NULL,
  `KpiRate` decimal(3,1) DEFAULT NULL,
  `WorkDays` int(11) DEFAULT NULL,
  `RealDays` int(11) DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of hrs_wages_info
-- ----------------------------

-- ----------------------------
-- Table structure for hrs_wages_log
-- ----------------------------
DROP TABLE IF EXISTS `hrs_wages_log`;
CREATE TABLE `hrs_wages_log` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) DEFAULT NULL,
  `Year` int(11) DEFAULT NULL,
  `Month` int(11) DEFAULT NULL,
  `Content` text,
  `Creator` varchar(32) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of hrs_wages_log
-- ----------------------------

-- ----------------------------
-- Table structure for pms_project_info
-- ----------------------------
DROP TABLE IF EXISTS `pms_project_info`;
CREATE TABLE `pms_project_info` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(128) DEFAULT NULL,
  `Code` varchar(32) DEFAULT NULL,
  `Description` text,
  `Url` varchar(255) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of pms_project_info
-- ----------------------------
INSERT INTO `pms_project_info` VALUES ('1', '红河乡镇业务运营系统', 'HXY', null, null, null, null);
INSERT INTO `pms_project_info` VALUES ('2', '党政建设学习平台', 'PBL', '', '', null, null);

-- ----------------------------
-- Table structure for pms_publish_info
-- ----------------------------
DROP TABLE IF EXISTS `pms_publish_info`;
CREATE TABLE `pms_publish_info` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ProjectId` int(11) DEFAULT NULL,
  `Name` varchar(32) DEFAULT NULL,
  `Description` longtext,
  `Version` varchar(16) DEFAULT NULL,
  `Svn` varchar(16) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of pms_publish_info
-- ----------------------------

-- ----------------------------
-- Table structure for pms_publish_log
-- ----------------------------
DROP TABLE IF EXISTS `pms_publish_log`;
CREATE TABLE `pms_publish_log` (
  `Id` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of pms_publish_log
-- ----------------------------

-- ----------------------------
-- Table structure for pms_resource_info
-- ----------------------------
DROP TABLE IF EXISTS `pms_resource_info`;
CREATE TABLE `pms_resource_info` (
  `Id` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of pms_resource_info
-- ----------------------------

-- ----------------------------
-- Table structure for pms_resource_log
-- ----------------------------
DROP TABLE IF EXISTS `pms_resource_log`;
CREATE TABLE `pms_resource_log` (
  `Id` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of pms_resource_log
-- ----------------------------

-- ----------------------------
-- Table structure for pms_task_info
-- ----------------------------
DROP TABLE IF EXISTS `pms_task_info`;
CREATE TABLE `pms_task_info` (
  `Id` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of pms_task_info
-- ----------------------------

-- ----------------------------
-- Table structure for pms_task_log
-- ----------------------------
DROP TABLE IF EXISTS `pms_task_log`;
CREATE TABLE `pms_task_log` (
  `Id` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of pms_task_log
-- ----------------------------

-- ----------------------------
-- Table structure for shop_address
-- ----------------------------
DROP TABLE IF EXISTS `shop_address`;
CREATE TABLE `shop_address` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserAccount` varchar(32) DEFAULT NULL COMMENT '所属用户',
  `OrderCode` varchar(32) DEFAULT NULL,
  `Type` varchar(16) DEFAULT NULL,
  `Name` varchar(64) DEFAULT NULL COMMENT '联系人',
  `Tel` varchar(32) DEFAULT NULL COMMENT '联系电话',
  `Mobile` varchar(32) DEFAULT NULL,
  `Sex` varchar(8) DEFAULT NULL,
  `IdCardType` varchar(16) DEFAULT NULL,
  `IdCard` varchar(32) DEFAULT NULL,
  `Post` varchar(32) DEFAULT NULL,
  `Province` varchar(100) DEFAULT NULL COMMENT '省会',
  `Town` varchar(100) DEFAULT NULL COMMENT '市区',
  `Region` varchar(100) DEFAULT NULL COMMENT '地区',
  `Street` varchar(32) DEFAULT NULL COMMENT '街道',
  `Address` varchar(255) DEFAULT NULL COMMENT '地址',
  `Longitude` decimal(16,8) DEFAULT NULL COMMENT '经度',
  `Latitude` decimal(16,8) DEFAULT NULL,
  `IsDefault` int(11) DEFAULT NULL,
  `IsDel` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of shop_address
-- ----------------------------

-- ----------------------------
-- Table structure for shop_brand
-- ----------------------------
DROP TABLE IF EXISTS `shop_brand`;
CREATE TABLE `shop_brand` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(64) DEFAULT NULL,
  `Description` text,
  `IsEnabled` int(11) DEFAULT NULL,
  `IsDel` int(11) DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of shop_brand
-- ----------------------------

-- ----------------------------
-- Table structure for shop_cart
-- ----------------------------
DROP TABLE IF EXISTS `shop_cart`;
CREATE TABLE `shop_cart` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) DEFAULT NULL,
  `ParentId` int(11) DEFAULT NULL,
  `CommodityId` int(11) DEFAULT NULL,
  `Type` varchar(8) DEFAULT NULL,
  `Amount` int(11) DEFAULT NULL,
  `MemberLevel` varchar(16) DEFAULT NULL,
  `Price` double DEFAULT NULL,
  `TotalPrice` double DEFAULT NULL,
  `PersonNumber` int(11) DEFAULT NULL COMMENT '人数',
  `ChildrenNumber` int(11) DEFAULT NULL COMMENT '儿童',
  `ArrivalDate` datetime DEFAULT NULL,
  `LeaveDate` datetime DEFAULT NULL,
  `OccupancyDay` int(11) DEFAULT NULL,
  `IsPackages` int(11) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `TakeOffTime` varchar(255) DEFAULT NULL COMMENT '起飞时间（字符型）',
  `LandingTime` varchar(255) DEFAULT NULL COMMENT '到达时间（字符型）',
  `FlightTime` varchar(255) DEFAULT NULL COMMENT '飞行时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='商品购物车';

-- ----------------------------
-- Records of shop_cart
-- ----------------------------

-- ----------------------------
-- Table structure for shop_category
-- ----------------------------
DROP TABLE IF EXISTS `shop_category`;
CREATE TABLE `shop_category` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `AppCode` varchar(32) DEFAULT NULL COMMENT 'App代码',
  `Type` varchar(16) DEFAULT NULL,
  `ParentId` int(11) DEFAULT NULL COMMENT '父序号',
  `RootId` int(11) DEFAULT NULL COMMENT '根序号',
  `Path` text COMMENT '路径',
  `Name` varchar(64) DEFAULT NULL COMMENT '名称',
  `Code` varchar(32) DEFAULT NULL COMMENT '编码',
  `Icon` text COMMENT '图标',
  `Depth` int(11) DEFAULT NULL COMMENT '深度',
  `Comment` text COMMENT '备注',
  `OrderBy` int(11) DEFAULT NULL COMMENT '排序',
  `IsEnabled` int(11) DEFAULT NULL COMMENT '是否启用',
  `IsDel` int(11) DEFAULT NULL COMMENT '是否已删除',
  `Creator` varchar(32) DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`),
  KEY `IDX_ID` (`Id`),
  KEY `idx_Code` (`Code`),
  KEY `idx_ParentId` (`ParentId`,`RootId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COMMENT='ShopCategory 商品分类';

-- ----------------------------
-- Records of shop_category
-- ----------------------------
INSERT INTO `shop_category` VALUES ('2', '', '旅游', '0', '1', '', '旅游', '40', '', '0', '该类主要存放所有旅游度假商品', '2', '1', '0', 'admin', '2015-07-29 15:09:25');
INSERT INTO `shop_category` VALUES ('3', '', '礼品', '0', '1', '', '特色商城', '999', '', '0', '', '4', '1', '0', 'admin', '2015-04-28 00:10:09');
INSERT INTO `shop_category` VALUES ('4', '', '酒店', '0', '1', '', '酒店', '20', '', '0', '该类主要存放所有宾馆酒店信息', '3', '1', '0', 'admin', '2015-04-26 22:43:12');
INSERT INTO `shop_category` VALUES ('5', '', '机票', '0', '1', '', '机票', '30', '', '0', '', '5', '0', '0', 'admin', '2015-04-29 20:23:50');

-- ----------------------------
-- Table structure for shop_comment
-- ----------------------------
DROP TABLE IF EXISTS `shop_comment`;
CREATE TABLE `shop_comment` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CommodityId` int(11) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `UserName` varchar(32) DEFAULT NULL,
  `Comment` text,
  `Rank` int(11) DEFAULT NULL,
  `IsShow` int(11) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='商品评论';

-- ----------------------------
-- Records of shop_comment
-- ----------------------------

-- ----------------------------
-- Table structure for shop_commodity
-- ----------------------------
DROP TABLE IF EXISTS `shop_commodity`;
CREATE TABLE `shop_commodity` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CategoryId` int(11) DEFAULT NULL COMMENT '分类ID',
  `CategoryType` varchar(16) DEFAULT NULL,
  `SupplierId` int(11) DEFAULT NULL COMMENT '供应商',
  `RootCategoryId` int(11) DEFAULT NULL,
  `BrandId` int(11) DEFAULT NULL COMMENT '品牌ID',
  `Code` varchar(64) DEFAULT NULL,
  `Name` varchar(128) DEFAULT NULL COMMENT '名称',
  `Pinyin` varchar(128) DEFAULT NULL,
  `Keywords` varchar(255) DEFAULT NULL COMMENT '关键字',
  `Description` text COMMENT '介绍',
  `Thumb` varchar(255) DEFAULT NULL COMMENT '小图片',
  `PlaceStartCode` varchar(8) DEFAULT NULL,
  `PlaceStartName` varchar(64) DEFAULT NULL,
  `PlaceEndCode` varchar(8) DEFAULT NULL,
  `PlaceEndName` varchar(64) DEFAULT NULL,
  `Image` varchar(255) DEFAULT NULL COMMENT '主图片',
  `Stock` int(11) DEFAULT NULL COMMENT '库存数量',
  `Model` varchar(32) DEFAULT NULL,
  `Unit` varchar(32) DEFAULT NULL COMMENT '计量单位',
  `Address` varchar(255) DEFAULT NULL,
  `Characteristic` varchar(255) DEFAULT NULL COMMENT '特色',
  `Size` varchar(32) DEFAULT NULL,
  `OriginalPrice` double DEFAULT NULL COMMENT '原价',
  `CurrentPrice` double DEFAULT NULL COMMENT '现价',
  `IsBundling` int(11) DEFAULT NULL,
  `BundlingPrice` double DEFAULT NULL,
  `Point` double DEFAULT NULL COMMENT '积分',
  `SalePoint` double DEFAULT NULL,
  `SalesVolume` int(11) DEFAULT NULL COMMENT '已售数量',
  `TotalFavorite` int(11) DEFAULT NULL,
  `TotalComment` int(11) DEFAULT NULL,
  `TotalClick` int(11) DEFAULT NULL,
  `IsPackages` int(11) DEFAULT NULL,
  `IsLimitTime` int(11) DEFAULT NULL COMMENT '是否限时',
  `IsPriceOff` int(11) DEFAULT NULL COMMENT '是否优惠',
  `IsPoint` int(11) DEFAULT NULL COMMENT '是否积分商品',
  `IsRefund` int(11) DEFAULT NULL COMMENT '是否退改',
  `RefundMemo` text,
  `IsEnabled` int(11) DEFAULT NULL,
  `IsDel` int(11) DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL,
  `LeaveDate` datetime DEFAULT NULL COMMENT '离开时间',
  `ArrivalDate` datetime DEFAULT NULL COMMENT '到达日期',
  `Reserve` text,
  `Way` text,
  `Scenery` text,
  `Hint` text,
  `RefundRule` text COMMENT '退改规则',
  `RefundFormula` text COMMENT '退改公式',
  `FuelPrice` double DEFAULT NULL,
  `AirportPrice` double DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `OrderBy` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `idx_Code` (`Code`),
  KEY `idx_CategoryId` (`CategoryId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of shop_commodity
-- ----------------------------

-- ----------------------------
-- Table structure for shop_commodity_detail
-- ----------------------------
DROP TABLE IF EXISTS `shop_commodity_detail`;
CREATE TABLE `shop_commodity_detail` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键id',
  `FlightNo` varchar(255) DEFAULT NULL COMMENT '航班号',
  `CommodityId` int(11) DEFAULT NULL COMMENT '商品编号',
  `Price` double DEFAULT NULL COMMENT '购买价格',
  `DateBegin` datetime DEFAULT NULL COMMENT '开始日期',
  `DateEnd` datetime DEFAULT NULL COMMENT '结束日期',
  `DepartureTime` datetime DEFAULT NULL COMMENT '起飞时间',
  `DeparturePlace` varchar(255) DEFAULT NULL COMMENT '起飞地',
  `ArrivalTime` datetime DEFAULT NULL COMMENT '抵达时间',
  `ArrivalPlace` varchar(255) DEFAULT NULL COMMENT '目的地',
  `TakeOffTime` varchar(255) DEFAULT NULL COMMENT '起飞时间（字符型）',
  `LandingTime` varchar(255) DEFAULT NULL COMMENT '到达时间（字符型）',
  `FlightTime` varchar(255) DEFAULT NULL COMMENT '飞行时间',
  `Cabin` varchar(255) DEFAULT NULL COMMENT '舱位',
  `Memo` varchar(255) DEFAULT NULL COMMENT '备注',
  `IsEnabled` int(11) NOT NULL DEFAULT '1' COMMENT '是否启用',
  `IsDel` int(11) DEFAULT '0' COMMENT '是否删除',
  `CreateDate` datetime DEFAULT NULL COMMENT '创建时间',
  `Creator` varchar(32) DEFAULT NULL COMMENT '创建人',
  `OrderBy` int(11) DEFAULT NULL COMMENT '排序',
  `VipPrice` double DEFAULT NULL,
  `ClubPrice` double DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='航班时间价格表';

-- ----------------------------
-- Records of shop_commodity_detail
-- ----------------------------

-- ----------------------------
-- Table structure for shop_commodity_price
-- ----------------------------
DROP TABLE IF EXISTS `shop_commodity_price`;
CREATE TABLE `shop_commodity_price` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CommodityId` int(11) DEFAULT NULL,
  `Code` varchar(200) DEFAULT NULL COMMENT '三位码',
  `Price` double DEFAULT NULL COMMENT '购买价格',
  `DateBegin` datetime DEFAULT NULL,
  `DateEnd` datetime DEFAULT NULL,
  `Status` varchar(16) DEFAULT NULL COMMENT '状态：启用、过期',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='商品活动价';

-- ----------------------------
-- Records of shop_commodity_price
-- ----------------------------

-- ----------------------------
-- Table structure for shop_consultation
-- ----------------------------
DROP TABLE IF EXISTS `shop_consultation`;
CREATE TABLE `shop_consultation` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CommodityId` int(11) DEFAULT NULL,
  `Consultation` text,
  `Reply` text,
  `ContactWay` varchar(64) DEFAULT NULL,
  `IsShow` int(11) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='商品咨询';

-- ----------------------------
-- Records of shop_consultation
-- ----------------------------

-- ----------------------------
-- Table structure for shop_favorite
-- ----------------------------
DROP TABLE IF EXISTS `shop_favorite`;
CREATE TABLE `shop_favorite` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) DEFAULT NULL,
  `CommodityId` int(11) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='商品收藏';

-- ----------------------------
-- Records of shop_favorite
-- ----------------------------

-- ----------------------------
-- Table structure for shop_logs
-- ----------------------------
DROP TABLE IF EXISTS `shop_logs`;
CREATE TABLE `shop_logs` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Type` varchar(16) DEFAULT NULL,
  `Level` int(11) DEFAULT NULL,
  `Message` text,
  `Value` double DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of shop_logs
-- ----------------------------

-- ----------------------------
-- Table structure for shop_order
-- ----------------------------
DROP TABLE IF EXISTS `shop_order`;
CREATE TABLE `shop_order` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) DEFAULT NULL,
  `SupplierId` int(11) DEFAULT NULL COMMENT '供应商ID',
  `OrderType` varchar(16) DEFAULT NULL COMMENT '类型：网店、实体店',
  `OrderCode` varchar(64) DEFAULT NULL COMMENT '订单编号',
  `CommodityId` int(11) DEFAULT NULL COMMENT '主产品ID',
  `PayCode` varchar(128) DEFAULT NULL COMMENT '支付编号',
  `PostCode` varchar(128) DEFAULT NULL COMMENT '邮政单号',
  `TotalPrice` decimal(16,2) DEFAULT NULL COMMENT '订单总价',
  `RefundMoney` decimal(16,2) DEFAULT NULL,
  `PersonNumber` int(11) DEFAULT NULL COMMENT '人数',
  `ChildrenNumber` int(11) DEFAULT NULL COMMENT '儿童',
  `CreateDate` datetime DEFAULT NULL,
  `SuccessDate` datetime DEFAULT NULL,
  `PayDate` datetime DEFAULT NULL,
  `SendDate` datetime DEFAULT NULL COMMENT '寄送时间',
  `Address` varchar(255) DEFAULT NULL COMMENT '收货地址ID',
  `Longitude` decimal(16,8) DEFAULT NULL,
  `Latitude` decimal(16,8) DEFAULT NULL,
  `Post` varchar(32) DEFAULT NULL,
  `Region` varchar(32) DEFAULT NULL,
  `Receiver` varchar(32) DEFAULT NULL COMMENT '收货人',
  `Tel` varchar(32) DEFAULT NULL COMMENT '收货人电话',
  `Memo` text,
  `Status` varchar(16) DEFAULT NULL COMMENT '状态：0等待处理；1已审核；2已支付；3已完成；4已关闭',
  `RefundRule` text COMMENT '退改规则',
  `RefundFormula` text COMMENT '退改公式',
  `FuelPrice` double DEFAULT NULL,
  `AirportPrice` double DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='商品订单';

-- ----------------------------
-- Records of shop_order
-- ----------------------------

-- ----------------------------
-- Table structure for shop_order_flow
-- ----------------------------
DROP TABLE IF EXISTS `shop_order_flow`;
CREATE TABLE `shop_order_flow` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) DEFAULT NULL,
  `SupplierId` int(11) DEFAULT NULL COMMENT '供应商ID',
  `SourceOrderCode` varchar(64) DEFAULT NULL,
  `OrderType` varchar(16) DEFAULT NULL,
  `OrderCode` varchar(64) DEFAULT NULL COMMENT '订单编号',
  `PayCode` varchar(128) DEFAULT NULL COMMENT '支付编号',
  `PostCode` varchar(128) DEFAULT NULL COMMENT '邮政单号',
  `TotalPrice` decimal(16,2) DEFAULT NULL COMMENT '订单总价',
  `CreateDate` datetime DEFAULT NULL,
  `SuccessDate` datetime DEFAULT NULL,
  `PayDate` datetime DEFAULT NULL,
  `SendDate` datetime DEFAULT NULL COMMENT '寄送时间',
  `Address` varchar(255) DEFAULT NULL COMMENT '收货地址ID',
  `Longitude` decimal(16,8) DEFAULT NULL,
  `Latitude` decimal(16,8) DEFAULT NULL,
  `Post` varchar(32) DEFAULT NULL,
  `Region` varchar(32) DEFAULT NULL,
  `Receiver` varchar(32) DEFAULT NULL COMMENT '收货人',
  `Tel` varchar(32) DEFAULT NULL COMMENT '收货人电话',
  `Memo` text,
  `Status` varchar(16) DEFAULT NULL COMMENT '状态：等待处理；已支付；已发货；已成交；已关闭',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='处理流程中的额外订单，如：退款';

-- ----------------------------
-- Records of shop_order_flow
-- ----------------------------

-- ----------------------------
-- Table structure for shop_order_item
-- ----------------------------
DROP TABLE IF EXISTS `shop_order_item`;
CREATE TABLE `shop_order_item` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `OrderCode` varchar(64) DEFAULT NULL,
  `CommodityId` int(11) DEFAULT NULL,
  `Type` varchar(8) DEFAULT NULL,
  `Amount` int(11) DEFAULT NULL COMMENT '备注',
  `Model` varchar(128) DEFAULT NULL COMMENT '型号',
  `Price` double DEFAULT NULL COMMENT '购买价格',
  `TotalPrice` double DEFAULT NULL,
  `Memo` text COMMENT '备注',
  `ArrivalDate` datetime DEFAULT NULL COMMENT '到达日期',
  `LeaveDate` datetime DEFAULT NULL COMMENT '离开日期',
  `OccupancyDay` int(11) DEFAULT NULL COMMENT '入住天数',
  `TakeOffTime` varchar(255) DEFAULT NULL COMMENT '起飞时间（字符型）',
  `LandingTime` varchar(255) DEFAULT NULL COMMENT '到达时间（字符型）',
  `FlightTime` varchar(255) DEFAULT NULL COMMENT '飞行时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='商品订单项';

-- ----------------------------
-- Records of shop_order_item
-- ----------------------------

-- ----------------------------
-- Table structure for shop_packages
-- ----------------------------
DROP TABLE IF EXISTS `shop_packages`;
CREATE TABLE `shop_packages` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ParentId` int(11) DEFAULT NULL,
  `CommodityType` varchar(16) DEFAULT NULL,
  `CommodityId` int(11) DEFAULT NULL,
  `CommodityName` varchar(128) DEFAULT NULL,
  `Amount` int(11) DEFAULT NULL,
  `Price` double DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of shop_packages
-- ----------------------------

-- ----------------------------
-- Table structure for shop_pay_item
-- ----------------------------
DROP TABLE IF EXISTS `shop_pay_item`;
CREATE TABLE `shop_pay_item` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `BranchCode` varchar(32) DEFAULT NULL,
  `PayCode` varchar(32) DEFAULT NULL,
  `CommodityId` int(11) DEFAULT NULL,
  `OriginalPrice` double DEFAULT NULL,
  `CurrentPrice` double DEFAULT NULL,
  `Amount` double DEFAULT NULL,
  `Money` double DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of shop_pay_item
-- ----------------------------

-- ----------------------------
-- Table structure for shop_pay_list
-- ----------------------------
DROP TABLE IF EXISTS `shop_pay_list`;
CREATE TABLE `shop_pay_list` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `BranchCode` varchar(32) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `MemberCard` varchar(32) DEFAULT NULL,
  `PayCode` varchar(32) DEFAULT NULL,
  `Cost` decimal(16,4) DEFAULT NULL,
  `Point` decimal(16,4) DEFAULT NULL,
  `PayDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `idx_PayCode` (`PayCode`),
  KEY `idx_MemberCard` (`MemberCard`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of shop_pay_list
-- ----------------------------

-- ----------------------------
-- Table structure for shop_sale
-- ----------------------------
DROP TABLE IF EXISTS `shop_sale`;
CREATE TABLE `shop_sale` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CommodityId` int(11) DEFAULT NULL,
  `Price` double DEFAULT NULL COMMENT '促销价',
  `BeginDate` datetime DEFAULT NULL,
  `EndDate` datetime DEFAULT NULL,
  `IsEnabled` int(11) DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='商品促销';

-- ----------------------------
-- Records of shop_sale
-- ----------------------------

-- ----------------------------
-- Table structure for shop_service_order
-- ----------------------------
DROP TABLE IF EXISTS `shop_service_order`;
CREATE TABLE `shop_service_order` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserAccount` varchar(32) DEFAULT NULL,
  `OrderCode` varchar(64) DEFAULT NULL COMMENT '订单编号',
  `PayCode` varchar(128) DEFAULT NULL COMMENT '支付编号',
  `ServiceType` varchar(32) DEFAULT NULL COMMENT '服务类型',
  `Address` varchar(255) DEFAULT NULL COMMENT '服务地址',
  `Receiver` varchar(32) DEFAULT NULL COMMENT '服务对象',
  `Tel` varchar(32) DEFAULT NULL COMMENT '电话',
  `Memo` text COMMENT '备注',
  `Rank` int(11) DEFAULT NULL COMMENT '打分',
  `Comment` text,
  `Status` int(11) DEFAULT NULL COMMENT '状态：0:等待处理；1:正在服务；2:已成交；3:已关闭',
  `ReserveDate` datetime DEFAULT NULL COMMENT '预订时间',
  `SuccessDate` datetime DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='商品订单';

-- ----------------------------
-- Records of shop_service_order
-- ----------------------------

-- ----------------------------
-- Table structure for shop_supplier_info
-- ----------------------------
DROP TABLE IF EXISTS `shop_supplier_info`;
CREATE TABLE `shop_supplier_info` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CompanyName` varchar(128) DEFAULT NULL COMMENT '企业名称',
  `CompanyCode` varchar(64) DEFAULT NULL COMMENT '企业编号',
  `CompanyProperty` varchar(64) DEFAULT NULL COMMENT '企业性质',
  `Address` varchar(255) DEFAULT NULL COMMENT '地址',
  `Longitude` decimal(16,8) DEFAULT NULL COMMENT '经度',
  `Latitude` decimal(16,8) DEFAULT NULL COMMENT '纬度',
  `Post` varchar(32) DEFAULT NULL COMMENT '邮递区号',
  `Region` varchar(32) DEFAULT NULL,
  `Contact` varchar(32) DEFAULT NULL COMMENT '联系人',
  `Tel` varchar(32) DEFAULT NULL COMMENT '联系电话',
  `Memo` text COMMENT '备注',
  `Status` varchar(16) DEFAULT NULL COMMENT '状态',
  `CreateDate` datetime DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='供应商';

-- ----------------------------
-- Records of shop_supplier_info
-- ----------------------------

-- ----------------------------
-- Table structure for sys_action_detail
-- ----------------------------
DROP TABLE IF EXISTS `sys_action_detail`;
CREATE TABLE `sys_action_detail` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `ActionId` int(11) NOT NULL COMMENT '动作ID',
  `FieldCode` varchar(128) DEFAULT NULL COMMENT '字段编码',
  `OldValue` longtext COMMENT '旧值',
  `NewValue` longtext COMMENT '新值',
  `Tag` varchar(128) DEFAULT NULL COMMENT '标签',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='操作明细表';

-- ----------------------------
-- Records of sys_action_detail
-- ----------------------------

-- ----------------------------
-- Table structure for sys_action_log
-- ----------------------------
DROP TABLE IF EXISTS `sys_action_log`;
CREATE TABLE `sys_action_log` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `ActionType` varchar(32) NOT NULL COMMENT '动作类型',
  `ActionAccount` varchar(32) DEFAULT NULL COMMENT '动作账号',
  `TargetCode` varchar(128) DEFAULT NULL COMMENT '目标编码',
  `TargetId` varchar(64) DEFAULT NULL COMMENT '目标ID',
  `IP` varchar(64) DEFAULT NULL,
  `Tag` varchar(128) DEFAULT NULL COMMENT '标签：说明状态的短语',
  `Comment` longtext COMMENT '注释',
  `Status` varchar(16) DEFAULT NULL COMMENT '记录状态',
  `Date` datetime DEFAULT NULL COMMENT '操作时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='操作日志表';

-- ----------------------------
-- Records of sys_action_log
-- ----------------------------
INSERT INTO `sys_action_log` VALUES ('1', 'Login', 'admin', 'NPiculet.Authorization.LoginKit', '', null, null, 'Administrator登录成功！', null, '2017-11-21 17:25:37');

-- ----------------------------
-- Table structure for sys_admin_info
-- ----------------------------
DROP TABLE IF EXISTS `sys_admin_info`;
CREATE TABLE `sys_admin_info` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserAccount` varchar(32) NOT NULL COMMENT '用户账号',
  `IsEnabled` int(11) NOT NULL COMMENT '是否启用',
  PRIMARY KEY (`Id`),
  KEY `IDX_UserAccount` (`UserAccount`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='管理员表';

-- ----------------------------
-- Records of sys_admin_info
-- ----------------------------

-- ----------------------------
-- Table structure for sys_app
-- ----------------------------
DROP TABLE IF EXISTS `sys_app`;
CREATE TABLE `sys_app` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `Platform` varchar(32) DEFAULT NULL COMMENT '应用平台',
  `Name` varchar(64) DEFAULT NULL,
  `Code` varchar(32) DEFAULT NULL COMMENT '配置项名称',
  `Key` varchar(128) DEFAULT NULL COMMENT '配置项代码',
  `Creator` varchar(32) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `IsEnabled` int(11) NOT NULL COMMENT '是否启用',
  PRIMARY KEY (`Id`),
  KEY `IDX_ConfigType` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COMMENT='系统应用表';

-- ----------------------------
-- Records of sys_app
-- ----------------------------
INSERT INTO `sys_app` VALUES ('1', null, '核心服务', 'sys-app-service', '05n2nX6kXxzn6GlR', '管理员', '2017-06-21 00:00:00', '1');
INSERT INTO `sys_app` VALUES ('2', null, '入口平台', 'platform', 'u6YvYVh8Y044iqYv', '管理员', '2017-06-21 00:00:00', '1');
INSERT INTO `sys_app` VALUES ('3', null, null, null, '4ApSuIz8Ccm2qf2K', '管理员', '2017-05-10 09:11:47', '0');
INSERT INTO `sys_app` VALUES ('4', null, null, null, 'uozyIO7Y939622gK', '管理员', '2017-05-10 09:11:47', '0');
INSERT INTO `sys_app` VALUES ('5', null, null, null, 'ZD749L60810BzNp2', '管理员', '2017-05-10 09:11:47', '0');
INSERT INTO `sys_app` VALUES ('6', null, null, null, 'x1KHr06P1943HHPp', '管理员', '2017-05-10 09:11:47', '0');
INSERT INTO `sys_app` VALUES ('7', null, null, null, 'jfCs94jcTOD2TAih', '管理员', '2017-05-10 09:11:47', '0');
INSERT INTO `sys_app` VALUES ('8', null, null, null, 'p9j9Le8FHp265URv', '管理员', '2017-05-10 09:11:47', '0');
INSERT INTO `sys_app` VALUES ('9', null, null, null, 'zG70o90t3RH7NihV', '管理员', '2017-05-10 09:11:47', '0');
INSERT INTO `sys_app` VALUES ('10', null, null, null, 'z2I78o1DWE0Supx3', '管理员', '2017-05-10 09:11:47', '0');

-- ----------------------------
-- Table structure for sys_authorization
-- ----------------------------
DROP TABLE IF EXISTS `sys_authorization`;
CREATE TABLE `sys_authorization` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `TargetId` int(11) NOT NULL COMMENT '授权对象ID：用户、角色',
  `TargetType` varchar(16) NOT NULL COMMENT '授权对象类型：用户、角色',
  `FunctionId` int(11) NOT NULL COMMENT '功能ID：菜单、功能',
  `FunctionType` varchar(16) DEFAULT NULL COMMENT '功能类型：菜单、功能',
  `Creator` varchar(32) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=201 DEFAULT CHARSET=utf8 COMMENT='功能授权表';

-- ----------------------------
-- Records of sys_authorization
-- ----------------------------
INSERT INTO `sys_authorization` VALUES ('190', '1', 'Role', '5', 'Menu', '管理员', '2017-09-05 23:21:37');
INSERT INTO `sys_authorization` VALUES ('191', '1', 'Role', '1', 'Menu', '管理员', '2017-09-05 23:21:37');
INSERT INTO `sys_authorization` VALUES ('192', '1', 'Role', '7', 'Menu', '管理员', '2017-09-05 23:21:37');
INSERT INTO `sys_authorization` VALUES ('193', '1', 'Role', '10', 'Menu', '管理员', '2017-09-05 23:21:37');
INSERT INTO `sys_authorization` VALUES ('194', '1', 'Role', '8', 'Menu', '管理员', '2017-09-05 23:21:37');
INSERT INTO `sys_authorization` VALUES ('195', '1', 'Role', '9', 'Menu', '管理员', '2017-09-05 23:21:37');
INSERT INTO `sys_authorization` VALUES ('196', '1', 'Role', '3', 'Menu', '管理员', '2017-09-05 23:21:37');
INSERT INTO `sys_authorization` VALUES ('197', '1', 'Role', '4', 'Menu', '管理员', '2017-09-05 23:21:37');
INSERT INTO `sys_authorization` VALUES ('198', '1', 'Role', '48', 'Menu', '管理员', '2017-09-05 23:21:37');
INSERT INTO `sys_authorization` VALUES ('199', '1', 'Role', '19', 'Menu', '管理员', '2017-09-05 23:21:37');
INSERT INTO `sys_authorization` VALUES ('200', '1', 'Role', '6', 'Menu', '管理员', '2017-09-05 23:21:37');

-- ----------------------------
-- Table structure for sys_config
-- ----------------------------
DROP TABLE IF EXISTS `sys_config`;
CREATE TABLE `sys_config` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `ConfigType` varchar(32) DEFAULT NULL,
  `ConfigName` varchar(64) DEFAULT NULL COMMENT '配置项名称',
  `ConfigCode` varchar(32) DEFAULT NULL COMMENT '配置项代码',
  `ConfigValue` varchar(255) DEFAULT NULL COMMENT '配置值',
  `Creator` varchar(32) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IDX_ConfigType` (`ConfigType`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8 COMMENT='系统配置表';

-- ----------------------------
-- Records of sys_config
-- ----------------------------
INSERT INTO `sys_config` VALUES ('1', null, null, 'PlatformName', 'NPiculet信息化系统开发框架', '管理员', '2017-10-12 10:07:13');
INSERT INTO `sys_config` VALUES ('2', null, null, 'WebSiteName', 'NPiculet信息化系统开发框架', '管理员', '2017-10-12 10:07:13');
INSERT INTO `sys_config` VALUES ('3', null, null, 'CompanyName', 'pcx.cn', '管理员', '2017-10-12 10:07:13');
INSERT INTO `sys_config` VALUES ('4', null, null, 'DomainName', 'www.pcx.cn', '管理员', '2017-10-12 10:07:13');
INSERT INTO `sys_config` VALUES ('5', null, null, 'ICP', '滇ICP备14000796号-1', '管理员', '2017-10-12 10:07:13');
INSERT INTO `sys_config` VALUES ('6', null, null, 'Tel', '', '管理员', '2017-10-12 10:07:13');
INSERT INTO `sys_config` VALUES ('7', null, null, 'ServiceTel', '', '管理员', '2017-10-12 10:07:13');
INSERT INTO `sys_config` VALUES ('8', null, null, 'PostCode', '', '管理员', '2017-10-12 10:07:13');
INSERT INTO `sys_config` VALUES ('9', null, null, 'EMail', '', '管理员', '2017-10-12 10:07:13');
INSERT INTO `sys_config` VALUES ('10', null, null, 'Address', '', '管理员', '2017-10-12 10:07:13');
INSERT INTO `sys_config` VALUES ('15', null, null, 'NewsEditLimit', '', '管理员', '2017-10-12 10:07:13');
INSERT INTO `sys_config` VALUES ('16', '', '', 'ImageWidth', '1000', '管理员', '2017-10-18 23:19:28');

-- ----------------------------
-- Table structure for sys_link_user_org
-- ----------------------------
DROP TABLE IF EXISTS `sys_link_user_org`;
CREATE TABLE `sys_link_user_org` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `UserId` int(11) NOT NULL COMMENT '用户ID',
  `OrgId` int(11) NOT NULL COMMENT '组织机构ID',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='用户角色连接表';

-- ----------------------------
-- Records of sys_link_user_org
-- ----------------------------
INSERT INTO `sys_link_user_org` VALUES ('1', '2', '1');

-- ----------------------------
-- Table structure for sys_link_user_role
-- ----------------------------
DROP TABLE IF EXISTS `sys_link_user_role`;
CREATE TABLE `sys_link_user_role` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `UserId` int(11) NOT NULL COMMENT '用户ID',
  `RoleId` int(11) NOT NULL COMMENT '角色ID',
  PRIMARY KEY (`Id`),
  KEY `IDX_UserRoleId` (`UserId`,`RoleId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='用户角色连接表';

-- ----------------------------
-- Records of sys_link_user_role
-- ----------------------------
INSERT INTO `sys_link_user_role` VALUES ('4', '1', '1');
INSERT INTO `sys_link_user_role` VALUES ('1', '2', '3');

-- ----------------------------
-- Table structure for sys_member_data
-- ----------------------------
DROP TABLE IF EXISTS `sys_member_data`;
CREATE TABLE `sys_member_data` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `MemberId` int(11) NOT NULL,
  `MemberAccount` varchar(32) NOT NULL COMMENT '用户账号',
  `Nickname` varchar(32) DEFAULT NULL COMMENT '昵称',
  `Birthday` varchar(16) DEFAULT NULL COMMENT '生日',
  `Sex` varchar(8) DEFAULT NULL COMMENT '性别',
  `Email` varchar(64) DEFAULT NULL COMMENT '电子邮件',
  `Mobile` varchar(32) DEFAULT NULL COMMENT '手机号码',
  `Address` varchar(255) DEFAULT NULL COMMENT '住址',
  `MemberCard` varchar(32) DEFAULT NULL COMMENT '会员卡号',
  `IdCard` varchar(32) DEFAULT NULL COMMENT '身份证',
  `Education` varchar(62) DEFAULT NULL COMMENT '学历',
  `QQ` varchar(16) DEFAULT NULL COMMENT 'QQ',
  `Weixin` varchar(64) DEFAULT NULL COMMENT 'MSN',
  `Weibo` varchar(64) DEFAULT NULL,
  `Interest` varchar(128) DEFAULT NULL COMMENT '兴趣',
  `PointCurrent` decimal(16,2) DEFAULT NULL,
  `PointTotal` decimal(16,2) DEFAULT NULL COMMENT '积分',
  `Exp` decimal(16,2) DEFAULT NULL,
  `Cash` decimal(16,2) DEFAULT NULL COMMENT '现金',
  `Cost` decimal(16,2) DEFAULT NULL COMMENT '花费',
  `HeadIcon` varchar(128) DEFAULT NULL,
  `Memo` varchar(128) DEFAULT NULL COMMENT '备注',
  `IsDel` int(11) DEFAULT NULL COMMENT '0',
  PRIMARY KEY (`Id`),
  KEY `IDX_UserAccount` (`MemberAccount`),
  KEY `IDX_UserId` (`MemberId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='用户资料表';

-- ----------------------------
-- Records of sys_member_data
-- ----------------------------
INSERT INTO `sys_member_data` VALUES ('1', '1', 'test', '', '', '', '', '', '', null, null, '', '', null, null, null, '0.00', '0.00', null, null, null, null, null, '0');
INSERT INTO `sys_member_data` VALUES ('2', '2', 'user', '', '', '', '', '', '', null, null, '', '', null, null, null, '0.00', '0.00', null, null, null, null, null, '0');

-- ----------------------------
-- Table structure for sys_member_info
-- ----------------------------
DROP TABLE IF EXISTS `sys_member_info`;
CREATE TABLE `sys_member_info` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `MemberSn` varchar(64) NOT NULL COMMENT '序号',
  `Account` varchar(32) NOT NULL COMMENT '帐号',
  `Password` varchar(32) NOT NULL COMMENT '密码',
  `Name` varchar(32) NOT NULL COMMENT '名称',
  `Type` varchar(16) DEFAULT NULL COMMENT '类型：个人、企业',
  `MemberLevel` varchar(16) DEFAULT NULL,
  `MemberLevelStatus` varchar(255) DEFAULT NULL,
  `BindSource` varchar(32) DEFAULT NULL,
  `BindDate` datetime DEFAULT NULL,
  `LoginTimes` int(11) DEFAULT NULL COMMENT '登录次数',
  `LastLoginDate` datetime DEFAULT NULL COMMENT '最后登入时间',
  `LastLogoutDate` datetime DEFAULT NULL COMMENT '最后登出时间',
  `PassQuestion` varchar(255) DEFAULT NULL COMMENT '密码问题',
  `PassAnswer` varchar(255) DEFAULT NULL COMMENT '密码回答',
  `FailedCount` int(11) DEFAULT NULL COMMENT '登陆错误次数',
  `FailedDate` datetime DEFAULT NULL COMMENT '登陆错误时间',
  `IsEnabled` int(11) NOT NULL COMMENT '是否启用',
  `IsDel` int(11) NOT NULL COMMENT '是否已删除',
  `Status` varchar(16) DEFAULT NULL,
  `Updater` varchar(32) DEFAULT NULL,
  `UpdateDate` datetime DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`),
  KEY `IDX_Account` (`Account`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='用户表';

-- ----------------------------
-- Records of sys_member_info
-- ----------------------------
INSERT INTO `sys_member_info` VALUES ('1', '9b8298e8a03d4b85b0b11e55787e0ab5', 'test', '123', '测试', null, '个人用户', null, null, null, null, null, null, null, null, null, null, '1', '0', '外挂', null, null, null, '2017-01-01 00:00:00');
INSERT INTO `sys_member_info` VALUES ('2', '1a495283e1274e2a8dbd306bc8ad6af1', 'user', 'user', '野生动物', null, '个人用户', null, null, null, null, null, null, null, null, null, null, '1', '0', '0', null, null, null, '2017-01-01 00:00:00');
INSERT INTO `sys_member_info` VALUES ('3', 'e5552be4a58c4b0ea491ebeef07e6fdc', 'qy01', 'qy01', '企业用户', null, '企业用户', null, null, null, null, null, null, null, null, null, null, '1', '0', '0', null, null, null, '2017-01-01 00:00:00');

-- ----------------------------
-- Table structure for sys_menu
-- ----------------------------
DROP TABLE IF EXISTS `sys_menu`;
CREATE TABLE `sys_menu` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `ParentId` int(11) NOT NULL COMMENT '父序号',
  `RootId` int(11) NOT NULL COMMENT '根序号',
  `Path` longtext COMMENT '路径',
  `Name` varchar(64) DEFAULT NULL COMMENT '名称',
  `Code` varchar(32) DEFAULT NULL COMMENT '编码',
  `Icon` longtext COMMENT '图标',
  `Belong` int(11) DEFAULT NULL COMMENT '所属：菜单、栏目',
  `Type` int(11) DEFAULT NULL COMMENT '类型',
  `Depth` int(11) DEFAULT NULL COMMENT '深度',
  `IsExternal` int(11) DEFAULT NULL COMMENT '使用外部链接',
  `Url` longtext COMMENT '页面地址',
  `Target` varchar(32) DEFAULT NULL COMMENT '目标',
  `Comment` longtext COMMENT '备注',
  `Sort` int(11) DEFAULT NULL COMMENT '排序',
  `IsEnabled` int(11) NOT NULL COMMENT '是否启用',
  `IsDel` int(11) NOT NULL COMMENT '是否已删除',
  `Creator` varchar(32) DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`),
  KEY `IDX_ParentId` (`ParentId`),
  KEY `IDX_OrderBy` (`Sort`)
) ENGINE=InnoDB AUTO_INCREMENT=127 DEFAULT CHARSET=utf8 COMMENT='系统菜单表';

-- ----------------------------
-- Records of sys_menu
-- ----------------------------
INSERT INTO `sys_menu` VALUES ('1', '0', '0', '', '系统菜单', '', '', '1', '0', '0', '0', '', 'mainFrame', '', '900', '1', '0', '', '2017-07-30 00:00:00');
INSERT INTO `sys_menu` VALUES ('3', '7', '1', '/1/7', '字典分组管理', '', '', '1', '0', '2', '0', 'system/DictGroupList.aspx', 'mainFrame', '', '100', '1', '0', '', '2017-07-30 00:00:00');
INSERT INTO `sys_menu` VALUES ('4', '7', '1', '/1/7', '字典数据管理', '', '', '1', '0', '2', '0', 'system/DictItemList.aspx', 'mainFrame', '', '110', '1', '0', '', '2017-07-30 00:00:00');
INSERT INTO `sys_menu` VALUES ('5', '7', '1', '/1/7', '功能管理', '', '', '1', '0', '2', '0', 'system/MenuSet.aspx', 'mainFrame', '', '0', '1', '0', '', '2017-07-30 00:00:00');
INSERT INTO `sys_menu` VALUES ('6', '7', '1', '/1/7', '系统配置项', '', '', '1', '0', '2', '0', 'system/ConfigSet.aspx', 'mainFrame', '', '999', '1', '0', '', '2017-07-30 00:00:00');
INSERT INTO `sys_menu` VALUES ('7', '1', '1', '/1', '系统管理', '', '', '1', '0', '1', '0', '', 'mainFrame', '', '9999', '1', '0', '', '2017-07-30 00:00:00');
INSERT INTO `sys_menu` VALUES ('8', '7', '1', '/1/7', '用户管理', '', '', '1', '0', '2', '0', 'system/UserList.aspx', 'mainFrame', '', '20', '1', '0', '', '2017-07-30 00:00:00');
INSERT INTO `sys_menu` VALUES ('9', '7', '1', '/1/7', '角色管理', '', '', '1', '0', '2', '0', 'system/RoleList.aspx', 'mainFrame', '', '40', '1', '0', '', '2017-07-30 00:00:00');
INSERT INTO `sys_menu` VALUES ('10', '7', '1', '/1/7', '机构管理', '', '', '1', '0', '2', '0', 'system/OrgSet.aspx', 'mainFrame', '', '10', '1', '0', '', '2017-07-30 00:00:00');
INSERT INTO `sys_menu` VALUES ('15', '1', '1', '/1', '信息管理', '', '', '1', '0', '1', '0', '', 'mainFrame', '', '100', '1', '0', '管理员', '2017-07-30 00:00:00');
INSERT INTO `sys_menu` VALUES ('16', '15', '1', '/1/15', '广告管理', '', '', '1', '0', '2', '0', 'cms/AdvList.aspx', 'mainFrame', '', '80', '1', '0', '管理员', '2017-07-30 00:00:00');
INSERT INTO `sys_menu` VALUES ('19', '7', '1', '/1/7', '栏目配置', '', '', '1', '0', '2', '0', 'cms/InfoGroupSet.aspx', 'mainFrame', '配置栏目', '998', '1', '0', '管理员', '2017-07-30 00:00:00');
INSERT INTO `sys_menu` VALUES ('37', '1', '1', '/1', '置顶栏目', '', '', '1', '0', '1', '0', '', 'mainFrame', '', '200', '1', '0', '管理员', '2017-07-30 00:00:00');
INSERT INTO `sys_menu` VALUES ('38', '37', '1', '/1/37', '本站动态', '1,3', '', '2', '0', '2', '0', 'cms/PageList.aspx?gid=3', 'mainFrame', '', '10', '1', '0', '管理员', '2017-07-30 00:00:00');
INSERT INTO `sys_menu` VALUES ('39', '37', '1', '/1/37', '发布日志', '1,2', '', '2', '0', '2', '0', 'cms/PageList.aspx?gid=2', 'mainFrame', '', '20', '1', '0', '管理员', '2017-07-30 00:00:00');
INSERT INTO `sys_menu` VALUES ('48', '7', '1', '/1/7', '系统日志', '', '', '1', '0', '2', '0', 'system/SystemLogList.aspx', 'mainFrame', '配置栏目', '997', '1', '0', '管理员', '2017-07-30 23:15:41');
INSERT INTO `sys_menu` VALUES ('49', '15', '1', '/1/15', '积分管理', '', '', '1', '0', '2', '0', 'system/PointSet.aspx', 'mainFrame', '', '999', '1', '0', '管理员', '2017-08-01 18:12:47');
INSERT INTO `sys_menu` VALUES ('53', '15', '1', '/1/15', '外部链接管理', '', '', '1', '0', '2', '0', 'cms/LinksList.aspx', 'mainFrame', '', '90', '1', '0', '管理员', '2017-08-15 13:42:16');
INSERT INTO `sys_menu` VALUES ('117', '7', '1', '/1/7', '模板管理', '', '', '1', '0', '2', '0', 'cms/ContentTmplList.aspx', 'mainFrame', '', '120', '1', '0', '管理员', '2017-09-17 22:48:51');
INSERT INTO `sys_menu` VALUES ('118', '1', '1', '/1', '字典管理', '', '', '1', '0', '1', '0', '', 'mainFrame', '', '900', '1', '0', '管理员', '2017-09-25 23:43:17');
INSERT INTO `sys_menu` VALUES ('119', '118', '1', '/1/118', '系统日志分类', '1', '', '3', '0', '2', '0', 'system/DictItemList.aspx?group=SystemLog&fix=true&cols=类型,日志名称,日志编码', 'mainFrame', '', '10', '1', '0', '管理员', '2017-09-25 23:43:29');
INSERT INTO `sys_menu` VALUES ('120', '118', '1', '/1/118', '企业性质', '2', '', '3', '0', '2', '0', 'system/DictItemList.aspx?group=EntNature&fix=true&cols=', 'mainFrame', '', '20', '1', '0', '管理员', '2017-09-25 23:43:36');
INSERT INTO `sys_menu` VALUES ('121', '118', '1', '/1/118', '用户类型', '3', '', '3', '0', '2', '0', 'system/DictItemList.aspx?group=UserType&fix=true&cols=', 'mainFrame', '', '30', '1', '0', '管理员', '2017-09-25 23:43:44');
INSERT INTO `sys_menu` VALUES ('122', '118', '1', '/1/118', '广告位置', '4', '', '3', '0', '2', '0', 'system/DictItemList.aspx?group=AdPosition&fix=true&cols=', 'mainFrame', '', '40', '1', '0', '管理员', '2017-09-25 23:43:51');
INSERT INTO `sys_menu` VALUES ('123', '1', '1', '/1', '会员管理', '', '', '1', null, '1', '0', '', 'mainFrame', '', '300', '1', '0', '管理员', '2017-10-18 23:54:53');
INSERT INTO `sys_menu` VALUES ('124', '123', '1', '/1/123', '会员管理', '', '', '1', null, '2', '0', 'member/MemberList.aspx', 'mainFrame', '', '10', '1', '0', '管理员', '2017-10-18 23:55:15');
INSERT INTO `sys_menu` VALUES ('125', '7', '1', '/1/7', '留言板分组管理', '', '', '1', null, '2', '0', 'cms/MsgBoardGroupList.aspx', 'mainFrame', '', '130', '1', '0', '管理员', '2017-11-21 17:20:02');
INSERT INTO `sys_menu` VALUES ('126', '15', '1', '/1/15', '留言管理', '', '', '1', null, '2', '0', 'cms/MsgBoardList.aspx', 'mainFrame', '', '200', '1', '0', '管理员', '2017-11-21 17:20:35');

-- ----------------------------
-- Table structure for sys_org_group
-- ----------------------------
DROP TABLE IF EXISTS `sys_org_group`;
CREATE TABLE `sys_org_group` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `GroupName` varchar(64) DEFAULT NULL COMMENT '名称',
  `GroupCode` varchar(32) DEFAULT NULL COMMENT '编码',
  `Memo` longtext COMMENT '备注',
  `IsVirtual` int(11) NOT NULL COMMENT '是否虚拟组织',
  `IsDel` int(11) NOT NULL COMMENT '是否已删除',
  `Creator` varchar(32) DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='组织机构组';

-- ----------------------------
-- Records of sys_org_group
-- ----------------------------

-- ----------------------------
-- Table structure for sys_org_info
-- ----------------------------
DROP TABLE IF EXISTS `sys_org_info`;
CREATE TABLE `sys_org_info` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `GroupCode` varchar(32) NOT NULL COMMENT '组ID',
  `ParentId` int(11) NOT NULL COMMENT '父ID',
  `RootId` int(11) NOT NULL COMMENT '根ID',
  `Path` longtext COMMENT '路径',
  `OrgName` varchar(64) DEFAULT NULL COMMENT '名称',
  `OrgCode` varchar(32) DEFAULT NULL COMMENT '编码',
  `OrgType` int(11) DEFAULT NULL COMMENT '类型：主机构、子机构',
  `FullName` longtext,
  `Alias` varchar(64) DEFAULT NULL,
  `Level` int(11) DEFAULT NULL COMMENT '子组织等级',
  `Address` text,
  `Tel` varchar(128) DEFAULT NULL,
  `Memo` longtext COMMENT '备注',
  `Point` decimal(12,2) DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL COMMENT '排序',
  `IsEnabled` int(11) NOT NULL COMMENT '是否启用',
  `IsDel` int(11) NOT NULL COMMENT '是否已删除',
  `Creator` varchar(32) DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`),
  KEY `IDX_GroupCode` (`GroupCode`),
  KEY `IDX_IsEnabled` (`IsEnabled`),
  KEY `IDX_IsDel` (`IsDel`),
  KEY `IDX_OrderBy` (`Sort`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='组织机构表';

-- ----------------------------
-- Records of sys_org_info
-- ----------------------------
INSERT INTO `sys_org_info` VALUES ('1', 'Default', '0', '0', '', 'pcx.cn', '', '1', 'pcx.cn', 'pcx.cn', '0', null, null, '', null, '0', '1', '0', '管理员', '2017-09-05 22:32:54');
INSERT INTO `sys_org_info` VALUES ('2', 'Default', '1', '1', '/1', '技术中心', '', '1', 'pcx.cn/技术中心', '技术中心', '1', null, null, '', '0.00', '0', '1', '0', '管理员', '2017-09-05 22:39:55');

-- ----------------------------
-- Table structure for sys_role_info
-- ----------------------------
DROP TABLE IF EXISTS `sys_role_info`;
CREATE TABLE `sys_role_info` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `Type` varchar(16) DEFAULT NULL,
  `RoleName` varchar(32) DEFAULT NULL COMMENT '名称',
  `Comment` varchar(255) DEFAULT NULL COMMENT '备注',
  `IsEnabled` int(11) NOT NULL COMMENT '是否启用',
  `IsDel` int(11) NOT NULL COMMENT '是否已删除',
  `Creator` varchar(32) DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`),
  KEY `IDX_Name` (`RoleName`),
  KEY `IDX_Type` (`Type`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='角色信息';

-- ----------------------------
-- Records of sys_role_info
-- ----------------------------
INSERT INTO `sys_role_info` VALUES ('1', null, '系统管理员', '', '1', '0', '管理员', '2016-03-10 15:51:50');
INSERT INTO `sys_role_info` VALUES ('2', null, 'test', '', '1', '1', '管理员', '2017-09-05 21:05:41');

-- ----------------------------
-- Table structure for sys_user_data
-- ----------------------------
DROP TABLE IF EXISTS `sys_user_data`;
CREATE TABLE `sys_user_data` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `UserId` int(11) NOT NULL,
  `UserAccount` varchar(32) NOT NULL COMMENT '用户账号',
  `Nickname` varchar(32) DEFAULT NULL COMMENT '昵称',
  `Birthday` varchar(16) DEFAULT NULL COMMENT '生日',
  `Sex` varchar(8) DEFAULT NULL COMMENT '性别',
  `Email` varchar(64) DEFAULT NULL COMMENT '电子邮件',
  `Mobile` varchar(32) DEFAULT NULL COMMENT '手机号码',
  `Address` varchar(255) DEFAULT NULL COMMENT '住址',
  `MemberCard` varchar(32) DEFAULT NULL COMMENT '会员卡号',
  `IdCard` varchar(32) DEFAULT NULL COMMENT '身份证',
  `Education` varchar(62) DEFAULT NULL COMMENT '学历',
  `QQ` varchar(16) DEFAULT NULL COMMENT 'QQ',
  `Weixin` varchar(64) DEFAULT NULL COMMENT 'MSN',
  `Weibo` varchar(64) DEFAULT NULL,
  `Interest` varchar(128) DEFAULT NULL COMMENT '兴趣',
  `PointCurrent` decimal(16,2) DEFAULT NULL,
  `PointTotal` decimal(16,2) DEFAULT NULL COMMENT '积分',
  `Exp` decimal(16,2) DEFAULT NULL,
  `Cash` decimal(16,2) DEFAULT NULL COMMENT '现金',
  `Cost` decimal(16,2) DEFAULT NULL COMMENT '花费',
  `HeadIcon` varchar(128) DEFAULT NULL,
  `Memo` varchar(128) DEFAULT NULL COMMENT '备注',
  `IsDel` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IDX_UserAccount` (`UserAccount`),
  KEY `IDX_UserId` (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COMMENT='用户资料表';

-- ----------------------------
-- Records of sys_user_data
-- ----------------------------
INSERT INTO `sys_user_data` VALUES ('1', '1', 'admin', '', '', '', '', '', '', null, null, '', '', null, null, null, null, null, null, null, null, null, null, '0');
INSERT INTO `sys_user_data` VALUES ('2', '11', 'test', '', '', '', '', '', '', null, null, null, '', null, null, null, null, null, null, null, null, null, null, '1');
INSERT INTO `sys_user_data` VALUES ('3', '6', 'shangxy', 'x3', '', '男', '', '', '', null, null, null, '', null, null, null, null, null, null, null, null, null, null, '1');
INSERT INTO `sys_user_data` VALUES ('4', '4', 'changy', '', '', '', '', '', '', null, null, null, '', null, null, null, null, null, null, null, null, null, null, '1');
INSERT INTO `sys_user_data` VALUES ('5', '9', 'yangk', '', '', '', '', '', '', null, null, null, '', null, null, null, null, null, null, null, null, null, null, '1');

-- ----------------------------
-- Table structure for sys_user_info
-- ----------------------------
DROP TABLE IF EXISTS `sys_user_info`;
CREATE TABLE `sys_user_info` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `UserSn` varchar(64) NOT NULL COMMENT '序号',
  `Type` varchar(16) DEFAULT NULL COMMENT '自定义类型',
  `Account` varchar(32) NOT NULL COMMENT '帐号',
  `Password` varchar(32) NOT NULL COMMENT '密码',
  `Name` varchar(32) NOT NULL COMMENT '名称',
  `OrgId` int(11) DEFAULT NULL COMMENT '所属部门',
  `LoginTimes` int(11) DEFAULT NULL COMMENT '登录次数',
  `LastLoginDate` datetime DEFAULT NULL COMMENT '最后登入时间',
  `LastLogoutDate` datetime DEFAULT NULL COMMENT '最后登出时间',
  `FailedCount` int(11) DEFAULT NULL COMMENT '登陆错误次数',
  `FailedDate` datetime DEFAULT NULL COMMENT '登陆错误时间',
  `Sort` int(11) DEFAULT NULL,
  `IsEnabled` int(11) NOT NULL COMMENT '是否启用',
  `IsDel` int(11) NOT NULL COMMENT '是否已删除',
  `Updater` varchar(32) DEFAULT NULL,
  `UpdateDate` datetime DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`),
  KEY `IDX_Account` (`Account`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COMMENT='用户表';

-- ----------------------------
-- Records of sys_user_info
-- ----------------------------
INSERT INTO `sys_user_info` VALUES ('1', 'admin', '0', 'admin', '123', '管理员', null, null, null, null, null, null, '0', '1', '0', null, null, null, null);
INSERT INTO `sys_user_info` VALUES ('2', 'lisa', '0', 'lisa', '123', '李萨', null, null, null, null, null, null, '0', '1', '0', null, null, null, null);
INSERT INTO `sys_user_info` VALUES ('3', 'wangjl', '0', 'wangjl', '123', '王进龙', null, null, null, null, null, null, '0', '1', '1', null, null, null, null);
INSERT INTO `sys_user_info` VALUES ('4', 'changy', '', 'changy', '123', '常银', '2', null, null, null, null, null, '0', '1', '1', null, null, null, null);
INSERT INTO `sys_user_info` VALUES ('5', 'lij', '0', 'lij', '123', '李俊', null, null, null, null, null, null, '0', '1', '1', null, null, null, null);
INSERT INTO `sys_user_info` VALUES ('6', 'shangxy', '', 'shangxy', '123', '商晓亚', '2', null, null, null, null, null, '0', '1', '1', null, null, null, null);
INSERT INTO `sys_user_info` VALUES ('7', 'wangxb', '0', 'wangxb', '123', '王行波', null, null, null, null, null, null, '0', '1', '1', null, null, null, null);
INSERT INTO `sys_user_info` VALUES ('8', 'zhouzj', '0', 'zhouzj', '123', '周祉君', null, null, null, null, null, null, '0', '1', '1', null, null, null, null);
INSERT INTO `sys_user_info` VALUES ('9', 'yangk', '', 'yangk', '123', '杨凯', '2', null, null, null, null, null, '0', '1', '1', null, null, null, null);
INSERT INTO `sys_user_info` VALUES ('10', 'lixl', '0', 'lixl', '123', '李新雷', null, null, null, null, null, null, '0', '1', '1', null, null, null, null);
INSERT INTO `sys_user_info` VALUES ('11', 'a61649ab-3b05-4007-93d8-168f3f76cfaa', '', 'test', '123', 'test', null, null, null, null, null, null, '1', '1', '1', null, null, '管理员', '2017-09-05 22:02:16');
