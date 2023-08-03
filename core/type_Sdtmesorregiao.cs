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
   [XmlRoot(ElementName = "mesorregiao" )]
   [XmlType(TypeName =  "mesorregiao" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class Sdtmesorregiao : GxSilentTrnSdt
   {
      public Sdtmesorregiao( )
      {
      }

      public Sdtmesorregiao( IGxContext context )
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

      public void Load( int AV13MesorregiaoID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV13MesorregiaoID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"MesorregiaoID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "core\\mesorregiao");
         metadata.Set("BT", "tbibge_mesorregiao");
         metadata.Set("PK", "[ \"MesorregiaoID\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"UFID\" ],\"FKMap\":[ \"MesorregiaoUFID-UFID\" ] } ]");
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
         state.Add("gxTpr_Mesorregiaoid_Z");
         state.Add("gxTpr_Mesorregiaonome_Z");
         state.Add("gxTpr_Mesorregiaoufid_Z");
         state.Add("gxTpr_Mesorregiaoufsigla_Z");
         state.Add("gxTpr_Mesorregiaoufnome_Z");
         state.Add("gxTpr_Mesorregiaoufsiglanome_Z");
         state.Add("gxTpr_Mesorregiaoufregid_Z");
         state.Add("gxTpr_Mesorregiaoufregsigla_Z");
         state.Add("gxTpr_Mesorregiaoufregnome_Z");
         state.Add("gxTpr_Mesorregiaoufregsiglanome_Z");
         state.Add("gxTpr_Mesorregiaoufsiglanome_N");
         state.Add("gxTpr_Mesorregiaoufregsigla_N");
         state.Add("gxTpr_Mesorregiaoufregnome_N");
         state.Add("gxTpr_Mesorregiaoufregsiglanome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.Sdtmesorregiao sdt;
         sdt = (GeneXus.Programs.core.Sdtmesorregiao)(source);
         gxTv_Sdtmesorregiao_Mesorregiaoid = sdt.gxTv_Sdtmesorregiao_Mesorregiaoid ;
         gxTv_Sdtmesorregiao_Mesorregiaonome = sdt.gxTv_Sdtmesorregiao_Mesorregiaonome ;
         gxTv_Sdtmesorregiao_Mesorregiaoufid = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufid ;
         gxTv_Sdtmesorregiao_Mesorregiaoufsigla = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufsigla ;
         gxTv_Sdtmesorregiao_Mesorregiaoufnome = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufnome ;
         gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome ;
         gxTv_Sdtmesorregiao_Mesorregiaoufregid = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufregid ;
         gxTv_Sdtmesorregiao_Mesorregiaoufregsigla = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufregsigla ;
         gxTv_Sdtmesorregiao_Mesorregiaoufregnome = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufregnome ;
         gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome ;
         gxTv_Sdtmesorregiao_Mode = sdt.gxTv_Sdtmesorregiao_Mode ;
         gxTv_Sdtmesorregiao_Initialized = sdt.gxTv_Sdtmesorregiao_Initialized ;
         gxTv_Sdtmesorregiao_Mesorregiaoid_Z = sdt.gxTv_Sdtmesorregiao_Mesorregiaoid_Z ;
         gxTv_Sdtmesorregiao_Mesorregiaonome_Z = sdt.gxTv_Sdtmesorregiao_Mesorregiaonome_Z ;
         gxTv_Sdtmesorregiao_Mesorregiaoufid_Z = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufid_Z ;
         gxTv_Sdtmesorregiao_Mesorregiaoufsigla_Z = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufsigla_Z ;
         gxTv_Sdtmesorregiao_Mesorregiaoufnome_Z = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufnome_Z ;
         gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_Z = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_Z ;
         gxTv_Sdtmesorregiao_Mesorregiaoufregid_Z = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufregid_Z ;
         gxTv_Sdtmesorregiao_Mesorregiaoufregsigla_Z = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufregsigla_Z ;
         gxTv_Sdtmesorregiao_Mesorregiaoufregnome_Z = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufregnome_Z ;
         gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_Z = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_Z ;
         gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_N = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_N ;
         gxTv_Sdtmesorregiao_Mesorregiaoufregsigla_N = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufregsigla_N ;
         gxTv_Sdtmesorregiao_Mesorregiaoufregnome_N = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufregnome_N ;
         gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_N = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_N ;
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
         AddObjectProperty("MesorregiaoID", gxTv_Sdtmesorregiao_Mesorregiaoid, false, includeNonInitialized);
         AddObjectProperty("MesorregiaoNome", gxTv_Sdtmesorregiao_Mesorregiaonome, false, includeNonInitialized);
         AddObjectProperty("MesorregiaoUFID", gxTv_Sdtmesorregiao_Mesorregiaoufid, false, includeNonInitialized);
         AddObjectProperty("MesorregiaoUFSigla", gxTv_Sdtmesorregiao_Mesorregiaoufsigla, false, includeNonInitialized);
         AddObjectProperty("MesorregiaoUFNome", gxTv_Sdtmesorregiao_Mesorregiaoufnome, false, includeNonInitialized);
         AddObjectProperty("MesorregiaoUFSiglaNome", gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome, false, includeNonInitialized);
         AddObjectProperty("MesorregiaoUFSiglaNome_N", gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_N, false, includeNonInitialized);
         AddObjectProperty("MesorregiaoUFRegID", gxTv_Sdtmesorregiao_Mesorregiaoufregid, false, includeNonInitialized);
         AddObjectProperty("MesorregiaoUFRegSigla", gxTv_Sdtmesorregiao_Mesorregiaoufregsigla, false, includeNonInitialized);
         AddObjectProperty("MesorregiaoUFRegSigla_N", gxTv_Sdtmesorregiao_Mesorregiaoufregsigla_N, false, includeNonInitialized);
         AddObjectProperty("MesorregiaoUFRegNome", gxTv_Sdtmesorregiao_Mesorregiaoufregnome, false, includeNonInitialized);
         AddObjectProperty("MesorregiaoUFRegNome_N", gxTv_Sdtmesorregiao_Mesorregiaoufregnome_N, false, includeNonInitialized);
         AddObjectProperty("MesorregiaoUFRegSiglaNome", gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome, false, includeNonInitialized);
         AddObjectProperty("MesorregiaoUFRegSiglaNome_N", gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_Sdtmesorregiao_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_Sdtmesorregiao_Initialized, false, includeNonInitialized);
            AddObjectProperty("MesorregiaoID_Z", gxTv_Sdtmesorregiao_Mesorregiaoid_Z, false, includeNonInitialized);
            AddObjectProperty("MesorregiaoNome_Z", gxTv_Sdtmesorregiao_Mesorregiaonome_Z, false, includeNonInitialized);
            AddObjectProperty("MesorregiaoUFID_Z", gxTv_Sdtmesorregiao_Mesorregiaoufid_Z, false, includeNonInitialized);
            AddObjectProperty("MesorregiaoUFSigla_Z", gxTv_Sdtmesorregiao_Mesorregiaoufsigla_Z, false, includeNonInitialized);
            AddObjectProperty("MesorregiaoUFNome_Z", gxTv_Sdtmesorregiao_Mesorregiaoufnome_Z, false, includeNonInitialized);
            AddObjectProperty("MesorregiaoUFSiglaNome_Z", gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_Z, false, includeNonInitialized);
            AddObjectProperty("MesorregiaoUFRegID_Z", gxTv_Sdtmesorregiao_Mesorregiaoufregid_Z, false, includeNonInitialized);
            AddObjectProperty("MesorregiaoUFRegSigla_Z", gxTv_Sdtmesorregiao_Mesorregiaoufregsigla_Z, false, includeNonInitialized);
            AddObjectProperty("MesorregiaoUFRegNome_Z", gxTv_Sdtmesorregiao_Mesorregiaoufregnome_Z, false, includeNonInitialized);
            AddObjectProperty("MesorregiaoUFRegSiglaNome_Z", gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_Z, false, includeNonInitialized);
            AddObjectProperty("MesorregiaoUFSiglaNome_N", gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_N, false, includeNonInitialized);
            AddObjectProperty("MesorregiaoUFRegSigla_N", gxTv_Sdtmesorregiao_Mesorregiaoufregsigla_N, false, includeNonInitialized);
            AddObjectProperty("MesorregiaoUFRegNome_N", gxTv_Sdtmesorregiao_Mesorregiaoufregnome_N, false, includeNonInitialized);
            AddObjectProperty("MesorregiaoUFRegSiglaNome_N", gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.Sdtmesorregiao sdt )
      {
         if ( sdt.IsDirty("MesorregiaoID") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoid = sdt.gxTv_Sdtmesorregiao_Mesorregiaoid ;
         }
         if ( sdt.IsDirty("MesorregiaoNome") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaonome = sdt.gxTv_Sdtmesorregiao_Mesorregiaonome ;
         }
         if ( sdt.IsDirty("MesorregiaoUFID") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufid = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufid ;
         }
         if ( sdt.IsDirty("MesorregiaoUFSigla") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufsigla = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufsigla ;
         }
         if ( sdt.IsDirty("MesorregiaoUFNome") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufnome = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufnome ;
         }
         if ( sdt.IsDirty("MesorregiaoUFSiglaNome") )
         {
            gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_N = (short)(sdt.gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_N);
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome ;
         }
         if ( sdt.IsDirty("MesorregiaoUFRegID") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufregid = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufregid ;
         }
         if ( sdt.IsDirty("MesorregiaoUFRegSigla") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufregsigla = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufregsigla ;
         }
         if ( sdt.IsDirty("MesorregiaoUFRegNome") )
         {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufregnome = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufregnome ;
         }
         if ( sdt.IsDirty("MesorregiaoUFRegSiglaNome") )
         {
            gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_N = (short)(sdt.gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_N);
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome = sdt.gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "MesorregiaoID" )]
      [  XmlElement( ElementName = "MesorregiaoID"   )]
      public int gxTpr_Mesorregiaoid
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_Sdtmesorregiao_Mesorregiaoid != value )
            {
               gxTv_Sdtmesorregiao_Mode = "INS";
               this.gxTv_Sdtmesorregiao_Mesorregiaoid_Z_SetNull( );
               this.gxTv_Sdtmesorregiao_Mesorregiaonome_Z_SetNull( );
               this.gxTv_Sdtmesorregiao_Mesorregiaoufid_Z_SetNull( );
               this.gxTv_Sdtmesorregiao_Mesorregiaoufsigla_Z_SetNull( );
               this.gxTv_Sdtmesorregiao_Mesorregiaoufnome_Z_SetNull( );
               this.gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_Z_SetNull( );
               this.gxTv_Sdtmesorregiao_Mesorregiaoufregid_Z_SetNull( );
               this.gxTv_Sdtmesorregiao_Mesorregiaoufregsigla_Z_SetNull( );
               this.gxTv_Sdtmesorregiao_Mesorregiaoufregnome_Z_SetNull( );
               this.gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_Z_SetNull( );
            }
            gxTv_Sdtmesorregiao_Mesorregiaoid = value;
            SetDirty("Mesorregiaoid");
         }

      }

      [  SoapElement( ElementName = "MesorregiaoNome" )]
      [  XmlElement( ElementName = "MesorregiaoNome"   )]
      public string gxTpr_Mesorregiaonome
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaonome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaonome = value;
            SetDirty("Mesorregiaonome");
         }

      }

      [  SoapElement( ElementName = "MesorregiaoUFID" )]
      [  XmlElement( ElementName = "MesorregiaoUFID"   )]
      public int gxTpr_Mesorregiaoufid
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaoufid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufid = value;
            SetDirty("Mesorregiaoufid");
         }

      }

      [  SoapElement( ElementName = "MesorregiaoUFSigla" )]
      [  XmlElement( ElementName = "MesorregiaoUFSigla"   )]
      public string gxTpr_Mesorregiaoufsigla
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaoufsigla ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufsigla = value;
            SetDirty("Mesorregiaoufsigla");
         }

      }

      [  SoapElement( ElementName = "MesorregiaoUFNome" )]
      [  XmlElement( ElementName = "MesorregiaoUFNome"   )]
      public string gxTpr_Mesorregiaoufnome
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaoufnome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufnome = value;
            SetDirty("Mesorregiaoufnome");
         }

      }

      [  SoapElement( ElementName = "MesorregiaoUFSiglaNome" )]
      [  XmlElement( ElementName = "MesorregiaoUFSiglaNome"   )]
      public string gxTpr_Mesorregiaoufsiglanome
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome ;
         }

         set {
            gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_N = 0;
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome = value;
            SetDirty("Mesorregiaoufsiglanome");
         }

      }

      public void gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_SetNull( )
      {
         gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_N = 1;
         gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome = "";
         SetDirty("Mesorregiaoufsiglanome");
         return  ;
      }

      public bool gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_IsNull( )
      {
         return (gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_N==1) ;
      }

      [  SoapElement( ElementName = "MesorregiaoUFRegID" )]
      [  XmlElement( ElementName = "MesorregiaoUFRegID"   )]
      public int gxTpr_Mesorregiaoufregid
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaoufregid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufregid = value;
            SetDirty("Mesorregiaoufregid");
         }

      }

      [  SoapElement( ElementName = "MesorregiaoUFRegSigla" )]
      [  XmlElement( ElementName = "MesorregiaoUFRegSigla"   )]
      public string gxTpr_Mesorregiaoufregsigla
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaoufregsigla ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufregsigla = value;
            SetDirty("Mesorregiaoufregsigla");
         }

      }

      [  SoapElement( ElementName = "MesorregiaoUFRegNome" )]
      [  XmlElement( ElementName = "MesorregiaoUFRegNome"   )]
      public string gxTpr_Mesorregiaoufregnome
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaoufregnome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufregnome = value;
            SetDirty("Mesorregiaoufregnome");
         }

      }

      [  SoapElement( ElementName = "MesorregiaoUFRegSiglaNome" )]
      [  XmlElement( ElementName = "MesorregiaoUFRegSiglaNome"   )]
      public string gxTpr_Mesorregiaoufregsiglanome
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome ;
         }

         set {
            gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_N = 0;
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome = value;
            SetDirty("Mesorregiaoufregsiglanome");
         }

      }

      public void gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_SetNull( )
      {
         gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_N = 1;
         gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome = "";
         SetDirty("Mesorregiaoufregsiglanome");
         return  ;
      }

      public bool gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_IsNull( )
      {
         return (gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_Sdtmesorregiao_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_Sdtmesorregiao_Mode_SetNull( )
      {
         gxTv_Sdtmesorregiao_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_Sdtmesorregiao_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_Sdtmesorregiao_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_Sdtmesorregiao_Initialized_SetNull( )
      {
         gxTv_Sdtmesorregiao_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_Sdtmesorregiao_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MesorregiaoID_Z" )]
      [  XmlElement( ElementName = "MesorregiaoID_Z"   )]
      public int gxTpr_Mesorregiaoid_Z
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoid_Z = value;
            SetDirty("Mesorregiaoid_Z");
         }

      }

      public void gxTv_Sdtmesorregiao_Mesorregiaoid_Z_SetNull( )
      {
         gxTv_Sdtmesorregiao_Mesorregiaoid_Z = 0;
         SetDirty("Mesorregiaoid_Z");
         return  ;
      }

      public bool gxTv_Sdtmesorregiao_Mesorregiaoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MesorregiaoNome_Z" )]
      [  XmlElement( ElementName = "MesorregiaoNome_Z"   )]
      public string gxTpr_Mesorregiaonome_Z
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaonome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaonome_Z = value;
            SetDirty("Mesorregiaonome_Z");
         }

      }

      public void gxTv_Sdtmesorregiao_Mesorregiaonome_Z_SetNull( )
      {
         gxTv_Sdtmesorregiao_Mesorregiaonome_Z = "";
         SetDirty("Mesorregiaonome_Z");
         return  ;
      }

      public bool gxTv_Sdtmesorregiao_Mesorregiaonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MesorregiaoUFID_Z" )]
      [  XmlElement( ElementName = "MesorregiaoUFID_Z"   )]
      public int gxTpr_Mesorregiaoufid_Z
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaoufid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufid_Z = value;
            SetDirty("Mesorregiaoufid_Z");
         }

      }

      public void gxTv_Sdtmesorregiao_Mesorregiaoufid_Z_SetNull( )
      {
         gxTv_Sdtmesorregiao_Mesorregiaoufid_Z = 0;
         SetDirty("Mesorregiaoufid_Z");
         return  ;
      }

      public bool gxTv_Sdtmesorregiao_Mesorregiaoufid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MesorregiaoUFSigla_Z" )]
      [  XmlElement( ElementName = "MesorregiaoUFSigla_Z"   )]
      public string gxTpr_Mesorregiaoufsigla_Z
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaoufsigla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufsigla_Z = value;
            SetDirty("Mesorregiaoufsigla_Z");
         }

      }

      public void gxTv_Sdtmesorregiao_Mesorregiaoufsigla_Z_SetNull( )
      {
         gxTv_Sdtmesorregiao_Mesorregiaoufsigla_Z = "";
         SetDirty("Mesorregiaoufsigla_Z");
         return  ;
      }

      public bool gxTv_Sdtmesorregiao_Mesorregiaoufsigla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MesorregiaoUFNome_Z" )]
      [  XmlElement( ElementName = "MesorregiaoUFNome_Z"   )]
      public string gxTpr_Mesorregiaoufnome_Z
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaoufnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufnome_Z = value;
            SetDirty("Mesorregiaoufnome_Z");
         }

      }

      public void gxTv_Sdtmesorregiao_Mesorregiaoufnome_Z_SetNull( )
      {
         gxTv_Sdtmesorregiao_Mesorregiaoufnome_Z = "";
         SetDirty("Mesorregiaoufnome_Z");
         return  ;
      }

      public bool gxTv_Sdtmesorregiao_Mesorregiaoufnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MesorregiaoUFSiglaNome_Z" )]
      [  XmlElement( ElementName = "MesorregiaoUFSiglaNome_Z"   )]
      public string gxTpr_Mesorregiaoufsiglanome_Z
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_Z = value;
            SetDirty("Mesorregiaoufsiglanome_Z");
         }

      }

      public void gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_Z_SetNull( )
      {
         gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_Z = "";
         SetDirty("Mesorregiaoufsiglanome_Z");
         return  ;
      }

      public bool gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MesorregiaoUFRegID_Z" )]
      [  XmlElement( ElementName = "MesorregiaoUFRegID_Z"   )]
      public int gxTpr_Mesorregiaoufregid_Z
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaoufregid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufregid_Z = value;
            SetDirty("Mesorregiaoufregid_Z");
         }

      }

      public void gxTv_Sdtmesorregiao_Mesorregiaoufregid_Z_SetNull( )
      {
         gxTv_Sdtmesorregiao_Mesorregiaoufregid_Z = 0;
         SetDirty("Mesorregiaoufregid_Z");
         return  ;
      }

      public bool gxTv_Sdtmesorregiao_Mesorregiaoufregid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MesorregiaoUFRegSigla_Z" )]
      [  XmlElement( ElementName = "MesorregiaoUFRegSigla_Z"   )]
      public string gxTpr_Mesorregiaoufregsigla_Z
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaoufregsigla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufregsigla_Z = value;
            SetDirty("Mesorregiaoufregsigla_Z");
         }

      }

      public void gxTv_Sdtmesorregiao_Mesorregiaoufregsigla_Z_SetNull( )
      {
         gxTv_Sdtmesorregiao_Mesorregiaoufregsigla_Z = "";
         SetDirty("Mesorregiaoufregsigla_Z");
         return  ;
      }

      public bool gxTv_Sdtmesorregiao_Mesorregiaoufregsigla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MesorregiaoUFRegNome_Z" )]
      [  XmlElement( ElementName = "MesorregiaoUFRegNome_Z"   )]
      public string gxTpr_Mesorregiaoufregnome_Z
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaoufregnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufregnome_Z = value;
            SetDirty("Mesorregiaoufregnome_Z");
         }

      }

      public void gxTv_Sdtmesorregiao_Mesorregiaoufregnome_Z_SetNull( )
      {
         gxTv_Sdtmesorregiao_Mesorregiaoufregnome_Z = "";
         SetDirty("Mesorregiaoufregnome_Z");
         return  ;
      }

      public bool gxTv_Sdtmesorregiao_Mesorregiaoufregnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MesorregiaoUFRegSiglaNome_Z" )]
      [  XmlElement( ElementName = "MesorregiaoUFRegSiglaNome_Z"   )]
      public string gxTpr_Mesorregiaoufregsiglanome_Z
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_Z = value;
            SetDirty("Mesorregiaoufregsiglanome_Z");
         }

      }

      public void gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_Z_SetNull( )
      {
         gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_Z = "";
         SetDirty("Mesorregiaoufregsiglanome_Z");
         return  ;
      }

      public bool gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MesorregiaoUFSiglaNome_N" )]
      [  XmlElement( ElementName = "MesorregiaoUFSiglaNome_N"   )]
      public short gxTpr_Mesorregiaoufsiglanome_N
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_N = value;
            SetDirty("Mesorregiaoufsiglanome_N");
         }

      }

      public void gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_N_SetNull( )
      {
         gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_N = 0;
         SetDirty("Mesorregiaoufsiglanome_N");
         return  ;
      }

      public bool gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MesorregiaoUFRegSigla_N" )]
      [  XmlElement( ElementName = "MesorregiaoUFRegSigla_N"   )]
      public short gxTpr_Mesorregiaoufregsigla_N
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaoufregsigla_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufregsigla_N = value;
            SetDirty("Mesorregiaoufregsigla_N");
         }

      }

      public void gxTv_Sdtmesorregiao_Mesorregiaoufregsigla_N_SetNull( )
      {
         gxTv_Sdtmesorregiao_Mesorregiaoufregsigla_N = 0;
         SetDirty("Mesorregiaoufregsigla_N");
         return  ;
      }

      public bool gxTv_Sdtmesorregiao_Mesorregiaoufregsigla_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MesorregiaoUFRegNome_N" )]
      [  XmlElement( ElementName = "MesorregiaoUFRegNome_N"   )]
      public short gxTpr_Mesorregiaoufregnome_N
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaoufregnome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufregnome_N = value;
            SetDirty("Mesorregiaoufregnome_N");
         }

      }

      public void gxTv_Sdtmesorregiao_Mesorregiaoufregnome_N_SetNull( )
      {
         gxTv_Sdtmesorregiao_Mesorregiaoufregnome_N = 0;
         SetDirty("Mesorregiaoufregnome_N");
         return  ;
      }

      public bool gxTv_Sdtmesorregiao_Mesorregiaoufregnome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MesorregiaoUFRegSiglaNome_N" )]
      [  XmlElement( ElementName = "MesorregiaoUFRegSiglaNome_N"   )]
      public short gxTpr_Mesorregiaoufregsiglanome_N
      {
         get {
            return gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_N = value;
            SetDirty("Mesorregiaoufregsiglanome_N");
         }

      }

      public void gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_N_SetNull( )
      {
         gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_N = 0;
         SetDirty("Mesorregiaoufregsiglanome_N");
         return  ;
      }

      public bool gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_Sdtmesorregiao_Mesorregiaonome = "";
         gxTv_Sdtmesorregiao_Mesorregiaoufsigla = "";
         gxTv_Sdtmesorregiao_Mesorregiaoufnome = "";
         gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome = "";
         gxTv_Sdtmesorregiao_Mesorregiaoufregsigla = "";
         gxTv_Sdtmesorregiao_Mesorregiaoufregnome = "";
         gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome = "";
         gxTv_Sdtmesorregiao_Mode = "";
         gxTv_Sdtmesorregiao_Mesorregiaonome_Z = "";
         gxTv_Sdtmesorregiao_Mesorregiaoufsigla_Z = "";
         gxTv_Sdtmesorregiao_Mesorregiaoufnome_Z = "";
         gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_Z = "";
         gxTv_Sdtmesorregiao_Mesorregiaoufregsigla_Z = "";
         gxTv_Sdtmesorregiao_Mesorregiaoufregnome_Z = "";
         gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "core.mesorregiao", "GeneXus.Programs.core.mesorregiao_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_Sdtmesorregiao_Initialized ;
      private short gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_N ;
      private short gxTv_Sdtmesorregiao_Mesorregiaoufregsigla_N ;
      private short gxTv_Sdtmesorregiao_Mesorregiaoufregnome_N ;
      private short gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_N ;
      private int gxTv_Sdtmesorregiao_Mesorregiaoid ;
      private int gxTv_Sdtmesorregiao_Mesorregiaoufid ;
      private int gxTv_Sdtmesorregiao_Mesorregiaoufregid ;
      private int gxTv_Sdtmesorregiao_Mesorregiaoid_Z ;
      private int gxTv_Sdtmesorregiao_Mesorregiaoufid_Z ;
      private int gxTv_Sdtmesorregiao_Mesorregiaoufregid_Z ;
      private string gxTv_Sdtmesorregiao_Mode ;
      private string gxTv_Sdtmesorregiao_Mesorregiaonome ;
      private string gxTv_Sdtmesorregiao_Mesorregiaoufsigla ;
      private string gxTv_Sdtmesorregiao_Mesorregiaoufnome ;
      private string gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome ;
      private string gxTv_Sdtmesorregiao_Mesorregiaoufregsigla ;
      private string gxTv_Sdtmesorregiao_Mesorregiaoufregnome ;
      private string gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome ;
      private string gxTv_Sdtmesorregiao_Mesorregiaonome_Z ;
      private string gxTv_Sdtmesorregiao_Mesorregiaoufsigla_Z ;
      private string gxTv_Sdtmesorregiao_Mesorregiaoufnome_Z ;
      private string gxTv_Sdtmesorregiao_Mesorregiaoufsiglanome_Z ;
      private string gxTv_Sdtmesorregiao_Mesorregiaoufregsigla_Z ;
      private string gxTv_Sdtmesorregiao_Mesorregiaoufregnome_Z ;
      private string gxTv_Sdtmesorregiao_Mesorregiaoufregsiglanome_Z ;
   }

   [DataContract(Name = @"core\mesorregiao", Namespace = "agl_tresorygroup")]
   public class Sdtmesorregiao_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.Sdtmesorregiao>
   {
      public Sdtmesorregiao_RESTInterface( ) : base()
      {
      }

      public Sdtmesorregiao_RESTInterface( GeneXus.Programs.core.Sdtmesorregiao psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MesorregiaoID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Mesorregiaoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Mesorregiaoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Mesorregiaoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "MesorregiaoNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Mesorregiaonome
      {
         get {
            return sdt.gxTpr_Mesorregiaonome ;
         }

         set {
            sdt.gxTpr_Mesorregiaonome = value;
         }

      }

      [DataMember( Name = "MesorregiaoUFID" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Mesorregiaoufid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Mesorregiaoufid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Mesorregiaoufid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "MesorregiaoUFSigla" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Mesorregiaoufsigla
      {
         get {
            return sdt.gxTpr_Mesorregiaoufsigla ;
         }

         set {
            sdt.gxTpr_Mesorregiaoufsigla = value;
         }

      }

      [DataMember( Name = "MesorregiaoUFNome" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Mesorregiaoufnome
      {
         get {
            return sdt.gxTpr_Mesorregiaoufnome ;
         }

         set {
            sdt.gxTpr_Mesorregiaoufnome = value;
         }

      }

      [DataMember( Name = "MesorregiaoUFSiglaNome" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Mesorregiaoufsiglanome
      {
         get {
            return sdt.gxTpr_Mesorregiaoufsiglanome ;
         }

         set {
            sdt.gxTpr_Mesorregiaoufsiglanome = value;
         }

      }

      [DataMember( Name = "MesorregiaoUFRegID" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Mesorregiaoufregid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Mesorregiaoufregid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Mesorregiaoufregid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "MesorregiaoUFRegSigla" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Mesorregiaoufregsigla
      {
         get {
            return sdt.gxTpr_Mesorregiaoufregsigla ;
         }

         set {
            sdt.gxTpr_Mesorregiaoufregsigla = value;
         }

      }

      [DataMember( Name = "MesorregiaoUFRegNome" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Mesorregiaoufregnome
      {
         get {
            return sdt.gxTpr_Mesorregiaoufregnome ;
         }

         set {
            sdt.gxTpr_Mesorregiaoufregnome = value;
         }

      }

      [DataMember( Name = "MesorregiaoUFRegSiglaNome" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Mesorregiaoufregsiglanome
      {
         get {
            return sdt.gxTpr_Mesorregiaoufregsiglanome ;
         }

         set {
            sdt.gxTpr_Mesorregiaoufregsiglanome = value;
         }

      }

      public GeneXus.Programs.core.Sdtmesorregiao sdt
      {
         get {
            return (GeneXus.Programs.core.Sdtmesorregiao)Sdt ;
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
            sdt = new GeneXus.Programs.core.Sdtmesorregiao() ;
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
   }

   [DataContract(Name = @"core\mesorregiao", Namespace = "agl_tresorygroup")]
   public class Sdtmesorregiao_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.Sdtmesorregiao>
   {
      public Sdtmesorregiao_RESTLInterface( ) : base()
      {
      }

      public Sdtmesorregiao_RESTLInterface( GeneXus.Programs.core.Sdtmesorregiao psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MesorregiaoNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Mesorregiaonome
      {
         get {
            return sdt.gxTpr_Mesorregiaonome ;
         }

         set {
            sdt.gxTpr_Mesorregiaonome = value;
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

      public GeneXus.Programs.core.Sdtmesorregiao sdt
      {
         get {
            return (GeneXus.Programs.core.Sdtmesorregiao)Sdt ;
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
            sdt = new GeneXus.Programs.core.Sdtmesorregiao() ;
         }
      }

   }

}
