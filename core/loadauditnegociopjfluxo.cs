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
namespace GeneXus.Programs.core {
   public class loadauditnegociopjfluxo : GXProcedure
   {
      public loadauditnegociopjfluxo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadauditnegociopjfluxo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SaveOldValues ,
                           ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                           Guid aP2_NegID ,
                           string aP3_NefChave ,
                           string aP4_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17NegID = aP2_NegID;
         this.AV18NefChave = aP3_NefChave;
         this.AV15ActualMode = aP4_ActualMode;
         initialize();
         executePrivate();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                                 Guid aP2_NegID ,
                                 string aP3_NefChave ,
                                 string aP4_ActualMode )
      {
         loadauditnegociopjfluxo objloadauditnegociopjfluxo;
         objloadauditnegociopjfluxo = new loadauditnegociopjfluxo();
         objloadauditnegociopjfluxo.AV14SaveOldValues = aP0_SaveOldValues;
         objloadauditnegociopjfluxo.AV11AuditingObject = aP1_AuditingObject;
         objloadauditnegociopjfluxo.AV17NegID = aP2_NegID;
         objloadauditnegociopjfluxo.AV18NefChave = aP3_NefChave;
         objloadauditnegociopjfluxo.AV15ActualMode = aP4_ActualMode;
         objloadauditnegociopjfluxo.context.SetSubmitInitialConfig(context);
         objloadauditnegociopjfluxo.initialize();
         Submit( executePrivateCatch,objloadauditnegociopjfluxo);
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadauditnegociopjfluxo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV14SaveOldValues, "Y") == 0 )
         {
            if ( ( StringUtil.StrCmp(AV15ActualMode, "DLT") == 0 ) || ( StringUtil.StrCmp(AV15ActualMode, "UPD") == 0 ) )
            {
               /* Execute user subroutine: 'LOADOLDVALUES' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
         }
         else
         {
            /* Execute user subroutine: 'LOADNEWVALUES' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADOLDVALUES' Routine */
         returnInSub = false;
         /* Using cursor P007X2 */
         pr_default.execute(0, new Object[] {AV17NegID, AV18NefChave});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A626NefChave = P007X2_A626NefChave[0];
            A345NegID = P007X2_A345NegID[0];
            A627NefConfirmado = P007X2_A627NefConfirmado[0];
            A628NefTexto = P007X2_A628NefTexto[0];
            n628NefTexto = P007X2_n628NefTexto[0];
            A629NefInsDataHora = P007X2_A629NefInsDataHora[0];
            A630NefInsData = P007X2_A630NefInsData[0];
            A631NefInsHora = P007X2_A631NefInsHora[0];
            A632NefInsUsuId = P007X2_A632NefInsUsuId[0];
            A633NefInsUsuNome = P007X2_A633NefInsUsuNome[0];
            A634NefUpdDataHora = P007X2_A634NefUpdDataHora[0];
            n634NefUpdDataHora = P007X2_n634NefUpdDataHora[0];
            A635NefUpdData = P007X2_A635NefUpdData[0];
            n635NefUpdData = P007X2_n635NefUpdData[0];
            A636NefUpdHora = P007X2_A636NefUpdHora[0];
            n636NefUpdHora = P007X2_n636NefUpdHora[0];
            A637NefUpdUsuId = P007X2_A637NefUpdUsuId[0];
            n637NefUpdUsuId = P007X2_n637NefUpdUsuId[0];
            A638NefUpdUsuNome = P007X2_A638NefUpdUsuNome[0];
            n638NefUpdUsuNome = P007X2_n638NefUpdUsuNome[0];
            A639NefValor = P007X2_A639NefValor[0];
            n639NefValor = P007X2_n639NefValor[0];
            AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
            AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
            AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
            AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_negociopj_fluxo";
            AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
            AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Oportunidade de Negócio";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A345NegID.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefChave";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "do Fluxo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A626NefChave;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefConfirmado";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Confirmado?";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A627NefConfirmado);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefTexto";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Texto";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A628NefTexto;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefInsDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído em";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A629NefInsDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefInsData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído em";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A630NefInsData, 10, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefInsHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído às";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A631NefInsHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefInsUsuId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído por";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A632NefInsUsuId;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefInsUsuNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído por";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A633NefInsUsuNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefUpdDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Alterado em";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A634NefUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefUpdData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Alterado em";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A635NefUpdData, 10, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefUpdHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Alterado às";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A636NefUpdHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefUpdUsuId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Alterado por";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A637NefUpdUsuId;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefUpdUsuNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Alterado por";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A638NefUpdUsuNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefValor";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Valor";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A639NefValor), 3, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      protected void S121( )
      {
         /* 'LOADNEWVALUES' Routine */
         returnInSub = false;
         /* Using cursor P007X3 */
         pr_default.execute(1, new Object[] {AV17NegID, AV18NefChave});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A626NefChave = P007X3_A626NefChave[0];
            A345NegID = P007X3_A345NegID[0];
            A627NefConfirmado = P007X3_A627NefConfirmado[0];
            A628NefTexto = P007X3_A628NefTexto[0];
            n628NefTexto = P007X3_n628NefTexto[0];
            A629NefInsDataHora = P007X3_A629NefInsDataHora[0];
            A630NefInsData = P007X3_A630NefInsData[0];
            A631NefInsHora = P007X3_A631NefInsHora[0];
            A632NefInsUsuId = P007X3_A632NefInsUsuId[0];
            A633NefInsUsuNome = P007X3_A633NefInsUsuNome[0];
            A634NefUpdDataHora = P007X3_A634NefUpdDataHora[0];
            n634NefUpdDataHora = P007X3_n634NefUpdDataHora[0];
            A635NefUpdData = P007X3_A635NefUpdData[0];
            n635NefUpdData = P007X3_n635NefUpdData[0];
            A636NefUpdHora = P007X3_A636NefUpdHora[0];
            n636NefUpdHora = P007X3_n636NefUpdHora[0];
            A637NefUpdUsuId = P007X3_A637NefUpdUsuId[0];
            n637NefUpdUsuId = P007X3_n637NefUpdUsuId[0];
            A638NefUpdUsuNome = P007X3_A638NefUpdUsuNome[0];
            n638NefUpdUsuNome = P007X3_n638NefUpdUsuNome[0];
            A639NefValor = P007X3_A639NefValor[0];
            n639NefValor = P007X3_n639NefValor[0];
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_negociopj_fluxo";
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Oportunidade de Negócio";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A345NegID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefChave";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "do Fluxo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A626NefChave;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefConfirmado";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Confirmado?";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A627NefConfirmado);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefTexto";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Texto";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A628NefTexto;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefInsDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído em";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A629NefInsDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefInsData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído em";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A630NefInsData, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefInsHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído às";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A631NefInsHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefInsUsuId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído por";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A632NefInsUsuId;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefInsUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído por";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A633NefInsUsuNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefUpdDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Alterado em";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A634NefUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefUpdData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Alterado em";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A635NefUpdData, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefUpdHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Alterado às";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A636NefUpdHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefUpdUsuId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Alterado por";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A637NefUpdUsuId;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefUpdUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Alterado por";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A638NefUpdUsuNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NefValor";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Valor";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A639NefValor), 3, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            }
            if ( StringUtil.StrCmp(AV15ActualMode, "UPD") == 0 )
            {
               AV21GXV1 = 1;
               while ( AV21GXV1 <= AV11AuditingObject.gxTpr_Record.Count )
               {
                  AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV11AuditingObject.gxTpr_Record.Item(AV21GXV1));
                  AV22GXV2 = 1;
                  while ( AV22GXV2 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                  {
                     AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV22GXV2));
                     if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A345NegID.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NefChave") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A626NefChave;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NefConfirmado") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A627NefConfirmado);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NefTexto") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A628NefTexto;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NefInsDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A629NefInsDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NefInsData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A630NefInsData, 10, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NefInsHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A631NefInsHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NefInsUsuId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A632NefInsUsuId;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NefInsUsuNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A633NefInsUsuNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NefUpdDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A634NefUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NefUpdData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A635NefUpdData, 10, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NefUpdHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A636NefUpdHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NefUpdUsuId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A637NefUpdUsuId;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NefUpdUsuNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A638NefUpdUsuNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NefValor") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A639NefValor), 3, 0);
                     }
                     AV22GXV2 = (int)(AV22GXV2+1);
                  }
                  AV21GXV1 = (int)(AV21GXV1+1);
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
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
         scmdbuf = "";
         P007X2_A626NefChave = new string[] {""} ;
         P007X2_A345NegID = new Guid[] {Guid.Empty} ;
         P007X2_A627NefConfirmado = new bool[] {false} ;
         P007X2_A628NefTexto = new string[] {""} ;
         P007X2_n628NefTexto = new bool[] {false} ;
         P007X2_A629NefInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007X2_A630NefInsData = new DateTime[] {DateTime.MinValue} ;
         P007X2_A631NefInsHora = new DateTime[] {DateTime.MinValue} ;
         P007X2_A632NefInsUsuId = new string[] {""} ;
         P007X2_A633NefInsUsuNome = new string[] {""} ;
         P007X2_A634NefUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P007X2_n634NefUpdDataHora = new bool[] {false} ;
         P007X2_A635NefUpdData = new DateTime[] {DateTime.MinValue} ;
         P007X2_n635NefUpdData = new bool[] {false} ;
         P007X2_A636NefUpdHora = new DateTime[] {DateTime.MinValue} ;
         P007X2_n636NefUpdHora = new bool[] {false} ;
         P007X2_A637NefUpdUsuId = new string[] {""} ;
         P007X2_n637NefUpdUsuId = new bool[] {false} ;
         P007X2_A638NefUpdUsuNome = new string[] {""} ;
         P007X2_n638NefUpdUsuNome = new bool[] {false} ;
         P007X2_A639NefValor = new short[1] ;
         P007X2_n639NefValor = new bool[] {false} ;
         A626NefChave = "";
         A345NegID = Guid.Empty;
         A628NefTexto = "";
         A629NefInsDataHora = (DateTime)(DateTime.MinValue);
         A630NefInsData = (DateTime)(DateTime.MinValue);
         A631NefInsHora = (DateTime)(DateTime.MinValue);
         A632NefInsUsuId = "";
         A633NefInsUsuNome = "";
         A634NefUpdDataHora = (DateTime)(DateTime.MinValue);
         A635NefUpdData = (DateTime)(DateTime.MinValue);
         A636NefUpdHora = (DateTime)(DateTime.MinValue);
         A637NefUpdUsuId = "";
         A638NefUpdUsuNome = "";
         AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P007X3_A626NefChave = new string[] {""} ;
         P007X3_A345NegID = new Guid[] {Guid.Empty} ;
         P007X3_A627NefConfirmado = new bool[] {false} ;
         P007X3_A628NefTexto = new string[] {""} ;
         P007X3_n628NefTexto = new bool[] {false} ;
         P007X3_A629NefInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007X3_A630NefInsData = new DateTime[] {DateTime.MinValue} ;
         P007X3_A631NefInsHora = new DateTime[] {DateTime.MinValue} ;
         P007X3_A632NefInsUsuId = new string[] {""} ;
         P007X3_A633NefInsUsuNome = new string[] {""} ;
         P007X3_A634NefUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P007X3_n634NefUpdDataHora = new bool[] {false} ;
         P007X3_A635NefUpdData = new DateTime[] {DateTime.MinValue} ;
         P007X3_n635NefUpdData = new bool[] {false} ;
         P007X3_A636NefUpdHora = new DateTime[] {DateTime.MinValue} ;
         P007X3_n636NefUpdHora = new bool[] {false} ;
         P007X3_A637NefUpdUsuId = new string[] {""} ;
         P007X3_n637NefUpdUsuId = new bool[] {false} ;
         P007X3_A638NefUpdUsuNome = new string[] {""} ;
         P007X3_n638NefUpdUsuNome = new bool[] {false} ;
         P007X3_A639NefValor = new short[1] ;
         P007X3_n639NefValor = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.loadauditnegociopjfluxo__default(),
            new Object[][] {
                new Object[] {
               P007X2_A626NefChave, P007X2_A345NegID, P007X2_A627NefConfirmado, P007X2_A628NefTexto, P007X2_n628NefTexto, P007X2_A629NefInsDataHora, P007X2_A630NefInsData, P007X2_A631NefInsHora, P007X2_A632NefInsUsuId, P007X2_A633NefInsUsuNome,
               P007X2_A634NefUpdDataHora, P007X2_n634NefUpdDataHora, P007X2_A635NefUpdData, P007X2_n635NefUpdData, P007X2_A636NefUpdHora, P007X2_n636NefUpdHora, P007X2_A637NefUpdUsuId, P007X2_n637NefUpdUsuId, P007X2_A638NefUpdUsuNome, P007X2_n638NefUpdUsuNome,
               P007X2_A639NefValor, P007X2_n639NefValor
               }
               , new Object[] {
               P007X3_A626NefChave, P007X3_A345NegID, P007X3_A627NefConfirmado, P007X3_A628NefTexto, P007X3_n628NefTexto, P007X3_A629NefInsDataHora, P007X3_A630NefInsData, P007X3_A631NefInsHora, P007X3_A632NefInsUsuId, P007X3_A633NefInsUsuNome,
               P007X3_A634NefUpdDataHora, P007X3_n634NefUpdDataHora, P007X3_A635NefUpdData, P007X3_n635NefUpdData, P007X3_A636NefUpdHora, P007X3_n636NefUpdHora, P007X3_A637NefUpdUsuId, P007X3_n637NefUpdUsuId, P007X3_A638NefUpdUsuNome, P007X3_n638NefUpdUsuNome,
               P007X3_A639NefValor, P007X3_n639NefValor
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A639NefValor ;
      private int AV21GXV1 ;
      private int AV22GXV2 ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private string scmdbuf ;
      private string A632NefInsUsuId ;
      private string A637NefUpdUsuId ;
      private DateTime A629NefInsDataHora ;
      private DateTime A630NefInsData ;
      private DateTime A631NefInsHora ;
      private DateTime A634NefUpdDataHora ;
      private DateTime A635NefUpdData ;
      private DateTime A636NefUpdHora ;
      private bool returnInSub ;
      private bool A627NefConfirmado ;
      private bool n628NefTexto ;
      private bool n634NefUpdDataHora ;
      private bool n635NefUpdData ;
      private bool n636NefUpdHora ;
      private bool n637NefUpdUsuId ;
      private bool n638NefUpdUsuNome ;
      private bool n639NefValor ;
      private string AV18NefChave ;
      private string A626NefChave ;
      private string A628NefTexto ;
      private string A633NefInsUsuNome ;
      private string A638NefUpdUsuNome ;
      private Guid AV17NegID ;
      private Guid A345NegID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private string[] P007X2_A626NefChave ;
      private Guid[] P007X2_A345NegID ;
      private bool[] P007X2_A627NefConfirmado ;
      private string[] P007X2_A628NefTexto ;
      private bool[] P007X2_n628NefTexto ;
      private DateTime[] P007X2_A629NefInsDataHora ;
      private DateTime[] P007X2_A630NefInsData ;
      private DateTime[] P007X2_A631NefInsHora ;
      private string[] P007X2_A632NefInsUsuId ;
      private string[] P007X2_A633NefInsUsuNome ;
      private DateTime[] P007X2_A634NefUpdDataHora ;
      private bool[] P007X2_n634NefUpdDataHora ;
      private DateTime[] P007X2_A635NefUpdData ;
      private bool[] P007X2_n635NefUpdData ;
      private DateTime[] P007X2_A636NefUpdHora ;
      private bool[] P007X2_n636NefUpdHora ;
      private string[] P007X2_A637NefUpdUsuId ;
      private bool[] P007X2_n637NefUpdUsuId ;
      private string[] P007X2_A638NefUpdUsuNome ;
      private bool[] P007X2_n638NefUpdUsuNome ;
      private short[] P007X2_A639NefValor ;
      private bool[] P007X2_n639NefValor ;
      private string[] P007X3_A626NefChave ;
      private Guid[] P007X3_A345NegID ;
      private bool[] P007X3_A627NefConfirmado ;
      private string[] P007X3_A628NefTexto ;
      private bool[] P007X3_n628NefTexto ;
      private DateTime[] P007X3_A629NefInsDataHora ;
      private DateTime[] P007X3_A630NefInsData ;
      private DateTime[] P007X3_A631NefInsHora ;
      private string[] P007X3_A632NefInsUsuId ;
      private string[] P007X3_A633NefInsUsuNome ;
      private DateTime[] P007X3_A634NefUpdDataHora ;
      private bool[] P007X3_n634NefUpdDataHora ;
      private DateTime[] P007X3_A635NefUpdData ;
      private bool[] P007X3_n635NefUpdData ;
      private DateTime[] P007X3_A636NefUpdHora ;
      private bool[] P007X3_n636NefUpdHora ;
      private string[] P007X3_A637NefUpdUsuId ;
      private bool[] P007X3_n637NefUpdUsuId ;
      private string[] P007X3_A638NefUpdUsuNome ;
      private bool[] P007X3_n638NefUpdUsuNome ;
      private short[] P007X3_A639NefValor ;
      private bool[] P007X3_n639NefValor ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV11AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
   }

   public class loadauditnegociopjfluxo__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007X2;
          prmP007X2 = new Object[] {
          new ParDef("AV17NegID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18NefChave",GXType.VarChar,100,0)
          };
          Object[] prmP007X3;
          prmP007X3 = new Object[] {
          new ParDef("AV17NegID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18NefChave",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007X2", "SELECT NefChave, NegID, NefConfirmado, NefTexto, NefInsDataHora, NefInsData, NefInsHora, NefInsUsuId, NefInsUsuNome, NefUpdDataHora, NefUpdData, NefUpdHora, NefUpdUsuId, NefUpdUsuNome, NefValor FROM tb_negociopj_fluxo WHERE NegID = :AV17NegID and NefChave = ( :AV18NefChave) ORDER BY NegID, NefChave ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007X2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007X3", "SELECT NefChave, NegID, NefConfirmado, NefTexto, NefInsDataHora, NefInsData, NefInsHora, NefInsUsuId, NefInsUsuNome, NefUpdDataHora, NefUpdData, NefUpdHora, NefUpdUsuId, NefUpdUsuNome, NefValor FROM tb_negociopj_fluxo WHERE NegID = :AV17NegID and NefChave = ( :AV18NefChave) ORDER BY NegID, NefChave ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007X3,1, GxCacheFrequency.OFF ,false,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5, true);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 40);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(10, true);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((string[]) buf[16])[0] = rslt.getString(13, 40);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                ((string[]) buf[18])[0] = rslt.getVarchar(14);
                ((bool[]) buf[19])[0] = rslt.wasNull(14);
                ((short[]) buf[20])[0] = rslt.getShort(15);
                ((bool[]) buf[21])[0] = rslt.wasNull(15);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5, true);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 40);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(10, true);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((string[]) buf[16])[0] = rslt.getString(13, 40);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                ((string[]) buf[18])[0] = rslt.getVarchar(14);
                ((bool[]) buf[19])[0] = rslt.wasNull(14);
                ((short[]) buf[20])[0] = rslt.getShort(15);
                ((bool[]) buf[21])[0] = rslt.wasNull(15);
                return;
       }
    }

 }

}
