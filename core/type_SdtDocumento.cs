using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.core {
   [XmlRoot(ElementName = "Documento" )]
   [XmlType(TypeName =  "Documento" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class SdtDocumento : GxSilentTrnSdt
   {
      public SdtDocumento( )
      {
      }

      public SdtDocumento( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( Guid AV289DocID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV289DocID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"DocID", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "core\\Documento");
         metadata.Set("BT", "tb_documento");
         metadata.Set("PK", "[ \"DocID\" ]");
         metadata.Set("PKAssigned", "[ \"DocID\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"DocID\" ],\"FKMap\":[ \"DocVersaoIDPai-DocID\" ] },{ \"FK\":[ \"DocTipoID\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Docid_Z");
         state.Add("gxTpr_Docversao_Z");
         state.Add("gxTpr_Docversaoidpai_Z");
         state.Add("gxTpr_Docversaonomepai_Z");
         state.Add("gxTpr_Docorigem_Z");
         state.Add("gxTpr_Docorigemid_Z");
         state.Add("gxTpr_Docinsdata_Z_Nullable");
         state.Add("gxTpr_Docinshora_Z_Nullable");
         state.Add("gxTpr_Docinsdatahora_Z_Nullable");
         state.Add("gxTpr_Docinsusuid_Z");
         state.Add("gxTpr_Docupddata_Z_Nullable");
         state.Add("gxTpr_Docupdhora_Z_Nullable");
         state.Add("gxTpr_Docupddatahora_Z_Nullable");
         state.Add("gxTpr_Docupdusuid_Z");
         state.Add("gxTpr_Docdel_Z");
         state.Add("gxTpr_Docdeldatahora_Z_Nullable");
         state.Add("gxTpr_Docdeldata_Z_Nullable");
         state.Add("gxTpr_Docdelhora_Z_Nullable");
         state.Add("gxTpr_Docdelusuid_Z");
         state.Add("gxTpr_Docdelusunome_Z");
         state.Add("gxTpr_Docnome_Z");
         state.Add("gxTpr_Doctipoid_Z");
         state.Add("gxTpr_Doctiposigla_Z");
         state.Add("gxTpr_Doctiponome_Z");
         state.Add("gxTpr_Doctipoativo_Z");
         state.Add("gxTpr_Docultarqseq_Z");
         state.Add("gxTpr_Doccontrato_Z");
         state.Add("gxTpr_Docassinado_Z");
         state.Add("gxTpr_Docativo_Z");
         state.Add("gxTpr_Docversaoidpai_N");
         state.Add("gxTpr_Docinsusuid_N");
         state.Add("gxTpr_Docupddata_N");
         state.Add("gxTpr_Docupdhora_N");
         state.Add("gxTpr_Docupddatahora_N");
         state.Add("gxTpr_Docupdusuid_N");
         state.Add("gxTpr_Docdeldatahora_N");
         state.Add("gxTpr_Docdeldata_N");
         state.Add("gxTpr_Docdelhora_N");
         state.Add("gxTpr_Docdelusuid_N");
         state.Add("gxTpr_Docdelusunome_N");
         state.Add("gxTpr_Docultarqseq_N");
         state.Add("gxTpr_Docativo_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.SdtDocumento sdt;
         sdt = (GeneXus.Programs.core.SdtDocumento)(source);
         gxTv_SdtDocumento_Docid = sdt.gxTv_SdtDocumento_Docid ;
         gxTv_SdtDocumento_Docversao = sdt.gxTv_SdtDocumento_Docversao ;
         gxTv_SdtDocumento_Docversaoidpai = sdt.gxTv_SdtDocumento_Docversaoidpai ;
         gxTv_SdtDocumento_Docversaonomepai = sdt.gxTv_SdtDocumento_Docversaonomepai ;
         gxTv_SdtDocumento_Docorigem = sdt.gxTv_SdtDocumento_Docorigem ;
         gxTv_SdtDocumento_Docorigemid = sdt.gxTv_SdtDocumento_Docorigemid ;
         gxTv_SdtDocumento_Docinsdata = sdt.gxTv_SdtDocumento_Docinsdata ;
         gxTv_SdtDocumento_Docinshora = sdt.gxTv_SdtDocumento_Docinshora ;
         gxTv_SdtDocumento_Docinsdatahora = sdt.gxTv_SdtDocumento_Docinsdatahora ;
         gxTv_SdtDocumento_Docinsusuid = sdt.gxTv_SdtDocumento_Docinsusuid ;
         gxTv_SdtDocumento_Docupddata = sdt.gxTv_SdtDocumento_Docupddata ;
         gxTv_SdtDocumento_Docupdhora = sdt.gxTv_SdtDocumento_Docupdhora ;
         gxTv_SdtDocumento_Docupddatahora = sdt.gxTv_SdtDocumento_Docupddatahora ;
         gxTv_SdtDocumento_Docupdusuid = sdt.gxTv_SdtDocumento_Docupdusuid ;
         gxTv_SdtDocumento_Docdel = sdt.gxTv_SdtDocumento_Docdel ;
         gxTv_SdtDocumento_Docdeldatahora = sdt.gxTv_SdtDocumento_Docdeldatahora ;
         gxTv_SdtDocumento_Docdeldata = sdt.gxTv_SdtDocumento_Docdeldata ;
         gxTv_SdtDocumento_Docdelhora = sdt.gxTv_SdtDocumento_Docdelhora ;
         gxTv_SdtDocumento_Docdelusuid = sdt.gxTv_SdtDocumento_Docdelusuid ;
         gxTv_SdtDocumento_Docdelusunome = sdt.gxTv_SdtDocumento_Docdelusunome ;
         gxTv_SdtDocumento_Docnome = sdt.gxTv_SdtDocumento_Docnome ;
         gxTv_SdtDocumento_Doctipoid = sdt.gxTv_SdtDocumento_Doctipoid ;
         gxTv_SdtDocumento_Doctiposigla = sdt.gxTv_SdtDocumento_Doctiposigla ;
         gxTv_SdtDocumento_Doctiponome = sdt.gxTv_SdtDocumento_Doctiponome ;
         gxTv_SdtDocumento_Doctipoativo = sdt.gxTv_SdtDocumento_Doctipoativo ;
         gxTv_SdtDocumento_Docultarqseq = sdt.gxTv_SdtDocumento_Docultarqseq ;
         gxTv_SdtDocumento_Doccontrato = sdt.gxTv_SdtDocumento_Doccontrato ;
         gxTv_SdtDocumento_Docassinado = sdt.gxTv_SdtDocumento_Docassinado ;
         gxTv_SdtDocumento_Docativo = sdt.gxTv_SdtDocumento_Docativo ;
         gxTv_SdtDocumento_Mode = sdt.gxTv_SdtDocumento_Mode ;
         gxTv_SdtDocumento_Initialized = sdt.gxTv_SdtDocumento_Initialized ;
         gxTv_SdtDocumento_Docid_Z = sdt.gxTv_SdtDocumento_Docid_Z ;
         gxTv_SdtDocumento_Docversao_Z = sdt.gxTv_SdtDocumento_Docversao_Z ;
         gxTv_SdtDocumento_Docversaoidpai_Z = sdt.gxTv_SdtDocumento_Docversaoidpai_Z ;
         gxTv_SdtDocumento_Docversaonomepai_Z = sdt.gxTv_SdtDocumento_Docversaonomepai_Z ;
         gxTv_SdtDocumento_Docorigem_Z = sdt.gxTv_SdtDocumento_Docorigem_Z ;
         gxTv_SdtDocumento_Docorigemid_Z = sdt.gxTv_SdtDocumento_Docorigemid_Z ;
         gxTv_SdtDocumento_Docinsdata_Z = sdt.gxTv_SdtDocumento_Docinsdata_Z ;
         gxTv_SdtDocumento_Docinshora_Z = sdt.gxTv_SdtDocumento_Docinshora_Z ;
         gxTv_SdtDocumento_Docinsdatahora_Z = sdt.gxTv_SdtDocumento_Docinsdatahora_Z ;
         gxTv_SdtDocumento_Docinsusuid_Z = sdt.gxTv_SdtDocumento_Docinsusuid_Z ;
         gxTv_SdtDocumento_Docupddata_Z = sdt.gxTv_SdtDocumento_Docupddata_Z ;
         gxTv_SdtDocumento_Docupdhora_Z = sdt.gxTv_SdtDocumento_Docupdhora_Z ;
         gxTv_SdtDocumento_Docupddatahora_Z = sdt.gxTv_SdtDocumento_Docupddatahora_Z ;
         gxTv_SdtDocumento_Docupdusuid_Z = sdt.gxTv_SdtDocumento_Docupdusuid_Z ;
         gxTv_SdtDocumento_Docdel_Z = sdt.gxTv_SdtDocumento_Docdel_Z ;
         gxTv_SdtDocumento_Docdeldatahora_Z = sdt.gxTv_SdtDocumento_Docdeldatahora_Z ;
         gxTv_SdtDocumento_Docdeldata_Z = sdt.gxTv_SdtDocumento_Docdeldata_Z ;
         gxTv_SdtDocumento_Docdelhora_Z = sdt.gxTv_SdtDocumento_Docdelhora_Z ;
         gxTv_SdtDocumento_Docdelusuid_Z = sdt.gxTv_SdtDocumento_Docdelusuid_Z ;
         gxTv_SdtDocumento_Docdelusunome_Z = sdt.gxTv_SdtDocumento_Docdelusunome_Z ;
         gxTv_SdtDocumento_Docnome_Z = sdt.gxTv_SdtDocumento_Docnome_Z ;
         gxTv_SdtDocumento_Doctipoid_Z = sdt.gxTv_SdtDocumento_Doctipoid_Z ;
         gxTv_SdtDocumento_Doctiposigla_Z = sdt.gxTv_SdtDocumento_Doctiposigla_Z ;
         gxTv_SdtDocumento_Doctiponome_Z = sdt.gxTv_SdtDocumento_Doctiponome_Z ;
         gxTv_SdtDocumento_Doctipoativo_Z = sdt.gxTv_SdtDocumento_Doctipoativo_Z ;
         gxTv_SdtDocumento_Docultarqseq_Z = sdt.gxTv_SdtDocumento_Docultarqseq_Z ;
         gxTv_SdtDocumento_Doccontrato_Z = sdt.gxTv_SdtDocumento_Doccontrato_Z ;
         gxTv_SdtDocumento_Docassinado_Z = sdt.gxTv_SdtDocumento_Docassinado_Z ;
         gxTv_SdtDocumento_Docativo_Z = sdt.gxTv_SdtDocumento_Docativo_Z ;
         gxTv_SdtDocumento_Docversaoidpai_N = sdt.gxTv_SdtDocumento_Docversaoidpai_N ;
         gxTv_SdtDocumento_Docinsusuid_N = sdt.gxTv_SdtDocumento_Docinsusuid_N ;
         gxTv_SdtDocumento_Docupddata_N = sdt.gxTv_SdtDocumento_Docupddata_N ;
         gxTv_SdtDocumento_Docupdhora_N = sdt.gxTv_SdtDocumento_Docupdhora_N ;
         gxTv_SdtDocumento_Docupddatahora_N = sdt.gxTv_SdtDocumento_Docupddatahora_N ;
         gxTv_SdtDocumento_Docupdusuid_N = sdt.gxTv_SdtDocumento_Docupdusuid_N ;
         gxTv_SdtDocumento_Docdeldatahora_N = sdt.gxTv_SdtDocumento_Docdeldatahora_N ;
         gxTv_SdtDocumento_Docdeldata_N = sdt.gxTv_SdtDocumento_Docdeldata_N ;
         gxTv_SdtDocumento_Docdelhora_N = sdt.gxTv_SdtDocumento_Docdelhora_N ;
         gxTv_SdtDocumento_Docdelusuid_N = sdt.gxTv_SdtDocumento_Docdelusuid_N ;
         gxTv_SdtDocumento_Docdelusunome_N = sdt.gxTv_SdtDocumento_Docdelusunome_N ;
         gxTv_SdtDocumento_Docultarqseq_N = sdt.gxTv_SdtDocumento_Docultarqseq_N ;
         gxTv_SdtDocumento_Docativo_N = sdt.gxTv_SdtDocumento_Docativo_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("DocID", gxTv_SdtDocumento_Docid, false, includeNonInitialized);
         AddObjectProperty("DocVersao", gxTv_SdtDocumento_Docversao, false, includeNonInitialized);
         AddObjectProperty("DocVersaoIDPai", gxTv_SdtDocumento_Docversaoidpai, false, includeNonInitialized);
         AddObjectProperty("DocVersaoIDPai_N", gxTv_SdtDocumento_Docversaoidpai_N, false, includeNonInitialized);
         AddObjectProperty("DocVersaoNomePai", gxTv_SdtDocumento_Docversaonomepai, false, includeNonInitialized);
         AddObjectProperty("DocOrigem", gxTv_SdtDocumento_Docorigem, false, includeNonInitialized);
         AddObjectProperty("DocOrigemID", gxTv_SdtDocumento_Docorigemid, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocumento_Docinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocumento_Docinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocumento_Docinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("DocInsData", sDateCnv, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtDocumento_Docinshora;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("DocInsHora", sDateCnv, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtDocumento_Docinsdatahora;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ".";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.MilliSecond( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "000", 1, 3-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("DocInsDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DocInsUsuID", gxTv_SdtDocumento_Docinsusuid, false, includeNonInitialized);
         AddObjectProperty("DocInsUsuID_N", gxTv_SdtDocumento_Docinsusuid_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocumento_Docupddata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocumento_Docupddata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocumento_Docupddata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("DocUpdData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DocUpdData_N", gxTv_SdtDocumento_Docupddata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtDocumento_Docupdhora;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("DocUpdHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DocUpdHora_N", gxTv_SdtDocumento_Docupdhora_N, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtDocumento_Docupddatahora;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ".";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.MilliSecond( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "000", 1, 3-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("DocUpdDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DocUpdDataHora_N", gxTv_SdtDocumento_Docupddatahora_N, false, includeNonInitialized);
         AddObjectProperty("DocUpdUsuID", gxTv_SdtDocumento_Docupdusuid, false, includeNonInitialized);
         AddObjectProperty("DocUpdUsuID_N", gxTv_SdtDocumento_Docupdusuid_N, false, includeNonInitialized);
         AddObjectProperty("DocDel", gxTv_SdtDocumento_Docdel, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtDocumento_Docdeldatahora;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ".";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.MilliSecond( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "000", 1, 3-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("DocDelDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DocDelDataHora_N", gxTv_SdtDocumento_Docdeldatahora_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtDocumento_Docdeldata;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("DocDelData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DocDelData_N", gxTv_SdtDocumento_Docdeldata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtDocumento_Docdelhora;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("DocDelHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DocDelHora_N", gxTv_SdtDocumento_Docdelhora_N, false, includeNonInitialized);
         AddObjectProperty("DocDelUsuID", gxTv_SdtDocumento_Docdelusuid, false, includeNonInitialized);
         AddObjectProperty("DocDelUsuID_N", gxTv_SdtDocumento_Docdelusuid_N, false, includeNonInitialized);
         AddObjectProperty("DocDelUsuNome", gxTv_SdtDocumento_Docdelusunome, false, includeNonInitialized);
         AddObjectProperty("DocDelUsuNome_N", gxTv_SdtDocumento_Docdelusunome_N, false, includeNonInitialized);
         AddObjectProperty("DocNome", gxTv_SdtDocumento_Docnome, false, includeNonInitialized);
         AddObjectProperty("DocTipoID", gxTv_SdtDocumento_Doctipoid, false, includeNonInitialized);
         AddObjectProperty("DocTipoSigla", gxTv_SdtDocumento_Doctiposigla, false, includeNonInitialized);
         AddObjectProperty("DocTipoNome", gxTv_SdtDocumento_Doctiponome, false, includeNonInitialized);
         AddObjectProperty("DocTipoAtivo", gxTv_SdtDocumento_Doctipoativo, false, includeNonInitialized);
         AddObjectProperty("DocUltArqSeq", gxTv_SdtDocumento_Docultarqseq, false, includeNonInitialized);
         AddObjectProperty("DocUltArqSeq_N", gxTv_SdtDocumento_Docultarqseq_N, false, includeNonInitialized);
         AddObjectProperty("DocContrato", gxTv_SdtDocumento_Doccontrato, false, includeNonInitialized);
         AddObjectProperty("DocAssinado", gxTv_SdtDocumento_Docassinado, false, includeNonInitialized);
         AddObjectProperty("DocAtivo", gxTv_SdtDocumento_Docativo, false, includeNonInitialized);
         AddObjectProperty("DocAtivo_N", gxTv_SdtDocumento_Docativo_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtDocumento_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtDocumento_Initialized, false, includeNonInitialized);
            AddObjectProperty("DocID_Z", gxTv_SdtDocumento_Docid_Z, false, includeNonInitialized);
            AddObjectProperty("DocVersao_Z", gxTv_SdtDocumento_Docversao_Z, false, includeNonInitialized);
            AddObjectProperty("DocVersaoIDPai_Z", gxTv_SdtDocumento_Docversaoidpai_Z, false, includeNonInitialized);
            AddObjectProperty("DocVersaoNomePai_Z", gxTv_SdtDocumento_Docversaonomepai_Z, false, includeNonInitialized);
            AddObjectProperty("DocOrigem_Z", gxTv_SdtDocumento_Docorigem_Z, false, includeNonInitialized);
            AddObjectProperty("DocOrigemID_Z", gxTv_SdtDocumento_Docorigemid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocumento_Docinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocumento_Docinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocumento_Docinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("DocInsData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtDocumento_Docinshora_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("DocInsHora_Z", sDateCnv, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtDocumento_Docinsdatahora_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ".";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.MilliSecond( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "000", 1, 3-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("DocInsDataHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("DocInsUsuID_Z", gxTv_SdtDocumento_Docinsusuid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocumento_Docupddata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocumento_Docupddata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocumento_Docupddata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("DocUpdData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtDocumento_Docupdhora_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("DocUpdHora_Z", sDateCnv, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtDocumento_Docupddatahora_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ".";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.MilliSecond( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "000", 1, 3-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("DocUpdDataHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("DocUpdUsuID_Z", gxTv_SdtDocumento_Docupdusuid_Z, false, includeNonInitialized);
            AddObjectProperty("DocDel_Z", gxTv_SdtDocumento_Docdel_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtDocumento_Docdeldatahora_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ".";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.MilliSecond( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "000", 1, 3-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("DocDelDataHora_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtDocumento_Docdeldata_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("DocDelData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtDocumento_Docdelhora_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("DocDelHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("DocDelUsuID_Z", gxTv_SdtDocumento_Docdelusuid_Z, false, includeNonInitialized);
            AddObjectProperty("DocDelUsuNome_Z", gxTv_SdtDocumento_Docdelusunome_Z, false, includeNonInitialized);
            AddObjectProperty("DocNome_Z", gxTv_SdtDocumento_Docnome_Z, false, includeNonInitialized);
            AddObjectProperty("DocTipoID_Z", gxTv_SdtDocumento_Doctipoid_Z, false, includeNonInitialized);
            AddObjectProperty("DocTipoSigla_Z", gxTv_SdtDocumento_Doctiposigla_Z, false, includeNonInitialized);
            AddObjectProperty("DocTipoNome_Z", gxTv_SdtDocumento_Doctiponome_Z, false, includeNonInitialized);
            AddObjectProperty("DocTipoAtivo_Z", gxTv_SdtDocumento_Doctipoativo_Z, false, includeNonInitialized);
            AddObjectProperty("DocUltArqSeq_Z", gxTv_SdtDocumento_Docultarqseq_Z, false, includeNonInitialized);
            AddObjectProperty("DocContrato_Z", gxTv_SdtDocumento_Doccontrato_Z, false, includeNonInitialized);
            AddObjectProperty("DocAssinado_Z", gxTv_SdtDocumento_Docassinado_Z, false, includeNonInitialized);
            AddObjectProperty("DocAtivo_Z", gxTv_SdtDocumento_Docativo_Z, false, includeNonInitialized);
            AddObjectProperty("DocVersaoIDPai_N", gxTv_SdtDocumento_Docversaoidpai_N, false, includeNonInitialized);
            AddObjectProperty("DocInsUsuID_N", gxTv_SdtDocumento_Docinsusuid_N, false, includeNonInitialized);
            AddObjectProperty("DocUpdData_N", gxTv_SdtDocumento_Docupddata_N, false, includeNonInitialized);
            AddObjectProperty("DocUpdHora_N", gxTv_SdtDocumento_Docupdhora_N, false, includeNonInitialized);
            AddObjectProperty("DocUpdDataHora_N", gxTv_SdtDocumento_Docupddatahora_N, false, includeNonInitialized);
            AddObjectProperty("DocUpdUsuID_N", gxTv_SdtDocumento_Docupdusuid_N, false, includeNonInitialized);
            AddObjectProperty("DocDelDataHora_N", gxTv_SdtDocumento_Docdeldatahora_N, false, includeNonInitialized);
            AddObjectProperty("DocDelData_N", gxTv_SdtDocumento_Docdeldata_N, false, includeNonInitialized);
            AddObjectProperty("DocDelHora_N", gxTv_SdtDocumento_Docdelhora_N, false, includeNonInitialized);
            AddObjectProperty("DocDelUsuID_N", gxTv_SdtDocumento_Docdelusuid_N, false, includeNonInitialized);
            AddObjectProperty("DocDelUsuNome_N", gxTv_SdtDocumento_Docdelusunome_N, false, includeNonInitialized);
            AddObjectProperty("DocUltArqSeq_N", gxTv_SdtDocumento_Docultarqseq_N, false, includeNonInitialized);
            AddObjectProperty("DocAtivo_N", gxTv_SdtDocumento_Docativo_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.SdtDocumento sdt )
      {
         if ( sdt.IsDirty("DocID") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docid = sdt.gxTv_SdtDocumento_Docid ;
         }
         if ( sdt.IsDirty("DocVersao") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docversao = sdt.gxTv_SdtDocumento_Docversao ;
         }
         if ( sdt.IsDirty("DocVersaoIDPai") )
         {
            gxTv_SdtDocumento_Docversaoidpai_N = (short)(sdt.gxTv_SdtDocumento_Docversaoidpai_N);
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docversaoidpai = sdt.gxTv_SdtDocumento_Docversaoidpai ;
         }
         if ( sdt.IsDirty("DocVersaoNomePai") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docversaonomepai = sdt.gxTv_SdtDocumento_Docversaonomepai ;
         }
         if ( sdt.IsDirty("DocOrigem") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docorigem = sdt.gxTv_SdtDocumento_Docorigem ;
         }
         if ( sdt.IsDirty("DocOrigemID") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docorigemid = sdt.gxTv_SdtDocumento_Docorigemid ;
         }
         if ( sdt.IsDirty("DocInsData") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docinsdata = sdt.gxTv_SdtDocumento_Docinsdata ;
         }
         if ( sdt.IsDirty("DocInsHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docinshora = sdt.gxTv_SdtDocumento_Docinshora ;
         }
         if ( sdt.IsDirty("DocInsDataHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docinsdatahora = sdt.gxTv_SdtDocumento_Docinsdatahora ;
         }
         if ( sdt.IsDirty("DocInsUsuID") )
         {
            gxTv_SdtDocumento_Docinsusuid_N = (short)(sdt.gxTv_SdtDocumento_Docinsusuid_N);
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docinsusuid = sdt.gxTv_SdtDocumento_Docinsusuid ;
         }
         if ( sdt.IsDirty("DocUpdData") )
         {
            gxTv_SdtDocumento_Docupddata_N = (short)(sdt.gxTv_SdtDocumento_Docupddata_N);
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docupddata = sdt.gxTv_SdtDocumento_Docupddata ;
         }
         if ( sdt.IsDirty("DocUpdHora") )
         {
            gxTv_SdtDocumento_Docupdhora_N = (short)(sdt.gxTv_SdtDocumento_Docupdhora_N);
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docupdhora = sdt.gxTv_SdtDocumento_Docupdhora ;
         }
         if ( sdt.IsDirty("DocUpdDataHora") )
         {
            gxTv_SdtDocumento_Docupddatahora_N = (short)(sdt.gxTv_SdtDocumento_Docupddatahora_N);
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docupddatahora = sdt.gxTv_SdtDocumento_Docupddatahora ;
         }
         if ( sdt.IsDirty("DocUpdUsuID") )
         {
            gxTv_SdtDocumento_Docupdusuid_N = (short)(sdt.gxTv_SdtDocumento_Docupdusuid_N);
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docupdusuid = sdt.gxTv_SdtDocumento_Docupdusuid ;
         }
         if ( sdt.IsDirty("DocDel") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docdel = sdt.gxTv_SdtDocumento_Docdel ;
         }
         if ( sdt.IsDirty("DocDelDataHora") )
         {
            gxTv_SdtDocumento_Docdeldatahora_N = (short)(sdt.gxTv_SdtDocumento_Docdeldatahora_N);
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docdeldatahora = sdt.gxTv_SdtDocumento_Docdeldatahora ;
         }
         if ( sdt.IsDirty("DocDelData") )
         {
            gxTv_SdtDocumento_Docdeldata_N = (short)(sdt.gxTv_SdtDocumento_Docdeldata_N);
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docdeldata = sdt.gxTv_SdtDocumento_Docdeldata ;
         }
         if ( sdt.IsDirty("DocDelHora") )
         {
            gxTv_SdtDocumento_Docdelhora_N = (short)(sdt.gxTv_SdtDocumento_Docdelhora_N);
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docdelhora = sdt.gxTv_SdtDocumento_Docdelhora ;
         }
         if ( sdt.IsDirty("DocDelUsuID") )
         {
            gxTv_SdtDocumento_Docdelusuid_N = (short)(sdt.gxTv_SdtDocumento_Docdelusuid_N);
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docdelusuid = sdt.gxTv_SdtDocumento_Docdelusuid ;
         }
         if ( sdt.IsDirty("DocDelUsuNome") )
         {
            gxTv_SdtDocumento_Docdelusunome_N = (short)(sdt.gxTv_SdtDocumento_Docdelusunome_N);
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docdelusunome = sdt.gxTv_SdtDocumento_Docdelusunome ;
         }
         if ( sdt.IsDirty("DocNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docnome = sdt.gxTv_SdtDocumento_Docnome ;
         }
         if ( sdt.IsDirty("DocTipoID") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Doctipoid = sdt.gxTv_SdtDocumento_Doctipoid ;
         }
         if ( sdt.IsDirty("DocTipoSigla") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Doctiposigla = sdt.gxTv_SdtDocumento_Doctiposigla ;
         }
         if ( sdt.IsDirty("DocTipoNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Doctiponome = sdt.gxTv_SdtDocumento_Doctiponome ;
         }
         if ( sdt.IsDirty("DocTipoAtivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Doctipoativo = sdt.gxTv_SdtDocumento_Doctipoativo ;
         }
         if ( sdt.IsDirty("DocUltArqSeq") )
         {
            gxTv_SdtDocumento_Docultarqseq_N = (short)(sdt.gxTv_SdtDocumento_Docultarqseq_N);
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docultarqseq = sdt.gxTv_SdtDocumento_Docultarqseq ;
         }
         if ( sdt.IsDirty("DocContrato") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Doccontrato = sdt.gxTv_SdtDocumento_Doccontrato ;
         }
         if ( sdt.IsDirty("DocAssinado") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docassinado = sdt.gxTv_SdtDocumento_Docassinado ;
         }
         if ( sdt.IsDirty("DocAtivo") )
         {
            gxTv_SdtDocumento_Docativo_N = (short)(sdt.gxTv_SdtDocumento_Docativo_N);
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docativo = sdt.gxTv_SdtDocumento_Docativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "DocID" )]
      [  XmlElement( ElementName = "DocID"   )]
      public Guid gxTpr_Docid
      {
         get {
            return gxTv_SdtDocumento_Docid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtDocumento_Docid != value )
            {
               gxTv_SdtDocumento_Mode = "INS";
               this.gxTv_SdtDocumento_Docid_Z_SetNull( );
               this.gxTv_SdtDocumento_Docversao_Z_SetNull( );
               this.gxTv_SdtDocumento_Docversaoidpai_Z_SetNull( );
               this.gxTv_SdtDocumento_Docversaonomepai_Z_SetNull( );
               this.gxTv_SdtDocumento_Docorigem_Z_SetNull( );
               this.gxTv_SdtDocumento_Docorigemid_Z_SetNull( );
               this.gxTv_SdtDocumento_Docinsdata_Z_SetNull( );
               this.gxTv_SdtDocumento_Docinshora_Z_SetNull( );
               this.gxTv_SdtDocumento_Docinsdatahora_Z_SetNull( );
               this.gxTv_SdtDocumento_Docinsusuid_Z_SetNull( );
               this.gxTv_SdtDocumento_Docupddata_Z_SetNull( );
               this.gxTv_SdtDocumento_Docupdhora_Z_SetNull( );
               this.gxTv_SdtDocumento_Docupddatahora_Z_SetNull( );
               this.gxTv_SdtDocumento_Docupdusuid_Z_SetNull( );
               this.gxTv_SdtDocumento_Docdel_Z_SetNull( );
               this.gxTv_SdtDocumento_Docdeldatahora_Z_SetNull( );
               this.gxTv_SdtDocumento_Docdeldata_Z_SetNull( );
               this.gxTv_SdtDocumento_Docdelhora_Z_SetNull( );
               this.gxTv_SdtDocumento_Docdelusuid_Z_SetNull( );
               this.gxTv_SdtDocumento_Docdelusunome_Z_SetNull( );
               this.gxTv_SdtDocumento_Docnome_Z_SetNull( );
               this.gxTv_SdtDocumento_Doctipoid_Z_SetNull( );
               this.gxTv_SdtDocumento_Doctiposigla_Z_SetNull( );
               this.gxTv_SdtDocumento_Doctiponome_Z_SetNull( );
               this.gxTv_SdtDocumento_Doctipoativo_Z_SetNull( );
               this.gxTv_SdtDocumento_Docultarqseq_Z_SetNull( );
               this.gxTv_SdtDocumento_Doccontrato_Z_SetNull( );
               this.gxTv_SdtDocumento_Docassinado_Z_SetNull( );
               this.gxTv_SdtDocumento_Docativo_Z_SetNull( );
            }
            gxTv_SdtDocumento_Docid = value;
            SetDirty("Docid");
         }

      }

      [  SoapElement( ElementName = "DocVersao" )]
      [  XmlElement( ElementName = "DocVersao"   )]
      public short gxTpr_Docversao
      {
         get {
            return gxTv_SdtDocumento_Docversao ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docversao = value;
            SetDirty("Docversao");
         }

      }

      [  SoapElement( ElementName = "DocVersaoIDPai" )]
      [  XmlElement( ElementName = "DocVersaoIDPai"   )]
      public Guid gxTpr_Docversaoidpai
      {
         get {
            return gxTv_SdtDocumento_Docversaoidpai ;
         }

         set {
            gxTv_SdtDocumento_Docversaoidpai_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docversaoidpai = value;
            SetDirty("Docversaoidpai");
         }

      }

      public void gxTv_SdtDocumento_Docversaoidpai_SetNull( )
      {
         gxTv_SdtDocumento_Docversaoidpai_N = 1;
         gxTv_SdtDocumento_Docversaoidpai = Guid.Empty;
         SetDirty("Docversaoidpai");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docversaoidpai_IsNull( )
      {
         return (gxTv_SdtDocumento_Docversaoidpai_N==1) ;
      }

      [  SoapElement( ElementName = "DocVersaoNomePai" )]
      [  XmlElement( ElementName = "DocVersaoNomePai"   )]
      public string gxTpr_Docversaonomepai
      {
         get {
            return gxTv_SdtDocumento_Docversaonomepai ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docversaonomepai = value;
            SetDirty("Docversaonomepai");
         }

      }

      [  SoapElement( ElementName = "DocOrigem" )]
      [  XmlElement( ElementName = "DocOrigem"   )]
      public string gxTpr_Docorigem
      {
         get {
            return gxTv_SdtDocumento_Docorigem ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docorigem = value;
            SetDirty("Docorigem");
         }

      }

      [  SoapElement( ElementName = "DocOrigemID" )]
      [  XmlElement( ElementName = "DocOrigemID"   )]
      public string gxTpr_Docorigemid
      {
         get {
            return gxTv_SdtDocumento_Docorigemid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docorigemid = value;
            SetDirty("Docorigemid");
         }

      }

      [  SoapElement( ElementName = "DocInsData" )]
      [  XmlElement( ElementName = "DocInsData"  , IsNullable=true )]
      public string gxTpr_Docinsdata_Nullable
      {
         get {
            if ( gxTv_SdtDocumento_Docinsdata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocumento_Docinsdata).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocumento_Docinsdata = DateTime.MinValue;
            else
               gxTv_SdtDocumento_Docinsdata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docinsdata
      {
         get {
            return gxTv_SdtDocumento_Docinsdata ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docinsdata = value;
            SetDirty("Docinsdata");
         }

      }

      [  SoapElement( ElementName = "DocInsHora" )]
      [  XmlElement( ElementName = "DocInsHora"  , IsNullable=true )]
      public string gxTpr_Docinshora_Nullable
      {
         get {
            if ( gxTv_SdtDocumento_Docinshora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumento_Docinshora).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumento_Docinshora = DateTime.MinValue;
            else
               gxTv_SdtDocumento_Docinshora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docinshora
      {
         get {
            return gxTv_SdtDocumento_Docinshora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docinshora = value;
            SetDirty("Docinshora");
         }

      }

      [  SoapElement( ElementName = "DocInsDataHora" )]
      [  XmlElement( ElementName = "DocInsDataHora"  , IsNullable=true )]
      public string gxTpr_Docinsdatahora_Nullable
      {
         get {
            if ( gxTv_SdtDocumento_Docinsdatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumento_Docinsdatahora, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumento_Docinsdatahora = DateTime.MinValue;
            else
               gxTv_SdtDocumento_Docinsdatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docinsdatahora
      {
         get {
            return gxTv_SdtDocumento_Docinsdatahora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docinsdatahora = value;
            SetDirty("Docinsdatahora");
         }

      }

      [  SoapElement( ElementName = "DocInsUsuID" )]
      [  XmlElement( ElementName = "DocInsUsuID"   )]
      public string gxTpr_Docinsusuid
      {
         get {
            return gxTv_SdtDocumento_Docinsusuid ;
         }

         set {
            gxTv_SdtDocumento_Docinsusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docinsusuid = value;
            SetDirty("Docinsusuid");
         }

      }

      public void gxTv_SdtDocumento_Docinsusuid_SetNull( )
      {
         gxTv_SdtDocumento_Docinsusuid_N = 1;
         gxTv_SdtDocumento_Docinsusuid = "";
         SetDirty("Docinsusuid");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docinsusuid_IsNull( )
      {
         return (gxTv_SdtDocumento_Docinsusuid_N==1) ;
      }

      [  SoapElement( ElementName = "DocUpdData" )]
      [  XmlElement( ElementName = "DocUpdData"  , IsNullable=true )]
      public string gxTpr_Docupddata_Nullable
      {
         get {
            if ( gxTv_SdtDocumento_Docupddata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocumento_Docupddata).value ;
         }

         set {
            gxTv_SdtDocumento_Docupddata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocumento_Docupddata = DateTime.MinValue;
            else
               gxTv_SdtDocumento_Docupddata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docupddata
      {
         get {
            return gxTv_SdtDocumento_Docupddata ;
         }

         set {
            gxTv_SdtDocumento_Docupddata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docupddata = value;
            SetDirty("Docupddata");
         }

      }

      public void gxTv_SdtDocumento_Docupddata_SetNull( )
      {
         gxTv_SdtDocumento_Docupddata_N = 1;
         gxTv_SdtDocumento_Docupddata = (DateTime)(DateTime.MinValue);
         SetDirty("Docupddata");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docupddata_IsNull( )
      {
         return (gxTv_SdtDocumento_Docupddata_N==1) ;
      }

      [  SoapElement( ElementName = "DocUpdHora" )]
      [  XmlElement( ElementName = "DocUpdHora"  , IsNullable=true )]
      public string gxTpr_Docupdhora_Nullable
      {
         get {
            if ( gxTv_SdtDocumento_Docupdhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumento_Docupdhora).value ;
         }

         set {
            gxTv_SdtDocumento_Docupdhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumento_Docupdhora = DateTime.MinValue;
            else
               gxTv_SdtDocumento_Docupdhora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docupdhora
      {
         get {
            return gxTv_SdtDocumento_Docupdhora ;
         }

         set {
            gxTv_SdtDocumento_Docupdhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docupdhora = value;
            SetDirty("Docupdhora");
         }

      }

      public void gxTv_SdtDocumento_Docupdhora_SetNull( )
      {
         gxTv_SdtDocumento_Docupdhora_N = 1;
         gxTv_SdtDocumento_Docupdhora = (DateTime)(DateTime.MinValue);
         SetDirty("Docupdhora");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docupdhora_IsNull( )
      {
         return (gxTv_SdtDocumento_Docupdhora_N==1) ;
      }

      [  SoapElement( ElementName = "DocUpdDataHora" )]
      [  XmlElement( ElementName = "DocUpdDataHora"  , IsNullable=true )]
      public string gxTpr_Docupddatahora_Nullable
      {
         get {
            if ( gxTv_SdtDocumento_Docupddatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumento_Docupddatahora, null, true).value ;
         }

         set {
            gxTv_SdtDocumento_Docupddatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumento_Docupddatahora = DateTime.MinValue;
            else
               gxTv_SdtDocumento_Docupddatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docupddatahora
      {
         get {
            return gxTv_SdtDocumento_Docupddatahora ;
         }

         set {
            gxTv_SdtDocumento_Docupddatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docupddatahora = value;
            SetDirty("Docupddatahora");
         }

      }

      public void gxTv_SdtDocumento_Docupddatahora_SetNull( )
      {
         gxTv_SdtDocumento_Docupddatahora_N = 1;
         gxTv_SdtDocumento_Docupddatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Docupddatahora");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docupddatahora_IsNull( )
      {
         return (gxTv_SdtDocumento_Docupddatahora_N==1) ;
      }

      [  SoapElement( ElementName = "DocUpdUsuID" )]
      [  XmlElement( ElementName = "DocUpdUsuID"   )]
      public string gxTpr_Docupdusuid
      {
         get {
            return gxTv_SdtDocumento_Docupdusuid ;
         }

         set {
            gxTv_SdtDocumento_Docupdusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docupdusuid = value;
            SetDirty("Docupdusuid");
         }

      }

      public void gxTv_SdtDocumento_Docupdusuid_SetNull( )
      {
         gxTv_SdtDocumento_Docupdusuid_N = 1;
         gxTv_SdtDocumento_Docupdusuid = "";
         SetDirty("Docupdusuid");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docupdusuid_IsNull( )
      {
         return (gxTv_SdtDocumento_Docupdusuid_N==1) ;
      }

      [  SoapElement( ElementName = "DocDel" )]
      [  XmlElement( ElementName = "DocDel"   )]
      public bool gxTpr_Docdel
      {
         get {
            return gxTv_SdtDocumento_Docdel ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docdel = value;
            SetDirty("Docdel");
         }

      }

      [  SoapElement( ElementName = "DocDelDataHora" )]
      [  XmlElement( ElementName = "DocDelDataHora"  , IsNullable=true )]
      public string gxTpr_Docdeldatahora_Nullable
      {
         get {
            if ( gxTv_SdtDocumento_Docdeldatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumento_Docdeldatahora, null, true).value ;
         }

         set {
            gxTv_SdtDocumento_Docdeldatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumento_Docdeldatahora = DateTime.MinValue;
            else
               gxTv_SdtDocumento_Docdeldatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docdeldatahora
      {
         get {
            return gxTv_SdtDocumento_Docdeldatahora ;
         }

         set {
            gxTv_SdtDocumento_Docdeldatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docdeldatahora = value;
            SetDirty("Docdeldatahora");
         }

      }

      public void gxTv_SdtDocumento_Docdeldatahora_SetNull( )
      {
         gxTv_SdtDocumento_Docdeldatahora_N = 1;
         gxTv_SdtDocumento_Docdeldatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Docdeldatahora");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docdeldatahora_IsNull( )
      {
         return (gxTv_SdtDocumento_Docdeldatahora_N==1) ;
      }

      [  SoapElement( ElementName = "DocDelData" )]
      [  XmlElement( ElementName = "DocDelData"  , IsNullable=true )]
      public string gxTpr_Docdeldata_Nullable
      {
         get {
            if ( gxTv_SdtDocumento_Docdeldata == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumento_Docdeldata).value ;
         }

         set {
            gxTv_SdtDocumento_Docdeldata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumento_Docdeldata = DateTime.MinValue;
            else
               gxTv_SdtDocumento_Docdeldata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docdeldata
      {
         get {
            return gxTv_SdtDocumento_Docdeldata ;
         }

         set {
            gxTv_SdtDocumento_Docdeldata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docdeldata = value;
            SetDirty("Docdeldata");
         }

      }

      public void gxTv_SdtDocumento_Docdeldata_SetNull( )
      {
         gxTv_SdtDocumento_Docdeldata_N = 1;
         gxTv_SdtDocumento_Docdeldata = (DateTime)(DateTime.MinValue);
         SetDirty("Docdeldata");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docdeldata_IsNull( )
      {
         return (gxTv_SdtDocumento_Docdeldata_N==1) ;
      }

      [  SoapElement( ElementName = "DocDelHora" )]
      [  XmlElement( ElementName = "DocDelHora"  , IsNullable=true )]
      public string gxTpr_Docdelhora_Nullable
      {
         get {
            if ( gxTv_SdtDocumento_Docdelhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumento_Docdelhora).value ;
         }

         set {
            gxTv_SdtDocumento_Docdelhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumento_Docdelhora = DateTime.MinValue;
            else
               gxTv_SdtDocumento_Docdelhora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docdelhora
      {
         get {
            return gxTv_SdtDocumento_Docdelhora ;
         }

         set {
            gxTv_SdtDocumento_Docdelhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docdelhora = value;
            SetDirty("Docdelhora");
         }

      }

      public void gxTv_SdtDocumento_Docdelhora_SetNull( )
      {
         gxTv_SdtDocumento_Docdelhora_N = 1;
         gxTv_SdtDocumento_Docdelhora = (DateTime)(DateTime.MinValue);
         SetDirty("Docdelhora");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docdelhora_IsNull( )
      {
         return (gxTv_SdtDocumento_Docdelhora_N==1) ;
      }

      [  SoapElement( ElementName = "DocDelUsuID" )]
      [  XmlElement( ElementName = "DocDelUsuID"   )]
      public string gxTpr_Docdelusuid
      {
         get {
            return gxTv_SdtDocumento_Docdelusuid ;
         }

         set {
            gxTv_SdtDocumento_Docdelusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docdelusuid = value;
            SetDirty("Docdelusuid");
         }

      }

      public void gxTv_SdtDocumento_Docdelusuid_SetNull( )
      {
         gxTv_SdtDocumento_Docdelusuid_N = 1;
         gxTv_SdtDocumento_Docdelusuid = "";
         SetDirty("Docdelusuid");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docdelusuid_IsNull( )
      {
         return (gxTv_SdtDocumento_Docdelusuid_N==1) ;
      }

      [  SoapElement( ElementName = "DocDelUsuNome" )]
      [  XmlElement( ElementName = "DocDelUsuNome"   )]
      public string gxTpr_Docdelusunome
      {
         get {
            return gxTv_SdtDocumento_Docdelusunome ;
         }

         set {
            gxTv_SdtDocumento_Docdelusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docdelusunome = value;
            SetDirty("Docdelusunome");
         }

      }

      public void gxTv_SdtDocumento_Docdelusunome_SetNull( )
      {
         gxTv_SdtDocumento_Docdelusunome_N = 1;
         gxTv_SdtDocumento_Docdelusunome = "";
         SetDirty("Docdelusunome");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docdelusunome_IsNull( )
      {
         return (gxTv_SdtDocumento_Docdelusunome_N==1) ;
      }

      [  SoapElement( ElementName = "DocNome" )]
      [  XmlElement( ElementName = "DocNome"   )]
      public string gxTpr_Docnome
      {
         get {
            return gxTv_SdtDocumento_Docnome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docnome = value;
            SetDirty("Docnome");
         }

      }

      [  SoapElement( ElementName = "DocTipoID" )]
      [  XmlElement( ElementName = "DocTipoID"   )]
      public int gxTpr_Doctipoid
      {
         get {
            return gxTv_SdtDocumento_Doctipoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Doctipoid = value;
            SetDirty("Doctipoid");
         }

      }

      [  SoapElement( ElementName = "DocTipoSigla" )]
      [  XmlElement( ElementName = "DocTipoSigla"   )]
      public string gxTpr_Doctiposigla
      {
         get {
            return gxTv_SdtDocumento_Doctiposigla ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Doctiposigla = value;
            SetDirty("Doctiposigla");
         }

      }

      [  SoapElement( ElementName = "DocTipoNome" )]
      [  XmlElement( ElementName = "DocTipoNome"   )]
      public string gxTpr_Doctiponome
      {
         get {
            return gxTv_SdtDocumento_Doctiponome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Doctiponome = value;
            SetDirty("Doctiponome");
         }

      }

      [  SoapElement( ElementName = "DocTipoAtivo" )]
      [  XmlElement( ElementName = "DocTipoAtivo"   )]
      public bool gxTpr_Doctipoativo
      {
         get {
            return gxTv_SdtDocumento_Doctipoativo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Doctipoativo = value;
            SetDirty("Doctipoativo");
         }

      }

      [  SoapElement( ElementName = "DocUltArqSeq" )]
      [  XmlElement( ElementName = "DocUltArqSeq"   )]
      public short gxTpr_Docultarqseq
      {
         get {
            return gxTv_SdtDocumento_Docultarqseq ;
         }

         set {
            gxTv_SdtDocumento_Docultarqseq_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docultarqseq = value;
            SetDirty("Docultarqseq");
         }

      }

      public void gxTv_SdtDocumento_Docultarqseq_SetNull( )
      {
         gxTv_SdtDocumento_Docultarqseq_N = 1;
         gxTv_SdtDocumento_Docultarqseq = 0;
         SetDirty("Docultarqseq");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docultarqseq_IsNull( )
      {
         return (gxTv_SdtDocumento_Docultarqseq_N==1) ;
      }

      [  SoapElement( ElementName = "DocContrato" )]
      [  XmlElement( ElementName = "DocContrato"   )]
      public bool gxTpr_Doccontrato
      {
         get {
            return gxTv_SdtDocumento_Doccontrato ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Doccontrato = value;
            SetDirty("Doccontrato");
         }

      }

      [  SoapElement( ElementName = "DocAssinado" )]
      [  XmlElement( ElementName = "DocAssinado"   )]
      public bool gxTpr_Docassinado
      {
         get {
            return gxTv_SdtDocumento_Docassinado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docassinado = value;
            SetDirty("Docassinado");
         }

      }

      [  SoapElement( ElementName = "DocAtivo" )]
      [  XmlElement( ElementName = "DocAtivo"   )]
      public bool gxTpr_Docativo
      {
         get {
            return gxTv_SdtDocumento_Docativo ;
         }

         set {
            gxTv_SdtDocumento_Docativo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docativo = value;
            SetDirty("Docativo");
         }

      }

      public void gxTv_SdtDocumento_Docativo_SetNull( )
      {
         gxTv_SdtDocumento_Docativo_N = 1;
         gxTv_SdtDocumento_Docativo = false;
         SetDirty("Docativo");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docativo_IsNull( )
      {
         return (gxTv_SdtDocumento_Docativo_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtDocumento_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtDocumento_Mode_SetNull( )
      {
         gxTv_SdtDocumento_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtDocumento_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtDocumento_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtDocumento_Initialized_SetNull( )
      {
         gxTv_SdtDocumento_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtDocumento_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocID_Z" )]
      [  XmlElement( ElementName = "DocID_Z"   )]
      public Guid gxTpr_Docid_Z
      {
         get {
            return gxTv_SdtDocumento_Docid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docid_Z = value;
            SetDirty("Docid_Z");
         }

      }

      public void gxTv_SdtDocumento_Docid_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docid_Z = Guid.Empty;
         SetDirty("Docid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocVersao_Z" )]
      [  XmlElement( ElementName = "DocVersao_Z"   )]
      public short gxTpr_Docversao_Z
      {
         get {
            return gxTv_SdtDocumento_Docversao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docversao_Z = value;
            SetDirty("Docversao_Z");
         }

      }

      public void gxTv_SdtDocumento_Docversao_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docversao_Z = 0;
         SetDirty("Docversao_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docversao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocVersaoIDPai_Z" )]
      [  XmlElement( ElementName = "DocVersaoIDPai_Z"   )]
      public Guid gxTpr_Docversaoidpai_Z
      {
         get {
            return gxTv_SdtDocumento_Docversaoidpai_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docversaoidpai_Z = value;
            SetDirty("Docversaoidpai_Z");
         }

      }

      public void gxTv_SdtDocumento_Docversaoidpai_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docversaoidpai_Z = Guid.Empty;
         SetDirty("Docversaoidpai_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docversaoidpai_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocVersaoNomePai_Z" )]
      [  XmlElement( ElementName = "DocVersaoNomePai_Z"   )]
      public string gxTpr_Docversaonomepai_Z
      {
         get {
            return gxTv_SdtDocumento_Docversaonomepai_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docversaonomepai_Z = value;
            SetDirty("Docversaonomepai_Z");
         }

      }

      public void gxTv_SdtDocumento_Docversaonomepai_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docversaonomepai_Z = "";
         SetDirty("Docversaonomepai_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docversaonomepai_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocOrigem_Z" )]
      [  XmlElement( ElementName = "DocOrigem_Z"   )]
      public string gxTpr_Docorigem_Z
      {
         get {
            return gxTv_SdtDocumento_Docorigem_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docorigem_Z = value;
            SetDirty("Docorigem_Z");
         }

      }

      public void gxTv_SdtDocumento_Docorigem_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docorigem_Z = "";
         SetDirty("Docorigem_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docorigem_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocOrigemID_Z" )]
      [  XmlElement( ElementName = "DocOrigemID_Z"   )]
      public string gxTpr_Docorigemid_Z
      {
         get {
            return gxTv_SdtDocumento_Docorigemid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docorigemid_Z = value;
            SetDirty("Docorigemid_Z");
         }

      }

      public void gxTv_SdtDocumento_Docorigemid_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docorigemid_Z = "";
         SetDirty("Docorigemid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docorigemid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocInsData_Z" )]
      [  XmlElement( ElementName = "DocInsData_Z"  , IsNullable=true )]
      public string gxTpr_Docinsdata_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumento_Docinsdata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocumento_Docinsdata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocumento_Docinsdata_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumento_Docinsdata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docinsdata_Z
      {
         get {
            return gxTv_SdtDocumento_Docinsdata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docinsdata_Z = value;
            SetDirty("Docinsdata_Z");
         }

      }

      public void gxTv_SdtDocumento_Docinsdata_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docinsdata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docinsdata_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docinsdata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocInsHora_Z" )]
      [  XmlElement( ElementName = "DocInsHora_Z"  , IsNullable=true )]
      public string gxTpr_Docinshora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumento_Docinshora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumento_Docinshora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumento_Docinshora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumento_Docinshora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docinshora_Z
      {
         get {
            return gxTv_SdtDocumento_Docinshora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docinshora_Z = value;
            SetDirty("Docinshora_Z");
         }

      }

      public void gxTv_SdtDocumento_Docinshora_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docinshora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docinshora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docinshora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocInsDataHora_Z" )]
      [  XmlElement( ElementName = "DocInsDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Docinsdatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumento_Docinsdatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumento_Docinsdatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumento_Docinsdatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumento_Docinsdatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docinsdatahora_Z
      {
         get {
            return gxTv_SdtDocumento_Docinsdatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docinsdatahora_Z = value;
            SetDirty("Docinsdatahora_Z");
         }

      }

      public void gxTv_SdtDocumento_Docinsdatahora_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docinsdatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docinsdatahora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docinsdatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocInsUsuID_Z" )]
      [  XmlElement( ElementName = "DocInsUsuID_Z"   )]
      public string gxTpr_Docinsusuid_Z
      {
         get {
            return gxTv_SdtDocumento_Docinsusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docinsusuid_Z = value;
            SetDirty("Docinsusuid_Z");
         }

      }

      public void gxTv_SdtDocumento_Docinsusuid_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docinsusuid_Z = "";
         SetDirty("Docinsusuid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docinsusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocUpdData_Z" )]
      [  XmlElement( ElementName = "DocUpdData_Z"  , IsNullable=true )]
      public string gxTpr_Docupddata_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumento_Docupddata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocumento_Docupddata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocumento_Docupddata_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumento_Docupddata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docupddata_Z
      {
         get {
            return gxTv_SdtDocumento_Docupddata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docupddata_Z = value;
            SetDirty("Docupddata_Z");
         }

      }

      public void gxTv_SdtDocumento_Docupddata_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docupddata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docupddata_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docupddata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocUpdHora_Z" )]
      [  XmlElement( ElementName = "DocUpdHora_Z"  , IsNullable=true )]
      public string gxTpr_Docupdhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumento_Docupdhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumento_Docupdhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumento_Docupdhora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumento_Docupdhora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docupdhora_Z
      {
         get {
            return gxTv_SdtDocumento_Docupdhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docupdhora_Z = value;
            SetDirty("Docupdhora_Z");
         }

      }

      public void gxTv_SdtDocumento_Docupdhora_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docupdhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docupdhora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docupdhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocUpdDataHora_Z" )]
      [  XmlElement( ElementName = "DocUpdDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Docupddatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumento_Docupddatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumento_Docupddatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumento_Docupddatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumento_Docupddatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docupddatahora_Z
      {
         get {
            return gxTv_SdtDocumento_Docupddatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docupddatahora_Z = value;
            SetDirty("Docupddatahora_Z");
         }

      }

      public void gxTv_SdtDocumento_Docupddatahora_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docupddatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docupddatahora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docupddatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocUpdUsuID_Z" )]
      [  XmlElement( ElementName = "DocUpdUsuID_Z"   )]
      public string gxTpr_Docupdusuid_Z
      {
         get {
            return gxTv_SdtDocumento_Docupdusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docupdusuid_Z = value;
            SetDirty("Docupdusuid_Z");
         }

      }

      public void gxTv_SdtDocumento_Docupdusuid_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docupdusuid_Z = "";
         SetDirty("Docupdusuid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docupdusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDel_Z" )]
      [  XmlElement( ElementName = "DocDel_Z"   )]
      public bool gxTpr_Docdel_Z
      {
         get {
            return gxTv_SdtDocumento_Docdel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docdel_Z = value;
            SetDirty("Docdel_Z");
         }

      }

      public void gxTv_SdtDocumento_Docdel_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docdel_Z = false;
         SetDirty("Docdel_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docdel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDelDataHora_Z" )]
      [  XmlElement( ElementName = "DocDelDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Docdeldatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumento_Docdeldatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumento_Docdeldatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumento_Docdeldatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumento_Docdeldatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docdeldatahora_Z
      {
         get {
            return gxTv_SdtDocumento_Docdeldatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docdeldatahora_Z = value;
            SetDirty("Docdeldatahora_Z");
         }

      }

      public void gxTv_SdtDocumento_Docdeldatahora_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docdeldatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docdeldatahora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docdeldatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDelData_Z" )]
      [  XmlElement( ElementName = "DocDelData_Z"  , IsNullable=true )]
      public string gxTpr_Docdeldata_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumento_Docdeldata_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumento_Docdeldata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumento_Docdeldata_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumento_Docdeldata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docdeldata_Z
      {
         get {
            return gxTv_SdtDocumento_Docdeldata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docdeldata_Z = value;
            SetDirty("Docdeldata_Z");
         }

      }

      public void gxTv_SdtDocumento_Docdeldata_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docdeldata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docdeldata_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docdeldata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDelHora_Z" )]
      [  XmlElement( ElementName = "DocDelHora_Z"  , IsNullable=true )]
      public string gxTpr_Docdelhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumento_Docdelhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumento_Docdelhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumento_Docdelhora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumento_Docdelhora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docdelhora_Z
      {
         get {
            return gxTv_SdtDocumento_Docdelhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docdelhora_Z = value;
            SetDirty("Docdelhora_Z");
         }

      }

      public void gxTv_SdtDocumento_Docdelhora_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docdelhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docdelhora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docdelhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDelUsuID_Z" )]
      [  XmlElement( ElementName = "DocDelUsuID_Z"   )]
      public string gxTpr_Docdelusuid_Z
      {
         get {
            return gxTv_SdtDocumento_Docdelusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docdelusuid_Z = value;
            SetDirty("Docdelusuid_Z");
         }

      }

      public void gxTv_SdtDocumento_Docdelusuid_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docdelusuid_Z = "";
         SetDirty("Docdelusuid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docdelusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDelUsuNome_Z" )]
      [  XmlElement( ElementName = "DocDelUsuNome_Z"   )]
      public string gxTpr_Docdelusunome_Z
      {
         get {
            return gxTv_SdtDocumento_Docdelusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docdelusunome_Z = value;
            SetDirty("Docdelusunome_Z");
         }

      }

      public void gxTv_SdtDocumento_Docdelusunome_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docdelusunome_Z = "";
         SetDirty("Docdelusunome_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docdelusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocNome_Z" )]
      [  XmlElement( ElementName = "DocNome_Z"   )]
      public string gxTpr_Docnome_Z
      {
         get {
            return gxTv_SdtDocumento_Docnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docnome_Z = value;
            SetDirty("Docnome_Z");
         }

      }

      public void gxTv_SdtDocumento_Docnome_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docnome_Z = "";
         SetDirty("Docnome_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocTipoID_Z" )]
      [  XmlElement( ElementName = "DocTipoID_Z"   )]
      public int gxTpr_Doctipoid_Z
      {
         get {
            return gxTv_SdtDocumento_Doctipoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Doctipoid_Z = value;
            SetDirty("Doctipoid_Z");
         }

      }

      public void gxTv_SdtDocumento_Doctipoid_Z_SetNull( )
      {
         gxTv_SdtDocumento_Doctipoid_Z = 0;
         SetDirty("Doctipoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Doctipoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocTipoSigla_Z" )]
      [  XmlElement( ElementName = "DocTipoSigla_Z"   )]
      public string gxTpr_Doctiposigla_Z
      {
         get {
            return gxTv_SdtDocumento_Doctiposigla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Doctiposigla_Z = value;
            SetDirty("Doctiposigla_Z");
         }

      }

      public void gxTv_SdtDocumento_Doctiposigla_Z_SetNull( )
      {
         gxTv_SdtDocumento_Doctiposigla_Z = "";
         SetDirty("Doctiposigla_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Doctiposigla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocTipoNome_Z" )]
      [  XmlElement( ElementName = "DocTipoNome_Z"   )]
      public string gxTpr_Doctiponome_Z
      {
         get {
            return gxTv_SdtDocumento_Doctiponome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Doctiponome_Z = value;
            SetDirty("Doctiponome_Z");
         }

      }

      public void gxTv_SdtDocumento_Doctiponome_Z_SetNull( )
      {
         gxTv_SdtDocumento_Doctiponome_Z = "";
         SetDirty("Doctiponome_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Doctiponome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocTipoAtivo_Z" )]
      [  XmlElement( ElementName = "DocTipoAtivo_Z"   )]
      public bool gxTpr_Doctipoativo_Z
      {
         get {
            return gxTv_SdtDocumento_Doctipoativo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Doctipoativo_Z = value;
            SetDirty("Doctipoativo_Z");
         }

      }

      public void gxTv_SdtDocumento_Doctipoativo_Z_SetNull( )
      {
         gxTv_SdtDocumento_Doctipoativo_Z = false;
         SetDirty("Doctipoativo_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Doctipoativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocUltArqSeq_Z" )]
      [  XmlElement( ElementName = "DocUltArqSeq_Z"   )]
      public short gxTpr_Docultarqseq_Z
      {
         get {
            return gxTv_SdtDocumento_Docultarqseq_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docultarqseq_Z = value;
            SetDirty("Docultarqseq_Z");
         }

      }

      public void gxTv_SdtDocumento_Docultarqseq_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docultarqseq_Z = 0;
         SetDirty("Docultarqseq_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docultarqseq_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocContrato_Z" )]
      [  XmlElement( ElementName = "DocContrato_Z"   )]
      public bool gxTpr_Doccontrato_Z
      {
         get {
            return gxTv_SdtDocumento_Doccontrato_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Doccontrato_Z = value;
            SetDirty("Doccontrato_Z");
         }

      }

      public void gxTv_SdtDocumento_Doccontrato_Z_SetNull( )
      {
         gxTv_SdtDocumento_Doccontrato_Z = false;
         SetDirty("Doccontrato_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Doccontrato_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocAssinado_Z" )]
      [  XmlElement( ElementName = "DocAssinado_Z"   )]
      public bool gxTpr_Docassinado_Z
      {
         get {
            return gxTv_SdtDocumento_Docassinado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docassinado_Z = value;
            SetDirty("Docassinado_Z");
         }

      }

      public void gxTv_SdtDocumento_Docassinado_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docassinado_Z = false;
         SetDirty("Docassinado_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docassinado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocAtivo_Z" )]
      [  XmlElement( ElementName = "DocAtivo_Z"   )]
      public bool gxTpr_Docativo_Z
      {
         get {
            return gxTv_SdtDocumento_Docativo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docativo_Z = value;
            SetDirty("Docativo_Z");
         }

      }

      public void gxTv_SdtDocumento_Docativo_Z_SetNull( )
      {
         gxTv_SdtDocumento_Docativo_Z = false;
         SetDirty("Docativo_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocVersaoIDPai_N" )]
      [  XmlElement( ElementName = "DocVersaoIDPai_N"   )]
      public short gxTpr_Docversaoidpai_N
      {
         get {
            return gxTv_SdtDocumento_Docversaoidpai_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docversaoidpai_N = value;
            SetDirty("Docversaoidpai_N");
         }

      }

      public void gxTv_SdtDocumento_Docversaoidpai_N_SetNull( )
      {
         gxTv_SdtDocumento_Docversaoidpai_N = 0;
         SetDirty("Docversaoidpai_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docversaoidpai_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocInsUsuID_N" )]
      [  XmlElement( ElementName = "DocInsUsuID_N"   )]
      public short gxTpr_Docinsusuid_N
      {
         get {
            return gxTv_SdtDocumento_Docinsusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docinsusuid_N = value;
            SetDirty("Docinsusuid_N");
         }

      }

      public void gxTv_SdtDocumento_Docinsusuid_N_SetNull( )
      {
         gxTv_SdtDocumento_Docinsusuid_N = 0;
         SetDirty("Docinsusuid_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docinsusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocUpdData_N" )]
      [  XmlElement( ElementName = "DocUpdData_N"   )]
      public short gxTpr_Docupddata_N
      {
         get {
            return gxTv_SdtDocumento_Docupddata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docupddata_N = value;
            SetDirty("Docupddata_N");
         }

      }

      public void gxTv_SdtDocumento_Docupddata_N_SetNull( )
      {
         gxTv_SdtDocumento_Docupddata_N = 0;
         SetDirty("Docupddata_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docupddata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocUpdHora_N" )]
      [  XmlElement( ElementName = "DocUpdHora_N"   )]
      public short gxTpr_Docupdhora_N
      {
         get {
            return gxTv_SdtDocumento_Docupdhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docupdhora_N = value;
            SetDirty("Docupdhora_N");
         }

      }

      public void gxTv_SdtDocumento_Docupdhora_N_SetNull( )
      {
         gxTv_SdtDocumento_Docupdhora_N = 0;
         SetDirty("Docupdhora_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docupdhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocUpdDataHora_N" )]
      [  XmlElement( ElementName = "DocUpdDataHora_N"   )]
      public short gxTpr_Docupddatahora_N
      {
         get {
            return gxTv_SdtDocumento_Docupddatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docupddatahora_N = value;
            SetDirty("Docupddatahora_N");
         }

      }

      public void gxTv_SdtDocumento_Docupddatahora_N_SetNull( )
      {
         gxTv_SdtDocumento_Docupddatahora_N = 0;
         SetDirty("Docupddatahora_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docupddatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocUpdUsuID_N" )]
      [  XmlElement( ElementName = "DocUpdUsuID_N"   )]
      public short gxTpr_Docupdusuid_N
      {
         get {
            return gxTv_SdtDocumento_Docupdusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docupdusuid_N = value;
            SetDirty("Docupdusuid_N");
         }

      }

      public void gxTv_SdtDocumento_Docupdusuid_N_SetNull( )
      {
         gxTv_SdtDocumento_Docupdusuid_N = 0;
         SetDirty("Docupdusuid_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docupdusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDelDataHora_N" )]
      [  XmlElement( ElementName = "DocDelDataHora_N"   )]
      public short gxTpr_Docdeldatahora_N
      {
         get {
            return gxTv_SdtDocumento_Docdeldatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docdeldatahora_N = value;
            SetDirty("Docdeldatahora_N");
         }

      }

      public void gxTv_SdtDocumento_Docdeldatahora_N_SetNull( )
      {
         gxTv_SdtDocumento_Docdeldatahora_N = 0;
         SetDirty("Docdeldatahora_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docdeldatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDelData_N" )]
      [  XmlElement( ElementName = "DocDelData_N"   )]
      public short gxTpr_Docdeldata_N
      {
         get {
            return gxTv_SdtDocumento_Docdeldata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docdeldata_N = value;
            SetDirty("Docdeldata_N");
         }

      }

      public void gxTv_SdtDocumento_Docdeldata_N_SetNull( )
      {
         gxTv_SdtDocumento_Docdeldata_N = 0;
         SetDirty("Docdeldata_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docdeldata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDelHora_N" )]
      [  XmlElement( ElementName = "DocDelHora_N"   )]
      public short gxTpr_Docdelhora_N
      {
         get {
            return gxTv_SdtDocumento_Docdelhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docdelhora_N = value;
            SetDirty("Docdelhora_N");
         }

      }

      public void gxTv_SdtDocumento_Docdelhora_N_SetNull( )
      {
         gxTv_SdtDocumento_Docdelhora_N = 0;
         SetDirty("Docdelhora_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docdelhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDelUsuID_N" )]
      [  XmlElement( ElementName = "DocDelUsuID_N"   )]
      public short gxTpr_Docdelusuid_N
      {
         get {
            return gxTv_SdtDocumento_Docdelusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docdelusuid_N = value;
            SetDirty("Docdelusuid_N");
         }

      }

      public void gxTv_SdtDocumento_Docdelusuid_N_SetNull( )
      {
         gxTv_SdtDocumento_Docdelusuid_N = 0;
         SetDirty("Docdelusuid_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docdelusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDelUsuNome_N" )]
      [  XmlElement( ElementName = "DocDelUsuNome_N"   )]
      public short gxTpr_Docdelusunome_N
      {
         get {
            return gxTv_SdtDocumento_Docdelusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docdelusunome_N = value;
            SetDirty("Docdelusunome_N");
         }

      }

      public void gxTv_SdtDocumento_Docdelusunome_N_SetNull( )
      {
         gxTv_SdtDocumento_Docdelusunome_N = 0;
         SetDirty("Docdelusunome_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docdelusunome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocUltArqSeq_N" )]
      [  XmlElement( ElementName = "DocUltArqSeq_N"   )]
      public short gxTpr_Docultarqseq_N
      {
         get {
            return gxTv_SdtDocumento_Docultarqseq_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docultarqseq_N = value;
            SetDirty("Docultarqseq_N");
         }

      }

      public void gxTv_SdtDocumento_Docultarqseq_N_SetNull( )
      {
         gxTv_SdtDocumento_Docultarqseq_N = 0;
         SetDirty("Docultarqseq_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docultarqseq_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocAtivo_N" )]
      [  XmlElement( ElementName = "DocAtivo_N"   )]
      public short gxTpr_Docativo_N
      {
         get {
            return gxTv_SdtDocumento_Docativo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumento_Docativo_N = value;
            SetDirty("Docativo_N");
         }

      }

      public void gxTv_SdtDocumento_Docativo_N_SetNull( )
      {
         gxTv_SdtDocumento_Docativo_N = 0;
         SetDirty("Docativo_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Docativo_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtDocumento_Docid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtDocumento_Docversaoidpai = Guid.Empty;
         gxTv_SdtDocumento_Docversaonomepai = "";
         gxTv_SdtDocumento_Docorigem = "";
         gxTv_SdtDocumento_Docorigemid = "";
         gxTv_SdtDocumento_Docinsdata = DateTime.MinValue;
         gxTv_SdtDocumento_Docinshora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumento_Docinsdatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumento_Docinsusuid = "";
         gxTv_SdtDocumento_Docupddata = DateTime.MinValue;
         gxTv_SdtDocumento_Docupdhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumento_Docupddatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumento_Docupdusuid = "";
         gxTv_SdtDocumento_Docdel = false;
         gxTv_SdtDocumento_Docdeldatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumento_Docdeldata = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumento_Docdelhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumento_Docdelusuid = "";
         gxTv_SdtDocumento_Docdelusunome = "";
         gxTv_SdtDocumento_Docnome = "";
         gxTv_SdtDocumento_Doctiposigla = "";
         gxTv_SdtDocumento_Doctiponome = "";
         gxTv_SdtDocumento_Doctipoativo = true;
         gxTv_SdtDocumento_Doccontrato = false;
         gxTv_SdtDocumento_Docassinado = false;
         gxTv_SdtDocumento_Docativo = true;
         gxTv_SdtDocumento_Mode = "";
         gxTv_SdtDocumento_Docid_Z = Guid.Empty;
         gxTv_SdtDocumento_Docversaoidpai_Z = Guid.Empty;
         gxTv_SdtDocumento_Docversaonomepai_Z = "";
         gxTv_SdtDocumento_Docorigem_Z = "";
         gxTv_SdtDocumento_Docorigemid_Z = "";
         gxTv_SdtDocumento_Docinsdata_Z = DateTime.MinValue;
         gxTv_SdtDocumento_Docinshora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumento_Docinsdatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumento_Docinsusuid_Z = "";
         gxTv_SdtDocumento_Docupddata_Z = DateTime.MinValue;
         gxTv_SdtDocumento_Docupdhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumento_Docupddatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumento_Docupdusuid_Z = "";
         gxTv_SdtDocumento_Docdeldatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumento_Docdeldata_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumento_Docdelhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumento_Docdelusuid_Z = "";
         gxTv_SdtDocumento_Docdelusunome_Z = "";
         gxTv_SdtDocumento_Docnome_Z = "";
         gxTv_SdtDocumento_Doctiposigla_Z = "";
         gxTv_SdtDocumento_Doctiponome_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "core.documento", "GeneXus.Programs.core.documento_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtDocumento_Docversao ;
      private short gxTv_SdtDocumento_Docultarqseq ;
      private short gxTv_SdtDocumento_Initialized ;
      private short gxTv_SdtDocumento_Docversao_Z ;
      private short gxTv_SdtDocumento_Docultarqseq_Z ;
      private short gxTv_SdtDocumento_Docversaoidpai_N ;
      private short gxTv_SdtDocumento_Docinsusuid_N ;
      private short gxTv_SdtDocumento_Docupddata_N ;
      private short gxTv_SdtDocumento_Docupdhora_N ;
      private short gxTv_SdtDocumento_Docupddatahora_N ;
      private short gxTv_SdtDocumento_Docupdusuid_N ;
      private short gxTv_SdtDocumento_Docdeldatahora_N ;
      private short gxTv_SdtDocumento_Docdeldata_N ;
      private short gxTv_SdtDocumento_Docdelhora_N ;
      private short gxTv_SdtDocumento_Docdelusuid_N ;
      private short gxTv_SdtDocumento_Docdelusunome_N ;
      private short gxTv_SdtDocumento_Docultarqseq_N ;
      private short gxTv_SdtDocumento_Docativo_N ;
      private int gxTv_SdtDocumento_Doctipoid ;
      private int gxTv_SdtDocumento_Doctipoid_Z ;
      private string gxTv_SdtDocumento_Docinsusuid ;
      private string gxTv_SdtDocumento_Docupdusuid ;
      private string gxTv_SdtDocumento_Docdelusuid ;
      private string gxTv_SdtDocumento_Mode ;
      private string gxTv_SdtDocumento_Docinsusuid_Z ;
      private string gxTv_SdtDocumento_Docupdusuid_Z ;
      private string gxTv_SdtDocumento_Docdelusuid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtDocumento_Docinshora ;
      private DateTime gxTv_SdtDocumento_Docinsdatahora ;
      private DateTime gxTv_SdtDocumento_Docupdhora ;
      private DateTime gxTv_SdtDocumento_Docupddatahora ;
      private DateTime gxTv_SdtDocumento_Docdeldatahora ;
      private DateTime gxTv_SdtDocumento_Docdeldata ;
      private DateTime gxTv_SdtDocumento_Docdelhora ;
      private DateTime gxTv_SdtDocumento_Docinshora_Z ;
      private DateTime gxTv_SdtDocumento_Docinsdatahora_Z ;
      private DateTime gxTv_SdtDocumento_Docupdhora_Z ;
      private DateTime gxTv_SdtDocumento_Docupddatahora_Z ;
      private DateTime gxTv_SdtDocumento_Docdeldatahora_Z ;
      private DateTime gxTv_SdtDocumento_Docdeldata_Z ;
      private DateTime gxTv_SdtDocumento_Docdelhora_Z ;
      private DateTime datetime_STZ ;
      private DateTime datetimemil_STZ ;
      private DateTime gxTv_SdtDocumento_Docinsdata ;
      private DateTime gxTv_SdtDocumento_Docupddata ;
      private DateTime gxTv_SdtDocumento_Docinsdata_Z ;
      private DateTime gxTv_SdtDocumento_Docupddata_Z ;
      private bool gxTv_SdtDocumento_Docdel ;
      private bool gxTv_SdtDocumento_Doctipoativo ;
      private bool gxTv_SdtDocumento_Doccontrato ;
      private bool gxTv_SdtDocumento_Docassinado ;
      private bool gxTv_SdtDocumento_Docativo ;
      private bool gxTv_SdtDocumento_Docdel_Z ;
      private bool gxTv_SdtDocumento_Doctipoativo_Z ;
      private bool gxTv_SdtDocumento_Doccontrato_Z ;
      private bool gxTv_SdtDocumento_Docassinado_Z ;
      private bool gxTv_SdtDocumento_Docativo_Z ;
      private string gxTv_SdtDocumento_Docversaonomepai ;
      private string gxTv_SdtDocumento_Docorigem ;
      private string gxTv_SdtDocumento_Docorigemid ;
      private string gxTv_SdtDocumento_Docdelusunome ;
      private string gxTv_SdtDocumento_Docnome ;
      private string gxTv_SdtDocumento_Doctiposigla ;
      private string gxTv_SdtDocumento_Doctiponome ;
      private string gxTv_SdtDocumento_Docversaonomepai_Z ;
      private string gxTv_SdtDocumento_Docorigem_Z ;
      private string gxTv_SdtDocumento_Docorigemid_Z ;
      private string gxTv_SdtDocumento_Docdelusunome_Z ;
      private string gxTv_SdtDocumento_Docnome_Z ;
      private string gxTv_SdtDocumento_Doctiposigla_Z ;
      private string gxTv_SdtDocumento_Doctiponome_Z ;
      private Guid gxTv_SdtDocumento_Docid ;
      private Guid gxTv_SdtDocumento_Docversaoidpai ;
      private Guid gxTv_SdtDocumento_Docid_Z ;
      private Guid gxTv_SdtDocumento_Docversaoidpai_Z ;
   }

   [DataContract(Name = @"core\Documento", Namespace = "agl_tresorygroup")]
   public class SdtDocumento_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtDocumento>
   {
      public SdtDocumento_RESTInterface( ) : base()
      {
      }

      public SdtDocumento_RESTInterface( GeneXus.Programs.core.SdtDocumento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DocID" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Docid
      {
         get {
            return sdt.gxTpr_Docid ;
         }

         set {
            sdt.gxTpr_Docid = value;
         }

      }

      [DataMember( Name = "DocVersao" , Order = 1 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Docversao
      {
         get {
            return sdt.gxTpr_Docversao ;
         }

         set {
            sdt.gxTpr_Docversao = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "DocVersaoIDPai" , Order = 2 )]
      [GxSeudo()]
      public Guid gxTpr_Docversaoidpai
      {
         get {
            return sdt.gxTpr_Docversaoidpai ;
         }

         set {
            sdt.gxTpr_Docversaoidpai = value;
         }

      }

      [DataMember( Name = "DocVersaoNomePai" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Docversaonomepai
      {
         get {
            return sdt.gxTpr_Docversaonomepai ;
         }

         set {
            sdt.gxTpr_Docversaonomepai = value;
         }

      }

      [DataMember( Name = "DocOrigem" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Docorigem
      {
         get {
            return sdt.gxTpr_Docorigem ;
         }

         set {
            sdt.gxTpr_Docorigem = value;
         }

      }

      [DataMember( Name = "DocOrigemID" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Docorigemid
      {
         get {
            return sdt.gxTpr_Docorigemid ;
         }

         set {
            sdt.gxTpr_Docorigemid = value;
         }

      }

      [DataMember( Name = "DocInsData" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Docinsdata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Docinsdata) ;
         }

         set {
            sdt.gxTpr_Docinsdata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "DocInsHora" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Docinshora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Docinshora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Docinshora = GXt_dtime1;
         }

      }

      [DataMember( Name = "DocInsDataHora" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Docinsdatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Docinsdatahora) ;
         }

         set {
            sdt.gxTpr_Docinsdatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "DocInsUsuID" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Docinsusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Docinsusuid) ;
         }

         set {
            sdt.gxTpr_Docinsusuid = value;
         }

      }

      [DataMember( Name = "DocUpdData" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Docupddata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Docupddata) ;
         }

         set {
            sdt.gxTpr_Docupddata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "DocUpdHora" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Docupdhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Docupdhora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Docupdhora = GXt_dtime1;
         }

      }

      [DataMember( Name = "DocUpdDataHora" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Docupddatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Docupddatahora) ;
         }

         set {
            sdt.gxTpr_Docupddatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "DocUpdUsuID" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Docupdusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Docupdusuid) ;
         }

         set {
            sdt.gxTpr_Docupdusuid = value;
         }

      }

      [DataMember( Name = "DocDel" , Order = 14 )]
      [GxSeudo()]
      public bool gxTpr_Docdel
      {
         get {
            return sdt.gxTpr_Docdel ;
         }

         set {
            sdt.gxTpr_Docdel = value;
         }

      }

      [DataMember( Name = "DocDelDataHora" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Docdeldatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Docdeldatahora) ;
         }

         set {
            sdt.gxTpr_Docdeldatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "DocDelData" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Docdeldata
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Docdeldata) ;
         }

         set {
            sdt.gxTpr_Docdeldata = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "DocDelHora" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Docdelhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Docdelhora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Docdelhora = GXt_dtime1;
         }

      }

      [DataMember( Name = "DocDelUsuID" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Docdelusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Docdelusuid) ;
         }

         set {
            sdt.gxTpr_Docdelusuid = value;
         }

      }

      [DataMember( Name = "DocDelUsuNome" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Docdelusunome
      {
         get {
            return sdt.gxTpr_Docdelusunome ;
         }

         set {
            sdt.gxTpr_Docdelusunome = value;
         }

      }

      [DataMember( Name = "DocNome" , Order = 20 )]
      [GxSeudo()]
      public string gxTpr_Docnome
      {
         get {
            return sdt.gxTpr_Docnome ;
         }

         set {
            sdt.gxTpr_Docnome = value;
         }

      }

      [DataMember( Name = "DocTipoID" , Order = 21 )]
      [GxSeudo()]
      public string gxTpr_Doctipoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Doctipoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Doctipoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "DocTipoSigla" , Order = 22 )]
      [GxSeudo()]
      public string gxTpr_Doctiposigla
      {
         get {
            return sdt.gxTpr_Doctiposigla ;
         }

         set {
            sdt.gxTpr_Doctiposigla = value;
         }

      }

      [DataMember( Name = "DocTipoNome" , Order = 23 )]
      [GxSeudo()]
      public string gxTpr_Doctiponome
      {
         get {
            return sdt.gxTpr_Doctiponome ;
         }

         set {
            sdt.gxTpr_Doctiponome = value;
         }

      }

      [DataMember( Name = "DocTipoAtivo" , Order = 24 )]
      [GxSeudo()]
      public bool gxTpr_Doctipoativo
      {
         get {
            return sdt.gxTpr_Doctipoativo ;
         }

         set {
            sdt.gxTpr_Doctipoativo = value;
         }

      }

      [DataMember( Name = "DocUltArqSeq" , Order = 25 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Docultarqseq
      {
         get {
            return sdt.gxTpr_Docultarqseq ;
         }

         set {
            sdt.gxTpr_Docultarqseq = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "DocContrato" , Order = 26 )]
      [GxSeudo()]
      public bool gxTpr_Doccontrato
      {
         get {
            return sdt.gxTpr_Doccontrato ;
         }

         set {
            sdt.gxTpr_Doccontrato = value;
         }

      }

      [DataMember( Name = "DocAssinado" , Order = 27 )]
      [GxSeudo()]
      public bool gxTpr_Docassinado
      {
         get {
            return sdt.gxTpr_Docassinado ;
         }

         set {
            sdt.gxTpr_Docassinado = value;
         }

      }

      [DataMember( Name = "DocAtivo" , Order = 28 )]
      [GxSeudo()]
      public bool gxTpr_Docativo
      {
         get {
            return sdt.gxTpr_Docativo ;
         }

         set {
            sdt.gxTpr_Docativo = value;
         }

      }

      public GeneXus.Programs.core.SdtDocumento sdt
      {
         get {
            return (GeneXus.Programs.core.SdtDocumento)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new GeneXus.Programs.core.SdtDocumento() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 29 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
      private DateTime GXt_dtime1 ;
   }

   [DataContract(Name = @"core\Documento", Namespace = "agl_tresorygroup")]
   public class SdtDocumento_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtDocumento>
   {
      public SdtDocumento_RESTLInterface( ) : base()
      {
      }

      public SdtDocumento_RESTLInterface( GeneXus.Programs.core.SdtDocumento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DocNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Docnome
      {
         get {
            return sdt.gxTpr_Docnome ;
         }

         set {
            sdt.gxTpr_Docnome = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public GeneXus.Programs.core.SdtDocumento sdt
      {
         get {
            return (GeneXus.Programs.core.SdtDocumento)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new GeneXus.Programs.core.SdtDocumento() ;
         }
      }

   }

}
