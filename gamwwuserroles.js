gx.evt.autoSkip=!1;gx.define("gamwwuserroles",!1,function(){var n,i,t,u,r;this.ServerClass="gamwwuserroles";this.PackageName="GeneXus.Programs";this.ServerFullClass="gamwwuserroles.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV57ManageFiltersExecutionStep=gx.fn.getIntegerValue("vMANAGEFILTERSEXECUTIONSTEP",".");this.AV69Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV28UserId=gx.fn.getControlValue("vUSERID");this.AV37GridState=gx.fn.getControlValue("vGRIDSTATE");this.AV67IsAuthorized_Back=gx.fn.getControlValue("vISAUTHORIZED_BACK");this.AV68IsAuthorized_Insert=gx.fn.getControlValue("vISAUTHORIZED_INSERT");this.AV27RolesId=gx.fn.getIntegerValue("vROLESID",".");this.subGrid_Recordcount=gx.fn.getIntegerValue("subGrid_Recordcount",".")};this.s152_client=function(){this.AV11DisplayInheritRoles=!1};this.e12232_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e13232_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e11232_client=function(){return this.executeServerEvent("DDO_MANAGEFILTERS.ONOPTIONCLICKED",!1,null,!0,!0)};this.e14232_client=function(){return this.executeServerEvent("'DOBACK'",!1,null,!1,!1)};this.e15232_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e19232_client=function(){return this.executeServerEvent("VDELETE.CLICK",!0,arguments[0],!1,!1)};this.e20232_client=function(){return this.executeServerEvent("'DOADD'",!0,arguments[0],!1,!1)};this.e21232_client=function(){return this.executeServerEvent("VBTNMAINROLE.CLICK",!0,arguments[0],!1,!1)};this.e22232_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e23232_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,26,29,30,31,32,33,35,36,37,38,39,41,42,43,44,45,46,47,49,50,51];this.GXLastCtrlId=51;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",40,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"gamwwuserroles",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Novo registro",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addSingleLineEdit("Delete",41,"vDELETE","","Excluir","Delete","char",0,"px",20,20,"start","e19232_client",[],"Delete","Delete",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn");i.addSingleLineEdit("Btnmainrole",42,"vBTNMAINROLE","","","BtnMainRole","char",120,"px",10,10,"start","e21232_client",[],"Btnmainrole","BtnMainRole",!0,0,!1,!1,"Attribute",0,"WWActionColumn");i.addSingleLineEdit("Name",43,"vNAME","Perfil","","Name","char",0,"px",120,80,"start",null,[],"Name","Name",!0,0,!1,!1,"Attribute",0,"WWColumn");i.addSingleLineEdit("Id",44,"vID","Key Numeric Long","","Id","int",0,"px",12,12,"end",null,[],"Id","Id",!1,0,!1,!1,"Attribute",0,"WWColumn");i.addSingleLineEdit("Guid",45,"vGUID","Guid","","GUID","char",0,"px",40,40,"start",null,[],"Guid","GUID",!1,0,!1,!1,"Attribute",0,"WWColumn");this.GridContainer.emptyText="";this.setGrid(i);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,48,31,"DVelop_DVPaginationBar","GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");t=this.GRIDPAGINATIONBARContainer;t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Class","Class","PaginationBar","str");t.setProp("ShowFirst","Showfirst",!0,"bool");t.setProp("ShowPrevious","Showprevious",!0,"bool");t.setProp("ShowNext","Shownext",!0,"bool");t.setProp("ShowLast","Showlast",!0,"bool");t.setProp("PagesToShow","Pagestoshow",5,"num");t.setProp("PagingButtonsPosition","Pagingbuttonsposition","Left","str");t.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");t.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");t.setProp("SelectedPage","Selectedpage","","char");t.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");t.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");t.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");t.setProp("First","First","WWP_PagingFirstCaption","str");t.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");t.setProp("Next","Next","WWP_PagingNextCaption","str");t.setProp("Last","Last","WWP_PagingLastCaption","str");t.setProp("Caption","Caption","Página <CURRENT_PAGE> de <TOTAL_PAGES>","str");t.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");t.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");t.addV2CFunction("AV64GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");t.addC2VFunction(function(n){n.ParentObject.AV64GridCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",n.ParentObject.AV64GridCurrentPage)});t.addV2CFunction("AV18GridPageCount","vGRIDPAGECOUNT","SetPageCount");t.addC2VFunction(function(n){n.ParentObject.AV18GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV18GridPageCount)});t.setProp("RecordCount","Recordcount","","str");t.setProp("Page","Page","","str");t.addV2CFunction("AV66GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");t.addC2VFunction(function(n){n.ParentObject.AV66GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV66GridAppliedFilters)});t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("ChangePage",this.e12232_client);t.addEventHandler("ChangeRowsPerPage",this.e13232_client);this.setUserControl(t);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,52,31,"WWP_GridEmpowerer","GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");u=this.GRID_EMPOWERERContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setDynProp("GridInternalName","Gridinternalname","","char");u.setProp("HasCategories","Hascategories",!1,"bool");u.setProp("InfiniteScrolling","Infinitescrolling","False","str");u.setProp("HasTitleSettings","Hastitlesettings",!1,"bool");u.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");u.setProp("HasRowGroups","Hasrowgroups",!1,"bool");u.setProp("FixedColumns","Fixedcolumns","","str");u.setProp("PopoversInGrid","Popoversingrid","","str");u.setProp("Visible","Visible",!0,"bool");u.setC2ShowFunction(function(n){n.show()});this.setUserControl(u);this.DDO_MANAGEFILTERSContainer=gx.uc.getNew(this,24,0,"BootstrapDropDownOptions","DDO_MANAGEFILTERSContainer","Ddo_managefilters","DDO_MANAGEFILTERS");r=this.DDO_MANAGEFILTERSContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("IconType","Icontype","FontIcon","str");r.setProp("Icon","Icon","fas fa-filter","str");r.setProp("Caption","Caption","","str");r.setProp("Tooltip","Tooltip","WWP_ManageFiltersTooltip","str");r.setProp("Cls","Cls","ManageFilters","str");r.setProp("ActiveEventKey","Activeeventkey","","char");r.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");r.setProp("DropDownOptionsType","Dropdownoptionstype","Regular","str");r.setProp("Visible","Visible",!0,"bool");r.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");r.addV2CFunction("AV61ManageFiltersData","vMANAGEFILTERSDATA","SetDropDownOptionsData");r.addC2VFunction(function(n){n.ParentObject.AV61ManageFiltersData=n.GetDropDownOptionsData();gx.fn.setControlValue("vMANAGEFILTERSDATA",n.ParentObject.AV61ManageFiltersData)});r.setC2ShowFunction(function(n){n.show()});r.addEventHandler("OnOptionClicked",this.e11232_client);this.setUserControl(r);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TABLEHEADER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLEACTIONS",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"BTNBACK",grid:0,evt:"e14232_client"};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"BTNINSERT",grid:0,evt:"e15232_client"};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"TABLERIGHTHEADER",grid:0};n[26]={id:26,fld:"TABLEFILTERS",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDISPLAYINHERITROLES",fmt:0,gxz:"ZV11DisplayInheritRoles",gxold:"OV11DisplayInheritRoles",gxvar:"AV11DisplayInheritRoles",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV11DisplayInheritRoles=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV11DisplayInheritRoles=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vDISPLAYINHERITROLES",gx.O.AV11DisplayInheritRoles,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11DisplayInheritRoles=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vDISPLAYINHERITROLES")},nac:gx.falseFn,values:["true","false"]};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[41]={id:41,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:40,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",fmt:1,gxz:"ZV5Delete",gxold:"OV5Delete",gxvar:"AV5Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV5Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(40),gx.O.AV5Delete,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV5Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(40))},nac:gx.falseFn,evt:"e19232_client"};n[42]={id:42,lvl:2,type:"char",len:10,dec:0,sign:!1,ro:0,isacc:0,grid:40,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBTNMAINROLE",fmt:0,gxz:"ZV9BtnMainRole",gxold:"OV9BtnMainRole",gxvar:"AV9BtnMainRole",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV9BtnMainRole=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9BtnMainRole=n)},v2c:function(n){gx.fn.setGridControlValue("vBTNMAINROLE",n||gx.fn.currentGridRowImpl(40),gx.O.AV9BtnMainRole,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV9BtnMainRole=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vBTNMAINROLE",n||gx.fn.currentGridRowImpl(40))},nac:gx.falseFn,evt:"e21232_client"};n[43]={id:43,lvl:2,type:"char",len:120,dec:0,sign:!1,ro:0,isacc:0,grid:40,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",fmt:0,gxz:"ZV24Name",gxold:"OV24Name",gxvar:"AV24Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV24Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV24Name=n)},v2c:function(n){gx.fn.setGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(40),gx.O.AV24Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV24Name=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(40))},nac:gx.falseFn};n[44]={id:44,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,isacc:0,grid:40,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vID",fmt:0,gxz:"ZV22Id",gxold:"OV22Id",gxvar:"AV22Id",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV22Id=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV22Id=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vID",n||gx.fn.currentGridRowImpl(40),gx.O.AV22Id,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV22Id=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vID",n||gx.fn.currentGridRowImpl(40),".")},nac:gx.falseFn};n[45]={id:45,lvl:2,type:"char",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:40,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGUID",fmt:0,gxz:"ZV21GUID",gxold:"OV21GUID",gxvar:"AV21GUID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV21GUID=n)},v2z:function(n){n!==undefined&&(gx.O.ZV21GUID=n)},v2c:function(n){gx.fn.setGridControlValue("vGUID",n||gx.fn.currentGridRowImpl(40),gx.O.AV21GUID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV21GUID=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vGUID",n||gx.fn.currentGridRowImpl(40))},nac:gx.falseFn};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};this.AV11DisplayInheritRoles=!1;this.ZV11DisplayInheritRoles=!1;this.OV11DisplayInheritRoles=!1;this.ZV5Delete="";this.OV5Delete="";this.ZV9BtnMainRole="";this.OV9BtnMainRole="";this.ZV24Name="";this.OV24Name="";this.ZV22Id=0;this.OV22Id=0;this.ZV21GUID="";this.OV21GUID="";this.AV61ManageFiltersData=[];this.AV11DisplayInheritRoles=!1;this.AV64GridCurrentPage=0;this.AV28UserId="";this.AV5Delete="";this.AV9BtnMainRole="";this.AV24Name="";this.AV22Id=0;this.AV21GUID="";this.AV57ManageFiltersExecutionStep=0;this.AV69Pgmname="";this.AV37GridState={CurrentPage:0,OrderedBy:0,OrderedDsc:!1,HidingSearch:0,PageSize:"",CollapsedRecords:"",GroupBy:"",FilterValues:[],DynamicFilters:[]};this.AV67IsAuthorized_Back=!1;this.AV68IsAuthorized_Insert=!1;this.AV27RolesId=0;this.Events={e12232_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e13232_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e11232_client:["DDO_MANAGEFILTERS.ONOPTIONCLICKED",!0],e14232_client:["'DOBACK'",!0],e15232_client:["'DOINSERT'",!0],e19232_client:["VDELETE.CLICK",!0],e20232_client:["'DOADD'",!0],e21232_client:["VBTNMAINROLE.CLICK",!0],e22232_client:["ENTER",!0],e23232_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{ctrl:"GRID",prop:"Rows"},{av:"AV69Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""},{av:"AV28UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV27RolesId",fld:"vROLESID",pic:"ZZZZZZZZZZZ9",hsh:!0}],[{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV64GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV66GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{ctrl:"BTNBACK",prop:"Visible"},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV61ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV69Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""},{av:"AV28UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV27RolesId",fld:"vROLESID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV69Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""},{av:"AV28UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV27RolesId",fld:"vROLESID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{ctrl:"GRID",prop:"Rows"}]];this.EvtParms["GRID.LOAD"]=[[{av:"AV28UserId",fld:"vUSERID",pic:"",hsh:!0},{ctrl:"GRID",prop:"Rows"},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""}],[{av:"AV5Delete",fld:"vDELETE",pic:""},{av:"AV9BtnMainRole",fld:"vBTNMAINROLE",pic:"",hsh:!0},{av:"AV18GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV24Name",fld:"vNAME",pic:""},{av:'gx.fn.getCtrlProperty("vDELETE","Visible")',ctrl:"vDELETE",prop:"Visible"},{av:"AV21GUID",fld:"vGUID",pic:""},{av:"AV22Id",fld:"vID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:'gx.fn.getCtrlProperty("vBTNMAINROLE","Visible")',ctrl:"vBTNMAINROLE",prop:"Visible"}]];this.EvtParms["DDO_MANAGEFILTERS.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV69Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""},{av:"AV28UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV27RolesId",fld:"vROLESID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"this.DDO_MANAGEFILTERSContainer.ActiveEventKey",ctrl:"DDO_MANAGEFILTERS",prop:"ActiveEventKey"},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""}],[{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""},{av:"AV64GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV66GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{ctrl:"BTNBACK",prop:"Visible"},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV61ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""}]];this.EvtParms["'DOBACK'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV69Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""},{av:"AV28UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV27RolesId",fld:"vROLESID",pic:"ZZZZZZZZZZZ9",hsh:!0}],[{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV64GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV66GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{ctrl:"BTNBACK",prop:"Visible"},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV61ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""}]];this.EvtParms["'DOINSERT'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV69Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""},{av:"AV28UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV27RolesId",fld:"vROLESID",pic:"ZZZZZZZZZZZ9",hsh:!0}],[{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV64GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV66GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{ctrl:"BTNBACK",prop:"Visible"},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV61ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""}]];this.EvtParms["VDELETE.CLICK"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV69Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""},{av:"AV28UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV27RolesId",fld:"vROLESID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV22Id",fld:"vID",pic:"ZZZZZZZZZZZ9",hsh:!0}],[{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV64GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV66GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{ctrl:"BTNBACK",prop:"Visible"},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV61ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""}]];this.EvtParms["'DOADD'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV69Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""},{av:"AV28UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV27RolesId",fld:"vROLESID",pic:"ZZZZZZZZZZZ9",hsh:!0}],[{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV64GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV66GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{ctrl:"BTNBACK",prop:"Visible"},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV61ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""}]];this.EvtParms["VBTNMAINROLE.CLICK"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV69Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""},{av:"AV28UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV27RolesId",fld:"vROLESID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV9BtnMainRole",fld:"vBTNMAINROLE",pic:"",hsh:!0},{av:"AV22Id",fld:"vID",pic:"ZZZZZZZZZZZ9",hsh:!0}],[{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV64GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV66GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{ctrl:"BTNBACK",prop:"Visible"},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV61ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV57ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV69Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV28UserId","vUSERID",0,"char",40,0);this.setVCMap("AV37GridState","vGRIDSTATE",0,"WWPBaseObjectsWWPGridState",0,0);this.setVCMap("AV67IsAuthorized_Back","vISAUTHORIZED_BACK",0,"boolean",4,0);this.setVCMap("AV68IsAuthorized_Insert","vISAUTHORIZED_INSERT",0,"boolean",4,0);this.setVCMap("AV27RolesId","vROLESID",0,"int",12,0);this.setVCMap("AV57ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV69Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV28UserId","vUSERID",0,"char",40,0);this.setVCMap("AV57ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV69Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV28UserId","vUSERID",0,"char",40,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV57ManageFiltersExecutionStep"});i.addRefreshingVar({rfrVar:"AV69Pgmname"});i.addRefreshingVar(this.GXValidFnc[31]);i.addRefreshingVar({rfrVar:"AV28UserId"});i.addRefreshingVar({rfrVar:"AV67IsAuthorized_Back"});i.addRefreshingVar({rfrVar:"AV68IsAuthorized_Insert"});i.addRefreshingVar({rfrVar:"AV27RolesId"});i.addRefreshingParm({rfrVar:"AV57ManageFiltersExecutionStep"});i.addRefreshingParm({rfrVar:"AV69Pgmname"});i.addRefreshingParm(this.GXValidFnc[31]);i.addRefreshingParm({rfrVar:"AV28UserId"});i.addRefreshingParm({rfrVar:"AV67IsAuthorized_Back"});i.addRefreshingParm({rfrVar:"AV68IsAuthorized_Insert"});i.addRefreshingParm({rfrVar:"AV27RolesId"});this.Initialize();this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState",{FilterValues:{sdt:"WWPBaseObjects\\WWPGridState.FilterValue"},DynamicFilters:{sdt:"WWPBaseObjects\\WWPGridState.DynamicFilter"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState.DynamicFilter",{Dsc:{extr:"d"}});this.setSDTMapping("WWPBaseObjects\\WWPColumnsSelector",{Columns:{sdt:"WWPBaseObjects\\WWPColumnsSelector.Column"}});this.setSDTMapping("WWPBaseObjects\\WWPColumnsSelector.Column",{ColumnName:{extr:"C"},IsVisible:{extr:"V"},DisplayName:{extr:"D"},Order:{extr:"O"},Category:{extr:"G"},Fixed:{extr:"F"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"},OptionGroup_fi:{extr:"og"}});this.setSDTMapping("GeneXusSecurity\\GAMApplication",{Environment:{sdt:"GeneXusSecurity\\GAMApplicationEnvironment"}})});gx.wi(function(){gx.createParentObj(this.gamwwuserroles)})