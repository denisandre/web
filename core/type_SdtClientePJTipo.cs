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
   [XmlRoot(ElementName = "ClientePJTipo" )]
   [XmlType(TypeName =  "ClientePJTipo" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class SdtClientePJTipo : GxSilentTrnSdt
   {
      public SdtClientePJTipo( )
      {
      }

      public SdtClientePJTipo( IGxContext context )
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

      public void Load( int AV155PjtID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV155PjtID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PjtID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "core\\ClientePJTipo");
         metadata.Set("BT", "tb_clientepjtipo");
         metadata.Set("PK", "[ \"PjtID\" ]");
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
         state.Add("gxTpr_Pjtid_Z");
         state.Add("gxTpr_Pjtsigla_Z");
         state.Add("gxTpr_Pjtnome_Z");
         state.Add("gxTpr_Pjtativo_Z");
         state.Add("gxTpr_Pjtdel_Z");
         state.Add("gxTpr_Pjtdeldatahora_Z_Nullable");
         state.Add("gxTpr_Pjtdeldata_Z_Nullable");
         state.Add("gxTpr_Pjtdelhora_Z_Nullable");
         state.Add("gxTpr_Pjtdelusuid_Z");
         state.Add("gxTpr_Pjtdelusunome_Z");
         state.Add("gxTpr_Pjtdeldatahora_N");
         state.Add("gxTpr_Pjtdeldata_N");
         state.Add("gxTpr_Pjtdelhora_N");
         state.Add("gxTpr_Pjtdelusuid_N");
         state.Add("gxTpr_Pjtdelusunome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.SdtClientePJTipo sdt;
         sdt = (GeneXus.Programs.core.SdtClientePJTipo)(source);
         gxTv_SdtClientePJTipo_Pjtid = sdt.gxTv_SdtClientePJTipo_Pjtid ;
         gxTv_SdtClientePJTipo_Pjtsigla = sdt.gxTv_SdtClientePJTipo_Pjtsigla ;
         gxTv_SdtClientePJTipo_Pjtnome = sdt.gxTv_SdtClientePJTipo_Pjtnome ;
         gxTv_SdtClientePJTipo_Pjtativo = sdt.gxTv_SdtClientePJTipo_Pjtativo ;
         gxTv_SdtClientePJTipo_Pjtdel = sdt.gxTv_SdtClientePJTipo_Pjtdel ;
         gxTv_SdtClientePJTipo_Pjtdeldatahora = sdt.gxTv_SdtClientePJTipo_Pjtdeldatahora ;
         gxTv_SdtClientePJTipo_Pjtdeldata = sdt.gxTv_SdtClientePJTipo_Pjtdeldata ;
         gxTv_SdtClientePJTipo_Pjtdelhora = sdt.gxTv_SdtClientePJTipo_Pjtdelhora ;
         gxTv_SdtClientePJTipo_Pjtdelusuid = sdt.gxTv_SdtClientePJTipo_Pjtdelusuid ;
         gxTv_SdtClientePJTipo_Pjtdelusunome = sdt.gxTv_SdtClientePJTipo_Pjtdelusunome ;
         gxTv_SdtClientePJTipo_Mode = sdt.gxTv_SdtClientePJTipo_Mode ;
         gxTv_SdtClientePJTipo_Initialized = sdt.gxTv_SdtClientePJTipo_Initialized ;
         gxTv_SdtClientePJTipo_Pjtid_Z = sdt.gxTv_SdtClientePJTipo_Pjtid_Z ;
         gxTv_SdtClientePJTipo_Pjtsigla_Z = sdt.gxTv_SdtClientePJTipo_Pjtsigla_Z ;
         gxTv_SdtClientePJTipo_Pjtnome_Z = sdt.gxTv_SdtClientePJTipo_Pjtnome_Z ;
         gxTv_SdtClientePJTipo_Pjtativo_Z = sdt.gxTv_SdtClientePJTipo_Pjtativo_Z ;
         gxTv_SdtClientePJTipo_Pjtdel_Z = sdt.gxTv_SdtClientePJTipo_Pjtdel_Z ;
         gxTv_SdtClientePJTipo_Pjtdeldatahora_Z = sdt.gxTv_SdtClientePJTipo_Pjtdeldatahora_Z ;
         gxTv_SdtClientePJTipo_Pjtdeldata_Z = sdt.gxTv_SdtClientePJTipo_Pjtdeldata_Z ;
         gxTv_SdtClientePJTipo_Pjtdelhora_Z = sdt.gxTv_SdtClientePJTipo_Pjtdelhora_Z ;
         gxTv_SdtClientePJTipo_Pjtdelusuid_Z = sdt.gxTv_SdtClientePJTipo_Pjtdelusuid_Z ;
         gxTv_SdtClientePJTipo_Pjtdelusunome_Z = sdt.gxTv_SdtClientePJTipo_Pjtdelusunome_Z ;
         gxTv_SdtClientePJTipo_Pjtdeldatahora_N = sdt.gxTv_SdtClientePJTipo_Pjtdeldatahora_N ;
         gxTv_SdtClientePJTipo_Pjtdeldata_N = sdt.gxTv_SdtClientePJTipo_Pjtdeldata_N ;
         gxTv_SdtClientePJTipo_Pjtdelhora_N = sdt.gxTv_SdtClientePJTipo_Pjtdelhora_N ;
         gxTv_SdtClientePJTipo_Pjtdelusuid_N = sdt.gxTv_SdtClientePJTipo_Pjtdelusuid_N ;
         gxTv_SdtClientePJTipo_Pjtdelusunome_N = sdt.gxTv_SdtClientePJTipo_Pjtdelusunome_N ;
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
         AddObjectProperty("PjtID", gxTv_SdtClientePJTipo_Pjtid, false, includeNonInitialized);
         AddObjectProperty("PjtSigla", gxTv_SdtClientePJTipo_Pjtsigla, false, includeNonInitialized);
         AddObjectProperty("PjtNome", gxTv_SdtClientePJTipo_Pjtnome, false, includeNonInitialized);
         AddObjectProperty("PjtAtivo", gxTv_SdtClientePJTipo_Pjtativo, false, includeNonInitialized);
         AddObjectProperty("PjtDel", gxTv_SdtClientePJTipo_Pjtdel, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtClientePJTipo_Pjtdeldatahora;
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
         AddObjectProperty("PjtDelDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PjtDelDataHora_N", gxTv_SdtClientePJTipo_Pjtdeldatahora_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtClientePJTipo_Pjtdeldata;
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
         AddObjectProperty("PjtDelData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PjtDelData_N", gxTv_SdtClientePJTipo_Pjtdeldata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtClientePJTipo_Pjtdelhora;
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
         AddObjectProperty("PjtDelHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PjtDelHora_N", gxTv_SdtClientePJTipo_Pjtdelhora_N, false, includeNonInitialized);
         AddObjectProperty("PjtDelUsuId", gxTv_SdtClientePJTipo_Pjtdelusuid, false, includeNonInitialized);
         AddObjectProperty("PjtDelUsuId_N", gxTv_SdtClientePJTipo_Pjtdelusuid_N, false, includeNonInitialized);
         AddObjectProperty("PjtDelUsuNome", gxTv_SdtClientePJTipo_Pjtdelusunome, false, includeNonInitialized);
         AddObjectProperty("PjtDelUsuNome_N", gxTv_SdtClientePJTipo_Pjtdelusunome_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtClientePJTipo_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtClientePJTipo_Initialized, false, includeNonInitialized);
            AddObjectProperty("PjtID_Z", gxTv_SdtClientePJTipo_Pjtid_Z, false, includeNonInitialized);
            AddObjectProperty("PjtSigla_Z", gxTv_SdtClientePJTipo_Pjtsigla_Z, false, includeNonInitialized);
            AddObjectProperty("PjtNome_Z", gxTv_SdtClientePJTipo_Pjtnome_Z, false, includeNonInitialized);
            AddObjectProperty("PjtAtivo_Z", gxTv_SdtClientePJTipo_Pjtativo_Z, false, includeNonInitialized);
            AddObjectProperty("PjtDel_Z", gxTv_SdtClientePJTipo_Pjtdel_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtClientePJTipo_Pjtdeldatahora_Z;
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
            AddObjectProperty("PjtDelDataHora_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtClientePJTipo_Pjtdeldata_Z;
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
            AddObjectProperty("PjtDelData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtClientePJTipo_Pjtdelhora_Z;
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
            AddObjectProperty("PjtDelHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("PjtDelUsuId_Z", gxTv_SdtClientePJTipo_Pjtdelusuid_Z, false, includeNonInitialized);
            AddObjectProperty("PjtDelUsuNome_Z", gxTv_SdtClientePJTipo_Pjtdelusunome_Z, false, includeNonInitialized);
            AddObjectProperty("PjtDelDataHora_N", gxTv_SdtClientePJTipo_Pjtdeldatahora_N, false, includeNonInitialized);
            AddObjectProperty("PjtDelData_N", gxTv_SdtClientePJTipo_Pjtdeldata_N, false, includeNonInitialized);
            AddObjectProperty("PjtDelHora_N", gxTv_SdtClientePJTipo_Pjtdelhora_N, false, includeNonInitialized);
            AddObjectProperty("PjtDelUsuId_N", gxTv_SdtClientePJTipo_Pjtdelusuid_N, false, includeNonInitialized);
            AddObjectProperty("PjtDelUsuNome_N", gxTv_SdtClientePJTipo_Pjtdelusunome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.SdtClientePJTipo sdt )
      {
         if ( sdt.IsDirty("PjtID") )
         {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtid = sdt.gxTv_SdtClientePJTipo_Pjtid ;
         }
         if ( sdt.IsDirty("PjtSigla") )
         {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtsigla = sdt.gxTv_SdtClientePJTipo_Pjtsigla ;
         }
         if ( sdt.IsDirty("PjtNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtnome = sdt.gxTv_SdtClientePJTipo_Pjtnome ;
         }
         if ( sdt.IsDirty("PjtAtivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtativo = sdt.gxTv_SdtClientePJTipo_Pjtativo ;
         }
         if ( sdt.IsDirty("PjtDel") )
         {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtdel = sdt.gxTv_SdtClientePJTipo_Pjtdel ;
         }
         if ( sdt.IsDirty("PjtDelDataHora") )
         {
            gxTv_SdtClientePJTipo_Pjtdeldatahora_N = (short)(sdt.gxTv_SdtClientePJTipo_Pjtdeldatahora_N);
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtdeldatahora = sdt.gxTv_SdtClientePJTipo_Pjtdeldatahora ;
         }
         if ( sdt.IsDirty("PjtDelData") )
         {
            gxTv_SdtClientePJTipo_Pjtdeldata_N = (short)(sdt.gxTv_SdtClientePJTipo_Pjtdeldata_N);
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtdeldata = sdt.gxTv_SdtClientePJTipo_Pjtdeldata ;
         }
         if ( sdt.IsDirty("PjtDelHora") )
         {
            gxTv_SdtClientePJTipo_Pjtdelhora_N = (short)(sdt.gxTv_SdtClientePJTipo_Pjtdelhora_N);
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtdelhora = sdt.gxTv_SdtClientePJTipo_Pjtdelhora ;
         }
         if ( sdt.IsDirty("PjtDelUsuId") )
         {
            gxTv_SdtClientePJTipo_Pjtdelusuid_N = (short)(sdt.gxTv_SdtClientePJTipo_Pjtdelusuid_N);
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtdelusuid = sdt.gxTv_SdtClientePJTipo_Pjtdelusuid ;
         }
         if ( sdt.IsDirty("PjtDelUsuNome") )
         {
            gxTv_SdtClientePJTipo_Pjtdelusunome_N = (short)(sdt.gxTv_SdtClientePJTipo_Pjtdelusunome_N);
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtdelusunome = sdt.gxTv_SdtClientePJTipo_Pjtdelusunome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PjtID" )]
      [  XmlElement( ElementName = "PjtID"   )]
      public int gxTpr_Pjtid
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtClientePJTipo_Pjtid != value )
            {
               gxTv_SdtClientePJTipo_Mode = "INS";
               this.gxTv_SdtClientePJTipo_Pjtid_Z_SetNull( );
               this.gxTv_SdtClientePJTipo_Pjtsigla_Z_SetNull( );
               this.gxTv_SdtClientePJTipo_Pjtnome_Z_SetNull( );
               this.gxTv_SdtClientePJTipo_Pjtativo_Z_SetNull( );
               this.gxTv_SdtClientePJTipo_Pjtdel_Z_SetNull( );
               this.gxTv_SdtClientePJTipo_Pjtdeldatahora_Z_SetNull( );
               this.gxTv_SdtClientePJTipo_Pjtdeldata_Z_SetNull( );
               this.gxTv_SdtClientePJTipo_Pjtdelhora_Z_SetNull( );
               this.gxTv_SdtClientePJTipo_Pjtdelusuid_Z_SetNull( );
               this.gxTv_SdtClientePJTipo_Pjtdelusunome_Z_SetNull( );
            }
            gxTv_SdtClientePJTipo_Pjtid = value;
            SetDirty("Pjtid");
         }

      }

      [  SoapElement( ElementName = "PjtSigla" )]
      [  XmlElement( ElementName = "PjtSigla"   )]
      public string gxTpr_Pjtsigla
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtsigla ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtsigla = value;
            SetDirty("Pjtsigla");
         }

      }

      [  SoapElement( ElementName = "PjtNome" )]
      [  XmlElement( ElementName = "PjtNome"   )]
      public string gxTpr_Pjtnome
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtnome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtnome = value;
            SetDirty("Pjtnome");
         }

      }

      [  SoapElement( ElementName = "PjtAtivo" )]
      [  XmlElement( ElementName = "PjtAtivo"   )]
      public bool gxTpr_Pjtativo
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtativo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtativo = value;
            SetDirty("Pjtativo");
         }

      }

      [  SoapElement( ElementName = "PjtDel" )]
      [  XmlElement( ElementName = "PjtDel"   )]
      public bool gxTpr_Pjtdel
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtdel ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtdel = value;
            SetDirty("Pjtdel");
         }

      }

      [  SoapElement( ElementName = "PjtDelDataHora" )]
      [  XmlElement( ElementName = "PjtDelDataHora"  , IsNullable=true )]
      public string gxTpr_Pjtdeldatahora_Nullable
      {
         get {
            if ( gxTv_SdtClientePJTipo_Pjtdeldatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtClientePJTipo_Pjtdeldatahora, null, true).value ;
         }

         set {
            gxTv_SdtClientePJTipo_Pjtdeldatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtClientePJTipo_Pjtdeldatahora = DateTime.MinValue;
            else
               gxTv_SdtClientePJTipo_Pjtdeldatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Pjtdeldatahora
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtdeldatahora ;
         }

         set {
            gxTv_SdtClientePJTipo_Pjtdeldatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtdeldatahora = value;
            SetDirty("Pjtdeldatahora");
         }

      }

      public void gxTv_SdtClientePJTipo_Pjtdeldatahora_SetNull( )
      {
         gxTv_SdtClientePJTipo_Pjtdeldatahora_N = 1;
         gxTv_SdtClientePJTipo_Pjtdeldatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Pjtdeldatahora");
         return  ;
      }

      public bool gxTv_SdtClientePJTipo_Pjtdeldatahora_IsNull( )
      {
         return (gxTv_SdtClientePJTipo_Pjtdeldatahora_N==1) ;
      }

      [  SoapElement( ElementName = "PjtDelData" )]
      [  XmlElement( ElementName = "PjtDelData"  , IsNullable=true )]
      public string gxTpr_Pjtdeldata_Nullable
      {
         get {
            if ( gxTv_SdtClientePJTipo_Pjtdeldata == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtClientePJTipo_Pjtdeldata).value ;
         }

         set {
            gxTv_SdtClientePJTipo_Pjtdeldata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtClientePJTipo_Pjtdeldata = DateTime.MinValue;
            else
               gxTv_SdtClientePJTipo_Pjtdeldata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Pjtdeldata
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtdeldata ;
         }

         set {
            gxTv_SdtClientePJTipo_Pjtdeldata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtdeldata = value;
            SetDirty("Pjtdeldata");
         }

      }

      public void gxTv_SdtClientePJTipo_Pjtdeldata_SetNull( )
      {
         gxTv_SdtClientePJTipo_Pjtdeldata_N = 1;
         gxTv_SdtClientePJTipo_Pjtdeldata = (DateTime)(DateTime.MinValue);
         SetDirty("Pjtdeldata");
         return  ;
      }

      public bool gxTv_SdtClientePJTipo_Pjtdeldata_IsNull( )
      {
         return (gxTv_SdtClientePJTipo_Pjtdeldata_N==1) ;
      }

      [  SoapElement( ElementName = "PjtDelHora" )]
      [  XmlElement( ElementName = "PjtDelHora"  , IsNullable=true )]
      public string gxTpr_Pjtdelhora_Nullable
      {
         get {
            if ( gxTv_SdtClientePJTipo_Pjtdelhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtClientePJTipo_Pjtdelhora).value ;
         }

         set {
            gxTv_SdtClientePJTipo_Pjtdelhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtClientePJTipo_Pjtdelhora = DateTime.MinValue;
            else
               gxTv_SdtClientePJTipo_Pjtdelhora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Pjtdelhora
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtdelhora ;
         }

         set {
            gxTv_SdtClientePJTipo_Pjtdelhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtdelhora = value;
            SetDirty("Pjtdelhora");
         }

      }

      public void gxTv_SdtClientePJTipo_Pjtdelhora_SetNull( )
      {
         gxTv_SdtClientePJTipo_Pjtdelhora_N = 1;
         gxTv_SdtClientePJTipo_Pjtdelhora = (DateTime)(DateTime.MinValue);
         SetDirty("Pjtdelhora");
         return  ;
      }

      public bool gxTv_SdtClientePJTipo_Pjtdelhora_IsNull( )
      {
         return (gxTv_SdtClientePJTipo_Pjtdelhora_N==1) ;
      }

      [  SoapElement( ElementName = "PjtDelUsuId" )]
      [  XmlElement( ElementName = "PjtDelUsuId"   )]
      public string gxTpr_Pjtdelusuid
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtdelusuid ;
         }

         set {
            gxTv_SdtClientePJTipo_Pjtdelusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtdelusuid = value;
            SetDirty("Pjtdelusuid");
         }

      }

      public void gxTv_SdtClientePJTipo_Pjtdelusuid_SetNull( )
      {
         gxTv_SdtClientePJTipo_Pjtdelusuid_N = 1;
         gxTv_SdtClientePJTipo_Pjtdelusuid = "";
         SetDirty("Pjtdelusuid");
         return  ;
      }

      public bool gxTv_SdtClientePJTipo_Pjtdelusuid_IsNull( )
      {
         return (gxTv_SdtClientePJTipo_Pjtdelusuid_N==1) ;
      }

      [  SoapElement( ElementName = "PjtDelUsuNome" )]
      [  XmlElement( ElementName = "PjtDelUsuNome"   )]
      public string gxTpr_Pjtdelusunome
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtdelusunome ;
         }

         set {
            gxTv_SdtClientePJTipo_Pjtdelusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtdelusunome = value;
            SetDirty("Pjtdelusunome");
         }

      }

      public void gxTv_SdtClientePJTipo_Pjtdelusunome_SetNull( )
      {
         gxTv_SdtClientePJTipo_Pjtdelusunome_N = 1;
         gxTv_SdtClientePJTipo_Pjtdelusunome = "";
         SetDirty("Pjtdelusunome");
         return  ;
      }

      public bool gxTv_SdtClientePJTipo_Pjtdelusunome_IsNull( )
      {
         return (gxTv_SdtClientePJTipo_Pjtdelusunome_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtClientePJTipo_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtClientePJTipo_Mode_SetNull( )
      {
         gxTv_SdtClientePJTipo_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtClientePJTipo_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtClientePJTipo_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtClientePJTipo_Initialized_SetNull( )
      {
         gxTv_SdtClientePJTipo_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtClientePJTipo_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PjtID_Z" )]
      [  XmlElement( ElementName = "PjtID_Z"   )]
      public int gxTpr_Pjtid_Z
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtid_Z = value;
            SetDirty("Pjtid_Z");
         }

      }

      public void gxTv_SdtClientePJTipo_Pjtid_Z_SetNull( )
      {
         gxTv_SdtClientePJTipo_Pjtid_Z = 0;
         SetDirty("Pjtid_Z");
         return  ;
      }

      public bool gxTv_SdtClientePJTipo_Pjtid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PjtSigla_Z" )]
      [  XmlElement( ElementName = "PjtSigla_Z"   )]
      public string gxTpr_Pjtsigla_Z
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtsigla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtsigla_Z = value;
            SetDirty("Pjtsigla_Z");
         }

      }

      public void gxTv_SdtClientePJTipo_Pjtsigla_Z_SetNull( )
      {
         gxTv_SdtClientePJTipo_Pjtsigla_Z = "";
         SetDirty("Pjtsigla_Z");
         return  ;
      }

      public bool gxTv_SdtClientePJTipo_Pjtsigla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PjtNome_Z" )]
      [  XmlElement( ElementName = "PjtNome_Z"   )]
      public string gxTpr_Pjtnome_Z
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtnome_Z = value;
            SetDirty("Pjtnome_Z");
         }

      }

      public void gxTv_SdtClientePJTipo_Pjtnome_Z_SetNull( )
      {
         gxTv_SdtClientePJTipo_Pjtnome_Z = "";
         SetDirty("Pjtnome_Z");
         return  ;
      }

      public bool gxTv_SdtClientePJTipo_Pjtnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PjtAtivo_Z" )]
      [  XmlElement( ElementName = "PjtAtivo_Z"   )]
      public bool gxTpr_Pjtativo_Z
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtativo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtativo_Z = value;
            SetDirty("Pjtativo_Z");
         }

      }

      public void gxTv_SdtClientePJTipo_Pjtativo_Z_SetNull( )
      {
         gxTv_SdtClientePJTipo_Pjtativo_Z = false;
         SetDirty("Pjtativo_Z");
         return  ;
      }

      public bool gxTv_SdtClientePJTipo_Pjtativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PjtDel_Z" )]
      [  XmlElement( ElementName = "PjtDel_Z"   )]
      public bool gxTpr_Pjtdel_Z
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtdel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtdel_Z = value;
            SetDirty("Pjtdel_Z");
         }

      }

      public void gxTv_SdtClientePJTipo_Pjtdel_Z_SetNull( )
      {
         gxTv_SdtClientePJTipo_Pjtdel_Z = false;
         SetDirty("Pjtdel_Z");
         return  ;
      }

      public bool gxTv_SdtClientePJTipo_Pjtdel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PjtDelDataHora_Z" )]
      [  XmlElement( ElementName = "PjtDelDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Pjtdeldatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtClientePJTipo_Pjtdeldatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtClientePJTipo_Pjtdeldatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtClientePJTipo_Pjtdeldatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtClientePJTipo_Pjtdeldatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Pjtdeldatahora_Z
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtdeldatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtdeldatahora_Z = value;
            SetDirty("Pjtdeldatahora_Z");
         }

      }

      public void gxTv_SdtClientePJTipo_Pjtdeldatahora_Z_SetNull( )
      {
         gxTv_SdtClientePJTipo_Pjtdeldatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Pjtdeldatahora_Z");
         return  ;
      }

      public bool gxTv_SdtClientePJTipo_Pjtdeldatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PjtDelData_Z" )]
      [  XmlElement( ElementName = "PjtDelData_Z"  , IsNullable=true )]
      public string gxTpr_Pjtdeldata_Z_Nullable
      {
         get {
            if ( gxTv_SdtClientePJTipo_Pjtdeldata_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtClientePJTipo_Pjtdeldata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtClientePJTipo_Pjtdeldata_Z = DateTime.MinValue;
            else
               gxTv_SdtClientePJTipo_Pjtdeldata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Pjtdeldata_Z
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtdeldata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtdeldata_Z = value;
            SetDirty("Pjtdeldata_Z");
         }

      }

      public void gxTv_SdtClientePJTipo_Pjtdeldata_Z_SetNull( )
      {
         gxTv_SdtClientePJTipo_Pjtdeldata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Pjtdeldata_Z");
         return  ;
      }

      public bool gxTv_SdtClientePJTipo_Pjtdeldata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PjtDelHora_Z" )]
      [  XmlElement( ElementName = "PjtDelHora_Z"  , IsNullable=true )]
      public string gxTpr_Pjtdelhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtClientePJTipo_Pjtdelhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtClientePJTipo_Pjtdelhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtClientePJTipo_Pjtdelhora_Z = DateTime.MinValue;
            else
               gxTv_SdtClientePJTipo_Pjtdelhora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Pjtdelhora_Z
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtdelhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtdelhora_Z = value;
            SetDirty("Pjtdelhora_Z");
         }

      }

      public void gxTv_SdtClientePJTipo_Pjtdelhora_Z_SetNull( )
      {
         gxTv_SdtClientePJTipo_Pjtdelhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Pjtdelhora_Z");
         return  ;
      }

      public bool gxTv_SdtClientePJTipo_Pjtdelhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PjtDelUsuId_Z" )]
      [  XmlElement( ElementName = "PjtDelUsuId_Z"   )]
      public string gxTpr_Pjtdelusuid_Z
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtdelusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtdelusuid_Z = value;
            SetDirty("Pjtdelusuid_Z");
         }

      }

      public void gxTv_SdtClientePJTipo_Pjtdelusuid_Z_SetNull( )
      {
         gxTv_SdtClientePJTipo_Pjtdelusuid_Z = "";
         SetDirty("Pjtdelusuid_Z");
         return  ;
      }

      public bool gxTv_SdtClientePJTipo_Pjtdelusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PjtDelUsuNome_Z" )]
      [  XmlElement( ElementName = "PjtDelUsuNome_Z"   )]
      public string gxTpr_Pjtdelusunome_Z
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtdelusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtdelusunome_Z = value;
            SetDirty("Pjtdelusunome_Z");
         }

      }

      public void gxTv_SdtClientePJTipo_Pjtdelusunome_Z_SetNull( )
      {
         gxTv_SdtClientePJTipo_Pjtdelusunome_Z = "";
         SetDirty("Pjtdelusunome_Z");
         return  ;
      }

      public bool gxTv_SdtClientePJTipo_Pjtdelusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PjtDelDataHora_N" )]
      [  XmlElement( ElementName = "PjtDelDataHora_N"   )]
      public short gxTpr_Pjtdeldatahora_N
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtdeldatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtdeldatahora_N = value;
            SetDirty("Pjtdeldatahora_N");
         }

      }

      public void gxTv_SdtClientePJTipo_Pjtdeldatahora_N_SetNull( )
      {
         gxTv_SdtClientePJTipo_Pjtdeldatahora_N = 0;
         SetDirty("Pjtdeldatahora_N");
         return  ;
      }

      public bool gxTv_SdtClientePJTipo_Pjtdeldatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PjtDelData_N" )]
      [  XmlElement( ElementName = "PjtDelData_N"   )]
      public short gxTpr_Pjtdeldata_N
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtdeldata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtdeldata_N = value;
            SetDirty("Pjtdeldata_N");
         }

      }

      public void gxTv_SdtClientePJTipo_Pjtdeldata_N_SetNull( )
      {
         gxTv_SdtClientePJTipo_Pjtdeldata_N = 0;
         SetDirty("Pjtdeldata_N");
         return  ;
      }

      public bool gxTv_SdtClientePJTipo_Pjtdeldata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PjtDelHora_N" )]
      [  XmlElement( ElementName = "PjtDelHora_N"   )]
      public short gxTpr_Pjtdelhora_N
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtdelhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtdelhora_N = value;
            SetDirty("Pjtdelhora_N");
         }

      }

      public void gxTv_SdtClientePJTipo_Pjtdelhora_N_SetNull( )
      {
         gxTv_SdtClientePJTipo_Pjtdelhora_N = 0;
         SetDirty("Pjtdelhora_N");
         return  ;
      }

      public bool gxTv_SdtClientePJTipo_Pjtdelhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PjtDelUsuId_N" )]
      [  XmlElement( ElementName = "PjtDelUsuId_N"   )]
      public short gxTpr_Pjtdelusuid_N
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtdelusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtdelusuid_N = value;
            SetDirty("Pjtdelusuid_N");
         }

      }

      public void gxTv_SdtClientePJTipo_Pjtdelusuid_N_SetNull( )
      {
         gxTv_SdtClientePJTipo_Pjtdelusuid_N = 0;
         SetDirty("Pjtdelusuid_N");
         return  ;
      }

      public bool gxTv_SdtClientePJTipo_Pjtdelusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PjtDelUsuNome_N" )]
      [  XmlElement( ElementName = "PjtDelUsuNome_N"   )]
      public short gxTpr_Pjtdelusunome_N
      {
         get {
            return gxTv_SdtClientePJTipo_Pjtdelusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClientePJTipo_Pjtdelusunome_N = value;
            SetDirty("Pjtdelusunome_N");
         }

      }

      public void gxTv_SdtClientePJTipo_Pjtdelusunome_N_SetNull( )
      {
         gxTv_SdtClientePJTipo_Pjtdelusunome_N = 0;
         SetDirty("Pjtdelusunome_N");
         return  ;
      }

      public bool gxTv_SdtClientePJTipo_Pjtdelusunome_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtClientePJTipo_Pjtsigla = "";
         gxTv_SdtClientePJTipo_Pjtnome = "";
         gxTv_SdtClientePJTipo_Pjtativo = true;
         gxTv_SdtClientePJTipo_Pjtdeldatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtClientePJTipo_Pjtdeldata = (DateTime)(DateTime.MinValue);
         gxTv_SdtClientePJTipo_Pjtdelhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtClientePJTipo_Pjtdelusuid = "";
         gxTv_SdtClientePJTipo_Pjtdelusunome = "";
         gxTv_SdtClientePJTipo_Mode = "";
         gxTv_SdtClientePJTipo_Pjtsigla_Z = "";
         gxTv_SdtClientePJTipo_Pjtnome_Z = "";
         gxTv_SdtClientePJTipo_Pjtdeldatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtClientePJTipo_Pjtdeldata_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtClientePJTipo_Pjtdelhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtClientePJTipo_Pjtdelusuid_Z = "";
         gxTv_SdtClientePJTipo_Pjtdelusunome_Z = "";
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "core.clientepjtipo", "GeneXus.Programs.core.clientepjtipo_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtClientePJTipo_Initialized ;
      private short gxTv_SdtClientePJTipo_Pjtdeldatahora_N ;
      private short gxTv_SdtClientePJTipo_Pjtdeldata_N ;
      private short gxTv_SdtClientePJTipo_Pjtdelhora_N ;
      private short gxTv_SdtClientePJTipo_Pjtdelusuid_N ;
      private short gxTv_SdtClientePJTipo_Pjtdelusunome_N ;
      private int gxTv_SdtClientePJTipo_Pjtid ;
      private int gxTv_SdtClientePJTipo_Pjtid_Z ;
      private string gxTv_SdtClientePJTipo_Pjtdelusuid ;
      private string gxTv_SdtClientePJTipo_Mode ;
      private string gxTv_SdtClientePJTipo_Pjtdelusuid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtClientePJTipo_Pjtdeldatahora ;
      private DateTime gxTv_SdtClientePJTipo_Pjtdeldata ;
      private DateTime gxTv_SdtClientePJTipo_Pjtdelhora ;
      private DateTime gxTv_SdtClientePJTipo_Pjtdeldatahora_Z ;
      private DateTime gxTv_SdtClientePJTipo_Pjtdeldata_Z ;
      private DateTime gxTv_SdtClientePJTipo_Pjtdelhora_Z ;
      private DateTime datetimemil_STZ ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtClientePJTipo_Pjtativo ;
      private bool gxTv_SdtClientePJTipo_Pjtdel ;
      private bool gxTv_SdtClientePJTipo_Pjtativo_Z ;
      private bool gxTv_SdtClientePJTipo_Pjtdel_Z ;
      private string gxTv_SdtClientePJTipo_Pjtsigla ;
      private string gxTv_SdtClientePJTipo_Pjtnome ;
      private string gxTv_SdtClientePJTipo_Pjtdelusunome ;
      private string gxTv_SdtClientePJTipo_Pjtsigla_Z ;
      private string gxTv_SdtClientePJTipo_Pjtnome_Z ;
      private string gxTv_SdtClientePJTipo_Pjtdelusunome_Z ;
   }

   [DataContract(Name = @"core\ClientePJTipo", Namespace = "agl_tresorygroup")]
   public class SdtClientePJTipo_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtClientePJTipo>
   {
      public SdtClientePJTipo_RESTInterface( ) : base()
      {
      }

      public SdtClientePJTipo_RESTInterface( GeneXus.Programs.core.SdtClientePJTipo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PjtID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Pjtid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Pjtid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Pjtid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PjtSigla" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Pjtsigla
      {
         get {
            return sdt.gxTpr_Pjtsigla ;
         }

         set {
            sdt.gxTpr_Pjtsigla = value;
         }

      }

      [DataMember( Name = "PjtNome" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Pjtnome
      {
         get {
            return sdt.gxTpr_Pjtnome ;
         }

         set {
            sdt.gxTpr_Pjtnome = value;
         }

      }

      [DataMember( Name = "PjtAtivo" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Pjtativo
      {
         get {
            return sdt.gxTpr_Pjtativo ;
         }

         set {
            sdt.gxTpr_Pjtativo = value;
         }

      }

      [DataMember( Name = "PjtDel" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Pjtdel
      {
         get {
            return sdt.gxTpr_Pjtdel ;
         }

         set {
            sdt.gxTpr_Pjtdel = value;
         }

      }

      [DataMember( Name = "PjtDelDataHora" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Pjtdeldatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Pjtdeldatahora) ;
         }

         set {
            sdt.gxTpr_Pjtdeldatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "PjtDelData" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Pjtdeldata
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Pjtdeldata) ;
         }

         set {
            sdt.gxTpr_Pjtdeldata = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "PjtDelHora" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Pjtdelhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Pjtdelhora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Pjtdelhora = GXt_dtime1;
         }

      }

      [DataMember( Name = "PjtDelUsuId" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Pjtdelusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Pjtdelusuid) ;
         }

         set {
            sdt.gxTpr_Pjtdelusuid = value;
         }

      }

      [DataMember( Name = "PjtDelUsuNome" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Pjtdelusunome
      {
         get {
            return sdt.gxTpr_Pjtdelusunome ;
         }

         set {
            sdt.gxTpr_Pjtdelusunome = value;
         }

      }

      public GeneXus.Programs.core.SdtClientePJTipo sdt
      {
         get {
            return (GeneXus.Programs.core.SdtClientePJTipo)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtClientePJTipo() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 10 )]
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

   [DataContract(Name = @"core\ClientePJTipo", Namespace = "agl_tresorygroup")]
   public class SdtClientePJTipo_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtClientePJTipo>
   {
      public SdtClientePJTipo_RESTLInterface( ) : base()
      {
      }

      public SdtClientePJTipo_RESTLInterface( GeneXus.Programs.core.SdtClientePJTipo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PjtNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Pjtnome
      {
         get {
            return sdt.gxTpr_Pjtnome ;
         }

         set {
            sdt.gxTpr_Pjtnome = value;
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

      public GeneXus.Programs.core.SdtClientePJTipo sdt
      {
         get {
            return (GeneXus.Programs.core.SdtClientePJTipo)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtClientePJTipo() ;
         }
      }

   }

}
