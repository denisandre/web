gx.evt.autoSkip=!1;gx.define("gam_updateregisteruser",!1,function(){this.ServerClass="gam_updateregisteruser";this.PackageName="GeneXus.Security.Backend";this.ServerFullClass="gam_updateregisteruser.aspx";this.setObjectType("web");this.setAjaxSecurity(!1);this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="GAMDesignSystem";this.SetStandaloneVars=function(){this.AV18IDP_State=gx.fn.getControlValue("vIDP_STATE")};this.Validv_Birthday=function(){return this.validCliEvt("Validv_Birthday",0,function(){try{var n=gx.util.balloon.getNew("vBIRTHDAY");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV6Birthday)===0||new gx.date.gxdate(this.AV6Birthday).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError(gx.text.format(gx.getMessage("GXSPC_OutOfRange"),gx.getMessage("Birthday"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Gender=function(){return this.validCliEvt("Validv_Gender",0,function(){try{var n=gx.util.balloon.getNew("vGENDER");if(this.AnyError=0,!(gx.text.compare(this.AV11Gender,"N")==0||gx.text.compare(this.AV11Gender,"F")==0||gx.text.compare(this.AV11Gender,"M")==0))try{n.setError(gx.text.format(gx.getMessage("GXSPC_OutOfRange"),gx.getMessage("Gender"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e121i2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e131i2_client=function(){return this.executeServerEvent("'RETURNTOLOGIN'",!1,null,!1,!1)};this.e151i2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,40,41,42,43,44,45,46];this.GXLastCtrlId=46;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TBTITLE",format:0,grid:0,ctrltype:"textblock"};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",fmt:0,gxz:"ZV14Name",gxold:"OV14Name",gxvar:"AV14Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV14Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14Name=n)},v2c:function(){gx.fn.setControlValue("vNAME",gx.O.AV14Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV14Name=this.val())},val:function(){return gx.fn.getControlValue("vNAME")},nac:gx.falseFn};this.declareDomainHdlr(11,function(){});n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vEMAIL",fmt:0,gxz:"ZV7EMail",gxold:"OV7EMail",gxvar:"AV7EMail",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7EMail=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7EMail=n)},v2c:function(){gx.fn.setControlValue("vEMAIL",gx.O.AV7EMail,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV7EMail=this.val())},val:function(){return gx.fn.getControlValue("vEMAIL")},nac:gx.falseFn};this.declareDomainHdlr(16,function(){});n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFIRSTNAME",fmt:0,gxz:"ZV10FirstName",gxold:"OV10FirstName",gxvar:"AV10FirstName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10FirstName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10FirstName=n)},v2c:function(){gx.fn.setControlValue("vFIRSTNAME",gx.O.AV10FirstName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV10FirstName=this.val())},val:function(){return gx.fn.getControlValue("vFIRSTNAME")},nac:gx.falseFn};this.declareDomainHdlr(21,function(){});n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLASTNAME",fmt:0,gxz:"ZV13LastName",gxold:"OV13LastName",gxvar:"AV13LastName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13LastName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13LastName=n)},v2c:function(){gx.fn.setControlValue("vLASTNAME",gx.O.AV13LastName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV13LastName=this.val())},val:function(){return gx.fn.getControlValue("vLASTNAME")},nac:gx.falseFn};this.declareDomainHdlr(26,function(){});n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Birthday,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBIRTHDAY",fmt:0,gxz:"ZV6Birthday",gxold:"OV6Birthday",gxvar:"AV6Birthday",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[31],ip:[31],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6Birthday=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6Birthday=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vBIRTHDAY",gx.O.AV6Birthday,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV6Birthday=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vBIRTHDAY")},nac:gx.falseFn};this.declareDomainHdlr(31,function(){});n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"char",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Gender,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGENDER",fmt:0,gxz:"ZV11Gender",gxold:"OV11Gender",gxvar:"AV11Gender",ucs:[],op:[36],ip:[36],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV11Gender=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11Gender=n)},v2c:function(){gx.fn.setComboBoxValue("vGENDER",gx.O.AV11Gender);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV11Gender=this.val())},val:function(){return gx.fn.getControlValue("vGENDER")},nac:gx.falseFn};this.declareDomainHdlr(36,function(){});n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"BUTTONLOGIN",grid:0,evt:"e131i2_client"};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"BUTTON2",grid:0,evt:"e121i2_client",std:"ENTER"};this.AV14Name="";this.ZV14Name="";this.OV14Name="";this.AV7EMail="";this.ZV7EMail="";this.OV7EMail="";this.AV10FirstName="";this.ZV10FirstName="";this.OV10FirstName="";this.AV13LastName="";this.ZV13LastName="";this.OV13LastName="";this.AV6Birthday=gx.date.nullDate();this.ZV6Birthday=gx.date.nullDate();this.OV6Birthday=gx.date.nullDate();this.AV11Gender="";this.ZV11Gender="";this.OV11Gender="";this.AV14Name="";this.AV7EMail="";this.AV10FirstName="";this.AV13LastName="";this.AV6Birthday=gx.date.nullDate();this.AV11Gender="";this.AV18IDP_State="";this.Events={e121i2_client:["ENTER",!0],e131i2_client:["'RETURNTOLOGIN'",!0],e151i2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV18IDP_State",fld:"vIDP_STATE",pic:"",hsh:!0}],[]];this.EvtParms.ENTER=[[{av:"AV14Name",fld:"vNAME",pic:""},{av:"AV7EMail",fld:"vEMAIL",pic:""},{av:"AV10FirstName",fld:"vFIRSTNAME",pic:""},{av:"AV13LastName",fld:"vLASTNAME",pic:""},{av:"AV6Birthday",fld:"vBIRTHDAY",pic:""},{ctrl:"vGENDER"},{av:"AV11Gender",fld:"vGENDER",pic:""},{av:"AV18IDP_State",fld:"vIDP_STATE",pic:"",hsh:!0}],[]];this.EvtParms["'RETURNTOLOGIN'"]=[[],[]];this.EvtParms.VALIDV_BIRTHDAY=[[],[]];this.EvtParms.VALIDV_GENDER=[[],[]];this.EnterCtrl=["BUTTON2"];this.setVCMap("AV18IDP_State","vIDP_STATE",0,"char",60,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gam_updateregisteruser)})