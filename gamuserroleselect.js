gx.evt.autoSkip=!1;gx.define("gamuserroleselect",!1,function(){var n,i,t,u,r;this.ServerClass="gamuserroleselect";this.PackageName="GeneXus.Programs";this.ServerFullClass="gamuserroleselect.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV40ManageFiltersExecutionStep=gx.fn.getIntegerValue("vMANAGEFILTERSEXECUTIONSTEP",".");this.AV48Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV22UserId=gx.fn.getControlValue("vUSERID");this.AV11FilExternalId=gx.fn.getControlValue("vFILEXTERNALID");this.AV37GridState=gx.fn.getControlValue("vGRIDSTATE");this.AV17isOK=gx.fn.getControlValue("vISOK");this.subGrid_Recordcount=gx.fn.getIntegerValue("subGrid_Recordcount",".")};this.s142_client=function(){this.AV12FilName="";this.AV28GAMDescriptionLong=""};this.e121y2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e131y2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e111y2_client=function(){return this.executeServerEvent("DDO_MANAGEFILTERS.ONOPTIONCLICKED",!1,null,!0,!0)};this.e141y2_client=function(){return this.executeServerEvent("'DOADDSELECTED'",!1,null,!1,!1)};this.e181y2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e191y1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,19,22,23,24,27,28,29,30,31,33,34,35,36,37,39,40,41,42,43,45,46,47,48,49,50,51,52,53,54];this.GXLastCtrlId=54;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",38,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"gamuserroleselect",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Novo registro",!0,!1,!0,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addCheckBox("Select",39,"vSELECT","","","Select","boolean","true","false",null,!0,!1,50,"px","WWColumn");i.addSingleLineEdit("Name",40,"vNAME","Perfil","","Name","char",0,"px",120,80,"start",null,[],"Name","Name",!0,0,!1,!1,"Attribute",0,"WWColumn");i.addSingleLineEdit("Id",41,"vID","Key Numeric Long","","Id","int",0,"px",12,12,"end",null,[],"Id","Id",!1,0,!1,!1,"Attribute",0,"WWColumn");this.GridContainer.emptyText="";this.setGrid(i);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,44,24,"DVelop_DVPaginationBar","GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");t=this.GRIDPAGINATIONBARContainer;t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Class","Class","PaginationBar","str");t.setProp("ShowFirst","Showfirst",!0,"bool");t.setProp("ShowPrevious","Showprevious",!0,"bool");t.setProp("ShowNext","Shownext",!0,"bool");t.setProp("ShowLast","Showlast",!0,"bool");t.setProp("PagesToShow","Pagestoshow",5,"num");t.setProp("PagingButtonsPosition","Pagingbuttonsposition","Left","str");t.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");t.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");t.setProp("SelectedPage","Selectedpage","","char");t.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");t.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");t.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");t.setProp("First","First","WWP_PagingFirstCaption","str");t.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");t.setProp("Next","Next","WWP_PagingNextCaption","str");t.setProp("Last","Last","WWP_PagingLastCaption","str");t.setProp("Caption","Caption","Página <CURRENT_PAGE> de <TOTAL_PAGES>","str");t.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");t.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");t.addV2CFunction("AV46GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");t.addC2VFunction(function(n){n.ParentObject.AV46GridCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",n.ParentObject.AV46GridCurrentPage)});t.addV2CFunction("AV26GridPageCount","vGRIDPAGECOUNT","SetPageCount");t.addC2VFunction(function(n){n.ParentObject.AV26GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV26GridPageCount)});t.setProp("RecordCount","Recordcount","","str");t.setProp("Page","Page","","str");t.addV2CFunction("AV47GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");t.addC2VFunction(function(n){n.ParentObject.AV47GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV47GridAppliedFilters)});t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("ChangePage",this.e121y2_client);t.addEventHandler("ChangeRowsPerPage",this.e131y2_client);this.setUserControl(t);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,55,24,"WWP_GridEmpowerer","GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");u=this.GRID_EMPOWERERContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setDynProp("GridInternalName","Gridinternalname","","char");u.setProp("HasCategories","Hascategories",!1,"bool");u.setProp("InfiniteScrolling","Infinitescrolling","False","str");u.setProp("HasTitleSettings","Hastitlesettings",!1,"bool");u.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");u.setProp("HasRowGroups","Hasrowgroups",!1,"bool");u.setProp("FixedColumns","Fixedcolumns","","str");u.setProp("PopoversInGrid","Popoversingrid","","str");u.setProp("Visible","Visible",!0,"bool");u.setC2ShowFunction(function(n){n.show()});this.setUserControl(u);this.DDO_MANAGEFILTERSContainer=gx.uc.getNew(this,17,0,"BootstrapDropDownOptions","DDO_MANAGEFILTERSContainer","Ddo_managefilters","DDO_MANAGEFILTERS");r=this.DDO_MANAGEFILTERSContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("IconType","Icontype","FontIcon","str");r.setProp("Icon","Icon","fas fa-filter","str");r.setProp("Caption","Caption","","str");r.setProp("Tooltip","Tooltip","WWP_ManageFiltersTooltip","str");r.setProp("Cls","Cls","ManageFilters","str");r.setProp("ActiveEventKey","Activeeventkey","","char");r.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");r.setProp("DropDownOptionsType","Dropdownoptionstype","Regular","str");r.setProp("Visible","Visible",!0,"bool");r.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");r.addV2CFunction("AV44ManageFiltersData","vMANAGEFILTERSDATA","SetDropDownOptionsData");r.addC2VFunction(function(n){n.ParentObject.AV44ManageFiltersData=n.GetDropDownOptionsData();gx.fn.setControlValue("vMANAGEFILTERSDATA",n.ParentObject.AV44ManageFiltersData)});r.setC2ShowFunction(function(n){n.show()});r.addEventHandler("OnOptionClicked",this.e111y2_client);this.setUserControl(r);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TABLEHEADER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLEACTIONS",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"TABLERIGHTHEADER",grid:0};n[19]={id:19,fld:"TABLEFILTERS",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFILNAME",fmt:0,gxz:"ZV12FilName",gxold:"OV12FilName",gxvar:"AV12FilName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12FilName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12FilName=n)},v2c:function(){gx.fn.setControlValue("vFILNAME",gx.O.AV12FilName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV12FilName=this.val())},val:function(){return gx.fn.getControlValue("vFILNAME")},nac:gx.falseFn};this.declareDomainHdlr(24,function(){});n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGAMDESCRIPTIONLONG",fmt:0,gxz:"ZV28GAMDescriptionLong",gxold:"OV28GAMDescriptionLong",gxvar:"AV28GAMDescriptionLong",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV28GAMDescriptionLong=n)},v2z:function(n){n!==undefined&&(gx.O.ZV28GAMDescriptionLong=n)},v2c:function(){gx.fn.setControlValue("vGAMDESCRIPTIONLONG",gx.O.AV28GAMDescriptionLong,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV28GAMDescriptionLong=this.val())},val:function(){return gx.fn.getControlValue("vGAMDESCRIPTIONLONG")},nac:gx.falseFn};this.declareDomainHdlr(29,function(){});n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[39]={id:39,lvl:2,type:"boolean",len:4,dec:0,sign:!1,ro:0,isacc:0,grid:38,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSELECT",fmt:0,gxz:"ZV21Select",gxold:"OV21Select",gxvar:"AV21Select",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV21Select=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV21Select=gx.lang.booleanValue(n))},v2c:function(n){gx.fn.setGridCheckBoxValue("vSELECT",n||gx.fn.currentGridRowImpl(38),gx.O.AV21Select,!0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV21Select=gx.lang.booleanValue(this.val(n)))},val:function(n){return gx.fn.getGridControlValue("vSELECT",n||gx.fn.currentGridRowImpl(38))},nac:gx.falseFn,values:["true","false"]};n[40]={id:40,lvl:2,type:"char",len:120,dec:0,sign:!1,ro:0,isacc:0,grid:38,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",fmt:0,gxz:"ZV18Name",gxold:"OV18Name",gxvar:"AV18Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV18Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV18Name=n)},v2c:function(n){gx.fn.setGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(38),gx.O.AV18Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV18Name=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(38))},nac:gx.falseFn};n[41]={id:41,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,isacc:0,grid:38,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vID",fmt:0,gxz:"ZV16Id",gxold:"OV16Id",gxvar:"AV16Id",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV16Id=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV16Id=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vID",n||gx.fn.currentGridRowImpl(38),gx.O.AV16Id,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV16Id=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vID",n||gx.fn.currentGridRowImpl(38),".")},nac:gx.falseFn};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"BTNADDSELECTED",grid:0,evt:"e141y2_client"};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"BTNCANCEL",grid:0,evt:"e191y1_client"};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};this.AV12FilName="";this.ZV12FilName="";this.OV12FilName="";this.AV28GAMDescriptionLong="";this.ZV28GAMDescriptionLong="";this.OV28GAMDescriptionLong="";this.ZV21Select=!1;this.OV21Select=!1;this.ZV18Name="";this.OV18Name="";this.ZV16Id=0;this.OV16Id=0;this.AV44ManageFiltersData=[];this.AV12FilName="";this.AV28GAMDescriptionLong="";this.AV46GridCurrentPage=0;this.AV22UserId="";this.AV21Select=!1;this.AV18Name="";this.AV16Id=0;this.AV40ManageFiltersExecutionStep=0;this.AV48Pgmname="";this.AV11FilExternalId="";this.AV37GridState={CurrentPage:0,OrderedBy:0,OrderedDsc:!1,HidingSearch:0,PageSize:"",CollapsedRecords:"",GroupBy:"",FilterValues:[],DynamicFilters:[]};this.AV17isOK=!1;this.Events={e121y2_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e131y2_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e111y2_client:["DDO_MANAGEFILTERS.ONOPTIONCLICKED",!0],e141y2_client:["'DOADDSELECTED'",!0],e181y2_client:["ENTER",!0],e191y1_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{ctrl:"GRID",prop:"Rows"},{av:"AV48Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV12FilName",fld:"vFILNAME",pic:""},{av:"AV28GAMDescriptionLong",fld:"vGAMDESCRIPTIONLONG",pic:""},{av:"AV22UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV11FilExternalId",fld:"vFILEXTERNALID",pic:"",hsh:!0}],[{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV46GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV47GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV44ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV48Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV12FilName",fld:"vFILNAME",pic:""},{av:"AV28GAMDescriptionLong",fld:"vGAMDESCRIPTIONLONG",pic:""},{av:"AV22UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV11FilExternalId",fld:"vFILEXTERNALID",pic:"",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV48Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV12FilName",fld:"vFILNAME",pic:""},{av:"AV28GAMDescriptionLong",fld:"vGAMDESCRIPTIONLONG",pic:""},{av:"AV22UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV11FilExternalId",fld:"vFILEXTERNALID",pic:"",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{ctrl:"GRID",prop:"Rows"}]];this.EvtParms["GRID.LOAD"]=[[{ctrl:"GRID",prop:"Rows"},{av:"AV22UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV12FilName",fld:"vFILNAME",pic:""},{av:"AV11FilExternalId",fld:"vFILEXTERNALID",pic:"",hsh:!0}],[{av:"AV26GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV21Select",fld:"vSELECT",pic:""},{av:"AV16Id",fld:"vID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV18Name",fld:"vNAME",pic:""}]];this.EvtParms["DDO_MANAGEFILTERS.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV48Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV12FilName",fld:"vFILNAME",pic:""},{av:"AV28GAMDescriptionLong",fld:"vGAMDESCRIPTIONLONG",pic:""},{av:"AV22UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV11FilExternalId",fld:"vFILEXTERNALID",pic:"",hsh:!0},{av:"this.DDO_MANAGEFILTERSContainer.ActiveEventKey",ctrl:"DDO_MANAGEFILTERS",prop:"ActiveEventKey"},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""}],[{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""},{av:"AV12FilName",fld:"vFILNAME",pic:""},{av:"AV28GAMDescriptionLong",fld:"vGAMDESCRIPTIONLONG",pic:""},{av:"AV46GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV47GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV44ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""}]];this.EvtParms["'DOADDSELECTED'"]=[[{av:"AV22UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV21Select",fld:"vSELECT",grid:38,pic:""},{av:"GRID_nFirstRecordOnPage"},{av:"nRC_GXsfl_38",ctrl:"GRID",grid:38,prop:"GridRC",grid:38},{av:"AV16Id",fld:"vID",grid:38,pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV17isOK",fld:"vISOK",pic:""}],[{av:"AV17isOK",fld:"vISOK",pic:""}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV40ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV48Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV22UserId","vUSERID",0,"char",40,0);this.setVCMap("AV11FilExternalId","vFILEXTERNALID",0,"char",254,0);this.setVCMap("AV37GridState","vGRIDSTATE",0,"WWPBaseObjectsWWPGridState",0,0);this.setVCMap("AV17isOK","vISOK",0,"boolean",4,0);this.setVCMap("AV40ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV48Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV22UserId","vUSERID",0,"char",40,0);this.setVCMap("AV11FilExternalId","vFILEXTERNALID",0,"char",254,0);this.setVCMap("AV40ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV48Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV22UserId","vUSERID",0,"char",40,0);this.setVCMap("AV11FilExternalId","vFILEXTERNALID",0,"char",254,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV40ManageFiltersExecutionStep"});i.addRefreshingVar({rfrVar:"AV48Pgmname"});i.addRefreshingVar(this.GXValidFnc[24]);i.addRefreshingVar(this.GXValidFnc[29]);i.addRefreshingVar({rfrVar:"AV22UserId"});i.addRefreshingVar({rfrVar:"AV11FilExternalId"});i.addRefreshingParm({rfrVar:"AV40ManageFiltersExecutionStep"});i.addRefreshingParm({rfrVar:"AV48Pgmname"});i.addRefreshingParm(this.GXValidFnc[24]);i.addRefreshingParm(this.GXValidFnc[29]);i.addRefreshingParm({rfrVar:"AV22UserId"});i.addRefreshingParm({rfrVar:"AV11FilExternalId"});this.Initialize();this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});this.setSDTMapping("GeneXusSecurity\\GAMApplication",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMMenuOptionList",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"},Nodes:{sdt:"GeneXusSecurity\\GAMMenuOptionList"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState",{FilterValues:{sdt:"WWPBaseObjects\\WWPGridState.FilterValue"},DynamicFilters:{sdt:"WWPBaseObjects\\WWPGridState.DynamicFilter"}});this.setSDTMapping("GeneXusSecurity\\GAMRole",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMRepository",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState.DynamicFilter",{Dsc:{extr:"d"}});this.setSDTMapping("GeneXusSecurity\\GAMSession",{User:{sdt:"GeneXusSecurity\\GAMUser"},InitialProperties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMLoginAdditionalParameters",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMPermission",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}});this.setSDTMapping("GeneXusSecurity\\GAMRoleFilter",{Properties:{sdt:"GeneXusSecurity\\GAMProperty"}})});gx.wi(function(){gx.createParentObj(this.gamuserroleselect)})