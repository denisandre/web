gx.evt.autoSkip=!1;gx.define("core.microrregiaogeneral",!0,function(n){this.ServerClass="core.microrregiaogeneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="core.microrregiaogeneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){};this.Valid_Microrregiaoid=function(){return this.validCliEvt("Valid_Microrregiaoid",0,function(){try{var n=gx.util.balloon.getNew("MICRORREGIAOID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e134j2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e144j2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35];this.GXLastCtrlId=35;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLE",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TRANSACTIONDETAIL_TABLEATTRIBUTES",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,lvl:0,type:"int",len:9,dec:0,sign:!1,pic:"ZZZ,ZZZ,ZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Microrregiaoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MICRORREGIAOID",fmt:0,gxz:"Z23MicrorregiaoID",gxold:"O23MicrorregiaoID",gxvar:"A23MicrorregiaoID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A23MicrorregiaoID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z23MicrorregiaoID=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("MICRORREGIAOID",gx.O.A23MicrorregiaoID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A23MicrorregiaoID=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("MICRORREGIAOID",".")},nac:gx.falseFn};this.declareDomainHdlr(14,function(){});t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,lvl:0,type:"svchar",len:80,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MICRORREGIAONOME",fmt:0,gxz:"Z24MicrorregiaoNome",gxold:"O24MicrorregiaoNome",gxvar:"A24MicrorregiaoNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A24MicrorregiaoNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z24MicrorregiaoNome=n)},v2c:function(){gx.fn.setControlValue("MICRORREGIAONOME",gx.O.A24MicrorregiaoNome,0)},c2v:function(){this.val()!==undefined&&(gx.O.A24MicrorregiaoNome=this.val())},val:function(){return gx.fn.getControlValue("MICRORREGIAONOME")},nac:gx.falseFn};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"",grid:0};t[24]={id:24,lvl:0,type:"svchar",len:80,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MICRORREGIAOMESONOME",fmt:0,gxz:"Z26MicrorregiaoMesoNome",gxold:"O26MicrorregiaoMesoNome",gxvar:"A26MicrorregiaoMesoNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A26MicrorregiaoMesoNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z26MicrorregiaoMesoNome=n)},v2c:function(){gx.fn.setControlValue("MICRORREGIAOMESONOME",gx.O.A26MicrorregiaoMesoNome,0)},c2v:function(){this.val()!==undefined&&(gx.O.A26MicrorregiaoMesoNome=this.val())},val:function(){return gx.fn.getControlValue("MICRORREGIAOMESONOME")},nac:gx.falseFn};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};t[28]={id:28,lvl:0,type:"int",len:9,dec:0,sign:!1,pic:"ZZZ,ZZZ,ZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MICRORREGIAOMESOUFID",fmt:0,gxz:"Z27MicrorregiaoMesoUFID",gxold:"O27MicrorregiaoMesoUFID",gxvar:"A27MicrorregiaoMesoUFID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A27MicrorregiaoMesoUFID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z27MicrorregiaoMesoUFID=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("MICRORREGIAOMESOUFID",gx.O.A27MicrorregiaoMesoUFID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A27MicrorregiaoMesoUFID=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("MICRORREGIAOMESOUFID",".")},nac:gx.falseFn};this.declareDomainHdlr(28,function(){});t[29]={id:29,lvl:0,type:"svchar",len:2,dec:0,sign:!1,pic:"@!",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MICRORREGIAOMESOUFSIGLA",fmt:0,gxz:"Z28MicrorregiaoMesoUFSigla",gxold:"O28MicrorregiaoMesoUFSigla",gxvar:"A28MicrorregiaoMesoUFSigla",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A28MicrorregiaoMesoUFSigla=n)},v2z:function(n){n!==undefined&&(gx.O.Z28MicrorregiaoMesoUFSigla=n)},v2c:function(){gx.fn.setControlValue("MICRORREGIAOMESOUFSIGLA",gx.O.A28MicrorregiaoMesoUFSigla,0)},c2v:function(){this.val()!==undefined&&(gx.O.A28MicrorregiaoMesoUFSigla=this.val())},val:function(){return gx.fn.getControlValue("MICRORREGIAOMESOUFSIGLA")},nac:gx.falseFn};t[30]={id:30,lvl:0,type:"svchar",len:50,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MICRORREGIAOMESOUFNOME",fmt:0,gxz:"Z29MicrorregiaoMesoUFNome",gxold:"O29MicrorregiaoMesoUFNome",gxvar:"A29MicrorregiaoMesoUFNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A29MicrorregiaoMesoUFNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z29MicrorregiaoMesoUFNome=n)},v2c:function(){gx.fn.setControlValue("MICRORREGIAOMESOUFNOME",gx.O.A29MicrorregiaoMesoUFNome,0)},c2v:function(){this.val()!==undefined&&(gx.O.A29MicrorregiaoMesoUFNome=this.val())},val:function(){return gx.fn.getControlValue("MICRORREGIAOMESOUFNOME")},nac:gx.falseFn};t[31]={id:31,lvl:0,type:"svchar",len:70,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MICRORREGIAOMESOUFSIGLANOME",fmt:0,gxz:"Z30MicrorregiaoMesoUFSiglaNome",gxold:"O30MicrorregiaoMesoUFSiglaNome",gxvar:"A30MicrorregiaoMesoUFSiglaNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A30MicrorregiaoMesoUFSiglaNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z30MicrorregiaoMesoUFSiglaNome=n)},v2c:function(){gx.fn.setControlValue("MICRORREGIAOMESOUFSIGLANOME",gx.O.A30MicrorregiaoMesoUFSiglaNome,0)},c2v:function(){this.val()!==undefined&&(gx.O.A30MicrorregiaoMesoUFSiglaNome=this.val())},val:function(){return gx.fn.getControlValue("MICRORREGIAOMESOUFSIGLANOME")},nac:gx.falseFn};t[32]={id:32,lvl:0,type:"int",len:9,dec:0,sign:!1,pic:"ZZZ,ZZZ,ZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MICRORREGIAOMESOUFREGID",fmt:0,gxz:"Z31MicrorregiaoMesoUFRegID",gxold:"O31MicrorregiaoMesoUFRegID",gxvar:"A31MicrorregiaoMesoUFRegID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A31MicrorregiaoMesoUFRegID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z31MicrorregiaoMesoUFRegID=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("MICRORREGIAOMESOUFREGID",gx.O.A31MicrorregiaoMesoUFRegID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A31MicrorregiaoMesoUFRegID=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("MICRORREGIAOMESOUFREGID",".")},nac:gx.falseFn};this.declareDomainHdlr(32,function(){});t[33]={id:33,lvl:0,type:"svchar",len:10,dec:0,sign:!1,pic:"@!",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MICRORREGIAOMESOUFREGSIGLA",fmt:0,gxz:"Z32MicrorregiaoMesoUFRegSigla",gxold:"O32MicrorregiaoMesoUFRegSigla",gxvar:"A32MicrorregiaoMesoUFRegSigla",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A32MicrorregiaoMesoUFRegSigla=n)},v2z:function(n){n!==undefined&&(gx.O.Z32MicrorregiaoMesoUFRegSigla=n)},v2c:function(){gx.fn.setControlValue("MICRORREGIAOMESOUFREGSIGLA",gx.O.A32MicrorregiaoMesoUFRegSigla,0)},c2v:function(){this.val()!==undefined&&(gx.O.A32MicrorregiaoMesoUFRegSigla=this.val())},val:function(){return gx.fn.getControlValue("MICRORREGIAOMESOUFREGSIGLA")},nac:gx.falseFn};t[34]={id:34,lvl:0,type:"svchar",len:50,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MICRORREGIAOMESOUFREGNOME",fmt:0,gxz:"Z33MicrorregiaoMesoUFRegNome",gxold:"O33MicrorregiaoMesoUFRegNome",gxvar:"A33MicrorregiaoMesoUFRegNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A33MicrorregiaoMesoUFRegNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z33MicrorregiaoMesoUFRegNome=n)},v2c:function(){gx.fn.setControlValue("MICRORREGIAOMESOUFREGNOME",gx.O.A33MicrorregiaoMesoUFRegNome,0)},c2v:function(){this.val()!==undefined&&(gx.O.A33MicrorregiaoMesoUFRegNome=this.val())},val:function(){return gx.fn.getControlValue("MICRORREGIAOMESOUFREGNOME")},nac:gx.falseFn};t[35]={id:35,lvl:0,type:"svchar",len:70,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MICRORREGIAOMESOUFREGSIGLANOME",fmt:0,gxz:"Z34MicrorregiaoMesoUFRegSiglaNome",gxold:"O34MicrorregiaoMesoUFRegSiglaNome",gxvar:"A34MicrorregiaoMesoUFRegSiglaNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A34MicrorregiaoMesoUFRegSiglaNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z34MicrorregiaoMesoUFRegSiglaNome=n)},v2c:function(){gx.fn.setControlValue("MICRORREGIAOMESOUFREGSIGLANOME",gx.O.A34MicrorregiaoMesoUFRegSiglaNome,0)},c2v:function(){this.val()!==undefined&&(gx.O.A34MicrorregiaoMesoUFRegSiglaNome=this.val())},val:function(){return gx.fn.getControlValue("MICRORREGIAOMESOUFREGSIGLANOME")},nac:gx.falseFn};this.A23MicrorregiaoID=0;this.Z23MicrorregiaoID=0;this.O23MicrorregiaoID=0;this.A24MicrorregiaoNome="";this.Z24MicrorregiaoNome="";this.O24MicrorregiaoNome="";this.A26MicrorregiaoMesoNome="";this.Z26MicrorregiaoMesoNome="";this.O26MicrorregiaoMesoNome="";this.A27MicrorregiaoMesoUFID=0;this.Z27MicrorregiaoMesoUFID=0;this.O27MicrorregiaoMesoUFID=0;this.A28MicrorregiaoMesoUFSigla="";this.Z28MicrorregiaoMesoUFSigla="";this.O28MicrorregiaoMesoUFSigla="";this.A29MicrorregiaoMesoUFNome="";this.Z29MicrorregiaoMesoUFNome="";this.O29MicrorregiaoMesoUFNome="";this.A30MicrorregiaoMesoUFSiglaNome="";this.Z30MicrorregiaoMesoUFSiglaNome="";this.O30MicrorregiaoMesoUFSiglaNome="";this.A31MicrorregiaoMesoUFRegID=0;this.Z31MicrorregiaoMesoUFRegID=0;this.O31MicrorregiaoMesoUFRegID=0;this.A32MicrorregiaoMesoUFRegSigla="";this.Z32MicrorregiaoMesoUFRegSigla="";this.O32MicrorregiaoMesoUFRegSigla="";this.A33MicrorregiaoMesoUFRegNome="";this.Z33MicrorregiaoMesoUFRegNome="";this.O33MicrorregiaoMesoUFRegNome="";this.A34MicrorregiaoMesoUFRegSiglaNome="";this.Z34MicrorregiaoMesoUFRegSiglaNome="";this.O34MicrorregiaoMesoUFRegSiglaNome="";this.A23MicrorregiaoID=0;this.A24MicrorregiaoNome="";this.A26MicrorregiaoMesoNome="";this.A27MicrorregiaoMesoUFID=0;this.A28MicrorregiaoMesoUFSigla="";this.A29MicrorregiaoMesoUFNome="";this.A30MicrorregiaoMesoUFSiglaNome="";this.A31MicrorregiaoMesoUFRegID=0;this.A32MicrorregiaoMesoUFRegSigla="";this.A33MicrorregiaoMesoUFRegNome="";this.A34MicrorregiaoMesoUFRegSiglaNome="";this.A25MicrorregiaoMesoID=0;this.Events={e134j2_client:["ENTER",!0],e144j2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"A23MicrorregiaoID",fld:"MICRORREGIAOID",pic:"ZZZ,ZZZ,ZZ9"}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALID_MICRORREGIAOID=[[],[]];this.Initialize()})