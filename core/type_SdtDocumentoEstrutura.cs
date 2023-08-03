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
   [XmlRoot(ElementName = "DocumentoEstrutura" )]
   [XmlType(TypeName =  "DocumentoEstrutura" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class SdtDocumentoEstrutura : GxSilentTrnSdt
   {
      public SdtDocumentoEstrutura( )
      {
      }

      public SdtDocumentoEstrutura( IGxContext context )
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
         metadata.Set("Name", "core\\DocumentoEstrutura");
         metadata.Set("BT", "tb_documento");
         metadata.Set("PK", "[ \"DocID\" ]");
         metadata.Set("PKAssigned", "[ \"DocID\" ]");
         metadata.Set("Levels", "[ \"Arquivos\" ]");
         metadata.Set("Serial", "[ [ \"Same\",\"tb_documento\",\"DocUltArqSeq\",\"DocArqSeq\",\"DocID\",\"DocID\" ] ]");
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
         state.Add("gxTpr_Docdeldata_Z_Nullable");
         state.Add("gxTpr_Docdelhora_Z_Nullable");
         state.Add("gxTpr_Docdeldatahora_Z_Nullable");
         state.Add("gxTpr_Docdelusuid_Z");
         state.Add("gxTpr_Docnome_Z");
         state.Add("gxTpr_Doctipoid_Z");
         state.Add("gxTpr_Doctiposigla_Z");
         state.Add("gxTpr_Doctiponome_Z");
         state.Add("gxTpr_Doctipoativo_Z");
         state.Add("gxTpr_Docultarqseq_Z");
         state.Add("gxTpr_Docativo_Z");
         state.Add("gxTpr_Docassinado_Z");
         state.Add("gxTpr_Doccontrato_Z");
         state.Add("gxTpr_Docversaoidpai_N");
         state.Add("gxTpr_Docinsusuid_N");
         state.Add("gxTpr_Docupddata_N");
         state.Add("gxTpr_Docupdhora_N");
         state.Add("gxTpr_Docupddatahora_N");
         state.Add("gxTpr_Docupdusuid_N");
         state.Add("gxTpr_Docdeldata_N");
         state.Add("gxTpr_Docdelhora_N");
         state.Add("gxTpr_Docdeldatahora_N");
         state.Add("gxTpr_Docdelusuid_N");
         state.Add("gxTpr_Docultarqseq_N");
         state.Add("gxTpr_Docativo_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.SdtDocumentoEstrutura sdt;
         sdt = (GeneXus.Programs.core.SdtDocumentoEstrutura)(source);
         gxTv_SdtDocumentoEstrutura_Docid = sdt.gxTv_SdtDocumentoEstrutura_Docid ;
         gxTv_SdtDocumentoEstrutura_Docversao = sdt.gxTv_SdtDocumentoEstrutura_Docversao ;
         gxTv_SdtDocumentoEstrutura_Docversaoidpai = sdt.gxTv_SdtDocumentoEstrutura_Docversaoidpai ;
         gxTv_SdtDocumentoEstrutura_Docversaonomepai = sdt.gxTv_SdtDocumentoEstrutura_Docversaonomepai ;
         gxTv_SdtDocumentoEstrutura_Docorigem = sdt.gxTv_SdtDocumentoEstrutura_Docorigem ;
         gxTv_SdtDocumentoEstrutura_Docorigemid = sdt.gxTv_SdtDocumentoEstrutura_Docorigemid ;
         gxTv_SdtDocumentoEstrutura_Docinsdata = sdt.gxTv_SdtDocumentoEstrutura_Docinsdata ;
         gxTv_SdtDocumentoEstrutura_Docinshora = sdt.gxTv_SdtDocumentoEstrutura_Docinshora ;
         gxTv_SdtDocumentoEstrutura_Docinsdatahora = sdt.gxTv_SdtDocumentoEstrutura_Docinsdatahora ;
         gxTv_SdtDocumentoEstrutura_Docinsusuid = sdt.gxTv_SdtDocumentoEstrutura_Docinsusuid ;
         gxTv_SdtDocumentoEstrutura_Docupddata = sdt.gxTv_SdtDocumentoEstrutura_Docupddata ;
         gxTv_SdtDocumentoEstrutura_Docupdhora = sdt.gxTv_SdtDocumentoEstrutura_Docupdhora ;
         gxTv_SdtDocumentoEstrutura_Docupddatahora = sdt.gxTv_SdtDocumentoEstrutura_Docupddatahora ;
         gxTv_SdtDocumentoEstrutura_Docupdusuid = sdt.gxTv_SdtDocumentoEstrutura_Docupdusuid ;
         gxTv_SdtDocumentoEstrutura_Docdel = sdt.gxTv_SdtDocumentoEstrutura_Docdel ;
         gxTv_SdtDocumentoEstrutura_Docdeldata = sdt.gxTv_SdtDocumentoEstrutura_Docdeldata ;
         gxTv_SdtDocumentoEstrutura_Docdelhora = sdt.gxTv_SdtDocumentoEstrutura_Docdelhora ;
         gxTv_SdtDocumentoEstrutura_Docdeldatahora = sdt.gxTv_SdtDocumentoEstrutura_Docdeldatahora ;
         gxTv_SdtDocumentoEstrutura_Docdelusuid = sdt.gxTv_SdtDocumentoEstrutura_Docdelusuid ;
         gxTv_SdtDocumentoEstrutura_Docnome = sdt.gxTv_SdtDocumentoEstrutura_Docnome ;
         gxTv_SdtDocumentoEstrutura_Doctipoid = sdt.gxTv_SdtDocumentoEstrutura_Doctipoid ;
         gxTv_SdtDocumentoEstrutura_Doctiposigla = sdt.gxTv_SdtDocumentoEstrutura_Doctiposigla ;
         gxTv_SdtDocumentoEstrutura_Doctiponome = sdt.gxTv_SdtDocumentoEstrutura_Doctiponome ;
         gxTv_SdtDocumentoEstrutura_Doctipoativo = sdt.gxTv_SdtDocumentoEstrutura_Doctipoativo ;
         gxTv_SdtDocumentoEstrutura_Docultarqseq = sdt.gxTv_SdtDocumentoEstrutura_Docultarqseq ;
         gxTv_SdtDocumentoEstrutura_Arquivos = sdt.gxTv_SdtDocumentoEstrutura_Arquivos ;
         gxTv_SdtDocumentoEstrutura_Docativo = sdt.gxTv_SdtDocumentoEstrutura_Docativo ;
         gxTv_SdtDocumentoEstrutura_Docassinado = sdt.gxTv_SdtDocumentoEstrutura_Docassinado ;
         gxTv_SdtDocumentoEstrutura_Doccontrato = sdt.gxTv_SdtDocumentoEstrutura_Doccontrato ;
         gxTv_SdtDocumentoEstrutura_Mode = sdt.gxTv_SdtDocumentoEstrutura_Mode ;
         gxTv_SdtDocumentoEstrutura_Initialized = sdt.gxTv_SdtDocumentoEstrutura_Initialized ;
         gxTv_SdtDocumentoEstrutura_Docid_Z = sdt.gxTv_SdtDocumentoEstrutura_Docid_Z ;
         gxTv_SdtDocumentoEstrutura_Docversao_Z = sdt.gxTv_SdtDocumentoEstrutura_Docversao_Z ;
         gxTv_SdtDocumentoEstrutura_Docversaoidpai_Z = sdt.gxTv_SdtDocumentoEstrutura_Docversaoidpai_Z ;
         gxTv_SdtDocumentoEstrutura_Docversaonomepai_Z = sdt.gxTv_SdtDocumentoEstrutura_Docversaonomepai_Z ;
         gxTv_SdtDocumentoEstrutura_Docorigem_Z = sdt.gxTv_SdtDocumentoEstrutura_Docorigem_Z ;
         gxTv_SdtDocumentoEstrutura_Docorigemid_Z = sdt.gxTv_SdtDocumentoEstrutura_Docorigemid_Z ;
         gxTv_SdtDocumentoEstrutura_Docinsdata_Z = sdt.gxTv_SdtDocumentoEstrutura_Docinsdata_Z ;
         gxTv_SdtDocumentoEstrutura_Docinshora_Z = sdt.gxTv_SdtDocumentoEstrutura_Docinshora_Z ;
         gxTv_SdtDocumentoEstrutura_Docinsdatahora_Z = sdt.gxTv_SdtDocumentoEstrutura_Docinsdatahora_Z ;
         gxTv_SdtDocumentoEstrutura_Docinsusuid_Z = sdt.gxTv_SdtDocumentoEstrutura_Docinsusuid_Z ;
         gxTv_SdtDocumentoEstrutura_Docupddata_Z = sdt.gxTv_SdtDocumentoEstrutura_Docupddata_Z ;
         gxTv_SdtDocumentoEstrutura_Docupdhora_Z = sdt.gxTv_SdtDocumentoEstrutura_Docupdhora_Z ;
         gxTv_SdtDocumentoEstrutura_Docupddatahora_Z = sdt.gxTv_SdtDocumentoEstrutura_Docupddatahora_Z ;
         gxTv_SdtDocumentoEstrutura_Docupdusuid_Z = sdt.gxTv_SdtDocumentoEstrutura_Docupdusuid_Z ;
         gxTv_SdtDocumentoEstrutura_Docdel_Z = sdt.gxTv_SdtDocumentoEstrutura_Docdel_Z ;
         gxTv_SdtDocumentoEstrutura_Docdeldata_Z = sdt.gxTv_SdtDocumentoEstrutura_Docdeldata_Z ;
         gxTv_SdtDocumentoEstrutura_Docdelhora_Z = sdt.gxTv_SdtDocumentoEstrutura_Docdelhora_Z ;
         gxTv_SdtDocumentoEstrutura_Docdeldatahora_Z = sdt.gxTv_SdtDocumentoEstrutura_Docdeldatahora_Z ;
         gxTv_SdtDocumentoEstrutura_Docdelusuid_Z = sdt.gxTv_SdtDocumentoEstrutura_Docdelusuid_Z ;
         gxTv_SdtDocumentoEstrutura_Docnome_Z = sdt.gxTv_SdtDocumentoEstrutura_Docnome_Z ;
         gxTv_SdtDocumentoEstrutura_Doctipoid_Z = sdt.gxTv_SdtDocumentoEstrutura_Doctipoid_Z ;
         gxTv_SdtDocumentoEstrutura_Doctiposigla_Z = sdt.gxTv_SdtDocumentoEstrutura_Doctiposigla_Z ;
         gxTv_SdtDocumentoEstrutura_Doctiponome_Z = sdt.gxTv_SdtDocumentoEstrutura_Doctiponome_Z ;
         gxTv_SdtDocumentoEstrutura_Doctipoativo_Z = sdt.gxTv_SdtDocumentoEstrutura_Doctipoativo_Z ;
         gxTv_SdtDocumentoEstrutura_Docultarqseq_Z = sdt.gxTv_SdtDocumentoEstrutura_Docultarqseq_Z ;
         gxTv_SdtDocumentoEstrutura_Docativo_Z = sdt.gxTv_SdtDocumentoEstrutura_Docativo_Z ;
         gxTv_SdtDocumentoEstrutura_Docassinado_Z = sdt.gxTv_SdtDocumentoEstrutura_Docassinado_Z ;
         gxTv_SdtDocumentoEstrutura_Doccontrato_Z = sdt.gxTv_SdtDocumentoEstrutura_Doccontrato_Z ;
         gxTv_SdtDocumentoEstrutura_Docversaoidpai_N = sdt.gxTv_SdtDocumentoEstrutura_Docversaoidpai_N ;
         gxTv_SdtDocumentoEstrutura_Docinsusuid_N = sdt.gxTv_SdtDocumentoEstrutura_Docinsusuid_N ;
         gxTv_SdtDocumentoEstrutura_Docupddata_N = sdt.gxTv_SdtDocumentoEstrutura_Docupddata_N ;
         gxTv_SdtDocumentoEstrutura_Docupdhora_N = sdt.gxTv_SdtDocumentoEstrutura_Docupdhora_N ;
         gxTv_SdtDocumentoEstrutura_Docupddatahora_N = sdt.gxTv_SdtDocumentoEstrutura_Docupddatahora_N ;
         gxTv_SdtDocumentoEstrutura_Docupdusuid_N = sdt.gxTv_SdtDocumentoEstrutura_Docupdusuid_N ;
         gxTv_SdtDocumentoEstrutura_Docdeldata_N = sdt.gxTv_SdtDocumentoEstrutura_Docdeldata_N ;
         gxTv_SdtDocumentoEstrutura_Docdelhora_N = sdt.gxTv_SdtDocumentoEstrutura_Docdelhora_N ;
         gxTv_SdtDocumentoEstrutura_Docdeldatahora_N = sdt.gxTv_SdtDocumentoEstrutura_Docdeldatahora_N ;
         gxTv_SdtDocumentoEstrutura_Docdelusuid_N = sdt.gxTv_SdtDocumentoEstrutura_Docdelusuid_N ;
         gxTv_SdtDocumentoEstrutura_Docultarqseq_N = sdt.gxTv_SdtDocumentoEstrutura_Docultarqseq_N ;
         gxTv_SdtDocumentoEstrutura_Docativo_N = sdt.gxTv_SdtDocumentoEstrutura_Docativo_N ;
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
         AddObjectProperty("DocID", gxTv_SdtDocumentoEstrutura_Docid, false, includeNonInitialized);
         AddObjectProperty("DocVersao", gxTv_SdtDocumentoEstrutura_Docversao, false, includeNonInitialized);
         AddObjectProperty("DocVersaoIDPai", gxTv_SdtDocumentoEstrutura_Docversaoidpai, false, includeNonInitialized);
         AddObjectProperty("DocVersaoIDPai_N", gxTv_SdtDocumentoEstrutura_Docversaoidpai_N, false, includeNonInitialized);
         AddObjectProperty("DocVersaoNomePai", gxTv_SdtDocumentoEstrutura_Docversaonomepai, false, includeNonInitialized);
         AddObjectProperty("DocOrigem", gxTv_SdtDocumentoEstrutura_Docorigem, false, includeNonInitialized);
         AddObjectProperty("DocOrigemID", gxTv_SdtDocumentoEstrutura_Docorigemid, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocumentoEstrutura_Docinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocumentoEstrutura_Docinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocumentoEstrutura_Docinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("DocInsData", sDateCnv, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtDocumentoEstrutura_Docinshora;
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
         datetimemil_STZ = gxTv_SdtDocumentoEstrutura_Docinsdatahora;
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
         AddObjectProperty("DocInsUsuID", gxTv_SdtDocumentoEstrutura_Docinsusuid, false, includeNonInitialized);
         AddObjectProperty("DocInsUsuID_N", gxTv_SdtDocumentoEstrutura_Docinsusuid_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocumentoEstrutura_Docupddata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocumentoEstrutura_Docupddata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocumentoEstrutura_Docupddata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("DocUpdData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DocUpdData_N", gxTv_SdtDocumentoEstrutura_Docupddata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtDocumentoEstrutura_Docupdhora;
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
         AddObjectProperty("DocUpdHora_N", gxTv_SdtDocumentoEstrutura_Docupdhora_N, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtDocumentoEstrutura_Docupddatahora;
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
         AddObjectProperty("DocUpdDataHora_N", gxTv_SdtDocumentoEstrutura_Docupddatahora_N, false, includeNonInitialized);
         AddObjectProperty("DocUpdUsuID", gxTv_SdtDocumentoEstrutura_Docupdusuid, false, includeNonInitialized);
         AddObjectProperty("DocUpdUsuID_N", gxTv_SdtDocumentoEstrutura_Docupdusuid_N, false, includeNonInitialized);
         AddObjectProperty("DocDel", gxTv_SdtDocumentoEstrutura_Docdel, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtDocumentoEstrutura_Docdeldata;
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
         AddObjectProperty("DocDelData_N", gxTv_SdtDocumentoEstrutura_Docdeldata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtDocumentoEstrutura_Docdelhora;
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
         AddObjectProperty("DocDelHora_N", gxTv_SdtDocumentoEstrutura_Docdelhora_N, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtDocumentoEstrutura_Docdeldatahora;
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
         AddObjectProperty("DocDelDataHora_N", gxTv_SdtDocumentoEstrutura_Docdeldatahora_N, false, includeNonInitialized);
         AddObjectProperty("DocDelUsuID", gxTv_SdtDocumentoEstrutura_Docdelusuid, false, includeNonInitialized);
         AddObjectProperty("DocDelUsuID_N", gxTv_SdtDocumentoEstrutura_Docdelusuid_N, false, includeNonInitialized);
         AddObjectProperty("DocNome", gxTv_SdtDocumentoEstrutura_Docnome, false, includeNonInitialized);
         AddObjectProperty("DocTipoID", gxTv_SdtDocumentoEstrutura_Doctipoid, false, includeNonInitialized);
         AddObjectProperty("DocTipoSigla", gxTv_SdtDocumentoEstrutura_Doctiposigla, false, includeNonInitialized);
         AddObjectProperty("DocTipoNome", gxTv_SdtDocumentoEstrutura_Doctiponome, false, includeNonInitialized);
         AddObjectProperty("DocTipoAtivo", gxTv_SdtDocumentoEstrutura_Doctipoativo, false, includeNonInitialized);
         AddObjectProperty("DocUltArqSeq", gxTv_SdtDocumentoEstrutura_Docultarqseq, false, includeNonInitialized);
         AddObjectProperty("DocUltArqSeq_N", gxTv_SdtDocumentoEstrutura_Docultarqseq_N, false, includeNonInitialized);
         if ( gxTv_SdtDocumentoEstrutura_Arquivos != null )
         {
            AddObjectProperty("Arquivos", gxTv_SdtDocumentoEstrutura_Arquivos, includeState, includeNonInitialized);
         }
         AddObjectProperty("DocAtivo", gxTv_SdtDocumentoEstrutura_Docativo, false, includeNonInitialized);
         AddObjectProperty("DocAtivo_N", gxTv_SdtDocumentoEstrutura_Docativo_N, false, includeNonInitialized);
         AddObjectProperty("DocAssinado", gxTv_SdtDocumentoEstrutura_Docassinado, false, includeNonInitialized);
         AddObjectProperty("DocContrato", gxTv_SdtDocumentoEstrutura_Doccontrato, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtDocumentoEstrutura_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtDocumentoEstrutura_Initialized, false, includeNonInitialized);
            AddObjectProperty("DocID_Z", gxTv_SdtDocumentoEstrutura_Docid_Z, false, includeNonInitialized);
            AddObjectProperty("DocVersao_Z", gxTv_SdtDocumentoEstrutura_Docversao_Z, false, includeNonInitialized);
            AddObjectProperty("DocVersaoIDPai_Z", gxTv_SdtDocumentoEstrutura_Docversaoidpai_Z, false, includeNonInitialized);
            AddObjectProperty("DocVersaoNomePai_Z", gxTv_SdtDocumentoEstrutura_Docversaonomepai_Z, false, includeNonInitialized);
            AddObjectProperty("DocOrigem_Z", gxTv_SdtDocumentoEstrutura_Docorigem_Z, false, includeNonInitialized);
            AddObjectProperty("DocOrigemID_Z", gxTv_SdtDocumentoEstrutura_Docorigemid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocumentoEstrutura_Docinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocumentoEstrutura_Docinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocumentoEstrutura_Docinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("DocInsData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtDocumentoEstrutura_Docinshora_Z;
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
            datetimemil_STZ = gxTv_SdtDocumentoEstrutura_Docinsdatahora_Z;
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
            AddObjectProperty("DocInsUsuID_Z", gxTv_SdtDocumentoEstrutura_Docinsusuid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocumentoEstrutura_Docupddata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocumentoEstrutura_Docupddata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocumentoEstrutura_Docupddata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("DocUpdData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtDocumentoEstrutura_Docupdhora_Z;
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
            datetimemil_STZ = gxTv_SdtDocumentoEstrutura_Docupddatahora_Z;
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
            AddObjectProperty("DocUpdUsuID_Z", gxTv_SdtDocumentoEstrutura_Docupdusuid_Z, false, includeNonInitialized);
            AddObjectProperty("DocDel_Z", gxTv_SdtDocumentoEstrutura_Docdel_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtDocumentoEstrutura_Docdeldata_Z;
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
            datetime_STZ = gxTv_SdtDocumentoEstrutura_Docdelhora_Z;
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
            datetimemil_STZ = gxTv_SdtDocumentoEstrutura_Docdeldatahora_Z;
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
            AddObjectProperty("DocDelUsuID_Z", gxTv_SdtDocumentoEstrutura_Docdelusuid_Z, false, includeNonInitialized);
            AddObjectProperty("DocNome_Z", gxTv_SdtDocumentoEstrutura_Docnome_Z, false, includeNonInitialized);
            AddObjectProperty("DocTipoID_Z", gxTv_SdtDocumentoEstrutura_Doctipoid_Z, false, includeNonInitialized);
            AddObjectProperty("DocTipoSigla_Z", gxTv_SdtDocumentoEstrutura_Doctiposigla_Z, false, includeNonInitialized);
            AddObjectProperty("DocTipoNome_Z", gxTv_SdtDocumentoEstrutura_Doctiponome_Z, false, includeNonInitialized);
            AddObjectProperty("DocTipoAtivo_Z", gxTv_SdtDocumentoEstrutura_Doctipoativo_Z, false, includeNonInitialized);
            AddObjectProperty("DocUltArqSeq_Z", gxTv_SdtDocumentoEstrutura_Docultarqseq_Z, false, includeNonInitialized);
            AddObjectProperty("DocAtivo_Z", gxTv_SdtDocumentoEstrutura_Docativo_Z, false, includeNonInitialized);
            AddObjectProperty("DocAssinado_Z", gxTv_SdtDocumentoEstrutura_Docassinado_Z, false, includeNonInitialized);
            AddObjectProperty("DocContrato_Z", gxTv_SdtDocumentoEstrutura_Doccontrato_Z, false, includeNonInitialized);
            AddObjectProperty("DocVersaoIDPai_N", gxTv_SdtDocumentoEstrutura_Docversaoidpai_N, false, includeNonInitialized);
            AddObjectProperty("DocInsUsuID_N", gxTv_SdtDocumentoEstrutura_Docinsusuid_N, false, includeNonInitialized);
            AddObjectProperty("DocUpdData_N", gxTv_SdtDocumentoEstrutura_Docupddata_N, false, includeNonInitialized);
            AddObjectProperty("DocUpdHora_N", gxTv_SdtDocumentoEstrutura_Docupdhora_N, false, includeNonInitialized);
            AddObjectProperty("DocUpdDataHora_N", gxTv_SdtDocumentoEstrutura_Docupddatahora_N, false, includeNonInitialized);
            AddObjectProperty("DocUpdUsuID_N", gxTv_SdtDocumentoEstrutura_Docupdusuid_N, false, includeNonInitialized);
            AddObjectProperty("DocDelData_N", gxTv_SdtDocumentoEstrutura_Docdeldata_N, false, includeNonInitialized);
            AddObjectProperty("DocDelHora_N", gxTv_SdtDocumentoEstrutura_Docdelhora_N, false, includeNonInitialized);
            AddObjectProperty("DocDelDataHora_N", gxTv_SdtDocumentoEstrutura_Docdeldatahora_N, false, includeNonInitialized);
            AddObjectProperty("DocDelUsuID_N", gxTv_SdtDocumentoEstrutura_Docdelusuid_N, false, includeNonInitialized);
            AddObjectProperty("DocUltArqSeq_N", gxTv_SdtDocumentoEstrutura_Docultarqseq_N, false, includeNonInitialized);
            AddObjectProperty("DocAtivo_N", gxTv_SdtDocumentoEstrutura_Docativo_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.SdtDocumentoEstrutura sdt )
      {
         if ( sdt.IsDirty("DocID") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docid = sdt.gxTv_SdtDocumentoEstrutura_Docid ;
         }
         if ( sdt.IsDirty("DocVersao") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docversao = sdt.gxTv_SdtDocumentoEstrutura_Docversao ;
         }
         if ( sdt.IsDirty("DocVersaoIDPai") )
         {
            gxTv_SdtDocumentoEstrutura_Docversaoidpai_N = (short)(sdt.gxTv_SdtDocumentoEstrutura_Docversaoidpai_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docversaoidpai = sdt.gxTv_SdtDocumentoEstrutura_Docversaoidpai ;
         }
         if ( sdt.IsDirty("DocVersaoNomePai") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docversaonomepai = sdt.gxTv_SdtDocumentoEstrutura_Docversaonomepai ;
         }
         if ( sdt.IsDirty("DocOrigem") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docorigem = sdt.gxTv_SdtDocumentoEstrutura_Docorigem ;
         }
         if ( sdt.IsDirty("DocOrigemID") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docorigemid = sdt.gxTv_SdtDocumentoEstrutura_Docorigemid ;
         }
         if ( sdt.IsDirty("DocInsData") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docinsdata = sdt.gxTv_SdtDocumentoEstrutura_Docinsdata ;
         }
         if ( sdt.IsDirty("DocInsHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docinshora = sdt.gxTv_SdtDocumentoEstrutura_Docinshora ;
         }
         if ( sdt.IsDirty("DocInsDataHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docinsdatahora = sdt.gxTv_SdtDocumentoEstrutura_Docinsdatahora ;
         }
         if ( sdt.IsDirty("DocInsUsuID") )
         {
            gxTv_SdtDocumentoEstrutura_Docinsusuid_N = (short)(sdt.gxTv_SdtDocumentoEstrutura_Docinsusuid_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docinsusuid = sdt.gxTv_SdtDocumentoEstrutura_Docinsusuid ;
         }
         if ( sdt.IsDirty("DocUpdData") )
         {
            gxTv_SdtDocumentoEstrutura_Docupddata_N = (short)(sdt.gxTv_SdtDocumentoEstrutura_Docupddata_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docupddata = sdt.gxTv_SdtDocumentoEstrutura_Docupddata ;
         }
         if ( sdt.IsDirty("DocUpdHora") )
         {
            gxTv_SdtDocumentoEstrutura_Docupdhora_N = (short)(sdt.gxTv_SdtDocumentoEstrutura_Docupdhora_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docupdhora = sdt.gxTv_SdtDocumentoEstrutura_Docupdhora ;
         }
         if ( sdt.IsDirty("DocUpdDataHora") )
         {
            gxTv_SdtDocumentoEstrutura_Docupddatahora_N = (short)(sdt.gxTv_SdtDocumentoEstrutura_Docupddatahora_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docupddatahora = sdt.gxTv_SdtDocumentoEstrutura_Docupddatahora ;
         }
         if ( sdt.IsDirty("DocUpdUsuID") )
         {
            gxTv_SdtDocumentoEstrutura_Docupdusuid_N = (short)(sdt.gxTv_SdtDocumentoEstrutura_Docupdusuid_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docupdusuid = sdt.gxTv_SdtDocumentoEstrutura_Docupdusuid ;
         }
         if ( sdt.IsDirty("DocDel") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docdel = sdt.gxTv_SdtDocumentoEstrutura_Docdel ;
         }
         if ( sdt.IsDirty("DocDelData") )
         {
            gxTv_SdtDocumentoEstrutura_Docdeldata_N = (short)(sdt.gxTv_SdtDocumentoEstrutura_Docdeldata_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docdeldata = sdt.gxTv_SdtDocumentoEstrutura_Docdeldata ;
         }
         if ( sdt.IsDirty("DocDelHora") )
         {
            gxTv_SdtDocumentoEstrutura_Docdelhora_N = (short)(sdt.gxTv_SdtDocumentoEstrutura_Docdelhora_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docdelhora = sdt.gxTv_SdtDocumentoEstrutura_Docdelhora ;
         }
         if ( sdt.IsDirty("DocDelDataHora") )
         {
            gxTv_SdtDocumentoEstrutura_Docdeldatahora_N = (short)(sdt.gxTv_SdtDocumentoEstrutura_Docdeldatahora_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docdeldatahora = sdt.gxTv_SdtDocumentoEstrutura_Docdeldatahora ;
         }
         if ( sdt.IsDirty("DocDelUsuID") )
         {
            gxTv_SdtDocumentoEstrutura_Docdelusuid_N = (short)(sdt.gxTv_SdtDocumentoEstrutura_Docdelusuid_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docdelusuid = sdt.gxTv_SdtDocumentoEstrutura_Docdelusuid ;
         }
         if ( sdt.IsDirty("DocNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docnome = sdt.gxTv_SdtDocumentoEstrutura_Docnome ;
         }
         if ( sdt.IsDirty("DocTipoID") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Doctipoid = sdt.gxTv_SdtDocumentoEstrutura_Doctipoid ;
         }
         if ( sdt.IsDirty("DocTipoSigla") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Doctiposigla = sdt.gxTv_SdtDocumentoEstrutura_Doctiposigla ;
         }
         if ( sdt.IsDirty("DocTipoNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Doctiponome = sdt.gxTv_SdtDocumentoEstrutura_Doctiponome ;
         }
         if ( sdt.IsDirty("DocTipoAtivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Doctipoativo = sdt.gxTv_SdtDocumentoEstrutura_Doctipoativo ;
         }
         if ( sdt.IsDirty("DocUltArqSeq") )
         {
            gxTv_SdtDocumentoEstrutura_Docultarqseq_N = (short)(sdt.gxTv_SdtDocumentoEstrutura_Docultarqseq_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docultarqseq = sdt.gxTv_SdtDocumentoEstrutura_Docultarqseq ;
         }
         if ( gxTv_SdtDocumentoEstrutura_Arquivos != null )
         {
            GXBCLevelCollection<GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos> newCollectionArquivos = sdt.gxTpr_Arquivos;
            GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos currItemArquivos;
            GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos newItemArquivos;
            short idx = 1;
            while ( idx <= newCollectionArquivos.Count )
            {
               newItemArquivos = ((GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos)newCollectionArquivos.Item(idx));
               currItemArquivos = gxTv_SdtDocumentoEstrutura_Arquivos.GetByKey(newItemArquivos.gxTpr_Docarqseq);
               if ( StringUtil.StrCmp(currItemArquivos.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemArquivos.UpdateDirties(newItemArquivos);
                  if ( StringUtil.StrCmp(newItemArquivos.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemArquivos.gxTpr_Mode = "DLT";
                  }
                  currItemArquivos.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtDocumentoEstrutura_Arquivos.Add(newItemArquivos, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( sdt.IsDirty("DocAtivo") )
         {
            gxTv_SdtDocumentoEstrutura_Docativo_N = (short)(sdt.gxTv_SdtDocumentoEstrutura_Docativo_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docativo = sdt.gxTv_SdtDocumentoEstrutura_Docativo ;
         }
         if ( sdt.IsDirty("DocAssinado") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docassinado = sdt.gxTv_SdtDocumentoEstrutura_Docassinado ;
         }
         if ( sdt.IsDirty("DocContrato") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Doccontrato = sdt.gxTv_SdtDocumentoEstrutura_Doccontrato ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "DocID" )]
      [  XmlElement( ElementName = "DocID"   )]
      public Guid gxTpr_Docid
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtDocumentoEstrutura_Docid != value )
            {
               gxTv_SdtDocumentoEstrutura_Mode = "INS";
               this.gxTv_SdtDocumentoEstrutura_Docid_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Docversao_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Docversaoidpai_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Docversaonomepai_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Docorigem_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Docorigemid_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Docinsdata_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Docinshora_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Docinsdatahora_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Docinsusuid_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Docupddata_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Docupdhora_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Docupddatahora_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Docupdusuid_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Docdel_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Docdeldata_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Docdelhora_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Docdeldatahora_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Docdelusuid_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Docnome_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Doctipoid_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Doctiposigla_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Doctiponome_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Doctipoativo_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Docultarqseq_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Docativo_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Docassinado_Z_SetNull( );
               this.gxTv_SdtDocumentoEstrutura_Doccontrato_Z_SetNull( );
               if ( gxTv_SdtDocumentoEstrutura_Arquivos != null )
               {
                  GXBCLevelCollection<GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos> collectionArquivos = gxTv_SdtDocumentoEstrutura_Arquivos;
                  GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos currItemArquivos;
                  short idx = 1;
                  while ( idx <= collectionArquivos.Count )
                  {
                     currItemArquivos = ((GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos)collectionArquivos.Item(idx));
                     currItemArquivos.gxTpr_Mode = "INS";
                     currItemArquivos.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtDocumentoEstrutura_Docid = value;
            SetDirty("Docid");
         }

      }

      [  SoapElement( ElementName = "DocVersao" )]
      [  XmlElement( ElementName = "DocVersao"   )]
      public short gxTpr_Docversao
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docversao ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docversao = value;
            SetDirty("Docversao");
         }

      }

      [  SoapElement( ElementName = "DocVersaoIDPai" )]
      [  XmlElement( ElementName = "DocVersaoIDPai"   )]
      public Guid gxTpr_Docversaoidpai
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docversaoidpai ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Docversaoidpai_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docversaoidpai = value;
            SetDirty("Docversaoidpai");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docversaoidpai_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docversaoidpai_N = 1;
         gxTv_SdtDocumentoEstrutura_Docversaoidpai = Guid.Empty;
         SetDirty("Docversaoidpai");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docversaoidpai_IsNull( )
      {
         return (gxTv_SdtDocumentoEstrutura_Docversaoidpai_N==1) ;
      }

      [  SoapElement( ElementName = "DocVersaoNomePai" )]
      [  XmlElement( ElementName = "DocVersaoNomePai"   )]
      public string gxTpr_Docversaonomepai
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docversaonomepai ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docversaonomepai = value;
            SetDirty("Docversaonomepai");
         }

      }

      [  SoapElement( ElementName = "DocOrigem" )]
      [  XmlElement( ElementName = "DocOrigem"   )]
      public string gxTpr_Docorigem
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docorigem ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docorigem = value;
            SetDirty("Docorigem");
         }

      }

      [  SoapElement( ElementName = "DocOrigemID" )]
      [  XmlElement( ElementName = "DocOrigemID"   )]
      public string gxTpr_Docorigemid
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docorigemid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docorigemid = value;
            SetDirty("Docorigemid");
         }

      }

      [  SoapElement( ElementName = "DocInsData" )]
      [  XmlElement( ElementName = "DocInsData"  , IsNullable=true )]
      public string gxTpr_Docinsdata_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Docinsdata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocumentoEstrutura_Docinsdata).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocumentoEstrutura_Docinsdata = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Docinsdata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docinsdata
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docinsdata ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docinsdata = value;
            SetDirty("Docinsdata");
         }

      }

      [  SoapElement( ElementName = "DocInsHora" )]
      [  XmlElement( ElementName = "DocInsHora"  , IsNullable=true )]
      public string gxTpr_Docinshora_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Docinshora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Docinshora).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Docinshora = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Docinshora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docinshora
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docinshora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docinshora = value;
            SetDirty("Docinshora");
         }

      }

      [  SoapElement( ElementName = "DocInsDataHora" )]
      [  XmlElement( ElementName = "DocInsDataHora"  , IsNullable=true )]
      public string gxTpr_Docinsdatahora_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Docinsdatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Docinsdatahora, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Docinsdatahora = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Docinsdatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docinsdatahora
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docinsdatahora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docinsdatahora = value;
            SetDirty("Docinsdatahora");
         }

      }

      [  SoapElement( ElementName = "DocInsUsuID" )]
      [  XmlElement( ElementName = "DocInsUsuID"   )]
      public string gxTpr_Docinsusuid
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docinsusuid ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Docinsusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docinsusuid = value;
            SetDirty("Docinsusuid");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docinsusuid_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docinsusuid_N = 1;
         gxTv_SdtDocumentoEstrutura_Docinsusuid = "";
         SetDirty("Docinsusuid");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docinsusuid_IsNull( )
      {
         return (gxTv_SdtDocumentoEstrutura_Docinsusuid_N==1) ;
      }

      [  SoapElement( ElementName = "DocUpdData" )]
      [  XmlElement( ElementName = "DocUpdData"  , IsNullable=true )]
      public string gxTpr_Docupddata_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Docupddata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocumentoEstrutura_Docupddata).value ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Docupddata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocumentoEstrutura_Docupddata = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Docupddata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docupddata
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docupddata ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Docupddata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docupddata = value;
            SetDirty("Docupddata");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docupddata_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docupddata_N = 1;
         gxTv_SdtDocumentoEstrutura_Docupddata = (DateTime)(DateTime.MinValue);
         SetDirty("Docupddata");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docupddata_IsNull( )
      {
         return (gxTv_SdtDocumentoEstrutura_Docupddata_N==1) ;
      }

      [  SoapElement( ElementName = "DocUpdHora" )]
      [  XmlElement( ElementName = "DocUpdHora"  , IsNullable=true )]
      public string gxTpr_Docupdhora_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Docupdhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Docupdhora).value ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Docupdhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Docupdhora = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Docupdhora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docupdhora
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docupdhora ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Docupdhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docupdhora = value;
            SetDirty("Docupdhora");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docupdhora_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docupdhora_N = 1;
         gxTv_SdtDocumentoEstrutura_Docupdhora = (DateTime)(DateTime.MinValue);
         SetDirty("Docupdhora");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docupdhora_IsNull( )
      {
         return (gxTv_SdtDocumentoEstrutura_Docupdhora_N==1) ;
      }

      [  SoapElement( ElementName = "DocUpdDataHora" )]
      [  XmlElement( ElementName = "DocUpdDataHora"  , IsNullable=true )]
      public string gxTpr_Docupddatahora_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Docupddatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Docupddatahora, null, true).value ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Docupddatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Docupddatahora = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Docupddatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docupddatahora
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docupddatahora ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Docupddatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docupddatahora = value;
            SetDirty("Docupddatahora");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docupddatahora_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docupddatahora_N = 1;
         gxTv_SdtDocumentoEstrutura_Docupddatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Docupddatahora");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docupddatahora_IsNull( )
      {
         return (gxTv_SdtDocumentoEstrutura_Docupddatahora_N==1) ;
      }

      [  SoapElement( ElementName = "DocUpdUsuID" )]
      [  XmlElement( ElementName = "DocUpdUsuID"   )]
      public string gxTpr_Docupdusuid
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docupdusuid ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Docupdusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docupdusuid = value;
            SetDirty("Docupdusuid");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docupdusuid_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docupdusuid_N = 1;
         gxTv_SdtDocumentoEstrutura_Docupdusuid = "";
         SetDirty("Docupdusuid");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docupdusuid_IsNull( )
      {
         return (gxTv_SdtDocumentoEstrutura_Docupdusuid_N==1) ;
      }

      [  SoapElement( ElementName = "DocDel" )]
      [  XmlElement( ElementName = "DocDel"   )]
      public bool gxTpr_Docdel
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docdel ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docdel = value;
            SetDirty("Docdel");
         }

      }

      [  SoapElement( ElementName = "DocDelData" )]
      [  XmlElement( ElementName = "DocDelData"  , IsNullable=true )]
      public string gxTpr_Docdeldata_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Docdeldata == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Docdeldata).value ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Docdeldata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Docdeldata = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Docdeldata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docdeldata
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docdeldata ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Docdeldata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docdeldata = value;
            SetDirty("Docdeldata");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docdeldata_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docdeldata_N = 1;
         gxTv_SdtDocumentoEstrutura_Docdeldata = (DateTime)(DateTime.MinValue);
         SetDirty("Docdeldata");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docdeldata_IsNull( )
      {
         return (gxTv_SdtDocumentoEstrutura_Docdeldata_N==1) ;
      }

      [  SoapElement( ElementName = "DocDelHora" )]
      [  XmlElement( ElementName = "DocDelHora"  , IsNullable=true )]
      public string gxTpr_Docdelhora_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Docdelhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Docdelhora).value ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Docdelhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Docdelhora = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Docdelhora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docdelhora
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docdelhora ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Docdelhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docdelhora = value;
            SetDirty("Docdelhora");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docdelhora_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docdelhora_N = 1;
         gxTv_SdtDocumentoEstrutura_Docdelhora = (DateTime)(DateTime.MinValue);
         SetDirty("Docdelhora");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docdelhora_IsNull( )
      {
         return (gxTv_SdtDocumentoEstrutura_Docdelhora_N==1) ;
      }

      [  SoapElement( ElementName = "DocDelDataHora" )]
      [  XmlElement( ElementName = "DocDelDataHora"  , IsNullable=true )]
      public string gxTpr_Docdeldatahora_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Docdeldatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Docdeldatahora, null, true).value ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Docdeldatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Docdeldatahora = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Docdeldatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docdeldatahora
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docdeldatahora ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Docdeldatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docdeldatahora = value;
            SetDirty("Docdeldatahora");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docdeldatahora_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docdeldatahora_N = 1;
         gxTv_SdtDocumentoEstrutura_Docdeldatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Docdeldatahora");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docdeldatahora_IsNull( )
      {
         return (gxTv_SdtDocumentoEstrutura_Docdeldatahora_N==1) ;
      }

      [  SoapElement( ElementName = "DocDelUsuID" )]
      [  XmlElement( ElementName = "DocDelUsuID"   )]
      public string gxTpr_Docdelusuid
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docdelusuid ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Docdelusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docdelusuid = value;
            SetDirty("Docdelusuid");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docdelusuid_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docdelusuid_N = 1;
         gxTv_SdtDocumentoEstrutura_Docdelusuid = "";
         SetDirty("Docdelusuid");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docdelusuid_IsNull( )
      {
         return (gxTv_SdtDocumentoEstrutura_Docdelusuid_N==1) ;
      }

      [  SoapElement( ElementName = "DocNome" )]
      [  XmlElement( ElementName = "DocNome"   )]
      public string gxTpr_Docnome
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docnome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docnome = value;
            SetDirty("Docnome");
         }

      }

      [  SoapElement( ElementName = "DocTipoID" )]
      [  XmlElement( ElementName = "DocTipoID"   )]
      public int gxTpr_Doctipoid
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Doctipoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Doctipoid = value;
            SetDirty("Doctipoid");
         }

      }

      [  SoapElement( ElementName = "DocTipoSigla" )]
      [  XmlElement( ElementName = "DocTipoSigla"   )]
      public string gxTpr_Doctiposigla
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Doctiposigla ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Doctiposigla = value;
            SetDirty("Doctiposigla");
         }

      }

      [  SoapElement( ElementName = "DocTipoNome" )]
      [  XmlElement( ElementName = "DocTipoNome"   )]
      public string gxTpr_Doctiponome
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Doctiponome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Doctiponome = value;
            SetDirty("Doctiponome");
         }

      }

      [  SoapElement( ElementName = "DocTipoAtivo" )]
      [  XmlElement( ElementName = "DocTipoAtivo"   )]
      public bool gxTpr_Doctipoativo
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Doctipoativo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Doctipoativo = value;
            SetDirty("Doctipoativo");
         }

      }

      [  SoapElement( ElementName = "DocUltArqSeq" )]
      [  XmlElement( ElementName = "DocUltArqSeq"   )]
      public short gxTpr_Docultarqseq
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docultarqseq ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Docultarqseq_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docultarqseq = value;
            SetDirty("Docultarqseq");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docultarqseq_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docultarqseq_N = 1;
         gxTv_SdtDocumentoEstrutura_Docultarqseq = 0;
         SetDirty("Docultarqseq");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docultarqseq_IsNull( )
      {
         return (gxTv_SdtDocumentoEstrutura_Docultarqseq_N==1) ;
      }

      [  SoapElement( ElementName = "Arquivos" )]
      [  XmlArray( ElementName = "Arquivos"  )]
      [  XmlArrayItemAttribute( ElementName= "DocumentoEstrutura.Arquivos"  , IsNullable=false)]
      public GXBCLevelCollection<GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos> gxTpr_Arquivos_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Arquivos == null )
            {
               gxTv_SdtDocumentoEstrutura_Arquivos = new GXBCLevelCollection<GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos>( context, "DocumentoEstrutura.Arquivos", "agl_tresorygroup");
            }
            return gxTv_SdtDocumentoEstrutura_Arquivos ;
         }

         set {
            if ( gxTv_SdtDocumentoEstrutura_Arquivos == null )
            {
               gxTv_SdtDocumentoEstrutura_Arquivos = new GXBCLevelCollection<GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos>( context, "DocumentoEstrutura.Arquivos", "agl_tresorygroup");
            }
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos> gxTpr_Arquivos
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Arquivos == null )
            {
               gxTv_SdtDocumentoEstrutura_Arquivos = new GXBCLevelCollection<GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos>( context, "DocumentoEstrutura.Arquivos", "agl_tresorygroup");
            }
            sdtIsNull = 0;
            return gxTv_SdtDocumentoEstrutura_Arquivos ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Arquivos = value;
            SetDirty("Arquivos");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Arquivos_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Arquivos = null;
         SetDirty("Arquivos");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Arquivos_IsNull( )
      {
         if ( gxTv_SdtDocumentoEstrutura_Arquivos == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "DocAtivo" )]
      [  XmlElement( ElementName = "DocAtivo"   )]
      public bool gxTpr_Docativo
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docativo ;
         }

         set {
            gxTv_SdtDocumentoEstrutura_Docativo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docativo = value;
            SetDirty("Docativo");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docativo_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docativo_N = 1;
         gxTv_SdtDocumentoEstrutura_Docativo = false;
         SetDirty("Docativo");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docativo_IsNull( )
      {
         return (gxTv_SdtDocumentoEstrutura_Docativo_N==1) ;
      }

      [  SoapElement( ElementName = "DocAssinado" )]
      [  XmlElement( ElementName = "DocAssinado"   )]
      public bool gxTpr_Docassinado
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docassinado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docassinado = value;
            SetDirty("Docassinado");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docassinado_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docassinado = false;
         SetDirty("Docassinado");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docassinado_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocContrato" )]
      [  XmlElement( ElementName = "DocContrato"   )]
      public bool gxTpr_Doccontrato
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Doccontrato ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Doccontrato = value;
            SetDirty("Doccontrato");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Doccontrato_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Doccontrato = false;
         SetDirty("Doccontrato");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Doccontrato_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Mode_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Initialized_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocID_Z" )]
      [  XmlElement( ElementName = "DocID_Z"   )]
      public Guid gxTpr_Docid_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docid_Z = value;
            SetDirty("Docid_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docid_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docid_Z = Guid.Empty;
         SetDirty("Docid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocVersao_Z" )]
      [  XmlElement( ElementName = "DocVersao_Z"   )]
      public short gxTpr_Docversao_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docversao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docversao_Z = value;
            SetDirty("Docversao_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docversao_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docversao_Z = 0;
         SetDirty("Docversao_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docversao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocVersaoIDPai_Z" )]
      [  XmlElement( ElementName = "DocVersaoIDPai_Z"   )]
      public Guid gxTpr_Docversaoidpai_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docversaoidpai_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docversaoidpai_Z = value;
            SetDirty("Docversaoidpai_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docversaoidpai_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docversaoidpai_Z = Guid.Empty;
         SetDirty("Docversaoidpai_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docversaoidpai_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocVersaoNomePai_Z" )]
      [  XmlElement( ElementName = "DocVersaoNomePai_Z"   )]
      public string gxTpr_Docversaonomepai_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docversaonomepai_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docversaonomepai_Z = value;
            SetDirty("Docversaonomepai_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docversaonomepai_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docversaonomepai_Z = "";
         SetDirty("Docversaonomepai_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docversaonomepai_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocOrigem_Z" )]
      [  XmlElement( ElementName = "DocOrigem_Z"   )]
      public string gxTpr_Docorigem_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docorigem_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docorigem_Z = value;
            SetDirty("Docorigem_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docorigem_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docorigem_Z = "";
         SetDirty("Docorigem_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docorigem_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocOrigemID_Z" )]
      [  XmlElement( ElementName = "DocOrigemID_Z"   )]
      public string gxTpr_Docorigemid_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docorigemid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docorigemid_Z = value;
            SetDirty("Docorigemid_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docorigemid_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docorigemid_Z = "";
         SetDirty("Docorigemid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docorigemid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocInsData_Z" )]
      [  XmlElement( ElementName = "DocInsData_Z"  , IsNullable=true )]
      public string gxTpr_Docinsdata_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Docinsdata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocumentoEstrutura_Docinsdata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocumentoEstrutura_Docinsdata_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Docinsdata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docinsdata_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docinsdata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docinsdata_Z = value;
            SetDirty("Docinsdata_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docinsdata_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docinsdata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docinsdata_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docinsdata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocInsHora_Z" )]
      [  XmlElement( ElementName = "DocInsHora_Z"  , IsNullable=true )]
      public string gxTpr_Docinshora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Docinshora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Docinshora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Docinshora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Docinshora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docinshora_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docinshora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docinshora_Z = value;
            SetDirty("Docinshora_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docinshora_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docinshora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docinshora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docinshora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocInsDataHora_Z" )]
      [  XmlElement( ElementName = "DocInsDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Docinsdatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Docinsdatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Docinsdatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Docinsdatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Docinsdatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docinsdatahora_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docinsdatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docinsdatahora_Z = value;
            SetDirty("Docinsdatahora_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docinsdatahora_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docinsdatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docinsdatahora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docinsdatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocInsUsuID_Z" )]
      [  XmlElement( ElementName = "DocInsUsuID_Z"   )]
      public string gxTpr_Docinsusuid_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docinsusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docinsusuid_Z = value;
            SetDirty("Docinsusuid_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docinsusuid_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docinsusuid_Z = "";
         SetDirty("Docinsusuid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docinsusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocUpdData_Z" )]
      [  XmlElement( ElementName = "DocUpdData_Z"  , IsNullable=true )]
      public string gxTpr_Docupddata_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Docupddata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocumentoEstrutura_Docupddata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocumentoEstrutura_Docupddata_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Docupddata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docupddata_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docupddata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docupddata_Z = value;
            SetDirty("Docupddata_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docupddata_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docupddata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docupddata_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docupddata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocUpdHora_Z" )]
      [  XmlElement( ElementName = "DocUpdHora_Z"  , IsNullable=true )]
      public string gxTpr_Docupdhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Docupdhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Docupdhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Docupdhora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Docupdhora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docupdhora_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docupdhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docupdhora_Z = value;
            SetDirty("Docupdhora_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docupdhora_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docupdhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docupdhora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docupdhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocUpdDataHora_Z" )]
      [  XmlElement( ElementName = "DocUpdDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Docupddatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Docupddatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Docupddatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Docupddatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Docupddatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docupddatahora_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docupddatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docupddatahora_Z = value;
            SetDirty("Docupddatahora_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docupddatahora_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docupddatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docupddatahora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docupddatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocUpdUsuID_Z" )]
      [  XmlElement( ElementName = "DocUpdUsuID_Z"   )]
      public string gxTpr_Docupdusuid_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docupdusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docupdusuid_Z = value;
            SetDirty("Docupdusuid_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docupdusuid_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docupdusuid_Z = "";
         SetDirty("Docupdusuid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docupdusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDel_Z" )]
      [  XmlElement( ElementName = "DocDel_Z"   )]
      public bool gxTpr_Docdel_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docdel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docdel_Z = value;
            SetDirty("Docdel_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docdel_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docdel_Z = false;
         SetDirty("Docdel_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docdel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDelData_Z" )]
      [  XmlElement( ElementName = "DocDelData_Z"  , IsNullable=true )]
      public string gxTpr_Docdeldata_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Docdeldata_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Docdeldata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Docdeldata_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Docdeldata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docdeldata_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docdeldata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docdeldata_Z = value;
            SetDirty("Docdeldata_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docdeldata_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docdeldata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docdeldata_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docdeldata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDelHora_Z" )]
      [  XmlElement( ElementName = "DocDelHora_Z"  , IsNullable=true )]
      public string gxTpr_Docdelhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Docdelhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Docdelhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Docdelhora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Docdelhora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docdelhora_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docdelhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docdelhora_Z = value;
            SetDirty("Docdelhora_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docdelhora_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docdelhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docdelhora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docdelhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDelDataHora_Z" )]
      [  XmlElement( ElementName = "DocDelDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Docdeldatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoEstrutura_Docdeldatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoEstrutura_Docdeldatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoEstrutura_Docdeldatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoEstrutura_Docdeldatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Docdeldatahora_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docdeldatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docdeldatahora_Z = value;
            SetDirty("Docdeldatahora_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docdeldatahora_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docdeldatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docdeldatahora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docdeldatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDelUsuID_Z" )]
      [  XmlElement( ElementName = "DocDelUsuID_Z"   )]
      public string gxTpr_Docdelusuid_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docdelusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docdelusuid_Z = value;
            SetDirty("Docdelusuid_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docdelusuid_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docdelusuid_Z = "";
         SetDirty("Docdelusuid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docdelusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocNome_Z" )]
      [  XmlElement( ElementName = "DocNome_Z"   )]
      public string gxTpr_Docnome_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docnome_Z = value;
            SetDirty("Docnome_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docnome_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docnome_Z = "";
         SetDirty("Docnome_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocTipoID_Z" )]
      [  XmlElement( ElementName = "DocTipoID_Z"   )]
      public int gxTpr_Doctipoid_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Doctipoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Doctipoid_Z = value;
            SetDirty("Doctipoid_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Doctipoid_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Doctipoid_Z = 0;
         SetDirty("Doctipoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Doctipoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocTipoSigla_Z" )]
      [  XmlElement( ElementName = "DocTipoSigla_Z"   )]
      public string gxTpr_Doctiposigla_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Doctiposigla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Doctiposigla_Z = value;
            SetDirty("Doctiposigla_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Doctiposigla_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Doctiposigla_Z = "";
         SetDirty("Doctiposigla_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Doctiposigla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocTipoNome_Z" )]
      [  XmlElement( ElementName = "DocTipoNome_Z"   )]
      public string gxTpr_Doctiponome_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Doctiponome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Doctiponome_Z = value;
            SetDirty("Doctiponome_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Doctiponome_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Doctiponome_Z = "";
         SetDirty("Doctiponome_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Doctiponome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocTipoAtivo_Z" )]
      [  XmlElement( ElementName = "DocTipoAtivo_Z"   )]
      public bool gxTpr_Doctipoativo_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Doctipoativo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Doctipoativo_Z = value;
            SetDirty("Doctipoativo_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Doctipoativo_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Doctipoativo_Z = false;
         SetDirty("Doctipoativo_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Doctipoativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocUltArqSeq_Z" )]
      [  XmlElement( ElementName = "DocUltArqSeq_Z"   )]
      public short gxTpr_Docultarqseq_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docultarqseq_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docultarqseq_Z = value;
            SetDirty("Docultarqseq_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docultarqseq_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docultarqseq_Z = 0;
         SetDirty("Docultarqseq_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docultarqseq_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocAtivo_Z" )]
      [  XmlElement( ElementName = "DocAtivo_Z"   )]
      public bool gxTpr_Docativo_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docativo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docativo_Z = value;
            SetDirty("Docativo_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docativo_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docativo_Z = false;
         SetDirty("Docativo_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocAssinado_Z" )]
      [  XmlElement( ElementName = "DocAssinado_Z"   )]
      public bool gxTpr_Docassinado_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docassinado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docassinado_Z = value;
            SetDirty("Docassinado_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docassinado_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docassinado_Z = false;
         SetDirty("Docassinado_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docassinado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocContrato_Z" )]
      [  XmlElement( ElementName = "DocContrato_Z"   )]
      public bool gxTpr_Doccontrato_Z
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Doccontrato_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Doccontrato_Z = value;
            SetDirty("Doccontrato_Z");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Doccontrato_Z_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Doccontrato_Z = false;
         SetDirty("Doccontrato_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Doccontrato_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocVersaoIDPai_N" )]
      [  XmlElement( ElementName = "DocVersaoIDPai_N"   )]
      public short gxTpr_Docversaoidpai_N
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docversaoidpai_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docversaoidpai_N = value;
            SetDirty("Docversaoidpai_N");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docversaoidpai_N_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docversaoidpai_N = 0;
         SetDirty("Docversaoidpai_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docversaoidpai_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocInsUsuID_N" )]
      [  XmlElement( ElementName = "DocInsUsuID_N"   )]
      public short gxTpr_Docinsusuid_N
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docinsusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docinsusuid_N = value;
            SetDirty("Docinsusuid_N");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docinsusuid_N_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docinsusuid_N = 0;
         SetDirty("Docinsusuid_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docinsusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocUpdData_N" )]
      [  XmlElement( ElementName = "DocUpdData_N"   )]
      public short gxTpr_Docupddata_N
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docupddata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docupddata_N = value;
            SetDirty("Docupddata_N");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docupddata_N_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docupddata_N = 0;
         SetDirty("Docupddata_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docupddata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocUpdHora_N" )]
      [  XmlElement( ElementName = "DocUpdHora_N"   )]
      public short gxTpr_Docupdhora_N
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docupdhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docupdhora_N = value;
            SetDirty("Docupdhora_N");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docupdhora_N_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docupdhora_N = 0;
         SetDirty("Docupdhora_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docupdhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocUpdDataHora_N" )]
      [  XmlElement( ElementName = "DocUpdDataHora_N"   )]
      public short gxTpr_Docupddatahora_N
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docupddatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docupddatahora_N = value;
            SetDirty("Docupddatahora_N");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docupddatahora_N_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docupddatahora_N = 0;
         SetDirty("Docupddatahora_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docupddatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocUpdUsuID_N" )]
      [  XmlElement( ElementName = "DocUpdUsuID_N"   )]
      public short gxTpr_Docupdusuid_N
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docupdusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docupdusuid_N = value;
            SetDirty("Docupdusuid_N");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docupdusuid_N_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docupdusuid_N = 0;
         SetDirty("Docupdusuid_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docupdusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDelData_N" )]
      [  XmlElement( ElementName = "DocDelData_N"   )]
      public short gxTpr_Docdeldata_N
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docdeldata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docdeldata_N = value;
            SetDirty("Docdeldata_N");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docdeldata_N_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docdeldata_N = 0;
         SetDirty("Docdeldata_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docdeldata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDelHora_N" )]
      [  XmlElement( ElementName = "DocDelHora_N"   )]
      public short gxTpr_Docdelhora_N
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docdelhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docdelhora_N = value;
            SetDirty("Docdelhora_N");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docdelhora_N_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docdelhora_N = 0;
         SetDirty("Docdelhora_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docdelhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDelDataHora_N" )]
      [  XmlElement( ElementName = "DocDelDataHora_N"   )]
      public short gxTpr_Docdeldatahora_N
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docdeldatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docdeldatahora_N = value;
            SetDirty("Docdeldatahora_N");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docdeldatahora_N_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docdeldatahora_N = 0;
         SetDirty("Docdeldatahora_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docdeldatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDelUsuID_N" )]
      [  XmlElement( ElementName = "DocDelUsuID_N"   )]
      public short gxTpr_Docdelusuid_N
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docdelusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docdelusuid_N = value;
            SetDirty("Docdelusuid_N");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docdelusuid_N_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docdelusuid_N = 0;
         SetDirty("Docdelusuid_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docdelusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocUltArqSeq_N" )]
      [  XmlElement( ElementName = "DocUltArqSeq_N"   )]
      public short gxTpr_Docultarqseq_N
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docultarqseq_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docultarqseq_N = value;
            SetDirty("Docultarqseq_N");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docultarqseq_N_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docultarqseq_N = 0;
         SetDirty("Docultarqseq_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docultarqseq_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocAtivo_N" )]
      [  XmlElement( ElementName = "DocAtivo_N"   )]
      public short gxTpr_Docativo_N
      {
         get {
            return gxTv_SdtDocumentoEstrutura_Docativo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoEstrutura_Docativo_N = value;
            SetDirty("Docativo_N");
         }

      }

      public void gxTv_SdtDocumentoEstrutura_Docativo_N_SetNull( )
      {
         gxTv_SdtDocumentoEstrutura_Docativo_N = 0;
         SetDirty("Docativo_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoEstrutura_Docativo_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtDocumentoEstrutura_Docid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtDocumentoEstrutura_Docversaoidpai = Guid.Empty;
         gxTv_SdtDocumentoEstrutura_Docversaonomepai = "";
         gxTv_SdtDocumentoEstrutura_Docorigem = "";
         gxTv_SdtDocumentoEstrutura_Docorigemid = "";
         gxTv_SdtDocumentoEstrutura_Docinsdata = DateTime.MinValue;
         gxTv_SdtDocumentoEstrutura_Docinshora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Docinsdatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Docinsusuid = "";
         gxTv_SdtDocumentoEstrutura_Docupddata = DateTime.MinValue;
         gxTv_SdtDocumentoEstrutura_Docupdhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Docupddatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Docupdusuid = "";
         gxTv_SdtDocumentoEstrutura_Docdel = false;
         gxTv_SdtDocumentoEstrutura_Docdeldata = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Docdelhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Docdeldatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Docdelusuid = "";
         gxTv_SdtDocumentoEstrutura_Docnome = "";
         gxTv_SdtDocumentoEstrutura_Doctiposigla = "";
         gxTv_SdtDocumentoEstrutura_Doctiponome = "";
         gxTv_SdtDocumentoEstrutura_Doctipoativo = true;
         gxTv_SdtDocumentoEstrutura_Mode = "";
         gxTv_SdtDocumentoEstrutura_Docid_Z = Guid.Empty;
         gxTv_SdtDocumentoEstrutura_Docversaoidpai_Z = Guid.Empty;
         gxTv_SdtDocumentoEstrutura_Docversaonomepai_Z = "";
         gxTv_SdtDocumentoEstrutura_Docorigem_Z = "";
         gxTv_SdtDocumentoEstrutura_Docorigemid_Z = "";
         gxTv_SdtDocumentoEstrutura_Docinsdata_Z = DateTime.MinValue;
         gxTv_SdtDocumentoEstrutura_Docinshora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Docinsdatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Docinsusuid_Z = "";
         gxTv_SdtDocumentoEstrutura_Docupddata_Z = DateTime.MinValue;
         gxTv_SdtDocumentoEstrutura_Docupdhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Docupddatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Docupdusuid_Z = "";
         gxTv_SdtDocumentoEstrutura_Docdeldata_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Docdelhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Docdeldatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoEstrutura_Docdelusuid_Z = "";
         gxTv_SdtDocumentoEstrutura_Docnome_Z = "";
         gxTv_SdtDocumentoEstrutura_Doctiposigla_Z = "";
         gxTv_SdtDocumentoEstrutura_Doctiponome_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "core.documentoestrutura", "GeneXus.Programs.core.documentoestrutura_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtDocumentoEstrutura_Docversao ;
      private short gxTv_SdtDocumentoEstrutura_Docultarqseq ;
      private short gxTv_SdtDocumentoEstrutura_Initialized ;
      private short gxTv_SdtDocumentoEstrutura_Docversao_Z ;
      private short gxTv_SdtDocumentoEstrutura_Docultarqseq_Z ;
      private short gxTv_SdtDocumentoEstrutura_Docversaoidpai_N ;
      private short gxTv_SdtDocumentoEstrutura_Docinsusuid_N ;
      private short gxTv_SdtDocumentoEstrutura_Docupddata_N ;
      private short gxTv_SdtDocumentoEstrutura_Docupdhora_N ;
      private short gxTv_SdtDocumentoEstrutura_Docupddatahora_N ;
      private short gxTv_SdtDocumentoEstrutura_Docupdusuid_N ;
      private short gxTv_SdtDocumentoEstrutura_Docdeldata_N ;
      private short gxTv_SdtDocumentoEstrutura_Docdelhora_N ;
      private short gxTv_SdtDocumentoEstrutura_Docdeldatahora_N ;
      private short gxTv_SdtDocumentoEstrutura_Docdelusuid_N ;
      private short gxTv_SdtDocumentoEstrutura_Docultarqseq_N ;
      private short gxTv_SdtDocumentoEstrutura_Docativo_N ;
      private int gxTv_SdtDocumentoEstrutura_Doctipoid ;
      private int gxTv_SdtDocumentoEstrutura_Doctipoid_Z ;
      private string gxTv_SdtDocumentoEstrutura_Docinsusuid ;
      private string gxTv_SdtDocumentoEstrutura_Docupdusuid ;
      private string gxTv_SdtDocumentoEstrutura_Docdelusuid ;
      private string gxTv_SdtDocumentoEstrutura_Mode ;
      private string gxTv_SdtDocumentoEstrutura_Docinsusuid_Z ;
      private string gxTv_SdtDocumentoEstrutura_Docupdusuid_Z ;
      private string gxTv_SdtDocumentoEstrutura_Docdelusuid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtDocumentoEstrutura_Docinshora ;
      private DateTime gxTv_SdtDocumentoEstrutura_Docinsdatahora ;
      private DateTime gxTv_SdtDocumentoEstrutura_Docupdhora ;
      private DateTime gxTv_SdtDocumentoEstrutura_Docupddatahora ;
      private DateTime gxTv_SdtDocumentoEstrutura_Docdeldata ;
      private DateTime gxTv_SdtDocumentoEstrutura_Docdelhora ;
      private DateTime gxTv_SdtDocumentoEstrutura_Docdeldatahora ;
      private DateTime gxTv_SdtDocumentoEstrutura_Docinshora_Z ;
      private DateTime gxTv_SdtDocumentoEstrutura_Docinsdatahora_Z ;
      private DateTime gxTv_SdtDocumentoEstrutura_Docupdhora_Z ;
      private DateTime gxTv_SdtDocumentoEstrutura_Docupddatahora_Z ;
      private DateTime gxTv_SdtDocumentoEstrutura_Docdeldata_Z ;
      private DateTime gxTv_SdtDocumentoEstrutura_Docdelhora_Z ;
      private DateTime gxTv_SdtDocumentoEstrutura_Docdeldatahora_Z ;
      private DateTime datetime_STZ ;
      private DateTime datetimemil_STZ ;
      private DateTime gxTv_SdtDocumentoEstrutura_Docinsdata ;
      private DateTime gxTv_SdtDocumentoEstrutura_Docupddata ;
      private DateTime gxTv_SdtDocumentoEstrutura_Docinsdata_Z ;
      private DateTime gxTv_SdtDocumentoEstrutura_Docupddata_Z ;
      private bool gxTv_SdtDocumentoEstrutura_Docdel ;
      private bool gxTv_SdtDocumentoEstrutura_Doctipoativo ;
      private bool gxTv_SdtDocumentoEstrutura_Docativo ;
      private bool gxTv_SdtDocumentoEstrutura_Docassinado ;
      private bool gxTv_SdtDocumentoEstrutura_Doccontrato ;
      private bool gxTv_SdtDocumentoEstrutura_Docdel_Z ;
      private bool gxTv_SdtDocumentoEstrutura_Doctipoativo_Z ;
      private bool gxTv_SdtDocumentoEstrutura_Docativo_Z ;
      private bool gxTv_SdtDocumentoEstrutura_Docassinado_Z ;
      private bool gxTv_SdtDocumentoEstrutura_Doccontrato_Z ;
      private string gxTv_SdtDocumentoEstrutura_Docversaonomepai ;
      private string gxTv_SdtDocumentoEstrutura_Docorigem ;
      private string gxTv_SdtDocumentoEstrutura_Docorigemid ;
      private string gxTv_SdtDocumentoEstrutura_Docnome ;
      private string gxTv_SdtDocumentoEstrutura_Doctiposigla ;
      private string gxTv_SdtDocumentoEstrutura_Doctiponome ;
      private string gxTv_SdtDocumentoEstrutura_Docversaonomepai_Z ;
      private string gxTv_SdtDocumentoEstrutura_Docorigem_Z ;
      private string gxTv_SdtDocumentoEstrutura_Docorigemid_Z ;
      private string gxTv_SdtDocumentoEstrutura_Docnome_Z ;
      private string gxTv_SdtDocumentoEstrutura_Doctiposigla_Z ;
      private string gxTv_SdtDocumentoEstrutura_Doctiponome_Z ;
      private Guid gxTv_SdtDocumentoEstrutura_Docid ;
      private Guid gxTv_SdtDocumentoEstrutura_Docversaoidpai ;
      private Guid gxTv_SdtDocumentoEstrutura_Docid_Z ;
      private Guid gxTv_SdtDocumentoEstrutura_Docversaoidpai_Z ;
      private GXBCLevelCollection<GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos> gxTv_SdtDocumentoEstrutura_Arquivos=null ;
   }

   [DataContract(Name = @"core\DocumentoEstrutura", Namespace = "agl_tresorygroup")]
   public class SdtDocumentoEstrutura_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtDocumentoEstrutura>
   {
      public SdtDocumentoEstrutura_RESTInterface( ) : base()
      {
      }

      public SdtDocumentoEstrutura_RESTInterface( GeneXus.Programs.core.SdtDocumentoEstrutura psdt ) : base(psdt)
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

      [DataMember( Name = "DocDelData" , Order = 15 )]
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

      [DataMember( Name = "DocDelHora" , Order = 16 )]
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

      [DataMember( Name = "DocDelDataHora" , Order = 17 )]
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

      [DataMember( Name = "DocNome" , Order = 19 )]
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

      [DataMember( Name = "DocTipoID" , Order = 20 )]
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

      [DataMember( Name = "DocTipoSigla" , Order = 21 )]
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

      [DataMember( Name = "DocTipoNome" , Order = 22 )]
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

      [DataMember( Name = "DocTipoAtivo" , Order = 23 )]
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

      [DataMember( Name = "DocUltArqSeq" , Order = 24 )]
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

      [DataMember( Name = "Arquivos" , Order = 25 )]
      public GxGenericCollection<GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos_RESTInterface> gxTpr_Arquivos
      {
         get {
            return new GxGenericCollection<GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos_RESTInterface>(sdt.gxTpr_Arquivos) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Arquivos);
         }

      }

      [DataMember( Name = "DocAtivo" , Order = 26 )]
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

      [DataMember( Name = "DocContrato" , Order = 28 )]
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

      public GeneXus.Programs.core.SdtDocumentoEstrutura sdt
      {
         get {
            return (GeneXus.Programs.core.SdtDocumentoEstrutura)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtDocumentoEstrutura() ;
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

   [DataContract(Name = @"core\DocumentoEstrutura", Namespace = "agl_tresorygroup")]
   public class SdtDocumentoEstrutura_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtDocumentoEstrutura>
   {
      public SdtDocumentoEstrutura_RESTLInterface( ) : base()
      {
      }

      public SdtDocumentoEstrutura_RESTLInterface( GeneXus.Programs.core.SdtDocumentoEstrutura psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DocVersao" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public GeneXus.Programs.core.SdtDocumentoEstrutura sdt
      {
         get {
            return (GeneXus.Programs.core.SdtDocumentoEstrutura)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtDocumentoEstrutura() ;
         }
      }

   }

}
