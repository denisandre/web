gx.evt.autoSkip=!1;gx.define("wwpbaseobjects.mail.wwp_mail",!1,function(){var n,t;this.ServerClass="wwpbaseobjects.mail.wwp_mail";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwpbaseobjects.mail.wwp_mail.aspx";this.setObjectType("trn");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",".")};this.Valid_Wwpmailid=function(){return this.validSrvEvt("Valid_Wwpmailid",0).then(function(n){return n}.closure(this))};this.Valid_Wwpmailstatus=function(){return this.validCliEvt("Valid_Wwpmailstatus",0,function(){try{var n=gx.util.balloon.getNew("WWPMAILSTATUS");if(this.AnyError=0,!(this.A123WWPMailStatus==1||this.A123WWPMailStatus==2||this.A123WWPMailStatus==3))try{n.setError("Campo Mail Status fora do intervalo");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Wwpnotificationid=function(){return this.validSrvEvt("Valid_Wwpnotificationid",0).then(function(n){return n}.closure(this))};this.Valid_Wwpmailattachmentname=function(){var n=gx.fn.currentGridRowImpl(113);return this.validCliEvt("Valid_Wwpmailattachmentname",113,function(){try{if(gx.fn.currentGridRowImpl(113)===0)return!0;var n=gx.util.balloon.getNew("WWPMAILATTACHMENTNAME",gx.fn.currentGridRowImpl(113));this.AnyError=0;this.sMode16=this.Gx_mode;this.Gx_mode=gx.fn.getGridRowMode(16,113);this.standaloneModal0F16();this.standaloneNotModal0F16();gx.fn.gridDuplicateKey(114)&&(n.setError(gx.text.format(gx.getMessage("GXM_1004"),"Attachments","","","","","","","","")),this.AnyError=gx.num.trunc(1,0))}catch(t){}try{return(this.Gx_mode=this.sMode16,n==null)?!0:n.show()}catch(t){}return!0})};this.standaloneModal0F16=function(){try{gx.text.compare(this.Gx_mode,"INS")!=0?gx.fn.setCtrlProperty("WWPMAILATTACHMENTNAME","Enabled",0):gx.fn.setCtrlProperty("WWPMAILATTACHMENTNAME","Enabled",1)}catch(n){}};this.standaloneNotModal0F16=function(){};this.e110f15_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e120f15_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,114,115,116,117,118,119,120,121,122,123,124];this.GXLastCtrlId=124;this.Gridwwp_mail_attachmentsContainer=new gx.grid.grid(this,16,"Attachments",113,"Gridwwp_mail_attachments","Gridwwp_mail_attachments","Gridwwp_mail_attachmentsContainer",this.CmpContext,this.IsMasterPage,"wwpbaseobjects.mail.wwp_mail",[135],!1,1,!1,!0,5,!1,!1,!1,"",0,"px",0,"px","Novo registro",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Gridwwp_mail_attachmentsContainer;t.addSingleLineEdit(135,114,"WWPMAILATTACHMENTNAME","Attachment Name","","WWPMailAttachmentName","svchar",0,"px",40,40,"start",null,[],135,"WWPMailAttachmentName",!0,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit(127,115,"WWPMAILATTACHMENTFILE","Attachment File","","WWPMailAttachmentFile","vchar",0,"px",2097152,80,"start",null,[],127,"WWPMailAttachmentFile",!0,0,!1,!1,"Attribute",0,"");this.Gridwwp_mail_attachmentsContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e130f15_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e140f15_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e150f15_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e160f15_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e170f15_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpmailid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Gridwwp_mail_attachmentsContainer],fld:"WWPMAILID",fmt:0,gxz:"Z122WWPMailId",gxold:"O122WWPMailId",gxvar:"A122WWPMailId",ucs:[],op:[99,94,89,84,79,74,69,64,59,54,49,44,39],ip:[99,94,89,84,79,74,69,64,59,54,49,44,39,34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A122WWPMailId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z122WWPMailId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("WWPMAILID",gx.O.A122WWPMailId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A122WWPMailId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("WWPMAILID",".")},nac:gx.falseFn};this.declareDomainHdlr(34,function(){});n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"svchar",len:80,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILSUBJECT",fmt:0,gxz:"Z111WWPMailSubject",gxold:"O111WWPMailSubject",gxvar:"A111WWPMailSubject",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A111WWPMailSubject=n)},v2z:function(n){n!==undefined&&(gx.O.Z111WWPMailSubject=n)},v2c:function(){gx.fn.setControlValue("WWPMAILSUBJECT",gx.O.A111WWPMailSubject,0)},c2v:function(){this.val()!==undefined&&(gx.O.A111WWPMailSubject=this.val())},val:function(){return gx.fn.getControlValue("WWPMAILSUBJECT")},nac:gx.falseFn};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"vchar",len:2097152,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILBODY",fmt:1,gxz:"Z103WWPMailBody",gxold:"O103WWPMailBody",gxvar:"A103WWPMailBody",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A103WWPMailBody=n)},v2z:function(n){n!==undefined&&(gx.O.Z103WWPMailBody=n)},v2c:function(){gx.fn.setControlValue("WWPMAILBODY",gx.O.A103WWPMailBody,1);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A103WWPMailBody=this.val())},val:function(){return gx.fn.getControlValue("WWPMAILBODY")},nac:gx.falseFn};this.declareDomainHdlr(44,function(){});n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"vchar",len:2097152,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILTO",fmt:0,gxz:"Z112WWPMailTo",gxold:"O112WWPMailTo",gxvar:"A112WWPMailTo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A112WWPMailTo=n)},v2z:function(n){n!==undefined&&(gx.O.Z112WWPMailTo=n)},v2c:function(){gx.fn.setControlValue("WWPMAILTO",gx.O.A112WWPMailTo,0)},c2v:function(){this.val()!==undefined&&(gx.O.A112WWPMailTo=this.val())},val:function(){return gx.fn.getControlValue("WWPMAILTO")},nac:gx.falseFn};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"vchar",len:2097152,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILCC",fmt:0,gxz:"Z125WWPMailCC",gxold:"O125WWPMailCC",gxvar:"A125WWPMailCC",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A125WWPMailCC=n)},v2z:function(n){n!==undefined&&(gx.O.Z125WWPMailCC=n)},v2c:function(){gx.fn.setControlValue("WWPMAILCC",gx.O.A125WWPMailCC,0)},c2v:function(){this.val()!==undefined&&(gx.O.A125WWPMailCC=this.val())},val:function(){return gx.fn.getControlValue("WWPMAILCC")},nac:gx.falseFn};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"vchar",len:2097152,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILBCC",fmt:0,gxz:"Z126WWPMailBCC",gxold:"O126WWPMailBCC",gxvar:"A126WWPMailBCC",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A126WWPMailBCC=n)},v2z:function(n){n!==undefined&&(gx.O.Z126WWPMailBCC=n)},v2c:function(){gx.fn.setControlValue("WWPMAILBCC",gx.O.A126WWPMailBCC,0)},c2v:function(){this.val()!==undefined&&(gx.O.A126WWPMailBCC=this.val())},val:function(){return gx.fn.getControlValue("WWPMAILBCC")},nac:gx.falseFn};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,lvl:0,type:"vchar",len:2097152,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILSENDERADDRESS",fmt:0,gxz:"Z113WWPMailSenderAddress",gxold:"O113WWPMailSenderAddress",gxvar:"A113WWPMailSenderAddress",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A113WWPMailSenderAddress=n)},v2z:function(n){n!==undefined&&(gx.O.Z113WWPMailSenderAddress=n)},v2c:function(){gx.fn.setControlValue("WWPMAILSENDERADDRESS",gx.O.A113WWPMailSenderAddress,0)},c2v:function(){this.val()!==undefined&&(gx.O.A113WWPMailSenderAddress=this.val())},val:function(){return gx.fn.getControlValue("WWPMAILSENDERADDRESS")},nac:gx.falseFn};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,lvl:0,type:"vchar",len:2097152,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILSENDERNAME",fmt:0,gxz:"Z114WWPMailSenderName",gxold:"O114WWPMailSenderName",gxvar:"A114WWPMailSenderName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A114WWPMailSenderName=n)},v2z:function(n){n!==undefined&&(gx.O.Z114WWPMailSenderName=n)},v2c:function(){gx.fn.setControlValue("WWPMAILSENDERNAME",gx.O.A114WWPMailSenderName,0)},c2v:function(){this.val()!==undefined&&(gx.O.A114WWPMailSenderName=this.val())},val:function(){return gx.fn.getControlValue("WWPMAILSENDERNAME")},nac:gx.falseFn};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"",grid:0};n[74]={id:74,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpmailstatus,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILSTATUS",fmt:0,gxz:"Z123WWPMailStatus",gxold:"O123WWPMailStatus",gxvar:"A123WWPMailStatus",ucs:[],op:[74],ip:[74],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A123WWPMailStatus=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z123WWPMailStatus=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("WWPMAILSTATUS",gx.O.A123WWPMailStatus);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A123WWPMailStatus=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("WWPMAILSTATUS",".")},nac:gx.falseFn};this.declareDomainHdlr(74,function(){});n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,lvl:0,type:"dtime",len:10,dec:12,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILCREATED",fmt:0,gxz:"Z133WWPMailCreated",gxold:"O133WWPMailCreated",gxvar:"A133WWPMailCreated",dp:{f:0,st:!0,wn:!1,mf:!1,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A133WWPMailCreated=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z133WWPMailCreated=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("WWPMAILCREATED",gx.O.A133WWPMailCreated,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A133WWPMailCreated=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getDateTimeValue("WWPMAILCREATED")},nac:gx.falseFn};this.declareDomainHdlr(79,function(){});n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[84]={id:84,lvl:0,type:"dtime",len:10,dec:12,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILSCHEDULED",fmt:0,gxz:"Z134WWPMailScheduled",gxold:"O134WWPMailScheduled",gxvar:"A134WWPMailScheduled",dp:{f:0,st:!0,wn:!1,mf:!1,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A134WWPMailScheduled=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z134WWPMailScheduled=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("WWPMAILSCHEDULED",gx.O.A134WWPMailScheduled,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A134WWPMailScheduled=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getDateTimeValue("WWPMAILSCHEDULED")},nac:gx.falseFn};this.declareDomainHdlr(84,function(){});n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"",grid:0};n[88]={id:88,fld:"",grid:0};n[89]={id:89,lvl:0,type:"dtime",len:10,dec:12,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILPROCESSED",fmt:0,gxz:"Z128WWPMailProcessed",gxold:"O128WWPMailProcessed",gxvar:"A128WWPMailProcessed",dp:{f:0,st:!0,wn:!1,mf:!1,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A128WWPMailProcessed=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z128WWPMailProcessed=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("WWPMAILPROCESSED",gx.O.A128WWPMailProcessed,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A128WWPMailProcessed=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getDateTimeValue("WWPMAILPROCESSED")},nac:gx.falseFn};this.declareDomainHdlr(89,function(){});n[90]={id:90,fld:"",grid:0};n[91]={id:91,fld:"",grid:0};n[92]={id:92,fld:"",grid:0};n[93]={id:93,fld:"",grid:0};n[94]={id:94,lvl:0,type:"vchar",len:2097152,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILDETAIL",fmt:0,gxz:"Z129WWPMailDetail",gxold:"O129WWPMailDetail",gxvar:"A129WWPMailDetail",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A129WWPMailDetail=n)},v2z:function(n){n!==undefined&&(gx.O.Z129WWPMailDetail=n)},v2c:function(){gx.fn.setControlValue("WWPMAILDETAIL",gx.O.A129WWPMailDetail,0)},c2v:function(){this.val()!==undefined&&(gx.O.A129WWPMailDetail=this.val())},val:function(){return gx.fn.getControlValue("WWPMAILDETAIL")},nac:gx.falseFn};n[95]={id:95,fld:"",grid:0};n[96]={id:96,fld:"",grid:0};n[97]={id:97,fld:"",grid:0};n[98]={id:98,fld:"",grid:0};n[99]={id:99,lvl:0,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpnotificationid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONID",fmt:0,gxz:"Z64WWPNotificationId",gxold:"O64WWPNotificationId",gxvar:"A64WWPNotificationId",ucs:[],op:[104],ip:[104,99],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A64WWPNotificationId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z64WWPNotificationId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONID",gx.O.A64WWPNotificationId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A64WWPNotificationId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("WWPNOTIFICATIONID",".")},nac:gx.falseFn};this.declareDomainHdlr(99,function(){});n[100]={id:100,fld:"",grid:0};n[101]={id:101,fld:"",grid:0};n[102]={id:102,fld:"",grid:0};n[103]={id:103,fld:"",grid:0};n[104]={id:104,lvl:0,type:"dtime",len:10,dec:12,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONCREATED",fmt:0,gxz:"Z66WWPNotificationCreated",gxold:"O66WWPNotificationCreated",gxvar:"A66WWPNotificationCreated",dp:{f:0,st:!0,wn:!1,mf:!1,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A66WWPNotificationCreated=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z66WWPNotificationCreated=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONCREATED",gx.O.A66WWPNotificationCreated,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A66WWPNotificationCreated=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getDateTimeValue("WWPNOTIFICATIONCREATED")},nac:gx.falseFn};this.declareDomainHdlr(104,function(){});n[105]={id:105,fld:"",grid:0};n[106]={id:106,fld:"",grid:0};n[107]={id:107,fld:"ATTACHMENTSTABLE",grid:0};n[108]={id:108,fld:"",grid:0};n[109]={id:109,fld:"",grid:0};n[110]={id:110,fld:"TITLEATTACHMENTS",format:0,grid:0,ctrltype:"textblock"};n[111]={id:111,fld:"",grid:0};n[112]={id:112,fld:"",grid:0};n[114]={id:114,lvl:16,type:"svchar",len:40,dec:0,sign:!1,ro:0,isacc:1,grid:113,gxgrid:this.Gridwwp_mail_attachmentsContainer,fnc:this.Valid_Wwpmailattachmentname,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILATTACHMENTNAME",fmt:0,gxz:"Z135WWPMailAttachmentName",gxold:"O135WWPMailAttachmentName",gxvar:"A135WWPMailAttachmentName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A135WWPMailAttachmentName=n)},v2z:function(n){n!==undefined&&(gx.O.Z135WWPMailAttachmentName=n)},v2c:function(n){gx.fn.setGridControlValue("WWPMAILATTACHMENTNAME",n||gx.fn.currentGridRowImpl(113),gx.O.A135WWPMailAttachmentName,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A135WWPMailAttachmentName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("WWPMAILATTACHMENTNAME",n||gx.fn.currentGridRowImpl(113))},nac:gx.falseFn};n[115]={id:115,lvl:16,type:"vchar",len:2097152,dec:0,sign:!1,ro:0,isacc:1,grid:113,gxgrid:this.Gridwwp_mail_attachmentsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILATTACHMENTFILE",fmt:0,gxz:"Z127WWPMailAttachmentFile",gxold:"O127WWPMailAttachmentFile",gxvar:"A127WWPMailAttachmentFile",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A127WWPMailAttachmentFile=n)},v2z:function(n){n!==undefined&&(gx.O.Z127WWPMailAttachmentFile=n)},v2c:function(n){gx.fn.setGridControlValue("WWPMAILATTACHMENTFILE",n||gx.fn.currentGridRowImpl(113),gx.O.A127WWPMailAttachmentFile,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A127WWPMailAttachmentFile=this.val(n))},val:function(n){return gx.fn.getGridControlValue("WWPMAILATTACHMENTFILE",n||gx.fn.currentGridRowImpl(113))},nac:gx.falseFn};n[116]={id:116,fld:"",grid:0};n[117]={id:117,fld:"",grid:0};n[118]={id:118,fld:"",grid:0};n[119]={id:119,fld:"",grid:0};n[120]={id:120,fld:"BTN_ENTER",grid:0,evt:"e110f15_client",std:"ENTER"};n[121]={id:121,fld:"",grid:0};n[122]={id:122,fld:"BTN_CANCEL",grid:0,evt:"e120f15_client"};n[123]={id:123,fld:"",grid:0};n[124]={id:124,fld:"BTN_DELETE",grid:0,evt:"e180f15_client",std:"DELETE"};this.A122WWPMailId=0;this.Z122WWPMailId=0;this.O122WWPMailId=0;this.A111WWPMailSubject="";this.Z111WWPMailSubject="";this.O111WWPMailSubject="";this.A103WWPMailBody="";this.Z103WWPMailBody="";this.O103WWPMailBody="";this.A112WWPMailTo="";this.Z112WWPMailTo="";this.O112WWPMailTo="";this.A125WWPMailCC="";this.Z125WWPMailCC="";this.O125WWPMailCC="";this.A126WWPMailBCC="";this.Z126WWPMailBCC="";this.O126WWPMailBCC="";this.A113WWPMailSenderAddress="";this.Z113WWPMailSenderAddress="";this.O113WWPMailSenderAddress="";this.A114WWPMailSenderName="";this.Z114WWPMailSenderName="";this.O114WWPMailSenderName="";this.A123WWPMailStatus=0;this.Z123WWPMailStatus=0;this.O123WWPMailStatus=0;this.A133WWPMailCreated=gx.date.nullDate();this.Z133WWPMailCreated=gx.date.nullDate();this.O133WWPMailCreated=gx.date.nullDate();this.A134WWPMailScheduled=gx.date.nullDate();this.Z134WWPMailScheduled=gx.date.nullDate();this.O134WWPMailScheduled=gx.date.nullDate();this.A128WWPMailProcessed=gx.date.nullDate();this.Z128WWPMailProcessed=gx.date.nullDate();this.O128WWPMailProcessed=gx.date.nullDate();this.A129WWPMailDetail="";this.Z129WWPMailDetail="";this.O129WWPMailDetail="";this.A64WWPNotificationId=0;this.Z64WWPNotificationId=0;this.O64WWPNotificationId=0;this.A66WWPNotificationCreated=gx.date.nullDate();this.Z66WWPNotificationCreated=gx.date.nullDate();this.O66WWPNotificationCreated=gx.date.nullDate();this.Z135WWPMailAttachmentName="";this.O135WWPMailAttachmentName="";this.Z127WWPMailAttachmentFile="";this.O127WWPMailAttachmentFile="";this.A135WWPMailAttachmentName="";this.A127WWPMailAttachmentFile="";this.A122WWPMailId=0;this.Gx_BScreen=0;this.A111WWPMailSubject="";this.A103WWPMailBody="";this.A112WWPMailTo="";this.A125WWPMailCC="";this.A126WWPMailBCC="";this.A113WWPMailSenderAddress="";this.A114WWPMailSenderName="";this.A123WWPMailStatus=0;this.A133WWPMailCreated=gx.date.nullDate();this.A134WWPMailScheduled=gx.date.nullDate();this.A128WWPMailProcessed=gx.date.nullDate();this.A129WWPMailDetail="";this.A64WWPNotificationId=0;this.A66WWPNotificationCreated=gx.date.nullDate();this.Events={e110f15_client:["ENTER",!0],e120f15_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_WWPMAILID=[[{av:"A122WWPMailId",fld:"WWPMAILID",pic:"ZZZZZZZZZ9"},{av:"Gx_BScreen",fld:"vGXBSCREEN",pic:"9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{ctrl:"WWPMAILSTATUS"},{av:"A123WWPMailStatus",fld:"WWPMAILSTATUS",pic:"ZZZ9"},{av:"A133WWPMailCreated",fld:"WWPMAILCREATED",pic:"99/99/9999 99:99:99.999"},{av:"A134WWPMailScheduled",fld:"WWPMAILSCHEDULED",pic:"99/99/9999 99:99:99.999"}],[{av:"A111WWPMailSubject",fld:"WWPMAILSUBJECT",pic:""},{av:"A103WWPMailBody",fld:"WWPMAILBODY",pic:""},{av:"A112WWPMailTo",fld:"WWPMAILTO",pic:""},{av:"A125WWPMailCC",fld:"WWPMAILCC",pic:""},{av:"A126WWPMailBCC",fld:"WWPMAILBCC",pic:""},{av:"A113WWPMailSenderAddress",fld:"WWPMAILSENDERADDRESS",pic:""},{av:"A114WWPMailSenderName",fld:"WWPMAILSENDERNAME",pic:""},{ctrl:"WWPMAILSTATUS"},{av:"A123WWPMailStatus",fld:"WWPMAILSTATUS",pic:"ZZZ9"},{av:"A133WWPMailCreated",fld:"WWPMAILCREATED",pic:"99/99/9999 99:99:99.999"},{av:"A134WWPMailScheduled",fld:"WWPMAILSCHEDULED",pic:"99/99/9999 99:99:99.999"},{av:"A128WWPMailProcessed",fld:"WWPMAILPROCESSED",pic:"99/99/9999 99:99:99.999"},{av:"A129WWPMailDetail",fld:"WWPMAILDETAIL",pic:""},{av:"A64WWPNotificationId",fld:"WWPNOTIFICATIONID",pic:"ZZZZZZZZZ9"},{av:"A66WWPNotificationCreated",fld:"WWPNOTIFICATIONCREATED",pic:"99/99/9999 99:99:99.999"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z122WWPMailId"},{av:"Z111WWPMailSubject"},{av:"Z103WWPMailBody"},{av:"Z112WWPMailTo"},{av:"Z125WWPMailCC"},{av:"Z126WWPMailBCC"},{av:"Z113WWPMailSenderAddress"},{av:"Z114WWPMailSenderName"},{av:"Z123WWPMailStatus"},{av:"Z133WWPMailCreated"},{av:"Z134WWPMailScheduled"},{av:"Z128WWPMailProcessed"},{av:"Z129WWPMailDetail"},{av:"Z64WWPNotificationId"},{av:"Z66WWPNotificationCreated"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"}]];this.EvtParms.VALID_WWPMAILSTATUS=[[{ctrl:"WWPMAILSTATUS"},{av:"A123WWPMailStatus",fld:"WWPMAILSTATUS",pic:"ZZZ9"}],[{ctrl:"WWPMAILSTATUS"},{av:"A123WWPMailStatus",fld:"WWPMAILSTATUS",pic:"ZZZ9"}]];this.EvtParms.VALID_WWPNOTIFICATIONID=[[{av:"A64WWPNotificationId",fld:"WWPNOTIFICATIONID",pic:"ZZZZZZZZZ9"},{av:"A66WWPNotificationCreated",fld:"WWPNOTIFICATIONCREATED",pic:"99/99/9999 99:99:99.999"}],[{av:"A66WWPNotificationCreated",fld:"WWPNOTIFICATIONCREATED",pic:"99/99/9999 99:99:99.999"}]];this.EvtParms.VALID_WWPMAILATTACHMENTNAME=[[],[]];this.EnterCtrl=["BTN_ENTER"];this.setVCMap("Gx_BScreen","vGXBSCREEN",0,"int",1,0);t.addPostingVar({rfrVar:"Gx_mode"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.wwpbaseobjects.mail.wwp_mail)})