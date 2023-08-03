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
   [XmlRoot(ElementName = "Produto" )]
   [XmlType(TypeName =  "Produto" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class SdtProduto : GxSilentTrnSdt
   {
      public SdtProduto( )
      {
      }

      public SdtProduto( IGxContext context )
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

      public void Load( Guid AV220PrdID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV220PrdID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PrdID", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "core\\Produto");
         metadata.Set("BT", "tb_produto");
         metadata.Set("PK", "[ \"PrdID\" ]");
         metadata.Set("PKAssigned", "[ \"PrdID\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"PrtID\" ],\"FKMap\":[ \"PrdTipoID-PrtID\" ] } ]");
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
         state.Add("gxTpr_Prdid_Z");
         state.Add("gxTpr_Prdcodigo_Z");
         state.Add("gxTpr_Prdnome_Z");
         state.Add("gxTpr_Prdinsdata_Z_Nullable");
         state.Add("gxTpr_Prdinshora_Z_Nullable");
         state.Add("gxTpr_Prdinsdatahora_Z_Nullable");
         state.Add("gxTpr_Prdinsusuid_Z");
         state.Add("gxTpr_Prdupddata_Z_Nullable");
         state.Add("gxTpr_Prdupdhora_Z_Nullable");
         state.Add("gxTpr_Prdupddatahora_Z_Nullable");
         state.Add("gxTpr_Prdupdusuid_Z");
         state.Add("gxTpr_Prdativo_Z");
         state.Add("gxTpr_Prdtipoid_Z");
         state.Add("gxTpr_Prdtiposigla_Z");
         state.Add("gxTpr_Prdtiponome_Z");
         state.Add("gxTpr_Prddel_Z");
         state.Add("gxTpr_Prddeldatahora_Z_Nullable");
         state.Add("gxTpr_Prddeldata_Z_Nullable");
         state.Add("gxTpr_Prddelhora_Z_Nullable");
         state.Add("gxTpr_Prddelusuid_Z");
         state.Add("gxTpr_Prddelusunome_Z");
         state.Add("gxTpr_Prdinsusuid_N");
         state.Add("gxTpr_Prdupddata_N");
         state.Add("gxTpr_Prdupdhora_N");
         state.Add("gxTpr_Prdupddatahora_N");
         state.Add("gxTpr_Prdupdusuid_N");
         state.Add("gxTpr_Prddeldatahora_N");
         state.Add("gxTpr_Prddeldata_N");
         state.Add("gxTpr_Prddelhora_N");
         state.Add("gxTpr_Prddelusuid_N");
         state.Add("gxTpr_Prddelusunome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.SdtProduto sdt;
         sdt = (GeneXus.Programs.core.SdtProduto)(source);
         gxTv_SdtProduto_Prdid = sdt.gxTv_SdtProduto_Prdid ;
         gxTv_SdtProduto_Prdcodigo = sdt.gxTv_SdtProduto_Prdcodigo ;
         gxTv_SdtProduto_Prdnome = sdt.gxTv_SdtProduto_Prdnome ;
         gxTv_SdtProduto_Prdinsdata = sdt.gxTv_SdtProduto_Prdinsdata ;
         gxTv_SdtProduto_Prdinshora = sdt.gxTv_SdtProduto_Prdinshora ;
         gxTv_SdtProduto_Prdinsdatahora = sdt.gxTv_SdtProduto_Prdinsdatahora ;
         gxTv_SdtProduto_Prdinsusuid = sdt.gxTv_SdtProduto_Prdinsusuid ;
         gxTv_SdtProduto_Prdupddata = sdt.gxTv_SdtProduto_Prdupddata ;
         gxTv_SdtProduto_Prdupdhora = sdt.gxTv_SdtProduto_Prdupdhora ;
         gxTv_SdtProduto_Prdupddatahora = sdt.gxTv_SdtProduto_Prdupddatahora ;
         gxTv_SdtProduto_Prdupdusuid = sdt.gxTv_SdtProduto_Prdupdusuid ;
         gxTv_SdtProduto_Prdativo = sdt.gxTv_SdtProduto_Prdativo ;
         gxTv_SdtProduto_Prdtipoid = sdt.gxTv_SdtProduto_Prdtipoid ;
         gxTv_SdtProduto_Prdtiposigla = sdt.gxTv_SdtProduto_Prdtiposigla ;
         gxTv_SdtProduto_Prdtiponome = sdt.gxTv_SdtProduto_Prdtiponome ;
         gxTv_SdtProduto_Prddel = sdt.gxTv_SdtProduto_Prddel ;
         gxTv_SdtProduto_Prddeldatahora = sdt.gxTv_SdtProduto_Prddeldatahora ;
         gxTv_SdtProduto_Prddeldata = sdt.gxTv_SdtProduto_Prddeldata ;
         gxTv_SdtProduto_Prddelhora = sdt.gxTv_SdtProduto_Prddelhora ;
         gxTv_SdtProduto_Prddelusuid = sdt.gxTv_SdtProduto_Prddelusuid ;
         gxTv_SdtProduto_Prddelusunome = sdt.gxTv_SdtProduto_Prddelusunome ;
         gxTv_SdtProduto_Mode = sdt.gxTv_SdtProduto_Mode ;
         gxTv_SdtProduto_Initialized = sdt.gxTv_SdtProduto_Initialized ;
         gxTv_SdtProduto_Prdid_Z = sdt.gxTv_SdtProduto_Prdid_Z ;
         gxTv_SdtProduto_Prdcodigo_Z = sdt.gxTv_SdtProduto_Prdcodigo_Z ;
         gxTv_SdtProduto_Prdnome_Z = sdt.gxTv_SdtProduto_Prdnome_Z ;
         gxTv_SdtProduto_Prdinsdata_Z = sdt.gxTv_SdtProduto_Prdinsdata_Z ;
         gxTv_SdtProduto_Prdinshora_Z = sdt.gxTv_SdtProduto_Prdinshora_Z ;
         gxTv_SdtProduto_Prdinsdatahora_Z = sdt.gxTv_SdtProduto_Prdinsdatahora_Z ;
         gxTv_SdtProduto_Prdinsusuid_Z = sdt.gxTv_SdtProduto_Prdinsusuid_Z ;
         gxTv_SdtProduto_Prdupddata_Z = sdt.gxTv_SdtProduto_Prdupddata_Z ;
         gxTv_SdtProduto_Prdupdhora_Z = sdt.gxTv_SdtProduto_Prdupdhora_Z ;
         gxTv_SdtProduto_Prdupddatahora_Z = sdt.gxTv_SdtProduto_Prdupddatahora_Z ;
         gxTv_SdtProduto_Prdupdusuid_Z = sdt.gxTv_SdtProduto_Prdupdusuid_Z ;
         gxTv_SdtProduto_Prdativo_Z = sdt.gxTv_SdtProduto_Prdativo_Z ;
         gxTv_SdtProduto_Prdtipoid_Z = sdt.gxTv_SdtProduto_Prdtipoid_Z ;
         gxTv_SdtProduto_Prdtiposigla_Z = sdt.gxTv_SdtProduto_Prdtiposigla_Z ;
         gxTv_SdtProduto_Prdtiponome_Z = sdt.gxTv_SdtProduto_Prdtiponome_Z ;
         gxTv_SdtProduto_Prddel_Z = sdt.gxTv_SdtProduto_Prddel_Z ;
         gxTv_SdtProduto_Prddeldatahora_Z = sdt.gxTv_SdtProduto_Prddeldatahora_Z ;
         gxTv_SdtProduto_Prddeldata_Z = sdt.gxTv_SdtProduto_Prddeldata_Z ;
         gxTv_SdtProduto_Prddelhora_Z = sdt.gxTv_SdtProduto_Prddelhora_Z ;
         gxTv_SdtProduto_Prddelusuid_Z = sdt.gxTv_SdtProduto_Prddelusuid_Z ;
         gxTv_SdtProduto_Prddelusunome_Z = sdt.gxTv_SdtProduto_Prddelusunome_Z ;
         gxTv_SdtProduto_Prdinsusuid_N = sdt.gxTv_SdtProduto_Prdinsusuid_N ;
         gxTv_SdtProduto_Prdupddata_N = sdt.gxTv_SdtProduto_Prdupddata_N ;
         gxTv_SdtProduto_Prdupdhora_N = sdt.gxTv_SdtProduto_Prdupdhora_N ;
         gxTv_SdtProduto_Prdupddatahora_N = sdt.gxTv_SdtProduto_Prdupddatahora_N ;
         gxTv_SdtProduto_Prdupdusuid_N = sdt.gxTv_SdtProduto_Prdupdusuid_N ;
         gxTv_SdtProduto_Prddeldatahora_N = sdt.gxTv_SdtProduto_Prddeldatahora_N ;
         gxTv_SdtProduto_Prddeldata_N = sdt.gxTv_SdtProduto_Prddeldata_N ;
         gxTv_SdtProduto_Prddelhora_N = sdt.gxTv_SdtProduto_Prddelhora_N ;
         gxTv_SdtProduto_Prddelusuid_N = sdt.gxTv_SdtProduto_Prddelusuid_N ;
         gxTv_SdtProduto_Prddelusunome_N = sdt.gxTv_SdtProduto_Prddelusunome_N ;
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
         AddObjectProperty("PrdID", gxTv_SdtProduto_Prdid, false, includeNonInitialized);
         AddObjectProperty("PrdCodigo", gxTv_SdtProduto_Prdcodigo, false, includeNonInitialized);
         AddObjectProperty("PrdNome", gxTv_SdtProduto_Prdnome, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtProduto_Prdinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtProduto_Prdinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtProduto_Prdinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("PrdInsData", sDateCnv, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtProduto_Prdinshora;
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
         AddObjectProperty("PrdInsHora", sDateCnv, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtProduto_Prdinsdatahora;
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
         AddObjectProperty("PrdInsDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PrdInsUsuID", gxTv_SdtProduto_Prdinsusuid, false, includeNonInitialized);
         AddObjectProperty("PrdInsUsuID_N", gxTv_SdtProduto_Prdinsusuid_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtProduto_Prdupddata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtProduto_Prdupddata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtProduto_Prdupddata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("PrdUpdData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PrdUpdData_N", gxTv_SdtProduto_Prdupddata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtProduto_Prdupdhora;
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
         AddObjectProperty("PrdUpdHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PrdUpdHora_N", gxTv_SdtProduto_Prdupdhora_N, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtProduto_Prdupddatahora;
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
         AddObjectProperty("PrdUpdDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PrdUpdDataHora_N", gxTv_SdtProduto_Prdupddatahora_N, false, includeNonInitialized);
         AddObjectProperty("PrdUpdUsuID", gxTv_SdtProduto_Prdupdusuid, false, includeNonInitialized);
         AddObjectProperty("PrdUpdUsuID_N", gxTv_SdtProduto_Prdupdusuid_N, false, includeNonInitialized);
         AddObjectProperty("PrdAtivo", gxTv_SdtProduto_Prdativo, false, includeNonInitialized);
         AddObjectProperty("PrdTipoID", gxTv_SdtProduto_Prdtipoid, false, includeNonInitialized);
         AddObjectProperty("PrdTipoSigla", gxTv_SdtProduto_Prdtiposigla, false, includeNonInitialized);
         AddObjectProperty("PrdTipoNome", gxTv_SdtProduto_Prdtiponome, false, includeNonInitialized);
         AddObjectProperty("PrdDel", gxTv_SdtProduto_Prddel, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtProduto_Prddeldatahora;
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
         AddObjectProperty("PrdDelDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PrdDelDataHora_N", gxTv_SdtProduto_Prddeldatahora_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtProduto_Prddeldata;
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
         AddObjectProperty("PrdDelData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PrdDelData_N", gxTv_SdtProduto_Prddeldata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtProduto_Prddelhora;
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
         AddObjectProperty("PrdDelHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PrdDelHora_N", gxTv_SdtProduto_Prddelhora_N, false, includeNonInitialized);
         AddObjectProperty("PrdDelUsuId", gxTv_SdtProduto_Prddelusuid, false, includeNonInitialized);
         AddObjectProperty("PrdDelUsuId_N", gxTv_SdtProduto_Prddelusuid_N, false, includeNonInitialized);
         AddObjectProperty("PrdDelUsuNome", gxTv_SdtProduto_Prddelusunome, false, includeNonInitialized);
         AddObjectProperty("PrdDelUsuNome_N", gxTv_SdtProduto_Prddelusunome_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtProduto_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtProduto_Initialized, false, includeNonInitialized);
            AddObjectProperty("PrdID_Z", gxTv_SdtProduto_Prdid_Z, false, includeNonInitialized);
            AddObjectProperty("PrdCodigo_Z", gxTv_SdtProduto_Prdcodigo_Z, false, includeNonInitialized);
            AddObjectProperty("PrdNome_Z", gxTv_SdtProduto_Prdnome_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtProduto_Prdinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtProduto_Prdinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtProduto_Prdinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("PrdInsData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtProduto_Prdinshora_Z;
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
            AddObjectProperty("PrdInsHora_Z", sDateCnv, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtProduto_Prdinsdatahora_Z;
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
            AddObjectProperty("PrdInsDataHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("PrdInsUsuID_Z", gxTv_SdtProduto_Prdinsusuid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtProduto_Prdupddata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtProduto_Prdupddata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtProduto_Prdupddata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("PrdUpdData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtProduto_Prdupdhora_Z;
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
            AddObjectProperty("PrdUpdHora_Z", sDateCnv, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtProduto_Prdupddatahora_Z;
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
            AddObjectProperty("PrdUpdDataHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("PrdUpdUsuID_Z", gxTv_SdtProduto_Prdupdusuid_Z, false, includeNonInitialized);
            AddObjectProperty("PrdAtivo_Z", gxTv_SdtProduto_Prdativo_Z, false, includeNonInitialized);
            AddObjectProperty("PrdTipoID_Z", gxTv_SdtProduto_Prdtipoid_Z, false, includeNonInitialized);
            AddObjectProperty("PrdTipoSigla_Z", gxTv_SdtProduto_Prdtiposigla_Z, false, includeNonInitialized);
            AddObjectProperty("PrdTipoNome_Z", gxTv_SdtProduto_Prdtiponome_Z, false, includeNonInitialized);
            AddObjectProperty("PrdDel_Z", gxTv_SdtProduto_Prddel_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtProduto_Prddeldatahora_Z;
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
            AddObjectProperty("PrdDelDataHora_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtProduto_Prddeldata_Z;
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
            AddObjectProperty("PrdDelData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtProduto_Prddelhora_Z;
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
            AddObjectProperty("PrdDelHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("PrdDelUsuId_Z", gxTv_SdtProduto_Prddelusuid_Z, false, includeNonInitialized);
            AddObjectProperty("PrdDelUsuNome_Z", gxTv_SdtProduto_Prddelusunome_Z, false, includeNonInitialized);
            AddObjectProperty("PrdInsUsuID_N", gxTv_SdtProduto_Prdinsusuid_N, false, includeNonInitialized);
            AddObjectProperty("PrdUpdData_N", gxTv_SdtProduto_Prdupddata_N, false, includeNonInitialized);
            AddObjectProperty("PrdUpdHora_N", gxTv_SdtProduto_Prdupdhora_N, false, includeNonInitialized);
            AddObjectProperty("PrdUpdDataHora_N", gxTv_SdtProduto_Prdupddatahora_N, false, includeNonInitialized);
            AddObjectProperty("PrdUpdUsuID_N", gxTv_SdtProduto_Prdupdusuid_N, false, includeNonInitialized);
            AddObjectProperty("PrdDelDataHora_N", gxTv_SdtProduto_Prddeldatahora_N, false, includeNonInitialized);
            AddObjectProperty("PrdDelData_N", gxTv_SdtProduto_Prddeldata_N, false, includeNonInitialized);
            AddObjectProperty("PrdDelHora_N", gxTv_SdtProduto_Prddelhora_N, false, includeNonInitialized);
            AddObjectProperty("PrdDelUsuId_N", gxTv_SdtProduto_Prddelusuid_N, false, includeNonInitialized);
            AddObjectProperty("PrdDelUsuNome_N", gxTv_SdtProduto_Prddelusunome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.SdtProduto sdt )
      {
         if ( sdt.IsDirty("PrdID") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdid = sdt.gxTv_SdtProduto_Prdid ;
         }
         if ( sdt.IsDirty("PrdCodigo") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdcodigo = sdt.gxTv_SdtProduto_Prdcodigo ;
         }
         if ( sdt.IsDirty("PrdNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdnome = sdt.gxTv_SdtProduto_Prdnome ;
         }
         if ( sdt.IsDirty("PrdInsData") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdinsdata = sdt.gxTv_SdtProduto_Prdinsdata ;
         }
         if ( sdt.IsDirty("PrdInsHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdinshora = sdt.gxTv_SdtProduto_Prdinshora ;
         }
         if ( sdt.IsDirty("PrdInsDataHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdinsdatahora = sdt.gxTv_SdtProduto_Prdinsdatahora ;
         }
         if ( sdt.IsDirty("PrdInsUsuID") )
         {
            gxTv_SdtProduto_Prdinsusuid_N = (short)(sdt.gxTv_SdtProduto_Prdinsusuid_N);
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdinsusuid = sdt.gxTv_SdtProduto_Prdinsusuid ;
         }
         if ( sdt.IsDirty("PrdUpdData") )
         {
            gxTv_SdtProduto_Prdupddata_N = (short)(sdt.gxTv_SdtProduto_Prdupddata_N);
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdupddata = sdt.gxTv_SdtProduto_Prdupddata ;
         }
         if ( sdt.IsDirty("PrdUpdHora") )
         {
            gxTv_SdtProduto_Prdupdhora_N = (short)(sdt.gxTv_SdtProduto_Prdupdhora_N);
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdupdhora = sdt.gxTv_SdtProduto_Prdupdhora ;
         }
         if ( sdt.IsDirty("PrdUpdDataHora") )
         {
            gxTv_SdtProduto_Prdupddatahora_N = (short)(sdt.gxTv_SdtProduto_Prdupddatahora_N);
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdupddatahora = sdt.gxTv_SdtProduto_Prdupddatahora ;
         }
         if ( sdt.IsDirty("PrdUpdUsuID") )
         {
            gxTv_SdtProduto_Prdupdusuid_N = (short)(sdt.gxTv_SdtProduto_Prdupdusuid_N);
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdupdusuid = sdt.gxTv_SdtProduto_Prdupdusuid ;
         }
         if ( sdt.IsDirty("PrdAtivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdativo = sdt.gxTv_SdtProduto_Prdativo ;
         }
         if ( sdt.IsDirty("PrdTipoID") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdtipoid = sdt.gxTv_SdtProduto_Prdtipoid ;
         }
         if ( sdt.IsDirty("PrdTipoSigla") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdtiposigla = sdt.gxTv_SdtProduto_Prdtiposigla ;
         }
         if ( sdt.IsDirty("PrdTipoNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdtiponome = sdt.gxTv_SdtProduto_Prdtiponome ;
         }
         if ( sdt.IsDirty("PrdDel") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prddel = sdt.gxTv_SdtProduto_Prddel ;
         }
         if ( sdt.IsDirty("PrdDelDataHora") )
         {
            gxTv_SdtProduto_Prddeldatahora_N = (short)(sdt.gxTv_SdtProduto_Prddeldatahora_N);
            sdtIsNull = 0;
            gxTv_SdtProduto_Prddeldatahora = sdt.gxTv_SdtProduto_Prddeldatahora ;
         }
         if ( sdt.IsDirty("PrdDelData") )
         {
            gxTv_SdtProduto_Prddeldata_N = (short)(sdt.gxTv_SdtProduto_Prddeldata_N);
            sdtIsNull = 0;
            gxTv_SdtProduto_Prddeldata = sdt.gxTv_SdtProduto_Prddeldata ;
         }
         if ( sdt.IsDirty("PrdDelHora") )
         {
            gxTv_SdtProduto_Prddelhora_N = (short)(sdt.gxTv_SdtProduto_Prddelhora_N);
            sdtIsNull = 0;
            gxTv_SdtProduto_Prddelhora = sdt.gxTv_SdtProduto_Prddelhora ;
         }
         if ( sdt.IsDirty("PrdDelUsuId") )
         {
            gxTv_SdtProduto_Prddelusuid_N = (short)(sdt.gxTv_SdtProduto_Prddelusuid_N);
            sdtIsNull = 0;
            gxTv_SdtProduto_Prddelusuid = sdt.gxTv_SdtProduto_Prddelusuid ;
         }
         if ( sdt.IsDirty("PrdDelUsuNome") )
         {
            gxTv_SdtProduto_Prddelusunome_N = (short)(sdt.gxTv_SdtProduto_Prddelusunome_N);
            sdtIsNull = 0;
            gxTv_SdtProduto_Prddelusunome = sdt.gxTv_SdtProduto_Prddelusunome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PrdID" )]
      [  XmlElement( ElementName = "PrdID"   )]
      public Guid gxTpr_Prdid
      {
         get {
            return gxTv_SdtProduto_Prdid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtProduto_Prdid != value )
            {
               gxTv_SdtProduto_Mode = "INS";
               this.gxTv_SdtProduto_Prdid_Z_SetNull( );
               this.gxTv_SdtProduto_Prdcodigo_Z_SetNull( );
               this.gxTv_SdtProduto_Prdnome_Z_SetNull( );
               this.gxTv_SdtProduto_Prdinsdata_Z_SetNull( );
               this.gxTv_SdtProduto_Prdinshora_Z_SetNull( );
               this.gxTv_SdtProduto_Prdinsdatahora_Z_SetNull( );
               this.gxTv_SdtProduto_Prdinsusuid_Z_SetNull( );
               this.gxTv_SdtProduto_Prdupddata_Z_SetNull( );
               this.gxTv_SdtProduto_Prdupdhora_Z_SetNull( );
               this.gxTv_SdtProduto_Prdupddatahora_Z_SetNull( );
               this.gxTv_SdtProduto_Prdupdusuid_Z_SetNull( );
               this.gxTv_SdtProduto_Prdativo_Z_SetNull( );
               this.gxTv_SdtProduto_Prdtipoid_Z_SetNull( );
               this.gxTv_SdtProduto_Prdtiposigla_Z_SetNull( );
               this.gxTv_SdtProduto_Prdtiponome_Z_SetNull( );
               this.gxTv_SdtProduto_Prddel_Z_SetNull( );
               this.gxTv_SdtProduto_Prddeldatahora_Z_SetNull( );
               this.gxTv_SdtProduto_Prddeldata_Z_SetNull( );
               this.gxTv_SdtProduto_Prddelhora_Z_SetNull( );
               this.gxTv_SdtProduto_Prddelusuid_Z_SetNull( );
               this.gxTv_SdtProduto_Prddelusunome_Z_SetNull( );
            }
            gxTv_SdtProduto_Prdid = value;
            SetDirty("Prdid");
         }

      }

      [  SoapElement( ElementName = "PrdCodigo" )]
      [  XmlElement( ElementName = "PrdCodigo"   )]
      public string gxTpr_Prdcodigo
      {
         get {
            return gxTv_SdtProduto_Prdcodigo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdcodigo = value;
            SetDirty("Prdcodigo");
         }

      }

      [  SoapElement( ElementName = "PrdNome" )]
      [  XmlElement( ElementName = "PrdNome"   )]
      public string gxTpr_Prdnome
      {
         get {
            return gxTv_SdtProduto_Prdnome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdnome = value;
            SetDirty("Prdnome");
         }

      }

      [  SoapElement( ElementName = "PrdInsData" )]
      [  XmlElement( ElementName = "PrdInsData"  , IsNullable=true )]
      public string gxTpr_Prdinsdata_Nullable
      {
         get {
            if ( gxTv_SdtProduto_Prdinsdata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtProduto_Prdinsdata).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtProduto_Prdinsdata = DateTime.MinValue;
            else
               gxTv_SdtProduto_Prdinsdata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prdinsdata
      {
         get {
            return gxTv_SdtProduto_Prdinsdata ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdinsdata = value;
            SetDirty("Prdinsdata");
         }

      }

      [  SoapElement( ElementName = "PrdInsHora" )]
      [  XmlElement( ElementName = "PrdInsHora"  , IsNullable=true )]
      public string gxTpr_Prdinshora_Nullable
      {
         get {
            if ( gxTv_SdtProduto_Prdinshora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProduto_Prdinshora).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProduto_Prdinshora = DateTime.MinValue;
            else
               gxTv_SdtProduto_Prdinshora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prdinshora
      {
         get {
            return gxTv_SdtProduto_Prdinshora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdinshora = value;
            SetDirty("Prdinshora");
         }

      }

      [  SoapElement( ElementName = "PrdInsDataHora" )]
      [  XmlElement( ElementName = "PrdInsDataHora"  , IsNullable=true )]
      public string gxTpr_Prdinsdatahora_Nullable
      {
         get {
            if ( gxTv_SdtProduto_Prdinsdatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProduto_Prdinsdatahora, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProduto_Prdinsdatahora = DateTime.MinValue;
            else
               gxTv_SdtProduto_Prdinsdatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prdinsdatahora
      {
         get {
            return gxTv_SdtProduto_Prdinsdatahora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdinsdatahora = value;
            SetDirty("Prdinsdatahora");
         }

      }

      [  SoapElement( ElementName = "PrdInsUsuID" )]
      [  XmlElement( ElementName = "PrdInsUsuID"   )]
      public string gxTpr_Prdinsusuid
      {
         get {
            return gxTv_SdtProduto_Prdinsusuid ;
         }

         set {
            gxTv_SdtProduto_Prdinsusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdinsusuid = value;
            SetDirty("Prdinsusuid");
         }

      }

      public void gxTv_SdtProduto_Prdinsusuid_SetNull( )
      {
         gxTv_SdtProduto_Prdinsusuid_N = 1;
         gxTv_SdtProduto_Prdinsusuid = "";
         SetDirty("Prdinsusuid");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdinsusuid_IsNull( )
      {
         return (gxTv_SdtProduto_Prdinsusuid_N==1) ;
      }

      [  SoapElement( ElementName = "PrdUpdData" )]
      [  XmlElement( ElementName = "PrdUpdData"  , IsNullable=true )]
      public string gxTpr_Prdupddata_Nullable
      {
         get {
            if ( gxTv_SdtProduto_Prdupddata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtProduto_Prdupddata).value ;
         }

         set {
            gxTv_SdtProduto_Prdupddata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtProduto_Prdupddata = DateTime.MinValue;
            else
               gxTv_SdtProduto_Prdupddata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prdupddata
      {
         get {
            return gxTv_SdtProduto_Prdupddata ;
         }

         set {
            gxTv_SdtProduto_Prdupddata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdupddata = value;
            SetDirty("Prdupddata");
         }

      }

      public void gxTv_SdtProduto_Prdupddata_SetNull( )
      {
         gxTv_SdtProduto_Prdupddata_N = 1;
         gxTv_SdtProduto_Prdupddata = (DateTime)(DateTime.MinValue);
         SetDirty("Prdupddata");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdupddata_IsNull( )
      {
         return (gxTv_SdtProduto_Prdupddata_N==1) ;
      }

      [  SoapElement( ElementName = "PrdUpdHora" )]
      [  XmlElement( ElementName = "PrdUpdHora"  , IsNullable=true )]
      public string gxTpr_Prdupdhora_Nullable
      {
         get {
            if ( gxTv_SdtProduto_Prdupdhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProduto_Prdupdhora).value ;
         }

         set {
            gxTv_SdtProduto_Prdupdhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProduto_Prdupdhora = DateTime.MinValue;
            else
               gxTv_SdtProduto_Prdupdhora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prdupdhora
      {
         get {
            return gxTv_SdtProduto_Prdupdhora ;
         }

         set {
            gxTv_SdtProduto_Prdupdhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdupdhora = value;
            SetDirty("Prdupdhora");
         }

      }

      public void gxTv_SdtProduto_Prdupdhora_SetNull( )
      {
         gxTv_SdtProduto_Prdupdhora_N = 1;
         gxTv_SdtProduto_Prdupdhora = (DateTime)(DateTime.MinValue);
         SetDirty("Prdupdhora");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdupdhora_IsNull( )
      {
         return (gxTv_SdtProduto_Prdupdhora_N==1) ;
      }

      [  SoapElement( ElementName = "PrdUpdDataHora" )]
      [  XmlElement( ElementName = "PrdUpdDataHora"  , IsNullable=true )]
      public string gxTpr_Prdupddatahora_Nullable
      {
         get {
            if ( gxTv_SdtProduto_Prdupddatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProduto_Prdupddatahora, null, true).value ;
         }

         set {
            gxTv_SdtProduto_Prdupddatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProduto_Prdupddatahora = DateTime.MinValue;
            else
               gxTv_SdtProduto_Prdupddatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prdupddatahora
      {
         get {
            return gxTv_SdtProduto_Prdupddatahora ;
         }

         set {
            gxTv_SdtProduto_Prdupddatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdupddatahora = value;
            SetDirty("Prdupddatahora");
         }

      }

      public void gxTv_SdtProduto_Prdupddatahora_SetNull( )
      {
         gxTv_SdtProduto_Prdupddatahora_N = 1;
         gxTv_SdtProduto_Prdupddatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Prdupddatahora");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdupddatahora_IsNull( )
      {
         return (gxTv_SdtProduto_Prdupddatahora_N==1) ;
      }

      [  SoapElement( ElementName = "PrdUpdUsuID" )]
      [  XmlElement( ElementName = "PrdUpdUsuID"   )]
      public string gxTpr_Prdupdusuid
      {
         get {
            return gxTv_SdtProduto_Prdupdusuid ;
         }

         set {
            gxTv_SdtProduto_Prdupdusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdupdusuid = value;
            SetDirty("Prdupdusuid");
         }

      }

      public void gxTv_SdtProduto_Prdupdusuid_SetNull( )
      {
         gxTv_SdtProduto_Prdupdusuid_N = 1;
         gxTv_SdtProduto_Prdupdusuid = "";
         SetDirty("Prdupdusuid");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdupdusuid_IsNull( )
      {
         return (gxTv_SdtProduto_Prdupdusuid_N==1) ;
      }

      [  SoapElement( ElementName = "PrdAtivo" )]
      [  XmlElement( ElementName = "PrdAtivo"   )]
      public bool gxTpr_Prdativo
      {
         get {
            return gxTv_SdtProduto_Prdativo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdativo = value;
            SetDirty("Prdativo");
         }

      }

      [  SoapElement( ElementName = "PrdTipoID" )]
      [  XmlElement( ElementName = "PrdTipoID"   )]
      public int gxTpr_Prdtipoid
      {
         get {
            return gxTv_SdtProduto_Prdtipoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdtipoid = value;
            SetDirty("Prdtipoid");
         }

      }

      [  SoapElement( ElementName = "PrdTipoSigla" )]
      [  XmlElement( ElementName = "PrdTipoSigla"   )]
      public string gxTpr_Prdtiposigla
      {
         get {
            return gxTv_SdtProduto_Prdtiposigla ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdtiposigla = value;
            SetDirty("Prdtiposigla");
         }

      }

      [  SoapElement( ElementName = "PrdTipoNome" )]
      [  XmlElement( ElementName = "PrdTipoNome"   )]
      public string gxTpr_Prdtiponome
      {
         get {
            return gxTv_SdtProduto_Prdtiponome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdtiponome = value;
            SetDirty("Prdtiponome");
         }

      }

      [  SoapElement( ElementName = "PrdDel" )]
      [  XmlElement( ElementName = "PrdDel"   )]
      public bool gxTpr_Prddel
      {
         get {
            return gxTv_SdtProduto_Prddel ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prddel = value;
            SetDirty("Prddel");
         }

      }

      [  SoapElement( ElementName = "PrdDelDataHora" )]
      [  XmlElement( ElementName = "PrdDelDataHora"  , IsNullable=true )]
      public string gxTpr_Prddeldatahora_Nullable
      {
         get {
            if ( gxTv_SdtProduto_Prddeldatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProduto_Prddeldatahora, null, true).value ;
         }

         set {
            gxTv_SdtProduto_Prddeldatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProduto_Prddeldatahora = DateTime.MinValue;
            else
               gxTv_SdtProduto_Prddeldatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prddeldatahora
      {
         get {
            return gxTv_SdtProduto_Prddeldatahora ;
         }

         set {
            gxTv_SdtProduto_Prddeldatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProduto_Prddeldatahora = value;
            SetDirty("Prddeldatahora");
         }

      }

      public void gxTv_SdtProduto_Prddeldatahora_SetNull( )
      {
         gxTv_SdtProduto_Prddeldatahora_N = 1;
         gxTv_SdtProduto_Prddeldatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Prddeldatahora");
         return  ;
      }

      public bool gxTv_SdtProduto_Prddeldatahora_IsNull( )
      {
         return (gxTv_SdtProduto_Prddeldatahora_N==1) ;
      }

      [  SoapElement( ElementName = "PrdDelData" )]
      [  XmlElement( ElementName = "PrdDelData"  , IsNullable=true )]
      public string gxTpr_Prddeldata_Nullable
      {
         get {
            if ( gxTv_SdtProduto_Prddeldata == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProduto_Prddeldata).value ;
         }

         set {
            gxTv_SdtProduto_Prddeldata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProduto_Prddeldata = DateTime.MinValue;
            else
               gxTv_SdtProduto_Prddeldata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prddeldata
      {
         get {
            return gxTv_SdtProduto_Prddeldata ;
         }

         set {
            gxTv_SdtProduto_Prddeldata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProduto_Prddeldata = value;
            SetDirty("Prddeldata");
         }

      }

      public void gxTv_SdtProduto_Prddeldata_SetNull( )
      {
         gxTv_SdtProduto_Prddeldata_N = 1;
         gxTv_SdtProduto_Prddeldata = (DateTime)(DateTime.MinValue);
         SetDirty("Prddeldata");
         return  ;
      }

      public bool gxTv_SdtProduto_Prddeldata_IsNull( )
      {
         return (gxTv_SdtProduto_Prddeldata_N==1) ;
      }

      [  SoapElement( ElementName = "PrdDelHora" )]
      [  XmlElement( ElementName = "PrdDelHora"  , IsNullable=true )]
      public string gxTpr_Prddelhora_Nullable
      {
         get {
            if ( gxTv_SdtProduto_Prddelhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProduto_Prddelhora).value ;
         }

         set {
            gxTv_SdtProduto_Prddelhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProduto_Prddelhora = DateTime.MinValue;
            else
               gxTv_SdtProduto_Prddelhora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prddelhora
      {
         get {
            return gxTv_SdtProduto_Prddelhora ;
         }

         set {
            gxTv_SdtProduto_Prddelhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProduto_Prddelhora = value;
            SetDirty("Prddelhora");
         }

      }

      public void gxTv_SdtProduto_Prddelhora_SetNull( )
      {
         gxTv_SdtProduto_Prddelhora_N = 1;
         gxTv_SdtProduto_Prddelhora = (DateTime)(DateTime.MinValue);
         SetDirty("Prddelhora");
         return  ;
      }

      public bool gxTv_SdtProduto_Prddelhora_IsNull( )
      {
         return (gxTv_SdtProduto_Prddelhora_N==1) ;
      }

      [  SoapElement( ElementName = "PrdDelUsuId" )]
      [  XmlElement( ElementName = "PrdDelUsuId"   )]
      public string gxTpr_Prddelusuid
      {
         get {
            return gxTv_SdtProduto_Prddelusuid ;
         }

         set {
            gxTv_SdtProduto_Prddelusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProduto_Prddelusuid = value;
            SetDirty("Prddelusuid");
         }

      }

      public void gxTv_SdtProduto_Prddelusuid_SetNull( )
      {
         gxTv_SdtProduto_Prddelusuid_N = 1;
         gxTv_SdtProduto_Prddelusuid = "";
         SetDirty("Prddelusuid");
         return  ;
      }

      public bool gxTv_SdtProduto_Prddelusuid_IsNull( )
      {
         return (gxTv_SdtProduto_Prddelusuid_N==1) ;
      }

      [  SoapElement( ElementName = "PrdDelUsuNome" )]
      [  XmlElement( ElementName = "PrdDelUsuNome"   )]
      public string gxTpr_Prddelusunome
      {
         get {
            return gxTv_SdtProduto_Prddelusunome ;
         }

         set {
            gxTv_SdtProduto_Prddelusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProduto_Prddelusunome = value;
            SetDirty("Prddelusunome");
         }

      }

      public void gxTv_SdtProduto_Prddelusunome_SetNull( )
      {
         gxTv_SdtProduto_Prddelusunome_N = 1;
         gxTv_SdtProduto_Prddelusunome = "";
         SetDirty("Prddelusunome");
         return  ;
      }

      public bool gxTv_SdtProduto_Prddelusunome_IsNull( )
      {
         return (gxTv_SdtProduto_Prddelusunome_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtProduto_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtProduto_Mode_SetNull( )
      {
         gxTv_SdtProduto_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtProduto_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtProduto_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtProduto_Initialized_SetNull( )
      {
         gxTv_SdtProduto_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtProduto_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdID_Z" )]
      [  XmlElement( ElementName = "PrdID_Z"   )]
      public Guid gxTpr_Prdid_Z
      {
         get {
            return gxTv_SdtProduto_Prdid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdid_Z = value;
            SetDirty("Prdid_Z");
         }

      }

      public void gxTv_SdtProduto_Prdid_Z_SetNull( )
      {
         gxTv_SdtProduto_Prdid_Z = Guid.Empty;
         SetDirty("Prdid_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdCodigo_Z" )]
      [  XmlElement( ElementName = "PrdCodigo_Z"   )]
      public string gxTpr_Prdcodigo_Z
      {
         get {
            return gxTv_SdtProduto_Prdcodigo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdcodigo_Z = value;
            SetDirty("Prdcodigo_Z");
         }

      }

      public void gxTv_SdtProduto_Prdcodigo_Z_SetNull( )
      {
         gxTv_SdtProduto_Prdcodigo_Z = "";
         SetDirty("Prdcodigo_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdcodigo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdNome_Z" )]
      [  XmlElement( ElementName = "PrdNome_Z"   )]
      public string gxTpr_Prdnome_Z
      {
         get {
            return gxTv_SdtProduto_Prdnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdnome_Z = value;
            SetDirty("Prdnome_Z");
         }

      }

      public void gxTv_SdtProduto_Prdnome_Z_SetNull( )
      {
         gxTv_SdtProduto_Prdnome_Z = "";
         SetDirty("Prdnome_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdInsData_Z" )]
      [  XmlElement( ElementName = "PrdInsData_Z"  , IsNullable=true )]
      public string gxTpr_Prdinsdata_Z_Nullable
      {
         get {
            if ( gxTv_SdtProduto_Prdinsdata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtProduto_Prdinsdata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtProduto_Prdinsdata_Z = DateTime.MinValue;
            else
               gxTv_SdtProduto_Prdinsdata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prdinsdata_Z
      {
         get {
            return gxTv_SdtProduto_Prdinsdata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdinsdata_Z = value;
            SetDirty("Prdinsdata_Z");
         }

      }

      public void gxTv_SdtProduto_Prdinsdata_Z_SetNull( )
      {
         gxTv_SdtProduto_Prdinsdata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Prdinsdata_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdinsdata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdInsHora_Z" )]
      [  XmlElement( ElementName = "PrdInsHora_Z"  , IsNullable=true )]
      public string gxTpr_Prdinshora_Z_Nullable
      {
         get {
            if ( gxTv_SdtProduto_Prdinshora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProduto_Prdinshora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProduto_Prdinshora_Z = DateTime.MinValue;
            else
               gxTv_SdtProduto_Prdinshora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prdinshora_Z
      {
         get {
            return gxTv_SdtProduto_Prdinshora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdinshora_Z = value;
            SetDirty("Prdinshora_Z");
         }

      }

      public void gxTv_SdtProduto_Prdinshora_Z_SetNull( )
      {
         gxTv_SdtProduto_Prdinshora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Prdinshora_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdinshora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdInsDataHora_Z" )]
      [  XmlElement( ElementName = "PrdInsDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Prdinsdatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtProduto_Prdinsdatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProduto_Prdinsdatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProduto_Prdinsdatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtProduto_Prdinsdatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prdinsdatahora_Z
      {
         get {
            return gxTv_SdtProduto_Prdinsdatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdinsdatahora_Z = value;
            SetDirty("Prdinsdatahora_Z");
         }

      }

      public void gxTv_SdtProduto_Prdinsdatahora_Z_SetNull( )
      {
         gxTv_SdtProduto_Prdinsdatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Prdinsdatahora_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdinsdatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdInsUsuID_Z" )]
      [  XmlElement( ElementName = "PrdInsUsuID_Z"   )]
      public string gxTpr_Prdinsusuid_Z
      {
         get {
            return gxTv_SdtProduto_Prdinsusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdinsusuid_Z = value;
            SetDirty("Prdinsusuid_Z");
         }

      }

      public void gxTv_SdtProduto_Prdinsusuid_Z_SetNull( )
      {
         gxTv_SdtProduto_Prdinsusuid_Z = "";
         SetDirty("Prdinsusuid_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdinsusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdUpdData_Z" )]
      [  XmlElement( ElementName = "PrdUpdData_Z"  , IsNullable=true )]
      public string gxTpr_Prdupddata_Z_Nullable
      {
         get {
            if ( gxTv_SdtProduto_Prdupddata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtProduto_Prdupddata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtProduto_Prdupddata_Z = DateTime.MinValue;
            else
               gxTv_SdtProduto_Prdupddata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prdupddata_Z
      {
         get {
            return gxTv_SdtProduto_Prdupddata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdupddata_Z = value;
            SetDirty("Prdupddata_Z");
         }

      }

      public void gxTv_SdtProduto_Prdupddata_Z_SetNull( )
      {
         gxTv_SdtProduto_Prdupddata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Prdupddata_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdupddata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdUpdHora_Z" )]
      [  XmlElement( ElementName = "PrdUpdHora_Z"  , IsNullable=true )]
      public string gxTpr_Prdupdhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtProduto_Prdupdhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProduto_Prdupdhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProduto_Prdupdhora_Z = DateTime.MinValue;
            else
               gxTv_SdtProduto_Prdupdhora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prdupdhora_Z
      {
         get {
            return gxTv_SdtProduto_Prdupdhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdupdhora_Z = value;
            SetDirty("Prdupdhora_Z");
         }

      }

      public void gxTv_SdtProduto_Prdupdhora_Z_SetNull( )
      {
         gxTv_SdtProduto_Prdupdhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Prdupdhora_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdupdhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdUpdDataHora_Z" )]
      [  XmlElement( ElementName = "PrdUpdDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Prdupddatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtProduto_Prdupddatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProduto_Prdupddatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProduto_Prdupddatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtProduto_Prdupddatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prdupddatahora_Z
      {
         get {
            return gxTv_SdtProduto_Prdupddatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdupddatahora_Z = value;
            SetDirty("Prdupddatahora_Z");
         }

      }

      public void gxTv_SdtProduto_Prdupddatahora_Z_SetNull( )
      {
         gxTv_SdtProduto_Prdupddatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Prdupddatahora_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdupddatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdUpdUsuID_Z" )]
      [  XmlElement( ElementName = "PrdUpdUsuID_Z"   )]
      public string gxTpr_Prdupdusuid_Z
      {
         get {
            return gxTv_SdtProduto_Prdupdusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdupdusuid_Z = value;
            SetDirty("Prdupdusuid_Z");
         }

      }

      public void gxTv_SdtProduto_Prdupdusuid_Z_SetNull( )
      {
         gxTv_SdtProduto_Prdupdusuid_Z = "";
         SetDirty("Prdupdusuid_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdupdusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdAtivo_Z" )]
      [  XmlElement( ElementName = "PrdAtivo_Z"   )]
      public bool gxTpr_Prdativo_Z
      {
         get {
            return gxTv_SdtProduto_Prdativo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdativo_Z = value;
            SetDirty("Prdativo_Z");
         }

      }

      public void gxTv_SdtProduto_Prdativo_Z_SetNull( )
      {
         gxTv_SdtProduto_Prdativo_Z = false;
         SetDirty("Prdativo_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdTipoID_Z" )]
      [  XmlElement( ElementName = "PrdTipoID_Z"   )]
      public int gxTpr_Prdtipoid_Z
      {
         get {
            return gxTv_SdtProduto_Prdtipoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdtipoid_Z = value;
            SetDirty("Prdtipoid_Z");
         }

      }

      public void gxTv_SdtProduto_Prdtipoid_Z_SetNull( )
      {
         gxTv_SdtProduto_Prdtipoid_Z = 0;
         SetDirty("Prdtipoid_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdtipoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdTipoSigla_Z" )]
      [  XmlElement( ElementName = "PrdTipoSigla_Z"   )]
      public string gxTpr_Prdtiposigla_Z
      {
         get {
            return gxTv_SdtProduto_Prdtiposigla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdtiposigla_Z = value;
            SetDirty("Prdtiposigla_Z");
         }

      }

      public void gxTv_SdtProduto_Prdtiposigla_Z_SetNull( )
      {
         gxTv_SdtProduto_Prdtiposigla_Z = "";
         SetDirty("Prdtiposigla_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdtiposigla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdTipoNome_Z" )]
      [  XmlElement( ElementName = "PrdTipoNome_Z"   )]
      public string gxTpr_Prdtiponome_Z
      {
         get {
            return gxTv_SdtProduto_Prdtiponome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdtiponome_Z = value;
            SetDirty("Prdtiponome_Z");
         }

      }

      public void gxTv_SdtProduto_Prdtiponome_Z_SetNull( )
      {
         gxTv_SdtProduto_Prdtiponome_Z = "";
         SetDirty("Prdtiponome_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdtiponome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdDel_Z" )]
      [  XmlElement( ElementName = "PrdDel_Z"   )]
      public bool gxTpr_Prddel_Z
      {
         get {
            return gxTv_SdtProduto_Prddel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prddel_Z = value;
            SetDirty("Prddel_Z");
         }

      }

      public void gxTv_SdtProduto_Prddel_Z_SetNull( )
      {
         gxTv_SdtProduto_Prddel_Z = false;
         SetDirty("Prddel_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Prddel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdDelDataHora_Z" )]
      [  XmlElement( ElementName = "PrdDelDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Prddeldatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtProduto_Prddeldatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProduto_Prddeldatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProduto_Prddeldatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtProduto_Prddeldatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prddeldatahora_Z
      {
         get {
            return gxTv_SdtProduto_Prddeldatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prddeldatahora_Z = value;
            SetDirty("Prddeldatahora_Z");
         }

      }

      public void gxTv_SdtProduto_Prddeldatahora_Z_SetNull( )
      {
         gxTv_SdtProduto_Prddeldatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Prddeldatahora_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Prddeldatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdDelData_Z" )]
      [  XmlElement( ElementName = "PrdDelData_Z"  , IsNullable=true )]
      public string gxTpr_Prddeldata_Z_Nullable
      {
         get {
            if ( gxTv_SdtProduto_Prddeldata_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProduto_Prddeldata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProduto_Prddeldata_Z = DateTime.MinValue;
            else
               gxTv_SdtProduto_Prddeldata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prddeldata_Z
      {
         get {
            return gxTv_SdtProduto_Prddeldata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prddeldata_Z = value;
            SetDirty("Prddeldata_Z");
         }

      }

      public void gxTv_SdtProduto_Prddeldata_Z_SetNull( )
      {
         gxTv_SdtProduto_Prddeldata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Prddeldata_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Prddeldata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdDelHora_Z" )]
      [  XmlElement( ElementName = "PrdDelHora_Z"  , IsNullable=true )]
      public string gxTpr_Prddelhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtProduto_Prddelhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProduto_Prddelhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProduto_Prddelhora_Z = DateTime.MinValue;
            else
               gxTv_SdtProduto_Prddelhora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prddelhora_Z
      {
         get {
            return gxTv_SdtProduto_Prddelhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prddelhora_Z = value;
            SetDirty("Prddelhora_Z");
         }

      }

      public void gxTv_SdtProduto_Prddelhora_Z_SetNull( )
      {
         gxTv_SdtProduto_Prddelhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Prddelhora_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Prddelhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdDelUsuId_Z" )]
      [  XmlElement( ElementName = "PrdDelUsuId_Z"   )]
      public string gxTpr_Prddelusuid_Z
      {
         get {
            return gxTv_SdtProduto_Prddelusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prddelusuid_Z = value;
            SetDirty("Prddelusuid_Z");
         }

      }

      public void gxTv_SdtProduto_Prddelusuid_Z_SetNull( )
      {
         gxTv_SdtProduto_Prddelusuid_Z = "";
         SetDirty("Prddelusuid_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Prddelusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdDelUsuNome_Z" )]
      [  XmlElement( ElementName = "PrdDelUsuNome_Z"   )]
      public string gxTpr_Prddelusunome_Z
      {
         get {
            return gxTv_SdtProduto_Prddelusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prddelusunome_Z = value;
            SetDirty("Prddelusunome_Z");
         }

      }

      public void gxTv_SdtProduto_Prddelusunome_Z_SetNull( )
      {
         gxTv_SdtProduto_Prddelusunome_Z = "";
         SetDirty("Prddelusunome_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Prddelusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdInsUsuID_N" )]
      [  XmlElement( ElementName = "PrdInsUsuID_N"   )]
      public short gxTpr_Prdinsusuid_N
      {
         get {
            return gxTv_SdtProduto_Prdinsusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdinsusuid_N = value;
            SetDirty("Prdinsusuid_N");
         }

      }

      public void gxTv_SdtProduto_Prdinsusuid_N_SetNull( )
      {
         gxTv_SdtProduto_Prdinsusuid_N = 0;
         SetDirty("Prdinsusuid_N");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdinsusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdUpdData_N" )]
      [  XmlElement( ElementName = "PrdUpdData_N"   )]
      public short gxTpr_Prdupddata_N
      {
         get {
            return gxTv_SdtProduto_Prdupddata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdupddata_N = value;
            SetDirty("Prdupddata_N");
         }

      }

      public void gxTv_SdtProduto_Prdupddata_N_SetNull( )
      {
         gxTv_SdtProduto_Prdupddata_N = 0;
         SetDirty("Prdupddata_N");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdupddata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdUpdHora_N" )]
      [  XmlElement( ElementName = "PrdUpdHora_N"   )]
      public short gxTpr_Prdupdhora_N
      {
         get {
            return gxTv_SdtProduto_Prdupdhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdupdhora_N = value;
            SetDirty("Prdupdhora_N");
         }

      }

      public void gxTv_SdtProduto_Prdupdhora_N_SetNull( )
      {
         gxTv_SdtProduto_Prdupdhora_N = 0;
         SetDirty("Prdupdhora_N");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdupdhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdUpdDataHora_N" )]
      [  XmlElement( ElementName = "PrdUpdDataHora_N"   )]
      public short gxTpr_Prdupddatahora_N
      {
         get {
            return gxTv_SdtProduto_Prdupddatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdupddatahora_N = value;
            SetDirty("Prdupddatahora_N");
         }

      }

      public void gxTv_SdtProduto_Prdupddatahora_N_SetNull( )
      {
         gxTv_SdtProduto_Prdupddatahora_N = 0;
         SetDirty("Prdupddatahora_N");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdupddatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdUpdUsuID_N" )]
      [  XmlElement( ElementName = "PrdUpdUsuID_N"   )]
      public short gxTpr_Prdupdusuid_N
      {
         get {
            return gxTv_SdtProduto_Prdupdusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prdupdusuid_N = value;
            SetDirty("Prdupdusuid_N");
         }

      }

      public void gxTv_SdtProduto_Prdupdusuid_N_SetNull( )
      {
         gxTv_SdtProduto_Prdupdusuid_N = 0;
         SetDirty("Prdupdusuid_N");
         return  ;
      }

      public bool gxTv_SdtProduto_Prdupdusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdDelDataHora_N" )]
      [  XmlElement( ElementName = "PrdDelDataHora_N"   )]
      public short gxTpr_Prddeldatahora_N
      {
         get {
            return gxTv_SdtProduto_Prddeldatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prddeldatahora_N = value;
            SetDirty("Prddeldatahora_N");
         }

      }

      public void gxTv_SdtProduto_Prddeldatahora_N_SetNull( )
      {
         gxTv_SdtProduto_Prddeldatahora_N = 0;
         SetDirty("Prddeldatahora_N");
         return  ;
      }

      public bool gxTv_SdtProduto_Prddeldatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdDelData_N" )]
      [  XmlElement( ElementName = "PrdDelData_N"   )]
      public short gxTpr_Prddeldata_N
      {
         get {
            return gxTv_SdtProduto_Prddeldata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prddeldata_N = value;
            SetDirty("Prddeldata_N");
         }

      }

      public void gxTv_SdtProduto_Prddeldata_N_SetNull( )
      {
         gxTv_SdtProduto_Prddeldata_N = 0;
         SetDirty("Prddeldata_N");
         return  ;
      }

      public bool gxTv_SdtProduto_Prddeldata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdDelHora_N" )]
      [  XmlElement( ElementName = "PrdDelHora_N"   )]
      public short gxTpr_Prddelhora_N
      {
         get {
            return gxTv_SdtProduto_Prddelhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prddelhora_N = value;
            SetDirty("Prddelhora_N");
         }

      }

      public void gxTv_SdtProduto_Prddelhora_N_SetNull( )
      {
         gxTv_SdtProduto_Prddelhora_N = 0;
         SetDirty("Prddelhora_N");
         return  ;
      }

      public bool gxTv_SdtProduto_Prddelhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdDelUsuId_N" )]
      [  XmlElement( ElementName = "PrdDelUsuId_N"   )]
      public short gxTpr_Prddelusuid_N
      {
         get {
            return gxTv_SdtProduto_Prddelusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prddelusuid_N = value;
            SetDirty("Prddelusuid_N");
         }

      }

      public void gxTv_SdtProduto_Prddelusuid_N_SetNull( )
      {
         gxTv_SdtProduto_Prddelusuid_N = 0;
         SetDirty("Prddelusuid_N");
         return  ;
      }

      public bool gxTv_SdtProduto_Prddelusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdDelUsuNome_N" )]
      [  XmlElement( ElementName = "PrdDelUsuNome_N"   )]
      public short gxTpr_Prddelusunome_N
      {
         get {
            return gxTv_SdtProduto_Prddelusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduto_Prddelusunome_N = value;
            SetDirty("Prddelusunome_N");
         }

      }

      public void gxTv_SdtProduto_Prddelusunome_N_SetNull( )
      {
         gxTv_SdtProduto_Prddelusunome_N = 0;
         SetDirty("Prddelusunome_N");
         return  ;
      }

      public bool gxTv_SdtProduto_Prddelusunome_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtProduto_Prdid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtProduto_Prdcodigo = "";
         gxTv_SdtProduto_Prdnome = "";
         gxTv_SdtProduto_Prdinsdata = DateTime.MinValue;
         gxTv_SdtProduto_Prdinshora = (DateTime)(DateTime.MinValue);
         gxTv_SdtProduto_Prdinsdatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtProduto_Prdinsusuid = "";
         gxTv_SdtProduto_Prdupddata = DateTime.MinValue;
         gxTv_SdtProduto_Prdupdhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtProduto_Prdupddatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtProduto_Prdupdusuid = "";
         gxTv_SdtProduto_Prdativo = true;
         gxTv_SdtProduto_Prdtiposigla = "";
         gxTv_SdtProduto_Prdtiponome = "";
         gxTv_SdtProduto_Prddeldatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtProduto_Prddeldata = (DateTime)(DateTime.MinValue);
         gxTv_SdtProduto_Prddelhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtProduto_Prddelusuid = "";
         gxTv_SdtProduto_Prddelusunome = "";
         gxTv_SdtProduto_Mode = "";
         gxTv_SdtProduto_Prdid_Z = Guid.Empty;
         gxTv_SdtProduto_Prdcodigo_Z = "";
         gxTv_SdtProduto_Prdnome_Z = "";
         gxTv_SdtProduto_Prdinsdata_Z = DateTime.MinValue;
         gxTv_SdtProduto_Prdinshora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtProduto_Prdinsdatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtProduto_Prdinsusuid_Z = "";
         gxTv_SdtProduto_Prdupddata_Z = DateTime.MinValue;
         gxTv_SdtProduto_Prdupdhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtProduto_Prdupddatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtProduto_Prdupdusuid_Z = "";
         gxTv_SdtProduto_Prdtiposigla_Z = "";
         gxTv_SdtProduto_Prdtiponome_Z = "";
         gxTv_SdtProduto_Prddeldatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtProduto_Prddeldata_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtProduto_Prddelhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtProduto_Prddelusuid_Z = "";
         gxTv_SdtProduto_Prddelusunome_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "core.produto", "GeneXus.Programs.core.produto_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtProduto_Initialized ;
      private short gxTv_SdtProduto_Prdinsusuid_N ;
      private short gxTv_SdtProduto_Prdupddata_N ;
      private short gxTv_SdtProduto_Prdupdhora_N ;
      private short gxTv_SdtProduto_Prdupddatahora_N ;
      private short gxTv_SdtProduto_Prdupdusuid_N ;
      private short gxTv_SdtProduto_Prddeldatahora_N ;
      private short gxTv_SdtProduto_Prddeldata_N ;
      private short gxTv_SdtProduto_Prddelhora_N ;
      private short gxTv_SdtProduto_Prddelusuid_N ;
      private short gxTv_SdtProduto_Prddelusunome_N ;
      private int gxTv_SdtProduto_Prdtipoid ;
      private int gxTv_SdtProduto_Prdtipoid_Z ;
      private string gxTv_SdtProduto_Prdinsusuid ;
      private string gxTv_SdtProduto_Prdupdusuid ;
      private string gxTv_SdtProduto_Prddelusuid ;
      private string gxTv_SdtProduto_Mode ;
      private string gxTv_SdtProduto_Prdinsusuid_Z ;
      private string gxTv_SdtProduto_Prdupdusuid_Z ;
      private string gxTv_SdtProduto_Prddelusuid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtProduto_Prdinshora ;
      private DateTime gxTv_SdtProduto_Prdinsdatahora ;
      private DateTime gxTv_SdtProduto_Prdupdhora ;
      private DateTime gxTv_SdtProduto_Prdupddatahora ;
      private DateTime gxTv_SdtProduto_Prddeldatahora ;
      private DateTime gxTv_SdtProduto_Prddeldata ;
      private DateTime gxTv_SdtProduto_Prddelhora ;
      private DateTime gxTv_SdtProduto_Prdinshora_Z ;
      private DateTime gxTv_SdtProduto_Prdinsdatahora_Z ;
      private DateTime gxTv_SdtProduto_Prdupdhora_Z ;
      private DateTime gxTv_SdtProduto_Prdupddatahora_Z ;
      private DateTime gxTv_SdtProduto_Prddeldatahora_Z ;
      private DateTime gxTv_SdtProduto_Prddeldata_Z ;
      private DateTime gxTv_SdtProduto_Prddelhora_Z ;
      private DateTime datetime_STZ ;
      private DateTime datetimemil_STZ ;
      private DateTime gxTv_SdtProduto_Prdinsdata ;
      private DateTime gxTv_SdtProduto_Prdupddata ;
      private DateTime gxTv_SdtProduto_Prdinsdata_Z ;
      private DateTime gxTv_SdtProduto_Prdupddata_Z ;
      private bool gxTv_SdtProduto_Prdativo ;
      private bool gxTv_SdtProduto_Prddel ;
      private bool gxTv_SdtProduto_Prdativo_Z ;
      private bool gxTv_SdtProduto_Prddel_Z ;
      private string gxTv_SdtProduto_Prdcodigo ;
      private string gxTv_SdtProduto_Prdnome ;
      private string gxTv_SdtProduto_Prdtiposigla ;
      private string gxTv_SdtProduto_Prdtiponome ;
      private string gxTv_SdtProduto_Prddelusunome ;
      private string gxTv_SdtProduto_Prdcodigo_Z ;
      private string gxTv_SdtProduto_Prdnome_Z ;
      private string gxTv_SdtProduto_Prdtiposigla_Z ;
      private string gxTv_SdtProduto_Prdtiponome_Z ;
      private string gxTv_SdtProduto_Prddelusunome_Z ;
      private Guid gxTv_SdtProduto_Prdid ;
      private Guid gxTv_SdtProduto_Prdid_Z ;
   }

   [DataContract(Name = @"core\Produto", Namespace = "agl_tresorygroup")]
   public class SdtProduto_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtProduto>
   {
      public SdtProduto_RESTInterface( ) : base()
      {
      }

      public SdtProduto_RESTInterface( GeneXus.Programs.core.SdtProduto psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PrdID" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Prdid
      {
         get {
            return sdt.gxTpr_Prdid ;
         }

         set {
            sdt.gxTpr_Prdid = value;
         }

      }

      [DataMember( Name = "PrdCodigo" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Prdcodigo
      {
         get {
            return sdt.gxTpr_Prdcodigo ;
         }

         set {
            sdt.gxTpr_Prdcodigo = value;
         }

      }

      [DataMember( Name = "PrdNome" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Prdnome
      {
         get {
            return sdt.gxTpr_Prdnome ;
         }

         set {
            sdt.gxTpr_Prdnome = value;
         }

      }

      [DataMember( Name = "PrdInsData" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Prdinsdata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Prdinsdata) ;
         }

         set {
            sdt.gxTpr_Prdinsdata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "PrdInsHora" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Prdinshora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Prdinshora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Prdinshora = GXt_dtime1;
         }

      }

      [DataMember( Name = "PrdInsDataHora" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Prdinsdatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Prdinsdatahora) ;
         }

         set {
            sdt.gxTpr_Prdinsdatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "PrdInsUsuID" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Prdinsusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Prdinsusuid) ;
         }

         set {
            sdt.gxTpr_Prdinsusuid = value;
         }

      }

      [DataMember( Name = "PrdUpdData" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Prdupddata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Prdupddata) ;
         }

         set {
            sdt.gxTpr_Prdupddata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "PrdUpdHora" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Prdupdhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Prdupdhora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Prdupdhora = GXt_dtime1;
         }

      }

      [DataMember( Name = "PrdUpdDataHora" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Prdupddatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Prdupddatahora) ;
         }

         set {
            sdt.gxTpr_Prdupddatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "PrdUpdUsuID" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Prdupdusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Prdupdusuid) ;
         }

         set {
            sdt.gxTpr_Prdupdusuid = value;
         }

      }

      [DataMember( Name = "PrdAtivo" , Order = 11 )]
      [GxSeudo()]
      public bool gxTpr_Prdativo
      {
         get {
            return sdt.gxTpr_Prdativo ;
         }

         set {
            sdt.gxTpr_Prdativo = value;
         }

      }

      [DataMember( Name = "PrdTipoID" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Prdtipoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Prdtipoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Prdtipoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PrdTipoSigla" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Prdtiposigla
      {
         get {
            return sdt.gxTpr_Prdtiposigla ;
         }

         set {
            sdt.gxTpr_Prdtiposigla = value;
         }

      }

      [DataMember( Name = "PrdTipoNome" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Prdtiponome
      {
         get {
            return sdt.gxTpr_Prdtiponome ;
         }

         set {
            sdt.gxTpr_Prdtiponome = value;
         }

      }

      [DataMember( Name = "PrdDel" , Order = 15 )]
      [GxSeudo()]
      public bool gxTpr_Prddel
      {
         get {
            return sdt.gxTpr_Prddel ;
         }

         set {
            sdt.gxTpr_Prddel = value;
         }

      }

      [DataMember( Name = "PrdDelDataHora" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Prddeldatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Prddeldatahora) ;
         }

         set {
            sdt.gxTpr_Prddeldatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "PrdDelData" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Prddeldata
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Prddeldata) ;
         }

         set {
            sdt.gxTpr_Prddeldata = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "PrdDelHora" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Prddelhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Prddelhora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Prddelhora = GXt_dtime1;
         }

      }

      [DataMember( Name = "PrdDelUsuId" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Prddelusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Prddelusuid) ;
         }

         set {
            sdt.gxTpr_Prddelusuid = value;
         }

      }

      [DataMember( Name = "PrdDelUsuNome" , Order = 20 )]
      [GxSeudo()]
      public string gxTpr_Prddelusunome
      {
         get {
            return sdt.gxTpr_Prddelusunome ;
         }

         set {
            sdt.gxTpr_Prddelusunome = value;
         }

      }

      public GeneXus.Programs.core.SdtProduto sdt
      {
         get {
            return (GeneXus.Programs.core.SdtProduto)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtProduto() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 21 )]
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

   [DataContract(Name = @"core\Produto", Namespace = "agl_tresorygroup")]
   public class SdtProduto_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtProduto>
   {
      public SdtProduto_RESTLInterface( ) : base()
      {
      }

      public SdtProduto_RESTLInterface( GeneXus.Programs.core.SdtProduto psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PrdCodigo" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Prdcodigo
      {
         get {
            return sdt.gxTpr_Prdcodigo ;
         }

         set {
            sdt.gxTpr_Prdcodigo = value;
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

      public GeneXus.Programs.core.SdtProduto sdt
      {
         get {
            return (GeneXus.Programs.core.SdtProduto)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtProduto() ;
         }
      }

   }

}
