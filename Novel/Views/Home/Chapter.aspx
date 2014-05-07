<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<%var chapterInfo=(Model.ChapterInfo)ViewData["ChapterInfo"]; %>
<title><% =chapterInfo.Novel.NovelName%>无弹窗_<% =chapterInfo.Novel.NovelName%>全文阅读_<%=ConfigurationManager.AppSettings["WebsiteName"]%></title>
<meta http-equiv="Content-Type" content="text/html; charset=gbk" />
<meta name="keywords" content="<% =chapterInfo.Novel.NovelName%>" />
<meta name="description" content="<% =chapterInfo.Novel.NovelName%>全文作者是<% =chapterInfo.Novel.NovelAuthor%>，<%=ConfigurationManager.AppSettings["WebsiteName"]%>免费提供在线<% =chapterInfo.Novel.NovelType%><% =chapterInfo.Novel.NovelName%>全文阅读，在这里<% =chapterInfo.Novel.NovelName%>无弹窗阅读更畅快。" />
<link href="/style/c.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/style/c.js"></script>
</head>
<body>
<div id="header">
<div id="menu"><table width="100%"><tbody><tr>
<td align="left" height="23">&nbsp;&nbsp;<% =chapterInfo.Novel.NovelName%>&bull;<% =chapterInfo.Novel.NovelAuthor%></td>
<td class="tddh"><a href="<% =chapterInfo.Novel.NovelUrl%>">返回书页</a></td>
</tr></tbody></table></div>
<div id="mainbav">	 
<div id="leftsidebar">&nbsp;&nbsp;<a href="<%=ConfigurationManager.AppSettings["WebsiteUrl"]%>"><%=ConfigurationManager.AppSettings["WebsiteName"]%></a>&nbsp;&raquo;&nbsp;<a href="<% =chapterInfo.Novel.NovelTypeUrl%>"><% =chapterInfo.Novel.NovelType%></a>&nbsp;&raquo;&nbsp;<% =chapterInfo.Novel.NovelName%>全文阅读</div>
</div></div>
<div id="title"><h1><% =chapterInfo.Novel.NovelName%></h1></div>
<div id="msg">作者：<% =chapterInfo.Novel.NovelAuthor%> | 类型：<% =chapterInfo.Novel.NovelType%> | 最新：<a href="<% =chapterInfo.ChapterUrl%>"><% =chapterInfo.ChapterName%></a></div>
<div id="list">
<dl>

<%foreach (var item in (List<Model.ChapterInfo>)ViewData["Chapters"])
  {
      if (item.IsSubTitle)
      {%>
      <dt><% =item.ChapterName%></dt>
      <%}
      else
      { %>
      <dd><a href="<% =item.ChapterUrl %>"><% =item.ChapterName%></a></dd>
      <%} %>
<%} %>


</dl></div>  
<div id="copyright"><br />如果您喜欢,请把<strong>《<% =chapterInfo.Novel.NovelName%>》</strong>加入书架</a>,方便以后阅读<strong><% =chapterInfo.Novel.NovelName%></strong>更新连载.<br /><% =chapterInfo.Novel.NovelName%>全文阅读仅代表作者<% =chapterInfo.Novel.NovelAuthor%>的观点，不代表网站立场，有任何疑问，请与联系作者。<br />如发现<% =chapterInfo.Novel.NovelName%>全文阅读内容有与法律抵触之处或含有低俗内容，请马上向网站举报。<br />
</body></html>
