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
   [XmlRoot(ElementName = "Genero" )]
   [XmlType(TypeName =  "Genero" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class SdtGenero : GxSilentTrnSdt
   {
      public SdtGenero( )
      {
      }

      public SdtGenero( IGxContext context )
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

      public void Load( int AV152GenID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV152GenID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"GenID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "core\\Genero");
         metadata.Set("BT", "tb_genero");
         metadata.Set("PK", "[ \"GenID\" ]");
         metadata.Set("PKAssigned", "[ \"GenID\" ]");
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
         state.Add("gxTpr_Genid_Z");
         state.Add("gxTpr_Gensigla_Z");
         state.Add("gxTpr_Gennome_Z");
         state.Add("gxTpr_Genativo_Z");
         state.Add("gxTpr_Gendel_Z");
         state.Add("gxTpr_Gendeldatahora_Z_Nullable");
         state.Add("gxTpr_Gendeldata_Z_Nullable");
         state.Add("gxTpr_Gendelhora_Z_Nullable");
         state.Add("gxTpr_Gendelusuid_Z");
         state.Add("gxTpr_Gendelusunome_Z");
         state.Add("gxTpr_Gendeldatahora_N");
         state.Add("gxTpr_Gendeldata_N");
         state.Add("gxTpr_Gendelhora_N");
         state.Add("gxTpr_Gendelusuid_N");
         state.Add("gxTpr_Gendelusunome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.SdtGenero sdt;
         sdt = (GeneXus.Programs.core.SdtGenero)(source);
         gxTv_SdtGenero_Genid = sdt.gxTv_SdtGenero_Genid ;
         gxTv_SdtGenero_Gensigla = sdt.gxTv_SdtGenero_Gensigla ;
         gxTv_SdtGenero_Gennome = sdt.gxTv_SdtGenero_Gennome ;
         gxTv_SdtGenero_Genativo = sdt.gxTv_SdtGenero_Genativo ;
         gxTv_SdtGenero_Gendel = sdt.gxTv_SdtGenero_Gendel ;
         gxTv_SdtGenero_Gendeldatahora = sdt.gxTv_SdtGenero_Gendeldatahora ;
         gxTv_SdtGenero_Gendeldata = sdt.gxTv_SdtGenero_Gendeldata ;
         gxTv_SdtGenero_Gendelhora = sdt.gxTv_SdtGenero_Gendelhora ;
         gxTv_SdtGenero_Gendelusuid = sdt.gxTv_SdtGenero_Gendelusuid ;
         gxTv_SdtGenero_Gendelusunome = sdt.gxTv_SdtGenero_Gendelusunome ;
         gxTv_SdtGenero_Mode = sdt.gxTv_SdtGenero_Mode ;
         gxTv_SdtGenero_Initialized = sdt.gxTv_SdtGenero_Initialized ;
         gxTv_SdtGenero_Genid_Z = sdt.gxTv_SdtGenero_Genid_Z ;
         gxTv_SdtGenero_Gensigla_Z = sdt.gxTv_SdtGenero_Gensigla_Z ;
         gxTv_SdtGenero_Gennome_Z = sdt.gxTv_SdtGenero_Gennome_Z ;
         gxTv_SdtGenero_Genativo_Z = sdt.gxTv_SdtGenero_Genativo_Z ;
         gxTv_SdtGenero_Gendel_Z = sdt.gxTv_SdtGenero_Gendel_Z ;
         gxTv_SdtGenero_Gendeldatahora_Z = sdt.gxTv_SdtGenero_Gendeldatahora_Z ;
         gxTv_SdtGenero_Gendeldata_Z = sdt.gxTv_SdtGenero_Gendeldata_Z ;
         gxTv_SdtGenero_Gendelhora_Z = sdt.gxTv_SdtGenero_Gendelhora_Z ;
         gxTv_SdtGenero_Gendelusuid_Z = sdt.gxTv_SdtGenero_Gendelusuid_Z ;
         gxTv_SdtGenero_Gendelusunome_Z = sdt.gxTv_SdtGenero_Gendelusunome_Z ;
         gxTv_SdtGenero_Gendeldatahora_N = sdt.gxTv_SdtGenero_Gendeldatahora_N ;
         gxTv_SdtGenero_Gendeldata_N = sdt.gxTv_SdtGenero_Gendeldata_N ;
         gxTv_SdtGenero_Gendelhora_N = sdt.gxTv_SdtGenero_Gendelhora_N ;
         gxTv_SdtGenero_Gendelusuid_N = sdt.gxTv_SdtGenero_Gendelusuid_N ;
         gxTv_SdtGenero_Gendelusunome_N = sdt.gxTv_SdtGenero_Gendelusunome_N ;
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
         AddObjectProperty("GenID", gxTv_SdtGenero_Genid, false, includeNonInitialized);
         AddObjectProperty("GenSigla", gxTv_SdtGenero_Gensigla, false, includeNonInitialized);
         AddObjectProperty("GenNome", gxTv_SdtGenero_Gennome, false, includeNonInitialized);
         AddObjectProperty("GenAtivo", gxTv_SdtGenero_Genativo, false, includeNonInitialized);
         AddObjectProperty("GenDel", gxTv_SdtGenero_Gendel, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtGenero_Gendeldatahora;
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
         AddObjectProperty("GenDelDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("GenDelDataHora_N", gxTv_SdtGenero_Gendeldatahora_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtGenero_Gendeldata;
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
         AddObjectProperty("GenDelData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("GenDelData_N", gxTv_SdtGenero_Gendeldata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtGenero_Gendelhora;
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
         AddObjectProperty("GenDelHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("GenDelHora_N", gxTv_SdtGenero_Gendelhora_N, false, includeNonInitialized);
         AddObjectProperty("GenDelUsuId", gxTv_SdtGenero_Gendelusuid, false, includeNonInitialized);
         AddObjectProperty("GenDelUsuId_N", gxTv_SdtGenero_Gendelusuid_N, false, includeNonInitialized);
         AddObjectProperty("GenDelUsuNome", gxTv_SdtGenero_Gendelusunome, false, includeNonInitialized);
         AddObjectProperty("GenDelUsuNome_N", gxTv_SdtGenero_Gendelusunome_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtGenero_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtGenero_Initialized, false, includeNonInitialized);
            AddObjectProperty("GenID_Z", gxTv_SdtGenero_Genid_Z, false, includeNonInitialized);
            AddObjectProperty("GenSigla_Z", gxTv_SdtGenero_Gensigla_Z, false, includeNonInitialized);
            AddObjectProperty("GenNome_Z", gxTv_SdtGenero_Gennome_Z, false, includeNonInitialized);
            AddObjectProperty("GenAtivo_Z", gxTv_SdtGenero_Genativo_Z, false, includeNonInitialized);
            AddObjectProperty("GenDel_Z", gxTv_SdtGenero_Gendel_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtGenero_Gendeldatahora_Z;
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
            AddObjectProperty("GenDelDataHora_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtGenero_Gendeldata_Z;
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
            AddObjectProperty("GenDelData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtGenero_Gendelhora_Z;
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
            AddObjectProperty("GenDelHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("GenDelUsuId_Z", gxTv_SdtGenero_Gendelusuid_Z, false, includeNonInitialized);
            AddObjectProperty("GenDelUsuNome_Z", gxTv_SdtGenero_Gendelusunome_Z, false, includeNonInitialized);
            AddObjectProperty("GenDelDataHora_N", gxTv_SdtGenero_Gendeldatahora_N, false, includeNonInitialized);
            AddObjectProperty("GenDelData_N", gxTv_SdtGenero_Gendeldata_N, false, includeNonInitialized);
            AddObjectProperty("GenDelHora_N", gxTv_SdtGenero_Gendelhora_N, false, includeNonInitialized);
            AddObjectProperty("GenDelUsuId_N", gxTv_SdtGenero_Gendelusuid_N, false, includeNonInitialized);
            AddObjectProperty("GenDelUsuNome_N", gxTv_SdtGenero_Gendelusunome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.SdtGenero sdt )
      {
         if ( sdt.IsDirty("GenID") )
         {
            sdtIsNull = 0;
            gxTv_SdtGenero_Genid = sdt.gxTv_SdtGenero_Genid ;
         }
         if ( sdt.IsDirty("GenSigla") )
         {
            sdtIsNull = 0;
            gxTv_SdtGenero_Gensigla = sdt.gxTv_SdtGenero_Gensigla ;
         }
         if ( sdt.IsDirty("GenNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtGenero_Gennome = sdt.gxTv_SdtGenero_Gennome ;
         }
         if ( sdt.IsDirty("GenAtivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtGenero_Genativo = sdt.gxTv_SdtGenero_Genativo ;
         }
         if ( sdt.IsDirty("GenDel") )
         {
            sdtIsNull = 0;
            gxTv_SdtGenero_Gendel = sdt.gxTv_SdtGenero_Gendel ;
         }
         if ( sdt.IsDirty("GenDelDataHora") )
         {
            gxTv_SdtGenero_Gendeldatahora_N = (short)(sdt.gxTv_SdtGenero_Gendeldatahora_N);
            sdtIsNull = 0;
            gxTv_SdtGenero_Gendeldatahora = sdt.gxTv_SdtGenero_Gendeldatahora ;
         }
         if ( sdt.IsDirty("GenDelData") )
         {
            gxTv_SdtGenero_Gendeldata_N = (short)(sdt.gxTv_SdtGenero_Gendeldata_N);
            sdtIsNull = 0;
            gxTv_SdtGenero_Gendeldata = sdt.gxTv_SdtGenero_Gendeldata ;
         }
         if ( sdt.IsDirty("GenDelHora") )
         {
            gxTv_SdtGenero_Gendelhora_N = (short)(sdt.gxTv_SdtGenero_Gendelhora_N);
            sdtIsNull = 0;
            gxTv_SdtGenero_Gendelhora = sdt.gxTv_SdtGenero_Gendelhora ;
         }
         if ( sdt.IsDirty("GenDelUsuId") )
         {
            gxTv_SdtGenero_Gendelusuid_N = (short)(sdt.gxTv_SdtGenero_Gendelusuid_N);
            sdtIsNull = 0;
            gxTv_SdtGenero_Gendelusuid = sdt.gxTv_SdtGenero_Gendelusuid ;
         }
         if ( sdt.IsDirty("GenDelUsuNome") )
         {
            gxTv_SdtGenero_Gendelusunome_N = (short)(sdt.gxTv_SdtGenero_Gendelusunome_N);
            sdtIsNull = 0;
            gxTv_SdtGenero_Gendelusunome = sdt.gxTv_SdtGenero_Gendelusunome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "GenID" )]
      [  XmlElement( ElementName = "GenID"   )]
      public int gxTpr_Genid
      {
         get {
            return gxTv_SdtGenero_Genid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtGenero_Genid != value )
            {
               gxTv_SdtGenero_Mode = "INS";
               this.gxTv_SdtGenero_Genid_Z_SetNull( );
               this.gxTv_SdtGenero_Gensigla_Z_SetNull( );
               this.gxTv_SdtGenero_Gennome_Z_SetNull( );
               this.gxTv_SdtGenero_Genativo_Z_SetNull( );
               this.gxTv_SdtGenero_Gendel_Z_SetNull( );
               this.gxTv_SdtGenero_Gendeldatahora_Z_SetNull( );
               this.gxTv_SdtGenero_Gendeldata_Z_SetNull( );
               this.gxTv_SdtGenero_Gendelhora_Z_SetNull( );
               this.gxTv_SdtGenero_Gendelusuid_Z_SetNull( );
               this.gxTv_SdtGenero_Gendelusunome_Z_SetNull( );
            }
            gxTv_SdtGenero_Genid = value;
            SetDirty("Genid");
         }

      }

      [  SoapElement( ElementName = "GenSigla" )]
      [  XmlElement( ElementName = "GenSigla"   )]
      public string gxTpr_Gensigla
      {
         get {
            return gxTv_SdtGenero_Gensigla ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGenero_Gensigla = value;
            SetDirty("Gensigla");
         }

      }

      [  SoapElement( ElementName = "GenNome" )]
      [  XmlElement( ElementName = "GenNome"   )]
      public string gxTpr_Gennome
      {
         get {
            return gxTv_SdtGenero_Gennome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGenero_Gennome = value;
            SetDirty("Gennome");
         }

      }

      [  SoapElement( ElementName = "GenAtivo" )]
      [  XmlElement( ElementName = "GenAtivo"   )]
      public bool gxTpr_Genativo
      {
         get {
            return gxTv_SdtGenero_Genativo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGenero_Genativo = value;
            SetDirty("Genativo");
         }

      }

      [  SoapElement( ElementName = "GenDel" )]
      [  XmlElement( ElementName = "GenDel"   )]
      public bool gxTpr_Gendel
      {
         get {
            return gxTv_SdtGenero_Gendel ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGenero_Gendel = value;
            SetDirty("Gendel");
         }

      }

      [  SoapElement( ElementName = "GenDelDataHora" )]
      [  XmlElement( ElementName = "GenDelDataHora"  , IsNullable=true )]
      public string gxTpr_Gendeldatahora_Nullable
      {
         get {
            if ( gxTv_SdtGenero_Gendeldatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtGenero_Gendeldatahora, null, true).value ;
         }

         set {
            gxTv_SdtGenero_Gendeldatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtGenero_Gendeldatahora = DateTime.MinValue;
            else
               gxTv_SdtGenero_Gendeldatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Gendeldatahora
      {
         get {
            return gxTv_SdtGenero_Gendeldatahora ;
         }

         set {
            gxTv_SdtGenero_Gendeldatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtGenero_Gendeldatahora = value;
            SetDirty("Gendeldatahora");
         }

      }

      public void gxTv_SdtGenero_Gendeldatahora_SetNull( )
      {
         gxTv_SdtGenero_Gendeldatahora_N = 1;
         gxTv_SdtGenero_Gendeldatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Gendeldatahora");
         return  ;
      }

      public bool gxTv_SdtGenero_Gendeldatahora_IsNull( )
      {
         return (gxTv_SdtGenero_Gendeldatahora_N==1) ;
      }

      [  SoapElement( ElementName = "GenDelData" )]
      [  XmlElement( ElementName = "GenDelData"  , IsNullable=true )]
      public string gxTpr_Gendeldata_Nullable
      {
         get {
            if ( gxTv_SdtGenero_Gendeldata == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtGenero_Gendeldata).value ;
         }

         set {
            gxTv_SdtGenero_Gendeldata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtGenero_Gendeldata = DateTime.MinValue;
            else
               gxTv_SdtGenero_Gendeldata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Gendeldata
      {
         get {
            return gxTv_SdtGenero_Gendeldata ;
         }

         set {
            gxTv_SdtGenero_Gendeldata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtGenero_Gendeldata = value;
            SetDirty("Gendeldata");
         }

      }

      public void gxTv_SdtGenero_Gendeldata_SetNull( )
      {
         gxTv_SdtGenero_Gendeldata_N = 1;
         gxTv_SdtGenero_Gendeldata = (DateTime)(DateTime.MinValue);
         SetDirty("Gendeldata");
         return  ;
      }

      public bool gxTv_SdtGenero_Gendeldata_IsNull( )
      {
         return (gxTv_SdtGenero_Gendeldata_N==1) ;
      }

      [  SoapElement( ElementName = "GenDelHora" )]
      [  XmlElement( ElementName = "GenDelHora"  , IsNullable=true )]
      public string gxTpr_Gendelhora_Nullable
      {
         get {
            if ( gxTv_SdtGenero_Gendelhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtGenero_Gendelhora).value ;
         }

         set {
            gxTv_SdtGenero_Gendelhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtGenero_Gendelhora = DateTime.MinValue;
            else
               gxTv_SdtGenero_Gendelhora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Gendelhora
      {
         get {
            return gxTv_SdtGenero_Gendelhora ;
         }

         set {
            gxTv_SdtGenero_Gendelhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtGenero_Gendelhora = value;
            SetDirty("Gendelhora");
         }

      }

      public void gxTv_SdtGenero_Gendelhora_SetNull( )
      {
         gxTv_SdtGenero_Gendelhora_N = 1;
         gxTv_SdtGenero_Gendelhora = (DateTime)(DateTime.MinValue);
         SetDirty("Gendelhora");
         return  ;
      }

      public bool gxTv_SdtGenero_Gendelhora_IsNull( )
      {
         return (gxTv_SdtGenero_Gendelhora_N==1) ;
      }

      [  SoapElement( ElementName = "GenDelUsuId" )]
      [  XmlElement( ElementName = "GenDelUsuId"   )]
      public string gxTpr_Gendelusuid
      {
         get {
            return gxTv_SdtGenero_Gendelusuid ;
         }

         set {
            gxTv_SdtGenero_Gendelusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtGenero_Gendelusuid = value;
            SetDirty("Gendelusuid");
         }

      }

      public void gxTv_SdtGenero_Gendelusuid_SetNull( )
      {
         gxTv_SdtGenero_Gendelusuid_N = 1;
         gxTv_SdtGenero_Gendelusuid = "";
         SetDirty("Gendelusuid");
         return  ;
      }

      public bool gxTv_SdtGenero_Gendelusuid_IsNull( )
      {
         return (gxTv_SdtGenero_Gendelusuid_N==1) ;
      }

      [  SoapElement( ElementName = "GenDelUsuNome" )]
      [  XmlElement( ElementName = "GenDelUsuNome"   )]
      public string gxTpr_Gendelusunome
      {
         get {
            return gxTv_SdtGenero_Gendelusunome ;
         }

         set {
            gxTv_SdtGenero_Gendelusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtGenero_Gendelusunome = value;
            SetDirty("Gendelusunome");
         }

      }

      public void gxTv_SdtGenero_Gendelusunome_SetNull( )
      {
         gxTv_SdtGenero_Gendelusunome_N = 1;
         gxTv_SdtGenero_Gendelusunome = "";
         SetDirty("Gendelusunome");
         return  ;
      }

      public bool gxTv_SdtGenero_Gendelusunome_IsNull( )
      {
         return (gxTv_SdtGenero_Gendelusunome_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtGenero_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGenero_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtGenero_Mode_SetNull( )
      {
         gxTv_SdtGenero_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtGenero_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtGenero_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGenero_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtGenero_Initialized_SetNull( )
      {
         gxTv_SdtGenero_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtGenero_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GenID_Z" )]
      [  XmlElement( ElementName = "GenID_Z"   )]
      public int gxTpr_Genid_Z
      {
         get {
            return gxTv_SdtGenero_Genid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGenero_Genid_Z = value;
            SetDirty("Genid_Z");
         }

      }

      public void gxTv_SdtGenero_Genid_Z_SetNull( )
      {
         gxTv_SdtGenero_Genid_Z = 0;
         SetDirty("Genid_Z");
         return  ;
      }

      public bool gxTv_SdtGenero_Genid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GenSigla_Z" )]
      [  XmlElement( ElementName = "GenSigla_Z"   )]
      public string gxTpr_Gensigla_Z
      {
         get {
            return gxTv_SdtGenero_Gensigla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGenero_Gensigla_Z = value;
            SetDirty("Gensigla_Z");
         }

      }

      public void gxTv_SdtGenero_Gensigla_Z_SetNull( )
      {
         gxTv_SdtGenero_Gensigla_Z = "";
         SetDirty("Gensigla_Z");
         return  ;
      }

      public bool gxTv_SdtGenero_Gensigla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GenNome_Z" )]
      [  XmlElement( ElementName = "GenNome_Z"   )]
      public string gxTpr_Gennome_Z
      {
         get {
            return gxTv_SdtGenero_Gennome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGenero_Gennome_Z = value;
            SetDirty("Gennome_Z");
         }

      }

      public void gxTv_SdtGenero_Gennome_Z_SetNull( )
      {
         gxTv_SdtGenero_Gennome_Z = "";
         SetDirty("Gennome_Z");
         return  ;
      }

      public bool gxTv_SdtGenero_Gennome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GenAtivo_Z" )]
      [  XmlElement( ElementName = "GenAtivo_Z"   )]
      public bool gxTpr_Genativo_Z
      {
         get {
            return gxTv_SdtGenero_Genativo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGenero_Genativo_Z = value;
            SetDirty("Genativo_Z");
         }

      }

      public void gxTv_SdtGenero_Genativo_Z_SetNull( )
      {
         gxTv_SdtGenero_Genativo_Z = false;
         SetDirty("Genativo_Z");
         return  ;
      }

      public bool gxTv_SdtGenero_Genativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GenDel_Z" )]
      [  XmlElement( ElementName = "GenDel_Z"   )]
      public bool gxTpr_Gendel_Z
      {
         get {
            return gxTv_SdtGenero_Gendel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGenero_Gendel_Z = value;
            SetDirty("Gendel_Z");
         }

      }

      public void gxTv_SdtGenero_Gendel_Z_SetNull( )
      {
         gxTv_SdtGenero_Gendel_Z = false;
         SetDirty("Gendel_Z");
         return  ;
      }

      public bool gxTv_SdtGenero_Gendel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GenDelDataHora_Z" )]
      [  XmlElement( ElementName = "GenDelDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Gendeldatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtGenero_Gendeldatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtGenero_Gendeldatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtGenero_Gendeldatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtGenero_Gendeldatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Gendeldatahora_Z
      {
         get {
            return gxTv_SdtGenero_Gendeldatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGenero_Gendeldatahora_Z = value;
            SetDirty("Gendeldatahora_Z");
         }

      }

      public void gxTv_SdtGenero_Gendeldatahora_Z_SetNull( )
      {
         gxTv_SdtGenero_Gendeldatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Gendeldatahora_Z");
         return  ;
      }

      public bool gxTv_SdtGenero_Gendeldatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GenDelData_Z" )]
      [  XmlElement( ElementName = "GenDelData_Z"  , IsNullable=true )]
      public string gxTpr_Gendeldata_Z_Nullable
      {
         get {
            if ( gxTv_SdtGenero_Gendeldata_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtGenero_Gendeldata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtGenero_Gendeldata_Z = DateTime.MinValue;
            else
               gxTv_SdtGenero_Gendeldata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Gendeldata_Z
      {
         get {
            return gxTv_SdtGenero_Gendeldata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGenero_Gendeldata_Z = value;
            SetDirty("Gendeldata_Z");
         }

      }

      public void gxTv_SdtGenero_Gendeldata_Z_SetNull( )
      {
         gxTv_SdtGenero_Gendeldata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Gendeldata_Z");
         return  ;
      }

      public bool gxTv_SdtGenero_Gendeldata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GenDelHora_Z" )]
      [  XmlElement( ElementName = "GenDelHora_Z"  , IsNullable=true )]
      public string gxTpr_Gendelhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtGenero_Gendelhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtGenero_Gendelhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtGenero_Gendelhora_Z = DateTime.MinValue;
            else
               gxTv_SdtGenero_Gendelhora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Gendelhora_Z
      {
         get {
            return gxTv_SdtGenero_Gendelhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGenero_Gendelhora_Z = value;
            SetDirty("Gendelhora_Z");
         }

      }

      public void gxTv_SdtGenero_Gendelhora_Z_SetNull( )
      {
         gxTv_SdtGenero_Gendelhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Gendelhora_Z");
         return  ;
      }

      public bool gxTv_SdtGenero_Gendelhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GenDelUsuId_Z" )]
      [  XmlElement( ElementName = "GenDelUsuId_Z"   )]
      public string gxTpr_Gendelusuid_Z
      {
         get {
            return gxTv_SdtGenero_Gendelusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGenero_Gendelusuid_Z = value;
            SetDirty("Gendelusuid_Z");
         }

      }

      public void gxTv_SdtGenero_Gendelusuid_Z_SetNull( )
      {
         gxTv_SdtGenero_Gendelusuid_Z = "";
         SetDirty("Gendelusuid_Z");
         return  ;
      }

      public bool gxTv_SdtGenero_Gendelusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GenDelUsuNome_Z" )]
      [  XmlElement( ElementName = "GenDelUsuNome_Z"   )]
      public string gxTpr_Gendelusunome_Z
      {
         get {
            return gxTv_SdtGenero_Gendelusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGenero_Gendelusunome_Z = value;
            SetDirty("Gendelusunome_Z");
         }

      }

      public void gxTv_SdtGenero_Gendelusunome_Z_SetNull( )
      {
         gxTv_SdtGenero_Gendelusunome_Z = "";
         SetDirty("Gendelusunome_Z");
         return  ;
      }

      public bool gxTv_SdtGenero_Gendelusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GenDelDataHora_N" )]
      [  XmlElement( ElementName = "GenDelDataHora_N"   )]
      public short gxTpr_Gendeldatahora_N
      {
         get {
            return gxTv_SdtGenero_Gendeldatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGenero_Gendeldatahora_N = value;
            SetDirty("Gendeldatahora_N");
         }

      }

      public void gxTv_SdtGenero_Gendeldatahora_N_SetNull( )
      {
         gxTv_SdtGenero_Gendeldatahora_N = 0;
         SetDirty("Gendeldatahora_N");
         return  ;
      }

      public bool gxTv_SdtGenero_Gendeldatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GenDelData_N" )]
      [  XmlElement( ElementName = "GenDelData_N"   )]
      public short gxTpr_Gendeldata_N
      {
         get {
            return gxTv_SdtGenero_Gendeldata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGenero_Gendeldata_N = value;
            SetDirty("Gendeldata_N");
         }

      }

      public void gxTv_SdtGenero_Gendeldata_N_SetNull( )
      {
         gxTv_SdtGenero_Gendeldata_N = 0;
         SetDirty("Gendeldata_N");
         return  ;
      }

      public bool gxTv_SdtGenero_Gendeldata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GenDelHora_N" )]
      [  XmlElement( ElementName = "GenDelHora_N"   )]
      public short gxTpr_Gendelhora_N
      {
         get {
            return gxTv_SdtGenero_Gendelhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGenero_Gendelhora_N = value;
            SetDirty("Gendelhora_N");
         }

      }

      public void gxTv_SdtGenero_Gendelhora_N_SetNull( )
      {
         gxTv_SdtGenero_Gendelhora_N = 0;
         SetDirty("Gendelhora_N");
         return  ;
      }

      public bool gxTv_SdtGenero_Gendelhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GenDelUsuId_N" )]
      [  XmlElement( ElementName = "GenDelUsuId_N"   )]
      public short gxTpr_Gendelusuid_N
      {
         get {
            return gxTv_SdtGenero_Gendelusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGenero_Gendelusuid_N = value;
            SetDirty("Gendelusuid_N");
         }

      }

      public void gxTv_SdtGenero_Gendelusuid_N_SetNull( )
      {
         gxTv_SdtGenero_Gendelusuid_N = 0;
         SetDirty("Gendelusuid_N");
         return  ;
      }

      public bool gxTv_SdtGenero_Gendelusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GenDelUsuNome_N" )]
      [  XmlElement( ElementName = "GenDelUsuNome_N"   )]
      public short gxTpr_Gendelusunome_N
      {
         get {
            return gxTv_SdtGenero_Gendelusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGenero_Gendelusunome_N = value;
            SetDirty("Gendelusunome_N");
         }

      }

      public void gxTv_SdtGenero_Gendelusunome_N_SetNull( )
      {
         gxTv_SdtGenero_Gendelusunome_N = 0;
         SetDirty("Gendelusunome_N");
         return  ;
      }

      public bool gxTv_SdtGenero_Gendelusunome_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtGenero_Gensigla = "";
         gxTv_SdtGenero_Gennome = "";
         gxTv_SdtGenero_Genativo = true;
         gxTv_SdtGenero_Gendeldatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtGenero_Gendeldata = (DateTime)(DateTime.MinValue);
         gxTv_SdtGenero_Gendelhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtGenero_Gendelusuid = "";
         gxTv_SdtGenero_Gendelusunome = "";
         gxTv_SdtGenero_Mode = "";
         gxTv_SdtGenero_Gensigla_Z = "";
         gxTv_SdtGenero_Gennome_Z = "";
         gxTv_SdtGenero_Gendeldatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtGenero_Gendeldata_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtGenero_Gendelhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtGenero_Gendelusuid_Z = "";
         gxTv_SdtGenero_Gendelusunome_Z = "";
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "core.genero", "GeneXus.Programs.core.genero_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtGenero_Initialized ;
      private short gxTv_SdtGenero_Gendeldatahora_N ;
      private short gxTv_SdtGenero_Gendeldata_N ;
      private short gxTv_SdtGenero_Gendelhora_N ;
      private short gxTv_SdtGenero_Gendelusuid_N ;
      private short gxTv_SdtGenero_Gendelusunome_N ;
      private int gxTv_SdtGenero_Genid ;
      private int gxTv_SdtGenero_Genid_Z ;
      private string gxTv_SdtGenero_Gendelusuid ;
      private string gxTv_SdtGenero_Mode ;
      private string gxTv_SdtGenero_Gendelusuid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtGenero_Gendeldatahora ;
      private DateTime gxTv_SdtGenero_Gendeldata ;
      private DateTime gxTv_SdtGenero_Gendelhora ;
      private DateTime gxTv_SdtGenero_Gendeldatahora_Z ;
      private DateTime gxTv_SdtGenero_Gendeldata_Z ;
      private DateTime gxTv_SdtGenero_Gendelhora_Z ;
      private DateTime datetimemil_STZ ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtGenero_Genativo ;
      private bool gxTv_SdtGenero_Gendel ;
      private bool gxTv_SdtGenero_Genativo_Z ;
      private bool gxTv_SdtGenero_Gendel_Z ;
      private string gxTv_SdtGenero_Gensigla ;
      private string gxTv_SdtGenero_Gennome ;
      private string gxTv_SdtGenero_Gendelusunome ;
      private string gxTv_SdtGenero_Gensigla_Z ;
      private string gxTv_SdtGenero_Gennome_Z ;
      private string gxTv_SdtGenero_Gendelusunome_Z ;
   }

   [DataContract(Name = @"core\Genero", Namespace = "agl_tresorygroup")]
   public class SdtGenero_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtGenero>
   {
      public SdtGenero_RESTInterface( ) : base()
      {
      }

      public SdtGenero_RESTInterface( GeneXus.Programs.core.SdtGenero psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "GenID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Genid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Genid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Genid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "GenSigla" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Gensigla
      {
         get {
            return sdt.gxTpr_Gensigla ;
         }

         set {
            sdt.gxTpr_Gensigla = value;
         }

      }

      [DataMember( Name = "GenNome" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Gennome
      {
         get {
            return sdt.gxTpr_Gennome ;
         }

         set {
            sdt.gxTpr_Gennome = value;
         }

      }

      [DataMember( Name = "GenAtivo" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Genativo
      {
         get {
            return sdt.gxTpr_Genativo ;
         }

         set {
            sdt.gxTpr_Genativo = value;
         }

      }

      [DataMember( Name = "GenDel" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Gendel
      {
         get {
            return sdt.gxTpr_Gendel ;
         }

         set {
            sdt.gxTpr_Gendel = value;
         }

      }

      [DataMember( Name = "GenDelDataHora" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Gendeldatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Gendeldatahora) ;
         }

         set {
            sdt.gxTpr_Gendeldatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "GenDelData" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Gendeldata
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Gendeldata) ;
         }

         set {
            sdt.gxTpr_Gendeldata = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "GenDelHora" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Gendelhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Gendelhora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Gendelhora = GXt_dtime1;
         }

      }

      [DataMember( Name = "GenDelUsuId" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Gendelusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Gendelusuid) ;
         }

         set {
            sdt.gxTpr_Gendelusuid = value;
         }

      }

      [DataMember( Name = "GenDelUsuNome" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Gendelusunome
      {
         get {
            return sdt.gxTpr_Gendelusunome ;
         }

         set {
            sdt.gxTpr_Gendelusunome = value;
         }

      }

      public GeneXus.Programs.core.SdtGenero sdt
      {
         get {
            return (GeneXus.Programs.core.SdtGenero)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtGenero() ;
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

   [DataContract(Name = @"core\Genero", Namespace = "agl_tresorygroup")]
   public class SdtGenero_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtGenero>
   {
      public SdtGenero_RESTLInterface( ) : base()
      {
      }

      public SdtGenero_RESTLInterface( GeneXus.Programs.core.SdtGenero psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "GenSigla" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Gensigla
      {
         get {
            return sdt.gxTpr_Gensigla ;
         }

         set {
            sdt.gxTpr_Gensigla = value;
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

      public GeneXus.Programs.core.SdtGenero sdt
      {
         get {
            return (GeneXus.Programs.core.SdtGenero)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtGenero() ;
         }
      }

   }

}
