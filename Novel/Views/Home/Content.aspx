<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<% var content = ViewData["Content"] as Model.ChapterInfo;
     %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title><%=content.ChapterName %> / <%=content.Novel.NovelType %><%=content.Novel.NovelName %></title>
<meta http-equiv="Content-Type" content="text/html; charset=gbk" />
<meta name="keywords" content="<%=content.ChapterName %>,<%=content.Novel.NovelName %>" />
<meta name="description" content="<%=content.Novel.NovelType %><%=content.Novel.NovelName %>最新章节<%=content.ChapterName %>免费在线阅读，<%=ConfigurationManager.AppSettings["WebsiteName"]%>无讨厌的弹窗广告。" />
<link href="/style/c.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/style/c.js"></script>
</head>
<body id="html">
<div id="header"><div id="menu"><table width="100%"><tbody><tr>
<td class="tddh"><a href="<%=content.PreviousChapterUrl %>">上一章</a></td>
<td class="tddh"><a href="<%=content.Novel.NovelUrl %>">返回书目</a></td>
<td class="tddh"><a href="<%=content.NextChapterUrl %>">下一章</a></td>

</tr></tbody></table></div>
<div id="mainbav"><div id="leftsidebar">&nbsp;&nbsp;<a href="http://www.cxzww.com/"><%=ConfigurationManager.AppSettings["WebsiteName"]%></a>&nbsp;&raquo;&nbsp;<a href="<%=content.Novel.NovelTypeUrl %>"><%=content.Novel.NovelType %></a>&nbsp;&raquo;&nbsp;<a href="<%=content.Novel.NovelUrl %>"><%=content.Novel.NovelName %></a>&nbsp;&raquo;&nbsp;<%=content.ChapterName %></div>
<div id="rightsidebar"></div></div></div>
<h1><%=content.ChapterName %></h1>
<div id="content">
<%=content.ChapterContent %>
</div>
<div id="link"><a href="#">推荐本书</a><a href="<%=content.Novel.NovelUrl %>" target="_blank">加入书签</a><a href="<%=content.PreviousChapterUrl %>">上一章</a><a href="<%=content.Novel.NovelUrl %>">目 录</a><a href="<%=content.NextChapterUrl %>">下一章</a></div>
<div id="copyright">本网站提供的小说《<a href="<%=content.Novel.NovelUrl %>"><b>极品老师</b></a>》版权为原作者所有。为了更好的阅读体验请到各大书店或网店购买正版小说。<br />Copyright <%=DateTime.Now.Year %>  All Rights Reserved <%=ConfigurationManager.AppSettings["WebsiteName"]%></div>
<script type="text/javascript">    var preview_page = "<%=content.PreviousChapterUrl %>"; var next_page = "<%=content.NextChapterUrl %>"; var index_page = "/";  function jumpPage() { var event = document.all ? window.event : arguments[0]; if (event.keyCode == 37) document.location = preview_page; if (event.keyCode == 39) document.location = next_page; if (event.keyCode == 13) document.location = index_page; } document.onkeydown = jumpPage;</script>
</body></html>
