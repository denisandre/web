gx.evt.autoSkip=!1;gx.define("gamnotauthorized",!1,function(){this.ServerClass="gamnotauthorized";this.PackageName="GeneXus.Programs";this.ServerFullClass="gamnotauthorized.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){};this.e120f2_client=function(){return this.executeServerEvent("LOGINAGAIN.CLICK",!0,null,!1,!0)};this.e130f2_client=function(){return this.executeServerEvent("RETURN.CLICK",!0,null,!1,!0)};this.e150f2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e160f2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,18,20,23,25];this.GXLastCtrlId=25;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"GAMNOTAUTHORIZED",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"UNAUTHORIZEDACCESS",format:0,grid:0,ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"UNNAMEDTABLE1",grid:0};n[18]={id:18,fld:"TOLOGINAGAIN",format:0,grid:0,ctrltype:"textblock"};n[20]={id:20,fld:"LOGINAGAIN",format:0,grid:0,evt:"e120f2_client",ctrltype:"textblock"};n[23]={id:23,fld:"TORETURN",format:0,grid:0,ctrltype:"textblock"};n[25]={id:25,fld:"RETURN",format:0,grid:0,evt:"e130f2_client",ctrltype:"textblock"};this.Events={e120f2_client:["LOGINAGAIN.CLICK",!0],e130f2_client:["RETURN.CLICK",!0],e150f2_client:["ENTER",!0],e160f2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[],[]];this.EvtParms["LOGINAGAIN.CLICK"]=[[],[]];this.EvtParms["RETURN.CLICK"]=[[],[]];this.EvtParms.ENTER=[[],[]];this.Initialize()});gx.wi(function(){gx.createParentObj(this.gamnotauthorized)})