gx.evt.autoSkip=!1;gx.define("gameventsubscriptionentry",!1,function(){var n,t;this.ServerClass="gameventsubscriptionentry";this.PackageName="GeneXus.Programs";this.ServerFullClass="gameventsubscriptionentry.aspx";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV14Id=gx.fn.getControlValue("vID");this.Gx_mode=gx.fn.getControlValue("vMODE")};this.Validv_Event=function(){return this.validCliEvt("Validv_Event",0,function(){try{var n=gx.util.balloon.getNew("vEVENT");if(this.AnyError=0,!(gx.text.compare(this.AV11Event,"user-update")==0||gx.text.compare(this.AV11Event,"user-insert")==0||gx.text.compare(this.AV11Event,"user-delete")==0||gx.text.compare(this.AV11Event,"user-updateroles")==0||gx.text.compare(this.AV11Event,"user-getcustominfo")==0||gx.text.compare(this.AV11Event,"user-savecustominfo")==0||gx.text.compare(this.AV11Event,"role-insert")==0||gx.text.compare(this.AV11Event,"role-update")==0||gx.text.compare(this.AV11Event,"role-delete")==0||gx.text.compare(this.AV11Event,"repository-login")==0||gx.text.compare(this.AV11Event,"repository-loginfailed")==0||gx.text.compare(this.AV11Event,"repository-logout")==0||gx.text.compare(this.AV11Event,"externalauthentication-response")==0||gx.text.compare(this.AV11Event,"application-checkprmfail")==0||gx.text.compare(this.AV11Event,"user-otp-validateuser")==0||gx.text.compare(this.AV11Event,"user-otp-generatecode")==0||gx.text.compare(this.AV11Event,"user-otp-sendcode")==0||gx.text.compare(this.AV11Event,"user-otp-validatecode")==0))try{n.setError("Campo Event fora do intervalo");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e12282_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e14281_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54];this.GXLastCtrlId=54;this.DVPANEL_TABLEATTRIBUTESContainer=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_TABLEATTRIBUTESContainer","Dvpanel_tableattributes","DVPANEL_TABLEATTRIBUTES");t=this.DVPANEL_TABLEATTRIBUTESContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","100%","str");t.setProp("Height","Height","100","str");t.setProp("AutoWidth","Autowidth",!1,"bool");t.setProp("AutoHeight","Autoheight",!0,"bool");t.setProp("Cls","Cls","PanelCard_IconAndTitle Panel_BaseColor","str");t.setProp("ShowHeader","Showheader",!0,"bool");t.setProp("Title","Title","General Information","str");t.setProp("Collapsible","Collapsible",!1,"bool");t.setProp("Collapsed","Collapsed",!1,"bool");t.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");t.setProp("IconPosition","Iconposition","Right","str");t.setProp("AutoScroll","Autoscroll",!1,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"TABLEATTRIBUTES",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"char",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDESCRIPTION",fmt:0,gxz:"ZV8Description",gxold:"OV8Description",gxvar:"AV8Description",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8Description=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8Description=n)},v2c:function(){gx.fn.setControlValue("vDESCRIPTION",gx.O.AV8Description,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV8Description=this.val())},val:function(){return gx.fn.getControlValue("vDESCRIPTION")},nac:gx.falseFn};this.declareDomainHdlr(22,function(){});n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,lvl:0,type:"char",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSTATUS",fmt:0,gxz:"ZV16Status",gxold:"OV16Status",gxvar:"AV16Status",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV16Status=n)},v2z:function(n){n!==undefined&&(gx.O.ZV16Status=n)},v2c:function(){gx.fn.setComboBoxValue("vSTATUS",gx.O.AV16Status)},c2v:function(){this.val()!==undefined&&(gx.O.AV16Status=this.val())},val:function(){return gx.fn.getControlValue("vSTATUS")},nac:gx.falseFn};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Event,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vEVENT",fmt:0,gxz:"ZV11Event",gxold:"OV11Event",gxvar:"AV11Event",ucs:[],op:[32],ip:[32],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV11Event=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11Event=n)},v2c:function(){gx.fn.setComboBoxValue("vEVENT",gx.O.AV11Event)},c2v:function(){this.val()!==undefined&&(gx.O.AV11Event=this.val())},val:function(){return gx.fn.getControlValue("vEVENT")},nac:gx.falseFn};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFILENAME",fmt:0,gxz:"ZV13FileName",gxold:"OV13FileName",gxvar:"AV13FileName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13FileName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13FileName=n)},v2c:function(){gx.fn.setControlValue("vFILENAME",gx.O.AV13FileName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV13FileName=this.val())},val:function(){return gx.fn.getControlValue("vFILENAME")},nac:gx.falseFn};this.declareDomainHdlr(37,function(){});n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCLASSNAME",fmt:0,gxz:"ZV7ClassName",gxold:"OV7ClassName",gxvar:"AV7ClassName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7ClassName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7ClassName=n)},v2c:function(){gx.fn.setControlValue("vCLASSNAME",gx.O.AV7ClassName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV7ClassName=this.val())},val:function(){return gx.fn.getControlValue("vCLASSNAME")},nac:gx.falseFn};this.declareDomainHdlr(42,function(){});n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vMETHODNAME",fmt:0,gxz:"ZV15MethodName",gxold:"OV15MethodName",gxvar:"AV15MethodName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV15MethodName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15MethodName=n)},v2c:function(){gx.fn.setControlValue("vMETHODNAME",gx.O.AV15MethodName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV15MethodName=this.val())},val:function(){return gx.fn.getControlValue("vMETHODNAME")},nac:gx.falseFn};this.declareDomainHdlr(47,function(){});n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"BTNENTER",grid:0,evt:"e12282_client",std:"ENTER"};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"BTNCANCEL",grid:0,evt:"e14281_client"};this.AV8Description="";this.ZV8Description="";this.OV8Description="";this.AV16Status="";this.ZV16Status="";this.OV16Status="";this.AV11Event="";this.ZV11Event="";this.OV11Event="";this.AV13FileName="";this.ZV13FileName="";this.OV13FileName="";this.AV7ClassName="";this.ZV7ClassName="";this.OV7ClassName="";this.AV15MethodName="";this.ZV15MethodName="";this.OV15MethodName="";this.AV8Description="";this.AV16Status="";this.AV11Event="";this.AV13FileName="";this.AV7ClassName="";this.AV15MethodName="";this.AV14Id="";this.Gx_mode="";this.Events={e12282_client:["ENTER",!0],e14281_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV14Id",fld:"vID",pic:"",hsh:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0}],[]];this.EvtParms.ENTER=[[{av:"AV14Id",fld:"vID",pic:"",hsh:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV8Description",fld:"vDESCRIPTION",pic:""},{ctrl:"vEVENT"},{av:"AV11Event",fld:"vEVENT",pic:""},{av:"AV13FileName",fld:"vFILENAME",pic:""},{av:"AV7ClassName",fld:"vCLASSNAME",pic:""},{av:"AV15MethodName",fld:"vMETHODNAME",pic:""}],[]];this.EvtParms.VALIDV_EVENT=[[],[]];this.EnterCtrl=["BTNENTER"];this.setVCMap("AV14Id","vID",0,"char",40,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gameventsubscriptionentry)})