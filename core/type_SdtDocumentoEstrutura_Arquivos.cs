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
   [XmlRoot(ElementName = "DocumentoEstrutura.Arquivos" )]
   [XmlType(TypeName =  "DocumentoEstrutura.Arquivos" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class SdtDocumentoEstrutura_Arquivos : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtDocumentoEstrutura_Arquivos( )
      {
      }

      public SdtDocumentoEstrutura_Arquivos( IGxContext context )
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

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"DocArqSeq", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Arquivos");
         metadata.Set("BT", "tb_documento_arquivo");
         metadata.Set("PK", "[ \"DocArqSeq\" ]");
         metadata.Set("PKAssigned", "[ \"DocArqSeq\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"DocID\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Docarqseq_Z");
         state.Add("gxTpr_Docarqinsdata_Z_Nullable");
         state.Add("gxTpr_Docarqinshora_Z_Nullable");
         state.Add("gxTpr_Docarqinsdatahora_Z_Nullable");
         state.Add("gxTpr_Docarqinsusuid_Z");
         state.Add("gxTpr_Docarqupddata_Z_Nullable");
         state.Add("gxTpr_Docarqupdhora_Z_Nullable");
         state.Add("gxTpr_Docarqupddatahora_Z_Nullable");
         state.Add("gxTpr_Docarqusuid_Z");
         state.Add("gxTpr_Docarqdel_Z");
         state.Add("gxTpr_Docarqdeldata_Z_Nullable");
         state.Add("gxTpr_Docarqdeldatahora_Z_Nullable");
         state.Add("gxTpr_Docarqdelusuid_Z");
         state.Add("gxTpr_Docarqconteudonome_Z");
         state.Add("gxTpr_Docarqconteudoextensao_Z");
         state.Add("gxTpr_Docarqobservacao_Z");
         state.Add("gxTpr_Docarqarmexterno_Z");
         state.Add("gxTpr_Docarqarmexternopath_Z");
         state.Add("gxTpr_Docarqinsusuid_N");
         state.Add("gxTpr_Docarqupddata_N");
         state.Add("gxTpr_Docarqupdhora_N");
         state.Add("gxTpr_Docarqupddatahora_N");
         state.Add("gxTpr_Docarqusuid_N");
         state.Add("gxTpr_Docarqdeldata_N");
         state.Add("gxTpr_Docarqdeldatahora_N");
         state.Add("gxTpr_Docarqdelusuid_N");
         state.Add("gxTpr_Docarqconteudo_N");
         state.Add("gxTpr_Docarqobservacao_N");
         state.Add("gxTpr_Docarqarmexternopath_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos sdt;
         sdt = (GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos)(source);
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqseq = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqseq ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdel = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdel ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudonome = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudonome ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudoextensao = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudoextensao ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexterno = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexterno ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Mode = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Mode ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Modified = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Modified ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Initialized = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Initialized ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqseq_Z = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqseq_Z ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata_Z = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata_Z ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora_Z = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora_Z ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora_Z = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora_Z ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_Z = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_Z ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_Z = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_Z ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_Z = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_Z ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_Z = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_Z ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_Z = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_Z ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdel_Z = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdel_Z ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_Z = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_Z ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_Z = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_Z ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_Z = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_Z ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudonome_Z = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudonome_Z ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudoextensao_Z = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudoextensao_Z ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_Z = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_Z ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexterno_Z = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexterno_Z ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_Z = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_Z ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_N = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_N ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_N = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_N ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_N = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_N ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_N = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_N ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_N = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_N ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_N = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_N ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_N = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_N ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_N = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_N ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo_N = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo_N ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_N = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_N ;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_N = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_N ;
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
         AddObjectProperty("DocArqSeq", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqseq, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("DocArqInsData", sDateCnv, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora;
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
         AddObjectProperty("DocArqInsHora", sDateCnv, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora;
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
         AddObjectProperty("DocArqInsDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DocArqInsUsuID", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid, false, includeNonInitialized);
         AddObjectProperty("DocArqInsUsuID_N", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("DocArqUpdData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DocArqUpdData_N", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora;
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
         AddObjectProperty("DocArqUpdHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DocArqUpdHora_N", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_N, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora;
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
         AddObjectProperty("DocArqUpdDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DocArqUpdDataHora_N", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_N, false, includeNonInitialized);
         AddObjectProperty("DocArqUsuID", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid, false, includeNonInitialized);
         AddObjectProperty("DocArqUsuID_N", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_N, false, includeNonInitialized);
         AddObjectProperty("DocArqDel", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdel, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata;
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
         AddObjectProperty("DocArqDelData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DocArqDelData_N", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_N, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora;
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
         AddObjectProperty("DocArqDelDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DocArqDelDataHora_N", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_N, false, includeNonInitialized);
         AddObjectProperty("DocArqDelUsuID", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid, false, includeNonInitialized);
         AddObjectProperty("DocArqDelUsuID_N", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_N, false, includeNonInitialized);
         AddObjectProperty("DocArqConteudo", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo, false, includeNonInitialized);
         AddObjectProperty("DocArqConteudo_N", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo_N, false, includeNonInitialized);
         AddObjectProperty("DocArqConteudoNome", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudonome, false, includeNonInitialized);
         AddObjectProperty("DocArqConteudoExtensao", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudoextensao, false, includeNonInitialized);
         AddObjectProperty("DocArqObservacao", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao, false, includeNonInitialized);
         AddObjectProperty("DocArqObservacao_N", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_N, false, includeNonInitialized);
         AddObjectProperty("DocArqArmExterno", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexterno, false, includeNonInitialized);
         AddObjectProperty("DocArqArmExternoPath", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath, false, includeNonInitialized);
         AddObjectProperty("DocArqArmExternoPath_N", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtDocumentoEstrutura_Arquivos_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtDocumentoEstrutura_Arquivos_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtDocumentoEstrutura_Arquivos_Initialized, false, includeNonInitialized);
            AddObjectProperty("DocArqSeq_Z", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqseq_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("DocArqInsData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora_Z;
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
            AddObjectProperty("DocArqInsHora_Z", sDateCnv, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora_Z;
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
            AddObjectProperty("DocArqInsDataHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("DocArqInsUsuID_Z", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("DocArqUpdData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_Z;
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
            AddObjectProperty("DocArqUpdHora_Z", sDateCnv, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_Z;
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
            AddObjectProperty("DocArqUpdDataHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("DocArqUsuID_Z", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_Z, false, includeNonInitialized);
            AddObjectProperty("DocArqDel_Z", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdel_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_Z;
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
            AddObjectProperty("DocArqDelData_Z", sDateCnv, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_Z;
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
            AddObjectProperty("DocArqDelDataHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("DocArqDelUsuID_Z", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_Z, false, includeNonInitialized);
            AddObjectProperty("DocArqConteudoNome_Z", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudonome_Z, false, includeNonInitialized);
            AddObjectProperty("DocArqConteudoExtensao_Z", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudoextensao_Z, false, includeNonInitialized);
            AddObjectProperty("DocArqObservacao_Z", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_Z, false, includeNonInitialized);
            AddObjectProperty("DocArqArmExterno_Z", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexterno_Z, false, includeNonInitialized);
            AddObjectProperty("DocArqArmExternoPath_Z", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_Z, false, includeNonInitialized);
            AddObjectProperty("DocArqInsUsuID_N", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_N, false, includeNonInitialized);
            AddObjectProperty("DocArqUpdData_N", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_N, false, includeNonInitialized);
            AddObjectProperty("DocArqUpdHora_N", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_N, false, includeNonInitialized);
            AddObjectProperty("DocArqUpdDataHora_N", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_N, false, includeNonInitialized);
            AddObjectProperty("DocArqUsuID_N", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_N, false, includeNonInitialized);
            AddObjectProperty("DocArqDelData_N", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_N, false, includeNonInitialized);
            AddObjectProperty("DocArqDelDataHora_N", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_N, false, includeNonInitialized);
            AddObjectProperty("DocArqDelUsuID_N", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_N, false, includeNonInitialized);
            AddObjectProperty("DocArqConteudo_N", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo_N, false, includeNonInitialized);
            AddObjectProperty("DocArqObservacao_N", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_N, false, includeNonInitialized);
            AddObjectProperty("DocArqArmExternoPath_N", gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos sdt )
      {
         if ( sdt.IsDirty("DocArqSeq") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqseq = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqseq ;
         }
         if ( sdt.IsDirty("DocArqInsData") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata ;
         }
         if ( sdt.IsDirty("DocArqInsHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora ;
         }
         if ( sdt.IsDirty("DocArqInsDataHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora ;
         }
         if ( sdt.IsDirty("DocArqInsUsuID") )
         {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_N = (short)(sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid ;
         }
         if ( sdt.IsDirty("DocArqUpdData") )
         {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_N = (short)(sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata ;
         }
         if ( sdt.IsDirty("DocArqUpdHora") )
         {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_N = (short)(sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora ;
         }
         if ( sdt.IsDirty("DocArqUpdDataHora") )
         {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_N = (short)(sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora ;
         }
         if ( sdt.IsDirty("DocArqUsuID") )
         {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_N = (short)(sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid ;
         }
         if ( sdt.IsDirty("DocArqDel") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdel = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdel ;
         }
         if ( sdt.IsDirty("DocArqDelData") )
         {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_N = (short)(sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata ;
         }
         if ( sdt.IsDirty("DocArqDelDataHora") )
         {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_N = (short)(sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora ;
         }
         if ( sdt.IsDirty("DocArqDelUsuID") )
         {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_N = (short)(sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid ;
         }
         if ( sdt.IsDirty("DocArqConteudo") )
         {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo_N = (short)(sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo ;
         }
         if ( sdt.IsDirty("DocArqConteudoNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudonome = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudonome ;
         }
         if ( sdt.IsDirty("DocArqConteudoExtensao") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudoextensao = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudoextensao ;
         }
         if ( sdt.IsDirty("DocArqObservacao") )
         {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_N = (short)(sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao ;
         }
         if ( sdt.IsDirty("DocArqArmExterno") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexterno = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexterno ;
         }
         if ( sdt.IsDirty("DocArqArmExternoPath") )
         {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_N = (short)(sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath = sdt.gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "DocArqSeq" )]
      [  XmlElement( ElementName = "DocArqSeq"   )]
      public short gxTpr_Docarqseq
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqseq ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqseq = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqseq");
         }

      }

      [  SoapElement( ElementName = "DocArqInsData" )]
      [  XmlElement( ElementName = "DocArqInsData"  , IsNullable=true )]
      public string gxTpr_Docarqinsdata_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata = DateTime.Parse( value);
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqinsdata
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqinsdata");
         }

      }

      [  SoapElement( ElementName = "DocArqInsHora" )]
      [  XmlElement( ElementName = "DocArqInsHora"  , IsNullable=true )]
      public string gxTpr_Docarqinshora_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora = DateTime.Parse( value);
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqinshora
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqinshora");
         }

      }

      [  SoapElement( ElementName = "DocArqInsDataHora" )]
      [  XmlElement( ElementName = "DocArqInsDataHora"  , IsNullable=true )]
      public string gxTpr_Docarqinsdatahora_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora = DateTime.Parse( value);
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqinsdatahora
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqinsdatahora");
         }

      }

      [  SoapElement( ElementName = "DocArqInsUsuID" )]
      [  XmlElement( ElementName = "DocArqInsUsuID"   )]
      public string gxTpr_Docarqinsusuid
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqinsusuid");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_N = 1;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid = "";
         SetDirty("Docarqinsusuid");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_IsNull( )
      {
         return (gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_N==1) ;
      }

      [  SoapElement( ElementName = "DocArqUpdData" )]
      [  XmlElement( ElementName = "DocArqUpdData"  , IsNullable=true )]
      public string gxTpr_Docarqupddata_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata).value ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata = DateTime.Parse( value);
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqupddata
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqupddata");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_N = 1;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqupddata");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_IsNull( )
      {
         return (gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_N==1) ;
      }

      [  SoapElement( ElementName = "DocArqUpdHora" )]
      [  XmlElement( ElementName = "DocArqUpdHora"  , IsNullable=true )]
      public string gxTpr_Docarqupdhora_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora).value ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora = DateTime.Parse( value);
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqupdhora
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqupdhora");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_N = 1;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqupdhora");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_IsNull( )
      {
         return (gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_N==1) ;
      }

      [  SoapElement( ElementName = "DocArqUpdDataHora" )]
      [  XmlElement( ElementName = "DocArqUpdDataHora"  , IsNullable=true )]
      public string gxTpr_Docarqupddatahora_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora, null, true).value ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora = DateTime.Parse( value);
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqupddatahora
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqupddatahora");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_N = 1;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqupddatahora");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_IsNull( )
      {
         return (gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_N==1) ;
      }

      [  SoapElement( ElementName = "DocArqUsuID" )]
      [  XmlElement( ElementName = "DocArqUsuID"   )]
      public string gxTpr_Docarqusuid
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqusuid");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_N = 1;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid = "";
         SetDirty("Docarqusuid");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_IsNull( )
      {
         return (gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_N==1) ;
      }

      [  SoapElement( ElementName = "DocArqDel" )]
      [  XmlElement( ElementName = "DocArqDel"   )]
      public bool gxTpr_Docarqdel
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdel ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdel = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqdel");
         }

      }

      [  SoapElement( ElementName = "DocArqDelData" )]
      [  XmlElement( ElementName = "DocArqDelData"  , IsNullable=true )]
      public string gxTpr_Docarqdeldata_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata).value ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata = DateTime.Parse( value);
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqdeldata
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqdeldata");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_N = 1;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqdeldata");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_IsNull( )
      {
         return (gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_N==1) ;
      }

      [  SoapElement( ElementName = "DocArqDelDataHora" )]
      [  XmlElement( ElementName = "DocArqDelDataHora"  , IsNullable=true )]
      public string gxTpr_Docarqdeldatahora_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora, null, true).value ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora = DateTime.Parse( value);
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqdeldatahora
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqdeldatahora");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_N = 1;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqdeldatahora");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_IsNull( )
      {
         return (gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_N==1) ;
      }

      [  SoapElement( ElementName = "DocArqDelUsuID" )]
      [  XmlElement( ElementName = "DocArqDelUsuID"   )]
      public string gxTpr_Docarqdelusuid
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqdelusuid");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_N = 1;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid = "";
         SetDirty("Docarqdelusuid");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_IsNull( )
      {
         return (gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_N==1) ;
      }

      [  SoapElement( ElementName = "DocArqConteudo" )]
      [  XmlElement( ElementName = "DocArqConteudo"   )]
      [GxUpload()]
      public byte[] gxTpr_Docarqconteudo_Blob
      {
         get {
            IGxContext context = this.context == null ? new GxContext() : this.context;
            return context.FileToByteArray( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo) ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo_N = 0;
            sdtIsNull = 0;
            IGxContext context = this.context == null ? new GxContext() : this.context;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo=context.FileFromByteArray( value) ;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
         }

      }

      [XmlIgnore]
      [GxUpload()]
      public string gxTpr_Docarqconteudo
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqconteudo");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo_SetBlob( string blob ,
                                                                              string fileName ,
                                                                              string fileType )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo = blob;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudonome = fileName;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudoextensao = fileType;
         return  ;
      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo_N = 1;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo = "";
         SetDirty("Docarqconteudo");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo_IsNull( )
      {
         return (gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo_N==1) ;
      }

      [  SoapElement( ElementName = "DocArqConteudoNome" )]
      [  XmlElement( ElementName = "DocArqConteudoNome"   )]
      public string gxTpr_Docarqconteudonome
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudonome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudonome = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqconteudonome");
         }

      }

      [  SoapElement( ElementName = "DocArqConteudoExtensao" )]
      [  XmlElement( ElementName = "DocArqConteudoExtensao"   )]
      public string gxTpr_Docarqconteudoextensao
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudoextensao ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudoextensao = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqconteudoextensao");
         }

      }

      [  SoapElement( ElementName = "DocArqObservacao" )]
      [  XmlElement( ElementName = "DocArqObservacao"   )]
      public string gxTpr_Docarqobservacao
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqobservacao");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_N = 1;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao = "";
         SetDirty("Docarqobservacao");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_IsNull( )
      {
         return (gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_N==1) ;
      }

      [  SoapElement( ElementName = "DocArqArmExterno" )]
      [  XmlElement( ElementName = "DocArqArmExterno"   )]
      public bool gxTpr_Docarqarmexterno
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexterno ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexterno = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqarmexterno");
         }

      }

      [  SoapElement( ElementName = "DocArqArmExternoPath" )]
      [  XmlElement( ElementName = "DocArqArmExternoPath"   )]
      public string gxTpr_Docarqarmexternopath
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqarmexternopath");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_N = 1;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath = "";
         SetDirty("Docarqarmexternopath");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_IsNull( )
      {
         return (gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Mode_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Modified_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Initialized = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Initialized_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqSeq_Z" )]
      [  XmlElement( ElementName = "DocArqSeq_Z"   )]
      public short gxTpr_Docarqseq_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqseq_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqseq_Z = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqseq_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqseq_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqseq_Z = 0;
         SetDirty("Docarqseq_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqseq_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqInsData_Z" )]
      [  XmlElement( ElementName = "DocArqInsData_Z"  , IsNullable=true )]
      public string gxTpr_Docarqinsdata_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata_Z = DateTime.Parse( value);
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqinsdata_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata_Z = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqinsdata_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqinsdata_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqInsHora_Z" )]
      [  XmlElement( ElementName = "DocArqInsHora_Z"  , IsNullable=true )]
      public string gxTpr_Docarqinshora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora_Z = DateTime.Parse( value);
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqinshora_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora_Z = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqinshora_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqinshora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqInsDataHora_Z" )]
      [  XmlElement( ElementName = "DocArqInsDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Docarqinsdatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora_Z = DateTime.Parse( value);
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqinsdatahora_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora_Z = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqinsdatahora_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqinsdatahora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqInsUsuID_Z" )]
      [  XmlElement( ElementName = "DocArqInsUsuID_Z"   )]
      public string gxTpr_Docarqinsusuid_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_Z = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqinsusuid_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_Z = "";
         SetDirty("Docarqinsusuid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqUpdData_Z" )]
      [  XmlElement( ElementName = "DocArqUpdData_Z"  , IsNullable=true )]
      public string gxTpr_Docarqupddata_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_Z = DateTime.Parse( value);
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqupddata_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_Z = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqupddata_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqupddata_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqUpdHora_Z" )]
      [  XmlElement( ElementName = "DocArqUpdHora_Z"  , IsNullable=true )]
      public string gxTpr_Docarqupdhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_Z = DateTime.Parse( value);
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqupdhora_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_Z = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqupdhora_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqupdhora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqUpdDataHora_Z" )]
      [  XmlElement( ElementName = "DocArqUpdDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Docarqupddatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_Z = DateTime.Parse( value);
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqupddatahora_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_Z = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqupddatahora_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqupddatahora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqUsuID_Z" )]
      [  XmlElement( ElementName = "DocArqUsuID_Z"   )]
      public string gxTpr_Docarqusuid_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_Z = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqusuid_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_Z = "";
         SetDirty("Docarqusuid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqDel_Z" )]
      [  XmlElement( ElementName = "DocArqDel_Z"   )]
      public bool gxTpr_Docarqdel_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdel_Z = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqdel_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdel_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdel_Z = false;
         SetDirty("Docarqdel_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqDelData_Z" )]
      [  XmlElement( ElementName = "DocArqDelData_Z"  , IsNullable=true )]
      public string gxTpr_Docarqdeldata_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_Z = DateTime.Parse( value);
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqdeldata_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_Z = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqdeldata_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqdeldata_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqDelDataHora_Z" )]
      [  XmlElement( ElementName = "DocArqDelDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Docarqdeldatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_Z = DateTime.Parse( value);
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqdeldatahora_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_Z = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqdeldatahora_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqdeldatahora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqDelUsuID_Z" )]
      [  XmlElement( ElementName = "DocArqDelUsuID_Z"   )]
      public string gxTpr_Docarqdelusuid_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_Z = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqdelusuid_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_Z = "";
         SetDirty("Docarqdelusuid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqConteudoNome_Z" )]
      [  XmlElement( ElementName = "DocArqConteudoNome_Z"   )]
      public string gxTpr_Docarqconteudonome_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudonome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudonome_Z = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqconteudonome_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudonome_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudonome_Z = "";
         SetDirty("Docarqconteudonome_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqConteudoExtensao_Z" )]
      [  XmlElement( ElementName = "DocArqConteudoExtensao_Z"   )]
      public string gxTpr_Docarqconteudoextensao_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudoextensao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudoextensao_Z = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqconteudoextensao_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudoextensao_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudoextensao_Z = "";
         SetDirty("Docarqconteudoextensao_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudoextensao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqObservacao_Z" )]
      [  XmlElement( ElementName = "DocArqObservacao_Z"   )]
      public string gxTpr_Docarqobservacao_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_Z = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqobservacao_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_Z = "";
         SetDirty("Docarqobservacao_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqArmExterno_Z" )]
      [  XmlElement( ElementName = "DocArqArmExterno_Z"   )]
      public bool gxTpr_Docarqarmexterno_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexterno_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexterno_Z = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqarmexterno_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexterno_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexterno_Z = false;
         SetDirty("Docarqarmexterno_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexterno_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqArmExternoPath_Z" )]
      [  XmlElement( ElementName = "DocArqArmExternoPath_Z"   )]
      public string gxTpr_Docarqarmexternopath_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_Z = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqarmexternopath_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_Z = "";
         SetDirty("Docarqarmexternopath_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqInsUsuID_N" )]
      [  XmlElement( ElementName = "DocArqInsUsuID_N"   )]
      public short gxTpr_Docarqinsusuid_N
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_N = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqinsusuid_N");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_N_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_N = 0;
         SetDirty("Docarqinsusuid_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqUpdData_N" )]
      [  XmlElement( ElementName = "DocArqUpdData_N"   )]
      public short gxTpr_Docarqupddata_N
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_N = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqupddata_N");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_N_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_N = 0;
         SetDirty("Docarqupddata_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqUpdHora_N" )]
      [  XmlElement( ElementName = "DocArqUpdHora_N"   )]
      public short gxTpr_Docarqupdhora_N
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_N = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqupdhora_N");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_N_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_N = 0;
         SetDirty("Docarqupdhora_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqUpdDataHora_N" )]
      [  XmlElement( ElementName = "DocArqUpdDataHora_N"   )]
      public short gxTpr_Docarqupddatahora_N
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_N = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqupddatahora_N");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_N_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_N = 0;
         SetDirty("Docarqupddatahora_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqUsuID_N" )]
      [  XmlElement( ElementName = "DocArqUsuID_N"   )]
      public short gxTpr_Docarqusuid_N
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_N = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqusuid_N");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_N_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_N = 0;
         SetDirty("Docarqusuid_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqDelData_N" )]
      [  XmlElement( ElementName = "DocArqDelData_N"   )]
      public short gxTpr_Docarqdeldata_N
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_N = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqdeldata_N");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_N_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_N = 0;
         SetDirty("Docarqdeldata_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqDelDataHora_N" )]
      [  XmlElement( ElementName = "DocArqDelDataHora_N"   )]
      public short gxTpr_Docarqdeldatahora_N
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_N = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqdeldatahora_N");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_N_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_N = 0;
         SetDirty("Docarqdeldatahora_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqDelUsuID_N" )]
      [  XmlElement( ElementName = "DocArqDelUsuID_N"   )]
      public short gxTpr_Docarqdelusuid_N
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_N = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqdelusuid_N");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_N_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_N = 0;
         SetDirty("Docarqdelusuid_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqConteudo_N" )]
      [  XmlElement( ElementName = "DocArqConteudo_N"   )]
      public short gxTpr_Docarqconteudo_N
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo_N = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqconteudo_N");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo_N_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo_N = 0;
         SetDirty("Docarqconteudo_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqObservacao_N" )]
      [  XmlElement( ElementName = "DocArqObservacao_N"   )]
      public short gxTpr_Docarqobservacao_N
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_N = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqobservacao_N");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_N_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_N = 0;
         SetDirty("Docarqobservacao_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqArmExternoPath_N" )]
      [  XmlElement( ElementName = "DocArqArmExternoPath_N"   )]
      public short gxTpr_Docarqarmexternopath_N
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_N = value;
            gxTv_SdtDocumentoEstrutura_Arquivos_Modified = 1;
            SetDirty("Docarqarmexternopath_N");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_N_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_N = 0;
         SetDirty("Docarqarmexternopath_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata = DateTime.MinValue;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid = "";
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata = DateTime.MinValue;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid = "";
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdel = false;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid = "";
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo = "";
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudonome = "";
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudoextensao = "";
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao = "";
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexterno = false;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath = "";
         gxTv_SdtDocumentoEstrutura_Arquivos_Mode = "";
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata_Z = DateTime.MinValue;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_Z = "";
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_Z = DateTime.MinValue;
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_Z = "";
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_Z = "";
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudonome_Z = "";
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudoextensao_Z = "";
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_Z = "";
         gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtDocumentoEstrutura_Arquivos_Docarqseq ;
      private short sdtIsNull ;
      private short gxTv_SdtDocumentoEstrutura_Arquivos_Modified ;
      private short gxTv_SdtDocumentoEstrutura_Arquivos_Initialized ;
      private short gxTv_SdtDocumentoEstrutura_Arquivos_Docarqseq_Z ;
      private short gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_N ;
      private short gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_N ;
      private short gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_N ;
      private short gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_N ;
      private short gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_N ;
      private short gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_N ;
      private short gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_N ;
      private short gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_N ;
      private short gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo_N ;
      private short gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_N ;
      private short gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_N ;
      private string gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid ;
      private string gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid ;
      private string gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid ;
      private string gxTv_SdtDocumentoEstrutura_Arquivos_Mode ;
      private string gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsusuid_Z ;
      private string gxTv_SdtDocumentoEstrutura_Arquivos_Docarqusuid_Z ;
      private string gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdelusuid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora ;
      private DateTime gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora ;
      private DateTime gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora ;
      private DateTime gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora ;
      private DateTime gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata ;
      private DateTime gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora ;
      private DateTime gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinshora_Z ;
      private DateTime gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdatahora_Z ;
      private DateTime gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupdhora_Z ;
      private DateTime gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddatahora_Z ;
      private DateTime gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldata_Z ;
      private DateTime gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdeldatahora_Z ;
      private DateTime datetime_STZ ;
      private DateTime datetimemil_STZ ;
      private DateTime gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata ;
      private DateTime gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata ;
      private DateTime gxTv_SdtDocumentoEstrutura_Arquivos_Docarqinsdata_Z ;
      private DateTime gxTv_SdtDocumentoEstrutura_Arquivos_Docarqupddata_Z ;
      private bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdel ;
      private bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexterno ;
      private bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqdel_Z ;
      private bool gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexterno_Z ;
      private string gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudonome ;
      private string gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudoextensao ;
      private string gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao ;
      private string gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath ;
      private string gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudonome_Z ;
      private string gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudoextensao_Z ;
      private string gxTv_SdtDocumentoEstrutura_Arquivos_Docarqobservacao_Z ;
      private string gxTv_SdtDocumentoEstrutura_Arquivos_Docarqarmexternopath_Z ;
      private string gxTv_SdtDocumentoEstrutura_Arquivos_Docarqconteudo ;
   }

   [DataContract(Name = @"core\DocumentoEstrutura.Arquivos", Namespace = "agl_tresorygroup")]
   public class SdtDocumentoEstrutura_Arquivos_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos>
   {
      public SdtDocumentoEstrutura_Arquivos_RESTInterface( ) : base()
      {
      }

      public SdtDocumentoEstrutura_Arquivos_RESTInterface( GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DocArqSeq" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Docarqseq
      {
         get {
            return sdt.gxTpr_Docarqseq ;
         }

         set {
            sdt.gxTpr_Docarqseq = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "DocArqInsData" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Docarqinsdata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Docarqinsdata) ;
         }

         set {
            sdt.gxTpr_Docarqinsdata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "DocArqInsHora" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Docarqinshora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Docarqinshora) ;
         }

         set {
            GXt_dtime2 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Docarqinshora = GXt_dtime2;
         }

      }

      [DataMember( Name = "DocArqInsDataHora" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Docarqinsdatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Docarqinsdatahora) ;
         }

         set {
            sdt.gxTpr_Docarqinsdatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "DocArqInsUsuID" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Docarqinsusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Docarqinsusuid) ;
         }

         set {
            sdt.gxTpr_Docarqinsusuid = value;
         }

      }

      [DataMember( Name = "DocArqUpdData" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Docarqupddata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Docarqupddata) ;
         }

         set {
            sdt.gxTpr_Docarqupddata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "DocArqUpdHora" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Docarqupdhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Docarqupdhora) ;
         }

         set {
            GXt_dtime2 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Docarqupdhora = GXt_dtime2;
         }

      }

      [DataMember( Name = "DocArqUpdDataHora" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Docarqupddatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Docarqupddatahora) ;
         }

         set {
            sdt.gxTpr_Docarqupddatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "DocArqUsuID" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Docarqusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Docarqusuid) ;
         }

         set {
            sdt.gxTpr_Docarqusuid = value;
         }

      }

      [DataMember( Name = "DocArqDel" , Order = 9 )]
      [GxSeudo()]
      public bool gxTpr_Docarqdel
      {
         get {
            return sdt.gxTpr_Docarqdel ;
         }

         set {
            sdt.gxTpr_Docarqdel = value;
         }

      }

      [DataMember( Name = "DocArqDelData" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Docarqdeldata
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Docarqdeldata) ;
         }

         set {
            sdt.gxTpr_Docarqdeldata = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "DocArqDelDataHora" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Docarqdeldatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Docarqdeldatahora) ;
         }

         set {
            sdt.gxTpr_Docarqdeldatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "DocArqDelUsuID" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Docarqdelusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Docarqdelusuid) ;
         }

         set {
            sdt.gxTpr_Docarqdelusuid = value;
         }

      }

      [DataMember( Name = "DocArqConteudo" , Order = 13 )]
      [GxUpload()]
      public string gxTpr_Docarqconteudo
      {
         get {
            return PathUtil.RelativeURL( sdt.gxTpr_Docarqconteudo) ;
         }

         set {
            sdt.gxTpr_Docarqconteudo = value;
         }

      }

      [DataMember( Name = "DocArqConteudoNome" , Order = 14 )]
      public string gxTpr_Docarqconteudonome
      {
         get {
            return sdt.gxTpr_Docarqconteudonome ;
         }

         set {
            sdt.gxTpr_Docarqconteudonome = value;
         }

      }

      [DataMember( Name = "DocArqConteudoExtensao" , Order = 15 )]
      public string gxTpr_Docarqconteudoextensao
      {
         get {
            return sdt.gxTpr_Docarqconteudoextensao ;
         }

         set {
            sdt.gxTpr_Docarqconteudoextensao = value;
         }

      }

      [DataMember( Name = "DocArqObservacao" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Docarqobservacao
      {
         get {
            return sdt.gxTpr_Docarqobservacao ;
         }

         set {
            sdt.gxTpr_Docarqobservacao = value;
         }

      }

      [DataMember( Name = "DocArqArmExterno" , Order = 17 )]
      [GxSeudo()]
      public bool gxTpr_Docarqarmexterno
      {
         get {
            return sdt.gxTpr_Docarqarmexterno ;
         }

         set {
            sdt.gxTpr_Docarqarmexterno = value;
         }

      }

      [DataMember( Name = "DocArqArmExternoPath" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Docarqarmexternopath
      {
         get {
            return sdt.gxTpr_Docarqarmexternopath ;
         }

         set {
            sdt.gxTpr_Docarqarmexternopath = value;
         }

      }

      public GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos sdt
      {
         get {
            return (GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos() ;
         }
      }

      private DateTime GXt_dtime2 ;
   }

   [DataContract(Name = @"core\DocumentoEstrutura.Arquivos", Namespace = "agl_tresorygroup")]
   public class SdtDocumentoEstrutura_Arquivos_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos>
   {
      public SdtDocumentoEstrutura_Arquivos_RESTLInterface( ) : base()
      {
      }

      public SdtDocumentoEstrutura_Arquivos_RESTLInterface( GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos psdt ) : base(psdt)
      {
      }

      public GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos sdt
      {
         get {
            return (GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos() ;
         }
      }

   }

}
