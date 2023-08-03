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
   [XmlRoot(ElementName = "microrregiao" )]
   [XmlType(TypeName =  "microrregiao" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class Sdtmicrorregiao : GxSilentTrnSdt
   {
      public Sdtmicrorregiao( )
      {
      }

      public Sdtmicrorregiao( IGxContext context )
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

      public void Load( int AV23MicrorregiaoID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV23MicrorregiaoID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"MicrorregiaoID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "core\\microrregiao");
         metadata.Set("BT", "tbibge_microrregiao");
         metadata.Set("PK", "[ \"MicrorregiaoID\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"MesorregiaoID\" ],\"FKMap\":[ \"MicrorregiaoMesoID-MesorregiaoID\" ] } ]");
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
         state.Add("gxTpr_Microrregiaoid_Z");
         state.Add("gxTpr_Microrregiaonome_Z");
         state.Add("gxTpr_Microrregiaomesoid_Z");
         state.Add("gxTpr_Microrregiaomesonome_Z");
         state.Add("gxTpr_Microrregiaomesoufid_Z");
         state.Add("gxTpr_Microrregiaomesoufsigla_Z");
         state.Add("gxTpr_Microrregiaomesoufnome_Z");
         state.Add("gxTpr_Microrregiaomesoufsiglanome_Z");
         state.Add("gxTpr_Microrregiaomesoufregid_Z");
         state.Add("gxTpr_Microrregiaomesoufregsigla_Z");
         state.Add("gxTpr_Microrregiaomesoufregnome_Z");
         state.Add("gxTpr_Microrregiaomesoufregsiglanome_Z");
         state.Add("gxTpr_Microrregiaomesoufsigla_N");
         state.Add("gxTpr_Microrregiaomesoufnome_N");
         state.Add("gxTpr_Microrregiaomesoufsiglanome_N");
         state.Add("gxTpr_Microrregiaomesoufregid_N");
         state.Add("gxTpr_Microrregiaomesoufregsigla_N");
         state.Add("gxTpr_Microrregiaomesoufregnome_N");
         state.Add("gxTpr_Microrregiaomesoufregsiglanome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.Sdtmicrorregiao sdt;
         sdt = (GeneXus.Programs.core.Sdtmicrorregiao)(source);
         gxTv_Sdtmicrorregiao_Microrregiaoid = sdt.gxTv_Sdtmicrorregiao_Microrregiaoid ;
         gxTv_Sdtmicrorregiao_Microrregiaonome = sdt.gxTv_Sdtmicrorregiao_Microrregiaonome ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoid = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoid ;
         gxTv_Sdtmicrorregiao_Microrregiaomesonome = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesonome ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufid = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufid ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufnome = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufnome ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregid = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufregid ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome ;
         gxTv_Sdtmicrorregiao_Mode = sdt.gxTv_Sdtmicrorregiao_Mode ;
         gxTv_Sdtmicrorregiao_Initialized = sdt.gxTv_Sdtmicrorregiao_Initialized ;
         gxTv_Sdtmicrorregiao_Microrregiaoid_Z = sdt.gxTv_Sdtmicrorregiao_Microrregiaoid_Z ;
         gxTv_Sdtmicrorregiao_Microrregiaonome_Z = sdt.gxTv_Sdtmicrorregiao_Microrregiaonome_Z ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoid_Z = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoid_Z ;
         gxTv_Sdtmicrorregiao_Microrregiaomesonome_Z = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesonome_Z ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufid_Z = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufid_Z ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla_Z = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla_Z ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufnome_Z = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufnome_Z ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_Z = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_Z ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregid_Z = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufregid_Z ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla_Z = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla_Z ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome_Z = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome_Z ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_Z = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_Z ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla_N = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla_N ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufnome_N = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufnome_N ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_N = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_N ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregid_N = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufregid_N ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla_N = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla_N ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome_N = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome_N ;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_N = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_N ;
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
         AddObjectProperty("MicrorregiaoID", gxTv_Sdtmicrorregiao_Microrregiaoid, false, includeNonInitialized);
         AddObjectProperty("MicrorregiaoNome", gxTv_Sdtmicrorregiao_Microrregiaonome, false, includeNonInitialized);
         AddObjectProperty("MicrorregiaoMesoID", gxTv_Sdtmicrorregiao_Microrregiaomesoid, false, includeNonInitialized);
         AddObjectProperty("MicrorregiaoMesoNome", gxTv_Sdtmicrorregiao_Microrregiaomesonome, false, includeNonInitialized);
         AddObjectProperty("MicrorregiaoMesoUFID", gxTv_Sdtmicrorregiao_Microrregiaomesoufid, false, includeNonInitialized);
         AddObjectProperty("MicrorregiaoMesoUFSigla", gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla, false, includeNonInitialized);
         AddObjectProperty("MicrorregiaoMesoUFSigla_N", gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla_N, false, includeNonInitialized);
         AddObjectProperty("MicrorregiaoMesoUFNome", gxTv_Sdtmicrorregiao_Microrregiaomesoufnome, false, includeNonInitialized);
         AddObjectProperty("MicrorregiaoMesoUFNome_N", gxTv_Sdtmicrorregiao_Microrregiaomesoufnome_N, false, includeNonInitialized);
         AddObjectProperty("MicrorregiaoMesoUFSiglaNome", gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome, false, includeNonInitialized);
         AddObjectProperty("MicrorregiaoMesoUFSiglaNome_N", gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_N, false, includeNonInitialized);
         AddObjectProperty("MicrorregiaoMesoUFRegID", gxTv_Sdtmicrorregiao_Microrregiaomesoufregid, false, includeNonInitialized);
         AddObjectProperty("MicrorregiaoMesoUFRegID_N", gxTv_Sdtmicrorregiao_Microrregiaomesoufregid_N, false, includeNonInitialized);
         AddObjectProperty("MicrorregiaoMesoUFRegSigla", gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla, false, includeNonInitialized);
         AddObjectProperty("MicrorregiaoMesoUFRegSigla_N", gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla_N, false, includeNonInitialized);
         AddObjectProperty("MicrorregiaoMesoUFRegNome", gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome, false, includeNonInitialized);
         AddObjectProperty("MicrorregiaoMesoUFRegNome_N", gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome_N, false, includeNonInitialized);
         AddObjectProperty("MicrorregiaoMesoUFRegSiglaNome", gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome, false, includeNonInitialized);
         AddObjectProperty("MicrorregiaoMesoUFRegSiglaNome_N", gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_Sdtmicrorregiao_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_Sdtmicrorregiao_Initialized, false, includeNonInitialized);
            AddObjectProperty("MicrorregiaoID_Z", gxTv_Sdtmicrorregiao_Microrregiaoid_Z, false, includeNonInitialized);
            AddObjectProperty("MicrorregiaoNome_Z", gxTv_Sdtmicrorregiao_Microrregiaonome_Z, false, includeNonInitialized);
            AddObjectProperty("MicrorregiaoMesoID_Z", gxTv_Sdtmicrorregiao_Microrregiaomesoid_Z, false, includeNonInitialized);
            AddObjectProperty("MicrorregiaoMesoNome_Z", gxTv_Sdtmicrorregiao_Microrregiaomesonome_Z, false, includeNonInitialized);
            AddObjectProperty("MicrorregiaoMesoUFID_Z", gxTv_Sdtmicrorregiao_Microrregiaomesoufid_Z, false, includeNonInitialized);
            AddObjectProperty("MicrorregiaoMesoUFSigla_Z", gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla_Z, false, includeNonInitialized);
            AddObjectProperty("MicrorregiaoMesoUFNome_Z", gxTv_Sdtmicrorregiao_Microrregiaomesoufnome_Z, false, includeNonInitialized);
            AddObjectProperty("MicrorregiaoMesoUFSiglaNome_Z", gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_Z, false, includeNonInitialized);
            AddObjectProperty("MicrorregiaoMesoUFRegID_Z", gxTv_Sdtmicrorregiao_Microrregiaomesoufregid_Z, false, includeNonInitialized);
            AddObjectProperty("MicrorregiaoMesoUFRegSigla_Z", gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla_Z, false, includeNonInitialized);
            AddObjectProperty("MicrorregiaoMesoUFRegNome_Z", gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome_Z, false, includeNonInitialized);
            AddObjectProperty("MicrorregiaoMesoUFRegSiglaNome_Z", gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_Z, false, includeNonInitialized);
            AddObjectProperty("MicrorregiaoMesoUFSigla_N", gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla_N, false, includeNonInitialized);
            AddObjectProperty("MicrorregiaoMesoUFNome_N", gxTv_Sdtmicrorregiao_Microrregiaomesoufnome_N, false, includeNonInitialized);
            AddObjectProperty("MicrorregiaoMesoUFSiglaNome_N", gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_N, false, includeNonInitialized);
            AddObjectProperty("MicrorregiaoMesoUFRegID_N", gxTv_Sdtmicrorregiao_Microrregiaomesoufregid_N, false, includeNonInitialized);
            AddObjectProperty("MicrorregiaoMesoUFRegSigla_N", gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla_N, false, includeNonInitialized);
            AddObjectProperty("MicrorregiaoMesoUFRegNome_N", gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome_N, false, includeNonInitialized);
            AddObjectProperty("MicrorregiaoMesoUFRegSiglaNome_N", gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.Sdtmicrorregiao sdt )
      {
         if ( sdt.IsDirty("MicrorregiaoID") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaoid = sdt.gxTv_Sdtmicrorregiao_Microrregiaoid ;
         }
         if ( sdt.IsDirty("MicrorregiaoNome") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaonome = sdt.gxTv_Sdtmicrorregiao_Microrregiaonome ;
         }
         if ( sdt.IsDirty("MicrorregiaoMesoID") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoid = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoid ;
         }
         if ( sdt.IsDirty("MicrorregiaoMesoNome") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesonome = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesonome ;
         }
         if ( sdt.IsDirty("MicrorregiaoMesoUFID") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufid = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufid ;
         }
         if ( sdt.IsDirty("MicrorregiaoMesoUFSigla") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla ;
         }
         if ( sdt.IsDirty("MicrorregiaoMesoUFNome") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufnome = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufnome ;
         }
         if ( sdt.IsDirty("MicrorregiaoMesoUFSiglaNome") )
         {
            gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_N = (short)(sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_N);
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome ;
         }
         if ( sdt.IsDirty("MicrorregiaoMesoUFRegID") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufregid = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufregid ;
         }
         if ( sdt.IsDirty("MicrorregiaoMesoUFRegSigla") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla ;
         }
         if ( sdt.IsDirty("MicrorregiaoMesoUFRegNome") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome ;
         }
         if ( sdt.IsDirty("MicrorregiaoMesoUFRegSiglaNome") )
         {
            gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_N = (short)(sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_N);
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome = sdt.gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "MicrorregiaoID" )]
      [  XmlElement( ElementName = "MicrorregiaoID"   )]
      public int gxTpr_Microrregiaoid
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_Sdtmicrorregiao_Microrregiaoid != value )
            {
               gxTv_Sdtmicrorregiao_Mode = "INS";
               this.gxTv_Sdtmicrorregiao_Microrregiaoid_Z_SetNull( );
               this.gxTv_Sdtmicrorregiao_Microrregiaonome_Z_SetNull( );
               this.gxTv_Sdtmicrorregiao_Microrregiaomesoid_Z_SetNull( );
               this.gxTv_Sdtmicrorregiao_Microrregiaomesonome_Z_SetNull( );
               this.gxTv_Sdtmicrorregiao_Microrregiaomesoufid_Z_SetNull( );
               this.gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla_Z_SetNull( );
               this.gxTv_Sdtmicrorregiao_Microrregiaomesoufnome_Z_SetNull( );
               this.gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_Z_SetNull( );
               this.gxTv_Sdtmicrorregiao_Microrregiaomesoufregid_Z_SetNull( );
               this.gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla_Z_SetNull( );
               this.gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome_Z_SetNull( );
               this.gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_Z_SetNull( );
            }
            gxTv_Sdtmicrorregiao_Microrregiaoid = value;
            SetDirty("Microrregiaoid");
         }

      }

      [  SoapElement( ElementName = "MicrorregiaoNome" )]
      [  XmlElement( ElementName = "MicrorregiaoNome"   )]
      public string gxTpr_Microrregiaonome
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaonome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaonome = value;
            SetDirty("Microrregiaonome");
         }

      }

      [  SoapElement( ElementName = "MicrorregiaoMesoID" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoID"   )]
      public int gxTpr_Microrregiaomesoid
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoid = value;
            SetDirty("Microrregiaomesoid");
         }

      }

      [  SoapElement( ElementName = "MicrorregiaoMesoNome" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoNome"   )]
      public string gxTpr_Microrregiaomesonome
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesonome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesonome = value;
            SetDirty("Microrregiaomesonome");
         }

      }

      [  SoapElement( ElementName = "MicrorregiaoMesoUFID" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoUFID"   )]
      public int gxTpr_Microrregiaomesoufid
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoufid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufid = value;
            SetDirty("Microrregiaomesoufid");
         }

      }

      [  SoapElement( ElementName = "MicrorregiaoMesoUFSigla" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoUFSigla"   )]
      public string gxTpr_Microrregiaomesoufsigla
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla = value;
            SetDirty("Microrregiaomesoufsigla");
         }

      }

      [  SoapElement( ElementName = "MicrorregiaoMesoUFNome" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoUFNome"   )]
      public string gxTpr_Microrregiaomesoufnome
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoufnome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufnome = value;
            SetDirty("Microrregiaomesoufnome");
         }

      }

      [  SoapElement( ElementName = "MicrorregiaoMesoUFSiglaNome" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoUFSiglaNome"   )]
      public string gxTpr_Microrregiaomesoufsiglanome
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome ;
         }

         set {
            gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_N = 0;
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome = value;
            SetDirty("Microrregiaomesoufsiglanome");
         }

      }

      public void gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_SetNull( )
      {
         gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_N = 1;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome = "";
         SetDirty("Microrregiaomesoufsiglanome");
         return  ;
      }

      public bool gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_IsNull( )
      {
         return (gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_N==1) ;
      }

      [  SoapElement( ElementName = "MicrorregiaoMesoUFRegID" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoUFRegID"   )]
      public int gxTpr_Microrregiaomesoufregid
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoufregid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufregid = value;
            SetDirty("Microrregiaomesoufregid");
         }

      }

      [  SoapElement( ElementName = "MicrorregiaoMesoUFRegSigla" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoUFRegSigla"   )]
      public string gxTpr_Microrregiaomesoufregsigla
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla = value;
            SetDirty("Microrregiaomesoufregsigla");
         }

      }

      [  SoapElement( ElementName = "MicrorregiaoMesoUFRegNome" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoUFRegNome"   )]
      public string gxTpr_Microrregiaomesoufregnome
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome = value;
            SetDirty("Microrregiaomesoufregnome");
         }

      }

      [  SoapElement( ElementName = "MicrorregiaoMesoUFRegSiglaNome" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoUFRegSiglaNome"   )]
      public string gxTpr_Microrregiaomesoufregsiglanome
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome ;
         }

         set {
            gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_N = 0;
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome = value;
            SetDirty("Microrregiaomesoufregsiglanome");
         }

      }

      public void gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_SetNull( )
      {
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_N = 1;
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome = "";
         SetDirty("Microrregiaomesoufregsiglanome");
         return  ;
      }

      public bool gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_IsNull( )
      {
         return (gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_Sdtmicrorregiao_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_Sdtmicrorregiao_Mode_SetNull( )
      {
         gxTv_Sdtmicrorregiao_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_Sdtmicrorregiao_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_Sdtmicrorregiao_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_Sdtmicrorregiao_Initialized_SetNull( )
      {
         gxTv_Sdtmicrorregiao_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_Sdtmicrorregiao_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MicrorregiaoID_Z" )]
      [  XmlElement( ElementName = "MicrorregiaoID_Z"   )]
      public int gxTpr_Microrregiaoid_Z
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaoid_Z = value;
            SetDirty("Microrregiaoid_Z");
         }

      }

      public void gxTv_Sdtmicrorregiao_Microrregiaoid_Z_SetNull( )
      {
         gxTv_Sdtmicrorregiao_Microrregiaoid_Z = 0;
         SetDirty("Microrregiaoid_Z");
         return  ;
      }

      public bool gxTv_Sdtmicrorregiao_Microrregiaoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MicrorregiaoNome_Z" )]
      [  XmlElement( ElementName = "MicrorregiaoNome_Z"   )]
      public string gxTpr_Microrregiaonome_Z
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaonome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaonome_Z = value;
            SetDirty("Microrregiaonome_Z");
         }

      }

      public void gxTv_Sdtmicrorregiao_Microrregiaonome_Z_SetNull( )
      {
         gxTv_Sdtmicrorregiao_Microrregiaonome_Z = "";
         SetDirty("Microrregiaonome_Z");
         return  ;
      }

      public bool gxTv_Sdtmicrorregiao_Microrregiaonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MicrorregiaoMesoID_Z" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoID_Z"   )]
      public int gxTpr_Microrregiaomesoid_Z
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoid_Z = value;
            SetDirty("Microrregiaomesoid_Z");
         }

      }

      public void gxTv_Sdtmicrorregiao_Microrregiaomesoid_Z_SetNull( )
      {
         gxTv_Sdtmicrorregiao_Microrregiaomesoid_Z = 0;
         SetDirty("Microrregiaomesoid_Z");
         return  ;
      }

      public bool gxTv_Sdtmicrorregiao_Microrregiaomesoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MicrorregiaoMesoNome_Z" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoNome_Z"   )]
      public string gxTpr_Microrregiaomesonome_Z
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesonome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesonome_Z = value;
            SetDirty("Microrregiaomesonome_Z");
         }

      }

      public void gxTv_Sdtmicrorregiao_Microrregiaomesonome_Z_SetNull( )
      {
         gxTv_Sdtmicrorregiao_Microrregiaomesonome_Z = "";
         SetDirty("Microrregiaomesonome_Z");
         return  ;
      }

      public bool gxTv_Sdtmicrorregiao_Microrregiaomesonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MicrorregiaoMesoUFID_Z" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoUFID_Z"   )]
      public int gxTpr_Microrregiaomesoufid_Z
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoufid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufid_Z = value;
            SetDirty("Microrregiaomesoufid_Z");
         }

      }

      public void gxTv_Sdtmicrorregiao_Microrregiaomesoufid_Z_SetNull( )
      {
         gxTv_Sdtmicrorregiao_Microrregiaomesoufid_Z = 0;
         SetDirty("Microrregiaomesoufid_Z");
         return  ;
      }

      public bool gxTv_Sdtmicrorregiao_Microrregiaomesoufid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MicrorregiaoMesoUFSigla_Z" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoUFSigla_Z"   )]
      public string gxTpr_Microrregiaomesoufsigla_Z
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla_Z = value;
            SetDirty("Microrregiaomesoufsigla_Z");
         }

      }

      public void gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla_Z_SetNull( )
      {
         gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla_Z = "";
         SetDirty("Microrregiaomesoufsigla_Z");
         return  ;
      }

      public bool gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MicrorregiaoMesoUFNome_Z" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoUFNome_Z"   )]
      public string gxTpr_Microrregiaomesoufnome_Z
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoufnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufnome_Z = value;
            SetDirty("Microrregiaomesoufnome_Z");
         }

      }

      public void gxTv_Sdtmicrorregiao_Microrregiaomesoufnome_Z_SetNull( )
      {
         gxTv_Sdtmicrorregiao_Microrregiaomesoufnome_Z = "";
         SetDirty("Microrregiaomesoufnome_Z");
         return  ;
      }

      public bool gxTv_Sdtmicrorregiao_Microrregiaomesoufnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MicrorregiaoMesoUFSiglaNome_Z" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoUFSiglaNome_Z"   )]
      public string gxTpr_Microrregiaomesoufsiglanome_Z
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_Z = value;
            SetDirty("Microrregiaomesoufsiglanome_Z");
         }

      }

      public void gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_Z_SetNull( )
      {
         gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_Z = "";
         SetDirty("Microrregiaomesoufsiglanome_Z");
         return  ;
      }

      public bool gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MicrorregiaoMesoUFRegID_Z" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoUFRegID_Z"   )]
      public int gxTpr_Microrregiaomesoufregid_Z
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoufregid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufregid_Z = value;
            SetDirty("Microrregiaomesoufregid_Z");
         }

      }

      public void gxTv_Sdtmicrorregiao_Microrregiaomesoufregid_Z_SetNull( )
      {
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregid_Z = 0;
         SetDirty("Microrregiaomesoufregid_Z");
         return  ;
      }

      public bool gxTv_Sdtmicrorregiao_Microrregiaomesoufregid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MicrorregiaoMesoUFRegSigla_Z" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoUFRegSigla_Z"   )]
      public string gxTpr_Microrregiaomesoufregsigla_Z
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla_Z = value;
            SetDirty("Microrregiaomesoufregsigla_Z");
         }

      }

      public void gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla_Z_SetNull( )
      {
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla_Z = "";
         SetDirty("Microrregiaomesoufregsigla_Z");
         return  ;
      }

      public bool gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MicrorregiaoMesoUFRegNome_Z" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoUFRegNome_Z"   )]
      public string gxTpr_Microrregiaomesoufregnome_Z
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome_Z = value;
            SetDirty("Microrregiaomesoufregnome_Z");
         }

      }

      public void gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome_Z_SetNull( )
      {
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome_Z = "";
         SetDirty("Microrregiaomesoufregnome_Z");
         return  ;
      }

      public bool gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MicrorregiaoMesoUFRegSiglaNome_Z" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoUFRegSiglaNome_Z"   )]
      public string gxTpr_Microrregiaomesoufregsiglanome_Z
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_Z = value;
            SetDirty("Microrregiaomesoufregsiglanome_Z");
         }

      }

      public void gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_Z_SetNull( )
      {
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_Z = "";
         SetDirty("Microrregiaomesoufregsiglanome_Z");
         return  ;
      }

      public bool gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MicrorregiaoMesoUFSigla_N" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoUFSigla_N"   )]
      public short gxTpr_Microrregiaomesoufsigla_N
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla_N = value;
            SetDirty("Microrregiaomesoufsigla_N");
         }

      }

      public void gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla_N_SetNull( )
      {
         gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla_N = 0;
         SetDirty("Microrregiaomesoufsigla_N");
         return  ;
      }

      public bool gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MicrorregiaoMesoUFNome_N" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoUFNome_N"   )]
      public short gxTpr_Microrregiaomesoufnome_N
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoufnome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufnome_N = value;
            SetDirty("Microrregiaomesoufnome_N");
         }

      }

      public void gxTv_Sdtmicrorregiao_Microrregiaomesoufnome_N_SetNull( )
      {
         gxTv_Sdtmicrorregiao_Microrregiaomesoufnome_N = 0;
         SetDirty("Microrregiaomesoufnome_N");
         return  ;
      }

      public bool gxTv_Sdtmicrorregiao_Microrregiaomesoufnome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MicrorregiaoMesoUFSiglaNome_N" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoUFSiglaNome_N"   )]
      public short gxTpr_Microrregiaomesoufsiglanome_N
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_N = value;
            SetDirty("Microrregiaomesoufsiglanome_N");
         }

      }

      public void gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_N_SetNull( )
      {
         gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_N = 0;
         SetDirty("Microrregiaomesoufsiglanome_N");
         return  ;
      }

      public bool gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MicrorregiaoMesoUFRegID_N" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoUFRegID_N"   )]
      public short gxTpr_Microrregiaomesoufregid_N
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoufregid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufregid_N = value;
            SetDirty("Microrregiaomesoufregid_N");
         }

      }

      public void gxTv_Sdtmicrorregiao_Microrregiaomesoufregid_N_SetNull( )
      {
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregid_N = 0;
         SetDirty("Microrregiaomesoufregid_N");
         return  ;
      }

      public bool gxTv_Sdtmicrorregiao_Microrregiaomesoufregid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MicrorregiaoMesoUFRegSigla_N" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoUFRegSigla_N"   )]
      public short gxTpr_Microrregiaomesoufregsigla_N
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla_N = value;
            SetDirty("Microrregiaomesoufregsigla_N");
         }

      }

      public void gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla_N_SetNull( )
      {
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla_N = 0;
         SetDirty("Microrregiaomesoufregsigla_N");
         return  ;
      }

      public bool gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MicrorregiaoMesoUFRegNome_N" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoUFRegNome_N"   )]
      public short gxTpr_Microrregiaomesoufregnome_N
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome_N = value;
            SetDirty("Microrregiaomesoufregnome_N");
         }

      }

      public void gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome_N_SetNull( )
      {
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome_N = 0;
         SetDirty("Microrregiaomesoufregnome_N");
         return  ;
      }

      public bool gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MicrorregiaoMesoUFRegSiglaNome_N" )]
      [  XmlElement( ElementName = "MicrorregiaoMesoUFRegSiglaNome_N"   )]
      public short gxTpr_Microrregiaomesoufregsiglanome_N
      {
         get {
            return gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_N = value;
            SetDirty("Microrregiaomesoufregsiglanome_N");
         }

      }

      public void gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_N_SetNull( )
      {
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_N = 0;
         SetDirty("Microrregiaomesoufregsiglanome_N");
         return  ;
      }

      public bool gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_Sdtmicrorregiao_Microrregiaonome = "";
         gxTv_Sdtmicrorregiao_Microrregiaomesonome = "";
         gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla = "";
         gxTv_Sdtmicrorregiao_Microrregiaomesoufnome = "";
         gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome = "";
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla = "";
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome = "";
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome = "";
         gxTv_Sdtmicrorregiao_Mode = "";
         gxTv_Sdtmicrorregiao_Microrregiaonome_Z = "";
         gxTv_Sdtmicrorregiao_Microrregiaomesonome_Z = "";
         gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla_Z = "";
         gxTv_Sdtmicrorregiao_Microrregiaomesoufnome_Z = "";
         gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_Z = "";
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla_Z = "";
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome_Z = "";
         gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "core.microrregiao", "GeneXus.Programs.core.microrregiao_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_Sdtmicrorregiao_Initialized ;
      private short gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla_N ;
      private short gxTv_Sdtmicrorregiao_Microrregiaomesoufnome_N ;
      private short gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_N ;
      private short gxTv_Sdtmicrorregiao_Microrregiaomesoufregid_N ;
      private short gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla_N ;
      private short gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome_N ;
      private short gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_N ;
      private int gxTv_Sdtmicrorregiao_Microrregiaoid ;
      private int gxTv_Sdtmicrorregiao_Microrregiaomesoid ;
      private int gxTv_Sdtmicrorregiao_Microrregiaomesoufid ;
      private int gxTv_Sdtmicrorregiao_Microrregiaomesoufregid ;
      private int gxTv_Sdtmicrorregiao_Microrregiaoid_Z ;
      private int gxTv_Sdtmicrorregiao_Microrregiaomesoid_Z ;
      private int gxTv_Sdtmicrorregiao_Microrregiaomesoufid_Z ;
      private int gxTv_Sdtmicrorregiao_Microrregiaomesoufregid_Z ;
      private string gxTv_Sdtmicrorregiao_Mode ;
      private string gxTv_Sdtmicrorregiao_Microrregiaonome ;
      private string gxTv_Sdtmicrorregiao_Microrregiaomesonome ;
      private string gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla ;
      private string gxTv_Sdtmicrorregiao_Microrregiaomesoufnome ;
      private string gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome ;
      private string gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla ;
      private string gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome ;
      private string gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome ;
      private string gxTv_Sdtmicrorregiao_Microrregiaonome_Z ;
      private string gxTv_Sdtmicrorregiao_Microrregiaomesonome_Z ;
      private string gxTv_Sdtmicrorregiao_Microrregiaomesoufsigla_Z ;
      private string gxTv_Sdtmicrorregiao_Microrregiaomesoufnome_Z ;
      private string gxTv_Sdtmicrorregiao_Microrregiaomesoufsiglanome_Z ;
      private string gxTv_Sdtmicrorregiao_Microrregiaomesoufregsigla_Z ;
      private string gxTv_Sdtmicrorregiao_Microrregiaomesoufregnome_Z ;
      private string gxTv_Sdtmicrorregiao_Microrregiaomesoufregsiglanome_Z ;
   }

   [DataContract(Name = @"core\microrregiao", Namespace = "agl_tresorygroup")]
   public class Sdtmicrorregiao_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.Sdtmicrorregiao>
   {
      public Sdtmicrorregiao_RESTInterface( ) : base()
      {
      }

      public Sdtmicrorregiao_RESTInterface( GeneXus.Programs.core.Sdtmicrorregiao psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MicrorregiaoID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Microrregiaoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Microrregiaoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Microrregiaoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "MicrorregiaoNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Microrregiaonome
      {
         get {
            return sdt.gxTpr_Microrregiaonome ;
         }

         set {
            sdt.gxTpr_Microrregiaonome = value;
         }

      }

      [DataMember( Name = "MicrorregiaoMesoID" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Microrregiaomesoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Microrregiaomesoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Microrregiaomesoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "MicrorregiaoMesoNome" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Microrregiaomesonome
      {
         get {
            return sdt.gxTpr_Microrregiaomesonome ;
         }

         set {
            sdt.gxTpr_Microrregiaomesonome = value;
         }

      }

      [DataMember( Name = "MicrorregiaoMesoUFID" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Microrregiaomesoufid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Microrregiaomesoufid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Microrregiaomesoufid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "MicrorregiaoMesoUFSigla" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Microrregiaomesoufsigla
      {
         get {
            return sdt.gxTpr_Microrregiaomesoufsigla ;
         }

         set {
            sdt.gxTpr_Microrregiaomesoufsigla = value;
         }

      }

      [DataMember( Name = "MicrorregiaoMesoUFNome" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Microrregiaomesoufnome
      {
         get {
            return sdt.gxTpr_Microrregiaomesoufnome ;
         }

         set {
            sdt.gxTpr_Microrregiaomesoufnome = value;
         }

      }

      [DataMember( Name = "MicrorregiaoMesoUFSiglaNome" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Microrregiaomesoufsiglanome
      {
         get {
            return sdt.gxTpr_Microrregiaomesoufsiglanome ;
         }

         set {
            sdt.gxTpr_Microrregiaomesoufsiglanome = value;
         }

      }

      [DataMember( Name = "MicrorregiaoMesoUFRegID" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Microrregiaomesoufregid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Microrregiaomesoufregid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Microrregiaomesoufregid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "MicrorregiaoMesoUFRegSigla" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Microrregiaomesoufregsigla
      {
         get {
            return sdt.gxTpr_Microrregiaomesoufregsigla ;
         }

         set {
            sdt.gxTpr_Microrregiaomesoufregsigla = value;
         }

      }

      [DataMember( Name = "MicrorregiaoMesoUFRegNome" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Microrregiaomesoufregnome
      {
         get {
            return sdt.gxTpr_Microrregiaomesoufregnome ;
         }

         set {
            sdt.gxTpr_Microrregiaomesoufregnome = value;
         }

      }

      [DataMember( Name = "MicrorregiaoMesoUFRegSiglaNome" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Microrregiaomesoufregsiglanome
      {
         get {
            return sdt.gxTpr_Microrregiaomesoufregsiglanome ;
         }

         set {
            sdt.gxTpr_Microrregiaomesoufregsiglanome = value;
         }

      }

      public GeneXus.Programs.core.Sdtmicrorregiao sdt
      {
         get {
            return (GeneXus.Programs.core.Sdtmicrorregiao)Sdt ;
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
            sdt = new GeneXus.Programs.core.Sdtmicrorregiao() ;
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
   }

   [DataContract(Name = @"core\microrregiao", Namespace = "agl_tresorygroup")]
   public class Sdtmicrorregiao_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.Sdtmicrorregiao>
   {
      public Sdtmicrorregiao_RESTLInterface( ) : base()
      {
      }

      public Sdtmicrorregiao_RESTLInterface( GeneXus.Programs.core.Sdtmicrorregiao psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MicrorregiaoNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Microrregiaonome
      {
         get {
            return sdt.gxTpr_Microrregiaonome ;
         }

         set {
            sdt.gxTpr_Microrregiaonome = value;
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

      public GeneXus.Programs.core.Sdtmicrorregiao sdt
      {
         get {
            return (GeneXus.Programs.core.Sdtmicrorregiao)Sdt ;
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
            sdt = new GeneXus.Programs.core.Sdtmicrorregiao() ;
         }
      }

   }

}
