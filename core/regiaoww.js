gx.evt.autoSkip=!1;gx.define("core.regiaoww",!1,function(){var t,r,i,e,f,n,u,s,o;this.ServerClass="core.regiaoww";this.PackageName="GeneXus.Programs";this.ServerFullClass="core.regiaoww.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV40ManageFiltersExecutionStep=gx.fn.getIntegerValue("vMANAGEFILTERSEXECUTIONSTEP",".");this.AV35ColumnsSelector=gx.fn.getControlValue("vCOLUMNSSELECTOR");this.AV60Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV41TFRegiaoID=gx.fn.getIntegerValue("vTFREGIAOID",".");this.AV42TFRegiaoID_To=gx.fn.getIntegerValue("vTFREGIAOID_TO",".");this.AV43TFRegiaoSigla=gx.fn.getControlValue("vTFREGIAOSIGLA");this.AV44TFRegiaoSigla_Sel=gx.fn.getControlValue("vTFREGIAOSIGLA_SEL");this.AV45TFRegiaoNome=gx.fn.getControlValue("vTFREGIAONOME");this.AV46TFRegiaoNome_Sel=gx.fn.getControlValue("vTFREGIAONOME_SEL");this.AV14OrderedBy=gx.fn.getIntegerValue("vORDEREDBY",".");this.AV15OrderedDsc=gx.fn.getControlValue("vORDEREDDSC");this.AV59IsAuthorized_RegiaoSigla=gx.fn.getControlValue("vISAUTHORIZED_REGIAOSIGLA");this.AV11GridState=gx.fn.getControlValue("vGRIDSTATE")};this.s142_client=function(){this.DDO_GRIDContainer.SortedStatus=gx.text.trim(gx.num.str(this.AV14OrderedBy,4,0))+":"+(this.AV15OrderedDsc?"DSC":"ASC")};this.s182_client=function(){this.AV17FilterFullText="";this.AV41TFRegiaoID=gx.num.trunc(0,0);this.AV42TFRegiaoID_To=gx.num.trunc(0,0);this.AV43TFRegiaoSigla="";this.AV44TFRegiaoSigla_Sel="";this.AV45TFRegiaoNome="";this.AV46TFRegiaoNome_Sel="";this.DDO_GRIDContainer.SelectedValue_set="";this.DDO_GRIDContainer.FilteredText_set="";this.DDO_GRIDContainer.FilteredTextTo_set=""};this.e12462_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e13462_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e16462_client=function(){return this.executeServerEvent("DDO_GRID.ONOPTIONCLICKED",!1,null,!0,!0)};this.e17462_client=function(){return this.executeServerEvent("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",!1,null,!0,!0)};this.e11462_client=function(){return this.executeServerEvent("DDO_MANAGEFILTERS.ONOPTIONCLICKED",!1,null,!0,!0)};this.e14462_client=function(){return this.executeServerEvent("DDO_AGEXPORT.ONOPTIONCLICKED",!1,null,!0,!0)};this.e15462_client=function(){return this.executeServerEvent("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",!1,null,!0,!0)};this.e21462_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e22462_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,28,31,32,33,34,36,37,38,39,40,42,43,44,45,46,48,49,50,56];this.GXLastCtrlId=56;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",41,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"core.regiaoww",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Novo registro",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);r=this.GridContainer;r.addSingleLineEdit(1,42,"REGIAOID","ID","","RegiaoID","int",0,"px",11,11,"end",null,[],1,"RegiaoID",!0,0,!1,!1,"Attribute",0,"WWColumn");r.addSingleLineEdit(2,43,"REGIAOSIGLA","Sigla","","RegiaoSigla","svchar",0,"px",10,10,"start",null,[],2,"RegiaoSigla",!0,0,!1,!1,"Attribute",0,"WWColumn");r.addSingleLineEdit(3,44,"REGIAONOME","Descrição","","RegiaoNome","svchar",0,"px",50,50,"start",null,[],3,"RegiaoNome",!0,0,!1,!1,"Attribute",0,"WWColumn");this.GridContainer.emptyText="";this.setGrid(r);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,47,32,"DVelop_DVPaginationBar","GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");i=this.GRIDPAGINATIONBARContainer;i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Class","Class","PaginationBar","str");i.setProp("ShowFirst","Showfirst",!0,"bool");i.setProp("ShowPrevious","Showprevious",!0,"bool");i.setProp("ShowNext","Shownext",!0,"bool");i.setProp("ShowLast","Showlast",!0,"bool");i.setProp("PagesToShow","Pagestoshow",5,"num");i.setProp("PagingButtonsPosition","Pagingbuttonsposition","Left","str");i.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");i.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");i.setProp("SelectedPage","Selectedpage","","char");i.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");i.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");i.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");i.setProp("First","First","WWP_PagingFirstCaption","str");i.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");i.setProp("Next","Next","WWP_PagingNextCaption","str");i.setProp("Last","Last","WWP_PagingLastCaption","str");i.setProp("Caption","Caption","Página <CURRENT_PAGE> de <TOTAL_PAGES>","str");i.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");i.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");i.addV2CFunction("AV51GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");i.addC2VFunction(function(n){n.ParentObject.AV51GridCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",n.ParentObject.AV51GridCurrentPage)});i.addV2CFunction("AV52GridPageCount","vGRIDPAGECOUNT","SetPageCount");i.addC2VFunction(function(n){n.ParentObject.AV52GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV52GridPageCount)});i.setProp("RecordCount","Recordcount","","str");i.setProp("Page","Page","","str");i.addV2CFunction("AV53GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");i.addC2VFunction(function(n){n.ParentObject.AV53GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV53GridAppliedFilters)});i.setProp("Visible","Visible",!0,"bool");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("ChangePage",this.e12462_client);i.addEventHandler("ChangeRowsPerPage",this.e13462_client);this.setUserControl(i);this.DDO_AGEXPORTContainer=gx.uc.getNew(this,51,32,"BootstrapDropDownOptions","DDO_AGEXPORTContainer","Ddo_agexport","DDO_AGEXPORT");e=this.DDO_AGEXPORTContainer;e.setProp("Class","Class","","char");e.setProp("Enabled","Enabled",!0,"boolean");e.setProp("IconType","Icontype","FontIcon","str");e.setProp("Icon","Icon","fas fa-download","str");e.setProp("Caption","Caption","Exportar","str");e.setProp("Tooltip","Tooltip","","str");e.setProp("Cls","Cls","ColumnsSelector","str");e.setProp("ActiveEventKey","Activeeventkey","","char");e.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");e.setProp("DropDownOptionsType","Dropdownoptionstype","Regular","str");e.setProp("Visible","Visible",!0,"bool");e.setDynProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");e.addV2CFunction("AV57AGExportData","vAGEXPORTDATA","SetDropDownOptionsData");e.addC2VFunction(function(n){n.ParentObject.AV57AGExportData=n.GetDropDownOptionsData();gx.fn.setControlValue("vAGEXPORTDATA",n.ParentObject.AV57AGExportData)});e.setC2ShowFunction(function(n){n.show()});e.addEventHandler("OnOptionClicked",this.e14462_client);this.setUserControl(e);this.DDC_SUBSCRIPTIONSContainer=gx.uc.getNew(this,52,32,"BootstrapDropDownOptions","DDC_SUBSCRIPTIONSContainer","Ddc_subscriptions","DDC_SUBSCRIPTIONS");f=this.DDC_SUBSCRIPTIONSContainer;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setProp("IconType","Icontype","FontIcon","str");f.setProp("Icon","Icon","fas fa-rss","str");f.setProp("Caption","Caption","","str");f.setProp("Tooltip","Tooltip","WWP_Subscriptions_Tooltip","str");f.setProp("Cls","Cls","ColumnsSelector","str");f.setProp("ComponentWidth","Componentwidth",400,"num");f.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");f.setProp("DropDownOptionsType","Dropdownoptionstype","Component","str");f.setProp("Visible","Visible",!0,"bool");f.setDynProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");f.setProp("ShowLoading","Showloading",!0,"bool");f.setProp("Load","Load","OnEveryClick","str");f.setProp("KeepOpened","Keepopened",!1,"bool");f.setProp("Trigger","Trigger","Click","str");f.setC2ShowFunction(function(n){n.show()});f.addEventHandler("OnLoadComponent",this.e15462_client);this.setUserControl(f);this.DDO_GRIDContainer=gx.uc.getNew(this,53,32,"DDOGridTitleSettingsM","DDO_GRIDContainer","Ddo_grid","DDO_GRID");n=this.DDO_GRIDContainer;n.setProp("Class","Class","","char");n.setProp("Enabled","Enabled",!0,"boolean");n.setProp("IconType","Icontype","Image","str");n.setProp("Icon","Icon","","str");n.setProp("Caption","Caption","","str");n.setProp("Tooltip","Tooltip","","str");n.setProp("Cls","Cls","","str");n.setProp("ActiveEventKey","Activeeventkey","","char");n.setDynProp("FilteredText_set","Filteredtext_set","","char");n.setProp("FilteredText_get","Filteredtext_get","","char");n.setDynProp("FilteredTextTo_set","Filteredtextto_set","","char");n.setProp("FilteredTextTo_get","Filteredtextto_get","","char");n.setDynProp("SelectedValue_set","Selectedvalue_set","","char");n.setProp("SelectedValue_get","Selectedvalue_get","","char");n.setProp("SelectedText_set","Selectedtext_set","","char");n.setProp("SelectedText_get","Selectedtext_get","","char");n.setProp("SelectedColumn","Selectedcolumn","","char");n.setProp("SelectedColumnFixedFilter","Selectedcolumnfixedfilter","","char");n.setDynProp("GAMOAuthToken","Gamoauthtoken","","char");n.setProp("TitleControlAlign","Titlecontrolalign","","str");n.setProp("Visible","Visible","","str");n.setDynProp("GridInternalName","Gridinternalname","","str");n.setProp("ColumnIds","Columnids","0:RegiaoID|1:RegiaoSigla|2:RegiaoNome","str");n.setProp("ColumnsSortValues","Columnssortvalues","2|1|3","str");n.setProp("IncludeSortASC","Includesortasc","T","str");n.setProp("IncludeSortDSC","Includesortdsc","","str");n.setProp("AllowGroup","Allowgroup","","str");n.setProp("Fixable","Fixable","T","str");n.setDynProp("SortedStatus","Sortedstatus","","char");n.setProp("IncludeFilter","Includefilter","T","str");n.setProp("FilterType","Filtertype","Numeric|Character|Character","str");n.setProp("FilterIsRange","Filterisrange","T||","str");n.setProp("IncludeDataList","Includedatalist","|T|T","str");n.setProp("DataListType","Datalisttype","|Dynamic|Dynamic","str");n.setProp("AllowMultipleSelection","Allowmultipleselection","","str");n.setProp("DataListFixedValues","Datalistfixedvalues","","str");n.setProp("DataListProc","Datalistproc","core.regiaoWWGetFilterData","str");n.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");n.setProp("RemoteServicesParameters","Remoteservicesparameters","","str");n.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");n.setProp("FixedFilters","Fixedfilters","","str");n.setProp("Format","Format","9.0||","str");n.setProp("SelectedFixedFilter","Selectedfixedfilter","","char");n.setProp("SortASC","Sortasc","","str");n.setProp("SortDSC","Sortdsc","","str");n.setProp("AllowGroupText","Allowgrouptext","","str");n.setProp("LoadingData","Loadingdata","","str");n.setProp("CleanFilter","Cleanfilter","","str");n.setProp("RangeFilterFrom","Rangefilterfrom","","str");n.setProp("RangeFilterTo","Rangefilterto","","str");n.setProp("NoResultsFound","Noresultsfound","","str");n.setProp("SearchButtonText","Searchbuttontext","","str");n.addV2CFunction("AV47DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");n.addC2VFunction(function(n){n.ParentObject.AV47DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV47DDO_TitleSettingsIcons)});n.setC2ShowFunction(function(n){n.show()});n.addEventHandler("OnOptionClicked",this.e16462_client);this.setUserControl(n);this.DDO_GRIDCOLUMNSSELECTORContainer=gx.uc.getNew(this,54,32,"BootstrapDropDownOptions","DDO_GRIDCOLUMNSSELECTORContainer","Ddo_gridcolumnsselector","DDO_GRIDCOLUMNSSELECTOR");u=this.DDO_GRIDCOLUMNSSELECTORContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("IconType","Icontype","FontIcon","str");u.setProp("Icon","Icon","fas fa-cog","str");u.setProp("Caption","Caption","Selecionar colunas","str");u.setProp("Tooltip","Tooltip","WWP_EditColumnsTooltip","str");u.setProp("Cls","Cls","ColumnsSelector hidden-xs","str");u.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");u.setProp("DropDownOptionsType","Dropdownoptionstype","GridColumnsSelector","str");u.setProp("Visible","Visible",!0,"bool");u.setDynProp("GridInternalName","Gridinternalname","","char");u.setDynProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");u.setProp("ColumnsSelectorValues","Columnsselectorvalues","","char");u.setProp("UpdateButtonText","Updatebuttontext","","str");u.addV2CFunction("AV47DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");u.addC2VFunction(function(n){n.ParentObject.AV47DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV47DDO_TitleSettingsIcons)});u.addV2CFunction("AV35ColumnsSelector","vCOLUMNSSELECTOR","SetDropDownOptionsData");u.addC2VFunction(function(n){n.ParentObject.AV35ColumnsSelector=n.GetDropDownOptionsData();gx.fn.setControlValue("vCOLUMNSSELECTOR",n.ParentObject.AV35ColumnsSelector)});u.setC2ShowFunction(function(n){n.show()});u.addEventHandler("OnColumnsChanged",this.e17462_client);this.setUserControl(u);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,55,32,"WWP_GridEmpowerer","GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");s=this.GRID_EMPOWERERContainer;s.setProp("Class","Class","","char");s.setProp("Enabled","Enabled",!0,"boolean");s.setDynProp("GridInternalName","Gridinternalname","","char");s.setProp("HasCategories","Hascategories",!1,"bool");s.setProp("InfiniteScrolling","Infinitescrolling","False","str");s.setProp("HasTitleSettings","Hastitlesettings",!0,"bool");s.setProp("HasColumnsSelector","Hascolumnsselector",!0,"bool");s.setProp("HasRowGroups","Hasrowgroups",!1,"bool");s.setProp("FixedColumns","Fixedcolumns","","str");s.setProp("PopoversInGrid","Popoversingrid","","str");s.setProp("Visible","Visible",!0,"bool");s.setC2ShowFunction(function(n){n.show()});this.setUserControl(s);this.DDO_MANAGEFILTERSContainer=gx.uc.getNew(this,26,0,"BootstrapDropDownOptions","DDO_MANAGEFILTERSContainer","Ddo_managefilters","DDO_MANAGEFILTERS");o=this.DDO_MANAGEFILTERSContainer;o.setProp("Class","Class","","char");o.setProp("Enabled","Enabled",!0,"boolean");o.setProp("IconType","Icontype","FontIcon","str");o.setProp("Icon","Icon","fas fa-filter","str");o.setProp("Caption","Caption","","str");o.setProp("Tooltip","Tooltip","WWP_ManageFiltersTooltip","str");o.setProp("Cls","Cls","ManageFilters","str");o.setProp("ActiveEventKey","Activeeventkey","","char");o.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");o.setProp("DropDownOptionsType","Dropdownoptionstype","Regular","str");o.setProp("Visible","Visible",!0,"bool");o.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");o.addV2CFunction("AV38ManageFiltersData","vMANAGEFILTERSDATA","SetDropDownOptionsData");o.addC2VFunction(function(n){n.ParentObject.AV38ManageFiltersData=n.GetDropDownOptionsData();gx.fn.setControlValue("vMANAGEFILTERSDATA",n.ParentObject.AV38ManageFiltersData)});o.setC2ShowFunction(function(n){n.show()});o.addEventHandler("OnOptionClicked",this.e11462_client);this.setUserControl(o);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TABLEHEADER",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"TABLEHEADERCONTENT",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"TABLEACTIONS",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"BTNAGEXPORT",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"BTNEDITCOLUMNS",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"BTNSUBSCRIPTIONS",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"TABLERIGHTHEADER",grid:0};t[28]={id:28,fld:"TABLEFILTERS",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vFILTERFULLTEXT",fmt:0,gxz:"ZV17FilterFullText",gxold:"OV17FilterFullText",gxvar:"AV17FilterFullText",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV17FilterFullText=n)},v2z:function(n){n!==undefined&&(gx.O.ZV17FilterFullText=n)},v2c:function(){gx.fn.setControlValue("vFILTERFULLTEXT",gx.O.AV17FilterFullText,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV17FilterFullText=this.val())},val:function(){return gx.fn.getControlValue("vFILTERFULLTEXT")},nac:gx.falseFn};this.declareDomainHdlr(32,function(){});t[33]={id:33,fld:"",grid:0};t[34]={id:34,fld:"",grid:0};t[36]={id:36,fld:"",grid:0};t[37]={id:37,fld:"",grid:0};t[38]={id:38,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};t[39]={id:39,fld:"",grid:0};t[40]={id:40,fld:"",grid:0};t[42]={id:42,lvl:2,type:"int",len:9,dec:0,sign:!1,pic:"ZZZ,ZZZ,ZZ9",ro:1,isacc:0,grid:41,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"REGIAOID",fmt:0,gxz:"Z1RegiaoID",gxold:"O1RegiaoID",gxvar:"A1RegiaoID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A1RegiaoID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1RegiaoID=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("REGIAOID",n||gx.fn.currentGridRowImpl(41),gx.O.A1RegiaoID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1RegiaoID=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("REGIAOID",n||gx.fn.currentGridRowImpl(41),".")},nac:gx.falseFn};t[43]={id:43,lvl:2,type:"svchar",len:10,dec:0,sign:!1,pic:"@!",ro:1,isacc:0,grid:41,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"REGIAOSIGLA",fmt:0,gxz:"Z2RegiaoSigla",gxold:"O2RegiaoSigla",gxvar:"A2RegiaoSigla",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2RegiaoSigla=n)},v2z:function(n){n!==undefined&&(gx.O.Z2RegiaoSigla=n)},v2c:function(n){gx.fn.setGridControlValue("REGIAOSIGLA",n||gx.fn.currentGridRowImpl(41),gx.O.A2RegiaoSigla,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2RegiaoSigla=this.val(n))},val:function(n){return gx.fn.getGridControlValue("REGIAOSIGLA",n||gx.fn.currentGridRowImpl(41))},nac:gx.falseFn};t[44]={id:44,lvl:2,type:"svchar",len:50,dec:0,sign:!1,ro:1,isacc:0,grid:41,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"REGIAONOME",fmt:0,gxz:"Z3RegiaoNome",gxold:"O3RegiaoNome",gxvar:"A3RegiaoNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A3RegiaoNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z3RegiaoNome=n)},v2c:function(n){gx.fn.setGridControlValue("REGIAONOME",n||gx.fn.currentGridRowImpl(41),gx.O.A3RegiaoNome,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A3RegiaoNome=this.val(n))},val:function(n){return gx.fn.getGridControlValue("REGIAONOME",n||gx.fn.currentGridRowImpl(41))},nac:gx.falseFn};t[45]={id:45,fld:"",grid:0};t[46]={id:46,fld:"",grid:0};t[48]={id:48,fld:"",grid:0};t[49]={id:49,fld:"",grid:0};t[50]={id:50,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};t[56]={id:56,fld:"DIV_WWPAUXWC",grid:0};this.AV17FilterFullText="";this.ZV17FilterFullText="";this.OV17FilterFullText="";this.Z1RegiaoID=0;this.O1RegiaoID=0;this.Z2RegiaoSigla="";this.O2RegiaoSigla="";this.Z3RegiaoNome="";this.O3RegiaoNome="";this.AV38ManageFiltersData=[];this.AV17FilterFullText="";this.AV51GridCurrentPage=0;this.AV57AGExportData=[];this.AV47DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:"",OptionGroup_fi:""};this.A1RegiaoID=0;this.A2RegiaoSigla="";this.A3RegiaoNome="";this.AV40ManageFiltersExecutionStep=0;this.AV35ColumnsSelector={Columns:[]};this.AV60Pgmname="";this.AV41TFRegiaoID=0;this.AV42TFRegiaoID_To=0;this.AV43TFRegiaoSigla="";this.AV44TFRegiaoSigla_Sel="";this.AV45TFRegiaoNome="";this.AV46TFRegiaoNome_Sel="";this.AV14OrderedBy=0;this.AV15OrderedDsc=!1;this.AV59IsAuthorized_RegiaoSigla=!1;this.AV11GridState={CurrentPage:0,OrderedBy:0,OrderedDsc:!1,HidingSearch:0,PageSize:"",CollapsedRecords:"",GroupBy:"",FilterValues:[],DynamicFilters:[]};this.Events={e12462_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e13462_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e16462_client:["DDO_GRID.ONOPTIONCLICKED",!0],e17462_client:["DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",!0],e11462_client:["DDO_MANAGEFILTERS.ONOPTIONCLICKED",!0],e14462_client:["DDO_AGEXPORT.ONOPTIONCLICKED",!0],e15462_client:["DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",!0],e21462_client:["ENTER",!0],e22462_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV35ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{ctrl:"GRID",prop:"Rows"},{av:"AV17FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV60Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV41TFRegiaoID",fld:"vTFREGIAOID",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV42TFRegiaoID_To",fld:"vTFREGIAOID_TO",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV43TFRegiaoSigla",fld:"vTFREGIAOSIGLA",pic:"@!"},{av:"AV44TFRegiaoSigla_Sel",fld:"vTFREGIAOSIGLA_SEL",pic:"@!"},{av:"AV45TFRegiaoNome",fld:"vTFREGIAONOME",pic:""},{av:"AV46TFRegiaoNome_Sel",fld:"vTFREGIAONOME_SEL",pic:""},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV59IsAuthorized_RegiaoSigla",fld:"vISAUTHORIZED_REGIAOSIGLA",pic:"",hsh:!0}],[{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV35ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:'gx.fn.getCtrlProperty("REGIAOID","Visible")',ctrl:"REGIAOID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("REGIAOSIGLA","Visible")',ctrl:"REGIAOSIGLA",prop:"Visible"},{av:'gx.fn.getCtrlProperty("REGIAONOME","Visible")',ctrl:"REGIAONOME",prop:"Visible"},{av:"AV51GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV52GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV53GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{ctrl:"BTNSUBSCRIPTIONS",prop:"Visible"},{av:"AV38ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV11GridState",fld:"vGRIDSTATE",pic:""}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV17FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV35ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:"AV60Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV41TFRegiaoID",fld:"vTFREGIAOID",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV42TFRegiaoID_To",fld:"vTFREGIAOID_TO",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV43TFRegiaoSigla",fld:"vTFREGIAOSIGLA",pic:"@!"},{av:"AV44TFRegiaoSigla_Sel",fld:"vTFREGIAOSIGLA_SEL",pic:"@!"},{av:"AV45TFRegiaoNome",fld:"vTFREGIAONOME",pic:""},{av:"AV46TFRegiaoNome_Sel",fld:"vTFREGIAONOME_SEL",pic:""},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV59IsAuthorized_RegiaoSigla",fld:"vISAUTHORIZED_REGIAOSIGLA",pic:"",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV17FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV35ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:"AV60Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV41TFRegiaoID",fld:"vTFREGIAOID",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV42TFRegiaoID_To",fld:"vTFREGIAOID_TO",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV43TFRegiaoSigla",fld:"vTFREGIAOSIGLA",pic:"@!"},{av:"AV44TFRegiaoSigla_Sel",fld:"vTFREGIAOSIGLA_SEL",pic:"@!"},{av:"AV45TFRegiaoNome",fld:"vTFREGIAONOME",pic:""},{av:"AV46TFRegiaoNome_Sel",fld:"vTFREGIAONOME_SEL",pic:""},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV59IsAuthorized_RegiaoSigla",fld:"vISAUTHORIZED_REGIAOSIGLA",pic:"",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{ctrl:"GRID",prop:"Rows"}]];this.EvtParms["DDO_GRID.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV17FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV35ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:"AV60Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV41TFRegiaoID",fld:"vTFREGIAOID",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV42TFRegiaoID_To",fld:"vTFREGIAOID_TO",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV43TFRegiaoSigla",fld:"vTFREGIAOSIGLA",pic:"@!"},{av:"AV44TFRegiaoSigla_Sel",fld:"vTFREGIAOSIGLA_SEL",pic:"@!"},{av:"AV45TFRegiaoNome",fld:"vTFREGIAONOME",pic:""},{av:"AV46TFRegiaoNome_Sel",fld:"vTFREGIAONOME_SEL",pic:""},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV59IsAuthorized_RegiaoSigla",fld:"vISAUTHORIZED_REGIAOSIGLA",pic:"",hsh:!0},{av:"this.DDO_GRIDContainer.ActiveEventKey",ctrl:"DDO_GRID",prop:"ActiveEventKey"},{av:"this.DDO_GRIDContainer.SelectedValue_get",ctrl:"DDO_GRID",prop:"SelectedValue_get"},{av:"this.DDO_GRIDContainer.SelectedColumn",ctrl:"DDO_GRID",prop:"SelectedColumn"},{av:"this.DDO_GRIDContainer.FilteredText_get",ctrl:"DDO_GRID",prop:"FilteredText_get"},{av:"this.DDO_GRIDContainer.FilteredTextTo_get",ctrl:"DDO_GRID",prop:"FilteredTextTo_get"}],[{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV41TFRegiaoID",fld:"vTFREGIAOID",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV42TFRegiaoID_To",fld:"vTFREGIAOID_TO",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV43TFRegiaoSigla",fld:"vTFREGIAOSIGLA",pic:"@!"},{av:"AV44TFRegiaoSigla_Sel",fld:"vTFREGIAOSIGLA_SEL",pic:"@!"},{av:"AV45TFRegiaoNome",fld:"vTFREGIAONOME",pic:""},{av:"AV46TFRegiaoNome_Sel",fld:"vTFREGIAONOME_SEL",pic:""},{av:"this.DDO_GRIDContainer.SortedStatus",ctrl:"DDO_GRID",prop:"SortedStatus"}]];this.EvtParms["GRID.LOAD"]=[[{av:"AV59IsAuthorized_RegiaoSigla",fld:"vISAUTHORIZED_REGIAOSIGLA",pic:"",hsh:!0},{av:"A1RegiaoID",fld:"REGIAOID",pic:"ZZZ,ZZZ,ZZ9"}],[{av:'gx.fn.getCtrlProperty("REGIAOSIGLA","Link")',ctrl:"REGIAOSIGLA",prop:"Link"}]];this.EvtParms["DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV17FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV35ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:"AV60Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV41TFRegiaoID",fld:"vTFREGIAOID",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV42TFRegiaoID_To",fld:"vTFREGIAOID_TO",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV43TFRegiaoSigla",fld:"vTFREGIAOSIGLA",pic:"@!"},{av:"AV44TFRegiaoSigla_Sel",fld:"vTFREGIAOSIGLA_SEL",pic:"@!"},{av:"AV45TFRegiaoNome",fld:"vTFREGIAONOME",pic:""},{av:"AV46TFRegiaoNome_Sel",fld:"vTFREGIAONOME_SEL",pic:""},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV59IsAuthorized_RegiaoSigla",fld:"vISAUTHORIZED_REGIAOSIGLA",pic:"",hsh:!0},{av:"this.DDO_GRIDCOLUMNSSELECTORContainer.ColumnsSelectorValues",ctrl:"DDO_GRIDCOLUMNSSELECTOR",prop:"ColumnsSelectorValues"}],[{av:"AV35ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:'gx.fn.getCtrlProperty("REGIAOID","Visible")',ctrl:"REGIAOID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("REGIAOSIGLA","Visible")',ctrl:"REGIAOSIGLA",prop:"Visible"},{av:'gx.fn.getCtrlProperty("REGIAONOME","Visible")',ctrl:"REGIAONOME",prop:"Visible"},{av:"AV51GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV52GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV53GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{ctrl:"BTNSUBSCRIPTIONS",prop:"Visible"},{av:"AV38ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV11GridState",fld:"vGRIDSTATE",pic:""}]];this.EvtParms["DDO_MANAGEFILTERS.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV17FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV35ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:"AV60Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV41TFRegiaoID",fld:"vTFREGIAOID",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV42TFRegiaoID_To",fld:"vTFREGIAOID_TO",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV43TFRegiaoSigla",fld:"vTFREGIAOSIGLA",pic:"@!"},{av:"AV44TFRegiaoSigla_Sel",fld:"vTFREGIAOSIGLA_SEL",pic:"@!"},{av:"AV45TFRegiaoNome",fld:"vTFREGIAONOME",pic:""},{av:"AV46TFRegiaoNome_Sel",fld:"vTFREGIAONOME_SEL",pic:""},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV59IsAuthorized_RegiaoSigla",fld:"vISAUTHORIZED_REGIAOSIGLA",pic:"",hsh:!0},{av:"this.DDO_MANAGEFILTERSContainer.ActiveEventKey",ctrl:"DDO_MANAGEFILTERS",prop:"ActiveEventKey"},{av:"AV11GridState",fld:"vGRIDSTATE",pic:""}],[{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV11GridState",fld:"vGRIDSTATE",pic:""},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV17FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV41TFRegiaoID",fld:"vTFREGIAOID",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV42TFRegiaoID_To",fld:"vTFREGIAOID_TO",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV43TFRegiaoSigla",fld:"vTFREGIAOSIGLA",pic:"@!"},{av:"AV44TFRegiaoSigla_Sel",fld:"vTFREGIAOSIGLA_SEL",pic:"@!"},{av:"AV45TFRegiaoNome",fld:"vTFREGIAONOME",pic:""},{av:"AV46TFRegiaoNome_Sel",fld:"vTFREGIAONOME_SEL",pic:""},{av:"this.DDO_GRIDContainer.SelectedValue_set",ctrl:"DDO_GRID",prop:"SelectedValue_set"},{av:"this.DDO_GRIDContainer.FilteredText_set",ctrl:"DDO_GRID",prop:"FilteredText_set"},{av:"this.DDO_GRIDContainer.FilteredTextTo_set",ctrl:"DDO_GRID",prop:"FilteredTextTo_set"},{av:"this.DDO_GRIDContainer.SortedStatus",ctrl:"DDO_GRID",prop:"SortedStatus"},{av:"AV35ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:'gx.fn.getCtrlProperty("REGIAOID","Visible")',ctrl:"REGIAOID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("REGIAOSIGLA","Visible")',ctrl:"REGIAOSIGLA",prop:"Visible"},{av:'gx.fn.getCtrlProperty("REGIAONOME","Visible")',ctrl:"REGIAONOME",prop:"Visible"},{av:"AV51GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV52GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV53GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{ctrl:"BTNSUBSCRIPTIONS",prop:"Visible"},{av:"AV38ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""}]];this.EvtParms["DDO_AGEXPORT.ONOPTIONCLICKED"]=[[{av:"this.DDO_AGEXPORTContainer.ActiveEventKey",ctrl:"DDO_AGEXPORT",prop:"ActiveEventKey"},{av:"AV60Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV11GridState",fld:"vGRIDSTATE",pic:""},{av:"AV44TFRegiaoSigla_Sel",fld:"vTFREGIAOSIGLA_SEL",pic:"@!"},{av:"AV46TFRegiaoNome_Sel",fld:"vTFREGIAONOME_SEL",pic:""},{av:"AV41TFRegiaoID",fld:"vTFREGIAOID",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV43TFRegiaoSigla",fld:"vTFREGIAOSIGLA",pic:"@!"},{av:"AV45TFRegiaoNome",fld:"vTFREGIAONOME",pic:""},{av:"AV42TFRegiaoID_To",fld:"vTFREGIAOID_TO",pic:"ZZZ,ZZZ,ZZ9"}],[{av:"AV11GridState",fld:"vGRIDSTATE",pic:""},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{ctrl:"GRID",prop:"Rows"},{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV17FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV35ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:"AV60Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV41TFRegiaoID",fld:"vTFREGIAOID",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV42TFRegiaoID_To",fld:"vTFREGIAOID_TO",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV43TFRegiaoSigla",fld:"vTFREGIAOSIGLA",pic:"@!"},{av:"AV44TFRegiaoSigla_Sel",fld:"vTFREGIAOSIGLA_SEL",pic:"@!"},{av:"AV45TFRegiaoNome",fld:"vTFREGIAONOME",pic:""},{av:"AV46TFRegiaoNome_Sel",fld:"vTFREGIAONOME_SEL",pic:""},{av:"AV59IsAuthorized_RegiaoSigla",fld:"vISAUTHORIZED_REGIAOSIGLA",pic:"",hsh:!0},{av:"this.DDO_GRIDContainer.SortedStatus",ctrl:"DDO_GRID",prop:"SortedStatus"},{av:"this.DDO_GRIDContainer.SelectedValue_set",ctrl:"DDO_GRID",prop:"SelectedValue_set"},{av:"this.DDO_GRIDContainer.FilteredText_set",ctrl:"DDO_GRID",prop:"FilteredText_set"},{av:"this.DDO_GRIDContainer.FilteredTextTo_set",ctrl:"DDO_GRID",prop:"FilteredTextTo_set"}]];this.EvtParms["DDC_SUBSCRIPTIONS.ONLOADCOMPONENT"]=[[],[{ctrl:"WWPAUX_WC"}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV40ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV35ColumnsSelector","vCOLUMNSSELECTOR",0,"WWPBaseObjectsWWPColumnsSelector",0,0);this.setVCMap("AV60Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV41TFRegiaoID","vTFREGIAOID",0,"int",9,0);this.setVCMap("AV42TFRegiaoID_To","vTFREGIAOID_TO",0,"int",9,0);this.setVCMap("AV43TFRegiaoSigla","vTFREGIAOSIGLA",0,"svchar",10,0);this.setVCMap("AV44TFRegiaoSigla_Sel","vTFREGIAOSIGLA_SEL",0,"svchar",10,0);this.setVCMap("AV45TFRegiaoNome","vTFREGIAONOME",0,"svchar",50,0);this.setVCMap("AV46TFRegiaoNome_Sel","vTFREGIAONOME_SEL",0,"svchar",50,0);this.setVCMap("AV14OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV15OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV59IsAuthorized_RegiaoSigla","vISAUTHORIZED_REGIAOSIGLA",0,"boolean",4,0);this.setVCMap("AV11GridState","vGRIDSTATE",0,"WWPBaseObjectsWWPGridState",0,0);this.setVCMap("AV40ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV35ColumnsSelector","vCOLUMNSSELECTOR",0,"WWPBaseObjectsWWPColumnsSelector",0,0);this.setVCMap("AV60Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV41TFRegiaoID","vTFREGIAOID",0,"int",9,0);this.setVCMap("AV42TFRegiaoID_To","vTFREGIAOID_TO",0,"int",9,0);this.setVCMap("AV43TFRegiaoSigla","vTFREGIAOSIGLA",0,"svchar",10,0);this.setVCMap("AV44TFRegiaoSigla_Sel","vTFREGIAOSIGLA_SEL",0,"svchar",10,0);this.setVCMap("AV45TFRegiaoNome","vTFREGIAONOME",0,"svchar",50,0);this.setVCMap("AV46TFRegiaoNome_Sel","vTFREGIAONOME_SEL",0,"svchar",50,0);this.setVCMap("AV14OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV15OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV59IsAuthorized_RegiaoSigla","vISAUTHORIZED_REGIAOSIGLA",0,"boolean",4,0);this.setVCMap("AV40ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV35ColumnsSelector","vCOLUMNSSELECTOR",0,"WWPBaseObjectsWWPColumnsSelector",0,0);this.setVCMap("AV60Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV41TFRegiaoID","vTFREGIAOID",0,"int",9,0);this.setVCMap("AV42TFRegiaoID_To","vTFREGIAOID_TO",0,"int",9,0);this.setVCMap("AV43TFRegiaoSigla","vTFREGIAOSIGLA",0,"svchar",10,0);this.setVCMap("AV44TFRegiaoSigla_Sel","vTFREGIAOSIGLA_SEL",0,"svchar",10,0);this.setVCMap("AV45TFRegiaoNome","vTFREGIAONOME",0,"svchar",50,0);this.setVCMap("AV46TFRegiaoNome_Sel","vTFREGIAONOME_SEL",0,"svchar",50,0);this.setVCMap("AV14OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV15OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV59IsAuthorized_RegiaoSigla","vISAUTHORIZED_REGIAOSIGLA",0,"boolean",4,0);r.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});r.addRefreshingVar(this.GXValidFnc[32]);r.addRefreshingVar({rfrVar:"AV40ManageFiltersExecutionStep"});r.addRefreshingVar({rfrVar:"AV35ColumnsSelector"});r.addRefreshingVar({rfrVar:"AV60Pgmname"});r.addRefreshingVar({rfrVar:"AV41TFRegiaoID"});r.addRefreshingVar({rfrVar:"AV42TFRegiaoID_To"});r.addRefreshingVar({rfrVar:"AV43TFRegiaoSigla"});r.addRefreshingVar({rfrVar:"AV44TFRegiaoSigla_Sel"});r.addRefreshingVar({rfrVar:"AV45TFRegiaoNome"});r.addRefreshingVar({rfrVar:"AV46TFRegiaoNome_Sel"});r.addRefreshingVar({rfrVar:"AV14OrderedBy"});r.addRefreshingVar({rfrVar:"AV15OrderedDsc"});r.addRefreshingVar({rfrVar:"AV59IsAuthorized_RegiaoSigla"});r.addRefreshingParm(this.GXValidFnc[32]);r.addRefreshingParm({rfrVar:"AV40ManageFiltersExecutionStep"});r.addRefreshingParm({rfrVar:"AV35ColumnsSelector"});r.addRefreshingParm({rfrVar:"AV60Pgmname"});r.addRefreshingParm({rfrVar:"AV41TFRegiaoID"});r.addRefreshingParm({rfrVar:"AV42TFRegiaoID_To"});r.addRefreshingParm({rfrVar:"AV43TFRegiaoSigla"});r.addRefreshingParm({rfrVar:"AV44TFRegiaoSigla_Sel"});r.addRefreshingParm({rfrVar:"AV45TFRegiaoNome"});r.addRefreshingParm({rfrVar:"AV46TFRegiaoNome_Sel"});r.addRefreshingParm({rfrVar:"AV14OrderedBy"});r.addRefreshingParm({rfrVar:"AV15OrderedDsc"});r.addRefreshingParm({rfrVar:"AV59IsAuthorized_RegiaoSigla"});this.Initialize();this.setComponent({id:"WWPAUX_WC",GXClass:null,Prefix:"W0057",lvl:1});this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState",{FilterValues:{sdt:"WWPBaseObjects\\WWPGridState.FilterValue"},DynamicFilters:{sdt:"WWPBaseObjects\\WWPGridState.DynamicFilter"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState.DynamicFilter",{Dsc:{extr:"d"}});this.setSDTMapping("WWPBaseObjects\\WWPColumnsSelector",{Columns:{sdt:"WWPBaseObjects\\WWPColumnsSelector.Column"}});this.setSDTMapping("WWPBaseObjects\\WWPColumnsSelector.Column",{ColumnName:{extr:"C"},IsVisible:{extr:"V"},DisplayName:{extr:"D"},Order:{extr:"O"},Category:{extr:"G"},Fixed:{extr:"F"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"},OptionGroup_fi:{extr:"og"}});this.setSDTMapping("GeneXusSecurity\\GAMSession",{User:{sdt:"GeneXusSecurity\\GAMUser"},SecurityPolicy:{sdt:"GeneXusSecurity\\GAMSecurityPolicy"}});this.setSDTMapping("GeneXusSecurity\\GAMApplication",{Environment:{sdt:"GeneXusSecurity\\GAMApplicationEnvironment"}});this.setSDTMapping("GeneXusSecurity\\GAMMenuOptionList",{Nodes:{sdt:"GeneXusSecurity\\GAMMenuOptionList"}})});gx.wi(function(){gx.createParentObj(this.core.regiaoww)})