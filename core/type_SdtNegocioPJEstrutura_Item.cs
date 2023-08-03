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
   [XmlRoot(ElementName = "NegocioPJEstrutura.Item" )]
   [XmlType(TypeName =  "NegocioPJEstrutura.Item" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class SdtNegocioPJEstrutura_Item : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtNegocioPJEstrutura_Item( )
      {
      }

      public SdtNegocioPJEstrutura_Item( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"NgpItem", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Item");
         metadata.Set("BT", "tb_negociopj_item");
         metadata.Set("PK", "[ \"NgpItem\" ]");
         metadata.Set("PKAssigned", "[ \"NgpItem\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"NegID\" ],\"FKMap\":[  ] },{ \"FK\":[ \"TppID\",\"PrdID\" ],\"FKMap\":[ \"NgpTppID-TppID\",\"NgpTppPrdID-PrdID\" ] } ]");
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
         state.Add("gxTpr_Ngpitem_Z");
         state.Add("gxTpr_Ngpinsdata_Z_Nullable");
         state.Add("gxTpr_Ngpinshora_Z_Nullable");
         state.Add("gxTpr_Ngpinsdatahora_Z_Nullable");
         state.Add("gxTpr_Ngpinsusuid_Z");
         state.Add("gxTpr_Ngpinsusunome_Z");
         state.Add("gxTpr_Ngptppid_Z");
         state.Add("gxTpr_Ngptppprdid_Z");
         state.Add("gxTpr_Ngptppprdcodigo_Z");
         state.Add("gxTpr_Ngptppprdnome_Z");
         state.Add("gxTpr_Ngptppprdtipoid_Z");
         state.Add("gxTpr_Ngptppprdativo_Z");
         state.Add("gxTpr_Ngptpp1preco_Z");
         state.Add("gxTpr_Ngppreco_Z");
         state.Add("gxTpr_Ngpqtde_Z");
         state.Add("gxTpr_Ngptotal_Z");
         state.Add("gxTpr_Ngpobs_Z");
         state.Add("gxTpr_Ngpdel_Z");
         state.Add("gxTpr_Ngpdeldatahora_Z_Nullable");
         state.Add("gxTpr_Ngpdeldata_Z_Nullable");
         state.Add("gxTpr_Ngpdelhora_Z_Nullable");
         state.Add("gxTpr_Ngpdelusuid_Z");
         state.Add("gxTpr_Ngpdelusunome_Z");
         state.Add("gxTpr_Ngpinsusuid_N");
         state.Add("gxTpr_Ngpinsusunome_N");
         state.Add("gxTpr_Ngpdeldatahora_N");
         state.Add("gxTpr_Ngpdeldata_N");
         state.Add("gxTpr_Ngpdelhora_N");
         state.Add("gxTpr_Ngpdelusuid_N");
         state.Add("gxTpr_Ngpdelusunome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.SdtNegocioPJEstrutura_Item sdt;
         sdt = (GeneXus.Programs.core.SdtNegocioPJEstrutura_Item)(source);
         gxTv_SdtNegocioPJEstrutura_Item_Ngpitem = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpitem ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppid = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptppid ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdid = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdid ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdcodigo = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdcodigo ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdnome = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdnome ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdtipoid = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdtipoid ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdativo = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdativo ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngptpp1preco = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptpp1preco ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngppreco = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngppreco ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpqtde = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpqtde ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngptotal = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptotal ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpobs = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpobs ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdel = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdel ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome ;
         gxTv_SdtNegocioPJEstrutura_Item_Mode = sdt.gxTv_SdtNegocioPJEstrutura_Item_Mode ;
         gxTv_SdtNegocioPJEstrutura_Item_Modified = sdt.gxTv_SdtNegocioPJEstrutura_Item_Modified ;
         gxTv_SdtNegocioPJEstrutura_Item_Initialized = sdt.gxTv_SdtNegocioPJEstrutura_Item_Initialized ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpitem_Z = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpitem_Z ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata_Z = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata_Z ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora_Z = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora_Z ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora_Z = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora_Z ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_Z = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_Z ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_Z = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_Z ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppid_Z = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptppid_Z ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdid_Z = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdid_Z ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdcodigo_Z = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdcodigo_Z ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdnome_Z = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdnome_Z ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdtipoid_Z = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdtipoid_Z ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdativo_Z = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdativo_Z ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngptpp1preco_Z = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptpp1preco_Z ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngppreco_Z = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngppreco_Z ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpqtde_Z = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpqtde_Z ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngptotal_Z = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptotal_Z ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpobs_Z = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpobs_Z ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdel_Z = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdel_Z ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_Z = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_Z ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_Z = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_Z ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_Z = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_Z ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_Z = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_Z ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_Z = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_Z ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_N = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_N ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_N = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_N ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_N = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_N ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_N = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_N ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_N = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_N ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_N = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_N ;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_N = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_N ;
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
         AddObjectProperty("NgpItem", gxTv_SdtNegocioPJEstrutura_Item_Ngpitem, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("NgpInsData", sDateCnv, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora;
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
         AddObjectProperty("NgpInsHora", sDateCnv, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora;
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
         AddObjectProperty("NgpInsDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NgpInsUsuID", gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid, false, includeNonInitialized);
         AddObjectProperty("NgpInsUsuID_N", gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_N, false, includeNonInitialized);
         AddObjectProperty("NgpInsUsuNome", gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome, false, includeNonInitialized);
         AddObjectProperty("NgpInsUsuNome_N", gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_N, false, includeNonInitialized);
         AddObjectProperty("NgpTppID", gxTv_SdtNegocioPJEstrutura_Item_Ngptppid, false, includeNonInitialized);
         AddObjectProperty("NgpTppPrdID", gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdid, false, includeNonInitialized);
         AddObjectProperty("NgpTppPrdCodigo", gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdcodigo, false, includeNonInitialized);
         AddObjectProperty("NgpTppPrdNome", gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdnome, false, includeNonInitialized);
         AddObjectProperty("NgpTppPrdTipoID", gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdtipoid, false, includeNonInitialized);
         AddObjectProperty("NgpTppPrdAtivo", gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdativo, false, includeNonInitialized);
         AddObjectProperty("NgpTpp1Preco", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNegocioPJEstrutura_Item_Ngptpp1preco, 16, 2)), false, includeNonInitialized);
         AddObjectProperty("NgpPreco", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNegocioPJEstrutura_Item_Ngppreco, 16, 2)), false, includeNonInitialized);
         AddObjectProperty("NgpQtde", gxTv_SdtNegocioPJEstrutura_Item_Ngpqtde, false, includeNonInitialized);
         AddObjectProperty("NgpTotal", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNegocioPJEstrutura_Item_Ngptotal, 16, 2)), false, includeNonInitialized);
         AddObjectProperty("NgpObs", gxTv_SdtNegocioPJEstrutura_Item_Ngpobs, false, includeNonInitialized);
         AddObjectProperty("NgpDel", gxTv_SdtNegocioPJEstrutura_Item_Ngpdel, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora;
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
         AddObjectProperty("NgpDelDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NgpDelDataHora_N", gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata;
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
         AddObjectProperty("NgpDelData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NgpDelData_N", gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora;
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
         AddObjectProperty("NgpDelHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NgpDelHora_N", gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_N, false, includeNonInitialized);
         AddObjectProperty("NgpDelUsuId", gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid, false, includeNonInitialized);
         AddObjectProperty("NgpDelUsuId_N", gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_N, false, includeNonInitialized);
         AddObjectProperty("NgpDelUsuNome", gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome, false, includeNonInitialized);
         AddObjectProperty("NgpDelUsuNome_N", gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtNegocioPJEstrutura_Item_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtNegocioPJEstrutura_Item_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtNegocioPJEstrutura_Item_Initialized, false, includeNonInitialized);
            AddObjectProperty("NgpItem_Z", gxTv_SdtNegocioPJEstrutura_Item_Ngpitem_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("NgpInsData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora_Z;
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
            AddObjectProperty("NgpInsHora_Z", sDateCnv, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora_Z;
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
            AddObjectProperty("NgpInsDataHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("NgpInsUsuID_Z", gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_Z, false, includeNonInitialized);
            AddObjectProperty("NgpInsUsuNome_Z", gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_Z, false, includeNonInitialized);
            AddObjectProperty("NgpTppID_Z", gxTv_SdtNegocioPJEstrutura_Item_Ngptppid_Z, false, includeNonInitialized);
            AddObjectProperty("NgpTppPrdID_Z", gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdid_Z, false, includeNonInitialized);
            AddObjectProperty("NgpTppPrdCodigo_Z", gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdcodigo_Z, false, includeNonInitialized);
            AddObjectProperty("NgpTppPrdNome_Z", gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdnome_Z, false, includeNonInitialized);
            AddObjectProperty("NgpTppPrdTipoID_Z", gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdtipoid_Z, false, includeNonInitialized);
            AddObjectProperty("NgpTppPrdAtivo_Z", gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdativo_Z, false, includeNonInitialized);
            AddObjectProperty("NgpTpp1Preco_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNegocioPJEstrutura_Item_Ngptpp1preco_Z, 16, 2)), false, includeNonInitialized);
            AddObjectProperty("NgpPreco_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNegocioPJEstrutura_Item_Ngppreco_Z, 16, 2)), false, includeNonInitialized);
            AddObjectProperty("NgpQtde_Z", gxTv_SdtNegocioPJEstrutura_Item_Ngpqtde_Z, false, includeNonInitialized);
            AddObjectProperty("NgpTotal_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNegocioPJEstrutura_Item_Ngptotal_Z, 16, 2)), false, includeNonInitialized);
            AddObjectProperty("NgpObs_Z", gxTv_SdtNegocioPJEstrutura_Item_Ngpobs_Z, false, includeNonInitialized);
            AddObjectProperty("NgpDel_Z", gxTv_SdtNegocioPJEstrutura_Item_Ngpdel_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_Z;
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
            AddObjectProperty("NgpDelDataHora_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_Z;
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
            AddObjectProperty("NgpDelData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_Z;
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
            AddObjectProperty("NgpDelHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("NgpDelUsuId_Z", gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_Z, false, includeNonInitialized);
            AddObjectProperty("NgpDelUsuNome_Z", gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_Z, false, includeNonInitialized);
            AddObjectProperty("NgpInsUsuID_N", gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_N, false, includeNonInitialized);
            AddObjectProperty("NgpInsUsuNome_N", gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_N, false, includeNonInitialized);
            AddObjectProperty("NgpDelDataHora_N", gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_N, false, includeNonInitialized);
            AddObjectProperty("NgpDelData_N", gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_N, false, includeNonInitialized);
            AddObjectProperty("NgpDelHora_N", gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_N, false, includeNonInitialized);
            AddObjectProperty("NgpDelUsuId_N", gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_N, false, includeNonInitialized);
            AddObjectProperty("NgpDelUsuNome_N", gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.SdtNegocioPJEstrutura_Item sdt )
      {
         if ( sdt.IsDirty("NgpItem") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpitem = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpitem ;
         }
         if ( sdt.IsDirty("NgpInsData") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata ;
         }
         if ( sdt.IsDirty("NgpInsHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora ;
         }
         if ( sdt.IsDirty("NgpInsDataHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora ;
         }
         if ( sdt.IsDirty("NgpInsUsuID") )
         {
            gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid ;
         }
         if ( sdt.IsDirty("NgpInsUsuNome") )
         {
            gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome ;
         }
         if ( sdt.IsDirty("NgpTppID") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptppid = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptppid ;
         }
         if ( sdt.IsDirty("NgpTppPrdID") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdid = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdid ;
         }
         if ( sdt.IsDirty("NgpTppPrdCodigo") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdcodigo = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdcodigo ;
         }
         if ( sdt.IsDirty("NgpTppPrdNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdnome = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdnome ;
         }
         if ( sdt.IsDirty("NgpTppPrdTipoID") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdtipoid = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdtipoid ;
         }
         if ( sdt.IsDirty("NgpTppPrdAtivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdativo = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdativo ;
         }
         if ( sdt.IsDirty("NgpTpp1Preco") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptpp1preco = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptpp1preco ;
         }
         if ( sdt.IsDirty("NgpPreco") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngppreco = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngppreco ;
         }
         if ( sdt.IsDirty("NgpQtde") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpqtde = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpqtde ;
         }
         if ( sdt.IsDirty("NgpTotal") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptotal = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngptotal ;
         }
         if ( sdt.IsDirty("NgpObs") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpobs = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpobs ;
         }
         if ( sdt.IsDirty("NgpDel") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdel = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdel ;
         }
         if ( sdt.IsDirty("NgpDelDataHora") )
         {
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora ;
         }
         if ( sdt.IsDirty("NgpDelData") )
         {
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata ;
         }
         if ( sdt.IsDirty("NgpDelHora") )
         {
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora ;
         }
         if ( sdt.IsDirty("NgpDelUsuId") )
         {
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid ;
         }
         if ( sdt.IsDirty("NgpDelUsuNome") )
         {
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome = sdt.gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "NgpItem" )]
      [  XmlElement( ElementName = "NgpItem"   )]
      public int gxTpr_Ngpitem
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpitem ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpitem = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpitem");
         }

      }

      [  SoapElement( ElementName = "NgpInsData" )]
      [  XmlElement( ElementName = "NgpInsData"  , IsNullable=true )]
      public string gxTpr_Ngpinsdata_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngpinsdata
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpinsdata");
         }

      }

      [  SoapElement( ElementName = "NgpInsHora" )]
      [  XmlElement( ElementName = "NgpInsHora"  , IsNullable=true )]
      public string gxTpr_Ngpinshora_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngpinshora
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpinshora");
         }

      }

      [  SoapElement( ElementName = "NgpInsDataHora" )]
      [  XmlElement( ElementName = "NgpInsDataHora"  , IsNullable=true )]
      public string gxTpr_Ngpinsdatahora_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngpinsdatahora
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpinsdatahora");
         }

      }

      [  SoapElement( ElementName = "NgpInsUsuID" )]
      [  XmlElement( ElementName = "NgpInsUsuID"   )]
      public string gxTpr_Ngpinsusuid
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpinsusuid");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_N = 1;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid = "";
         SetDirty("Ngpinsusuid");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_N==1) ;
      }

      [  SoapElement( ElementName = "NgpInsUsuNome" )]
      [  XmlElement( ElementName = "NgpInsUsuNome"   )]
      public string gxTpr_Ngpinsusunome
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpinsusunome");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_N = 1;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome = "";
         SetDirty("Ngpinsusunome");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_N==1) ;
      }

      [  SoapElement( ElementName = "NgpTppID" )]
      [  XmlElement( ElementName = "NgpTppID"   )]
      public Guid gxTpr_Ngptppid
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngptppid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptppid = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngptppid");
         }

      }

      [  SoapElement( ElementName = "NgpTppPrdID" )]
      [  XmlElement( ElementName = "NgpTppPrdID"   )]
      public Guid gxTpr_Ngptppprdid
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdid = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngptppprdid");
         }

      }

      [  SoapElement( ElementName = "NgpTppPrdCodigo" )]
      [  XmlElement( ElementName = "NgpTppPrdCodigo"   )]
      public string gxTpr_Ngptppprdcodigo
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdcodigo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdcodigo = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngptppprdcodigo");
         }

      }

      [  SoapElement( ElementName = "NgpTppPrdNome" )]
      [  XmlElement( ElementName = "NgpTppPrdNome"   )]
      public string gxTpr_Ngptppprdnome
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdnome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdnome = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngptppprdnome");
         }

      }

      [  SoapElement( ElementName = "NgpTppPrdTipoID" )]
      [  XmlElement( ElementName = "NgpTppPrdTipoID"   )]
      public int gxTpr_Ngptppprdtipoid
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdtipoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdtipoid = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngptppprdtipoid");
         }

      }

      [  SoapElement( ElementName = "NgpTppPrdAtivo" )]
      [  XmlElement( ElementName = "NgpTppPrdAtivo"   )]
      public bool gxTpr_Ngptppprdativo
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdativo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdativo = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngptppprdativo");
         }

      }

      [  SoapElement( ElementName = "NgpTpp1Preco" )]
      [  XmlElement( ElementName = "NgpTpp1Preco"   )]
      public decimal gxTpr_Ngptpp1preco
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngptpp1preco ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptpp1preco = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngptpp1preco");
         }

      }

      [  SoapElement( ElementName = "NgpPreco" )]
      [  XmlElement( ElementName = "NgpPreco"   )]
      public decimal gxTpr_Ngppreco
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngppreco ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngppreco = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngppreco");
         }

      }

      [  SoapElement( ElementName = "NgpQtde" )]
      [  XmlElement( ElementName = "NgpQtde"   )]
      public int gxTpr_Ngpqtde
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpqtde ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpqtde = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpqtde");
         }

      }

      [  SoapElement( ElementName = "NgpTotal" )]
      [  XmlElement( ElementName = "NgpTotal"   )]
      public decimal gxTpr_Ngptotal
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngptotal ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptotal = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngptotal");
         }

      }

      [  SoapElement( ElementName = "NgpObs" )]
      [  XmlElement( ElementName = "NgpObs"   )]
      public string gxTpr_Ngpobs
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpobs ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpobs = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpobs");
         }

      }

      [  SoapElement( ElementName = "NgpDel" )]
      [  XmlElement( ElementName = "NgpDel"   )]
      public bool gxTpr_Ngpdel
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpdel ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdel = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpdel");
         }

      }

      [  SoapElement( ElementName = "NgpDelDataHora" )]
      [  XmlElement( ElementName = "NgpDelDataHora"  , IsNullable=true )]
      public string gxTpr_Ngpdeldatahora_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora, null, true).value ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngpdeldatahora
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpdeldatahora");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_N = 1;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Ngpdeldatahora");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_N==1) ;
      }

      [  SoapElement( ElementName = "NgpDelData" )]
      [  XmlElement( ElementName = "NgpDelData"  , IsNullable=true )]
      public string gxTpr_Ngpdeldata_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata).value ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngpdeldata
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpdeldata");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_N = 1;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata = (DateTime)(DateTime.MinValue);
         SetDirty("Ngpdeldata");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_N==1) ;
      }

      [  SoapElement( ElementName = "NgpDelHora" )]
      [  XmlElement( ElementName = "NgpDelHora"  , IsNullable=true )]
      public string gxTpr_Ngpdelhora_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora).value ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngpdelhora
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpdelhora");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_N = 1;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora = (DateTime)(DateTime.MinValue);
         SetDirty("Ngpdelhora");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_N==1) ;
      }

      [  SoapElement( ElementName = "NgpDelUsuId" )]
      [  XmlElement( ElementName = "NgpDelUsuId"   )]
      public string gxTpr_Ngpdelusuid
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpdelusuid");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_N = 1;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid = "";
         SetDirty("Ngpdelusuid");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_N==1) ;
      }

      [  SoapElement( ElementName = "NgpDelUsuNome" )]
      [  XmlElement( ElementName = "NgpDelUsuNome"   )]
      public string gxTpr_Ngpdelusunome
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpdelusunome");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_N = 1;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome = "";
         SetDirty("Ngpdelusunome");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Mode_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Modified_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Initialized = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Initialized_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpItem_Z" )]
      [  XmlElement( ElementName = "NgpItem_Z"   )]
      public int gxTpr_Ngpitem_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpitem_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpitem_Z = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpitem_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpitem_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpitem_Z = 0;
         SetDirty("Ngpitem_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpitem_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpInsData_Z" )]
      [  XmlElement( ElementName = "NgpInsData_Z"  , IsNullable=true )]
      public string gxTpr_Ngpinsdata_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata_Z = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngpinsdata_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata_Z = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpinsdata_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Ngpinsdata_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpInsHora_Z" )]
      [  XmlElement( ElementName = "NgpInsHora_Z"  , IsNullable=true )]
      public string gxTpr_Ngpinshora_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora_Z = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngpinshora_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora_Z = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpinshora_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Ngpinshora_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpInsDataHora_Z" )]
      [  XmlElement( ElementName = "NgpInsDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Ngpinsdatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora_Z = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngpinsdatahora_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora_Z = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpinsdatahora_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Ngpinsdatahora_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpInsUsuID_Z" )]
      [  XmlElement( ElementName = "NgpInsUsuID_Z"   )]
      public string gxTpr_Ngpinsusuid_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_Z = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpinsusuid_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_Z = "";
         SetDirty("Ngpinsusuid_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpInsUsuNome_Z" )]
      [  XmlElement( ElementName = "NgpInsUsuNome_Z"   )]
      public string gxTpr_Ngpinsusunome_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_Z = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpinsusunome_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_Z = "";
         SetDirty("Ngpinsusunome_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpTppID_Z" )]
      [  XmlElement( ElementName = "NgpTppID_Z"   )]
      public Guid gxTpr_Ngptppid_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngptppid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptppid_Z = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngptppid_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngptppid_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppid_Z = Guid.Empty;
         SetDirty("Ngptppid_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngptppid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpTppPrdID_Z" )]
      [  XmlElement( ElementName = "NgpTppPrdID_Z"   )]
      public Guid gxTpr_Ngptppprdid_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdid_Z = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngptppprdid_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdid_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdid_Z = Guid.Empty;
         SetDirty("Ngptppprdid_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpTppPrdCodigo_Z" )]
      [  XmlElement( ElementName = "NgpTppPrdCodigo_Z"   )]
      public string gxTpr_Ngptppprdcodigo_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdcodigo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdcodigo_Z = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngptppprdcodigo_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdcodigo_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdcodigo_Z = "";
         SetDirty("Ngptppprdcodigo_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdcodigo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpTppPrdNome_Z" )]
      [  XmlElement( ElementName = "NgpTppPrdNome_Z"   )]
      public string gxTpr_Ngptppprdnome_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdnome_Z = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngptppprdnome_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdnome_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdnome_Z = "";
         SetDirty("Ngptppprdnome_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpTppPrdTipoID_Z" )]
      [  XmlElement( ElementName = "NgpTppPrdTipoID_Z"   )]
      public int gxTpr_Ngptppprdtipoid_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdtipoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdtipoid_Z = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngptppprdtipoid_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdtipoid_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdtipoid_Z = 0;
         SetDirty("Ngptppprdtipoid_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdtipoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpTppPrdAtivo_Z" )]
      [  XmlElement( ElementName = "NgpTppPrdAtivo_Z"   )]
      public bool gxTpr_Ngptppprdativo_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdativo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdativo_Z = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngptppprdativo_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdativo_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdativo_Z = false;
         SetDirty("Ngptppprdativo_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpTpp1Preco_Z" )]
      [  XmlElement( ElementName = "NgpTpp1Preco_Z"   )]
      public decimal gxTpr_Ngptpp1preco_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngptpp1preco_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptpp1preco_Z = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngptpp1preco_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngptpp1preco_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngptpp1preco_Z = 0;
         SetDirty("Ngptpp1preco_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngptpp1preco_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpPreco_Z" )]
      [  XmlElement( ElementName = "NgpPreco_Z"   )]
      public decimal gxTpr_Ngppreco_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngppreco_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngppreco_Z = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngppreco_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngppreco_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngppreco_Z = 0;
         SetDirty("Ngppreco_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngppreco_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpQtde_Z" )]
      [  XmlElement( ElementName = "NgpQtde_Z"   )]
      public int gxTpr_Ngpqtde_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpqtde_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpqtde_Z = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpqtde_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpqtde_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpqtde_Z = 0;
         SetDirty("Ngpqtde_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpqtde_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpTotal_Z" )]
      [  XmlElement( ElementName = "NgpTotal_Z"   )]
      public decimal gxTpr_Ngptotal_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngptotal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngptotal_Z = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngptotal_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngptotal_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngptotal_Z = 0;
         SetDirty("Ngptotal_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngptotal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpObs_Z" )]
      [  XmlElement( ElementName = "NgpObs_Z"   )]
      public string gxTpr_Ngpobs_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpobs_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpobs_Z = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpobs_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpobs_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpobs_Z = "";
         SetDirty("Ngpobs_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpobs_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpDel_Z" )]
      [  XmlElement( ElementName = "NgpDel_Z"   )]
      public bool gxTpr_Ngpdel_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpdel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdel_Z = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpdel_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpdel_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdel_Z = false;
         SetDirty("Ngpdel_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpdel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpDelDataHora_Z" )]
      [  XmlElement( ElementName = "NgpDelDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Ngpdeldatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_Z = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngpdeldatahora_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_Z = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpdeldatahora_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Ngpdeldatahora_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpDelData_Z" )]
      [  XmlElement( ElementName = "NgpDelData_Z"  , IsNullable=true )]
      public string gxTpr_Ngpdeldata_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_Z = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngpdeldata_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_Z = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpdeldata_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Ngpdeldata_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpDelHora_Z" )]
      [  XmlElement( ElementName = "NgpDelHora_Z"  , IsNullable=true )]
      public string gxTpr_Ngpdelhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_Z = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngpdelhora_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_Z = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpdelhora_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Ngpdelhora_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpDelUsuId_Z" )]
      [  XmlElement( ElementName = "NgpDelUsuId_Z"   )]
      public string gxTpr_Ngpdelusuid_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_Z = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpdelusuid_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_Z = "";
         SetDirty("Ngpdelusuid_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpDelUsuNome_Z" )]
      [  XmlElement( ElementName = "NgpDelUsuNome_Z"   )]
      public string gxTpr_Ngpdelusunome_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_Z = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpdelusunome_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_Z = "";
         SetDirty("Ngpdelusunome_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpInsUsuID_N" )]
      [  XmlElement( ElementName = "NgpInsUsuID_N"   )]
      public short gxTpr_Ngpinsusuid_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_N = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpinsusuid_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_N = 0;
         SetDirty("Ngpinsusuid_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpInsUsuNome_N" )]
      [  XmlElement( ElementName = "NgpInsUsuNome_N"   )]
      public short gxTpr_Ngpinsusunome_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_N = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpinsusunome_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_N = 0;
         SetDirty("Ngpinsusunome_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpDelDataHora_N" )]
      [  XmlElement( ElementName = "NgpDelDataHora_N"   )]
      public short gxTpr_Ngpdeldatahora_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_N = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpdeldatahora_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_N = 0;
         SetDirty("Ngpdeldatahora_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpDelData_N" )]
      [  XmlElement( ElementName = "NgpDelData_N"   )]
      public short gxTpr_Ngpdeldata_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_N = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpdeldata_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_N = 0;
         SetDirty("Ngpdeldata_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpDelHora_N" )]
      [  XmlElement( ElementName = "NgpDelHora_N"   )]
      public short gxTpr_Ngpdelhora_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_N = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpdelhora_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_N = 0;
         SetDirty("Ngpdelhora_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpDelUsuId_N" )]
      [  XmlElement( ElementName = "NgpDelUsuId_N"   )]
      public short gxTpr_Ngpdelusuid_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_N = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpdelusuid_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_N = 0;
         SetDirty("Ngpdelusuid_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgpDelUsuNome_N" )]
      [  XmlElement( ElementName = "NgpDelUsuNome_N"   )]
      public short gxTpr_Ngpdelusunome_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_N = value;
            gxTv_SdtNegocioPJEstrutura_Item_Modified = 1;
            SetDirty("Ngpdelusunome_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_N = 0;
         SetDirty("Ngpdelusunome_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata = DateTime.MinValue;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid = "";
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome = "";
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppid = Guid.Empty;
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdid = Guid.Empty;
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdcodigo = "";
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdnome = "";
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdativo = true;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpqtde = 1;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpobs = "";
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid = "";
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome = "";
         gxTv_SdtNegocioPJEstrutura_Item_Mode = "";
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata_Z = DateTime.MinValue;
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_Z = "";
         gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_Z = "";
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppid_Z = Guid.Empty;
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdid_Z = Guid.Empty;
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdcodigo_Z = "";
         gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdnome_Z = "";
         gxTv_SdtNegocioPJEstrutura_Item_Ngpobs_Z = "";
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_Z = "";
         gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_Z = "";
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

      private short sdtIsNull ;
      private short gxTv_SdtNegocioPJEstrutura_Item_Modified ;
      private short gxTv_SdtNegocioPJEstrutura_Item_Initialized ;
      private short gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_N ;
      private short gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_N ;
      private short gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_N ;
      private short gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_N ;
      private short gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_N ;
      private short gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_N ;
      private short gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_N ;
      private int gxTv_SdtNegocioPJEstrutura_Item_Ngpitem ;
      private int gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdtipoid ;
      private int gxTv_SdtNegocioPJEstrutura_Item_Ngpqtde ;
      private int gxTv_SdtNegocioPJEstrutura_Item_Ngpitem_Z ;
      private int gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdtipoid_Z ;
      private int gxTv_SdtNegocioPJEstrutura_Item_Ngpqtde_Z ;
      private decimal gxTv_SdtNegocioPJEstrutura_Item_Ngptpp1preco ;
      private decimal gxTv_SdtNegocioPJEstrutura_Item_Ngppreco ;
      private decimal gxTv_SdtNegocioPJEstrutura_Item_Ngptotal ;
      private decimal gxTv_SdtNegocioPJEstrutura_Item_Ngptpp1preco_Z ;
      private decimal gxTv_SdtNegocioPJEstrutura_Item_Ngppreco_Z ;
      private decimal gxTv_SdtNegocioPJEstrutura_Item_Ngptotal_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid ;
      private string gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid ;
      private string gxTv_SdtNegocioPJEstrutura_Item_Mode ;
      private string gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusuid_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusuid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Item_Ngpinshora_Z ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdatahora_Z ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldatahora_Z ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Item_Ngpdeldata_Z ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Item_Ngpdelhora_Z ;
      private DateTime datetime_STZ ;
      private DateTime datetimemil_STZ ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Item_Ngpinsdata_Z ;
      private bool gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdativo ;
      private bool gxTv_SdtNegocioPJEstrutura_Item_Ngpdel ;
      private bool gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdativo_Z ;
      private bool gxTv_SdtNegocioPJEstrutura_Item_Ngpdel_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome ;
      private string gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdcodigo ;
      private string gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdnome ;
      private string gxTv_SdtNegocioPJEstrutura_Item_Ngpobs ;
      private string gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome ;
      private string gxTv_SdtNegocioPJEstrutura_Item_Ngpinsusunome_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdcodigo_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdnome_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Item_Ngpobs_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Item_Ngpdelusunome_Z ;
      private Guid gxTv_SdtNegocioPJEstrutura_Item_Ngptppid ;
      private Guid gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdid ;
      private Guid gxTv_SdtNegocioPJEstrutura_Item_Ngptppid_Z ;
      private Guid gxTv_SdtNegocioPJEstrutura_Item_Ngptppprdid_Z ;
   }

   [DataContract(Name = @"core\NegocioPJEstrutura.Item", Namespace = "agl_tresorygroup")]
   public class SdtNegocioPJEstrutura_Item_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtNegocioPJEstrutura_Item>
   {
      public SdtNegocioPJEstrutura_Item_RESTInterface( ) : base()
      {
      }

      public SdtNegocioPJEstrutura_Item_RESTInterface( GeneXus.Programs.core.SdtNegocioPJEstrutura_Item psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NgpItem" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Ngpitem
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Ngpitem), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Ngpitem = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "NgpInsData" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Ngpinsdata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Ngpinsdata) ;
         }

         set {
            sdt.gxTpr_Ngpinsdata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "NgpInsHora" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Ngpinshora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Ngpinshora) ;
         }

         set {
            GXt_dtime3 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Ngpinshora = GXt_dtime3;
         }

      }

      [DataMember( Name = "NgpInsDataHora" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Ngpinsdatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Ngpinsdatahora) ;
         }

         set {
            sdt.gxTpr_Ngpinsdatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "NgpInsUsuID" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Ngpinsusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Ngpinsusuid) ;
         }

         set {
            sdt.gxTpr_Ngpinsusuid = value;
         }

      }

      [DataMember( Name = "NgpInsUsuNome" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Ngpinsusunome
      {
         get {
            return sdt.gxTpr_Ngpinsusunome ;
         }

         set {
            sdt.gxTpr_Ngpinsusunome = value;
         }

      }

      [DataMember( Name = "NgpTppID" , Order = 6 )]
      [GxSeudo()]
      public Guid gxTpr_Ngptppid
      {
         get {
            return sdt.gxTpr_Ngptppid ;
         }

         set {
            sdt.gxTpr_Ngptppid = value;
         }

      }

      [DataMember( Name = "NgpTppPrdID" , Order = 7 )]
      [GxSeudo()]
      public Guid gxTpr_Ngptppprdid
      {
         get {
            return sdt.gxTpr_Ngptppprdid ;
         }

         set {
            sdt.gxTpr_Ngptppprdid = value;
         }

      }

      [DataMember( Name = "NgpTppPrdCodigo" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Ngptppprdcodigo
      {
         get {
            return sdt.gxTpr_Ngptppprdcodigo ;
         }

         set {
            sdt.gxTpr_Ngptppprdcodigo = value;
         }

      }

      [DataMember( Name = "NgpTppPrdNome" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Ngptppprdnome
      {
         get {
            return sdt.gxTpr_Ngptppprdnome ;
         }

         set {
            sdt.gxTpr_Ngptppprdnome = value;
         }

      }

      [DataMember( Name = "NgpTppPrdTipoID" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Ngptppprdtipoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Ngptppprdtipoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Ngptppprdtipoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "NgpTppPrdAtivo" , Order = 11 )]
      [GxSeudo()]
      public bool gxTpr_Ngptppprdativo
      {
         get {
            return sdt.gxTpr_Ngptppprdativo ;
         }

         set {
            sdt.gxTpr_Ngptppprdativo = value;
         }

      }

      [DataMember( Name = "NgpTpp1Preco" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Ngptpp1preco
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Ngptpp1preco, 16, 2)) ;
         }

         set {
            sdt.gxTpr_Ngptpp1preco = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "NgpPreco" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Ngppreco
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Ngppreco, 16, 2)) ;
         }

         set {
            sdt.gxTpr_Ngppreco = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "NgpQtde" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Ngpqtde
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Ngpqtde), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Ngpqtde = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "NgpTotal" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Ngptotal
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Ngptotal, 16, 2)) ;
         }

         set {
            sdt.gxTpr_Ngptotal = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "NgpObs" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Ngpobs
      {
         get {
            return sdt.gxTpr_Ngpobs ;
         }

         set {
            sdt.gxTpr_Ngpobs = value;
         }

      }

      [DataMember( Name = "NgpDel" , Order = 17 )]
      [GxSeudo()]
      public bool gxTpr_Ngpdel
      {
         get {
            return sdt.gxTpr_Ngpdel ;
         }

         set {
            sdt.gxTpr_Ngpdel = value;
         }

      }

      [DataMember( Name = "NgpDelDataHora" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Ngpdeldatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Ngpdeldatahora) ;
         }

         set {
            sdt.gxTpr_Ngpdeldatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "NgpDelData" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Ngpdeldata
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Ngpdeldata) ;
         }

         set {
            sdt.gxTpr_Ngpdeldata = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "NgpDelHora" , Order = 20 )]
      [GxSeudo()]
      public string gxTpr_Ngpdelhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Ngpdelhora) ;
         }

         set {
            GXt_dtime3 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Ngpdelhora = GXt_dtime3;
         }

      }

      [DataMember( Name = "NgpDelUsuId" , Order = 21 )]
      [GxSeudo()]
      public string gxTpr_Ngpdelusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Ngpdelusuid) ;
         }

         set {
            sdt.gxTpr_Ngpdelusuid = value;
         }

      }

      [DataMember( Name = "NgpDelUsuNome" , Order = 22 )]
      [GxSeudo()]
      public string gxTpr_Ngpdelusunome
      {
         get {
            return sdt.gxTpr_Ngpdelusunome ;
         }

         set {
            sdt.gxTpr_Ngpdelusunome = value;
         }

      }

      public GeneXus.Programs.core.SdtNegocioPJEstrutura_Item sdt
      {
         get {
            return (GeneXus.Programs.core.SdtNegocioPJEstrutura_Item)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtNegocioPJEstrutura_Item() ;
         }
      }

      private DateTime GXt_dtime3 ;
   }

   [DataContract(Name = @"core\NegocioPJEstrutura.Item", Namespace = "agl_tresorygroup")]
   public class SdtNegocioPJEstrutura_Item_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtNegocioPJEstrutura_Item>
   {
      public SdtNegocioPJEstrutura_Item_RESTLInterface( ) : base()
      {
      }

      public SdtNegocioPJEstrutura_Item_RESTLInterface( GeneXus.Programs.core.SdtNegocioPJEstrutura_Item psdt ) : base(psdt)
      {
      }

      public GeneXus.Programs.core.SdtNegocioPJEstrutura_Item sdt
      {
         get {
            return (GeneXus.Programs.core.SdtNegocioPJEstrutura_Item)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtNegocioPJEstrutura_Item() ;
         }
      }

   }

}
