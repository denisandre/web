gx.evt.autoSkip=!1;gx.define("core.municipiogeneral",!0,function(n){this.ServerClass="core.municipiogeneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="core.municipiogeneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){};this.Valid_Municipioid=function(){return this.validCliEvt("Valid_Municipioid",0,function(){try{var n=gx.util.balloon.getNew("MUNICIPIOID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e134n2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e144n2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49];this.GXLastCtrlId=49;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLE",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TRANSACTIONDETAIL_TABLEATTRIBUTES",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,lvl:0,type:"int",len:9,dec:0,sign:!1,pic:"ZZZ,ZZZ,ZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Municipioid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MUNICIPIOID",fmt:0,gxz:"Z35MunicipioID",gxold:"O35MunicipioID",gxvar:"A35MunicipioID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A35MunicipioID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z35MunicipioID=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("MUNICIPIOID",gx.O.A35MunicipioID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A35MunicipioID=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("MUNICIPIOID",".")},nac:gx.falseFn};this.declareDomainHdlr(14,function(){});t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,lvl:0,type:"svchar",len:80,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MUNICIPIONOME",fmt:0,gxz:"Z36MunicipioNome",gxold:"O36MunicipioNome",gxvar:"A36MunicipioNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A36MunicipioNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z36MunicipioNome=n)},v2c:function(){gx.fn.setControlValue("MUNICIPIONOME",gx.O.A36MunicipioNome,0)},c2v:function(){this.val()!==undefined&&(gx.O.A36MunicipioNome=this.val())},val:function(){return gx.fn.getControlValue("MUNICIPIONOME")},nac:gx.falseFn};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"",grid:0};t[24]={id:24,lvl:0,type:"svchar",len:80,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MUNICIPIOMICRONOME",fmt:0,gxz:"Z38MunicipioMicroNome",gxold:"O38MunicipioMicroNome",gxvar:"A38MunicipioMicroNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A38MunicipioMicroNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z38MunicipioMicroNome=n)},v2c:function(){gx.fn.setControlValue("MUNICIPIOMICRONOME",gx.O.A38MunicipioMicroNome,0)},c2v:function(){this.val()!==undefined&&(gx.O.A38MunicipioMicroNome=this.val())},val:function(){return gx.fn.getControlValue("MUNICIPIOMICRONOME")},nac:gx.falseFn};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,fld:"",grid:0};t[29]={id:29,lvl:0,type:"int",len:9,dec:0,sign:!1,pic:"ZZZ,ZZZ,ZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MUNICIPIOMICROMESOID",fmt:0,gxz:"Z39MunicipioMicroMesoID",gxold:"O39MunicipioMicroMesoID",gxvar:"A39MunicipioMicroMesoID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A39MunicipioMicroMesoID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z39MunicipioMicroMesoID=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("MUNICIPIOMICROMESOID",gx.O.A39MunicipioMicroMesoID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A39MunicipioMicroMesoID=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("MUNICIPIOMICROMESOID",".")},nac:gx.falseFn};this.declareDomainHdlr(29,function(){});t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,fld:"",grid:0};t[34]={id:34,lvl:0,type:"int",len:9,dec:0,sign:!1,pic:"ZZZ,ZZZ,ZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MUNICIPIOMICROMESOUFID",fmt:0,gxz:"Z41MunicipioMicroMesoUFID",gxold:"O41MunicipioMicroMesoUFID",gxvar:"A41MunicipioMicroMesoUFID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A41MunicipioMicroMesoUFID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z41MunicipioMicroMesoUFID=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("MUNICIPIOMICROMESOUFID",gx.O.A41MunicipioMicroMesoUFID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A41MunicipioMicroMesoUFID=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("MUNICIPIOMICROMESOUFID",".")},nac:gx.falseFn};this.declareDomainHdlr(34,function(){});t[35]={id:35,fld:"",grid:0};t[36]={id:36,fld:"",grid:0};t[37]={id:37,fld:"",grid:0};t[38]={id:38,fld:"",grid:0};t[39]={id:39,lvl:0,type:"int",len:9,dec:0,sign:!1,pic:"ZZZ,ZZZ,ZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MUNICIPIOMICROMESOUFREGID",fmt:0,gxz:"Z45MunicipioMicroMesoUFRegID",gxold:"O45MunicipioMicroMesoUFRegID",gxvar:"A45MunicipioMicroMesoUFRegID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A45MunicipioMicroMesoUFRegID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z45MunicipioMicroMesoUFRegID=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("MUNICIPIOMICROMESOUFREGID",gx.O.A45MunicipioMicroMesoUFRegID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A45MunicipioMicroMesoUFRegID=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("MUNICIPIOMICROMESOUFREGID",".")},nac:gx.falseFn};this.declareDomainHdlr(39,function(){});t[40]={id:40,fld:"",grid:0};t[41]={id:41,fld:"",grid:0};t[42]={id:42,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};t[43]={id:43,lvl:0,type:"svchar",len:80,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MUNICIPIOMICROMESONOME",fmt:0,gxz:"Z40MunicipioMicroMesoNome",gxold:"O40MunicipioMicroMesoNome",gxvar:"A40MunicipioMicroMesoNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A40MunicipioMicroMesoNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z40MunicipioMicroMesoNome=n)},v2c:function(){gx.fn.setControlValue("MUNICIPIOMICROMESONOME",gx.O.A40MunicipioMicroMesoNome,0)},c2v:function(){this.val()!==undefined&&(gx.O.A40MunicipioMicroMesoNome=this.val())},val:function(){return gx.fn.getControlValue("MUNICIPIOMICROMESONOME")},nac:gx.falseFn};t[44]={id:44,lvl:0,type:"svchar",len:2,dec:0,sign:!1,pic:"@!",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MUNICIPIOMICROMESOUFSIGLA",fmt:0,gxz:"Z42MunicipioMicroMesoUFSigla",gxold:"O42MunicipioMicroMesoUFSigla",gxvar:"A42MunicipioMicroMesoUFSigla",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A42MunicipioMicroMesoUFSigla=n)},v2z:function(n){n!==undefined&&(gx.O.Z42MunicipioMicroMesoUFSigla=n)},v2c:function(){gx.fn.setControlValue("MUNICIPIOMICROMESOUFSIGLA",gx.O.A42MunicipioMicroMesoUFSigla,0)},c2v:function(){this.val()!==undefined&&(gx.O.A42MunicipioMicroMesoUFSigla=this.val())},val:function(){return gx.fn.getControlValue("MUNICIPIOMICROMESOUFSIGLA")},nac:gx.falseFn};t[45]={id:45,lvl:0,type:"svchar",len:50,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MUNICIPIOMICROMESOUFNOME",fmt:0,gxz:"Z43MunicipioMicroMesoUFNome",gxold:"O43MunicipioMicroMesoUFNome",gxvar:"A43MunicipioMicroMesoUFNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A43MunicipioMicroMesoUFNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z43MunicipioMicroMesoUFNome=n)},v2c:function(){gx.fn.setControlValue("MUNICIPIOMICROMESOUFNOME",gx.O.A43MunicipioMicroMesoUFNome,0)},c2v:function(){this.val()!==undefined&&(gx.O.A43MunicipioMicroMesoUFNome=this.val())},val:function(){return gx.fn.getControlValue("MUNICIPIOMICROMESOUFNOME")},nac:gx.falseFn};t[46]={id:46,lvl:0,type:"svchar",len:70,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MUNICIPIOMICROMESOUFSIGLANOME",fmt:0,gxz:"Z44MunicipioMicroMesoUFSiglaNome",gxold:"O44MunicipioMicroMesoUFSiglaNome",gxvar:"A44MunicipioMicroMesoUFSiglaNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A44MunicipioMicroMesoUFSiglaNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z44MunicipioMicroMesoUFSiglaNome=n)},v2c:function(){gx.fn.setControlValue("MUNICIPIOMICROMESOUFSIGLANOME",gx.O.A44MunicipioMicroMesoUFSiglaNome,0)},c2v:function(){this.val()!==undefined&&(gx.O.A44MunicipioMicroMesoUFSiglaNome=this.val())},val:function(){return gx.fn.getControlValue("MUNICIPIOMICROMESOUFSIGLANOME")},nac:gx.falseFn};t[47]={id:47,lvl:0,type:"svchar",len:10,dec:0,sign:!1,pic:"@!",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MUNICIPIOMICROMESOUFREGSIGLA",fmt:0,gxz:"Z46MunicipioMicroMesoUFRegSigla",gxold:"O46MunicipioMicroMesoUFRegSigla",gxvar:"A46MunicipioMicroMesoUFRegSigla",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A46MunicipioMicroMesoUFRegSigla=n)},v2z:function(n){n!==undefined&&(gx.O.Z46MunicipioMicroMesoUFRegSigla=n)},v2c:function(){gx.fn.setControlValue("MUNICIPIOMICROMESOUFREGSIGLA",gx.O.A46MunicipioMicroMesoUFRegSigla,0)},c2v:function(){this.val()!==undefined&&(gx.O.A46MunicipioMicroMesoUFRegSigla=this.val())},val:function(){return gx.fn.getControlValue("MUNICIPIOMICROMESOUFREGSIGLA")},nac:gx.falseFn};t[48]={id:48,lvl:0,type:"svchar",len:50,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MUNICIPIOMICROMESOUFREGNOME",fmt:0,gxz:"Z47MunicipioMicroMesoUFRegNome",gxold:"O47MunicipioMicroMesoUFRegNome",gxvar:"A47MunicipioMicroMesoUFRegNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A47MunicipioMicroMesoUFRegNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z47MunicipioMicroMesoUFRegNome=n)},v2c:function(){gx.fn.setControlValue("MUNICIPIOMICROMESOUFREGNOME",gx.O.A47MunicipioMicroMesoUFRegNome,0)},c2v:function(){this.val()!==undefined&&(gx.O.A47MunicipioMicroMesoUFRegNome=this.val())},val:function(){return gx.fn.getControlValue("MUNICIPIOMICROMESOUFREGNOME")},nac:gx.falseFn};t[49]={id:49,lvl:0,type:"svchar",len:70,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MUNICIPIOMICROMESOUFREGSIGLANO",fmt:0,gxz:"Z48MunicipioMicroMesoUFRegSiglaNo",gxold:"O48MunicipioMicroMesoUFRegSiglaNo",gxvar:"A48MunicipioMicroMesoUFRegSiglaNo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A48MunicipioMicroMesoUFRegSiglaNo=n)},v2z:function(n){n!==undefined&&(gx.O.Z48MunicipioMicroMesoUFRegSiglaNo=n)},v2c:function(){gx.fn.setControlValue("MUNICIPIOMICROMESOUFREGSIGLANO",gx.O.A48MunicipioMicroMesoUFRegSiglaNo,0)},c2v:function(){this.val()!==undefined&&(gx.O.A48MunicipioMicroMesoUFRegSiglaNo=this.val())},val:function(){return gx.fn.getControlValue("MUNICIPIOMICROMESOUFREGSIGLANO")},nac:gx.falseFn};this.A35MunicipioID=0;this.Z35MunicipioID=0;this.O35MunicipioID=0;this.A36MunicipioNome="";this.Z36MunicipioNome="";this.O36MunicipioNome="";this.A38MunicipioMicroNome="";this.Z38MunicipioMicroNome="";this.O38MunicipioMicroNome="";this.A39MunicipioMicroMesoID=0;this.Z39MunicipioMicroMesoID=0;this.O39MunicipioMicroMesoID=0;this.A41MunicipioMicroMesoUFID=0;this.Z41MunicipioMicroMesoUFID=0;this.O41MunicipioMicroMesoUFID=0;this.A45MunicipioMicroMesoUFRegID=0;this.Z45MunicipioMicroMesoUFRegID=0;this.O45MunicipioMicroMesoUFRegID=0;this.A40MunicipioMicroMesoNome="";this.Z40MunicipioMicroMesoNome="";this.O40MunicipioMicroMesoNome="";this.A42MunicipioMicroMesoUFSigla="";this.Z42MunicipioMicroMesoUFSigla="";this.O42MunicipioMicroMesoUFSigla="";this.A43MunicipioMicroMesoUFNome="";this.Z43MunicipioMicroMesoUFNome="";this.O43MunicipioMicroMesoUFNome="";this.A44MunicipioMicroMesoUFSiglaNome="";this.Z44MunicipioMicroMesoUFSiglaNome="";this.O44MunicipioMicroMesoUFSiglaNome="";this.A46MunicipioMicroMesoUFRegSigla="";this.Z46MunicipioMicroMesoUFRegSigla="";this.O46MunicipioMicroMesoUFRegSigla="";this.A47MunicipioMicroMesoUFRegNome="";this.Z47MunicipioMicroMesoUFRegNome="";this.O47MunicipioMicroMesoUFRegNome="";this.A48MunicipioMicroMesoUFRegSiglaNo="";this.Z48MunicipioMicroMesoUFRegSiglaNo="";this.O48MunicipioMicroMesoUFRegSiglaNo="";this.A35MunicipioID=0;this.A36MunicipioNome="";this.A38MunicipioMicroNome="";this.A39MunicipioMicroMesoID=0;this.A41MunicipioMicroMesoUFID=0;this.A45MunicipioMicroMesoUFRegID=0;this.A40MunicipioMicroMesoNome="";this.A42MunicipioMicroMesoUFSigla="";this.A43MunicipioMicroMesoUFNome="";this.A44MunicipioMicroMesoUFSiglaNome="";this.A46MunicipioMicroMesoUFRegSigla="";this.A47MunicipioMicroMesoUFRegNome="";this.A48MunicipioMicroMesoUFRegSiglaNo="";this.A37MunicipioMicroID=0;this.Events={e134n2_client:["ENTER",!0],e144n2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"A35MunicipioID",fld:"MUNICIPIOID",pic:"ZZZ,ZZZ,ZZ9"}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALID_MUNICIPIOID=[[],[]];this.Initialize()})