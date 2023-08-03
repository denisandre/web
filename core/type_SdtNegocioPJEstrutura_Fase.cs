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
   [XmlRoot(ElementName = "NegocioPJEstrutura.Fase" )]
   [XmlType(TypeName =  "NegocioPJEstrutura.Fase" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class SdtNegocioPJEstrutura_Fase : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtNegocioPJEstrutura_Fase( )
      {
      }

      public SdtNegocioPJEstrutura_Fase( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"NgfSeq", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Fase");
         metadata.Set("BT", "tb_negociopj_fase");
         metadata.Set("PK", "[ \"NgfSeq\" ]");
         metadata.Set("PKAssigned", "[ \"NgfSeq\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"IteID\" ],\"FKMap\":[ \"NgfIteID-IteID\" ] },{ \"FK\":[ \"NegID\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Ngfseq_Z");
         state.Add("gxTpr_Ngfinsdata_Z_Nullable");
         state.Add("gxTpr_Ngfinshora_Z_Nullable");
         state.Add("gxTpr_Ngfinsdatahora_Z_Nullable");
         state.Add("gxTpr_Ngfinsusuid_Z");
         state.Add("gxTpr_Ngfinsusunome_Z");
         state.Add("gxTpr_Ngfiteid_Z");
         state.Add("gxTpr_Ngfiteordem_Z");
         state.Add("gxTpr_Ngfitenome_Z");
         state.Add("gxTpr_Ngffimdata_Z_Nullable");
         state.Add("gxTpr_Ngffimhora_Z_Nullable");
         state.Add("gxTpr_Ngffimdatahora_Z_Nullable");
         state.Add("gxTpr_Ngffimusuid_Z");
         state.Add("gxTpr_Ngffimusunome_Z");
         state.Add("gxTpr_Ngfstatus_Z");
         state.Add("gxTpr_Ngfdel_Z");
         state.Add("gxTpr_Ngfdeldatahora_Z_Nullable");
         state.Add("gxTpr_Ngfdeldata_Z_Nullable");
         state.Add("gxTpr_Ngfdelhora_Z_Nullable");
         state.Add("gxTpr_Ngfdelusuid_Z");
         state.Add("gxTpr_Ngfdelusunome_Z");
         state.Add("gxTpr_Ngfinsusuid_N");
         state.Add("gxTpr_Ngfinsusunome_N");
         state.Add("gxTpr_Ngffimdata_N");
         state.Add("gxTpr_Ngffimhora_N");
         state.Add("gxTpr_Ngffimdatahora_N");
         state.Add("gxTpr_Ngffimusuid_N");
         state.Add("gxTpr_Ngffimusunome_N");
         state.Add("gxTpr_Ngfstatus_N");
         state.Add("gxTpr_Ngfdeldatahora_N");
         state.Add("gxTpr_Ngfdeldata_N");
         state.Add("gxTpr_Ngfdelhora_N");
         state.Add("gxTpr_Ngfdelusuid_N");
         state.Add("gxTpr_Ngfdelusunome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase sdt;
         sdt = (GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase)(source);
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfseq = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfseq ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteid = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteid ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteordem = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteordem ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfitenome = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfitenome ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdel = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdel ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome ;
         gxTv_SdtNegocioPJEstrutura_Fase_Mode = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Mode ;
         gxTv_SdtNegocioPJEstrutura_Fase_Modified = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Modified ;
         gxTv_SdtNegocioPJEstrutura_Fase_Initialized = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Initialized ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfseq_Z = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfseq_Z ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata_Z = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata_Z ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora_Z = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora_Z ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora_Z = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora_Z ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_Z = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_Z ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_Z = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_Z ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteid_Z = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteid_Z ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteordem_Z = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteordem_Z ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfitenome_Z = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfitenome_Z ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_Z = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_Z ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_Z = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_Z ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_Z = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_Z ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_Z = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_Z ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_Z = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_Z ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_Z = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_Z ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdel_Z = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdel_Z ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_Z = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_Z ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_Z = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_Z ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_Z = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_Z ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_Z = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_Z ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_Z = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_Z ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_N = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_N ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_N = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_N ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_N = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_N ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_N = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_N ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_N = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_N ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_N = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_N ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_N = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_N ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_N = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_N ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_N = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_N ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_N = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_N ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_N = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_N ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_N = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_N ;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_N = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_N ;
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
         AddObjectProperty("NgfSeq", gxTv_SdtNegocioPJEstrutura_Fase_Ngfseq, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("NgfInsData", sDateCnv, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora;
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
         AddObjectProperty("NgfInsHora", sDateCnv, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora;
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
         AddObjectProperty("NgfInsDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NgfInsUsuID", gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid, false, includeNonInitialized);
         AddObjectProperty("NgfInsUsuID_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_N, false, includeNonInitialized);
         AddObjectProperty("NgfInsUsuNome", gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome, false, includeNonInitialized);
         AddObjectProperty("NgfInsUsuNome_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_N, false, includeNonInitialized);
         AddObjectProperty("NgfIteID", gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteid, false, includeNonInitialized);
         AddObjectProperty("NgfIteOrdem", gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteordem, false, includeNonInitialized);
         AddObjectProperty("NgfIteNome", gxTv_SdtNegocioPJEstrutura_Fase_Ngfitenome, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("NgfFimData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NgfFimData_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora;
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
         AddObjectProperty("NgfFimHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NgfFimHora_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_N, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora;
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
         AddObjectProperty("NgfFimDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NgfFimDataHora_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_N, false, includeNonInitialized);
         AddObjectProperty("NgfFimUsuID", gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid, false, includeNonInitialized);
         AddObjectProperty("NgfFimUsuID_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_N, false, includeNonInitialized);
         AddObjectProperty("NgfFimUsuNome", gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome, false, includeNonInitialized);
         AddObjectProperty("NgfFimUsuNome_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_N, false, includeNonInitialized);
         AddObjectProperty("NgfStatus", gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus, false, includeNonInitialized);
         AddObjectProperty("NgfStatus_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_N, false, includeNonInitialized);
         AddObjectProperty("NgfDel", gxTv_SdtNegocioPJEstrutura_Fase_Ngfdel, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora;
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
         AddObjectProperty("NgfDelDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NgfDelDataHora_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata;
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
         AddObjectProperty("NgfDelData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NgfDelData_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora;
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
         AddObjectProperty("NgfDelHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NgfDelHora_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_N, false, includeNonInitialized);
         AddObjectProperty("NgfDelUsuId", gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid, false, includeNonInitialized);
         AddObjectProperty("NgfDelUsuId_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_N, false, includeNonInitialized);
         AddObjectProperty("NgfDelUsuNome", gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome, false, includeNonInitialized);
         AddObjectProperty("NgfDelUsuNome_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtNegocioPJEstrutura_Fase_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtNegocioPJEstrutura_Fase_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtNegocioPJEstrutura_Fase_Initialized, false, includeNonInitialized);
            AddObjectProperty("NgfSeq_Z", gxTv_SdtNegocioPJEstrutura_Fase_Ngfseq_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("NgfInsData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora_Z;
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
            AddObjectProperty("NgfInsHora_Z", sDateCnv, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora_Z;
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
            AddObjectProperty("NgfInsDataHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("NgfInsUsuID_Z", gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_Z, false, includeNonInitialized);
            AddObjectProperty("NgfInsUsuNome_Z", gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_Z, false, includeNonInitialized);
            AddObjectProperty("NgfIteID_Z", gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteid_Z, false, includeNonInitialized);
            AddObjectProperty("NgfIteOrdem_Z", gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteordem_Z, false, includeNonInitialized);
            AddObjectProperty("NgfIteNome_Z", gxTv_SdtNegocioPJEstrutura_Fase_Ngfitenome_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("NgfFimData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_Z;
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
            AddObjectProperty("NgfFimHora_Z", sDateCnv, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_Z;
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
            AddObjectProperty("NgfFimDataHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("NgfFimUsuID_Z", gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_Z, false, includeNonInitialized);
            AddObjectProperty("NgfFimUsuNome_Z", gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_Z, false, includeNonInitialized);
            AddObjectProperty("NgfStatus_Z", gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_Z, false, includeNonInitialized);
            AddObjectProperty("NgfDel_Z", gxTv_SdtNegocioPJEstrutura_Fase_Ngfdel_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_Z;
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
            AddObjectProperty("NgfDelDataHora_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_Z;
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
            AddObjectProperty("NgfDelData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_Z;
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
            AddObjectProperty("NgfDelHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("NgfDelUsuId_Z", gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_Z, false, includeNonInitialized);
            AddObjectProperty("NgfDelUsuNome_Z", gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_Z, false, includeNonInitialized);
            AddObjectProperty("NgfInsUsuID_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_N, false, includeNonInitialized);
            AddObjectProperty("NgfInsUsuNome_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_N, false, includeNonInitialized);
            AddObjectProperty("NgfFimData_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_N, false, includeNonInitialized);
            AddObjectProperty("NgfFimHora_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_N, false, includeNonInitialized);
            AddObjectProperty("NgfFimDataHora_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_N, false, includeNonInitialized);
            AddObjectProperty("NgfFimUsuID_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_N, false, includeNonInitialized);
            AddObjectProperty("NgfFimUsuNome_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_N, false, includeNonInitialized);
            AddObjectProperty("NgfStatus_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_N, false, includeNonInitialized);
            AddObjectProperty("NgfDelDataHora_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_N, false, includeNonInitialized);
            AddObjectProperty("NgfDelData_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_N, false, includeNonInitialized);
            AddObjectProperty("NgfDelHora_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_N, false, includeNonInitialized);
            AddObjectProperty("NgfDelUsuId_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_N, false, includeNonInitialized);
            AddObjectProperty("NgfDelUsuNome_N", gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase sdt )
      {
         if ( sdt.IsDirty("NgfSeq") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfseq = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfseq ;
         }
         if ( sdt.IsDirty("NgfInsData") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata ;
         }
         if ( sdt.IsDirty("NgfInsHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora ;
         }
         if ( sdt.IsDirty("NgfInsDataHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora ;
         }
         if ( sdt.IsDirty("NgfInsUsuID") )
         {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid ;
         }
         if ( sdt.IsDirty("NgfInsUsuNome") )
         {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome ;
         }
         if ( sdt.IsDirty("NgfIteID") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteid = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteid ;
         }
         if ( sdt.IsDirty("NgfIteOrdem") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteordem = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteordem ;
         }
         if ( sdt.IsDirty("NgfIteNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfitenome = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfitenome ;
         }
         if ( sdt.IsDirty("NgfFimData") )
         {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata ;
         }
         if ( sdt.IsDirty("NgfFimHora") )
         {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora ;
         }
         if ( sdt.IsDirty("NgfFimDataHora") )
         {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora ;
         }
         if ( sdt.IsDirty("NgfFimUsuID") )
         {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid ;
         }
         if ( sdt.IsDirty("NgfFimUsuNome") )
         {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome ;
         }
         if ( sdt.IsDirty("NgfStatus") )
         {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus ;
         }
         if ( sdt.IsDirty("NgfDel") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdel = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdel ;
         }
         if ( sdt.IsDirty("NgfDelDataHora") )
         {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora ;
         }
         if ( sdt.IsDirty("NgfDelData") )
         {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata ;
         }
         if ( sdt.IsDirty("NgfDelHora") )
         {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora ;
         }
         if ( sdt.IsDirty("NgfDelUsuId") )
         {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid ;
         }
         if ( sdt.IsDirty("NgfDelUsuNome") )
         {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome = sdt.gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "NgfSeq" )]
      [  XmlElement( ElementName = "NgfSeq"   )]
      public int gxTpr_Ngfseq
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfseq ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfseq = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfseq");
         }

      }

      [  SoapElement( ElementName = "NgfInsData" )]
      [  XmlElement( ElementName = "NgfInsData"  , IsNullable=true )]
      public string gxTpr_Ngfinsdata_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngfinsdata
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfinsdata");
         }

      }

      [  SoapElement( ElementName = "NgfInsHora" )]
      [  XmlElement( ElementName = "NgfInsHora"  , IsNullable=true )]
      public string gxTpr_Ngfinshora_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngfinshora
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfinshora");
         }

      }

      [  SoapElement( ElementName = "NgfInsDataHora" )]
      [  XmlElement( ElementName = "NgfInsDataHora"  , IsNullable=true )]
      public string gxTpr_Ngfinsdatahora_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngfinsdatahora
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfinsdatahora");
         }

      }

      [  SoapElement( ElementName = "NgfInsUsuID" )]
      [  XmlElement( ElementName = "NgfInsUsuID"   )]
      public string gxTpr_Ngfinsusuid
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfinsusuid");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_N = 1;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid = "";
         SetDirty("Ngfinsusuid");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_N==1) ;
      }

      [  SoapElement( ElementName = "NgfInsUsuNome" )]
      [  XmlElement( ElementName = "NgfInsUsuNome"   )]
      public string gxTpr_Ngfinsusunome
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfinsusunome");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_N = 1;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome = "";
         SetDirty("Ngfinsusunome");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_N==1) ;
      }

      [  SoapElement( ElementName = "NgfIteID" )]
      [  XmlElement( ElementName = "NgfIteID"   )]
      public Guid gxTpr_Ngfiteid
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteid = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfiteid");
         }

      }

      [  SoapElement( ElementName = "NgfIteOrdem" )]
      [  XmlElement( ElementName = "NgfIteOrdem"   )]
      public int gxTpr_Ngfiteordem
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteordem ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteordem = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfiteordem");
         }

      }

      [  SoapElement( ElementName = "NgfIteNome" )]
      [  XmlElement( ElementName = "NgfIteNome"   )]
      public string gxTpr_Ngfitenome
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfitenome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfitenome = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfitenome");
         }

      }

      [  SoapElement( ElementName = "NgfFimData" )]
      [  XmlElement( ElementName = "NgfFimData"  , IsNullable=true )]
      public string gxTpr_Ngffimdata_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata).value ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngffimdata
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngffimdata");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_N = 1;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata = (DateTime)(DateTime.MinValue);
         SetDirty("Ngffimdata");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_N==1) ;
      }

      [  SoapElement( ElementName = "NgfFimHora" )]
      [  XmlElement( ElementName = "NgfFimHora"  , IsNullable=true )]
      public string gxTpr_Ngffimhora_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora).value ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngffimhora
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngffimhora");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_N = 1;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora = (DateTime)(DateTime.MinValue);
         SetDirty("Ngffimhora");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_N==1) ;
      }

      [  SoapElement( ElementName = "NgfFimDataHora" )]
      [  XmlElement( ElementName = "NgfFimDataHora"  , IsNullable=true )]
      public string gxTpr_Ngffimdatahora_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora, null, true).value ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngffimdatahora
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngffimdatahora");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_N = 1;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Ngffimdatahora");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_N==1) ;
      }

      [  SoapElement( ElementName = "NgfFimUsuID" )]
      [  XmlElement( ElementName = "NgfFimUsuID"   )]
      public string gxTpr_Ngffimusuid
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngffimusuid");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_N = 1;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid = "";
         SetDirty("Ngffimusuid");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_N==1) ;
      }

      [  SoapElement( ElementName = "NgfFimUsuNome" )]
      [  XmlElement( ElementName = "NgfFimUsuNome"   )]
      public string gxTpr_Ngffimusunome
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngffimusunome");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_N = 1;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome = "";
         SetDirty("Ngffimusunome");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_N==1) ;
      }

      [  SoapElement( ElementName = "NgfStatus" )]
      [  XmlElement( ElementName = "NgfStatus"   )]
      public string gxTpr_Ngfstatus
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfstatus");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_N = 1;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus = "";
         SetDirty("Ngfstatus");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_N==1) ;
      }

      [  SoapElement( ElementName = "NgfDel" )]
      [  XmlElement( ElementName = "NgfDel"   )]
      public bool gxTpr_Ngfdel
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfdel ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdel = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfdel");
         }

      }

      [  SoapElement( ElementName = "NgfDelDataHora" )]
      [  XmlElement( ElementName = "NgfDelDataHora"  , IsNullable=true )]
      public string gxTpr_Ngfdeldatahora_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora, null, true).value ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngfdeldatahora
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfdeldatahora");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_N = 1;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Ngfdeldatahora");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_N==1) ;
      }

      [  SoapElement( ElementName = "NgfDelData" )]
      [  XmlElement( ElementName = "NgfDelData"  , IsNullable=true )]
      public string gxTpr_Ngfdeldata_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata).value ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngfdeldata
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfdeldata");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_N = 1;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata = (DateTime)(DateTime.MinValue);
         SetDirty("Ngfdeldata");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_N==1) ;
      }

      [  SoapElement( ElementName = "NgfDelHora" )]
      [  XmlElement( ElementName = "NgfDelHora"  , IsNullable=true )]
      public string gxTpr_Ngfdelhora_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora).value ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngfdelhora
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfdelhora");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_N = 1;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora = (DateTime)(DateTime.MinValue);
         SetDirty("Ngfdelhora");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_N==1) ;
      }

      [  SoapElement( ElementName = "NgfDelUsuId" )]
      [  XmlElement( ElementName = "NgfDelUsuId"   )]
      public string gxTpr_Ngfdelusuid
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfdelusuid");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_N = 1;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid = "";
         SetDirty("Ngfdelusuid");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_N==1) ;
      }

      [  SoapElement( ElementName = "NgfDelUsuNome" )]
      [  XmlElement( ElementName = "NgfDelUsuNome"   )]
      public string gxTpr_Ngfdelusunome
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfdelusunome");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_N = 1;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome = "";
         SetDirty("Ngfdelusunome");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Mode_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Modified_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Initialized = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Initialized_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfSeq_Z" )]
      [  XmlElement( ElementName = "NgfSeq_Z"   )]
      public int gxTpr_Ngfseq_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfseq_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfseq_Z = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfseq_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfseq_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfseq_Z = 0;
         SetDirty("Ngfseq_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfseq_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfInsData_Z" )]
      [  XmlElement( ElementName = "NgfInsData_Z"  , IsNullable=true )]
      public string gxTpr_Ngfinsdata_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata_Z = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngfinsdata_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata_Z = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfinsdata_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Ngfinsdata_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfInsHora_Z" )]
      [  XmlElement( ElementName = "NgfInsHora_Z"  , IsNullable=true )]
      public string gxTpr_Ngfinshora_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora_Z = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngfinshora_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora_Z = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfinshora_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Ngfinshora_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfInsDataHora_Z" )]
      [  XmlElement( ElementName = "NgfInsDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Ngfinsdatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora_Z = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngfinsdatahora_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora_Z = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfinsdatahora_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Ngfinsdatahora_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfInsUsuID_Z" )]
      [  XmlElement( ElementName = "NgfInsUsuID_Z"   )]
      public string gxTpr_Ngfinsusuid_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_Z = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfinsusuid_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_Z = "";
         SetDirty("Ngfinsusuid_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfInsUsuNome_Z" )]
      [  XmlElement( ElementName = "NgfInsUsuNome_Z"   )]
      public string gxTpr_Ngfinsusunome_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_Z = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfinsusunome_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_Z = "";
         SetDirty("Ngfinsusunome_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfIteID_Z" )]
      [  XmlElement( ElementName = "NgfIteID_Z"   )]
      public Guid gxTpr_Ngfiteid_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteid_Z = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfiteid_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteid_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteid_Z = Guid.Empty;
         SetDirty("Ngfiteid_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfIteOrdem_Z" )]
      [  XmlElement( ElementName = "NgfIteOrdem_Z"   )]
      public int gxTpr_Ngfiteordem_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteordem_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteordem_Z = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfiteordem_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteordem_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteordem_Z = 0;
         SetDirty("Ngfiteordem_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteordem_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfIteNome_Z" )]
      [  XmlElement( ElementName = "NgfIteNome_Z"   )]
      public string gxTpr_Ngfitenome_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfitenome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfitenome_Z = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfitenome_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfitenome_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfitenome_Z = "";
         SetDirty("Ngfitenome_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfitenome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfFimData_Z" )]
      [  XmlElement( ElementName = "NgfFimData_Z"  , IsNullable=true )]
      public string gxTpr_Ngffimdata_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_Z = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngffimdata_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_Z = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngffimdata_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Ngffimdata_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfFimHora_Z" )]
      [  XmlElement( ElementName = "NgfFimHora_Z"  , IsNullable=true )]
      public string gxTpr_Ngffimhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_Z = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngffimhora_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_Z = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngffimhora_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Ngffimhora_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfFimDataHora_Z" )]
      [  XmlElement( ElementName = "NgfFimDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Ngffimdatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_Z = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngffimdatahora_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_Z = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngffimdatahora_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Ngffimdatahora_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfFimUsuID_Z" )]
      [  XmlElement( ElementName = "NgfFimUsuID_Z"   )]
      public string gxTpr_Ngffimusuid_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_Z = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngffimusuid_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_Z = "";
         SetDirty("Ngffimusuid_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfFimUsuNome_Z" )]
      [  XmlElement( ElementName = "NgfFimUsuNome_Z"   )]
      public string gxTpr_Ngffimusunome_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_Z = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngffimusunome_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_Z = "";
         SetDirty("Ngffimusunome_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfStatus_Z" )]
      [  XmlElement( ElementName = "NgfStatus_Z"   )]
      public string gxTpr_Ngfstatus_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_Z = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfstatus_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_Z = "";
         SetDirty("Ngfstatus_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfDel_Z" )]
      [  XmlElement( ElementName = "NgfDel_Z"   )]
      public bool gxTpr_Ngfdel_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfdel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdel_Z = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfdel_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfdel_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdel_Z = false;
         SetDirty("Ngfdel_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfdel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfDelDataHora_Z" )]
      [  XmlElement( ElementName = "NgfDelDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Ngfdeldatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_Z = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngfdeldatahora_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_Z = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfdeldatahora_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Ngfdeldatahora_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfDelData_Z" )]
      [  XmlElement( ElementName = "NgfDelData_Z"  , IsNullable=true )]
      public string gxTpr_Ngfdeldata_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_Z = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngfdeldata_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_Z = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfdeldata_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Ngfdeldata_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfDelHora_Z" )]
      [  XmlElement( ElementName = "NgfDelHora_Z"  , IsNullable=true )]
      public string gxTpr_Ngfdelhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_Z = DateTime.Parse( value);
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ngfdelhora_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_Z = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfdelhora_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Ngfdelhora_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfDelUsuId_Z" )]
      [  XmlElement( ElementName = "NgfDelUsuId_Z"   )]
      public string gxTpr_Ngfdelusuid_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_Z = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfdelusuid_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_Z = "";
         SetDirty("Ngfdelusuid_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfDelUsuNome_Z" )]
      [  XmlElement( ElementName = "NgfDelUsuNome_Z"   )]
      public string gxTpr_Ngfdelusunome_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_Z = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfdelusunome_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_Z = "";
         SetDirty("Ngfdelusunome_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfInsUsuID_N" )]
      [  XmlElement( ElementName = "NgfInsUsuID_N"   )]
      public short gxTpr_Ngfinsusuid_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_N = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfinsusuid_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_N = 0;
         SetDirty("Ngfinsusuid_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfInsUsuNome_N" )]
      [  XmlElement( ElementName = "NgfInsUsuNome_N"   )]
      public short gxTpr_Ngfinsusunome_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_N = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfinsusunome_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_N = 0;
         SetDirty("Ngfinsusunome_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfFimData_N" )]
      [  XmlElement( ElementName = "NgfFimData_N"   )]
      public short gxTpr_Ngffimdata_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_N = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngffimdata_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_N = 0;
         SetDirty("Ngffimdata_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfFimHora_N" )]
      [  XmlElement( ElementName = "NgfFimHora_N"   )]
      public short gxTpr_Ngffimhora_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_N = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngffimhora_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_N = 0;
         SetDirty("Ngffimhora_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfFimDataHora_N" )]
      [  XmlElement( ElementName = "NgfFimDataHora_N"   )]
      public short gxTpr_Ngffimdatahora_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_N = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngffimdatahora_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_N = 0;
         SetDirty("Ngffimdatahora_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfFimUsuID_N" )]
      [  XmlElement( ElementName = "NgfFimUsuID_N"   )]
      public short gxTpr_Ngffimusuid_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_N = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngffimusuid_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_N = 0;
         SetDirty("Ngffimusuid_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfFimUsuNome_N" )]
      [  XmlElement( ElementName = "NgfFimUsuNome_N"   )]
      public short gxTpr_Ngffimusunome_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_N = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngffimusunome_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_N = 0;
         SetDirty("Ngffimusunome_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfStatus_N" )]
      [  XmlElement( ElementName = "NgfStatus_N"   )]
      public short gxTpr_Ngfstatus_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_N = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfstatus_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_N = 0;
         SetDirty("Ngfstatus_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfDelDataHora_N" )]
      [  XmlElement( ElementName = "NgfDelDataHora_N"   )]
      public short gxTpr_Ngfdeldatahora_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_N = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfdeldatahora_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_N = 0;
         SetDirty("Ngfdeldatahora_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfDelData_N" )]
      [  XmlElement( ElementName = "NgfDelData_N"   )]
      public short gxTpr_Ngfdeldata_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_N = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfdeldata_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_N = 0;
         SetDirty("Ngfdeldata_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfDelHora_N" )]
      [  XmlElement( ElementName = "NgfDelHora_N"   )]
      public short gxTpr_Ngfdelhora_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_N = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfdelhora_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_N = 0;
         SetDirty("Ngfdelhora_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfDelUsuId_N" )]
      [  XmlElement( ElementName = "NgfDelUsuId_N"   )]
      public short gxTpr_Ngfdelusuid_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_N = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfdelusuid_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_N = 0;
         SetDirty("Ngfdelusuid_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NgfDelUsuNome_N" )]
      [  XmlElement( ElementName = "NgfDelUsuNome_N"   )]
      public short gxTpr_Ngfdelusunome_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_N = value;
            gxTv_SdtNegocioPJEstrutura_Fase_Modified = 1;
            SetDirty("Ngfdelusunome_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_N = 0;
         SetDirty("Ngfdelusunome_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata = DateTime.MinValue;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid = "";
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome = "";
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteid = Guid.Empty;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfitenome = "";
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata = DateTime.MinValue;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid = "";
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome = "";
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus = "";
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid = "";
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome = "";
         gxTv_SdtNegocioPJEstrutura_Fase_Mode = "";
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata_Z = DateTime.MinValue;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_Z = "";
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_Z = "";
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteid_Z = Guid.Empty;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfitenome_Z = "";
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_Z = DateTime.MinValue;
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_Z = "";
         gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_Z = "";
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_Z = "";
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_Z = "";
         gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_Z = "";
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
      private short gxTv_SdtNegocioPJEstrutura_Fase_Modified ;
      private short gxTv_SdtNegocioPJEstrutura_Fase_Initialized ;
      private short gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_N ;
      private short gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_N ;
      private short gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_N ;
      private short gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_N ;
      private short gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_N ;
      private short gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_N ;
      private short gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_N ;
      private short gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_N ;
      private short gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_N ;
      private short gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_N ;
      private short gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_N ;
      private short gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_N ;
      private short gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_N ;
      private int gxTv_SdtNegocioPJEstrutura_Fase_Ngfseq ;
      private int gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteordem ;
      private int gxTv_SdtNegocioPJEstrutura_Fase_Ngfseq_Z ;
      private int gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteordem_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid ;
      private string gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid ;
      private string gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid ;
      private string gxTv_SdtNegocioPJEstrutura_Fase_Mode ;
      private string gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusuid_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusuid_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusuid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Fase_Ngfinshora_Z ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdatahora_Z ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Fase_Ngffimhora_Z ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdatahora_Z ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldatahora_Z ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Fase_Ngfdeldata_Z ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelhora_Z ;
      private DateTime datetime_STZ ;
      private DateTime datetimemil_STZ ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsdata_Z ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Fase_Ngffimdata_Z ;
      private bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfdel ;
      private bool gxTv_SdtNegocioPJEstrutura_Fase_Ngfdel_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome ;
      private string gxTv_SdtNegocioPJEstrutura_Fase_Ngfitenome ;
      private string gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome ;
      private string gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus ;
      private string gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome ;
      private string gxTv_SdtNegocioPJEstrutura_Fase_Ngfinsusunome_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Fase_Ngfitenome_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Fase_Ngffimusunome_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Fase_Ngfstatus_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Fase_Ngfdelusunome_Z ;
      private Guid gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteid ;
      private Guid gxTv_SdtNegocioPJEstrutura_Fase_Ngfiteid_Z ;
   }

   [DataContract(Name = @"core\NegocioPJEstrutura.Fase", Namespace = "agl_tresorygroup")]
   public class SdtNegocioPJEstrutura_Fase_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase>
   {
      public SdtNegocioPJEstrutura_Fase_RESTInterface( ) : base()
      {
      }

      public SdtNegocioPJEstrutura_Fase_RESTInterface( GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NgfSeq" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Ngfseq
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Ngfseq), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Ngfseq = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "NgfInsData" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Ngfinsdata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Ngfinsdata) ;
         }

         set {
            sdt.gxTpr_Ngfinsdata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "NgfInsHora" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Ngfinshora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Ngfinshora) ;
         }

         set {
            GXt_dtime2 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Ngfinshora = GXt_dtime2;
         }

      }

      [DataMember( Name = "NgfInsDataHora" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Ngfinsdatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Ngfinsdatahora) ;
         }

         set {
            sdt.gxTpr_Ngfinsdatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "NgfInsUsuID" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Ngfinsusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Ngfinsusuid) ;
         }

         set {
            sdt.gxTpr_Ngfinsusuid = value;
         }

      }

      [DataMember( Name = "NgfInsUsuNome" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Ngfinsusunome
      {
         get {
            return sdt.gxTpr_Ngfinsusunome ;
         }

         set {
            sdt.gxTpr_Ngfinsusunome = value;
         }

      }

      [DataMember( Name = "NgfIteID" , Order = 6 )]
      [GxSeudo()]
      public Guid gxTpr_Ngfiteid
      {
         get {
            return sdt.gxTpr_Ngfiteid ;
         }

         set {
            sdt.gxTpr_Ngfiteid = value;
         }

      }

      [DataMember( Name = "NgfIteOrdem" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Ngfiteordem
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Ngfiteordem), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Ngfiteordem = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "NgfIteNome" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Ngfitenome
      {
         get {
            return sdt.gxTpr_Ngfitenome ;
         }

         set {
            sdt.gxTpr_Ngfitenome = value;
         }

      }

      [DataMember( Name = "NgfFimData" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Ngffimdata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Ngffimdata) ;
         }

         set {
            sdt.gxTpr_Ngffimdata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "NgfFimHora" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Ngffimhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Ngffimhora) ;
         }

         set {
            GXt_dtime2 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Ngffimhora = GXt_dtime2;
         }

      }

      [DataMember( Name = "NgfFimDataHora" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Ngffimdatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Ngffimdatahora) ;
         }

         set {
            sdt.gxTpr_Ngffimdatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "NgfFimUsuID" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Ngffimusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Ngffimusuid) ;
         }

         set {
            sdt.gxTpr_Ngffimusuid = value;
         }

      }

      [DataMember( Name = "NgfFimUsuNome" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Ngffimusunome
      {
         get {
            return sdt.gxTpr_Ngffimusunome ;
         }

         set {
            sdt.gxTpr_Ngffimusunome = value;
         }

      }

      [DataMember( Name = "NgfStatus" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Ngfstatus
      {
         get {
            return sdt.gxTpr_Ngfstatus ;
         }

         set {
            sdt.gxTpr_Ngfstatus = value;
         }

      }

      [DataMember( Name = "NgfDel" , Order = 15 )]
      [GxSeudo()]
      public bool gxTpr_Ngfdel
      {
         get {
            return sdt.gxTpr_Ngfdel ;
         }

         set {
            sdt.gxTpr_Ngfdel = value;
         }

      }

      [DataMember( Name = "NgfDelDataHora" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Ngfdeldatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Ngfdeldatahora) ;
         }

         set {
            sdt.gxTpr_Ngfdeldatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "NgfDelData" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Ngfdeldata
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Ngfdeldata) ;
         }

         set {
            sdt.gxTpr_Ngfdeldata = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "NgfDelHora" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Ngfdelhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Ngfdelhora) ;
         }

         set {
            GXt_dtime2 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Ngfdelhora = GXt_dtime2;
         }

      }

      [DataMember( Name = "NgfDelUsuId" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Ngfdelusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Ngfdelusuid) ;
         }

         set {
            sdt.gxTpr_Ngfdelusuid = value;
         }

      }

      [DataMember( Name = "NgfDelUsuNome" , Order = 20 )]
      [GxSeudo()]
      public string gxTpr_Ngfdelusunome
      {
         get {
            return sdt.gxTpr_Ngfdelusunome ;
         }

         set {
            sdt.gxTpr_Ngfdelusunome = value;
         }

      }

      public GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase sdt
      {
         get {
            return (GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase() ;
         }
      }

      private DateTime GXt_dtime2 ;
   }

   [DataContract(Name = @"core\NegocioPJEstrutura.Fase", Namespace = "agl_tresorygroup")]
   public class SdtNegocioPJEstrutura_Fase_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase>
   {
      public SdtNegocioPJEstrutura_Fase_RESTLInterface( ) : base()
      {
      }

      public SdtNegocioPJEstrutura_Fase_RESTLInterface( GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase psdt ) : base(psdt)
      {
      }

      public GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase sdt
      {
         get {
            return (GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase() ;
         }
      }

   }

}
