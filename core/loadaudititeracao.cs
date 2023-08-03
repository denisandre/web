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
   public class loadaudititeracao : GXProcedure
   {
      public loadaudititeracao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadaudititeracao( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SaveOldValues ,
                           ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                           Guid aP2_IteID ,
                           string aP3_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17IteID = aP2_IteID;
         this.AV15ActualMode = aP3_ActualMode;
         initialize();
         executePrivate();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                                 Guid aP2_IteID ,
                                 string aP3_ActualMode )
      {
         loadaudititeracao objloadaudititeracao;
         objloadaudititeracao = new loadaudititeracao();
         objloadaudititeracao.AV14SaveOldValues = aP0_SaveOldValues;
         objloadaudititeracao.AV11AuditingObject = aP1_AuditingObject;
         objloadaudititeracao.AV17IteID = aP2_IteID;
         objloadaudititeracao.AV15ActualMode = aP3_ActualMode;
         objloadaudititeracao.context.SetSubmitInitialConfig(context);
         objloadaudititeracao.initialize();
         Submit( executePrivateCatch,objloadaudititeracao);
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadaudititeracao)stateInfo).executePrivate();
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
         /* Using cursor P00782 */
         pr_default.execute(0, new Object[] {AV17IteID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A382IteOrdem = P00782_A382IteOrdem[0];
            A383IteNome = P00782_A383IteNome[0];
            A384IteAtivo = P00782_A384IteAtivo[0];
            A590IteDel = P00782_A590IteDel[0];
            A591IteDelDataHora = P00782_A591IteDelDataHora[0];
            n591IteDelDataHora = P00782_n591IteDelDataHora[0];
            A592IteDelData = P00782_A592IteDelData[0];
            n592IteDelData = P00782_n592IteDelData[0];
            A593IteDelHora = P00782_A593IteDelHora[0];
            n593IteDelHora = P00782_n593IteDelHora[0];
            A594IteDelUsuId = P00782_A594IteDelUsuId[0];
            n594IteDelUsuId = P00782_n594IteDelUsuId[0];
            A595IteDelUsuNome = P00782_A595IteDelUsuNome[0];
            n595IteDelUsuNome = P00782_n595IteDelUsuNome[0];
            A381IteID = P00782_A381IteID[0];
            A432IteQtdeOportunidades = GetIteQtdeOportunidades0( A381IteID);
            A431IteTotalOportunidades = GetIteTotalOportunidades0( A381IteID);
            AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
            AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
            AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
            AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_Iteracao";
            AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
            AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A381IteID.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteOrdem";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ordem de Execução";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A382IteOrdem), 8, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A383IteNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteAtivo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ativo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A384IteAtivo);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteTotalOportunidades";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Total em Oportunidades";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( A431IteTotalOportunidades, 16, 2);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteQtdeOportunidades";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Quantidade de Oportunidades";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A432IteQtdeOportunidades), 8, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteDel";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A590IteDel);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteDelDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A591IteDelDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteDelData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A592IteDelData, 10, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteDelHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A593IteDelHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteDelUsuId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A594IteDelUsuId;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteDelUsuNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A595IteDelUsuNome;
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
         /* Using cursor P00783 */
         pr_default.execute(1, new Object[] {AV17IteID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A382IteOrdem = P00783_A382IteOrdem[0];
            A383IteNome = P00783_A383IteNome[0];
            A384IteAtivo = P00783_A384IteAtivo[0];
            A590IteDel = P00783_A590IteDel[0];
            A591IteDelDataHora = P00783_A591IteDelDataHora[0];
            n591IteDelDataHora = P00783_n591IteDelDataHora[0];
            A592IteDelData = P00783_A592IteDelData[0];
            n592IteDelData = P00783_n592IteDelData[0];
            A593IteDelHora = P00783_A593IteDelHora[0];
            n593IteDelHora = P00783_n593IteDelHora[0];
            A594IteDelUsuId = P00783_A594IteDelUsuId[0];
            n594IteDelUsuId = P00783_n594IteDelUsuId[0];
            A595IteDelUsuNome = P00783_A595IteDelUsuNome[0];
            n595IteDelUsuNome = P00783_n595IteDelUsuNome[0];
            A381IteID = P00783_A381IteID[0];
            A432IteQtdeOportunidades = GetIteQtdeOportunidades0( A381IteID);
            A431IteTotalOportunidades = GetIteTotalOportunidades0( A381IteID);
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_Iteracao";
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A381IteID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteOrdem";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ordem de Execução";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A382IteOrdem), 8, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A383IteNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteAtivo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ativo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A384IteAtivo);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteTotalOportunidades";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Total em Oportunidades";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A431IteTotalOportunidades, 16, 2);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteQtdeOportunidades";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Quantidade de Oportunidades";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A432IteQtdeOportunidades), 8, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteDel";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A590IteDel);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteDelDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A591IteDelDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteDelData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A592IteDelData, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteDelHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A593IteDelHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteDelUsuId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A594IteDelUsuId;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "IteDelUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A595IteDelUsuNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            }
            if ( StringUtil.StrCmp(AV15ActualMode, "UPD") == 0 )
            {
               AV20GXV1 = 1;
               while ( AV20GXV1 <= AV11AuditingObject.gxTpr_Record.Count )
               {
                  AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV11AuditingObject.gxTpr_Record.Item(AV20GXV1));
                  AV21GXV2 = 1;
                  while ( AV21GXV2 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                  {
                     AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV21GXV2));
                     if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "IteID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A381IteID.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "IteOrdem") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A382IteOrdem), 8, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "IteNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A383IteNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "IteAtivo") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A384IteAtivo);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "IteTotalOportunidades") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A431IteTotalOportunidades, 16, 2);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "IteQtdeOportunidades") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A432IteQtdeOportunidades), 8, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "IteDel") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A590IteDel);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "IteDelDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A591IteDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "IteDelData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A592IteDelData, 10, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "IteDelHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A593IteDelHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "IteDelUsuId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A594IteDelUsuId;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "IteDelUsuNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A595IteDelUsuNome;
                     }
                     AV21GXV2 = (int)(AV21GXV2+1);
                  }
                  AV20GXV1 = (int)(AV20GXV1+1);
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
      }

      protected decimal GetIteTotalOportunidades0( Guid E381IteID )
      {
         X385NegValorAtualizado = 0;
         /* Using cursor P00784 */
         pr_default.execute(2, new Object[] {E381IteID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            X385NegValorAtualizado = P00784_A385NegValorAtualizado[0];
         }
         pr_default.close(2);
         return X385NegValorAtualizado ;
      }

      protected int GetIteQtdeOportunidades0( Guid E381IteID )
      {
         Gx_cnt = 0;
         /* Using cursor P00785 */
         pr_default.execute(3, new Object[] {E381IteID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            Gx_cnt = P00785_Gx_cnt[0];
         }
         pr_default.close(3);
         return Gx_cnt ;
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
         P00782_A382IteOrdem = new int[1] ;
         P00782_A383IteNome = new string[] {""} ;
         P00782_A384IteAtivo = new bool[] {false} ;
         P00782_A590IteDel = new bool[] {false} ;
         P00782_A591IteDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P00782_n591IteDelDataHora = new bool[] {false} ;
         P00782_A592IteDelData = new DateTime[] {DateTime.MinValue} ;
         P00782_n592IteDelData = new bool[] {false} ;
         P00782_A593IteDelHora = new DateTime[] {DateTime.MinValue} ;
         P00782_n593IteDelHora = new bool[] {false} ;
         P00782_A594IteDelUsuId = new string[] {""} ;
         P00782_n594IteDelUsuId = new bool[] {false} ;
         P00782_A595IteDelUsuNome = new string[] {""} ;
         P00782_n595IteDelUsuNome = new bool[] {false} ;
         P00782_A381IteID = new Guid[] {Guid.Empty} ;
         A383IteNome = "";
         A591IteDelDataHora = (DateTime)(DateTime.MinValue);
         A592IteDelData = (DateTime)(DateTime.MinValue);
         A593IteDelHora = (DateTime)(DateTime.MinValue);
         A594IteDelUsuId = "";
         A595IteDelUsuNome = "";
         A381IteID = Guid.Empty;
         AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P00783_A382IteOrdem = new int[1] ;
         P00783_A383IteNome = new string[] {""} ;
         P00783_A384IteAtivo = new bool[] {false} ;
         P00783_A590IteDel = new bool[] {false} ;
         P00783_A591IteDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P00783_n591IteDelDataHora = new bool[] {false} ;
         P00783_A592IteDelData = new DateTime[] {DateTime.MinValue} ;
         P00783_n592IteDelData = new bool[] {false} ;
         P00783_A593IteDelHora = new DateTime[] {DateTime.MinValue} ;
         P00783_n593IteDelHora = new bool[] {false} ;
         P00783_A594IteDelUsuId = new string[] {""} ;
         P00783_n594IteDelUsuId = new bool[] {false} ;
         P00783_A595IteDelUsuNome = new string[] {""} ;
         P00783_n595IteDelUsuNome = new bool[] {false} ;
         P00783_A381IteID = new Guid[] {Guid.Empty} ;
         E381IteID = Guid.Empty;
         P00784_A385NegValorAtualizado = new decimal[1] ;
         P00785_Gx_cnt = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.loadaudititeracao__default(),
            new Object[][] {
                new Object[] {
               P00782_A382IteOrdem, P00782_A383IteNome, P00782_A384IteAtivo, P00782_A590IteDel, P00782_A591IteDelDataHora, P00782_n591IteDelDataHora, P00782_A592IteDelData, P00782_n592IteDelData, P00782_A593IteDelHora, P00782_n593IteDelHora,
               P00782_A594IteDelUsuId, P00782_n594IteDelUsuId, P00782_A595IteDelUsuNome, P00782_n595IteDelUsuNome, P00782_A381IteID
               }
               , new Object[] {
               P00783_A382IteOrdem, P00783_A383IteNome, P00783_A384IteAtivo, P00783_A590IteDel, P00783_A591IteDelDataHora, P00783_n591IteDelDataHora, P00783_A592IteDelData, P00783_n592IteDelData, P00783_A593IteDelHora, P00783_n593IteDelHora,
               P00783_A594IteDelUsuId, P00783_n594IteDelUsuId, P00783_A595IteDelUsuNome, P00783_n595IteDelUsuNome, P00783_A381IteID
               }
               , new Object[] {
               P00784_A385NegValorAtualizado
               }
               , new Object[] {
               P00785_Gx_cnt
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A382IteOrdem ;
      private int A432IteQtdeOportunidades ;
      private int AV20GXV1 ;
      private int AV21GXV2 ;
      private int Gx_cnt ;
      private decimal A431IteTotalOportunidades ;
      private decimal X385NegValorAtualizado ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private string scmdbuf ;
      private string A594IteDelUsuId ;
      private DateTime A591IteDelDataHora ;
      private DateTime A592IteDelData ;
      private DateTime A593IteDelHora ;
      private bool returnInSub ;
      private bool A384IteAtivo ;
      private bool A590IteDel ;
      private bool n591IteDelDataHora ;
      private bool n592IteDelData ;
      private bool n593IteDelHora ;
      private bool n594IteDelUsuId ;
      private bool n595IteDelUsuNome ;
      private string A383IteNome ;
      private string A595IteDelUsuNome ;
      private Guid AV17IteID ;
      private Guid A381IteID ;
      private Guid E381IteID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private int[] P00782_A382IteOrdem ;
      private string[] P00782_A383IteNome ;
      private bool[] P00782_A384IteAtivo ;
      private bool[] P00782_A590IteDel ;
      private DateTime[] P00782_A591IteDelDataHora ;
      private bool[] P00782_n591IteDelDataHora ;
      private DateTime[] P00782_A592IteDelData ;
      private bool[] P00782_n592IteDelData ;
      private DateTime[] P00782_A593IteDelHora ;
      private bool[] P00782_n593IteDelHora ;
      private string[] P00782_A594IteDelUsuId ;
      private bool[] P00782_n594IteDelUsuId ;
      private string[] P00782_A595IteDelUsuNome ;
      private bool[] P00782_n595IteDelUsuNome ;
      private Guid[] P00782_A381IteID ;
      private int[] P00783_A382IteOrdem ;
      private string[] P00783_A383IteNome ;
      private bool[] P00783_A384IteAtivo ;
      private bool[] P00783_A590IteDel ;
      private DateTime[] P00783_A591IteDelDataHora ;
      private bool[] P00783_n591IteDelDataHora ;
      private DateTime[] P00783_A592IteDelData ;
      private bool[] P00783_n592IteDelData ;
      private DateTime[] P00783_A593IteDelHora ;
      private bool[] P00783_n593IteDelHora ;
      private string[] P00783_A594IteDelUsuId ;
      private bool[] P00783_n594IteDelUsuId ;
      private string[] P00783_A595IteDelUsuNome ;
      private bool[] P00783_n595IteDelUsuNome ;
      private Guid[] P00783_A381IteID ;
      private decimal[] P00784_A385NegValorAtualizado ;
      private int[] P00785_Gx_cnt ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV11AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
   }

   public class loadaudititeracao__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00782;
          prmP00782 = new Object[] {
          new ParDef("AV17IteID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00783;
          prmP00783 = new Object[] {
          new ParDef("AV17IteID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00784;
          prmP00784 = new Object[] {
          new ParDef("IteID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00785;
          prmP00785 = new Object[] {
          new ParDef("IteID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00782", "SELECT IteOrdem, IteNome, IteAtivo, IteDel, IteDelDataHora, IteDelData, IteDelHora, IteDelUsuId, IteDelUsuNome, IteID FROM tb_Iteracao WHERE IteID = :AV17IteID ORDER BY IteID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00782,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00783", "SELECT IteOrdem, IteNome, IteAtivo, IteDel, IteDelDataHora, IteDelData, IteDelHora, IteDelUsuId, IteDelUsuNome, IteID FROM tb_Iteracao WHERE IteID = :AV17IteID ORDER BY IteID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00783,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00784", "SELECT SUM(NegValorAtualizado) FROM tb_negociopj WHERE NegUltIteID = :IteID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00784,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00785", "SELECT COUNT(*) FROM tb_negociopj WHERE NegUltIteID = :IteID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00785,1, GxCacheFrequency.OFF ,true,true )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((string[]) buf[10])[0] = rslt.getString(8, 40);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((string[]) buf[12])[0] = rslt.getVarchar(9);
                ((bool[]) buf[13])[0] = rslt.wasNull(9);
                ((Guid[]) buf[14])[0] = rslt.getGuid(10);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((string[]) buf[10])[0] = rslt.getString(8, 40);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((string[]) buf[12])[0] = rslt.getVarchar(9);
                ((bool[]) buf[13])[0] = rslt.wasNull(9);
                ((Guid[]) buf[14])[0] = rslt.getGuid(10);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
