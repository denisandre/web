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
   [XmlRoot(ElementName = "ProdutoTipo" )]
   [XmlType(TypeName =  "ProdutoTipo" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class SdtProdutoTipo : GxSilentTrnSdt
   {
      public SdtProdutoTipo( )
      {
      }

      public SdtProdutoTipo( IGxContext context )
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

      public void Load( int AV211PrtID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV211PrtID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PrtID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "core\\ProdutoTipo");
         metadata.Set("BT", "tb_produtotipo");
         metadata.Set("PK", "[ \"PrtID\" ]");
         metadata.Set("PKAssigned", "[ \"PrtID\" ]");
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
         state.Add("gxTpr_Prtid_Z");
         state.Add("gxTpr_Prtsigla_Z");
         state.Add("gxTpr_Prtnome_Z");
         state.Add("gxTpr_Prtativo_Z");
         state.Add("gxTpr_Prtdel_Z");
         state.Add("gxTpr_Prtdeldatahora_Z_Nullable");
         state.Add("gxTpr_Prtdeldata_Z_Nullable");
         state.Add("gxTpr_Prtdelhora_Z_Nullable");
         state.Add("gxTpr_Prtdelusuid_Z");
         state.Add("gxTpr_Prtdelusunome_Z");
         state.Add("gxTpr_Prtdeldatahora_N");
         state.Add("gxTpr_Prtdeldata_N");
         state.Add("gxTpr_Prtdelhora_N");
         state.Add("gxTpr_Prtdelusuid_N");
         state.Add("gxTpr_Prtdelusunome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.SdtProdutoTipo sdt;
         sdt = (GeneXus.Programs.core.SdtProdutoTipo)(source);
         gxTv_SdtProdutoTipo_Prtid = sdt.gxTv_SdtProdutoTipo_Prtid ;
         gxTv_SdtProdutoTipo_Prtsigla = sdt.gxTv_SdtProdutoTipo_Prtsigla ;
         gxTv_SdtProdutoTipo_Prtnome = sdt.gxTv_SdtProdutoTipo_Prtnome ;
         gxTv_SdtProdutoTipo_Prtativo = sdt.gxTv_SdtProdutoTipo_Prtativo ;
         gxTv_SdtProdutoTipo_Prtdel = sdt.gxTv_SdtProdutoTipo_Prtdel ;
         gxTv_SdtProdutoTipo_Prtdeldatahora = sdt.gxTv_SdtProdutoTipo_Prtdeldatahora ;
         gxTv_SdtProdutoTipo_Prtdeldata = sdt.gxTv_SdtProdutoTipo_Prtdeldata ;
         gxTv_SdtProdutoTipo_Prtdelhora = sdt.gxTv_SdtProdutoTipo_Prtdelhora ;
         gxTv_SdtProdutoTipo_Prtdelusuid = sdt.gxTv_SdtProdutoTipo_Prtdelusuid ;
         gxTv_SdtProdutoTipo_Prtdelusunome = sdt.gxTv_SdtProdutoTipo_Prtdelusunome ;
         gxTv_SdtProdutoTipo_Mode = sdt.gxTv_SdtProdutoTipo_Mode ;
         gxTv_SdtProdutoTipo_Initialized = sdt.gxTv_SdtProdutoTipo_Initialized ;
         gxTv_SdtProdutoTipo_Prtid_Z = sdt.gxTv_SdtProdutoTipo_Prtid_Z ;
         gxTv_SdtProdutoTipo_Prtsigla_Z = sdt.gxTv_SdtProdutoTipo_Prtsigla_Z ;
         gxTv_SdtProdutoTipo_Prtnome_Z = sdt.gxTv_SdtProdutoTipo_Prtnome_Z ;
         gxTv_SdtProdutoTipo_Prtativo_Z = sdt.gxTv_SdtProdutoTipo_Prtativo_Z ;
         gxTv_SdtProdutoTipo_Prtdel_Z = sdt.gxTv_SdtProdutoTipo_Prtdel_Z ;
         gxTv_SdtProdutoTipo_Prtdeldatahora_Z = sdt.gxTv_SdtProdutoTipo_Prtdeldatahora_Z ;
         gxTv_SdtProdutoTipo_Prtdeldata_Z = sdt.gxTv_SdtProdutoTipo_Prtdeldata_Z ;
         gxTv_SdtProdutoTipo_Prtdelhora_Z = sdt.gxTv_SdtProdutoTipo_Prtdelhora_Z ;
         gxTv_SdtProdutoTipo_Prtdelusuid_Z = sdt.gxTv_SdtProdutoTipo_Prtdelusuid_Z ;
         gxTv_SdtProdutoTipo_Prtdelusunome_Z = sdt.gxTv_SdtProdutoTipo_Prtdelusunome_Z ;
         gxTv_SdtProdutoTipo_Prtdeldatahora_N = sdt.gxTv_SdtProdutoTipo_Prtdeldatahora_N ;
         gxTv_SdtProdutoTipo_Prtdeldata_N = sdt.gxTv_SdtProdutoTipo_Prtdeldata_N ;
         gxTv_SdtProdutoTipo_Prtdelhora_N = sdt.gxTv_SdtProdutoTipo_Prtdelhora_N ;
         gxTv_SdtProdutoTipo_Prtdelusuid_N = sdt.gxTv_SdtProdutoTipo_Prtdelusuid_N ;
         gxTv_SdtProdutoTipo_Prtdelusunome_N = sdt.gxTv_SdtProdutoTipo_Prtdelusunome_N ;
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
         AddObjectProperty("PrtID", gxTv_SdtProdutoTipo_Prtid, false, includeNonInitialized);
         AddObjectProperty("PrtSigla", gxTv_SdtProdutoTipo_Prtsigla, false, includeNonInitialized);
         AddObjectProperty("PrtNome", gxTv_SdtProdutoTipo_Prtnome, false, includeNonInitialized);
         AddObjectProperty("PrtAtivo", gxTv_SdtProdutoTipo_Prtativo, false, includeNonInitialized);
         AddObjectProperty("PrtDel", gxTv_SdtProdutoTipo_Prtdel, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtProdutoTipo_Prtdeldatahora;
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
         AddObjectProperty("PrtDelDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PrtDelDataHora_N", gxTv_SdtProdutoTipo_Prtdeldatahora_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtProdutoTipo_Prtdeldata;
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
         AddObjectProperty("PrtDelData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PrtDelData_N", gxTv_SdtProdutoTipo_Prtdeldata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtProdutoTipo_Prtdelhora;
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
         AddObjectProperty("PrtDelHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PrtDelHora_N", gxTv_SdtProdutoTipo_Prtdelhora_N, false, includeNonInitialized);
         AddObjectProperty("PrtDelUsuId", gxTv_SdtProdutoTipo_Prtdelusuid, false, includeNonInitialized);
         AddObjectProperty("PrtDelUsuId_N", gxTv_SdtProdutoTipo_Prtdelusuid_N, false, includeNonInitialized);
         AddObjectProperty("PrtDelUsuNome", gxTv_SdtProdutoTipo_Prtdelusunome, false, includeNonInitialized);
         AddObjectProperty("PrtDelUsuNome_N", gxTv_SdtProdutoTipo_Prtdelusunome_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtProdutoTipo_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtProdutoTipo_Initialized, false, includeNonInitialized);
            AddObjectProperty("PrtID_Z", gxTv_SdtProdutoTipo_Prtid_Z, false, includeNonInitialized);
            AddObjectProperty("PrtSigla_Z", gxTv_SdtProdutoTipo_Prtsigla_Z, false, includeNonInitialized);
            AddObjectProperty("PrtNome_Z", gxTv_SdtProdutoTipo_Prtnome_Z, false, includeNonInitialized);
            AddObjectProperty("PrtAtivo_Z", gxTv_SdtProdutoTipo_Prtativo_Z, false, includeNonInitialized);
            AddObjectProperty("PrtDel_Z", gxTv_SdtProdutoTipo_Prtdel_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtProdutoTipo_Prtdeldatahora_Z;
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
            AddObjectProperty("PrtDelDataHora_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtProdutoTipo_Prtdeldata_Z;
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
            AddObjectProperty("PrtDelData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtProdutoTipo_Prtdelhora_Z;
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
            AddObjectProperty("PrtDelHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("PrtDelUsuId_Z", gxTv_SdtProdutoTipo_Prtdelusuid_Z, false, includeNonInitialized);
            AddObjectProperty("PrtDelUsuNome_Z", gxTv_SdtProdutoTipo_Prtdelusunome_Z, false, includeNonInitialized);
            AddObjectProperty("PrtDelDataHora_N", gxTv_SdtProdutoTipo_Prtdeldatahora_N, false, includeNonInitialized);
            AddObjectProperty("PrtDelData_N", gxTv_SdtProdutoTipo_Prtdeldata_N, false, includeNonInitialized);
            AddObjectProperty("PrtDelHora_N", gxTv_SdtProdutoTipo_Prtdelhora_N, false, includeNonInitialized);
            AddObjectProperty("PrtDelUsuId_N", gxTv_SdtProdutoTipo_Prtdelusuid_N, false, includeNonInitialized);
            AddObjectProperty("PrtDelUsuNome_N", gxTv_SdtProdutoTipo_Prtdelusunome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.SdtProdutoTipo sdt )
      {
         if ( sdt.IsDirty("PrtID") )
         {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtid = sdt.gxTv_SdtProdutoTipo_Prtid ;
         }
         if ( sdt.IsDirty("PrtSigla") )
         {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtsigla = sdt.gxTv_SdtProdutoTipo_Prtsigla ;
         }
         if ( sdt.IsDirty("PrtNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtnome = sdt.gxTv_SdtProdutoTipo_Prtnome ;
         }
         if ( sdt.IsDirty("PrtAtivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtativo = sdt.gxTv_SdtProdutoTipo_Prtativo ;
         }
         if ( sdt.IsDirty("PrtDel") )
         {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtdel = sdt.gxTv_SdtProdutoTipo_Prtdel ;
         }
         if ( sdt.IsDirty("PrtDelDataHora") )
         {
            gxTv_SdtProdutoTipo_Prtdeldatahora_N = (short)(sdt.gxTv_SdtProdutoTipo_Prtdeldatahora_N);
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtdeldatahora = sdt.gxTv_SdtProdutoTipo_Prtdeldatahora ;
         }
         if ( sdt.IsDirty("PrtDelData") )
         {
            gxTv_SdtProdutoTipo_Prtdeldata_N = (short)(sdt.gxTv_SdtProdutoTipo_Prtdeldata_N);
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtdeldata = sdt.gxTv_SdtProdutoTipo_Prtdeldata ;
         }
         if ( sdt.IsDirty("PrtDelHora") )
         {
            gxTv_SdtProdutoTipo_Prtdelhora_N = (short)(sdt.gxTv_SdtProdutoTipo_Prtdelhora_N);
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtdelhora = sdt.gxTv_SdtProdutoTipo_Prtdelhora ;
         }
         if ( sdt.IsDirty("PrtDelUsuId") )
         {
            gxTv_SdtProdutoTipo_Prtdelusuid_N = (short)(sdt.gxTv_SdtProdutoTipo_Prtdelusuid_N);
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtdelusuid = sdt.gxTv_SdtProdutoTipo_Prtdelusuid ;
         }
         if ( sdt.IsDirty("PrtDelUsuNome") )
         {
            gxTv_SdtProdutoTipo_Prtdelusunome_N = (short)(sdt.gxTv_SdtProdutoTipo_Prtdelusunome_N);
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtdelusunome = sdt.gxTv_SdtProdutoTipo_Prtdelusunome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PrtID" )]
      [  XmlElement( ElementName = "PrtID"   )]
      public int gxTpr_Prtid
      {
         get {
            return gxTv_SdtProdutoTipo_Prtid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtProdutoTipo_Prtid != value )
            {
               gxTv_SdtProdutoTipo_Mode = "INS";
               this.gxTv_SdtProdutoTipo_Prtid_Z_SetNull( );
               this.gxTv_SdtProdutoTipo_Prtsigla_Z_SetNull( );
               this.gxTv_SdtProdutoTipo_Prtnome_Z_SetNull( );
               this.gxTv_SdtProdutoTipo_Prtativo_Z_SetNull( );
               this.gxTv_SdtProdutoTipo_Prtdel_Z_SetNull( );
               this.gxTv_SdtProdutoTipo_Prtdeldatahora_Z_SetNull( );
               this.gxTv_SdtProdutoTipo_Prtdeldata_Z_SetNull( );
               this.gxTv_SdtProdutoTipo_Prtdelhora_Z_SetNull( );
               this.gxTv_SdtProdutoTipo_Prtdelusuid_Z_SetNull( );
               this.gxTv_SdtProdutoTipo_Prtdelusunome_Z_SetNull( );
            }
            gxTv_SdtProdutoTipo_Prtid = value;
            SetDirty("Prtid");
         }

      }

      [  SoapElement( ElementName = "PrtSigla" )]
      [  XmlElement( ElementName = "PrtSigla"   )]
      public string gxTpr_Prtsigla
      {
         get {
            return gxTv_SdtProdutoTipo_Prtsigla ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtsigla = value;
            SetDirty("Prtsigla");
         }

      }

      [  SoapElement( ElementName = "PrtNome" )]
      [  XmlElement( ElementName = "PrtNome"   )]
      public string gxTpr_Prtnome
      {
         get {
            return gxTv_SdtProdutoTipo_Prtnome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtnome = value;
            SetDirty("Prtnome");
         }

      }

      [  SoapElement( ElementName = "PrtAtivo" )]
      [  XmlElement( ElementName = "PrtAtivo"   )]
      public bool gxTpr_Prtativo
      {
         get {
            return gxTv_SdtProdutoTipo_Prtativo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtativo = value;
            SetDirty("Prtativo");
         }

      }

      [  SoapElement( ElementName = "PrtDel" )]
      [  XmlElement( ElementName = "PrtDel"   )]
      public bool gxTpr_Prtdel
      {
         get {
            return gxTv_SdtProdutoTipo_Prtdel ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtdel = value;
            SetDirty("Prtdel");
         }

      }

      [  SoapElement( ElementName = "PrtDelDataHora" )]
      [  XmlElement( ElementName = "PrtDelDataHora"  , IsNullable=true )]
      public string gxTpr_Prtdeldatahora_Nullable
      {
         get {
            if ( gxTv_SdtProdutoTipo_Prtdeldatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProdutoTipo_Prtdeldatahora, null, true).value ;
         }

         set {
            gxTv_SdtProdutoTipo_Prtdeldatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProdutoTipo_Prtdeldatahora = DateTime.MinValue;
            else
               gxTv_SdtProdutoTipo_Prtdeldatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prtdeldatahora
      {
         get {
            return gxTv_SdtProdutoTipo_Prtdeldatahora ;
         }

         set {
            gxTv_SdtProdutoTipo_Prtdeldatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtdeldatahora = value;
            SetDirty("Prtdeldatahora");
         }

      }

      public void gxTv_SdtProdutoTipo_Prtdeldatahora_SetNull( )
      {
         gxTv_SdtProdutoTipo_Prtdeldatahora_N = 1;
         gxTv_SdtProdutoTipo_Prtdeldatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Prtdeldatahora");
         return  ;
      }

      public bool gxTv_SdtProdutoTipo_Prtdeldatahora_IsNull( )
      {
         return (gxTv_SdtProdutoTipo_Prtdeldatahora_N==1) ;
      }

      [  SoapElement( ElementName = "PrtDelData" )]
      [  XmlElement( ElementName = "PrtDelData"  , IsNullable=true )]
      public string gxTpr_Prtdeldata_Nullable
      {
         get {
            if ( gxTv_SdtProdutoTipo_Prtdeldata == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProdutoTipo_Prtdeldata).value ;
         }

         set {
            gxTv_SdtProdutoTipo_Prtdeldata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProdutoTipo_Prtdeldata = DateTime.MinValue;
            else
               gxTv_SdtProdutoTipo_Prtdeldata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prtdeldata
      {
         get {
            return gxTv_SdtProdutoTipo_Prtdeldata ;
         }

         set {
            gxTv_SdtProdutoTipo_Prtdeldata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtdeldata = value;
            SetDirty("Prtdeldata");
         }

      }

      public void gxTv_SdtProdutoTipo_Prtdeldata_SetNull( )
      {
         gxTv_SdtProdutoTipo_Prtdeldata_N = 1;
         gxTv_SdtProdutoTipo_Prtdeldata = (DateTime)(DateTime.MinValue);
         SetDirty("Prtdeldata");
         return  ;
      }

      public bool gxTv_SdtProdutoTipo_Prtdeldata_IsNull( )
      {
         return (gxTv_SdtProdutoTipo_Prtdeldata_N==1) ;
      }

      [  SoapElement( ElementName = "PrtDelHora" )]
      [  XmlElement( ElementName = "PrtDelHora"  , IsNullable=true )]
      public string gxTpr_Prtdelhora_Nullable
      {
         get {
            if ( gxTv_SdtProdutoTipo_Prtdelhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProdutoTipo_Prtdelhora).value ;
         }

         set {
            gxTv_SdtProdutoTipo_Prtdelhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProdutoTipo_Prtdelhora = DateTime.MinValue;
            else
               gxTv_SdtProdutoTipo_Prtdelhora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prtdelhora
      {
         get {
            return gxTv_SdtProdutoTipo_Prtdelhora ;
         }

         set {
            gxTv_SdtProdutoTipo_Prtdelhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtdelhora = value;
            SetDirty("Prtdelhora");
         }

      }

      public void gxTv_SdtProdutoTipo_Prtdelhora_SetNull( )
      {
         gxTv_SdtProdutoTipo_Prtdelhora_N = 1;
         gxTv_SdtProdutoTipo_Prtdelhora = (DateTime)(DateTime.MinValue);
         SetDirty("Prtdelhora");
         return  ;
      }

      public bool gxTv_SdtProdutoTipo_Prtdelhora_IsNull( )
      {
         return (gxTv_SdtProdutoTipo_Prtdelhora_N==1) ;
      }

      [  SoapElement( ElementName = "PrtDelUsuId" )]
      [  XmlElement( ElementName = "PrtDelUsuId"   )]
      public string gxTpr_Prtdelusuid
      {
         get {
            return gxTv_SdtProdutoTipo_Prtdelusuid ;
         }

         set {
            gxTv_SdtProdutoTipo_Prtdelusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtdelusuid = value;
            SetDirty("Prtdelusuid");
         }

      }

      public void gxTv_SdtProdutoTipo_Prtdelusuid_SetNull( )
      {
         gxTv_SdtProdutoTipo_Prtdelusuid_N = 1;
         gxTv_SdtProdutoTipo_Prtdelusuid = "";
         SetDirty("Prtdelusuid");
         return  ;
      }

      public bool gxTv_SdtProdutoTipo_Prtdelusuid_IsNull( )
      {
         return (gxTv_SdtProdutoTipo_Prtdelusuid_N==1) ;
      }

      [  SoapElement( ElementName = "PrtDelUsuNome" )]
      [  XmlElement( ElementName = "PrtDelUsuNome"   )]
      public string gxTpr_Prtdelusunome
      {
         get {
            return gxTv_SdtProdutoTipo_Prtdelusunome ;
         }

         set {
            gxTv_SdtProdutoTipo_Prtdelusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtdelusunome = value;
            SetDirty("Prtdelusunome");
         }

      }

      public void gxTv_SdtProdutoTipo_Prtdelusunome_SetNull( )
      {
         gxTv_SdtProdutoTipo_Prtdelusunome_N = 1;
         gxTv_SdtProdutoTipo_Prtdelusunome = "";
         SetDirty("Prtdelusunome");
         return  ;
      }

      public bool gxTv_SdtProdutoTipo_Prtdelusunome_IsNull( )
      {
         return (gxTv_SdtProdutoTipo_Prtdelusunome_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtProdutoTipo_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtProdutoTipo_Mode_SetNull( )
      {
         gxTv_SdtProdutoTipo_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtProdutoTipo_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtProdutoTipo_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtProdutoTipo_Initialized_SetNull( )
      {
         gxTv_SdtProdutoTipo_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtProdutoTipo_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrtID_Z" )]
      [  XmlElement( ElementName = "PrtID_Z"   )]
      public int gxTpr_Prtid_Z
      {
         get {
            return gxTv_SdtProdutoTipo_Prtid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtid_Z = value;
            SetDirty("Prtid_Z");
         }

      }

      public void gxTv_SdtProdutoTipo_Prtid_Z_SetNull( )
      {
         gxTv_SdtProdutoTipo_Prtid_Z = 0;
         SetDirty("Prtid_Z");
         return  ;
      }

      public bool gxTv_SdtProdutoTipo_Prtid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrtSigla_Z" )]
      [  XmlElement( ElementName = "PrtSigla_Z"   )]
      public string gxTpr_Prtsigla_Z
      {
         get {
            return gxTv_SdtProdutoTipo_Prtsigla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtsigla_Z = value;
            SetDirty("Prtsigla_Z");
         }

      }

      public void gxTv_SdtProdutoTipo_Prtsigla_Z_SetNull( )
      {
         gxTv_SdtProdutoTipo_Prtsigla_Z = "";
         SetDirty("Prtsigla_Z");
         return  ;
      }

      public bool gxTv_SdtProdutoTipo_Prtsigla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrtNome_Z" )]
      [  XmlElement( ElementName = "PrtNome_Z"   )]
      public string gxTpr_Prtnome_Z
      {
         get {
            return gxTv_SdtProdutoTipo_Prtnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtnome_Z = value;
            SetDirty("Prtnome_Z");
         }

      }

      public void gxTv_SdtProdutoTipo_Prtnome_Z_SetNull( )
      {
         gxTv_SdtProdutoTipo_Prtnome_Z = "";
         SetDirty("Prtnome_Z");
         return  ;
      }

      public bool gxTv_SdtProdutoTipo_Prtnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrtAtivo_Z" )]
      [  XmlElement( ElementName = "PrtAtivo_Z"   )]
      public bool gxTpr_Prtativo_Z
      {
         get {
            return gxTv_SdtProdutoTipo_Prtativo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtativo_Z = value;
            SetDirty("Prtativo_Z");
         }

      }

      public void gxTv_SdtProdutoTipo_Prtativo_Z_SetNull( )
      {
         gxTv_SdtProdutoTipo_Prtativo_Z = false;
         SetDirty("Prtativo_Z");
         return  ;
      }

      public bool gxTv_SdtProdutoTipo_Prtativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrtDel_Z" )]
      [  XmlElement( ElementName = "PrtDel_Z"   )]
      public bool gxTpr_Prtdel_Z
      {
         get {
            return gxTv_SdtProdutoTipo_Prtdel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtdel_Z = value;
            SetDirty("Prtdel_Z");
         }

      }

      public void gxTv_SdtProdutoTipo_Prtdel_Z_SetNull( )
      {
         gxTv_SdtProdutoTipo_Prtdel_Z = false;
         SetDirty("Prtdel_Z");
         return  ;
      }

      public bool gxTv_SdtProdutoTipo_Prtdel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrtDelDataHora_Z" )]
      [  XmlElement( ElementName = "PrtDelDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Prtdeldatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtProdutoTipo_Prtdeldatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProdutoTipo_Prtdeldatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProdutoTipo_Prtdeldatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtProdutoTipo_Prtdeldatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prtdeldatahora_Z
      {
         get {
            return gxTv_SdtProdutoTipo_Prtdeldatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtdeldatahora_Z = value;
            SetDirty("Prtdeldatahora_Z");
         }

      }

      public void gxTv_SdtProdutoTipo_Prtdeldatahora_Z_SetNull( )
      {
         gxTv_SdtProdutoTipo_Prtdeldatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Prtdeldatahora_Z");
         return  ;
      }

      public bool gxTv_SdtProdutoTipo_Prtdeldatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrtDelData_Z" )]
      [  XmlElement( ElementName = "PrtDelData_Z"  , IsNullable=true )]
      public string gxTpr_Prtdeldata_Z_Nullable
      {
         get {
            if ( gxTv_SdtProdutoTipo_Prtdeldata_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProdutoTipo_Prtdeldata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProdutoTipo_Prtdeldata_Z = DateTime.MinValue;
            else
               gxTv_SdtProdutoTipo_Prtdeldata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prtdeldata_Z
      {
         get {
            return gxTv_SdtProdutoTipo_Prtdeldata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtdeldata_Z = value;
            SetDirty("Prtdeldata_Z");
         }

      }

      public void gxTv_SdtProdutoTipo_Prtdeldata_Z_SetNull( )
      {
         gxTv_SdtProdutoTipo_Prtdeldata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Prtdeldata_Z");
         return  ;
      }

      public bool gxTv_SdtProdutoTipo_Prtdeldata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrtDelHora_Z" )]
      [  XmlElement( ElementName = "PrtDelHora_Z"  , IsNullable=true )]
      public string gxTpr_Prtdelhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtProdutoTipo_Prtdelhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProdutoTipo_Prtdelhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProdutoTipo_Prtdelhora_Z = DateTime.MinValue;
            else
               gxTv_SdtProdutoTipo_Prtdelhora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Prtdelhora_Z
      {
         get {
            return gxTv_SdtProdutoTipo_Prtdelhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtdelhora_Z = value;
            SetDirty("Prtdelhora_Z");
         }

      }

      public void gxTv_SdtProdutoTipo_Prtdelhora_Z_SetNull( )
      {
         gxTv_SdtProdutoTipo_Prtdelhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Prtdelhora_Z");
         return  ;
      }

      public bool gxTv_SdtProdutoTipo_Prtdelhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrtDelUsuId_Z" )]
      [  XmlElement( ElementName = "PrtDelUsuId_Z"   )]
      public string gxTpr_Prtdelusuid_Z
      {
         get {
            return gxTv_SdtProdutoTipo_Prtdelusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtdelusuid_Z = value;
            SetDirty("Prtdelusuid_Z");
         }

      }

      public void gxTv_SdtProdutoTipo_Prtdelusuid_Z_SetNull( )
      {
         gxTv_SdtProdutoTipo_Prtdelusuid_Z = "";
         SetDirty("Prtdelusuid_Z");
         return  ;
      }

      public bool gxTv_SdtProdutoTipo_Prtdelusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrtDelUsuNome_Z" )]
      [  XmlElement( ElementName = "PrtDelUsuNome_Z"   )]
      public string gxTpr_Prtdelusunome_Z
      {
         get {
            return gxTv_SdtProdutoTipo_Prtdelusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtdelusunome_Z = value;
            SetDirty("Prtdelusunome_Z");
         }

      }

      public void gxTv_SdtProdutoTipo_Prtdelusunome_Z_SetNull( )
      {
         gxTv_SdtProdutoTipo_Prtdelusunome_Z = "";
         SetDirty("Prtdelusunome_Z");
         return  ;
      }

      public bool gxTv_SdtProdutoTipo_Prtdelusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrtDelDataHora_N" )]
      [  XmlElement( ElementName = "PrtDelDataHora_N"   )]
      public short gxTpr_Prtdeldatahora_N
      {
         get {
            return gxTv_SdtProdutoTipo_Prtdeldatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtdeldatahora_N = value;
            SetDirty("Prtdeldatahora_N");
         }

      }

      public void gxTv_SdtProdutoTipo_Prtdeldatahora_N_SetNull( )
      {
         gxTv_SdtProdutoTipo_Prtdeldatahora_N = 0;
         SetDirty("Prtdeldatahora_N");
         return  ;
      }

      public bool gxTv_SdtProdutoTipo_Prtdeldatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrtDelData_N" )]
      [  XmlElement( ElementName = "PrtDelData_N"   )]
      public short gxTpr_Prtdeldata_N
      {
         get {
            return gxTv_SdtProdutoTipo_Prtdeldata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtdeldata_N = value;
            SetDirty("Prtdeldata_N");
         }

      }

      public void gxTv_SdtProdutoTipo_Prtdeldata_N_SetNull( )
      {
         gxTv_SdtProdutoTipo_Prtdeldata_N = 0;
         SetDirty("Prtdeldata_N");
         return  ;
      }

      public bool gxTv_SdtProdutoTipo_Prtdeldata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrtDelHora_N" )]
      [  XmlElement( ElementName = "PrtDelHora_N"   )]
      public short gxTpr_Prtdelhora_N
      {
         get {
            return gxTv_SdtProdutoTipo_Prtdelhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtdelhora_N = value;
            SetDirty("Prtdelhora_N");
         }

      }

      public void gxTv_SdtProdutoTipo_Prtdelhora_N_SetNull( )
      {
         gxTv_SdtProdutoTipo_Prtdelhora_N = 0;
         SetDirty("Prtdelhora_N");
         return  ;
      }

      public bool gxTv_SdtProdutoTipo_Prtdelhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrtDelUsuId_N" )]
      [  XmlElement( ElementName = "PrtDelUsuId_N"   )]
      public short gxTpr_Prtdelusuid_N
      {
         get {
            return gxTv_SdtProdutoTipo_Prtdelusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtdelusuid_N = value;
            SetDirty("Prtdelusuid_N");
         }

      }

      public void gxTv_SdtProdutoTipo_Prtdelusuid_N_SetNull( )
      {
         gxTv_SdtProdutoTipo_Prtdelusuid_N = 0;
         SetDirty("Prtdelusuid_N");
         return  ;
      }

      public bool gxTv_SdtProdutoTipo_Prtdelusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrtDelUsuNome_N" )]
      [  XmlElement( ElementName = "PrtDelUsuNome_N"   )]
      public short gxTpr_Prtdelusunome_N
      {
         get {
            return gxTv_SdtProdutoTipo_Prtdelusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProdutoTipo_Prtdelusunome_N = value;
            SetDirty("Prtdelusunome_N");
         }

      }

      public void gxTv_SdtProdutoTipo_Prtdelusunome_N_SetNull( )
      {
         gxTv_SdtProdutoTipo_Prtdelusunome_N = 0;
         SetDirty("Prtdelusunome_N");
         return  ;
      }

      public bool gxTv_SdtProdutoTipo_Prtdelusunome_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtProdutoTipo_Prtsigla = "";
         gxTv_SdtProdutoTipo_Prtnome = "";
         gxTv_SdtProdutoTipo_Prtativo = true;
         gxTv_SdtProdutoTipo_Prtdeldatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtProdutoTipo_Prtdeldata = (DateTime)(DateTime.MinValue);
         gxTv_SdtProdutoTipo_Prtdelhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtProdutoTipo_Prtdelusuid = "";
         gxTv_SdtProdutoTipo_Prtdelusunome = "";
         gxTv_SdtProdutoTipo_Mode = "";
         gxTv_SdtProdutoTipo_Prtsigla_Z = "";
         gxTv_SdtProdutoTipo_Prtnome_Z = "";
         gxTv_SdtProdutoTipo_Prtdeldatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtProdutoTipo_Prtdeldata_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtProdutoTipo_Prtdelhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtProdutoTipo_Prtdelusuid_Z = "";
         gxTv_SdtProdutoTipo_Prtdelusunome_Z = "";
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "core.produtotipo", "GeneXus.Programs.core.produtotipo_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtProdutoTipo_Initialized ;
      private short gxTv_SdtProdutoTipo_Prtdeldatahora_N ;
      private short gxTv_SdtProdutoTipo_Prtdeldata_N ;
      private short gxTv_SdtProdutoTipo_Prtdelhora_N ;
      private short gxTv_SdtProdutoTipo_Prtdelusuid_N ;
      private short gxTv_SdtProdutoTipo_Prtdelusunome_N ;
      private int gxTv_SdtProdutoTipo_Prtid ;
      private int gxTv_SdtProdutoTipo_Prtid_Z ;
      private string gxTv_SdtProdutoTipo_Prtdelusuid ;
      private string gxTv_SdtProdutoTipo_Mode ;
      private string gxTv_SdtProdutoTipo_Prtdelusuid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtProdutoTipo_Prtdeldatahora ;
      private DateTime gxTv_SdtProdutoTipo_Prtdeldata ;
      private DateTime gxTv_SdtProdutoTipo_Prtdelhora ;
      private DateTime gxTv_SdtProdutoTipo_Prtdeldatahora_Z ;
      private DateTime gxTv_SdtProdutoTipo_Prtdeldata_Z ;
      private DateTime gxTv_SdtProdutoTipo_Prtdelhora_Z ;
      private DateTime datetimemil_STZ ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtProdutoTipo_Prtativo ;
      private bool gxTv_SdtProdutoTipo_Prtdel ;
      private bool gxTv_SdtProdutoTipo_Prtativo_Z ;
      private bool gxTv_SdtProdutoTipo_Prtdel_Z ;
      private string gxTv_SdtProdutoTipo_Prtsigla ;
      private string gxTv_SdtProdutoTipo_Prtnome ;
      private string gxTv_SdtProdutoTipo_Prtdelusunome ;
      private string gxTv_SdtProdutoTipo_Prtsigla_Z ;
      private string gxTv_SdtProdutoTipo_Prtnome_Z ;
      private string gxTv_SdtProdutoTipo_Prtdelusunome_Z ;
   }

   [DataContract(Name = @"core\ProdutoTipo", Namespace = "agl_tresorygroup")]
   public class SdtProdutoTipo_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtProdutoTipo>
   {
      public SdtProdutoTipo_RESTInterface( ) : base()
      {
      }

      public SdtProdutoTipo_RESTInterface( GeneXus.Programs.core.SdtProdutoTipo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PrtID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Prtid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Prtid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Prtid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PrtSigla" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Prtsigla
      {
         get {
            return sdt.gxTpr_Prtsigla ;
         }

         set {
            sdt.gxTpr_Prtsigla = value;
         }

      }

      [DataMember( Name = "PrtNome" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Prtnome
      {
         get {
            return sdt.gxTpr_Prtnome ;
         }

         set {
            sdt.gxTpr_Prtnome = value;
         }

      }

      [DataMember( Name = "PrtAtivo" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Prtativo
      {
         get {
            return sdt.gxTpr_Prtativo ;
         }

         set {
            sdt.gxTpr_Prtativo = value;
         }

      }

      [DataMember( Name = "PrtDel" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Prtdel
      {
         get {
            return sdt.gxTpr_Prtdel ;
         }

         set {
            sdt.gxTpr_Prtdel = value;
         }

      }

      [DataMember( Name = "PrtDelDataHora" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Prtdeldatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Prtdeldatahora) ;
         }

         set {
            sdt.gxTpr_Prtdeldatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "PrtDelData" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Prtdeldata
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Prtdeldata) ;
         }

         set {
            sdt.gxTpr_Prtdeldata = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "PrtDelHora" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Prtdelhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Prtdelhora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Prtdelhora = GXt_dtime1;
         }

      }

      [DataMember( Name = "PrtDelUsuId" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Prtdelusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Prtdelusuid) ;
         }

         set {
            sdt.gxTpr_Prtdelusuid = value;
         }

      }

      [DataMember( Name = "PrtDelUsuNome" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Prtdelusunome
      {
         get {
            return sdt.gxTpr_Prtdelusunome ;
         }

         set {
            sdt.gxTpr_Prtdelusunome = value;
         }

      }

      public GeneXus.Programs.core.SdtProdutoTipo sdt
      {
         get {
            return (GeneXus.Programs.core.SdtProdutoTipo)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtProdutoTipo() ;
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

   [DataContract(Name = @"core\ProdutoTipo", Namespace = "agl_tresorygroup")]
   public class SdtProdutoTipo_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtProdutoTipo>
   {
      public SdtProdutoTipo_RESTLInterface( ) : base()
      {
      }

      public SdtProdutoTipo_RESTLInterface( GeneXus.Programs.core.SdtProdutoTipo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PrtNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Prtnome
      {
         get {
            return sdt.gxTpr_Prtnome ;
         }

         set {
            sdt.gxTpr_Prtnome = value;
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

      public GeneXus.Programs.core.SdtProdutoTipo sdt
      {
         get {
            return (GeneXus.Programs.core.SdtProdutoTipo)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtProdutoTipo() ;
         }
      }

   }

}
