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
   [XmlRoot(ElementName = "Audit" )]
   [XmlType(TypeName =  "Audit" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class SdtAudit : GxSilentTrnSdt
   {
      public SdtAudit( )
      {
      }

      public SdtAudit( IGxContext context )
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

      public void Load( Guid AV493AuditID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV493AuditID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"AuditID", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "core\\Audit");
         metadata.Set("BT", "tb_audit");
         metadata.Set("PK", "[ \"AuditID\" ]");
         metadata.Set("PKAssigned", "[ \"AuditID\" ]");
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
         state.Add("gxTpr_Auditid_Z");
         state.Add("gxTpr_Auditdate_Z_Nullable");
         state.Add("gxTpr_Audittime_Z_Nullable");
         state.Add("gxTpr_Auditdatetime_Z_Nullable");
         state.Add("gxTpr_Audittablename_Z");
         state.Add("gxTpr_Auditshortdescription_Z");
         state.Add("gxTpr_Auditgamuserid_Z");
         state.Add("gxTpr_Auditgamusername_Z");
         state.Add("gxTpr_Auditaction_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.SdtAudit sdt;
         sdt = (GeneXus.Programs.core.SdtAudit)(source);
         gxTv_SdtAudit_Auditid = sdt.gxTv_SdtAudit_Auditid ;
         gxTv_SdtAudit_Auditdate = sdt.gxTv_SdtAudit_Auditdate ;
         gxTv_SdtAudit_Audittime = sdt.gxTv_SdtAudit_Audittime ;
         gxTv_SdtAudit_Auditdatetime = sdt.gxTv_SdtAudit_Auditdatetime ;
         gxTv_SdtAudit_Audittablename = sdt.gxTv_SdtAudit_Audittablename ;
         gxTv_SdtAudit_Auditdescription = sdt.gxTv_SdtAudit_Auditdescription ;
         gxTv_SdtAudit_Auditshortdescription = sdt.gxTv_SdtAudit_Auditshortdescription ;
         gxTv_SdtAudit_Auditgamuserid = sdt.gxTv_SdtAudit_Auditgamuserid ;
         gxTv_SdtAudit_Auditgamusername = sdt.gxTv_SdtAudit_Auditgamusername ;
         gxTv_SdtAudit_Auditaction = sdt.gxTv_SdtAudit_Auditaction ;
         gxTv_SdtAudit_Mode = sdt.gxTv_SdtAudit_Mode ;
         gxTv_SdtAudit_Initialized = sdt.gxTv_SdtAudit_Initialized ;
         gxTv_SdtAudit_Auditid_Z = sdt.gxTv_SdtAudit_Auditid_Z ;
         gxTv_SdtAudit_Auditdate_Z = sdt.gxTv_SdtAudit_Auditdate_Z ;
         gxTv_SdtAudit_Audittime_Z = sdt.gxTv_SdtAudit_Audittime_Z ;
         gxTv_SdtAudit_Auditdatetime_Z = sdt.gxTv_SdtAudit_Auditdatetime_Z ;
         gxTv_SdtAudit_Audittablename_Z = sdt.gxTv_SdtAudit_Audittablename_Z ;
         gxTv_SdtAudit_Auditshortdescription_Z = sdt.gxTv_SdtAudit_Auditshortdescription_Z ;
         gxTv_SdtAudit_Auditgamuserid_Z = sdt.gxTv_SdtAudit_Auditgamuserid_Z ;
         gxTv_SdtAudit_Auditgamusername_Z = sdt.gxTv_SdtAudit_Auditgamusername_Z ;
         gxTv_SdtAudit_Auditaction_Z = sdt.gxTv_SdtAudit_Auditaction_Z ;
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
         AddObjectProperty("AuditID", gxTv_SdtAudit_Auditid, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtAudit_Auditdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtAudit_Auditdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtAudit_Auditdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("AuditDate", sDateCnv, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtAudit_Audittime;
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
         AddObjectProperty("AuditTime", sDateCnv, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtAudit_Auditdatetime;
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
         AddObjectProperty("AuditDateTime", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("AuditTableName", gxTv_SdtAudit_Audittablename, false, includeNonInitialized);
         AddObjectProperty("AuditDescription", gxTv_SdtAudit_Auditdescription, false, includeNonInitialized);
         AddObjectProperty("AuditShortDescription", gxTv_SdtAudit_Auditshortdescription, false, includeNonInitialized);
         AddObjectProperty("AuditGAMUserID", gxTv_SdtAudit_Auditgamuserid, false, includeNonInitialized);
         AddObjectProperty("AuditGAMUserName", gxTv_SdtAudit_Auditgamusername, false, includeNonInitialized);
         AddObjectProperty("AuditAction", gxTv_SdtAudit_Auditaction, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtAudit_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtAudit_Initialized, false, includeNonInitialized);
            AddObjectProperty("AuditID_Z", gxTv_SdtAudit_Auditid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtAudit_Auditdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtAudit_Auditdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtAudit_Auditdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("AuditDate_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtAudit_Audittime_Z;
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
            AddObjectProperty("AuditTime_Z", sDateCnv, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtAudit_Auditdatetime_Z;
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
            AddObjectProperty("AuditDateTime_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("AuditTableName_Z", gxTv_SdtAudit_Audittablename_Z, false, includeNonInitialized);
            AddObjectProperty("AuditShortDescription_Z", gxTv_SdtAudit_Auditshortdescription_Z, false, includeNonInitialized);
            AddObjectProperty("AuditGAMUserID_Z", gxTv_SdtAudit_Auditgamuserid_Z, false, includeNonInitialized);
            AddObjectProperty("AuditGAMUserName_Z", gxTv_SdtAudit_Auditgamusername_Z, false, includeNonInitialized);
            AddObjectProperty("AuditAction_Z", gxTv_SdtAudit_Auditaction_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.SdtAudit sdt )
      {
         if ( sdt.IsDirty("AuditID") )
         {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditid = sdt.gxTv_SdtAudit_Auditid ;
         }
         if ( sdt.IsDirty("AuditDate") )
         {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditdate = sdt.gxTv_SdtAudit_Auditdate ;
         }
         if ( sdt.IsDirty("AuditTime") )
         {
            sdtIsNull = 0;
            gxTv_SdtAudit_Audittime = sdt.gxTv_SdtAudit_Audittime ;
         }
         if ( sdt.IsDirty("AuditDateTime") )
         {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditdatetime = sdt.gxTv_SdtAudit_Auditdatetime ;
         }
         if ( sdt.IsDirty("AuditTableName") )
         {
            sdtIsNull = 0;
            gxTv_SdtAudit_Audittablename = sdt.gxTv_SdtAudit_Audittablename ;
         }
         if ( sdt.IsDirty("AuditDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditdescription = sdt.gxTv_SdtAudit_Auditdescription ;
         }
         if ( sdt.IsDirty("AuditShortDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditshortdescription = sdt.gxTv_SdtAudit_Auditshortdescription ;
         }
         if ( sdt.IsDirty("AuditGAMUserID") )
         {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditgamuserid = sdt.gxTv_SdtAudit_Auditgamuserid ;
         }
         if ( sdt.IsDirty("AuditGAMUserName") )
         {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditgamusername = sdt.gxTv_SdtAudit_Auditgamusername ;
         }
         if ( sdt.IsDirty("AuditAction") )
         {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditaction = sdt.gxTv_SdtAudit_Auditaction ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "AuditID" )]
      [  XmlElement( ElementName = "AuditID"   )]
      public Guid gxTpr_Auditid
      {
         get {
            return gxTv_SdtAudit_Auditid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtAudit_Auditid != value )
            {
               gxTv_SdtAudit_Mode = "INS";
               this.gxTv_SdtAudit_Auditid_Z_SetNull( );
               this.gxTv_SdtAudit_Auditdate_Z_SetNull( );
               this.gxTv_SdtAudit_Audittime_Z_SetNull( );
               this.gxTv_SdtAudit_Auditdatetime_Z_SetNull( );
               this.gxTv_SdtAudit_Audittablename_Z_SetNull( );
               this.gxTv_SdtAudit_Auditshortdescription_Z_SetNull( );
               this.gxTv_SdtAudit_Auditgamuserid_Z_SetNull( );
               this.gxTv_SdtAudit_Auditgamusername_Z_SetNull( );
               this.gxTv_SdtAudit_Auditaction_Z_SetNull( );
            }
            gxTv_SdtAudit_Auditid = value;
            SetDirty("Auditid");
         }

      }

      [  SoapElement( ElementName = "AuditDate" )]
      [  XmlElement( ElementName = "AuditDate"  , IsNullable=true )]
      public string gxTpr_Auditdate_Nullable
      {
         get {
            if ( gxTv_SdtAudit_Auditdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtAudit_Auditdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtAudit_Auditdate = DateTime.MinValue;
            else
               gxTv_SdtAudit_Auditdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Auditdate
      {
         get {
            return gxTv_SdtAudit_Auditdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditdate = value;
            SetDirty("Auditdate");
         }

      }

      [  SoapElement( ElementName = "AuditTime" )]
      [  XmlElement( ElementName = "AuditTime"  , IsNullable=true )]
      public string gxTpr_Audittime_Nullable
      {
         get {
            if ( gxTv_SdtAudit_Audittime == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtAudit_Audittime).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtAudit_Audittime = DateTime.MinValue;
            else
               gxTv_SdtAudit_Audittime = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Audittime
      {
         get {
            return gxTv_SdtAudit_Audittime ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Audittime = value;
            SetDirty("Audittime");
         }

      }

      [  SoapElement( ElementName = "AuditDateTime" )]
      [  XmlElement( ElementName = "AuditDateTime"  , IsNullable=true )]
      public string gxTpr_Auditdatetime_Nullable
      {
         get {
            if ( gxTv_SdtAudit_Auditdatetime == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtAudit_Auditdatetime, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtAudit_Auditdatetime = DateTime.MinValue;
            else
               gxTv_SdtAudit_Auditdatetime = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Auditdatetime
      {
         get {
            return gxTv_SdtAudit_Auditdatetime ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditdatetime = value;
            SetDirty("Auditdatetime");
         }

      }

      [  SoapElement( ElementName = "AuditTableName" )]
      [  XmlElement( ElementName = "AuditTableName"   )]
      public string gxTpr_Audittablename
      {
         get {
            return gxTv_SdtAudit_Audittablename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Audittablename = value;
            SetDirty("Audittablename");
         }

      }

      [  SoapElement( ElementName = "AuditDescription" )]
      [  XmlElement( ElementName = "AuditDescription"   )]
      public string gxTpr_Auditdescription
      {
         get {
            return gxTv_SdtAudit_Auditdescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditdescription = value;
            SetDirty("Auditdescription");
         }

      }

      [  SoapElement( ElementName = "AuditShortDescription" )]
      [  XmlElement( ElementName = "AuditShortDescription"   )]
      public string gxTpr_Auditshortdescription
      {
         get {
            return gxTv_SdtAudit_Auditshortdescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditshortdescription = value;
            SetDirty("Auditshortdescription");
         }

      }

      [  SoapElement( ElementName = "AuditGAMUserID" )]
      [  XmlElement( ElementName = "AuditGAMUserID"   )]
      public string gxTpr_Auditgamuserid
      {
         get {
            return gxTv_SdtAudit_Auditgamuserid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditgamuserid = value;
            SetDirty("Auditgamuserid");
         }

      }

      [  SoapElement( ElementName = "AuditGAMUserName" )]
      [  XmlElement( ElementName = "AuditGAMUserName"   )]
      public string gxTpr_Auditgamusername
      {
         get {
            return gxTv_SdtAudit_Auditgamusername ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditgamusername = value;
            SetDirty("Auditgamusername");
         }

      }

      [  SoapElement( ElementName = "AuditAction" )]
      [  XmlElement( ElementName = "AuditAction"   )]
      public string gxTpr_Auditaction
      {
         get {
            return gxTv_SdtAudit_Auditaction ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditaction = value;
            SetDirty("Auditaction");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtAudit_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtAudit_Mode_SetNull( )
      {
         gxTv_SdtAudit_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtAudit_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtAudit_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtAudit_Initialized_SetNull( )
      {
         gxTv_SdtAudit_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtAudit_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditID_Z" )]
      [  XmlElement( ElementName = "AuditID_Z"   )]
      public Guid gxTpr_Auditid_Z
      {
         get {
            return gxTv_SdtAudit_Auditid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditid_Z = value;
            SetDirty("Auditid_Z");
         }

      }

      public void gxTv_SdtAudit_Auditid_Z_SetNull( )
      {
         gxTv_SdtAudit_Auditid_Z = Guid.Empty;
         SetDirty("Auditid_Z");
         return  ;
      }

      public bool gxTv_SdtAudit_Auditid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditDate_Z" )]
      [  XmlElement( ElementName = "AuditDate_Z"  , IsNullable=true )]
      public string gxTpr_Auditdate_Z_Nullable
      {
         get {
            if ( gxTv_SdtAudit_Auditdate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtAudit_Auditdate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtAudit_Auditdate_Z = DateTime.MinValue;
            else
               gxTv_SdtAudit_Auditdate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Auditdate_Z
      {
         get {
            return gxTv_SdtAudit_Auditdate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditdate_Z = value;
            SetDirty("Auditdate_Z");
         }

      }

      public void gxTv_SdtAudit_Auditdate_Z_SetNull( )
      {
         gxTv_SdtAudit_Auditdate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Auditdate_Z");
         return  ;
      }

      public bool gxTv_SdtAudit_Auditdate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditTime_Z" )]
      [  XmlElement( ElementName = "AuditTime_Z"  , IsNullable=true )]
      public string gxTpr_Audittime_Z_Nullable
      {
         get {
            if ( gxTv_SdtAudit_Audittime_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtAudit_Audittime_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtAudit_Audittime_Z = DateTime.MinValue;
            else
               gxTv_SdtAudit_Audittime_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Audittime_Z
      {
         get {
            return gxTv_SdtAudit_Audittime_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Audittime_Z = value;
            SetDirty("Audittime_Z");
         }

      }

      public void gxTv_SdtAudit_Audittime_Z_SetNull( )
      {
         gxTv_SdtAudit_Audittime_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Audittime_Z");
         return  ;
      }

      public bool gxTv_SdtAudit_Audittime_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditDateTime_Z" )]
      [  XmlElement( ElementName = "AuditDateTime_Z"  , IsNullable=true )]
      public string gxTpr_Auditdatetime_Z_Nullable
      {
         get {
            if ( gxTv_SdtAudit_Auditdatetime_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtAudit_Auditdatetime_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtAudit_Auditdatetime_Z = DateTime.MinValue;
            else
               gxTv_SdtAudit_Auditdatetime_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Auditdatetime_Z
      {
         get {
            return gxTv_SdtAudit_Auditdatetime_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditdatetime_Z = value;
            SetDirty("Auditdatetime_Z");
         }

      }

      public void gxTv_SdtAudit_Auditdatetime_Z_SetNull( )
      {
         gxTv_SdtAudit_Auditdatetime_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Auditdatetime_Z");
         return  ;
      }

      public bool gxTv_SdtAudit_Auditdatetime_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditTableName_Z" )]
      [  XmlElement( ElementName = "AuditTableName_Z"   )]
      public string gxTpr_Audittablename_Z
      {
         get {
            return gxTv_SdtAudit_Audittablename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Audittablename_Z = value;
            SetDirty("Audittablename_Z");
         }

      }

      public void gxTv_SdtAudit_Audittablename_Z_SetNull( )
      {
         gxTv_SdtAudit_Audittablename_Z = "";
         SetDirty("Audittablename_Z");
         return  ;
      }

      public bool gxTv_SdtAudit_Audittablename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditShortDescription_Z" )]
      [  XmlElement( ElementName = "AuditShortDescription_Z"   )]
      public string gxTpr_Auditshortdescription_Z
      {
         get {
            return gxTv_SdtAudit_Auditshortdescription_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditshortdescription_Z = value;
            SetDirty("Auditshortdescription_Z");
         }

      }

      public void gxTv_SdtAudit_Auditshortdescription_Z_SetNull( )
      {
         gxTv_SdtAudit_Auditshortdescription_Z = "";
         SetDirty("Auditshortdescription_Z");
         return  ;
      }

      public bool gxTv_SdtAudit_Auditshortdescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditGAMUserID_Z" )]
      [  XmlElement( ElementName = "AuditGAMUserID_Z"   )]
      public string gxTpr_Auditgamuserid_Z
      {
         get {
            return gxTv_SdtAudit_Auditgamuserid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditgamuserid_Z = value;
            SetDirty("Auditgamuserid_Z");
         }

      }

      public void gxTv_SdtAudit_Auditgamuserid_Z_SetNull( )
      {
         gxTv_SdtAudit_Auditgamuserid_Z = "";
         SetDirty("Auditgamuserid_Z");
         return  ;
      }

      public bool gxTv_SdtAudit_Auditgamuserid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditGAMUserName_Z" )]
      [  XmlElement( ElementName = "AuditGAMUserName_Z"   )]
      public string gxTpr_Auditgamusername_Z
      {
         get {
            return gxTv_SdtAudit_Auditgamusername_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditgamusername_Z = value;
            SetDirty("Auditgamusername_Z");
         }

      }

      public void gxTv_SdtAudit_Auditgamusername_Z_SetNull( )
      {
         gxTv_SdtAudit_Auditgamusername_Z = "";
         SetDirty("Auditgamusername_Z");
         return  ;
      }

      public bool gxTv_SdtAudit_Auditgamusername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditAction_Z" )]
      [  XmlElement( ElementName = "AuditAction_Z"   )]
      public string gxTpr_Auditaction_Z
      {
         get {
            return gxTv_SdtAudit_Auditaction_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditaction_Z = value;
            SetDirty("Auditaction_Z");
         }

      }

      public void gxTv_SdtAudit_Auditaction_Z_SetNull( )
      {
         gxTv_SdtAudit_Auditaction_Z = "";
         SetDirty("Auditaction_Z");
         return  ;
      }

      public bool gxTv_SdtAudit_Auditaction_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtAudit_Auditid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtAudit_Auditdate = DateTime.MinValue;
         gxTv_SdtAudit_Audittime = (DateTime)(DateTime.MinValue);
         gxTv_SdtAudit_Auditdatetime = (DateTime)(DateTime.MinValue);
         gxTv_SdtAudit_Audittablename = "";
         gxTv_SdtAudit_Auditdescription = "";
         gxTv_SdtAudit_Auditshortdescription = "";
         gxTv_SdtAudit_Auditgamuserid = "";
         gxTv_SdtAudit_Auditgamusername = "";
         gxTv_SdtAudit_Auditaction = "";
         gxTv_SdtAudit_Mode = "";
         gxTv_SdtAudit_Auditid_Z = Guid.Empty;
         gxTv_SdtAudit_Auditdate_Z = DateTime.MinValue;
         gxTv_SdtAudit_Audittime_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtAudit_Auditdatetime_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtAudit_Audittablename_Z = "";
         gxTv_SdtAudit_Auditshortdescription_Z = "";
         gxTv_SdtAudit_Auditgamuserid_Z = "";
         gxTv_SdtAudit_Auditgamusername_Z = "";
         gxTv_SdtAudit_Auditaction_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "core.audit", "GeneXus.Programs.core.audit_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtAudit_Initialized ;
      private string gxTv_SdtAudit_Auditgamuserid ;
      private string gxTv_SdtAudit_Mode ;
      private string gxTv_SdtAudit_Auditgamuserid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtAudit_Audittime ;
      private DateTime gxTv_SdtAudit_Auditdatetime ;
      private DateTime gxTv_SdtAudit_Audittime_Z ;
      private DateTime gxTv_SdtAudit_Auditdatetime_Z ;
      private DateTime datetime_STZ ;
      private DateTime datetimemil_STZ ;
      private DateTime gxTv_SdtAudit_Auditdate ;
      private DateTime gxTv_SdtAudit_Auditdate_Z ;
      private string gxTv_SdtAudit_Auditdescription ;
      private string gxTv_SdtAudit_Audittablename ;
      private string gxTv_SdtAudit_Auditshortdescription ;
      private string gxTv_SdtAudit_Auditgamusername ;
      private string gxTv_SdtAudit_Auditaction ;
      private string gxTv_SdtAudit_Audittablename_Z ;
      private string gxTv_SdtAudit_Auditshortdescription_Z ;
      private string gxTv_SdtAudit_Auditgamusername_Z ;
      private string gxTv_SdtAudit_Auditaction_Z ;
      private Guid gxTv_SdtAudit_Auditid ;
      private Guid gxTv_SdtAudit_Auditid_Z ;
   }

   [DataContract(Name = @"core\Audit", Namespace = "agl_tresorygroup")]
   public class SdtAudit_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtAudit>
   {
      public SdtAudit_RESTInterface( ) : base()
      {
      }

      public SdtAudit_RESTInterface( GeneXus.Programs.core.SdtAudit psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AuditID" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Auditid
      {
         get {
            return sdt.gxTpr_Auditid ;
         }

         set {
            sdt.gxTpr_Auditid = value;
         }

      }

      [DataMember( Name = "AuditDate" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Auditdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Auditdate) ;
         }

         set {
            sdt.gxTpr_Auditdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "AuditTime" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Audittime
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Audittime) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Audittime = GXt_dtime1;
         }

      }

      [DataMember( Name = "AuditDateTime" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Auditdatetime
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Auditdatetime) ;
         }

         set {
            sdt.gxTpr_Auditdatetime = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "AuditTableName" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Audittablename
      {
         get {
            return sdt.gxTpr_Audittablename ;
         }

         set {
            sdt.gxTpr_Audittablename = value;
         }

      }

      [DataMember( Name = "AuditDescription" , Order = 5 )]
      public string gxTpr_Auditdescription
      {
         get {
            return sdt.gxTpr_Auditdescription ;
         }

         set {
            sdt.gxTpr_Auditdescription = value;
         }

      }

      [DataMember( Name = "AuditShortDescription" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Auditshortdescription
      {
         get {
            return sdt.gxTpr_Auditshortdescription ;
         }

         set {
            sdt.gxTpr_Auditshortdescription = value;
         }

      }

      [DataMember( Name = "AuditGAMUserID" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Auditgamuserid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Auditgamuserid) ;
         }

         set {
            sdt.gxTpr_Auditgamuserid = value;
         }

      }

      [DataMember( Name = "AuditGAMUserName" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Auditgamusername
      {
         get {
            return sdt.gxTpr_Auditgamusername ;
         }

         set {
            sdt.gxTpr_Auditgamusername = value;
         }

      }

      [DataMember( Name = "AuditAction" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Auditaction
      {
         get {
            return sdt.gxTpr_Auditaction ;
         }

         set {
            sdt.gxTpr_Auditaction = value;
         }

      }

      public GeneXus.Programs.core.SdtAudit sdt
      {
         get {
            return (GeneXus.Programs.core.SdtAudit)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtAudit() ;
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

   [DataContract(Name = @"core\Audit", Namespace = "agl_tresorygroup")]
   public class SdtAudit_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtAudit>
   {
      public SdtAudit_RESTLInterface( ) : base()
      {
      }

      public SdtAudit_RESTLInterface( GeneXus.Programs.core.SdtAudit psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AuditTableName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Audittablename
      {
         get {
            return sdt.gxTpr_Audittablename ;
         }

         set {
            sdt.gxTpr_Audittablename = value;
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

      public GeneXus.Programs.core.SdtAudit sdt
      {
         get {
            return (GeneXus.Programs.core.SdtAudit)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtAudit() ;
         }
      }

   }

}
