gx.evt.autoSkip=!1;gx.define("core.iteracaoww",!1,function(){var t,r,i,f,u,n,o,e;this.ServerClass="core.iteracaoww";this.PackageName="GeneXus.Programs";this.ServerFullClass="core.iteracaoww.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV40ManageFiltersExecutionStep=gx.fn.getIntegerValue("vMANAGEFILTERSEXECUTIONSTEP",".");this.AV60Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV41TFIteOrdem=gx.fn.getIntegerValue("vTFITEORDEM",".");this.AV42TFIteOrdem_To=gx.fn.getIntegerValue("vTFITEORDEM_TO",".");this.AV43TFIteNome=gx.fn.getControlValue("vTFITENOME");this.AV44TFIteNome_Sel=gx.fn.getControlValue("vTFITENOME_SEL");this.AV14OrderedBy=gx.fn.getIntegerValue("vORDEREDBY",".");this.AV15OrderedDsc=gx.fn.getControlValue("vORDEREDDSC");this.AV59IsAuthorized_IteOrdem=gx.fn.getControlValue("vISAUTHORIZED_ITEORDEM");this.AV11GridState=gx.fn.getControlValue("vGRIDSTATE")};this.s142_client=function(){this.DDO_GRIDContainer.SortedStatus=gx.text.trim(gx.num.str(this.AV14OrderedBy,4,0))+":"+(this.AV15OrderedDsc?"DSC":"ASC")};this.s172_client=function(){this.AV17FilterFullText="";this.AV41TFIteOrdem=gx.num.trunc(0,0);this.AV42TFIteOrdem_To=gx.num.trunc(0,0);this.AV43TFIteNome="";this.AV44TFIteNome_Sel="";this.DDO_GRIDContainer.SelectedValue_set="";this.DDO_GRIDContainer.FilteredText_set="";this.DDO_GRIDContainer.FilteredTextTo_set=""};this.e12432_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e13432_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e16432_client=function(){return this.executeServerEvent("DDO_GRID.ONOPTIONCLICKED",!1,null,!0,!0)};this.e11432_client=function(){return this.executeServerEvent("DDO_MANAGEFILTERS.ONOPTIONCLICKED",!1,null,!0,!0)};this.e14432_client=function(){return this.executeServerEvent("DDO_AGEXPORT.ONOPTIONCLICKED",!1,null,!0,!0)};this.e15432_client=function(){return this.executeServerEvent("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",!1,null,!0,!0)};this.e20432_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e21432_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,26,29,30,31,32,34,35,36,37,38,40,41,42,43,44,45,47,48,49,54];this.GXLastCtrlId=54;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",39,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"core.iteracaoww",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Novo registro",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);r=this.GridContainer;r.addSingleLineEdit(381,40,"ITEID","ID","","IteID","guid",0,"px",36,36,"",null,[],381,"IteID",!1,0,!1,!0,"Attribute",0,"WWColumn");r.addSingleLineEdit(382,41,"ITEORDEM","Ordem de Execução","","IteOrdem","int",0,"px",8,8,"end",null,[],382,"IteOrdem",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");r.addSingleLineEdit(383,42,"ITENOME","Descrição","","IteNome","svchar",0,"px",80,80,"start",null,[],383,"IteNome",!0,0,!1,!1,"Attribute",0,"WWColumn");r.addCheckBox(384,43,"ITEATIVO","Ativo","","IteAtivo","boolean","true","false",null,!1,!1,0,"px","WWColumn");this.GridContainer.emptyText="";this.setGrid(r);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,46,30,"DVelop_DVPaginationBar","GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");i=this.GRIDPAGINATIONBARContainer;i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Class","Class","PaginationBar","str");i.setProp("ShowFirst","Showfirst",!0,"bool");i.setProp("ShowPrevious","Showprevious",!0,"bool");i.setProp("ShowNext","Shownext",!0,"bool");i.setProp("ShowLast","Showlast",!0,"bool");i.setProp("PagesToShow","Pagestoshow",5,"num");i.setProp("PagingButtonsPosition","Pagingbuttonsposition","Left","str");i.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");i.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");i.setProp("SelectedPage","Selectedpage","","char");i.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");i.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");i.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");i.setProp("First","First","WWP_PagingFirstCaption","str");i.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");i.setProp("Next","Next","WWP_PagingNextCaption","str");i.setProp("Last","Last","WWP_PagingLastCaption","str");i.setProp("Caption","Caption","Página <CURRENT_PAGE> de <TOTAL_PAGES>","str");i.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");i.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");i.addV2CFunction("AV50GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");i.addC2VFunction(function(n){n.ParentObject.AV50GridCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",n.ParentObject.AV50GridCurrentPage)});i.addV2CFunction("AV51GridPageCount","vGRIDPAGECOUNT","SetPageCount");i.addC2VFunction(function(n){n.ParentObject.AV51GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV51GridPageCount)});i.setProp("RecordCount","Recordcount","","str");i.setProp("Page","Page","","str");i.addV2CFunction("AV52GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");i.addC2VFunction(function(n){n.ParentObject.AV52GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV52GridAppliedFilters)});i.setProp("Visible","Visible",!0,"bool");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("ChangePage",this.e12432_client);i.addEventHandler("ChangeRowsPerPage",this.e13432_client);this.setUserControl(i);this.DDO_AGEXPORTContainer=gx.uc.getNew(this,50,30,"BootstrapDropDownOptions","DDO_AGEXPORTContainer","Ddo_agexport","DDO_AGEXPORT");f=this.DDO_AGEXPORTContainer;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setProp("IconType","Icontype","FontIcon","str");f.setProp("Icon","Icon","fas fa-download","str");f.setProp("Caption","Caption","Exportar","str");f.setProp("Tooltip","Tooltip","","str");f.setProp("Cls","Cls","ColumnsSelector","str");f.setProp("ActiveEventKey","Activeeventkey","","char");f.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");f.setProp("DropDownOptionsType","Dropdownoptionstype","Regular","str");f.setProp("Visible","Visible",!0,"bool");f.setDynProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");f.addV2CFunction("AV56AGExportData","vAGEXPORTDATA","SetDropDownOptionsData");f.addC2VFunction(function(n){n.ParentObject.AV56AGExportData=n.GetDropDownOptionsData();gx.fn.setControlValue("vAGEXPORTDATA",n.ParentObject.AV56AGExportData)});f.setC2ShowFunction(function(n){n.show()});f.addEventHandler("OnOptionClicked",this.e14432_client);this.setUserControl(f);this.DDC_SUBSCRIPTIONSContainer=gx.uc.getNew(this,51,30,"BootstrapDropDownOptions","DDC_SUBSCRIPTIONSContainer","Ddc_subscriptions","DDC_SUBSCRIPTIONS");u=this.DDC_SUBSCRIPTIONSContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("IconType","Icontype","FontIcon","str");u.setProp("Icon","Icon","fas fa-rss","str");u.setProp("Caption","Caption","","str");u.setProp("Tooltip","Tooltip","WWP_Subscriptions_Tooltip","str");u.setProp("Cls","Cls","ColumnsSelector","str");u.setProp("ComponentWidth","Componentwidth",400,"num");u.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");u.setProp("DropDownOptionsType","Dropdownoptionstype","Component","str");u.setProp("Visible","Visible",!0,"bool");u.setDynProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");u.setProp("ShowLoading","Showloading",!0,"bool");u.setProp("Load","Load","OnEveryClick","str");u.setProp("KeepOpened","Keepopened",!1,"bool");u.setProp("Trigger","Trigger","Click","str");u.setC2ShowFunction(function(n){n.show()});u.addEventHandler("OnLoadComponent",this.e15432_client);this.setUserControl(u);this.DDO_GRIDContainer=gx.uc.getNew(this,52,30,"DDOGridTitleSettingsM","DDO_GRIDContainer","Ddo_grid","DDO_GRID");n=this.DDO_GRIDContainer;n.setProp("Class","Class","","char");n.setProp("Enabled","Enabled",!0,"boolean");n.setProp("IconType","Icontype","Image","str");n.setProp("Icon","Icon","","str");n.setProp("Caption","Caption","","str");n.setProp("Tooltip","Tooltip","","str");n.setProp("Cls","Cls","","str");n.setProp("ActiveEventKey","Activeeventkey","","char");n.setDynProp("FilteredText_set","Filteredtext_set","","char");n.setProp("FilteredText_get","Filteredtext_get","","char");n.setDynProp("FilteredTextTo_set","Filteredtextto_set","","char");n.setProp("FilteredTextTo_get","Filteredtextto_get","","char");n.setDynProp("SelectedValue_set","Selectedvalue_set","","char");n.setProp("SelectedValue_get","Selectedvalue_get","","char");n.setProp("SelectedText_set","Selectedtext_set","","char");n.setProp("SelectedText_get","Selectedtext_get","","char");n.setProp("SelectedColumn","Selectedcolumn","","char");n.setProp("SelectedColumnFixedFilter","Selectedcolumnfixedfilter","","char");n.setDynProp("GAMOAuthToken","Gamoauthtoken","","char");n.setProp("TitleControlAlign","Titlecontrolalign","","str");n.setProp("Visible","Visible","","str");n.setDynProp("GridInternalName","Gridinternalname","","str");n.setProp("ColumnIds","Columnids","1:IteOrdem|2:IteNome","str");n.setProp("ColumnsSortValues","Columnssortvalues","1|2","str");n.setProp("IncludeSortASC","Includesortasc","T","str");n.setProp("IncludeSortDSC","Includesortdsc","","str");n.setProp("AllowGroup","Allowgroup","","str");n.setProp("Fixable","Fixable","","str");n.setDynProp("SortedStatus","Sortedstatus","","char");n.setProp("IncludeFilter","Includefilter","T","str");n.setProp("FilterType","Filtertype","Numeric|Character","str");n.setProp("FilterIsRange","Filterisrange","T|","str");n.setProp("IncludeDataList","Includedatalist","|T","str");n.setProp("DataListType","Datalisttype","|Dynamic","str");n.setProp("AllowMultipleSelection","Allowmultipleselection","","str");n.setProp("DataListFixedValues","Datalistfixedvalues","","str");n.setProp("DataListProc","Datalistproc","core.IteracaoWWGetFilterData","str");n.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");n.setProp("RemoteServicesParameters","Remoteservicesparameters","","str");n.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");n.setProp("FixedFilters","Fixedfilters","","str");n.setProp("Format","Format","8.0|","str");n.setProp("SelectedFixedFilter","Selectedfixedfilter","","char");n.setProp("SortASC","Sortasc","","str");n.setProp("SortDSC","Sortdsc","","str");n.setProp("AllowGroupText","Allowgrouptext","","str");n.setProp("LoadingData","Loadingdata","","str");n.setProp("CleanFilter","Cleanfilter","","str");n.setProp("RangeFilterFrom","Rangefilterfrom","","str");n.setProp("RangeFilterTo","Rangefilterto","","str");n.setProp("NoResultsFound","Noresultsfound","","str");n.setProp("SearchButtonText","Searchbuttontext","","str");n.addV2CFunction("AV46DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");n.addC2VFunction(function(n){n.ParentObject.AV46DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV46DDO_TitleSettingsIcons)});n.setC2ShowFunction(function(n){n.show()});n.addEventHandler("OnOptionClicked",this.e16432_client);this.setUserControl(n);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,53,30,"WWP_GridEmpowerer","GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");o=this.GRID_EMPOWERERContainer;o.setProp("Class","Class","","char");o.setProp("Enabled","Enabled",!0,"boolean");o.setDynProp("GridInternalName","Gridinternalname","","char");o.setProp("HasCategories","Hascategories",!1,"bool");o.setProp("InfiniteScrolling","Infinitescrolling","False","str");o.setProp("HasTitleSettings","Hastitlesettings",!0,"bool");o.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");o.setProp("HasRowGroups","Hasrowgroups",!1,"bool");o.setProp("FixedColumns","Fixedcolumns","","str");o.setProp("PopoversInGrid","Popoversingrid","","str");o.setProp("Visible","Visible",!0,"bool");o.setC2ShowFunction(function(n){n.show()});this.setUserControl(o);this.DDO_MANAGEFILTERSContainer=gx.uc.getNew(this,24,0,"BootstrapDropDownOptions","DDO_MANAGEFILTERSContainer","Ddo_managefilters","DDO_MANAGEFILTERS");e=this.DDO_MANAGEFILTERSContainer;e.setProp("Class","Class","","char");e.setProp("Enabled","Enabled",!0,"boolean");e.setProp("IconType","Icontype","FontIcon","str");e.setProp("Icon","Icon","fas fa-filter","str");e.setProp("Caption","Caption","","str");e.setProp("Tooltip","Tooltip","WWP_ManageFiltersTooltip","str");e.setProp("Cls","Cls","ManageFilters","str");e.setProp("ActiveEventKey","Activeeventkey","","char");e.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");e.setProp("DropDownOptionsType","Dropdownoptionstype","Regular","str");e.setProp("Visible","Visible",!0,"bool");e.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");e.addV2CFunction("AV38ManageFiltersData","vMANAGEFILTERSDATA","SetDropDownOptionsData");e.addC2VFunction(function(n){n.ParentObject.AV38ManageFiltersData=n.GetDropDownOptionsData();gx.fn.setControlValue("vMANAGEFILTERSDATA",n.ParentObject.AV38ManageFiltersData)});e.setC2ShowFunction(function(n){n.show()});e.addEventHandler("OnOptionClicked",this.e11432_client);this.setUserControl(e);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TABLEHEADER",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"TABLEHEADERCONTENT",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"TABLEACTIONS",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"BTNAGEXPORT",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"BTNSUBSCRIPTIONS",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"TABLERIGHTHEADER",grid:0};t[26]={id:26,fld:"TABLEFILTERS",grid:0};t[29]={id:29,fld:"",grid:0};t[30]={id:30,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vFILTERFULLTEXT",fmt:0,gxz:"ZV17FilterFullText",gxold:"OV17FilterFullText",gxvar:"AV17FilterFullText",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV17FilterFullText=n)},v2z:function(n){n!==undefined&&(gx.O.ZV17FilterFullText=n)},v2c:function(){gx.fn.setControlValue("vFILTERFULLTEXT",gx.O.AV17FilterFullText,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV17FilterFullText=this.val())},val:function(){return gx.fn.getControlValue("vFILTERFULLTEXT")},nac:gx.falseFn};this.declareDomainHdlr(30,function(){});t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[34]={id:34,fld:"",grid:0};t[35]={id:35,fld:"",grid:0};t[36]={id:36,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};t[37]={id:37,fld:"",grid:0};t[38]={id:38,fld:"",grid:0};t[40]={id:40,lvl:2,type:"guid",len:9,dec:0,sign:!1,ro:1,isacc:0,grid:39,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ITEID",fmt:0,gxz:"Z381IteID",gxold:"O381IteID",gxvar:"A381IteID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A381IteID=n)},v2z:function(n){n!==undefined&&(gx.O.Z381IteID=n)},v2c:function(n){gx.fn.setGridControlValue("ITEID",n||gx.fn.currentGridRowImpl(39),gx.O.A381IteID,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A381IteID=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ITEID",n||gx.fn.currentGridRowImpl(39))},nac:gx.falseFn};t[41]={id:41,lvl:2,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:1,isacc:0,grid:39,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ITEORDEM",fmt:0,gxz:"Z382IteOrdem",gxold:"O382IteOrdem",gxvar:"A382IteOrdem",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A382IteOrdem=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z382IteOrdem=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ITEORDEM",n||gx.fn.currentGridRowImpl(39),gx.O.A382IteOrdem,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A382IteOrdem=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ITEORDEM",n||gx.fn.currentGridRowImpl(39),".")},nac:gx.falseFn};t[42]={id:42,lvl:2,type:"svchar",len:80,dec:0,sign:!1,pic:"@!",ro:1,isacc:0,grid:39,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ITENOME",fmt:0,gxz:"Z383IteNome",gxold:"O383IteNome",gxvar:"A383IteNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A383IteNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z383IteNome=n)},v2c:function(n){gx.fn.setGridControlValue("ITENOME",n||gx.fn.currentGridRowImpl(39),gx.O.A383IteNome,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A383IteNome=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ITENOME",n||gx.fn.currentGridRowImpl(39))},nac:gx.falseFn};t[43]={id:43,lvl:2,type:"boolean",len:4,dec:0,sign:!1,ro:1,isacc:0,grid:39,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ITEATIVO",fmt:0,gxz:"Z384IteAtivo",gxold:"O384IteAtivo",gxvar:"A384IteAtivo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A384IteAtivo=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z384IteAtivo=gx.lang.booleanValue(n))},v2c:function(n){gx.fn.setGridCheckBoxValue("ITEATIVO",n||gx.fn.currentGridRowImpl(39),gx.O.A384IteAtivo,!0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A384IteAtivo=gx.lang.booleanValue(this.val(n)))},val:function(n){return gx.fn.getGridControlValue("ITEATIVO",n||gx.fn.currentGridRowImpl(39))},nac:gx.falseFn,values:["true","false"]};t[44]={id:44,fld:"",grid:0};t[45]={id:45,fld:"",grid:0};t[47]={id:47,fld:"",grid:0};t[48]={id:48,fld:"",grid:0};t[49]={id:49,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};t[54]={id:54,fld:"DIV_WWPAUXWC",grid:0};this.AV17FilterFullText="";this.ZV17FilterFullText="";this.OV17FilterFullText="";this.Z381IteID="00000000-0000-0000-0000-000000000000";this.O381IteID="00000000-0000-0000-0000-000000000000";this.Z382IteOrdem=0;this.O382IteOrdem=0;this.Z383IteNome="";this.O383IteNome="";this.Z384IteAtivo=!1;this.O384IteAtivo=!1;this.AV38ManageFiltersData=[];this.AV17FilterFullText="";this.AV50GridCurrentPage=0;this.AV56AGExportData=[];this.AV46DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:"",OptionGroup_fi:""};this.A381IteID="00000000-0000-0000-0000-000000000000";this.A382IteOrdem=0;this.A383IteNome="";this.A384IteAtivo=!1;this.AV40ManageFiltersExecutionStep=0;this.AV60Pgmname="";this.AV41TFIteOrdem=0;this.AV42TFIteOrdem_To=0;this.AV43TFIteNome="";this.AV44TFIteNome_Sel="";this.AV14OrderedBy=0;this.AV15OrderedDsc=!1;this.AV59IsAuthorized_IteOrdem=!1;this.AV11GridState={CurrentPage:0,OrderedBy:0,OrderedDsc:!1,HidingSearch:0,PageSize:"",CollapsedRecords:"",GroupBy:"",FilterValues:[],DynamicFilters:[]};this.Events={e12432_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e13432_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e16432_client:["DDO_GRID.ONOPTIONCLICKED",!0],e11432_client:["DDO_MANAGEFILTERS.ONOPTIONCLICKED",!0],e14432_client:["DDO_AGEXPORT.ONOPTIONCLICKED",!0],e15432_client:["DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",!0],e20432_client:["ENTER",!0],e21432_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{ctrl:"GRID",prop:"Rows"},{av:"AV17FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV60Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV41TFIteOrdem",fld:"vTFITEORDEM",pic:"ZZZZZZZ9"},{av:"AV42TFIteOrdem_To",fld:"vTFITEORDEM_TO",pic:"ZZZZZZZ9"},{av:"AV43TFIteNome",fld:"vTFITENOME",pic:"@!"},{av:"AV44TFIteNome_Sel",fld:"vTFITENOME_SEL",pic:"@!"},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV59IsAuthorized_IteOrdem",fld:"vISAUTHORIZED_ITEORDEM",pic:"",hsh:!0}],[{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV50GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV51GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV52GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{ctrl:"BTNSUBSCRIPTIONS",prop:"Visible"},{av:"AV38ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV11GridState",fld:"vGRIDSTATE",pic:""}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV17FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV60Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV41TFIteOrdem",fld:"vTFITEORDEM",pic:"ZZZZZZZ9"},{av:"AV42TFIteOrdem_To",fld:"vTFITEORDEM_TO",pic:"ZZZZZZZ9"},{av:"AV43TFIteNome",fld:"vTFITENOME",pic:"@!"},{av:"AV44TFIteNome_Sel",fld:"vTFITENOME_SEL",pic:"@!"},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV59IsAuthorized_IteOrdem",fld:"vISAUTHORIZED_ITEORDEM",pic:"",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV17FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV60Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV41TFIteOrdem",fld:"vTFITEORDEM",pic:"ZZZZZZZ9"},{av:"AV42TFIteOrdem_To",fld:"vTFITEORDEM_TO",pic:"ZZZZZZZ9"},{av:"AV43TFIteNome",fld:"vTFITENOME",pic:"@!"},{av:"AV44TFIteNome_Sel",fld:"vTFITENOME_SEL",pic:"@!"},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV59IsAuthorized_IteOrdem",fld:"vISAUTHORIZED_ITEORDEM",pic:"",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{ctrl:"GRID",prop:"Rows"}]];this.EvtParms["DDO_GRID.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV17FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV60Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV41TFIteOrdem",fld:"vTFITEORDEM",pic:"ZZZZZZZ9"},{av:"AV42TFIteOrdem_To",fld:"vTFITEORDEM_TO",pic:"ZZZZZZZ9"},{av:"AV43TFIteNome",fld:"vTFITENOME",pic:"@!"},{av:"AV44TFIteNome_Sel",fld:"vTFITENOME_SEL",pic:"@!"},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV59IsAuthorized_IteOrdem",fld:"vISAUTHORIZED_ITEORDEM",pic:"",hsh:!0},{av:"this.DDO_GRIDContainer.ActiveEventKey",ctrl:"DDO_GRID",prop:"ActiveEventKey"},{av:"this.DDO_GRIDContainer.SelectedValue_get",ctrl:"DDO_GRID",prop:"SelectedValue_get"},{av:"this.DDO_GRIDContainer.SelectedColumn",ctrl:"DDO_GRID",prop:"SelectedColumn"},{av:"this.DDO_GRIDContainer.FilteredText_get",ctrl:"DDO_GRID",prop:"FilteredText_get"},{av:"this.DDO_GRIDContainer.FilteredTextTo_get",ctrl:"DDO_GRID",prop:"FilteredTextTo_get"}],[{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV41TFIteOrdem",fld:"vTFITEORDEM",pic:"ZZZZZZZ9"},{av:"AV42TFIteOrdem_To",fld:"vTFITEORDEM_TO",pic:"ZZZZZZZ9"},{av:"AV43TFIteNome",fld:"vTFITENOME",pic:"@!"},{av:"AV44TFIteNome_Sel",fld:"vTFITENOME_SEL",pic:"@!"},{av:"this.DDO_GRIDContainer.SortedStatus",ctrl:"DDO_GRID",prop:"SortedStatus"}]];this.EvtParms["GRID.LOAD"]=[[{av:"AV59IsAuthorized_IteOrdem",fld:"vISAUTHORIZED_ITEORDEM",pic:"",hsh:!0},{av:"A381IteID",fld:"ITEID",pic:""}],[{av:'gx.fn.getCtrlProperty("ITEORDEM","Link")',ctrl:"ITEORDEM",prop:"Link"}]];this.EvtParms["DDO_MANAGEFILTERS.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV17FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV60Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV41TFIteOrdem",fld:"vTFITEORDEM",pic:"ZZZZZZZ9"},{av:"AV42TFIteOrdem_To",fld:"vTFITEORDEM_TO",pic:"ZZZZZZZ9"},{av:"AV43TFIteNome",fld:"vTFITENOME",pic:"@!"},{av:"AV44TFIteNome_Sel",fld:"vTFITENOME_SEL",pic:"@!"},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV59IsAuthorized_IteOrdem",fld:"vISAUTHORIZED_ITEORDEM",pic:"",hsh:!0},{av:"this.DDO_MANAGEFILTERSContainer.ActiveEventKey",ctrl:"DDO_MANAGEFILTERS",prop:"ActiveEventKey"},{av:"AV11GridState",fld:"vGRIDSTATE",pic:""}],[{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV11GridState",fld:"vGRIDSTATE",pic:""},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV17FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV41TFIteOrdem",fld:"vTFITEORDEM",pic:"ZZZZZZZ9"},{av:"AV42TFIteOrdem_To",fld:"vTFITEORDEM_TO",pic:"ZZZZZZZ9"},{av:"AV43TFIteNome",fld:"vTFITENOME",pic:"@!"},{av:"AV44TFIteNome_Sel",fld:"vTFITENOME_SEL",pic:"@!"},{av:"this.DDO_GRIDContainer.SelectedValue_set",ctrl:"DDO_GRID",prop:"SelectedValue_set"},{av:"this.DDO_GRIDContainer.FilteredText_set",ctrl:"DDO_GRID",prop:"FilteredText_set"},{av:"this.DDO_GRIDContainer.FilteredTextTo_set",ctrl:"DDO_GRID",prop:"FilteredTextTo_set"},{av:"this.DDO_GRIDContainer.SortedStatus",ctrl:"DDO_GRID",prop:"SortedStatus"},{av:"AV50GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV51GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV52GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{ctrl:"BTNSUBSCRIPTIONS",prop:"Visible"},{av:"AV38ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""}]];this.EvtParms["DDO_AGEXPORT.ONOPTIONCLICKED"]=[[{av:"this.DDO_AGEXPORTContainer.ActiveEventKey",ctrl:"DDO_AGEXPORT",prop:"ActiveEventKey"},{av:"AV60Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"AV11GridState",fld:"vGRIDSTATE",pic:""},{av:"AV44TFIteNome_Sel",fld:"vTFITENOME_SEL",pic:"@!"},{av:"AV41TFIteOrdem",fld:"vTFITEORDEM",pic:"ZZZZZZZ9"},{av:"AV43TFIteNome",fld:"vTFITENOME",pic:"@!"},{av:"AV42TFIteOrdem_To",fld:"vTFITEORDEM_TO",pic:"ZZZZZZZ9"}],[{av:"AV11GridState",fld:"vGRIDSTATE",pic:""},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC",pic:""},{ctrl:"GRID",prop:"Rows"},{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV17FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV60Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV41TFIteOrdem",fld:"vTFITEORDEM",pic:"ZZZZZZZ9"},{av:"AV42TFIteOrdem_To",fld:"vTFITEORDEM_TO",pic:"ZZZZZZZ9"},{av:"AV43TFIteNome",fld:"vTFITENOME",pic:"@!"},{av:"AV44TFIteNome_Sel",fld:"vTFITENOME_SEL",pic:"@!"},{av:"AV59IsAuthorized_IteOrdem",fld:"vISAUTHORIZED_ITEORDEM",pic:"",hsh:!0},{av:"this.DDO_GRIDContainer.SortedStatus",ctrl:"DDO_GRID",prop:"SortedStatus"},{av:"this.DDO_GRIDContainer.SelectedValue_set",ctrl:"DDO_GRID",prop:"SelectedValue_set"},{av:"this.DDO_GRIDContainer.FilteredText_set",ctrl:"DDO_GRID",prop:"FilteredText_set"},{av:"this.DDO_GRIDContainer.FilteredTextTo_set",ctrl:"DDO_GRID",prop:"FilteredTextTo_set"}]];this.EvtParms["DDC_SUBSCRIPTIONS.ONLOADCOMPONENT"]=[[],[{ctrl:"WWPAUX_WC"}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV40ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV60Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV41TFIteOrdem","vTFITEORDEM",0,"int",8,0);this.setVCMap("AV42TFIteOrdem_To","vTFITEORDEM_TO",0,"int",8,0);this.setVCMap("AV43TFIteNome","vTFITENOME",0,"svchar",80,0);this.setVCMap("AV44TFIteNome_Sel","vTFITENOME_SEL",0,"svchar",80,0);this.setVCMap("AV14OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV15OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV59IsAuthorized_IteOrdem","vISAUTHORIZED_ITEORDEM",0,"boolean",4,0);this.setVCMap("AV11GridState","vGRIDSTATE",0,"WWPBaseObjectsWWPGridState",0,0);this.setVCMap("AV40ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV60Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV41TFIteOrdem","vTFITEORDEM",0,"int",8,0);this.setVCMap("AV42TFIteOrdem_To","vTFITEORDEM_TO",0,"int",8,0);this.setVCMap("AV43TFIteNome","vTFITENOME",0,"svchar",80,0);this.setVCMap("AV44TFIteNome_Sel","vTFITENOME_SEL",0,"svchar",80,0);this.setVCMap("AV14OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV15OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV59IsAuthorized_IteOrdem","vISAUTHORIZED_ITEORDEM",0,"boolean",4,0);this.setVCMap("AV40ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV60Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV41TFIteOrdem","vTFITEORDEM",0,"int",8,0);this.setVCMap("AV42TFIteOrdem_To","vTFITEORDEM_TO",0,"int",8,0);this.setVCMap("AV43TFIteNome","vTFITENOME",0,"svchar",80,0);this.setVCMap("AV44TFIteNome_Sel","vTFITENOME_SEL",0,"svchar",80,0);this.setVCMap("AV14OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV15OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV59IsAuthorized_IteOrdem","vISAUTHORIZED_ITEORDEM",0,"boolean",4,0);r.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});r.addRefreshingVar(this.GXValidFnc[30]);r.addRefreshingVar({rfrVar:"AV40ManageFiltersExecutionStep"});r.addRefreshingVar({rfrVar:"AV60Pgmname"});r.addRefreshingVar({rfrVar:"AV41TFIteOrdem"});r.addRefreshingVar({rfrVar:"AV42TFIteOrdem_To"});r.addRefreshingVar({rfrVar:"AV43TFIteNome"});r.addRefreshingVar({rfrVar:"AV44TFIteNome_Sel"});r.addRefreshingVar({rfrVar:"AV14OrderedBy"});r.addRefreshingVar({rfrVar:"AV15OrderedDsc"});r.addRefreshingVar({rfrVar:"AV59IsAuthorized_IteOrdem"});r.addRefreshingParm(this.GXValidFnc[30]);r.addRefreshingParm({rfrVar:"AV40ManageFiltersExecutionStep"});r.addRefreshingParm({rfrVar:"AV60Pgmname"});r.addRefreshingParm({rfrVar:"AV41TFIteOrdem"});r.addRefreshingParm({rfrVar:"AV42TFIteOrdem_To"});r.addRefreshingParm({rfrVar:"AV43TFIteNome"});r.addRefreshingParm({rfrVar:"AV44TFIteNome_Sel"});r.addRefreshingParm({rfrVar:"AV14OrderedBy"});r.addRefreshingParm({rfrVar:"AV15OrderedDsc"});r.addRefreshingParm({rfrVar:"AV59IsAuthorized_IteOrdem"});this.Initialize();this.setComponent({id:"WWPAUX_WC",GXClass:null,Prefix:"W0055",lvl:1});this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState",{FilterValues:{sdt:"WWPBaseObjects\\WWPGridState.FilterValue"},DynamicFilters:{sdt:"WWPBaseObjects\\WWPGridState.DynamicFilter"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState.DynamicFilter",{Dsc:{extr:"d"}});this.setSDTMapping("WWPBaseObjects\\WWPColumnsSelector",{Columns:{sdt:"WWPBaseObjects\\WWPColumnsSelector.Column"}});this.setSDTMapping("WWPBaseObjects\\WWPColumnsSelector.Column",{ColumnName:{extr:"C"},IsVisible:{extr:"V"},DisplayName:{extr:"D"},Order:{extr:"O"},Category:{extr:"G"},Fixed:{extr:"F"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"},OptionGroup_fi:{extr:"og"}});this.setSDTMapping("GeneXusSecurity\\GAMSession",{User:{sdt:"GeneXusSecurity\\GAMUser"},SecurityPolicy:{sdt:"GeneXusSecurity\\GAMSecurityPolicy"}});this.setSDTMapping("GeneXusSecurity\\GAMApplication",{Environment:{sdt:"GeneXusSecurity\\GAMApplicationEnvironment"}});this.setSDTMapping("GeneXusSecurity\\GAMMenuOptionList",{Nodes:{sdt:"GeneXusSecurity\\GAMMenuOptionList"}})});gx.wi(function(){gx.createParentObj(this.core.iteracaoww)})