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
   [XmlRoot(ElementName = "VisitaTipo" )]
   [XmlType(TypeName =  "VisitaTipo" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class SdtVisitaTipo : GxSilentTrnSdt
   {
      public SdtVisitaTipo( )
      {
      }

      public SdtVisitaTipo( IGxContext context )
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

      public void Load( int AV411VitID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV411VitID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"VitID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "core\\VisitaTipo");
         metadata.Set("BT", "tb_visitatipo");
         metadata.Set("PK", "[ \"VitID\" ]");
         metadata.Set("PKAssigned", "[ \"VitID\" ]");
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
         state.Add("gxTpr_Vitid_Z");
         state.Add("gxTpr_Vitsigla_Z");
         state.Add("gxTpr_Vitnome_Z");
         state.Add("gxTpr_Vitdel_Z");
         state.Add("gxTpr_Vitdeldatahora_Z_Nullable");
         state.Add("gxTpr_Vitdeldata_Z_Nullable");
         state.Add("gxTpr_Vitdelhora_Z_Nullable");
         state.Add("gxTpr_Vitdelusuid_Z");
         state.Add("gxTpr_Vitdelusunome_Z");
         state.Add("gxTpr_Vitdeldatahora_N");
         state.Add("gxTpr_Vitdeldata_N");
         state.Add("gxTpr_Vitdelhora_N");
         state.Add("gxTpr_Vitdelusuid_N");
         state.Add("gxTpr_Vitdelusunome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.SdtVisitaTipo sdt;
         sdt = (GeneXus.Programs.core.SdtVisitaTipo)(source);
         gxTv_SdtVisitaTipo_Vitid = sdt.gxTv_SdtVisitaTipo_Vitid ;
         gxTv_SdtVisitaTipo_Vitsigla = sdt.gxTv_SdtVisitaTipo_Vitsigla ;
         gxTv_SdtVisitaTipo_Vitnome = sdt.gxTv_SdtVisitaTipo_Vitnome ;
         gxTv_SdtVisitaTipo_Vitdel = sdt.gxTv_SdtVisitaTipo_Vitdel ;
         gxTv_SdtVisitaTipo_Vitdeldatahora = sdt.gxTv_SdtVisitaTipo_Vitdeldatahora ;
         gxTv_SdtVisitaTipo_Vitdeldata = sdt.gxTv_SdtVisitaTipo_Vitdeldata ;
         gxTv_SdtVisitaTipo_Vitdelhora = sdt.gxTv_SdtVisitaTipo_Vitdelhora ;
         gxTv_SdtVisitaTipo_Vitdelusuid = sdt.gxTv_SdtVisitaTipo_Vitdelusuid ;
         gxTv_SdtVisitaTipo_Vitdelusunome = sdt.gxTv_SdtVisitaTipo_Vitdelusunome ;
         gxTv_SdtVisitaTipo_Mode = sdt.gxTv_SdtVisitaTipo_Mode ;
         gxTv_SdtVisitaTipo_Initialized = sdt.gxTv_SdtVisitaTipo_Initialized ;
         gxTv_SdtVisitaTipo_Vitid_Z = sdt.gxTv_SdtVisitaTipo_Vitid_Z ;
         gxTv_SdtVisitaTipo_Vitsigla_Z = sdt.gxTv_SdtVisitaTipo_Vitsigla_Z ;
         gxTv_SdtVisitaTipo_Vitnome_Z = sdt.gxTv_SdtVisitaTipo_Vitnome_Z ;
         gxTv_SdtVisitaTipo_Vitdel_Z = sdt.gxTv_SdtVisitaTipo_Vitdel_Z ;
         gxTv_SdtVisitaTipo_Vitdeldatahora_Z = sdt.gxTv_SdtVisitaTipo_Vitdeldatahora_Z ;
         gxTv_SdtVisitaTipo_Vitdeldata_Z = sdt.gxTv_SdtVisitaTipo_Vitdeldata_Z ;
         gxTv_SdtVisitaTipo_Vitdelhora_Z = sdt.gxTv_SdtVisitaTipo_Vitdelhora_Z ;
         gxTv_SdtVisitaTipo_Vitdelusuid_Z = sdt.gxTv_SdtVisitaTipo_Vitdelusuid_Z ;
         gxTv_SdtVisitaTipo_Vitdelusunome_Z = sdt.gxTv_SdtVisitaTipo_Vitdelusunome_Z ;
         gxTv_SdtVisitaTipo_Vitdeldatahora_N = sdt.gxTv_SdtVisitaTipo_Vitdeldatahora_N ;
         gxTv_SdtVisitaTipo_Vitdeldata_N = sdt.gxTv_SdtVisitaTipo_Vitdeldata_N ;
         gxTv_SdtVisitaTipo_Vitdelhora_N = sdt.gxTv_SdtVisitaTipo_Vitdelhora_N ;
         gxTv_SdtVisitaTipo_Vitdelusuid_N = sdt.gxTv_SdtVisitaTipo_Vitdelusuid_N ;
         gxTv_SdtVisitaTipo_Vitdelusunome_N = sdt.gxTv_SdtVisitaTipo_Vitdelusunome_N ;
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
         AddObjectProperty("VitID", gxTv_SdtVisitaTipo_Vitid, false, includeNonInitialized);
         AddObjectProperty("VitSigla", gxTv_SdtVisitaTipo_Vitsigla, false, includeNonInitialized);
         AddObjectProperty("VitNome", gxTv_SdtVisitaTipo_Vitnome, false, includeNonInitialized);
         AddObjectProperty("VitDel", gxTv_SdtVisitaTipo_Vitdel, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtVisitaTipo_Vitdeldatahora;
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
         AddObjectProperty("VitDelDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("VitDelDataHora_N", gxTv_SdtVisitaTipo_Vitdeldatahora_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtVisitaTipo_Vitdeldata;
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
         AddObjectProperty("VitDelData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("VitDelData_N", gxTv_SdtVisitaTipo_Vitdeldata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtVisitaTipo_Vitdelhora;
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
         AddObjectProperty("VitDelHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("VitDelHora_N", gxTv_SdtVisitaTipo_Vitdelhora_N, false, includeNonInitialized);
         AddObjectProperty("VitDelUsuId", gxTv_SdtVisitaTipo_Vitdelusuid, false, includeNonInitialized);
         AddObjectProperty("VitDelUsuId_N", gxTv_SdtVisitaTipo_Vitdelusuid_N, false, includeNonInitialized);
         AddObjectProperty("VitDelUsuNome", gxTv_SdtVisitaTipo_Vitdelusunome, false, includeNonInitialized);
         AddObjectProperty("VitDelUsuNome_N", gxTv_SdtVisitaTipo_Vitdelusunome_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtVisitaTipo_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtVisitaTipo_Initialized, false, includeNonInitialized);
            AddObjectProperty("VitID_Z", gxTv_SdtVisitaTipo_Vitid_Z, false, includeNonInitialized);
            AddObjectProperty("VitSigla_Z", gxTv_SdtVisitaTipo_Vitsigla_Z, false, includeNonInitialized);
            AddObjectProperty("VitNome_Z", gxTv_SdtVisitaTipo_Vitnome_Z, false, includeNonInitialized);
            AddObjectProperty("VitDel_Z", gxTv_SdtVisitaTipo_Vitdel_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtVisitaTipo_Vitdeldatahora_Z;
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
            AddObjectProperty("VitDelDataHora_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtVisitaTipo_Vitdeldata_Z;
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
            AddObjectProperty("VitDelData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtVisitaTipo_Vitdelhora_Z;
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
            AddObjectProperty("VitDelHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("VitDelUsuId_Z", gxTv_SdtVisitaTipo_Vitdelusuid_Z, false, includeNonInitialized);
            AddObjectProperty("VitDelUsuNome_Z", gxTv_SdtVisitaTipo_Vitdelusunome_Z, false, includeNonInitialized);
            AddObjectProperty("VitDelDataHora_N", gxTv_SdtVisitaTipo_Vitdeldatahora_N, false, includeNonInitialized);
            AddObjectProperty("VitDelData_N", gxTv_SdtVisitaTipo_Vitdeldata_N, false, includeNonInitialized);
            AddObjectProperty("VitDelHora_N", gxTv_SdtVisitaTipo_Vitdelhora_N, false, includeNonInitialized);
            AddObjectProperty("VitDelUsuId_N", gxTv_SdtVisitaTipo_Vitdelusuid_N, false, includeNonInitialized);
            AddObjectProperty("VitDelUsuNome_N", gxTv_SdtVisitaTipo_Vitdelusunome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.SdtVisitaTipo sdt )
      {
         if ( sdt.IsDirty("VitID") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitid = sdt.gxTv_SdtVisitaTipo_Vitid ;
         }
         if ( sdt.IsDirty("VitSigla") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitsigla = sdt.gxTv_SdtVisitaTipo_Vitsigla ;
         }
         if ( sdt.IsDirty("VitNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitnome = sdt.gxTv_SdtVisitaTipo_Vitnome ;
         }
         if ( sdt.IsDirty("VitDel") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitdel = sdt.gxTv_SdtVisitaTipo_Vitdel ;
         }
         if ( sdt.IsDirty("VitDelDataHora") )
         {
            gxTv_SdtVisitaTipo_Vitdeldatahora_N = (short)(sdt.gxTv_SdtVisitaTipo_Vitdeldatahora_N);
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitdeldatahora = sdt.gxTv_SdtVisitaTipo_Vitdeldatahora ;
         }
         if ( sdt.IsDirty("VitDelData") )
         {
            gxTv_SdtVisitaTipo_Vitdeldata_N = (short)(sdt.gxTv_SdtVisitaTipo_Vitdeldata_N);
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitdeldata = sdt.gxTv_SdtVisitaTipo_Vitdeldata ;
         }
         if ( sdt.IsDirty("VitDelHora") )
         {
            gxTv_SdtVisitaTipo_Vitdelhora_N = (short)(sdt.gxTv_SdtVisitaTipo_Vitdelhora_N);
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitdelhora = sdt.gxTv_SdtVisitaTipo_Vitdelhora ;
         }
         if ( sdt.IsDirty("VitDelUsuId") )
         {
            gxTv_SdtVisitaTipo_Vitdelusuid_N = (short)(sdt.gxTv_SdtVisitaTipo_Vitdelusuid_N);
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitdelusuid = sdt.gxTv_SdtVisitaTipo_Vitdelusuid ;
         }
         if ( sdt.IsDirty("VitDelUsuNome") )
         {
            gxTv_SdtVisitaTipo_Vitdelusunome_N = (short)(sdt.gxTv_SdtVisitaTipo_Vitdelusunome_N);
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitdelusunome = sdt.gxTv_SdtVisitaTipo_Vitdelusunome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "VitID" )]
      [  XmlElement( ElementName = "VitID"   )]
      public int gxTpr_Vitid
      {
         get {
            return gxTv_SdtVisitaTipo_Vitid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtVisitaTipo_Vitid != value )
            {
               gxTv_SdtVisitaTipo_Mode = "INS";
               this.gxTv_SdtVisitaTipo_Vitid_Z_SetNull( );
               this.gxTv_SdtVisitaTipo_Vitsigla_Z_SetNull( );
               this.gxTv_SdtVisitaTipo_Vitnome_Z_SetNull( );
               this.gxTv_SdtVisitaTipo_Vitdel_Z_SetNull( );
               this.gxTv_SdtVisitaTipo_Vitdeldatahora_Z_SetNull( );
               this.gxTv_SdtVisitaTipo_Vitdeldata_Z_SetNull( );
               this.gxTv_SdtVisitaTipo_Vitdelhora_Z_SetNull( );
               this.gxTv_SdtVisitaTipo_Vitdelusuid_Z_SetNull( );
               this.gxTv_SdtVisitaTipo_Vitdelusunome_Z_SetNull( );
            }
            gxTv_SdtVisitaTipo_Vitid = value;
            SetDirty("Vitid");
         }

      }

      [  SoapElement( ElementName = "VitSigla" )]
      [  XmlElement( ElementName = "VitSigla"   )]
      public string gxTpr_Vitsigla
      {
         get {
            return gxTv_SdtVisitaTipo_Vitsigla ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitsigla = value;
            SetDirty("Vitsigla");
         }

      }

      [  SoapElement( ElementName = "VitNome" )]
      [  XmlElement( ElementName = "VitNome"   )]
      public string gxTpr_Vitnome
      {
         get {
            return gxTv_SdtVisitaTipo_Vitnome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitnome = value;
            SetDirty("Vitnome");
         }

      }

      [  SoapElement( ElementName = "VitDel" )]
      [  XmlElement( ElementName = "VitDel"   )]
      public bool gxTpr_Vitdel
      {
         get {
            return gxTv_SdtVisitaTipo_Vitdel ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitdel = value;
            SetDirty("Vitdel");
         }

      }

      [  SoapElement( ElementName = "VitDelDataHora" )]
      [  XmlElement( ElementName = "VitDelDataHora"  , IsNullable=true )]
      public string gxTpr_Vitdeldatahora_Nullable
      {
         get {
            if ( gxTv_SdtVisitaTipo_Vitdeldatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisitaTipo_Vitdeldatahora, null, true).value ;
         }

         set {
            gxTv_SdtVisitaTipo_Vitdeldatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisitaTipo_Vitdeldatahora = DateTime.MinValue;
            else
               gxTv_SdtVisitaTipo_Vitdeldatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Vitdeldatahora
      {
         get {
            return gxTv_SdtVisitaTipo_Vitdeldatahora ;
         }

         set {
            gxTv_SdtVisitaTipo_Vitdeldatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitdeldatahora = value;
            SetDirty("Vitdeldatahora");
         }

      }

      public void gxTv_SdtVisitaTipo_Vitdeldatahora_SetNull( )
      {
         gxTv_SdtVisitaTipo_Vitdeldatahora_N = 1;
         gxTv_SdtVisitaTipo_Vitdeldatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Vitdeldatahora");
         return  ;
      }

      public bool gxTv_SdtVisitaTipo_Vitdeldatahora_IsNull( )
      {
         return (gxTv_SdtVisitaTipo_Vitdeldatahora_N==1) ;
      }

      [  SoapElement( ElementName = "VitDelData" )]
      [  XmlElement( ElementName = "VitDelData"  , IsNullable=true )]
      public string gxTpr_Vitdeldata_Nullable
      {
         get {
            if ( gxTv_SdtVisitaTipo_Vitdeldata == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisitaTipo_Vitdeldata).value ;
         }

         set {
            gxTv_SdtVisitaTipo_Vitdeldata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisitaTipo_Vitdeldata = DateTime.MinValue;
            else
               gxTv_SdtVisitaTipo_Vitdeldata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Vitdeldata
      {
         get {
            return gxTv_SdtVisitaTipo_Vitdeldata ;
         }

         set {
            gxTv_SdtVisitaTipo_Vitdeldata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitdeldata = value;
            SetDirty("Vitdeldata");
         }

      }

      public void gxTv_SdtVisitaTipo_Vitdeldata_SetNull( )
      {
         gxTv_SdtVisitaTipo_Vitdeldata_N = 1;
         gxTv_SdtVisitaTipo_Vitdeldata = (DateTime)(DateTime.MinValue);
         SetDirty("Vitdeldata");
         return  ;
      }

      public bool gxTv_SdtVisitaTipo_Vitdeldata_IsNull( )
      {
         return (gxTv_SdtVisitaTipo_Vitdeldata_N==1) ;
      }

      [  SoapElement( ElementName = "VitDelHora" )]
      [  XmlElement( ElementName = "VitDelHora"  , IsNullable=true )]
      public string gxTpr_Vitdelhora_Nullable
      {
         get {
            if ( gxTv_SdtVisitaTipo_Vitdelhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisitaTipo_Vitdelhora).value ;
         }

         set {
            gxTv_SdtVisitaTipo_Vitdelhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisitaTipo_Vitdelhora = DateTime.MinValue;
            else
               gxTv_SdtVisitaTipo_Vitdelhora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Vitdelhora
      {
         get {
            return gxTv_SdtVisitaTipo_Vitdelhora ;
         }

         set {
            gxTv_SdtVisitaTipo_Vitdelhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitdelhora = value;
            SetDirty("Vitdelhora");
         }

      }

      public void gxTv_SdtVisitaTipo_Vitdelhora_SetNull( )
      {
         gxTv_SdtVisitaTipo_Vitdelhora_N = 1;
         gxTv_SdtVisitaTipo_Vitdelhora = (DateTime)(DateTime.MinValue);
         SetDirty("Vitdelhora");
         return  ;
      }

      public bool gxTv_SdtVisitaTipo_Vitdelhora_IsNull( )
      {
         return (gxTv_SdtVisitaTipo_Vitdelhora_N==1) ;
      }

      [  SoapElement( ElementName = "VitDelUsuId" )]
      [  XmlElement( ElementName = "VitDelUsuId"   )]
      public string gxTpr_Vitdelusuid
      {
         get {
            return gxTv_SdtVisitaTipo_Vitdelusuid ;
         }

         set {
            gxTv_SdtVisitaTipo_Vitdelusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitdelusuid = value;
            SetDirty("Vitdelusuid");
         }

      }

      public void gxTv_SdtVisitaTipo_Vitdelusuid_SetNull( )
      {
         gxTv_SdtVisitaTipo_Vitdelusuid_N = 1;
         gxTv_SdtVisitaTipo_Vitdelusuid = "";
         SetDirty("Vitdelusuid");
         return  ;
      }

      public bool gxTv_SdtVisitaTipo_Vitdelusuid_IsNull( )
      {
         return (gxTv_SdtVisitaTipo_Vitdelusuid_N==1) ;
      }

      [  SoapElement( ElementName = "VitDelUsuNome" )]
      [  XmlElement( ElementName = "VitDelUsuNome"   )]
      public string gxTpr_Vitdelusunome
      {
         get {
            return gxTv_SdtVisitaTipo_Vitdelusunome ;
         }

         set {
            gxTv_SdtVisitaTipo_Vitdelusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitdelusunome = value;
            SetDirty("Vitdelusunome");
         }

      }

      public void gxTv_SdtVisitaTipo_Vitdelusunome_SetNull( )
      {
         gxTv_SdtVisitaTipo_Vitdelusunome_N = 1;
         gxTv_SdtVisitaTipo_Vitdelusunome = "";
         SetDirty("Vitdelusunome");
         return  ;
      }

      public bool gxTv_SdtVisitaTipo_Vitdelusunome_IsNull( )
      {
         return (gxTv_SdtVisitaTipo_Vitdelusunome_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtVisitaTipo_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtVisitaTipo_Mode_SetNull( )
      {
         gxTv_SdtVisitaTipo_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtVisitaTipo_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtVisitaTipo_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtVisitaTipo_Initialized_SetNull( )
      {
         gxTv_SdtVisitaTipo_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtVisitaTipo_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VitID_Z" )]
      [  XmlElement( ElementName = "VitID_Z"   )]
      public int gxTpr_Vitid_Z
      {
         get {
            return gxTv_SdtVisitaTipo_Vitid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitid_Z = value;
            SetDirty("Vitid_Z");
         }

      }

      public void gxTv_SdtVisitaTipo_Vitid_Z_SetNull( )
      {
         gxTv_SdtVisitaTipo_Vitid_Z = 0;
         SetDirty("Vitid_Z");
         return  ;
      }

      public bool gxTv_SdtVisitaTipo_Vitid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VitSigla_Z" )]
      [  XmlElement( ElementName = "VitSigla_Z"   )]
      public string gxTpr_Vitsigla_Z
      {
         get {
            return gxTv_SdtVisitaTipo_Vitsigla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitsigla_Z = value;
            SetDirty("Vitsigla_Z");
         }

      }

      public void gxTv_SdtVisitaTipo_Vitsigla_Z_SetNull( )
      {
         gxTv_SdtVisitaTipo_Vitsigla_Z = "";
         SetDirty("Vitsigla_Z");
         return  ;
      }

      public bool gxTv_SdtVisitaTipo_Vitsigla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VitNome_Z" )]
      [  XmlElement( ElementName = "VitNome_Z"   )]
      public string gxTpr_Vitnome_Z
      {
         get {
            return gxTv_SdtVisitaTipo_Vitnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitnome_Z = value;
            SetDirty("Vitnome_Z");
         }

      }

      public void gxTv_SdtVisitaTipo_Vitnome_Z_SetNull( )
      {
         gxTv_SdtVisitaTipo_Vitnome_Z = "";
         SetDirty("Vitnome_Z");
         return  ;
      }

      public bool gxTv_SdtVisitaTipo_Vitnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VitDel_Z" )]
      [  XmlElement( ElementName = "VitDel_Z"   )]
      public bool gxTpr_Vitdel_Z
      {
         get {
            return gxTv_SdtVisitaTipo_Vitdel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitdel_Z = value;
            SetDirty("Vitdel_Z");
         }

      }

      public void gxTv_SdtVisitaTipo_Vitdel_Z_SetNull( )
      {
         gxTv_SdtVisitaTipo_Vitdel_Z = false;
         SetDirty("Vitdel_Z");
         return  ;
      }

      public bool gxTv_SdtVisitaTipo_Vitdel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VitDelDataHora_Z" )]
      [  XmlElement( ElementName = "VitDelDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Vitdeldatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtVisitaTipo_Vitdeldatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisitaTipo_Vitdeldatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisitaTipo_Vitdeldatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtVisitaTipo_Vitdeldatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Vitdeldatahora_Z
      {
         get {
            return gxTv_SdtVisitaTipo_Vitdeldatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitdeldatahora_Z = value;
            SetDirty("Vitdeldatahora_Z");
         }

      }

      public void gxTv_SdtVisitaTipo_Vitdeldatahora_Z_SetNull( )
      {
         gxTv_SdtVisitaTipo_Vitdeldatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Vitdeldatahora_Z");
         return  ;
      }

      public bool gxTv_SdtVisitaTipo_Vitdeldatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VitDelData_Z" )]
      [  XmlElement( ElementName = "VitDelData_Z"  , IsNullable=true )]
      public string gxTpr_Vitdeldata_Z_Nullable
      {
         get {
            if ( gxTv_SdtVisitaTipo_Vitdeldata_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisitaTipo_Vitdeldata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisitaTipo_Vitdeldata_Z = DateTime.MinValue;
            else
               gxTv_SdtVisitaTipo_Vitdeldata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Vitdeldata_Z
      {
         get {
            return gxTv_SdtVisitaTipo_Vitdeldata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitdeldata_Z = value;
            SetDirty("Vitdeldata_Z");
         }

      }

      public void gxTv_SdtVisitaTipo_Vitdeldata_Z_SetNull( )
      {
         gxTv_SdtVisitaTipo_Vitdeldata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Vitdeldata_Z");
         return  ;
      }

      public bool gxTv_SdtVisitaTipo_Vitdeldata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VitDelHora_Z" )]
      [  XmlElement( ElementName = "VitDelHora_Z"  , IsNullable=true )]
      public string gxTpr_Vitdelhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtVisitaTipo_Vitdelhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisitaTipo_Vitdelhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisitaTipo_Vitdelhora_Z = DateTime.MinValue;
            else
               gxTv_SdtVisitaTipo_Vitdelhora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Vitdelhora_Z
      {
         get {
            return gxTv_SdtVisitaTipo_Vitdelhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitdelhora_Z = value;
            SetDirty("Vitdelhora_Z");
         }

      }

      public void gxTv_SdtVisitaTipo_Vitdelhora_Z_SetNull( )
      {
         gxTv_SdtVisitaTipo_Vitdelhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Vitdelhora_Z");
         return  ;
      }

      public bool gxTv_SdtVisitaTipo_Vitdelhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VitDelUsuId_Z" )]
      [  XmlElement( ElementName = "VitDelUsuId_Z"   )]
      public string gxTpr_Vitdelusuid_Z
      {
         get {
            return gxTv_SdtVisitaTipo_Vitdelusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitdelusuid_Z = value;
            SetDirty("Vitdelusuid_Z");
         }

      }

      public void gxTv_SdtVisitaTipo_Vitdelusuid_Z_SetNull( )
      {
         gxTv_SdtVisitaTipo_Vitdelusuid_Z = "";
         SetDirty("Vitdelusuid_Z");
         return  ;
      }

      public bool gxTv_SdtVisitaTipo_Vitdelusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VitDelUsuNome_Z" )]
      [  XmlElement( ElementName = "VitDelUsuNome_Z"   )]
      public string gxTpr_Vitdelusunome_Z
      {
         get {
            return gxTv_SdtVisitaTipo_Vitdelusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitdelusunome_Z = value;
            SetDirty("Vitdelusunome_Z");
         }

      }

      public void gxTv_SdtVisitaTipo_Vitdelusunome_Z_SetNull( )
      {
         gxTv_SdtVisitaTipo_Vitdelusunome_Z = "";
         SetDirty("Vitdelusunome_Z");
         return  ;
      }

      public bool gxTv_SdtVisitaTipo_Vitdelusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VitDelDataHora_N" )]
      [  XmlElement( ElementName = "VitDelDataHora_N"   )]
      public short gxTpr_Vitdeldatahora_N
      {
         get {
            return gxTv_SdtVisitaTipo_Vitdeldatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitdeldatahora_N = value;
            SetDirty("Vitdeldatahora_N");
         }

      }

      public void gxTv_SdtVisitaTipo_Vitdeldatahora_N_SetNull( )
      {
         gxTv_SdtVisitaTipo_Vitdeldatahora_N = 0;
         SetDirty("Vitdeldatahora_N");
         return  ;
      }

      public bool gxTv_SdtVisitaTipo_Vitdeldatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VitDelData_N" )]
      [  XmlElement( ElementName = "VitDelData_N"   )]
      public short gxTpr_Vitdeldata_N
      {
         get {
            return gxTv_SdtVisitaTipo_Vitdeldata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitdeldata_N = value;
            SetDirty("Vitdeldata_N");
         }

      }

      public void gxTv_SdtVisitaTipo_Vitdeldata_N_SetNull( )
      {
         gxTv_SdtVisitaTipo_Vitdeldata_N = 0;
         SetDirty("Vitdeldata_N");
         return  ;
      }

      public bool gxTv_SdtVisitaTipo_Vitdeldata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VitDelHora_N" )]
      [  XmlElement( ElementName = "VitDelHora_N"   )]
      public short gxTpr_Vitdelhora_N
      {
         get {
            return gxTv_SdtVisitaTipo_Vitdelhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitdelhora_N = value;
            SetDirty("Vitdelhora_N");
         }

      }

      public void gxTv_SdtVisitaTipo_Vitdelhora_N_SetNull( )
      {
         gxTv_SdtVisitaTipo_Vitdelhora_N = 0;
         SetDirty("Vitdelhora_N");
         return  ;
      }

      public bool gxTv_SdtVisitaTipo_Vitdelhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VitDelUsuId_N" )]
      [  XmlElement( ElementName = "VitDelUsuId_N"   )]
      public short gxTpr_Vitdelusuid_N
      {
         get {
            return gxTv_SdtVisitaTipo_Vitdelusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitdelusuid_N = value;
            SetDirty("Vitdelusuid_N");
         }

      }

      public void gxTv_SdtVisitaTipo_Vitdelusuid_N_SetNull( )
      {
         gxTv_SdtVisitaTipo_Vitdelusuid_N = 0;
         SetDirty("Vitdelusuid_N");
         return  ;
      }

      public bool gxTv_SdtVisitaTipo_Vitdelusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VitDelUsuNome_N" )]
      [  XmlElement( ElementName = "VitDelUsuNome_N"   )]
      public short gxTpr_Vitdelusunome_N
      {
         get {
            return gxTv_SdtVisitaTipo_Vitdelusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisitaTipo_Vitdelusunome_N = value;
            SetDirty("Vitdelusunome_N");
         }

      }

      public void gxTv_SdtVisitaTipo_Vitdelusunome_N_SetNull( )
      {
         gxTv_SdtVisitaTipo_Vitdelusunome_N = 0;
         SetDirty("Vitdelusunome_N");
         return  ;
      }

      public bool gxTv_SdtVisitaTipo_Vitdelusunome_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtVisitaTipo_Vitsigla = "";
         gxTv_SdtVisitaTipo_Vitnome = "";
         gxTv_SdtVisitaTipo_Vitdeldatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisitaTipo_Vitdeldata = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisitaTipo_Vitdelhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisitaTipo_Vitdelusuid = "";
         gxTv_SdtVisitaTipo_Vitdelusunome = "";
         gxTv_SdtVisitaTipo_Mode = "";
         gxTv_SdtVisitaTipo_Vitsigla_Z = "";
         gxTv_SdtVisitaTipo_Vitnome_Z = "";
         gxTv_SdtVisitaTipo_Vitdeldatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisitaTipo_Vitdeldata_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisitaTipo_Vitdelhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisitaTipo_Vitdelusuid_Z = "";
         gxTv_SdtVisitaTipo_Vitdelusunome_Z = "";
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "core.visitatipo", "GeneXus.Programs.core.visitatipo_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtVisitaTipo_Initialized ;
      private short gxTv_SdtVisitaTipo_Vitdeldatahora_N ;
      private short gxTv_SdtVisitaTipo_Vitdeldata_N ;
      private short gxTv_SdtVisitaTipo_Vitdelhora_N ;
      private short gxTv_SdtVisitaTipo_Vitdelusuid_N ;
      private short gxTv_SdtVisitaTipo_Vitdelusunome_N ;
      private int gxTv_SdtVisitaTipo_Vitid ;
      private int gxTv_SdtVisitaTipo_Vitid_Z ;
      private string gxTv_SdtVisitaTipo_Vitdelusuid ;
      private string gxTv_SdtVisitaTipo_Mode ;
      private string gxTv_SdtVisitaTipo_Vitdelusuid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtVisitaTipo_Vitdeldatahora ;
      private DateTime gxTv_SdtVisitaTipo_Vitdeldata ;
      private DateTime gxTv_SdtVisitaTipo_Vitdelhora ;
      private DateTime gxTv_SdtVisitaTipo_Vitdeldatahora_Z ;
      private DateTime gxTv_SdtVisitaTipo_Vitdeldata_Z ;
      private DateTime gxTv_SdtVisitaTipo_Vitdelhora_Z ;
      private DateTime datetimemil_STZ ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtVisitaTipo_Vitdel ;
      private bool gxTv_SdtVisitaTipo_Vitdel_Z ;
      private string gxTv_SdtVisitaTipo_Vitsigla ;
      private string gxTv_SdtVisitaTipo_Vitnome ;
      private string gxTv_SdtVisitaTipo_Vitdelusunome ;
      private string gxTv_SdtVisitaTipo_Vitsigla_Z ;
      private string gxTv_SdtVisitaTipo_Vitnome_Z ;
      private string gxTv_SdtVisitaTipo_Vitdelusunome_Z ;
   }

   [DataContract(Name = @"core\VisitaTipo", Namespace = "agl_tresorygroup")]
   public class SdtVisitaTipo_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtVisitaTipo>
   {
      public SdtVisitaTipo_RESTInterface( ) : base()
      {
      }

      public SdtVisitaTipo_RESTInterface( GeneXus.Programs.core.SdtVisitaTipo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "VitID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Vitid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Vitid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Vitid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "VitSigla" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Vitsigla
      {
         get {
            return sdt.gxTpr_Vitsigla ;
         }

         set {
            sdt.gxTpr_Vitsigla = value;
         }

      }

      [DataMember( Name = "VitNome" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Vitnome
      {
         get {
            return sdt.gxTpr_Vitnome ;
         }

         set {
            sdt.gxTpr_Vitnome = value;
         }

      }

      [DataMember( Name = "VitDel" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Vitdel
      {
         get {
            return sdt.gxTpr_Vitdel ;
         }

         set {
            sdt.gxTpr_Vitdel = value;
         }

      }

      [DataMember( Name = "VitDelDataHora" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Vitdeldatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Vitdeldatahora) ;
         }

         set {
            sdt.gxTpr_Vitdeldatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "VitDelData" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Vitdeldata
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Vitdeldata) ;
         }

         set {
            sdt.gxTpr_Vitdeldata = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "VitDelHora" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Vitdelhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Vitdelhora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Vitdelhora = GXt_dtime1;
         }

      }

      [DataMember( Name = "VitDelUsuId" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Vitdelusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Vitdelusuid) ;
         }

         set {
            sdt.gxTpr_Vitdelusuid = value;
         }

      }

      [DataMember( Name = "VitDelUsuNome" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Vitdelusunome
      {
         get {
            return sdt.gxTpr_Vitdelusunome ;
         }

         set {
            sdt.gxTpr_Vitdelusunome = value;
         }

      }

      public GeneXus.Programs.core.SdtVisitaTipo sdt
      {
         get {
            return (GeneXus.Programs.core.SdtVisitaTipo)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtVisitaTipo() ;
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

   [DataContract(Name = @"core\VisitaTipo", Namespace = "agl_tresorygroup")]
   public class SdtVisitaTipo_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtVisitaTipo>
   {
      public SdtVisitaTipo_RESTLInterface( ) : base()
      {
      }

      public SdtVisitaTipo_RESTLInterface( GeneXus.Programs.core.SdtVisitaTipo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "VitNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Vitnome
      {
         get {
            return sdt.gxTpr_Vitnome ;
         }

         set {
            sdt.gxTpr_Vitnome = value;
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

      public GeneXus.Programs.core.SdtVisitaTipo sdt
      {
         get {
            return (GeneXus.Programs.core.SdtVisitaTipo)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtVisitaTipo() ;
         }
      }

   }

}
