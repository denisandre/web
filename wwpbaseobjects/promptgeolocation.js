gx.evt.autoSkip=!1;gx.define("wwpbaseobjects.promptgeolocation",!1,function(){var t,n;this.ServerClass="wwpbaseobjects.promptgeolocation";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwpbaseobjects.promptgeolocation.aspx";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV10Latitude=gx.fn.getControlValue("vLATITUDE");this.AV7Geolocation=gx.fn.getControlValue("vGEOLOCATION");this.AV11Longitude=gx.fn.getControlValue("vLONGITUDE")};this.e120z2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e140z1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,8,14,15,16];this.GXLastCtrlId=16;this.GOOGLEMAPCONTROL1Container=gx.uc.getNew(this,11,0,"gxMap","GOOGLEMAPCONTROL1Container","Googlemapcontrol1","GOOGLEMAPCONTROL1");n=this.GOOGLEMAPCONTROL1Container;n.setProp("Class","Class","","char");n.setProp("Enabled","Enabled",!0,"boolean");n.setProp("Title","Title","Map Title","str");n.setProp("Width","Width","500px","str");n.setProp("Height","Height","350px","str");n.setProp("Provider","Provider","GOOGLE","str");n.setProp("Type","Type","G_NORMAL_MAP","str");n.setProp("City","City","","str");n.setDynProp("Latitude","Latitude","-34.906275829530244","str");n.setDynProp("Longitude","Longitude","-56.199703216552734","str");n.setProp("Precision","Precision",15,"num");n.setProp("Style","Style","GStyle_Standard","str");n.setProp("Small_Control","Gsmall","GSmall_True","str");n.setProp("Type_Control","Gtype","GType_False","str");n.setProp("Scale_Control","Scale","GScale_False","str");n.setProp("OverView_Control","Overview","GOverviewMap_False","str");n.setProp("Small_Zoom_Control","Smallzoom","GSmallZoom_False","str");n.setProp("Large_Control","Large","GLarge_False","str");n.setProp("MapType_Control_Style","Maptype_control_style","DEFAULT","str");n.setProp("Navigation_Control_Style","Navigation_control_style","DEFAULT","str");n.setProp("ScrollWheel","Scrollwheel",!0,"bool");n.addV2CFunction("GxMapData","vGXMAPDATA","SetData");n.addC2VFunction(function(n){n.ParentObject.GxMapData=n.GetData();gx.fn.setControlValue("vGXMAPDATA",n.ParentObject.GxMapData)});n.addV2CFunction("AV10Latitude","vLATITUDE","SetClickLatitude");n.addC2VFunction(function(n){n.ParentObject.AV10Latitude=n.GetClickLatitude();gx.fn.setControlValue("vLATITUDE",n.ParentObject.AV10Latitude)});n.addV2CFunction("AV11Longitude","vLONGITUDE","SetClickLongitude");n.addC2VFunction(function(n){n.ParentObject.AV11Longitude=n.GetClickLongitude();gx.fn.setControlValue("vLONGITUDE",n.ParentObject.AV11Longitude)});n.setProp("InformationControl","Informationcontrol","ControlName","str");n.setProp("Icon","Icon","Default","str");n.setProp("IconWidth","Iconwidth",20,"num");n.setProp("IconHeight","Iconheight",32,"num");n.setProp("AnchorLeft","Anchorleft",10,"num");n.setProp("AnchorTop","Anchortop",32,"num");n.setProp("GoogleApiKey","Googleapikey","","str");n.setProp("MarkerClustering","Markerclustering",!1,"bool");n.setProp("DisplayNumberClusteredPoints","Displaynumberclusteredpoints",!0,"bool");n.setProp("DisplayStyleClusteredPoints","Displaystyleclusteredpoints","","str");n.setProp("OpenLinksInNewWindow","Openlinksinnewwindow","OpenNew_True","str");n.setProp("KML","Kml",!1,"bool");n.setProp("KMLURL","Kmlurl","","str");n.setProp("getIcon","Geticon","Orange","str");n.setProp("Onclick","Onclick","getvalue","str");n.setProp("CenterWhenClick","Centerwhenclick",!0,"bool");n.setProp("Clear_Overlay","Clear_overlay",!1,"bool");n.setProp("BaiduKey","Baidukey","41e051de8c41e0a4532e367c6b0e12fc","str");n.setProp("Travel_Mode","Travel_mode","1","str");n.setProp("Visible","Visible",!0,"bool");n.setC2ShowFunction(function(n){n.show()});this.setUserControl(n);t[2]={id:2,fld:"TABLEMAIN",grid:0};t[8]={id:8,fld:"UTGEOLOCATION",grid:0};t[14]={id:14,fld:"ACTIONGROUP_ACTIONS",grid:0};t[15]={id:15,fld:"BTNENTER",grid:0,evt:"e120z2_client",std:"ENTER"};t[16]={id:16,fld:"BTNCANCEL",grid:0,evt:"e140z1_client"};this.GxMapData={MapType:"",MapZoom:0,MapLatitude:"",MapLongitude:"",Circles:[],Points:[],Polygons:[],Lines:[],Routing:[]};this.AV7Geolocation="";this.AV10Latitude="";this.AV11Longitude="";this.Events={e120z2_client:["ENTER",!0],e140z1_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[],[]];this.EvtParms.ENTER=[[{av:"AV10Latitude",fld:"vLATITUDE",pic:""},{av:"AV7Geolocation",fld:"vGEOLOCATION",pic:""},{av:"AV11Longitude",fld:"vLONGITUDE",pic:""}],[{av:"AV7Geolocation",fld:"vGEOLOCATION",pic:""}]];this.EnterCtrl=["BTNENTER"];this.setVCMap("AV10Latitude","vLATITUDE",0,"svchar",9,0);this.setVCMap("AV7Geolocation","vGEOLOCATION",0,"svchar",200,0);this.setVCMap("AV11Longitude","vLONGITUDE",0,"svchar",9,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.wwpbaseobjects.promptgeolocation)})