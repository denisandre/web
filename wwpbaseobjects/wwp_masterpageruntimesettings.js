gx.evt.autoSkip=!1;gx.define("wwpbaseobjects.wwp_masterpageruntimesettings",!0,function(n){this.ServerClass="wwpbaseobjects.wwp_masterpageruntimesettings";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwpbaseobjects.wwp_masterpageruntimesettings.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV11FontSizeSelected=gx.fn.getControlValue("vFONTSIZESELECTED");this.AV5WWP_DesignSystemSettings=gx.fn.getControlValue("vWWP_DESIGNSYSTEMSETTINGS")};this.s112_client=function(){this.AV11FontSizeSelected=this.AV5WWP_DesignSystemSettings.FontSize;gx.fn.setCtrlProperty("FONTSIZESMALL","Class","FontSizeSelectorSmall");gx.fn.setCtrlProperty("FONTSIZEMEDIUM","Class","FontSizeSelectorMedium");gx.fn.setCtrlProperty("FONTSIZELARGE","Class","FontSizeSelectorLarge");gx.text.compare(this.AV11FontSizeSelected,"Small")==0?gx.fn.setCtrlProperty("FONTSIZESMALL","Class",gx.fn.getCtrlProperty("FONTSIZESMALL","Class")+" FontSizeSelectorSelected"):gx.text.compare(this.AV11FontSizeSelected,"Medium")==0?gx.fn.setCtrlProperty("FONTSIZEMEDIUM","Class",gx.fn.getCtrlProperty("FONTSIZEMEDIUM","Class")+" FontSizeSelectorSelected"):gx.text.compare(this.AV11FontSizeSelected,"Large")==0&&gx.fn.setCtrlProperty("FONTSIZELARGE","Class",gx.fn.getCtrlProperty("FONTSIZELARGE","Class")+" FontSizeSelectorSelected")};this.e122t2_client=function(){return this.executeServerEvent("FONTSIZESMALL.CLICK",!0,null,!1,!0)};this.e132t2_client=function(){return this.executeServerEvent("FONTSIZEMEDIUM.CLICK",!0,null,!1,!0)};this.e142t2_client=function(){return this.executeServerEvent("FONTSIZELARGE.CLICK",!0,null,!1,!0)};this.e152t2_client=function(){return this.executeServerEvent("VBACKSTYLE.CONTROLVALUECHANGED",!0,null,!1,!0)};this.e172t2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e182t2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26];this.GXLastCtrlId=26;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"BACKSTYLETXT",format:0,grid:0,ctrltype:"textblock"};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,lvl:0,type:"svchar",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:"e152t2_client",evt_cvcing:null,rgrid:[],fld:"vBACKSTYLE",fmt:0,gxz:"ZV6BackStyle",gxold:"OV6BackStyle",gxvar:"AV6BackStyle",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"radio",v2v:function(n){n!==undefined&&(gx.O.AV6BackStyle=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6BackStyle=n)},v2c:function(){gx.fn.setRadioValue("vBACKSTYLE",gx.O.AV6BackStyle)},c2v:function(){this.val()!==undefined&&(gx.O.AV6BackStyle=this.val())},val:function(){return gx.fn.getControlValue("vBACKSTYLE")},nac:gx.falseFn};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"FONTSIZETXT",format:0,grid:0,ctrltype:"textblock"};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"UNNAMEDTABLE1",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"FONTSIZESMALL",format:0,grid:0,evt:"e122t2_client",ctrltype:"textblock"};t[23]={id:23,fld:"",grid:0};t[24]={id:24,fld:"FONTSIZEMEDIUM",format:0,grid:0,evt:"e132t2_client",ctrltype:"textblock"};t[25]={id:25,fld:"FONTSIZELARGECELL",grid:0};t[26]={id:26,fld:"FONTSIZELARGE",format:0,grid:0,evt:"e142t2_client",ctrltype:"textblock"};this.AV6BackStyle="";this.ZV6BackStyle="";this.OV6BackStyle="";this.AV6BackStyle="";this.AV11FontSizeSelected="";this.AV5WWP_DesignSystemSettings={BaseColor:"",BackgroundStyle:"",FontSize:"",MenuColor:""};this.Events={e122t2_client:["FONTSIZESMALL.CLICK",!0],e132t2_client:["FONTSIZEMEDIUM.CLICK",!0],e142t2_client:["FONTSIZELARGE.CLICK",!0],e152t2_client:["VBACKSTYLE.CONTROLVALUECHANGED",!0],e172t2_client:["ENTER",!0],e182t2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{ctrl:"vBACKSTYLE"},{av:"AV6BackStyle",fld:"vBACKSTYLE",pic:""}],[]];this.EvtParms["FONTSIZESMALL.CLICK"]=[[{av:"AV11FontSizeSelected",fld:"vFONTSIZESELECTED",pic:""},{av:"AV5WWP_DesignSystemSettings",fld:"vWWP_DESIGNSYSTEMSETTINGS",pic:""}],[{av:"AV11FontSizeSelected",fld:"vFONTSIZESELECTED",pic:""},{av:"AV5WWP_DesignSystemSettings",fld:"vWWP_DESIGNSYSTEMSETTINGS",pic:""},{av:'gx.fn.getCtrlProperty("FONTSIZESMALL","Class")',ctrl:"FONTSIZESMALL",prop:"Class"},{av:'gx.fn.getCtrlProperty("FONTSIZEMEDIUM","Class")',ctrl:"FONTSIZEMEDIUM",prop:"Class"},{av:'gx.fn.getCtrlProperty("FONTSIZELARGE","Class")',ctrl:"FONTSIZELARGE",prop:"Class"}]];this.EvtParms["FONTSIZEMEDIUM.CLICK"]=[[{av:"AV11FontSizeSelected",fld:"vFONTSIZESELECTED",pic:""},{av:"AV5WWP_DesignSystemSettings",fld:"vWWP_DESIGNSYSTEMSETTINGS",pic:""}],[{av:"AV11FontSizeSelected",fld:"vFONTSIZESELECTED",pic:""},{av:"AV5WWP_DesignSystemSettings",fld:"vWWP_DESIGNSYSTEMSETTINGS",pic:""},{av:'gx.fn.getCtrlProperty("FONTSIZESMALL","Class")',ctrl:"FONTSIZESMALL",prop:"Class"},{av:'gx.fn.getCtrlProperty("FONTSIZEMEDIUM","Class")',ctrl:"FONTSIZEMEDIUM",prop:"Class"},{av:'gx.fn.getCtrlProperty("FONTSIZELARGE","Class")',ctrl:"FONTSIZELARGE",prop:"Class"}]];this.EvtParms["FONTSIZELARGE.CLICK"]=[[{av:"AV11FontSizeSelected",fld:"vFONTSIZESELECTED",pic:""},{av:"AV5WWP_DesignSystemSettings",fld:"vWWP_DESIGNSYSTEMSETTINGS",pic:""}],[{av:"AV11FontSizeSelected",fld:"vFONTSIZESELECTED",pic:""},{av:"AV5WWP_DesignSystemSettings",fld:"vWWP_DESIGNSYSTEMSETTINGS",pic:""},{av:'gx.fn.getCtrlProperty("FONTSIZESMALL","Class")',ctrl:"FONTSIZESMALL",prop:"Class"},{av:'gx.fn.getCtrlProperty("FONTSIZEMEDIUM","Class")',ctrl:"FONTSIZEMEDIUM",prop:"Class"},{av:'gx.fn.getCtrlProperty("FONTSIZELARGE","Class")',ctrl:"FONTSIZELARGE",prop:"Class"}]];this.EvtParms["VBACKSTYLE.CONTROLVALUECHANGED"]=[[{ctrl:"vBACKSTYLE"},{av:"AV6BackStyle",fld:"vBACKSTYLE",pic:""}],[{av:"AV5WWP_DesignSystemSettings",fld:"vWWP_DESIGNSYSTEMSETTINGS",pic:""}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV11FontSizeSelected","vFONTSIZESELECTED",0,"svchar",40,0);this.setVCMap("AV5WWP_DesignSystemSettings","vWWP_DESIGNSYSTEMSETTINGS",0,"WWPBaseObjectsWWP_DesignSystemSettings",0,0);this.Initialize()})