gx.evt.autoSkip=!1;gx.define("wwpbaseobjects.subscriptions.wwp_subscriptionssettingsbyrolewc",!0,function(n){var i,t,r;this.ServerClass="wwpbaseobjects.subscriptions.wwp_subscriptionssettingsbyrolewc";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwpbaseobjects.subscriptions.wwp_subscriptionssettingsbyrolewc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV26Pgmname=gx.fn.getControlValue("vPGMNAME");this.A62WWPEntityId=gx.fn.getIntegerValue("WWPENTITYID",".");this.AV13WWPEntityId=gx.fn.getIntegerValue("vWWPENTITYID",".");this.A72WWPNotificationDefinitionAppli=gx.fn.getIntegerValue("WWPNOTIFICATIONDEFINITIONAPPLI",".");this.A65WWPNotificationDefinitionId=gx.fn.getIntegerValue("WWPNOTIFICATIONDEFINITIONID",".");this.A71WWPNotificationDefinitionDescr=gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONDESCR");this.A61WWPSubscriptionRoleId=gx.fn.getControlValue("WWPSUBSCRIPTIONROLEID");this.AV16WWPSubscriptionRoleId=gx.fn.getControlValue("vWWPSUBSCRIPTIONROLEID");this.A67WWPSubscriptionId=gx.fn.getIntegerValue("WWPSUBSCRIPTIONID",".");this.AV10NotifShowOnlySubscribedEvents=gx.fn.getControlValue("vNOTIFSHOWONLYSUBSCRIBEDEVENTS");this.subGrid_Recordcount=gx.fn.getIntegerValue("subGrid_Recordcount",".")};this.e112j2_client=function(){return this.executeServerEvent("TABLESUBSCRIPTIONITEM.CLICK",!0,arguments[0],!1,!0)};this.e152j2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e162j2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];i=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,11,15,16,17,18,19,20,21,22,23,24,25,26,27,30,31,33,34];this.GXLastCtrlId=34;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",14,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"wwpbaseobjects.subscriptions.wwp_subscriptionssettingsbyrolewc",[],!0,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","Novo registro",!0,!1,!0,null,null,!1,"",!0,[1,1,1,1],!1,0,!1,!1);t=this.GridContainer;t.startDiv(15,"Unnamedtablefsgrid","0px","0px");t.startDiv(16,"","0px","0px");t.startDiv(17,"","0px","0px");t.startDiv(18,"Tablesubscriptionitem","0px","0px");t.startDiv(19,"","0px","0px");t.startDiv(20,"","0px","0px");t.addLabel();t.addCheckBox("Includenotification",21,"vINCLUDENOTIFICATION","","","IncludeNotification","boolean","true","false",null,!0,!1,4,"chr","");t.endDiv();t.endDiv();t.startDiv(22,"","0px","0px");t.startDiv(23,"","0px","0px");t.addLabel();t.addMultipleLineEdit("Wwpnotificationdescription",24,"vWWPNOTIFICATIONDESCRIPTION","","WWPNotificationDescription","svchar",80,"chr",3,"row","200",200,"start",null,!0,!1,0,"");t.endDiv();t.endDiv();t.endDiv();t.endDiv();t.endDiv();t.startDiv(25,"","0px","0px");t.startDiv(26,"","0px","0px");t.startTable("Unnamedtablecontentfsgrid",27,"0px");t.startRow("","","","","","");t.startCell("","","","","","","","","","");t.startDiv(30,"","0px","0px");t.addLabel();t.addSingleLineEdit("Wwpnotificationdefinitionid",31,"vWWPNOTIFICATIONDEFINITIONID","","","WWPNotificationDefinitionId","int",10,"chr",10,10,"end",null,[],"Wwpnotificationdefinitionid","WWPNotificationDefinitionId",!0,0,!1,!1,"Attribute",0,"");t.endDiv();t.endCell();t.startCell("","","","","","","","","","");t.startDiv(33,"","0px","0px");t.addLabel();t.addSingleLineEdit("Wwpsubscriptionid",34,"vWWPSUBSCRIPTIONID","","","WWPSubscriptionId","int",10,"chr",10,10,"end",null,[],"Wwpsubscriptionid","WWPSubscriptionId",!0,0,!1,!1,"Attribute",0,"");t.endDiv();t.endCell();t.endRow();t.endTable();t.endDiv();t.endDiv();t.endDiv();this.GridContainer.emptyText="";this.setGrid(t);this.DVPANEL_UNNAMEDTABLE1Container=gx.uc.getNew(this,9,0,"BootstrapPanel",this.CmpContext+"DVPANEL_UNNAMEDTABLE1Container","Dvpanel_unnamedtable1","DVPANEL_UNNAMEDTABLE1");r=this.DVPANEL_UNNAMEDTABLE1Container;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("Width","Width","100%","str");r.setProp("Height","Height","100","str");r.setProp("AutoWidth","Autowidth",!1,"bool");r.setProp("AutoHeight","Autoheight",!0,"bool");r.setProp("Cls","Cls","PanelNoHeader","str");r.setProp("ShowHeader","Showheader",!0,"bool");r.setProp("Title","Title","","str");r.setProp("Collapsible","Collapsible",!0,"bool");r.setProp("Collapsed","Collapsed",!1,"bool");r.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");r.setProp("IconPosition","Iconposition","Right","str");r.setProp("AutoScroll","Autoscroll",!1,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);i[2]={id:2,fld:"",grid:0};i[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};i[4]={id:4,fld:"",grid:0};i[5]={id:5,fld:"",grid:0};i[6]={id:6,fld:"TABLEMAIN",grid:0};i[7]={id:7,fld:"",grid:0};i[8]={id:8,fld:"",grid:0};i[11]={id:11,fld:"UNNAMEDTABLE1",grid:0};i[15]={id:15,fld:"UNNAMEDTABLEFSGRID",grid:14};i[16]={id:16,fld:"",grid:14};i[17]={id:17,fld:"",grid:14};i[18]={id:18,fld:"TABLESUBSCRIPTIONITEM",grid:14,evt:"e112j2_client"};i[19]={id:19,fld:"",grid:14};i[20]={id:20,fld:"",grid:14};i[21]={id:21,lvl:2,type:"boolean",len:4,dec:0,sign:!1,ro:0,isacc:0,grid:14,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vINCLUDENOTIFICATION",fmt:0,gxz:"ZV9IncludeNotification",gxold:"OV9IncludeNotification",gxvar:"AV9IncludeNotification",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV9IncludeNotification=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV9IncludeNotification=gx.lang.booleanValue(n))},v2c:function(n){gx.fn.setGridCheckBoxValue("vINCLUDENOTIFICATION",n||gx.fn.currentGridRowImpl(14),gx.O.AV9IncludeNotification,!0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV9IncludeNotification=gx.lang.booleanValue(this.val(n)))},val:function(n){return gx.fn.getGridControlValue("vINCLUDENOTIFICATION",n||gx.fn.currentGridRowImpl(14))},nac:gx.falseFn,values:["true","false"]};i[22]={id:22,fld:"",grid:14};i[23]={id:23,fld:"",grid:14};i[24]={id:24,lvl:2,type:"svchar",len:200,dec:0,sign:!1,ro:0,isacc:0,multiline:!0,grid:14,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vWWPNOTIFICATIONDESCRIPTION",fmt:0,gxz:"ZV14WWPNotificationDescription",gxold:"OV14WWPNotificationDescription",gxvar:"AV14WWPNotificationDescription",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV14WWPNotificationDescription=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14WWPNotificationDescription=n)},v2c:function(n){gx.fn.setGridControlValue("vWWPNOTIFICATIONDESCRIPTION",n||gx.fn.currentGridRowImpl(14),gx.O.AV14WWPNotificationDescription,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV14WWPNotificationDescription=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vWWPNOTIFICATIONDESCRIPTION",n||gx.fn.currentGridRowImpl(14))},nac:gx.falseFn};i[25]={id:25,fld:"",grid:14};i[26]={id:26,fld:"",grid:14};i[27]={id:27,fld:"UNNAMEDTABLECONTENTFSGRID",grid:14};i[30]={id:30,fld:"",grid:14};i[31]={id:31,lvl:2,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:0,isacc:0,grid:14,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vWWPNOTIFICATIONDEFINITIONID",fmt:0,gxz:"ZV5WWPNotificationDefinitionId",gxold:"OV5WWPNotificationDefinitionId",gxvar:"AV5WWPNotificationDefinitionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5WWPNotificationDefinitionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV5WWPNotificationDefinitionId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vWWPNOTIFICATIONDEFINITIONID",n||gx.fn.currentGridRowImpl(14),gx.O.AV5WWPNotificationDefinitionId,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV5WWPNotificationDefinitionId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vWWPNOTIFICATIONDEFINITIONID",n||gx.fn.currentGridRowImpl(14),".")},nac:gx.falseFn};i[33]={id:33,fld:"",grid:14};i[34]={id:34,lvl:2,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:0,isacc:0,grid:14,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vWWPSUBSCRIPTIONID",fmt:0,gxz:"ZV6WWPSubscriptionId",gxold:"OV6WWPSubscriptionId",gxvar:"AV6WWPSubscriptionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV6WWPSubscriptionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6WWPSubscriptionId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vWWPSUBSCRIPTIONID",n||gx.fn.currentGridRowImpl(14),gx.O.AV6WWPSubscriptionId,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV6WWPSubscriptionId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vWWPSUBSCRIPTIONID",n||gx.fn.currentGridRowImpl(14),".")},nac:gx.falseFn};this.ZV9IncludeNotification=!1;this.OV9IncludeNotification=!1;this.ZV14WWPNotificationDescription="";this.OV14WWPNotificationDescription="";this.ZV5WWPNotificationDefinitionId=0;this.OV5WWPNotificationDefinitionId=0;this.ZV6WWPSubscriptionId=0;this.OV6WWPSubscriptionId=0;this.AV13WWPEntityId=0;this.AV10NotifShowOnlySubscribedEvents=!1;this.AV16WWPSubscriptionRoleId="";this.AV9IncludeNotification=!1;this.AV14WWPNotificationDescription="";this.AV5WWPNotificationDefinitionId=0;this.AV6WWPSubscriptionId=0;this.A65WWPNotificationDefinitionId=0;this.A72WWPNotificationDefinitionAppli=0;this.A62WWPEntityId=0;this.A71WWPNotificationDefinitionDescr="";this.A61WWPSubscriptionRoleId="";this.A67WWPSubscriptionId=0;this.AV26Pgmname="";this.Events={e112j2_client:["TABLESUBSCRIPTIONITEM.CLICK",!0],e152j2_client:["ENTER",!0],e162j2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:'gx.fn.getCtrlProperty("vWWPNOTIFICATIONDEFINITIONID","Visible")',ctrl:"vWWPNOTIFICATIONDEFINITIONID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vWWPSUBSCRIPTIONID","Visible")',ctrl:"vWWPSUBSCRIPTIONID",prop:"Visible"},{av:"A62WWPEntityId",fld:"WWPENTITYID",pic:"ZZZZZZZZZ9"},{av:"AV13WWPEntityId",fld:"vWWPENTITYID",pic:"ZZZZZZZZZ9"},{av:"A72WWPNotificationDefinitionAppli",fld:"WWPNOTIFICATIONDEFINITIONAPPLI",pic:"9"},{av:"A65WWPNotificationDefinitionId",fld:"WWPNOTIFICATIONDEFINITIONID",pic:"ZZZZZZZZZ9"},{av:"A71WWPNotificationDefinitionDescr",fld:"WWPNOTIFICATIONDEFINITIONDESCR",pic:""},{av:"A61WWPSubscriptionRoleId",fld:"WWPSUBSCRIPTIONROLEID",pic:""},{av:"AV16WWPSubscriptionRoleId",fld:"vWWPSUBSCRIPTIONROLEID",pic:""},{av:"A67WWPSubscriptionId",fld:"WWPSUBSCRIPTIONID",pic:"ZZZZZZZZZ9"},{av:"AV10NotifShowOnlySubscribedEvents",fld:"vNOTIFSHOWONLYSUBSCRIBEDEVENTS",pic:""},{av:"sPrefix"},{ctrl:"GRID",prop:"Rows"},{av:"AV26Pgmname",fld:"vPGMNAME",pic:"",hsh:!0}],[]];this.EvtParms["GRID.LOAD"]=[[{av:"A62WWPEntityId",fld:"WWPENTITYID",pic:"ZZZZZZZZZ9"},{av:"AV13WWPEntityId",fld:"vWWPENTITYID",pic:"ZZZZZZZZZ9"},{av:"A72WWPNotificationDefinitionAppli",fld:"WWPNOTIFICATIONDEFINITIONAPPLI",pic:"9"},{av:"A65WWPNotificationDefinitionId",fld:"WWPNOTIFICATIONDEFINITIONID",pic:"ZZZZZZZZZ9"},{av:"A71WWPNotificationDefinitionDescr",fld:"WWPNOTIFICATIONDEFINITIONDESCR",pic:""},{av:"A61WWPSubscriptionRoleId",fld:"WWPSUBSCRIPTIONROLEID",pic:""},{av:"AV16WWPSubscriptionRoleId",fld:"vWWPSUBSCRIPTIONROLEID",pic:""},{av:"A67WWPSubscriptionId",fld:"WWPSUBSCRIPTIONID",pic:"ZZZZZZZZZ9"},{av:"AV10NotifShowOnlySubscribedEvents",fld:"vNOTIFSHOWONLYSUBSCRIBEDEVENTS",pic:""},{ctrl:"GRID",prop:"Rows"}],[{av:"AV5WWPNotificationDefinitionId",fld:"vWWPNOTIFICATIONDEFINITIONID",pic:"ZZZZZZZZZ9"},{av:"AV14WWPNotificationDescription",fld:"vWWPNOTIFICATIONDESCRIPTION",pic:""},{av:"AV9IncludeNotification",fld:"vINCLUDENOTIFICATION",pic:""},{av:"AV6WWPSubscriptionId",fld:"vWWPSUBSCRIPTIONID",pic:"ZZZZZZZZZ9"}]];this.EvtParms["TABLESUBSCRIPTIONITEM.CLICK"]=[[{av:"AV9IncludeNotification",fld:"vINCLUDENOTIFICATION",grid:14,pic:""},{av:"GRID_nFirstRecordOnPage"},{av:"nRC_GXsfl_14",ctrl:"GRID",grid:14,prop:"GridRC",grid:14},{av:"AV6WWPSubscriptionId",fld:"vWWPSUBSCRIPTIONID",grid:14,pic:"ZZZZZZZZZ9"},{av:"AV5WWPNotificationDefinitionId",fld:"vWWPNOTIFICATIONDEFINITIONID",grid:14,pic:"ZZZZZZZZZ9"},{av:"AV16WWPSubscriptionRoleId",fld:"vWWPSUBSCRIPTIONROLEID",pic:""}],[{av:"AV9IncludeNotification",fld:"vINCLUDENOTIFICATION",pic:""},{av:"AV6WWPSubscriptionId",fld:"vWWPSUBSCRIPTIONID",pic:"ZZZZZZZZZ9"}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:'gx.fn.getCtrlProperty("vWWPNOTIFICATIONDEFINITIONID","Visible")',ctrl:"vWWPNOTIFICATIONDEFINITIONID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vWWPSUBSCRIPTIONID","Visible")',ctrl:"vWWPSUBSCRIPTIONID",prop:"Visible"},{av:"A62WWPEntityId",fld:"WWPENTITYID",pic:"ZZZZZZZZZ9"},{av:"AV13WWPEntityId",fld:"vWWPENTITYID",pic:"ZZZZZZZZZ9"},{av:"A72WWPNotificationDefinitionAppli",fld:"WWPNOTIFICATIONDEFINITIONAPPLI",pic:"9"},{av:"A65WWPNotificationDefinitionId",fld:"WWPNOTIFICATIONDEFINITIONID",pic:"ZZZZZZZZZ9"},{av:"A71WWPNotificationDefinitionDescr",fld:"WWPNOTIFICATIONDEFINITIONDESCR",pic:""},{av:"A61WWPSubscriptionRoleId",fld:"WWPSUBSCRIPTIONROLEID",pic:""},{av:"AV16WWPSubscriptionRoleId",fld:"vWWPSUBSCRIPTIONROLEID",pic:""},{av:"A67WWPSubscriptionId",fld:"WWPSUBSCRIPTIONID",pic:"ZZZZZZZZZ9"},{av:"AV10NotifShowOnlySubscribedEvents",fld:"vNOTIFSHOWONLYSUBSCRIBEDEVENTS",pic:""},{av:"sPrefix"},{av:"AV26Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{ctrl:"GRID",prop:"Rows"}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:'gx.fn.getCtrlProperty("vWWPNOTIFICATIONDEFINITIONID","Visible")',ctrl:"vWWPNOTIFICATIONDEFINITIONID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vWWPSUBSCRIPTIONID","Visible")',ctrl:"vWWPSUBSCRIPTIONID",prop:"Visible"},{av:"A62WWPEntityId",fld:"WWPENTITYID",pic:"ZZZZZZZZZ9"},{av:"AV13WWPEntityId",fld:"vWWPENTITYID",pic:"ZZZZZZZZZ9"},{av:"A72WWPNotificationDefinitionAppli",fld:"WWPNOTIFICATIONDEFINITIONAPPLI",pic:"9"},{av:"A65WWPNotificationDefinitionId",fld:"WWPNOTIFICATIONDEFINITIONID",pic:"ZZZZZZZZZ9"},{av:"A71WWPNotificationDefinitionDescr",fld:"WWPNOTIFICATIONDEFINITIONDESCR",pic:""},{av:"A61WWPSubscriptionRoleId",fld:"WWPSUBSCRIPTIONROLEID",pic:""},{av:"AV16WWPSubscriptionRoleId",fld:"vWWPSUBSCRIPTIONROLEID",pic:""},{av:"A67WWPSubscriptionId",fld:"WWPSUBSCRIPTIONID",pic:"ZZZZZZZZZ9"},{av:"AV10NotifShowOnlySubscribedEvents",fld:"vNOTIFSHOWONLYSUBSCRIBEDEVENTS",pic:""},{av:"sPrefix"},{av:"AV26Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{ctrl:"GRID",prop:"Rows"}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:'gx.fn.getCtrlProperty("vWWPNOTIFICATIONDEFINITIONID","Visible")',ctrl:"vWWPNOTIFICATIONDEFINITIONID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vWWPSUBSCRIPTIONID","Visible")',ctrl:"vWWPSUBSCRIPTIONID",prop:"Visible"},{av:"A62WWPEntityId",fld:"WWPENTITYID",pic:"ZZZZZZZZZ9"},{av:"AV13WWPEntityId",fld:"vWWPENTITYID",pic:"ZZZZZZZZZ9"},{av:"A72WWPNotificationDefinitionAppli",fld:"WWPNOTIFICATIONDEFINITIONAPPLI",pic:"9"},{av:"A65WWPNotificationDefinitionId",fld:"WWPNOTIFICATIONDEFINITIONID",pic:"ZZZZZZZZZ9"},{av:"A71WWPNotificationDefinitionDescr",fld:"WWPNOTIFICATIONDEFINITIONDESCR",pic:""},{av:"A61WWPSubscriptionRoleId",fld:"WWPSUBSCRIPTIONROLEID",pic:""},{av:"AV16WWPSubscriptionRoleId",fld:"vWWPSUBSCRIPTIONROLEID",pic:""},{av:"A67WWPSubscriptionId",fld:"WWPSUBSCRIPTIONID",pic:"ZZZZZZZZZ9"},{av:"AV10NotifShowOnlySubscribedEvents",fld:"vNOTIFSHOWONLYSUBSCRIBEDEVENTS",pic:""},{av:"sPrefix"},{av:"AV26Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{ctrl:"GRID",prop:"Rows"}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:'gx.fn.getCtrlProperty("vWWPNOTIFICATIONDEFINITIONID","Visible")',ctrl:"vWWPNOTIFICATIONDEFINITIONID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vWWPSUBSCRIPTIONID","Visible")',ctrl:"vWWPSUBSCRIPTIONID",prop:"Visible"},{av:"A62WWPEntityId",fld:"WWPENTITYID",pic:"ZZZZZZZZZ9"},{av:"AV13WWPEntityId",fld:"vWWPENTITYID",pic:"ZZZZZZZZZ9"},{av:"A72WWPNotificationDefinitionAppli",fld:"WWPNOTIFICATIONDEFINITIONAPPLI",pic:"9"},{av:"A65WWPNotificationDefinitionId",fld:"WWPNOTIFICATIONDEFINITIONID",pic:"ZZZZZZZZZ9"},{av:"A71WWPNotificationDefinitionDescr",fld:"WWPNOTIFICATIONDEFINITIONDESCR",pic:""},{av:"A61WWPSubscriptionRoleId",fld:"WWPSUBSCRIPTIONROLEID",pic:""},{av:"AV16WWPSubscriptionRoleId",fld:"vWWPSUBSCRIPTIONROLEID",pic:""},{av:"A67WWPSubscriptionId",fld:"WWPSUBSCRIPTIONID",pic:"ZZZZZZZZZ9"},{av:"AV10NotifShowOnlySubscribedEvents",fld:"vNOTIFSHOWONLYSUBSCRIBEDEVENTS",pic:""},{av:"sPrefix"},{av:"AV26Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{ctrl:"GRID",prop:"Rows"},{av:"subGrid_Recordcount"}],[]];this.setVCMap("AV26Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("A62WWPEntityId","WWPENTITYID",0,"int",10,0);this.setVCMap("AV13WWPEntityId","vWWPENTITYID",0,"int",10,0);this.setVCMap("A72WWPNotificationDefinitionAppli","WWPNOTIFICATIONDEFINITIONAPPLI",0,"int",1,0);this.setVCMap("A65WWPNotificationDefinitionId","WWPNOTIFICATIONDEFINITIONID",0,"int",10,0);this.setVCMap("A71WWPNotificationDefinitionDescr","WWPNOTIFICATIONDEFINITIONDESCR",0,"svchar",200,0);this.setVCMap("A61WWPSubscriptionRoleId","WWPSUBSCRIPTIONROLEID",0,"char",40,0);this.setVCMap("AV16WWPSubscriptionRoleId","vWWPSUBSCRIPTIONROLEID",0,"char",40,0);this.setVCMap("A67WWPSubscriptionId","WWPSUBSCRIPTIONID",0,"int",10,0);this.setVCMap("AV10NotifShowOnlySubscribedEvents","vNOTIFSHOWONLYSUBSCRIBEDEVENTS",0,"boolean",4,0);this.setVCMap("AV26Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("A62WWPEntityId","WWPENTITYID",0,"int",10,0);this.setVCMap("AV13WWPEntityId","vWWPENTITYID",0,"int",10,0);this.setVCMap("A72WWPNotificationDefinitionAppli","WWPNOTIFICATIONDEFINITIONAPPLI",0,"int",1,0);this.setVCMap("A65WWPNotificationDefinitionId","WWPNOTIFICATIONDEFINITIONID",0,"int",10,0);this.setVCMap("A71WWPNotificationDefinitionDescr","WWPNOTIFICATIONDEFINITIONDESCR",0,"svchar",200,0);this.setVCMap("A61WWPSubscriptionRoleId","WWPSUBSCRIPTIONROLEID",0,"char",40,0);this.setVCMap("AV16WWPSubscriptionRoleId","vWWPSUBSCRIPTIONROLEID",0,"char",40,0);this.setVCMap("A67WWPSubscriptionId","WWPSUBSCRIPTIONID",0,"int",10,0);this.setVCMap("AV10NotifShowOnlySubscribedEvents","vNOTIFSHOWONLYSUBSCRIBEDEVENTS",0,"boolean",4,0);this.setVCMap("AV26Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("A62WWPEntityId","WWPENTITYID",0,"int",10,0);this.setVCMap("AV13WWPEntityId","vWWPENTITYID",0,"int",10,0);this.setVCMap("A72WWPNotificationDefinitionAppli","WWPNOTIFICATIONDEFINITIONAPPLI",0,"int",1,0);this.setVCMap("A65WWPNotificationDefinitionId","WWPNOTIFICATIONDEFINITIONID",0,"int",10,0);this.setVCMap("A71WWPNotificationDefinitionDescr","WWPNOTIFICATIONDEFINITIONDESCR",0,"svchar",200,0);this.setVCMap("A61WWPSubscriptionRoleId","WWPSUBSCRIPTIONROLEID",0,"char",40,0);this.setVCMap("AV16WWPSubscriptionRoleId","vWWPSUBSCRIPTIONROLEID",0,"char",40,0);this.setVCMap("A67WWPSubscriptionId","WWPSUBSCRIPTIONID",0,"int",10,0);this.setVCMap("AV10NotifShowOnlySubscribedEvents","vNOTIFSHOWONLYSUBSCRIBEDEVENTS",0,"boolean",4,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});t.addRefreshingVar({rfrVar:"AV26Pgmname"});t.addRefreshingVar({rfrVar:"AV5WWPNotificationDefinitionId",rfrProp:"Visible",gxAttId:"Wwpnotificationdefinitionid"});t.addRefreshingVar({rfrVar:"AV6WWPSubscriptionId",rfrProp:"Visible",gxAttId:"Wwpsubscriptionid"});t.addRefreshingVar({rfrVar:"A62WWPEntityId"});t.addRefreshingVar({rfrVar:"AV13WWPEntityId"});t.addRefreshingVar({rfrVar:"A72WWPNotificationDefinitionAppli"});t.addRefreshingVar({rfrVar:"A65WWPNotificationDefinitionId"});t.addRefreshingVar({rfrVar:"A71WWPNotificationDefinitionDescr"});t.addRefreshingVar({rfrVar:"A61WWPSubscriptionRoleId"});t.addRefreshingVar({rfrVar:"AV16WWPSubscriptionRoleId"});t.addRefreshingVar({rfrVar:"A67WWPSubscriptionId"});t.addRefreshingVar({rfrVar:"AV10NotifShowOnlySubscribedEvents"});t.addRefreshingParm({rfrVar:"AV26Pgmname"});t.addRefreshingParm({rfrVar:"AV5WWPNotificationDefinitionId",rfrProp:"Visible",gxAttId:"Wwpnotificationdefinitionid"});t.addRefreshingParm({rfrVar:"AV6WWPSubscriptionId",rfrProp:"Visible",gxAttId:"Wwpsubscriptionid"});t.addRefreshingParm({rfrVar:"A62WWPEntityId"});t.addRefreshingParm({rfrVar:"AV13WWPEntityId"});t.addRefreshingParm({rfrVar:"A72WWPNotificationDefinitionAppli"});t.addRefreshingParm({rfrVar:"A65WWPNotificationDefinitionId"});t.addRefreshingParm({rfrVar:"A71WWPNotificationDefinitionDescr"});t.addRefreshingParm({rfrVar:"A61WWPSubscriptionRoleId"});t.addRefreshingParm({rfrVar:"AV16WWPSubscriptionRoleId"});t.addRefreshingParm({rfrVar:"A67WWPSubscriptionId"});t.addRefreshingParm({rfrVar:"AV10NotifShowOnlySubscribedEvents"});this.Initialize()})