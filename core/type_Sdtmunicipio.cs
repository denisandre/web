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
   [XmlRoot(ElementName = "municipio" )]
   [XmlType(TypeName =  "municipio" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class Sdtmunicipio : GxSilentTrnSdt
   {
      public Sdtmunicipio( )
      {
      }

      public Sdtmunicipio( IGxContext context )
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

      public void Load( int AV35MunicipioID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV35MunicipioID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"MunicipioID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "core\\municipio");
         metadata.Set("BT", "tbibge_municipio");
         metadata.Set("PK", "[ \"MunicipioID\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"MicrorregiaoID\" ],\"FKMap\":[ \"MunicipioMicroID-MicrorregiaoID\" ] } ]");
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
         state.Add("gxTpr_Municipioid_Z");
         state.Add("gxTpr_Municipionome_Z");
         state.Add("gxTpr_Municipiomicroid_Z");
         state.Add("gxTpr_Municipiomicronome_Z");
         state.Add("gxTpr_Municipiomicromesoid_Z");
         state.Add("gxTpr_Municipiomicromesonome_Z");
         state.Add("gxTpr_Municipiomicromesoufid_Z");
         state.Add("gxTpr_Municipiomicromesoufsigla_Z");
         state.Add("gxTpr_Municipiomicromesoufnome_Z");
         state.Add("gxTpr_Municipiomicromesoufsiglanome_Z");
         state.Add("gxTpr_Municipiomicromesoufregid_Z");
         state.Add("gxTpr_Municipiomicromesoufregsigla_Z");
         state.Add("gxTpr_Municipiomicromesoufregnome_Z");
         state.Add("gxTpr_Municipiomicromesoufregsiglanome_Z");
         state.Add("gxTpr_Municipiomicromesonome_N");
         state.Add("gxTpr_Municipiomicromesoufid_N");
         state.Add("gxTpr_Municipiomicromesoufsigla_N");
         state.Add("gxTpr_Municipiomicromesoufnome_N");
         state.Add("gxTpr_Municipiomicromesoufsiglanome_N");
         state.Add("gxTpr_Municipiomicromesoufregid_N");
         state.Add("gxTpr_Municipiomicromesoufregsigla_N");
         state.Add("gxTpr_Municipiomicromesoufregnome_N");
         state.Add("gxTpr_Municipiomicromesoufregsiglanome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.Sdtmunicipio sdt;
         sdt = (GeneXus.Programs.core.Sdtmunicipio)(source);
         gxTv_Sdtmunicipio_Municipioid = sdt.gxTv_Sdtmunicipio_Municipioid ;
         gxTv_Sdtmunicipio_Municipionome = sdt.gxTv_Sdtmunicipio_Municipionome ;
         gxTv_Sdtmunicipio_Municipiomicroid = sdt.gxTv_Sdtmunicipio_Municipiomicroid ;
         gxTv_Sdtmunicipio_Municipiomicronome = sdt.gxTv_Sdtmunicipio_Municipiomicronome ;
         gxTv_Sdtmunicipio_Municipiomicromesoid = sdt.gxTv_Sdtmunicipio_Municipiomicromesoid ;
         gxTv_Sdtmunicipio_Municipiomicromesonome = sdt.gxTv_Sdtmunicipio_Municipiomicromesonome ;
         gxTv_Sdtmunicipio_Municipiomicromesoufid = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufid ;
         gxTv_Sdtmunicipio_Municipiomicromesoufsigla = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufsigla ;
         gxTv_Sdtmunicipio_Municipiomicromesoufnome = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufnome ;
         gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome ;
         gxTv_Sdtmunicipio_Municipiomicromesoufregid = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufregid ;
         gxTv_Sdtmunicipio_Municipiomicromesoufregsigla = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufregsigla ;
         gxTv_Sdtmunicipio_Municipiomicromesoufregnome = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufregnome ;
         gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome ;
         gxTv_Sdtmunicipio_Mode = sdt.gxTv_Sdtmunicipio_Mode ;
         gxTv_Sdtmunicipio_Initialized = sdt.gxTv_Sdtmunicipio_Initialized ;
         gxTv_Sdtmunicipio_Municipioid_Z = sdt.gxTv_Sdtmunicipio_Municipioid_Z ;
         gxTv_Sdtmunicipio_Municipionome_Z = sdt.gxTv_Sdtmunicipio_Municipionome_Z ;
         gxTv_Sdtmunicipio_Municipiomicroid_Z = sdt.gxTv_Sdtmunicipio_Municipiomicroid_Z ;
         gxTv_Sdtmunicipio_Municipiomicronome_Z = sdt.gxTv_Sdtmunicipio_Municipiomicronome_Z ;
         gxTv_Sdtmunicipio_Municipiomicromesoid_Z = sdt.gxTv_Sdtmunicipio_Municipiomicromesoid_Z ;
         gxTv_Sdtmunicipio_Municipiomicromesonome_Z = sdt.gxTv_Sdtmunicipio_Municipiomicromesonome_Z ;
         gxTv_Sdtmunicipio_Municipiomicromesoufid_Z = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufid_Z ;
         gxTv_Sdtmunicipio_Municipiomicromesoufsigla_Z = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufsigla_Z ;
         gxTv_Sdtmunicipio_Municipiomicromesoufnome_Z = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufnome_Z ;
         gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_Z = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_Z ;
         gxTv_Sdtmunicipio_Municipiomicromesoufregid_Z = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufregid_Z ;
         gxTv_Sdtmunicipio_Municipiomicromesoufregsigla_Z = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufregsigla_Z ;
         gxTv_Sdtmunicipio_Municipiomicromesoufregnome_Z = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufregnome_Z ;
         gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_Z = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_Z ;
         gxTv_Sdtmunicipio_Municipiomicromesonome_N = sdt.gxTv_Sdtmunicipio_Municipiomicromesonome_N ;
         gxTv_Sdtmunicipio_Municipiomicromesoufid_N = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufid_N ;
         gxTv_Sdtmunicipio_Municipiomicromesoufsigla_N = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufsigla_N ;
         gxTv_Sdtmunicipio_Municipiomicromesoufnome_N = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufnome_N ;
         gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_N = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_N ;
         gxTv_Sdtmunicipio_Municipiomicromesoufregid_N = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufregid_N ;
         gxTv_Sdtmunicipio_Municipiomicromesoufregsigla_N = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufregsigla_N ;
         gxTv_Sdtmunicipio_Municipiomicromesoufregnome_N = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufregnome_N ;
         gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_N = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_N ;
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
         AddObjectProperty("MunicipioID", gxTv_Sdtmunicipio_Municipioid, false, includeNonInitialized);
         AddObjectProperty("MunicipioNome", gxTv_Sdtmunicipio_Municipionome, false, includeNonInitialized);
         AddObjectProperty("MunicipioMicroID", gxTv_Sdtmunicipio_Municipiomicroid, false, includeNonInitialized);
         AddObjectProperty("MunicipioMicroNome", gxTv_Sdtmunicipio_Municipiomicronome, false, includeNonInitialized);
         AddObjectProperty("MunicipioMicroMesoID", gxTv_Sdtmunicipio_Municipiomicromesoid, false, includeNonInitialized);
         AddObjectProperty("MunicipioMicroMesoNome", gxTv_Sdtmunicipio_Municipiomicromesonome, false, includeNonInitialized);
         AddObjectProperty("MunicipioMicroMesoNome_N", gxTv_Sdtmunicipio_Municipiomicromesonome_N, false, includeNonInitialized);
         AddObjectProperty("MunicipioMicroMesoUFID", gxTv_Sdtmunicipio_Municipiomicromesoufid, false, includeNonInitialized);
         AddObjectProperty("MunicipioMicroMesoUFID_N", gxTv_Sdtmunicipio_Municipiomicromesoufid_N, false, includeNonInitialized);
         AddObjectProperty("MunicipioMicroMesoUFSigla", gxTv_Sdtmunicipio_Municipiomicromesoufsigla, false, includeNonInitialized);
         AddObjectProperty("MunicipioMicroMesoUFSigla_N", gxTv_Sdtmunicipio_Municipiomicromesoufsigla_N, false, includeNonInitialized);
         AddObjectProperty("MunicipioMicroMesoUFNome", gxTv_Sdtmunicipio_Municipiomicromesoufnome, false, includeNonInitialized);
         AddObjectProperty("MunicipioMicroMesoUFNome_N", gxTv_Sdtmunicipio_Municipiomicromesoufnome_N, false, includeNonInitialized);
         AddObjectProperty("MunicipioMicroMesoUFSiglaNome", gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome, false, includeNonInitialized);
         AddObjectProperty("MunicipioMicroMesoUFSiglaNome_N", gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_N, false, includeNonInitialized);
         AddObjectProperty("MunicipioMicroMesoUFRegID", gxTv_Sdtmunicipio_Municipiomicromesoufregid, false, includeNonInitialized);
         AddObjectProperty("MunicipioMicroMesoUFRegID_N", gxTv_Sdtmunicipio_Municipiomicromesoufregid_N, false, includeNonInitialized);
         AddObjectProperty("MunicipioMicroMesoUFRegSigla", gxTv_Sdtmunicipio_Municipiomicromesoufregsigla, false, includeNonInitialized);
         AddObjectProperty("MunicipioMicroMesoUFRegSigla_N", gxTv_Sdtmunicipio_Municipiomicromesoufregsigla_N, false, includeNonInitialized);
         AddObjectProperty("MunicipioMicroMesoUFRegNome", gxTv_Sdtmunicipio_Municipiomicromesoufregnome, false, includeNonInitialized);
         AddObjectProperty("MunicipioMicroMesoUFRegNome_N", gxTv_Sdtmunicipio_Municipiomicromesoufregnome_N, false, includeNonInitialized);
         AddObjectProperty("MunicipioMicroMesoUFRegSiglaNome", gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome, false, includeNonInitialized);
         AddObjectProperty("MunicipioMicroMesoUFRegSiglaNome_N", gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_Sdtmunicipio_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_Sdtmunicipio_Initialized, false, includeNonInitialized);
            AddObjectProperty("MunicipioID_Z", gxTv_Sdtmunicipio_Municipioid_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioNome_Z", gxTv_Sdtmunicipio_Municipionome_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioMicroID_Z", gxTv_Sdtmunicipio_Municipiomicroid_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioMicroNome_Z", gxTv_Sdtmunicipio_Municipiomicronome_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioMicroMesoID_Z", gxTv_Sdtmunicipio_Municipiomicromesoid_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioMicroMesoNome_Z", gxTv_Sdtmunicipio_Municipiomicromesonome_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioMicroMesoUFID_Z", gxTv_Sdtmunicipio_Municipiomicromesoufid_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioMicroMesoUFSigla_Z", gxTv_Sdtmunicipio_Municipiomicromesoufsigla_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioMicroMesoUFNome_Z", gxTv_Sdtmunicipio_Municipiomicromesoufnome_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioMicroMesoUFSiglaNome_Z", gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioMicroMesoUFRegID_Z", gxTv_Sdtmunicipio_Municipiomicromesoufregid_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioMicroMesoUFRegSigla_Z", gxTv_Sdtmunicipio_Municipiomicromesoufregsigla_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioMicroMesoUFRegNome_Z", gxTv_Sdtmunicipio_Municipiomicromesoufregnome_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioMicroMesoUFRegSiglaNome_Z", gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioMicroMesoNome_N", gxTv_Sdtmunicipio_Municipiomicromesonome_N, false, includeNonInitialized);
            AddObjectProperty("MunicipioMicroMesoUFID_N", gxTv_Sdtmunicipio_Municipiomicromesoufid_N, false, includeNonInitialized);
            AddObjectProperty("MunicipioMicroMesoUFSigla_N", gxTv_Sdtmunicipio_Municipiomicromesoufsigla_N, false, includeNonInitialized);
            AddObjectProperty("MunicipioMicroMesoUFNome_N", gxTv_Sdtmunicipio_Municipiomicromesoufnome_N, false, includeNonInitialized);
            AddObjectProperty("MunicipioMicroMesoUFSiglaNome_N", gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_N, false, includeNonInitialized);
            AddObjectProperty("MunicipioMicroMesoUFRegID_N", gxTv_Sdtmunicipio_Municipiomicromesoufregid_N, false, includeNonInitialized);
            AddObjectProperty("MunicipioMicroMesoUFRegSigla_N", gxTv_Sdtmunicipio_Municipiomicromesoufregsigla_N, false, includeNonInitialized);
            AddObjectProperty("MunicipioMicroMesoUFRegNome_N", gxTv_Sdtmunicipio_Municipiomicromesoufregnome_N, false, includeNonInitialized);
            AddObjectProperty("MunicipioMicroMesoUFRegSiglaNome_N", gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.Sdtmunicipio sdt )
      {
         if ( sdt.IsDirty("MunicipioID") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipioid = sdt.gxTv_Sdtmunicipio_Municipioid ;
         }
         if ( sdt.IsDirty("MunicipioNome") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipionome = sdt.gxTv_Sdtmunicipio_Municipionome ;
         }
         if ( sdt.IsDirty("MunicipioMicroID") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicroid = sdt.gxTv_Sdtmunicipio_Municipiomicroid ;
         }
         if ( sdt.IsDirty("MunicipioMicroNome") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicronome = sdt.gxTv_Sdtmunicipio_Municipiomicronome ;
         }
         if ( sdt.IsDirty("MunicipioMicroMesoID") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoid = sdt.gxTv_Sdtmunicipio_Municipiomicromesoid ;
         }
         if ( sdt.IsDirty("MunicipioMicroMesoNome") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesonome = sdt.gxTv_Sdtmunicipio_Municipiomicromesonome ;
         }
         if ( sdt.IsDirty("MunicipioMicroMesoUFID") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufid = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufid ;
         }
         if ( sdt.IsDirty("MunicipioMicroMesoUFSigla") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufsigla = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufsigla ;
         }
         if ( sdt.IsDirty("MunicipioMicroMesoUFNome") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufnome = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufnome ;
         }
         if ( sdt.IsDirty("MunicipioMicroMesoUFSiglaNome") )
         {
            gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_N = (short)(sdt.gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_N);
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome ;
         }
         if ( sdt.IsDirty("MunicipioMicroMesoUFRegID") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufregid = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufregid ;
         }
         if ( sdt.IsDirty("MunicipioMicroMesoUFRegSigla") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufregsigla = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufregsigla ;
         }
         if ( sdt.IsDirty("MunicipioMicroMesoUFRegNome") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufregnome = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufregnome ;
         }
         if ( sdt.IsDirty("MunicipioMicroMesoUFRegSiglaNome") )
         {
            gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_N = (short)(sdt.gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_N);
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome = sdt.gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "MunicipioID" )]
      [  XmlElement( ElementName = "MunicipioID"   )]
      public int gxTpr_Municipioid
      {
         get {
            return gxTv_Sdtmunicipio_Municipioid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_Sdtmunicipio_Municipioid != value )
            {
               gxTv_Sdtmunicipio_Mode = "INS";
               this.gxTv_Sdtmunicipio_Municipioid_Z_SetNull( );
               this.gxTv_Sdtmunicipio_Municipionome_Z_SetNull( );
               this.gxTv_Sdtmunicipio_Municipiomicroid_Z_SetNull( );
               this.gxTv_Sdtmunicipio_Municipiomicronome_Z_SetNull( );
               this.gxTv_Sdtmunicipio_Municipiomicromesoid_Z_SetNull( );
               this.gxTv_Sdtmunicipio_Municipiomicromesonome_Z_SetNull( );
               this.gxTv_Sdtmunicipio_Municipiomicromesoufid_Z_SetNull( );
               this.gxTv_Sdtmunicipio_Municipiomicromesoufsigla_Z_SetNull( );
               this.gxTv_Sdtmunicipio_Municipiomicromesoufnome_Z_SetNull( );
               this.gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_Z_SetNull( );
               this.gxTv_Sdtmunicipio_Municipiomicromesoufregid_Z_SetNull( );
               this.gxTv_Sdtmunicipio_Municipiomicromesoufregsigla_Z_SetNull( );
               this.gxTv_Sdtmunicipio_Municipiomicromesoufregnome_Z_SetNull( );
               this.gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_Z_SetNull( );
            }
            gxTv_Sdtmunicipio_Municipioid = value;
            SetDirty("Municipioid");
         }

      }

      [  SoapElement( ElementName = "MunicipioNome" )]
      [  XmlElement( ElementName = "MunicipioNome"   )]
      public string gxTpr_Municipionome
      {
         get {
            return gxTv_Sdtmunicipio_Municipionome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipionome = value;
            SetDirty("Municipionome");
         }

      }

      [  SoapElement( ElementName = "MunicipioMicroID" )]
      [  XmlElement( ElementName = "MunicipioMicroID"   )]
      public int gxTpr_Municipiomicroid
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicroid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicroid = value;
            SetDirty("Municipiomicroid");
         }

      }

      [  SoapElement( ElementName = "MunicipioMicroNome" )]
      [  XmlElement( ElementName = "MunicipioMicroNome"   )]
      public string gxTpr_Municipiomicronome
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicronome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicronome = value;
            SetDirty("Municipiomicronome");
         }

      }

      [  SoapElement( ElementName = "MunicipioMicroMesoID" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoID"   )]
      public int gxTpr_Municipiomicromesoid
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoid = value;
            SetDirty("Municipiomicromesoid");
         }

      }

      [  SoapElement( ElementName = "MunicipioMicroMesoNome" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoNome"   )]
      public string gxTpr_Municipiomicromesonome
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesonome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesonome = value;
            SetDirty("Municipiomicromesonome");
         }

      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFID" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFID"   )]
      public int gxTpr_Municipiomicromesoufid
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufid = value;
            SetDirty("Municipiomicromesoufid");
         }

      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFSigla" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFSigla"   )]
      public string gxTpr_Municipiomicromesoufsigla
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufsigla ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufsigla = value;
            SetDirty("Municipiomicromesoufsigla");
         }

      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFNome" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFNome"   )]
      public string gxTpr_Municipiomicromesoufnome
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufnome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufnome = value;
            SetDirty("Municipiomicromesoufnome");
         }

      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFSiglaNome" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFSiglaNome"   )]
      public string gxTpr_Municipiomicromesoufsiglanome
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome ;
         }

         set {
            gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_N = 0;
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome = value;
            SetDirty("Municipiomicromesoufsiglanome");
         }

      }

      public void gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_N = 1;
         gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome = "";
         SetDirty("Municipiomicromesoufsiglanome");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_IsNull( )
      {
         return (gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_N==1) ;
      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFRegID" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFRegID"   )]
      public int gxTpr_Municipiomicromesoufregid
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufregid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufregid = value;
            SetDirty("Municipiomicromesoufregid");
         }

      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFRegSigla" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFRegSigla"   )]
      public string gxTpr_Municipiomicromesoufregsigla
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufregsigla ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufregsigla = value;
            SetDirty("Municipiomicromesoufregsigla");
         }

      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFRegNome" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFRegNome"   )]
      public string gxTpr_Municipiomicromesoufregnome
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufregnome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufregnome = value;
            SetDirty("Municipiomicromesoufregnome");
         }

      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFRegSiglaNome" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFRegSiglaNome"   )]
      public string gxTpr_Municipiomicromesoufregsiglanome
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome ;
         }

         set {
            gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_N = 0;
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome = value;
            SetDirty("Municipiomicromesoufregsiglanome");
         }

      }

      public void gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_N = 1;
         gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome = "";
         SetDirty("Municipiomicromesoufregsiglanome");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_IsNull( )
      {
         return (gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_Sdtmunicipio_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_Sdtmunicipio_Mode_SetNull( )
      {
         gxTv_Sdtmunicipio_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_Sdtmunicipio_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_Sdtmunicipio_Initialized_SetNull( )
      {
         gxTv_Sdtmunicipio_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioID_Z" )]
      [  XmlElement( ElementName = "MunicipioID_Z"   )]
      public int gxTpr_Municipioid_Z
      {
         get {
            return gxTv_Sdtmunicipio_Municipioid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipioid_Z = value;
            SetDirty("Municipioid_Z");
         }

      }

      public void gxTv_Sdtmunicipio_Municipioid_Z_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipioid_Z = 0;
         SetDirty("Municipioid_Z");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioNome_Z" )]
      [  XmlElement( ElementName = "MunicipioNome_Z"   )]
      public string gxTpr_Municipionome_Z
      {
         get {
            return gxTv_Sdtmunicipio_Municipionome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipionome_Z = value;
            SetDirty("Municipionome_Z");
         }

      }

      public void gxTv_Sdtmunicipio_Municipionome_Z_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipionome_Z = "";
         SetDirty("Municipionome_Z");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipionome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioMicroID_Z" )]
      [  XmlElement( ElementName = "MunicipioMicroID_Z"   )]
      public int gxTpr_Municipiomicroid_Z
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicroid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicroid_Z = value;
            SetDirty("Municipiomicroid_Z");
         }

      }

      public void gxTv_Sdtmunicipio_Municipiomicroid_Z_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipiomicroid_Z = 0;
         SetDirty("Municipiomicroid_Z");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipiomicroid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioMicroNome_Z" )]
      [  XmlElement( ElementName = "MunicipioMicroNome_Z"   )]
      public string gxTpr_Municipiomicronome_Z
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicronome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicronome_Z = value;
            SetDirty("Municipiomicronome_Z");
         }

      }

      public void gxTv_Sdtmunicipio_Municipiomicronome_Z_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipiomicronome_Z = "";
         SetDirty("Municipiomicronome_Z");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipiomicronome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioMicroMesoID_Z" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoID_Z"   )]
      public int gxTpr_Municipiomicromesoid_Z
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoid_Z = value;
            SetDirty("Municipiomicromesoid_Z");
         }

      }

      public void gxTv_Sdtmunicipio_Municipiomicromesoid_Z_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipiomicromesoid_Z = 0;
         SetDirty("Municipiomicromesoid_Z");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipiomicromesoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioMicroMesoNome_Z" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoNome_Z"   )]
      public string gxTpr_Municipiomicromesonome_Z
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesonome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesonome_Z = value;
            SetDirty("Municipiomicromesonome_Z");
         }

      }

      public void gxTv_Sdtmunicipio_Municipiomicromesonome_Z_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipiomicromesonome_Z = "";
         SetDirty("Municipiomicromesonome_Z");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipiomicromesonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFID_Z" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFID_Z"   )]
      public int gxTpr_Municipiomicromesoufid_Z
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufid_Z = value;
            SetDirty("Municipiomicromesoufid_Z");
         }

      }

      public void gxTv_Sdtmunicipio_Municipiomicromesoufid_Z_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipiomicromesoufid_Z = 0;
         SetDirty("Municipiomicromesoufid_Z");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipiomicromesoufid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFSigla_Z" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFSigla_Z"   )]
      public string gxTpr_Municipiomicromesoufsigla_Z
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufsigla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufsigla_Z = value;
            SetDirty("Municipiomicromesoufsigla_Z");
         }

      }

      public void gxTv_Sdtmunicipio_Municipiomicromesoufsigla_Z_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipiomicromesoufsigla_Z = "";
         SetDirty("Municipiomicromesoufsigla_Z");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipiomicromesoufsigla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFNome_Z" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFNome_Z"   )]
      public string gxTpr_Municipiomicromesoufnome_Z
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufnome_Z = value;
            SetDirty("Municipiomicromesoufnome_Z");
         }

      }

      public void gxTv_Sdtmunicipio_Municipiomicromesoufnome_Z_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipiomicromesoufnome_Z = "";
         SetDirty("Municipiomicromesoufnome_Z");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipiomicromesoufnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFSiglaNome_Z" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFSiglaNome_Z"   )]
      public string gxTpr_Municipiomicromesoufsiglanome_Z
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_Z = value;
            SetDirty("Municipiomicromesoufsiglanome_Z");
         }

      }

      public void gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_Z_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_Z = "";
         SetDirty("Municipiomicromesoufsiglanome_Z");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFRegID_Z" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFRegID_Z"   )]
      public int gxTpr_Municipiomicromesoufregid_Z
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufregid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufregid_Z = value;
            SetDirty("Municipiomicromesoufregid_Z");
         }

      }

      public void gxTv_Sdtmunicipio_Municipiomicromesoufregid_Z_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipiomicromesoufregid_Z = 0;
         SetDirty("Municipiomicromesoufregid_Z");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipiomicromesoufregid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFRegSigla_Z" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFRegSigla_Z"   )]
      public string gxTpr_Municipiomicromesoufregsigla_Z
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufregsigla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufregsigla_Z = value;
            SetDirty("Municipiomicromesoufregsigla_Z");
         }

      }

      public void gxTv_Sdtmunicipio_Municipiomicromesoufregsigla_Z_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipiomicromesoufregsigla_Z = "";
         SetDirty("Municipiomicromesoufregsigla_Z");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipiomicromesoufregsigla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFRegNome_Z" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFRegNome_Z"   )]
      public string gxTpr_Municipiomicromesoufregnome_Z
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufregnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufregnome_Z = value;
            SetDirty("Municipiomicromesoufregnome_Z");
         }

      }

      public void gxTv_Sdtmunicipio_Municipiomicromesoufregnome_Z_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipiomicromesoufregnome_Z = "";
         SetDirty("Municipiomicromesoufregnome_Z");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipiomicromesoufregnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFRegSiglaNome_Z" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFRegSiglaNome_Z"   )]
      public string gxTpr_Municipiomicromesoufregsiglanome_Z
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_Z = value;
            SetDirty("Municipiomicromesoufregsiglanome_Z");
         }

      }

      public void gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_Z_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_Z = "";
         SetDirty("Municipiomicromesoufregsiglanome_Z");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioMicroMesoNome_N" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoNome_N"   )]
      public short gxTpr_Municipiomicromesonome_N
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesonome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesonome_N = value;
            SetDirty("Municipiomicromesonome_N");
         }

      }

      public void gxTv_Sdtmunicipio_Municipiomicromesonome_N_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipiomicromesonome_N = 0;
         SetDirty("Municipiomicromesonome_N");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipiomicromesonome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFID_N" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFID_N"   )]
      public short gxTpr_Municipiomicromesoufid_N
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufid_N = value;
            SetDirty("Municipiomicromesoufid_N");
         }

      }

      public void gxTv_Sdtmunicipio_Municipiomicromesoufid_N_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipiomicromesoufid_N = 0;
         SetDirty("Municipiomicromesoufid_N");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipiomicromesoufid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFSigla_N" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFSigla_N"   )]
      public short gxTpr_Municipiomicromesoufsigla_N
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufsigla_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufsigla_N = value;
            SetDirty("Municipiomicromesoufsigla_N");
         }

      }

      public void gxTv_Sdtmunicipio_Municipiomicromesoufsigla_N_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipiomicromesoufsigla_N = 0;
         SetDirty("Municipiomicromesoufsigla_N");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipiomicromesoufsigla_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFNome_N" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFNome_N"   )]
      public short gxTpr_Municipiomicromesoufnome_N
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufnome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufnome_N = value;
            SetDirty("Municipiomicromesoufnome_N");
         }

      }

      public void gxTv_Sdtmunicipio_Municipiomicromesoufnome_N_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipiomicromesoufnome_N = 0;
         SetDirty("Municipiomicromesoufnome_N");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipiomicromesoufnome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFSiglaNome_N" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFSiglaNome_N"   )]
      public short gxTpr_Municipiomicromesoufsiglanome_N
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_N = value;
            SetDirty("Municipiomicromesoufsiglanome_N");
         }

      }

      public void gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_N_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_N = 0;
         SetDirty("Municipiomicromesoufsiglanome_N");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFRegID_N" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFRegID_N"   )]
      public short gxTpr_Municipiomicromesoufregid_N
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufregid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufregid_N = value;
            SetDirty("Municipiomicromesoufregid_N");
         }

      }

      public void gxTv_Sdtmunicipio_Municipiomicromesoufregid_N_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipiomicromesoufregid_N = 0;
         SetDirty("Municipiomicromesoufregid_N");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipiomicromesoufregid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFRegSigla_N" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFRegSigla_N"   )]
      public short gxTpr_Municipiomicromesoufregsigla_N
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufregsigla_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufregsigla_N = value;
            SetDirty("Municipiomicromesoufregsigla_N");
         }

      }

      public void gxTv_Sdtmunicipio_Municipiomicromesoufregsigla_N_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipiomicromesoufregsigla_N = 0;
         SetDirty("Municipiomicromesoufregsigla_N");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipiomicromesoufregsigla_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFRegNome_N" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFRegNome_N"   )]
      public short gxTpr_Municipiomicromesoufregnome_N
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufregnome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufregnome_N = value;
            SetDirty("Municipiomicromesoufregnome_N");
         }

      }

      public void gxTv_Sdtmunicipio_Municipiomicromesoufregnome_N_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipiomicromesoufregnome_N = 0;
         SetDirty("Municipiomicromesoufregnome_N");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipiomicromesoufregnome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioMicroMesoUFRegSiglaNome_N" )]
      [  XmlElement( ElementName = "MunicipioMicroMesoUFRegSiglaNome_N"   )]
      public short gxTpr_Municipiomicromesoufregsiglanome_N
      {
         get {
            return gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_N = value;
            SetDirty("Municipiomicromesoufregsiglanome_N");
         }

      }

      public void gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_N_SetNull( )
      {
         gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_N = 0;
         SetDirty("Municipiomicromesoufregsiglanome_N");
         return  ;
      }

      public bool gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_Sdtmunicipio_Municipionome = "";
         gxTv_Sdtmunicipio_Municipiomicronome = "";
         gxTv_Sdtmunicipio_Municipiomicromesonome = "";
         gxTv_Sdtmunicipio_Municipiomicromesoufsigla = "";
         gxTv_Sdtmunicipio_Municipiomicromesoufnome = "";
         gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome = "";
         gxTv_Sdtmunicipio_Municipiomicromesoufregsigla = "";
         gxTv_Sdtmunicipio_Municipiomicromesoufregnome = "";
         gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome = "";
         gxTv_Sdtmunicipio_Mode = "";
         gxTv_Sdtmunicipio_Municipionome_Z = "";
         gxTv_Sdtmunicipio_Municipiomicronome_Z = "";
         gxTv_Sdtmunicipio_Municipiomicromesonome_Z = "";
         gxTv_Sdtmunicipio_Municipiomicromesoufsigla_Z = "";
         gxTv_Sdtmunicipio_Municipiomicromesoufnome_Z = "";
         gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_Z = "";
         gxTv_Sdtmunicipio_Municipiomicromesoufregsigla_Z = "";
         gxTv_Sdtmunicipio_Municipiomicromesoufregnome_Z = "";
         gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "core.municipio", "GeneXus.Programs.core.municipio_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_Sdtmunicipio_Initialized ;
      private short gxTv_Sdtmunicipio_Municipiomicromesonome_N ;
      private short gxTv_Sdtmunicipio_Municipiomicromesoufid_N ;
      private short gxTv_Sdtmunicipio_Municipiomicromesoufsigla_N ;
      private short gxTv_Sdtmunicipio_Municipiomicromesoufnome_N ;
      private short gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_N ;
      private short gxTv_Sdtmunicipio_Municipiomicromesoufregid_N ;
      private short gxTv_Sdtmunicipio_Municipiomicromesoufregsigla_N ;
      private short gxTv_Sdtmunicipio_Municipiomicromesoufregnome_N ;
      private short gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_N ;
      private int gxTv_Sdtmunicipio_Municipioid ;
      private int gxTv_Sdtmunicipio_Municipiomicroid ;
      private int gxTv_Sdtmunicipio_Municipiomicromesoid ;
      private int gxTv_Sdtmunicipio_Municipiomicromesoufid ;
      private int gxTv_Sdtmunicipio_Municipiomicromesoufregid ;
      private int gxTv_Sdtmunicipio_Municipioid_Z ;
      private int gxTv_Sdtmunicipio_Municipiomicroid_Z ;
      private int gxTv_Sdtmunicipio_Municipiomicromesoid_Z ;
      private int gxTv_Sdtmunicipio_Municipiomicromesoufid_Z ;
      private int gxTv_Sdtmunicipio_Municipiomicromesoufregid_Z ;
      private string gxTv_Sdtmunicipio_Mode ;
      private string gxTv_Sdtmunicipio_Municipionome ;
      private string gxTv_Sdtmunicipio_Municipiomicronome ;
      private string gxTv_Sdtmunicipio_Municipiomicromesonome ;
      private string gxTv_Sdtmunicipio_Municipiomicromesoufsigla ;
      private string gxTv_Sdtmunicipio_Municipiomicromesoufnome ;
      private string gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome ;
      private string gxTv_Sdtmunicipio_Municipiomicromesoufregsigla ;
      private string gxTv_Sdtmunicipio_Municipiomicromesoufregnome ;
      private string gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome ;
      private string gxTv_Sdtmunicipio_Municipionome_Z ;
      private string gxTv_Sdtmunicipio_Municipiomicronome_Z ;
      private string gxTv_Sdtmunicipio_Municipiomicromesonome_Z ;
      private string gxTv_Sdtmunicipio_Municipiomicromesoufsigla_Z ;
      private string gxTv_Sdtmunicipio_Municipiomicromesoufnome_Z ;
      private string gxTv_Sdtmunicipio_Municipiomicromesoufsiglanome_Z ;
      private string gxTv_Sdtmunicipio_Municipiomicromesoufregsigla_Z ;
      private string gxTv_Sdtmunicipio_Municipiomicromesoufregnome_Z ;
      private string gxTv_Sdtmunicipio_Municipiomicromesoufregsiglanome_Z ;
   }

   [DataContract(Name = @"core\municipio", Namespace = "agl_tresorygroup")]
   public class Sdtmunicipio_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.Sdtmunicipio>
   {
      public Sdtmunicipio_RESTInterface( ) : base()
      {
      }

      public Sdtmunicipio_RESTInterface( GeneXus.Programs.core.Sdtmunicipio psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MunicipioID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Municipioid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Municipioid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Municipioid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "MunicipioNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Municipionome
      {
         get {
            return sdt.gxTpr_Municipionome ;
         }

         set {
            sdt.gxTpr_Municipionome = value;
         }

      }

      [DataMember( Name = "MunicipioMicroID" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Municipiomicroid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Municipiomicroid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Municipiomicroid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "MunicipioMicroNome" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Municipiomicronome
      {
         get {
            return sdt.gxTpr_Municipiomicronome ;
         }

         set {
            sdt.gxTpr_Municipiomicronome = value;
         }

      }

      [DataMember( Name = "MunicipioMicroMesoID" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Municipiomicromesoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Municipiomicromesoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Municipiomicromesoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "MunicipioMicroMesoNome" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Municipiomicromesonome
      {
         get {
            return sdt.gxTpr_Municipiomicromesonome ;
         }

         set {
            sdt.gxTpr_Municipiomicromesonome = value;
         }

      }

      [DataMember( Name = "MunicipioMicroMesoUFID" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Municipiomicromesoufid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Municipiomicromesoufid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Municipiomicromesoufid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "MunicipioMicroMesoUFSigla" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Municipiomicromesoufsigla
      {
         get {
            return sdt.gxTpr_Municipiomicromesoufsigla ;
         }

         set {
            sdt.gxTpr_Municipiomicromesoufsigla = value;
         }

      }

      [DataMember( Name = "MunicipioMicroMesoUFNome" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Municipiomicromesoufnome
      {
         get {
            return sdt.gxTpr_Municipiomicromesoufnome ;
         }

         set {
            sdt.gxTpr_Municipiomicromesoufnome = value;
         }

      }

      [DataMember( Name = "MunicipioMicroMesoUFSiglaNome" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Municipiomicromesoufsiglanome
      {
         get {
            return sdt.gxTpr_Municipiomicromesoufsiglanome ;
         }

         set {
            sdt.gxTpr_Municipiomicromesoufsiglanome = value;
         }

      }

      [DataMember( Name = "MunicipioMicroMesoUFRegID" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Municipiomicromesoufregid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Municipiomicromesoufregid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Municipiomicromesoufregid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "MunicipioMicroMesoUFRegSigla" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Municipiomicromesoufregsigla
      {
         get {
            return sdt.gxTpr_Municipiomicromesoufregsigla ;
         }

         set {
            sdt.gxTpr_Municipiomicromesoufregsigla = value;
         }

      }

      [DataMember( Name = "MunicipioMicroMesoUFRegNome" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Municipiomicromesoufregnome
      {
         get {
            return sdt.gxTpr_Municipiomicromesoufregnome ;
         }

         set {
            sdt.gxTpr_Municipiomicromesoufregnome = value;
         }

      }

      [DataMember( Name = "MunicipioMicroMesoUFRegSiglaNome" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Municipiomicromesoufregsiglanome
      {
         get {
            return sdt.gxTpr_Municipiomicromesoufregsiglanome ;
         }

         set {
            sdt.gxTpr_Municipiomicromesoufregsiglanome = value;
         }

      }

      public GeneXus.Programs.core.Sdtmunicipio sdt
      {
         get {
            return (GeneXus.Programs.core.Sdtmunicipio)Sdt ;
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
            sdt = new GeneXus.Programs.core.Sdtmunicipio() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 14 )]
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
   }

   [DataContract(Name = @"core\municipio", Namespace = "agl_tresorygroup")]
   public class Sdtmunicipio_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.Sdtmunicipio>
   {
      public Sdtmunicipio_RESTLInterface( ) : base()
      {
      }

      public Sdtmunicipio_RESTLInterface( GeneXus.Programs.core.Sdtmunicipio psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MunicipioNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Municipionome
      {
         get {
            return sdt.gxTpr_Municipionome ;
         }

         set {
            sdt.gxTpr_Municipionome = value;
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

      public GeneXus.Programs.core.Sdtmunicipio sdt
      {
         get {
            return (GeneXus.Programs.core.Sdtmunicipio)Sdt ;
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
            sdt = new GeneXus.Programs.core.Sdtmunicipio() ;
         }
      }

   }

}
