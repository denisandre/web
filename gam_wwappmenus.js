gx.evt.autoSkip=!1;gx.define("gam_wwappmenus",!1,function(){var n,t;this.ServerClass="gam_wwappmenus";this.PackageName="GeneXus.Security.Backend";this.ServerFullClass="gam_wwappmenus.aspx";this.setObjectType("web");this.setAjaxSecurity(!1);this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="GAMDesignSystem";this.SetStandaloneVars=function(){this.AV6ApplicationId=gx.fn.getIntegerValue("vAPPLICATIONID",gx.thousandSeparator);this.subGridww_Recordcount=gx.fn.getIntegerValue("subGridww_Recordcount",gx.thousandSeparator)};this.e172g1_client=function(){return this.clearMessages(),this.refreshOutputs([]),this.refreshGrid("Gridww"),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e112g1_client=function(){return this.clearMessages(),this.call("gam_appmenuentry.aspx",["INS",this.AV6ApplicationId,0],null,["Mode","ApplicationId","Id"]),this.refreshOutputs([{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e182g1_client=function(){return this.clearMessages(),this.call("gam_applicationentry.aspx",["DSP",this.AV6ApplicationId],null,["Mode","Id"]),this.refreshOutputs([{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e132g2_client=function(){return this.clearMessages(),this.call("gam_appmenuentry.aspx",["DSP",this.AV6ApplicationId,this.AV15Id],null,["Mode","ApplicationId","Id"]),this.refreshOutputs([{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e152g2_client=function(){return this.clearMessages(),this.call("gam_appmenuentry.aspx",["UPD",this.AV6ApplicationId,this.AV15Id],null,["Mode","ApplicationId","Id"]),this.refreshOutputs([{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e162g2_client=function(){return this.clearMessages(),this.call("gam_appmenuentry.aspx",["DLT",this.AV6ApplicationId,this.AV15Id],null,["Mode","ApplicationId","Id"]),this.refreshOutputs([{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e142g2_client=function(){return this.clearMessages(),this.call("gam_wwappmenuoptions.aspx",[this.AV6ApplicationId,this.AV15Id],null,["ApplicationId","MenuId"]),this.refreshOutputs([{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e192g2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e202g2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,32,33,34,35,36];this.GXLastCtrlId=36;this.GridwwContainer=new gx.grid.grid(this,2,"WbpLvl2",31,"Gridww","Gridww","GridwwContainer",this.CmpContext,this.IsMasterPage,"gam_wwappmenus",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px",gx.getMessage("GXM_newrow"),!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridwwContainer;t.addSingleLineEdit("Name",32,"vNAME",gx.getMessage("Name"),"","Name","char",0,"px",120,80,"start","e132g2_client",[],"Name","Name",!0,0,!1,!1,"Attribute",0,"column");t.addSingleLineEdit("Btnmenuoptions",33,"vBTNMENUOPTIONS","","","BtnMenuOptions","char",0,"px",20,20,"start","e142g2_client",[],"Btnmenuoptions","BtnMenuOptions",!0,0,!1,!1,"TextActionAttribute",0,"WWTextActionColumn column-optional");t.addSingleLineEdit("Btnupd",34,"vBTNUPD","","","BtnUpd","char",0,"px",20,20,"start","e152g2_client",[],"Btnupd","BtnUpd",!0,0,!1,!1,"TextActionAttribute",0,"WWTextActionColumn column-optional");t.addSingleLineEdit("Btndlt",35,"vBTNDLT","","","BtnDlt","char",0,"px",20,20,"start","e162g2_client",[],"Btndlt","BtnDlt",!0,0,!1,!1,"TextActionAttribute",0,"WWTextActionColumn column-optional");t.addSingleLineEdit("Id",36,"vID",gx.getMessage("Id"),"","Id","int",0,"px",12,12,"end",null,[],"Id","Id",!1,0,!1,!1,"Attribute",0,"");this.GridwwContainer.emptyText=gx.getMessage("No results found.");this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"GAM_HEADERWWBACK",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"GAM_HEADERWWBACK_TBLBACKCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"GAM_HEADERWWBACK_TABLEBACK",grid:0,evt:"e182g1_client"};n[15]={id:15,fld:"GAM_HEADERWWBACK_TXTBACK",format:0,grid:0,ctrltype:"textblock"};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"GAM_HEADERWWBACK_TABLEACTIONS",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"GAM_HEADERWWBACK_TITLE",format:0,grid:0,ctrltype:"textblock"};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"GAM_HEADERWWBACK_ADDNEW",grid:0,evt:"e112g1_client"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:"e172g1_client",evt_cvcing:null,rgrid:[],fld:"vSEARCH",fmt:0,gxz:"ZV18Search",gxold:"OV18Search",gxvar:"AV18Search",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV18Search=n)},v2z:function(n){n!==undefined&&(gx.O.ZV18Search=n)},v2c:function(){gx.fn.setControlValue("vSEARCH",gx.O.AV18Search,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV18Search=this.val())},val:function(){return gx.fn.getControlValue("vSEARCH")},nac:gx.falseFn};this.declareDomainHdlr(25,function(){});n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"GRIDCONTAINER",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[32]={id:32,lvl:2,type:"char",len:120,dec:0,sign:!1,ro:0,isacc:0,grid:31,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",fmt:0,gxz:"ZV16Name",gxold:"OV16Name",gxvar:"AV16Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV16Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV16Name=n)},v2c:function(n){gx.fn.setGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(31),gx.O.AV16Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV16Name=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(31))},nac:gx.falseFn,evt:"e132g2_client"};n[33]={id:33,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:31,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBTNMENUOPTIONS",fmt:0,gxz:"ZV9BtnMenuOptions",gxold:"OV9BtnMenuOptions",gxvar:"AV9BtnMenuOptions",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV9BtnMenuOptions=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9BtnMenuOptions=n)},v2c:function(n){gx.fn.setGridControlValue("vBTNMENUOPTIONS",n||gx.fn.currentGridRowImpl(31),gx.O.AV9BtnMenuOptions,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV9BtnMenuOptions=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vBTNMENUOPTIONS",n||gx.fn.currentGridRowImpl(31))},nac:gx.falseFn,evt:"e142g2_client"};n[34]={id:34,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:31,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBTNUPD",fmt:0,gxz:"ZV10BtnUpd",gxold:"OV10BtnUpd",gxvar:"AV10BtnUpd",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV10BtnUpd=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10BtnUpd=n)},v2c:function(n){gx.fn.setGridControlValue("vBTNUPD",n||gx.fn.currentGridRowImpl(31),gx.O.AV10BtnUpd,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV10BtnUpd=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vBTNUPD",n||gx.fn.currentGridRowImpl(31))},nac:gx.falseFn,evt:"e152g2_client"};n[35]={id:35,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:31,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBTNDLT",fmt:0,gxz:"ZV8BtnDlt",gxold:"OV8BtnDlt",gxvar:"AV8BtnDlt",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV8BtnDlt=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8BtnDlt=n)},v2c:function(n){gx.fn.setGridControlValue("vBTNDLT",n||gx.fn.currentGridRowImpl(31),gx.O.AV8BtnDlt,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV8BtnDlt=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vBTNDLT",n||gx.fn.currentGridRowImpl(31))},nac:gx.falseFn,evt:"e162g2_client"};n[36]={id:36,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,isacc:0,grid:31,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vID",fmt:0,gxz:"ZV15Id",gxold:"OV15Id",gxvar:"AV15Id",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV15Id=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV15Id=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vID",n||gx.fn.currentGridRowImpl(31),gx.O.AV15Id,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV15Id=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vID",n||gx.fn.currentGridRowImpl(31),gx.thousandSeparator)},nac:gx.falseFn};this.AV18Search="";this.ZV18Search="";this.OV18Search="";this.ZV16Name="";this.OV16Name="";this.ZV9BtnMenuOptions="";this.OV9BtnMenuOptions="";this.ZV10BtnUpd="";this.OV10BtnUpd="";this.ZV8BtnDlt="";this.OV8BtnDlt="";this.ZV15Id=0;this.OV15Id=0;this.AV18Search="";this.AV6ApplicationId=0;this.AV16Name="";this.AV9BtnMenuOptions="";this.AV10BtnUpd="";this.AV8BtnDlt="";this.AV15Id=0;this.Events={e192g2_client:["ENTER",!0],e202g2_client:["CANCEL",!0],e172g1_client:["VSEARCH.CONTROLVALUECHANGED",!1],e112g1_client:["'ADDNEW'",!1],e182g1_client:["GAM_HEADERWWBACK_TABLEBACK.CLICK",!1],e132g2_client:["VNAME.CLICK",!1],e152g2_client:["VBTNUPD.CLICK",!1],e162g2_client:["VBTNDLT.CLICK",!1],e142g2_client:["VBTNMENUOPTIONS.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{ctrl:"GRIDWW",prop:"Rows"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV18Search",fld:"vSEARCH",pic:""}],[]];this.EvtParms["GRIDWW.LOAD"]=[[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV18Search",fld:"vSEARCH",pic:""}],[{av:'gx.fn.getCtrlProperty("GAM_HEADERWWBACK_TITLE","Caption")',ctrl:"GAM_HEADERWWBACK_TITLE",prop:"Caption"},{av:"AV10BtnUpd",fld:"vBTNUPD",pic:""},{av:"AV8BtnDlt",fld:"vBTNDLT",pic:""},{av:"AV9BtnMenuOptions",fld:"vBTNMENUOPTIONS",pic:""},{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV16Name",fld:"vNAME",pic:""}]];this.EvtParms["VSEARCH.CONTROLVALUECHANGED"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{ctrl:"GRIDWW",prop:"Rows"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV18Search",fld:"vSEARCH",pic:""}],[]];this.EvtParms["'ADDNEW'"]=[[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["GAM_HEADERWWBACK_TABLEBACK.CLICK"]=[[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["VNAME.CLICK"]=[[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["VBTNUPD.CLICK"]=[[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["VBTNDLT.CLICK"]=[[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["VBTNMENUOPTIONS.CLICK"]=[[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRIDWW_FIRSTPAGE=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{ctrl:"GRIDWW",prop:"Rows"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV18Search",fld:"vSEARCH",pic:""}],[]];this.EvtParms.GRIDWW_PREVPAGE=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{ctrl:"GRIDWW",prop:"Rows"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV18Search",fld:"vSEARCH",pic:""}],[]];this.EvtParms.GRIDWW_NEXTPAGE=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{ctrl:"GRIDWW",prop:"Rows"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV18Search",fld:"vSEARCH",pic:""}],[]];this.EvtParms.GRIDWW_LASTPAGE=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{ctrl:"GRIDWW",prop:"Rows"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV18Search",fld:"vSEARCH",pic:""},{av:"subGridww_Recordcount"}],[]];this.setVCMap("AV6ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV6ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV6ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV6ApplicationId","vAPPLICATIONID",0,"int",12,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Gridww"});t.addRefreshingVar({rfrVar:"AV6ApplicationId"});t.addRefreshingVar(this.GXValidFnc[25]);t.addRefreshingParm({rfrVar:"AV6ApplicationId"});t.addRefreshingParm(this.GXValidFnc[25]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gam_wwappmenus)})