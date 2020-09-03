<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" Inherits="CWMS_DOC_2015.EPADAHS_EPADAHS" Codebehind="EPADAHS.aspx.vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 194px;
        }
        .style3
        {
        }
        .style4
        {
            width: 427px;
        }
        .style5
        {
            width: 14px;
        }
        .style6
        {
            width: 96px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3" colspan="4">
                <p class="MsoNormal">
                    &nbsp;</p>
                <p class="MsoNormal">
                    試辦環保署版 資料獲取及傳輸模組 (EPA DAHS)</p>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="txt">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
                <asp:Image ID="Image4" runat="server" Height="100px" Width="96px" 
                    ImageUrl="~/Images/LEAVE.GIF" />
            </td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                一、緣由<span><br />
                <br />
                我國連續自動監測設施管理辦法並未統一公私場所之監測設施之儀控系統與數據擷取與處理系統<span lang="EN-US">(DAHS)</span>間之介面，導致主管機關無法完全信任由公私場所自行發展之資料獲取及處理程式，公私場所也因法規變動，必須花費成本進行資料獲取及處理程式修改並進行驗證，本項作業主要為強化「連續自動監測設施」數據防弊，整合全國監測數據傳輸至中央，提昇監測數據管理正確性及效率之方式，提升公私場所之監測儀器與數據擷取與處理系統之可信度、監測數據管理正確性及效率並將低公私場所配合法規運轉連續自動監測設施之成本。</span></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
                <asp:Image ID="Image3" runat="server" Height="100px" Width="96px" 
                    ImageUrl="~/Images/Pol100x100.jpg" />
            </td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                <span><br />
                <br />
                二、示範目的<br />
                <br />
                評估環保署版 資料獲取及傳輸模組 ( EPA DAHS ) 運作可靠度及可行性，作為後續推廣之評估。</span></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                &nbsp;
                <span>三、 EPA DAHS
                </span>規劃<br />
                <br />
                如圖 :
                <br />
                <span lang="EN-US"><span>(一)&nbsp;</span>Internet</span><span>通訊界面<br />
                將整合現有之「<span lang="EN-US">CEMS </span>傳輸模組」功能，並負責公私場所端監測數據防弊整合模組（<span 
                    lang="EN-US">EPA DAHS</span>）系統對外傳遞資訊使用，對象包含環保署主機或者環保局主機、公私場所控制中心等對象，亦有可能負責接收來自主管機關之指令，例如版本更新、時間校正、標準值調整及資料重傳等指令。<br />
                <br />
                <span lang="EN-US">(二)EPA DAHS</span>主系統<br />
                主系統為<span lang="EN-US">EPA DAHS</span>之核心模組，統籌控管所有模組或界面之作業，這包括了資料處理、資料儲存、資料顯示及操作設計等功能，均在主核心模組中設計實現。目前規劃的細部規格如<span 
                    lang="EN-US">3.2.4 </span>節<span lang="EN-US">-- EPA DAHS</span>功能描述。<br />
                <br />
                <span lang="EN-US">(三)Open Interface<br />
                EPA DAHS將與各廠牌通訊格式元件間之通訊(Communication)當作是一個個服務請求(Service 
                Request)來看待，因此制定一個界面專門處理與外界元件的溝通，如呼叫方式、參數定義、數值回送方式，以提供公私場所儀控設備通訊格式通訊之用。<br />
                <br />
                儀控設備通訊格式函式庫由儀器儀控製造商提供，(如呼叫方式、參數定義、數值回送方式等，採開放架構)以動態連結函式庫(*.DLL)的型式提供，經測試確認後，整合至EPA 
                DAHS的函式庫中。<br />
                <br />
                目前我們所發展的EPA DAHS已支援Modbus / TCP 協定，可利用標準TCP / IP 網路，連結第三方支援Modbus / TCP的I/O 
                模組，進行資料擷取與通訊控制。<br />
                <br />
                (四)訊號接收<br />
                依前述通訊格式，接收儀控設備回傳之訊號。<br />
                <br />
                (五)實際訊號比對擴充界面<br />
                此界面是規劃實作與實際訊號比對之接入界面，在有必要時可從污染源之分析儀處直接併接訊號源之訊號與原資料管道作比較，為最直接之比對方式。<br />
                </span></span>
                <br />
                <br />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/DAHS.jpg" 
                    Width="400px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                四、示範對象徵求<br />
                <br />
                我們成摯邀請符合以下三個條件的公私場所，加入我們試辦的行列:<br />
                <br />
                (1) 裝設連續自動監測設施(CEMS)<br />
                (2) 監測設施(CEMS) 使用支援 <span lang="EN-US">Modbus / TCP的I/O 模組進行控制<br />
                (3) 提供示範所需之訊號隔離器及相關硬設備</span></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                五、MODBUS 通訊協定介紹<br />
                <br />
                <span lang="EN-US">MODBUS</span><span>為業界最常用之控制協定，它原是一種序列，是於<span lang="EN-US">1979</span>年，為使用<span 
                    lang="EN-US"><a href="http://zh.wikipedia.org/zh-hant/可编程逻辑控制器" 
                    title="可編程邏輯控制器">可</a></span>（<span lang="EN-US">PLC</span>）而發表的。它已經成為工業領域通信協議，並且現在是工業電子設備之間相當常用的連接方式。<span 
                    lang="EN-US">Modbus</span>比其他通信協議使用的更廣泛的主要原因有:<br />
                (1) 公開發表並且無版稅要求<br />
                (2) 相對容易的工業網路部署<br />
                <br />
                Modbus允許多個設備連接在同一個網絡上進行通信，舉個例子，一個由量測不透光率的監測設施，並且將結果發送給電腦。在數據或取與處理控制系統（DAHS）中，Modbus通常用來連接監控電腦和remote 
                terminal unit (RTU)。Modbus 目前包含用於RS232、E-thernet以及其他支援TCP/IP通訊協定的網路的版本。<br />
                <br />
                過去大多數Modbus設備通信通過序列埠RS-485進行，目前也有對於序列埠發展兩個模式， Modbus RTU ，採用二進制表示數據的方式，Modbus 
                ASCII是一種人類可讀的。這兩個模式都使用序列通訊（serial communication）方式。<br />
                <br />
                值得注意的是，配置為RTU模式的節點不會和設置為ASCII模式的節點通信，反之亦然。另外，廣泛應用於TCP/IP 
                網路（例如乙太網路）的連接，則使用Modbus/TCP 協定。對於所有的這三種通信協定在數據模型和功能調用上都是相同的，只有封裝方式是不同的。<br />
                <br />
                Modbus 另有一個擴展版本 Modbus Plus(Modbus+或者MB+)，不過此協定是Modicon專有的，和 
                Modbus不同。它需要一個專門的協處理器來處理類似HDLC的高速令牌旋轉。它使用1Mbit/s的雙絞線，並且每個節點都有轉換隔離裝置，是一種採用轉換／邊緣觸發而不是電壓／水平觸發的裝置。連接Modbus 
                Plus到計算機需要特別的連接埠，通常是支援ISA（SA85）,PCI或者PCMCIA總線的板卡。</span></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

