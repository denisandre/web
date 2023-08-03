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
   [XmlRoot(ElementName = "DocumentoTipo" )]
   [XmlType(TypeName =  "DocumentoTipo" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class SdtDocumentoTipo : GxSilentTrnSdt
   {
      public SdtDocumentoTipo( )
      {
      }

      public SdtDocumentoTipo( IGxContext context )
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

      public void Load( int AV146DocTipoID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV146DocTipoID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"DocTipoID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "core\\DocumentoTipo");
         metadata.Set("BT", "tb_documentotipo");
         metadata.Set("PK", "[ \"DocTipoID\" ]");
         metadata.Set("PKAssigned", "[ \"DocTipoID\" ]");
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
         state.Add("gxTpr_Doctipoid_Z");
         state.Add("gxTpr_Doctiposigla_Z");
         state.Add("gxTpr_Doctiponome_Z");
         state.Add("gxTpr_Doctipoativo_Z");
         state.Add("gxTpr_Doctipodel_Z");
         state.Add("gxTpr_Doctipodeldatahora_Z_Nullable");
         state.Add("gxTpr_Doctipodeldata_Z_Nullable");
         state.Add("gxTpr_Doctipodelhora_Z_Nullable");
         state.Add("gxTpr_Doctipodelusuid_Z");
         state.Add("gxTpr_Doctipodelusunome_Z");
         state.Add("gxTpr_Doctipodeldatahora_N");
         state.Add("gxTpr_Doctipodeldata_N");
         state.Add("gxTpr_Doctipodelhora_N");
         state.Add("gxTpr_Doctipodelusuid_N");
         state.Add("gxTpr_Doctipodelusunome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.SdtDocumentoTipo sdt;
         sdt = (GeneXus.Programs.core.SdtDocumentoTipo)(source);
         gxTv_SdtDocumentoTipo_Doctipoid = sdt.gxTv_SdtDocumentoTipo_Doctipoid ;
         gxTv_SdtDocumentoTipo_Doctiposigla = sdt.gxTv_SdtDocumentoTipo_Doctiposigla ;
         gxTv_SdtDocumentoTipo_Doctiponome = sdt.gxTv_SdtDocumentoTipo_Doctiponome ;
         gxTv_SdtDocumentoTipo_Doctipoativo = sdt.gxTv_SdtDocumentoTipo_Doctipoativo ;
         gxTv_SdtDocumentoTipo_Doctipodel = sdt.gxTv_SdtDocumentoTipo_Doctipodel ;
         gxTv_SdtDocumentoTipo_Doctipodeldatahora = sdt.gxTv_SdtDocumentoTipo_Doctipodeldatahora ;
         gxTv_SdtDocumentoTipo_Doctipodeldata = sdt.gxTv_SdtDocumentoTipo_Doctipodeldata ;
         gxTv_SdtDocumentoTipo_Doctipodelhora = sdt.gxTv_SdtDocumentoTipo_Doctipodelhora ;
         gxTv_SdtDocumentoTipo_Doctipodelusuid = sdt.gxTv_SdtDocumentoTipo_Doctipodelusuid ;
         gxTv_SdtDocumentoTipo_Doctipodelusunome = sdt.gxTv_SdtDocumentoTipo_Doctipodelusunome ;
         gxTv_SdtDocumentoTipo_Mode = sdt.gxTv_SdtDocumentoTipo_Mode ;
         gxTv_SdtDocumentoTipo_Initialized = sdt.gxTv_SdtDocumentoTipo_Initialized ;
         gxTv_SdtDocumentoTipo_Doctipoid_Z = sdt.gxTv_SdtDocumentoTipo_Doctipoid_Z ;
         gxTv_SdtDocumentoTipo_Doctiposigla_Z = sdt.gxTv_SdtDocumentoTipo_Doctiposigla_Z ;
         gxTv_SdtDocumentoTipo_Doctiponome_Z = sdt.gxTv_SdtDocumentoTipo_Doctiponome_Z ;
         gxTv_SdtDocumentoTipo_Doctipoativo_Z = sdt.gxTv_SdtDocumentoTipo_Doctipoativo_Z ;
         gxTv_SdtDocumentoTipo_Doctipodel_Z = sdt.gxTv_SdtDocumentoTipo_Doctipodel_Z ;
         gxTv_SdtDocumentoTipo_Doctipodeldatahora_Z = sdt.gxTv_SdtDocumentoTipo_Doctipodeldatahora_Z ;
         gxTv_SdtDocumentoTipo_Doctipodeldata_Z = sdt.gxTv_SdtDocumentoTipo_Doctipodeldata_Z ;
         gxTv_SdtDocumentoTipo_Doctipodelhora_Z = sdt.gxTv_SdtDocumentoTipo_Doctipodelhora_Z ;
         gxTv_SdtDocumentoTipo_Doctipodelusuid_Z = sdt.gxTv_SdtDocumentoTipo_Doctipodelusuid_Z ;
         gxTv_SdtDocumentoTipo_Doctipodelusunome_Z = sdt.gxTv_SdtDocumentoTipo_Doctipodelusunome_Z ;
         gxTv_SdtDocumentoTipo_Doctipodeldatahora_N = sdt.gxTv_SdtDocumentoTipo_Doctipodeldatahora_N ;
         gxTv_SdtDocumentoTipo_Doctipodeldata_N = sdt.gxTv_SdtDocumentoTipo_Doctipodeldata_N ;
         gxTv_SdtDocumentoTipo_Doctipodelhora_N = sdt.gxTv_SdtDocumentoTipo_Doctipodelhora_N ;
         gxTv_SdtDocumentoTipo_Doctipodelusuid_N = sdt.gxTv_SdtDocumentoTipo_Doctipodelusuid_N ;
         gxTv_SdtDocumentoTipo_Doctipodelusunome_N = sdt.gxTv_SdtDocumentoTipo_Doctipodelusunome_N ;
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
         AddObjectProperty("DocTipoID", gxTv_SdtDocumentoTipo_Doctipoid, false, includeNonInitialized);
         AddObjectProperty("DocTipoSigla", gxTv_SdtDocumentoTipo_Doctiposigla, false, includeNonInitialized);
         AddObjectProperty("DocTipoNome", gxTv_SdtDocumentoTipo_Doctiponome, false, includeNonInitialized);
         AddObjectProperty("DocTipoAtivo", gxTv_SdtDocumentoTipo_Doctipoativo, false, includeNonInitialized);
         AddObjectProperty("DocTipoDel", gxTv_SdtDocumentoTipo_Doctipodel, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtDocumentoTipo_Doctipodeldatahora;
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
         AddObjectProperty("DocTipoDelDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DocTipoDelDataHora_N", gxTv_SdtDocumentoTipo_Doctipodeldatahora_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocumentoTipo_Doctipodeldata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocumentoTipo_Doctipodeldata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocumentoTipo_Doctipodeldata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("DocTipoDelData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DocTipoDelData_N", gxTv_SdtDocumentoTipo_Doctipodeldata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtDocumentoTipo_Doctipodelhora;
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
         AddObjectProperty("DocTipoDelHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DocTipoDelHora_N", gxTv_SdtDocumentoTipo_Doctipodelhora_N, false, includeNonInitialized);
         AddObjectProperty("DocTipoDelUsuID", gxTv_SdtDocumentoTipo_Doctipodelusuid, false, includeNonInitialized);
         AddObjectProperty("DocTipoDelUsuID_N", gxTv_SdtDocumentoTipo_Doctipodelusuid_N, false, includeNonInitialized);
         AddObjectProperty("DocTipoDelUsuNome", gxTv_SdtDocumentoTipo_Doctipodelusunome, false, includeNonInitialized);
         AddObjectProperty("DocTipoDelUsuNome_N", gxTv_SdtDocumentoTipo_Doctipodelusunome_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtDocumentoTipo_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtDocumentoTipo_Initialized, false, includeNonInitialized);
            AddObjectProperty("DocTipoID_Z", gxTv_SdtDocumentoTipo_Doctipoid_Z, false, includeNonInitialized);
            AddObjectProperty("DocTipoSigla_Z", gxTv_SdtDocumentoTipo_Doctiposigla_Z, false, includeNonInitialized);
            AddObjectProperty("DocTipoNome_Z", gxTv_SdtDocumentoTipo_Doctiponome_Z, false, includeNonInitialized);
            AddObjectProperty("DocTipoAtivo_Z", gxTv_SdtDocumentoTipo_Doctipoativo_Z, false, includeNonInitialized);
            AddObjectProperty("DocTipoDel_Z", gxTv_SdtDocumentoTipo_Doctipodel_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtDocumentoTipo_Doctipodeldatahora_Z;
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
            AddObjectProperty("DocTipoDelDataHora_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocumentoTipo_Doctipodeldata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocumentoTipo_Doctipodeldata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocumentoTipo_Doctipodeldata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("DocTipoDelData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtDocumentoTipo_Doctipodelhora_Z;
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
            AddObjectProperty("DocTipoDelHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("DocTipoDelUsuID_Z", gxTv_SdtDocumentoTipo_Doctipodelusuid_Z, false, includeNonInitialized);
            AddObjectProperty("DocTipoDelUsuNome_Z", gxTv_SdtDocumentoTipo_Doctipodelusunome_Z, false, includeNonInitialized);
            AddObjectProperty("DocTipoDelDataHora_N", gxTv_SdtDocumentoTipo_Doctipodeldatahora_N, false, includeNonInitialized);
            AddObjectProperty("DocTipoDelData_N", gxTv_SdtDocumentoTipo_Doctipodeldata_N, false, includeNonInitialized);
            AddObjectProperty("DocTipoDelHora_N", gxTv_SdtDocumentoTipo_Doctipodelhora_N, false, includeNonInitialized);
            AddObjectProperty("DocTipoDelUsuID_N", gxTv_SdtDocumentoTipo_Doctipodelusuid_N, false, includeNonInitialized);
            AddObjectProperty("DocTipoDelUsuNome_N", gxTv_SdtDocumentoTipo_Doctipodelusunome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.SdtDocumentoTipo sdt )
      {
         if ( sdt.IsDirty("DocTipoID") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipoid = sdt.gxTv_SdtDocumentoTipo_Doctipoid ;
         }
         if ( sdt.IsDirty("DocTipoSigla") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctiposigla = sdt.gxTv_SdtDocumentoTipo_Doctiposigla ;
         }
         if ( sdt.IsDirty("DocTipoNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctiponome = sdt.gxTv_SdtDocumentoTipo_Doctiponome ;
         }
         if ( sdt.IsDirty("DocTipoAtivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipoativo = sdt.gxTv_SdtDocumentoTipo_Doctipoativo ;
         }
         if ( sdt.IsDirty("DocTipoDel") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipodel = sdt.gxTv_SdtDocumentoTipo_Doctipodel ;
         }
         if ( sdt.IsDirty("DocTipoDelDataHora") )
         {
            gxTv_SdtDocumentoTipo_Doctipodeldatahora_N = (short)(sdt.gxTv_SdtDocumentoTipo_Doctipodeldatahora_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipodeldatahora = sdt.gxTv_SdtDocumentoTipo_Doctipodeldatahora ;
         }
         if ( sdt.IsDirty("DocTipoDelData") )
         {
            gxTv_SdtDocumentoTipo_Doctipodeldata_N = (short)(sdt.gxTv_SdtDocumentoTipo_Doctipodeldata_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipodeldata = sdt.gxTv_SdtDocumentoTipo_Doctipodeldata ;
         }
         if ( sdt.IsDirty("DocTipoDelHora") )
         {
            gxTv_SdtDocumentoTipo_Doctipodelhora_N = (short)(sdt.gxTv_SdtDocumentoTipo_Doctipodelhora_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipodelhora = sdt.gxTv_SdtDocumentoTipo_Doctipodelhora ;
         }
         if ( sdt.IsDirty("DocTipoDelUsuID") )
         {
            gxTv_SdtDocumentoTipo_Doctipodelusuid_N = (short)(sdt.gxTv_SdtDocumentoTipo_Doctipodelusuid_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipodelusuid = sdt.gxTv_SdtDocumentoTipo_Doctipodelusuid ;
         }
         if ( sdt.IsDirty("DocTipoDelUsuNome") )
         {
            gxTv_SdtDocumentoTipo_Doctipodelusunome_N = (short)(sdt.gxTv_SdtDocumentoTipo_Doctipodelusunome_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipodelusunome = sdt.gxTv_SdtDocumentoTipo_Doctipodelusunome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "DocTipoID" )]
      [  XmlElement( ElementName = "DocTipoID"   )]
      public int gxTpr_Doctipoid
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctipoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtDocumentoTipo_Doctipoid != value )
            {
               gxTv_SdtDocumentoTipo_Mode = "INS";
               this.gxTv_SdtDocumentoTipo_Doctipoid_Z_SetNull( );
               this.gxTv_SdtDocumentoTipo_Doctiposigla_Z_SetNull( );
               this.gxTv_SdtDocumentoTipo_Doctiponome_Z_SetNull( );
               this.gxTv_SdtDocumentoTipo_Doctipoativo_Z_SetNull( );
               this.gxTv_SdtDocumentoTipo_Doctipodel_Z_SetNull( );
               this.gxTv_SdtDocumentoTipo_Doctipodeldatahora_Z_SetNull( );
               this.gxTv_SdtDocumentoTipo_Doctipodeldata_Z_SetNull( );
               this.gxTv_SdtDocumentoTipo_Doctipodelhora_Z_SetNull( );
               this.gxTv_SdtDocumentoTipo_Doctipodelusuid_Z_SetNull( );
               this.gxTv_SdtDocumentoTipo_Doctipodelusunome_Z_SetNull( );
            }
            gxTv_SdtDocumentoTipo_Doctipoid = value;
            SetDirty("Doctipoid");
         }

      }

      [  SoapElement( ElementName = "DocTipoSigla" )]
      [  XmlElement( ElementName = "DocTipoSigla"   )]
      public string gxTpr_Doctiposigla
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctiposigla ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctiposigla = value;
            SetDirty("Doctiposigla");
         }

      }

      [  SoapElement( ElementName = "DocTipoNome" )]
      [  XmlElement( ElementName = "DocTipoNome"   )]
      public string gxTpr_Doctiponome
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctiponome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctiponome = value;
            SetDirty("Doctiponome");
         }

      }

      [  SoapElement( ElementName = "DocTipoAtivo" )]
      [  XmlElement( ElementName = "DocTipoAtivo"   )]
      public bool gxTpr_Doctipoativo
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctipoativo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipoativo = value;
            SetDirty("Doctipoativo");
         }

      }

      [  SoapElement( ElementName = "DocTipoDel" )]
      [  XmlElement( ElementName = "DocTipoDel"   )]
      public bool gxTpr_Doctipodel
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctipodel ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipodel = value;
            SetDirty("Doctipodel");
         }

      }

      [  SoapElement( ElementName = "DocTipoDelDataHora" )]
      [  XmlElement( ElementName = "DocTipoDelDataHora"  , IsNullable=true )]
      public string gxTpr_Doctipodeldatahora_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoTipo_Doctipodeldatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoTipo_Doctipodeldatahora).value ;
         }

         set {
            gxTv_SdtDocumentoTipo_Doctipodeldatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoTipo_Doctipodeldatahora = DateTime.MinValue;
            else
               gxTv_SdtDocumentoTipo_Doctipodeldatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Doctipodeldatahora
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctipodeldatahora ;
         }

         set {
            gxTv_SdtDocumentoTipo_Doctipodeldatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipodeldatahora = value;
            SetDirty("Doctipodeldatahora");
         }

      }

      public void gxTv_SdtDocumentoTipo_Doctipodeldatahora_SetNull( )
      {
         gxTv_SdtDocumentoTipo_Doctipodeldatahora_N = 1;
         gxTv_SdtDocumentoTipo_Doctipodeldatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Doctipodeldatahora");
         return  ;
      }

      public bool gxTv_SdtDocumentoTipo_Doctipodeldatahora_IsNull( )
      {
         return (gxTv_SdtDocumentoTipo_Doctipodeldatahora_N==1) ;
      }

      [  SoapElement( ElementName = "DocTipoDelData" )]
      [  XmlElement( ElementName = "DocTipoDelData"  , IsNullable=true )]
      public string gxTpr_Doctipodeldata_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoTipo_Doctipodeldata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocumentoTipo_Doctipodeldata).value ;
         }

         set {
            gxTv_SdtDocumentoTipo_Doctipodeldata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocumentoTipo_Doctipodeldata = DateTime.MinValue;
            else
               gxTv_SdtDocumentoTipo_Doctipodeldata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Doctipodeldata
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctipodeldata ;
         }

         set {
            gxTv_SdtDocumentoTipo_Doctipodeldata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipodeldata = value;
            SetDirty("Doctipodeldata");
         }

      }

      public void gxTv_SdtDocumentoTipo_Doctipodeldata_SetNull( )
      {
         gxTv_SdtDocumentoTipo_Doctipodeldata_N = 1;
         gxTv_SdtDocumentoTipo_Doctipodeldata = (DateTime)(DateTime.MinValue);
         SetDirty("Doctipodeldata");
         return  ;
      }

      public bool gxTv_SdtDocumentoTipo_Doctipodeldata_IsNull( )
      {
         return (gxTv_SdtDocumentoTipo_Doctipodeldata_N==1) ;
      }

      [  SoapElement( ElementName = "DocTipoDelHora" )]
      [  XmlElement( ElementName = "DocTipoDelHora"  , IsNullable=true )]
      public string gxTpr_Doctipodelhora_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoTipo_Doctipodelhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoTipo_Doctipodelhora).value ;
         }

         set {
            gxTv_SdtDocumentoTipo_Doctipodelhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoTipo_Doctipodelhora = DateTime.MinValue;
            else
               gxTv_SdtDocumentoTipo_Doctipodelhora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Doctipodelhora
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctipodelhora ;
         }

         set {
            gxTv_SdtDocumentoTipo_Doctipodelhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipodelhora = value;
            SetDirty("Doctipodelhora");
         }

      }

      public void gxTv_SdtDocumentoTipo_Doctipodelhora_SetNull( )
      {
         gxTv_SdtDocumentoTipo_Doctipodelhora_N = 1;
         gxTv_SdtDocumentoTipo_Doctipodelhora = (DateTime)(DateTime.MinValue);
         SetDirty("Doctipodelhora");
         return  ;
      }

      public bool gxTv_SdtDocumentoTipo_Doctipodelhora_IsNull( )
      {
         return (gxTv_SdtDocumentoTipo_Doctipodelhora_N==1) ;
      }

      [  SoapElement( ElementName = "DocTipoDelUsuID" )]
      [  XmlElement( ElementName = "DocTipoDelUsuID"   )]
      public string gxTpr_Doctipodelusuid
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctipodelusuid ;
         }

         set {
            gxTv_SdtDocumentoTipo_Doctipodelusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipodelusuid = value;
            SetDirty("Doctipodelusuid");
         }

      }

      public void gxTv_SdtDocumentoTipo_Doctipodelusuid_SetNull( )
      {
         gxTv_SdtDocumentoTipo_Doctipodelusuid_N = 1;
         gxTv_SdtDocumentoTipo_Doctipodelusuid = "";
         SetDirty("Doctipodelusuid");
         return  ;
      }

      public bool gxTv_SdtDocumentoTipo_Doctipodelusuid_IsNull( )
      {
         return (gxTv_SdtDocumentoTipo_Doctipodelusuid_N==1) ;
      }

      [  SoapElement( ElementName = "DocTipoDelUsuNome" )]
      [  XmlElement( ElementName = "DocTipoDelUsuNome"   )]
      public string gxTpr_Doctipodelusunome
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctipodelusunome ;
         }

         set {
            gxTv_SdtDocumentoTipo_Doctipodelusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipodelusunome = value;
            SetDirty("Doctipodelusunome");
         }

      }

      public void gxTv_SdtDocumentoTipo_Doctipodelusunome_SetNull( )
      {
         gxTv_SdtDocumentoTipo_Doctipodelusunome_N = 1;
         gxTv_SdtDocumentoTipo_Doctipodelusunome = "";
         SetDirty("Doctipodelusunome");
         return  ;
      }

      public bool gxTv_SdtDocumentoTipo_Doctipodelusunome_IsNull( )
      {
         return (gxTv_SdtDocumentoTipo_Doctipodelusunome_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtDocumentoTipo_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtDocumentoTipo_Mode_SetNull( )
      {
         gxTv_SdtDocumentoTipo_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtDocumentoTipo_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtDocumentoTipo_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtDocumentoTipo_Initialized_SetNull( )
      {
         gxTv_SdtDocumentoTipo_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtDocumentoTipo_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocTipoID_Z" )]
      [  XmlElement( ElementName = "DocTipoID_Z"   )]
      public int gxTpr_Doctipoid_Z
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctipoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipoid_Z = value;
            SetDirty("Doctipoid_Z");
         }

      }

      public void gxTv_SdtDocumentoTipo_Doctipoid_Z_SetNull( )
      {
         gxTv_SdtDocumentoTipo_Doctipoid_Z = 0;
         SetDirty("Doctipoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoTipo_Doctipoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocTipoSigla_Z" )]
      [  XmlElement( ElementName = "DocTipoSigla_Z"   )]
      public string gxTpr_Doctiposigla_Z
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctiposigla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctiposigla_Z = value;
            SetDirty("Doctiposigla_Z");
         }

      }

      public void gxTv_SdtDocumentoTipo_Doctiposigla_Z_SetNull( )
      {
         gxTv_SdtDocumentoTipo_Doctiposigla_Z = "";
         SetDirty("Doctiposigla_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoTipo_Doctiposigla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocTipoNome_Z" )]
      [  XmlElement( ElementName = "DocTipoNome_Z"   )]
      public string gxTpr_Doctiponome_Z
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctiponome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctiponome_Z = value;
            SetDirty("Doctiponome_Z");
         }

      }

      public void gxTv_SdtDocumentoTipo_Doctiponome_Z_SetNull( )
      {
         gxTv_SdtDocumentoTipo_Doctiponome_Z = "";
         SetDirty("Doctiponome_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoTipo_Doctiponome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocTipoAtivo_Z" )]
      [  XmlElement( ElementName = "DocTipoAtivo_Z"   )]
      public bool gxTpr_Doctipoativo_Z
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctipoativo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipoativo_Z = value;
            SetDirty("Doctipoativo_Z");
         }

      }

      public void gxTv_SdtDocumentoTipo_Doctipoativo_Z_SetNull( )
      {
         gxTv_SdtDocumentoTipo_Doctipoativo_Z = false;
         SetDirty("Doctipoativo_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoTipo_Doctipoativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocTipoDel_Z" )]
      [  XmlElement( ElementName = "DocTipoDel_Z"   )]
      public bool gxTpr_Doctipodel_Z
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctipodel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipodel_Z = value;
            SetDirty("Doctipodel_Z");
         }

      }

      public void gxTv_SdtDocumentoTipo_Doctipodel_Z_SetNull( )
      {
         gxTv_SdtDocumentoTipo_Doctipodel_Z = false;
         SetDirty("Doctipodel_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoTipo_Doctipodel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocTipoDelDataHora_Z" )]
      [  XmlElement( ElementName = "DocTipoDelDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Doctipodeldatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoTipo_Doctipodeldatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoTipo_Doctipodeldatahora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoTipo_Doctipodeldatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoTipo_Doctipodeldatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Doctipodeldatahora_Z
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctipodeldatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipodeldatahora_Z = value;
            SetDirty("Doctipodeldatahora_Z");
         }

      }

      public void gxTv_SdtDocumentoTipo_Doctipodeldatahora_Z_SetNull( )
      {
         gxTv_SdtDocumentoTipo_Doctipodeldatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Doctipodeldatahora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoTipo_Doctipodeldatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocTipoDelData_Z" )]
      [  XmlElement( ElementName = "DocTipoDelData_Z"  , IsNullable=true )]
      public string gxTpr_Doctipodeldata_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoTipo_Doctipodeldata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocumentoTipo_Doctipodeldata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocumentoTipo_Doctipodeldata_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoTipo_Doctipodeldata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Doctipodeldata_Z
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctipodeldata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipodeldata_Z = value;
            SetDirty("Doctipodeldata_Z");
         }

      }

      public void gxTv_SdtDocumentoTipo_Doctipodeldata_Z_SetNull( )
      {
         gxTv_SdtDocumentoTipo_Doctipodeldata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Doctipodeldata_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoTipo_Doctipodeldata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocTipoDelHora_Z" )]
      [  XmlElement( ElementName = "DocTipoDelHora_Z"  , IsNullable=true )]
      public string gxTpr_Doctipodelhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumentoTipo_Doctipodelhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumentoTipo_Doctipodelhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumentoTipo_Doctipodelhora_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumentoTipo_Doctipodelhora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Doctipodelhora_Z
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctipodelhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipodelhora_Z = value;
            SetDirty("Doctipodelhora_Z");
         }

      }

      public void gxTv_SdtDocumentoTipo_Doctipodelhora_Z_SetNull( )
      {
         gxTv_SdtDocumentoTipo_Doctipodelhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Doctipodelhora_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoTipo_Doctipodelhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocTipoDelUsuID_Z" )]
      [  XmlElement( ElementName = "DocTipoDelUsuID_Z"   )]
      public string gxTpr_Doctipodelusuid_Z
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctipodelusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipodelusuid_Z = value;
            SetDirty("Doctipodelusuid_Z");
         }

      }

      public void gxTv_SdtDocumentoTipo_Doctipodelusuid_Z_SetNull( )
      {
         gxTv_SdtDocumentoTipo_Doctipodelusuid_Z = "";
         SetDirty("Doctipodelusuid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoTipo_Doctipodelusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocTipoDelUsuNome_Z" )]
      [  XmlElement( ElementName = "DocTipoDelUsuNome_Z"   )]
      public string gxTpr_Doctipodelusunome_Z
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctipodelusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipodelusunome_Z = value;
            SetDirty("Doctipodelusunome_Z");
         }

      }

      public void gxTv_SdtDocumentoTipo_Doctipodelusunome_Z_SetNull( )
      {
         gxTv_SdtDocumentoTipo_Doctipodelusunome_Z = "";
         SetDirty("Doctipodelusunome_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentoTipo_Doctipodelusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocTipoDelDataHora_N" )]
      [  XmlElement( ElementName = "DocTipoDelDataHora_N"   )]
      public short gxTpr_Doctipodeldatahora_N
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctipodeldatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipodeldatahora_N = value;
            SetDirty("Doctipodeldatahora_N");
         }

      }

      public void gxTv_SdtDocumentoTipo_Doctipodeldatahora_N_SetNull( )
      {
         gxTv_SdtDocumentoTipo_Doctipodeldatahora_N = 0;
         SetDirty("Doctipodeldatahora_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoTipo_Doctipodeldatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocTipoDelData_N" )]
      [  XmlElement( ElementName = "DocTipoDelData_N"   )]
      public short gxTpr_Doctipodeldata_N
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctipodeldata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipodeldata_N = value;
            SetDirty("Doctipodeldata_N");
         }

      }

      public void gxTv_SdtDocumentoTipo_Doctipodeldata_N_SetNull( )
      {
         gxTv_SdtDocumentoTipo_Doctipodeldata_N = 0;
         SetDirty("Doctipodeldata_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoTipo_Doctipodeldata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocTipoDelHora_N" )]
      [  XmlElement( ElementName = "DocTipoDelHora_N"   )]
      public short gxTpr_Doctipodelhora_N
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctipodelhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipodelhora_N = value;
            SetDirty("Doctipodelhora_N");
         }

      }

      public void gxTv_SdtDocumentoTipo_Doctipodelhora_N_SetNull( )
      {
         gxTv_SdtDocumentoTipo_Doctipodelhora_N = 0;
         SetDirty("Doctipodelhora_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoTipo_Doctipodelhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocTipoDelUsuID_N" )]
      [  XmlElement( ElementName = "DocTipoDelUsuID_N"   )]
      public short gxTpr_Doctipodelusuid_N
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctipodelusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipodelusuid_N = value;
            SetDirty("Doctipodelusuid_N");
         }

      }

      public void gxTv_SdtDocumentoTipo_Doctipodelusuid_N_SetNull( )
      {
         gxTv_SdtDocumentoTipo_Doctipodelusuid_N = 0;
         SetDirty("Doctipodelusuid_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoTipo_Doctipodelusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocTipoDelUsuNome_N" )]
      [  XmlElement( ElementName = "DocTipoDelUsuNome_N"   )]
      public short gxTpr_Doctipodelusunome_N
      {
         get {
            return gxTv_SdtDocumentoTipo_Doctipodelusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentoTipo_Doctipodelusunome_N = value;
            SetDirty("Doctipodelusunome_N");
         }

      }

      public void gxTv_SdtDocumentoTipo_Doctipodelusunome_N_SetNull( )
      {
         gxTv_SdtDocumentoTipo_Doctipodelusunome_N = 0;
         SetDirty("Doctipodelusunome_N");
         return  ;
      }

      public bool gxTv_SdtDocumentoTipo_Doctipodelusunome_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtDocumentoTipo_Doctiposigla = "";
         gxTv_SdtDocumentoTipo_Doctiponome = "";
         gxTv_SdtDocumentoTipo_Doctipoativo = true;
         gxTv_SdtDocumentoTipo_Doctipodeldatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoTipo_Doctipodeldata = DateTime.MinValue;
         gxTv_SdtDocumentoTipo_Doctipodelhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoTipo_Doctipodelusuid = "";
         gxTv_SdtDocumentoTipo_Doctipodelusunome = "";
         gxTv_SdtDocumentoTipo_Mode = "";
         gxTv_SdtDocumentoTipo_Doctiposigla_Z = "";
         gxTv_SdtDocumentoTipo_Doctiponome_Z = "";
         gxTv_SdtDocumentoTipo_Doctipodeldatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoTipo_Doctipodeldata_Z = DateTime.MinValue;
         gxTv_SdtDocumentoTipo_Doctipodelhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumentoTipo_Doctipodelusuid_Z = "";
         gxTv_SdtDocumentoTipo_Doctipodelusunome_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "core.documentotipo", "GeneXus.Programs.core.documentotipo_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtDocumentoTipo_Initialized ;
      private short gxTv_SdtDocumentoTipo_Doctipodeldatahora_N ;
      private short gxTv_SdtDocumentoTipo_Doctipodeldata_N ;
      private short gxTv_SdtDocumentoTipo_Doctipodelhora_N ;
      private short gxTv_SdtDocumentoTipo_Doctipodelusuid_N ;
      private short gxTv_SdtDocumentoTipo_Doctipodelusunome_N ;
      private int gxTv_SdtDocumentoTipo_Doctipoid ;
      private int gxTv_SdtDocumentoTipo_Doctipoid_Z ;
      private string gxTv_SdtDocumentoTipo_Doctipodelusuid ;
      private string gxTv_SdtDocumentoTipo_Mode ;
      private string gxTv_SdtDocumentoTipo_Doctipodelusuid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtDocumentoTipo_Doctipodeldatahora ;
      private DateTime gxTv_SdtDocumentoTipo_Doctipodelhora ;
      private DateTime gxTv_SdtDocumentoTipo_Doctipodeldatahora_Z ;
      private DateTime gxTv_SdtDocumentoTipo_Doctipodelhora_Z ;
      private DateTime datetime_STZ ;
      private DateTime gxTv_SdtDocumentoTipo_Doctipodeldata ;
      private DateTime gxTv_SdtDocumentoTipo_Doctipodeldata_Z ;
      private bool gxTv_SdtDocumentoTipo_Doctipoativo ;
      private bool gxTv_SdtDocumentoTipo_Doctipodel ;
      private bool gxTv_SdtDocumentoTipo_Doctipoativo_Z ;
      private bool gxTv_SdtDocumentoTipo_Doctipodel_Z ;
      private string gxTv_SdtDocumentoTipo_Doctiposigla ;
      private string gxTv_SdtDocumentoTipo_Doctiponome ;
      private string gxTv_SdtDocumentoTipo_Doctipodelusunome ;
      private string gxTv_SdtDocumentoTipo_Doctiposigla_Z ;
      private string gxTv_SdtDocumentoTipo_Doctiponome_Z ;
      private string gxTv_SdtDocumentoTipo_Doctipodelusunome_Z ;
   }

   [DataContract(Name = @"core\DocumentoTipo", Namespace = "agl_tresorygroup")]
   public class SdtDocumentoTipo_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtDocumentoTipo>
   {
      public SdtDocumentoTipo_RESTInterface( ) : base()
      {
      }

      public SdtDocumentoTipo_RESTInterface( GeneXus.Programs.core.SdtDocumentoTipo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DocTipoID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Doctipoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Doctipoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Doctipoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "DocTipoSigla" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Doctiposigla
      {
         get {
            return sdt.gxTpr_Doctiposigla ;
         }

         set {
            sdt.gxTpr_Doctiposigla = value;
         }

      }

      [DataMember( Name = "DocTipoNome" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Doctiponome
      {
         get {
            return sdt.gxTpr_Doctiponome ;
         }

         set {
            sdt.gxTpr_Doctiponome = value;
         }

      }

      [DataMember( Name = "DocTipoAtivo" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Doctipoativo
      {
         get {
            return sdt.gxTpr_Doctipoativo ;
         }

         set {
            sdt.gxTpr_Doctipoativo = value;
         }

      }

      [DataMember( Name = "DocTipoDel" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Doctipodel
      {
         get {
            return sdt.gxTpr_Doctipodel ;
         }

         set {
            sdt.gxTpr_Doctipodel = value;
         }

      }

      [DataMember( Name = "DocTipoDelDataHora" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Doctipodeldatahora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Doctipodeldatahora) ;
         }

         set {
            sdt.gxTpr_Doctipodeldatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "DocTipoDelData" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Doctipodeldata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Doctipodeldata) ;
         }

         set {
            sdt.gxTpr_Doctipodeldata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "DocTipoDelHora" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Doctipodelhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Doctipodelhora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Doctipodelhora = GXt_dtime1;
         }

      }

      [DataMember( Name = "DocTipoDelUsuID" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Doctipodelusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Doctipodelusuid) ;
         }

         set {
            sdt.gxTpr_Doctipodelusuid = value;
         }

      }

      [DataMember( Name = "DocTipoDelUsuNome" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Doctipodelusunome
      {
         get {
            return sdt.gxTpr_Doctipodelusunome ;
         }

         set {
            sdt.gxTpr_Doctipodelusunome = value;
         }

      }

      public GeneXus.Programs.core.SdtDocumentoTipo sdt
      {
         get {
            return (GeneXus.Programs.core.SdtDocumentoTipo)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtDocumentoTipo() ;
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

   [DataContract(Name = @"core\DocumentoTipo", Namespace = "agl_tresorygroup")]
   public class SdtDocumentoTipo_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtDocumentoTipo>
   {
      public SdtDocumentoTipo_RESTLInterface( ) : base()
      {
      }

      public SdtDocumentoTipo_RESTLInterface( GeneXus.Programs.core.SdtDocumentoTipo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DocTipoSigla" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Doctiposigla
      {
         get {
            return sdt.gxTpr_Doctiposigla ;
         }

         set {
            sdt.gxTpr_Doctiposigla = value;
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

      public GeneXus.Programs.core.SdtDocumentoTipo sdt
      {
         get {
            return (GeneXus.Programs.core.SdtDocumentoTipo)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtDocumentoTipo() ;
         }
      }

   }

}
