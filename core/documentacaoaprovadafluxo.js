gx.evt.autoSkip=!1;gx.define("core.documentacaoaprovadafluxo",!1,function(){var n,t,i,r,u,f;this.ServerClass="core.documentacaoaprovadafluxo";this.PackageName="GeneXus.Programs";this.ServerFullClass="core.documentacaoaprovadafluxo.aspx";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV9docFluxoAnaliseDocumentacao=gx.fn.getControlValue("vDOCFLUXOANALISEDOCUMENTACAO");this.AV10docFluxoCAFRegistrarEnvio=gx.fn.getControlValue("vDOCFLUXOCAFREGISTRARENVIO");this.AV11docFluxoCAFRegistrarRetorno=gx.fn.getControlValue("vDOCFLUXOCAFREGISTRARRETORNO");this.AV17docFluxoAnaliseCredito=gx.fn.getControlValue("vDOCFLUXOANALISECREDITO");this.AV16CheckRequiredFieldsResult=gx.fn.getControlValue("vCHECKREQUIREDFIELDSRESULT");this.AV12Messages=gx.fn.getControlValue("vMESSAGES")};this.e145q1_client=function(){return this.clearMessages(),gx.fn.setCtrlProperty("TBLREGISTRARENVIOCAF","Visible",this.AV9docFluxoAnaliseDocumentacao.NefConfirmado),gx.fn.setCtrlProperty("DOCFLUXOANALISEDOCUMENTACAO_NEFTEXTO_CELL","Class",this.AV9docFluxoAnaliseDocumentacao.NefConfirmado?"Invisible":"col-xs-12 DataContentCellFL RequiredDataContentCellFL"),gx.fn.setCtrlProperty("DOCFLUXOANALISEDOCUMENTACAO_NEFTEXTO","Visible",!this.AV9docFluxoAnaliseDocumentacao.NefConfirmado),this.AV9docFluxoAnaliseDocumentacao.NefConfirmado||(gx.fn.setCtrlProperty("TBLREGISTRARRETORNOCAF","Visible",!1),gx.fn.setCtrlProperty("TBLANACREDITO","Visible",!1),this.AV10docFluxoCAFRegistrarEnvio.NefConfirmado=!1,this.AV11docFluxoCAFRegistrarRetorno.NefConfirmado=!1,this.AV17docFluxoAnaliseCredito.NefConfirmado=!1,this.AV17docFluxoAnaliseCredito.NefValor=gx.num.trunc(0,0)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TBLREGISTRARENVIOCAF","Visible")',ctrl:"TBLREGISTRARENVIOCAF",prop:"Visible"},{av:'gx.fn.getCtrlProperty("DOCFLUXOANALISEDOCUMENTACAO_NEFTEXTO_CELL","Class")',ctrl:"DOCFLUXOANALISEDOCUMENTACAO_NEFTEXTO_CELL",prop:"Class"},{ctrl:"DOCFLUXOANALISEDOCUMENTACAO_NEFTEXTO",prop:"Visible"},{av:'gx.fn.getCtrlProperty("TBLREGISTRARRETORNOCAF","Visible")',ctrl:"TBLREGISTRARRETORNOCAF",prop:"Visible"},{av:'gx.fn.getCtrlProperty("TBLANACREDITO","Visible")',ctrl:"TBLANACREDITO",prop:"Visible"},{av:"AV10docFluxoCAFRegistrarEnvio",fld:"vDOCFLUXOCAFREGISTRARENVIO",pic:""},{av:"AV11docFluxoCAFRegistrarRetorno",fld:"vDOCFLUXOCAFREGISTRARRETORNO",pic:""},{av:"AV17docFluxoAnaliseCredito",fld:"vDOCFLUXOANALISECREDITO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e155q1_client=function(){return this.clearMessages(),gx.fn.setCtrlProperty("TBLREGISTRARRETORNOCAF","Visible",this.AV10docFluxoCAFRegistrarEnvio.NefConfirmado),this.AV10docFluxoCAFRegistrarEnvio.NefConfirmado||(gx.fn.setCtrlProperty("TBLANACREDITO","Visible",!1),this.AV11docFluxoCAFRegistrarRetorno.NefConfirmado=!1,this.AV17docFluxoAnaliseCredito.NefConfirmado=!1,this.AV17docFluxoAnaliseCredito.NefValor=gx.num.trunc(0,0)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TBLREGISTRARRETORNOCAF","Visible")',ctrl:"TBLREGISTRARRETORNOCAF",prop:"Visible"},{av:'gx.fn.getCtrlProperty("TBLANACREDITO","Visible")',ctrl:"TBLANACREDITO",prop:"Visible"},{av:"AV11docFluxoCAFRegistrarRetorno",fld:"vDOCFLUXOCAFREGISTRARRETORNO",pic:""},{av:"AV17docFluxoAnaliseCredito",fld:"vDOCFLUXOANALISECREDITO",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e165q1_client=function(){return this.clearMessages(),gx.fn.setCtrlProperty("TBLANACREDITO","Visible",this.AV11docFluxoCAFRegistrarRetorno.NefConfirmado),this.AV17docFluxoAnaliseCredito.NefConfirmado?gx.fn.setCtrlProperty("DOCFLUXOANALISECREDITO_NEFVALOR_CELL","Class","col-xs-12 DataContentCellFL RequiredDataContentCellFL"):gx.fn.setCtrlProperty("DOCFLUXOANALISECREDITO_NEFVALOR_CELL","Class","col-xs-12"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TBLANACREDITO","Visible")',ctrl:"TBLANACREDITO",prop:"Visible"},{av:'gx.fn.getCtrlProperty("DOCFLUXOANALISECREDITO_NEFVALOR_CELL","Class")',ctrl:"DOCFLUXOANALISECREDITO_NEFVALOR_CELL",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e125q2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e175q1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,11,12,13,15,17,18,19,20,21,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,41,42,43,44,45,46,47,48,49,50,51,54,55,56,57,58,59,60,61,62,63,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94];this.GXLastCtrlId=94;this.DVPANEL_TABLEOPORTUNIDADEContainer=gx.uc.getNew(this,9,0,"BootstrapPanel","DVPANEL_TABLEOPORTUNIDADEContainer","Dvpanel_tableoportunidade","DVPANEL_TABLEOPORTUNIDADE");t=this.DVPANEL_TABLEOPORTUNIDADEContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","100%","str");t.setProp("Height","Height","100","str");t.setProp("AutoWidth","Autowidth",!1,"bool");t.setProp("AutoHeight","Autoheight",!0,"bool");t.setProp("Cls","Cls","PanelCard_IconAndTitle Panel_BaseColor","str");t.setProp("ShowHeader","Showheader",!0,"bool");t.setDynProp("Title","Title","Negociação [!NEGCODIGO!]: [!NEGASSUNTO!]","str");t.setProp("Collapsible","Collapsible",!0,"bool");t.setProp("Collapsed","Collapsed",!0,"bool");t.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");t.setProp("IconPosition","Iconposition","Right","str");t.setProp("AutoScroll","Autoscroll",!1,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);this.DVPANEL_PNLANADOCUMENTACAOContainer=gx.uc.getNew(this,22,0,"BootstrapPanel","DVPANEL_PNLANADOCUMENTACAOContainer","Dvpanel_pnlanadocumentacao","DVPANEL_PNLANADOCUMENTACAO");i=this.DVPANEL_PNLANADOCUMENTACAOContainer;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Width","Width","100%","str");i.setProp("Height","Height","100","str");i.setProp("AutoWidth","Autowidth",!1,"bool");i.setProp("AutoHeight","Autoheight",!0,"bool");i.setProp("Cls","Cls","PanelCard_IconAndTitle Panel_BaseColor","str");i.setProp("ShowHeader","Showheader",!0,"bool");i.setProp("Title","Title","","str");i.setProp("Collapsible","Collapsible",!0,"bool");i.setProp("Collapsed","Collapsed",!1,"bool");i.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");i.setProp("IconPosition","Iconposition","Right","str");i.setProp("AutoScroll","Autoscroll",!1,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);this.DVPANEL_UNNAMEDTABLE1Container=gx.uc.getNew(this,39,29,"BootstrapPanel","DVPANEL_UNNAMEDTABLE1Container","Dvpanel_unnamedtable1","DVPANEL_UNNAMEDTABLE1");r=this.DVPANEL_UNNAMEDTABLE1Container;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("Width","Width","100%","str");r.setProp("Height","Height","100","str");r.setProp("AutoWidth","Autowidth",!1,"bool");r.setProp("AutoHeight","Autoheight",!0,"bool");r.setProp("Cls","Cls","PanelCard_IconAndTitle Panel_BaseColor","str");r.setProp("ShowHeader","Showheader",!0,"bool");r.setProp("Title","Title","","str");r.setProp("Collapsible","Collapsible",!0,"bool");r.setProp("Collapsed","Collapsed",!1,"bool");r.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");r.setProp("IconPosition","Iconposition","Right","str");r.setProp("AutoScroll","Autoscroll",!1,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);this.DVPANEL_PNLREGISTRARRETORNOCAFContainer=gx.uc.getNew(this,52,29,"BootstrapPanel","DVPANEL_PNLREGISTRARRETORNOCAFContainer","Dvpanel_pnlregistrarretornocaf","DVPANEL_PNLREGISTRARRETORNOCAF");u=this.DVPANEL_PNLREGISTRARRETORNOCAFContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("Width","Width","100%","str");u.setProp("Height","Height","100","str");u.setProp("AutoWidth","Autowidth",!1,"bool");u.setProp("AutoHeight","Autoheight",!0,"bool");u.setProp("Cls","Cls","PanelCard_IconAndTitle Panel_BaseColor","str");u.setProp("ShowHeader","Showheader",!0,"bool");u.setProp("Title","Title","","str");u.setProp("Collapsible","Collapsible",!0,"bool");u.setProp("Collapsed","Collapsed",!1,"bool");u.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");u.setProp("IconPosition","Iconposition","Right","str");u.setProp("AutoScroll","Autoscroll",!1,"bool");u.setProp("Visible","Visible",!0,"bool");u.setProp("Gx Control Type","Gxcontroltype","","int");u.setC2ShowFunction(function(n){n.show()});this.setUserControl(u);this.DVPANEL_PNLANACREDITOContainer=gx.uc.getNew(this,64,29,"BootstrapPanel","DVPANEL_PNLANACREDITOContainer","Dvpanel_pnlanacredito","DVPANEL_PNLANACREDITO");f=this.DVPANEL_PNLANACREDITOContainer;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setProp("Width","Width","100%","str");f.setProp("Height","Height","100","str");f.setProp("AutoWidth","Autowidth",!1,"bool");f.setProp("AutoHeight","Autoheight",!0,"bool");f.setProp("Cls","Cls","PanelCard_IconAndTitle Panel_BaseColor","str");f.setProp("ShowHeader","Showheader",!0,"bool");f.setProp("Title","Title","","str");f.setProp("Collapsible","Collapsible",!0,"bool");f.setProp("Collapsed","Collapsed",!1,"bool");f.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");f.setProp("IconPosition","Iconposition","Right","str");f.setProp("AutoScroll","Autoscroll",!1,"bool");f.setProp("Visible","Visible",!0,"bool");f.setProp("Gx Control Type","Gxcontroltype","","int");f.setC2ShowFunction(function(n){n.show()});this.setUserControl(f);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"DVPANEL_TABLEOPORTUNIDADE_CELL",grid:0};n[11]={id:11,fld:"TABLEOPORTUNIDADE",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"TBLANADOCUMENTACAO",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[24]={id:24,fld:"PNLANADOCUMENTACAO",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:"e145q1_client",evt_cvcing:null,rgrid:[],fld:"DOCFLUXOANALISEDOCUMENTACAO_NEFCONFIRMADO",fmt:0,gxz:"ZV18GXV1",gxold:"OV18GXV1",gxvar:"GXV1",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.GXV1=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV18GXV1=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setComboBoxValue("DOCFLUXOANALISEDOCUMENTACAO_NEFCONFIRMADO",gx.O.GXV1)},c2v:function(){this.val()!==undefined&&(gx.O.GXV1=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("DOCFLUXOANALISEDOCUMENTACAO_NEFCONFIRMADO")},nac:gx.falseFn};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"DOCFLUXOANALISEDOCUMENTACAO_NEFTEXTO_CELL",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"svchar",len:250,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCFLUXOANALISEDOCUMENTACAO_NEFTEXTO",fmt:0,gxz:"ZV19GXV2",gxold:"OV19GXV2",gxvar:"GXV2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.GXV2=n)},v2z:function(n){n!==undefined&&(gx.O.ZV19GXV2=n)},v2c:function(){gx.fn.setControlValue("DOCFLUXOANALISEDOCUMENTACAO_NEFTEXTO",gx.O.GXV2,0)},c2v:function(){this.val()!==undefined&&(gx.O.GXV2=this.val())},val:function(){return gx.fn.getControlValue("DOCFLUXOANALISEDOCUMENTACAO_NEFTEXTO")},nac:gx.falseFn};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"TBLREGISTRARENVIOCAF",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[41]={id:41,fld:"UNNAMEDTABLE1",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:"e155q1_client",evt_cvcing:null,rgrid:[],fld:"DOCFLUXOCAFREGISTRARENVIO_NEFCONFIRMADO",fmt:0,gxz:"ZV20GXV3",gxold:"OV20GXV3",gxvar:"GXV3",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.GXV3=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV20GXV3=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setComboBoxValue("DOCFLUXOCAFREGISTRARENVIO_NEFCONFIRMADO",gx.O.GXV3)},c2v:function(){this.val()!==undefined&&(gx.O.GXV3=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("DOCFLUXOCAFREGISTRARENVIO_NEFCONFIRMADO")},nac:gx.falseFn};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"TBLREGISTRARRETORNOCAF",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[54]={id:54,fld:"PNLREGISTRARRETORNOCAF",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:"e165q1_client",evt_cvcing:null,rgrid:[],fld:"DOCFLUXOCAFREGISTRARRETORNO_NEFCONFIRMADO",fmt:0,gxz:"ZV21GXV4",gxold:"OV21GXV4",gxvar:"GXV4",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.GXV4=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV21GXV4=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setComboBoxValue("DOCFLUXOCAFREGISTRARRETORNO_NEFCONFIRMADO",gx.O.GXV4)},c2v:function(){this.val()!==undefined&&(gx.O.GXV4=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("DOCFLUXOCAFREGISTRARRETORNO_NEFCONFIRMADO")},nac:gx.falseFn};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"TBLANACREDITO",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[66]={id:66,fld:"PNLANACREDITO",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCFLUXOANALISECREDITO_NEFCONFIRMADO",fmt:0,gxz:"ZV22GXV5",gxold:"OV22GXV5",gxvar:"GXV5",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.GXV5=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV22GXV5=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setComboBoxValue("DOCFLUXOANALISECREDITO_NEFCONFIRMADO",gx.O.GXV5)},c2v:function(){this.val()!==undefined&&(gx.O.GXV5=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("DOCFLUXOANALISECREDITO_NEFCONFIRMADO")},nac:gx.falseFn};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"DOCFLUXOANALISECREDITO_NEFVALOR_CELL",grid:0};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"",grid:0};n[76]={id:76,lvl:0,type:"int",len:3,dec:0,sign:!1,pic:"ZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCFLUXOANALISECREDITO_NEFVALOR",fmt:0,gxz:"ZV23GXV6",gxold:"OV23GXV6",gxvar:"GXV6",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.GXV6=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV23GXV6=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("DOCFLUXOANALISECREDITO_NEFVALOR",gx.O.GXV6,0)},c2v:function(){this.val()!==undefined&&(gx.O.GXV6=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("DOCFLUXOANALISECREDITO_NEFVALOR",".")},nac:gx.falseFn};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,fld:"TABLEHEADER",grid:0};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"TABLEHEADERCONTENT",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"TABLEACTIONS",grid:0};n[84]={id:84,fld:"",grid:0};n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"BTNCANCEL",grid:0,evt:"e175q1_client"};n[88]={id:88,fld:"",grid:0};n[89]={id:89,fld:"BTNENTER",grid:0,evt:"e125q2_client",std:"ENTER"};n[90]={id:90,fld:"",grid:0};n[91]={id:91,fld:"",grid:0};n[92]={id:92,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[93]={id:93,lvl:0,type:"svchar",len:30,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDOCORIGEM",fmt:0,gxz:"ZV5DocOrigem",gxold:"OV5DocOrigem",gxvar:"AV5DocOrigem",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV5DocOrigem=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5DocOrigem=n)},v2c:function(){gx.fn.setControlValue("vDOCORIGEM",gx.O.AV5DocOrigem,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV5DocOrigem=this.val())},val:function(){return gx.fn.getControlValue("vDOCORIGEM")},nac:gx.falseFn};n[94]={id:94,lvl:0,type:"svchar",len:50,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDOCORIGEMID",fmt:0,gxz:"ZV6DocOrigemID",gxold:"OV6DocOrigemID",gxvar:"AV6DocOrigemID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6DocOrigemID=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6DocOrigemID=n)},v2c:function(){gx.fn.setControlValue("vDOCORIGEMID",gx.O.AV6DocOrigemID,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6DocOrigemID=this.val())},val:function(){return gx.fn.getControlValue("vDOCORIGEMID")},nac:gx.falseFn};this.GXV1=!1;this.ZV18GXV1=!1;this.OV18GXV1=!1;this.GXV2="";this.ZV19GXV2="";this.OV19GXV2="";this.GXV3=!1;this.ZV20GXV3=!1;this.OV20GXV3=!1;this.GXV4=!1;this.ZV21GXV4=!1;this.OV21GXV4=!1;this.GXV5=!1;this.ZV22GXV5=!1;this.OV22GXV5=!1;this.GXV6=0;this.ZV23GXV6=0;this.OV23GXV6=0;this.AV5DocOrigem="";this.ZV5DocOrigem="";this.OV5DocOrigem="";this.AV6DocOrigemID="";this.ZV6DocOrigemID="";this.OV6DocOrigemID="";this.GXV1=!1;this.GXV2="";this.GXV3=!1;this.GXV4=!1;this.GXV5=!1;this.GXV6=0;this.AV5DocOrigem="";this.AV6DocOrigemID="";this.A345NegID="00000000-0000-0000-0000-000000000000";this.A362NegAssunto="";this.A356NegCodigo=0;this.AV9docFluxoAnaliseDocumentacao={NegID:"00000000-0000-0000-0000-000000000000",NefChave:"",NefConfirmado:!1,NefTexto:"",NefInsDataHora:gx.date.nullDate(),NefInsData:gx.date.nullDate(),NefInsHora:gx.date.nullDate(),NefInsUsuId:"",NefInsUsuNome:"",NefUpdDataHora:gx.date.nullDate(),NefUpdData:gx.date.nullDate(),NefUpdHora:gx.date.nullDate(),NefUpdUsuId:"",NefUpdUsuNome:"",NefValor:0};this.AV10docFluxoCAFRegistrarEnvio={NegID:"00000000-0000-0000-0000-000000000000",NefChave:"",NefConfirmado:!1,NefTexto:"",NefInsDataHora:gx.date.nullDate(),NefInsData:gx.date.nullDate(),NefInsHora:gx.date.nullDate(),NefInsUsuId:"",NefInsUsuNome:"",NefUpdDataHora:gx.date.nullDate(),NefUpdData:gx.date.nullDate(),NefUpdHora:gx.date.nullDate(),NefUpdUsuId:"",NefUpdUsuNome:"",NefValor:0};this.AV11docFluxoCAFRegistrarRetorno={NegID:"00000000-0000-0000-0000-000000000000",NefChave:"",NefConfirmado:!1,NefTexto:"",NefInsDataHora:gx.date.nullDate(),NefInsData:gx.date.nullDate(),NefInsHora:gx.date.nullDate(),NefInsUsuId:"",NefInsUsuNome:"",NefUpdDataHora:gx.date.nullDate(),NefUpdData:gx.date.nullDate(),NefUpdHora:gx.date.nullDate(),NefUpdUsuId:"",NefUpdUsuNome:"",NefValor:0};this.AV17docFluxoAnaliseCredito={NegID:"00000000-0000-0000-0000-000000000000",NefChave:"",NefConfirmado:!1,NefTexto:"",NefInsDataHora:gx.date.nullDate(),NefInsData:gx.date.nullDate(),NefInsHora:gx.date.nullDate(),NefInsUsuId:"",NefInsUsuNome:"",NefUpdDataHora:gx.date.nullDate(),NefUpdData:gx.date.nullDate(),NefUpdHora:gx.date.nullDate(),NefUpdUsuId:"",NefUpdUsuNome:"",NefValor:0};this.AV16CheckRequiredFieldsResult=!1;this.AV12Messages=[];this.Events={e125q2_client:["ENTER",!0],e175q1_client:["CANCEL",!0],e145q1_client:["DOCFLUXOANALISEDOCUMENTACAO_NEFCONFIRMADO.CONTROLVALUECHANGED",!1],e155q1_client:["DOCFLUXOCAFREGISTRARENVIO_NEFCONFIRMADO.CONTROLVALUECHANGED",!1],e165q1_client:["DOCFLUXOCAFREGISTRARRETORNO_NEFCONFIRMADO.CONTROLVALUECHANGED",!1]};this.EvtParms.REFRESH=[[{av:"AV5DocOrigem",fld:"vDOCORIGEM",pic:"",hsh:!0},{av:"AV6DocOrigemID",fld:"vDOCORIGEMID",pic:"",hsh:!0}],[]];this.EvtParms["DOCFLUXOANALISEDOCUMENTACAO_NEFCONFIRMADO.CONTROLVALUECHANGED"]=[[{av:"AV9docFluxoAnaliseDocumentacao",fld:"vDOCFLUXOANALISEDOCUMENTACAO",pic:""},{av:"AV10docFluxoCAFRegistrarEnvio",fld:"vDOCFLUXOCAFREGISTRARENVIO",pic:""},{av:"AV11docFluxoCAFRegistrarRetorno",fld:"vDOCFLUXOCAFREGISTRARRETORNO",pic:""},{av:"AV17docFluxoAnaliseCredito",fld:"vDOCFLUXOANALISECREDITO",pic:""}],[{av:'gx.fn.getCtrlProperty("TBLREGISTRARENVIOCAF","Visible")',ctrl:"TBLREGISTRARENVIOCAF",prop:"Visible"},{av:'gx.fn.getCtrlProperty("DOCFLUXOANALISEDOCUMENTACAO_NEFTEXTO_CELL","Class")',ctrl:"DOCFLUXOANALISEDOCUMENTACAO_NEFTEXTO_CELL",prop:"Class"},{ctrl:"DOCFLUXOANALISEDOCUMENTACAO_NEFTEXTO",prop:"Visible"},{av:'gx.fn.getCtrlProperty("TBLREGISTRARRETORNOCAF","Visible")',ctrl:"TBLREGISTRARRETORNOCAF",prop:"Visible"},{av:'gx.fn.getCtrlProperty("TBLANACREDITO","Visible")',ctrl:"TBLANACREDITO",prop:"Visible"},{av:"AV10docFluxoCAFRegistrarEnvio",fld:"vDOCFLUXOCAFREGISTRARENVIO",pic:""},{av:"AV11docFluxoCAFRegistrarRetorno",fld:"vDOCFLUXOCAFREGISTRARRETORNO",pic:""},{av:"AV17docFluxoAnaliseCredito",fld:"vDOCFLUXOANALISECREDITO",pic:""}]];this.EvtParms["DOCFLUXOCAFREGISTRARENVIO_NEFCONFIRMADO.CONTROLVALUECHANGED"]=[[{av:"AV10docFluxoCAFRegistrarEnvio",fld:"vDOCFLUXOCAFREGISTRARENVIO",pic:""},{av:"AV11docFluxoCAFRegistrarRetorno",fld:"vDOCFLUXOCAFREGISTRARRETORNO",pic:""},{av:"AV17docFluxoAnaliseCredito",fld:"vDOCFLUXOANALISECREDITO",pic:""}],[{av:'gx.fn.getCtrlProperty("TBLREGISTRARRETORNOCAF","Visible")',ctrl:"TBLREGISTRARRETORNOCAF",prop:"Visible"},{av:'gx.fn.getCtrlProperty("TBLANACREDITO","Visible")',ctrl:"TBLANACREDITO",prop:"Visible"},{av:"AV11docFluxoCAFRegistrarRetorno",fld:"vDOCFLUXOCAFREGISTRARRETORNO",pic:""},{av:"AV17docFluxoAnaliseCredito",fld:"vDOCFLUXOANALISECREDITO",pic:""}]];this.EvtParms["DOCFLUXOCAFREGISTRARRETORNO_NEFCONFIRMADO.CONTROLVALUECHANGED"]=[[{av:"AV11docFluxoCAFRegistrarRetorno",fld:"vDOCFLUXOCAFREGISTRARRETORNO",pic:""},{av:"AV17docFluxoAnaliseCredito",fld:"vDOCFLUXOANALISECREDITO",pic:""}],[{av:'gx.fn.getCtrlProperty("TBLANACREDITO","Visible")',ctrl:"TBLANACREDITO",prop:"Visible"},{av:'gx.fn.getCtrlProperty("DOCFLUXOANALISECREDITO_NEFVALOR_CELL","Class")',ctrl:"DOCFLUXOANALISECREDITO_NEFVALOR_CELL",prop:"Class"}]];this.EvtParms.ENTER=[[{av:"AV6DocOrigemID",fld:"vDOCORIGEMID",pic:"",hsh:!0},{av:"AV9docFluxoAnaliseDocumentacao",fld:"vDOCFLUXOANALISEDOCUMENTACAO",pic:""},{av:"AV16CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT",pic:""},{av:"AV12Messages",fld:"vMESSAGES",pic:""},{av:"AV10docFluxoCAFRegistrarEnvio",fld:"vDOCFLUXOCAFREGISTRARENVIO",pic:""},{av:"AV11docFluxoCAFRegistrarRetorno",fld:"vDOCFLUXOCAFREGISTRARRETORNO",pic:""},{av:"AV17docFluxoAnaliseCredito",fld:"vDOCFLUXOANALISECREDITO",pic:""}],[{av:"AV15NegId",fld:"vNEGID",pic:""},{av:"AV9docFluxoAnaliseDocumentacao",fld:"vDOCFLUXOANALISEDOCUMENTACAO",pic:""},{av:"AV12Messages",fld:"vMESSAGES",pic:""},{av:"AV10docFluxoCAFRegistrarEnvio",fld:"vDOCFLUXOCAFREGISTRARENVIO",pic:""},{av:"AV11docFluxoCAFRegistrarRetorno",fld:"vDOCFLUXOCAFREGISTRARRETORNO",pic:""},{av:"AV17docFluxoAnaliseCredito",fld:"vDOCFLUXOANALISECREDITO",pic:""},{av:"AV16CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT",pic:""}]];this.EnterCtrl=["BTNENTER"];this.setVCMap("AV9docFluxoAnaliseDocumentacao","vDOCFLUXOANALISEDOCUMENTACAO",0,"coreSDTNegocioPJFluxo",0,0);this.setVCMap("AV10docFluxoCAFRegistrarEnvio","vDOCFLUXOCAFREGISTRARENVIO",0,"coreSDTNegocioPJFluxo",0,0);this.setVCMap("AV11docFluxoCAFRegistrarRetorno","vDOCFLUXOCAFREGISTRARRETORNO",0,"coreSDTNegocioPJFluxo",0,0);this.setVCMap("AV17docFluxoAnaliseCredito","vDOCFLUXOANALISECREDITO",0,"coreSDTNegocioPJFluxo",0,0);this.setVCMap("AV9docFluxoAnaliseDocumentacao","vDOCFLUXOANALISEDOCUMENTACAO",0,"coreSDTNegocioPJFluxo",0,0);this.setVCMap("AV10docFluxoCAFRegistrarEnvio","vDOCFLUXOCAFREGISTRARENVIO",0,"coreSDTNegocioPJFluxo",0,0);this.setVCMap("AV11docFluxoCAFRegistrarRetorno","vDOCFLUXOCAFREGISTRARRETORNO",0,"coreSDTNegocioPJFluxo",0,0);this.setVCMap("AV17docFluxoAnaliseCredito","vDOCFLUXOANALISECREDITO",0,"coreSDTNegocioPJFluxo",0,0);this.setVCMap("AV16CheckRequiredFieldsResult","vCHECKREQUIREDFIELDSRESULT",0,"boolean",4,0);this.setVCMap("AV12Messages","vMESSAGES",0,"CollGeneXusCommonMessages.Message",0,0);this.addBCProperty("Docfluxoanalisedocumentacao",["NefConfirmado"],this.GXValidFnc[29],"AV9docFluxoAnaliseDocumentacao");this.addBCProperty("Docfluxoanalisedocumentacao",["NefTexto"],this.GXValidFnc[34],"AV9docFluxoAnaliseDocumentacao");this.addBCProperty("Docfluxocafregistrarenvio",["NefConfirmado"],this.GXValidFnc[46],"AV10docFluxoCAFRegistrarEnvio");this.addBCProperty("Docfluxocafregistrarretorno",["NefConfirmado"],this.GXValidFnc[59],"AV11docFluxoCAFRegistrarRetorno");this.addBCProperty("Docfluxoanalisecredito",["NefConfirmado"],this.GXValidFnc[71],"AV17docFluxoAnaliseCredito");this.addBCProperty("Docfluxoanalisecredito",["NefValor"],this.GXValidFnc[76],"AV17docFluxoAnaliseCredito");this.Initialize();this.setComponent({id:"WCNEGOCIOPJGENERAL",GXClass:null,Prefix:"W0014",lvl:1})});gx.wi(function(){gx.createParentObj(this.core.documentacaoaprovadafluxo)})