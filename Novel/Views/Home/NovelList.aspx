<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Novel.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <title><%=ConfigurationManager.AppSettings["WebsiteName"]%></title>
    <meta name="keywords" content="<%=ConfigurationManager.AppSettings["WebsiteName"]%>" />
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="main m_center">

  <div id="centerl">


<div id="content">
<table class="grid" width="100%" align="center">
  <tbody><tr align="center">
    <th width="20%">文章名称</th>
    <th width="49%">最新章节</th>
    <th width="15%">作者</th>
    <th width="10%">更新</th>
    <th width="6%">状态</th>
  </tr>
  
  <%foreach (var item in (List<Model.ChapterInfo>)ViewData["NovelList"])
    {%>
  <tr>
    <td class="odd"><a href="<%= item.Novel.NovelUrl%>"><%= item.Novel.NovelName%></a></td>
    <td class="even"><a href="<%= item.ChapterUrl %>" target="_blank"><%= item.ChapterName%></a></td>
    <td class="odd"><%= item.Novel.NovelAuthor%></td>
    <td class="even" align="center"><%=item.Novel.LatestUpdateDate%></td>
    <td class="odd" align="center"><%=item.Novel.IsFinished%></td>
  </tr>
  <%} %>
  
  
</tbody></table>
<div class="pages"><div class="pagelink" id="pagelink"><em id="pagestats">1/545</em><a href="http://www.cxzww.com/sortid_3/1/" class="first">1</a><a href="http://www.cxzww.com/sortid_3/1/" class="pgroup">&lt;&lt;</a><strong>1</strong><a href="http://www.cxzww.com/sortid_3/2/">2</a><a href="http://www.cxzww.com/sortid_3/3/">3</a><a href="http://www.cxzww.com/sortid_3/4/">4</a><a href="http://www.cxzww.com/sortid_3/5/">5</a><a href="http://www.cxzww.com/sortid_3/6/">6</a><a href="http://www.cxzww.com/sortid_3/7/">7</a><a href="http://www.cxzww.com/sortid_3/8/">8</a><a href="http://www.cxzww.com/sortid_3/9/">9</a><a href="http://www.cxzww.com/sortid_3/10/">10</a><a href="http://www.cxzww.com/sortid_3/2/" class="next">&gt;</a><a href="http://www.cxzww.com/sortid_3/16/" class="ngroup">&gt;&gt;</a><a href="http://www.cxzww.com/sortid_3/545/" class="last">545</a><kbd><input name="page" type="text" size="4" maxlength="6" onkeydown="if(event.keyCode==13){window.location='http://www.cxzww.com/sortid_3/&lt;{$page}&gt;/'.replace('&lt;{$page|subdirectory}&gt;', '/' + Math.floor(this.value / 1000)).replace('&lt;{$page}&gt;', this.value); return false;}"></kbd></div></div></div>

</div>




<div style="clear:both;"></div>
</div>

</asp:Content>
