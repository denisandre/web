gx.evt.autoSkip=!1;gx.define("wwpbaseobjects.discussions.wwp_discussionmessage",!1,function(){this.ServerClass="wwpbaseobjects.discussions.wwp_discussionmessage";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwpbaseobjects.discussions.wwp_discussionmessage.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.A40000WWPUserExtendedPhoto_GXI=gx.fn.getControlValue("WWPUSEREXTENDEDPHOTO_GXI")};this.Valid_Wwpdiscussionmessageid=function(){return this.validSrvEvt("Valid_Wwpdiscussionmessageid",0).then(function(n){return n}.closure(this))};this.Valid_Wwpdiscussionmessagethreadid=function(){return this.validSrvEvt("Valid_Wwpdiscussionmessagethreadid",0).then(function(n){return n}.closure(this))};this.Valid_Wwpuserextendedid=function(){return this.validSrvEvt("Valid_Wwpuserextendedid",0).then(function(n){return n}.closure(this))};this.Valid_Wwpentityid=function(){return this.validSrvEvt("Valid_Wwpentityid",0).then(function(n){return n}.closure(this))};this.e110g17_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e120g17_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88];this.GXLastCtrlId=88;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e130g17_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e140g17_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e150g17_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e160g17_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e170g17_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpdiscussionmessageid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPDISCUSSIONMESSAGEID",fmt:0,gxz:"Z137WWPDiscussionMessageId",gxold:"O137WWPDiscussionMessageId",gxvar:"A137WWPDiscussionMessageId",ucs:[],op:[44,69,54,79,49,39],ip:[44,69,54,79,49,39,34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A137WWPDiscussionMessageId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z137WWPDiscussionMessageId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("WWPDISCUSSIONMESSAGEID",gx.O.A137WWPDiscussionMessageId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A137WWPDiscussionMessageId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("WWPDISCUSSIONMESSAGEID",".")},nac:gx.falseFn};this.declareDomainHdlr(34,function(){});n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"dtime",len:8,dec:5,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPDISCUSSIONMESSAGEDATE",fmt:0,gxz:"Z140WWPDiscussionMessageDate",gxold:"O140WWPDiscussionMessageDate",gxvar:"A140WWPDiscussionMessageDate",dp:{f:0,st:!0,wn:!1,mf:!1,pic:"99/99/99 99:99",dec:5},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A140WWPDiscussionMessageDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z140WWPDiscussionMessageDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("WWPDISCUSSIONMESSAGEDATE",gx.O.A140WWPDiscussionMessageDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.A140WWPDiscussionMessageDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getDateTimeValue("WWPDISCUSSIONMESSAGEDATE")},nac:gx.falseFn};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpdiscussionmessagethreadid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPDISCUSSIONMESSAGETHREADID",fmt:0,gxz:"Z136WWPDiscussionMessageThreadId",gxold:"O136WWPDiscussionMessageThreadId",gxvar:"A136WWPDiscussionMessageThreadId",ucs:[],op:[],ip:[44],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A136WWPDiscussionMessageThreadId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z136WWPDiscussionMessageThreadId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("WWPDISCUSSIONMESSAGETHREADID",gx.O.A136WWPDiscussionMessageThreadId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A136WWPDiscussionMessageThreadId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("WWPDISCUSSIONMESSAGETHREADID",".")},nac:gx.falseFn};this.declareDomainHdlr(44,function(){});n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"svchar",len:400,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPDISCUSSIONMESSAGEMESSAGE",fmt:0,gxz:"Z141WWPDiscussionMessageMessage",gxold:"O141WWPDiscussionMessageMessage",gxvar:"A141WWPDiscussionMessageMessage",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A141WWPDiscussionMessageMessage=n)},v2z:function(n){n!==undefined&&(gx.O.Z141WWPDiscussionMessageMessage=n)},v2c:function(){gx.fn.setControlValue("WWPDISCUSSIONMESSAGEMESSAGE",gx.O.A141WWPDiscussionMessageMessage,0)},c2v:function(){this.val()!==undefined&&(gx.O.A141WWPDiscussionMessageMessage=this.val())},val:function(){return gx.fn.getControlValue("WWPDISCUSSIONMESSAGEMESSAGE")},nac:gx.falseFn};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"char",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpuserextendedid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDID",fmt:0,gxz:"Z49WWPUserExtendedId",gxold:"O49WWPUserExtendedId",gxvar:"A49WWPUserExtendedId",ucs:[],op:[64,59],ip:[64,59,54],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A49WWPUserExtendedId=n)},v2z:function(n){n!==undefined&&(gx.O.Z49WWPUserExtendedId=n)},v2c:function(){gx.fn.setControlValue("WWPUSEREXTENDEDID",gx.O.A49WWPUserExtendedId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A49WWPUserExtendedId=this.val())},val:function(){return gx.fn.getControlValue("WWPUSEREXTENDEDID")},nac:gx.falseFn};this.declareDomainHdlr(54,function(){});n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"bits",len:1024,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDPHOTO",fmt:0,gxz:"Z52WWPUserExtendedPhoto",gxold:"O52WWPUserExtendedPhoto",gxvar:"A52WWPUserExtendedPhoto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A52WWPUserExtendedPhoto=n)},v2z:function(n){n!==undefined&&(gx.O.Z52WWPUserExtendedPhoto=n)},v2c:function(){gx.fn.setMultimediaValue("WWPUSEREXTENDEDPHOTO",gx.O.A52WWPUserExtendedPhoto,gx.O.A40000WWPUserExtendedPhoto_GXI)},c2v:function(){gx.O.A40000WWPUserExtendedPhoto_GXI=this.val_GXI();this.val()!==undefined&&(gx.O.A52WWPUserExtendedPhoto=this.val())},val:function(){return gx.fn.getBlobValue("WWPUSEREXTENDEDPHOTO")},val_GXI:function(){return gx.fn.getControlValue("WWPUSEREXTENDEDPHOTO_GXI")},gxvar_GXI:"A40000WWPUserExtendedPhoto_GXI",nac:gx.falseFn};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDFULLNAME",fmt:0,gxz:"Z50WWPUserExtendedFullName",gxold:"O50WWPUserExtendedFullName",gxvar:"A50WWPUserExtendedFullName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A50WWPUserExtendedFullName=n)},v2z:function(n){n!==undefined&&(gx.O.Z50WWPUserExtendedFullName=n)},v2c:function(){gx.fn.setControlValue("WWPUSEREXTENDEDFULLNAME",gx.O.A50WWPUserExtendedFullName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A50WWPUserExtendedFullName=this.val())},val:function(){return gx.fn.getControlValue("WWPUSEREXTENDEDFULLNAME")},nac:gx.falseFn};this.declareDomainHdlr(64,function(){});n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,lvl:0,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpentityid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPENTITYID",fmt:0,gxz:"Z62WWPEntityId",gxold:"O62WWPEntityId",gxvar:"A62WWPEntityId",ucs:[],op:[74],ip:[74,69],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A62WWPEntityId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z62WWPEntityId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("WWPENTITYID",gx.O.A62WWPEntityId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A62WWPEntityId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("WWPENTITYID",".")},nac:gx.falseFn};this.declareDomainHdlr(69,function(){});n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"",grid:0};n[74]={id:74,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPENTITYNAME",fmt:0,gxz:"Z63WWPEntityName",gxold:"O63WWPEntityName",gxvar:"A63WWPEntityName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A63WWPEntityName=n)},v2z:function(n){n!==undefined&&(gx.O.Z63WWPEntityName=n)},v2c:function(){gx.fn.setControlValue("WWPENTITYNAME",gx.O.A63WWPEntityName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A63WWPEntityName=this.val())},val:function(){return gx.fn.getControlValue("WWPENTITYNAME")},nac:gx.falseFn};this.declareDomainHdlr(74,function(){});n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPDISCUSSIONMESSAGEENTITYRECO",fmt:0,gxz:"Z142WWPDiscussionMessageEntityReco",gxold:"O142WWPDiscussionMessageEntityReco",gxvar:"A142WWPDiscussionMessageEntityReco",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A142WWPDiscussionMessageEntityReco=n)},v2z:function(n){n!==undefined&&(gx.O.Z142WWPDiscussionMessageEntityReco=n)},v2c:function(){gx.fn.setControlValue("WWPDISCUSSIONMESSAGEENTITYRECO",gx.O.A142WWPDiscussionMessageEntityReco,0)},c2v:function(){this.val()!==undefined&&(gx.O.A142WWPDiscussionMessageEntityReco=this.val())},val:function(){return gx.fn.getControlValue("WWPDISCUSSIONMESSAGEENTITYRECO")},nac:gx.falseFn};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[84]={id:84,fld:"BTN_ENTER",grid:0,evt:"e110g17_client",std:"ENTER"};n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"BTN_CANCEL",grid:0,evt:"e120g17_client"};n[87]={id:87,fld:"",grid:0};n[88]={id:88,fld:"BTN_DELETE",grid:0,evt:"e180g17_client",std:"DELETE"};this.A137WWPDiscussionMessageId=0;this.Z137WWPDiscussionMessageId=0;this.O137WWPDiscussionMessageId=0;this.A140WWPDiscussionMessageDate=gx.date.nullDate();this.Z140WWPDiscussionMessageDate=gx.date.nullDate();this.O140WWPDiscussionMessageDate=gx.date.nullDate();this.A136WWPDiscussionMessageThreadId=0;this.Z136WWPDiscussionMessageThreadId=0;this.O136WWPDiscussionMessageThreadId=0;this.A141WWPDiscussionMessageMessage="";this.Z141WWPDiscussionMessageMessage="";this.O141WWPDiscussionMessageMessage="";this.A49WWPUserExtendedId="";this.Z49WWPUserExtendedId="";this.O49WWPUserExtendedId="";this.A40000WWPUserExtendedPhoto_GXI="";this.A52WWPUserExtendedPhoto="";this.Z52WWPUserExtendedPhoto="";this.O52WWPUserExtendedPhoto="";this.A50WWPUserExtendedFullName="";this.Z50WWPUserExtendedFullName="";this.O50WWPUserExtendedFullName="";this.A62WWPEntityId=0;this.Z62WWPEntityId=0;this.O62WWPEntityId=0;this.A63WWPEntityName="";this.Z63WWPEntityName="";this.O63WWPEntityName="";this.A142WWPDiscussionMessageEntityReco="";this.Z142WWPDiscussionMessageEntityReco="";this.O142WWPDiscussionMessageEntityReco="";this.A40000WWPUserExtendedPhoto_GXI="";this.A137WWPDiscussionMessageId=0;this.A140WWPDiscussionMessageDate=gx.date.nullDate();this.A49WWPUserExtendedId="";this.A136WWPDiscussionMessageThreadId=0;this.A141WWPDiscussionMessageMessage="";this.A52WWPUserExtendedPhoto="";this.A50WWPUserExtendedFullName="";this.A62WWPEntityId=0;this.A63WWPEntityName="";this.A142WWPDiscussionMessageEntityReco="";this.Events={e110g17_client:["ENTER",!0],e120g17_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_WWPDISCUSSIONMESSAGEID=[[{av:"A137WWPDiscussionMessageId",fld:"WWPDISCUSSIONMESSAGEID",pic:"ZZZZZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"A140WWPDiscussionMessageDate",fld:"WWPDISCUSSIONMESSAGEDATE",pic:"99/99/99 99:99"},{av:"A49WWPUserExtendedId",fld:"WWPUSEREXTENDEDID",pic:""}],[{av:"A140WWPDiscussionMessageDate",fld:"WWPDISCUSSIONMESSAGEDATE",pic:"99/99/99 99:99"},{av:"A49WWPUserExtendedId",fld:"WWPUSEREXTENDEDID",pic:""},{av:"A136WWPDiscussionMessageThreadId",fld:"WWPDISCUSSIONMESSAGETHREADID",pic:"ZZZZZZZZZ9"},{av:"A141WWPDiscussionMessageMessage",fld:"WWPDISCUSSIONMESSAGEMESSAGE",pic:""},{av:"A62WWPEntityId",fld:"WWPENTITYID",pic:"ZZZZZZZZZ9"},{av:"A142WWPDiscussionMessageEntityReco",fld:"WWPDISCUSSIONMESSAGEENTITYRECO",pic:""},{av:"A52WWPUserExtendedPhoto",fld:"WWPUSEREXTENDEDPHOTO",pic:""},{av:"A40000WWPUserExtendedPhoto_GXI",fld:"WWPUSEREXTENDEDPHOTO_GXI",pic:""},{av:"A50WWPUserExtendedFullName",fld:"WWPUSEREXTENDEDFULLNAME",pic:""},{av:"A63WWPEntityName",fld:"WWPENTITYNAME",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z137WWPDiscussionMessageId"},{av:"Z140WWPDiscussionMessageDate"},{av:"Z49WWPUserExtendedId"},{av:"Z136WWPDiscussionMessageThreadId"},{av:"Z141WWPDiscussionMessageMessage"},{av:"Z62WWPEntityId"},{av:"Z142WWPDiscussionMessageEntityReco"},{av:"Z52WWPUserExtendedPhoto"},{av:"Z40000WWPUserExtendedPhoto_GXI"},{av:"Z50WWPUserExtendedFullName"},{av:"Z63WWPEntityName"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"}]];this.EvtParms.VALID_WWPDISCUSSIONMESSAGETHREADID=[[{av:"A136WWPDiscussionMessageThreadId",fld:"WWPDISCUSSIONMESSAGETHREADID",pic:"ZZZZZZZZZ9"}],[]];this.EvtParms.VALID_WWPUSEREXTENDEDID=[[{av:"A49WWPUserExtendedId",fld:"WWPUSEREXTENDEDID",pic:""},{av:"A52WWPUserExtendedPhoto",fld:"WWPUSEREXTENDEDPHOTO",pic:""},{av:"A40000WWPUserExtendedPhoto_GXI",fld:"WWPUSEREXTENDEDPHOTO_GXI",pic:""},{av:"A50WWPUserExtendedFullName",fld:"WWPUSEREXTENDEDFULLNAME",pic:""}],[{av:"A52WWPUserExtendedPhoto",fld:"WWPUSEREXTENDEDPHOTO",pic:""},{av:"A40000WWPUserExtendedPhoto_GXI",fld:"WWPUSEREXTENDEDPHOTO_GXI",pic:""},{av:"A50WWPUserExtendedFullName",fld:"WWPUSEREXTENDEDFULLNAME",pic:""}]];this.EvtParms.VALID_WWPENTITYID=[[{av:"A62WWPEntityId",fld:"WWPENTITYID",pic:"ZZZZZZZZZ9"},{av:"A63WWPEntityName",fld:"WWPENTITYNAME",pic:""}],[{av:"A63WWPEntityName",fld:"WWPENTITYNAME",pic:""}]];this.EnterCtrl=["BTN_ENTER"];this.setVCMap("A40000WWPUserExtendedPhoto_GXI","WWPUSEREXTENDEDPHOTO_GXI",0,"svchar",2048,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.wwpbaseobjects.discussions.wwp_discussionmessage)})