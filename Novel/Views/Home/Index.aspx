<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Novel.Master"  Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <title><%=ConfigurationManager.AppSettings["WebsiteName"]%></title>
    <meta name="keywords" content="<%=ConfigurationManager.AppSettings["WebsiteName"]%>" />
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">


<div id="left">

<div class="block">
<div class="blocktitle">小说阅读榜</div>
<div class="blockcontent"><ul class="ultop">

  <%foreach (var item in (List<Model.NovelInfo>)ViewData["TopViewNovels"]){%>
  <li><a href="<%=item.NovelUrl %>" target="_blank"><%=item.NovelName %></a></li>
  <%} %>

</ul></div>
</div>

<div class="block">
<div class="blocktitle">最新完结小说</div>
<div class="blockcontent"><ul class="ultop">

  <%foreach (var item in (List<Model.NovelInfo>)ViewData["FinishedNovels"]){%>
  <li><a href="<%=item.NovelUrl %>" target="_blank"><%=item.NovelName %></a></li>
  <%} %>

</ul></div>
</div>
  
</div>


<div id="centers">

<div class="block">
<div class="blockcontent"><ul class="bg222">

<%foreach (var item in (List<Model.NovelInfo>)ViewData["ImageNovels"])
  { %>
<li class="qianglei_ul"> 
    <a href="<%=item.NovelUrl %>" target="_blank" class="imga">
        <img src="<%=item.NovelImage %>" border="0" width="100" height="125" alt="<%=item.NovelName %>">
    </a> 
    <p class="name"> <a href="<%=item.NovelUrl %>" target="_blank">《<%=item.NovelName %>》</a><p> 
    <em><%=item.NovelDesc %></em> 
</li>
<%} %>
  
</ul> 
<div style="clear:both"></div></div>
</div>


<div class="block">
<div class="blocktitle"><div class="blocktitlel">[ 最新小说更新列表 ]</div><div class="blocktitler"> </div></div>
<div class="blockcontent"><ul class="ulmul" style="width:100%">
<%foreach (var item in (List<Model.ChapterInfo>)ViewData["LatestChapters"])
  { %>
<li class="fl lm" style="width:70%;">[<%=item.Novel.NovelCategory.CategoryName %>] 《
    <a class="poptext" href="<%=item.Novel.NovelUrl %>" target="_blank"><%=item.Novel.NovelName %></a>》 
    <a href="<%=item.ChapterUrl %>" target="_blank"><%=item.ChapterName %></a>
</li>
<li class="fr tr" style="width:30%;"><%=item.Novel.NovelAuthor %></li>

<%} %>

</ul></div>
</div>

</div>


<div id="right">

<div class="block">
<div class="blocktitle"><div class="blocktitlel">小说推荐榜</div><div class="blocktitler">  </div></div>
<div class="blockcontent"><ul class="ultop">

  <%foreach (var item in (List<Model.NovelInfo>)ViewData["SuggestNovels"]){%>
  <li><a href="<%=item.NovelUrl %>" target="_blank"><%=item.NovelName %></a></li>
  <%} %>

</ul></div>
</div>

<div class="block">
<div class="blocktitle"><div class="blocktitlel">最新入库小说</div><div class="blocktitler">  </div></div>
<div class="blockcontent"><ul class="ultop">

  <%foreach (var item in (List<Model.NovelInfo>)ViewData["LatestNovels"]){%>
  <li><a href="<%=item.NovelUrl %>" target="_blank"><%=item.NovelName %></a></li>
  <%} %>

</ul></div>
</div>

</div>

</asp:Content>