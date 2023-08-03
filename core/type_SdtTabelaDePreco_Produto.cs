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
   [XmlRoot(ElementName = "TabelaDePreco.Produto" )]
   [XmlType(TypeName =  "TabelaDePreco.Produto" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class SdtTabelaDePreco_Produto : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtTabelaDePreco_Produto( )
      {
      }

      public SdtTabelaDePreco_Produto( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"PrdID", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Produto");
         metadata.Set("BT", "tb_tabeladepreco_produto");
         metadata.Set("PK", "[ \"PrdID\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"PrdID\" ],\"FKMap\":[  ] },{ \"FK\":[ \"TppID\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Prdid_Z");
         state.Add("gxTpr_Prdcodigo_Z");
         state.Add("gxTpr_Prdnome_Z");
         state.Add("gxTpr_Prdtipoid_Z");
         state.Add("gxTpr_Prdativo_Z");
         state.Add("gxTpr_Tpp1preco_Z");
         state.Add("gxTpr_Tpp1del_Z");
         state.Add("gxTpr_Tpp1deldatahora_Z_Nullable");
         state.Add("gxTpr_Tpp1deldata_Z_Nullable");
         state.Add("gxTpr_Tpp1delhora_Z_Nullable");
         state.Add("gxTpr_Tpp1delusuid_Z");
         state.Add("gxTpr_Tpp1delusunome_Z");
         state.Add("gxTpr_Tpp1deldatahora_N");
         state.Add("gxTpr_Tpp1deldata_N");
         state.Add("gxTpr_Tpp1delhora_N");
         state.Add("gxTpr_Tpp1delusuid_N");
         state.Add("gxTpr_Tpp1delusunome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.SdtTabelaDePreco_Produto sdt;
         sdt = (GeneXus.Programs.core.SdtTabelaDePreco_Produto)(source);
         gxTv_SdtTabelaDePreco_Produto_Prdid = sdt.gxTv_SdtTabelaDePreco_Produto_Prdid ;
         gxTv_SdtTabelaDePreco_Produto_Prdcodigo = sdt.gxTv_SdtTabelaDePreco_Produto_Prdcodigo ;
         gxTv_SdtTabelaDePreco_Produto_Prdnome = sdt.gxTv_SdtTabelaDePreco_Produto_Prdnome ;
         gxTv_SdtTabelaDePreco_Produto_Prdtipoid = sdt.gxTv_SdtTabelaDePreco_Produto_Prdtipoid ;
         gxTv_SdtTabelaDePreco_Produto_Prdativo = sdt.gxTv_SdtTabelaDePreco_Produto_Prdativo ;
         gxTv_SdtTabelaDePreco_Produto_Tpp1preco = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1preco ;
         gxTv_SdtTabelaDePreco_Produto_Tpp1del = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1del ;
         gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora ;
         gxTv_SdtTabelaDePreco_Produto_Tpp1deldata = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1deldata ;
         gxTv_SdtTabelaDePreco_Produto_Tpp1delhora = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1delhora ;
         gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid ;
         gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome ;
         gxTv_SdtTabelaDePreco_Produto_Mode = sdt.gxTv_SdtTabelaDePreco_Produto_Mode ;
         gxTv_SdtTabelaDePreco_Produto_Modified = sdt.gxTv_SdtTabelaDePreco_Produto_Modified ;
         gxTv_SdtTabelaDePreco_Produto_Initialized = sdt.gxTv_SdtTabelaDePreco_Produto_Initialized ;
         gxTv_SdtTabelaDePreco_Produto_Prdid_Z = sdt.gxTv_SdtTabelaDePreco_Produto_Prdid_Z ;
         gxTv_SdtTabelaDePreco_Produto_Prdcodigo_Z = sdt.gxTv_SdtTabelaDePreco_Produto_Prdcodigo_Z ;
         gxTv_SdtTabelaDePreco_Produto_Prdnome_Z = sdt.gxTv_SdtTabelaDePreco_Produto_Prdnome_Z ;
         gxTv_SdtTabelaDePreco_Produto_Prdtipoid_Z = sdt.gxTv_SdtTabelaDePreco_Produto_Prdtipoid_Z ;
         gxTv_SdtTabelaDePreco_Produto_Prdativo_Z = sdt.gxTv_SdtTabelaDePreco_Produto_Prdativo_Z ;
         gxTv_SdtTabelaDePreco_Produto_Tpp1preco_Z = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1preco_Z ;
         gxTv_SdtTabelaDePreco_Produto_Tpp1del_Z = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1del_Z ;
         gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_Z = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_Z ;
         gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_Z = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_Z ;
         gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_Z = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_Z ;
         gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_Z = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_Z ;
         gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_Z = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_Z ;
         gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_N = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_N ;
         gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_N = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_N ;
         gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_N = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_N ;
         gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_N = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_N ;
         gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_N = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_N ;
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
         AddObjectProperty("PrdID", gxTv_SdtTabelaDePreco_Produto_Prdid, false, includeNonInitialized);
         AddObjectProperty("PrdCodigo", gxTv_SdtTabelaDePreco_Produto_Prdcodigo, false, includeNonInitialized);
         AddObjectProperty("PrdNome", gxTv_SdtTabelaDePreco_Produto_Prdnome, false, includeNonInitialized);
         AddObjectProperty("PrdTipoID", gxTv_SdtTabelaDePreco_Produto_Prdtipoid, false, includeNonInitialized);
         AddObjectProperty("PrdAtivo", gxTv_SdtTabelaDePreco_Produto_Prdativo, false, includeNonInitialized);
         AddObjectProperty("Tpp1Preco", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTabelaDePreco_Produto_Tpp1preco, 16, 2)), false, includeNonInitialized);
         AddObjectProperty("Tpp1Del", gxTv_SdtTabelaDePreco_Produto_Tpp1del, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora;
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
         AddObjectProperty("Tpp1DelDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("Tpp1DelDataHora_N", gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTabelaDePreco_Produto_Tpp1deldata;
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
         AddObjectProperty("Tpp1DelData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("Tpp1DelData_N", gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTabelaDePreco_Produto_Tpp1delhora;
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
         AddObjectProperty("Tpp1DelHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("Tpp1DelHora_N", gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_N, false, includeNonInitialized);
         AddObjectProperty("Tpp1DelUsuId", gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid, false, includeNonInitialized);
         AddObjectProperty("Tpp1DelUsuId_N", gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_N, false, includeNonInitialized);
         AddObjectProperty("Tpp1DelUsuNome", gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome, false, includeNonInitialized);
         AddObjectProperty("Tpp1DelUsuNome_N", gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTabelaDePreco_Produto_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtTabelaDePreco_Produto_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTabelaDePreco_Produto_Initialized, false, includeNonInitialized);
            AddObjectProperty("PrdID_Z", gxTv_SdtTabelaDePreco_Produto_Prdid_Z, false, includeNonInitialized);
            AddObjectProperty("PrdCodigo_Z", gxTv_SdtTabelaDePreco_Produto_Prdcodigo_Z, false, includeNonInitialized);
            AddObjectProperty("PrdNome_Z", gxTv_SdtTabelaDePreco_Produto_Prdnome_Z, false, includeNonInitialized);
            AddObjectProperty("PrdTipoID_Z", gxTv_SdtTabelaDePreco_Produto_Prdtipoid_Z, false, includeNonInitialized);
            AddObjectProperty("PrdAtivo_Z", gxTv_SdtTabelaDePreco_Produto_Prdativo_Z, false, includeNonInitialized);
            AddObjectProperty("Tpp1Preco_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTabelaDePreco_Produto_Tpp1preco_Z, 16, 2)), false, includeNonInitialized);
            AddObjectProperty("Tpp1Del_Z", gxTv_SdtTabelaDePreco_Produto_Tpp1del_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_Z;
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
            AddObjectProperty("Tpp1DelDataHora_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_Z;
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
            AddObjectProperty("Tpp1DelData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_Z;
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
            AddObjectProperty("Tpp1DelHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("Tpp1DelUsuId_Z", gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_Z, false, includeNonInitialized);
            AddObjectProperty("Tpp1DelUsuNome_Z", gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_Z, false, includeNonInitialized);
            AddObjectProperty("Tpp1DelDataHora_N", gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_N, false, includeNonInitialized);
            AddObjectProperty("Tpp1DelData_N", gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_N, false, includeNonInitialized);
            AddObjectProperty("Tpp1DelHora_N", gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_N, false, includeNonInitialized);
            AddObjectProperty("Tpp1DelUsuId_N", gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_N, false, includeNonInitialized);
            AddObjectProperty("Tpp1DelUsuNome_N", gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.SdtTabelaDePreco_Produto sdt )
      {
         if ( sdt.IsDirty("PrdID") )
         {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Prdid = sdt.gxTv_SdtTabelaDePreco_Produto_Prdid ;
         }
         if ( sdt.IsDirty("PrdCodigo") )
         {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Prdcodigo = sdt.gxTv_SdtTabelaDePreco_Produto_Prdcodigo ;
         }
         if ( sdt.IsDirty("PrdNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Prdnome = sdt.gxTv_SdtTabelaDePreco_Produto_Prdnome ;
         }
         if ( sdt.IsDirty("PrdTipoID") )
         {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Prdtipoid = sdt.gxTv_SdtTabelaDePreco_Produto_Prdtipoid ;
         }
         if ( sdt.IsDirty("PrdAtivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Prdativo = sdt.gxTv_SdtTabelaDePreco_Produto_Prdativo ;
         }
         if ( sdt.IsDirty("Tpp1Preco") )
         {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1preco = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1preco ;
         }
         if ( sdt.IsDirty("Tpp1Del") )
         {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1del = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1del ;
         }
         if ( sdt.IsDirty("Tpp1DelDataHora") )
         {
            gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_N = (short)(sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_N);
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora ;
         }
         if ( sdt.IsDirty("Tpp1DelData") )
         {
            gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_N = (short)(sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_N);
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1deldata = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1deldata ;
         }
         if ( sdt.IsDirty("Tpp1DelHora") )
         {
            gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_N = (short)(sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_N);
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1delhora = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1delhora ;
         }
         if ( sdt.IsDirty("Tpp1DelUsuId") )
         {
            gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_N = (short)(sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_N);
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid ;
         }
         if ( sdt.IsDirty("Tpp1DelUsuNome") )
         {
            gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_N = (short)(sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_N);
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome = sdt.gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PrdID" )]
      [  XmlElement( ElementName = "PrdID"   )]
      public Guid gxTpr_Prdid
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Prdid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Prdid = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Prdid");
         }

      }

      [  SoapElement( ElementName = "PrdCodigo" )]
      [  XmlElement( ElementName = "PrdCodigo"   )]
      public string gxTpr_Prdcodigo
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Prdcodigo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Prdcodigo = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Prdcodigo");
         }

      }

      [  SoapElement( ElementName = "PrdNome" )]
      [  XmlElement( ElementName = "PrdNome"   )]
      public string gxTpr_Prdnome
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Prdnome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Prdnome = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Prdnome");
         }

      }

      [  SoapElement( ElementName = "PrdTipoID" )]
      [  XmlElement( ElementName = "PrdTipoID"   )]
      public int gxTpr_Prdtipoid
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Prdtipoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Prdtipoid = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Prdtipoid");
         }

      }

      [  SoapElement( ElementName = "PrdAtivo" )]
      [  XmlElement( ElementName = "PrdAtivo"   )]
      public bool gxTpr_Prdativo
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Prdativo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Prdativo = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Prdativo");
         }

      }

      [  SoapElement( ElementName = "Tpp1Preco" )]
      [  XmlElement( ElementName = "Tpp1Preco"   )]
      public decimal gxTpr_Tpp1preco
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Tpp1preco ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1preco = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Tpp1preco");
         }

      }

      [  SoapElement( ElementName = "Tpp1Del" )]
      [  XmlElement( ElementName = "Tpp1Del"   )]
      public bool gxTpr_Tpp1del
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Tpp1del ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1del = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Tpp1del");
         }

      }

      [  SoapElement( ElementName = "Tpp1DelDataHora" )]
      [  XmlElement( ElementName = "Tpp1DelDataHora"  , IsNullable=true )]
      public string gxTpr_Tpp1deldatahora_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora, null, true).value ;
         }

         set {
            gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora = DateTime.Parse( value);
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tpp1deldatahora
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora ;
         }

         set {
            gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Tpp1deldatahora");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_N = 1;
         gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Tpp1deldatahora");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_IsNull( )
      {
         return (gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_N==1) ;
      }

      [  SoapElement( ElementName = "Tpp1DelData" )]
      [  XmlElement( ElementName = "Tpp1DelData"  , IsNullable=true )]
      public string gxTpr_Tpp1deldata_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Produto_Tpp1deldata == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTabelaDePreco_Produto_Tpp1deldata).value ;
         }

         set {
            gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTabelaDePreco_Produto_Tpp1deldata = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Produto_Tpp1deldata = DateTime.Parse( value);
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tpp1deldata
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Tpp1deldata ;
         }

         set {
            gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1deldata = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Tpp1deldata");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_N = 1;
         gxTv_SdtTabelaDePreco_Produto_Tpp1deldata = (DateTime)(DateTime.MinValue);
         SetDirty("Tpp1deldata");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_IsNull( )
      {
         return (gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_N==1) ;
      }

      [  SoapElement( ElementName = "Tpp1DelHora" )]
      [  XmlElement( ElementName = "Tpp1DelHora"  , IsNullable=true )]
      public string gxTpr_Tpp1delhora_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Produto_Tpp1delhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTabelaDePreco_Produto_Tpp1delhora).value ;
         }

         set {
            gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTabelaDePreco_Produto_Tpp1delhora = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Produto_Tpp1delhora = DateTime.Parse( value);
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tpp1delhora
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Tpp1delhora ;
         }

         set {
            gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1delhora = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Tpp1delhora");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_N = 1;
         gxTv_SdtTabelaDePreco_Produto_Tpp1delhora = (DateTime)(DateTime.MinValue);
         SetDirty("Tpp1delhora");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_IsNull( )
      {
         return (gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_N==1) ;
      }

      [  SoapElement( ElementName = "Tpp1DelUsuId" )]
      [  XmlElement( ElementName = "Tpp1DelUsuId"   )]
      public string gxTpr_Tpp1delusuid
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid ;
         }

         set {
            gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Tpp1delusuid");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_N = 1;
         gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid = "";
         SetDirty("Tpp1delusuid");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_IsNull( )
      {
         return (gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_N==1) ;
      }

      [  SoapElement( ElementName = "Tpp1DelUsuNome" )]
      [  XmlElement( ElementName = "Tpp1DelUsuNome"   )]
      public string gxTpr_Tpp1delusunome
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome ;
         }

         set {
            gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Tpp1delusunome");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_N = 1;
         gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome = "";
         SetDirty("Tpp1delusunome");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_IsNull( )
      {
         return (gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Mode_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Modified_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Initialized = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Initialized_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdID_Z" )]
      [  XmlElement( ElementName = "PrdID_Z"   )]
      public Guid gxTpr_Prdid_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Prdid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Prdid_Z = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Prdid_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Prdid_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Prdid_Z = Guid.Empty;
         SetDirty("Prdid_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Prdid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdCodigo_Z" )]
      [  XmlElement( ElementName = "PrdCodigo_Z"   )]
      public string gxTpr_Prdcodigo_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Prdcodigo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Prdcodigo_Z = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Prdcodigo_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Prdcodigo_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Prdcodigo_Z = "";
         SetDirty("Prdcodigo_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Prdcodigo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdNome_Z" )]
      [  XmlElement( ElementName = "PrdNome_Z"   )]
      public string gxTpr_Prdnome_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Prdnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Prdnome_Z = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Prdnome_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Prdnome_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Prdnome_Z = "";
         SetDirty("Prdnome_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Prdnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdTipoID_Z" )]
      [  XmlElement( ElementName = "PrdTipoID_Z"   )]
      public int gxTpr_Prdtipoid_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Prdtipoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Prdtipoid_Z = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Prdtipoid_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Prdtipoid_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Prdtipoid_Z = 0;
         SetDirty("Prdtipoid_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Prdtipoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrdAtivo_Z" )]
      [  XmlElement( ElementName = "PrdAtivo_Z"   )]
      public bool gxTpr_Prdativo_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Prdativo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Prdativo_Z = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Prdativo_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Prdativo_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Prdativo_Z = false;
         SetDirty("Prdativo_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Prdativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Tpp1Preco_Z" )]
      [  XmlElement( ElementName = "Tpp1Preco_Z"   )]
      public decimal gxTpr_Tpp1preco_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Tpp1preco_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1preco_Z = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Tpp1preco_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Tpp1preco_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Tpp1preco_Z = 0;
         SetDirty("Tpp1preco_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Tpp1preco_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Tpp1Del_Z" )]
      [  XmlElement( ElementName = "Tpp1Del_Z"   )]
      public bool gxTpr_Tpp1del_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Tpp1del_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1del_Z = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Tpp1del_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Tpp1del_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Tpp1del_Z = false;
         SetDirty("Tpp1del_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Tpp1del_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Tpp1DelDataHora_Z" )]
      [  XmlElement( ElementName = "Tpp1DelDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Tpp1deldatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_Z = DateTime.Parse( value);
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tpp1deldatahora_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_Z = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Tpp1deldatahora_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Tpp1deldatahora_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Tpp1DelData_Z" )]
      [  XmlElement( ElementName = "Tpp1DelData_Z"  , IsNullable=true )]
      public string gxTpr_Tpp1deldata_Z_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_Z = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_Z = DateTime.Parse( value);
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tpp1deldata_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_Z = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Tpp1deldata_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Tpp1deldata_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Tpp1DelHora_Z" )]
      [  XmlElement( ElementName = "Tpp1DelHora_Z"  , IsNullable=true )]
      public string gxTpr_Tpp1delhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_Z = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_Z = DateTime.Parse( value);
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tpp1delhora_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_Z = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Tpp1delhora_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Tpp1delhora_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Tpp1DelUsuId_Z" )]
      [  XmlElement( ElementName = "Tpp1DelUsuId_Z"   )]
      public string gxTpr_Tpp1delusuid_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_Z = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Tpp1delusuid_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_Z = "";
         SetDirty("Tpp1delusuid_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Tpp1DelUsuNome_Z" )]
      [  XmlElement( ElementName = "Tpp1DelUsuNome_Z"   )]
      public string gxTpr_Tpp1delusunome_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_Z = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Tpp1delusunome_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_Z = "";
         SetDirty("Tpp1delusunome_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Tpp1DelDataHora_N" )]
      [  XmlElement( ElementName = "Tpp1DelDataHora_N"   )]
      public short gxTpr_Tpp1deldatahora_N
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_N = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Tpp1deldatahora_N");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_N_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_N = 0;
         SetDirty("Tpp1deldatahora_N");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Tpp1DelData_N" )]
      [  XmlElement( ElementName = "Tpp1DelData_N"   )]
      public short gxTpr_Tpp1deldata_N
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_N = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Tpp1deldata_N");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_N_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_N = 0;
         SetDirty("Tpp1deldata_N");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Tpp1DelHora_N" )]
      [  XmlElement( ElementName = "Tpp1DelHora_N"   )]
      public short gxTpr_Tpp1delhora_N
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_N = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Tpp1delhora_N");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_N_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_N = 0;
         SetDirty("Tpp1delhora_N");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Tpp1DelUsuId_N" )]
      [  XmlElement( ElementName = "Tpp1DelUsuId_N"   )]
      public short gxTpr_Tpp1delusuid_N
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_N = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Tpp1delusuid_N");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_N_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_N = 0;
         SetDirty("Tpp1delusuid_N");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Tpp1DelUsuNome_N" )]
      [  XmlElement( ElementName = "Tpp1DelUsuNome_N"   )]
      public short gxTpr_Tpp1delusunome_N
      {
         get {
            return gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_N = value;
            gxTv_SdtTabelaDePreco_Produto_Modified = 1;
            SetDirty("Tpp1delusunome_N");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_N_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_N = 0;
         SetDirty("Tpp1delusunome_N");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtTabelaDePreco_Produto_Prdid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTabelaDePreco_Produto_Prdcodigo = "";
         gxTv_SdtTabelaDePreco_Produto_Prdnome = "";
         gxTv_SdtTabelaDePreco_Produto_Prdativo = true;
         gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtTabelaDePreco_Produto_Tpp1deldata = (DateTime)(DateTime.MinValue);
         gxTv_SdtTabelaDePreco_Produto_Tpp1delhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid = "";
         gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome = "";
         gxTv_SdtTabelaDePreco_Produto_Mode = "";
         gxTv_SdtTabelaDePreco_Produto_Prdid_Z = Guid.Empty;
         gxTv_SdtTabelaDePreco_Produto_Prdcodigo_Z = "";
         gxTv_SdtTabelaDePreco_Produto_Prdnome_Z = "";
         gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_Z = "";
         gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_Z = "";
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtTabelaDePreco_Produto_Modified ;
      private short gxTv_SdtTabelaDePreco_Produto_Initialized ;
      private short gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_N ;
      private short gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_N ;
      private short gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_N ;
      private short gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_N ;
      private short gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_N ;
      private int gxTv_SdtTabelaDePreco_Produto_Prdtipoid ;
      private int gxTv_SdtTabelaDePreco_Produto_Prdtipoid_Z ;
      private decimal gxTv_SdtTabelaDePreco_Produto_Tpp1preco ;
      private decimal gxTv_SdtTabelaDePreco_Produto_Tpp1preco_Z ;
      private string gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid ;
      private string gxTv_SdtTabelaDePreco_Produto_Mode ;
      private string gxTv_SdtTabelaDePreco_Produto_Tpp1delusuid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora ;
      private DateTime gxTv_SdtTabelaDePreco_Produto_Tpp1deldata ;
      private DateTime gxTv_SdtTabelaDePreco_Produto_Tpp1delhora ;
      private DateTime gxTv_SdtTabelaDePreco_Produto_Tpp1deldatahora_Z ;
      private DateTime gxTv_SdtTabelaDePreco_Produto_Tpp1deldata_Z ;
      private DateTime gxTv_SdtTabelaDePreco_Produto_Tpp1delhora_Z ;
      private DateTime datetimemil_STZ ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtTabelaDePreco_Produto_Prdativo ;
      private bool gxTv_SdtTabelaDePreco_Produto_Tpp1del ;
      private bool gxTv_SdtTabelaDePreco_Produto_Prdativo_Z ;
      private bool gxTv_SdtTabelaDePreco_Produto_Tpp1del_Z ;
      private string gxTv_SdtTabelaDePreco_Produto_Prdcodigo ;
      private string gxTv_SdtTabelaDePreco_Produto_Prdnome ;
      private string gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome ;
      private string gxTv_SdtTabelaDePreco_Produto_Prdcodigo_Z ;
      private string gxTv_SdtTabelaDePreco_Produto_Prdnome_Z ;
      private string gxTv_SdtTabelaDePreco_Produto_Tpp1delusunome_Z ;
      private Guid gxTv_SdtTabelaDePreco_Produto_Prdid ;
      private Guid gxTv_SdtTabelaDePreco_Produto_Prdid_Z ;
   }

   [DataContract(Name = @"core\TabelaDePreco.Produto", Namespace = "agl_tresorygroup")]
   public class SdtTabelaDePreco_Produto_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtTabelaDePreco_Produto>
   {
      public SdtTabelaDePreco_Produto_RESTInterface( ) : base()
      {
      }

      public SdtTabelaDePreco_Produto_RESTInterface( GeneXus.Programs.core.SdtTabelaDePreco_Produto psdt ) : base(psdt)
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

      [DataMember( Name = "PrdTipoID" , Order = 3 )]
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

      [DataMember( Name = "PrdAtivo" , Order = 4 )]
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

      [DataMember( Name = "Tpp1Preco" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Tpp1preco
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Tpp1preco, 16, 2)) ;
         }

         set {
            sdt.gxTpr_Tpp1preco = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "Tpp1Del" , Order = 6 )]
      [GxSeudo()]
      public bool gxTpr_Tpp1del
      {
         get {
            return sdt.gxTpr_Tpp1del ;
         }

         set {
            sdt.gxTpr_Tpp1del = value;
         }

      }

      [DataMember( Name = "Tpp1DelDataHora" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Tpp1deldatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Tpp1deldatahora) ;
         }

         set {
            sdt.gxTpr_Tpp1deldatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "Tpp1DelData" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Tpp1deldata
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Tpp1deldata) ;
         }

         set {
            sdt.gxTpr_Tpp1deldata = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "Tpp1DelHora" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Tpp1delhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Tpp1delhora) ;
         }

         set {
            GXt_dtime2 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Tpp1delhora = GXt_dtime2;
         }

      }

      [DataMember( Name = "Tpp1DelUsuId" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Tpp1delusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Tpp1delusuid) ;
         }

         set {
            sdt.gxTpr_Tpp1delusuid = value;
         }

      }

      [DataMember( Name = "Tpp1DelUsuNome" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Tpp1delusunome
      {
         get {
            return sdt.gxTpr_Tpp1delusunome ;
         }

         set {
            sdt.gxTpr_Tpp1delusunome = value;
         }

      }

      public GeneXus.Programs.core.SdtTabelaDePreco_Produto sdt
      {
         get {
            return (GeneXus.Programs.core.SdtTabelaDePreco_Produto)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtTabelaDePreco_Produto() ;
         }
      }

      private DateTime GXt_dtime2 ;
   }

   [DataContract(Name = @"core\TabelaDePreco.Produto", Namespace = "agl_tresorygroup")]
   public class SdtTabelaDePreco_Produto_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtTabelaDePreco_Produto>
   {
      public SdtTabelaDePreco_Produto_RESTLInterface( ) : base()
      {
      }

      public SdtTabelaDePreco_Produto_RESTLInterface( GeneXus.Programs.core.SdtTabelaDePreco_Produto psdt ) : base(psdt)
      {
      }

      public GeneXus.Programs.core.SdtTabelaDePreco_Produto sdt
      {
         get {
            return (GeneXus.Programs.core.SdtTabelaDePreco_Produto)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtTabelaDePreco_Produto() ;
         }
      }

   }

}
