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
   [XmlRoot(ElementName = "ContatoTipo" )]
   [XmlType(TypeName =  "ContatoTipo" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class SdtContatoTipo : GxSilentTrnSdt
   {
      public SdtContatoTipo( )
      {
      }

      public SdtContatoTipo( IGxContext context )
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

      public void Load( int AV149CotID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV149CotID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CotID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "core\\ContatoTipo");
         metadata.Set("BT", "tb_contatotipo");
         metadata.Set("PK", "[ \"CotID\" ]");
         metadata.Set("PKAssigned", "[ \"CotID\" ]");
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
         state.Add("gxTpr_Cotid_Z");
         state.Add("gxTpr_Cotsigla_Z");
         state.Add("gxTpr_Cotnome_Z");
         state.Add("gxTpr_Cotativo_Z");
         state.Add("gxTpr_Cotdel_Z");
         state.Add("gxTpr_Cotdeldatahora_Z_Nullable");
         state.Add("gxTpr_Cotdeldata_Z_Nullable");
         state.Add("gxTpr_Cotdelhora_Z_Nullable");
         state.Add("gxTpr_Cotdelusuid_Z");
         state.Add("gxTpr_Cotdelusunome_Z");
         state.Add("gxTpr_Cotdeldatahora_N");
         state.Add("gxTpr_Cotdeldata_N");
         state.Add("gxTpr_Cotdelhora_N");
         state.Add("gxTpr_Cotdelusuid_N");
         state.Add("gxTpr_Cotdelusunome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.SdtContatoTipo sdt;
         sdt = (GeneXus.Programs.core.SdtContatoTipo)(source);
         gxTv_SdtContatoTipo_Cotid = sdt.gxTv_SdtContatoTipo_Cotid ;
         gxTv_SdtContatoTipo_Cotsigla = sdt.gxTv_SdtContatoTipo_Cotsigla ;
         gxTv_SdtContatoTipo_Cotnome = sdt.gxTv_SdtContatoTipo_Cotnome ;
         gxTv_SdtContatoTipo_Cotativo = sdt.gxTv_SdtContatoTipo_Cotativo ;
         gxTv_SdtContatoTipo_Cotdel = sdt.gxTv_SdtContatoTipo_Cotdel ;
         gxTv_SdtContatoTipo_Cotdeldatahora = sdt.gxTv_SdtContatoTipo_Cotdeldatahora ;
         gxTv_SdtContatoTipo_Cotdeldata = sdt.gxTv_SdtContatoTipo_Cotdeldata ;
         gxTv_SdtContatoTipo_Cotdelhora = sdt.gxTv_SdtContatoTipo_Cotdelhora ;
         gxTv_SdtContatoTipo_Cotdelusuid = sdt.gxTv_SdtContatoTipo_Cotdelusuid ;
         gxTv_SdtContatoTipo_Cotdelusunome = sdt.gxTv_SdtContatoTipo_Cotdelusunome ;
         gxTv_SdtContatoTipo_Mode = sdt.gxTv_SdtContatoTipo_Mode ;
         gxTv_SdtContatoTipo_Initialized = sdt.gxTv_SdtContatoTipo_Initialized ;
         gxTv_SdtContatoTipo_Cotid_Z = sdt.gxTv_SdtContatoTipo_Cotid_Z ;
         gxTv_SdtContatoTipo_Cotsigla_Z = sdt.gxTv_SdtContatoTipo_Cotsigla_Z ;
         gxTv_SdtContatoTipo_Cotnome_Z = sdt.gxTv_SdtContatoTipo_Cotnome_Z ;
         gxTv_SdtContatoTipo_Cotativo_Z = sdt.gxTv_SdtContatoTipo_Cotativo_Z ;
         gxTv_SdtContatoTipo_Cotdel_Z = sdt.gxTv_SdtContatoTipo_Cotdel_Z ;
         gxTv_SdtContatoTipo_Cotdeldatahora_Z = sdt.gxTv_SdtContatoTipo_Cotdeldatahora_Z ;
         gxTv_SdtContatoTipo_Cotdeldata_Z = sdt.gxTv_SdtContatoTipo_Cotdeldata_Z ;
         gxTv_SdtContatoTipo_Cotdelhora_Z = sdt.gxTv_SdtContatoTipo_Cotdelhora_Z ;
         gxTv_SdtContatoTipo_Cotdelusuid_Z = sdt.gxTv_SdtContatoTipo_Cotdelusuid_Z ;
         gxTv_SdtContatoTipo_Cotdelusunome_Z = sdt.gxTv_SdtContatoTipo_Cotdelusunome_Z ;
         gxTv_SdtContatoTipo_Cotdeldatahora_N = sdt.gxTv_SdtContatoTipo_Cotdeldatahora_N ;
         gxTv_SdtContatoTipo_Cotdeldata_N = sdt.gxTv_SdtContatoTipo_Cotdeldata_N ;
         gxTv_SdtContatoTipo_Cotdelhora_N = sdt.gxTv_SdtContatoTipo_Cotdelhora_N ;
         gxTv_SdtContatoTipo_Cotdelusuid_N = sdt.gxTv_SdtContatoTipo_Cotdelusuid_N ;
         gxTv_SdtContatoTipo_Cotdelusunome_N = sdt.gxTv_SdtContatoTipo_Cotdelusunome_N ;
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
         AddObjectProperty("CotID", gxTv_SdtContatoTipo_Cotid, false, includeNonInitialized);
         AddObjectProperty("CotSigla", gxTv_SdtContatoTipo_Cotsigla, false, includeNonInitialized);
         AddObjectProperty("CotNome", gxTv_SdtContatoTipo_Cotnome, false, includeNonInitialized);
         AddObjectProperty("CotAtivo", gxTv_SdtContatoTipo_Cotativo, false, includeNonInitialized);
         AddObjectProperty("CotDel", gxTv_SdtContatoTipo_Cotdel, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtContatoTipo_Cotdeldatahora;
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
         AddObjectProperty("CotDelDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("CotDelDataHora_N", gxTv_SdtContatoTipo_Cotdeldatahora_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtContatoTipo_Cotdeldata;
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
         AddObjectProperty("CotDelData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("CotDelData_N", gxTv_SdtContatoTipo_Cotdeldata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtContatoTipo_Cotdelhora;
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
         AddObjectProperty("CotDelHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("CotDelHora_N", gxTv_SdtContatoTipo_Cotdelhora_N, false, includeNonInitialized);
         AddObjectProperty("CotDelUsuId", gxTv_SdtContatoTipo_Cotdelusuid, false, includeNonInitialized);
         AddObjectProperty("CotDelUsuId_N", gxTv_SdtContatoTipo_Cotdelusuid_N, false, includeNonInitialized);
         AddObjectProperty("CotDelUsuNome", gxTv_SdtContatoTipo_Cotdelusunome, false, includeNonInitialized);
         AddObjectProperty("CotDelUsuNome_N", gxTv_SdtContatoTipo_Cotdelusunome_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtContatoTipo_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtContatoTipo_Initialized, false, includeNonInitialized);
            AddObjectProperty("CotID_Z", gxTv_SdtContatoTipo_Cotid_Z, false, includeNonInitialized);
            AddObjectProperty("CotSigla_Z", gxTv_SdtContatoTipo_Cotsigla_Z, false, includeNonInitialized);
            AddObjectProperty("CotNome_Z", gxTv_SdtContatoTipo_Cotnome_Z, false, includeNonInitialized);
            AddObjectProperty("CotAtivo_Z", gxTv_SdtContatoTipo_Cotativo_Z, false, includeNonInitialized);
            AddObjectProperty("CotDel_Z", gxTv_SdtContatoTipo_Cotdel_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtContatoTipo_Cotdeldatahora_Z;
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
            AddObjectProperty("CotDelDataHora_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtContatoTipo_Cotdeldata_Z;
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
            AddObjectProperty("CotDelData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtContatoTipo_Cotdelhora_Z;
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
            AddObjectProperty("CotDelHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("CotDelUsuId_Z", gxTv_SdtContatoTipo_Cotdelusuid_Z, false, includeNonInitialized);
            AddObjectProperty("CotDelUsuNome_Z", gxTv_SdtContatoTipo_Cotdelusunome_Z, false, includeNonInitialized);
            AddObjectProperty("CotDelDataHora_N", gxTv_SdtContatoTipo_Cotdeldatahora_N, false, includeNonInitialized);
            AddObjectProperty("CotDelData_N", gxTv_SdtContatoTipo_Cotdeldata_N, false, includeNonInitialized);
            AddObjectProperty("CotDelHora_N", gxTv_SdtContatoTipo_Cotdelhora_N, false, includeNonInitialized);
            AddObjectProperty("CotDelUsuId_N", gxTv_SdtContatoTipo_Cotdelusuid_N, false, includeNonInitialized);
            AddObjectProperty("CotDelUsuNome_N", gxTv_SdtContatoTipo_Cotdelusunome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.SdtContatoTipo sdt )
      {
         if ( sdt.IsDirty("CotID") )
         {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotid = sdt.gxTv_SdtContatoTipo_Cotid ;
         }
         if ( sdt.IsDirty("CotSigla") )
         {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotsigla = sdt.gxTv_SdtContatoTipo_Cotsigla ;
         }
         if ( sdt.IsDirty("CotNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotnome = sdt.gxTv_SdtContatoTipo_Cotnome ;
         }
         if ( sdt.IsDirty("CotAtivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotativo = sdt.gxTv_SdtContatoTipo_Cotativo ;
         }
         if ( sdt.IsDirty("CotDel") )
         {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotdel = sdt.gxTv_SdtContatoTipo_Cotdel ;
         }
         if ( sdt.IsDirty("CotDelDataHora") )
         {
            gxTv_SdtContatoTipo_Cotdeldatahora_N = (short)(sdt.gxTv_SdtContatoTipo_Cotdeldatahora_N);
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotdeldatahora = sdt.gxTv_SdtContatoTipo_Cotdeldatahora ;
         }
         if ( sdt.IsDirty("CotDelData") )
         {
            gxTv_SdtContatoTipo_Cotdeldata_N = (short)(sdt.gxTv_SdtContatoTipo_Cotdeldata_N);
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotdeldata = sdt.gxTv_SdtContatoTipo_Cotdeldata ;
         }
         if ( sdt.IsDirty("CotDelHora") )
         {
            gxTv_SdtContatoTipo_Cotdelhora_N = (short)(sdt.gxTv_SdtContatoTipo_Cotdelhora_N);
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotdelhora = sdt.gxTv_SdtContatoTipo_Cotdelhora ;
         }
         if ( sdt.IsDirty("CotDelUsuId") )
         {
            gxTv_SdtContatoTipo_Cotdelusuid_N = (short)(sdt.gxTv_SdtContatoTipo_Cotdelusuid_N);
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotdelusuid = sdt.gxTv_SdtContatoTipo_Cotdelusuid ;
         }
         if ( sdt.IsDirty("CotDelUsuNome") )
         {
            gxTv_SdtContatoTipo_Cotdelusunome_N = (short)(sdt.gxTv_SdtContatoTipo_Cotdelusunome_N);
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotdelusunome = sdt.gxTv_SdtContatoTipo_Cotdelusunome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CotID" )]
      [  XmlElement( ElementName = "CotID"   )]
      public int gxTpr_Cotid
      {
         get {
            return gxTv_SdtContatoTipo_Cotid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtContatoTipo_Cotid != value )
            {
               gxTv_SdtContatoTipo_Mode = "INS";
               this.gxTv_SdtContatoTipo_Cotid_Z_SetNull( );
               this.gxTv_SdtContatoTipo_Cotsigla_Z_SetNull( );
               this.gxTv_SdtContatoTipo_Cotnome_Z_SetNull( );
               this.gxTv_SdtContatoTipo_Cotativo_Z_SetNull( );
               this.gxTv_SdtContatoTipo_Cotdel_Z_SetNull( );
               this.gxTv_SdtContatoTipo_Cotdeldatahora_Z_SetNull( );
               this.gxTv_SdtContatoTipo_Cotdeldata_Z_SetNull( );
               this.gxTv_SdtContatoTipo_Cotdelhora_Z_SetNull( );
               this.gxTv_SdtContatoTipo_Cotdelusuid_Z_SetNull( );
               this.gxTv_SdtContatoTipo_Cotdelusunome_Z_SetNull( );
            }
            gxTv_SdtContatoTipo_Cotid = value;
            SetDirty("Cotid");
         }

      }

      [  SoapElement( ElementName = "CotSigla" )]
      [  XmlElement( ElementName = "CotSigla"   )]
      public string gxTpr_Cotsigla
      {
         get {
            return gxTv_SdtContatoTipo_Cotsigla ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotsigla = value;
            SetDirty("Cotsigla");
         }

      }

      [  SoapElement( ElementName = "CotNome" )]
      [  XmlElement( ElementName = "CotNome"   )]
      public string gxTpr_Cotnome
      {
         get {
            return gxTv_SdtContatoTipo_Cotnome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotnome = value;
            SetDirty("Cotnome");
         }

      }

      [  SoapElement( ElementName = "CotAtivo" )]
      [  XmlElement( ElementName = "CotAtivo"   )]
      public bool gxTpr_Cotativo
      {
         get {
            return gxTv_SdtContatoTipo_Cotativo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotativo = value;
            SetDirty("Cotativo");
         }

      }

      [  SoapElement( ElementName = "CotDel" )]
      [  XmlElement( ElementName = "CotDel"   )]
      public bool gxTpr_Cotdel
      {
         get {
            return gxTv_SdtContatoTipo_Cotdel ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotdel = value;
            SetDirty("Cotdel");
         }

      }

      [  SoapElement( ElementName = "CotDelDataHora" )]
      [  XmlElement( ElementName = "CotDelDataHora"  , IsNullable=true )]
      public string gxTpr_Cotdeldatahora_Nullable
      {
         get {
            if ( gxTv_SdtContatoTipo_Cotdeldatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtContatoTipo_Cotdeldatahora, null, true).value ;
         }

         set {
            gxTv_SdtContatoTipo_Cotdeldatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtContatoTipo_Cotdeldatahora = DateTime.MinValue;
            else
               gxTv_SdtContatoTipo_Cotdeldatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Cotdeldatahora
      {
         get {
            return gxTv_SdtContatoTipo_Cotdeldatahora ;
         }

         set {
            gxTv_SdtContatoTipo_Cotdeldatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotdeldatahora = value;
            SetDirty("Cotdeldatahora");
         }

      }

      public void gxTv_SdtContatoTipo_Cotdeldatahora_SetNull( )
      {
         gxTv_SdtContatoTipo_Cotdeldatahora_N = 1;
         gxTv_SdtContatoTipo_Cotdeldatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Cotdeldatahora");
         return  ;
      }

      public bool gxTv_SdtContatoTipo_Cotdeldatahora_IsNull( )
      {
         return (gxTv_SdtContatoTipo_Cotdeldatahora_N==1) ;
      }

      [  SoapElement( ElementName = "CotDelData" )]
      [  XmlElement( ElementName = "CotDelData"  , IsNullable=true )]
      public string gxTpr_Cotdeldata_Nullable
      {
         get {
            if ( gxTv_SdtContatoTipo_Cotdeldata == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtContatoTipo_Cotdeldata).value ;
         }

         set {
            gxTv_SdtContatoTipo_Cotdeldata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtContatoTipo_Cotdeldata = DateTime.MinValue;
            else
               gxTv_SdtContatoTipo_Cotdeldata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Cotdeldata
      {
         get {
            return gxTv_SdtContatoTipo_Cotdeldata ;
         }

         set {
            gxTv_SdtContatoTipo_Cotdeldata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotdeldata = value;
            SetDirty("Cotdeldata");
         }

      }

      public void gxTv_SdtContatoTipo_Cotdeldata_SetNull( )
      {
         gxTv_SdtContatoTipo_Cotdeldata_N = 1;
         gxTv_SdtContatoTipo_Cotdeldata = (DateTime)(DateTime.MinValue);
         SetDirty("Cotdeldata");
         return  ;
      }

      public bool gxTv_SdtContatoTipo_Cotdeldata_IsNull( )
      {
         return (gxTv_SdtContatoTipo_Cotdeldata_N==1) ;
      }

      [  SoapElement( ElementName = "CotDelHora" )]
      [  XmlElement( ElementName = "CotDelHora"  , IsNullable=true )]
      public string gxTpr_Cotdelhora_Nullable
      {
         get {
            if ( gxTv_SdtContatoTipo_Cotdelhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtContatoTipo_Cotdelhora).value ;
         }

         set {
            gxTv_SdtContatoTipo_Cotdelhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtContatoTipo_Cotdelhora = DateTime.MinValue;
            else
               gxTv_SdtContatoTipo_Cotdelhora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Cotdelhora
      {
         get {
            return gxTv_SdtContatoTipo_Cotdelhora ;
         }

         set {
            gxTv_SdtContatoTipo_Cotdelhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotdelhora = value;
            SetDirty("Cotdelhora");
         }

      }

      public void gxTv_SdtContatoTipo_Cotdelhora_SetNull( )
      {
         gxTv_SdtContatoTipo_Cotdelhora_N = 1;
         gxTv_SdtContatoTipo_Cotdelhora = (DateTime)(DateTime.MinValue);
         SetDirty("Cotdelhora");
         return  ;
      }

      public bool gxTv_SdtContatoTipo_Cotdelhora_IsNull( )
      {
         return (gxTv_SdtContatoTipo_Cotdelhora_N==1) ;
      }

      [  SoapElement( ElementName = "CotDelUsuId" )]
      [  XmlElement( ElementName = "CotDelUsuId"   )]
      public string gxTpr_Cotdelusuid
      {
         get {
            return gxTv_SdtContatoTipo_Cotdelusuid ;
         }

         set {
            gxTv_SdtContatoTipo_Cotdelusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotdelusuid = value;
            SetDirty("Cotdelusuid");
         }

      }

      public void gxTv_SdtContatoTipo_Cotdelusuid_SetNull( )
      {
         gxTv_SdtContatoTipo_Cotdelusuid_N = 1;
         gxTv_SdtContatoTipo_Cotdelusuid = "";
         SetDirty("Cotdelusuid");
         return  ;
      }

      public bool gxTv_SdtContatoTipo_Cotdelusuid_IsNull( )
      {
         return (gxTv_SdtContatoTipo_Cotdelusuid_N==1) ;
      }

      [  SoapElement( ElementName = "CotDelUsuNome" )]
      [  XmlElement( ElementName = "CotDelUsuNome"   )]
      public string gxTpr_Cotdelusunome
      {
         get {
            return gxTv_SdtContatoTipo_Cotdelusunome ;
         }

         set {
            gxTv_SdtContatoTipo_Cotdelusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotdelusunome = value;
            SetDirty("Cotdelusunome");
         }

      }

      public void gxTv_SdtContatoTipo_Cotdelusunome_SetNull( )
      {
         gxTv_SdtContatoTipo_Cotdelusunome_N = 1;
         gxTv_SdtContatoTipo_Cotdelusunome = "";
         SetDirty("Cotdelusunome");
         return  ;
      }

      public bool gxTv_SdtContatoTipo_Cotdelusunome_IsNull( )
      {
         return (gxTv_SdtContatoTipo_Cotdelusunome_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtContatoTipo_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtContatoTipo_Mode_SetNull( )
      {
         gxTv_SdtContatoTipo_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtContatoTipo_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtContatoTipo_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtContatoTipo_Initialized_SetNull( )
      {
         gxTv_SdtContatoTipo_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtContatoTipo_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CotID_Z" )]
      [  XmlElement( ElementName = "CotID_Z"   )]
      public int gxTpr_Cotid_Z
      {
         get {
            return gxTv_SdtContatoTipo_Cotid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotid_Z = value;
            SetDirty("Cotid_Z");
         }

      }

      public void gxTv_SdtContatoTipo_Cotid_Z_SetNull( )
      {
         gxTv_SdtContatoTipo_Cotid_Z = 0;
         SetDirty("Cotid_Z");
         return  ;
      }

      public bool gxTv_SdtContatoTipo_Cotid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CotSigla_Z" )]
      [  XmlElement( ElementName = "CotSigla_Z"   )]
      public string gxTpr_Cotsigla_Z
      {
         get {
            return gxTv_SdtContatoTipo_Cotsigla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotsigla_Z = value;
            SetDirty("Cotsigla_Z");
         }

      }

      public void gxTv_SdtContatoTipo_Cotsigla_Z_SetNull( )
      {
         gxTv_SdtContatoTipo_Cotsigla_Z = "";
         SetDirty("Cotsigla_Z");
         return  ;
      }

      public bool gxTv_SdtContatoTipo_Cotsigla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CotNome_Z" )]
      [  XmlElement( ElementName = "CotNome_Z"   )]
      public string gxTpr_Cotnome_Z
      {
         get {
            return gxTv_SdtContatoTipo_Cotnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotnome_Z = value;
            SetDirty("Cotnome_Z");
         }

      }

      public void gxTv_SdtContatoTipo_Cotnome_Z_SetNull( )
      {
         gxTv_SdtContatoTipo_Cotnome_Z = "";
         SetDirty("Cotnome_Z");
         return  ;
      }

      public bool gxTv_SdtContatoTipo_Cotnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CotAtivo_Z" )]
      [  XmlElement( ElementName = "CotAtivo_Z"   )]
      public bool gxTpr_Cotativo_Z
      {
         get {
            return gxTv_SdtContatoTipo_Cotativo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotativo_Z = value;
            SetDirty("Cotativo_Z");
         }

      }

      public void gxTv_SdtContatoTipo_Cotativo_Z_SetNull( )
      {
         gxTv_SdtContatoTipo_Cotativo_Z = false;
         SetDirty("Cotativo_Z");
         return  ;
      }

      public bool gxTv_SdtContatoTipo_Cotativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CotDel_Z" )]
      [  XmlElement( ElementName = "CotDel_Z"   )]
      public bool gxTpr_Cotdel_Z
      {
         get {
            return gxTv_SdtContatoTipo_Cotdel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotdel_Z = value;
            SetDirty("Cotdel_Z");
         }

      }

      public void gxTv_SdtContatoTipo_Cotdel_Z_SetNull( )
      {
         gxTv_SdtContatoTipo_Cotdel_Z = false;
         SetDirty("Cotdel_Z");
         return  ;
      }

      public bool gxTv_SdtContatoTipo_Cotdel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CotDelDataHora_Z" )]
      [  XmlElement( ElementName = "CotDelDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Cotdeldatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtContatoTipo_Cotdeldatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtContatoTipo_Cotdeldatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtContatoTipo_Cotdeldatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtContatoTipo_Cotdeldatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Cotdeldatahora_Z
      {
         get {
            return gxTv_SdtContatoTipo_Cotdeldatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotdeldatahora_Z = value;
            SetDirty("Cotdeldatahora_Z");
         }

      }

      public void gxTv_SdtContatoTipo_Cotdeldatahora_Z_SetNull( )
      {
         gxTv_SdtContatoTipo_Cotdeldatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Cotdeldatahora_Z");
         return  ;
      }

      public bool gxTv_SdtContatoTipo_Cotdeldatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CotDelData_Z" )]
      [  XmlElement( ElementName = "CotDelData_Z"  , IsNullable=true )]
      public string gxTpr_Cotdeldata_Z_Nullable
      {
         get {
            if ( gxTv_SdtContatoTipo_Cotdeldata_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtContatoTipo_Cotdeldata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtContatoTipo_Cotdeldata_Z = DateTime.MinValue;
            else
               gxTv_SdtContatoTipo_Cotdeldata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Cotdeldata_Z
      {
         get {
            return gxTv_SdtContatoTipo_Cotdeldata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotdeldata_Z = value;
            SetDirty("Cotdeldata_Z");
         }

      }

      public void gxTv_SdtContatoTipo_Cotdeldata_Z_SetNull( )
      {
         gxTv_SdtContatoTipo_Cotdeldata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Cotdeldata_Z");
         return  ;
      }

      public bool gxTv_SdtContatoTipo_Cotdeldata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CotDelHora_Z" )]
      [  XmlElement( ElementName = "CotDelHora_Z"  , IsNullable=true )]
      public string gxTpr_Cotdelhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtContatoTipo_Cotdelhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtContatoTipo_Cotdelhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtContatoTipo_Cotdelhora_Z = DateTime.MinValue;
            else
               gxTv_SdtContatoTipo_Cotdelhora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Cotdelhora_Z
      {
         get {
            return gxTv_SdtContatoTipo_Cotdelhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotdelhora_Z = value;
            SetDirty("Cotdelhora_Z");
         }

      }

      public void gxTv_SdtContatoTipo_Cotdelhora_Z_SetNull( )
      {
         gxTv_SdtContatoTipo_Cotdelhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Cotdelhora_Z");
         return  ;
      }

      public bool gxTv_SdtContatoTipo_Cotdelhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CotDelUsuId_Z" )]
      [  XmlElement( ElementName = "CotDelUsuId_Z"   )]
      public string gxTpr_Cotdelusuid_Z
      {
         get {
            return gxTv_SdtContatoTipo_Cotdelusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotdelusuid_Z = value;
            SetDirty("Cotdelusuid_Z");
         }

      }

      public void gxTv_SdtContatoTipo_Cotdelusuid_Z_SetNull( )
      {
         gxTv_SdtContatoTipo_Cotdelusuid_Z = "";
         SetDirty("Cotdelusuid_Z");
         return  ;
      }

      public bool gxTv_SdtContatoTipo_Cotdelusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CotDelUsuNome_Z" )]
      [  XmlElement( ElementName = "CotDelUsuNome_Z"   )]
      public string gxTpr_Cotdelusunome_Z
      {
         get {
            return gxTv_SdtContatoTipo_Cotdelusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotdelusunome_Z = value;
            SetDirty("Cotdelusunome_Z");
         }

      }

      public void gxTv_SdtContatoTipo_Cotdelusunome_Z_SetNull( )
      {
         gxTv_SdtContatoTipo_Cotdelusunome_Z = "";
         SetDirty("Cotdelusunome_Z");
         return  ;
      }

      public bool gxTv_SdtContatoTipo_Cotdelusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CotDelDataHora_N" )]
      [  XmlElement( ElementName = "CotDelDataHora_N"   )]
      public short gxTpr_Cotdeldatahora_N
      {
         get {
            return gxTv_SdtContatoTipo_Cotdeldatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotdeldatahora_N = value;
            SetDirty("Cotdeldatahora_N");
         }

      }

      public void gxTv_SdtContatoTipo_Cotdeldatahora_N_SetNull( )
      {
         gxTv_SdtContatoTipo_Cotdeldatahora_N = 0;
         SetDirty("Cotdeldatahora_N");
         return  ;
      }

      public bool gxTv_SdtContatoTipo_Cotdeldatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CotDelData_N" )]
      [  XmlElement( ElementName = "CotDelData_N"   )]
      public short gxTpr_Cotdeldata_N
      {
         get {
            return gxTv_SdtContatoTipo_Cotdeldata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotdeldata_N = value;
            SetDirty("Cotdeldata_N");
         }

      }

      public void gxTv_SdtContatoTipo_Cotdeldata_N_SetNull( )
      {
         gxTv_SdtContatoTipo_Cotdeldata_N = 0;
         SetDirty("Cotdeldata_N");
         return  ;
      }

      public bool gxTv_SdtContatoTipo_Cotdeldata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CotDelHora_N" )]
      [  XmlElement( ElementName = "CotDelHora_N"   )]
      public short gxTpr_Cotdelhora_N
      {
         get {
            return gxTv_SdtContatoTipo_Cotdelhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotdelhora_N = value;
            SetDirty("Cotdelhora_N");
         }

      }

      public void gxTv_SdtContatoTipo_Cotdelhora_N_SetNull( )
      {
         gxTv_SdtContatoTipo_Cotdelhora_N = 0;
         SetDirty("Cotdelhora_N");
         return  ;
      }

      public bool gxTv_SdtContatoTipo_Cotdelhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CotDelUsuId_N" )]
      [  XmlElement( ElementName = "CotDelUsuId_N"   )]
      public short gxTpr_Cotdelusuid_N
      {
         get {
            return gxTv_SdtContatoTipo_Cotdelusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotdelusuid_N = value;
            SetDirty("Cotdelusuid_N");
         }

      }

      public void gxTv_SdtContatoTipo_Cotdelusuid_N_SetNull( )
      {
         gxTv_SdtContatoTipo_Cotdelusuid_N = 0;
         SetDirty("Cotdelusuid_N");
         return  ;
      }

      public bool gxTv_SdtContatoTipo_Cotdelusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CotDelUsuNome_N" )]
      [  XmlElement( ElementName = "CotDelUsuNome_N"   )]
      public short gxTpr_Cotdelusunome_N
      {
         get {
            return gxTv_SdtContatoTipo_Cotdelusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContatoTipo_Cotdelusunome_N = value;
            SetDirty("Cotdelusunome_N");
         }

      }

      public void gxTv_SdtContatoTipo_Cotdelusunome_N_SetNull( )
      {
         gxTv_SdtContatoTipo_Cotdelusunome_N = 0;
         SetDirty("Cotdelusunome_N");
         return  ;
      }

      public bool gxTv_SdtContatoTipo_Cotdelusunome_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtContatoTipo_Cotsigla = "";
         gxTv_SdtContatoTipo_Cotnome = "";
         gxTv_SdtContatoTipo_Cotativo = true;
         gxTv_SdtContatoTipo_Cotdeldatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtContatoTipo_Cotdeldata = (DateTime)(DateTime.MinValue);
         gxTv_SdtContatoTipo_Cotdelhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtContatoTipo_Cotdelusuid = "";
         gxTv_SdtContatoTipo_Cotdelusunome = "";
         gxTv_SdtContatoTipo_Mode = "";
         gxTv_SdtContatoTipo_Cotsigla_Z = "";
         gxTv_SdtContatoTipo_Cotnome_Z = "";
         gxTv_SdtContatoTipo_Cotdeldatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtContatoTipo_Cotdeldata_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtContatoTipo_Cotdelhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtContatoTipo_Cotdelusuid_Z = "";
         gxTv_SdtContatoTipo_Cotdelusunome_Z = "";
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "core.contatotipo", "GeneXus.Programs.core.contatotipo_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtContatoTipo_Initialized ;
      private short gxTv_SdtContatoTipo_Cotdeldatahora_N ;
      private short gxTv_SdtContatoTipo_Cotdeldata_N ;
      private short gxTv_SdtContatoTipo_Cotdelhora_N ;
      private short gxTv_SdtContatoTipo_Cotdelusuid_N ;
      private short gxTv_SdtContatoTipo_Cotdelusunome_N ;
      private int gxTv_SdtContatoTipo_Cotid ;
      private int gxTv_SdtContatoTipo_Cotid_Z ;
      private string gxTv_SdtContatoTipo_Cotdelusuid ;
      private string gxTv_SdtContatoTipo_Mode ;
      private string gxTv_SdtContatoTipo_Cotdelusuid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtContatoTipo_Cotdeldatahora ;
      private DateTime gxTv_SdtContatoTipo_Cotdeldata ;
      private DateTime gxTv_SdtContatoTipo_Cotdelhora ;
      private DateTime gxTv_SdtContatoTipo_Cotdeldatahora_Z ;
      private DateTime gxTv_SdtContatoTipo_Cotdeldata_Z ;
      private DateTime gxTv_SdtContatoTipo_Cotdelhora_Z ;
      private DateTime datetimemil_STZ ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtContatoTipo_Cotativo ;
      private bool gxTv_SdtContatoTipo_Cotdel ;
      private bool gxTv_SdtContatoTipo_Cotativo_Z ;
      private bool gxTv_SdtContatoTipo_Cotdel_Z ;
      private string gxTv_SdtContatoTipo_Cotsigla ;
      private string gxTv_SdtContatoTipo_Cotnome ;
      private string gxTv_SdtContatoTipo_Cotdelusunome ;
      private string gxTv_SdtContatoTipo_Cotsigla_Z ;
      private string gxTv_SdtContatoTipo_Cotnome_Z ;
      private string gxTv_SdtContatoTipo_Cotdelusunome_Z ;
   }

   [DataContract(Name = @"core\ContatoTipo", Namespace = "agl_tresorygroup")]
   public class SdtContatoTipo_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtContatoTipo>
   {
      public SdtContatoTipo_RESTInterface( ) : base()
      {
      }

      public SdtContatoTipo_RESTInterface( GeneXus.Programs.core.SdtContatoTipo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CotID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Cotid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Cotid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Cotid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "CotSigla" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Cotsigla
      {
         get {
            return sdt.gxTpr_Cotsigla ;
         }

         set {
            sdt.gxTpr_Cotsigla = value;
         }

      }

      [DataMember( Name = "CotNome" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Cotnome
      {
         get {
            return sdt.gxTpr_Cotnome ;
         }

         set {
            sdt.gxTpr_Cotnome = value;
         }

      }

      [DataMember( Name = "CotAtivo" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Cotativo
      {
         get {
            return sdt.gxTpr_Cotativo ;
         }

         set {
            sdt.gxTpr_Cotativo = value;
         }

      }

      [DataMember( Name = "CotDel" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Cotdel
      {
         get {
            return sdt.gxTpr_Cotdel ;
         }

         set {
            sdt.gxTpr_Cotdel = value;
         }

      }

      [DataMember( Name = "CotDelDataHora" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Cotdeldatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Cotdeldatahora) ;
         }

         set {
            sdt.gxTpr_Cotdeldatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "CotDelData" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Cotdeldata
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Cotdeldata) ;
         }

         set {
            sdt.gxTpr_Cotdeldata = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "CotDelHora" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Cotdelhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Cotdelhora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Cotdelhora = GXt_dtime1;
         }

      }

      [DataMember( Name = "CotDelUsuId" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Cotdelusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Cotdelusuid) ;
         }

         set {
            sdt.gxTpr_Cotdelusuid = value;
         }

      }

      [DataMember( Name = "CotDelUsuNome" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Cotdelusunome
      {
         get {
            return sdt.gxTpr_Cotdelusunome ;
         }

         set {
            sdt.gxTpr_Cotdelusunome = value;
         }

      }

      public GeneXus.Programs.core.SdtContatoTipo sdt
      {
         get {
            return (GeneXus.Programs.core.SdtContatoTipo)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtContatoTipo() ;
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

   [DataContract(Name = @"core\ContatoTipo", Namespace = "agl_tresorygroup")]
   public class SdtContatoTipo_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtContatoTipo>
   {
      public SdtContatoTipo_RESTLInterface( ) : base()
      {
      }

      public SdtContatoTipo_RESTLInterface( GeneXus.Programs.core.SdtContatoTipo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CotNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Cotnome
      {
         get {
            return sdt.gxTpr_Cotnome ;
         }

         set {
            sdt.gxTpr_Cotnome = value;
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

      public GeneXus.Programs.core.SdtContatoTipo sdt
      {
         get {
            return (GeneXus.Programs.core.SdtContatoTipo)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtContatoTipo() ;
         }
      }

   }

}
