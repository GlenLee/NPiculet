# NPiculet B/S Framework

## 这是什么？

实现此框架的初衷是因为在十多年软件开发的积累中，为数十个项目开发过多个信息化框架，我希望能实现这样的一个框架：

1. 支持企业内部信息化管理系统的开发。
1. 支持商业网站项目开发，实现一站整合管理。
1. 面向开发简单，团队可以快速上手无需太多学习成本。

在我看来，开源世界中缺少一个简单实用的 .Net 框架，DNN类框架庞大臃肿，使得难以学习和扩展；专业建站系统功能单一，难以满足通用性要求；并且大部分开源系统面向开发者并不友好，很多代码只有作者自己能理解，陷阱多且学习成本高。功能强大的同时要把简化开发做到极致，才是这个框架的终极目标，时至今日糅合和舍弃了无数想法，框架算是基本实现了初衷。

## 有什么优势？

1. 极速开发，框架以开发为主导，非常简单易用，企业业务开发减少60%开发量，CMS网站开发减少90%开发量。
1. 功能强大，包含常见信息框架的所有用户管理、角色管理、授权管理、组织管理、信息管理等功能。
1. 结构简单，项目结构经过精心考虑，数年的发展让结构非常精简又能满足所有开发要求。
1. 性能卓越，满足互联网网站访问的需求，所有模块均有良好的性能，所有页面响应时间均低于1s。
1. 扩展容易，尽量采用原生的ASP.Net结构，新手老手都能用的得心应手。
1. 基于EF，抛弃了自构的数据层，采用EF更加简单和通用，且功能比许多自构数据层更强大。
1. 健壮可靠，在数十个实际项目中实践，各项已有功能均趋于完善。

## 支持功能

### 针对企业：
角色、用户、组织机构、菜单、权限、会员、配置管理等功能，在内控管理、电子沙盘、项目管理、机场管理等项目中实践过。

### 针对网站
会员管理（与后台用户独立，不混合），并自带一套前端CMS网站系统，在企业官网、微信网站、电子商务网、P2P金融网、政府官网、游戏网等项目中实践过。

## BSD开源授权

采用BSD开源授权，你可以最大程度的使用源码进行商业开发或发布开源项目，只要求保留原版权文件。

## 关于名字

为什么叫NPiculet（姬啄木鸟）？

- 首先，“N”表示这是一个面向 .Net 的框架；
- 其次，程序员天生为“捉虫”而生；
- 最后，似乎没有框架叫这个名字，至少有一点独特性。

## 已发布 2.x 版本

- 关于更新频次，每月发布一个更新版本。
- 开发版会含有未解决的BUG，请尽量下载发布的稳定版本。

## 目录结构

项目为了结构清晰，分为了两个部分：
- Framework 是框架底层：主要实现状态处理、数据访问基础类、日志工具、插件基础类、常用工具类等。
- Runtime 是业务逻辑：包含实际的业务逻辑，后台可用作企业信息化管理，前端是带会员管理的CMS系统。

## 未来计划

1. 操作更直观的菜单模块、栏目模块；
1. 增加微网站及微信管理功能；
1. 其实当前版本已经包含电商功能，但还没有整理完，所以暂未上线，下一步将整理添加；
1. 逐步完善开发说明书。
