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
   [XmlRoot(ElementName = "DocumentoArquivo" )]
   [XmlType(TypeName =  "DocumentoArquivo" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class SdtDocumentoArquivo : GxSilentTrnSdt
   {
      public SdtDocumentoArquivo( )
      {
      }

      public SdtDocumentoArquivo( IGxContext context )
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

      public void Load( Guid AV289DocID ,
                        short AV307DocArqSeq )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV289DocID,(short)AV307DocArqSeq});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"DocID", typeof(Guid)}, new Object[]{"DocArqSeq", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "core\\DocumentoArquivo");
         metadata.Set("BT", "tb_documento_arquivo");
         metadata.Set("PK", "[ \"DocID\",\"DocArqSeq\" ]");
         metadata.Set("PKAssigned", "[ \"DocArqSeq\" ]");
         metadata.Set("Serial", "[ [ \"Other\",\"tb_documento\",\"DocUltArqSeq\",\"DocArqSeq\",\"DocID\",\"DocID\" ] ]");
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
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Docid_Z");
         state.Add("gxTpr_Docultarqseq_Z");
         state.Add("gxTpr_Docversao_Z");
         state.Add("gxTpr_Docversaoidpai_Z");
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
         state.Add("gxTpr_Docarqdeldatahora_Z_Nullable");
         state.Add("gxTpr_Docarqdeldata_Z_Nullable");
         state.Add("gxTpr_Docarqdelhora_Z_Nullable");
         state.Add("gxTpr_Docarqdelusuid_Z");
         state.Add("gxTpr_Docarqdelusunome_Z");
         state.Add("gxTpr_Docarqconteudonome_Z");
         state.Add("gxTpr_Docarqconteudoextensao_Z");
         state.Add("gxTpr_Docarqobservacao_Z");
         state.Add("gxTpr_Docarqarmexterno_Z");
         state.Add("gxTpr_Docarqarmexternopath_Z");
         state.Add("gxTpr_Docultarqseq_N");
         state.Add("gxTpr_Docversaoidpai_N");
         state.Add("gxTpr_Docarqinsusuid_N");
         state.Add("gxTpr_Docarqupddata_N");
         state.Add("gxTpr_Docarqupdhora_N");
         state.Add("gxTpr_Docarqupddatahora_N");
         state.Add("gxTpr_Docarqusuid_N");
         state.Add("gxTpr_Docarqdeldatahora_N");
         state.Add("gxTpr_Docarqdeldata_N");
         state.Add("gxTpr_Docarqdelhora_N");
         state.Add("gxTpr_Docarqdelusuid_N");
         state.Add("gxTpr_Docarqdelusunome_N");
         state.Add("gxTpr_Docarqconteudo_N");
         state.Add("gxTpr_Docarqobservacao_N");
         state.Add("gxTpr_Docarqarmexternopath_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.SdtDocumentoArquivo sdt;
         sdt = (GeneXus.Programs.core.SdtDocumentoArquivo)(source);
         gxTv_SdtDocumentoArquivo_Docid = sdt.gxTv_SdtDocumentoArquivo_Docid ;
         gxTv_SdtDocumentoArquivo_Docultarqseq = sdt.gxTv_SdtDocumentoArquivo_Docultarqseq ;
         gxTv_SdtDocumentoArquivo_Docversao = sdt.gxTv_SdtDocumentoArquivo_Docversao ;
         gxTv_SdtDocumentoArquivo_Docversaoidpai = sdt.gxTv_SdtDocumentoArquivo_Docversaoidpai ;
         gxTv_SdtDocumentoArquivo_Docarqseq = sdt.gxTv_SdtDocumentoArquivo_Docarqseq ;
         gxTv_SdtDocumentoArquivo_Docarqinsdata = sdt.gxTv_SdtDocumentoArquivo_Docarqinsdata ;
         gxTv_SdtDocumentoArquivo_Docarqinshora = sdt.gxTv_SdtDocumentoArquivo_Docarqinshora ;
         gxTv_SdtDocumentoArquivo_Docarqinsdatahora = sdt.gxTv_SdtDocumentoArquivo_Docarqinsdatahora ;
         gxTv_SdtDocumentoArquivo_Docarqinsusuid = sdt.gxTv_SdtDocumentoArquivo_Docarqinsusuid ;
         gxTv_SdtDocumentoArquivo_Docarqupddata = sdt.gxTv_SdtDocumentoArquivo_Docarqupddata ;
         gxTv_SdtDocumentoArquivo_Docarqupdhora = sdt.gxTv_SdtDocumentoArquivo_Docarqupdhora ;
         gxTv_SdtDocumentoArquivo_Docarqupddatahora = sdt.gxTv_SdtDocumentoArquivo_Docarqupddatahora ;
         gxTv_SdtDocumentoArquivo_Docarqusuid = sdt.gxTv_SdtDocumentoArquivo_Docarqusuid ;
         gxTv_SdtDocumentoArquivo_Docarqdel = sdt.gxTv_SdtDocumentoArquivo_Docarqdel ;
         gxTv_SdtDocumentoArquivo_Docarqdeldatahora = sdt.gxTv_SdtDocumentoArquivo_Docarqdeldatahora ;
         gxTv_SdtDocumentoArquivo_Docarqdeldata = sdt.gxTv_SdtDocumentoArquivo_Docarqdeldata ;
         gxTv_SdtDocumentoArquivo_Docarqdelhora = sdt.gxTv_SdtDocumentoArquivo_Docarqdelhora ;
         gxTv_SdtDocumentoArquivo_Docarqdelusuid = sdt.gxTv_SdtDocumentoArquivo_Docarqdelusuid ;
         gxTv_SdtDocumentoArquivo_Docarqdelusunome = sdt.gxTv_SdtDocumentoArquivo_Docarqdelusunome ;
         gxTv_SdtDocumentoArquivo_Docarqconteudo = sdt.gxTv_SdtDocumentoArquivo_Docarqconteudo ;
         gxTv_SdtDocumentoArquivo_Docarqconteudonome = sdt.gxTv_SdtDocumentoArquivo_Docarqconteudonome ;
         gxTv_SdtDocumentoArquivo_Docarqconteudoextensao = sdt.gxTv_SdtDocumentoArquivo_Docarqconteudoextensao ;
         gxTv_SdtDocumentoArquivo_Docarqobservacao = sdt.gxTv_SdtDocumentoArquivo_Docarqobservacao ;
         gxTv_SdtDocumentoArquivo_Docarqarmexterno = sdt.gxTv_SdtDocumentoArquivo_Docarqarmexterno ;
         gxTv_SdtDocumentoArquivo_Docarqarmexternopath = sdt.gxTv_SdtDocumentoArquivo_Docarqarmexternopath ;
         gxTv_SdtDocumentoArquivo_Mode = sdt.gxTv_SdtDocumentoArquivo_Mode ;
         gxTv_SdtDocumentoArquivo_Initialized = sdt.gxTv_SdtDocumentoArquivo_Initialized ;
         gxTv_SdtDocumentoArquivo_Docid_Z = sdt.gxTv_SdtDocumentoArquivo_Docid_Z ;
         gxTv_SdtDocumentoArquivo_Docultarqseq_Z = sdt.gxTv_SdtDocumentoArquivo_Docultarqseq_Z ;
         gxTv_SdtDocumentoArquivo_Docversao_Z = sdt.gxTv_SdtDocumentoArquivo_Docversao_Z ;
         gxTv_SdtDocumentoArquivo_Docversaoidpai_Z = sdt.gxTv_SdtDocumentoArquivo_Docversaoidpai_Z ;
         gxTv_SdtDocumentoArquivo_Docarqseq_Z = sdt.gxTv_SdtDocumentoArquivo_Docarqseq_Z ;
         gxTv_SdtDocumentoArquivo_Docarqinsdata_Z = sdt.gxTv_SdtDocumentoArquivo_Docarqinsdata_Z ;
         gxTv_SdtDocumentoArquivo_Docarqinshora_Z = sdt.gxTv_SdtDocumentoArquivo_Docarqinshora_Z ;
         gxTv_SdtDocumentoArquivo_Docarqinsdatahora_Z = sdt.gxTv_SdtDocumentoArquivo_Docarqinsdatahora_Z ;
         gxTv_SdtDocumentoArquivo_Docarqinsusuid_Z = sdt.gxTv_SdtDocumentoArquivo_Docarqinsusuid_Z ;
         gxTv_SdtDocumentoArquivo_Docarqupddata_Z = sdt.gxTv_SdtDocumentoArquivo_Docarqupddata_Z ;
         gxTv_SdtDocumentoArquivo_Docarqupdhora_Z = sdt.gxTv_SdtDocumentoArquivo_Docarqupdhora_Z ;
         gxTv_SdtDocumentoArquivo_Docarqupddatahora_Z = sdt.gxTv_SdtDocumentoArquivo_Docarqupddatahora_Z ;
         gxTv_SdtDocumentoArquivo_Docarqusuid_Z = sdt.gxTv_SdtDocumentoArquivo_Docarqusuid_Z ;
         gxTv_SdtDocumentoArquivo_Docarqdel_Z = sdt.gxTv_SdtDocumentoArquivo_Docarqdel_Z ;
         gxTv_SdtDocumentoArquivo_Docarqdeldatahora_Z = sdt.gxTv_SdtDocumentoArquivo_Docarqdeldatahora_Z ;
         gxTv_SdtDocumentoArquivo_Docarqdeldata_Z = sdt.gxTv_SdtDocumentoArquivo_Docarqdeldata_Z ;
         gxTv_SdtDocumentoArquivo_Docarqdelhora_Z = sdt.gxTv_SdtDocumentoArquivo_Docarqdelhora_Z ;
         gxTv_SdtDocumentoArquivo_Docarqdelusuid_Z = sdt.gxTv_SdtDocumentoArquivo_Docarqdelusuid_Z ;
         gxTv_SdtDocumentoArquivo_Docarqdelusunome_Z = sdt.gxTv_SdtDocumentoArquivo_Docarqdelusunome_Z ;
         gxTv_SdtDocumentoArquivo_Docarqconteudonome_Z = sdt.gxTv_SdtDocumentoArquivo_Docarqconteudonome_Z ;
         gxTv_SdtDocumentoArquivo_Docarqconteudoextensao_Z = sdt.gxTv_SdtDocumentoArquivo_Docarqconteudoextensao_Z ;
         gxTv_SdtDocumentoArquivo_Docarqobservacao_Z = sdt.gxTv_SdtDocumentoArquivo_Docarqobservacao_Z ;
         gxTv_SdtDocumentoArquivo_Docarqarmexterno_Z = sdt.gxTv_SdtDocumentoArquivo_Docarqarmexterno_Z ;
         gxTv_SdtDocumentoArquivo_Docarqarmexternopath_Z = sdt.gxTv_SdtDocumentoArquivo_Docarqarmexternopath_Z ;
         gxTv_SdtDocumentoArquivo_Docultarqseq_N = sdt.gxTv_SdtDocumentoArquivo_Docultarqseq_N ;
         gxTv_SdtDocumentoArquivo_Docversaoidpai_N = sdt.gxTv_SdtDocumentoArquivo_Docversaoidpai_N ;
         gxTv_SdtDocumentoArquivo_Docarqinsusuid_N = sdt.gxTv_SdtDocumentoArquivo_Docarqinsusuid_N ;
         gxTv_SdtDocumentoArquivo_Docarqupddata_N = sdt.gxTv_SdtDocumentoArquivo_Docarqupddata_N ;
         gxTv_SdtDocumentoArquivo_Docarqupdhora_N = sdt.gxTv_SdtDocumentoArquivo_Docarqupdhora_N ;
         gxTv_SdtDocumentoArquivo_Docarqupddatahora_N = sdt.gxTv_SdtDocumentoArquivo_Docarqupddatahora_N ;
         gxTv_SdtDocumentoArquivo_Docarqusuid_N = sdt.gxTv_SdtDocumentoArquivo_Docarqusuid_N ;
         gxTv_SdtDocumentoArquivo_Docarqdeldatahora_N = sdt.gxTv_SdtDocumentoArquivo_Docarqdeldatahora_N ;
         gxTv_SdtDocumentoArquivo_Docarqdeldata_N = sdt.gxTv_SdtDocumentoArquivo_Docarqdeldata_N ;
         gxTv_SdtDocumentoArquivo_Docarqdelhora_N = sdt.gxTv_SdtDocumentoArquivo_Docarqdelhora_N ;
         gxTv_SdtDocumentoArquivo_Docarqdelusuid_N = sdt.gxTv_SdtDocumentoArquivo_Docarqdelusuid_N ;
         gxTv_SdtDocumentoArquivo_Docarqdelusunome_N = sdt.gxTv_SdtDocumentoArquivo_Docarqdelusunome_N ;
         gxTv_SdtDocumentoArquivo_Docarqconteudo_N = sdt.gxTv_SdtDocumentoArquivo_Docarqconteudo_N ;
         gxTv_SdtDocumentoArquivo_Docarqobservacao_N = sdt.gxTv_SdtDocumentoArquivo_Docarqobservacao_N ;
         gxTv_SdtDocumentoArquivo_Docarqarmexternopath_N = sdt.gxTv_SdtDocumentoArquivo_Docarqarmexternopath_N ;
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
         AddObjectProperty("DocID", gxTv_SdtDocumentoArquivo_Docid, false, includeNonInitialized);
         AddObjectProperty("DocUltArqSeq", gxTv_SdtDocumentoArquivo_Docultarqseq, false, includeNonInitialized);
         AddObjectProperty("DocUltArqSeq_N", gxTv_SdtDocumentoArquivo_Docultarqseq_N, false, includeNonInitialized);
         AddObjectProperty("DocVersao", gxTv_SdtDocumentoArquivo_Docversao, false, includeNonInitialized);
         AddObjectProperty("DocVersaoIDPai", gxTv_SdtDocumentoArquivo_Docversaoidpai, false, includeNonInitialized);
         AddObjectProperty("DocVersaoIDPai_N", gxTv_SdtDocumentoArquivo_Docversaoidpai_N, false, includeNonInitialized);
         AddObjectProperty("DocArqSeq", gxTv_SdtDocumentoArquivo_Docarqseq, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocumentoArquivo_Docarqinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocumentoArquivo_Docarqinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocumentoArquivo_Docarqinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("DocArqInsData", sDateCnv, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtDocumentoArquivo_Docarqinshora;
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
         datetimemil_STZ = gxTv_SdtDocumentoArquivo_Docarqinsdatahora;
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
         AddObjectProperty("DocArqInsUsuID", gxTv_SdtDocumentoArquivo_Docarqinsusuid, false, includeNonInitialized);
         AddObjectProperty("DocArqInsUsuID_N", gxTv_SdtDocumentoArquivo_Docarqinsusuid_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocumentoArquivo_Docarqupddata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocumentoArquivo_Docarqupddata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocumentoArquivo_Docarqupddata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("DocArqUpdData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DocArqUpdData_N", gxTv_SdtDocumentoArquivo_Docarqupddata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtDocumentoArquivo_Docarqupdhora;
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
         AddObjectProperty("DocArqUpdHora_N", gxTv_SdtDocumentoArquivo_Docarqupdhora_N, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtDocumentoArquivo_Docarqupddatahora;
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
         AddObjectProperty("DocArqUpdDataHora_N", gxTv_SdtDocumentoArquivo_Docarqupddatahora_N, false, includeNonInitialized);
         AddObjectProperty("DocArqUsuID", gxTv_SdtDocumentoArquivo_Docarqusuid, false, includeNonInitialized);
         AddObjectProperty("DocArqUsuID_N", gxTv_SdtDocumentoArquivo_Docarqusuid_N, false, includeNonInitialized);
         AddObjectProperty("DocArqDel", gxTv_SdtDocumentoArquivo_Docarqdel, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtDocumentoArquivo_Docarqdeldatahora;
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
         AddObjectProperty("DocArqDelDataHora_N", gxTv_SdtDocumentoArquivo_Docarqdeldatahora_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtDocumentoArquivo_Docarqdeldata;
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
         AddObjectProperty("DocArqDelData_N", gxTv_SdtDocumentoArquivo_Docarqdeldata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtDocumentoArquivo_Docarqdelhora;
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
         AddObjectProperty("DocArqDelHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DocArqDelHora_N", gxTv_SdtDocumentoArquivo_Docarqdelhora_N, false, includeNonInitialized);
         AddObjectProperty("DocArqDelUsuID", gxTv_SdtDocumentoArquivo_Docarqdelusuid, false, includeNonInitialized);
         AddObjectProperty("DocArqDelUsuID_N", gxTv_SdtDocumentoArquivo_Docarqdelusuid_N, false, includeNonInitialized);
         AddObjectProperty("DocArqDelUsuNome", gxTv_SdtDocumentoArquivo_Docarqdelusunome, false, includeNonInitialized);
         AddObjectProperty("DocArqDelUsuNome_N", gxTv_SdtDocumentoArquivo_Docarqdelusunome_N, false, includeNonInitialized);
         AddObjectProperty("DocArqConteudo", gxTv_SdtDocumentoArquivo_Docarqconteudo, false, includeNonInitialized);
         AddObjectProperty("DocArqConteudo_N", gxTv_SdtDocumentoArquivo_Docarqconteudo_N, false, includeNonInitialized);
         AddObjectProperty("DocArqConteudoNome", gxTv_SdtDocumentoArquivo_Docarqconteudonome, false, includeNonInitialized);
         AddObjectProperty("DocArqConteudoExtensao", gxTv_SdtDocumentoArquivo_Docarqconteudoextensao, false, includeNonInitialized);
         AddObjectProperty("DocArqObservacao", gxTv_SdtDocumentoArquivo_Docarqobservacao, false, includeNonInitialized);
         AddObjectProperty("DocArqObservacao_N", gxTv_SdtDocumentoArquivo_Docarqobservacao_N, false, includeNonInitialized);
         AddObjectProperty("DocArqArmExterno", gxTv_SdtDocumentoArquivo_Docarqarmexterno, false, includeNonInitialized);
         AddObjectProperty("DocArqArmExternoPath", gxTv_SdtDocumentoArquivo_Docarqarmexternopath, false, includeNonInitialized);
         AddObjectProperty("DocArqArmExternoPath_N", gxTv_SdtDocumentoArquivo_Docarqarmexternopath_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtDocumentoArquivo_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtDocumentoArquivo_Initialized, false, includeNonInitialized);
            AddObjectProperty("DocID_Z", gxTv_SdtDocumentoArquivo_Docid_Z, false, includeNonInitialized);
            AddObjectProperty("DocUltArqSeq_Z", gxTv_SdtDocumentoArquivo_Docultarqseq_Z, false, includeNonInitialized);
            AddObjectProperty("DocVersao_Z", gxTv_SdtDocumentoArquivo_Docversao_Z, false, includeNonInitialized);
            AddObjectProperty("DocVersaoIDPai_Z", gxTv_SdtDocumentoArquivo_Docversaoidpai_Z, false, includeNonInitialized);
            AddObjectProperty("DocArqSeq_Z", gxTv_SdtDocumentoArquivo_Docarqseq_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocumentoArquivo_Docarqinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocumentoArquivo_Docarqinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocumentoArquivo_Docarqinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("DocArqInsData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtDocumentoArquivo_Docarqinshora_Z;
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
            datetimemil_STZ = gxTv_SdtDocumentoArquivo_Docarqinsdatahora_Z;
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
            AddObjectProperty("DocArqInsUsuID_Z", gxTv_SdtDocumentoArquivo_Docarqinsusuid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocumentoArquivo_Docarqupddata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocumentoArquivo_Docarqupddata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocumentoArquivo_Docarqupddata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("DocArqUpdData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtDocumentoArquivo_Docarqupdhora_Z;
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
            datetimemil_STZ = gxTv_SdtDocumentoArquivo_Docarqupddatahora_Z;
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
            AddObjectProperty("DocArqUsuID_Z", gxTv_SdtDocumentoArquivo_Docarqusuid_Z, false, includeNonInitialized);
            AddObjectProperty("DocArqDel_Z", gxTv_SdtDocumentoArquivo_Docarqdel_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtDocumentoArquivo_Docarqdeldatahora_Z;
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
            datetime_STZ = gxTv_SdtDocumentoArquivo_Docarqdeldata_Z;
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
            datetime_STZ = gxTv_SdtDocumentoArquivo_Docarqdelhora_Z;
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
            AddObjectProperty("DocArqDelHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("DocArqDelUsuID_Z", gxTv_SdtDocumentoArquivo_Docarqdelusuid_Z, false, includeNonInitialized);
            AddObjectProperty("DocArqDelUsuNome_Z", gxTv_SdtDocumentoArquivo_Docarqdelusunome_Z, false, includeNonInitialized);
            AddObjectProperty("DocArqConteudoNome_Z", gxTv_SdtDocumentoArquivo_Docarqconteudonome_Z, false, includeNonInitialized);
            AddObjectProperty("DocArqConteudoExtensao_Z", gxTv_SdtDocumentoArquivo_Docarqconteudoextensao_Z, false, includeNonInitialized);
            AddObjectProperty("DocArqObservacao_Z", gxTv_SdtDocumentoArquivo_Docarqobservacao_Z, false, includeNonInitialized);
            AddObjectProperty("DocArqArmExterno_Z", gxTv_SdtDocumentoArquivo_Docarqarmexterno_Z, false, includeNonInitialized);
            AddObjectProperty("DocArqArmExternoPath_Z", gxTv_SdtDocumentoArquivo_Docarqarmexternopath_Z, false, includeNonInitialized);
            AddObjectProperty("DocUltArqSeq_N", gxTv_SdtDocumentoArquivo_Docultarqseq_N, false, includeNonInitialized);
            AddObjectProperty("DocVersaoIDPai_N", gxTv_SdtDocumentoArquivo_Docversaoidpai_N, false, includeNonInitialized);
            AddObjectProperty("DocArqInsUsuID_N", gxTv_SdtDocumentoArquivo_Docarqinsusuid_N, false, includeNonInitialized);
            AddObjectProperty("DocArqUpdData_N", gxTv_SdtDocumentoArquivo_Docarqupddata_N, false, includeNonInitialized);
            AddObjectProperty("DocArqUpdHora_N", gxTv_SdtDocumentoArquivo_Docarqupdhora_N, false, includeNonInitialized);
            AddObjectProperty("DocArqUpdDataHora_N", gxTv_SdtDocumentoArquivo_Docarqupddatahora_N, false, includeNonInitialized);
            AddObjectProperty("DocArqUsuID_N", gxTv_SdtDocumentoArquivo_Docarqusuid_N, false, includeNonInitialized);
            AddObjectProperty("DocArqDelDataHora_N", gxTv_SdtDocumentoArquivo_Docarqdeldatahora_N, false, includeNonInitialized);
            AddObjectProperty("DocArqDelData_N", gxTv_SdtDocumentoArquivo_Docarqdeldata_N, false, includeNonInitialized);
            AddObjectProperty("DocArqDelHora_N", gxTv_SdtDocumentoArquivo_Docarqdelhora_N, false, includeNonInitialized);
            AddObjectProperty("DocArqDelUsuID_N", gxTv_SdtDocumentoArquivo_Docarqdelusuid_N, false, includeNonInitialized);
            AddObjectProperty("DocArqDelUsuNome_N", gxTv_SdtDocumentoArquivo_Docarqdelusunome_N, false, includeNonInitialized);
            AddObjectProperty("DocArqConteudo_N", gxTv_SdtDocumentoArquivo_Docarqconteudo_N, false, includeNonInitialized);
            AddObjectProperty("DocArqObservacao_N", gxTv_SdtDocumentoArquivo_Docarqobservacao_N, false, includeNonInitialized);
            AddObjectProperty("DocArqArmExternoPath_N", gxTv_SdtDocumentoArquivo_Docarqarmexternopath_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.SdtDocumentoArquivo sdt )
      {
         if ( sdt.IsDirty("DocID") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docid = sdt.gxTv_SdtDocumentoArquivo_Docid ;
         }
         if ( sdt.IsDirty("DocUltArqSeq") )
         {
            gxTv_SdtDocumentoArquivo_Docultarqseq_N = (short)(sdt.gxTv_SdtDocumentoArquivo_Docultarqseq_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docultarqseq = sdt.gxTv_SdtDocumentoArquivo_Docultarqseq ;
         }
         if ( sdt.IsDirty("DocVersao") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docversao = sdt.gxTv_SdtDocumentoArquivo_Docversao ;
         }
         if ( sdt.IsDirty("DocVersaoIDPai") )
         {
            gxTv_SdtDocumentoArquivo_Docversaoidpai_N = (short)(sdt.gxTv_SdtDocumentoArquivo_Docversaoidpai_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docversaoidpai = sdt.gxTv_SdtDocumentoArquivo_Docversaoidpai ;
         }
         if ( sdt.IsDirty("DocArqSeq") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqseq = sdt.gxTv_SdtDocumentoArquivo_Docarqseq ;
         }
         if ( sdt.IsDirty("DocArqInsData") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqinsdata = sdt.gxTv_SdtDocumentoArquivo_Docarqinsdata ;
         }
         if ( sdt.IsDirty("DocArqInsHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqinshora = sdt.gxTv_SdtDocumentoArquivo_Docarqinshora ;
         }
         if ( sdt.IsDirty("DocArqInsDataHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqinsdatahora = sdt.gxTv_SdtDocumentoArquivo_Docarqinsdatahora ;
         }
         if ( sdt.IsDirty("DocArqInsUsuID") )
         {
            gxTv_SdtDocumentoArquivo_Docarqinsusuid_N = (short)(sdt.gxTv_SdtDocumentoArquivo_Docarqinsusuid_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqinsusuid = sdt.gxTv_SdtDocumentoArquivo_Docarqinsusuid ;
         }
         if ( sdt.IsDirty("DocArqUpdData") )
         {
            gxTv_SdtDocumentoArquivo_Docarqupddata_N = (short)(sdt.gxTv_SdtDocumentoArquivo_Docarqupddata_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqupddata = sdt.gxTv_SdtDocumentoArquivo_Docarqupddata ;
         }
         if ( sdt.IsDirty("DocArqUpdHora") )
         {
            gxTv_SdtDocumentoArquivo_Docarqupdhora_N = (short)(sdt.gxTv_SdtDocumentoArquivo_Docarqupdhora_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqupdhora = sdt.gxTv_SdtDocumentoArquivo_Docarqupdhora ;
         }
         if ( sdt.IsDirty("DocArqUpdDataHora") )
         {
            gxTv_SdtDocumentoArquivo_Docarqupddatahora_N = (short)(sdt.gxTv_SdtDocumentoArquivo_Docarqupddatahora_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqupddatahora = sdt.gxTv_SdtDocumentoArquivo_Docarqupddatahora ;
         }
         if ( sdt.IsDirty("DocArqUsuID") )
         {
            gxTv_SdtDocumentoArquivo_Docarqusuid_N = (short)(sdt.gxTv_SdtDocumentoArquivo_Docarqusuid_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqusuid = sdt.gxTv_SdtDocumentoArquivo_Docarqusuid ;
         }
         if ( sdt.IsDirty("DocArqDel") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqdel = sdt.gxTv_SdtDocumentoArquivo_Docarqdel ;
         }
         if ( sdt.IsDirty("DocArqDelDataHora") )
         {
            gxTv_SdtDocumentoArquivo_Docarqdeldatahora_N = (short)(sdt.gxTv_SdtDocumentoArquivo_Docarqdeldatahora_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqdeldatahora = sdt.gxTv_SdtDocumentoArquivo_Docarqdeldatahora ;
         }
         if ( sdt.IsDirty("DocArqDelData") )
         {
            gxTv_SdtDocumentoArquivo_Docarqdeldata_N = (short)(sdt.gxTv_SdtDocumentoArquivo_Docarqdeldata_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqdeldata = sdt.gxTv_SdtDocumentoArquivo_Docarqdeldata ;
         }
         if ( sdt.IsDirty("DocArqDelHora") )
         {
            gxTv_SdtDocumentoArquivo_Docarqdelhora_N = (short)(sdt.gxTv_SdtDocumentoArquivo_Docarqdelhora_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqdelhora = sdt.gxTv_SdtDocumentoArquivo_Docarqdelhora ;
         }
         if ( sdt.IsDirty("DocArqDelUsuID") )
         {
            gxTv_SdtDocumentoArquivo_Docarqdelusuid_N = (short)(sdt.gxTv_SdtDocumentoArquivo_Docarqdelusuid_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqdelusuid = sdt.gxTv_SdtDocumentoArquivo_Docarqdelusuid ;
         }
         if ( sdt.IsDirty("DocArqDelUsuNome") )
         {
            gxTv_SdtDocumentoArquivo_Docarqdelusunome_N = (short)(sdt.gxTv_SdtDocumentoArquivo_Docarqdelusunome_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqdelusunome = sdt.gxTv_SdtDocumentoArquivo_Docarqdelusunome ;
         }
         if ( sdt.IsDirty("DocArqConteudo") )
         {
            gxTv_SdtDocumentoArquivo_Docarqconteudo_N = (short)(sdt.gxTv_SdtDocumentoArquivo_Docarqconteudo_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqconteudo = sdt.gxTv_SdtDocumentoArquivo_Docarqconteudo ;
         }
         if ( sdt.IsDirty("DocArqConteudoNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqconteudonome = sdt.gxTv_SdtDocumentoArquivo_Docarqconteudonome ;
         }
         if ( sdt.IsDirty("DocArqConteudoExtensao") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqconteudoextensao = sdt.gxTv_SdtDocumentoArquivo_Docarqconteudoextensao ;
         }
         if ( sdt.IsDirty("DocArqObservacao") )
         {
            gxTv_SdtDocumentoArquivo_Docarqobservacao_N = (short)(sdt.gxTv_SdtDocumentoArquivo_Docarqobservacao_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqobservacao = sdt.gxTv_SdtDocumentoArquivo_Docarqobservacao ;
         }
         if ( sdt.IsDirty("DocArqArmExterno") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqarmexterno = sdt.gxTv_SdtDocumentoArquivo_Docarqarmexterno ;
         }
         if ( sdt.IsDirty("DocArqArmExternoPath") )
         {
            gxTv_SdtDocumentoArquivo_Docarqarmexternopath_N = (short)(sdt.gxTv_SdtDocumentoArquivo_Docarqarmexternopath_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqarmexternopath = sdt.gxTv_SdtDocumentoArquivo_Docarqarmexternopath ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "DocID" )]
      [  XmlElement( ElementName = "DocID"   )]
      public Guid gxTpr_Docid
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtDocumentoArquivo_Docid != value )
            {
               gxTv_SdtDocumentoArquivo_Mode = "INS";
               this.gxTv_SdtDocumentoArquivo_Docid_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docultarqseq_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docversao_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docversaoidpai_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqseq_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqinsdata_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqinshora_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqinsdatahora_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqinsusuid_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqupddata_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqupdhora_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqupddatahora_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqusuid_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqdel_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqdeldatahora_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqdeldata_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqdelhora_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqdelusuid_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqdelusunome_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqconteudonome_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqconteudoextensao_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqobservacao_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqarmexterno_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqarmexternopath_Z_SetNull( );
            }
            gxTv_SdtDocumentoArquivo_Docid = value;
            SetDirty("Docid");
         }

      }

      [  SoapElement( ElementName = "DocUltArqSeq" )]
      [  XmlElement( ElementName = "DocUltArqSeq"   )]
      public short gxTpr_Docultarqseq
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docultarqseq ;
         }

         set {
            gxTv_SdtDocumentoArquivo_Docultarqseq_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docultarqseq = value;
            SetDirty("Docultarqseq");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docultarqseq_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docultarqseq_N = 1;
         gxTv_SdtDocumentoArquivo_Docultarqseq = 0;
         SetDirty("Docultarqseq");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docultarqseq_IsNull( )
      {
         return (gxTv_SdtDocumentoArquivo_Docultarqseq_N==1) ;
      }

      [  SoapElement( ElementName = "DocVersao" )]
      [  XmlElement( ElementName = "DocVersao"   )]
      public short gxTpr_Docversao
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docversao ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docversao = value;
            SetDirty("Docversao");
         }

      }

      [  SoapElement( ElementName = "DocVersaoIDPai" )]
      [  XmlElement( ElementName = "DocVersaoIDPai"   )]
      public Guid gxTpr_Docversaoidpai
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docversaoidpai ;
         }

         set {
            gxTv_SdtDocumentoArquivo_Docversaoidpai_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docversaoidpai = value;
            SetDirty("Docversaoidpai");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docversaoidpai_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docversaoidpai_N = 1;
         gxTv_SdtDocumentoArquivo_Docversaoidpai = Guid.Empty;
         SetDirty("Docversaoidpai");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docversaoidpai_IsNull( )
      {
         return (gxTv_SdtDocumentoArquivo_Docversaoidpai_N==1) ;
      }

      [  SoapElement( ElementName = "DocArqSeq" )]
      [  XmlElement( ElementName = "DocArqSeq"   )]
      public short gxTpr_Docarqseq
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqseq ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtDocumentoArquivo_Docarqseq != value )
            {
               gxTv_SdtDocumentoArquivo_Mode = "INS";
               this.gxTv_SdtDocumentoArquivo_Docid_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docultarqseq_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docversao_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docversaoidpai_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqseq_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqinsdata_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqinshora_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqinsdatahora_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqinsusuid_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqupddata_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqupdhora_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqupddatahora_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqusuid_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqdel_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqdeldatahora_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqdeldata_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqdelhora_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqdelusuid_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqdelusunome_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqconteudonome_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqconteudoextensao_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqobservacao_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqarmexterno_Z_SetNull( );
               this.gxTv_SdtDocumentoArquivo_Docarqarmexternopath_Z_SetNull( );
            }
            gxTv_SdtDocumentoArquivo_Docarqseq = value;
            SetDirty("Docarqseq");
         }

      }

      [  SoapElement( ElementName = "DocArqInsData" )]
      [  XmlElement( ElementName = "DocArqInsData"  , IsNullable=true )]
      public string gxTpr_Docarqinsdata_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoArquivo_Docarqinsdata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocumentoArquivo_Docarqinsdata).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocumentoArquivo_Docarqinsdata = DateTime.MinValue;
            else
               gxTv_SdtDocumentoArquivo_Docarqinsdata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqinsdata
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqinsdata ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqinsdata = value;
            SetDirty("Docarqinsdata");
         }

      }

      [  SoapElement( ElementName = "DocArqInsHora" )]
      [  XmlElement( ElementName = "DocArqInsHora"  , IsNullable=true )]
      public string gxTpr_Docarqinshora_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoArquivo_Docarqinshora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoArquivo_Docarqinshora).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoArquivo_Docarqinshora = DateTime.MinValue;
            else
               gxTv_SdtDocumentoArquivo_Docarqinshora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqinshora
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqinshora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqinshora = value;
            SetDirty("Docarqinshora");
         }

      }

      [  SoapElement( ElementName = "DocArqInsDataHora" )]
      [  XmlElement( ElementName = "DocArqInsDataHora"  , IsNullable=true )]
      public string gxTpr_Docarqinsdatahora_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoArquivo_Docarqinsdatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoArquivo_Docarqinsdatahora, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoArquivo_Docarqinsdatahora = DateTime.MinValue;
            else
               gxTv_SdtDocumentoArquivo_Docarqinsdatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqinsdatahora
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqinsdatahora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqinsdatahora = value;
            SetDirty("Docarqinsdatahora");
         }

      }

      [  SoapElement( ElementName = "DocArqInsUsuID" )]
      [  XmlElement( ElementName = "DocArqInsUsuID"   )]
      public string gxTpr_Docarqinsusuid
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqinsusuid ;
         }

         set {
            gxTv_SdtDocumentoArquivo_Docarqinsusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqinsusuid = value;
            SetDirty("Docarqinsusuid");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqinsusuid_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqinsusuid_N = 1;
         gxTv_SdtDocumentoArquivo_Docarqinsusuid = "";
         SetDirty("Docarqinsusuid");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqinsusuid_IsNull( )
      {
         return (gxTv_SdtDocumentoArquivo_Docarqinsusuid_N==1) ;
      }

      [  SoapElement( ElementName = "DocArqUpdData" )]
      [  XmlElement( ElementName = "DocArqUpdData"  , IsNullable=true )]
      public string gxTpr_Docarqupddata_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoArquivo_Docarqupddata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocumentoArquivo_Docarqupddata).value ;
         }

         set {
            gxTv_SdtDocumentoArquivo_Docarqupddata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocumentoArquivo_Docarqupddata = DateTime.MinValue;
            else
               gxTv_SdtDocumentoArquivo_Docarqupddata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqupddata
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqupddata ;
         }

         set {
            gxTv_SdtDocumentoArquivo_Docarqupddata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqupddata = value;
            SetDirty("Docarqupddata");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqupddata_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqupddata_N = 1;
         gxTv_SdtDocumentoArquivo_Docarqupddata = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqupddata");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqupddata_IsNull( )
      {
         return (gxTv_SdtDocumentoArquivo_Docarqupddata_N==1) ;
      }

      [  SoapElement( ElementName = "DocArqUpdHora" )]
      [  XmlElement( ElementName = "DocArqUpdHora"  , IsNullable=true )]
      public string gxTpr_Docarqupdhora_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoArquivo_Docarqupdhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoArquivo_Docarqupdhora).value ;
         }

         set {
            gxTv_SdtDocumentoArquivo_Docarqupdhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoArquivo_Docarqupdhora = DateTime.MinValue;
            else
               gxTv_SdtDocumentoArquivo_Docarqupdhora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqupdhora
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqupdhora ;
         }

         set {
            gxTv_SdtDocumentoArquivo_Docarqupdhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqupdhora = value;
            SetDirty("Docarqupdhora");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqupdhora_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqupdhora_N = 1;
         gxTv_SdtDocumentoArquivo_Docarqupdhora = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqupdhora");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqupdhora_IsNull( )
      {
         return (gxTv_SdtDocumentoArquivo_Docarqupdhora_N==1) ;
      }

      [  SoapElement( ElementName = "DocArqUpdDataHora" )]
      [  XmlElement( ElementName = "DocArqUpdDataHora"  , IsNullable=true )]
      public string gxTpr_Docarqupddatahora_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoArquivo_Docarqupddatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoArquivo_Docarqupddatahora, null, true).value ;
         }

         set {
            gxTv_SdtDocumentoArquivo_Docarqupddatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoArquivo_Docarqupddatahora = DateTime.MinValue;
            else
               gxTv_SdtDocumentoArquivo_Docarqupddatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqupddatahora
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqupddatahora ;
         }

         set {
            gxTv_SdtDocumentoArquivo_Docarqupddatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqupddatahora = value;
            SetDirty("Docarqupddatahora");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqupddatahora_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqupddatahora_N = 1;
         gxTv_SdtDocumentoArquivo_Docarqupddatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqupddatahora");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqupddatahora_IsNull( )
      {
         return (gxTv_SdtDocumentoArquivo_Docarqupddatahora_N==1) ;
      }

      [  SoapElement( ElementName = "DocArqUsuID" )]
      [  XmlElement( ElementName = "DocArqUsuID"   )]
      public string gxTpr_Docarqusuid
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqusuid ;
         }

         set {
            gxTv_SdtDocumentoArquivo_Docarqusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqusuid = value;
            SetDirty("Docarqusuid");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqusuid_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqusuid_N = 1;
         gxTv_SdtDocumentoArquivo_Docarqusuid = "";
         SetDirty("Docarqusuid");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqusuid_IsNull( )
      {
         return (gxTv_SdtDocumentoArquivo_Docarqusuid_N==1) ;
      }

      [  SoapElement( ElementName = "DocArqDel" )]
      [  XmlElement( ElementName = "DocArqDel"   )]
      public bool gxTpr_Docarqdel
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqdel ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqdel = value;
            SetDirty("Docarqdel");
         }

      }

      [  SoapElement( ElementName = "DocArqDelDataHora" )]
      [  XmlElement( ElementName = "DocArqDelDataHora"  , IsNullable=true )]
      public string gxTpr_Docarqdeldatahora_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoArquivo_Docarqdeldatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoArquivo_Docarqdeldatahora, null, true).value ;
         }

         set {
            gxTv_SdtDocumentoArquivo_Docarqdeldatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoArquivo_Docarqdeldatahora = DateTime.MinValue;
            else
               gxTv_SdtDocumentoArquivo_Docarqdeldatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqdeldatahora
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqdeldatahora ;
         }

         set {
            gxTv_SdtDocumentoArquivo_Docarqdeldatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqdeldatahora = value;
            SetDirty("Docarqdeldatahora");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqdeldatahora_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqdeldatahora_N = 1;
         gxTv_SdtDocumentoArquivo_Docarqdeldatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqdeldatahora");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqdeldatahora_IsNull( )
      {
         return (gxTv_SdtDocumentoArquivo_Docarqdeldatahora_N==1) ;
      }

      [  SoapElement( ElementName = "DocArqDelData" )]
      [  XmlElement( ElementName = "DocArqDelData"  , IsNullable=true )]
      public string gxTpr_Docarqdeldata_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoArquivo_Docarqdeldata == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoArquivo_Docarqdeldata).value ;
         }

         set {
            gxTv_SdtDocumentoArquivo_Docarqdeldata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoArquivo_Docarqdeldata = DateTime.MinValue;
            else
               gxTv_SdtDocumentoArquivo_Docarqdeldata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqdeldata
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqdeldata ;
         }

         set {
            gxTv_SdtDocumentoArquivo_Docarqdeldata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqdeldata = value;
            SetDirty("Docarqdeldata");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqdeldata_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqdeldata_N = 1;
         gxTv_SdtDocumentoArquivo_Docarqdeldata = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqdeldata");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqdeldata_IsNull( )
      {
         return (gxTv_SdtDocumentoArquivo_Docarqdeldata_N==1) ;
      }

      [  SoapElement( ElementName = "DocArqDelHora" )]
      [  XmlElement( ElementName = "DocArqDelHora"  , IsNullable=true )]
      public string gxTpr_Docarqdelhora_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoArquivo_Docarqdelhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoArquivo_Docarqdelhora).value ;
         }

         set {
            gxTv_SdtDocumentoArquivo_Docarqdelhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoArquivo_Docarqdelhora = DateTime.MinValue;
            else
               gxTv_SdtDocumentoArquivo_Docarqdelhora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqdelhora
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqdelhora ;
         }

         set {
            gxTv_SdtDocumentoArquivo_Docarqdelhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqdelhora = value;
            SetDirty("Docarqdelhora");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqdelhora_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqdelhora_N = 1;
         gxTv_SdtDocumentoArquivo_Docarqdelhora = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqdelhora");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqdelhora_IsNull( )
      {
         return (gxTv_SdtDocumentoArquivo_Docarqdelhora_N==1) ;
      }

      [  SoapElement( ElementName = "DocArqDelUsuID" )]
      [  XmlElement( ElementName = "DocArqDelUsuID"   )]
      public string gxTpr_Docarqdelusuid
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqdelusuid ;
         }

         set {
            gxTv_SdtDocumentoArquivo_Docarqdelusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqdelusuid = value;
            SetDirty("Docarqdelusuid");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqdelusuid_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqdelusuid_N = 1;
         gxTv_SdtDocumentoArquivo_Docarqdelusuid = "";
         SetDirty("Docarqdelusuid");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqdelusuid_IsNull( )
      {
         return (gxTv_SdtDocumentoArquivo_Docarqdelusuid_N==1) ;
      }

      [  SoapElement( ElementName = "DocArqDelUsuNome" )]
      [  XmlElement( ElementName = "DocArqDelUsuNome"   )]
      public string gxTpr_Docarqdelusunome
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqdelusunome ;
         }

         set {
            gxTv_SdtDocumentoArquivo_Docarqdelusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqdelusunome = value;
            SetDirty("Docarqdelusunome");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqdelusunome_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqdelusunome_N = 1;
         gxTv_SdtDocumentoArquivo_Docarqdelusunome = "";
         SetDirty("Docarqdelusunome");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqdelusunome_IsNull( )
      {
         return (gxTv_SdtDocumentoArquivo_Docarqdelusunome_N==1) ;
      }

      [  SoapElement( ElementName = "DocArqConteudo" )]
      [  XmlElement( ElementName = "DocArqConteudo"   )]
      [GxUpload()]
      public byte[] gxTpr_Docarqconteudo_Blob
      {
         get {
            IGxContext context = this.context == null ? new GxContext() : this.context;
            return context.FileToByteArray( gxTv_SdtDocumentoArquivo_Docarqconteudo) ;
         }

         set {
            gxTv_SdtDocumentoArquivo_Docarqconteudo_N = 0;
            sdtIsNull = 0;
            IGxContext context = this.context == null ? new GxContext() : this.context;
            gxTv_SdtDocumentoArquivo_Docarqconteudo=context.FileFromByteArray( value) ;
         }

      }

      [XmlIgnore]
      [GxUpload()]
      public string gxTpr_Docarqconteudo
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqconteudo ;
         }

         set {
            gxTv_SdtDocumentoArquivo_Docarqconteudo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqconteudo = value;
            SetDirty("Docarqconteudo");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqconteudo_SetBlob( string blob ,
                                                                   string fileName ,
                                                                   string fileType )
      {
         gxTv_SdtDocumentoArquivo_Docarqconteudo = blob;
         gxTv_SdtDocumentoArquivo_Docarqconteudonome = fileName;
         gxTv_SdtDocumentoArquivo_Docarqconteudoextensao = fileType;
         return  ;
      }

      public void gxTv_SdtDocumentoArquivo_Docarqconteudo_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqconteudo_N = 1;
         gxTv_SdtDocumentoArquivo_Docarqconteudo = "";
         SetDirty("Docarqconteudo");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqconteudo_IsNull( )
      {
         return (gxTv_SdtDocumentoArquivo_Docarqconteudo_N==1) ;
      }

      [  SoapElement( ElementName = "DocArqConteudoNome" )]
      [  XmlElement( ElementName = "DocArqConteudoNome"   )]
      public string gxTpr_Docarqconteudonome
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqconteudonome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqconteudonome = value;
            SetDirty("Docarqconteudonome");
         }

      }

      [  SoapElement( ElementName = "DocArqConteudoExtensao" )]
      [  XmlElement( ElementName = "DocArqConteudoExtensao"   )]
      public string gxTpr_Docarqconteudoextensao
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqconteudoextensao ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqconteudoextensao = value;
            SetDirty("Docarqconteudoextensao");
         }

      }

      [  SoapElement( ElementName = "DocArqObservacao" )]
      [  XmlElement( ElementName = "DocArqObservacao"   )]
      public string gxTpr_Docarqobservacao
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqobservacao ;
         }

         set {
            gxTv_SdtDocumentoArquivo_Docarqobservacao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqobservacao = value;
            SetDirty("Docarqobservacao");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqobservacao_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqobservacao_N = 1;
         gxTv_SdtDocumentoArquivo_Docarqobservacao = "";
         SetDirty("Docarqobservacao");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqobservacao_IsNull( )
      {
         return (gxTv_SdtDocumentoArquivo_Docarqobservacao_N==1) ;
      }

      [  SoapElement( ElementName = "DocArqArmExterno" )]
      [  XmlElement( ElementName = "DocArqArmExterno"   )]
      public bool gxTpr_Docarqarmexterno
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqarmexterno ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqarmexterno = value;
            SetDirty("Docarqarmexterno");
         }

      }

      [  SoapElement( ElementName = "DocArqArmExternoPath" )]
      [  XmlElement( ElementName = "DocArqArmExternoPath"   )]
      public string gxTpr_Docarqarmexternopath
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqarmexternopath ;
         }

         set {
            gxTv_SdtDocumentoArquivo_Docarqarmexternopath_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqarmexternopath = value;
            SetDirty("Docarqarmexternopath");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqarmexternopath_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqarmexternopath_N = 1;
         gxTv_SdtDocumentoArquivo_Docarqarmexternopath = "";
         SetDirty("Docarqarmexternopath");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqarmexternopath_IsNull( )
      {
         return (gxTv_SdtDocumentoArquivo_Docarqarmexternopath_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtDocumentoArquivo_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Mode_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtDocumentoArquivo_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Initialized_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocID_Z" )]
      [  XmlElement( ElementName = "DocID_Z"   )]
      public Guid gxTpr_Docid_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docid_Z = value;
            SetDirty("Docid_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docid_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docid_Z = Guid.Empty;
         SetDirty("Docid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocUltArqSeq_Z" )]
      [  XmlElement( ElementName = "DocUltArqSeq_Z"   )]
      public short gxTpr_Docultarqseq_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docultarqseq_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docultarqseq_Z = value;
            SetDirty("Docultarqseq_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docultarqseq_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docultarqseq_Z = 0;
         SetDirty("Docultarqseq_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docultarqseq_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocVersao_Z" )]
      [  XmlElement( ElementName = "DocVersao_Z"   )]
      public short gxTpr_Docversao_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docversao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docversao_Z = value;
            SetDirty("Docversao_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docversao_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docversao_Z = 0;
         SetDirty("Docversao_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docversao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocVersaoIDPai_Z" )]
      [  XmlElement( ElementName = "DocVersaoIDPai_Z"   )]
      public Guid gxTpr_Docversaoidpai_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docversaoidpai_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docversaoidpai_Z = value;
            SetDirty("Docversaoidpai_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docversaoidpai_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docversaoidpai_Z = Guid.Empty;
         SetDirty("Docversaoidpai_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docversaoidpai_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqSeq_Z" )]
      [  XmlElement( ElementName = "DocArqSeq_Z"   )]
      public short gxTpr_Docarqseq_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqseq_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqseq_Z = value;
            SetDirty("Docarqseq_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqseq_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqseq_Z = 0;
         SetDirty("Docarqseq_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqseq_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqInsData_Z" )]
      [  XmlElement( ElementName = "DocArqInsData_Z"  , IsNullable=true )]
      public string gxTpr_Docarqinsdata_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoArquivo_Docarqinsdata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocumentoArquivo_Docarqinsdata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocumentoArquivo_Docarqinsdata_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoArquivo_Docarqinsdata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqinsdata_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqinsdata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqinsdata_Z = value;
            SetDirty("Docarqinsdata_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqinsdata_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqinsdata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqinsdata_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqinsdata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqInsHora_Z" )]
      [  XmlElement( ElementName = "DocArqInsHora_Z"  , IsNullable=true )]
      public string gxTpr_Docarqinshora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoArquivo_Docarqinshora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoArquivo_Docarqinshora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoArquivo_Docarqinshora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoArquivo_Docarqinshora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqinshora_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqinshora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqinshora_Z = value;
            SetDirty("Docarqinshora_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqinshora_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqinshora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqinshora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqinshora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqInsDataHora_Z" )]
      [  XmlElement( ElementName = "DocArqInsDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Docarqinsdatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoArquivo_Docarqinsdatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoArquivo_Docarqinsdatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoArquivo_Docarqinsdatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoArquivo_Docarqinsdatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqinsdatahora_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqinsdatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqinsdatahora_Z = value;
            SetDirty("Docarqinsdatahora_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqinsdatahora_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqinsdatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqinsdatahora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqinsdatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqInsUsuID_Z" )]
      [  XmlElement( ElementName = "DocArqInsUsuID_Z"   )]
      public string gxTpr_Docarqinsusuid_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqinsusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqinsusuid_Z = value;
            SetDirty("Docarqinsusuid_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqinsusuid_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqinsusuid_Z = "";
         SetDirty("Docarqinsusuid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqinsusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqUpdData_Z" )]
      [  XmlElement( ElementName = "DocArqUpdData_Z"  , IsNullable=true )]
      public string gxTpr_Docarqupddata_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoArquivo_Docarqupddata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocumentoArquivo_Docarqupddata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocumentoArquivo_Docarqupddata_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoArquivo_Docarqupddata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqupddata_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqupddata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqupddata_Z = value;
            SetDirty("Docarqupddata_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqupddata_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqupddata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqupddata_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqupddata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqUpdHora_Z" )]
      [  XmlElement( ElementName = "DocArqUpdHora_Z"  , IsNullable=true )]
      public string gxTpr_Docarqupdhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoArquivo_Docarqupdhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoArquivo_Docarqupdhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoArquivo_Docarqupdhora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoArquivo_Docarqupdhora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqupdhora_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqupdhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqupdhora_Z = value;
            SetDirty("Docarqupdhora_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqupdhora_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqupdhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqupdhora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqupdhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqUpdDataHora_Z" )]
      [  XmlElement( ElementName = "DocArqUpdDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Docarqupddatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoArquivo_Docarqupddatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoArquivo_Docarqupddatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoArquivo_Docarqupddatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoArquivo_Docarqupddatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqupddatahora_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqupddatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqupddatahora_Z = value;
            SetDirty("Docarqupddatahora_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqupddatahora_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqupddatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqupddatahora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqupddatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqUsuID_Z" )]
      [  XmlElement( ElementName = "DocArqUsuID_Z"   )]
      public string gxTpr_Docarqusuid_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqusuid_Z = value;
            SetDirty("Docarqusuid_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqusuid_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqusuid_Z = "";
         SetDirty("Docarqusuid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqDel_Z" )]
      [  XmlElement( ElementName = "DocArqDel_Z"   )]
      public bool gxTpr_Docarqdel_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqdel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqdel_Z = value;
            SetDirty("Docarqdel_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqdel_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqdel_Z = false;
         SetDirty("Docarqdel_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqdel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqDelDataHora_Z" )]
      [  XmlElement( ElementName = "DocArqDelDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Docarqdeldatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoArquivo_Docarqdeldatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoArquivo_Docarqdeldatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoArquivo_Docarqdeldatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoArquivo_Docarqdeldatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqdeldatahora_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqdeldatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqdeldatahora_Z = value;
            SetDirty("Docarqdeldatahora_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqdeldatahora_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqdeldatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqdeldatahora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqdeldatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqDelData_Z" )]
      [  XmlElement( ElementName = "DocArqDelData_Z"  , IsNullable=true )]
      public string gxTpr_Docarqdeldata_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoArquivo_Docarqdeldata_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoArquivo_Docarqdeldata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoArquivo_Docarqdeldata_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoArquivo_Docarqdeldata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqdeldata_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqdeldata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqdeldata_Z = value;
            SetDirty("Docarqdeldata_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqdeldata_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqdeldata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqdeldata_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqdeldata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqDelHora_Z" )]
      [  XmlElement( ElementName = "DocArqDelHora_Z"  , IsNullable=true )]
      public string gxTpr_Docarqdelhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoArquivo_Docarqdelhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoArquivo_Docarqdelhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoArquivo_Docarqdelhora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoArquivo_Docarqdelhora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docarqdelhora_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqdelhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqdelhora_Z = value;
            SetDirty("Docarqdelhora_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqdelhora_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqdelhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docarqdelhora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqdelhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqDelUsuID_Z" )]
      [  XmlElement( ElementName = "DocArqDelUsuID_Z"   )]
      public string gxTpr_Docarqdelusuid_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqdelusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqdelusuid_Z = value;
            SetDirty("Docarqdelusuid_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqdelusuid_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqdelusuid_Z = "";
         SetDirty("Docarqdelusuid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqdelusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqDelUsuNome_Z" )]
      [  XmlElement( ElementName = "DocArqDelUsuNome_Z"   )]
      public string gxTpr_Docarqdelusunome_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqdelusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqdelusunome_Z = value;
            SetDirty("Docarqdelusunome_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqdelusunome_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqdelusunome_Z = "";
         SetDirty("Docarqdelusunome_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqdelusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqConteudoNome_Z" )]
      [  XmlElement( ElementName = "DocArqConteudoNome_Z"   )]
      public string gxTpr_Docarqconteudonome_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqconteudonome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqconteudonome_Z = value;
            SetDirty("Docarqconteudonome_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqconteudonome_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqconteudonome_Z = "";
         SetDirty("Docarqconteudonome_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqconteudonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqConteudoExtensao_Z" )]
      [  XmlElement( ElementName = "DocArqConteudoExtensao_Z"   )]
      public string gxTpr_Docarqconteudoextensao_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqconteudoextensao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqconteudoextensao_Z = value;
            SetDirty("Docarqconteudoextensao_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqconteudoextensao_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqconteudoextensao_Z = "";
         SetDirty("Docarqconteudoextensao_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqconteudoextensao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqObservacao_Z" )]
      [  XmlElement( ElementName = "DocArqObservacao_Z"   )]
      public string gxTpr_Docarqobservacao_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqobservacao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqobservacao_Z = value;
            SetDirty("Docarqobservacao_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqobservacao_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqobservacao_Z = "";
         SetDirty("Docarqobservacao_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqobservacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqArmExterno_Z" )]
      [  XmlElement( ElementName = "DocArqArmExterno_Z"   )]
      public bool gxTpr_Docarqarmexterno_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqarmexterno_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqarmexterno_Z = value;
            SetDirty("Docarqarmexterno_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqarmexterno_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqarmexterno_Z = false;
         SetDirty("Docarqarmexterno_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqarmexterno_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqArmExternoPath_Z" )]
      [  XmlElement( ElementName = "DocArqArmExternoPath_Z"   )]
      public string gxTpr_Docarqarmexternopath_Z
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqarmexternopath_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqarmexternopath_Z = value;
            SetDirty("Docarqarmexternopath_Z");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqarmexternopath_Z_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqarmexternopath_Z = "";
         SetDirty("Docarqarmexternopath_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqarmexternopath_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocUltArqSeq_N" )]
      [  XmlElement( ElementName = "DocUltArqSeq_N"   )]
      public short gxTpr_Docultarqseq_N
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docultarqseq_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docultarqseq_N = value;
            SetDirty("Docultarqseq_N");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docultarqseq_N_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docultarqseq_N = 0;
         SetDirty("Docultarqseq_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docultarqseq_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocVersaoIDPai_N" )]
      [  XmlElement( ElementName = "DocVersaoIDPai_N"   )]
      public short gxTpr_Docversaoidpai_N
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docversaoidpai_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docversaoidpai_N = value;
            SetDirty("Docversaoidpai_N");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docversaoidpai_N_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docversaoidpai_N = 0;
         SetDirty("Docversaoidpai_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docversaoidpai_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqInsUsuID_N" )]
      [  XmlElement( ElementName = "DocArqInsUsuID_N"   )]
      public short gxTpr_Docarqinsusuid_N
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqinsusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqinsusuid_N = value;
            SetDirty("Docarqinsusuid_N");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqinsusuid_N_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqinsusuid_N = 0;
         SetDirty("Docarqinsusuid_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqinsusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqUpdData_N" )]
      [  XmlElement( ElementName = "DocArqUpdData_N"   )]
      public short gxTpr_Docarqupddata_N
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqupddata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqupddata_N = value;
            SetDirty("Docarqupddata_N");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqupddata_N_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqupddata_N = 0;
         SetDirty("Docarqupddata_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqupddata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqUpdHora_N" )]
      [  XmlElement( ElementName = "DocArqUpdHora_N"   )]
      public short gxTpr_Docarqupdhora_N
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqupdhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqupdhora_N = value;
            SetDirty("Docarqupdhora_N");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqupdhora_N_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqupdhora_N = 0;
         SetDirty("Docarqupdhora_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqupdhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqUpdDataHora_N" )]
      [  XmlElement( ElementName = "DocArqUpdDataHora_N"   )]
      public short gxTpr_Docarqupddatahora_N
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqupddatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqupddatahora_N = value;
            SetDirty("Docarqupddatahora_N");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqupddatahora_N_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqupddatahora_N = 0;
         SetDirty("Docarqupddatahora_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqupddatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqUsuID_N" )]
      [  XmlElement( ElementName = "DocArqUsuID_N"   )]
      public short gxTpr_Docarqusuid_N
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqusuid_N = value;
            SetDirty("Docarqusuid_N");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqusuid_N_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqusuid_N = 0;
         SetDirty("Docarqusuid_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqDelDataHora_N" )]
      [  XmlElement( ElementName = "DocArqDelDataHora_N"   )]
      public short gxTpr_Docarqdeldatahora_N
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqdeldatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqdeldatahora_N = value;
            SetDirty("Docarqdeldatahora_N");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqdeldatahora_N_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqdeldatahora_N = 0;
         SetDirty("Docarqdeldatahora_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqdeldatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqDelData_N" )]
      [  XmlElement( ElementName = "DocArqDelData_N"   )]
      public short gxTpr_Docarqdeldata_N
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqdeldata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqdeldata_N = value;
            SetDirty("Docarqdeldata_N");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqdeldata_N_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqdeldata_N = 0;
         SetDirty("Docarqdeldata_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqdeldata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqDelHora_N" )]
      [  XmlElement( ElementName = "DocArqDelHora_N"   )]
      public short gxTpr_Docarqdelhora_N
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqdelhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqdelhora_N = value;
            SetDirty("Docarqdelhora_N");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqdelhora_N_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqdelhora_N = 0;
         SetDirty("Docarqdelhora_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqdelhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqDelUsuID_N" )]
      [  XmlElement( ElementName = "DocArqDelUsuID_N"   )]
      public short gxTpr_Docarqdelusuid_N
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqdelusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqdelusuid_N = value;
            SetDirty("Docarqdelusuid_N");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqdelusuid_N_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqdelusuid_N = 0;
         SetDirty("Docarqdelusuid_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqdelusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqDelUsuNome_N" )]
      [  XmlElement( ElementName = "DocArqDelUsuNome_N"   )]
      public short gxTpr_Docarqdelusunome_N
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqdelusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqdelusunome_N = value;
            SetDirty("Docarqdelusunome_N");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqdelusunome_N_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqdelusunome_N = 0;
         SetDirty("Docarqdelusunome_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqdelusunome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqConteudo_N" )]
      [  XmlElement( ElementName = "DocArqConteudo_N"   )]
      public short gxTpr_Docarqconteudo_N
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqconteudo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqconteudo_N = value;
            SetDirty("Docarqconteudo_N");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqconteudo_N_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqconteudo_N = 0;
         SetDirty("Docarqconteudo_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqconteudo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqObservacao_N" )]
      [  XmlElement( ElementName = "DocArqObservacao_N"   )]
      public short gxTpr_Docarqobservacao_N
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqobservacao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqobservacao_N = value;
            SetDirty("Docarqobservacao_N");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqobservacao_N_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqobservacao_N = 0;
         SetDirty("Docarqobservacao_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqobservacao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocArqArmExternoPath_N" )]
      [  XmlElement( ElementName = "DocArqArmExternoPath_N"   )]
      public short gxTpr_Docarqarmexternopath_N
      {
         get {
            return gxTv_SdtDocumentoArquivo_Docarqarmexternopath_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoArquivo_Docarqarmexternopath_N = value;
            SetDirty("Docarqarmexternopath_N");
         }

      }

      public void gxTv_SdtDocumentoArquivo_Docarqarmexternopath_N_SetNull( )
      {
         gxTv_SdtDocumentoArquivo_Docarqarmexternopath_N = 0;
         SetDirty("Docarqarmexternopath_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoArquivo_Docarqarmexternopath_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtDocumentoArquivo_Docid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtDocumentoArquivo_Docversaoidpai = Guid.Empty;
         gxTv_SdtDocumentoArquivo_Docarqinsdata = DateTime.MinValue;
         gxTv_SdtDocumentoArquivo_Docarqinshora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoArquivo_Docarqinsdatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoArquivo_Docarqinsusuid = "";
         gxTv_SdtDocumentoArquivo_Docarqupddata = DateTime.MinValue;
         gxTv_SdtDocumentoArquivo_Docarqupdhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoArquivo_Docarqupddatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoArquivo_Docarqusuid = "";
         gxTv_SdtDocumentoArquivo_Docarqdel = false;
         gxTv_SdtDocumentoArquivo_Docarqdeldatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoArquivo_Docarqdeldata = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoArquivo_Docarqdelhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoArquivo_Docarqdelusuid = "";
         gxTv_SdtDocumentoArquivo_Docarqdelusunome = "";
         gxTv_SdtDocumentoArquivo_Docarqconteudo = "";
         gxTv_SdtDocumentoArquivo_Docarqconteudonome = "";
         gxTv_SdtDocumentoArquivo_Docarqconteudoextensao = "";
         gxTv_SdtDocumentoArquivo_Docarqobservacao = "";
         gxTv_SdtDocumentoArquivo_Docarqarmexterno = false;
         gxTv_SdtDocumentoArquivo_Docarqarmexternopath = "";
         gxTv_SdtDocumentoArquivo_Mode = "";
         gxTv_SdtDocumentoArquivo_Docid_Z = Guid.Empty;
         gxTv_SdtDocumentoArquivo_Docversaoidpai_Z = Guid.Empty;
         gxTv_SdtDocumentoArquivo_Docarqinsdata_Z = DateTime.MinValue;
         gxTv_SdtDocumentoArquivo_Docarqinshora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoArquivo_Docarqinsdatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoArquivo_Docarqinsusuid_Z = "";
         gxTv_SdtDocumentoArquivo_Docarqupddata_Z = DateTime.MinValue;
         gxTv_SdtDocumentoArquivo_Docarqupdhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoArquivo_Docarqupddatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoArquivo_Docarqusuid_Z = "";
         gxTv_SdtDocumentoArquivo_Docarqdeldatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoArquivo_Docarqdeldata_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoArquivo_Docarqdelhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoArquivo_Docarqdelusuid_Z = "";
         gxTv_SdtDocumentoArquivo_Docarqdelusunome_Z = "";
         gxTv_SdtDocumentoArquivo_Docarqconteudonome_Z = "";
         gxTv_SdtDocumentoArquivo_Docarqconteudoextensao_Z = "";
         gxTv_SdtDocumentoArquivo_Docarqobservacao_Z = "";
         gxTv_SdtDocumentoArquivo_Docarqarmexternopath_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "core.documentoarquivo", "GeneXus.Programs.core.documentoarquivo_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtDocumentoArquivo_Docultarqseq ;
      private short gxTv_SdtDocumentoArquivo_Docversao ;
      private short gxTv_SdtDocumentoArquivo_Docarqseq ;
      private short gxTv_SdtDocumentoArquivo_Initialized ;
      private short gxTv_SdtDocumentoArquivo_Docultarqseq_Z ;
      private short gxTv_SdtDocumentoArquivo_Docversao_Z ;
      private short gxTv_SdtDocumentoArquivo_Docarqseq_Z ;
      private short gxTv_SdtDocumentoArquivo_Docultarqseq_N ;
      private short gxTv_SdtDocumentoArquivo_Docversaoidpai_N ;
      private short gxTv_SdtDocumentoArquivo_Docarqinsusuid_N ;
      private short gxTv_SdtDocumentoArquivo_Docarqupddata_N ;
      private short gxTv_SdtDocumentoArquivo_Docarqupdhora_N ;
      private short gxTv_SdtDocumentoArquivo_Docarqupddatahora_N ;
      private short gxTv_SdtDocumentoArquivo_Docarqusuid_N ;
      private short gxTv_SdtDocumentoArquivo_Docarqdeldatahora_N ;
      private short gxTv_SdtDocumentoArquivo_Docarqdeldata_N ;
      private short gxTv_SdtDocumentoArquivo_Docarqdelhora_N ;
      private short gxTv_SdtDocumentoArquivo_Docarqdelusuid_N ;
      private short gxTv_SdtDocumentoArquivo_Docarqdelusunome_N ;
      private short gxTv_SdtDocumentoArquivo_Docarqconteudo_N ;
      private short gxTv_SdtDocumentoArquivo_Docarqobservacao_N ;
      private short gxTv_SdtDocumentoArquivo_Docarqarmexternopath_N ;
      private string gxTv_SdtDocumentoArquivo_Docarqinsusuid ;
      private string gxTv_SdtDocumentoArquivo_Docarqusuid ;
      private string gxTv_SdtDocumentoArquivo_Docarqdelusuid ;
      private string gxTv_SdtDocumentoArquivo_Mode ;
      private string gxTv_SdtDocumentoArquivo_Docarqinsusuid_Z ;
      private string gxTv_SdtDocumentoArquivo_Docarqusuid_Z ;
      private string gxTv_SdtDocumentoArquivo_Docarqdelusuid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtDocumentoArquivo_Docarqinshora ;
      private DateTime gxTv_SdtDocumentoArquivo_Docarqinsdatahora ;
      private DateTime gxTv_SdtDocumentoArquivo_Docarqupdhora ;
      private DateTime gxTv_SdtDocumentoArquivo_Docarqupddatahora ;
      private DateTime gxTv_SdtDocumentoArquivo_Docarqdeldatahora ;
      private DateTime gxTv_SdtDocumentoArquivo_Docarqdeldata ;
      private DateTime gxTv_SdtDocumentoArquivo_Docarqdelhora ;
      private DateTime gxTv_SdtDocumentoArquivo_Docarqinshora_Z ;
      private DateTime gxTv_SdtDocumentoArquivo_Docarqinsdatahora_Z ;
      private DateTime gxTv_SdtDocumentoArquivo_Docarqupdhora_Z ;
      private DateTime gxTv_SdtDocumentoArquivo_Docarqupddatahora_Z ;
      private DateTime gxTv_SdtDocumentoArquivo_Docarqdeldatahora_Z ;
      private DateTime gxTv_SdtDocumentoArquivo_Docarqdeldata_Z ;
      private DateTime gxTv_SdtDocumentoArquivo_Docarqdelhora_Z ;
      private DateTime datetime_STZ ;
      private DateTime datetimemil_STZ ;
      private DateTime gxTv_SdtDocumentoArquivo_Docarqinsdata ;
      private DateTime gxTv_SdtDocumentoArquivo_Docarqupddata ;
      private DateTime gxTv_SdtDocumentoArquivo_Docarqinsdata_Z ;
      private DateTime gxTv_SdtDocumentoArquivo_Docarqupddata_Z ;
      private bool gxTv_SdtDocumentoArquivo_Docarqdel ;
      private bool gxTv_SdtDocumentoArquivo_Docarqarmexterno ;
      private bool gxTv_SdtDocumentoArquivo_Docarqdel_Z ;
      private bool gxTv_SdtDocumentoArquivo_Docarqarmexterno_Z ;
      private string gxTv_SdtDocumentoArquivo_Docarqdelusunome ;
      private string gxTv_SdtDocumentoArquivo_Docarqconteudonome ;
      private string gxTv_SdtDocumentoArquivo_Docarqconteudoextensao ;
      private string gxTv_SdtDocumentoArquivo_Docarqobservacao ;
      private string gxTv_SdtDocumentoArquivo_Docarqarmexternopath ;
      private string gxTv_SdtDocumentoArquivo_Docarqdelusunome_Z ;
      private string gxTv_SdtDocumentoArquivo_Docarqconteudonome_Z ;
      private string gxTv_SdtDocumentoArquivo_Docarqconteudoextensao_Z ;
      private string gxTv_SdtDocumentoArquivo_Docarqobservacao_Z ;
      private string gxTv_SdtDocumentoArquivo_Docarqarmexternopath_Z ;
      private Guid gxTv_SdtDocumentoArquivo_Docid ;
      private Guid gxTv_SdtDocumentoArquivo_Docversaoidpai ;
      private Guid gxTv_SdtDocumentoArquivo_Docid_Z ;
      private Guid gxTv_SdtDocumentoArquivo_Docversaoidpai_Z ;
      private string gxTv_SdtDocumentoArquivo_Docarqconteudo ;
   }

   [DataContract(Name = @"core\DocumentoArquivo", Namespace = "agl_tresorygroup")]
   public class SdtDocumentoArquivo_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtDocumentoArquivo>
   {
      public SdtDocumentoArquivo_RESTInterface( ) : base()
      {
      }

      public SdtDocumentoArquivo_RESTInterface( GeneXus.Programs.core.SdtDocumentoArquivo psdt ) : base(psdt)
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

      [DataMember( Name = "DocUltArqSeq" , Order = 1 )]
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

      [DataMember( Name = "DocVersao" , Order = 2 )]
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

      [DataMember( Name = "DocVersaoIDPai" , Order = 3 )]
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

      [DataMember( Name = "DocArqSeq" , Order = 4 )]
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

      [DataMember( Name = "DocArqInsData" , Order = 5 )]
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

      [DataMember( Name = "DocArqInsHora" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Docarqinshora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Docarqinshora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Docarqinshora = GXt_dtime1;
         }

      }

      [DataMember( Name = "DocArqInsDataHora" , Order = 7 )]
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

      [DataMember( Name = "DocArqInsUsuID" , Order = 8 )]
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

      [DataMember( Name = "DocArqUpdData" , Order = 9 )]
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

      [DataMember( Name = "DocArqUpdHora" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Docarqupdhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Docarqupdhora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Docarqupdhora = GXt_dtime1;
         }

      }

      [DataMember( Name = "DocArqUpdDataHora" , Order = 11 )]
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

      [DataMember( Name = "DocArqUsuID" , Order = 12 )]
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

      [DataMember( Name = "DocArqDel" , Order = 13 )]
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

      [DataMember( Name = "DocArqDelDataHora" , Order = 14 )]
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

      [DataMember( Name = "DocArqDelData" , Order = 15 )]
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

      [DataMember( Name = "DocArqDelHora" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Docarqdelhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Docarqdelhora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Docarqdelhora = GXt_dtime1;
         }

      }

      [DataMember( Name = "DocArqDelUsuID" , Order = 17 )]
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

      [DataMember( Name = "DocArqDelUsuNome" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Docarqdelusunome
      {
         get {
            return sdt.gxTpr_Docarqdelusunome ;
         }

         set {
            sdt.gxTpr_Docarqdelusunome = value;
         }

      }

      [DataMember( Name = "DocArqConteudo" , Order = 19 )]
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

      [DataMember( Name = "DocArqConteudoNome" , Order = 20 )]
      public string gxTpr_Docarqconteudonome
      {
         get {
            return sdt.gxTpr_Docarqconteudonome ;
         }

         set {
            sdt.gxTpr_Docarqconteudonome = value;
         }

      }

      [DataMember( Name = "DocArqConteudoExtensao" , Order = 21 )]
      public string gxTpr_Docarqconteudoextensao
      {
         get {
            return sdt.gxTpr_Docarqconteudoextensao ;
         }

         set {
            sdt.gxTpr_Docarqconteudoextensao = value;
         }

      }

      [DataMember( Name = "DocArqObservacao" , Order = 22 )]
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

      [DataMember( Name = "DocArqArmExterno" , Order = 23 )]
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

      [DataMember( Name = "DocArqArmExternoPath" , Order = 24 )]
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

      public GeneXus.Programs.core.SdtDocumentoArquivo sdt
      {
         get {
            return (GeneXus.Programs.core.SdtDocumentoArquivo)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtDocumentoArquivo() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 25 )]
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

   [DataContract(Name = @"core\DocumentoArquivo", Namespace = "agl_tresorygroup")]
   public class SdtDocumentoArquivo_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtDocumentoArquivo>
   {
      public SdtDocumentoArquivo_RESTLInterface( ) : base()
      {
      }

      public SdtDocumentoArquivo_RESTLInterface( GeneXus.Programs.core.SdtDocumentoArquivo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DocArqInsData" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public GeneXus.Programs.core.SdtDocumentoArquivo sdt
      {
         get {
            return (GeneXus.Programs.core.SdtDocumentoArquivo)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtDocumentoArquivo() ;
         }
      }

   }

}
