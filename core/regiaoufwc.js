gx.evt.autoSkip=!1;gx.define("core.regiaoufwc",!0,function(n){var r,u,i,t,e,f;this.ServerClass="core.regiaoufwc";this.PackageName="GeneXus.Programs";this.ServerFullClass="core.regiaoufwc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV20ManageFiltersExecutionStep=gx.fn.getIntegerValue("vMANAGEFILTERSEXECUTIONSTEP",".");this.AV32Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV14OrderedBy=gx.fn.getIntegerValue("vORDEREDBY",".");this.AV15OrderedDsc=gx.fn.getControlValue("vORDEREDDSC");this.AV31IsAuthorized_UFSigla=gx.fn.getControlValue("vISAUTHORIZED_UFSIGLA");this.AV12GridState=gx.fn.getControlValue("vGRIDSTATE");this.AV8UFRegID=gx.fn.getIntegerValue("vUFREGID",".")};this.s142_client=function(){this.DDO_GRIDContainer.SortedStatus=gx.text.trim(gx.num.str(this.AV14OrderedBy,4,0))+":"+(this.AV15OrderedDsc?"DSC":"ASC")};this.s162_client=function(){this.AV16FilterFullText=""};this.e12482_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e13482_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e14482_client=function(){return this.executeServerEvent("DDO_GRID.ONOPTIONCLICKED",!1,null,!0,!0)};this.e11482_client=function(){return this.executeServerEvent("DDO_MANAGEFILTERS.ONOPTIONCLICKED",!1,null,!0,!0)};this.e18482_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e19482_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];r=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,15,16,21,24,25,26,27,28,29,30,32,33,34,35,36,37,39,40,41,43];this.GXLastCtrlId=43;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",31,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"core.regiaoufwc",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Novo registro",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);u=this.GridContainer;u.addSingleLineEdit(4,32,"UFID","UF","","UFID","int",0,"px",11,11,"end",null,[],4,"UFID",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");u.addSingleLineEdit(5,33,"UFSIGLA","Sigla","","UFSigla","svchar",0,"px",2,2,"start",null,[],5,"UFSigla",!0,0,!1,!1,"Attribute",0,"WWColumn");u.addSingleLineEdit(6,34,"UFNOME","Nome","","UFNome","svchar",0,"px",50,50,"start",null,[],6,"UFNome",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");u.addSingleLineEdit(12,35,"UFSIGLANOME","UF","","UFSiglaNome","svchar",0,"px",70,70,"start",null,[],12,"UFSiglaNome",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");this.GridContainer.emptyText="";this.setGrid(u);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,38,25,"DVelop_DVPaginationBar",this.CmpContext+"GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");i=this.GRIDPAGINATIONBARContainer;i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Class","Class","PaginationBar","str");i.setProp("ShowFirst","Showfirst",!0,"bool");i.setProp("ShowPrevious","Showprevious",!0,"bool");i.setProp("ShowNext","Shownext",!0,"bool");i.setProp("ShowLast","Showlast",!0,"bool");i.setProp("PagesToShow","Pagestoshow",5,"num");i.setProp("PagingButtonsPosition","Pagingbuttonsposition","Left","str");i.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");i.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");i.setProp("SelectedPage","Selectedpage","","char");i.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");i.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");i.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");i.setProp("First","First","WWP_PagingFirstCaption","str");i.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");i.setProp("Next","Next","WWP_PagingNextCaption","str");i.setProp("Last","Last","WWP_PagingLastCaption","str");i.setProp("Caption","Caption","Página <CURRENT_PAGE> de <TOTAL_PAGES>","str");i.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");i.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");i.addV2CFunction("AV24GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");i.addC2VFunction(function(n){n.ParentObject.AV24GridCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",n.ParentObject.AV24GridCurrentPage)});i.addV2CFunction("AV25GridPageCount","vGRIDPAGECOUNT","SetPageCount");i.addC2VFunction(function(n){n.ParentObject.AV25GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV25GridPageCount)});i.setProp("RecordCount","Recordcount","","str");i.setProp("Page","Page","","str");i.addV2CFunction("AV26GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");i.addC2VFunction(function(n){n.ParentObject.AV26GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV26GridAppliedFilters)});i.setProp("Visible","Visible",!0,"bool");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("ChangePage",this.e12482_client);i.addEventHandler("ChangeRowsPerPage",this.e13482_client);this.setUserControl(i);this.DDO_GRIDContainer=gx.uc.getNew(this,42,25,"DDOGridTitleSettingsM",this.CmpContext+"DDO_GRIDContainer","Ddo_grid","DDO_GRID");t=this.DDO_GRIDContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","","str");t.setProp("ActiveEventKey","Activeeventkey","","char");t.setProp("FilteredText_set","Filteredtext_set","","char");t.setProp("FilteredText_get","Filteredtext_get","","char");t.setProp("FilteredTextTo_set","Filteredtextto_set","","char");t.setProp("FilteredTextTo_get","Filteredtextto_get","","char");t.setProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setProp("SelectedColumn","Selectedcolumn","","char");t.setProp("SelectedColumnFixedFilter","Selectedcolumnfixedfilter","","char");t.setProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("TitleControlAlign","Titlecontrolalign","","str");t.setProp("Visible","Visible","","str");t.setDynProp("GridInternalName","Gridinternalname","","str");t.setProp("ColumnIds","Columnids","0:UFID|1:UFSigla|2:UFNome|3:UFSiglaNome","str");t.setProp("ColumnsSortValues","Columnssortvalues","2|1|3|4","str");t.setProp("IncludeSortASC","Includesortasc","T","str");t.setProp("IncludeSortDSC","Includesortdsc","","str");t.setProp("AllowGroup","Allowgroup","","str");t.setProp("Fixable","Fixable","","str");t.setDynProp("SortedStatus","Sortedstatus","","char");t.setProp("IncludeFilter","Includefilter","","str");t.setProp("FilterType","Filtertype","","str");t.setProp("FilterIsRange","Filterisrange","","str");t.setProp("IncludeDataList","Includedatalist","","str");t.setProp("DataListType","Datalisttype","","str");t.setProp("AllowMultipleSelection","Allowmultipleselection","","str");t.setProp("DataListFixedValues","Datalistfixedvalues","","str");t.setProp("DataListProc","Datalistproc","","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");t.setProp("RemoteServicesParameters","Remoteservicesparameters","","str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("FixedFilters","Fixedfilters","","str");t.setProp("Format","Format","","str");t.setProp("SelectedFixedFilter","Selectedfixedfilter","","char");t.setProp("SortASC","Sortasc","","str");t.setProp("SortDSC","Sortdsc","","str");t.setProp("AllowGroupText","Allowgrouptext","","str");t.setProp("LoadingData","Loadingdata","","str");t.setProp("CleanFilter","Cleanfilter","","str");t.setProp("RangeFilterFrom","Rangefilterfrom","","str");t.setProp("RangeFilterTo","Rangefilterto","","str");t.setProp("NoResultsFound","Noresultsfound","","str");t.setProp("SearchButtonText","Searchbuttontext","","str");t.addV2CFunction("AV21DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");t.addC2VFunction(function(n){n.ParentObject.AV21DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV21DDO_TitleSettingsIcons)});t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e14482_client);this.setUserControl(t);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,44,25,"WWP_GridEmpowerer",this.CmpContext+"GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");e=this.GRID_EMPOWERERContainer;e.setProp("Class","Class","","char");e.setProp("Enabled","Enabled",!0,"boolean");e.setDynProp("GridInternalName","Gridinternalname","","char");e.setProp("HasCategories","Hascategories",!1,"bool");e.setProp("InfiniteScrolling","Infinitescrolling","False","str");e.setProp("HasTitleSettings","Hastitlesettings",!0,"bool");e.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");e.setProp("HasRowGroups","Hasrowgroups",!1,"bool");e.setProp("FixedColumns","Fixedcolumns","","str");e.setProp("PopoversInGrid","Popoversingrid","","str");e.setProp("Visible","Visible",!0,"bool");e.setC2ShowFunction(function(n){n.show()});this.setUserControl(e);this.DDO_MANAGEFILTERSContainer=gx.uc.getNew(this,19,0,"BootstrapDropDownOptions",this.CmpContext+"DDO_MANAGEFILTERSContainer","Ddo_managefilters","DDO_MANAGEFILTERS");f=this.DDO_MANAGEFILTERSContainer;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setProp("IconType","Icontype","FontIcon","str");f.setProp("Icon","Icon","fas fa-filter","str");f.setProp("Caption","Caption","","str");f.setProp("Tooltip","Tooltip","WWP_ManageFiltersTooltip","str");f.setProp("Cls","Cls","ManageFilters","str");f.setProp("ActiveEventKey","Activeeventkey","","char");f.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");f.setProp("DropDownOptionsType","Dropdownoptionstype","Regular","str");f.setProp("Visible","Visible",!0,"bool");f.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");f.addV2CFunction("AV18ManageFiltersData","vMANAGEFILTERSDATA","SetDropDownOptionsData");f.addC2VFunction(function(n){n.ParentObject.AV18ManageFiltersData=n.GetDropDownOptionsData();gx.fn.setControlValue("vMANAGEFILTERSDATA",n.ParentObject.AV18ManageFiltersData)});f.setC2ShowFunction(function(n){n.show()});f.addEventHandler("OnOptionClicked",this.e11482_client);this.setUserControl(f);r[2]={id:2,fld:"",grid:0};r[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};r[4]={id:4,fld:"",grid:0};r[5]={id:5,fld:"",grid:0};r[6]={id:6,fld:"TABLEGRIDHEADER",grid:0};r[7]={id:7,fld:"",grid:0};r[8]={id:8,fld:"",grid:0};r[10]={id:10,fld:"",grid:0};r[11]={id:11,fld:"",grid:0};r[12]={id:12,fld:"TABLEHEADER",grid:0};r[13]={id:13,fld:"",grid:0};r[14]={id:14,fld:"TABLEHEADERCONTENT",grid:0};r[15]={id:15,fld:"",grid:0};r[16]={id:16,fld:"TABLERIGHTHEADER",grid:0};r[21]={id:21,fld:"TABLEFILTERS",grid:0};r[24]={id:24,fld:"",grid:0};r[25]={id:25,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vFILTERFULLTEXT",fmt:0,gxz:"ZV16FilterFullText",gxold:"OV16FilterFullText",gxvar:"AV16FilterFullText",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV16FilterFullText=n)},v2z:function(n){n!==undefined&&(gx.O.ZV16FilterFullText=n)},v2c:function(){gx.fn.setControlValue("vFILTERFULLTEXT",gx.O.AV16FilterFullText,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV16FilterFullText=this.val())},val:function(){return gx.fn.getControlValue("vFILTERFULLTEXT")},nac:gx.falseFn};this.declareDomainHdlr(25,function(){});r[26]={id:26,fld:"",grid:0};r[27]={id:27,fld:"",grid:0};r[28]={id:28,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};r[29]={id:29,fld:"",grid:0};r[30]={id:30,fld:"",grid:0};r[32]={id:32,lvl:2,type:"int",len:9,dec:0,sign:!1,pic:"ZZZ,ZZZ,ZZ9",ro:1,isacc:0,grid:31,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"UFID",fmt:0,gxz:"Z4UFID",gxold:"O4UFID",gxvar:"A4UFID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A4UFID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z4UFID=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("UFID",n||gx.fn.currentGridRowImpl(31),gx.O.A4UFID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A4UFID=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("UFID",n||gx.fn.currentGridRowImpl(31),".")},nac:gx.falseFn};r[33]={id:33,lvl:2,type:"svchar",len:2,dec:0,sign:!1,pic:"@!",ro:1,isacc:0,grid:31,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"UFSIGLA",fmt:0,gxz:"Z5UFSigla",gxold:"O5UFSigla",gxvar:"A5UFSigla",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A5UFSigla=n)},v2z:function(n){n!==undefined&&(gx.O.Z5UFSigla=n)},v2c:function(n){gx.fn.setGridControlValue("UFSIGLA",n||gx.fn.currentGridRowImpl(31),gx.O.A5UFSigla,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A5UFSigla=this.val(n))},val:function(n){return gx.fn.getGridControlValue("UFSIGLA",n||gx.fn.currentGridRowImpl(31))},nac:gx.falseFn};r[34]={id:34,lvl:2,type:"svchar",len:50,dec:0,sign:!1,ro:1,isacc:0,grid:31,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"UFNOME",fmt:0,gxz:"Z6UFNome",gxold:"O6UFNome",gxvar:"A6UFNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A6UFNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z6UFNome=n)},v2c:function(n){gx.fn.setGridControlValue("UFNOME",n||gx.fn.currentGridRowImpl(31),gx.O.A6UFNome,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A6UFNome=this.val(n))},val:function(n){return gx.fn.getGridControlValue("UFNOME",n||gx.fn.currentGridRowImpl(31))},nac:gx.falseFn};r[35]={id:35,lvl:2,type:"svchar",len:70,dec:0,sign:!1,ro:1,isacc:0,grid:31,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"UFSIGLANOME",fmt:0,gxz:"Z12UFSiglaNome",gxold:"O12UFSiglaNome",gxvar:"A12UFSiglaNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A12UFSiglaNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z12UFSiglaNome=n)},v2c:function(n){gx.fn.setGridControlValue("UFSIGLANOME",n||gx.fn.currentGridRowImpl(31),gx.O.A12UFSiglaNome,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A12UFSiglaNome=this.val(n))},val:function(n){return gx.fn.getGridControlValue("UFSIGLANOME",n||gx.fn.currentGridRowImpl(31))},nac:gx.falseFn};r[36]={id:36,fld:"",grid:0};r[37]={id:37,fld:"",grid:0};r[39]={id:39,fld:"",grid:0};r[40]={id:40,fld:"",grid:0};r[41]={id:41,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};r[43]={id:43,lvl:0,type:"int",len:9,dec:0,sign:!1,pic:"ZZZ,ZZZ,ZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"UFREGID",fmt:0,gxz:"Z8UFRegID",gxold:"O8UFRegID",gxvar:"A8UFRegID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A8UFRegID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z8UFRegID=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("UFREGID",gx.O.A8UFRegID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A8UFRegID=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("UFREGID",".")},nac:gx.falseFn};this.declareDomainHdlr(43,function(){});this.AV16FilterFullText="";this.ZV16FilterFullText="";this.OV16FilterFullText="";this.Z4UFID=0;this.O4UFID=0;this.Z5UFSigla="";this.O5UFSigla="";this.Z6UFNome="";this.O6UFNome="";this.Z12UFSiglaNome="";this.O12UFSiglaNome="";this.A8UFRegID=0;this.Z8UFRegID=0;this.O8UFRegID=0;this.AV18ManageFiltersData=[];this.AV16FilterFullText="";this.AV24GridCurrentPage=0;this.AV21DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:"",OptionGroup_fi:""};this.A8UFRegID=0;this.AV8UFRegID=0;this.A4UFID=0;this.A5UFSigla="";this.A6UFNome="";this.A12UFSiglaNome="";this.AV20ManageFiltersExecutionStep=0;this.AV32Pgmname="";this.AV14OrderedBy=0;this.AV15OrderedDsc=!1;this.AV31IsAuthorized_UFSigla=!1;this.AV12GridState={CurrentPage:0,OrderedBy:0,OrderedDsc:!1,HidingSearch:0,PageSize:"",CollapsedRecords:"",GroupBy:"",FilterValues:[],DynamicFilters:[]};this.Events={e12482_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e13482_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e14482_client:["DDO_GRID.ONOPTIONCLICKED",!0],e11482_client:["DDO_MANAGEFILTERS.ONOPTIONCLICKED",!0],e18482_client:["ENTER",!0],e19482_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV8UFRegID",fld:"vUFREGID",pic:"ZZZ,ZZZ,ZZ9"},{av:"sPrefix"},{av:"AV20ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{ctrl:"GRID",prop:"Rows"},{av:"AV16FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV32Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV31IsAuthorized_UFSigla",fld:"vISAUTHORIZED_UFSIGLA",pic:"",hsh:!0}],[{av:"AV20ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV24GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV25GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV26GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV18ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV12GridState",fld:"vGRIDSTATE",pic:""}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV16FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV8UFRegID",fld:"vUFREGID",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV20ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV32Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV31IsAuthorized_UFSigla",fld:"vISAUTHORIZED_UFSIGLA",pic:"",hsh:!0},{av:"sPrefix"},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV16FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV8UFRegID",fld:"vUFREGID",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV20ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV32Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV31IsAuthorized_UFSigla",fld:"vISAUTHORIZED_UFSIGLA",pic:"",hsh:!0},{av:"sPrefix"},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{ctrl:"GRID",prop:"Rows"}]];this.EvtParms["DDO_GRID.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV16FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV8UFRegID",fld:"vUFREGID",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV20ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV32Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV31IsAuthorized_UFSigla",fld:"vISAUTHORIZED_UFSIGLA",pic:"",hsh:!0},{av:"sPrefix"},{av:"this.DDO_GRIDContainer.ActiveEventKey",ctrl:"DDO_GRID",prop:"ActiveEventKey"},{av:"this.DDO_GRIDContainer.SelectedValue_get",ctrl:"DDO_GRID",prop:"SelectedValue_get"}],[{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"this.DDO_GRIDContainer.SortedStatus",ctrl:"DDO_GRID",prop:"SortedStatus"}]];this.EvtParms["GRID.LOAD"]=[[{av:"AV31IsAuthorized_UFSigla",fld:"vISAUTHORIZED_UFSIGLA",pic:"",hsh:!0},{av:"A4UFID",fld:"UFID",pic:"ZZZ,ZZZ,ZZ9"}],[{av:'gx.fn.getCtrlProperty("UFSIGLA","Link")',ctrl:"UFSIGLA",prop:"Link"}]];this.EvtParms["DDO_MANAGEFILTERS.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV16FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV8UFRegID",fld:"vUFREGID",pic:"ZZZ,ZZZ,ZZ9"},{av:"AV20ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV32Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV31IsAuthorized_UFSigla",fld:"vISAUTHORIZED_UFSIGLA",pic:"",hsh:!0},{av:"sPrefix"},{av:"this.DDO_MANAGEFILTERSContainer.ActiveEventKey",ctrl:"DDO_MANAGEFILTERS",prop:"ActiveEventKey"},{av:"AV12GridState",fld:"vGRIDSTATE",pic:""}],[{av:"AV20ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV12GridState",fld:"vGRIDSTATE",pic:""},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV16FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"this.DDO_GRIDContainer.SortedStatus",ctrl:"DDO_GRID",prop:"SortedStatus"},{av:"AV24GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV25GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV26GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV18ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV20ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV32Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV14OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV15OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV31IsAuthorized_UFSigla","vISAUTHORIZED_UFSIGLA",0,"boolean",4,0);this.setVCMap("AV12GridState","vGRIDSTATE",0,"WWPBaseObjectsWWPGridState",0,0);this.setVCMap("AV8UFRegID","vUFREGID",0,"int",9,0);this.setVCMap("AV8UFRegID","vUFREGID",0,"int",9,0);this.setVCMap("AV20ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV32Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV14OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV15OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV31IsAuthorized_UFSigla","vISAUTHORIZED_UFSIGLA",0,"boolean",4,0);this.setVCMap("AV8UFRegID","vUFREGID",0,"int",9,0);this.setVCMap("AV20ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV32Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV14OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV15OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV31IsAuthorized_UFSigla","vISAUTHORIZED_UFSIGLA",0,"boolean",4,0);u.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});u.addRefreshingVar(this.GXValidFnc[25]);u.addRefreshingVar({rfrVar:"AV8UFRegID"});u.addRefreshingVar({rfrVar:"AV20ManageFiltersExecutionStep"});u.addRefreshingVar({rfrVar:"AV32Pgmname"});u.addRefreshingVar({rfrVar:"AV14OrderedBy"});u.addRefreshingVar({rfrVar:"AV15OrderedDsc"});u.addRefreshingVar({rfrVar:"AV31IsAuthorized_UFSigla"});u.addRefreshingParm(this.GXValidFnc[25]);u.addRefreshingParm({rfrVar:"AV8UFRegID"});u.addRefreshingParm({rfrVar:"AV20ManageFiltersExecutionStep"});u.addRefreshingParm({rfrVar:"AV32Pgmname"});u.addRefreshingParm({rfrVar:"AV14OrderedBy"});u.addRefreshingParm({rfrVar:"AV15OrderedDsc"});u.addRefreshingParm({rfrVar:"AV31IsAuthorized_UFSigla"});this.Initialize();this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState",{FilterValues:{sdt:"WWPBaseObjects\\WWPGridState.FilterValue"},DynamicFilters:{sdt:"WWPBaseObjects\\WWPGridState.DynamicFilter"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState.DynamicFilter",{Dsc:{extr:"d"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"},OptionGroup_fi:{extr:"og"}})})