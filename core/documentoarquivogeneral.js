gx.evt.autoSkip=!1;gx.define("core.documentoarquivogeneral",!0,function(n){this.ServerClass="core.documentoarquivogeneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="core.documentoarquivogeneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){};this.Valid_Docid=function(){return this.validCliEvt("Valid_Docid",0,function(){try{var n=gx.util.balloon.getNew("DOCID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Docarqseq=function(){return this.validCliEvt("Valid_Docarqseq",0,function(){try{var n=gx.util.balloon.getNew("DOCARQSEQ");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e135l2_client=function(){return this.executeServerEvent("'DOUPDATE'",!1,null,!1,!1)};this.e145l2_client=function(){return this.executeServerEvent("'DODELETE'",!1,null,!1,!1)};this.e155l2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e165l2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36];this.GXLastCtrlId=36;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLE",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TRANSACTIONDETAIL_TABLEATTRIBUTES",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,lvl:0,type:"svchar",len:2e3,dec:0,sign:!1,ro:1,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCARQCONTEUDONOME",fmt:0,gxz:"Z322DocArqConteudoNome",gxold:"O322DocArqConteudoNome",gxvar:"A322DocArqConteudoNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A322DocArqConteudoNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z322DocArqConteudoNome=n)},v2c:function(){gx.fn.setControlValue("DOCARQCONTEUDONOME",gx.O.A322DocArqConteudoNome,0)},c2v:function(){this.val()!==undefined&&(gx.O.A322DocArqConteudoNome=this.val())},val:function(){return gx.fn.getControlValue("DOCARQCONTEUDONOME")},nac:gx.falseFn};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,lvl:0,type:"svchar",len:20,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCARQCONTEUDOEXTENSAO",fmt:0,gxz:"Z323DocArqConteudoExtensao",gxold:"O323DocArqConteudoExtensao",gxvar:"A323DocArqConteudoExtensao",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A323DocArqConteudoExtensao=n)},v2z:function(n){n!==undefined&&(gx.O.Z323DocArqConteudoExtensao=n)},v2c:function(){gx.fn.setControlValue("DOCARQCONTEUDOEXTENSAO",gx.O.A323DocArqConteudoExtensao,0)},c2v:function(){this.val()!==undefined&&(gx.O.A323DocArqConteudoExtensao=this.val())},val:function(){return gx.fn.getControlValue("DOCARQCONTEUDOEXTENSAO")},nac:gx.falseFn};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"",grid:0};t[24]={id:24,lvl:0,type:"svchar",len:2e3,dec:0,sign:!1,ro:1,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCARQOBSERVACAO",fmt:0,gxz:"Z324DocArqObservacao",gxold:"O324DocArqObservacao",gxvar:"A324DocArqObservacao",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A324DocArqObservacao=n)},v2z:function(n){n!==undefined&&(gx.O.Z324DocArqObservacao=n)},v2c:function(){gx.fn.setControlValue("DOCARQOBSERVACAO",gx.O.A324DocArqObservacao,0)},c2v:function(){this.val()!==undefined&&(gx.O.A324DocArqObservacao=this.val())},val:function(){return gx.fn.getControlValue("DOCARQOBSERVACAO")},nac:gx.falseFn};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,fld:"",grid:0};t[29]={id:29,fld:"BTNUPDATE",grid:0,evt:"e135l2_client"};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"BTNDELETE",grid:0,evt:"e145l2_client"};t[32]={id:32,fld:"",grid:0};t[33]={id:33,fld:"",grid:0};t[34]={id:34,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};t[35]={id:35,lvl:0,type:"guid",len:9,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:this.Valid_Docid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCID",fmt:0,gxz:"Z289DocID",gxold:"O289DocID",gxvar:"A289DocID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A289DocID=n)},v2z:function(n){n!==undefined&&(gx.O.Z289DocID=n)},v2c:function(){gx.fn.setControlValue("DOCID",gx.O.A289DocID,0)},c2v:function(){this.val()!==undefined&&(gx.O.A289DocID=this.val())},val:function(){return gx.fn.getControlValue("DOCID")},nac:gx.falseFn};t[36]={id:36,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Docarqseq,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCARQSEQ",fmt:0,gxz:"Z307DocArqSeq",gxold:"O307DocArqSeq",gxvar:"A307DocArqSeq",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A307DocArqSeq=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z307DocArqSeq=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("DOCARQSEQ",gx.O.A307DocArqSeq,0)},c2v:function(){this.val()!==undefined&&(gx.O.A307DocArqSeq=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("DOCARQSEQ",".")},nac:gx.falseFn};this.A322DocArqConteudoNome="";this.Z322DocArqConteudoNome="";this.O322DocArqConteudoNome="";this.A323DocArqConteudoExtensao="";this.Z323DocArqConteudoExtensao="";this.O323DocArqConteudoExtensao="";this.A324DocArqObservacao="";this.Z324DocArqObservacao="";this.O324DocArqObservacao="";this.A289DocID="00000000-0000-0000-0000-000000000000";this.Z289DocID="00000000-0000-0000-0000-000000000000";this.O289DocID="00000000-0000-0000-0000-000000000000";this.A307DocArqSeq=0;this.Z307DocArqSeq=0;this.O307DocArqSeq=0;this.A322DocArqConteudoNome="";this.A323DocArqConteudoExtensao="";this.A324DocArqObservacao="";this.A289DocID="00000000-0000-0000-0000-000000000000";this.A307DocArqSeq=0;this.Events={e135l2_client:["'DOUPDATE'",!0],e145l2_client:["'DODELETE'",!0],e155l2_client:["ENTER",!0],e165l2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"A289DocID",fld:"DOCID",pic:""},{av:"A307DocArqSeq",fld:"DOCARQSEQ",pic:"ZZZ9"}],[]];this.EvtParms["'DOUPDATE'"]=[[{av:"A289DocID",fld:"DOCID",pic:""},{av:"A307DocArqSeq",fld:"DOCARQSEQ",pic:"ZZZ9"}],[]];this.EvtParms["'DODELETE'"]=[[{av:"A289DocID",fld:"DOCID",pic:""},{av:"A307DocArqSeq",fld:"DOCARQSEQ",pic:"ZZZ9"}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALID_DOCID=[[],[]];this.EvtParms.VALID_DOCARQSEQ=[[],[]];this.Initialize()})