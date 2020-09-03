<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="PasswordRecovery.aspx.vb" Inherits="CWMS_DOC_2015.PasswordRecovery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" AnswerLabelText="解答："
        AnswerRequiredErrorMessage="解答不可省略" BackColor="#FFFBD6" BorderColor="#FFDFAD" BorderPadding="4"
        BorderStyle="Double" BorderWidth="1px" Font-Names="Verdana" Font-Size="1.0em" GeneralFailureText="查詢失敗，請重試。"
        QuestionFailureText="解答錯誤，請重試。" QuestionInstructionText="請回答以下問題才能查詢密碼"
        QuestionLabelText="安全性問題：" QuestionTitleText="身份確認" SuccessText="密碼已經寄到您註冊的 E-mail 信箱，請前往查收。"
        UserNameFailureText="您輸入的使用者名稱錯誤，請再試試。" UserNameInstructionText="請輸入您的使用者名稱來查詢密碼" UserNameLabelText="使用者名稱："
        UserNameRequiredErrorMessage="使用者名稱不可省略" UserNameTitleText="忘記密碼？" Width="400px">
        <MailDefinition BodyFileName="~/Login/PassReset/RecoveryMail.txt" From="a0-cwms@epa.gov.tw" IsBodyHtml="True"
          Priority="High" Subject="密碼通知">
        </MailDefinition>
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <SuccessTextStyle Font-Bold="True" ForeColor="#990000" />
        <TextBoxStyle Font-Size="1.0em" />
        <TitleTextStyle BackColor="#990000" Font-Bold="True" Font-Size="1.2em" ForeColor="White" />
        <SubmitButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px"
          Font-Names="Verdana" Font-Size="1.0em" ForeColor="#990000" />
      </asp:PasswordRecovery>
</asp:Content>
