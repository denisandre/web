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
   [XmlRoot(ElementName = "uf" )]
   [XmlType(TypeName =  "uf" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class Sdtuf : GxSilentTrnSdt
   {
      public Sdtuf( )
      {
      }

      public Sdtuf( IGxContext context )
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

      public void Load( int AV4UFID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV4UFID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"UFID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "core\\uf");
         metadata.Set("BT", "tbibge_uf");
         metadata.Set("PK", "[ \"UFID\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"RegiaoID\" ],\"FKMap\":[ \"UFRegID-RegiaoID\" ] } ]");
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
         state.Add("gxTpr_Ufid_Z");
         state.Add("gxTpr_Ufsigla_Z");
         state.Add("gxTpr_Ufnome_Z");
         state.Add("gxTpr_Ufsiglanome_Z");
         state.Add("gxTpr_Ufregid_Z");
         state.Add("gxTpr_Ufregsigla_Z");
         state.Add("gxTpr_Ufregnome_Z");
         state.Add("gxTpr_Ufregsiglanome_Z");
         state.Add("gxTpr_Ufregsiglanome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.Sdtuf sdt;
         sdt = (GeneXus.Programs.core.Sdtuf)(source);
         gxTv_Sdtuf_Ufid = sdt.gxTv_Sdtuf_Ufid ;
         gxTv_Sdtuf_Ufsigla = sdt.gxTv_Sdtuf_Ufsigla ;
         gxTv_Sdtuf_Ufnome = sdt.gxTv_Sdtuf_Ufnome ;
         gxTv_Sdtuf_Ufsiglanome = sdt.gxTv_Sdtuf_Ufsiglanome ;
         gxTv_Sdtuf_Ufregid = sdt.gxTv_Sdtuf_Ufregid ;
         gxTv_Sdtuf_Ufregsigla = sdt.gxTv_Sdtuf_Ufregsigla ;
         gxTv_Sdtuf_Ufregnome = sdt.gxTv_Sdtuf_Ufregnome ;
         gxTv_Sdtuf_Ufregsiglanome = sdt.gxTv_Sdtuf_Ufregsiglanome ;
         gxTv_Sdtuf_Mode = sdt.gxTv_Sdtuf_Mode ;
         gxTv_Sdtuf_Initialized = sdt.gxTv_Sdtuf_Initialized ;
         gxTv_Sdtuf_Ufid_Z = sdt.gxTv_Sdtuf_Ufid_Z ;
         gxTv_Sdtuf_Ufsigla_Z = sdt.gxTv_Sdtuf_Ufsigla_Z ;
         gxTv_Sdtuf_Ufnome_Z = sdt.gxTv_Sdtuf_Ufnome_Z ;
         gxTv_Sdtuf_Ufsiglanome_Z = sdt.gxTv_Sdtuf_Ufsiglanome_Z ;
         gxTv_Sdtuf_Ufregid_Z = sdt.gxTv_Sdtuf_Ufregid_Z ;
         gxTv_Sdtuf_Ufregsigla_Z = sdt.gxTv_Sdtuf_Ufregsigla_Z ;
         gxTv_Sdtuf_Ufregnome_Z = sdt.gxTv_Sdtuf_Ufregnome_Z ;
         gxTv_Sdtuf_Ufregsiglanome_Z = sdt.gxTv_Sdtuf_Ufregsiglanome_Z ;
         gxTv_Sdtuf_Ufregsiglanome_N = sdt.gxTv_Sdtuf_Ufregsiglanome_N ;
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
         AddObjectProperty("UFID", gxTv_Sdtuf_Ufid, false, includeNonInitialized);
         AddObjectProperty("UFSigla", gxTv_Sdtuf_Ufsigla, false, includeNonInitialized);
         AddObjectProperty("UFNome", gxTv_Sdtuf_Ufnome, false, includeNonInitialized);
         AddObjectProperty("UFSiglaNome", gxTv_Sdtuf_Ufsiglanome, false, includeNonInitialized);
         AddObjectProperty("UFRegID", gxTv_Sdtuf_Ufregid, false, includeNonInitialized);
         AddObjectProperty("UFRegSigla", gxTv_Sdtuf_Ufregsigla, false, includeNonInitialized);
         AddObjectProperty("UFRegNome", gxTv_Sdtuf_Ufregnome, false, includeNonInitialized);
         AddObjectProperty("UFRegSiglaNome", gxTv_Sdtuf_Ufregsiglanome, false, includeNonInitialized);
         AddObjectProperty("UFRegSiglaNome_N", gxTv_Sdtuf_Ufregsiglanome_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_Sdtuf_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_Sdtuf_Initialized, false, includeNonInitialized);
            AddObjectProperty("UFID_Z", gxTv_Sdtuf_Ufid_Z, false, includeNonInitialized);
            AddObjectProperty("UFSigla_Z", gxTv_Sdtuf_Ufsigla_Z, false, includeNonInitialized);
            AddObjectProperty("UFNome_Z", gxTv_Sdtuf_Ufnome_Z, false, includeNonInitialized);
            AddObjectProperty("UFSiglaNome_Z", gxTv_Sdtuf_Ufsiglanome_Z, false, includeNonInitialized);
            AddObjectProperty("UFRegID_Z", gxTv_Sdtuf_Ufregid_Z, false, includeNonInitialized);
            AddObjectProperty("UFRegSigla_Z", gxTv_Sdtuf_Ufregsigla_Z, false, includeNonInitialized);
            AddObjectProperty("UFRegNome_Z", gxTv_Sdtuf_Ufregnome_Z, false, includeNonInitialized);
            AddObjectProperty("UFRegSiglaNome_Z", gxTv_Sdtuf_Ufregsiglanome_Z, false, includeNonInitialized);
            AddObjectProperty("UFRegSiglaNome_N", gxTv_Sdtuf_Ufregsiglanome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.Sdtuf sdt )
      {
         if ( sdt.IsDirty("UFID") )
         {
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufid = sdt.gxTv_Sdtuf_Ufid ;
         }
         if ( sdt.IsDirty("UFSigla") )
         {
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufsigla = sdt.gxTv_Sdtuf_Ufsigla ;
         }
         if ( sdt.IsDirty("UFNome") )
         {
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufnome = sdt.gxTv_Sdtuf_Ufnome ;
         }
         if ( sdt.IsDirty("UFSiglaNome") )
         {
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufsiglanome = sdt.gxTv_Sdtuf_Ufsiglanome ;
         }
         if ( sdt.IsDirty("UFRegID") )
         {
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufregid = sdt.gxTv_Sdtuf_Ufregid ;
         }
         if ( sdt.IsDirty("UFRegSigla") )
         {
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufregsigla = sdt.gxTv_Sdtuf_Ufregsigla ;
         }
         if ( sdt.IsDirty("UFRegNome") )
         {
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufregnome = sdt.gxTv_Sdtuf_Ufregnome ;
         }
         if ( sdt.IsDirty("UFRegSiglaNome") )
         {
            gxTv_Sdtuf_Ufregsiglanome_N = (short)(sdt.gxTv_Sdtuf_Ufregsiglanome_N);
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufregsiglanome = sdt.gxTv_Sdtuf_Ufregsiglanome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "UFID" )]
      [  XmlElement( ElementName = "UFID"   )]
      public int gxTpr_Ufid
      {
         get {
            return gxTv_Sdtuf_Ufid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_Sdtuf_Ufid != value )
            {
               gxTv_Sdtuf_Mode = "INS";
               this.gxTv_Sdtuf_Ufid_Z_SetNull( );
               this.gxTv_Sdtuf_Ufsigla_Z_SetNull( );
               this.gxTv_Sdtuf_Ufnome_Z_SetNull( );
               this.gxTv_Sdtuf_Ufsiglanome_Z_SetNull( );
               this.gxTv_Sdtuf_Ufregid_Z_SetNull( );
               this.gxTv_Sdtuf_Ufregsigla_Z_SetNull( );
               this.gxTv_Sdtuf_Ufregnome_Z_SetNull( );
               this.gxTv_Sdtuf_Ufregsiglanome_Z_SetNull( );
            }
            gxTv_Sdtuf_Ufid = value;
            SetDirty("Ufid");
         }

      }

      [  SoapElement( ElementName = "UFSigla" )]
      [  XmlElement( ElementName = "UFSigla"   )]
      public string gxTpr_Ufsigla
      {
         get {
            return gxTv_Sdtuf_Ufsigla ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufsigla = value;
            SetDirty("Ufsigla");
         }

      }

      [  SoapElement( ElementName = "UFNome" )]
      [  XmlElement( ElementName = "UFNome"   )]
      public string gxTpr_Ufnome
      {
         get {
            return gxTv_Sdtuf_Ufnome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufnome = value;
            SetDirty("Ufnome");
         }

      }

      [  SoapElement( ElementName = "UFSiglaNome" )]
      [  XmlElement( ElementName = "UFSiglaNome"   )]
      public string gxTpr_Ufsiglanome
      {
         get {
            return gxTv_Sdtuf_Ufsiglanome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufsiglanome = value;
            SetDirty("Ufsiglanome");
         }

      }

      [  SoapElement( ElementName = "UFRegID" )]
      [  XmlElement( ElementName = "UFRegID"   )]
      public int gxTpr_Ufregid
      {
         get {
            return gxTv_Sdtuf_Ufregid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufregid = value;
            SetDirty("Ufregid");
         }

      }

      [  SoapElement( ElementName = "UFRegSigla" )]
      [  XmlElement( ElementName = "UFRegSigla"   )]
      public string gxTpr_Ufregsigla
      {
         get {
            return gxTv_Sdtuf_Ufregsigla ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufregsigla = value;
            SetDirty("Ufregsigla");
         }

      }

      [  SoapElement( ElementName = "UFRegNome" )]
      [  XmlElement( ElementName = "UFRegNome"   )]
      public string gxTpr_Ufregnome
      {
         get {
            return gxTv_Sdtuf_Ufregnome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufregnome = value;
            SetDirty("Ufregnome");
         }

      }

      [  SoapElement( ElementName = "UFRegSiglaNome" )]
      [  XmlElement( ElementName = "UFRegSiglaNome"   )]
      public string gxTpr_Ufregsiglanome
      {
         get {
            return gxTv_Sdtuf_Ufregsiglanome ;
         }

         set {
            gxTv_Sdtuf_Ufregsiglanome_N = 0;
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufregsiglanome = value;
            SetDirty("Ufregsiglanome");
         }

      }

      public void gxTv_Sdtuf_Ufregsiglanome_SetNull( )
      {
         gxTv_Sdtuf_Ufregsiglanome_N = 1;
         gxTv_Sdtuf_Ufregsiglanome = "";
         SetDirty("Ufregsiglanome");
         return  ;
      }

      public bool gxTv_Sdtuf_Ufregsiglanome_IsNull( )
      {
         return (gxTv_Sdtuf_Ufregsiglanome_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_Sdtuf_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtuf_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_Sdtuf_Mode_SetNull( )
      {
         gxTv_Sdtuf_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_Sdtuf_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_Sdtuf_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtuf_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_Sdtuf_Initialized_SetNull( )
      {
         gxTv_Sdtuf_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_Sdtuf_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UFID_Z" )]
      [  XmlElement( ElementName = "UFID_Z"   )]
      public int gxTpr_Ufid_Z
      {
         get {
            return gxTv_Sdtuf_Ufid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufid_Z = value;
            SetDirty("Ufid_Z");
         }

      }

      public void gxTv_Sdtuf_Ufid_Z_SetNull( )
      {
         gxTv_Sdtuf_Ufid_Z = 0;
         SetDirty("Ufid_Z");
         return  ;
      }

      public bool gxTv_Sdtuf_Ufid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UFSigla_Z" )]
      [  XmlElement( ElementName = "UFSigla_Z"   )]
      public string gxTpr_Ufsigla_Z
      {
         get {
            return gxTv_Sdtuf_Ufsigla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufsigla_Z = value;
            SetDirty("Ufsigla_Z");
         }

      }

      public void gxTv_Sdtuf_Ufsigla_Z_SetNull( )
      {
         gxTv_Sdtuf_Ufsigla_Z = "";
         SetDirty("Ufsigla_Z");
         return  ;
      }

      public bool gxTv_Sdtuf_Ufsigla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UFNome_Z" )]
      [  XmlElement( ElementName = "UFNome_Z"   )]
      public string gxTpr_Ufnome_Z
      {
         get {
            return gxTv_Sdtuf_Ufnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufnome_Z = value;
            SetDirty("Ufnome_Z");
         }

      }

      public void gxTv_Sdtuf_Ufnome_Z_SetNull( )
      {
         gxTv_Sdtuf_Ufnome_Z = "";
         SetDirty("Ufnome_Z");
         return  ;
      }

      public bool gxTv_Sdtuf_Ufnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UFSiglaNome_Z" )]
      [  XmlElement( ElementName = "UFSiglaNome_Z"   )]
      public string gxTpr_Ufsiglanome_Z
      {
         get {
            return gxTv_Sdtuf_Ufsiglanome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufsiglanome_Z = value;
            SetDirty("Ufsiglanome_Z");
         }

      }

      public void gxTv_Sdtuf_Ufsiglanome_Z_SetNull( )
      {
         gxTv_Sdtuf_Ufsiglanome_Z = "";
         SetDirty("Ufsiglanome_Z");
         return  ;
      }

      public bool gxTv_Sdtuf_Ufsiglanome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UFRegID_Z" )]
      [  XmlElement( ElementName = "UFRegID_Z"   )]
      public int gxTpr_Ufregid_Z
      {
         get {
            return gxTv_Sdtuf_Ufregid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufregid_Z = value;
            SetDirty("Ufregid_Z");
         }

      }

      public void gxTv_Sdtuf_Ufregid_Z_SetNull( )
      {
         gxTv_Sdtuf_Ufregid_Z = 0;
         SetDirty("Ufregid_Z");
         return  ;
      }

      public bool gxTv_Sdtuf_Ufregid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UFRegSigla_Z" )]
      [  XmlElement( ElementName = "UFRegSigla_Z"   )]
      public string gxTpr_Ufregsigla_Z
      {
         get {
            return gxTv_Sdtuf_Ufregsigla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufregsigla_Z = value;
            SetDirty("Ufregsigla_Z");
         }

      }

      public void gxTv_Sdtuf_Ufregsigla_Z_SetNull( )
      {
         gxTv_Sdtuf_Ufregsigla_Z = "";
         SetDirty("Ufregsigla_Z");
         return  ;
      }

      public bool gxTv_Sdtuf_Ufregsigla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UFRegNome_Z" )]
      [  XmlElement( ElementName = "UFRegNome_Z"   )]
      public string gxTpr_Ufregnome_Z
      {
         get {
            return gxTv_Sdtuf_Ufregnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufregnome_Z = value;
            SetDirty("Ufregnome_Z");
         }

      }

      public void gxTv_Sdtuf_Ufregnome_Z_SetNull( )
      {
         gxTv_Sdtuf_Ufregnome_Z = "";
         SetDirty("Ufregnome_Z");
         return  ;
      }

      public bool gxTv_Sdtuf_Ufregnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UFRegSiglaNome_Z" )]
      [  XmlElement( ElementName = "UFRegSiglaNome_Z"   )]
      public string gxTpr_Ufregsiglanome_Z
      {
         get {
            return gxTv_Sdtuf_Ufregsiglanome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufregsiglanome_Z = value;
            SetDirty("Ufregsiglanome_Z");
         }

      }

      public void gxTv_Sdtuf_Ufregsiglanome_Z_SetNull( )
      {
         gxTv_Sdtuf_Ufregsiglanome_Z = "";
         SetDirty("Ufregsiglanome_Z");
         return  ;
      }

      public bool gxTv_Sdtuf_Ufregsiglanome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UFRegSiglaNome_N" )]
      [  XmlElement( ElementName = "UFRegSiglaNome_N"   )]
      public short gxTpr_Ufregsiglanome_N
      {
         get {
            return gxTv_Sdtuf_Ufregsiglanome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtuf_Ufregsiglanome_N = value;
            SetDirty("Ufregsiglanome_N");
         }

      }

      public void gxTv_Sdtuf_Ufregsiglanome_N_SetNull( )
      {
         gxTv_Sdtuf_Ufregsiglanome_N = 0;
         SetDirty("Ufregsiglanome_N");
         return  ;
      }

      public bool gxTv_Sdtuf_Ufregsiglanome_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_Sdtuf_Ufsigla = "";
         gxTv_Sdtuf_Ufnome = "";
         gxTv_Sdtuf_Ufsiglanome = "";
         gxTv_Sdtuf_Ufregsigla = "";
         gxTv_Sdtuf_Ufregnome = "";
         gxTv_Sdtuf_Ufregsiglanome = "";
         gxTv_Sdtuf_Mode = "";
         gxTv_Sdtuf_Ufsigla_Z = "";
         gxTv_Sdtuf_Ufnome_Z = "";
         gxTv_Sdtuf_Ufsiglanome_Z = "";
         gxTv_Sdtuf_Ufregsigla_Z = "";
         gxTv_Sdtuf_Ufregnome_Z = "";
         gxTv_Sdtuf_Ufregsiglanome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "core.uf", "GeneXus.Programs.core.uf_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_Sdtuf_Initialized ;
      private short gxTv_Sdtuf_Ufregsiglanome_N ;
      private int gxTv_Sdtuf_Ufid ;
      private int gxTv_Sdtuf_Ufregid ;
      private int gxTv_Sdtuf_Ufid_Z ;
      private int gxTv_Sdtuf_Ufregid_Z ;
      private string gxTv_Sdtuf_Mode ;
      private string gxTv_Sdtuf_Ufsigla ;
      private string gxTv_Sdtuf_Ufnome ;
      private string gxTv_Sdtuf_Ufsiglanome ;
      private string gxTv_Sdtuf_Ufregsigla ;
      private string gxTv_Sdtuf_Ufregnome ;
      private string gxTv_Sdtuf_Ufregsiglanome ;
      private string gxTv_Sdtuf_Ufsigla_Z ;
      private string gxTv_Sdtuf_Ufnome_Z ;
      private string gxTv_Sdtuf_Ufsiglanome_Z ;
      private string gxTv_Sdtuf_Ufregsigla_Z ;
      private string gxTv_Sdtuf_Ufregnome_Z ;
      private string gxTv_Sdtuf_Ufregsiglanome_Z ;
   }

   [DataContract(Name = @"core\uf", Namespace = "agl_tresorygroup")]
   public class Sdtuf_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.Sdtuf>
   {
      public Sdtuf_RESTInterface( ) : base()
      {
      }

      public Sdtuf_RESTInterface( GeneXus.Programs.core.Sdtuf psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "UFID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Ufid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Ufid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Ufid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "UFSigla" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Ufsigla
      {
         get {
            return sdt.gxTpr_Ufsigla ;
         }

         set {
            sdt.gxTpr_Ufsigla = value;
         }

      }

      [DataMember( Name = "UFNome" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Ufnome
      {
         get {
            return sdt.gxTpr_Ufnome ;
         }

         set {
            sdt.gxTpr_Ufnome = value;
         }

      }

      [DataMember( Name = "UFSiglaNome" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Ufsiglanome
      {
         get {
            return sdt.gxTpr_Ufsiglanome ;
         }

         set {
            sdt.gxTpr_Ufsiglanome = value;
         }

      }

      [DataMember( Name = "UFRegID" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Ufregid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Ufregid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Ufregid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "UFRegSigla" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Ufregsigla
      {
         get {
            return sdt.gxTpr_Ufregsigla ;
         }

         set {
            sdt.gxTpr_Ufregsigla = value;
         }

      }

      [DataMember( Name = "UFRegNome" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Ufregnome
      {
         get {
            return sdt.gxTpr_Ufregnome ;
         }

         set {
            sdt.gxTpr_Ufregnome = value;
         }

      }

      [DataMember( Name = "UFRegSiglaNome" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Ufregsiglanome
      {
         get {
            return sdt.gxTpr_Ufregsiglanome ;
         }

         set {
            sdt.gxTpr_Ufregsiglanome = value;
         }

      }

      public GeneXus.Programs.core.Sdtuf sdt
      {
         get {
            return (GeneXus.Programs.core.Sdtuf)Sdt ;
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
            sdt = new GeneXus.Programs.core.Sdtuf() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 8 )]
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

   [DataContract(Name = @"core\uf", Namespace = "agl_tresorygroup")]
   public class Sdtuf_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.Sdtuf>
   {
      public Sdtuf_RESTLInterface( ) : base()
      {
      }

      public Sdtuf_RESTLInterface( GeneXus.Programs.core.Sdtuf psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "UFSigla" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Ufsigla
      {
         get {
            return sdt.gxTpr_Ufsigla ;
         }

         set {
            sdt.gxTpr_Ufsigla = value;
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

      public GeneXus.Programs.core.Sdtuf sdt
      {
         get {
            return (GeneXus.Programs.core.Sdtuf)Sdt ;
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
            sdt = new GeneXus.Programs.core.Sdtuf() ;
         }
      }

   }

}
