gx.evt.autoSkip=!1;gx.define("wwpbaseobjects.wwp_selectimportfile",!0,function(n){this.ServerClass="wwpbaseobjects.wwp_selectimportfile";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwpbaseobjects.wwp_selectimportfile.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV9ImportType=gx.fn.getControlValue("vIMPORTTYPE");this.AV5ErrorMsgs=gx.fn.getControlValue("vERRORMSGS");this.AV6ExtraParmsJson=gx.fn.getControlValue("vEXTRAPARMSJSON");this.AV14TransactionName=gx.fn.getControlValue("vTRANSACTIONNAME")};this.e11131_client=function(){return this.clearMessages(),this.addMessage("<#CLEAR#>"),WWPActions.WCPopup_Close(""),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e13132_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e15132_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24];this.GXLastCtrlId=24;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"TABLEATTRIBUTES",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,lvl:0,type:"bitstr",len:1024,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFILTERTOUPLOAD",fmt:0,gxz:"ZV7FilterToUpload",gxold:"OV7FilterToUpload",gxvar:"AV7FilterToUpload",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7FilterToUpload=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7FilterToUpload=n)},v2c:function(){gx.fn.setBlobValue("vFILTERTOUPLOAD",gx.O.AV7FilterToUpload)},c2v:function(){this.val()!==undefined&&(gx.O.AV7FilterToUpload=this.val())},val:function(){return gx.fn.getBlobValue("vFILTERTOUPLOAD")},nac:gx.falseFn};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"BTNENTER",grid:0,evt:"e13132_client",std:"ENTER"};t[23]={id:23,fld:"",grid:0};t[24]={id:24,fld:"BTNUCANCEL",grid:0,evt:"e11131_client"};this.AV7FilterToUpload="";this.ZV7FilterToUpload="";this.OV7FilterToUpload="";this.AV7FilterToUpload="";this.AV14TransactionName="";this.AV9ImportType="";this.AV6ExtraParmsJson="";this.AV5ErrorMsgs=[];this.Events={e13132_client:["ENTER",!0],e15132_client:["CANCEL",!0],e11131_client:["'DOUCANCEL'",!1]};this.EvtParms.REFRESH=[[{av:"AV5ErrorMsgs",fld:"vERRORMSGS",pic:"",hsh:!0}],[]];this.EvtParms["'DOUCANCEL'"]=[[],[]];this.EvtParms.ENTER=[[{ctrl:"vFILTERTOUPLOAD",prop:"Filename"},{av:"AV7FilterToUpload",fld:"vFILTERTOUPLOAD",pic:""},{av:"AV9ImportType",fld:"vIMPORTTYPE",pic:""},{av:"AV5ErrorMsgs",fld:"vERRORMSGS",pic:"",hsh:!0},{av:"AV6ExtraParmsJson",fld:"vEXTRAPARMSJSON",pic:""},{av:"AV14TransactionName",fld:"vTRANSACTIONNAME",pic:""}],[{av:"AV7FilterToUpload",fld:"vFILTERTOUPLOAD",pic:""}]];this.EnterCtrl=["BTNENTER"];this.setVCMap("AV9ImportType","vIMPORTTYPE",0,"svchar",40,0);this.setVCMap("AV5ErrorMsgs","vERRORMSGS",0,"CollGeneXusCommonMessages.Message",0,0);this.setVCMap("AV6ExtraParmsJson","vEXTRAPARMSJSON",0,"svchar",40,0);this.setVCMap("AV14TransactionName","vTRANSACTIONNAME",0,"svchar",40,0);this.Initialize()})