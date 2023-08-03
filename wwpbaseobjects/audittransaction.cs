using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects {
   public class audittransaction : GXProcedure
   {
      public audittransaction( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public audittransaction( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP0_AuditingObject ,
                           string aP1_CallerName )
      {
         this.AV8AuditingObject = aP0_AuditingObject;
         this.AV11CallerName = aP1_CallerName;
         initialize();
         executePrivate();
      }

      public void executeSubmit( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP0_AuditingObject ,
                                 string aP1_CallerName )
      {
         audittransaction objaudittransaction;
         objaudittransaction = new audittransaction();
         objaudittransaction.AV8AuditingObject = aP0_AuditingObject;
         objaudittransaction.AV11CallerName = aP1_CallerName;
         objaudittransaction.context.SetSubmitInitialConfig(context);
         objaudittransaction.initialize();
         Submit( executePrivateCatch,objaudittransaction);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((audittransaction)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV16WWPContext) ;
         AV15AuditPrimaryKey = "";
         AV17FirstRecord = true;
         AV19GXV1 = 1;
         while ( AV19GXV1 <= AV8AuditingObject.gxTpr_Record.Count )
         {
            AV9AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV8AuditingObject.gxTpr_Record.Item(AV19GXV1));
            AV12Audit = new GeneXus.Programs.core.SdtAudit(context);
            AV12Audit.gxTpr_Audittablename = AV9AuditingObjectRecordItem.gxTpr_Tablename;
            if ( AV17FirstRecord )
            {
               AV14AuditShortDescription = "Record with key '";
               AV13AuditDescription = "Record with key '";
               AV18ActualMode = AV8AuditingObject.gxTpr_Mode;
            }
            else
            {
               AV14AuditShortDescription = AV15AuditPrimaryKey;
               AV13AuditDescription = AV15AuditPrimaryKey;
               AV18ActualMode = AV9AuditingObjectRecordItem.gxTpr_Mode;
            }
            if ( StringUtil.StrCmp(AV18ActualMode, "INS") == 0 )
            {
               AV12Audit.gxTpr_Auditaction = "Insert";
            }
            else if ( StringUtil.StrCmp(AV18ActualMode, "UPD") == 0 )
            {
               AV12Audit.gxTpr_Auditaction = "Update";
            }
            else if ( StringUtil.StrCmp(AV18ActualMode, "DLT") == 0 )
            {
               AV12Audit.gxTpr_Auditaction = "Delete";
            }
            AV20GXV2 = 1;
            while ( AV20GXV2 <= AV9AuditingObjectRecordItem.gxTpr_Attribute.Count )
            {
               AV10AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV9AuditingObjectRecordItem.gxTpr_Attribute.Item(AV20GXV2));
               if ( AV10AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey )
               {
                  if ( StringUtil.StrCmp(AV18ActualMode, "INS") == 0 )
                  {
                     AV14AuditShortDescription += AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue + " ";
                     AV13AuditDescription += AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue + " ";
                  }
                  else
                  {
                     AV14AuditShortDescription += AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue + " ";
                     AV13AuditDescription += AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue + " ";
                  }
               }
               if ( AV10AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute )
               {
                  if ( StringUtil.StrCmp(AV18ActualMode, "INS") == 0 )
                  {
                     AV14AuditShortDescription += "- " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue + " ";
                     AV13AuditDescription += "- " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue + " ";
                  }
                  else
                  {
                     AV14AuditShortDescription += "- " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue + " ";
                     AV13AuditDescription += "- " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue + " ";
                  }
               }
               AV20GXV2 = (int)(AV20GXV2+1);
            }
            if ( AV17FirstRecord )
            {
               AV17FirstRecord = false;
               AV15AuditPrimaryKey = AV14AuditShortDescription;
            }
            AV14AuditShortDescription += "' was ";
            AV13AuditDescription += "' was ";
            if ( StringUtil.StrCmp(AV18ActualMode, "INS") == 0 )
            {
               AV14AuditShortDescription += "inserted";
               AV13AuditDescription += "inserted." + StringUtil.NewLine( ) + " Attributes:" + StringUtil.NewLine( );
            }
            else if ( StringUtil.StrCmp(AV18ActualMode, "UPD") == 0 )
            {
               AV14AuditShortDescription += "updated";
               AV13AuditDescription += "updated." + StringUtil.NewLine( ) + " Modified attributes:" + StringUtil.NewLine( );
            }
            else if ( StringUtil.StrCmp(AV18ActualMode, "DLT") == 0 )
            {
               AV14AuditShortDescription += "deleted";
               AV13AuditDescription += "deleted." + StringUtil.NewLine( ) + " Attributes:" + StringUtil.NewLine( );
            }
            AV14AuditShortDescription += ".";
            AV21GXV3 = 1;
            while ( AV21GXV3 <= AV9AuditingObjectRecordItem.gxTpr_Attribute.Count )
            {
               AV10AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV9AuditingObjectRecordItem.gxTpr_Attribute.Item(AV21GXV3));
               if ( ! ( AV10AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey ) )
               {
                  if ( StringUtil.StrCmp(AV18ActualMode, "INS") == 0 )
                  {
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue)) )
                     {
                        AV13AuditDescription += AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue + StringUtil.NewLine( );
                     }
                  }
                  else if ( StringUtil.StrCmp(AV18ActualMode, "UPD") == 0 )
                  {
                     if ( StringUtil.StrCmp(AV10AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue, AV10AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue) != 0 )
                     {
                        AV13AuditDescription += AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue + " (Old value = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue + ")" + StringUtil.NewLine( );
                     }
                  }
                  else if ( StringUtil.StrCmp(AV18ActualMode, "DLT") == 0 )
                  {
                     if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV10AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue)) ) )
                     {
                        AV13AuditDescription += AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue + StringUtil.NewLine( );
                     }
                  }
               }
               AV21GXV3 = (int)(AV21GXV3+1);
            }
            AV12Audit.gxTpr_Auditdescription = AV13AuditDescription;
            AV12Audit.gxTpr_Auditshortdescription = AV14AuditShortDescription;
            AV12Audit.Save();
            if ( AV12Audit.Success() )
            {
               context.CommitDataStores("wwpbaseobjects.audittransaction",pr_default);
            }
            AV19GXV1 = (int)(AV19GXV1+1);
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV16WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV15AuditPrimaryKey = "";
         AV9AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV12Audit = new GeneXus.Programs.core.SdtAudit(context);
         AV14AuditShortDescription = "";
         AV13AuditDescription = "";
         AV18ActualMode = "";
         AV10AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.audittransaction__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.audittransaction__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV19GXV1 ;
      private int AV20GXV2 ;
      private int AV21GXV3 ;
      private string AV18ActualMode ;
      private bool AV17FirstRecord ;
      private string AV13AuditDescription ;
      private string AV11CallerName ;
      private string AV15AuditPrimaryKey ;
      private string AV14AuditShortDescription ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV8AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV9AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV10AuditingObjectRecordItemAttributeItem ;
      private GeneXus.Programs.core.SdtAudit AV12Audit ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV16WWPContext ;
   }

   public class audittransaction__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class audittransaction__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

}

}
