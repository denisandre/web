gx.evt.autoSkip=!1;gx.define("core.ufview",!1,function(){var n,t,i,r;this.ServerClass="core.ufview";this.PackageName="GeneXus.Programs";this.ServerFullClass="core.ufview.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.A4UFID=gx.fn.getIntegerValue("UFID",".");this.AV15RecordDescription=gx.fn.getControlValue("vRECORDDESCRIPTION");this.AV11LoadAllTabs=gx.fn.getControlValue("vLOADALLTABS");this.AV12SelectedTabCode=gx.fn.getControlValue("vSELECTEDTABCODE");this.AV10UFID=gx.fn.getIntegerValue("vUFID",".");this.AV8TabCode=gx.fn.getControlValue("vTABCODE")};this.e11492_client=function(){return this.executeServerEvent("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",!1,null,!0,!0)};this.e12492_client=function(){return this.executeServerEvent("DDC_DISCUSSIONS.ONLOADCOMPONENT",!1,null,!0,!0)};this.e13492_client=function(){return this.executeServerEvent("TABS.TABCHANGED",!1,null,!0,!0)};this.e17492_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e18492_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,14,16,17,18,19,20,23,24,26,27,28,31,32,34,35,36,38,39,40,41];this.GXLastCtrlId=41;this.DDC_SUBSCRIPTIONSContainer=gx.uc.getNew(this,13,0,"BootstrapDropDownOptions","DDC_SUBSCRIPTIONSContainer","Ddc_subscriptions","DDC_SUBSCRIPTIONS");t=this.DDC_SUBSCRIPTIONSContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("IconType","Icontype","FontIcon","str");t.setProp("Icon","Icon","fas fa-rss","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","WWP_Subscriptions_Tooltip","str");t.setProp("Cls","Cls","DropDownComponent","str");t.setProp("ComponentWidth","Componentwidth",400,"num");t.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");t.setProp("DropDownOptionsType","Dropdownoptionstype","Component","str");t.setDynProp("Visible","Visible",!0,"bool");t.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");t.setProp("ShowLoading","Showloading",!0,"bool");t.setProp("Load","Load","OnEveryClick","str");t.setProp("KeepOpened","Keepopened",!1,"bool");t.setProp("Trigger","Trigger","Click","str");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnLoadComponent",this.e11492_client);this.setUserControl(t);this.DDC_DISCUSSIONSContainer=gx.uc.getNew(this,15,0,"BootstrapDropDownOptions","DDC_DISCUSSIONSContainer","Ddc_discussions","DDC_DISCUSSIONS");i=this.DDC_DISCUSSIONSContainer;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("IconType","Icontype","FontIcon","str");i.setDynProp("Icon","Icon","far fa-comment-dots","str");i.setProp("Caption","Caption","","str");i.setProp("Tooltip","Tooltip","WWP_Discussions_Tooltip","str");i.setProp("Cls","Cls","DropDownComponent","str");i.setProp("ComponentWidth","Componentwidth",400,"num");i.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");i.setProp("DropDownOptionsType","Dropdownoptionstype","Component","str");i.setProp("Visible","Visible",!0,"bool");i.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");i.setProp("ShowLoading","Showloading",!0,"bool");i.setProp("Load","Load","OnEveryClick","str");i.setProp("KeepOpened","Keepopened",!1,"bool");i.setProp("Trigger","Trigger","Click","str");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("OnLoadComponent",this.e12492_client);this.setUserControl(i);this.TABSContainer=gx.uc.getNew(this,21,0,"gx.ui.controls.Tab","TABSContainer","Tabs","TABS");r=this.TABSContainer;r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("ActivePage","Activepage","","int");r.setDynProp("ActivePageControlName","Activepagecontrolname","","char");r.setProp("PageCount","Pagecount",2,"num");r.setProp("Class","Class","ViewTab Tab","str");r.setProp("HistoryManagement","Historymanagement",!0,"bool");r.setProp("Visible","Visible",!0,"bool");r.setC2ShowFunction(function(n){n.show()});r.addEventHandler("TabChanged",this.e13492_client);this.setUserControl(r);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TABLEVIEWRIGHTITEMS",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"WORKWITHLINK",format:0,grid:0,ctrltype:"textblock"};n[12]={id:12,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"UNNAMEDTABLEVIEWCONTAINER",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[23]={id:23,fld:"GENERAL_TITLE",format:0,grid:0,ctrltype:"textblock"};n[24]={id:24,fld:"",grid:0};n[26]={id:26,fld:"UNNAMEDTABLEGENERAL",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[31]={id:31,fld:"MESORREGIAO_TITLE",format:0,grid:0,ctrltype:"textblock"};n[32]={id:32,fld:"",grid:0};n[34]={id:34,fld:"UNNAMEDTABLEMESORREGIAO",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[41]={id:41,fld:"DIV_WWPAUXWC",grid:0};this.AV10UFID=0;this.AV8TabCode="";this.A4UFID=0;this.A15MesorregiaoUFID=0;this.A5UFSigla="";this.AV15RecordDescription="";this.AV11LoadAllTabs=!1;this.AV12SelectedTabCode="";this.Events={e11492_client:["DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",!0],e12492_client:["DDC_DISCUSSIONS.ONLOADCOMPONENT",!0],e13492_client:["TABS.TABCHANGED",!0],e17492_client:["ENTER",!0],e18492_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"A4UFID",fld:"UFID",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV15RecordDescription",fld:"vRECORDDESCRIPTION",pic:"",hsh:!0},{av:"AV10UFID",fld:"vUFID",pic:"ZZZ,ZZZ,ZZ9",hsh:!0},{av:"AV8TabCode",fld:"vTABCODE",pic:"",hsh:!0}],[{av:"this.DDC_DISCUSSIONSContainer.Icon",ctrl:"DDC_DISCUSSIONS",prop:"Icon"},{av:"this.DDC_SUBSCRIPTIONSContainer.Visible",ctrl:"DDC_SUBSCRIPTIONS",prop:"Visible"}]];this.EvtParms["DDC_SUBSCRIPTIONS.ONLOADCOMPONENT"]=[[{av:"A4UFID",fld:"UFID",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV15RecordDescription",fld:"vRECORDDESCRIPTION",pic:"",hsh:!0}],[{ctrl:"WWPAUX_WC"}]];this.EvtParms["DDC_DISCUSSIONS.ONLOADCOMPONENT"]=[[{av:"AV15RecordDescription",fld:"vRECORDDESCRIPTION",pic:"",hsh:!0},{av:"A4UFID",fld:"UFID",pic:"ZZZ,ZZZ,ZZ9"}],[{ctrl:"WWPAUX_WC"}]];this.EvtParms["TABS.TABCHANGED"]=[[{av:"this.TABSContainer.ActivePageControlName",ctrl:"TABS",prop:"ActivePageControlName"},{av:"AV11LoadAllTabs",fld:"vLOADALLTABS",pic:""},{av:"AV12SelectedTabCode",fld:"vSELECTEDTABCODE",pic:""},{av:"AV10UFID",fld:"vUFID",pic:"ZZZ,ZZZ,ZZ9",hsh:!0}],[{av:"AV12SelectedTabCode",fld:"vSELECTEDTABCODE",pic:""},{av:"AV11LoadAllTabs",fld:"vLOADALLTABS",pic:""},{ctrl:"GENERALWC"},{ctrl:"MESORREGIAOWC"}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("A4UFID","UFID",0,"int",9,0);this.setVCMap("AV15RecordDescription","vRECORDDESCRIPTION",0,"svchar",40,0);this.setVCMap("AV11LoadAllTabs","vLOADALLTABS",0,"boolean",4,0);this.setVCMap("AV12SelectedTabCode","vSELECTEDTABCODE",0,"char",50,0);this.setVCMap("AV10UFID","vUFID",0,"int",9,0);this.setVCMap("AV8TabCode","vTABCODE",0,"char",50,0);this.Initialize();this.setComponent({id:"GENERALWC",GXClass:null,Prefix:"W0029",lvl:1});this.setComponent({id:"MESORREGIAOWC",GXClass:null,Prefix:"W0037",lvl:1});this.setComponent({id:"WWPAUX_WC",GXClass:null,Prefix:"W0042",lvl:1})});gx.wi(function(){gx.createParentObj(this.core.ufview)})