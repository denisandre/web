gx.evt.autoSkip=!1;gx.define("gam_dashboard",!1,function(){var t,n;this.ServerClass="gam_dashboard";this.PackageName="GeneXus.Security.Backend";this.ServerFullClass="gam_dashboard.aspx";this.setObjectType("web");this.setAjaxSecurity(!1);this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="GAMDesignSystem";this.SetStandaloneVars=function(){};this.e132u2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e142u2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8];this.GXLastCtrlId=8;this.DASHBOARDVIEWERContainer=gx.uc.getNew(this,9,0,"DashboardViewer","DASHBOARDVIEWERContainer","Dashboardviewer","DASHBOARDVIEWER");n=this.DASHBOARDVIEWERContainer;n.setProp("Enabled","Enabled",!0,"boolean");n.setProp("Width","Width","100%","str");n.setProp("Height","Height","100%","str");n.setDynProp("Object","Objectcall","","str");n.setProp("Class","Class","DashboardViewer","str");n.setProp("DashboardSpec","Dashboardspec","","char");n.setProp("WidgetsExpanded","Widgetsexpanded",!0,"bool");n.setProp("CSSRules","Cssrules","","char");n.setProp("DefaultStyle","Defaultstyle","","char");n.setProp("TranslationType","Translationtype","RunTime","str");n.setProp("ApplicationNamespace","Applicationnamespace","GeneXus.Security.Backend","str");n.addV2CFunction("AV7ItemClickData","vITEMCLICKDATA","SetItemClickData");n.addC2VFunction(function(n){n.ParentObject.AV7ItemClickData=n.GetItemClickData();gx.fn.setControlValue("vITEMCLICKDATA",n.ParentObject.AV7ItemClickData)});n.addV2CFunction("AV5FiltersChangedData","vFILTERSCHANGEDDATA","SetFiltersChangedData");n.addC2VFunction(function(n){n.ParentObject.AV5FiltersChangedData=n.GetFiltersChangedData();gx.fn.setControlValue("vFILTERSCHANGEDDATA",n.ParentObject.AV5FiltersChangedData)});n.addV2CFunction("AV9ValuesHighlightedData","vVALUESHIGHLIGHTEDDATA","SetValuesHighlightedData");n.addC2VFunction(function(n){n.ParentObject.AV9ValuesHighlightedData=n.GetValuesHighlightedData();gx.fn.setControlValue("vVALUESHIGHLIGHTEDDATA",n.ParentObject.AV9ValuesHighlightedData)});n.setProp("Visible","Visible",!0,"bool");n.setC2ShowFunction(function(n){n.show()});this.setUserControl(n);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TBLTITLE",format:0,grid:0,ctrltype:"textblock"};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};this.AV7ItemClickData={Object:"",Element:"",Value:"",Context:[],AllFilters:[]};this.Events={e132u2_client:["ENTER",!0],e142u2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[],[]];this.EvtParms.ENTER=[[],[]];this.Initialize()});gx.wi(function(){gx.createParentObj(this.gam_dashboard)})