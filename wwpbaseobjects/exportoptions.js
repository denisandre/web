gx.evt.autoSkip=!1;gx.define("wwpbaseobjects.exportoptions",!1,function(){var n,t,i,r;this.ServerClass="wwpbaseobjects.exportoptions";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwpbaseobjects.exportoptions.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV9GoogleDocResultXML=gx.fn.getControlValue("vGOOGLEDOCRESULTXML");this.AV7ExcelFileName=gx.fn.getControlValue("vEXCELFILENAME");this.AV6DefaultTitle=gx.fn.getControlValue("vDEFAULTTITLE")};this.Validv_Exporttype=function(){return this.validCliEvt("Validv_Exporttype",0,function(){try{var n=gx.util.balloon.getNew("vEXPORTTYPE");if(this.AnyError=0,!(this.AV8ExportType==1||this.AV8ExportType==2))try{n.setError("Campo Export Type fora do intervalo");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e150r1_client=function(){return this.clearMessages(),this.AV8ExportType==2?(gx.fn.setCtrlProperty("TABLEGOOGLEDRIVEINFO","Visible",!0),gx.fn.setCtrlProperty("BTNDOWNLOADTOFILE","Visible",!1),gx.fn.setCtrlProperty("BTNSAVEGOOGLEDRIVE","Visible",!0)):(gx.fn.setCtrlProperty("TABLEGOOGLEDRIVEINFO","Visible",!1),gx.fn.setCtrlProperty("BTNDOWNLOADTOFILE","Visible",!0),gx.fn.setCtrlProperty("BTNSAVEGOOGLEDRIVE","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TABLEGOOGLEDRIVEINFO","Visible")',ctrl:"TABLEGOOGLEDRIVEINFO",prop:"Visible"},{ctrl:"BTNDOWNLOADTOFILE",prop:"Visible"},{ctrl:"BTNSAVEGOOGLEDRIVE",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e120r2_client=function(){return this.executeServerEvent("'DODOWNLOADTOFILE'",!1,null,!1,!1)};this.e130r2_client=function(){return this.executeServerEvent("'DOSAVEGOOGLEDRIVE'",!1,null,!1,!1)};this.e160r2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e170r1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,9,15,20,21,22,23,24,25,28,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,51,52,58,59,60,61,62,63,64];this.GXLastCtrlId=64;this.INNEWWINDOW1Container=gx.uc.getNew(this,55,25,"InNewWindow","INNEWWINDOW1Container","Innewwindow1","INNEWWINDOW1");t=this.INNEWWINDOW1Container;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setDynProp("Width","Width","50","str");t.setDynProp("Height","Height","50","str");t.setProp("Name","Name","","str");t.setDynProp("Target","Target","","str");t.setProp("Fullscreen","Fullscreen",!1,"bool");t.setProp("Location","Location",!0,"bool");t.setProp("MenuBar","Menubar",!0,"bool");t.setProp("Resizable","Resizable",!0,"bool");t.setProp("Scrollbars","Scrollbars",!0,"bool");t.setProp("TitleBar","Titlebar",!0,"bool");t.setProp("ToolBar","Toolbar",!0,"bool");t.setProp("directories","Directories",!0,"bool");t.setProp("status","Status",!0,"bool");t.setProp("copyhistory","Copyhistory",!0,"bool");t.setProp("top","Top","5","str");t.setProp("left","Left","5","str");t.setProp("fitscreen","Fitscreen",!1,"bool");t.setProp("RefreshParentOnClose","Refreshparentonclose",!1,"bool");t.setProp("Targets","Targets","","str");t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);this.DVPANEL_TABLEEXPORTContainer=gx.uc.getNew(this,18,0,"BootstrapPanel","DVPANEL_TABLEEXPORTContainer","Dvpanel_tableexport","DVPANEL_TABLEEXPORT");i=this.DVPANEL_TABLEEXPORTContainer;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Width","Width","100%","str");i.setProp("Height","Height","100","str");i.setProp("AutoWidth","Autowidth",!1,"bool");i.setProp("AutoHeight","Autoheight",!0,"bool");i.setProp("Cls","Cls","PanelCard_IconAndTitle Panel_BaseColor","str");i.setProp("ShowHeader","Showheader",!0,"bool");i.setProp("Title","Title","Onde exportar?","str");i.setProp("Collapsible","Collapsible",!1,"bool");i.setProp("Collapsed","Collapsed",!1,"bool");i.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");i.setProp("IconPosition","Iconposition","Right","str");i.setProp("AutoScroll","Autoscroll",!1,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);this.DVPANEL_TABLEATTRIBUTESContainer=gx.uc.getNew(this,31,25,"BootstrapPanel","DVPANEL_TABLEATTRIBUTESContainer","Dvpanel_tableattributes","DVPANEL_TABLEATTRIBUTES");r=this.DVPANEL_TABLEATTRIBUTESContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("Width","Width","100%","str");r.setProp("Height","Height","100","str");r.setProp("AutoWidth","Autowidth",!1,"bool");r.setProp("AutoHeight","Autoheight",!0,"bool");r.setProp("Cls","Cls","PanelCard_IconAndTitle Panel_BaseColor","str");r.setProp("ShowHeader","Showheader",!0,"bool");r.setProp("Title","Title","Informação de Google Drive","str");r.setProp("Collapsible","Collapsible",!1,"bool");r.setProp("Collapsed","Collapsed",!1,"bool");r.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");r.setProp("IconPosition","Iconposition","Right","str");r.setProp("AutoScroll","Autoscroll",!1,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[9]={id:9,fld:"JS",format:2,grid:0,ctrltype:"textblock"};n[15]={id:15,fld:"TABLECONTENT",grid:0};n[20]={id:20,fld:"TABLEEXPORT",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:this.Validv_Exporttype,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vEXPORTTYPE",fmt:0,gxz:"ZV8ExportType",gxold:"OV8ExportType",gxvar:"AV8ExportType",ucs:[],op:[25],ip:[25],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV8ExportType=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8ExportType=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("vEXPORTTYPE",gx.O.AV8ExportType);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV8ExportType=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vEXPORTTYPE",".")},nac:gx.falseFn,evt:"e150r1_client"};this.declareDomainHdlr(25,function(){});n[28]={id:28,fld:"TABLEGOOGLEDRIVEINFO",grid:0};n[33]={id:33,fld:"TABLEATTRIBUTES",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSER",fmt:0,gxz:"ZV14User",gxold:"OV14User",gxvar:"AV14User",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV14User=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14User=n)},v2c:function(){gx.fn.setControlValue("vUSER",gx.O.AV14User,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV14User=this.val())},val:function(){return gx.fn.getControlValue("vUSER")},nac:gx.falseFn};this.declareDomainHdlr(38,function(){});n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDOCTITLE",fmt:0,gxz:"ZV5DocTitle",gxold:"OV5DocTitle",gxvar:"AV5DocTitle",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV5DocTitle=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5DocTitle=n)},v2c:function(){gx.fn.setControlValue("vDOCTITLE",gx.O.AV5DocTitle,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV5DocTitle=this.val())},val:function(){return gx.fn.getControlValue("vDOCTITLE")},nac:gx.falseFn};this.declareDomainHdlr(43,function(){});n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPASSWORD",fmt:0,gxz:"ZV12Password",gxold:"OV12Password",gxvar:"AV12Password",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12Password=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Password=n)},v2c:function(){gx.fn.setControlValue("vPASSWORD",gx.O.AV12Password,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV12Password=this.val())},val:function(){return gx.fn.getControlValue("vPASSWORD")},nac:gx.falseFn};this.declareDomainHdlr(48,function(){});n[51]={id:51,fld:"HTML_USERTABLE_UT",grid:0};n[52]={id:52,fld:"UT",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"BTNDOWNLOADTOFILE",grid:0,evt:"e120r2_client"};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"BTNSAVEGOOGLEDRIVE",grid:0,evt:"e130r2_client"};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"BTNCANCEL",grid:0,evt:"e170r1_client"};this.AV8ExportType=0;this.ZV8ExportType=0;this.OV8ExportType=0;this.AV14User="";this.ZV14User="";this.OV14User="";this.AV5DocTitle="";this.ZV5DocTitle="";this.OV5DocTitle="";this.AV12Password="";this.ZV12Password="";this.OV12Password="";this.AV8ExportType=0;this.AV14User="";this.AV5DocTitle="";this.AV12Password="";this.AV7ExcelFileName="";this.AV6DefaultTitle="";this.AV9GoogleDocResultXML="";this.Events={e120r2_client:["'DODOWNLOADTOFILE'",!0],e130r2_client:["'DOSAVEGOOGLEDRIVE'",!0],e160r2_client:["ENTER",!0],e170r1_client:["CANCEL",!0],e150r1_client:["VEXPORTTYPE.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"AV9GoogleDocResultXML",fld:"vGOOGLEDOCRESULTXML",pic:"",hsh:!0},{av:"AV7ExcelFileName",fld:"vEXCELFILENAME",pic:"",hsh:!0},{av:"AV6DefaultTitle",fld:"vDEFAULTTITLE",pic:"",hsh:!0}],[]];this.EvtParms["'DODOWNLOADTOFILE'"]=[[],[]];this.EvtParms["'DOSAVEGOOGLEDRIVE'"]=[[{av:"AV9GoogleDocResultXML",fld:"vGOOGLEDOCRESULTXML",pic:"",hsh:!0}],[{av:"this.INNEWWINDOW1Container.Target",ctrl:"INNEWWINDOW1",prop:"Target"},{av:"this.INNEWWINDOW1Container.Height",ctrl:"INNEWWINDOW1",prop:"Height"},{av:"this.INNEWWINDOW1Container.Width",ctrl:"INNEWWINDOW1",prop:"Width"},{ctrl:"BTNCANCEL",prop:"Caption"},{av:'gx.fn.getCtrlProperty("TABLECONTENT","Visible")',ctrl:"TABLECONTENT",prop:"Visible"},{ctrl:"BTNDOWNLOADTOFILE",prop:"Visible"},{ctrl:"BTNSAVEGOOGLEDRIVE",prop:"Visible"}]];this.EvtParms["VEXPORTTYPE.CLICK"]=[[{ctrl:"vEXPORTTYPE"},{av:"AV8ExportType",fld:"vEXPORTTYPE",pic:"9"}],[{av:'gx.fn.getCtrlProperty("TABLEGOOGLEDRIVEINFO","Visible")',ctrl:"TABLEGOOGLEDRIVEINFO",prop:"Visible"},{ctrl:"BTNDOWNLOADTOFILE",prop:"Visible"},{ctrl:"BTNSAVEGOOGLEDRIVE",prop:"Visible"}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALIDV_EXPORTTYPE=[[],[]];this.setVCMap("AV9GoogleDocResultXML","vGOOGLEDOCRESULTXML",0,"vchar",2097152,0);this.setVCMap("AV7ExcelFileName","vEXCELFILENAME",0,"svchar",1e3,0);this.setVCMap("AV6DefaultTitle","vDEFAULTTITLE",0,"svchar",100,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.wwpbaseobjects.exportoptions)})