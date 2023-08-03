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
   [XmlRoot(ElementName = "regiao" )]
   [XmlType(TypeName =  "regiao" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class Sdtregiao : GxSilentTrnSdt
   {
      public Sdtregiao( )
      {
      }

      public Sdtregiao( IGxContext context )
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

      public void Load( int AV1RegiaoID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV1RegiaoID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"RegiaoID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "core\\regiao");
         metadata.Set("BT", "tbibge_regiao");
         metadata.Set("PK", "[ \"RegiaoID\" ]");
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
         state.Add("gxTpr_Regiaoid_Z");
         state.Add("gxTpr_Regiaosigla_Z");
         state.Add("gxTpr_Regiaonome_Z");
         state.Add("gxTpr_Regiaosiglanome_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.Sdtregiao sdt;
         sdt = (GeneXus.Programs.core.Sdtregiao)(source);
         gxTv_Sdtregiao_Regiaoid = sdt.gxTv_Sdtregiao_Regiaoid ;
         gxTv_Sdtregiao_Regiaosigla = sdt.gxTv_Sdtregiao_Regiaosigla ;
         gxTv_Sdtregiao_Regiaonome = sdt.gxTv_Sdtregiao_Regiaonome ;
         gxTv_Sdtregiao_Regiaosiglanome = sdt.gxTv_Sdtregiao_Regiaosiglanome ;
         gxTv_Sdtregiao_Mode = sdt.gxTv_Sdtregiao_Mode ;
         gxTv_Sdtregiao_Initialized = sdt.gxTv_Sdtregiao_Initialized ;
         gxTv_Sdtregiao_Regiaoid_Z = sdt.gxTv_Sdtregiao_Regiaoid_Z ;
         gxTv_Sdtregiao_Regiaosigla_Z = sdt.gxTv_Sdtregiao_Regiaosigla_Z ;
         gxTv_Sdtregiao_Regiaonome_Z = sdt.gxTv_Sdtregiao_Regiaonome_Z ;
         gxTv_Sdtregiao_Regiaosiglanome_Z = sdt.gxTv_Sdtregiao_Regiaosiglanome_Z ;
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
         AddObjectProperty("RegiaoID", gxTv_Sdtregiao_Regiaoid, false, includeNonInitialized);
         AddObjectProperty("RegiaoSigla", gxTv_Sdtregiao_Regiaosigla, false, includeNonInitialized);
         AddObjectProperty("RegiaoNome", gxTv_Sdtregiao_Regiaonome, false, includeNonInitialized);
         AddObjectProperty("RegiaoSiglaNome", gxTv_Sdtregiao_Regiaosiglanome, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_Sdtregiao_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_Sdtregiao_Initialized, false, includeNonInitialized);
            AddObjectProperty("RegiaoID_Z", gxTv_Sdtregiao_Regiaoid_Z, false, includeNonInitialized);
            AddObjectProperty("RegiaoSigla_Z", gxTv_Sdtregiao_Regiaosigla_Z, false, includeNonInitialized);
            AddObjectProperty("RegiaoNome_Z", gxTv_Sdtregiao_Regiaonome_Z, false, includeNonInitialized);
            AddObjectProperty("RegiaoSiglaNome_Z", gxTv_Sdtregiao_Regiaosiglanome_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.Sdtregiao sdt )
      {
         if ( sdt.IsDirty("RegiaoID") )
         {
            sdtIsNull = 0;
            gxTv_Sdtregiao_Regiaoid = sdt.gxTv_Sdtregiao_Regiaoid ;
         }
         if ( sdt.IsDirty("RegiaoSigla") )
         {
            sdtIsNull = 0;
            gxTv_Sdtregiao_Regiaosigla = sdt.gxTv_Sdtregiao_Regiaosigla ;
         }
         if ( sdt.IsDirty("RegiaoNome") )
         {
            sdtIsNull = 0;
            gxTv_Sdtregiao_Regiaonome = sdt.gxTv_Sdtregiao_Regiaonome ;
         }
         if ( sdt.IsDirty("RegiaoSiglaNome") )
         {
            sdtIsNull = 0;
            gxTv_Sdtregiao_Regiaosiglanome = sdt.gxTv_Sdtregiao_Regiaosiglanome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "RegiaoID" )]
      [  XmlElement( ElementName = "RegiaoID"   )]
      public int gxTpr_Regiaoid
      {
         get {
            return gxTv_Sdtregiao_Regiaoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_Sdtregiao_Regiaoid != value )
            {
               gxTv_Sdtregiao_Mode = "INS";
               this.gxTv_Sdtregiao_Regiaoid_Z_SetNull( );
               this.gxTv_Sdtregiao_Regiaosigla_Z_SetNull( );
               this.gxTv_Sdtregiao_Regiaonome_Z_SetNull( );
               this.gxTv_Sdtregiao_Regiaosiglanome_Z_SetNull( );
            }
            gxTv_Sdtregiao_Regiaoid = value;
            SetDirty("Regiaoid");
         }

      }

      [  SoapElement( ElementName = "RegiaoSigla" )]
      [  XmlElement( ElementName = "RegiaoSigla"   )]
      public string gxTpr_Regiaosigla
      {
         get {
            return gxTv_Sdtregiao_Regiaosigla ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtregiao_Regiaosigla = value;
            SetDirty("Regiaosigla");
         }

      }

      [  SoapElement( ElementName = "RegiaoNome" )]
      [  XmlElement( ElementName = "RegiaoNome"   )]
      public string gxTpr_Regiaonome
      {
         get {
            return gxTv_Sdtregiao_Regiaonome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtregiao_Regiaonome = value;
            SetDirty("Regiaonome");
         }

      }

      [  SoapElement( ElementName = "RegiaoSiglaNome" )]
      [  XmlElement( ElementName = "RegiaoSiglaNome"   )]
      public string gxTpr_Regiaosiglanome
      {
         get {
            return gxTv_Sdtregiao_Regiaosiglanome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtregiao_Regiaosiglanome = value;
            SetDirty("Regiaosiglanome");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_Sdtregiao_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtregiao_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_Sdtregiao_Mode_SetNull( )
      {
         gxTv_Sdtregiao_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_Sdtregiao_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_Sdtregiao_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtregiao_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_Sdtregiao_Initialized_SetNull( )
      {
         gxTv_Sdtregiao_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_Sdtregiao_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RegiaoID_Z" )]
      [  XmlElement( ElementName = "RegiaoID_Z"   )]
      public int gxTpr_Regiaoid_Z
      {
         get {
            return gxTv_Sdtregiao_Regiaoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtregiao_Regiaoid_Z = value;
            SetDirty("Regiaoid_Z");
         }

      }

      public void gxTv_Sdtregiao_Regiaoid_Z_SetNull( )
      {
         gxTv_Sdtregiao_Regiaoid_Z = 0;
         SetDirty("Regiaoid_Z");
         return  ;
      }

      public bool gxTv_Sdtregiao_Regiaoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RegiaoSigla_Z" )]
      [  XmlElement( ElementName = "RegiaoSigla_Z"   )]
      public string gxTpr_Regiaosigla_Z
      {
         get {
            return gxTv_Sdtregiao_Regiaosigla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtregiao_Regiaosigla_Z = value;
            SetDirty("Regiaosigla_Z");
         }

      }

      public void gxTv_Sdtregiao_Regiaosigla_Z_SetNull( )
      {
         gxTv_Sdtregiao_Regiaosigla_Z = "";
         SetDirty("Regiaosigla_Z");
         return  ;
      }

      public bool gxTv_Sdtregiao_Regiaosigla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RegiaoNome_Z" )]
      [  XmlElement( ElementName = "RegiaoNome_Z"   )]
      public string gxTpr_Regiaonome_Z
      {
         get {
            return gxTv_Sdtregiao_Regiaonome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtregiao_Regiaonome_Z = value;
            SetDirty("Regiaonome_Z");
         }

      }

      public void gxTv_Sdtregiao_Regiaonome_Z_SetNull( )
      {
         gxTv_Sdtregiao_Regiaonome_Z = "";
         SetDirty("Regiaonome_Z");
         return  ;
      }

      public bool gxTv_Sdtregiao_Regiaonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RegiaoSiglaNome_Z" )]
      [  XmlElement( ElementName = "RegiaoSiglaNome_Z"   )]
      public string gxTpr_Regiaosiglanome_Z
      {
         get {
            return gxTv_Sdtregiao_Regiaosiglanome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtregiao_Regiaosiglanome_Z = value;
            SetDirty("Regiaosiglanome_Z");
         }

      }

      public void gxTv_Sdtregiao_Regiaosiglanome_Z_SetNull( )
      {
         gxTv_Sdtregiao_Regiaosiglanome_Z = "";
         SetDirty("Regiaosiglanome_Z");
         return  ;
      }

      public bool gxTv_Sdtregiao_Regiaosiglanome_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_Sdtregiao_Regiaosigla = "";
         gxTv_Sdtregiao_Regiaonome = "";
         gxTv_Sdtregiao_Regiaosiglanome = "";
         gxTv_Sdtregiao_Mode = "";
         gxTv_Sdtregiao_Regiaosigla_Z = "";
         gxTv_Sdtregiao_Regiaonome_Z = "";
         gxTv_Sdtregiao_Regiaosiglanome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "core.regiao", "GeneXus.Programs.core.regiao_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_Sdtregiao_Initialized ;
      private int gxTv_Sdtregiao_Regiaoid ;
      private int gxTv_Sdtregiao_Regiaoid_Z ;
      private string gxTv_Sdtregiao_Mode ;
      private string gxTv_Sdtregiao_Regiaosigla ;
      private string gxTv_Sdtregiao_Regiaonome ;
      private string gxTv_Sdtregiao_Regiaosiglanome ;
      private string gxTv_Sdtregiao_Regiaosigla_Z ;
      private string gxTv_Sdtregiao_Regiaonome_Z ;
      private string gxTv_Sdtregiao_Regiaosiglanome_Z ;
   }

   [DataContract(Name = @"core\regiao", Namespace = "agl_tresorygroup")]
   public class Sdtregiao_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.Sdtregiao>
   {
      public Sdtregiao_RESTInterface( ) : base()
      {
      }

      public Sdtregiao_RESTInterface( GeneXus.Programs.core.Sdtregiao psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "RegiaoID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Regiaoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Regiaoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Regiaoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "RegiaoSigla" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Regiaosigla
      {
         get {
            return sdt.gxTpr_Regiaosigla ;
         }

         set {
            sdt.gxTpr_Regiaosigla = value;
         }

      }

      [DataMember( Name = "RegiaoNome" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Regiaonome
      {
         get {
            return sdt.gxTpr_Regiaonome ;
         }

         set {
            sdt.gxTpr_Regiaonome = value;
         }

      }

      [DataMember( Name = "RegiaoSiglaNome" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Regiaosiglanome
      {
         get {
            return sdt.gxTpr_Regiaosiglanome ;
         }

         set {
            sdt.gxTpr_Regiaosiglanome = value;
         }

      }

      public GeneXus.Programs.core.Sdtregiao sdt
      {
         get {
            return (GeneXus.Programs.core.Sdtregiao)Sdt ;
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
            sdt = new GeneXus.Programs.core.Sdtregiao() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 4 )]
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

   [DataContract(Name = @"core\regiao", Namespace = "agl_tresorygroup")]
   public class Sdtregiao_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.Sdtregiao>
   {
      public Sdtregiao_RESTLInterface( ) : base()
      {
      }

      public Sdtregiao_RESTLInterface( GeneXus.Programs.core.Sdtregiao psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "RegiaoSigla" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Regiaosigla
      {
         get {
            return sdt.gxTpr_Regiaosigla ;
         }

         set {
            sdt.gxTpr_Regiaosigla = value;
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

      public GeneXus.Programs.core.Sdtregiao sdt
      {
         get {
            return (GeneXus.Programs.core.Sdtregiao)Sdt ;
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
            sdt = new GeneXus.Programs.core.Sdtregiao() ;
         }
      }

   }

}
