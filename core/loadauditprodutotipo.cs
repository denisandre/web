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
   public class loadauditprodutotipo : GXProcedure
   {
      public loadauditprodutotipo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadauditprodutotipo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SaveOldValues ,
                           ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                           int aP2_PrtID ,
                           string aP3_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17PrtID = aP2_PrtID;
         this.AV15ActualMode = aP3_ActualMode;
         initialize();
         executePrivate();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                                 int aP2_PrtID ,
                                 string aP3_ActualMode )
      {
         loadauditprodutotipo objloadauditprodutotipo;
         objloadauditprodutotipo = new loadauditprodutotipo();
         objloadauditprodutotipo.AV14SaveOldValues = aP0_SaveOldValues;
         objloadauditprodutotipo.AV11AuditingObject = aP1_AuditingObject;
         objloadauditprodutotipo.AV17PrtID = aP2_PrtID;
         objloadauditprodutotipo.AV15ActualMode = aP3_ActualMode;
         objloadauditprodutotipo.context.SetSubmitInitialConfig(context);
         objloadauditprodutotipo.initialize();
         Submit( executePrivateCatch,objloadauditprodutotipo);
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadauditprodutotipo)stateInfo).executePrivate();
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
         /* Using cursor P00752 */
         pr_default.execute(0, new Object[] {AV17PrtID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A211PrtID = P00752_A211PrtID[0];
            A212PrtSigla = P00752_A212PrtSigla[0];
            A213PrtNome = P00752_A213PrtNome[0];
            A214PrtAtivo = P00752_A214PrtAtivo[0];
            A614PrtDel = P00752_A614PrtDel[0];
            A615PrtDelDataHora = P00752_A615PrtDelDataHora[0];
            n615PrtDelDataHora = P00752_n615PrtDelDataHora[0];
            A616PrtDelData = P00752_A616PrtDelData[0];
            n616PrtDelData = P00752_n616PrtDelData[0];
            A617PrtDelHora = P00752_A617PrtDelHora[0];
            n617PrtDelHora = P00752_n617PrtDelHora[0];
            A618PrtDelUsuId = P00752_A618PrtDelUsuId[0];
            n618PrtDelUsuId = P00752_n618PrtDelUsuId[0];
            A619PrtDelUsuNome = P00752_A619PrtDelUsuNome[0];
            n619PrtDelUsuNome = P00752_n619PrtDelUsuNome[0];
            AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
            AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
            AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
            AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_produtotipo";
            AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
            AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrtID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A211PrtID), 9, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrtSigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A212PrtSigla;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrtNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A213PrtNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrtAtivo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ativo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A214PrtAtivo);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrtDel";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A614PrtDel);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrtDelDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A615PrtDelDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrtDelData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A616PrtDelData, 10, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrtDelHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A617PrtDelHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrtDelUsuId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A618PrtDelUsuId;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrtDelUsuNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A619PrtDelUsuNome;
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
         /* Using cursor P00753 */
         pr_default.execute(1, new Object[] {AV17PrtID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A211PrtID = P00753_A211PrtID[0];
            A212PrtSigla = P00753_A212PrtSigla[0];
            A213PrtNome = P00753_A213PrtNome[0];
            A214PrtAtivo = P00753_A214PrtAtivo[0];
            A614PrtDel = P00753_A614PrtDel[0];
            A615PrtDelDataHora = P00753_A615PrtDelDataHora[0];
            n615PrtDelDataHora = P00753_n615PrtDelDataHora[0];
            A616PrtDelData = P00753_A616PrtDelData[0];
            n616PrtDelData = P00753_n616PrtDelData[0];
            A617PrtDelHora = P00753_A617PrtDelHora[0];
            n617PrtDelHora = P00753_n617PrtDelHora[0];
            A618PrtDelUsuId = P00753_A618PrtDelUsuId[0];
            n618PrtDelUsuId = P00753_n618PrtDelUsuId[0];
            A619PrtDelUsuNome = P00753_A619PrtDelUsuNome[0];
            n619PrtDelUsuNome = P00753_n619PrtDelUsuNome[0];
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_produtotipo";
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrtID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A211PrtID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrtSigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A212PrtSigla;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrtNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A213PrtNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrtAtivo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ativo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A214PrtAtivo);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrtDel";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A614PrtDel);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrtDelDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A615PrtDelDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrtDelData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A616PrtDelData, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrtDelHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A617PrtDelHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrtDelUsuId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A618PrtDelUsuId;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrtDelUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A619PrtDelUsuNome;
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
                     if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrtID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A211PrtID), 9, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrtSigla") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A212PrtSigla;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrtNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A213PrtNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrtAtivo") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A214PrtAtivo);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrtDel") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A614PrtDel);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrtDelDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A615PrtDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrtDelData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A616PrtDelData, 10, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrtDelHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A617PrtDelHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrtDelUsuId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A618PrtDelUsuId;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrtDelUsuNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A619PrtDelUsuNome;
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
         P00752_A211PrtID = new int[1] ;
         P00752_A212PrtSigla = new string[] {""} ;
         P00752_A213PrtNome = new string[] {""} ;
         P00752_A214PrtAtivo = new bool[] {false} ;
         P00752_A614PrtDel = new bool[] {false} ;
         P00752_A615PrtDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P00752_n615PrtDelDataHora = new bool[] {false} ;
         P00752_A616PrtDelData = new DateTime[] {DateTime.MinValue} ;
         P00752_n616PrtDelData = new bool[] {false} ;
         P00752_A617PrtDelHora = new DateTime[] {DateTime.MinValue} ;
         P00752_n617PrtDelHora = new bool[] {false} ;
         P00752_A618PrtDelUsuId = new string[] {""} ;
         P00752_n618PrtDelUsuId = new bool[] {false} ;
         P00752_A619PrtDelUsuNome = new string[] {""} ;
         P00752_n619PrtDelUsuNome = new bool[] {false} ;
         A212PrtSigla = "";
         A213PrtNome = "";
         A615PrtDelDataHora = (DateTime)(DateTime.MinValue);
         A616PrtDelData = (DateTime)(DateTime.MinValue);
         A617PrtDelHora = (DateTime)(DateTime.MinValue);
         A618PrtDelUsuId = "";
         A619PrtDelUsuNome = "";
         AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P00753_A211PrtID = new int[1] ;
         P00753_A212PrtSigla = new string[] {""} ;
         P00753_A213PrtNome = new string[] {""} ;
         P00753_A214PrtAtivo = new bool[] {false} ;
         P00753_A614PrtDel = new bool[] {false} ;
         P00753_A615PrtDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P00753_n615PrtDelDataHora = new bool[] {false} ;
         P00753_A616PrtDelData = new DateTime[] {DateTime.MinValue} ;
         P00753_n616PrtDelData = new bool[] {false} ;
         P00753_A617PrtDelHora = new DateTime[] {DateTime.MinValue} ;
         P00753_n617PrtDelHora = new bool[] {false} ;
         P00753_A618PrtDelUsuId = new string[] {""} ;
         P00753_n618PrtDelUsuId = new bool[] {false} ;
         P00753_A619PrtDelUsuNome = new string[] {""} ;
         P00753_n619PrtDelUsuNome = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.loadauditprodutotipo__default(),
            new Object[][] {
                new Object[] {
               P00752_A211PrtID, P00752_A212PrtSigla, P00752_A213PrtNome, P00752_A214PrtAtivo, P00752_A614PrtDel, P00752_A615PrtDelDataHora, P00752_n615PrtDelDataHora, P00752_A616PrtDelData, P00752_n616PrtDelData, P00752_A617PrtDelHora,
               P00752_n617PrtDelHora, P00752_A618PrtDelUsuId, P00752_n618PrtDelUsuId, P00752_A619PrtDelUsuNome, P00752_n619PrtDelUsuNome
               }
               , new Object[] {
               P00753_A211PrtID, P00753_A212PrtSigla, P00753_A213PrtNome, P00753_A214PrtAtivo, P00753_A614PrtDel, P00753_A615PrtDelDataHora, P00753_n615PrtDelDataHora, P00753_A616PrtDelData, P00753_n616PrtDelData, P00753_A617PrtDelHora,
               P00753_n617PrtDelHora, P00753_A618PrtDelUsuId, P00753_n618PrtDelUsuId, P00753_A619PrtDelUsuNome, P00753_n619PrtDelUsuNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV17PrtID ;
      private int A211PrtID ;
      private int AV20GXV1 ;
      private int AV21GXV2 ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private string scmdbuf ;
      private string A618PrtDelUsuId ;
      private DateTime A615PrtDelDataHora ;
      private DateTime A616PrtDelData ;
      private DateTime A617PrtDelHora ;
      private bool returnInSub ;
      private bool A214PrtAtivo ;
      private bool A614PrtDel ;
      private bool n615PrtDelDataHora ;
      private bool n616PrtDelData ;
      private bool n617PrtDelHora ;
      private bool n618PrtDelUsuId ;
      private bool n619PrtDelUsuNome ;
      private string A212PrtSigla ;
      private string A213PrtNome ;
      private string A619PrtDelUsuNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private int[] P00752_A211PrtID ;
      private string[] P00752_A212PrtSigla ;
      private string[] P00752_A213PrtNome ;
      private bool[] P00752_A214PrtAtivo ;
      private bool[] P00752_A614PrtDel ;
      private DateTime[] P00752_A615PrtDelDataHora ;
      private bool[] P00752_n615PrtDelDataHora ;
      private DateTime[] P00752_A616PrtDelData ;
      private bool[] P00752_n616PrtDelData ;
      private DateTime[] P00752_A617PrtDelHora ;
      private bool[] P00752_n617PrtDelHora ;
      private string[] P00752_A618PrtDelUsuId ;
      private bool[] P00752_n618PrtDelUsuId ;
      private string[] P00752_A619PrtDelUsuNome ;
      private bool[] P00752_n619PrtDelUsuNome ;
      private int[] P00753_A211PrtID ;
      private string[] P00753_A212PrtSigla ;
      private string[] P00753_A213PrtNome ;
      private bool[] P00753_A214PrtAtivo ;
      private bool[] P00753_A614PrtDel ;
      private DateTime[] P00753_A615PrtDelDataHora ;
      private bool[] P00753_n615PrtDelDataHora ;
      private DateTime[] P00753_A616PrtDelData ;
      private bool[] P00753_n616PrtDelData ;
      private DateTime[] P00753_A617PrtDelHora ;
      private bool[] P00753_n617PrtDelHora ;
      private string[] P00753_A618PrtDelUsuId ;
      private bool[] P00753_n618PrtDelUsuId ;
      private string[] P00753_A619PrtDelUsuNome ;
      private bool[] P00753_n619PrtDelUsuNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV11AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
   }

   public class loadauditprodutotipo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00752;
          prmP00752 = new Object[] {
          new ParDef("AV17PrtID",GXType.Int32,9,0)
          };
          Object[] prmP00753;
          prmP00753 = new Object[] {
          new ParDef("AV17PrtID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00752", "SELECT PrtID, PrtSigla, PrtNome, PrtAtivo, PrtDel, PrtDelDataHora, PrtDelData, PrtDelHora, PrtDelUsuId, PrtDelUsuNome FROM tb_produtotipo WHERE PrtID = :AV17PrtID ORDER BY PrtID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00752,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00753", "SELECT PrtID, PrtSigla, PrtNome, PrtAtivo, PrtDel, PrtDelDataHora, PrtDelData, PrtDelHora, PrtDelUsuId, PrtDelUsuNome FROM tb_produtotipo WHERE PrtID = :AV17PrtID ORDER BY PrtID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00753,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getString(9, 40);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((string[]) buf[13])[0] = rslt.getVarchar(10);
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getString(9, 40);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((string[]) buf[13])[0] = rslt.getVarchar(10);
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                return;
       }
    }

 }

}
