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
   [XmlRoot(ElementName = "Parametros" )]
   [XmlType(TypeName =  "Parametros" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class SdtParametros : GxSilentTrnSdt
   {
      public SdtParametros( )
      {
      }

      public SdtParametros( IGxContext context )
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

      public void Load( string AV342ParametroChave )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(string)AV342ParametroChave});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ParametroChave", typeof(string)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "core\\Parametros");
         metadata.Set("BT", "tb_parametro");
         metadata.Set("PK", "[ \"ParametroChave\" ]");
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
         state.Add("gxTpr_Parametrochave_Z");
         state.Add("gxTpr_Parametrodescricao_Z");
         state.Add("gxTpr_Parametrovalor_Z");
         state.Add("gxTpr_Parametrodel_Z");
         state.Add("gxTpr_Parametrodeldatahora_Z_Nullable");
         state.Add("gxTpr_Parametrodeldata_Z_Nullable");
         state.Add("gxTpr_Parametrodelhora_Z_Nullable");
         state.Add("gxTpr_Parametrodelusuid_Z");
         state.Add("gxTpr_Parametrodelusunome_Z");
         state.Add("gxTpr_Parametrodescricao_N");
         state.Add("gxTpr_Parametrovalor_N");
         state.Add("gxTpr_Parametrodeldatahora_N");
         state.Add("gxTpr_Parametrodeldata_N");
         state.Add("gxTpr_Parametrodelhora_N");
         state.Add("gxTpr_Parametrodelusuid_N");
         state.Add("gxTpr_Parametrodelusunome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.SdtParametros sdt;
         sdt = (GeneXus.Programs.core.SdtParametros)(source);
         gxTv_SdtParametros_Parametrochave = sdt.gxTv_SdtParametros_Parametrochave ;
         gxTv_SdtParametros_Parametrodescricao = sdt.gxTv_SdtParametros_Parametrodescricao ;
         gxTv_SdtParametros_Parametrovalor = sdt.gxTv_SdtParametros_Parametrovalor ;
         gxTv_SdtParametros_Parametrodel = sdt.gxTv_SdtParametros_Parametrodel ;
         gxTv_SdtParametros_Parametrodeldatahora = sdt.gxTv_SdtParametros_Parametrodeldatahora ;
         gxTv_SdtParametros_Parametrodeldata = sdt.gxTv_SdtParametros_Parametrodeldata ;
         gxTv_SdtParametros_Parametrodelhora = sdt.gxTv_SdtParametros_Parametrodelhora ;
         gxTv_SdtParametros_Parametrodelusuid = sdt.gxTv_SdtParametros_Parametrodelusuid ;
         gxTv_SdtParametros_Parametrodelusunome = sdt.gxTv_SdtParametros_Parametrodelusunome ;
         gxTv_SdtParametros_Mode = sdt.gxTv_SdtParametros_Mode ;
         gxTv_SdtParametros_Initialized = sdt.gxTv_SdtParametros_Initialized ;
         gxTv_SdtParametros_Parametrochave_Z = sdt.gxTv_SdtParametros_Parametrochave_Z ;
         gxTv_SdtParametros_Parametrodescricao_Z = sdt.gxTv_SdtParametros_Parametrodescricao_Z ;
         gxTv_SdtParametros_Parametrovalor_Z = sdt.gxTv_SdtParametros_Parametrovalor_Z ;
         gxTv_SdtParametros_Parametrodel_Z = sdt.gxTv_SdtParametros_Parametrodel_Z ;
         gxTv_SdtParametros_Parametrodeldatahora_Z = sdt.gxTv_SdtParametros_Parametrodeldatahora_Z ;
         gxTv_SdtParametros_Parametrodeldata_Z = sdt.gxTv_SdtParametros_Parametrodeldata_Z ;
         gxTv_SdtParametros_Parametrodelhora_Z = sdt.gxTv_SdtParametros_Parametrodelhora_Z ;
         gxTv_SdtParametros_Parametrodelusuid_Z = sdt.gxTv_SdtParametros_Parametrodelusuid_Z ;
         gxTv_SdtParametros_Parametrodelusunome_Z = sdt.gxTv_SdtParametros_Parametrodelusunome_Z ;
         gxTv_SdtParametros_Parametrodescricao_N = sdt.gxTv_SdtParametros_Parametrodescricao_N ;
         gxTv_SdtParametros_Parametrovalor_N = sdt.gxTv_SdtParametros_Parametrovalor_N ;
         gxTv_SdtParametros_Parametrodeldatahora_N = sdt.gxTv_SdtParametros_Parametrodeldatahora_N ;
         gxTv_SdtParametros_Parametrodeldata_N = sdt.gxTv_SdtParametros_Parametrodeldata_N ;
         gxTv_SdtParametros_Parametrodelhora_N = sdt.gxTv_SdtParametros_Parametrodelhora_N ;
         gxTv_SdtParametros_Parametrodelusuid_N = sdt.gxTv_SdtParametros_Parametrodelusuid_N ;
         gxTv_SdtParametros_Parametrodelusunome_N = sdt.gxTv_SdtParametros_Parametrodelusunome_N ;
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
         AddObjectProperty("ParametroChave", gxTv_SdtParametros_Parametrochave, false, includeNonInitialized);
         AddObjectProperty("ParametroDescricao", gxTv_SdtParametros_Parametrodescricao, false, includeNonInitialized);
         AddObjectProperty("ParametroDescricao_N", gxTv_SdtParametros_Parametrodescricao_N, false, includeNonInitialized);
         AddObjectProperty("ParametroValor", gxTv_SdtParametros_Parametrovalor, false, includeNonInitialized);
         AddObjectProperty("ParametroValor_N", gxTv_SdtParametros_Parametrovalor_N, false, includeNonInitialized);
         AddObjectProperty("ParametroDel", gxTv_SdtParametros_Parametrodel, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtParametros_Parametrodeldatahora;
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
         AddObjectProperty("ParametroDelDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ParametroDelDataHora_N", gxTv_SdtParametros_Parametrodeldatahora_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtParametros_Parametrodeldata;
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
         AddObjectProperty("ParametroDelData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ParametroDelData_N", gxTv_SdtParametros_Parametrodeldata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtParametros_Parametrodelhora;
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
         AddObjectProperty("ParametroDelHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ParametroDelHora_N", gxTv_SdtParametros_Parametrodelhora_N, false, includeNonInitialized);
         AddObjectProperty("ParametroDelUsuId", gxTv_SdtParametros_Parametrodelusuid, false, includeNonInitialized);
         AddObjectProperty("ParametroDelUsuId_N", gxTv_SdtParametros_Parametrodelusuid_N, false, includeNonInitialized);
         AddObjectProperty("ParametroDelUsuNome", gxTv_SdtParametros_Parametrodelusunome, false, includeNonInitialized);
         AddObjectProperty("ParametroDelUsuNome_N", gxTv_SdtParametros_Parametrodelusunome_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtParametros_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtParametros_Initialized, false, includeNonInitialized);
            AddObjectProperty("ParametroChave_Z", gxTv_SdtParametros_Parametrochave_Z, false, includeNonInitialized);
            AddObjectProperty("ParametroDescricao_Z", gxTv_SdtParametros_Parametrodescricao_Z, false, includeNonInitialized);
            AddObjectProperty("ParametroValor_Z", gxTv_SdtParametros_Parametrovalor_Z, false, includeNonInitialized);
            AddObjectProperty("ParametroDel_Z", gxTv_SdtParametros_Parametrodel_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtParametros_Parametrodeldatahora_Z;
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
            AddObjectProperty("ParametroDelDataHora_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtParametros_Parametrodeldata_Z;
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
            AddObjectProperty("ParametroDelData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtParametros_Parametrodelhora_Z;
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
            AddObjectProperty("ParametroDelHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ParametroDelUsuId_Z", gxTv_SdtParametros_Parametrodelusuid_Z, false, includeNonInitialized);
            AddObjectProperty("ParametroDelUsuNome_Z", gxTv_SdtParametros_Parametrodelusunome_Z, false, includeNonInitialized);
            AddObjectProperty("ParametroDescricao_N", gxTv_SdtParametros_Parametrodescricao_N, false, includeNonInitialized);
            AddObjectProperty("ParametroValor_N", gxTv_SdtParametros_Parametrovalor_N, false, includeNonInitialized);
            AddObjectProperty("ParametroDelDataHora_N", gxTv_SdtParametros_Parametrodeldatahora_N, false, includeNonInitialized);
            AddObjectProperty("ParametroDelData_N", gxTv_SdtParametros_Parametrodeldata_N, false, includeNonInitialized);
            AddObjectProperty("ParametroDelHora_N", gxTv_SdtParametros_Parametrodelhora_N, false, includeNonInitialized);
            AddObjectProperty("ParametroDelUsuId_N", gxTv_SdtParametros_Parametrodelusuid_N, false, includeNonInitialized);
            AddObjectProperty("ParametroDelUsuNome_N", gxTv_SdtParametros_Parametrodelusunome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.SdtParametros sdt )
      {
         if ( sdt.IsDirty("ParametroChave") )
         {
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrochave = sdt.gxTv_SdtParametros_Parametrochave ;
         }
         if ( sdt.IsDirty("ParametroDescricao") )
         {
            gxTv_SdtParametros_Parametrodescricao_N = (short)(sdt.gxTv_SdtParametros_Parametrodescricao_N);
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodescricao = sdt.gxTv_SdtParametros_Parametrodescricao ;
         }
         if ( sdt.IsDirty("ParametroValor") )
         {
            gxTv_SdtParametros_Parametrovalor_N = (short)(sdt.gxTv_SdtParametros_Parametrovalor_N);
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrovalor = sdt.gxTv_SdtParametros_Parametrovalor ;
         }
         if ( sdt.IsDirty("ParametroDel") )
         {
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodel = sdt.gxTv_SdtParametros_Parametrodel ;
         }
         if ( sdt.IsDirty("ParametroDelDataHora") )
         {
            gxTv_SdtParametros_Parametrodeldatahora_N = (short)(sdt.gxTv_SdtParametros_Parametrodeldatahora_N);
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodeldatahora = sdt.gxTv_SdtParametros_Parametrodeldatahora ;
         }
         if ( sdt.IsDirty("ParametroDelData") )
         {
            gxTv_SdtParametros_Parametrodeldata_N = (short)(sdt.gxTv_SdtParametros_Parametrodeldata_N);
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodeldata = sdt.gxTv_SdtParametros_Parametrodeldata ;
         }
         if ( sdt.IsDirty("ParametroDelHora") )
         {
            gxTv_SdtParametros_Parametrodelhora_N = (short)(sdt.gxTv_SdtParametros_Parametrodelhora_N);
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodelhora = sdt.gxTv_SdtParametros_Parametrodelhora ;
         }
         if ( sdt.IsDirty("ParametroDelUsuId") )
         {
            gxTv_SdtParametros_Parametrodelusuid_N = (short)(sdt.gxTv_SdtParametros_Parametrodelusuid_N);
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodelusuid = sdt.gxTv_SdtParametros_Parametrodelusuid ;
         }
         if ( sdt.IsDirty("ParametroDelUsuNome") )
         {
            gxTv_SdtParametros_Parametrodelusunome_N = (short)(sdt.gxTv_SdtParametros_Parametrodelusunome_N);
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodelusunome = sdt.gxTv_SdtParametros_Parametrodelusunome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ParametroChave" )]
      [  XmlElement( ElementName = "ParametroChave"   )]
      public string gxTpr_Parametrochave
      {
         get {
            return gxTv_SdtParametros_Parametrochave ;
         }

         set {
            sdtIsNull = 0;
            if ( StringUtil.StrCmp(gxTv_SdtParametros_Parametrochave, value) != 0 )
            {
               gxTv_SdtParametros_Mode = "INS";
               this.gxTv_SdtParametros_Parametrochave_Z_SetNull( );
               this.gxTv_SdtParametros_Parametrodescricao_Z_SetNull( );
               this.gxTv_SdtParametros_Parametrovalor_Z_SetNull( );
               this.gxTv_SdtParametros_Parametrodel_Z_SetNull( );
               this.gxTv_SdtParametros_Parametrodeldatahora_Z_SetNull( );
               this.gxTv_SdtParametros_Parametrodeldata_Z_SetNull( );
               this.gxTv_SdtParametros_Parametrodelhora_Z_SetNull( );
               this.gxTv_SdtParametros_Parametrodelusuid_Z_SetNull( );
               this.gxTv_SdtParametros_Parametrodelusunome_Z_SetNull( );
            }
            gxTv_SdtParametros_Parametrochave = value;
            SetDirty("Parametrochave");
         }

      }

      [  SoapElement( ElementName = "ParametroDescricao" )]
      [  XmlElement( ElementName = "ParametroDescricao"   )]
      public string gxTpr_Parametrodescricao
      {
         get {
            return gxTv_SdtParametros_Parametrodescricao ;
         }

         set {
            gxTv_SdtParametros_Parametrodescricao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodescricao = value;
            SetDirty("Parametrodescricao");
         }

      }

      public void gxTv_SdtParametros_Parametrodescricao_SetNull( )
      {
         gxTv_SdtParametros_Parametrodescricao_N = 1;
         gxTv_SdtParametros_Parametrodescricao = "";
         SetDirty("Parametrodescricao");
         return  ;
      }

      public bool gxTv_SdtParametros_Parametrodescricao_IsNull( )
      {
         return (gxTv_SdtParametros_Parametrodescricao_N==1) ;
      }

      [  SoapElement( ElementName = "ParametroValor" )]
      [  XmlElement( ElementName = "ParametroValor"   )]
      public string gxTpr_Parametrovalor
      {
         get {
            return gxTv_SdtParametros_Parametrovalor ;
         }

         set {
            gxTv_SdtParametros_Parametrovalor_N = 0;
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrovalor = value;
            SetDirty("Parametrovalor");
         }

      }

      public void gxTv_SdtParametros_Parametrovalor_SetNull( )
      {
         gxTv_SdtParametros_Parametrovalor_N = 1;
         gxTv_SdtParametros_Parametrovalor = "";
         SetDirty("Parametrovalor");
         return  ;
      }

      public bool gxTv_SdtParametros_Parametrovalor_IsNull( )
      {
         return (gxTv_SdtParametros_Parametrovalor_N==1) ;
      }

      [  SoapElement( ElementName = "ParametroDel" )]
      [  XmlElement( ElementName = "ParametroDel"   )]
      public bool gxTpr_Parametrodel
      {
         get {
            return gxTv_SdtParametros_Parametrodel ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodel = value;
            SetDirty("Parametrodel");
         }

      }

      [  SoapElement( ElementName = "ParametroDelDataHora" )]
      [  XmlElement( ElementName = "ParametroDelDataHora"  , IsNullable=true )]
      public string gxTpr_Parametrodeldatahora_Nullable
      {
         get {
            if ( gxTv_SdtParametros_Parametrodeldatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtParametros_Parametrodeldatahora, null, true).value ;
         }

         set {
            gxTv_SdtParametros_Parametrodeldatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtParametros_Parametrodeldatahora = DateTime.MinValue;
            else
               gxTv_SdtParametros_Parametrodeldatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Parametrodeldatahora
      {
         get {
            return gxTv_SdtParametros_Parametrodeldatahora ;
         }

         set {
            gxTv_SdtParametros_Parametrodeldatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodeldatahora = value;
            SetDirty("Parametrodeldatahora");
         }

      }

      public void gxTv_SdtParametros_Parametrodeldatahora_SetNull( )
      {
         gxTv_SdtParametros_Parametrodeldatahora_N = 1;
         gxTv_SdtParametros_Parametrodeldatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Parametrodeldatahora");
         return  ;
      }

      public bool gxTv_SdtParametros_Parametrodeldatahora_IsNull( )
      {
         return (gxTv_SdtParametros_Parametrodeldatahora_N==1) ;
      }

      [  SoapElement( ElementName = "ParametroDelData" )]
      [  XmlElement( ElementName = "ParametroDelData"  , IsNullable=true )]
      public string gxTpr_Parametrodeldata_Nullable
      {
         get {
            if ( gxTv_SdtParametros_Parametrodeldata == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtParametros_Parametrodeldata).value ;
         }

         set {
            gxTv_SdtParametros_Parametrodeldata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtParametros_Parametrodeldata = DateTime.MinValue;
            else
               gxTv_SdtParametros_Parametrodeldata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Parametrodeldata
      {
         get {
            return gxTv_SdtParametros_Parametrodeldata ;
         }

         set {
            gxTv_SdtParametros_Parametrodeldata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodeldata = value;
            SetDirty("Parametrodeldata");
         }

      }

      public void gxTv_SdtParametros_Parametrodeldata_SetNull( )
      {
         gxTv_SdtParametros_Parametrodeldata_N = 1;
         gxTv_SdtParametros_Parametrodeldata = (DateTime)(DateTime.MinValue);
         SetDirty("Parametrodeldata");
         return  ;
      }

      public bool gxTv_SdtParametros_Parametrodeldata_IsNull( )
      {
         return (gxTv_SdtParametros_Parametrodeldata_N==1) ;
      }

      [  SoapElement( ElementName = "ParametroDelHora" )]
      [  XmlElement( ElementName = "ParametroDelHora"  , IsNullable=true )]
      public string gxTpr_Parametrodelhora_Nullable
      {
         get {
            if ( gxTv_SdtParametros_Parametrodelhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtParametros_Parametrodelhora).value ;
         }

         set {
            gxTv_SdtParametros_Parametrodelhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtParametros_Parametrodelhora = DateTime.MinValue;
            else
               gxTv_SdtParametros_Parametrodelhora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Parametrodelhora
      {
         get {
            return gxTv_SdtParametros_Parametrodelhora ;
         }

         set {
            gxTv_SdtParametros_Parametrodelhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodelhora = value;
            SetDirty("Parametrodelhora");
         }

      }

      public void gxTv_SdtParametros_Parametrodelhora_SetNull( )
      {
         gxTv_SdtParametros_Parametrodelhora_N = 1;
         gxTv_SdtParametros_Parametrodelhora = (DateTime)(DateTime.MinValue);
         SetDirty("Parametrodelhora");
         return  ;
      }

      public bool gxTv_SdtParametros_Parametrodelhora_IsNull( )
      {
         return (gxTv_SdtParametros_Parametrodelhora_N==1) ;
      }

      [  SoapElement( ElementName = "ParametroDelUsuId" )]
      [  XmlElement( ElementName = "ParametroDelUsuId"   )]
      public string gxTpr_Parametrodelusuid
      {
         get {
            return gxTv_SdtParametros_Parametrodelusuid ;
         }

         set {
            gxTv_SdtParametros_Parametrodelusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodelusuid = value;
            SetDirty("Parametrodelusuid");
         }

      }

      public void gxTv_SdtParametros_Parametrodelusuid_SetNull( )
      {
         gxTv_SdtParametros_Parametrodelusuid_N = 1;
         gxTv_SdtParametros_Parametrodelusuid = "";
         SetDirty("Parametrodelusuid");
         return  ;
      }

      public bool gxTv_SdtParametros_Parametrodelusuid_IsNull( )
      {
         return (gxTv_SdtParametros_Parametrodelusuid_N==1) ;
      }

      [  SoapElement( ElementName = "ParametroDelUsuNome" )]
      [  XmlElement( ElementName = "ParametroDelUsuNome"   )]
      public string gxTpr_Parametrodelusunome
      {
         get {
            return gxTv_SdtParametros_Parametrodelusunome ;
         }

         set {
            gxTv_SdtParametros_Parametrodelusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodelusunome = value;
            SetDirty("Parametrodelusunome");
         }

      }

      public void gxTv_SdtParametros_Parametrodelusunome_SetNull( )
      {
         gxTv_SdtParametros_Parametrodelusunome_N = 1;
         gxTv_SdtParametros_Parametrodelusunome = "";
         SetDirty("Parametrodelusunome");
         return  ;
      }

      public bool gxTv_SdtParametros_Parametrodelusunome_IsNull( )
      {
         return (gxTv_SdtParametros_Parametrodelusunome_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtParametros_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametros_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtParametros_Mode_SetNull( )
      {
         gxTv_SdtParametros_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtParametros_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtParametros_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametros_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtParametros_Initialized_SetNull( )
      {
         gxTv_SdtParametros_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtParametros_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroChave_Z" )]
      [  XmlElement( ElementName = "ParametroChave_Z"   )]
      public string gxTpr_Parametrochave_Z
      {
         get {
            return gxTv_SdtParametros_Parametrochave_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrochave_Z = value;
            SetDirty("Parametrochave_Z");
         }

      }

      public void gxTv_SdtParametros_Parametrochave_Z_SetNull( )
      {
         gxTv_SdtParametros_Parametrochave_Z = "";
         SetDirty("Parametrochave_Z");
         return  ;
      }

      public bool gxTv_SdtParametros_Parametrochave_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroDescricao_Z" )]
      [  XmlElement( ElementName = "ParametroDescricao_Z"   )]
      public string gxTpr_Parametrodescricao_Z
      {
         get {
            return gxTv_SdtParametros_Parametrodescricao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodescricao_Z = value;
            SetDirty("Parametrodescricao_Z");
         }

      }

      public void gxTv_SdtParametros_Parametrodescricao_Z_SetNull( )
      {
         gxTv_SdtParametros_Parametrodescricao_Z = "";
         SetDirty("Parametrodescricao_Z");
         return  ;
      }

      public bool gxTv_SdtParametros_Parametrodescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroValor_Z" )]
      [  XmlElement( ElementName = "ParametroValor_Z"   )]
      public string gxTpr_Parametrovalor_Z
      {
         get {
            return gxTv_SdtParametros_Parametrovalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrovalor_Z = value;
            SetDirty("Parametrovalor_Z");
         }

      }

      public void gxTv_SdtParametros_Parametrovalor_Z_SetNull( )
      {
         gxTv_SdtParametros_Parametrovalor_Z = "";
         SetDirty("Parametrovalor_Z");
         return  ;
      }

      public bool gxTv_SdtParametros_Parametrovalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroDel_Z" )]
      [  XmlElement( ElementName = "ParametroDel_Z"   )]
      public bool gxTpr_Parametrodel_Z
      {
         get {
            return gxTv_SdtParametros_Parametrodel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodel_Z = value;
            SetDirty("Parametrodel_Z");
         }

      }

      public void gxTv_SdtParametros_Parametrodel_Z_SetNull( )
      {
         gxTv_SdtParametros_Parametrodel_Z = false;
         SetDirty("Parametrodel_Z");
         return  ;
      }

      public bool gxTv_SdtParametros_Parametrodel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroDelDataHora_Z" )]
      [  XmlElement( ElementName = "ParametroDelDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Parametrodeldatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtParametros_Parametrodeldatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtParametros_Parametrodeldatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtParametros_Parametrodeldatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtParametros_Parametrodeldatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Parametrodeldatahora_Z
      {
         get {
            return gxTv_SdtParametros_Parametrodeldatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodeldatahora_Z = value;
            SetDirty("Parametrodeldatahora_Z");
         }

      }

      public void gxTv_SdtParametros_Parametrodeldatahora_Z_SetNull( )
      {
         gxTv_SdtParametros_Parametrodeldatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Parametrodeldatahora_Z");
         return  ;
      }

      public bool gxTv_SdtParametros_Parametrodeldatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroDelData_Z" )]
      [  XmlElement( ElementName = "ParametroDelData_Z"  , IsNullable=true )]
      public string gxTpr_Parametrodeldata_Z_Nullable
      {
         get {
            if ( gxTv_SdtParametros_Parametrodeldata_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtParametros_Parametrodeldata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtParametros_Parametrodeldata_Z = DateTime.MinValue;
            else
               gxTv_SdtParametros_Parametrodeldata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Parametrodeldata_Z
      {
         get {
            return gxTv_SdtParametros_Parametrodeldata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodeldata_Z = value;
            SetDirty("Parametrodeldata_Z");
         }

      }

      public void gxTv_SdtParametros_Parametrodeldata_Z_SetNull( )
      {
         gxTv_SdtParametros_Parametrodeldata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Parametrodeldata_Z");
         return  ;
      }

      public bool gxTv_SdtParametros_Parametrodeldata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroDelHora_Z" )]
      [  XmlElement( ElementName = "ParametroDelHora_Z"  , IsNullable=true )]
      public string gxTpr_Parametrodelhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtParametros_Parametrodelhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtParametros_Parametrodelhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtParametros_Parametrodelhora_Z = DateTime.MinValue;
            else
               gxTv_SdtParametros_Parametrodelhora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Parametrodelhora_Z
      {
         get {
            return gxTv_SdtParametros_Parametrodelhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodelhora_Z = value;
            SetDirty("Parametrodelhora_Z");
         }

      }

      public void gxTv_SdtParametros_Parametrodelhora_Z_SetNull( )
      {
         gxTv_SdtParametros_Parametrodelhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Parametrodelhora_Z");
         return  ;
      }

      public bool gxTv_SdtParametros_Parametrodelhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroDelUsuId_Z" )]
      [  XmlElement( ElementName = "ParametroDelUsuId_Z"   )]
      public string gxTpr_Parametrodelusuid_Z
      {
         get {
            return gxTv_SdtParametros_Parametrodelusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodelusuid_Z = value;
            SetDirty("Parametrodelusuid_Z");
         }

      }

      public void gxTv_SdtParametros_Parametrodelusuid_Z_SetNull( )
      {
         gxTv_SdtParametros_Parametrodelusuid_Z = "";
         SetDirty("Parametrodelusuid_Z");
         return  ;
      }

      public bool gxTv_SdtParametros_Parametrodelusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroDelUsuNome_Z" )]
      [  XmlElement( ElementName = "ParametroDelUsuNome_Z"   )]
      public string gxTpr_Parametrodelusunome_Z
      {
         get {
            return gxTv_SdtParametros_Parametrodelusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodelusunome_Z = value;
            SetDirty("Parametrodelusunome_Z");
         }

      }

      public void gxTv_SdtParametros_Parametrodelusunome_Z_SetNull( )
      {
         gxTv_SdtParametros_Parametrodelusunome_Z = "";
         SetDirty("Parametrodelusunome_Z");
         return  ;
      }

      public bool gxTv_SdtParametros_Parametrodelusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroDescricao_N" )]
      [  XmlElement( ElementName = "ParametroDescricao_N"   )]
      public short gxTpr_Parametrodescricao_N
      {
         get {
            return gxTv_SdtParametros_Parametrodescricao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodescricao_N = value;
            SetDirty("Parametrodescricao_N");
         }

      }

      public void gxTv_SdtParametros_Parametrodescricao_N_SetNull( )
      {
         gxTv_SdtParametros_Parametrodescricao_N = 0;
         SetDirty("Parametrodescricao_N");
         return  ;
      }

      public bool gxTv_SdtParametros_Parametrodescricao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroValor_N" )]
      [  XmlElement( ElementName = "ParametroValor_N"   )]
      public short gxTpr_Parametrovalor_N
      {
         get {
            return gxTv_SdtParametros_Parametrovalor_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrovalor_N = value;
            SetDirty("Parametrovalor_N");
         }

      }

      public void gxTv_SdtParametros_Parametrovalor_N_SetNull( )
      {
         gxTv_SdtParametros_Parametrovalor_N = 0;
         SetDirty("Parametrovalor_N");
         return  ;
      }

      public bool gxTv_SdtParametros_Parametrovalor_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroDelDataHora_N" )]
      [  XmlElement( ElementName = "ParametroDelDataHora_N"   )]
      public short gxTpr_Parametrodeldatahora_N
      {
         get {
            return gxTv_SdtParametros_Parametrodeldatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodeldatahora_N = value;
            SetDirty("Parametrodeldatahora_N");
         }

      }

      public void gxTv_SdtParametros_Parametrodeldatahora_N_SetNull( )
      {
         gxTv_SdtParametros_Parametrodeldatahora_N = 0;
         SetDirty("Parametrodeldatahora_N");
         return  ;
      }

      public bool gxTv_SdtParametros_Parametrodeldatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroDelData_N" )]
      [  XmlElement( ElementName = "ParametroDelData_N"   )]
      public short gxTpr_Parametrodeldata_N
      {
         get {
            return gxTv_SdtParametros_Parametrodeldata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodeldata_N = value;
            SetDirty("Parametrodeldata_N");
         }

      }

      public void gxTv_SdtParametros_Parametrodeldata_N_SetNull( )
      {
         gxTv_SdtParametros_Parametrodeldata_N = 0;
         SetDirty("Parametrodeldata_N");
         return  ;
      }

      public bool gxTv_SdtParametros_Parametrodeldata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroDelHora_N" )]
      [  XmlElement( ElementName = "ParametroDelHora_N"   )]
      public short gxTpr_Parametrodelhora_N
      {
         get {
            return gxTv_SdtParametros_Parametrodelhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodelhora_N = value;
            SetDirty("Parametrodelhora_N");
         }

      }

      public void gxTv_SdtParametros_Parametrodelhora_N_SetNull( )
      {
         gxTv_SdtParametros_Parametrodelhora_N = 0;
         SetDirty("Parametrodelhora_N");
         return  ;
      }

      public bool gxTv_SdtParametros_Parametrodelhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroDelUsuId_N" )]
      [  XmlElement( ElementName = "ParametroDelUsuId_N"   )]
      public short gxTpr_Parametrodelusuid_N
      {
         get {
            return gxTv_SdtParametros_Parametrodelusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodelusuid_N = value;
            SetDirty("Parametrodelusuid_N");
         }

      }

      public void gxTv_SdtParametros_Parametrodelusuid_N_SetNull( )
      {
         gxTv_SdtParametros_Parametrodelusuid_N = 0;
         SetDirty("Parametrodelusuid_N");
         return  ;
      }

      public bool gxTv_SdtParametros_Parametrodelusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroDelUsuNome_N" )]
      [  XmlElement( ElementName = "ParametroDelUsuNome_N"   )]
      public short gxTpr_Parametrodelusunome_N
      {
         get {
            return gxTv_SdtParametros_Parametrodelusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametros_Parametrodelusunome_N = value;
            SetDirty("Parametrodelusunome_N");
         }

      }

      public void gxTv_SdtParametros_Parametrodelusunome_N_SetNull( )
      {
         gxTv_SdtParametros_Parametrodelusunome_N = 0;
         SetDirty("Parametrodelusunome_N");
         return  ;
      }

      public bool gxTv_SdtParametros_Parametrodelusunome_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtParametros_Parametrochave = "";
         sdtIsNull = 1;
         gxTv_SdtParametros_Parametrodescricao = "";
         gxTv_SdtParametros_Parametrovalor = "";
         gxTv_SdtParametros_Parametrodeldatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtParametros_Parametrodeldata = (DateTime)(DateTime.MinValue);
         gxTv_SdtParametros_Parametrodelhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtParametros_Parametrodelusuid = "";
         gxTv_SdtParametros_Parametrodelusunome = "";
         gxTv_SdtParametros_Mode = "";
         gxTv_SdtParametros_Parametrochave_Z = "";
         gxTv_SdtParametros_Parametrodescricao_Z = "";
         gxTv_SdtParametros_Parametrovalor_Z = "";
         gxTv_SdtParametros_Parametrodeldatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtParametros_Parametrodeldata_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtParametros_Parametrodelhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtParametros_Parametrodelusuid_Z = "";
         gxTv_SdtParametros_Parametrodelusunome_Z = "";
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "core.parametros", "GeneXus.Programs.core.parametros_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtParametros_Initialized ;
      private short gxTv_SdtParametros_Parametrodescricao_N ;
      private short gxTv_SdtParametros_Parametrovalor_N ;
      private short gxTv_SdtParametros_Parametrodeldatahora_N ;
      private short gxTv_SdtParametros_Parametrodeldata_N ;
      private short gxTv_SdtParametros_Parametrodelhora_N ;
      private short gxTv_SdtParametros_Parametrodelusuid_N ;
      private short gxTv_SdtParametros_Parametrodelusunome_N ;
      private string gxTv_SdtParametros_Parametrodelusuid ;
      private string gxTv_SdtParametros_Mode ;
      private string gxTv_SdtParametros_Parametrodelusuid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtParametros_Parametrodeldatahora ;
      private DateTime gxTv_SdtParametros_Parametrodeldata ;
      private DateTime gxTv_SdtParametros_Parametrodelhora ;
      private DateTime gxTv_SdtParametros_Parametrodeldatahora_Z ;
      private DateTime gxTv_SdtParametros_Parametrodeldata_Z ;
      private DateTime gxTv_SdtParametros_Parametrodelhora_Z ;
      private DateTime datetimemil_STZ ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtParametros_Parametrodel ;
      private bool gxTv_SdtParametros_Parametrodel_Z ;
      private string gxTv_SdtParametros_Parametrochave ;
      private string gxTv_SdtParametros_Parametrodescricao ;
      private string gxTv_SdtParametros_Parametrovalor ;
      private string gxTv_SdtParametros_Parametrodelusunome ;
      private string gxTv_SdtParametros_Parametrochave_Z ;
      private string gxTv_SdtParametros_Parametrodescricao_Z ;
      private string gxTv_SdtParametros_Parametrovalor_Z ;
      private string gxTv_SdtParametros_Parametrodelusunome_Z ;
   }

   [DataContract(Name = @"core\Parametros", Namespace = "agl_tresorygroup")]
   public class SdtParametros_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtParametros>
   {
      public SdtParametros_RESTInterface( ) : base()
      {
      }

      public SdtParametros_RESTInterface( GeneXus.Programs.core.SdtParametros psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ParametroChave" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Parametrochave
      {
         get {
            return sdt.gxTpr_Parametrochave ;
         }

         set {
            sdt.gxTpr_Parametrochave = value;
         }

      }

      [DataMember( Name = "ParametroDescricao" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Parametrodescricao
      {
         get {
            return sdt.gxTpr_Parametrodescricao ;
         }

         set {
            sdt.gxTpr_Parametrodescricao = value;
         }

      }

      [DataMember( Name = "ParametroValor" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Parametrovalor
      {
         get {
            return sdt.gxTpr_Parametrovalor ;
         }

         set {
            sdt.gxTpr_Parametrovalor = value;
         }

      }

      [DataMember( Name = "ParametroDel" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Parametrodel
      {
         get {
            return sdt.gxTpr_Parametrodel ;
         }

         set {
            sdt.gxTpr_Parametrodel = value;
         }

      }

      [DataMember( Name = "ParametroDelDataHora" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Parametrodeldatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Parametrodeldatahora) ;
         }

         set {
            sdt.gxTpr_Parametrodeldatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "ParametroDelData" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Parametrodeldata
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Parametrodeldata) ;
         }

         set {
            sdt.gxTpr_Parametrodeldata = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "ParametroDelHora" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Parametrodelhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Parametrodelhora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Parametrodelhora = GXt_dtime1;
         }

      }

      [DataMember( Name = "ParametroDelUsuId" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Parametrodelusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Parametrodelusuid) ;
         }

         set {
            sdt.gxTpr_Parametrodelusuid = value;
         }

      }

      [DataMember( Name = "ParametroDelUsuNome" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Parametrodelusunome
      {
         get {
            return sdt.gxTpr_Parametrodelusunome ;
         }

         set {
            sdt.gxTpr_Parametrodelusunome = value;
         }

      }

      public GeneXus.Programs.core.SdtParametros sdt
      {
         get {
            return (GeneXus.Programs.core.SdtParametros)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtParametros() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 9 )]
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

   [DataContract(Name = @"core\Parametros", Namespace = "agl_tresorygroup")]
   public class SdtParametros_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtParametros>
   {
      public SdtParametros_RESTLInterface( ) : base()
      {
      }

      public SdtParametros_RESTLInterface( GeneXus.Programs.core.SdtParametros psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ParametroDescricao" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Parametrodescricao
      {
         get {
            return sdt.gxTpr_Parametrodescricao ;
         }

         set {
            sdt.gxTpr_Parametrodescricao = value;
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

      public GeneXus.Programs.core.SdtParametros sdt
      {
         get {
            return (GeneXus.Programs.core.SdtParametros)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtParametros() ;
         }
      }

   }

}
