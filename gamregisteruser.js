gx.evt.autoSkip=!1;gx.define("gamregisteruser",!1,function(){var n,t;this.ServerClass="gamregisteruser";this.PackageName="GeneXus.Programs";this.ServerFullClass="gamregisteruser.aspx";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV29CheckRequiredFieldsResult=gx.fn.getControlValue("vCHECKREQUIREDFIELDSRESULT");this.AV6Birthday=gx.fn.getDateValue("vBIRTHDAY");this.AV12Gender=gx.fn.getControlValue("vGENDER");this.AV28UserRememberMe=gx.fn.getIntegerValue("vUSERREMEMBERME",".")};this.e120l2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e140l1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57];this.GXLastCtrlId=57;this.WWPUTILITIESContainer=gx.uc.getNew(this,58,26,"DVelop_WorkWithPlusUtilities","WWPUTILITIESContainer","Wwputilities","WWPUTILITIES");t=this.WWPUTILITIESContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("EnableAutoUpdateFromDocumentTitle","Enableautoupdatefromdocumenttitle",!1,"bool");t.setProp("EnableFixObjectFitCover","Enablefixobjectfitcover",!1,"bool");t.setProp("EnableFloatingLabels","Enablefloatinglabels",!0,"bool");t.setProp("EmpowerTabs","Empowertabs",!1,"bool");t.setProp("EnableUpdateRowSelectionStatus","Enableupdaterowselectionstatus",!1,"bool");t.setProp("CurrentTab_ReturnUrl","Currenttab_returnurl","","char");t.setProp("EnableConvertComboToBootstrapSelect","Enableconvertcombotobootstrapselect",!1,"bool");t.setProp("AllowColumnResizing","Allowcolumnresizing",!0,"bool");t.setProp("AllowColumnReordering","Allowcolumnreordering",!0,"bool");t.setProp("AllowColumnDragging","Allowcolumndragging",!1,"bool");t.setProp("AllowColumnsRestore","Allowcolumnsrestore",!0,"bool");t.setProp("RestoreColumnsIconClass","Restorecolumnsiconclass","fas fa-undo","str");t.setProp("PagBarIncludeGoTo","Pagbarincludegoto",!1,"bool");t.setProp("ComboLoadType","Comboloadtype","InfiniteScrolling","str");t.setProp("InfiniteScrollingPage","Infinitescrollingpage",10,"num");t.setProp("UpdateButtonText","Updatebuttontext","WWP_ColumnsSelectorButton","str");t.setProp("AddNewOption","Addnewoption","WWP_AddNewOption","str");t.setProp("OnlySelectedValues","Onlyselectedvalues","WWP_OnlySelectedValues","str");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator",", ","str");t.setProp("SelectAll","Selectall","WWP_SelectAll","str");t.setProp("SortASC","Sortasc","WWP_TSSortASC","str");t.setProp("SortDSC","Sortdsc","WWP_TSSortDSC","str");t.setProp("AllowGroupText","Allowgrouptext","WWP_GroupByOption","str");t.setProp("FixLeftText","Fixlefttext","WWP_TSFixLeft","str");t.setProp("FixRightText","Fixrighttext","WWP_TSFixRight","str");t.setProp("LoadingData","Loadingdata","WWP_TSLoading","str");t.setProp("CleanFilter","Cleanfilter","WWP_TSCleanFilter","str");t.setProp("RangeFilterFrom","Rangefilterfrom","WWP_TSFrom","str");t.setProp("RangeFilterTo","Rangefilterto","WWP_TSTo","str");t.setProp("RangePickerInviteMessage","Rangepickerinvitemessage","WWP_TSRangePickerInviteMessage","str");t.setProp("NoResultsFound","Noresultsfound","WWP_TSNoResults","str");t.setProp("SearchButtonText","Searchbuttontext","WWP_TSSearchButtonCaption","str");t.setProp("SearchMultipleValuesButtonText","Searchmultiplevaluesbuttontext","WWP_FilterSelected","str");t.setProp("ColumnSelectorFixedLeftCategory","Columnselectorfixedleftcategory","WWP_ColumnSelectorFixedLeftCategory","str");t.setProp("ColumnSelectorFixedRightCategory","Columnselectorfixedrightcategory","WWP_ColumnSelectorFixedRightCategory","str");t.setProp("ColumnSelectorNotFixedCategory","Columnselectornotfixedcategory","WWP_ColumnSelectorNotFixedCategory","str");t.setProp("ColumnSelectorNoCategoryText","Columnselectornocategorytext","WWP_ColumnSelectorNoCategoryText","str");t.setProp("ColumnSelectorFixedEmpty","Columnselectorfixedempty","WWP_ColumnSelectorFixedEmpty","str");t.setProp("ColumnSelectorRestoreTooltip","Columnselectorrestoretooltip","WWP_SelectColumns_RestoreDefault","str");t.setProp("PagBarGoToCaption","Pagbargotocaption","WWP_PaginationBarGoToCaption","str");t.setProp("PagBarGoToIconClass","Pagbargotoiconclass","fas fa-redo","str");t.setProp("PagBarGoToTooltip","Pagbargototooltip","WWP_PaginationBarGoToTooltip","str");t.setProp("PagBarEmptyFilteredGridCaption","Pagbaremptyfilteredgridcaption","WWP_PaginationBarEmptyFilteredGridCaption","str");t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TABLECONTENT",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"HEADERORIGINAL",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"TABLELOGIN",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"SIGNIN",format:0,grid:0,ctrltype:"textblock"};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"UNNAMEDTABLE1",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"NAME_CELL",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",fmt:0,gxz:"ZV17Name",gxold:"OV17Name",gxvar:"AV17Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV17Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV17Name=n)},v2c:function(){gx.fn.setControlValue("vNAME",gx.O.AV17Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV17Name=this.val())},val:function(){return gx.fn.getControlValue("vNAME")},nac:gx.falseFn};this.declareDomainHdlr(26,function(){});n[27]={id:27,fld:"EMAIL_CELL",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vEMAIL",fmt:0,gxz:"ZV7EMail",gxold:"OV7EMail",gxvar:"AV7EMail",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7EMail=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7EMail=n)},v2c:function(){gx.fn.setControlValue("vEMAIL",gx.O.AV7EMail,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV7EMail=this.val())},val:function(){return gx.fn.getControlValue("vEMAIL")},nac:gx.falseFn};this.declareDomainHdlr(30,function(){});n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"PASSWORD_CELL",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPASSWORD",fmt:0,gxz:"ZV18Password",gxold:"OV18Password",gxvar:"AV18Password",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV18Password=n)},v2z:function(n){n!==undefined&&(gx.O.ZV18Password=n)},v2c:function(){gx.fn.setControlValue("vPASSWORD",gx.O.AV18Password,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV18Password=this.val())},val:function(){return gx.fn.getControlValue("vPASSWORD")},nac:gx.falseFn};this.declareDomainHdlr(35,function(){});n[36]={id:36,fld:"PASSWORDCONF_CELL",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPASSWORDCONF",fmt:0,gxz:"ZV19PasswordConf",gxold:"OV19PasswordConf",gxvar:"AV19PasswordConf",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV19PasswordConf=n)},v2z:function(n){n!==undefined&&(gx.O.ZV19PasswordConf=n)},v2c:function(){gx.fn.setControlValue("vPASSWORDCONF",gx.O.AV19PasswordConf,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV19PasswordConf=this.val())},val:function(){return gx.fn.getControlValue("vPASSWORDCONF")},nac:gx.falseFn};this.declareDomainHdlr(39,function(){});n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"FIRSTNAME_CELL",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFIRSTNAME",fmt:0,gxz:"ZV9FirstName",gxold:"OV9FirstName",gxvar:"AV9FirstName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9FirstName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9FirstName=n)},v2c:function(){gx.fn.setControlValue("vFIRSTNAME",gx.O.AV9FirstName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV9FirstName=this.val())},val:function(){return gx.fn.getControlValue("vFIRSTNAME")},nac:gx.falseFn};this.declareDomainHdlr(44,function(){});n[45]={id:45,fld:"LASTNAME_CELL",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLASTNAME",fmt:0,gxz:"ZV13LastName",gxold:"OV13LastName",gxvar:"AV13LastName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13LastName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13LastName=n)},v2c:function(){gx.fn.setControlValue("vLASTNAME",gx.O.AV13LastName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV13LastName=this.val())},val:function(){return gx.fn.getControlValue("vLASTNAME")},nac:gx.falseFn};this.declareDomainHdlr(48,function(){});n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"ACTIONS",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"BTNENTER",grid:0,evt:"e120l2_client",std:"ENTER"};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"BTN_CANCEL",grid:0,evt:"e140l1_client"};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};this.AV17Name="";this.ZV17Name="";this.OV17Name="";this.AV7EMail="";this.ZV7EMail="";this.OV7EMail="";this.AV18Password="";this.ZV18Password="";this.OV18Password="";this.AV19PasswordConf="";this.ZV19PasswordConf="";this.OV19PasswordConf="";this.AV9FirstName="";this.ZV9FirstName="";this.OV9FirstName="";this.AV13LastName="";this.ZV13LastName="";this.OV13LastName="";this.AV17Name="";this.AV7EMail="";this.AV18Password="";this.AV19PasswordConf="";this.AV9FirstName="";this.AV13LastName="";this.AV29CheckRequiredFieldsResult=!1;this.AV6Birthday=gx.date.nullDate();this.AV12Gender="";this.AV28UserRememberMe=0;this.Events={e120l2_client:["ENTER",!0],e140l1_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV6Birthday",fld:"vBIRTHDAY",pic:"",hsh:!0},{av:"AV12Gender",fld:"vGENDER",pic:"",hsh:!0},{av:"AV28UserRememberMe",fld:"vUSERREMEMBERME",pic:"Z9",hsh:!0}],[]];this.EvtParms.ENTER=[[{av:"AV29CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT",pic:""},{av:"AV18Password",fld:"vPASSWORD",pic:""},{av:"AV19PasswordConf",fld:"vPASSWORDCONF",pic:""},{av:"AV17Name",fld:"vNAME",pic:""},{av:"AV7EMail",fld:"vEMAIL",pic:""},{av:"AV9FirstName",fld:"vFIRSTNAME",pic:""},{av:"AV13LastName",fld:"vLASTNAME",pic:""},{av:"AV6Birthday",fld:"vBIRTHDAY",pic:"",hsh:!0},{av:"AV12Gender",fld:"vGENDER",pic:"",hsh:!0},{av:"AV28UserRememberMe",fld:"vUSERREMEMBERME",pic:"Z9",hsh:!0}],[{av:"AV29CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT",pic:""}]];this.EnterCtrl=["BTNENTER"];this.setVCMap("AV29CheckRequiredFieldsResult","vCHECKREQUIREDFIELDSRESULT",0,"boolean",4,0);this.setVCMap("AV6Birthday","vBIRTHDAY",0,"date",8,0);this.setVCMap("AV12Gender","vGENDER",0,"char",1,0);this.setVCMap("AV28UserRememberMe","vUSERREMEMBERME",0,"int",2,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gamregisteruser)})