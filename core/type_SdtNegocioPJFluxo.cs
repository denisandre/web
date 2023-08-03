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
   [XmlRoot(ElementName = "NegocioPJFluxo" )]
   [XmlType(TypeName =  "NegocioPJFluxo" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class SdtNegocioPJFluxo : GxSilentTrnSdt
   {
      public SdtNegocioPJFluxo( )
      {
      }

      public SdtNegocioPJFluxo( IGxContext context )
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

      public void Load( Guid AV345NegID ,
                        string AV626NefChave )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV345NegID,(string)AV626NefChave});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"NegID", typeof(Guid)}, new Object[]{"NefChave", typeof(string)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "core\\NegocioPJFluxo");
         metadata.Set("BT", "tb_negociopj_fluxo");
         metadata.Set("PK", "[ \"NegID\",\"NefChave\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"NegID\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Negid_Z");
         state.Add("gxTpr_Nefchave_Z");
         state.Add("gxTpr_Nefconfirmado_Z");
         state.Add("gxTpr_Neftexto_Z");
         state.Add("gxTpr_Nefinsdatahora_Z_Nullable");
         state.Add("gxTpr_Nefinsdata_Z_Nullable");
         state.Add("gxTpr_Nefinshora_Z_Nullable");
         state.Add("gxTpr_Nefinsusuid_Z");
         state.Add("gxTpr_Nefinsusunome_Z");
         state.Add("gxTpr_Nefupddatahora_Z_Nullable");
         state.Add("gxTpr_Nefupddata_Z_Nullable");
         state.Add("gxTpr_Nefupdhora_Z_Nullable");
         state.Add("gxTpr_Nefupdusuid_Z");
         state.Add("gxTpr_Nefupdusunome_Z");
         state.Add("gxTpr_Nefvalor_Z");
         state.Add("gxTpr_Neftexto_N");
         state.Add("gxTpr_Nefupddatahora_N");
         state.Add("gxTpr_Nefupddata_N");
         state.Add("gxTpr_Nefupdhora_N");
         state.Add("gxTpr_Nefupdusuid_N");
         state.Add("gxTpr_Nefupdusunome_N");
         state.Add("gxTpr_Nefvalor_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.SdtNegocioPJFluxo sdt;
         sdt = (GeneXus.Programs.core.SdtNegocioPJFluxo)(source);
         gxTv_SdtNegocioPJFluxo_Negid = sdt.gxTv_SdtNegocioPJFluxo_Negid ;
         gxTv_SdtNegocioPJFluxo_Nefchave = sdt.gxTv_SdtNegocioPJFluxo_Nefchave ;
         gxTv_SdtNegocioPJFluxo_Nefconfirmado = sdt.gxTv_SdtNegocioPJFluxo_Nefconfirmado ;
         gxTv_SdtNegocioPJFluxo_Neftexto = sdt.gxTv_SdtNegocioPJFluxo_Neftexto ;
         gxTv_SdtNegocioPJFluxo_Nefinsdatahora = sdt.gxTv_SdtNegocioPJFluxo_Nefinsdatahora ;
         gxTv_SdtNegocioPJFluxo_Nefinsdata = sdt.gxTv_SdtNegocioPJFluxo_Nefinsdata ;
         gxTv_SdtNegocioPJFluxo_Nefinshora = sdt.gxTv_SdtNegocioPJFluxo_Nefinshora ;
         gxTv_SdtNegocioPJFluxo_Nefinsusuid = sdt.gxTv_SdtNegocioPJFluxo_Nefinsusuid ;
         gxTv_SdtNegocioPJFluxo_Nefinsusunome = sdt.gxTv_SdtNegocioPJFluxo_Nefinsusunome ;
         gxTv_SdtNegocioPJFluxo_Nefupddatahora = sdt.gxTv_SdtNegocioPJFluxo_Nefupddatahora ;
         gxTv_SdtNegocioPJFluxo_Nefupddata = sdt.gxTv_SdtNegocioPJFluxo_Nefupddata ;
         gxTv_SdtNegocioPJFluxo_Nefupdhora = sdt.gxTv_SdtNegocioPJFluxo_Nefupdhora ;
         gxTv_SdtNegocioPJFluxo_Nefupdusuid = sdt.gxTv_SdtNegocioPJFluxo_Nefupdusuid ;
         gxTv_SdtNegocioPJFluxo_Nefupdusunome = sdt.gxTv_SdtNegocioPJFluxo_Nefupdusunome ;
         gxTv_SdtNegocioPJFluxo_Nefvalor = sdt.gxTv_SdtNegocioPJFluxo_Nefvalor ;
         gxTv_SdtNegocioPJFluxo_Mode = sdt.gxTv_SdtNegocioPJFluxo_Mode ;
         gxTv_SdtNegocioPJFluxo_Initialized = sdt.gxTv_SdtNegocioPJFluxo_Initialized ;
         gxTv_SdtNegocioPJFluxo_Negid_Z = sdt.gxTv_SdtNegocioPJFluxo_Negid_Z ;
         gxTv_SdtNegocioPJFluxo_Nefchave_Z = sdt.gxTv_SdtNegocioPJFluxo_Nefchave_Z ;
         gxTv_SdtNegocioPJFluxo_Nefconfirmado_Z = sdt.gxTv_SdtNegocioPJFluxo_Nefconfirmado_Z ;
         gxTv_SdtNegocioPJFluxo_Neftexto_Z = sdt.gxTv_SdtNegocioPJFluxo_Neftexto_Z ;
         gxTv_SdtNegocioPJFluxo_Nefinsdatahora_Z = sdt.gxTv_SdtNegocioPJFluxo_Nefinsdatahora_Z ;
         gxTv_SdtNegocioPJFluxo_Nefinsdata_Z = sdt.gxTv_SdtNegocioPJFluxo_Nefinsdata_Z ;
         gxTv_SdtNegocioPJFluxo_Nefinshora_Z = sdt.gxTv_SdtNegocioPJFluxo_Nefinshora_Z ;
         gxTv_SdtNegocioPJFluxo_Nefinsusuid_Z = sdt.gxTv_SdtNegocioPJFluxo_Nefinsusuid_Z ;
         gxTv_SdtNegocioPJFluxo_Nefinsusunome_Z = sdt.gxTv_SdtNegocioPJFluxo_Nefinsusunome_Z ;
         gxTv_SdtNegocioPJFluxo_Nefupddatahora_Z = sdt.gxTv_SdtNegocioPJFluxo_Nefupddatahora_Z ;
         gxTv_SdtNegocioPJFluxo_Nefupddata_Z = sdt.gxTv_SdtNegocioPJFluxo_Nefupddata_Z ;
         gxTv_SdtNegocioPJFluxo_Nefupdhora_Z = sdt.gxTv_SdtNegocioPJFluxo_Nefupdhora_Z ;
         gxTv_SdtNegocioPJFluxo_Nefupdusuid_Z = sdt.gxTv_SdtNegocioPJFluxo_Nefupdusuid_Z ;
         gxTv_SdtNegocioPJFluxo_Nefupdusunome_Z = sdt.gxTv_SdtNegocioPJFluxo_Nefupdusunome_Z ;
         gxTv_SdtNegocioPJFluxo_Nefvalor_Z = sdt.gxTv_SdtNegocioPJFluxo_Nefvalor_Z ;
         gxTv_SdtNegocioPJFluxo_Neftexto_N = sdt.gxTv_SdtNegocioPJFluxo_Neftexto_N ;
         gxTv_SdtNegocioPJFluxo_Nefupddatahora_N = sdt.gxTv_SdtNegocioPJFluxo_Nefupddatahora_N ;
         gxTv_SdtNegocioPJFluxo_Nefupddata_N = sdt.gxTv_SdtNegocioPJFluxo_Nefupddata_N ;
         gxTv_SdtNegocioPJFluxo_Nefupdhora_N = sdt.gxTv_SdtNegocioPJFluxo_Nefupdhora_N ;
         gxTv_SdtNegocioPJFluxo_Nefupdusuid_N = sdt.gxTv_SdtNegocioPJFluxo_Nefupdusuid_N ;
         gxTv_SdtNegocioPJFluxo_Nefupdusunome_N = sdt.gxTv_SdtNegocioPJFluxo_Nefupdusunome_N ;
         gxTv_SdtNegocioPJFluxo_Nefvalor_N = sdt.gxTv_SdtNegocioPJFluxo_Nefvalor_N ;
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
         AddObjectProperty("NegID", gxTv_SdtNegocioPJFluxo_Negid, false, includeNonInitialized);
         AddObjectProperty("NefChave", gxTv_SdtNegocioPJFluxo_Nefchave, false, includeNonInitialized);
         AddObjectProperty("NefConfirmado", gxTv_SdtNegocioPJFluxo_Nefconfirmado, false, includeNonInitialized);
         AddObjectProperty("NefTexto", gxTv_SdtNegocioPJFluxo_Neftexto, false, includeNonInitialized);
         AddObjectProperty("NefTexto_N", gxTv_SdtNegocioPJFluxo_Neftexto_N, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtNegocioPJFluxo_Nefinsdatahora;
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
         AddObjectProperty("NefInsDataHora", sDateCnv, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtNegocioPJFluxo_Nefinsdata;
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
         AddObjectProperty("NefInsData", sDateCnv, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtNegocioPJFluxo_Nefinshora;
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
         AddObjectProperty("NefInsHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NefInsUsuId", gxTv_SdtNegocioPJFluxo_Nefinsusuid, false, includeNonInitialized);
         AddObjectProperty("NefInsUsuNome", gxTv_SdtNegocioPJFluxo_Nefinsusunome, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtNegocioPJFluxo_Nefupddatahora;
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
         AddObjectProperty("NefUpdDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NefUpdDataHora_N", gxTv_SdtNegocioPJFluxo_Nefupddatahora_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtNegocioPJFluxo_Nefupddata;
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
         AddObjectProperty("NefUpdData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NefUpdData_N", gxTv_SdtNegocioPJFluxo_Nefupddata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtNegocioPJFluxo_Nefupdhora;
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
         AddObjectProperty("NefUpdHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NefUpdHora_N", gxTv_SdtNegocioPJFluxo_Nefupdhora_N, false, includeNonInitialized);
         AddObjectProperty("NefUpdUsuId", gxTv_SdtNegocioPJFluxo_Nefupdusuid, false, includeNonInitialized);
         AddObjectProperty("NefUpdUsuId_N", gxTv_SdtNegocioPJFluxo_Nefupdusuid_N, false, includeNonInitialized);
         AddObjectProperty("NefUpdUsuNome", gxTv_SdtNegocioPJFluxo_Nefupdusunome, false, includeNonInitialized);
         AddObjectProperty("NefUpdUsuNome_N", gxTv_SdtNegocioPJFluxo_Nefupdusunome_N, false, includeNonInitialized);
         AddObjectProperty("NefValor", gxTv_SdtNegocioPJFluxo_Nefvalor, false, includeNonInitialized);
         AddObjectProperty("NefValor_N", gxTv_SdtNegocioPJFluxo_Nefvalor_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtNegocioPJFluxo_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtNegocioPJFluxo_Initialized, false, includeNonInitialized);
            AddObjectProperty("NegID_Z", gxTv_SdtNegocioPJFluxo_Negid_Z, false, includeNonInitialized);
            AddObjectProperty("NefChave_Z", gxTv_SdtNegocioPJFluxo_Nefchave_Z, false, includeNonInitialized);
            AddObjectProperty("NefConfirmado_Z", gxTv_SdtNegocioPJFluxo_Nefconfirmado_Z, false, includeNonInitialized);
            AddObjectProperty("NefTexto_Z", gxTv_SdtNegocioPJFluxo_Neftexto_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtNegocioPJFluxo_Nefinsdatahora_Z;
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
            AddObjectProperty("NefInsDataHora_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtNegocioPJFluxo_Nefinsdata_Z;
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
            AddObjectProperty("NefInsData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtNegocioPJFluxo_Nefinshora_Z;
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
            AddObjectProperty("NefInsHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("NefInsUsuId_Z", gxTv_SdtNegocioPJFluxo_Nefinsusuid_Z, false, includeNonInitialized);
            AddObjectProperty("NefInsUsuNome_Z", gxTv_SdtNegocioPJFluxo_Nefinsusunome_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtNegocioPJFluxo_Nefupddatahora_Z;
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
            AddObjectProperty("NefUpdDataHora_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtNegocioPJFluxo_Nefupddata_Z;
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
            AddObjectProperty("NefUpdData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtNegocioPJFluxo_Nefupdhora_Z;
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
            AddObjectProperty("NefUpdHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("NefUpdUsuId_Z", gxTv_SdtNegocioPJFluxo_Nefupdusuid_Z, false, includeNonInitialized);
            AddObjectProperty("NefUpdUsuNome_Z", gxTv_SdtNegocioPJFluxo_Nefupdusunome_Z, false, includeNonInitialized);
            AddObjectProperty("NefValor_Z", gxTv_SdtNegocioPJFluxo_Nefvalor_Z, false, includeNonInitialized);
            AddObjectProperty("NefTexto_N", gxTv_SdtNegocioPJFluxo_Neftexto_N, false, includeNonInitialized);
            AddObjectProperty("NefUpdDataHora_N", gxTv_SdtNegocioPJFluxo_Nefupddatahora_N, false, includeNonInitialized);
            AddObjectProperty("NefUpdData_N", gxTv_SdtNegocioPJFluxo_Nefupddata_N, false, includeNonInitialized);
            AddObjectProperty("NefUpdHora_N", gxTv_SdtNegocioPJFluxo_Nefupdhora_N, false, includeNonInitialized);
            AddObjectProperty("NefUpdUsuId_N", gxTv_SdtNegocioPJFluxo_Nefupdusuid_N, false, includeNonInitialized);
            AddObjectProperty("NefUpdUsuNome_N", gxTv_SdtNegocioPJFluxo_Nefupdusunome_N, false, includeNonInitialized);
            AddObjectProperty("NefValor_N", gxTv_SdtNegocioPJFluxo_Nefvalor_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.SdtNegocioPJFluxo sdt )
      {
         if ( sdt.IsDirty("NegID") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Negid = sdt.gxTv_SdtNegocioPJFluxo_Negid ;
         }
         if ( sdt.IsDirty("NefChave") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefchave = sdt.gxTv_SdtNegocioPJFluxo_Nefchave ;
         }
         if ( sdt.IsDirty("NefConfirmado") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefconfirmado = sdt.gxTv_SdtNegocioPJFluxo_Nefconfirmado ;
         }
         if ( sdt.IsDirty("NefTexto") )
         {
            gxTv_SdtNegocioPJFluxo_Neftexto_N = (short)(sdt.gxTv_SdtNegocioPJFluxo_Neftexto_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Neftexto = sdt.gxTv_SdtNegocioPJFluxo_Neftexto ;
         }
         if ( sdt.IsDirty("NefInsDataHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefinsdatahora = sdt.gxTv_SdtNegocioPJFluxo_Nefinsdatahora ;
         }
         if ( sdt.IsDirty("NefInsData") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefinsdata = sdt.gxTv_SdtNegocioPJFluxo_Nefinsdata ;
         }
         if ( sdt.IsDirty("NefInsHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefinshora = sdt.gxTv_SdtNegocioPJFluxo_Nefinshora ;
         }
         if ( sdt.IsDirty("NefInsUsuId") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefinsusuid = sdt.gxTv_SdtNegocioPJFluxo_Nefinsusuid ;
         }
         if ( sdt.IsDirty("NefInsUsuNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefinsusunome = sdt.gxTv_SdtNegocioPJFluxo_Nefinsusunome ;
         }
         if ( sdt.IsDirty("NefUpdDataHora") )
         {
            gxTv_SdtNegocioPJFluxo_Nefupddatahora_N = (short)(sdt.gxTv_SdtNegocioPJFluxo_Nefupddatahora_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefupddatahora = sdt.gxTv_SdtNegocioPJFluxo_Nefupddatahora ;
         }
         if ( sdt.IsDirty("NefUpdData") )
         {
            gxTv_SdtNegocioPJFluxo_Nefupddata_N = (short)(sdt.gxTv_SdtNegocioPJFluxo_Nefupddata_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefupddata = sdt.gxTv_SdtNegocioPJFluxo_Nefupddata ;
         }
         if ( sdt.IsDirty("NefUpdHora") )
         {
            gxTv_SdtNegocioPJFluxo_Nefupdhora_N = (short)(sdt.gxTv_SdtNegocioPJFluxo_Nefupdhora_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefupdhora = sdt.gxTv_SdtNegocioPJFluxo_Nefupdhora ;
         }
         if ( sdt.IsDirty("NefUpdUsuId") )
         {
            gxTv_SdtNegocioPJFluxo_Nefupdusuid_N = (short)(sdt.gxTv_SdtNegocioPJFluxo_Nefupdusuid_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefupdusuid = sdt.gxTv_SdtNegocioPJFluxo_Nefupdusuid ;
         }
         if ( sdt.IsDirty("NefUpdUsuNome") )
         {
            gxTv_SdtNegocioPJFluxo_Nefupdusunome_N = (short)(sdt.gxTv_SdtNegocioPJFluxo_Nefupdusunome_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefupdusunome = sdt.gxTv_SdtNegocioPJFluxo_Nefupdusunome ;
         }
         if ( sdt.IsDirty("NefValor") )
         {
            gxTv_SdtNegocioPJFluxo_Nefvalor_N = (short)(sdt.gxTv_SdtNegocioPJFluxo_Nefvalor_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefvalor = sdt.gxTv_SdtNegocioPJFluxo_Nefvalor ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "NegID" )]
      [  XmlElement( ElementName = "NegID"   )]
      public Guid gxTpr_Negid
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Negid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtNegocioPJFluxo_Negid != value )
            {
               gxTv_SdtNegocioPJFluxo_Mode = "INS";
               this.gxTv_SdtNegocioPJFluxo_Negid_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefchave_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefconfirmado_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Neftexto_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefinsdatahora_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefinsdata_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefinshora_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefinsusuid_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefinsusunome_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefupddatahora_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefupddata_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefupdhora_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefupdusuid_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefupdusunome_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefvalor_Z_SetNull( );
            }
            gxTv_SdtNegocioPJFluxo_Negid = value;
            SetDirty("Negid");
         }

      }

      [  SoapElement( ElementName = "NefChave" )]
      [  XmlElement( ElementName = "NefChave"   )]
      public string gxTpr_Nefchave
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefchave ;
         }

         set {
            sdtIsNull = 0;
            if ( StringUtil.StrCmp(gxTv_SdtNegocioPJFluxo_Nefchave, value) != 0 )
            {
               gxTv_SdtNegocioPJFluxo_Mode = "INS";
               this.gxTv_SdtNegocioPJFluxo_Negid_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefchave_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefconfirmado_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Neftexto_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefinsdatahora_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefinsdata_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefinshora_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefinsusuid_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefinsusunome_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefupddatahora_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefupddata_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefupdhora_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefupdusuid_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefupdusunome_Z_SetNull( );
               this.gxTv_SdtNegocioPJFluxo_Nefvalor_Z_SetNull( );
            }
            gxTv_SdtNegocioPJFluxo_Nefchave = value;
            SetDirty("Nefchave");
         }

      }

      [  SoapElement( ElementName = "NefConfirmado" )]
      [  XmlElement( ElementName = "NefConfirmado"   )]
      public bool gxTpr_Nefconfirmado
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefconfirmado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefconfirmado = value;
            SetDirty("Nefconfirmado");
         }

      }

      [  SoapElement( ElementName = "NefTexto" )]
      [  XmlElement( ElementName = "NefTexto"   )]
      public string gxTpr_Neftexto
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Neftexto ;
         }

         set {
            gxTv_SdtNegocioPJFluxo_Neftexto_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Neftexto = value;
            SetDirty("Neftexto");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Neftexto_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Neftexto_N = 1;
         gxTv_SdtNegocioPJFluxo_Neftexto = "";
         SetDirty("Neftexto");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Neftexto_IsNull( )
      {
         return (gxTv_SdtNegocioPJFluxo_Neftexto_N==1) ;
      }

      [  SoapElement( ElementName = "NefInsDataHora" )]
      [  XmlElement( ElementName = "NefInsDataHora"  , IsNullable=true )]
      public string gxTpr_Nefinsdatahora_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJFluxo_Nefinsdatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJFluxo_Nefinsdatahora, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJFluxo_Nefinsdatahora = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJFluxo_Nefinsdatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Nefinsdatahora
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefinsdatahora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefinsdatahora = value;
            SetDirty("Nefinsdatahora");
         }

      }

      [  SoapElement( ElementName = "NefInsData" )]
      [  XmlElement( ElementName = "NefInsData"  , IsNullable=true )]
      public string gxTpr_Nefinsdata_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJFluxo_Nefinsdata == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJFluxo_Nefinsdata).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJFluxo_Nefinsdata = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJFluxo_Nefinsdata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Nefinsdata
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefinsdata ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefinsdata = value;
            SetDirty("Nefinsdata");
         }

      }

      [  SoapElement( ElementName = "NefInsHora" )]
      [  XmlElement( ElementName = "NefInsHora"  , IsNullable=true )]
      public string gxTpr_Nefinshora_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJFluxo_Nefinshora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJFluxo_Nefinshora).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJFluxo_Nefinshora = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJFluxo_Nefinshora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Nefinshora
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefinshora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefinshora = value;
            SetDirty("Nefinshora");
         }

      }

      [  SoapElement( ElementName = "NefInsUsuId" )]
      [  XmlElement( ElementName = "NefInsUsuId"   )]
      public string gxTpr_Nefinsusuid
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefinsusuid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefinsusuid = value;
            SetDirty("Nefinsusuid");
         }

      }

      [  SoapElement( ElementName = "NefInsUsuNome" )]
      [  XmlElement( ElementName = "NefInsUsuNome"   )]
      public string gxTpr_Nefinsusunome
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefinsusunome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefinsusunome = value;
            SetDirty("Nefinsusunome");
         }

      }

      [  SoapElement( ElementName = "NefUpdDataHora" )]
      [  XmlElement( ElementName = "NefUpdDataHora"  , IsNullable=true )]
      public string gxTpr_Nefupddatahora_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJFluxo_Nefupddatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJFluxo_Nefupddatahora, null, true).value ;
         }

         set {
            gxTv_SdtNegocioPJFluxo_Nefupddatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJFluxo_Nefupddatahora = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJFluxo_Nefupddatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Nefupddatahora
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefupddatahora ;
         }

         set {
            gxTv_SdtNegocioPJFluxo_Nefupddatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefupddatahora = value;
            SetDirty("Nefupddatahora");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefupddatahora_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefupddatahora_N = 1;
         gxTv_SdtNegocioPJFluxo_Nefupddatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Nefupddatahora");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefupddatahora_IsNull( )
      {
         return (gxTv_SdtNegocioPJFluxo_Nefupddatahora_N==1) ;
      }

      [  SoapElement( ElementName = "NefUpdData" )]
      [  XmlElement( ElementName = "NefUpdData"  , IsNullable=true )]
      public string gxTpr_Nefupddata_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJFluxo_Nefupddata == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJFluxo_Nefupddata).value ;
         }

         set {
            gxTv_SdtNegocioPJFluxo_Nefupddata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJFluxo_Nefupddata = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJFluxo_Nefupddata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Nefupddata
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefupddata ;
         }

         set {
            gxTv_SdtNegocioPJFluxo_Nefupddata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefupddata = value;
            SetDirty("Nefupddata");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefupddata_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefupddata_N = 1;
         gxTv_SdtNegocioPJFluxo_Nefupddata = (DateTime)(DateTime.MinValue);
         SetDirty("Nefupddata");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefupddata_IsNull( )
      {
         return (gxTv_SdtNegocioPJFluxo_Nefupddata_N==1) ;
      }

      [  SoapElement( ElementName = "NefUpdHora" )]
      [  XmlElement( ElementName = "NefUpdHora"  , IsNullable=true )]
      public string gxTpr_Nefupdhora_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJFluxo_Nefupdhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJFluxo_Nefupdhora).value ;
         }

         set {
            gxTv_SdtNegocioPJFluxo_Nefupdhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJFluxo_Nefupdhora = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJFluxo_Nefupdhora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Nefupdhora
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefupdhora ;
         }

         set {
            gxTv_SdtNegocioPJFluxo_Nefupdhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefupdhora = value;
            SetDirty("Nefupdhora");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefupdhora_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefupdhora_N = 1;
         gxTv_SdtNegocioPJFluxo_Nefupdhora = (DateTime)(DateTime.MinValue);
         SetDirty("Nefupdhora");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefupdhora_IsNull( )
      {
         return (gxTv_SdtNegocioPJFluxo_Nefupdhora_N==1) ;
      }

      [  SoapElement( ElementName = "NefUpdUsuId" )]
      [  XmlElement( ElementName = "NefUpdUsuId"   )]
      public string gxTpr_Nefupdusuid
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefupdusuid ;
         }

         set {
            gxTv_SdtNegocioPJFluxo_Nefupdusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefupdusuid = value;
            SetDirty("Nefupdusuid");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefupdusuid_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefupdusuid_N = 1;
         gxTv_SdtNegocioPJFluxo_Nefupdusuid = "";
         SetDirty("Nefupdusuid");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefupdusuid_IsNull( )
      {
         return (gxTv_SdtNegocioPJFluxo_Nefupdusuid_N==1) ;
      }

      [  SoapElement( ElementName = "NefUpdUsuNome" )]
      [  XmlElement( ElementName = "NefUpdUsuNome"   )]
      public string gxTpr_Nefupdusunome
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefupdusunome ;
         }

         set {
            gxTv_SdtNegocioPJFluxo_Nefupdusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefupdusunome = value;
            SetDirty("Nefupdusunome");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefupdusunome_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefupdusunome_N = 1;
         gxTv_SdtNegocioPJFluxo_Nefupdusunome = "";
         SetDirty("Nefupdusunome");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefupdusunome_IsNull( )
      {
         return (gxTv_SdtNegocioPJFluxo_Nefupdusunome_N==1) ;
      }

      [  SoapElement( ElementName = "NefValor" )]
      [  XmlElement( ElementName = "NefValor"   )]
      public short gxTpr_Nefvalor
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefvalor ;
         }

         set {
            gxTv_SdtNegocioPJFluxo_Nefvalor_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefvalor = value;
            SetDirty("Nefvalor");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefvalor_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefvalor_N = 1;
         gxTv_SdtNegocioPJFluxo_Nefvalor = 0;
         SetDirty("Nefvalor");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefvalor_IsNull( )
      {
         return (gxTv_SdtNegocioPJFluxo_Nefvalor_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Mode_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Initialized_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegID_Z" )]
      [  XmlElement( ElementName = "NegID_Z"   )]
      public Guid gxTpr_Negid_Z
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Negid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Negid_Z = value;
            SetDirty("Negid_Z");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Negid_Z_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Negid_Z = Guid.Empty;
         SetDirty("Negid_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Negid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NefChave_Z" )]
      [  XmlElement( ElementName = "NefChave_Z"   )]
      public string gxTpr_Nefchave_Z
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefchave_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefchave_Z = value;
            SetDirty("Nefchave_Z");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefchave_Z_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefchave_Z = "";
         SetDirty("Nefchave_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefchave_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NefConfirmado_Z" )]
      [  XmlElement( ElementName = "NefConfirmado_Z"   )]
      public bool gxTpr_Nefconfirmado_Z
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefconfirmado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefconfirmado_Z = value;
            SetDirty("Nefconfirmado_Z");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefconfirmado_Z_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefconfirmado_Z = false;
         SetDirty("Nefconfirmado_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefconfirmado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NefTexto_Z" )]
      [  XmlElement( ElementName = "NefTexto_Z"   )]
      public string gxTpr_Neftexto_Z
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Neftexto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Neftexto_Z = value;
            SetDirty("Neftexto_Z");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Neftexto_Z_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Neftexto_Z = "";
         SetDirty("Neftexto_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Neftexto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NefInsDataHora_Z" )]
      [  XmlElement( ElementName = "NefInsDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Nefinsdatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJFluxo_Nefinsdatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJFluxo_Nefinsdatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJFluxo_Nefinsdatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJFluxo_Nefinsdatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Nefinsdatahora_Z
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefinsdatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefinsdatahora_Z = value;
            SetDirty("Nefinsdatahora_Z");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefinsdatahora_Z_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefinsdatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Nefinsdatahora_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefinsdatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NefInsData_Z" )]
      [  XmlElement( ElementName = "NefInsData_Z"  , IsNullable=true )]
      public string gxTpr_Nefinsdata_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJFluxo_Nefinsdata_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJFluxo_Nefinsdata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJFluxo_Nefinsdata_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJFluxo_Nefinsdata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Nefinsdata_Z
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefinsdata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefinsdata_Z = value;
            SetDirty("Nefinsdata_Z");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefinsdata_Z_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefinsdata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Nefinsdata_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefinsdata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NefInsHora_Z" )]
      [  XmlElement( ElementName = "NefInsHora_Z"  , IsNullable=true )]
      public string gxTpr_Nefinshora_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJFluxo_Nefinshora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJFluxo_Nefinshora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJFluxo_Nefinshora_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJFluxo_Nefinshora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Nefinshora_Z
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefinshora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefinshora_Z = value;
            SetDirty("Nefinshora_Z");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefinshora_Z_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefinshora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Nefinshora_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefinshora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NefInsUsuId_Z" )]
      [  XmlElement( ElementName = "NefInsUsuId_Z"   )]
      public string gxTpr_Nefinsusuid_Z
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefinsusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefinsusuid_Z = value;
            SetDirty("Nefinsusuid_Z");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefinsusuid_Z_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefinsusuid_Z = "";
         SetDirty("Nefinsusuid_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefinsusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NefInsUsuNome_Z" )]
      [  XmlElement( ElementName = "NefInsUsuNome_Z"   )]
      public string gxTpr_Nefinsusunome_Z
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefinsusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefinsusunome_Z = value;
            SetDirty("Nefinsusunome_Z");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefinsusunome_Z_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefinsusunome_Z = "";
         SetDirty("Nefinsusunome_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefinsusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NefUpdDataHora_Z" )]
      [  XmlElement( ElementName = "NefUpdDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Nefupddatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJFluxo_Nefupddatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJFluxo_Nefupddatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJFluxo_Nefupddatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJFluxo_Nefupddatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Nefupddatahora_Z
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefupddatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefupddatahora_Z = value;
            SetDirty("Nefupddatahora_Z");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefupddatahora_Z_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefupddatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Nefupddatahora_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefupddatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NefUpdData_Z" )]
      [  XmlElement( ElementName = "NefUpdData_Z"  , IsNullable=true )]
      public string gxTpr_Nefupddata_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJFluxo_Nefupddata_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJFluxo_Nefupddata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJFluxo_Nefupddata_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJFluxo_Nefupddata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Nefupddata_Z
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefupddata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefupddata_Z = value;
            SetDirty("Nefupddata_Z");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefupddata_Z_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefupddata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Nefupddata_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefupddata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NefUpdHora_Z" )]
      [  XmlElement( ElementName = "NefUpdHora_Z"  , IsNullable=true )]
      public string gxTpr_Nefupdhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJFluxo_Nefupdhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJFluxo_Nefupdhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJFluxo_Nefupdhora_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJFluxo_Nefupdhora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Nefupdhora_Z
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefupdhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefupdhora_Z = value;
            SetDirty("Nefupdhora_Z");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefupdhora_Z_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefupdhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Nefupdhora_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefupdhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NefUpdUsuId_Z" )]
      [  XmlElement( ElementName = "NefUpdUsuId_Z"   )]
      public string gxTpr_Nefupdusuid_Z
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefupdusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefupdusuid_Z = value;
            SetDirty("Nefupdusuid_Z");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefupdusuid_Z_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefupdusuid_Z = "";
         SetDirty("Nefupdusuid_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefupdusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NefUpdUsuNome_Z" )]
      [  XmlElement( ElementName = "NefUpdUsuNome_Z"   )]
      public string gxTpr_Nefupdusunome_Z
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefupdusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefupdusunome_Z = value;
            SetDirty("Nefupdusunome_Z");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefupdusunome_Z_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefupdusunome_Z = "";
         SetDirty("Nefupdusunome_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefupdusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NefValor_Z" )]
      [  XmlElement( ElementName = "NefValor_Z"   )]
      public short gxTpr_Nefvalor_Z
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefvalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefvalor_Z = value;
            SetDirty("Nefvalor_Z");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefvalor_Z_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefvalor_Z = 0;
         SetDirty("Nefvalor_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefvalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NefTexto_N" )]
      [  XmlElement( ElementName = "NefTexto_N"   )]
      public short gxTpr_Neftexto_N
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Neftexto_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Neftexto_N = value;
            SetDirty("Neftexto_N");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Neftexto_N_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Neftexto_N = 0;
         SetDirty("Neftexto_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Neftexto_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NefUpdDataHora_N" )]
      [  XmlElement( ElementName = "NefUpdDataHora_N"   )]
      public short gxTpr_Nefupddatahora_N
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefupddatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefupddatahora_N = value;
            SetDirty("Nefupddatahora_N");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefupddatahora_N_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefupddatahora_N = 0;
         SetDirty("Nefupddatahora_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefupddatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NefUpdData_N" )]
      [  XmlElement( ElementName = "NefUpdData_N"   )]
      public short gxTpr_Nefupddata_N
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefupddata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefupddata_N = value;
            SetDirty("Nefupddata_N");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefupddata_N_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefupddata_N = 0;
         SetDirty("Nefupddata_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefupddata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NefUpdHora_N" )]
      [  XmlElement( ElementName = "NefUpdHora_N"   )]
      public short gxTpr_Nefupdhora_N
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefupdhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefupdhora_N = value;
            SetDirty("Nefupdhora_N");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefupdhora_N_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefupdhora_N = 0;
         SetDirty("Nefupdhora_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefupdhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NefUpdUsuId_N" )]
      [  XmlElement( ElementName = "NefUpdUsuId_N"   )]
      public short gxTpr_Nefupdusuid_N
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefupdusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefupdusuid_N = value;
            SetDirty("Nefupdusuid_N");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefupdusuid_N_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefupdusuid_N = 0;
         SetDirty("Nefupdusuid_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefupdusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NefUpdUsuNome_N" )]
      [  XmlElement( ElementName = "NefUpdUsuNome_N"   )]
      public short gxTpr_Nefupdusunome_N
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefupdusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefupdusunome_N = value;
            SetDirty("Nefupdusunome_N");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefupdusunome_N_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefupdusunome_N = 0;
         SetDirty("Nefupdusunome_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefupdusunome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NefValor_N" )]
      [  XmlElement( ElementName = "NefValor_N"   )]
      public short gxTpr_Nefvalor_N
      {
         get {
            return gxTv_SdtNegocioPJFluxo_Nefvalor_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJFluxo_Nefvalor_N = value;
            SetDirty("Nefvalor_N");
         }

      }

      public void gxTv_SdtNegocioPJFluxo_Nefvalor_N_SetNull( )
      {
         gxTv_SdtNegocioPJFluxo_Nefvalor_N = 0;
         SetDirty("Nefvalor_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJFluxo_Nefvalor_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtNegocioPJFluxo_Negid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtNegocioPJFluxo_Nefchave = "";
         gxTv_SdtNegocioPJFluxo_Neftexto = "";
         gxTv_SdtNegocioPJFluxo_Nefinsdatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJFluxo_Nefinsdata = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJFluxo_Nefinshora = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJFluxo_Nefinsusuid = "";
         gxTv_SdtNegocioPJFluxo_Nefinsusunome = "";
         gxTv_SdtNegocioPJFluxo_Nefupddatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJFluxo_Nefupddata = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJFluxo_Nefupdhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJFluxo_Nefupdusuid = "";
         gxTv_SdtNegocioPJFluxo_Nefupdusunome = "";
         gxTv_SdtNegocioPJFluxo_Mode = "";
         gxTv_SdtNegocioPJFluxo_Negid_Z = Guid.Empty;
         gxTv_SdtNegocioPJFluxo_Nefchave_Z = "";
         gxTv_SdtNegocioPJFluxo_Neftexto_Z = "";
         gxTv_SdtNegocioPJFluxo_Nefinsdatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJFluxo_Nefinsdata_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJFluxo_Nefinshora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJFluxo_Nefinsusuid_Z = "";
         gxTv_SdtNegocioPJFluxo_Nefinsusunome_Z = "";
         gxTv_SdtNegocioPJFluxo_Nefupddatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJFluxo_Nefupddata_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJFluxo_Nefupdhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJFluxo_Nefupdusuid_Z = "";
         gxTv_SdtNegocioPJFluxo_Nefupdusunome_Z = "";
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "core.negociopjfluxo", "GeneXus.Programs.core.negociopjfluxo_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtNegocioPJFluxo_Nefvalor ;
      private short gxTv_SdtNegocioPJFluxo_Initialized ;
      private short gxTv_SdtNegocioPJFluxo_Nefvalor_Z ;
      private short gxTv_SdtNegocioPJFluxo_Neftexto_N ;
      private short gxTv_SdtNegocioPJFluxo_Nefupddatahora_N ;
      private short gxTv_SdtNegocioPJFluxo_Nefupddata_N ;
      private short gxTv_SdtNegocioPJFluxo_Nefupdhora_N ;
      private short gxTv_SdtNegocioPJFluxo_Nefupdusuid_N ;
      private short gxTv_SdtNegocioPJFluxo_Nefupdusunome_N ;
      private short gxTv_SdtNegocioPJFluxo_Nefvalor_N ;
      private string gxTv_SdtNegocioPJFluxo_Nefinsusuid ;
      private string gxTv_SdtNegocioPJFluxo_Nefupdusuid ;
      private string gxTv_SdtNegocioPJFluxo_Mode ;
      private string gxTv_SdtNegocioPJFluxo_Nefinsusuid_Z ;
      private string gxTv_SdtNegocioPJFluxo_Nefupdusuid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtNegocioPJFluxo_Nefinsdatahora ;
      private DateTime gxTv_SdtNegocioPJFluxo_Nefinsdata ;
      private DateTime gxTv_SdtNegocioPJFluxo_Nefinshora ;
      private DateTime gxTv_SdtNegocioPJFluxo_Nefupddatahora ;
      private DateTime gxTv_SdtNegocioPJFluxo_Nefupddata ;
      private DateTime gxTv_SdtNegocioPJFluxo_Nefupdhora ;
      private DateTime gxTv_SdtNegocioPJFluxo_Nefinsdatahora_Z ;
      private DateTime gxTv_SdtNegocioPJFluxo_Nefinsdata_Z ;
      private DateTime gxTv_SdtNegocioPJFluxo_Nefinshora_Z ;
      private DateTime gxTv_SdtNegocioPJFluxo_Nefupddatahora_Z ;
      private DateTime gxTv_SdtNegocioPJFluxo_Nefupddata_Z ;
      private DateTime gxTv_SdtNegocioPJFluxo_Nefupdhora_Z ;
      private DateTime datetimemil_STZ ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtNegocioPJFluxo_Nefconfirmado ;
      private bool gxTv_SdtNegocioPJFluxo_Nefconfirmado_Z ;
      private string gxTv_SdtNegocioPJFluxo_Nefchave ;
      private string gxTv_SdtNegocioPJFluxo_Neftexto ;
      private string gxTv_SdtNegocioPJFluxo_Nefinsusunome ;
      private string gxTv_SdtNegocioPJFluxo_Nefupdusunome ;
      private string gxTv_SdtNegocioPJFluxo_Nefchave_Z ;
      private string gxTv_SdtNegocioPJFluxo_Neftexto_Z ;
      private string gxTv_SdtNegocioPJFluxo_Nefinsusunome_Z ;
      private string gxTv_SdtNegocioPJFluxo_Nefupdusunome_Z ;
      private Guid gxTv_SdtNegocioPJFluxo_Negid ;
      private Guid gxTv_SdtNegocioPJFluxo_Negid_Z ;
   }

   [DataContract(Name = @"core\NegocioPJFluxo", Namespace = "agl_tresorygroup")]
   public class SdtNegocioPJFluxo_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtNegocioPJFluxo>
   {
      public SdtNegocioPJFluxo_RESTInterface( ) : base()
      {
      }

      public SdtNegocioPJFluxo_RESTInterface( GeneXus.Programs.core.SdtNegocioPJFluxo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NegID" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Negid
      {
         get {
            return sdt.gxTpr_Negid ;
         }

         set {
            sdt.gxTpr_Negid = value;
         }

      }

      [DataMember( Name = "NefChave" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Nefchave
      {
         get {
            return sdt.gxTpr_Nefchave ;
         }

         set {
            sdt.gxTpr_Nefchave = value;
         }

      }

      [DataMember( Name = "NefConfirmado" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Nefconfirmado
      {
         get {
            return sdt.gxTpr_Nefconfirmado ;
         }

         set {
            sdt.gxTpr_Nefconfirmado = value;
         }

      }

      [DataMember( Name = "NefTexto" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Neftexto
      {
         get {
            return sdt.gxTpr_Neftexto ;
         }

         set {
            sdt.gxTpr_Neftexto = value;
         }

      }

      [DataMember( Name = "NefInsDataHora" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Nefinsdatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Nefinsdatahora) ;
         }

         set {
            sdt.gxTpr_Nefinsdatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "NefInsData" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Nefinsdata
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Nefinsdata) ;
         }

         set {
            sdt.gxTpr_Nefinsdata = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "NefInsHora" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Nefinshora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Nefinshora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Nefinshora = GXt_dtime1;
         }

      }

      [DataMember( Name = "NefInsUsuId" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Nefinsusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Nefinsusuid) ;
         }

         set {
            sdt.gxTpr_Nefinsusuid = value;
         }

      }

      [DataMember( Name = "NefInsUsuNome" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Nefinsusunome
      {
         get {
            return sdt.gxTpr_Nefinsusunome ;
         }

         set {
            sdt.gxTpr_Nefinsusunome = value;
         }

      }

      [DataMember( Name = "NefUpdDataHora" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Nefupddatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Nefupddatahora) ;
         }

         set {
            sdt.gxTpr_Nefupddatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "NefUpdData" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Nefupddata
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Nefupddata) ;
         }

         set {
            sdt.gxTpr_Nefupddata = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "NefUpdHora" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Nefupdhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Nefupdhora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Nefupdhora = GXt_dtime1;
         }

      }

      [DataMember( Name = "NefUpdUsuId" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Nefupdusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Nefupdusuid) ;
         }

         set {
            sdt.gxTpr_Nefupdusuid = value;
         }

      }

      [DataMember( Name = "NefUpdUsuNome" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Nefupdusunome
      {
         get {
            return sdt.gxTpr_Nefupdusunome ;
         }

         set {
            sdt.gxTpr_Nefupdusunome = value;
         }

      }

      [DataMember( Name = "NefValor" , Order = 14 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Nefvalor
      {
         get {
            return sdt.gxTpr_Nefvalor ;
         }

         set {
            sdt.gxTpr_Nefvalor = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public GeneXus.Programs.core.SdtNegocioPJFluxo sdt
      {
         get {
            return (GeneXus.Programs.core.SdtNegocioPJFluxo)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtNegocioPJFluxo() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 15 )]
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

   [DataContract(Name = @"core\NegocioPJFluxo", Namespace = "agl_tresorygroup")]
   public class SdtNegocioPJFluxo_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtNegocioPJFluxo>
   {
      public SdtNegocioPJFluxo_RESTLInterface( ) : base()
      {
      }

      public SdtNegocioPJFluxo_RESTLInterface( GeneXus.Programs.core.SdtNegocioPJFluxo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NefConfirmado" , Order = 0 )]
      [GxSeudo()]
      public bool gxTpr_Nefconfirmado
      {
         get {
            return sdt.gxTpr_Nefconfirmado ;
         }

         set {
            sdt.gxTpr_Nefconfirmado = value;
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

      public GeneXus.Programs.core.SdtNegocioPJFluxo sdt
      {
         get {
            return (GeneXus.Programs.core.SdtNegocioPJFluxo)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtNegocioPJFluxo() ;
         }
      }

   }

}
