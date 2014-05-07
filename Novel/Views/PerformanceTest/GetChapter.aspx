<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>


<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Performance Test
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <%: ViewData["NovelChapter"]%>
</asp:Content>
