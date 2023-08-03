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
   [XmlRoot(ElementName = "CentroDeCusto" )]
   [XmlType(TypeName =  "CentroDeCusto" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class SdtCentroDeCusto : GxSilentTrnSdt
   {
      public SdtCentroDeCusto( )
      {
      }

      public SdtCentroDeCusto( IGxContext context )
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

      public void Load( int AV208CcuID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV208CcuID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CcuID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "core\\CentroDeCusto");
         metadata.Set("BT", "tb_centrodecusto");
         metadata.Set("PK", "[ \"CcuID\" ]");
         metadata.Set("PKAssigned", "[ \"CcuID\" ]");
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
         state.Add("gxTpr_Ccuid_Z");
         state.Add("gxTpr_Ccusigla_Z");
         state.Add("gxTpr_Ccunome_Z");
         state.Add("gxTpr_Ccuativo_Z");
         state.Add("gxTpr_Ccudel_Z");
         state.Add("gxTpr_Ccudeldatahora_Z_Nullable");
         state.Add("gxTpr_Ccudeldata_Z_Nullable");
         state.Add("gxTpr_Ccudelhora_Z_Nullable");
         state.Add("gxTpr_Ccudelusuid_Z");
         state.Add("gxTpr_Ccudelusunome_Z");
         state.Add("gxTpr_Ccudeldatahora_N");
         state.Add("gxTpr_Ccudeldata_N");
         state.Add("gxTpr_Ccudelhora_N");
         state.Add("gxTpr_Ccudelusuid_N");
         state.Add("gxTpr_Ccudelusunome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.SdtCentroDeCusto sdt;
         sdt = (GeneXus.Programs.core.SdtCentroDeCusto)(source);
         gxTv_SdtCentroDeCusto_Ccuid = sdt.gxTv_SdtCentroDeCusto_Ccuid ;
         gxTv_SdtCentroDeCusto_Ccusigla = sdt.gxTv_SdtCentroDeCusto_Ccusigla ;
         gxTv_SdtCentroDeCusto_Ccunome = sdt.gxTv_SdtCentroDeCusto_Ccunome ;
         gxTv_SdtCentroDeCusto_Ccuativo = sdt.gxTv_SdtCentroDeCusto_Ccuativo ;
         gxTv_SdtCentroDeCusto_Ccudel = sdt.gxTv_SdtCentroDeCusto_Ccudel ;
         gxTv_SdtCentroDeCusto_Ccudeldatahora = sdt.gxTv_SdtCentroDeCusto_Ccudeldatahora ;
         gxTv_SdtCentroDeCusto_Ccudeldata = sdt.gxTv_SdtCentroDeCusto_Ccudeldata ;
         gxTv_SdtCentroDeCusto_Ccudelhora = sdt.gxTv_SdtCentroDeCusto_Ccudelhora ;
         gxTv_SdtCentroDeCusto_Ccudelusuid = sdt.gxTv_SdtCentroDeCusto_Ccudelusuid ;
         gxTv_SdtCentroDeCusto_Ccudelusunome = sdt.gxTv_SdtCentroDeCusto_Ccudelusunome ;
         gxTv_SdtCentroDeCusto_Mode = sdt.gxTv_SdtCentroDeCusto_Mode ;
         gxTv_SdtCentroDeCusto_Initialized = sdt.gxTv_SdtCentroDeCusto_Initialized ;
         gxTv_SdtCentroDeCusto_Ccuid_Z = sdt.gxTv_SdtCentroDeCusto_Ccuid_Z ;
         gxTv_SdtCentroDeCusto_Ccusigla_Z = sdt.gxTv_SdtCentroDeCusto_Ccusigla_Z ;
         gxTv_SdtCentroDeCusto_Ccunome_Z = sdt.gxTv_SdtCentroDeCusto_Ccunome_Z ;
         gxTv_SdtCentroDeCusto_Ccuativo_Z = sdt.gxTv_SdtCentroDeCusto_Ccuativo_Z ;
         gxTv_SdtCentroDeCusto_Ccudel_Z = sdt.gxTv_SdtCentroDeCusto_Ccudel_Z ;
         gxTv_SdtCentroDeCusto_Ccudeldatahora_Z = sdt.gxTv_SdtCentroDeCusto_Ccudeldatahora_Z ;
         gxTv_SdtCentroDeCusto_Ccudeldata_Z = sdt.gxTv_SdtCentroDeCusto_Ccudeldata_Z ;
         gxTv_SdtCentroDeCusto_Ccudelhora_Z = sdt.gxTv_SdtCentroDeCusto_Ccudelhora_Z ;
         gxTv_SdtCentroDeCusto_Ccudelusuid_Z = sdt.gxTv_SdtCentroDeCusto_Ccudelusuid_Z ;
         gxTv_SdtCentroDeCusto_Ccudelusunome_Z = sdt.gxTv_SdtCentroDeCusto_Ccudelusunome_Z ;
         gxTv_SdtCentroDeCusto_Ccudeldatahora_N = sdt.gxTv_SdtCentroDeCusto_Ccudeldatahora_N ;
         gxTv_SdtCentroDeCusto_Ccudeldata_N = sdt.gxTv_SdtCentroDeCusto_Ccudeldata_N ;
         gxTv_SdtCentroDeCusto_Ccudelhora_N = sdt.gxTv_SdtCentroDeCusto_Ccudelhora_N ;
         gxTv_SdtCentroDeCusto_Ccudelusuid_N = sdt.gxTv_SdtCentroDeCusto_Ccudelusuid_N ;
         gxTv_SdtCentroDeCusto_Ccudelusunome_N = sdt.gxTv_SdtCentroDeCusto_Ccudelusunome_N ;
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
         AddObjectProperty("CcuID", gxTv_SdtCentroDeCusto_Ccuid, false, includeNonInitialized);
         AddObjectProperty("CcuSigla", gxTv_SdtCentroDeCusto_Ccusigla, false, includeNonInitialized);
         AddObjectProperty("CcuNome", gxTv_SdtCentroDeCusto_Ccunome, false, includeNonInitialized);
         AddObjectProperty("CcuAtivo", gxTv_SdtCentroDeCusto_Ccuativo, false, includeNonInitialized);
         AddObjectProperty("CcuDel", gxTv_SdtCentroDeCusto_Ccudel, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtCentroDeCusto_Ccudeldatahora;
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
         AddObjectProperty("CcuDelDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("CcuDelDataHora_N", gxTv_SdtCentroDeCusto_Ccudeldatahora_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtCentroDeCusto_Ccudeldata;
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
         AddObjectProperty("CcuDelData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("CcuDelData_N", gxTv_SdtCentroDeCusto_Ccudeldata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtCentroDeCusto_Ccudelhora;
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
         AddObjectProperty("CcuDelHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("CcuDelHora_N", gxTv_SdtCentroDeCusto_Ccudelhora_N, false, includeNonInitialized);
         AddObjectProperty("CcuDelUsuId", gxTv_SdtCentroDeCusto_Ccudelusuid, false, includeNonInitialized);
         AddObjectProperty("CcuDelUsuId_N", gxTv_SdtCentroDeCusto_Ccudelusuid_N, false, includeNonInitialized);
         AddObjectProperty("CcuDelUsuNome", gxTv_SdtCentroDeCusto_Ccudelusunome, false, includeNonInitialized);
         AddObjectProperty("CcuDelUsuNome_N", gxTv_SdtCentroDeCusto_Ccudelusunome_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCentroDeCusto_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCentroDeCusto_Initialized, false, includeNonInitialized);
            AddObjectProperty("CcuID_Z", gxTv_SdtCentroDeCusto_Ccuid_Z, false, includeNonInitialized);
            AddObjectProperty("CcuSigla_Z", gxTv_SdtCentroDeCusto_Ccusigla_Z, false, includeNonInitialized);
            AddObjectProperty("CcuNome_Z", gxTv_SdtCentroDeCusto_Ccunome_Z, false, includeNonInitialized);
            AddObjectProperty("CcuAtivo_Z", gxTv_SdtCentroDeCusto_Ccuativo_Z, false, includeNonInitialized);
            AddObjectProperty("CcuDel_Z", gxTv_SdtCentroDeCusto_Ccudel_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtCentroDeCusto_Ccudeldatahora_Z;
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
            AddObjectProperty("CcuDelDataHora_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtCentroDeCusto_Ccudeldata_Z;
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
            AddObjectProperty("CcuDelData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtCentroDeCusto_Ccudelhora_Z;
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
            AddObjectProperty("CcuDelHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("CcuDelUsuId_Z", gxTv_SdtCentroDeCusto_Ccudelusuid_Z, false, includeNonInitialized);
            AddObjectProperty("CcuDelUsuNome_Z", gxTv_SdtCentroDeCusto_Ccudelusunome_Z, false, includeNonInitialized);
            AddObjectProperty("CcuDelDataHora_N", gxTv_SdtCentroDeCusto_Ccudeldatahora_N, false, includeNonInitialized);
            AddObjectProperty("CcuDelData_N", gxTv_SdtCentroDeCusto_Ccudeldata_N, false, includeNonInitialized);
            AddObjectProperty("CcuDelHora_N", gxTv_SdtCentroDeCusto_Ccudelhora_N, false, includeNonInitialized);
            AddObjectProperty("CcuDelUsuId_N", gxTv_SdtCentroDeCusto_Ccudelusuid_N, false, includeNonInitialized);
            AddObjectProperty("CcuDelUsuNome_N", gxTv_SdtCentroDeCusto_Ccudelusunome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.SdtCentroDeCusto sdt )
      {
         if ( sdt.IsDirty("CcuID") )
         {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccuid = sdt.gxTv_SdtCentroDeCusto_Ccuid ;
         }
         if ( sdt.IsDirty("CcuSigla") )
         {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccusigla = sdt.gxTv_SdtCentroDeCusto_Ccusigla ;
         }
         if ( sdt.IsDirty("CcuNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccunome = sdt.gxTv_SdtCentroDeCusto_Ccunome ;
         }
         if ( sdt.IsDirty("CcuAtivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccuativo = sdt.gxTv_SdtCentroDeCusto_Ccuativo ;
         }
         if ( sdt.IsDirty("CcuDel") )
         {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccudel = sdt.gxTv_SdtCentroDeCusto_Ccudel ;
         }
         if ( sdt.IsDirty("CcuDelDataHora") )
         {
            gxTv_SdtCentroDeCusto_Ccudeldatahora_N = (short)(sdt.gxTv_SdtCentroDeCusto_Ccudeldatahora_N);
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccudeldatahora = sdt.gxTv_SdtCentroDeCusto_Ccudeldatahora ;
         }
         if ( sdt.IsDirty("CcuDelData") )
         {
            gxTv_SdtCentroDeCusto_Ccudeldata_N = (short)(sdt.gxTv_SdtCentroDeCusto_Ccudeldata_N);
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccudeldata = sdt.gxTv_SdtCentroDeCusto_Ccudeldata ;
         }
         if ( sdt.IsDirty("CcuDelHora") )
         {
            gxTv_SdtCentroDeCusto_Ccudelhora_N = (short)(sdt.gxTv_SdtCentroDeCusto_Ccudelhora_N);
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccudelhora = sdt.gxTv_SdtCentroDeCusto_Ccudelhora ;
         }
         if ( sdt.IsDirty("CcuDelUsuId") )
         {
            gxTv_SdtCentroDeCusto_Ccudelusuid_N = (short)(sdt.gxTv_SdtCentroDeCusto_Ccudelusuid_N);
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccudelusuid = sdt.gxTv_SdtCentroDeCusto_Ccudelusuid ;
         }
         if ( sdt.IsDirty("CcuDelUsuNome") )
         {
            gxTv_SdtCentroDeCusto_Ccudelusunome_N = (short)(sdt.gxTv_SdtCentroDeCusto_Ccudelusunome_N);
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccudelusunome = sdt.gxTv_SdtCentroDeCusto_Ccudelusunome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CcuID" )]
      [  XmlElement( ElementName = "CcuID"   )]
      public int gxTpr_Ccuid
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccuid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtCentroDeCusto_Ccuid != value )
            {
               gxTv_SdtCentroDeCusto_Mode = "INS";
               this.gxTv_SdtCentroDeCusto_Ccuid_Z_SetNull( );
               this.gxTv_SdtCentroDeCusto_Ccusigla_Z_SetNull( );
               this.gxTv_SdtCentroDeCusto_Ccunome_Z_SetNull( );
               this.gxTv_SdtCentroDeCusto_Ccuativo_Z_SetNull( );
               this.gxTv_SdtCentroDeCusto_Ccudel_Z_SetNull( );
               this.gxTv_SdtCentroDeCusto_Ccudeldatahora_Z_SetNull( );
               this.gxTv_SdtCentroDeCusto_Ccudeldata_Z_SetNull( );
               this.gxTv_SdtCentroDeCusto_Ccudelhora_Z_SetNull( );
               this.gxTv_SdtCentroDeCusto_Ccudelusuid_Z_SetNull( );
               this.gxTv_SdtCentroDeCusto_Ccudelusunome_Z_SetNull( );
            }
            gxTv_SdtCentroDeCusto_Ccuid = value;
            SetDirty("Ccuid");
         }

      }

      [  SoapElement( ElementName = "CcuSigla" )]
      [  XmlElement( ElementName = "CcuSigla"   )]
      public string gxTpr_Ccusigla
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccusigla ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccusigla = value;
            SetDirty("Ccusigla");
         }

      }

      [  SoapElement( ElementName = "CcuNome" )]
      [  XmlElement( ElementName = "CcuNome"   )]
      public string gxTpr_Ccunome
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccunome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccunome = value;
            SetDirty("Ccunome");
         }

      }

      [  SoapElement( ElementName = "CcuAtivo" )]
      [  XmlElement( ElementName = "CcuAtivo"   )]
      public bool gxTpr_Ccuativo
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccuativo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccuativo = value;
            SetDirty("Ccuativo");
         }

      }

      [  SoapElement( ElementName = "CcuDel" )]
      [  XmlElement( ElementName = "CcuDel"   )]
      public bool gxTpr_Ccudel
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccudel ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccudel = value;
            SetDirty("Ccudel");
         }

      }

      [  SoapElement( ElementName = "CcuDelDataHora" )]
      [  XmlElement( ElementName = "CcuDelDataHora"  , IsNullable=true )]
      public string gxTpr_Ccudeldatahora_Nullable
      {
         get {
            if ( gxTv_SdtCentroDeCusto_Ccudeldatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtCentroDeCusto_Ccudeldatahora, null, true).value ;
         }

         set {
            gxTv_SdtCentroDeCusto_Ccudeldatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtCentroDeCusto_Ccudeldatahora = DateTime.MinValue;
            else
               gxTv_SdtCentroDeCusto_Ccudeldatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ccudeldatahora
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccudeldatahora ;
         }

         set {
            gxTv_SdtCentroDeCusto_Ccudeldatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccudeldatahora = value;
            SetDirty("Ccudeldatahora");
         }

      }

      public void gxTv_SdtCentroDeCusto_Ccudeldatahora_SetNull( )
      {
         gxTv_SdtCentroDeCusto_Ccudeldatahora_N = 1;
         gxTv_SdtCentroDeCusto_Ccudeldatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Ccudeldatahora");
         return  ;
      }

      public bool gxTv_SdtCentroDeCusto_Ccudeldatahora_IsNull( )
      {
         return (gxTv_SdtCentroDeCusto_Ccudeldatahora_N==1) ;
      }

      [  SoapElement( ElementName = "CcuDelData" )]
      [  XmlElement( ElementName = "CcuDelData"  , IsNullable=true )]
      public string gxTpr_Ccudeldata_Nullable
      {
         get {
            if ( gxTv_SdtCentroDeCusto_Ccudeldata == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtCentroDeCusto_Ccudeldata).value ;
         }

         set {
            gxTv_SdtCentroDeCusto_Ccudeldata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtCentroDeCusto_Ccudeldata = DateTime.MinValue;
            else
               gxTv_SdtCentroDeCusto_Ccudeldata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ccudeldata
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccudeldata ;
         }

         set {
            gxTv_SdtCentroDeCusto_Ccudeldata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccudeldata = value;
            SetDirty("Ccudeldata");
         }

      }

      public void gxTv_SdtCentroDeCusto_Ccudeldata_SetNull( )
      {
         gxTv_SdtCentroDeCusto_Ccudeldata_N = 1;
         gxTv_SdtCentroDeCusto_Ccudeldata = (DateTime)(DateTime.MinValue);
         SetDirty("Ccudeldata");
         return  ;
      }

      public bool gxTv_SdtCentroDeCusto_Ccudeldata_IsNull( )
      {
         return (gxTv_SdtCentroDeCusto_Ccudeldata_N==1) ;
      }

      [  SoapElement( ElementName = "CcuDelHora" )]
      [  XmlElement( ElementName = "CcuDelHora"  , IsNullable=true )]
      public string gxTpr_Ccudelhora_Nullable
      {
         get {
            if ( gxTv_SdtCentroDeCusto_Ccudelhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtCentroDeCusto_Ccudelhora).value ;
         }

         set {
            gxTv_SdtCentroDeCusto_Ccudelhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtCentroDeCusto_Ccudelhora = DateTime.MinValue;
            else
               gxTv_SdtCentroDeCusto_Ccudelhora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ccudelhora
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccudelhora ;
         }

         set {
            gxTv_SdtCentroDeCusto_Ccudelhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccudelhora = value;
            SetDirty("Ccudelhora");
         }

      }

      public void gxTv_SdtCentroDeCusto_Ccudelhora_SetNull( )
      {
         gxTv_SdtCentroDeCusto_Ccudelhora_N = 1;
         gxTv_SdtCentroDeCusto_Ccudelhora = (DateTime)(DateTime.MinValue);
         SetDirty("Ccudelhora");
         return  ;
      }

      public bool gxTv_SdtCentroDeCusto_Ccudelhora_IsNull( )
      {
         return (gxTv_SdtCentroDeCusto_Ccudelhora_N==1) ;
      }

      [  SoapElement( ElementName = "CcuDelUsuId" )]
      [  XmlElement( ElementName = "CcuDelUsuId"   )]
      public string gxTpr_Ccudelusuid
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccudelusuid ;
         }

         set {
            gxTv_SdtCentroDeCusto_Ccudelusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccudelusuid = value;
            SetDirty("Ccudelusuid");
         }

      }

      public void gxTv_SdtCentroDeCusto_Ccudelusuid_SetNull( )
      {
         gxTv_SdtCentroDeCusto_Ccudelusuid_N = 1;
         gxTv_SdtCentroDeCusto_Ccudelusuid = "";
         SetDirty("Ccudelusuid");
         return  ;
      }

      public bool gxTv_SdtCentroDeCusto_Ccudelusuid_IsNull( )
      {
         return (gxTv_SdtCentroDeCusto_Ccudelusuid_N==1) ;
      }

      [  SoapElement( ElementName = "CcuDelUsuNome" )]
      [  XmlElement( ElementName = "CcuDelUsuNome"   )]
      public string gxTpr_Ccudelusunome
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccudelusunome ;
         }

         set {
            gxTv_SdtCentroDeCusto_Ccudelusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccudelusunome = value;
            SetDirty("Ccudelusunome");
         }

      }

      public void gxTv_SdtCentroDeCusto_Ccudelusunome_SetNull( )
      {
         gxTv_SdtCentroDeCusto_Ccudelusunome_N = 1;
         gxTv_SdtCentroDeCusto_Ccudelusunome = "";
         SetDirty("Ccudelusunome");
         return  ;
      }

      public bool gxTv_SdtCentroDeCusto_Ccudelusunome_IsNull( )
      {
         return (gxTv_SdtCentroDeCusto_Ccudelusunome_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCentroDeCusto_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCentroDeCusto_Mode_SetNull( )
      {
         gxTv_SdtCentroDeCusto_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCentroDeCusto_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCentroDeCusto_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCentroDeCusto_Initialized_SetNull( )
      {
         gxTv_SdtCentroDeCusto_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCentroDeCusto_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CcuID_Z" )]
      [  XmlElement( ElementName = "CcuID_Z"   )]
      public int gxTpr_Ccuid_Z
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccuid_Z = value;
            SetDirty("Ccuid_Z");
         }

      }

      public void gxTv_SdtCentroDeCusto_Ccuid_Z_SetNull( )
      {
         gxTv_SdtCentroDeCusto_Ccuid_Z = 0;
         SetDirty("Ccuid_Z");
         return  ;
      }

      public bool gxTv_SdtCentroDeCusto_Ccuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CcuSigla_Z" )]
      [  XmlElement( ElementName = "CcuSigla_Z"   )]
      public string gxTpr_Ccusigla_Z
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccusigla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccusigla_Z = value;
            SetDirty("Ccusigla_Z");
         }

      }

      public void gxTv_SdtCentroDeCusto_Ccusigla_Z_SetNull( )
      {
         gxTv_SdtCentroDeCusto_Ccusigla_Z = "";
         SetDirty("Ccusigla_Z");
         return  ;
      }

      public bool gxTv_SdtCentroDeCusto_Ccusigla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CcuNome_Z" )]
      [  XmlElement( ElementName = "CcuNome_Z"   )]
      public string gxTpr_Ccunome_Z
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccunome_Z = value;
            SetDirty("Ccunome_Z");
         }

      }

      public void gxTv_SdtCentroDeCusto_Ccunome_Z_SetNull( )
      {
         gxTv_SdtCentroDeCusto_Ccunome_Z = "";
         SetDirty("Ccunome_Z");
         return  ;
      }

      public bool gxTv_SdtCentroDeCusto_Ccunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CcuAtivo_Z" )]
      [  XmlElement( ElementName = "CcuAtivo_Z"   )]
      public bool gxTpr_Ccuativo_Z
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccuativo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccuativo_Z = value;
            SetDirty("Ccuativo_Z");
         }

      }

      public void gxTv_SdtCentroDeCusto_Ccuativo_Z_SetNull( )
      {
         gxTv_SdtCentroDeCusto_Ccuativo_Z = false;
         SetDirty("Ccuativo_Z");
         return  ;
      }

      public bool gxTv_SdtCentroDeCusto_Ccuativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CcuDel_Z" )]
      [  XmlElement( ElementName = "CcuDel_Z"   )]
      public bool gxTpr_Ccudel_Z
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccudel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccudel_Z = value;
            SetDirty("Ccudel_Z");
         }

      }

      public void gxTv_SdtCentroDeCusto_Ccudel_Z_SetNull( )
      {
         gxTv_SdtCentroDeCusto_Ccudel_Z = false;
         SetDirty("Ccudel_Z");
         return  ;
      }

      public bool gxTv_SdtCentroDeCusto_Ccudel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CcuDelDataHora_Z" )]
      [  XmlElement( ElementName = "CcuDelDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Ccudeldatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtCentroDeCusto_Ccudeldatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtCentroDeCusto_Ccudeldatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtCentroDeCusto_Ccudeldatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtCentroDeCusto_Ccudeldatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ccudeldatahora_Z
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccudeldatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccudeldatahora_Z = value;
            SetDirty("Ccudeldatahora_Z");
         }

      }

      public void gxTv_SdtCentroDeCusto_Ccudeldatahora_Z_SetNull( )
      {
         gxTv_SdtCentroDeCusto_Ccudeldatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Ccudeldatahora_Z");
         return  ;
      }

      public bool gxTv_SdtCentroDeCusto_Ccudeldatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CcuDelData_Z" )]
      [  XmlElement( ElementName = "CcuDelData_Z"  , IsNullable=true )]
      public string gxTpr_Ccudeldata_Z_Nullable
      {
         get {
            if ( gxTv_SdtCentroDeCusto_Ccudeldata_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtCentroDeCusto_Ccudeldata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtCentroDeCusto_Ccudeldata_Z = DateTime.MinValue;
            else
               gxTv_SdtCentroDeCusto_Ccudeldata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ccudeldata_Z
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccudeldata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccudeldata_Z = value;
            SetDirty("Ccudeldata_Z");
         }

      }

      public void gxTv_SdtCentroDeCusto_Ccudeldata_Z_SetNull( )
      {
         gxTv_SdtCentroDeCusto_Ccudeldata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Ccudeldata_Z");
         return  ;
      }

      public bool gxTv_SdtCentroDeCusto_Ccudeldata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CcuDelHora_Z" )]
      [  XmlElement( ElementName = "CcuDelHora_Z"  , IsNullable=true )]
      public string gxTpr_Ccudelhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtCentroDeCusto_Ccudelhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtCentroDeCusto_Ccudelhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtCentroDeCusto_Ccudelhora_Z = DateTime.MinValue;
            else
               gxTv_SdtCentroDeCusto_Ccudelhora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Ccudelhora_Z
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccudelhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccudelhora_Z = value;
            SetDirty("Ccudelhora_Z");
         }

      }

      public void gxTv_SdtCentroDeCusto_Ccudelhora_Z_SetNull( )
      {
         gxTv_SdtCentroDeCusto_Ccudelhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Ccudelhora_Z");
         return  ;
      }

      public bool gxTv_SdtCentroDeCusto_Ccudelhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CcuDelUsuId_Z" )]
      [  XmlElement( ElementName = "CcuDelUsuId_Z"   )]
      public string gxTpr_Ccudelusuid_Z
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccudelusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccudelusuid_Z = value;
            SetDirty("Ccudelusuid_Z");
         }

      }

      public void gxTv_SdtCentroDeCusto_Ccudelusuid_Z_SetNull( )
      {
         gxTv_SdtCentroDeCusto_Ccudelusuid_Z = "";
         SetDirty("Ccudelusuid_Z");
         return  ;
      }

      public bool gxTv_SdtCentroDeCusto_Ccudelusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CcuDelUsuNome_Z" )]
      [  XmlElement( ElementName = "CcuDelUsuNome_Z"   )]
      public string gxTpr_Ccudelusunome_Z
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccudelusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccudelusunome_Z = value;
            SetDirty("Ccudelusunome_Z");
         }

      }

      public void gxTv_SdtCentroDeCusto_Ccudelusunome_Z_SetNull( )
      {
         gxTv_SdtCentroDeCusto_Ccudelusunome_Z = "";
         SetDirty("Ccudelusunome_Z");
         return  ;
      }

      public bool gxTv_SdtCentroDeCusto_Ccudelusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CcuDelDataHora_N" )]
      [  XmlElement( ElementName = "CcuDelDataHora_N"   )]
      public short gxTpr_Ccudeldatahora_N
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccudeldatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccudeldatahora_N = value;
            SetDirty("Ccudeldatahora_N");
         }

      }

      public void gxTv_SdtCentroDeCusto_Ccudeldatahora_N_SetNull( )
      {
         gxTv_SdtCentroDeCusto_Ccudeldatahora_N = 0;
         SetDirty("Ccudeldatahora_N");
         return  ;
      }

      public bool gxTv_SdtCentroDeCusto_Ccudeldatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CcuDelData_N" )]
      [  XmlElement( ElementName = "CcuDelData_N"   )]
      public short gxTpr_Ccudeldata_N
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccudeldata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccudeldata_N = value;
            SetDirty("Ccudeldata_N");
         }

      }

      public void gxTv_SdtCentroDeCusto_Ccudeldata_N_SetNull( )
      {
         gxTv_SdtCentroDeCusto_Ccudeldata_N = 0;
         SetDirty("Ccudeldata_N");
         return  ;
      }

      public bool gxTv_SdtCentroDeCusto_Ccudeldata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CcuDelHora_N" )]
      [  XmlElement( ElementName = "CcuDelHora_N"   )]
      public short gxTpr_Ccudelhora_N
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccudelhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccudelhora_N = value;
            SetDirty("Ccudelhora_N");
         }

      }

      public void gxTv_SdtCentroDeCusto_Ccudelhora_N_SetNull( )
      {
         gxTv_SdtCentroDeCusto_Ccudelhora_N = 0;
         SetDirty("Ccudelhora_N");
         return  ;
      }

      public bool gxTv_SdtCentroDeCusto_Ccudelhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CcuDelUsuId_N" )]
      [  XmlElement( ElementName = "CcuDelUsuId_N"   )]
      public short gxTpr_Ccudelusuid_N
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccudelusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccudelusuid_N = value;
            SetDirty("Ccudelusuid_N");
         }

      }

      public void gxTv_SdtCentroDeCusto_Ccudelusuid_N_SetNull( )
      {
         gxTv_SdtCentroDeCusto_Ccudelusuid_N = 0;
         SetDirty("Ccudelusuid_N");
         return  ;
      }

      public bool gxTv_SdtCentroDeCusto_Ccudelusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CcuDelUsuNome_N" )]
      [  XmlElement( ElementName = "CcuDelUsuNome_N"   )]
      public short gxTpr_Ccudelusunome_N
      {
         get {
            return gxTv_SdtCentroDeCusto_Ccudelusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCentroDeCusto_Ccudelusunome_N = value;
            SetDirty("Ccudelusunome_N");
         }

      }

      public void gxTv_SdtCentroDeCusto_Ccudelusunome_N_SetNull( )
      {
         gxTv_SdtCentroDeCusto_Ccudelusunome_N = 0;
         SetDirty("Ccudelusunome_N");
         return  ;
      }

      public bool gxTv_SdtCentroDeCusto_Ccudelusunome_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtCentroDeCusto_Ccusigla = "";
         gxTv_SdtCentroDeCusto_Ccunome = "";
         gxTv_SdtCentroDeCusto_Ccuativo = true;
         gxTv_SdtCentroDeCusto_Ccudeldatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtCentroDeCusto_Ccudeldata = (DateTime)(DateTime.MinValue);
         gxTv_SdtCentroDeCusto_Ccudelhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtCentroDeCusto_Ccudelusuid = "";
         gxTv_SdtCentroDeCusto_Ccudelusunome = "";
         gxTv_SdtCentroDeCusto_Mode = "";
         gxTv_SdtCentroDeCusto_Ccusigla_Z = "";
         gxTv_SdtCentroDeCusto_Ccunome_Z = "";
         gxTv_SdtCentroDeCusto_Ccudeldatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtCentroDeCusto_Ccudeldata_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtCentroDeCusto_Ccudelhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtCentroDeCusto_Ccudelusuid_Z = "";
         gxTv_SdtCentroDeCusto_Ccudelusunome_Z = "";
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "core.centrodecusto", "GeneXus.Programs.core.centrodecusto_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtCentroDeCusto_Initialized ;
      private short gxTv_SdtCentroDeCusto_Ccudeldatahora_N ;
      private short gxTv_SdtCentroDeCusto_Ccudeldata_N ;
      private short gxTv_SdtCentroDeCusto_Ccudelhora_N ;
      private short gxTv_SdtCentroDeCusto_Ccudelusuid_N ;
      private short gxTv_SdtCentroDeCusto_Ccudelusunome_N ;
      private int gxTv_SdtCentroDeCusto_Ccuid ;
      private int gxTv_SdtCentroDeCusto_Ccuid_Z ;
      private string gxTv_SdtCentroDeCusto_Ccudelusuid ;
      private string gxTv_SdtCentroDeCusto_Mode ;
      private string gxTv_SdtCentroDeCusto_Ccudelusuid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtCentroDeCusto_Ccudeldatahora ;
      private DateTime gxTv_SdtCentroDeCusto_Ccudeldata ;
      private DateTime gxTv_SdtCentroDeCusto_Ccudelhora ;
      private DateTime gxTv_SdtCentroDeCusto_Ccudeldatahora_Z ;
      private DateTime gxTv_SdtCentroDeCusto_Ccudeldata_Z ;
      private DateTime gxTv_SdtCentroDeCusto_Ccudelhora_Z ;
      private DateTime datetimemil_STZ ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtCentroDeCusto_Ccuativo ;
      private bool gxTv_SdtCentroDeCusto_Ccudel ;
      private bool gxTv_SdtCentroDeCusto_Ccuativo_Z ;
      private bool gxTv_SdtCentroDeCusto_Ccudel_Z ;
      private string gxTv_SdtCentroDeCusto_Ccusigla ;
      private string gxTv_SdtCentroDeCusto_Ccunome ;
      private string gxTv_SdtCentroDeCusto_Ccudelusunome ;
      private string gxTv_SdtCentroDeCusto_Ccusigla_Z ;
      private string gxTv_SdtCentroDeCusto_Ccunome_Z ;
      private string gxTv_SdtCentroDeCusto_Ccudelusunome_Z ;
   }

   [DataContract(Name = @"core\CentroDeCusto", Namespace = "agl_tresorygroup")]
   public class SdtCentroDeCusto_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtCentroDeCusto>
   {
      public SdtCentroDeCusto_RESTInterface( ) : base()
      {
      }

      public SdtCentroDeCusto_RESTInterface( GeneXus.Programs.core.SdtCentroDeCusto psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CcuID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Ccuid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Ccuid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Ccuid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "CcuSigla" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Ccusigla
      {
         get {
            return sdt.gxTpr_Ccusigla ;
         }

         set {
            sdt.gxTpr_Ccusigla = value;
         }

      }

      [DataMember( Name = "CcuNome" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Ccunome
      {
         get {
            return sdt.gxTpr_Ccunome ;
         }

         set {
            sdt.gxTpr_Ccunome = value;
         }

      }

      [DataMember( Name = "CcuAtivo" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Ccuativo
      {
         get {
            return sdt.gxTpr_Ccuativo ;
         }

         set {
            sdt.gxTpr_Ccuativo = value;
         }

      }

      [DataMember( Name = "CcuDel" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Ccudel
      {
         get {
            return sdt.gxTpr_Ccudel ;
         }

         set {
            sdt.gxTpr_Ccudel = value;
         }

      }

      [DataMember( Name = "CcuDelDataHora" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Ccudeldatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Ccudeldatahora) ;
         }

         set {
            sdt.gxTpr_Ccudeldatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "CcuDelData" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Ccudeldata
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Ccudeldata) ;
         }

         set {
            sdt.gxTpr_Ccudeldata = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "CcuDelHora" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Ccudelhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Ccudelhora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Ccudelhora = GXt_dtime1;
         }

      }

      [DataMember( Name = "CcuDelUsuId" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Ccudelusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Ccudelusuid) ;
         }

         set {
            sdt.gxTpr_Ccudelusuid = value;
         }

      }

      [DataMember( Name = "CcuDelUsuNome" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Ccudelusunome
      {
         get {
            return sdt.gxTpr_Ccudelusunome ;
         }

         set {
            sdt.gxTpr_Ccudelusunome = value;
         }

      }

      public GeneXus.Programs.core.SdtCentroDeCusto sdt
      {
         get {
            return (GeneXus.Programs.core.SdtCentroDeCusto)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtCentroDeCusto() ;
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

   [DataContract(Name = @"core\CentroDeCusto", Namespace = "agl_tresorygroup")]
   public class SdtCentroDeCusto_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtCentroDeCusto>
   {
      public SdtCentroDeCusto_RESTLInterface( ) : base()
      {
      }

      public SdtCentroDeCusto_RESTLInterface( GeneXus.Programs.core.SdtCentroDeCusto psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CcuNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Ccunome
      {
         get {
            return sdt.gxTpr_Ccunome ;
         }

         set {
            sdt.gxTpr_Ccunome = value;
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

      public GeneXus.Programs.core.SdtCentroDeCusto sdt
      {
         get {
            return (GeneXus.Programs.core.SdtCentroDeCusto)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtCentroDeCusto() ;
         }
      }

   }

}
