gx.evt.autoSkip=!1;gx.define("gamchangepassword",!1,function(){var i,t,n;this.ServerClass="gamchangepassword";this.PackageName="GeneXus.Programs";this.ServerFullClass="gamchangepassword.aspx";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV6IDP_State=gx.fn.getControlValue("vIDP_STATE")};this.e120h2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e130h2_client=function(){return this.executeServerEvent("BACKTOLOGIN.CLICK",!0,null,!1,!0)};this.e150h2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];i=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,24,25,26,29,30,31,34,35,36,39,40,41,44,45,46,47,48,49,50,52,53];this.GXLastCtrlId=53;this.UCMESSAGEContainer=gx.uc.getNew(this,51,26,"DVelop_DVMessage","UCMESSAGEContainer","Ucmessage","UCMESSAGE");t=this.UCMESSAGEContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","300","str");t.setProp("MinHeight","Minheight","16","str");t.setProp("StylingType","Stylingtype","fontawesome","str");t.setProp("DefaultMessageType","Defaultmessagetype","notice","str");t.setProp("StopOnError","Stoponerror",!0,"bool");t.setProp("TitleEscape","Titleescape",!1,"bool");t.setProp("TextEscape","Textescape",!1,"bool");t.setProp("ChangeNewLinesToBRs","Changenewlinestobrs",!0,"bool");t.setProp("Hide","Hide",!0,"bool");t.setProp("DelayUntilHide","Delayuntilhide",8e3,"num");t.setProp("MouseHideReset","Mousehidereset",!0,"bool");t.setProp("MessageAdditionalClasses","Messageadditionalclasses","","str");t.setProp("MessageCornerClass","Messagecornerclass","","str");t.setProp("Shadow","Shadow",!0,"bool");t.setProp("Opacity","Opacity","1","str");t.setProp("StackVerticalFirstPos","Stackverticalfirstpos",15,"num");t.setProp("StackHorizontalFirstPos","Stackhorizontalfirstpos",15,"num");t.setProp("StackVerticalSpacing","Stackverticalspacing",15,"num");t.setProp("StackHorizontalSpacing","Stackhorizontalspacing",15,"num");t.setProp("EffectIn","Effectin","fade","str");t.setProp("EffectOut","Effectout","fade","str");t.setProp("AnimationSpeed","Animationspeed",600,"num");t.setProp("StartPosition","Startposition","TopRight","str");t.setProp("NextMessagePosition","Nextmessageposition","down","str");t.setProp("Closer","Closer",!0,"bool");t.setProp("CloserHover","Closerhover",!0,"bool");t.setProp("Sticker","Sticker",!1,"bool");t.setProp("StickerHover","Stickerhover",!0,"bool");t.setProp("LabelCloseButton","Labelclosebutton","Close","str");t.setProp("LabelStickButton","Labelstickbutton","Stick","str");t.setProp("showEvenOnNonblock","Showevenonnonblock",!1,"bool");t.setProp("NonBlock","Nonblock",!1,"bool");t.setProp("NonBlockOpacity","Nonblockopacity",".2","str");t.setProp("EnableHistory","Enablehistory",!0,"bool");t.setProp("Menu","Menu",!1,"bool");t.setProp("FixedMenu","Fixedmenu",!0,"bool");t.setProp("MaxOnScreen","Maxonscreen","Infinity","str");t.setProp("LabelRedisplay","Labelredisplay","Redisplay","str");t.setProp("LabelAll","Labelall","All","str");t.setProp("LabelLast","Labellast","Last","str");t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);this.WWPUTILITIESContainer=gx.uc.getNew(this,54,26,"DVelop_WorkWithPlusUtilities","WWPUTILITIESContainer","Wwputilities","WWPUTILITIES");n=this.WWPUTILITIESContainer;n.setProp("Class","Class","","char");n.setProp("Enabled","Enabled",!0,"boolean");n.setProp("EnableAutoUpdateFromDocumentTitle","Enableautoupdatefromdocumenttitle",!1,"bool");n.setProp("EnableFixObjectFitCover","Enablefixobjectfitcover",!0,"bool");n.setProp("EnableFloatingLabels","Enablefloatinglabels",!1,"bool");n.setProp("EmpowerTabs","Empowertabs",!0,"bool");n.setProp("EnableUpdateRowSelectionStatus","Enableupdaterowselectionstatus",!0,"bool");n.setProp("CurrentTab_ReturnUrl","Currenttab_returnurl","","char");n.setProp("EnableConvertComboToBootstrapSelect","Enableconvertcombotobootstrapselect",!0,"bool");n.setProp("AllowColumnResizing","Allowcolumnresizing",!0,"bool");n.setProp("AllowColumnReordering","Allowcolumnreordering",!0,"bool");n.setProp("AllowColumnDragging","Allowcolumndragging",!0,"bool");n.setProp("AllowColumnsRestore","Allowcolumnsrestore",!0,"bool");n.setProp("RestoreColumnsIconClass","Restorecolumnsiconclass","fas fa-undo","str");n.setProp("PagBarIncludeGoTo","Pagbarincludegoto",!0,"bool");n.setProp("ComboLoadType","Comboloadtype","InfiniteScrolling","str");n.setProp("InfiniteScrollingPage","Infinitescrollingpage",10,"num");n.setProp("UpdateButtonText","Updatebuttontext","WWP_ColumnsSelectorButton","str");n.setProp("AddNewOption","Addnewoption","WWP_AddNewOption","str");n.setProp("OnlySelectedValues","Onlyselectedvalues","WWP_OnlySelectedValues","str");n.setProp("MultipleValuesSeparator","Multiplevaluesseparator",", ","str");n.setProp("SelectAll","Selectall","WWP_SelectAll","str");n.setProp("SortASC","Sortasc","WWP_TSSortASC","str");n.setProp("SortDSC","Sortdsc","WWP_TSSortDSC","str");n.setProp("AllowGroupText","Allowgrouptext","WWP_GroupByOption","str");n.setProp("FixLeftText","Fixlefttext","WWP_TSFixLeft","str");n.setProp("FixRightText","Fixrighttext","WWP_TSFixRight","str");n.setProp("LoadingData","Loadingdata","WWP_TSLoading","str");n.setProp("CleanFilter","Cleanfilter","WWP_TSCleanFilter","str");n.setProp("RangeFilterFrom","Rangefilterfrom","WWP_TSFrom","str");n.setProp("RangeFilterTo","Rangefilterto","WWP_TSTo","str");n.setProp("RangePickerInviteMessage","Rangepickerinvitemessage","WWP_TSRangePickerInviteMessage","str");n.setProp("NoResultsFound","Noresultsfound","WWP_TSNoResults","str");n.setProp("SearchButtonText","Searchbuttontext","WWP_TSSearchButtonCaption","str");n.setProp("SearchMultipleValuesButtonText","Searchmultiplevaluesbuttontext","WWP_FilterSelected","str");n.setProp("ColumnSelectorFixedLeftCategory","Columnselectorfixedleftcategory","WWP_ColumnSelectorFixedLeftCategory","str");n.setProp("ColumnSelectorFixedRightCategory","Columnselectorfixedrightcategory","WWP_ColumnSelectorFixedRightCategory","str");n.setProp("ColumnSelectorNotFixedCategory","Columnselectornotfixedcategory","WWP_ColumnSelectorNotFixedCategory","str");n.setProp("ColumnSelectorNoCategoryText","Columnselectornocategorytext","WWP_ColumnSelectorNoCategoryText","str");n.setProp("ColumnSelectorFixedEmpty","Columnselectorfixedempty","WWP_ColumnSelectorFixedEmpty","str");n.setProp("ColumnSelectorRestoreTooltip","Columnselectorrestoretooltip","WWP_SelectColumns_RestoreDefault","str");n.setProp("PagBarGoToCaption","Pagbargotocaption","WWP_PaginationBarGoToCaption","str");n.setProp("PagBarGoToIconClass","Pagbargotoiconclass","fas fa-redo","str");n.setProp("PagBarGoToTooltip","Pagbargototooltip","WWP_PaginationBarGoToTooltip","str");n.setProp("PagBarEmptyFilteredGridCaption","Pagbaremptyfilteredgridcaption","WWP_PaginationBarEmptyFilteredGridCaption","str");n.setProp("Visible","Visible",!0,"bool");n.setC2ShowFunction(function(n){n.show()});this.setUserControl(n);i[2]={id:2,fld:"",grid:0};i[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};i[4]={id:4,fld:"",grid:0};i[5]={id:5,fld:"",grid:0};i[6]={id:6,fld:"TABLEMAIN",grid:0};i[7]={id:7,fld:"",grid:0};i[8]={id:8,fld:"",grid:0};i[9]={id:9,fld:"TABLECONTENT",grid:0};i[10]={id:10,fld:"",grid:0};i[11]={id:11,fld:"",grid:0};i[12]={id:12,fld:"HEADERORIGINAL",grid:0};i[13]={id:13,fld:"",grid:0};i[14]={id:14,fld:"",grid:0};i[15]={id:15,fld:"TABLELOGIN",grid:0};i[16]={id:16,fld:"",grid:0};i[17]={id:17,fld:"",grid:0};i[18]={id:18,fld:"SIGNIN",format:0,grid:0,ctrltype:"textblock"};i[19]={id:19,fld:"",grid:0};i[20]={id:20,fld:"",grid:0};i[21]={id:21,fld:"UNNAMEDTABLE1",grid:0};i[24]={id:24,fld:"",grid:0};i[25]={id:25,fld:"",grid:0};i[26]={id:26,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERNAME",fmt:0,gxz:"ZV10UserName",gxold:"OV10UserName",gxvar:"AV10UserName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10UserName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10UserName=n)},v2c:function(){gx.fn.setControlValue("vUSERNAME",gx.O.AV10UserName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV10UserName=this.val())},val:function(){return gx.fn.getControlValue("vUSERNAME")},nac:gx.falseFn};this.declareDomainHdlr(26,function(){});i[29]={id:29,fld:"",grid:0};i[30]={id:30,fld:"",grid:0};i[31]={id:31,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERPASSWORD",fmt:0,gxz:"ZV11UserPassword",gxold:"OV11UserPassword",gxvar:"AV11UserPassword",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11UserPassword=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11UserPassword=n)},v2c:function(){gx.fn.setControlValue("vUSERPASSWORD",gx.O.AV11UserPassword,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV11UserPassword=this.val())},val:function(){return gx.fn.getControlValue("vUSERPASSWORD")},nac:gx.falseFn};this.declareDomainHdlr(31,function(){});i[34]={id:34,fld:"",grid:0};i[35]={id:35,fld:"",grid:0};i[36]={id:36,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERPASSWORDNEW",fmt:0,gxz:"ZV12UserPasswordNew",gxold:"OV12UserPasswordNew",gxvar:"AV12UserPasswordNew",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12UserPasswordNew=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12UserPasswordNew=n)},v2c:function(){gx.fn.setControlValue("vUSERPASSWORDNEW",gx.O.AV12UserPasswordNew,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV12UserPasswordNew=this.val())},val:function(){return gx.fn.getControlValue("vUSERPASSWORDNEW")},nac:gx.falseFn};this.declareDomainHdlr(36,function(){});i[39]={id:39,fld:"",grid:0};i[40]={id:40,fld:"",grid:0};i[41]={id:41,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERPASSWORDNEWCONF",fmt:0,gxz:"ZV13UserPasswordNewConf",gxold:"OV13UserPasswordNewConf",gxvar:"AV13UserPasswordNewConf",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13UserPasswordNewConf=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13UserPasswordNewConf=n)},v2c:function(){gx.fn.setControlValue("vUSERPASSWORDNEWCONF",gx.O.AV13UserPasswordNewConf,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV13UserPasswordNewConf=this.val())},val:function(){return gx.fn.getControlValue("vUSERPASSWORDNEWCONF")},nac:gx.falseFn};this.declareDomainHdlr(41,function(){});i[44]={id:44,fld:"ACTIONS",grid:0};i[45]={id:45,fld:"",grid:0};i[46]={id:46,fld:"BTNENTER",grid:0,evt:"e120h2_client",std:"ENTER"};i[47]={id:47,fld:"",grid:0};i[48]={id:48,fld:"BACKTOLOGIN",format:0,grid:0,evt:"e130h2_client",ctrltype:"textblock"};i[49]={id:49,fld:"",grid:0};i[50]={id:50,fld:"",grid:0};i[52]={id:52,fld:"",grid:0};i[53]={id:53,fld:"",grid:0};this.AV10UserName="";this.ZV10UserName="";this.OV10UserName="";this.AV11UserPassword="";this.ZV11UserPassword="";this.OV11UserPassword="";this.AV12UserPasswordNew="";this.ZV12UserPasswordNew="";this.OV12UserPasswordNew="";this.AV13UserPasswordNewConf="";this.ZV13UserPasswordNewConf="";this.OV13UserPasswordNewConf="";this.AV10UserName="";this.AV11UserPassword="";this.AV12UserPasswordNew="";this.AV13UserPasswordNewConf="";this.AV6IDP_State="";this.Events={e120h2_client:["ENTER",!0],e130h2_client:["BACKTOLOGIN.CLICK",!0],e150h2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV6IDP_State",fld:"vIDP_STATE",pic:"",hsh:!0}],[]];this.EvtParms.ENTER=[[{av:"AV12UserPasswordNew",fld:"vUSERPASSWORDNEW",pic:""},{av:"AV13UserPasswordNewConf",fld:"vUSERPASSWORDNEWCONF",pic:""},{av:"AV11UserPassword",fld:"vUSERPASSWORD",pic:""},{av:"AV6IDP_State",fld:"vIDP_STATE",pic:"",hsh:!0}],[]];this.EvtParms["BACKTOLOGIN.CLICK"]=[[],[]];this.EnterCtrl=["BTNENTER"];this.setVCMap("AV6IDP_State","vIDP_STATE",0,"char",60,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gamchangepassword)})