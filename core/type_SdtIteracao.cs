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
   [XmlRoot(ElementName = "Iteracao" )]
   [XmlType(TypeName =  "Iteracao" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class SdtIteracao : GxSilentTrnSdt
   {
      public SdtIteracao( )
      {
      }

      public SdtIteracao( IGxContext context )
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

      public void Load( Guid AV381IteID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV381IteID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"IteID", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "core\\Iteracao");
         metadata.Set("BT", "tb_Iteracao");
         metadata.Set("PK", "[ \"IteID\" ]");
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
         state.Add("gxTpr_Iteid_Z");
         state.Add("gxTpr_Iteordem_Z");
         state.Add("gxTpr_Itenome_Z");
         state.Add("gxTpr_Iteativo_Z");
         state.Add("gxTpr_Itetotaloportunidades_Z");
         state.Add("gxTpr_Iteqtdeoportunidades_Z");
         state.Add("gxTpr_Itedel_Z");
         state.Add("gxTpr_Itedeldatahora_Z_Nullable");
         state.Add("gxTpr_Itedeldata_Z_Nullable");
         state.Add("gxTpr_Itedelhora_Z_Nullable");
         state.Add("gxTpr_Itedelusuid_Z");
         state.Add("gxTpr_Itedelusunome_Z");
         state.Add("gxTpr_Itedeldatahora_N");
         state.Add("gxTpr_Itedeldata_N");
         state.Add("gxTpr_Itedelhora_N");
         state.Add("gxTpr_Itedelusuid_N");
         state.Add("gxTpr_Itedelusunome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.SdtIteracao sdt;
         sdt = (GeneXus.Programs.core.SdtIteracao)(source);
         gxTv_SdtIteracao_Iteid = sdt.gxTv_SdtIteracao_Iteid ;
         gxTv_SdtIteracao_Iteordem = sdt.gxTv_SdtIteracao_Iteordem ;
         gxTv_SdtIteracao_Itenome = sdt.gxTv_SdtIteracao_Itenome ;
         gxTv_SdtIteracao_Iteativo = sdt.gxTv_SdtIteracao_Iteativo ;
         gxTv_SdtIteracao_Itetotaloportunidades = sdt.gxTv_SdtIteracao_Itetotaloportunidades ;
         gxTv_SdtIteracao_Iteqtdeoportunidades = sdt.gxTv_SdtIteracao_Iteqtdeoportunidades ;
         gxTv_SdtIteracao_Itedel = sdt.gxTv_SdtIteracao_Itedel ;
         gxTv_SdtIteracao_Itedeldatahora = sdt.gxTv_SdtIteracao_Itedeldatahora ;
         gxTv_SdtIteracao_Itedeldata = sdt.gxTv_SdtIteracao_Itedeldata ;
         gxTv_SdtIteracao_Itedelhora = sdt.gxTv_SdtIteracao_Itedelhora ;
         gxTv_SdtIteracao_Itedelusuid = sdt.gxTv_SdtIteracao_Itedelusuid ;
         gxTv_SdtIteracao_Itedelusunome = sdt.gxTv_SdtIteracao_Itedelusunome ;
         gxTv_SdtIteracao_Mode = sdt.gxTv_SdtIteracao_Mode ;
         gxTv_SdtIteracao_Initialized = sdt.gxTv_SdtIteracao_Initialized ;
         gxTv_SdtIteracao_Iteid_Z = sdt.gxTv_SdtIteracao_Iteid_Z ;
         gxTv_SdtIteracao_Iteordem_Z = sdt.gxTv_SdtIteracao_Iteordem_Z ;
         gxTv_SdtIteracao_Itenome_Z = sdt.gxTv_SdtIteracao_Itenome_Z ;
         gxTv_SdtIteracao_Iteativo_Z = sdt.gxTv_SdtIteracao_Iteativo_Z ;
         gxTv_SdtIteracao_Itetotaloportunidades_Z = sdt.gxTv_SdtIteracao_Itetotaloportunidades_Z ;
         gxTv_SdtIteracao_Iteqtdeoportunidades_Z = sdt.gxTv_SdtIteracao_Iteqtdeoportunidades_Z ;
         gxTv_SdtIteracao_Itedel_Z = sdt.gxTv_SdtIteracao_Itedel_Z ;
         gxTv_SdtIteracao_Itedeldatahora_Z = sdt.gxTv_SdtIteracao_Itedeldatahora_Z ;
         gxTv_SdtIteracao_Itedeldata_Z = sdt.gxTv_SdtIteracao_Itedeldata_Z ;
         gxTv_SdtIteracao_Itedelhora_Z = sdt.gxTv_SdtIteracao_Itedelhora_Z ;
         gxTv_SdtIteracao_Itedelusuid_Z = sdt.gxTv_SdtIteracao_Itedelusuid_Z ;
         gxTv_SdtIteracao_Itedelusunome_Z = sdt.gxTv_SdtIteracao_Itedelusunome_Z ;
         gxTv_SdtIteracao_Itedeldatahora_N = sdt.gxTv_SdtIteracao_Itedeldatahora_N ;
         gxTv_SdtIteracao_Itedeldata_N = sdt.gxTv_SdtIteracao_Itedeldata_N ;
         gxTv_SdtIteracao_Itedelhora_N = sdt.gxTv_SdtIteracao_Itedelhora_N ;
         gxTv_SdtIteracao_Itedelusuid_N = sdt.gxTv_SdtIteracao_Itedelusuid_N ;
         gxTv_SdtIteracao_Itedelusunome_N = sdt.gxTv_SdtIteracao_Itedelusunome_N ;
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
         AddObjectProperty("IteID", gxTv_SdtIteracao_Iteid, false, includeNonInitialized);
         AddObjectProperty("IteOrdem", gxTv_SdtIteracao_Iteordem, false, includeNonInitialized);
         AddObjectProperty("IteNome", gxTv_SdtIteracao_Itenome, false, includeNonInitialized);
         AddObjectProperty("IteAtivo", gxTv_SdtIteracao_Iteativo, false, includeNonInitialized);
         AddObjectProperty("IteTotalOportunidades", StringUtil.LTrim( StringUtil.Str( gxTv_SdtIteracao_Itetotaloportunidades, 16, 2)), false, includeNonInitialized);
         AddObjectProperty("IteQtdeOportunidades", gxTv_SdtIteracao_Iteqtdeoportunidades, false, includeNonInitialized);
         AddObjectProperty("IteDel", gxTv_SdtIteracao_Itedel, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtIteracao_Itedeldatahora;
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
         AddObjectProperty("IteDelDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("IteDelDataHora_N", gxTv_SdtIteracao_Itedeldatahora_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtIteracao_Itedeldata;
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
         AddObjectProperty("IteDelData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("IteDelData_N", gxTv_SdtIteracao_Itedeldata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtIteracao_Itedelhora;
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
         AddObjectProperty("IteDelHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("IteDelHora_N", gxTv_SdtIteracao_Itedelhora_N, false, includeNonInitialized);
         AddObjectProperty("IteDelUsuId", gxTv_SdtIteracao_Itedelusuid, false, includeNonInitialized);
         AddObjectProperty("IteDelUsuId_N", gxTv_SdtIteracao_Itedelusuid_N, false, includeNonInitialized);
         AddObjectProperty("IteDelUsuNome", gxTv_SdtIteracao_Itedelusunome, false, includeNonInitialized);
         AddObjectProperty("IteDelUsuNome_N", gxTv_SdtIteracao_Itedelusunome_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtIteracao_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtIteracao_Initialized, false, includeNonInitialized);
            AddObjectProperty("IteID_Z", gxTv_SdtIteracao_Iteid_Z, false, includeNonInitialized);
            AddObjectProperty("IteOrdem_Z", gxTv_SdtIteracao_Iteordem_Z, false, includeNonInitialized);
            AddObjectProperty("IteNome_Z", gxTv_SdtIteracao_Itenome_Z, false, includeNonInitialized);
            AddObjectProperty("IteAtivo_Z", gxTv_SdtIteracao_Iteativo_Z, false, includeNonInitialized);
            AddObjectProperty("IteTotalOportunidades_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtIteracao_Itetotaloportunidades_Z, 16, 2)), false, includeNonInitialized);
            AddObjectProperty("IteQtdeOportunidades_Z", gxTv_SdtIteracao_Iteqtdeoportunidades_Z, false, includeNonInitialized);
            AddObjectProperty("IteDel_Z", gxTv_SdtIteracao_Itedel_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtIteracao_Itedeldatahora_Z;
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
            AddObjectProperty("IteDelDataHora_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtIteracao_Itedeldata_Z;
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
            AddObjectProperty("IteDelData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtIteracao_Itedelhora_Z;
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
            AddObjectProperty("IteDelHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("IteDelUsuId_Z", gxTv_SdtIteracao_Itedelusuid_Z, false, includeNonInitialized);
            AddObjectProperty("IteDelUsuNome_Z", gxTv_SdtIteracao_Itedelusunome_Z, false, includeNonInitialized);
            AddObjectProperty("IteDelDataHora_N", gxTv_SdtIteracao_Itedeldatahora_N, false, includeNonInitialized);
            AddObjectProperty("IteDelData_N", gxTv_SdtIteracao_Itedeldata_N, false, includeNonInitialized);
            AddObjectProperty("IteDelHora_N", gxTv_SdtIteracao_Itedelhora_N, false, includeNonInitialized);
            AddObjectProperty("IteDelUsuId_N", gxTv_SdtIteracao_Itedelusuid_N, false, includeNonInitialized);
            AddObjectProperty("IteDelUsuNome_N", gxTv_SdtIteracao_Itedelusunome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.SdtIteracao sdt )
      {
         if ( sdt.IsDirty("IteID") )
         {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Iteid = sdt.gxTv_SdtIteracao_Iteid ;
         }
         if ( sdt.IsDirty("IteOrdem") )
         {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Iteordem = sdt.gxTv_SdtIteracao_Iteordem ;
         }
         if ( sdt.IsDirty("IteNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itenome = sdt.gxTv_SdtIteracao_Itenome ;
         }
         if ( sdt.IsDirty("IteAtivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Iteativo = sdt.gxTv_SdtIteracao_Iteativo ;
         }
         if ( sdt.IsDirty("IteTotalOportunidades") )
         {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itetotaloportunidades = sdt.gxTv_SdtIteracao_Itetotaloportunidades ;
         }
         if ( sdt.IsDirty("IteQtdeOportunidades") )
         {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Iteqtdeoportunidades = sdt.gxTv_SdtIteracao_Iteqtdeoportunidades ;
         }
         if ( sdt.IsDirty("IteDel") )
         {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itedel = sdt.gxTv_SdtIteracao_Itedel ;
         }
         if ( sdt.IsDirty("IteDelDataHora") )
         {
            gxTv_SdtIteracao_Itedeldatahora_N = (short)(sdt.gxTv_SdtIteracao_Itedeldatahora_N);
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itedeldatahora = sdt.gxTv_SdtIteracao_Itedeldatahora ;
         }
         if ( sdt.IsDirty("IteDelData") )
         {
            gxTv_SdtIteracao_Itedeldata_N = (short)(sdt.gxTv_SdtIteracao_Itedeldata_N);
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itedeldata = sdt.gxTv_SdtIteracao_Itedeldata ;
         }
         if ( sdt.IsDirty("IteDelHora") )
         {
            gxTv_SdtIteracao_Itedelhora_N = (short)(sdt.gxTv_SdtIteracao_Itedelhora_N);
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itedelhora = sdt.gxTv_SdtIteracao_Itedelhora ;
         }
         if ( sdt.IsDirty("IteDelUsuId") )
         {
            gxTv_SdtIteracao_Itedelusuid_N = (short)(sdt.gxTv_SdtIteracao_Itedelusuid_N);
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itedelusuid = sdt.gxTv_SdtIteracao_Itedelusuid ;
         }
         if ( sdt.IsDirty("IteDelUsuNome") )
         {
            gxTv_SdtIteracao_Itedelusunome_N = (short)(sdt.gxTv_SdtIteracao_Itedelusunome_N);
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itedelusunome = sdt.gxTv_SdtIteracao_Itedelusunome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "IteID" )]
      [  XmlElement( ElementName = "IteID"   )]
      public Guid gxTpr_Iteid
      {
         get {
            return gxTv_SdtIteracao_Iteid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtIteracao_Iteid != value )
            {
               gxTv_SdtIteracao_Mode = "INS";
               this.gxTv_SdtIteracao_Iteid_Z_SetNull( );
               this.gxTv_SdtIteracao_Iteordem_Z_SetNull( );
               this.gxTv_SdtIteracao_Itenome_Z_SetNull( );
               this.gxTv_SdtIteracao_Iteativo_Z_SetNull( );
               this.gxTv_SdtIteracao_Itetotaloportunidades_Z_SetNull( );
               this.gxTv_SdtIteracao_Iteqtdeoportunidades_Z_SetNull( );
               this.gxTv_SdtIteracao_Itedel_Z_SetNull( );
               this.gxTv_SdtIteracao_Itedeldatahora_Z_SetNull( );
               this.gxTv_SdtIteracao_Itedeldata_Z_SetNull( );
               this.gxTv_SdtIteracao_Itedelhora_Z_SetNull( );
               this.gxTv_SdtIteracao_Itedelusuid_Z_SetNull( );
               this.gxTv_SdtIteracao_Itedelusunome_Z_SetNull( );
            }
            gxTv_SdtIteracao_Iteid = value;
            SetDirty("Iteid");
         }

      }

      [  SoapElement( ElementName = "IteOrdem" )]
      [  XmlElement( ElementName = "IteOrdem"   )]
      public int gxTpr_Iteordem
      {
         get {
            return gxTv_SdtIteracao_Iteordem ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Iteordem = value;
            SetDirty("Iteordem");
         }

      }

      [  SoapElement( ElementName = "IteNome" )]
      [  XmlElement( ElementName = "IteNome"   )]
      public string gxTpr_Itenome
      {
         get {
            return gxTv_SdtIteracao_Itenome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itenome = value;
            SetDirty("Itenome");
         }

      }

      [  SoapElement( ElementName = "IteAtivo" )]
      [  XmlElement( ElementName = "IteAtivo"   )]
      public bool gxTpr_Iteativo
      {
         get {
            return gxTv_SdtIteracao_Iteativo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Iteativo = value;
            SetDirty("Iteativo");
         }

      }

      [  SoapElement( ElementName = "IteTotalOportunidades" )]
      [  XmlElement( ElementName = "IteTotalOportunidades"   )]
      public decimal gxTpr_Itetotaloportunidades
      {
         get {
            return gxTv_SdtIteracao_Itetotaloportunidades ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itetotaloportunidades = value;
            SetDirty("Itetotaloportunidades");
         }

      }

      public void gxTv_SdtIteracao_Itetotaloportunidades_SetNull( )
      {
         gxTv_SdtIteracao_Itetotaloportunidades = 0;
         SetDirty("Itetotaloportunidades");
         return  ;
      }

      public bool gxTv_SdtIteracao_Itetotaloportunidades_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IteQtdeOportunidades" )]
      [  XmlElement( ElementName = "IteQtdeOportunidades"   )]
      public int gxTpr_Iteqtdeoportunidades
      {
         get {
            return gxTv_SdtIteracao_Iteqtdeoportunidades ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Iteqtdeoportunidades = value;
            SetDirty("Iteqtdeoportunidades");
         }

      }

      public void gxTv_SdtIteracao_Iteqtdeoportunidades_SetNull( )
      {
         gxTv_SdtIteracao_Iteqtdeoportunidades = 0;
         SetDirty("Iteqtdeoportunidades");
         return  ;
      }

      public bool gxTv_SdtIteracao_Iteqtdeoportunidades_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IteDel" )]
      [  XmlElement( ElementName = "IteDel"   )]
      public bool gxTpr_Itedel
      {
         get {
            return gxTv_SdtIteracao_Itedel ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itedel = value;
            SetDirty("Itedel");
         }

      }

      [  SoapElement( ElementName = "IteDelDataHora" )]
      [  XmlElement( ElementName = "IteDelDataHora"  , IsNullable=true )]
      public string gxTpr_Itedeldatahora_Nullable
      {
         get {
            if ( gxTv_SdtIteracao_Itedeldatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtIteracao_Itedeldatahora, null, true).value ;
         }

         set {
            gxTv_SdtIteracao_Itedeldatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtIteracao_Itedeldatahora = DateTime.MinValue;
            else
               gxTv_SdtIteracao_Itedeldatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Itedeldatahora
      {
         get {
            return gxTv_SdtIteracao_Itedeldatahora ;
         }

         set {
            gxTv_SdtIteracao_Itedeldatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itedeldatahora = value;
            SetDirty("Itedeldatahora");
         }

      }

      public void gxTv_SdtIteracao_Itedeldatahora_SetNull( )
      {
         gxTv_SdtIteracao_Itedeldatahora_N = 1;
         gxTv_SdtIteracao_Itedeldatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Itedeldatahora");
         return  ;
      }

      public bool gxTv_SdtIteracao_Itedeldatahora_IsNull( )
      {
         return (gxTv_SdtIteracao_Itedeldatahora_N==1) ;
      }

      [  SoapElement( ElementName = "IteDelData" )]
      [  XmlElement( ElementName = "IteDelData"  , IsNullable=true )]
      public string gxTpr_Itedeldata_Nullable
      {
         get {
            if ( gxTv_SdtIteracao_Itedeldata == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtIteracao_Itedeldata).value ;
         }

         set {
            gxTv_SdtIteracao_Itedeldata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtIteracao_Itedeldata = DateTime.MinValue;
            else
               gxTv_SdtIteracao_Itedeldata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Itedeldata
      {
         get {
            return gxTv_SdtIteracao_Itedeldata ;
         }

         set {
            gxTv_SdtIteracao_Itedeldata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itedeldata = value;
            SetDirty("Itedeldata");
         }

      }

      public void gxTv_SdtIteracao_Itedeldata_SetNull( )
      {
         gxTv_SdtIteracao_Itedeldata_N = 1;
         gxTv_SdtIteracao_Itedeldata = (DateTime)(DateTime.MinValue);
         SetDirty("Itedeldata");
         return  ;
      }

      public bool gxTv_SdtIteracao_Itedeldata_IsNull( )
      {
         return (gxTv_SdtIteracao_Itedeldata_N==1) ;
      }

      [  SoapElement( ElementName = "IteDelHora" )]
      [  XmlElement( ElementName = "IteDelHora"  , IsNullable=true )]
      public string gxTpr_Itedelhora_Nullable
      {
         get {
            if ( gxTv_SdtIteracao_Itedelhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtIteracao_Itedelhora).value ;
         }

         set {
            gxTv_SdtIteracao_Itedelhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtIteracao_Itedelhora = DateTime.MinValue;
            else
               gxTv_SdtIteracao_Itedelhora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Itedelhora
      {
         get {
            return gxTv_SdtIteracao_Itedelhora ;
         }

         set {
            gxTv_SdtIteracao_Itedelhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itedelhora = value;
            SetDirty("Itedelhora");
         }

      }

      public void gxTv_SdtIteracao_Itedelhora_SetNull( )
      {
         gxTv_SdtIteracao_Itedelhora_N = 1;
         gxTv_SdtIteracao_Itedelhora = (DateTime)(DateTime.MinValue);
         SetDirty("Itedelhora");
         return  ;
      }

      public bool gxTv_SdtIteracao_Itedelhora_IsNull( )
      {
         return (gxTv_SdtIteracao_Itedelhora_N==1) ;
      }

      [  SoapElement( ElementName = "IteDelUsuId" )]
      [  XmlElement( ElementName = "IteDelUsuId"   )]
      public string gxTpr_Itedelusuid
      {
         get {
            return gxTv_SdtIteracao_Itedelusuid ;
         }

         set {
            gxTv_SdtIteracao_Itedelusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itedelusuid = value;
            SetDirty("Itedelusuid");
         }

      }

      public void gxTv_SdtIteracao_Itedelusuid_SetNull( )
      {
         gxTv_SdtIteracao_Itedelusuid_N = 1;
         gxTv_SdtIteracao_Itedelusuid = "";
         SetDirty("Itedelusuid");
         return  ;
      }

      public bool gxTv_SdtIteracao_Itedelusuid_IsNull( )
      {
         return (gxTv_SdtIteracao_Itedelusuid_N==1) ;
      }

      [  SoapElement( ElementName = "IteDelUsuNome" )]
      [  XmlElement( ElementName = "IteDelUsuNome"   )]
      public string gxTpr_Itedelusunome
      {
         get {
            return gxTv_SdtIteracao_Itedelusunome ;
         }

         set {
            gxTv_SdtIteracao_Itedelusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itedelusunome = value;
            SetDirty("Itedelusunome");
         }

      }

      public void gxTv_SdtIteracao_Itedelusunome_SetNull( )
      {
         gxTv_SdtIteracao_Itedelusunome_N = 1;
         gxTv_SdtIteracao_Itedelusunome = "";
         SetDirty("Itedelusunome");
         return  ;
      }

      public bool gxTv_SdtIteracao_Itedelusunome_IsNull( )
      {
         return (gxTv_SdtIteracao_Itedelusunome_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtIteracao_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtIteracao_Mode_SetNull( )
      {
         gxTv_SdtIteracao_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtIteracao_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtIteracao_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtIteracao_Initialized_SetNull( )
      {
         gxTv_SdtIteracao_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtIteracao_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IteID_Z" )]
      [  XmlElement( ElementName = "IteID_Z"   )]
      public Guid gxTpr_Iteid_Z
      {
         get {
            return gxTv_SdtIteracao_Iteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Iteid_Z = value;
            SetDirty("Iteid_Z");
         }

      }

      public void gxTv_SdtIteracao_Iteid_Z_SetNull( )
      {
         gxTv_SdtIteracao_Iteid_Z = Guid.Empty;
         SetDirty("Iteid_Z");
         return  ;
      }

      public bool gxTv_SdtIteracao_Iteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IteOrdem_Z" )]
      [  XmlElement( ElementName = "IteOrdem_Z"   )]
      public int gxTpr_Iteordem_Z
      {
         get {
            return gxTv_SdtIteracao_Iteordem_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Iteordem_Z = value;
            SetDirty("Iteordem_Z");
         }

      }

      public void gxTv_SdtIteracao_Iteordem_Z_SetNull( )
      {
         gxTv_SdtIteracao_Iteordem_Z = 0;
         SetDirty("Iteordem_Z");
         return  ;
      }

      public bool gxTv_SdtIteracao_Iteordem_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IteNome_Z" )]
      [  XmlElement( ElementName = "IteNome_Z"   )]
      public string gxTpr_Itenome_Z
      {
         get {
            return gxTv_SdtIteracao_Itenome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itenome_Z = value;
            SetDirty("Itenome_Z");
         }

      }

      public void gxTv_SdtIteracao_Itenome_Z_SetNull( )
      {
         gxTv_SdtIteracao_Itenome_Z = "";
         SetDirty("Itenome_Z");
         return  ;
      }

      public bool gxTv_SdtIteracao_Itenome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IteAtivo_Z" )]
      [  XmlElement( ElementName = "IteAtivo_Z"   )]
      public bool gxTpr_Iteativo_Z
      {
         get {
            return gxTv_SdtIteracao_Iteativo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Iteativo_Z = value;
            SetDirty("Iteativo_Z");
         }

      }

      public void gxTv_SdtIteracao_Iteativo_Z_SetNull( )
      {
         gxTv_SdtIteracao_Iteativo_Z = false;
         SetDirty("Iteativo_Z");
         return  ;
      }

      public bool gxTv_SdtIteracao_Iteativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IteTotalOportunidades_Z" )]
      [  XmlElement( ElementName = "IteTotalOportunidades_Z"   )]
      public decimal gxTpr_Itetotaloportunidades_Z
      {
         get {
            return gxTv_SdtIteracao_Itetotaloportunidades_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itetotaloportunidades_Z = value;
            SetDirty("Itetotaloportunidades_Z");
         }

      }

      public void gxTv_SdtIteracao_Itetotaloportunidades_Z_SetNull( )
      {
         gxTv_SdtIteracao_Itetotaloportunidades_Z = 0;
         SetDirty("Itetotaloportunidades_Z");
         return  ;
      }

      public bool gxTv_SdtIteracao_Itetotaloportunidades_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IteQtdeOportunidades_Z" )]
      [  XmlElement( ElementName = "IteQtdeOportunidades_Z"   )]
      public int gxTpr_Iteqtdeoportunidades_Z
      {
         get {
            return gxTv_SdtIteracao_Iteqtdeoportunidades_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Iteqtdeoportunidades_Z = value;
            SetDirty("Iteqtdeoportunidades_Z");
         }

      }

      public void gxTv_SdtIteracao_Iteqtdeoportunidades_Z_SetNull( )
      {
         gxTv_SdtIteracao_Iteqtdeoportunidades_Z = 0;
         SetDirty("Iteqtdeoportunidades_Z");
         return  ;
      }

      public bool gxTv_SdtIteracao_Iteqtdeoportunidades_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IteDel_Z" )]
      [  XmlElement( ElementName = "IteDel_Z"   )]
      public bool gxTpr_Itedel_Z
      {
         get {
            return gxTv_SdtIteracao_Itedel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itedel_Z = value;
            SetDirty("Itedel_Z");
         }

      }

      public void gxTv_SdtIteracao_Itedel_Z_SetNull( )
      {
         gxTv_SdtIteracao_Itedel_Z = false;
         SetDirty("Itedel_Z");
         return  ;
      }

      public bool gxTv_SdtIteracao_Itedel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IteDelDataHora_Z" )]
      [  XmlElement( ElementName = "IteDelDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Itedeldatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtIteracao_Itedeldatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtIteracao_Itedeldatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtIteracao_Itedeldatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtIteracao_Itedeldatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Itedeldatahora_Z
      {
         get {
            return gxTv_SdtIteracao_Itedeldatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itedeldatahora_Z = value;
            SetDirty("Itedeldatahora_Z");
         }

      }

      public void gxTv_SdtIteracao_Itedeldatahora_Z_SetNull( )
      {
         gxTv_SdtIteracao_Itedeldatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Itedeldatahora_Z");
         return  ;
      }

      public bool gxTv_SdtIteracao_Itedeldatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IteDelData_Z" )]
      [  XmlElement( ElementName = "IteDelData_Z"  , IsNullable=true )]
      public string gxTpr_Itedeldata_Z_Nullable
      {
         get {
            if ( gxTv_SdtIteracao_Itedeldata_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtIteracao_Itedeldata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtIteracao_Itedeldata_Z = DateTime.MinValue;
            else
               gxTv_SdtIteracao_Itedeldata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Itedeldata_Z
      {
         get {
            return gxTv_SdtIteracao_Itedeldata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itedeldata_Z = value;
            SetDirty("Itedeldata_Z");
         }

      }

      public void gxTv_SdtIteracao_Itedeldata_Z_SetNull( )
      {
         gxTv_SdtIteracao_Itedeldata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Itedeldata_Z");
         return  ;
      }

      public bool gxTv_SdtIteracao_Itedeldata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IteDelHora_Z" )]
      [  XmlElement( ElementName = "IteDelHora_Z"  , IsNullable=true )]
      public string gxTpr_Itedelhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtIteracao_Itedelhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtIteracao_Itedelhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtIteracao_Itedelhora_Z = DateTime.MinValue;
            else
               gxTv_SdtIteracao_Itedelhora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Itedelhora_Z
      {
         get {
            return gxTv_SdtIteracao_Itedelhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itedelhora_Z = value;
            SetDirty("Itedelhora_Z");
         }

      }

      public void gxTv_SdtIteracao_Itedelhora_Z_SetNull( )
      {
         gxTv_SdtIteracao_Itedelhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Itedelhora_Z");
         return  ;
      }

      public bool gxTv_SdtIteracao_Itedelhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IteDelUsuId_Z" )]
      [  XmlElement( ElementName = "IteDelUsuId_Z"   )]
      public string gxTpr_Itedelusuid_Z
      {
         get {
            return gxTv_SdtIteracao_Itedelusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itedelusuid_Z = value;
            SetDirty("Itedelusuid_Z");
         }

      }

      public void gxTv_SdtIteracao_Itedelusuid_Z_SetNull( )
      {
         gxTv_SdtIteracao_Itedelusuid_Z = "";
         SetDirty("Itedelusuid_Z");
         return  ;
      }

      public bool gxTv_SdtIteracao_Itedelusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IteDelUsuNome_Z" )]
      [  XmlElement( ElementName = "IteDelUsuNome_Z"   )]
      public string gxTpr_Itedelusunome_Z
      {
         get {
            return gxTv_SdtIteracao_Itedelusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itedelusunome_Z = value;
            SetDirty("Itedelusunome_Z");
         }

      }

      public void gxTv_SdtIteracao_Itedelusunome_Z_SetNull( )
      {
         gxTv_SdtIteracao_Itedelusunome_Z = "";
         SetDirty("Itedelusunome_Z");
         return  ;
      }

      public bool gxTv_SdtIteracao_Itedelusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IteDelDataHora_N" )]
      [  XmlElement( ElementName = "IteDelDataHora_N"   )]
      public short gxTpr_Itedeldatahora_N
      {
         get {
            return gxTv_SdtIteracao_Itedeldatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itedeldatahora_N = value;
            SetDirty("Itedeldatahora_N");
         }

      }

      public void gxTv_SdtIteracao_Itedeldatahora_N_SetNull( )
      {
         gxTv_SdtIteracao_Itedeldatahora_N = 0;
         SetDirty("Itedeldatahora_N");
         return  ;
      }

      public bool gxTv_SdtIteracao_Itedeldatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IteDelData_N" )]
      [  XmlElement( ElementName = "IteDelData_N"   )]
      public short gxTpr_Itedeldata_N
      {
         get {
            return gxTv_SdtIteracao_Itedeldata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itedeldata_N = value;
            SetDirty("Itedeldata_N");
         }

      }

      public void gxTv_SdtIteracao_Itedeldata_N_SetNull( )
      {
         gxTv_SdtIteracao_Itedeldata_N = 0;
         SetDirty("Itedeldata_N");
         return  ;
      }

      public bool gxTv_SdtIteracao_Itedeldata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IteDelHora_N" )]
      [  XmlElement( ElementName = "IteDelHora_N"   )]
      public short gxTpr_Itedelhora_N
      {
         get {
            return gxTv_SdtIteracao_Itedelhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itedelhora_N = value;
            SetDirty("Itedelhora_N");
         }

      }

      public void gxTv_SdtIteracao_Itedelhora_N_SetNull( )
      {
         gxTv_SdtIteracao_Itedelhora_N = 0;
         SetDirty("Itedelhora_N");
         return  ;
      }

      public bool gxTv_SdtIteracao_Itedelhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IteDelUsuId_N" )]
      [  XmlElement( ElementName = "IteDelUsuId_N"   )]
      public short gxTpr_Itedelusuid_N
      {
         get {
            return gxTv_SdtIteracao_Itedelusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itedelusuid_N = value;
            SetDirty("Itedelusuid_N");
         }

      }

      public void gxTv_SdtIteracao_Itedelusuid_N_SetNull( )
      {
         gxTv_SdtIteracao_Itedelusuid_N = 0;
         SetDirty("Itedelusuid_N");
         return  ;
      }

      public bool gxTv_SdtIteracao_Itedelusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IteDelUsuNome_N" )]
      [  XmlElement( ElementName = "IteDelUsuNome_N"   )]
      public short gxTpr_Itedelusunome_N
      {
         get {
            return gxTv_SdtIteracao_Itedelusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtIteracao_Itedelusunome_N = value;
            SetDirty("Itedelusunome_N");
         }

      }

      public void gxTv_SdtIteracao_Itedelusunome_N_SetNull( )
      {
         gxTv_SdtIteracao_Itedelusunome_N = 0;
         SetDirty("Itedelusunome_N");
         return  ;
      }

      public bool gxTv_SdtIteracao_Itedelusunome_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtIteracao_Iteid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtIteracao_Itenome = "";
         gxTv_SdtIteracao_Iteativo = true;
         gxTv_SdtIteracao_Itedeldatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtIteracao_Itedeldata = (DateTime)(DateTime.MinValue);
         gxTv_SdtIteracao_Itedelhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtIteracao_Itedelusuid = "";
         gxTv_SdtIteracao_Itedelusunome = "";
         gxTv_SdtIteracao_Mode = "";
         gxTv_SdtIteracao_Iteid_Z = Guid.Empty;
         gxTv_SdtIteracao_Itenome_Z = "";
         gxTv_SdtIteracao_Itedeldatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtIteracao_Itedeldata_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtIteracao_Itedelhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtIteracao_Itedelusuid_Z = "";
         gxTv_SdtIteracao_Itedelusunome_Z = "";
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "core.iteracao", "GeneXus.Programs.core.iteracao_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtIteracao_Initialized ;
      private short gxTv_SdtIteracao_Itedeldatahora_N ;
      private short gxTv_SdtIteracao_Itedeldata_N ;
      private short gxTv_SdtIteracao_Itedelhora_N ;
      private short gxTv_SdtIteracao_Itedelusuid_N ;
      private short gxTv_SdtIteracao_Itedelusunome_N ;
      private int gxTv_SdtIteracao_Iteordem ;
      private int gxTv_SdtIteracao_Iteqtdeoportunidades ;
      private int gxTv_SdtIteracao_Iteordem_Z ;
      private int gxTv_SdtIteracao_Iteqtdeoportunidades_Z ;
      private decimal gxTv_SdtIteracao_Itetotaloportunidades ;
      private decimal gxTv_SdtIteracao_Itetotaloportunidades_Z ;
      private string gxTv_SdtIteracao_Itedelusuid ;
      private string gxTv_SdtIteracao_Mode ;
      private string gxTv_SdtIteracao_Itedelusuid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtIteracao_Itedeldatahora ;
      private DateTime gxTv_SdtIteracao_Itedeldata ;
      private DateTime gxTv_SdtIteracao_Itedelhora ;
      private DateTime gxTv_SdtIteracao_Itedeldatahora_Z ;
      private DateTime gxTv_SdtIteracao_Itedeldata_Z ;
      private DateTime gxTv_SdtIteracao_Itedelhora_Z ;
      private DateTime datetimemil_STZ ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtIteracao_Iteativo ;
      private bool gxTv_SdtIteracao_Itedel ;
      private bool gxTv_SdtIteracao_Iteativo_Z ;
      private bool gxTv_SdtIteracao_Itedel_Z ;
      private string gxTv_SdtIteracao_Itenome ;
      private string gxTv_SdtIteracao_Itedelusunome ;
      private string gxTv_SdtIteracao_Itenome_Z ;
      private string gxTv_SdtIteracao_Itedelusunome_Z ;
      private Guid gxTv_SdtIteracao_Iteid ;
      private Guid gxTv_SdtIteracao_Iteid_Z ;
   }

   [DataContract(Name = @"core\Iteracao", Namespace = "agl_tresorygroup")]
   public class SdtIteracao_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtIteracao>
   {
      public SdtIteracao_RESTInterface( ) : base()
      {
      }

      public SdtIteracao_RESTInterface( GeneXus.Programs.core.SdtIteracao psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "IteID" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Iteid
      {
         get {
            return sdt.gxTpr_Iteid ;
         }

         set {
            sdt.gxTpr_Iteid = value;
         }

      }

      [DataMember( Name = "IteOrdem" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Iteordem
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Iteordem), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Iteordem = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "IteNome" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Itenome
      {
         get {
            return sdt.gxTpr_Itenome ;
         }

         set {
            sdt.gxTpr_Itenome = value;
         }

      }

      [DataMember( Name = "IteAtivo" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Iteativo
      {
         get {
            return sdt.gxTpr_Iteativo ;
         }

         set {
            sdt.gxTpr_Iteativo = value;
         }

      }

      [DataMember( Name = "IteTotalOportunidades" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Itetotaloportunidades
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Itetotaloportunidades, 16, 2)) ;
         }

         set {
            sdt.gxTpr_Itetotaloportunidades = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "IteQtdeOportunidades" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Iteqtdeoportunidades
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Iteqtdeoportunidades), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Iteqtdeoportunidades = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "IteDel" , Order = 6 )]
      [GxSeudo()]
      public bool gxTpr_Itedel
      {
         get {
            return sdt.gxTpr_Itedel ;
         }

         set {
            sdt.gxTpr_Itedel = value;
         }

      }

      [DataMember( Name = "IteDelDataHora" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Itedeldatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Itedeldatahora) ;
         }

         set {
            sdt.gxTpr_Itedeldatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "IteDelData" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Itedeldata
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Itedeldata) ;
         }

         set {
            sdt.gxTpr_Itedeldata = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "IteDelHora" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Itedelhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Itedelhora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Itedelhora = GXt_dtime1;
         }

      }

      [DataMember( Name = "IteDelUsuId" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Itedelusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Itedelusuid) ;
         }

         set {
            sdt.gxTpr_Itedelusuid = value;
         }

      }

      [DataMember( Name = "IteDelUsuNome" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Itedelusunome
      {
         get {
            return sdt.gxTpr_Itedelusunome ;
         }

         set {
            sdt.gxTpr_Itedelusunome = value;
         }

      }

      public GeneXus.Programs.core.SdtIteracao sdt
      {
         get {
            return (GeneXus.Programs.core.SdtIteracao)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtIteracao() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 12 )]
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

   [DataContract(Name = @"core\Iteracao", Namespace = "agl_tresorygroup")]
   public class SdtIteracao_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtIteracao>
   {
      public SdtIteracao_RESTLInterface( ) : base()
      {
      }

      public SdtIteracao_RESTLInterface( GeneXus.Programs.core.SdtIteracao psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "IteNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Itenome
      {
         get {
            return sdt.gxTpr_Itenome ;
         }

         set {
            sdt.gxTpr_Itenome = value;
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

      public GeneXus.Programs.core.SdtIteracao sdt
      {
         get {
            return (GeneXus.Programs.core.SdtIteracao)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtIteracao() ;
         }
      }

   }

}
