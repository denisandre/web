gx.evt.autoSkip=!1;gx.define("login",!1,function(){var n,t,i;this.ServerClass="login";this.PackageName="GeneXus.Programs";this.ServerFullClass="login.aspx";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV16IDP_State=gx.fn.getControlValue("vIDP_STATE");this.AV23Language=gx.fn.getControlValue("vLANGUAGE");this.AV8AuxUserName=gx.fn.getControlValue("vAUXUSERNAME");this.AV33UserRememberMe=gx.fn.getIntegerValue("vUSERREMEMBERME",".");this.subGridauthtypes_Recordcount=gx.fn.getIntegerValue("subGridauthtypes_Recordcount",".")};this.Validv_Typeauthtype=function(){var n=gx.fn.currentGridRowImpl(62);return this.validCliEvt("Validv_Typeauthtype",62,function(){try{var n=gx.util.balloon.getNew("vTYPEAUTHTYPE");if(this.AnyError=0,!(gx.text.compare(this.AV29TypeAuthType,"AppleID")==0||gx.text.compare(this.AV29TypeAuthType,"Custom")==0||gx.text.compare(this.AV29TypeAuthType,"ExternalWebService")==0||gx.text.compare(this.AV29TypeAuthType,"Facebook")==0||gx.text.compare(this.AV29TypeAuthType,"GAMLocal")==0||gx.text.compare(this.AV29TypeAuthType,"GAMRemote")==0||gx.text.compare(this.AV29TypeAuthType,"GAMRemoteRest")==0||gx.text.compare(this.AV29TypeAuthType,"Google")==0||gx.text.compare(this.AV29TypeAuthType,"Oauth20")==0||gx.text.compare(this.AV29TypeAuthType,"OTP")==0||gx.text.compare(this.AV29TypeAuthType,"Saml20")==0||gx.text.compare(this.AV29TypeAuthType,"Twitter")==0||gx.text.compare(this.AV29TypeAuthType,"WeChat")==0))try{n.setError("Campo Type Auth Type fora do intervalo");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e110e2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e170e2_client=function(){return this.executeServerEvent("VIMAGEAUTHTYPE.CLICK",!0,arguments[0],!1,!1)};this.e120e2_client=function(){return this.executeServerEvent("VLOGONTO.CLICK",!0,null,!1,!0)};this.e130e2_client=function(){return this.executeServerEvent("FORGOTPASSWORD.CLICK",!0,null,!1,!0)};this.e180e2_client=function(){return this.executeServerEvent("'SELECTAUTHENTICATIONTYPE'",!0,arguments[0],!1,!1)};this.e190e2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,53,55,56,57,58,59,60,61,63,66,67,70,73,74,76,77,78,79,81,82,83,84];this.GXLastCtrlId=84;this.GridauthtypesContainer=new gx.grid.grid(this,2,"WbpLvl2",62,"Gridauthtypes","Gridauthtypes","GridauthtypesContainer",this.CmpContext,this.IsMasterPage,"login",[],!0,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Novo registro",!1,!1,!1,gx.grid.flexGrid,null,!1,"",!0,[1,1,1,1],!1,0,!1,!1);t=this.GridauthtypesContainer;t.startTable("Unnamedtablefsgridauthtypes",63,"0px");t.startRow("","","","","","");t.startCell("","","","","","","","","","");t.startDiv(66,"","0px","0px");t.addLabel();t.addBitmap("&Imageauthtype","vIMAGEAUTHTYPE",67,0,"",0,"","e170e2_client","","","AttributeImage30","");t.endDiv();t.endCell();t.endRow();t.startRow("","","","","","");t.startCell("","","","","","","","","","Invisible");t.startTable("Unnamedtablecontentfsgridauthtypes",70,"0px");t.startRow("","","","","","");t.startCell("","","","","","","","","","");t.startDiv(73,"","0px","0px");t.addLabel();t.addComboBox("Typeauthtype",74,"vTYPEAUTHTYPE","","TypeAuthType","char",null,0,!0,!1,30,"chr","");t.endDiv();t.endCell();t.startCell("","","","","","","","","","");t.startDiv(76,"","0px","0px");t.addLabel();t.addSingleLineEdit("Nameauthtype",77,"vNAMEAUTHTYPE","","","NameAuthType","char",60,"chr",60,60,"start",null,[],"Nameauthtype","NameAuthType",!0,0,!1,!1,"Attribute",0,"");t.endDiv();t.endCell();t.endRow();t.endTable();t.endCell();t.endRow();t.endTable();this.GridauthtypesContainer.emptyText="";t.setRenderProp("Class","Class","FreeStyleGrid","str");t.setRenderProp("Enabled","Enabled",!0,"boolean");t.setRenderProp("FlexDirection","Flexdirection","row","str");t.setRenderProp("FlexWrap","Flexwrap","nowrap","str");t.setRenderProp("JustifyContent","Justifycontent","flex-start","str");t.setRenderProp("AlignItems","Alignitems","stretch","str");t.setRenderProp("AlignContent","Aligncontent","stretch","str");t.setRenderDynProp("Visible","Visible",!0,"boolean");this.setGrid(t);this.WWPUTILITIESContainer=gx.uc.getNew(this,80,22,"DVelop_WorkWithPlusUtilities","WWPUTILITIESContainer","Wwputilities","WWPUTILITIES");i=this.WWPUTILITIESContainer;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("EnableAutoUpdateFromDocumentTitle","Enableautoupdatefromdocumenttitle",!1,"bool");i.setProp("EnableFixObjectFitCover","Enablefixobjectfitcover",!0,"bool");i.setProp("EnableFloatingLabels","Enablefloatinglabels",!1,"bool");i.setProp("EmpowerTabs","Empowertabs",!1,"bool");i.setProp("EnableUpdateRowSelectionStatus","Enableupdaterowselectionstatus",!1,"bool");i.setProp("CurrentTab_ReturnUrl","Currenttab_returnurl","","char");i.setProp("EnableConvertComboToBootstrapSelect","Enableconvertcombotobootstrapselect",!0,"bool");i.setProp("AllowColumnResizing","Allowcolumnresizing",!0,"bool");i.setProp("AllowColumnReordering","Allowcolumnreordering",!0,"bool");i.setProp("AllowColumnDragging","Allowcolumndragging",!1,"bool");i.setProp("AllowColumnsRestore","Allowcolumnsrestore",!0,"bool");i.setProp("RestoreColumnsIconClass","Restorecolumnsiconclass","fas fa-undo","str");i.setProp("PagBarIncludeGoTo","Pagbarincludegoto",!1,"bool");i.setProp("ComboLoadType","Comboloadtype","InfiniteScrolling","str");i.setProp("InfiniteScrollingPage","Infinitescrollingpage",10,"num");i.setProp("UpdateButtonText","Updatebuttontext","WWP_ColumnsSelectorButton","str");i.setProp("AddNewOption","Addnewoption","WWP_AddNewOption","str");i.setProp("OnlySelectedValues","Onlyselectedvalues","WWP_OnlySelectedValues","str");i.setProp("MultipleValuesSeparator","Multiplevaluesseparator",", ","str");i.setProp("SelectAll","Selectall","WWP_SelectAll","str");i.setProp("SortASC","Sortasc","WWP_TSSortASC","str");i.setProp("SortDSC","Sortdsc","WWP_TSSortDSC","str");i.setProp("AllowGroupText","Allowgrouptext","WWP_GroupByOption","str");i.setProp("FixLeftText","Fixlefttext","WWP_TSFixLeft","str");i.setProp("FixRightText","Fixrighttext","WWP_TSFixRight","str");i.setProp("LoadingData","Loadingdata","WWP_TSLoading","str");i.setProp("CleanFilter","Cleanfilter","WWP_TSCleanFilter","str");i.setProp("RangeFilterFrom","Rangefilterfrom","WWP_TSFrom","str");i.setProp("RangeFilterTo","Rangefilterto","WWP_TSTo","str");i.setProp("RangePickerInviteMessage","Rangepickerinvitemessage","WWP_TSRangePickerInviteMessage","str");i.setProp("NoResultsFound","Noresultsfound","WWP_TSNoResults","str");i.setProp("SearchButtonText","Searchbuttontext","WWP_TSSearchButtonCaption","str");i.setProp("SearchMultipleValuesButtonText","Searchmultiplevaluesbuttontext","WWP_FilterSelected","str");i.setProp("ColumnSelectorFixedLeftCategory","Columnselectorfixedleftcategory","WWP_ColumnSelectorFixedLeftCategory","str");i.setProp("ColumnSelectorFixedRightCategory","Columnselectorfixedrightcategory","WWP_ColumnSelectorFixedRightCategory","str");i.setProp("ColumnSelectorNotFixedCategory","Columnselectornotfixedcategory","WWP_ColumnSelectorNotFixedCategory","str");i.setProp("ColumnSelectorNoCategoryText","Columnselectornocategorytext","WWP_ColumnSelectorNoCategoryText","str");i.setProp("ColumnSelectorFixedEmpty","Columnselectorfixedempty","WWP_ColumnSelectorFixedEmpty","str");i.setProp("ColumnSelectorRestoreTooltip","Columnselectorrestoretooltip","WWP_SelectColumns_RestoreDefault","str");i.setProp("PagBarGoToCaption","Pagbargotocaption","WWP_PaginationBarGoToCaption","str");i.setProp("PagBarGoToIconClass","Pagbargotoiconclass","fas fa-redo","str");i.setProp("PagBarGoToTooltip","Pagbargototooltip","WWP_PaginationBarGoToTooltip","str");i.setProp("PagBarEmptyFilteredGridCaption","Pagbaremptyfilteredgridcaption","WWP_PaginationBarEmptyFilteredGridCaption","str");i.setProp("Visible","Visible",!0,"bool");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TABLELOGINCONTENT",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLELOGIN",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"LOGOLOGIN",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"UNNAMEDTABLE1",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLOGONTO",fmt:0,gxz:"ZV25LogOnTo",gxold:"OV25LogOnTo",gxvar:"AV25LogOnTo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV25LogOnTo=n)},v2z:function(n){n!==undefined&&(gx.O.ZV25LogOnTo=n)},v2c:function(){gx.fn.setComboBoxValue("vLOGONTO",gx.O.AV25LogOnTo);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV25LogOnTo=this.val())},val:function(){return gx.fn.getControlValue("vLOGONTO")},nac:gx.falseFn,evt:"e120e2_client"};this.declareDomainHdlr(22,function(){});n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"CURRENTREPOSITORYCELL",grid:0};n[25]={id:25,fld:"CURRENTREPOSITORY",format:0,grid:0,ctrltype:"textblock"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERNAME",fmt:0,gxz:"ZV31UserName",gxold:"OV31UserName",gxvar:"AV31UserName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV31UserName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV31UserName=n)},v2c:function(){gx.fn.setControlValue("vUSERNAME",gx.O.AV31UserName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV31UserName=this.val())},val:function(){return gx.fn.getControlValue("vUSERNAME")},nac:gx.falseFn};this.declareDomainHdlr(29,function(){});n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERPASSWORD",fmt:0,gxz:"ZV32UserPassword",gxold:"OV32UserPassword",gxvar:"AV32UserPassword",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV32UserPassword=n)},v2z:function(n){n!==undefined&&(gx.O.ZV32UserPassword=n)},v2c:function(){gx.fn.setControlValue("vUSERPASSWORD",gx.O.AV32UserPassword,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV32UserPassword=this.val())},val:function(){return gx.fn.getControlValue("vUSERPASSWORD")},nac:gx.falseFn};this.declareDomainHdlr(33,function(){});n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"FORGOTPASSWORD",format:1,grid:0,evt:"e130e2_client",ctrltype:"textblock"};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"KEEPMELOGGEDIN_CELL",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vKEEPMELOGGEDIN",fmt:0,gxz:"ZV22KeepMeLoggedIn",gxold:"OV22KeepMeLoggedIn",gxvar:"AV22KeepMeLoggedIn",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV22KeepMeLoggedIn=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV22KeepMeLoggedIn=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vKEEPMELOGGEDIN",gx.O.AV22KeepMeLoggedIn,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV22KeepMeLoggedIn=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vKEEPMELOGGEDIN")},nac:gx.falseFn,values:["true","false"]};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"REMEMBERME_CELL",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vREMEMBERME",fmt:0,gxz:"ZV27RememberMe",gxold:"OV27RememberMe",gxvar:"AV27RememberMe",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV27RememberMe=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV27RememberMe=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vREMEMBERME",gx.O.AV27RememberMe,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV27RememberMe=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vREMEMBERME")},nac:gx.falseFn,values:["true","false"]};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"BTNENTER",grid:0,evt:"e110e2_client",std:"ENTER"};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"TABLENOACCOUNT",grid:0};n[53]={id:53,fld:"NOACCOUNT",format:0,grid:0,ctrltype:"textblock"};n[55]={id:55,fld:"REGISTERUSER",format:0,grid:0,ctrltype:"textblock"};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"TABLEBUTTONS",grid:0};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"LOGINWITH",format:1,grid:0,ctrltype:"textblock"};n[61]={id:61,fld:"",grid:0};n[63]={id:63,fld:"UNNAMEDTABLEFSGRIDAUTHTYPES",grid:62};n[66]={id:66,fld:"",grid:62};n[67]={id:67,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:62,gxgrid:this.GridauthtypesContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vIMAGEAUTHTYPE",fmt:0,gxz:"ZV17ImageAuthType",gxold:"OV17ImageAuthType",gxvar:"AV17ImageAuthType",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV17ImageAuthType=n)},v2z:function(n){n!==undefined&&(gx.O.ZV17ImageAuthType=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vIMAGEAUTHTYPE",n||gx.fn.currentGridRowImpl(62),gx.O.AV17ImageAuthType,gx.O.AV49Imageauthtype_GXI)},c2v:function(n){gx.O.AV49Imageauthtype_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV17ImageAuthType=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vIMAGEAUTHTYPE",n||gx.fn.currentGridRowImpl(62))},val_GXI:function(n){return gx.fn.getGridControlValue("vIMAGEAUTHTYPE_GXI",n||gx.fn.currentGridRowImpl(62))},gxvar_GXI:"AV49Imageauthtype_GXI",nac:gx.falseFn,evt:"e170e2_client"};n[70]={id:70,fld:"UNNAMEDTABLECONTENTFSGRIDAUTHTYPES",grid:62};n[73]={id:73,fld:"",grid:62};n[74]={id:74,lvl:2,type:"char",len:30,dec:0,sign:!1,ro:0,isacc:0,grid:62,gxgrid:this.GridauthtypesContainer,fnc:this.Validv_Typeauthtype,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTYPEAUTHTYPE",fmt:0,gxz:"ZV29TypeAuthType",gxold:"OV29TypeAuthType",gxvar:"AV29TypeAuthType",ucs:[],op:[74],ip:[74],nacdep:[],ctrltype:"combo",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV29TypeAuthType=n)},v2z:function(n){n!==undefined&&(gx.O.ZV29TypeAuthType=n)},v2c:function(n){gx.fn.setGridComboBoxValue("vTYPEAUTHTYPE",n||gx.fn.currentGridRowImpl(62),gx.O.AV29TypeAuthType);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV29TypeAuthType=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vTYPEAUTHTYPE",n||gx.fn.currentGridRowImpl(62))},nac:gx.falseFn};n[76]={id:76,fld:"",grid:62};n[77]={id:77,lvl:2,type:"char",len:60,dec:0,sign:!1,ro:0,isacc:0,grid:62,gxgrid:this.GridauthtypesContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAMEAUTHTYPE",fmt:0,gxz:"ZV26NameAuthType",gxold:"OV26NameAuthType",gxvar:"AV26NameAuthType",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV26NameAuthType=n)},v2z:function(n){n!==undefined&&(gx.O.ZV26NameAuthType=n)},v2c:function(n){gx.fn.setGridControlValue("vNAMEAUTHTYPE",n||gx.fn.currentGridRowImpl(62),gx.O.AV26NameAuthType,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV26NameAuthType=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNAMEAUTHTYPE",n||gx.fn.currentGridRowImpl(62))},nac:gx.falseFn};n[78]={id:78,fld:"",grid:0};n[79]={id:79,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[84]={id:84,lvl:0,type:"svchar",len:2048,dec:250,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vURL",fmt:0,gxz:"ZV30URL",gxold:"OV30URL",gxvar:"AV30URL",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV30URL=n)},v2z:function(n){n!==undefined&&(gx.O.ZV30URL=n)},v2c:function(){gx.fn.setControlValue("vURL",gx.O.AV30URL,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV30URL=this.val())},val:function(){return gx.fn.getControlValue("vURL")},nac:gx.falseFn};this.declareDomainHdlr(84,function(){});this.AV25LogOnTo="";this.ZV25LogOnTo="";this.OV25LogOnTo="";this.AV31UserName="";this.ZV31UserName="";this.OV31UserName="";this.AV32UserPassword="";this.ZV32UserPassword="";this.OV32UserPassword="";this.AV22KeepMeLoggedIn=!1;this.ZV22KeepMeLoggedIn=!1;this.OV22KeepMeLoggedIn=!1;this.AV27RememberMe=!1;this.ZV27RememberMe=!1;this.OV27RememberMe=!1;this.ZV17ImageAuthType="";this.OV17ImageAuthType="";this.ZV29TypeAuthType="";this.OV29TypeAuthType="";this.ZV26NameAuthType="";this.OV26NameAuthType="";this.AV30URL="";this.ZV30URL="";this.OV30URL="";this.AV25LogOnTo="";this.AV31UserName="";this.AV32UserPassword="";this.AV22KeepMeLoggedIn=!1;this.AV27RememberMe=!1;this.AV30URL="";this.AV17ImageAuthType="";this.AV29TypeAuthType="";this.AV26NameAuthType="";this.AV16IDP_State="";this.AV23Language="";this.AV8AuxUserName="";this.AV33UserRememberMe=0;this.Events={e110e2_client:["ENTER",!0],e170e2_client:["VIMAGEAUTHTYPE.CLICK",!0],e120e2_client:["VLOGONTO.CLICK",!0],e130e2_client:["FORGOTPASSWORD.CLICK",!0],e180e2_client:["'SELECTAUTHENTICATIONTYPE'",!0],e190e2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRIDAUTHTYPES_nFirstRecordOnPage"},{av:"GRIDAUTHTYPES_nEOF"},{ctrl:"vTYPEAUTHTYPE"},{av:'gx.fn.getCtrlProperty("vNAMEAUTHTYPE","Visible")',ctrl:"vNAMEAUTHTYPE",prop:"Visible"},{av:"AV22KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN",pic:""},{av:"AV27RememberMe",fld:"vREMEMBERME",pic:""},{av:"AV23Language",fld:"vLANGUAGE",pic:"",hsh:!0},{av:"AV8AuxUserName",fld:"vAUXUSERNAME",pic:"",hsh:!0},{av:"AV33UserRememberMe",fld:"vUSERREMEMBERME",pic:"Z9",hsh:!0}],[{av:"AV32UserPassword",fld:"vUSERPASSWORD",pic:""},{av:"AV30URL",fld:"vURL",pic:""},{ctrl:"vLOGONTO"},{av:"AV25LogOnTo",fld:"vLOGONTO",pic:""},{av:'gx.fn.getCtrlProperty("GRIDAUTHTYPES","Visible")',ctrl:"GRIDAUTHTYPES",prop:"Visible"},{av:"AV31UserName",fld:"vUSERNAME",pic:""},{av:"AV27RememberMe",fld:"vREMEMBERME",pic:""},{av:'gx.fn.getCtrlProperty("vKEEPMELOGGEDIN","Visible")',ctrl:"vKEEPMELOGGEDIN",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vREMEMBERME","Visible")',ctrl:"vREMEMBERME",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vUSERPASSWORD","Visible")',ctrl:"vUSERPASSWORD",prop:"Visible"},{ctrl:"BTNENTER",prop:"Caption"},{av:'gx.fn.getCtrlProperty("FORGOTPASSWORD","Visible")',ctrl:"FORGOTPASSWORD",prop:"Visible"}]];this.EvtParms["GRIDAUTHTYPES.LOAD"]=[[{av:'gx.fn.getCtrlProperty("TABLEBUTTONS","Visible")',ctrl:"TABLEBUTTONS",prop:"Visible"}],[{av:"AV17ImageAuthType",fld:"vIMAGEAUTHTYPE",pic:""},{ctrl:"vTYPEAUTHTYPE"},{av:"AV29TypeAuthType",fld:"vTYPEAUTHTYPE",pic:""},{av:"AV26NameAuthType",fld:"vNAMEAUTHTYPE",pic:""},{av:'gx.fn.getCtrlProperty("vIMAGEAUTHTYPE","Tooltiptext")',ctrl:"vIMAGEAUTHTYPE",prop:"Tooltiptext"},{av:'gx.fn.getCtrlProperty("TABLEBUTTONS","Visible")',ctrl:"TABLEBUTTONS",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"AV22KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN",pic:""},{av:"AV27RememberMe",fld:"vREMEMBERME",pic:""},{ctrl:"vLOGONTO"},{av:"AV25LogOnTo",fld:"vLOGONTO",pic:""},{av:"AV31UserName",fld:"vUSERNAME",pic:""},{av:"AV32UserPassword",fld:"vUSERPASSWORD",pic:""},{av:"AV16IDP_State",fld:"vIDP_STATE",pic:""}],[{av:"AV30URL",fld:"vURL",pic:""},{av:"AV16IDP_State",fld:"vIDP_STATE",pic:""},{av:"AV32UserPassword",fld:"vUSERPASSWORD",pic:""}]];this.EvtParms["VIMAGEAUTHTYPE.CLICK"]=[[{av:"AV26NameAuthType",fld:"vNAMEAUTHTYPE",pic:""},{av:"AV31UserName",fld:"vUSERNAME",pic:""},{av:"AV32UserPassword",fld:"vUSERPASSWORD",pic:""}],[]];this.EvtParms["VLOGONTO.CLICK"]=[[{av:"AV23Language",fld:"vLANGUAGE",pic:"",hsh:!0},{ctrl:"vLOGONTO"},{av:"AV25LogOnTo",fld:"vLOGONTO",pic:""}],[{av:'gx.fn.getCtrlProperty("vUSERPASSWORD","Visible")',ctrl:"vUSERPASSWORD",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vUSERPASSWORD","Invitemessage")',ctrl:"vUSERPASSWORD",prop:"Invitemessage"},{ctrl:"BTNENTER",prop:"Caption"},{av:'gx.fn.getCtrlProperty("FORGOTPASSWORD","Visible")',ctrl:"FORGOTPASSWORD",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vREMEMBERME","Visible")',ctrl:"vREMEMBERME",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vKEEPMELOGGEDIN","Visible")',ctrl:"vKEEPMELOGGEDIN",prop:"Visible"}]];this.EvtParms["FORGOTPASSWORD.CLICK"]=[[{av:"AV16IDP_State",fld:"vIDP_STATE",pic:""}],[{av:"AV16IDP_State",fld:"vIDP_STATE",pic:""}]];this.EvtParms["'SELECTAUTHENTICATIONTYPE'"]=[[{av:"AV26NameAuthType",fld:"vNAMEAUTHTYPE",pic:""},{av:"AV31UserName",fld:"vUSERNAME",pic:""},{av:"AV32UserPassword",fld:"vUSERPASSWORD",pic:""}],[]];this.EvtParms.VALIDV_TYPEAUTHTYPE=[[{ctrl:"vTYPEAUTHTYPE"},{av:"AV29TypeAuthType",fld:"vTYPEAUTHTYPE",pic:""}],[{ctrl:"vTYPEAUTHTYPE"},{av:"AV29TypeAuthType",fld:"vTYPEAUTHTYPE",pic:""}]];this.EnterCtrl=["BTNENTER"];this.setVCMap("AV16IDP_State","vIDP_STATE",0,"char",60,0);this.setVCMap("AV23Language","vLANGUAGE",0,"char",3,0);this.setVCMap("AV8AuxUserName","vAUXUSERNAME",0,"svchar",100,60);this.setVCMap("AV33UserRememberMe","vUSERREMEMBERME",0,"int",2,0);this.setVCMap("AV23Language","vLANGUAGE",0,"char",3,0);this.setVCMap("AV8AuxUserName","vAUXUSERNAME",0,"svchar",100,60);this.setVCMap("AV33UserRememberMe","vUSERREMEMBERME",0,"int",2,0);this.setVCMap("AV23Language","vLANGUAGE",0,"char",3,0);this.setVCMap("AV8AuxUserName","vAUXUSERNAME",0,"svchar",100,60);this.setVCMap("AV33UserRememberMe","vUSERREMEMBERME",0,"int",2,0);t.addRefreshingVar({rfrVar:"AV23Language"});t.addRefreshingVar({rfrVar:"AV8AuxUserName"});t.addRefreshingVar({rfrVar:"AV33UserRememberMe"});t.addRefreshingVar({rfrVar:"AV29TypeAuthType",rfrProp:"Visible",gxAttId:"Typeauthtype"});t.addRefreshingVar({rfrVar:"AV26NameAuthType",rfrProp:"Visible",gxAttId:"Nameauthtype"});t.addRefreshingParm({rfrVar:"AV23Language"});t.addRefreshingParm({rfrVar:"AV8AuxUserName"});t.addRefreshingParm({rfrVar:"AV33UserRememberMe"});t.addRefreshingParm({rfrVar:"AV29TypeAuthType",rfrProp:"Visible",gxAttId:"Typeauthtype"});t.addRefreshingParm({rfrVar:"AV26NameAuthType",rfrProp:"Visible",gxAttId:"Nameauthtype"});t.addRefreshingParm(this.GXValidFnc[40]);t.addRefreshingParm(this.GXValidFnc[44]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.login)})