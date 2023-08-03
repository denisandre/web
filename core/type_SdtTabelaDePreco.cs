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
   [XmlRoot(ElementName = "TabelaDePreco" )]
   [XmlType(TypeName =  "TabelaDePreco" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class SdtTabelaDePreco : GxSilentTrnSdt
   {
      public SdtTabelaDePreco( )
      {
      }

      public SdtTabelaDePreco( IGxContext context )
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

      public void Load( Guid AV235TppID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV235TppID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TppID", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "core\\TabelaDePreco");
         metadata.Set("BT", "tb_tabeladepreco");
         metadata.Set("PK", "[ \"TppID\" ]");
         metadata.Set("PKAssigned", "[ \"TppID\" ]");
         metadata.Set("Levels", "[ \"Produto\" ]");
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
         state.Add("gxTpr_Tppid_Z");
         state.Add("gxTpr_Tppcodigo_Z");
         state.Add("gxTpr_Tppnome_Z");
         state.Add("gxTpr_Tppinsdata_Z_Nullable");
         state.Add("gxTpr_Tppinshora_Z_Nullable");
         state.Add("gxTpr_Tppinsdatahora_Z_Nullable");
         state.Add("gxTpr_Tppinsusuid_Z");
         state.Add("gxTpr_Tppinsusunome_Z");
         state.Add("gxTpr_Tppupddata_Z_Nullable");
         state.Add("gxTpr_Tppupdhora_Z_Nullable");
         state.Add("gxTpr_Tppupddatahora_Z_Nullable");
         state.Add("gxTpr_Tppupdusuid_Z");
         state.Add("gxTpr_Tppupdusunome_Z");
         state.Add("gxTpr_Tppativo_Z");
         state.Add("gxTpr_Tppdel_Z");
         state.Add("gxTpr_Tppdeldatahora_Z_Nullable");
         state.Add("gxTpr_Tppdeldata_Z_Nullable");
         state.Add("gxTpr_Tppdelhora_Z_Nullable");
         state.Add("gxTpr_Tppdelusuid_Z");
         state.Add("gxTpr_Tppdelusunome_Z");
         state.Add("gxTpr_Tppinsusuid_N");
         state.Add("gxTpr_Tppinsusunome_N");
         state.Add("gxTpr_Tppupddata_N");
         state.Add("gxTpr_Tppupdhora_N");
         state.Add("gxTpr_Tppupddatahora_N");
         state.Add("gxTpr_Tppupdusuid_N");
         state.Add("gxTpr_Tppupdusunome_N");
         state.Add("gxTpr_Tppativo_N");
         state.Add("gxTpr_Tppdeldatahora_N");
         state.Add("gxTpr_Tppdeldata_N");
         state.Add("gxTpr_Tppdelhora_N");
         state.Add("gxTpr_Tppdelusuid_N");
         state.Add("gxTpr_Tppdelusunome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.SdtTabelaDePreco sdt;
         sdt = (GeneXus.Programs.core.SdtTabelaDePreco)(source);
         gxTv_SdtTabelaDePreco_Tppid = sdt.gxTv_SdtTabelaDePreco_Tppid ;
         gxTv_SdtTabelaDePreco_Tppcodigo = sdt.gxTv_SdtTabelaDePreco_Tppcodigo ;
         gxTv_SdtTabelaDePreco_Tppnome = sdt.gxTv_SdtTabelaDePreco_Tppnome ;
         gxTv_SdtTabelaDePreco_Tppinsdata = sdt.gxTv_SdtTabelaDePreco_Tppinsdata ;
         gxTv_SdtTabelaDePreco_Tppinshora = sdt.gxTv_SdtTabelaDePreco_Tppinshora ;
         gxTv_SdtTabelaDePreco_Tppinsdatahora = sdt.gxTv_SdtTabelaDePreco_Tppinsdatahora ;
         gxTv_SdtTabelaDePreco_Tppinsusuid = sdt.gxTv_SdtTabelaDePreco_Tppinsusuid ;
         gxTv_SdtTabelaDePreco_Tppinsusunome = sdt.gxTv_SdtTabelaDePreco_Tppinsusunome ;
         gxTv_SdtTabelaDePreco_Tppupddata = sdt.gxTv_SdtTabelaDePreco_Tppupddata ;
         gxTv_SdtTabelaDePreco_Tppupdhora = sdt.gxTv_SdtTabelaDePreco_Tppupdhora ;
         gxTv_SdtTabelaDePreco_Tppupddatahora = sdt.gxTv_SdtTabelaDePreco_Tppupddatahora ;
         gxTv_SdtTabelaDePreco_Tppupdusuid = sdt.gxTv_SdtTabelaDePreco_Tppupdusuid ;
         gxTv_SdtTabelaDePreco_Tppupdusunome = sdt.gxTv_SdtTabelaDePreco_Tppupdusunome ;
         gxTv_SdtTabelaDePreco_Tppativo = sdt.gxTv_SdtTabelaDePreco_Tppativo ;
         gxTv_SdtTabelaDePreco_Tppdel = sdt.gxTv_SdtTabelaDePreco_Tppdel ;
         gxTv_SdtTabelaDePreco_Tppdeldatahora = sdt.gxTv_SdtTabelaDePreco_Tppdeldatahora ;
         gxTv_SdtTabelaDePreco_Tppdeldata = sdt.gxTv_SdtTabelaDePreco_Tppdeldata ;
         gxTv_SdtTabelaDePreco_Tppdelhora = sdt.gxTv_SdtTabelaDePreco_Tppdelhora ;
         gxTv_SdtTabelaDePreco_Tppdelusuid = sdt.gxTv_SdtTabelaDePreco_Tppdelusuid ;
         gxTv_SdtTabelaDePreco_Tppdelusunome = sdt.gxTv_SdtTabelaDePreco_Tppdelusunome ;
         gxTv_SdtTabelaDePreco_Produto = sdt.gxTv_SdtTabelaDePreco_Produto ;
         gxTv_SdtTabelaDePreco_Mode = sdt.gxTv_SdtTabelaDePreco_Mode ;
         gxTv_SdtTabelaDePreco_Initialized = sdt.gxTv_SdtTabelaDePreco_Initialized ;
         gxTv_SdtTabelaDePreco_Tppid_Z = sdt.gxTv_SdtTabelaDePreco_Tppid_Z ;
         gxTv_SdtTabelaDePreco_Tppcodigo_Z = sdt.gxTv_SdtTabelaDePreco_Tppcodigo_Z ;
         gxTv_SdtTabelaDePreco_Tppnome_Z = sdt.gxTv_SdtTabelaDePreco_Tppnome_Z ;
         gxTv_SdtTabelaDePreco_Tppinsdata_Z = sdt.gxTv_SdtTabelaDePreco_Tppinsdata_Z ;
         gxTv_SdtTabelaDePreco_Tppinshora_Z = sdt.gxTv_SdtTabelaDePreco_Tppinshora_Z ;
         gxTv_SdtTabelaDePreco_Tppinsdatahora_Z = sdt.gxTv_SdtTabelaDePreco_Tppinsdatahora_Z ;
         gxTv_SdtTabelaDePreco_Tppinsusuid_Z = sdt.gxTv_SdtTabelaDePreco_Tppinsusuid_Z ;
         gxTv_SdtTabelaDePreco_Tppinsusunome_Z = sdt.gxTv_SdtTabelaDePreco_Tppinsusunome_Z ;
         gxTv_SdtTabelaDePreco_Tppupddata_Z = sdt.gxTv_SdtTabelaDePreco_Tppupddata_Z ;
         gxTv_SdtTabelaDePreco_Tppupdhora_Z = sdt.gxTv_SdtTabelaDePreco_Tppupdhora_Z ;
         gxTv_SdtTabelaDePreco_Tppupddatahora_Z = sdt.gxTv_SdtTabelaDePreco_Tppupddatahora_Z ;
         gxTv_SdtTabelaDePreco_Tppupdusuid_Z = sdt.gxTv_SdtTabelaDePreco_Tppupdusuid_Z ;
         gxTv_SdtTabelaDePreco_Tppupdusunome_Z = sdt.gxTv_SdtTabelaDePreco_Tppupdusunome_Z ;
         gxTv_SdtTabelaDePreco_Tppativo_Z = sdt.gxTv_SdtTabelaDePreco_Tppativo_Z ;
         gxTv_SdtTabelaDePreco_Tppdel_Z = sdt.gxTv_SdtTabelaDePreco_Tppdel_Z ;
         gxTv_SdtTabelaDePreco_Tppdeldatahora_Z = sdt.gxTv_SdtTabelaDePreco_Tppdeldatahora_Z ;
         gxTv_SdtTabelaDePreco_Tppdeldata_Z = sdt.gxTv_SdtTabelaDePreco_Tppdeldata_Z ;
         gxTv_SdtTabelaDePreco_Tppdelhora_Z = sdt.gxTv_SdtTabelaDePreco_Tppdelhora_Z ;
         gxTv_SdtTabelaDePreco_Tppdelusuid_Z = sdt.gxTv_SdtTabelaDePreco_Tppdelusuid_Z ;
         gxTv_SdtTabelaDePreco_Tppdelusunome_Z = sdt.gxTv_SdtTabelaDePreco_Tppdelusunome_Z ;
         gxTv_SdtTabelaDePreco_Tppinsusuid_N = sdt.gxTv_SdtTabelaDePreco_Tppinsusuid_N ;
         gxTv_SdtTabelaDePreco_Tppinsusunome_N = sdt.gxTv_SdtTabelaDePreco_Tppinsusunome_N ;
         gxTv_SdtTabelaDePreco_Tppupddata_N = sdt.gxTv_SdtTabelaDePreco_Tppupddata_N ;
         gxTv_SdtTabelaDePreco_Tppupdhora_N = sdt.gxTv_SdtTabelaDePreco_Tppupdhora_N ;
         gxTv_SdtTabelaDePreco_Tppupddatahora_N = sdt.gxTv_SdtTabelaDePreco_Tppupddatahora_N ;
         gxTv_SdtTabelaDePreco_Tppupdusuid_N = sdt.gxTv_SdtTabelaDePreco_Tppupdusuid_N ;
         gxTv_SdtTabelaDePreco_Tppupdusunome_N = sdt.gxTv_SdtTabelaDePreco_Tppupdusunome_N ;
         gxTv_SdtTabelaDePreco_Tppativo_N = sdt.gxTv_SdtTabelaDePreco_Tppativo_N ;
         gxTv_SdtTabelaDePreco_Tppdeldatahora_N = sdt.gxTv_SdtTabelaDePreco_Tppdeldatahora_N ;
         gxTv_SdtTabelaDePreco_Tppdeldata_N = sdt.gxTv_SdtTabelaDePreco_Tppdeldata_N ;
         gxTv_SdtTabelaDePreco_Tppdelhora_N = sdt.gxTv_SdtTabelaDePreco_Tppdelhora_N ;
         gxTv_SdtTabelaDePreco_Tppdelusuid_N = sdt.gxTv_SdtTabelaDePreco_Tppdelusuid_N ;
         gxTv_SdtTabelaDePreco_Tppdelusunome_N = sdt.gxTv_SdtTabelaDePreco_Tppdelusunome_N ;
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
         AddObjectProperty("TppID", gxTv_SdtTabelaDePreco_Tppid, false, includeNonInitialized);
         AddObjectProperty("TppCodigo", gxTv_SdtTabelaDePreco_Tppcodigo, false, includeNonInitialized);
         AddObjectProperty("TppNome", gxTv_SdtTabelaDePreco_Tppnome, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTabelaDePreco_Tppinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTabelaDePreco_Tppinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTabelaDePreco_Tppinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("TppInsData", sDateCnv, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTabelaDePreco_Tppinshora;
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
         AddObjectProperty("TppInsHora", sDateCnv, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTabelaDePreco_Tppinsdatahora;
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
         AddObjectProperty("TppInsDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TppInsUsuID", gxTv_SdtTabelaDePreco_Tppinsusuid, false, includeNonInitialized);
         AddObjectProperty("TppInsUsuID_N", gxTv_SdtTabelaDePreco_Tppinsusuid_N, false, includeNonInitialized);
         AddObjectProperty("TppInsUsuNome", gxTv_SdtTabelaDePreco_Tppinsusunome, false, includeNonInitialized);
         AddObjectProperty("TppInsUsuNome_N", gxTv_SdtTabelaDePreco_Tppinsusunome_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTabelaDePreco_Tppupddata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTabelaDePreco_Tppupddata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTabelaDePreco_Tppupddata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("TppUpdData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TppUpdData_N", gxTv_SdtTabelaDePreco_Tppupddata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTabelaDePreco_Tppupdhora;
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
         AddObjectProperty("TppUpdHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TppUpdHora_N", gxTv_SdtTabelaDePreco_Tppupdhora_N, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtTabelaDePreco_Tppupddatahora;
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
         AddObjectProperty("TppUpdDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TppUpdDataHora_N", gxTv_SdtTabelaDePreco_Tppupddatahora_N, false, includeNonInitialized);
         AddObjectProperty("TppUpdUsuID", gxTv_SdtTabelaDePreco_Tppupdusuid, false, includeNonInitialized);
         AddObjectProperty("TppUpdUsuID_N", gxTv_SdtTabelaDePreco_Tppupdusuid_N, false, includeNonInitialized);
         AddObjectProperty("TppUpdUsuNome", gxTv_SdtTabelaDePreco_Tppupdusunome, false, includeNonInitialized);
         AddObjectProperty("TppUpdUsuNome_N", gxTv_SdtTabelaDePreco_Tppupdusunome_N, false, includeNonInitialized);
         AddObjectProperty("TppAtivo", gxTv_SdtTabelaDePreco_Tppativo, false, includeNonInitialized);
         AddObjectProperty("TppAtivo_N", gxTv_SdtTabelaDePreco_Tppativo_N, false, includeNonInitialized);
         AddObjectProperty("TppDel", gxTv_SdtTabelaDePreco_Tppdel, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtTabelaDePreco_Tppdeldatahora;
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
         AddObjectProperty("TppDelDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TppDelDataHora_N", gxTv_SdtTabelaDePreco_Tppdeldatahora_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTabelaDePreco_Tppdeldata;
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
         AddObjectProperty("TppDelData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TppDelData_N", gxTv_SdtTabelaDePreco_Tppdeldata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTabelaDePreco_Tppdelhora;
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
         AddObjectProperty("TppDelHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TppDelHora_N", gxTv_SdtTabelaDePreco_Tppdelhora_N, false, includeNonInitialized);
         AddObjectProperty("TppDelUsuId", gxTv_SdtTabelaDePreco_Tppdelusuid, false, includeNonInitialized);
         AddObjectProperty("TppDelUsuId_N", gxTv_SdtTabelaDePreco_Tppdelusuid_N, false, includeNonInitialized);
         AddObjectProperty("TppDelUsuNome", gxTv_SdtTabelaDePreco_Tppdelusunome, false, includeNonInitialized);
         AddObjectProperty("TppDelUsuNome_N", gxTv_SdtTabelaDePreco_Tppdelusunome_N, false, includeNonInitialized);
         if ( gxTv_SdtTabelaDePreco_Produto != null )
         {
            AddObjectProperty("Produto", gxTv_SdtTabelaDePreco_Produto, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTabelaDePreco_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTabelaDePreco_Initialized, false, includeNonInitialized);
            AddObjectProperty("TppID_Z", gxTv_SdtTabelaDePreco_Tppid_Z, false, includeNonInitialized);
            AddObjectProperty("TppCodigo_Z", gxTv_SdtTabelaDePreco_Tppcodigo_Z, false, includeNonInitialized);
            AddObjectProperty("TppNome_Z", gxTv_SdtTabelaDePreco_Tppnome_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTabelaDePreco_Tppinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTabelaDePreco_Tppinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTabelaDePreco_Tppinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("TppInsData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTabelaDePreco_Tppinshora_Z;
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
            AddObjectProperty("TppInsHora_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTabelaDePreco_Tppinsdatahora_Z;
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
            AddObjectProperty("TppInsDataHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("TppInsUsuID_Z", gxTv_SdtTabelaDePreco_Tppinsusuid_Z, false, includeNonInitialized);
            AddObjectProperty("TppInsUsuNome_Z", gxTv_SdtTabelaDePreco_Tppinsusunome_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTabelaDePreco_Tppupddata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTabelaDePreco_Tppupddata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTabelaDePreco_Tppupddata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("TppUpdData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTabelaDePreco_Tppupdhora_Z;
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
            AddObjectProperty("TppUpdHora_Z", sDateCnv, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtTabelaDePreco_Tppupddatahora_Z;
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
            AddObjectProperty("TppUpdDataHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("TppUpdUsuID_Z", gxTv_SdtTabelaDePreco_Tppupdusuid_Z, false, includeNonInitialized);
            AddObjectProperty("TppUpdUsuNome_Z", gxTv_SdtTabelaDePreco_Tppupdusunome_Z, false, includeNonInitialized);
            AddObjectProperty("TppAtivo_Z", gxTv_SdtTabelaDePreco_Tppativo_Z, false, includeNonInitialized);
            AddObjectProperty("TppDel_Z", gxTv_SdtTabelaDePreco_Tppdel_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtTabelaDePreco_Tppdeldatahora_Z;
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
            AddObjectProperty("TppDelDataHora_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTabelaDePreco_Tppdeldata_Z;
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
            AddObjectProperty("TppDelData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTabelaDePreco_Tppdelhora_Z;
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
            AddObjectProperty("TppDelHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("TppDelUsuId_Z", gxTv_SdtTabelaDePreco_Tppdelusuid_Z, false, includeNonInitialized);
            AddObjectProperty("TppDelUsuNome_Z", gxTv_SdtTabelaDePreco_Tppdelusunome_Z, false, includeNonInitialized);
            AddObjectProperty("TppInsUsuID_N", gxTv_SdtTabelaDePreco_Tppinsusuid_N, false, includeNonInitialized);
            AddObjectProperty("TppInsUsuNome_N", gxTv_SdtTabelaDePreco_Tppinsusunome_N, false, includeNonInitialized);
            AddObjectProperty("TppUpdData_N", gxTv_SdtTabelaDePreco_Tppupddata_N, false, includeNonInitialized);
            AddObjectProperty("TppUpdHora_N", gxTv_SdtTabelaDePreco_Tppupdhora_N, false, includeNonInitialized);
            AddObjectProperty("TppUpdDataHora_N", gxTv_SdtTabelaDePreco_Tppupddatahora_N, false, includeNonInitialized);
            AddObjectProperty("TppUpdUsuID_N", gxTv_SdtTabelaDePreco_Tppupdusuid_N, false, includeNonInitialized);
            AddObjectProperty("TppUpdUsuNome_N", gxTv_SdtTabelaDePreco_Tppupdusunome_N, false, includeNonInitialized);
            AddObjectProperty("TppAtivo_N", gxTv_SdtTabelaDePreco_Tppativo_N, false, includeNonInitialized);
            AddObjectProperty("TppDelDataHora_N", gxTv_SdtTabelaDePreco_Tppdeldatahora_N, false, includeNonInitialized);
            AddObjectProperty("TppDelData_N", gxTv_SdtTabelaDePreco_Tppdeldata_N, false, includeNonInitialized);
            AddObjectProperty("TppDelHora_N", gxTv_SdtTabelaDePreco_Tppdelhora_N, false, includeNonInitialized);
            AddObjectProperty("TppDelUsuId_N", gxTv_SdtTabelaDePreco_Tppdelusuid_N, false, includeNonInitialized);
            AddObjectProperty("TppDelUsuNome_N", gxTv_SdtTabelaDePreco_Tppdelusunome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.SdtTabelaDePreco sdt )
      {
         if ( sdt.IsDirty("TppID") )
         {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppid = sdt.gxTv_SdtTabelaDePreco_Tppid ;
         }
         if ( sdt.IsDirty("TppCodigo") )
         {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppcodigo = sdt.gxTv_SdtTabelaDePreco_Tppcodigo ;
         }
         if ( sdt.IsDirty("TppNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppnome = sdt.gxTv_SdtTabelaDePreco_Tppnome ;
         }
         if ( sdt.IsDirty("TppInsData") )
         {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppinsdata = sdt.gxTv_SdtTabelaDePreco_Tppinsdata ;
         }
         if ( sdt.IsDirty("TppInsHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppinshora = sdt.gxTv_SdtTabelaDePreco_Tppinshora ;
         }
         if ( sdt.IsDirty("TppInsDataHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppinsdatahora = sdt.gxTv_SdtTabelaDePreco_Tppinsdatahora ;
         }
         if ( sdt.IsDirty("TppInsUsuID") )
         {
            gxTv_SdtTabelaDePreco_Tppinsusuid_N = (short)(sdt.gxTv_SdtTabelaDePreco_Tppinsusuid_N);
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppinsusuid = sdt.gxTv_SdtTabelaDePreco_Tppinsusuid ;
         }
         if ( sdt.IsDirty("TppInsUsuNome") )
         {
            gxTv_SdtTabelaDePreco_Tppinsusunome_N = (short)(sdt.gxTv_SdtTabelaDePreco_Tppinsusunome_N);
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppinsusunome = sdt.gxTv_SdtTabelaDePreco_Tppinsusunome ;
         }
         if ( sdt.IsDirty("TppUpdData") )
         {
            gxTv_SdtTabelaDePreco_Tppupddata_N = (short)(sdt.gxTv_SdtTabelaDePreco_Tppupddata_N);
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppupddata = sdt.gxTv_SdtTabelaDePreco_Tppupddata ;
         }
         if ( sdt.IsDirty("TppUpdHora") )
         {
            gxTv_SdtTabelaDePreco_Tppupdhora_N = (short)(sdt.gxTv_SdtTabelaDePreco_Tppupdhora_N);
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppupdhora = sdt.gxTv_SdtTabelaDePreco_Tppupdhora ;
         }
         if ( sdt.IsDirty("TppUpdDataHora") )
         {
            gxTv_SdtTabelaDePreco_Tppupddatahora_N = (short)(sdt.gxTv_SdtTabelaDePreco_Tppupddatahora_N);
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppupddatahora = sdt.gxTv_SdtTabelaDePreco_Tppupddatahora ;
         }
         if ( sdt.IsDirty("TppUpdUsuID") )
         {
            gxTv_SdtTabelaDePreco_Tppupdusuid_N = (short)(sdt.gxTv_SdtTabelaDePreco_Tppupdusuid_N);
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppupdusuid = sdt.gxTv_SdtTabelaDePreco_Tppupdusuid ;
         }
         if ( sdt.IsDirty("TppUpdUsuNome") )
         {
            gxTv_SdtTabelaDePreco_Tppupdusunome_N = (short)(sdt.gxTv_SdtTabelaDePreco_Tppupdusunome_N);
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppupdusunome = sdt.gxTv_SdtTabelaDePreco_Tppupdusunome ;
         }
         if ( sdt.IsDirty("TppAtivo") )
         {
            gxTv_SdtTabelaDePreco_Tppativo_N = (short)(sdt.gxTv_SdtTabelaDePreco_Tppativo_N);
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppativo = sdt.gxTv_SdtTabelaDePreco_Tppativo ;
         }
         if ( sdt.IsDirty("TppDel") )
         {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppdel = sdt.gxTv_SdtTabelaDePreco_Tppdel ;
         }
         if ( sdt.IsDirty("TppDelDataHora") )
         {
            gxTv_SdtTabelaDePreco_Tppdeldatahora_N = (short)(sdt.gxTv_SdtTabelaDePreco_Tppdeldatahora_N);
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppdeldatahora = sdt.gxTv_SdtTabelaDePreco_Tppdeldatahora ;
         }
         if ( sdt.IsDirty("TppDelData") )
         {
            gxTv_SdtTabelaDePreco_Tppdeldata_N = (short)(sdt.gxTv_SdtTabelaDePreco_Tppdeldata_N);
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppdeldata = sdt.gxTv_SdtTabelaDePreco_Tppdeldata ;
         }
         if ( sdt.IsDirty("TppDelHora") )
         {
            gxTv_SdtTabelaDePreco_Tppdelhora_N = (short)(sdt.gxTv_SdtTabelaDePreco_Tppdelhora_N);
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppdelhora = sdt.gxTv_SdtTabelaDePreco_Tppdelhora ;
         }
         if ( sdt.IsDirty("TppDelUsuId") )
         {
            gxTv_SdtTabelaDePreco_Tppdelusuid_N = (short)(sdt.gxTv_SdtTabelaDePreco_Tppdelusuid_N);
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppdelusuid = sdt.gxTv_SdtTabelaDePreco_Tppdelusuid ;
         }
         if ( sdt.IsDirty("TppDelUsuNome") )
         {
            gxTv_SdtTabelaDePreco_Tppdelusunome_N = (short)(sdt.gxTv_SdtTabelaDePreco_Tppdelusunome_N);
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppdelusunome = sdt.gxTv_SdtTabelaDePreco_Tppdelusunome ;
         }
         if ( gxTv_SdtTabelaDePreco_Produto != null )
         {
            GXBCLevelCollection<GeneXus.Programs.core.SdtTabelaDePreco_Produto> newCollectionProduto = sdt.gxTpr_Produto;
            GeneXus.Programs.core.SdtTabelaDePreco_Produto currItemProduto;
            GeneXus.Programs.core.SdtTabelaDePreco_Produto newItemProduto;
            short idx = 1;
            while ( idx <= newCollectionProduto.Count )
            {
               newItemProduto = ((GeneXus.Programs.core.SdtTabelaDePreco_Produto)newCollectionProduto.Item(idx));
               currItemProduto = gxTv_SdtTabelaDePreco_Produto.GetByKey(newItemProduto.gxTpr_Prdid);
               if ( StringUtil.StrCmp(currItemProduto.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemProduto.UpdateDirties(newItemProduto);
                  if ( StringUtil.StrCmp(newItemProduto.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemProduto.gxTpr_Mode = "DLT";
                  }
                  currItemProduto.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtTabelaDePreco_Produto.Add(newItemProduto, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "TppID" )]
      [  XmlElement( ElementName = "TppID"   )]
      public Guid gxTpr_Tppid
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTabelaDePreco_Tppid != value )
            {
               gxTv_SdtTabelaDePreco_Mode = "INS";
               this.gxTv_SdtTabelaDePreco_Tppid_Z_SetNull( );
               this.gxTv_SdtTabelaDePreco_Tppcodigo_Z_SetNull( );
               this.gxTv_SdtTabelaDePreco_Tppnome_Z_SetNull( );
               this.gxTv_SdtTabelaDePreco_Tppinsdata_Z_SetNull( );
               this.gxTv_SdtTabelaDePreco_Tppinshora_Z_SetNull( );
               this.gxTv_SdtTabelaDePreco_Tppinsdatahora_Z_SetNull( );
               this.gxTv_SdtTabelaDePreco_Tppinsusuid_Z_SetNull( );
               this.gxTv_SdtTabelaDePreco_Tppinsusunome_Z_SetNull( );
               this.gxTv_SdtTabelaDePreco_Tppupddata_Z_SetNull( );
               this.gxTv_SdtTabelaDePreco_Tppupdhora_Z_SetNull( );
               this.gxTv_SdtTabelaDePreco_Tppupddatahora_Z_SetNull( );
               this.gxTv_SdtTabelaDePreco_Tppupdusuid_Z_SetNull( );
               this.gxTv_SdtTabelaDePreco_Tppupdusunome_Z_SetNull( );
               this.gxTv_SdtTabelaDePreco_Tppativo_Z_SetNull( );
               this.gxTv_SdtTabelaDePreco_Tppdel_Z_SetNull( );
               this.gxTv_SdtTabelaDePreco_Tppdeldatahora_Z_SetNull( );
               this.gxTv_SdtTabelaDePreco_Tppdeldata_Z_SetNull( );
               this.gxTv_SdtTabelaDePreco_Tppdelhora_Z_SetNull( );
               this.gxTv_SdtTabelaDePreco_Tppdelusuid_Z_SetNull( );
               this.gxTv_SdtTabelaDePreco_Tppdelusunome_Z_SetNull( );
               if ( gxTv_SdtTabelaDePreco_Produto != null )
               {
                  GXBCLevelCollection<GeneXus.Programs.core.SdtTabelaDePreco_Produto> collectionProduto = gxTv_SdtTabelaDePreco_Produto;
                  GeneXus.Programs.core.SdtTabelaDePreco_Produto currItemProduto;
                  short idx = 1;
                  while ( idx <= collectionProduto.Count )
                  {
                     currItemProduto = ((GeneXus.Programs.core.SdtTabelaDePreco_Produto)collectionProduto.Item(idx));
                     currItemProduto.gxTpr_Mode = "INS";
                     currItemProduto.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtTabelaDePreco_Tppid = value;
            SetDirty("Tppid");
         }

      }

      [  SoapElement( ElementName = "TppCodigo" )]
      [  XmlElement( ElementName = "TppCodigo"   )]
      public string gxTpr_Tppcodigo
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppcodigo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppcodigo = value;
            SetDirty("Tppcodigo");
         }

      }

      [  SoapElement( ElementName = "TppNome" )]
      [  XmlElement( ElementName = "TppNome"   )]
      public string gxTpr_Tppnome
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppnome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppnome = value;
            SetDirty("Tppnome");
         }

      }

      [  SoapElement( ElementName = "TppInsData" )]
      [  XmlElement( ElementName = "TppInsData"  , IsNullable=true )]
      public string gxTpr_Tppinsdata_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Tppinsdata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTabelaDePreco_Tppinsdata).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTabelaDePreco_Tppinsdata = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Tppinsdata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tppinsdata
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppinsdata ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppinsdata = value;
            SetDirty("Tppinsdata");
         }

      }

      [  SoapElement( ElementName = "TppInsHora" )]
      [  XmlElement( ElementName = "TppInsHora"  , IsNullable=true )]
      public string gxTpr_Tppinshora_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Tppinshora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTabelaDePreco_Tppinshora).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTabelaDePreco_Tppinshora = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Tppinshora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tppinshora
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppinshora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppinshora = value;
            SetDirty("Tppinshora");
         }

      }

      [  SoapElement( ElementName = "TppInsDataHora" )]
      [  XmlElement( ElementName = "TppInsDataHora"  , IsNullable=true )]
      public string gxTpr_Tppinsdatahora_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Tppinsdatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTabelaDePreco_Tppinsdatahora).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTabelaDePreco_Tppinsdatahora = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Tppinsdatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tppinsdatahora
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppinsdatahora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppinsdatahora = value;
            SetDirty("Tppinsdatahora");
         }

      }

      [  SoapElement( ElementName = "TppInsUsuID" )]
      [  XmlElement( ElementName = "TppInsUsuID"   )]
      public string gxTpr_Tppinsusuid
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppinsusuid ;
         }

         set {
            gxTv_SdtTabelaDePreco_Tppinsusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppinsusuid = value;
            SetDirty("Tppinsusuid");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppinsusuid_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppinsusuid_N = 1;
         gxTv_SdtTabelaDePreco_Tppinsusuid = "";
         SetDirty("Tppinsusuid");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppinsusuid_IsNull( )
      {
         return (gxTv_SdtTabelaDePreco_Tppinsusuid_N==1) ;
      }

      [  SoapElement( ElementName = "TppInsUsuNome" )]
      [  XmlElement( ElementName = "TppInsUsuNome"   )]
      public string gxTpr_Tppinsusunome
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppinsusunome ;
         }

         set {
            gxTv_SdtTabelaDePreco_Tppinsusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppinsusunome = value;
            SetDirty("Tppinsusunome");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppinsusunome_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppinsusunome_N = 1;
         gxTv_SdtTabelaDePreco_Tppinsusunome = "";
         SetDirty("Tppinsusunome");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppinsusunome_IsNull( )
      {
         return (gxTv_SdtTabelaDePreco_Tppinsusunome_N==1) ;
      }

      [  SoapElement( ElementName = "TppUpdData" )]
      [  XmlElement( ElementName = "TppUpdData"  , IsNullable=true )]
      public string gxTpr_Tppupddata_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Tppupddata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTabelaDePreco_Tppupddata).value ;
         }

         set {
            gxTv_SdtTabelaDePreco_Tppupddata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTabelaDePreco_Tppupddata = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Tppupddata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tppupddata
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppupddata ;
         }

         set {
            gxTv_SdtTabelaDePreco_Tppupddata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppupddata = value;
            SetDirty("Tppupddata");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppupddata_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppupddata_N = 1;
         gxTv_SdtTabelaDePreco_Tppupddata = (DateTime)(DateTime.MinValue);
         SetDirty("Tppupddata");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppupddata_IsNull( )
      {
         return (gxTv_SdtTabelaDePreco_Tppupddata_N==1) ;
      }

      [  SoapElement( ElementName = "TppUpdHora" )]
      [  XmlElement( ElementName = "TppUpdHora"  , IsNullable=true )]
      public string gxTpr_Tppupdhora_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Tppupdhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTabelaDePreco_Tppupdhora).value ;
         }

         set {
            gxTv_SdtTabelaDePreco_Tppupdhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTabelaDePreco_Tppupdhora = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Tppupdhora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tppupdhora
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppupdhora ;
         }

         set {
            gxTv_SdtTabelaDePreco_Tppupdhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppupdhora = value;
            SetDirty("Tppupdhora");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppupdhora_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppupdhora_N = 1;
         gxTv_SdtTabelaDePreco_Tppupdhora = (DateTime)(DateTime.MinValue);
         SetDirty("Tppupdhora");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppupdhora_IsNull( )
      {
         return (gxTv_SdtTabelaDePreco_Tppupdhora_N==1) ;
      }

      [  SoapElement( ElementName = "TppUpdDataHora" )]
      [  XmlElement( ElementName = "TppUpdDataHora"  , IsNullable=true )]
      public string gxTpr_Tppupddatahora_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Tppupddatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTabelaDePreco_Tppupddatahora, null, true).value ;
         }

         set {
            gxTv_SdtTabelaDePreco_Tppupddatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTabelaDePreco_Tppupddatahora = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Tppupddatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tppupddatahora
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppupddatahora ;
         }

         set {
            gxTv_SdtTabelaDePreco_Tppupddatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppupddatahora = value;
            SetDirty("Tppupddatahora");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppupddatahora_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppupddatahora_N = 1;
         gxTv_SdtTabelaDePreco_Tppupddatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Tppupddatahora");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppupddatahora_IsNull( )
      {
         return (gxTv_SdtTabelaDePreco_Tppupddatahora_N==1) ;
      }

      [  SoapElement( ElementName = "TppUpdUsuID" )]
      [  XmlElement( ElementName = "TppUpdUsuID"   )]
      public string gxTpr_Tppupdusuid
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppupdusuid ;
         }

         set {
            gxTv_SdtTabelaDePreco_Tppupdusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppupdusuid = value;
            SetDirty("Tppupdusuid");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppupdusuid_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppupdusuid_N = 1;
         gxTv_SdtTabelaDePreco_Tppupdusuid = "";
         SetDirty("Tppupdusuid");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppupdusuid_IsNull( )
      {
         return (gxTv_SdtTabelaDePreco_Tppupdusuid_N==1) ;
      }

      [  SoapElement( ElementName = "TppUpdUsuNome" )]
      [  XmlElement( ElementName = "TppUpdUsuNome"   )]
      public string gxTpr_Tppupdusunome
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppupdusunome ;
         }

         set {
            gxTv_SdtTabelaDePreco_Tppupdusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppupdusunome = value;
            SetDirty("Tppupdusunome");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppupdusunome_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppupdusunome_N = 1;
         gxTv_SdtTabelaDePreco_Tppupdusunome = "";
         SetDirty("Tppupdusunome");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppupdusunome_IsNull( )
      {
         return (gxTv_SdtTabelaDePreco_Tppupdusunome_N==1) ;
      }

      [  SoapElement( ElementName = "TppAtivo" )]
      [  XmlElement( ElementName = "TppAtivo"   )]
      public bool gxTpr_Tppativo
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppativo ;
         }

         set {
            gxTv_SdtTabelaDePreco_Tppativo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppativo = value;
            SetDirty("Tppativo");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppativo_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppativo_N = 1;
         gxTv_SdtTabelaDePreco_Tppativo = false;
         SetDirty("Tppativo");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppativo_IsNull( )
      {
         return (gxTv_SdtTabelaDePreco_Tppativo_N==1) ;
      }

      [  SoapElement( ElementName = "TppDel" )]
      [  XmlElement( ElementName = "TppDel"   )]
      public bool gxTpr_Tppdel
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppdel ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppdel = value;
            SetDirty("Tppdel");
         }

      }

      [  SoapElement( ElementName = "TppDelDataHora" )]
      [  XmlElement( ElementName = "TppDelDataHora"  , IsNullable=true )]
      public string gxTpr_Tppdeldatahora_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Tppdeldatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTabelaDePreco_Tppdeldatahora, null, true).value ;
         }

         set {
            gxTv_SdtTabelaDePreco_Tppdeldatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTabelaDePreco_Tppdeldatahora = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Tppdeldatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tppdeldatahora
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppdeldatahora ;
         }

         set {
            gxTv_SdtTabelaDePreco_Tppdeldatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppdeldatahora = value;
            SetDirty("Tppdeldatahora");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppdeldatahora_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppdeldatahora_N = 1;
         gxTv_SdtTabelaDePreco_Tppdeldatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Tppdeldatahora");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppdeldatahora_IsNull( )
      {
         return (gxTv_SdtTabelaDePreco_Tppdeldatahora_N==1) ;
      }

      [  SoapElement( ElementName = "TppDelData" )]
      [  XmlElement( ElementName = "TppDelData"  , IsNullable=true )]
      public string gxTpr_Tppdeldata_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Tppdeldata == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTabelaDePreco_Tppdeldata).value ;
         }

         set {
            gxTv_SdtTabelaDePreco_Tppdeldata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTabelaDePreco_Tppdeldata = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Tppdeldata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tppdeldata
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppdeldata ;
         }

         set {
            gxTv_SdtTabelaDePreco_Tppdeldata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppdeldata = value;
            SetDirty("Tppdeldata");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppdeldata_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppdeldata_N = 1;
         gxTv_SdtTabelaDePreco_Tppdeldata = (DateTime)(DateTime.MinValue);
         SetDirty("Tppdeldata");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppdeldata_IsNull( )
      {
         return (gxTv_SdtTabelaDePreco_Tppdeldata_N==1) ;
      }

      [  SoapElement( ElementName = "TppDelHora" )]
      [  XmlElement( ElementName = "TppDelHora"  , IsNullable=true )]
      public string gxTpr_Tppdelhora_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Tppdelhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTabelaDePreco_Tppdelhora).value ;
         }

         set {
            gxTv_SdtTabelaDePreco_Tppdelhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTabelaDePreco_Tppdelhora = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Tppdelhora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tppdelhora
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppdelhora ;
         }

         set {
            gxTv_SdtTabelaDePreco_Tppdelhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppdelhora = value;
            SetDirty("Tppdelhora");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppdelhora_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppdelhora_N = 1;
         gxTv_SdtTabelaDePreco_Tppdelhora = (DateTime)(DateTime.MinValue);
         SetDirty("Tppdelhora");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppdelhora_IsNull( )
      {
         return (gxTv_SdtTabelaDePreco_Tppdelhora_N==1) ;
      }

      [  SoapElement( ElementName = "TppDelUsuId" )]
      [  XmlElement( ElementName = "TppDelUsuId"   )]
      public string gxTpr_Tppdelusuid
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppdelusuid ;
         }

         set {
            gxTv_SdtTabelaDePreco_Tppdelusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppdelusuid = value;
            SetDirty("Tppdelusuid");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppdelusuid_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppdelusuid_N = 1;
         gxTv_SdtTabelaDePreco_Tppdelusuid = "";
         SetDirty("Tppdelusuid");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppdelusuid_IsNull( )
      {
         return (gxTv_SdtTabelaDePreco_Tppdelusuid_N==1) ;
      }

      [  SoapElement( ElementName = "TppDelUsuNome" )]
      [  XmlElement( ElementName = "TppDelUsuNome"   )]
      public string gxTpr_Tppdelusunome
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppdelusunome ;
         }

         set {
            gxTv_SdtTabelaDePreco_Tppdelusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppdelusunome = value;
            SetDirty("Tppdelusunome");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppdelusunome_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppdelusunome_N = 1;
         gxTv_SdtTabelaDePreco_Tppdelusunome = "";
         SetDirty("Tppdelusunome");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppdelusunome_IsNull( )
      {
         return (gxTv_SdtTabelaDePreco_Tppdelusunome_N==1) ;
      }

      [  SoapElement( ElementName = "Produto" )]
      [  XmlArray( ElementName = "Produto"  )]
      [  XmlArrayItemAttribute( ElementName= "TabelaDePreco.Produto"  , IsNullable=false)]
      public GXBCLevelCollection<GeneXus.Programs.core.SdtTabelaDePreco_Produto> gxTpr_Produto_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Produto == null )
            {
               gxTv_SdtTabelaDePreco_Produto = new GXBCLevelCollection<GeneXus.Programs.core.SdtTabelaDePreco_Produto>( context, "TabelaDePreco.Produto", "agl_tresorygroup");
            }
            return gxTv_SdtTabelaDePreco_Produto ;
         }

         set {
            if ( gxTv_SdtTabelaDePreco_Produto == null )
            {
               gxTv_SdtTabelaDePreco_Produto = new GXBCLevelCollection<GeneXus.Programs.core.SdtTabelaDePreco_Produto>( context, "TabelaDePreco.Produto", "agl_tresorygroup");
            }
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<GeneXus.Programs.core.SdtTabelaDePreco_Produto> gxTpr_Produto
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Produto == null )
            {
               gxTv_SdtTabelaDePreco_Produto = new GXBCLevelCollection<GeneXus.Programs.core.SdtTabelaDePreco_Produto>( context, "TabelaDePreco.Produto", "agl_tresorygroup");
            }
            sdtIsNull = 0;
            return gxTv_SdtTabelaDePreco_Produto ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Produto = value;
            SetDirty("Produto");
         }

      }

      public void gxTv_SdtTabelaDePreco_Produto_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Produto = null;
         SetDirty("Produto");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Produto_IsNull( )
      {
         if ( gxTv_SdtTabelaDePreco_Produto == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTabelaDePreco_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTabelaDePreco_Mode_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTabelaDePreco_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTabelaDePreco_Initialized_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppID_Z" )]
      [  XmlElement( ElementName = "TppID_Z"   )]
      public Guid gxTpr_Tppid_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppid_Z = value;
            SetDirty("Tppid_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppid_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppid_Z = Guid.Empty;
         SetDirty("Tppid_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppCodigo_Z" )]
      [  XmlElement( ElementName = "TppCodigo_Z"   )]
      public string gxTpr_Tppcodigo_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppcodigo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppcodigo_Z = value;
            SetDirty("Tppcodigo_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppcodigo_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppcodigo_Z = "";
         SetDirty("Tppcodigo_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppcodigo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppNome_Z" )]
      [  XmlElement( ElementName = "TppNome_Z"   )]
      public string gxTpr_Tppnome_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppnome_Z = value;
            SetDirty("Tppnome_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppnome_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppnome_Z = "";
         SetDirty("Tppnome_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppInsData_Z" )]
      [  XmlElement( ElementName = "TppInsData_Z"  , IsNullable=true )]
      public string gxTpr_Tppinsdata_Z_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Tppinsdata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTabelaDePreco_Tppinsdata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTabelaDePreco_Tppinsdata_Z = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Tppinsdata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tppinsdata_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppinsdata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppinsdata_Z = value;
            SetDirty("Tppinsdata_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppinsdata_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppinsdata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Tppinsdata_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppinsdata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppInsHora_Z" )]
      [  XmlElement( ElementName = "TppInsHora_Z"  , IsNullable=true )]
      public string gxTpr_Tppinshora_Z_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Tppinshora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTabelaDePreco_Tppinshora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTabelaDePreco_Tppinshora_Z = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Tppinshora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tppinshora_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppinshora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppinshora_Z = value;
            SetDirty("Tppinshora_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppinshora_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppinshora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Tppinshora_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppinshora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppInsDataHora_Z" )]
      [  XmlElement( ElementName = "TppInsDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Tppinsdatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Tppinsdatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTabelaDePreco_Tppinsdatahora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTabelaDePreco_Tppinsdatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Tppinsdatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tppinsdatahora_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppinsdatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppinsdatahora_Z = value;
            SetDirty("Tppinsdatahora_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppinsdatahora_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppinsdatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Tppinsdatahora_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppinsdatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppInsUsuID_Z" )]
      [  XmlElement( ElementName = "TppInsUsuID_Z"   )]
      public string gxTpr_Tppinsusuid_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppinsusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppinsusuid_Z = value;
            SetDirty("Tppinsusuid_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppinsusuid_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppinsusuid_Z = "";
         SetDirty("Tppinsusuid_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppinsusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppInsUsuNome_Z" )]
      [  XmlElement( ElementName = "TppInsUsuNome_Z"   )]
      public string gxTpr_Tppinsusunome_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppinsusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppinsusunome_Z = value;
            SetDirty("Tppinsusunome_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppinsusunome_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppinsusunome_Z = "";
         SetDirty("Tppinsusunome_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppinsusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppUpdData_Z" )]
      [  XmlElement( ElementName = "TppUpdData_Z"  , IsNullable=true )]
      public string gxTpr_Tppupddata_Z_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Tppupddata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTabelaDePreco_Tppupddata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTabelaDePreco_Tppupddata_Z = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Tppupddata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tppupddata_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppupddata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppupddata_Z = value;
            SetDirty("Tppupddata_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppupddata_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppupddata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Tppupddata_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppupddata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppUpdHora_Z" )]
      [  XmlElement( ElementName = "TppUpdHora_Z"  , IsNullable=true )]
      public string gxTpr_Tppupdhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Tppupdhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTabelaDePreco_Tppupdhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTabelaDePreco_Tppupdhora_Z = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Tppupdhora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tppupdhora_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppupdhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppupdhora_Z = value;
            SetDirty("Tppupdhora_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppupdhora_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppupdhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Tppupdhora_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppupdhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppUpdDataHora_Z" )]
      [  XmlElement( ElementName = "TppUpdDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Tppupddatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Tppupddatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTabelaDePreco_Tppupddatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTabelaDePreco_Tppupddatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Tppupddatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tppupddatahora_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppupddatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppupddatahora_Z = value;
            SetDirty("Tppupddatahora_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppupddatahora_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppupddatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Tppupddatahora_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppupddatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppUpdUsuID_Z" )]
      [  XmlElement( ElementName = "TppUpdUsuID_Z"   )]
      public string gxTpr_Tppupdusuid_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppupdusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppupdusuid_Z = value;
            SetDirty("Tppupdusuid_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppupdusuid_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppupdusuid_Z = "";
         SetDirty("Tppupdusuid_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppupdusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppUpdUsuNome_Z" )]
      [  XmlElement( ElementName = "TppUpdUsuNome_Z"   )]
      public string gxTpr_Tppupdusunome_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppupdusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppupdusunome_Z = value;
            SetDirty("Tppupdusunome_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppupdusunome_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppupdusunome_Z = "";
         SetDirty("Tppupdusunome_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppupdusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppAtivo_Z" )]
      [  XmlElement( ElementName = "TppAtivo_Z"   )]
      public bool gxTpr_Tppativo_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppativo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppativo_Z = value;
            SetDirty("Tppativo_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppativo_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppativo_Z = false;
         SetDirty("Tppativo_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppDel_Z" )]
      [  XmlElement( ElementName = "TppDel_Z"   )]
      public bool gxTpr_Tppdel_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppdel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppdel_Z = value;
            SetDirty("Tppdel_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppdel_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppdel_Z = false;
         SetDirty("Tppdel_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppdel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppDelDataHora_Z" )]
      [  XmlElement( ElementName = "TppDelDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Tppdeldatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Tppdeldatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTabelaDePreco_Tppdeldatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTabelaDePreco_Tppdeldatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Tppdeldatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tppdeldatahora_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppdeldatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppdeldatahora_Z = value;
            SetDirty("Tppdeldatahora_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppdeldatahora_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppdeldatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Tppdeldatahora_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppdeldatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppDelData_Z" )]
      [  XmlElement( ElementName = "TppDelData_Z"  , IsNullable=true )]
      public string gxTpr_Tppdeldata_Z_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Tppdeldata_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTabelaDePreco_Tppdeldata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTabelaDePreco_Tppdeldata_Z = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Tppdeldata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tppdeldata_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppdeldata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppdeldata_Z = value;
            SetDirty("Tppdeldata_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppdeldata_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppdeldata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Tppdeldata_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppdeldata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppDelHora_Z" )]
      [  XmlElement( ElementName = "TppDelHora_Z"  , IsNullable=true )]
      public string gxTpr_Tppdelhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtTabelaDePreco_Tppdelhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTabelaDePreco_Tppdelhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTabelaDePreco_Tppdelhora_Z = DateTime.MinValue;
            else
               gxTv_SdtTabelaDePreco_Tppdelhora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tppdelhora_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppdelhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppdelhora_Z = value;
            SetDirty("Tppdelhora_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppdelhora_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppdelhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Tppdelhora_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppdelhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppDelUsuId_Z" )]
      [  XmlElement( ElementName = "TppDelUsuId_Z"   )]
      public string gxTpr_Tppdelusuid_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppdelusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppdelusuid_Z = value;
            SetDirty("Tppdelusuid_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppdelusuid_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppdelusuid_Z = "";
         SetDirty("Tppdelusuid_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppdelusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppDelUsuNome_Z" )]
      [  XmlElement( ElementName = "TppDelUsuNome_Z"   )]
      public string gxTpr_Tppdelusunome_Z
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppdelusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppdelusunome_Z = value;
            SetDirty("Tppdelusunome_Z");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppdelusunome_Z_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppdelusunome_Z = "";
         SetDirty("Tppdelusunome_Z");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppdelusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppInsUsuID_N" )]
      [  XmlElement( ElementName = "TppInsUsuID_N"   )]
      public short gxTpr_Tppinsusuid_N
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppinsusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppinsusuid_N = value;
            SetDirty("Tppinsusuid_N");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppinsusuid_N_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppinsusuid_N = 0;
         SetDirty("Tppinsusuid_N");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppinsusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppInsUsuNome_N" )]
      [  XmlElement( ElementName = "TppInsUsuNome_N"   )]
      public short gxTpr_Tppinsusunome_N
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppinsusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppinsusunome_N = value;
            SetDirty("Tppinsusunome_N");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppinsusunome_N_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppinsusunome_N = 0;
         SetDirty("Tppinsusunome_N");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppinsusunome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppUpdData_N" )]
      [  XmlElement( ElementName = "TppUpdData_N"   )]
      public short gxTpr_Tppupddata_N
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppupddata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppupddata_N = value;
            SetDirty("Tppupddata_N");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppupddata_N_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppupddata_N = 0;
         SetDirty("Tppupddata_N");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppupddata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppUpdHora_N" )]
      [  XmlElement( ElementName = "TppUpdHora_N"   )]
      public short gxTpr_Tppupdhora_N
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppupdhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppupdhora_N = value;
            SetDirty("Tppupdhora_N");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppupdhora_N_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppupdhora_N = 0;
         SetDirty("Tppupdhora_N");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppupdhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppUpdDataHora_N" )]
      [  XmlElement( ElementName = "TppUpdDataHora_N"   )]
      public short gxTpr_Tppupddatahora_N
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppupddatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppupddatahora_N = value;
            SetDirty("Tppupddatahora_N");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppupddatahora_N_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppupddatahora_N = 0;
         SetDirty("Tppupddatahora_N");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppupddatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppUpdUsuID_N" )]
      [  XmlElement( ElementName = "TppUpdUsuID_N"   )]
      public short gxTpr_Tppupdusuid_N
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppupdusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppupdusuid_N = value;
            SetDirty("Tppupdusuid_N");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppupdusuid_N_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppupdusuid_N = 0;
         SetDirty("Tppupdusuid_N");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppupdusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppUpdUsuNome_N" )]
      [  XmlElement( ElementName = "TppUpdUsuNome_N"   )]
      public short gxTpr_Tppupdusunome_N
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppupdusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppupdusunome_N = value;
            SetDirty("Tppupdusunome_N");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppupdusunome_N_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppupdusunome_N = 0;
         SetDirty("Tppupdusunome_N");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppupdusunome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppAtivo_N" )]
      [  XmlElement( ElementName = "TppAtivo_N"   )]
      public short gxTpr_Tppativo_N
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppativo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppativo_N = value;
            SetDirty("Tppativo_N");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppativo_N_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppativo_N = 0;
         SetDirty("Tppativo_N");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppativo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppDelDataHora_N" )]
      [  XmlElement( ElementName = "TppDelDataHora_N"   )]
      public short gxTpr_Tppdeldatahora_N
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppdeldatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppdeldatahora_N = value;
            SetDirty("Tppdeldatahora_N");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppdeldatahora_N_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppdeldatahora_N = 0;
         SetDirty("Tppdeldatahora_N");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppdeldatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppDelData_N" )]
      [  XmlElement( ElementName = "TppDelData_N"   )]
      public short gxTpr_Tppdeldata_N
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppdeldata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppdeldata_N = value;
            SetDirty("Tppdeldata_N");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppdeldata_N_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppdeldata_N = 0;
         SetDirty("Tppdeldata_N");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppdeldata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppDelHora_N" )]
      [  XmlElement( ElementName = "TppDelHora_N"   )]
      public short gxTpr_Tppdelhora_N
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppdelhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppdelhora_N = value;
            SetDirty("Tppdelhora_N");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppdelhora_N_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppdelhora_N = 0;
         SetDirty("Tppdelhora_N");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppdelhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppDelUsuId_N" )]
      [  XmlElement( ElementName = "TppDelUsuId_N"   )]
      public short gxTpr_Tppdelusuid_N
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppdelusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppdelusuid_N = value;
            SetDirty("Tppdelusuid_N");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppdelusuid_N_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppdelusuid_N = 0;
         SetDirty("Tppdelusuid_N");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppdelusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TppDelUsuNome_N" )]
      [  XmlElement( ElementName = "TppDelUsuNome_N"   )]
      public short gxTpr_Tppdelusunome_N
      {
         get {
            return gxTv_SdtTabelaDePreco_Tppdelusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTabelaDePreco_Tppdelusunome_N = value;
            SetDirty("Tppdelusunome_N");
         }

      }

      public void gxTv_SdtTabelaDePreco_Tppdelusunome_N_SetNull( )
      {
         gxTv_SdtTabelaDePreco_Tppdelusunome_N = 0;
         SetDirty("Tppdelusunome_N");
         return  ;
      }

      public bool gxTv_SdtTabelaDePreco_Tppdelusunome_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtTabelaDePreco_Tppid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTabelaDePreco_Tppcodigo = "";
         gxTv_SdtTabelaDePreco_Tppnome = "";
         gxTv_SdtTabelaDePreco_Tppinsdata = DateTime.MinValue;
         gxTv_SdtTabelaDePreco_Tppinshora = (DateTime)(DateTime.MinValue);
         gxTv_SdtTabelaDePreco_Tppinsdatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtTabelaDePreco_Tppinsusuid = "";
         gxTv_SdtTabelaDePreco_Tppinsusunome = "";
         gxTv_SdtTabelaDePreco_Tppupddata = DateTime.MinValue;
         gxTv_SdtTabelaDePreco_Tppupdhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtTabelaDePreco_Tppupddatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtTabelaDePreco_Tppupdusuid = "";
         gxTv_SdtTabelaDePreco_Tppupdusunome = "";
         gxTv_SdtTabelaDePreco_Tppativo = true;
         gxTv_SdtTabelaDePreco_Tppdeldatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtTabelaDePreco_Tppdeldata = (DateTime)(DateTime.MinValue);
         gxTv_SdtTabelaDePreco_Tppdelhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtTabelaDePreco_Tppdelusuid = "";
         gxTv_SdtTabelaDePreco_Tppdelusunome = "";
         gxTv_SdtTabelaDePreco_Mode = "";
         gxTv_SdtTabelaDePreco_Tppid_Z = Guid.Empty;
         gxTv_SdtTabelaDePreco_Tppcodigo_Z = "";
         gxTv_SdtTabelaDePreco_Tppnome_Z = "";
         gxTv_SdtTabelaDePreco_Tppinsdata_Z = DateTime.MinValue;
         gxTv_SdtTabelaDePreco_Tppinshora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTabelaDePreco_Tppinsdatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTabelaDePreco_Tppinsusuid_Z = "";
         gxTv_SdtTabelaDePreco_Tppinsusunome_Z = "";
         gxTv_SdtTabelaDePreco_Tppupddata_Z = DateTime.MinValue;
         gxTv_SdtTabelaDePreco_Tppupdhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTabelaDePreco_Tppupddatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTabelaDePreco_Tppupdusuid_Z = "";
         gxTv_SdtTabelaDePreco_Tppupdusunome_Z = "";
         gxTv_SdtTabelaDePreco_Tppdeldatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTabelaDePreco_Tppdeldata_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTabelaDePreco_Tppdelhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTabelaDePreco_Tppdelusuid_Z = "";
         gxTv_SdtTabelaDePreco_Tppdelusunome_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "core.tabeladepreco", "GeneXus.Programs.core.tabeladepreco_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTabelaDePreco_Initialized ;
      private short gxTv_SdtTabelaDePreco_Tppinsusuid_N ;
      private short gxTv_SdtTabelaDePreco_Tppinsusunome_N ;
      private short gxTv_SdtTabelaDePreco_Tppupddata_N ;
      private short gxTv_SdtTabelaDePreco_Tppupdhora_N ;
      private short gxTv_SdtTabelaDePreco_Tppupddatahora_N ;
      private short gxTv_SdtTabelaDePreco_Tppupdusuid_N ;
      private short gxTv_SdtTabelaDePreco_Tppupdusunome_N ;
      private short gxTv_SdtTabelaDePreco_Tppativo_N ;
      private short gxTv_SdtTabelaDePreco_Tppdeldatahora_N ;
      private short gxTv_SdtTabelaDePreco_Tppdeldata_N ;
      private short gxTv_SdtTabelaDePreco_Tppdelhora_N ;
      private short gxTv_SdtTabelaDePreco_Tppdelusuid_N ;
      private short gxTv_SdtTabelaDePreco_Tppdelusunome_N ;
      private string gxTv_SdtTabelaDePreco_Tppinsusuid ;
      private string gxTv_SdtTabelaDePreco_Tppupdusuid ;
      private string gxTv_SdtTabelaDePreco_Tppdelusuid ;
      private string gxTv_SdtTabelaDePreco_Mode ;
      private string gxTv_SdtTabelaDePreco_Tppinsusuid_Z ;
      private string gxTv_SdtTabelaDePreco_Tppupdusuid_Z ;
      private string gxTv_SdtTabelaDePreco_Tppdelusuid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtTabelaDePreco_Tppinshora ;
      private DateTime gxTv_SdtTabelaDePreco_Tppinsdatahora ;
      private DateTime gxTv_SdtTabelaDePreco_Tppupdhora ;
      private DateTime gxTv_SdtTabelaDePreco_Tppupddatahora ;
      private DateTime gxTv_SdtTabelaDePreco_Tppdeldatahora ;
      private DateTime gxTv_SdtTabelaDePreco_Tppdeldata ;
      private DateTime gxTv_SdtTabelaDePreco_Tppdelhora ;
      private DateTime gxTv_SdtTabelaDePreco_Tppinshora_Z ;
      private DateTime gxTv_SdtTabelaDePreco_Tppinsdatahora_Z ;
      private DateTime gxTv_SdtTabelaDePreco_Tppupdhora_Z ;
      private DateTime gxTv_SdtTabelaDePreco_Tppupddatahora_Z ;
      private DateTime gxTv_SdtTabelaDePreco_Tppdeldatahora_Z ;
      private DateTime gxTv_SdtTabelaDePreco_Tppdeldata_Z ;
      private DateTime gxTv_SdtTabelaDePreco_Tppdelhora_Z ;
      private DateTime datetime_STZ ;
      private DateTime datetimemil_STZ ;
      private DateTime gxTv_SdtTabelaDePreco_Tppinsdata ;
      private DateTime gxTv_SdtTabelaDePreco_Tppupddata ;
      private DateTime gxTv_SdtTabelaDePreco_Tppinsdata_Z ;
      private DateTime gxTv_SdtTabelaDePreco_Tppupddata_Z ;
      private bool gxTv_SdtTabelaDePreco_Tppativo ;
      private bool gxTv_SdtTabelaDePreco_Tppdel ;
      private bool gxTv_SdtTabelaDePreco_Tppativo_Z ;
      private bool gxTv_SdtTabelaDePreco_Tppdel_Z ;
      private string gxTv_SdtTabelaDePreco_Tppcodigo ;
      private string gxTv_SdtTabelaDePreco_Tppnome ;
      private string gxTv_SdtTabelaDePreco_Tppinsusunome ;
      private string gxTv_SdtTabelaDePreco_Tppupdusunome ;
      private string gxTv_SdtTabelaDePreco_Tppdelusunome ;
      private string gxTv_SdtTabelaDePreco_Tppcodigo_Z ;
      private string gxTv_SdtTabelaDePreco_Tppnome_Z ;
      private string gxTv_SdtTabelaDePreco_Tppinsusunome_Z ;
      private string gxTv_SdtTabelaDePreco_Tppupdusunome_Z ;
      private string gxTv_SdtTabelaDePreco_Tppdelusunome_Z ;
      private Guid gxTv_SdtTabelaDePreco_Tppid ;
      private Guid gxTv_SdtTabelaDePreco_Tppid_Z ;
      private GXBCLevelCollection<GeneXus.Programs.core.SdtTabelaDePreco_Produto> gxTv_SdtTabelaDePreco_Produto=null ;
   }

   [DataContract(Name = @"core\TabelaDePreco", Namespace = "agl_tresorygroup")]
   public class SdtTabelaDePreco_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtTabelaDePreco>
   {
      public SdtTabelaDePreco_RESTInterface( ) : base()
      {
      }

      public SdtTabelaDePreco_RESTInterface( GeneXus.Programs.core.SdtTabelaDePreco psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TppID" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Tppid
      {
         get {
            return sdt.gxTpr_Tppid ;
         }

         set {
            sdt.gxTpr_Tppid = value;
         }

      }

      [DataMember( Name = "TppCodigo" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Tppcodigo
      {
         get {
            return sdt.gxTpr_Tppcodigo ;
         }

         set {
            sdt.gxTpr_Tppcodigo = value;
         }

      }

      [DataMember( Name = "TppNome" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Tppnome
      {
         get {
            return sdt.gxTpr_Tppnome ;
         }

         set {
            sdt.gxTpr_Tppnome = value;
         }

      }

      [DataMember( Name = "TppInsData" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Tppinsdata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Tppinsdata) ;
         }

         set {
            sdt.gxTpr_Tppinsdata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "TppInsHora" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Tppinshora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Tppinshora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Tppinshora = GXt_dtime1;
         }

      }

      [DataMember( Name = "TppInsDataHora" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Tppinsdatahora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Tppinsdatahora) ;
         }

         set {
            sdt.gxTpr_Tppinsdatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "TppInsUsuID" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Tppinsusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Tppinsusuid) ;
         }

         set {
            sdt.gxTpr_Tppinsusuid = value;
         }

      }

      [DataMember( Name = "TppInsUsuNome" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Tppinsusunome
      {
         get {
            return sdt.gxTpr_Tppinsusunome ;
         }

         set {
            sdt.gxTpr_Tppinsusunome = value;
         }

      }

      [DataMember( Name = "TppUpdData" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Tppupddata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Tppupddata) ;
         }

         set {
            sdt.gxTpr_Tppupddata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "TppUpdHora" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Tppupdhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Tppupdhora) ;
         }

         set {
            sdt.gxTpr_Tppupdhora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "TppUpdDataHora" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Tppupddatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Tppupddatahora) ;
         }

         set {
            sdt.gxTpr_Tppupddatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "TppUpdUsuID" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Tppupdusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Tppupdusuid) ;
         }

         set {
            sdt.gxTpr_Tppupdusuid = value;
         }

      }

      [DataMember( Name = "TppUpdUsuNome" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Tppupdusunome
      {
         get {
            return sdt.gxTpr_Tppupdusunome ;
         }

         set {
            sdt.gxTpr_Tppupdusunome = value;
         }

      }

      [DataMember( Name = "TppAtivo" , Order = 13 )]
      [GxSeudo()]
      public bool gxTpr_Tppativo
      {
         get {
            return sdt.gxTpr_Tppativo ;
         }

         set {
            sdt.gxTpr_Tppativo = value;
         }

      }

      [DataMember( Name = "TppDel" , Order = 14 )]
      [GxSeudo()]
      public bool gxTpr_Tppdel
      {
         get {
            return sdt.gxTpr_Tppdel ;
         }

         set {
            sdt.gxTpr_Tppdel = value;
         }

      }

      [DataMember( Name = "TppDelDataHora" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Tppdeldatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Tppdeldatahora) ;
         }

         set {
            sdt.gxTpr_Tppdeldatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "TppDelData" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Tppdeldata
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Tppdeldata) ;
         }

         set {
            sdt.gxTpr_Tppdeldata = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "TppDelHora" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Tppdelhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Tppdelhora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Tppdelhora = GXt_dtime1;
         }

      }

      [DataMember( Name = "TppDelUsuId" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Tppdelusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Tppdelusuid) ;
         }

         set {
            sdt.gxTpr_Tppdelusuid = value;
         }

      }

      [DataMember( Name = "TppDelUsuNome" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Tppdelusunome
      {
         get {
            return sdt.gxTpr_Tppdelusunome ;
         }

         set {
            sdt.gxTpr_Tppdelusunome = value;
         }

      }

      [DataMember( Name = "Produto" , Order = 20 )]
      public GxGenericCollection<GeneXus.Programs.core.SdtTabelaDePreco_Produto_RESTInterface> gxTpr_Produto
      {
         get {
            return new GxGenericCollection<GeneXus.Programs.core.SdtTabelaDePreco_Produto_RESTInterface>(sdt.gxTpr_Produto) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Produto);
         }

      }

      public GeneXus.Programs.core.SdtTabelaDePreco sdt
      {
         get {
            return (GeneXus.Programs.core.SdtTabelaDePreco)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtTabelaDePreco() ;
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

   [DataContract(Name = @"core\TabelaDePreco", Namespace = "agl_tresorygroup")]
   public class SdtTabelaDePreco_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtTabelaDePreco>
   {
      public SdtTabelaDePreco_RESTLInterface( ) : base()
      {
      }

      public SdtTabelaDePreco_RESTLInterface( GeneXus.Programs.core.SdtTabelaDePreco psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TppCodigo" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Tppcodigo
      {
         get {
            return sdt.gxTpr_Tppcodigo ;
         }

         set {
            sdt.gxTpr_Tppcodigo = value;
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

      public GeneXus.Programs.core.SdtTabelaDePreco sdt
      {
         get {
            return (GeneXus.Programs.core.SdtTabelaDePreco)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtTabelaDePreco() ;
         }
      }

   }

}
