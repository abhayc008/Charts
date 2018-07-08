<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Validation.aspx.cs" Inherits="HighStocks.Validation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .modalbg{
             opacity:0.4;
             background-color:black; 
        }
    </style>
    <asp:Panel ID="pnlgrid" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Program_Name" HeaderText="Program" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnk" runat="server" CommandArgument="<%=Id %>" CommandName="REDIRECT">Redirect</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </asp:Panel>
    <asp:HiddenField ID="hdn1" runat="server" />
    <cc1:ModalPopupExtender ID="modalgrd" runat="server" TargetControlID="hdn1" PopupControlID="pnlgrid" BackgroundCssClass="modalbg" >
    </cc1:ModalPopupExtender>

    <div>
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
                </td>
            </tr>
            <tr>

                <td><span>Years in City(YY/MM)</span>
                    <asp:TextBox ID="TextBox2" runat="server" placeholder="YY/MM"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender runat="server" TargetControlID="TextBox2" MaskType="None" ClearMaskOnLostFocus="false" Mask="99\/99"></ajaxToolkit:MaskedEditExtender>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAddClass" runat="server" Text="AddClass" />
                    <asp:Button ID="btnRemoveClass" runat="server" Text="RemoveClass" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <embed src="Content/Test.pdf" width="500" height="375">
    </div>
    <style>
        .customErrorBorder {
            border: 1px solid red;
        }
    </style>
    <script>
        $(document).ready(function () {

        });

        function fnaddClass() {
            debugger;
            $('#<%=TextBox1.ClientID%>').addClass('customErrorBorder');
            $('#<%=DropDownList1.ClientID%>').addClass('customErrorBorder');


            return false;

        };

        $('#<%=btnAddClass.ClientID%>').click(function (e) {
            $('#<%=TextBox1.ClientID%>').addClass('customErrorBorder');
            $('#<%=DropDownList1.ClientID%>').addClass('customErrorBorder');
            e.preventDefault();
            e.stopPropagation();
        });
        $('#<%=btnRemoveClass.ClientID%>').click(function (e) {
            $('.customErrorBorder').removeClass('customErrorBorder');
            $('#<%=TextBox1.ClientID%>').removeClass('customErrorBorder');
            $('#<%=DropDownList1.ClientID%>').removeClass('customErrorBorder');
            e.preventDefault();
            e.stopPropagation();
        });

    </script>



</asp:Content>
