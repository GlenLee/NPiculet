/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 50625
Source Host           : 127.0.0.1:19336
Source Database       : npiculet

Target Server Type    : MYSQL
Target Server Version : 50625
File Encoding         : 65001

Date: 2017-05-27 00:27:25
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
  `OrderBy` int(11) DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='字典分组';

-- ----------------------------
-- Records of bas_dict_group
-- ----------------------------
INSERT INTO `bas_dict_group` VALUES ('1', 'EmployeePosition', '招聘职位', '下拉列表', '招聘职位组', '0', null, '0', '1', null, '管理员', '2016-03-12 11:00:25');
INSERT INTO `bas_dict_group` VALUES ('2', 'EnterpriseNature', '企业性质', '下拉列表', '企业性质。国企，私企，合资，外商独资，港澳台企业，国内上市公司', '0', null, '0', '1', null, '管理员', '2016-03-23 20:53:54');

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
  `OrderBy` int(11) DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COMMENT='字典项';

-- ----------------------------
-- Records of bas_dict_item
-- ----------------------------
INSERT INTO `bas_dict_item` VALUES ('1', 'EnterpriseNature', 'EnterpriseNature', '国内上市公司', 'StockMarket', '企业性质。国企SOE，私企private，合资JointVenture，外商独资MNC，港澳台企业HK，国内上市公司StockMarket.', '1', '2', '管理员', '2016-03-23 21:00:52');
INSERT INTO `bas_dict_item` VALUES ('2', 'EnterpriseNature', 'EnterpriseNature', '国有企业', 'SOE', '企业性质。国企SOE，私企private，合资JointVenture，外商独资MNC，港澳台企业HK，国内上市公司StockMarket.', '1', '3', '管理员', '2016-03-23 21:11:46');
INSERT INTO `bas_dict_item` VALUES ('3', 'EnterpriseNature', 'EnterpriseNature', '私营企业', 'PrivateEnterprise', '企业性质。国企SOE，私企private，合资JointVenture，外商独资MNC，港澳台企业HK，国内上市公司StockMarket.', '1', '1', '管理员', '2016-03-23 21:13:35');
INSERT INTO `bas_dict_item` VALUES ('4', 'EnterpriseNature', 'EnterpriseNature', '中外合资', 'JointVenture', '', '1', '4', '管理员', '2016-03-23 21:14:45');
INSERT INTO `bas_dict_item` VALUES ('5', 'EnterpriseNature', 'EnterpriseNature', '港澳台企业', 'HKMacTai', '', '1', '5', '管理员', '2016-03-23 21:16:01');

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
  `Type` varchar(16) DEFAULT NULL,
  `Description` longtext,
  `Image` varchar(255) DEFAULT NULL,
  `Url` text,
  `Click` int(11) NOT NULL,
  `IsEnabled` int(11) NOT NULL,
  `OrderBy` int(11) DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL,
  `CreateDate` datetime NOT NULL,
  `EndDate` datetime DEFAULT NULL,
  `StartDate` datetime DEFAULT NULL,
  `LoopStart` varchar(255) DEFAULT NULL,
  `LoopEnd` varchar(255) DEFAULT NULL,
  `ValidTerm` int(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=48 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of cms_adv_info
-- ----------------------------
INSERT INTO `cms_adv_info` VALUES ('12', '推荐品牌', '演示的数据', null, 'http://pcx.cn', '0', '2', null, '管理员', '2016-03-29 16:11:56', null, '2016-03-17 16:16:28', null, null, '1');
INSERT INTO `cms_adv_info` VALUES ('25', '轮播广告', '演示的数据', '~/uploads/files/201608/G822S3303048.jpg', 'http://pcx.cn', '0', '1', null, '管理员', '2016-08-22 18:33:03', null, null, null, null, null);
INSERT INTO `cms_adv_info` VALUES ('26', '轮播广告', '演示的数据', '~/uploads/files/201608/G822S3321149.jpg', 'http://pcx.cn', '0', '1', null, '管理员', '2016-08-22 18:33:21', null, null, null, null, null);
INSERT INTO `cms_adv_info` VALUES ('27', '轮播广告', '演示的数据', '~/uploads/files/201608/G822S3337123.jpg', 'http://pcx.cn', '0', '1', null, '管理员', '2016-08-22 18:33:37', null, null, null, null, null);
INSERT INTO `cms_adv_info` VALUES ('29', '底部广告', '演示的数据', '~/uploads/files/201608/G822S3711963.jpg', 'http://pcx.cn', '0', '1', null, '管理员', '2016-08-22 18:37:12', null, null, null, null, null);
INSERT INTO `cms_adv_info` VALUES ('31', '右侧广告', '演示的数据', '~/uploads/files/201608/G825L5313123.png', 'http://pcx.cn', '0', '1', null, '管理员', '2016-08-25 11:53:13', null, null, null, null, null);
INSERT INTO `cms_adv_info` VALUES ('32', '右侧广告', '演示的数据', '~/uploads/files/201608/G825M0631574.png', 'http://pcx.cn', '0', '1', null, '管理员', '2016-08-25 12:06:04', null, null, null, null, null);
INSERT INTO `cms_adv_info` VALUES ('33', '推荐品牌', '演示的数据', '~/uploads/files/201608/G825M0858554.png', 'http://pcx.cn', '0', '1', null, '管理员', '2016-08-25 12:08:59', null, null, null, null, null);
INSERT INTO `cms_adv_info` VALUES ('34', '推荐品牌', '演示的数据', '~/uploads/files/201608/G825M0943950.png', 'http://pcx.cn', '0', '1', null, '管理员', '2016-08-25 12:09:44', null, null, null, null, null);
INSERT INTO `cms_adv_info` VALUES ('35', '推荐品牌', '演示的数据', '~/uploads/files/201608/G829U5235662.jpg', 'http://pcx.cn', '0', '1', null, '管理员', '2016-08-29 20:52:36', null, null, null, null, null);
INSERT INTO `cms_adv_info` VALUES ('36', '推荐品牌', '演示的数据', '~/uploads/files/201608/G829U5300218.jpg', 'http://pcx.cn', '0', '1', null, '管理员', '2016-08-29 20:53:00', null, null, null, null, null);
INSERT INTO `cms_adv_info` VALUES ('37', '推荐品牌', '演示的数据', '~/uploads/files/201608/G829U5321132.jpg', 'http://pcx.cn', '0', '1', null, '管理员', '2016-08-29 20:53:21', null, null, null, null, null);
INSERT INTO `cms_adv_info` VALUES ('38', '推荐品牌', '演示的数据', '~/uploads/files/201608/G829U5337499.jpg', 'http://pcx.cn', '0', '1', null, '管理员', '2016-08-29 20:53:38', null, null, null, null, null);
INSERT INTO `cms_adv_info` VALUES ('39', '推荐品牌', '演示的数据', '~/uploads/files/201608/G829U5357638.jpg', 'http://pcx.cn', '0', '1', null, '管理员', '2016-08-29 20:53:58', null, null, null, null, null);
INSERT INTO `cms_adv_info` VALUES ('41', '推荐品牌', '演示的数据', '~/uploads/files/201608/G829U5452339.jpg', 'http://pcx.cn', '0', '1', null, '管理员', '2016-08-29 20:54:52', null, null, null, null, null);
INSERT INTO `cms_adv_info` VALUES ('45', '推荐品牌', '演示的数据', '~/uploads/files/201608/G829U5815511.jpg', 'http://pcx.cn', '0', '1', null, '管理员', '2016-08-29 20:58:16', null, null, null, null, null);
INSERT INTO `cms_adv_info` VALUES ('46', '推荐品牌', '演示的数据', '~/uploads/files/201608/G829U5836591.jpg', 'http://pcx.cn', '0', '1', null, '管理员', '2016-08-29 20:58:37', null, null, null, null, null);
INSERT INTO `cms_adv_info` VALUES ('47', '推荐品牌', '演示的数据', '~/uploads/files/201608/G829V0449298.jpg', 'http://pcx.cn', '0', '1', null, '管理员', '2016-08-29 21:04:49', null, null, null, null, null);

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
  `IsExternal` int(11) DEFAULT NULL,
  `IsShow` int(11) DEFAULT NULL,
  `Comment` longtext,
  `OrderBy` int(11) DEFAULT NULL,
  `IsEnabled` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of cms_content_group
-- ----------------------------
INSERT INTO `cms_content_group` VALUES ('1', 'FontPage', '首页栏目', '', '0', '0', '', null, '', '0', '1', null, '0', '1');
INSERT INTO `cms_content_group` VALUES ('2', 'PageNew', '新闻页面', 'List', '1', '0', '', null, '', '0', '1', null, '1', '1');
INSERT INTO `cms_content_group` VALUES ('3', 'PagePolicy', '政策文件', 'List', '1', '0', '', null, '', '0', '1', null, '2', '1');
INSERT INTO `cms_content_group` VALUES ('4', 'PageAssociationNews', '协会动态', 'List', '1', '0', '', null, '', '0', '1', null, '3', '1');
INSERT INTO `cms_content_group` VALUES ('5', 'PageConsultNews', '综合资讯', 'List', '1', '0', '', null, '', '0', '1', null, '4', '1');
INSERT INTO `cms_content_group` VALUES ('6', 'PageAssociatorShow', '会员展示', 'List', '1', '0', '', null, '', '0', '1', null, '5', '1');
INSERT INTO `cms_content_group` VALUES ('7', 'PageLaw', '法律专栏', 'List', '1', '0', '', null, '', '0', '1', null, '6', '1');
INSERT INTO `cms_content_group` VALUES ('8', 'PageBar', '网吧培训', 'List', '1', '0', '', null, '', '0', '1', null, '7', '1');
INSERT INTO `cms_content_group` VALUES ('9', 'PageJobSeeker', '人才库', 'List', '1', '0', '', null, '', '0', '1', null, '8', '1');
INSERT INTO `cms_content_group` VALUES ('10', 'RecBrand', '广告管理', 'List', '1', '0', '', null, '', '0', '1', null, '9', '1');
INSERT INTO `cms_content_group` VALUES ('11', 'FontPage', '首页栏目', '', '1', '0', '', null, '', '0', '1', null, '0', '1');
INSERT INTO `cms_content_group` VALUES ('18', 'friendslinks', '友情链接', 'List', '1', '0', '', null, '', '0', '1', null, '12', '1');
INSERT INTO `cms_content_group` VALUES ('19', 'EntHire', '企业招聘', 'List', '1', '0', '', null, '', '0', '1', null, '9', '1');
INSERT INTO `cms_content_group` VALUES ('20', 'EntProtocol', '企业注册协议', 'Content', '1', '0', '', null, '', '0', '1', null, '200', '1');
INSERT INTO `cms_content_group` VALUES ('21', 'MemberProtocol', '个人注册协议', 'Content', '1', '0', '', null, '', '0', '1', null, '210', '1');
INSERT INTO `cms_content_group` VALUES ('22', 'Sale', '交易区', 'List', '1', '0', '', null, '', '0', '1', null, '13', '1');

-- ----------------------------
-- Table structure for cms_content_page
-- ----------------------------
DROP TABLE IF EXISTS `cms_content_page`;
CREATE TABLE `cms_content_page` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `GroupCode` varchar(32) NOT NULL,
  `CategoryId` int(11) NOT NULL,
  `CategoryName` varchar(64) DEFAULT NULL,
  `Title` varchar(128) DEFAULT NULL,
  `Content` longtext,
  `Thumb` varchar(128) DEFAULT NULL,
  `Source` varchar(128) DEFAULT NULL,
  `Click` int(11) NOT NULL,
  `IsEnabled` int(11) NOT NULL,
  `Author` varchar(32) DEFAULT NULL,
  `OrderBy` int(11) DEFAULT NULL,
  `CreateDate` datetime NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=126 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of cms_content_page
-- ----------------------------
INSERT INTO `cms_content_page` VALUES ('2', 'PagePolicy', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '15', '1', '管理员', null, '2016-03-13 16:49:41');
INSERT INTO `cms_content_page` VALUES ('4', 'PageConsultNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '9', '1', '管理员', null, '2016-03-13 16:57:39');
INSERT INTO `cms_content_page` VALUES ('6', 'PageLaw', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '11', '1', '管理员', null, '2016-03-13 17:00:33');
INSERT INTO `cms_content_page` VALUES ('7', 'PageBar', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '13', '1', '管理员', null, '2016-03-13 17:01:20');
INSERT INTO `cms_content_page` VALUES ('8', 'PageJobSeeker', '0', null, 'custom', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '18', '1', '管理员', null, '2016-03-13 17:18:09');
INSERT INTO `cms_content_page` VALUES ('10', 'RecBrand', '0', null, 'baidu', 'http://www.baidu.com', '~/uploads/thumb/201603/G315R3324495.jpg', null, '4', '1', '管理员', null, '2016-03-15 17:33:27');
INSERT INTO `cms_content_page` VALUES ('11', 'RecBrand', '0', null, 'baidu', 'http://www.baidu.com', '~/uploads/thumb/201603/G315R3324495.jpg', null, '0', '1', '管理员', null, '2016-03-15 17:33:27');
INSERT INTO `cms_content_page` VALUES ('12', 'RecBrand', '0', null, 'baidu', 'http://www.baidu.com', '~/uploads/thumb/201603/G315R3324495.jpg', null, '0', '1', '管理员', null, '2016-03-15 17:33:27');
INSERT INTO `cms_content_page` VALUES ('13', 'RecBrand', '0', null, 'baidu', 'http://www.baidu.com', '~/uploads/thumb/201603/G315R3324495.jpg', null, '0', '1', '管理员', null, '2016-03-15 17:33:27');
INSERT INTO `cms_content_page` VALUES ('14', 'RecBrand', '0', null, 'baidu', 'http://www.baidu.com', '~/uploads/thumb/201603/G315R3324495.jpg', null, '0', '1', '管理员', null, '2016-03-15 17:33:27');
INSERT INTO `cms_content_page` VALUES ('15', 'RecBrand', '0', null, 'baidu', 'http://www.baidu.com', '~/uploads/thumb/201603/G315R3324495.jpg', null, '0', '1', '管理员', null, '2016-03-15 17:33:27');
INSERT INTO `cms_content_page` VALUES ('16', 'RecBrand', '0', null, 'baidu', 'http://www.baidu.com', '~/uploads/thumb/201603/G315R3324495.jpg', null, '0', '1', '管理员', null, '2016-03-15 17:33:27');
INSERT INTO `cms_content_page` VALUES ('17', 'RecBrand', '0', null, 'baidu', 'http://www.baidu.com', '~/uploads/thumb/201603/G315R3324495.jpg', null, '0', '1', '管理员', null, '2016-03-15 17:33:27');
INSERT INTO `cms_content_page` VALUES ('18', 'RecBrand', '0', null, 'baidu', 'http://www.baidu.com', '~/uploads/thumb/201603/G315R3324495.jpg', null, '0', '1', '管理员', null, '2016-03-15 17:33:27');
INSERT INTO `cms_content_page` VALUES ('19', 'RecBrand', '0', null, 'baidu', 'http://www.baidu.com', '~/uploads/thumb/201603/G315R3324495.jpg', null, '0', '1', '管理员', null, '2016-03-15 17:33:27');
INSERT INTO `cms_content_page` VALUES ('20', 'RecBrand', '0', null, 'baidu', 'http://www.baidu.com', '~/uploads/thumb/201603/G315R3324495.jpg', null, '0', '1', '管理员', null, '2016-03-15 17:33:27');
INSERT INTO `cms_content_page` VALUES ('21', 'PagePolicy', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '10', '1', '管理员', null, '2016-03-24 17:06:38');
INSERT INTO `cms_content_page` VALUES ('22', 'PagePolicy', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '7', '1', '管理员', null, '2016-03-24 17:09:57');
INSERT INTO `cms_content_page` VALUES ('23', 'PagePolicy', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '398', '1', '管理员', null, '2016-03-24 17:12:53');
INSERT INTO `cms_content_page` VALUES ('24', 'PageNew', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', '~/uploads/thumb/201603/G324R2331146.jpg', null, '12', '1', '管理员', null, '2016-03-24 17:14:55');
INSERT INTO `cms_content_page` VALUES ('26', 'PageConsultNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '0', '1', '管理员', null, '2016-04-09 22:29:54');
INSERT INTO `cms_content_page` VALUES ('27', 'PageConsultNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '4', '1', '管理员', null, '2016-04-30 22:32:02');
INSERT INTO `cms_content_page` VALUES ('28', 'PageConsultNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', '~/uploads/thumb/201604/G409W4146004.jpg', null, '6', '1', '管理员', null, '2016-04-27 22:41:46');
INSERT INTO `cms_content_page` VALUES ('29', 'PageAssociationNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '6', '1', '管理员', null, '2016-04-09 22:58:34');
INSERT INTO `cms_content_page` VALUES ('30', 'PageAssociationNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', '~/uploads/thumb/201604/G409X0112118.jpg', null, '9', '1', '管理员', null, '2016-04-09 23:01:13');
INSERT INTO `cms_content_page` VALUES ('32', '', '0', null, 'custom', '', null, null, '2', '1', '管理员', null, '2016-04-28 11:41:03');
INSERT INTO `cms_content_page` VALUES ('43', 'EntHire', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '25', '1', '管理员', null, '2016-04-28 13:52:04');
INSERT INTO `cms_content_page` VALUES ('44', 'PageJobSeeker', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '22', '1', '管理员', null, '2016-04-28 14:31:14');
INSERT INTO `cms_content_page` VALUES ('45', 'PageAssociationNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', '~/uploads/thumb/201605/G504Q4735218.jpg', null, '319', '1', '管理员', null, '2016-05-04 16:47:35');
INSERT INTO `cms_content_page` VALUES ('46', 'MemberProtocol', '0', null, 'protocol', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '0', '1', '管理员', null, '2016-05-18 22:15:48');
INSERT INTO `cms_content_page` VALUES ('47', 'EntProtocol', '0', null, 'protocol', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '0', '1', '管理员', null, '2016-05-18 22:16:00');
INSERT INTO `cms_content_page` VALUES ('49', 'PagePolicy', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '6', '1', '管理员', null, '2016-08-23 10:02:25');
INSERT INTO `cms_content_page` VALUES ('50', 'PagePolicy', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '10', '1', '管理员', null, '2016-08-23 10:05:58');
INSERT INTO `cms_content_page` VALUES ('51', 'PagePolicy', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '15', '1', '管理员', null, '2016-08-23 10:09:39');
INSERT INTO `cms_content_page` VALUES ('52', 'PageLaw', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '10', '1', '管理员', null, '2016-08-23 10:14:11');
INSERT INTO `cms_content_page` VALUES ('53', 'PageConsultNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '3', '1', '管理员', null, '2016-08-23 14:27:32');
INSERT INTO `cms_content_page` VALUES ('54', 'PageConsultNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '4', '1', '管理员', null, '2016-08-23 14:28:14');
INSERT INTO `cms_content_page` VALUES ('55', 'PageConsultNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '0', '1', '管理员', null, '2016-08-23 14:29:41');
INSERT INTO `cms_content_page` VALUES ('56', 'PageNew', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '5', '1', '管理员', null, '2016-08-25 09:06:22');
INSERT INTO `cms_content_page` VALUES ('57', 'PageNew', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '2', '1', '管理员', null, '2016-08-25 09:08:06');
INSERT INTO `cms_content_page` VALUES ('58', 'PageConsultNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '6', '1', '管理员', null, '2016-08-25 09:10:00');
INSERT INTO `cms_content_page` VALUES ('59', 'PageBar', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '0', '1', '管理员', null, '2016-08-25 09:10:39');
INSERT INTO `cms_content_page` VALUES ('60', 'PageBar', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '0', '1', '管理员', null, '2016-08-25 09:11:38');
INSERT INTO `cms_content_page` VALUES ('61', 'PageBar', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '2', '1', '管理员', null, '2016-08-25 09:12:06');
INSERT INTO `cms_content_page` VALUES ('62', 'PageBar', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '8', '1', '管理员', null, '2016-08-25 09:13:54');
INSERT INTO `cms_content_page` VALUES ('63', 'PageBar', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '4', '1', '管理员', null, '2016-08-25 09:34:22');
INSERT INTO `cms_content_page` VALUES ('64', 'PageBar', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '2', '1', '管理员', null, '2016-08-25 09:35:35');
INSERT INTO `cms_content_page` VALUES ('65', 'PageBar', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '4', '1', '管理员', null, '2016-08-25 09:36:10');
INSERT INTO `cms_content_page` VALUES ('66', 'PageLaw', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '0', '1', '管理员', null, '2016-08-25 09:41:59');
INSERT INTO `cms_content_page` VALUES ('67', 'PageConsultNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '2', '1', '管理员', null, '2016-08-25 10:53:30');
INSERT INTO `cms_content_page` VALUES ('68', 'PageBar', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '0', '1', '管理员', null, '2016-08-25 10:55:53');
INSERT INTO `cms_content_page` VALUES ('69', 'PageBar', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '5', '1', '管理员', null, '2016-08-25 10:56:36');
INSERT INTO `cms_content_page` VALUES ('70', 'PageBar', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '2', '1', '管理员', null, '2016-08-25 10:57:19');
INSERT INTO `cms_content_page` VALUES ('71', 'PageBar', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '9', '1', '管理员', null, '2016-08-25 10:58:06');
INSERT INTO `cms_content_page` VALUES ('72', 'PageBar', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '1', '1', '管理员', null, '2016-08-25 11:01:05');
INSERT INTO `cms_content_page` VALUES ('73', 'PageConsultNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '5', '1', '管理员', null, '2016-08-25 11:03:32');
INSERT INTO `cms_content_page` VALUES ('74', 'PagePolicy', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '43', '1', '管理员', null, '2016-08-25 11:07:27');
INSERT INTO `cms_content_page` VALUES ('75', 'PagePolicy', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '16', '1', '管理员', null, '2016-08-25 11:09:23');
INSERT INTO `cms_content_page` VALUES ('76', 'Sale', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '9', '1', '管理员', null, '2016-08-25 11:16:51');
INSERT INTO `cms_content_page` VALUES ('77', 'Sale', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '7', '1', '管理员', null, '2016-08-25 11:23:17');
INSERT INTO `cms_content_page` VALUES ('78', 'Sale', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '6', '1', '管理员', null, '2016-08-25 11:25:00');
INSERT INTO `cms_content_page` VALUES ('79', 'Sale', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '9', '1', '管理员', null, '2016-08-25 11:28:42');
INSERT INTO `cms_content_page` VALUES ('80', 'Sale', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '7', '1', '管理员', null, '2016-08-25 11:31:46');
INSERT INTO `cms_content_page` VALUES ('81', 'Sale', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '12', '1', '管理员', null, '2016-08-25 11:33:44');
INSERT INTO `cms_content_page` VALUES ('82', 'Sale', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '9', '1', '管理员', null, '2016-08-25 11:35:35');
INSERT INTO `cms_content_page` VALUES ('83', 'PageAssociatorShow', '0', null, 'shop', '', null, null, '37', '1', '管理员', null, '2016-08-25 11:36:51');
INSERT INTO `cms_content_page` VALUES ('84', 'PageAssociatorShow', '0', null, 'shop', '', null, null, '39', '1', '管理员', null, '2016-08-25 11:37:17');
INSERT INTO `cms_content_page` VALUES ('85', 'PageAssociatorShow', '0', null, 'shop', '', null, null, '29', '1', '管理员', null, '2016-08-25 11:37:32');
INSERT INTO `cms_content_page` VALUES ('86', 'PageAssociatorShow', '0', null, 'shop', '', null, null, '21', '1', '管理员', null, '2016-08-25 11:37:44');
INSERT INTO `cms_content_page` VALUES ('87', 'PageAssociatorShow', '0', null, 'shop', '', null, null, '13', '1', '管理员', null, '2016-08-25 11:37:56');
INSERT INTO `cms_content_page` VALUES ('88', 'PageAssociatorShow', '0', null, 'shop', '', null, null, '26', '1', '管理员', null, '2016-08-25 11:38:09');
INSERT INTO `cms_content_page` VALUES ('89', 'PageAssociatorShow', '0', null, 'shop', '', null, null, '32', '1', '管理员', null, '2016-08-25 11:38:22');
INSERT INTO `cms_content_page` VALUES ('91', 'PageAssociatorShow', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '116', '1', '管理员', null, '2016-08-25 11:43:32');
INSERT INTO `cms_content_page` VALUES ('92', 'PageNew', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', '~/uploads/thumb/201608/G825M2418002.jpg', null, '5', '1', '管理员', null, '2016-08-25 12:22:26');
INSERT INTO `cms_content_page` VALUES ('93', 'PageAssociationNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '0', '1', '管理员', null, '2016-08-26 09:34:46');
INSERT INTO `cms_content_page` VALUES ('94', 'PageAssociationNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '2', '1', '管理员', null, '2016-08-26 09:39:59');
INSERT INTO `cms_content_page` VALUES ('95', 'PageAssociationNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '3', '1', '管理员', null, '2016-08-26 09:54:14');
INSERT INTO `cms_content_page` VALUES ('96', 'PageAssociationNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '4', '1', '管理员', null, '2016-08-26 09:55:35');
INSERT INTO `cms_content_page` VALUES ('97', 'PageAssociationNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '2', '1', '管理员', null, '2016-08-26 09:58:19');
INSERT INTO `cms_content_page` VALUES ('98', 'PageAssociationNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '1', '1', '管理员', null, '2016-08-26 09:59:29');
INSERT INTO `cms_content_page` VALUES ('99', 'PageAssociationNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '6', '1', '管理员', null, '2016-08-26 10:00:52');
INSERT INTO `cms_content_page` VALUES ('100', 'PageAssociationNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '5', '1', '管理员', null, '2016-08-26 10:03:22');
INSERT INTO `cms_content_page` VALUES ('101', 'PageAssociationNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '3', '1', '管理员', null, '2016-08-26 10:04:19');
INSERT INTO `cms_content_page` VALUES ('102', 'PageAssociationNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '6', '1', '管理员', null, '2016-08-26 10:06:21');
INSERT INTO `cms_content_page` VALUES ('103', 'PageAssociationNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '7', '1', '管理员', null, '2016-08-26 10:08:01');
INSERT INTO `cms_content_page` VALUES ('104', 'PageAssociationNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '12', '1', '管理员', null, '2016-08-26 10:10:32');
INSERT INTO `cms_content_page` VALUES ('105', 'PageAssociationNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '7', '1', '管理员', null, '2016-08-26 10:14:26');
INSERT INTO `cms_content_page` VALUES ('106', 'PageLaw', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '5', '1', '管理员', null, '2016-08-26 10:39:32');
INSERT INTO `cms_content_page` VALUES ('107', 'PageLaw', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '11', '1', '管理员', null, '2016-08-26 10:40:32');
INSERT INTO `cms_content_page` VALUES ('108', 'PageLaw', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '9', '1', '管理员', null, '2016-08-26 10:41:55');
INSERT INTO `cms_content_page` VALUES ('109', 'PageLaw', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '4', '1', '管理员', null, '2016-08-26 10:43:57');
INSERT INTO `cms_content_page` VALUES ('110', 'PageLaw', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '12', '1', '管理员', null, '2016-08-26 10:50:55');
INSERT INTO `cms_content_page` VALUES ('111', 'PageAssociationNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', '~/uploads/thumb/201608/G826L1121792.jpg', null, '18', '1', '管理员', null, '2016-08-26 11:11:22');
INSERT INTO `cms_content_page` VALUES ('112', 'PageAssociationNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', '~/uploads/thumb/201608/G830Q5909920.jpg', null, '58', '1', '管理员', null, '2016-08-26 11:49:50');
INSERT INTO `cms_content_page` VALUES ('113', 'PageJobSeeker', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '12', '1', '管理员', null, '2016-08-26 13:55:43');
INSERT INTO `cms_content_page` VALUES ('114', 'PageJobSeeker', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '19', '1', '管理员', null, '2016-08-26 13:59:53');
INSERT INTO `cms_content_page` VALUES ('115', 'PageNew', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '5', '1', '管理员', null, '2016-08-30 16:31:07');
INSERT INTO `cms_content_page` VALUES ('116', 'PageLaw', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '6', '1', '管理员', null, '2016-08-30 16:31:57');
INSERT INTO `cms_content_page` VALUES ('117', 'PageConsultNews', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '10', '1', '管理员', null, '2016-08-30 16:33:07');
INSERT INTO `cms_content_page` VALUES ('118', 'PageNew', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '2', '1', '管理员', null, '2016-08-30 16:34:31');
INSERT INTO `cms_content_page` VALUES ('119', 'PageNew', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '26', '1', '管理员', null, '2016-08-30 16:36:45');
INSERT INTO `cms_content_page` VALUES ('120', 'PageNew', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '12', '1', '管理员', null, '2016-08-30 16:40:27');
INSERT INTO `cms_content_page` VALUES ('121', 'PageNew', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '13', '1', '管理员', null, '2016-08-30 16:45:10');
INSERT INTO `cms_content_page` VALUES ('122', 'PageNew', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', '~/uploads/thumb/201608/G830R0242905.jpg', null, '13', '1', '管理员', null, '2016-08-30 16:53:58');
INSERT INTO `cms_content_page` VALUES ('123', 'PageLaw', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '26', '1', '管理员', null, '2016-08-30 16:56:13');
INSERT INTO `cms_content_page` VALUES ('124', 'PageNew', '0', null, 'Iron Man, Thor, Captain America, the X-Men', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', '~/uploads/thumb/201608/G830S4449982.jpg', null, '29', '1', '管理员', null, '2016-08-30 18:43:59');
INSERT INTO `cms_content_page` VALUES ('125', 'EntHire', '0', null, 'waiter', '<p>In the end, my love for Rocket, Groot, Gamora, Star-Lord, Yondu, Mantis, Drax, and Nebula - and some of the other forthcoming heroes - goes deeper than you guys can possibly imagine, and I feel they have more adventures to go on and things to learn about themselves and the wonderful and sometimes terrifying universe we all inhabit</p>', null, null, '6', '0', '管理员', null, '2016-09-03 18:15:47');

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
  `OrderBy` int(11) DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL,
  `CreateDate` datetime NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of cms_friendlinks_info
-- ----------------------------
INSERT INTO `cms_friendlinks_info` VALUES ('8', null, '百度', null, 'http://www.baidu.com/', '0', '1', null, '管理员', '2016-03-30 01:06:52');
INSERT INTO `cms_friendlinks_info` VALUES ('9', null, '阿里巴巴', null, 'http://www.alibaba.com/', '0', '1', null, '管理员', '2016-03-30 01:07:34');
INSERT INTO `cms_friendlinks_info` VALUES ('10', null, '腾讯', null, 'http://www.tencent.com/', '0', '1', null, '管理员', '2016-03-30 01:08:42');
INSERT INTO `cms_friendlinks_info` VALUES ('11', '', '仅仅是开始', '', 'http://pcx.cn/', '0', '1', null, '管理员', '2016-03-30 01:08:42');

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
) ENGINE=InnoDB AUTO_INCREMENT=99 DEFAULT CHARSET=utf8;

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
) ENGINE=InnoDB AUTO_INCREMENT=144 DEFAULT CHARSET=utf8 COMMENT='航班时间价格表';

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
) ENGINE=InnoDB AUTO_INCREMENT=692 DEFAULT CHARSET=utf8 COMMENT='商品订单项';

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
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8 COMMENT='商品订单项';

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
) ENGINE=InnoDB AUTO_INCREMENT=132 DEFAULT CHARSET=utf8;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='操作日志表';

-- ----------------------------
-- Records of sys_action_log
-- ----------------------------

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='功能授权表';

-- ----------------------------
-- Records of sys_authorization
-- ----------------------------

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
  `IsEnabled` int(11) NOT NULL COMMENT '是否启用',
  PRIMARY KEY (`Id`),
  KEY `IDX_ConfigType` (`ConfigType`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COMMENT='系统配置表';

-- ----------------------------
-- Records of sys_config
-- ----------------------------
INSERT INTO `sys_config` VALUES ('1', null, null, 'PlatformName', 'NPiculet信息化系统开发框架', '管理员', '2017-05-10 09:11:47', '1');
INSERT INTO `sys_config` VALUES ('2', null, null, 'WebSiteName', 'NPiculet信息化系统开发框架', '管理员', '2017-05-10 09:11:47', '1');
INSERT INTO `sys_config` VALUES ('3', null, null, 'CompanyName', '', '管理员', '2017-05-10 09:11:47', '1');
INSERT INTO `sys_config` VALUES ('4', null, null, 'DomainName', '', '管理员', '2017-05-10 09:11:47', '1');
INSERT INTO `sys_config` VALUES ('5', null, null, 'ICP', '', '管理员', '2017-05-10 09:11:47', '1');
INSERT INTO `sys_config` VALUES ('6', null, null, 'Tel', '', '管理员', '2017-05-10 09:11:47', '1');
INSERT INTO `sys_config` VALUES ('7', null, null, 'ServiceTel', '', '管理员', '2017-05-10 09:11:47', '1');
INSERT INTO `sys_config` VALUES ('8', null, null, 'PostCode', '', '管理员', '2017-05-10 09:11:47', '1');
INSERT INTO `sys_config` VALUES ('9', null, null, 'EMail', '', '管理员', '2017-05-10 09:11:47', '1');
INSERT INTO `sys_config` VALUES ('10', null, null, 'Address', '', '管理员', '2017-05-10 09:11:47', '1');

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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='用户角色连接表';

-- ----------------------------
-- Records of sys_link_user_role
-- ----------------------------
INSERT INTO `sys_link_user_role` VALUES ('1', '2', '3');

-- ----------------------------
-- Table structure for sys_member_corporation
-- ----------------------------
DROP TABLE IF EXISTS `sys_member_corporation`;
CREATE TABLE `sys_member_corporation` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '编码ID',
  `UserId` int(11) DEFAULT NULL COMMENT '用户ID',
  `UserAccount` varchar(32) DEFAULT NULL COMMENT '用户账号',
  `CorporationTel` varchar(255) DEFAULT NULL COMMENT '单位电话',
  `CorporationBreifName` varchar(255) DEFAULT NULL COMMENT '经营简称',
  `CorporationNature` varchar(255) DEFAULT NULL COMMENT '企业性质',
  `BusinessLicences` varchar(255) DEFAULT NULL COMMENT '营业执照',
  `CorporationName` varchar(255) DEFAULT NULL COMMENT '单位全称',
  `ApprovalDocument` varchar(255) DEFAULT NULL COMMENT '公安审核批准文件',
  `FireSafety` varchar(255) DEFAULT NULL COMMENT '消防安全审查合格证',
  `InternetCulture` varchar(255) DEFAULT NULL COMMENT '文化许可证',
  `BodyCorporateIdView` varchar(255) DEFAULT NULL COMMENT '法人身份证复印件',
  `BodyCorporateTel` varchar(255) DEFAULT NULL COMMENT '法人电话',
  `BodyCorporateIdCard` varchar(255) DEFAULT NULL COMMENT '法人身份证',
  `BodyCorporate` varchar(255) DEFAULT NULL COMMENT '法人姓名',
  `ChargeManIdView` varchar(255) DEFAULT NULL COMMENT '负责人身份证复印件',
  `ChargeMan` varchar(255) DEFAULT NULL COMMENT '负责人姓名',
  `ChargeManTel` varchar(255) DEFAULT NULL COMMENT '负责任人联系电话',
  `ChargeManIdCard` varchar(255) DEFAULT NULL COMMENT '负责人身份证编号',
  `CorporationAddress` varchar(255) DEFAULT NULL COMMENT '公司地址',
  `longitude` varchar(255) DEFAULT NULL COMMENT '经度',
  `Altitudes` varchar(255) DEFAULT NULL COMMENT '纬度',
  `BillboardView` varchar(255) DEFAULT NULL COMMENT '招牌图片',
  `EnterView` varchar(255) DEFAULT NULL COMMENT '入口招牌',
  `AllStaffForegroundView` varchar(255) DEFAULT NULL COMMENT '全体员工合影照',
  `ChargForegroundView` varchar(255) DEFAULT NULL COMMENT '负责人吧台照',
  `ForegroundView` varchar(255) DEFAULT NULL COMMENT '前台照片',
  `HallPanoramicView` varchar(255) DEFAULT NULL COMMENT '大厅全景照',
  `HallView` varchar(255) DEFAULT NULL COMMENT '大厅照片',
  `CorporationIntro` longtext,
  `MemberLevel` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_member_corporation
-- ----------------------------
INSERT INTO `sys_member_corporation` VALUES ('2', '3', 'qy01', '000', '百度', '国内上市公司', null, '百度', null, null, null, null, null, null, null, null, '等等等', null, '2222', '多的地方', null, null, null, null, null, null, null, null, null, null, null);

-- ----------------------------
-- Table structure for sys_member_data
-- ----------------------------
DROP TABLE IF EXISTS `sys_member_data`;
CREATE TABLE `sys_member_data` (
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
  `RechargeStatus` varchar(16) DEFAULT NULL COMMENT '充值状态',
  `IsDel` int(11) DEFAULT NULL COMMENT '0',
  PRIMARY KEY (`Id`),
  KEY `IDX_UserAccount` (`UserAccount`),
  KEY `IDX_UserId` (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='用户资料表';

-- ----------------------------
-- Records of sys_member_data
-- ----------------------------
INSERT INTO `sys_member_data` VALUES ('1', '2', 'user', '野生动物', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
INSERT INTO `sys_member_data` VALUES ('2', '3', 'qy01', '企业用户', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);

-- ----------------------------
-- Table structure for sys_member_info
-- ----------------------------
DROP TABLE IF EXISTS `sys_member_info`;
CREATE TABLE `sys_member_info` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `UserSn` varchar(64) NOT NULL COMMENT '序号',
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
  `OrderBy` int(11) DEFAULT NULL,
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
INSERT INTO `sys_member_info` VALUES ('1', '9b8298e8a03d4b85b0b11e55787e0ab5', 'test', 'test', 'test', null, '个人用户', null, null, null, null, null, null, null, null, null, null, null, '1', '0', '0', null, null, null, '2017-01-01 00:00:00');
INSERT INTO `sys_member_info` VALUES ('2', '1a495283e1274e2a8dbd306bc8ad6af1', 'user', 'user', '野生动物', null, '个人用户', null, null, null, null, null, null, null, null, null, null, null, '1', '0', '0', null, null, null, '2017-01-01 00:00:00');
INSERT INTO `sys_member_info` VALUES ('3', 'e5552be4a58c4b0ea491ebeef07e6fdc', 'qy01', 'qy01', '企业用户', null, '企业用户', null, null, null, null, null, null, null, null, null, null, null, '1', '0', '0', null, null, null, '2017-01-01 00:00:00');

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
  `Type` int(11) DEFAULT NULL COMMENT '类型',
  `Depth` int(11) DEFAULT NULL COMMENT '深度',
  `IsExternal` int(11) DEFAULT NULL COMMENT '使用外部链接',
  `Url` longtext COMMENT '页面地址',
  `Target` varchar(32) DEFAULT NULL COMMENT '目标',
  `Comment` longtext COMMENT '备注',
  `OrderBy` int(11) DEFAULT NULL COMMENT '排序',
  `IsEnabled` int(11) NOT NULL COMMENT '是否启用',
  `IsDel` int(11) NOT NULL COMMENT '是否已删除',
  `Creator` varchar(32) DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`),
  KEY `IDX_ParentId` (`ParentId`),
  KEY `IDX_OrderBy` (`OrderBy`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8 COMMENT='系统菜单表';

-- ----------------------------
-- Records of sys_menu
-- ----------------------------
INSERT INTO `sys_menu` VALUES ('1', '0', '0', '', '系统管理', '', '', '0', '0', '0', '', 'mainFrame', '', '900', '1', '0', '', '2014-04-14 16:11:38');
INSERT INTO `sys_menu` VALUES ('2', '1', '1', '/1', '系统设置', '', '', '0', '1', '0', '', 'mainFrame', '', '200', '1', '1', '', '2014-04-14 16:11:38');
INSERT INTO `sys_menu` VALUES ('3', '7', '1', '/1/7', '字典分组管理', '', '', '0', '2', '0', 'system/DictGroupList.aspx', 'mainFrame', '', '100', '1', '0', '', '2014-04-14 16:43:25');
INSERT INTO `sys_menu` VALUES ('4', '7', '1', '/1/7', '字典数据管理', '', '', '0', '2', '0', 'system/DictItemList.aspx', 'mainFrame', '', '110', '1', '0', '', '2014-04-14 16:44:05');
INSERT INTO `sys_menu` VALUES ('5', '7', '1', '/1/7', '功能管理', '', '', '0', '2', '0', 'system/MenuSet.aspx', 'mainFrame', '', '0', '1', '0', '', '2014-04-14 16:11:38');
INSERT INTO `sys_menu` VALUES ('6', '7', '1', '/1/7', '系统配置项', '', '', '0', '2', '0', 'system/ConfigSet.aspx', 'mainFrame', '', '999', '1', '0', '', '2014-04-14 17:56:16');
INSERT INTO `sys_menu` VALUES ('7', '1', '1', '/1', '系统管理', '', '', '0', '1', '0', '', 'mainFrame', '', '9999', '1', '0', '', '2014-04-14 16:33:30');
INSERT INTO `sys_menu` VALUES ('8', '7', '1', '/1/7', '用户管理', '', '', '0', '2', '0', 'system/UserList.aspx', 'mainFrame', '', '20', '1', '0', '', '2014-04-14 16:33:30');
INSERT INTO `sys_menu` VALUES ('9', '7', '1', '/1/7', '角色管理', '', '', '0', '2', '0', 'system/RoleList.aspx', 'mainFrame', '', '40', '1', '0', '', '2014-04-14 17:56:46');
INSERT INTO `sys_menu` VALUES ('10', '7', '1', '/1/7', '机构管理', '', '', '0', '2', '0', 'system/OrgSet.aspx', 'mainFrame', '', '10', '1', '0', '', '2014-04-14 17:57:00');
INSERT INTO `sys_menu` VALUES ('11', '0', '0', '', '会员管理', '', '', '0', '0', '0', '', 'mainFrame', '', '100', '1', '1', '管理员', '2014-12-26 16:21:44');
INSERT INTO `sys_menu` VALUES ('12', '11', '11', '/11', '会员管理', '', '', '0', '1', '0', 'member/MemberList.aspx', 'mainFrame', '', '10', '1', '1', '管理员', '2014-12-26 16:21:51');
INSERT INTO `sys_menu` VALUES ('13', '12', '11', '/11/12', '会员管理', '', '', '0', '2', '0', 'member/MemberList.aspx', 'mainFrame', '', '10', '1', '1', '管理员', '2014-12-26 16:22:08');
INSERT INTO `sys_menu` VALUES ('14', '0', '0', '', '系统管理', '', '', '0', '0', '0', '', 'mainFrame', '', '900', '1', '1', '管理员', '2015-11-05 23:25:40');
INSERT INTO `sys_menu` VALUES ('15', '1', '1', '/1', '基础数据管理', '', '', '0', '1', '0', '', 'mainFrame', '', '900', '1', '0', '管理员', '2015-11-05 23:26:55');
INSERT INTO `sys_menu` VALUES ('16', '15', '1', '/1/15', '项目状态字典', '', '', '0', '2', '0', 'system/DictItemList.aspx?group=ProjectState&fix=true&cols=分组,名称,编码,下一环节编码', 'mainFrame', '', '50', '1', '0', '管理员', '2015-11-28 11:50:44');
INSERT INTO `sys_menu` VALUES ('17', '1', '1', '/1', '栏目配置', '', '', '0', '1', '0', '', 'mainFrame', '', '100', '1', '0', '管理员', '2016-03-12 15:15:43');
INSERT INTO `sys_menu` VALUES ('18', '17', '1', '/1/17', '广告管理', 'RecBrand', '', '0', '2', '0', 'info/AdvList.aspx?code=adv', 'mainFrame', '', '10', '1', '0', '管理员', '2016-03-12 15:16:36');
INSERT INTO `sys_menu` VALUES ('19', '7', '1', '/1/7', '栏目配置', '', '', '0', '2', '0', 'info/InfoGroupSet.aspx', 'mainFrame', '配置栏目', '998', '1', '0', '管理员', '2016-03-12 15:40:18');
INSERT INTO `sys_menu` VALUES ('20', '17', '1', '/1/17', '政策文件', 'PagePolicy', '', '0', '2', '0', 'info/InfoPageList.aspx?code=PagePolicy', 'mainFrame', '', '2', '1', '0', '管理员', '2016-03-12 16:19:26');
INSERT INTO `sys_menu` VALUES ('21', '17', '1', '/1/17', '协会动态', 'PageAssociationNews', '', '0', '2', '0', 'info/InfoPageList.aspx?code=PageAssociationNews', 'mainFrame', '', '3', '1', '0', '管理员', '2016-03-13 14:39:28');
INSERT INTO `sys_menu` VALUES ('22', '17', '1', '/1/17', '综合资讯', 'PageConsultNews', '', '0', '2', '0', 'info/InfoPageList.aspx?code=PageConsultNews', 'mainFrame', '', '4', '1', '0', '管理员', '2016-03-13 14:39:56');
INSERT INTO `sys_menu` VALUES ('23', '17', '1', '/1/17', '会员展示', 'PageAssociatorShow', '', '0', '2', '0', 'info/InfoPageList.aspx?code=PageAssociatorShow', 'mainFrame', '', '5', '1', '0', '管理员', '2016-03-13 14:40:15');
INSERT INTO `sys_menu` VALUES ('24', '17', '1', '/1/17', '法律专栏', 'PageLaw', '', '0', '2', '0', 'info/InfoPageList.aspx?code=PageLaw', 'mainFrame', '', '6', '1', '0', '管理员', '2016-03-13 14:40:30');
INSERT INTO `sys_menu` VALUES ('25', '17', '1', '/1/17', '网吧培训', 'PageBar', '', '0', '2', '0', 'info/InfoPageList.aspx?code=PageBar', 'mainFrame', '', '7', '1', '0', '管理员', '2016-03-13 14:40:48');
INSERT INTO `sys_menu` VALUES ('26', '17', '1', '/1/17', '人才库', 'PageJobSeeker', '', '0', '2', '0', 'info/InfoPageList.aspx?code=PageJobSeeker', 'mainFrame', '', '8', '1', '0', '管理员', '2016-03-13 14:41:04');
INSERT INTO `sys_menu` VALUES ('27', '17', '1', '/1/17', '新闻', 'PageNew', '', '0', '2', '0', 'info/InfoPageList.aspx?code=PageNew', 'mainFrame', '', '1', '1', '0', '管理员', '2016-03-15 17:29:39');
INSERT INTO `sys_menu` VALUES ('28', '17', '1', '/1/17', '友情链接', 'friendslinks', '', '0', '2', '0', 'info/LinksList.aspx?code=links', 'mainFrame', '', '12', '1', '0', '管理员', '2016-03-23 20:42:19');
INSERT INTO `sys_menu` VALUES ('29', '1', '1', '/1', '会员管理', '', '', '0', '1', '0', '', 'mainFrame', '', '500', '1', '0', '管理员', '2016-03-26 11:58:19');
INSERT INTO `sys_menu` VALUES ('30', '29', '1', '/1/29', '企业会员管理', '', '', '0', '2', '0', 'member/EntMemberList.aspx', 'mainFrame', '', '10', '1', '0', '管理员', '2016-03-26 11:58:40');
INSERT INTO `sys_menu` VALUES ('31', '29', '1', '/1/29', '个人会员管理', '', '', '0', '2', '0', 'member/MemberList.aspx', 'mainFrame', '', '20', '1', '0', '管理员', '2016-04-26 23:29:12');
INSERT INTO `sys_menu` VALUES ('32', '17', '1', '/1/17', '企业招聘', 'EntHire', '', '0', '2', '0', 'info/InfoPageList.aspx?code=EntHire', 'mainFrame', '', '9', '1', '0', '管理员', '2016-04-28 10:49:23');
INSERT INTO `sys_menu` VALUES ('33', '29', '1', '/1/29', '个人注册协议', '', '', '0', '2', '0', 'info/InfoContentEdit.aspx?type=Content&code=MemberProtocol', 'mainFrame', '', '40', '1', '0', '管理员', '2016-05-18 22:06:33');
INSERT INTO `sys_menu` VALUES ('34', '29', '1', '/1/29', '企业注册协议', '', '', '0', '2', '0', 'info/InfoContentEdit.aspx?type=Content&code=EntProtocol', 'mainFrame', '', '30', '1', '0', '管理员', '2016-05-18 22:06:59');
INSERT INTO `sys_menu` VALUES ('35', '17', '1', '/1/17', '栏目配置', '', '', '0', '2', '0', 'info/InfoGroupSet.aspx', 'mainFrame', '', '100', '0', '0', '管理员', '2016-08-22 18:31:11');
INSERT INTO `sys_menu` VALUES ('36', '17', '1', '/1/17', '网吧交易区', 'Sale', '', '0', '2', '0', 'info/InfoPageList.aspx?code=Sale', 'mainFrame', '', '12', '1', '0', '管理员', '2016-08-23 09:56:40');

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
  `OrderBy` int(11) DEFAULT NULL COMMENT '排序',
  `IsEnabled` int(11) NOT NULL COMMENT '是否启用',
  `IsDel` int(11) NOT NULL COMMENT '是否已删除',
  `Creator` varchar(32) DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`),
  KEY `IDX_GroupCode` (`GroupCode`),
  KEY `IDX_IsEnabled` (`IsEnabled`),
  KEY `IDX_IsDel` (`IsDel`),
  KEY `IDX_OrderBy` (`OrderBy`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='组织机构表';

-- ----------------------------
-- Records of sys_org_info
-- ----------------------------
INSERT INTO `sys_org_info` VALUES ('1', 'Default', '0', '0', '', 'pcx.cn', '', '1', 'pcx.cn', 'pcx.cn', '0', null, null, '', '0', '1', '0', '管理员', '2016-03-10 23:46:31');

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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='角色信息';

-- ----------------------------
-- Records of sys_role_info
-- ----------------------------
INSERT INTO `sys_role_info` VALUES ('1', null, '系统管理员', '', '1', '0', '管理员', '2016-03-10 15:51:50');

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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='用户资料表';

-- ----------------------------
-- Records of sys_user_data
-- ----------------------------
INSERT INTO `sys_user_data` VALUES ('1', '1', 'admin', '', '', '', '', '', '', null, null, '', '', null, null, null, null, null, null, null, null, null, null, '0');

-- ----------------------------
-- Table structure for sys_user_info
-- ----------------------------
DROP TABLE IF EXISTS `sys_user_info`;
CREATE TABLE `sys_user_info` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `UserSn` varchar(64) NOT NULL COMMENT '序号',
  `Type` int(11) DEFAULT NULL COMMENT '自定义类型',
  `Account` varchar(32) NOT NULL COMMENT '帐号',
  `Password` varchar(32) NOT NULL COMMENT '密码',
  `Name` varchar(32) NOT NULL COMMENT '名称',
  `OrgId` int(11) DEFAULT NULL COMMENT '所属部门',
  `LoginTimes` int(11) DEFAULT NULL COMMENT '登录次数',
  `LastLoginDate` datetime DEFAULT NULL COMMENT '最后登入时间',
  `LastLogoutDate` datetime DEFAULT NULL COMMENT '最后登出时间',
  `FailedCount` int(11) DEFAULT NULL COMMENT '登陆错误次数',
  `FailedDate` datetime DEFAULT NULL COMMENT '登陆错误时间',
  `OrderBy` int(11) DEFAULT NULL,
  `IsEnabled` int(11) NOT NULL COMMENT '是否启用',
  `IsDel` int(11) NOT NULL COMMENT '是否已删除',
  `Updater` varchar(32) DEFAULT NULL,
  `UpdateDate` datetime DEFAULT NULL,
  `Creator` varchar(32) DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`),
  KEY `IDX_Account` (`Account`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='用户表';

-- ----------------------------
-- Records of sys_user_info
-- ----------------------------
INSERT INTO `sys_user_info` VALUES ('1', 'admin', '0', 'admin', '123', '管理员', null, null, null, null, null, null, '0', '1', '0', null, null, null, null);
