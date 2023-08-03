using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class tbibge_municipioloadredundancy : GXProcedure
   {
      public tbibge_municipioloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tbibge_municipioloadredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         tbibge_municipioloadredundancy objtbibge_municipioloadredundancy;
         objtbibge_municipioloadredundancy = new tbibge_municipioloadredundancy();
         objtbibge_municipioloadredundancy.context.SetSubmitInitialConfig(context);
         objtbibge_municipioloadredundancy.initialize();
         Submit( executePrivateCatch,objtbibge_municipioloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tbibge_municipioloadredundancy)stateInfo).executePrivate();
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
         /* Using cursor TBIBGE_MUN2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A37MunicipioMicroID = TBIBGE_MUN2_A37MunicipioMicroID[0];
            A47MunicipioMicroMesoUFRegNome = TBIBGE_MUN2_A47MunicipioMicroMesoUFRegNome[0];
            n47MunicipioMicroMesoUFRegNome = TBIBGE_MUN2_n47MunicipioMicroMesoUFRegNome[0];
            A47MunicipioMicroMesoUFRegNome = TBIBGE_MUN2_A47MunicipioMicroMesoUFRegNome[0];
            n47MunicipioMicroMesoUFRegNome = TBIBGE_MUN2_n47MunicipioMicroMesoUFRegNome[0];
            A46MunicipioMicroMesoUFRegSigla = TBIBGE_MUN2_A46MunicipioMicroMesoUFRegSigla[0];
            n46MunicipioMicroMesoUFRegSigla = TBIBGE_MUN2_n46MunicipioMicroMesoUFRegSigla[0];
            A46MunicipioMicroMesoUFRegSigla = TBIBGE_MUN2_A46MunicipioMicroMesoUFRegSigla[0];
            n46MunicipioMicroMesoUFRegSigla = TBIBGE_MUN2_n46MunicipioMicroMesoUFRegSigla[0];
            A45MunicipioMicroMesoUFRegID = TBIBGE_MUN2_A45MunicipioMicroMesoUFRegID[0];
            n45MunicipioMicroMesoUFRegID = TBIBGE_MUN2_n45MunicipioMicroMesoUFRegID[0];
            A45MunicipioMicroMesoUFRegID = TBIBGE_MUN2_A45MunicipioMicroMesoUFRegID[0];
            n45MunicipioMicroMesoUFRegID = TBIBGE_MUN2_n45MunicipioMicroMesoUFRegID[0];
            A43MunicipioMicroMesoUFNome = TBIBGE_MUN2_A43MunicipioMicroMesoUFNome[0];
            n43MunicipioMicroMesoUFNome = TBIBGE_MUN2_n43MunicipioMicroMesoUFNome[0];
            A43MunicipioMicroMesoUFNome = TBIBGE_MUN2_A43MunicipioMicroMesoUFNome[0];
            n43MunicipioMicroMesoUFNome = TBIBGE_MUN2_n43MunicipioMicroMesoUFNome[0];
            A42MunicipioMicroMesoUFSigla = TBIBGE_MUN2_A42MunicipioMicroMesoUFSigla[0];
            n42MunicipioMicroMesoUFSigla = TBIBGE_MUN2_n42MunicipioMicroMesoUFSigla[0];
            A42MunicipioMicroMesoUFSigla = TBIBGE_MUN2_A42MunicipioMicroMesoUFSigla[0];
            n42MunicipioMicroMesoUFSigla = TBIBGE_MUN2_n42MunicipioMicroMesoUFSigla[0];
            A41MunicipioMicroMesoUFID = TBIBGE_MUN2_A41MunicipioMicroMesoUFID[0];
            n41MunicipioMicroMesoUFID = TBIBGE_MUN2_n41MunicipioMicroMesoUFID[0];
            A41MunicipioMicroMesoUFID = TBIBGE_MUN2_A41MunicipioMicroMesoUFID[0];
            n41MunicipioMicroMesoUFID = TBIBGE_MUN2_n41MunicipioMicroMesoUFID[0];
            A40MunicipioMicroMesoNome = TBIBGE_MUN2_A40MunicipioMicroMesoNome[0];
            n40MunicipioMicroMesoNome = TBIBGE_MUN2_n40MunicipioMicroMesoNome[0];
            A40MunicipioMicroMesoNome = TBIBGE_MUN2_A40MunicipioMicroMesoNome[0];
            n40MunicipioMicroMesoNome = TBIBGE_MUN2_n40MunicipioMicroMesoNome[0];
            A39MunicipioMicroMesoID = TBIBGE_MUN2_A39MunicipioMicroMesoID[0];
            A39MunicipioMicroMesoID = TBIBGE_MUN2_A39MunicipioMicroMesoID[0];
            A38MunicipioMicroNome = TBIBGE_MUN2_A38MunicipioMicroNome[0];
            A38MunicipioMicroNome = TBIBGE_MUN2_A38MunicipioMicroNome[0];
            A44MunicipioMicroMesoUFSiglaNome = TBIBGE_MUN2_A44MunicipioMicroMesoUFSiglaNome[0];
            n44MunicipioMicroMesoUFSiglaNome = TBIBGE_MUN2_n44MunicipioMicroMesoUFSiglaNome[0];
            A48MunicipioMicroMesoUFRegSiglaNo = TBIBGE_MUN2_A48MunicipioMicroMesoUFRegSiglaNo[0];
            n48MunicipioMicroMesoUFRegSiglaNo = TBIBGE_MUN2_n48MunicipioMicroMesoUFRegSiglaNo[0];
            A35MunicipioID = TBIBGE_MUN2_A35MunicipioID[0];
            O47MunicipioMicroMesoUFRegNome = A47MunicipioMicroMesoUFRegNome;
            n47MunicipioMicroMesoUFRegNome = false;
            O46MunicipioMicroMesoUFRegSigla = A46MunicipioMicroMesoUFRegSigla;
            n46MunicipioMicroMesoUFRegSigla = false;
            O45MunicipioMicroMesoUFRegID = A45MunicipioMicroMesoUFRegID;
            n45MunicipioMicroMesoUFRegID = false;
            O43MunicipioMicroMesoUFNome = A43MunicipioMicroMesoUFNome;
            n43MunicipioMicroMesoUFNome = false;
            O42MunicipioMicroMesoUFSigla = A42MunicipioMicroMesoUFSigla;
            n42MunicipioMicroMesoUFSigla = false;
            O41MunicipioMicroMesoUFID = A41MunicipioMicroMesoUFID;
            n41MunicipioMicroMesoUFID = false;
            O40MunicipioMicroMesoNome = A40MunicipioMicroMesoNome;
            n40MunicipioMicroMesoNome = false;
            O39MunicipioMicroMesoID = A39MunicipioMicroMesoID;
            O38MunicipioMicroNome = A38MunicipioMicroNome;
            A39MunicipioMicroMesoID = TBIBGE_MUN2_A39MunicipioMicroMesoID[0];
            A38MunicipioMicroNome = TBIBGE_MUN2_A38MunicipioMicroNome[0];
            O39MunicipioMicroMesoID = A39MunicipioMicroMesoID;
            O38MunicipioMicroNome = A38MunicipioMicroNome;
            A47MunicipioMicroMesoUFRegNome = TBIBGE_MUN2_A47MunicipioMicroMesoUFRegNome[0];
            n47MunicipioMicroMesoUFRegNome = TBIBGE_MUN2_n47MunicipioMicroMesoUFRegNome[0];
            A46MunicipioMicroMesoUFRegSigla = TBIBGE_MUN2_A46MunicipioMicroMesoUFRegSigla[0];
            n46MunicipioMicroMesoUFRegSigla = TBIBGE_MUN2_n46MunicipioMicroMesoUFRegSigla[0];
            O47MunicipioMicroMesoUFRegNome = A47MunicipioMicroMesoUFRegNome;
            n47MunicipioMicroMesoUFRegNome = false;
            O46MunicipioMicroMesoUFRegSigla = A46MunicipioMicroMesoUFRegSigla;
            n46MunicipioMicroMesoUFRegSigla = false;
            A45MunicipioMicroMesoUFRegID = TBIBGE_MUN2_A45MunicipioMicroMesoUFRegID[0];
            n45MunicipioMicroMesoUFRegID = TBIBGE_MUN2_n45MunicipioMicroMesoUFRegID[0];
            A43MunicipioMicroMesoUFNome = TBIBGE_MUN2_A43MunicipioMicroMesoUFNome[0];
            n43MunicipioMicroMesoUFNome = TBIBGE_MUN2_n43MunicipioMicroMesoUFNome[0];
            A42MunicipioMicroMesoUFSigla = TBIBGE_MUN2_A42MunicipioMicroMesoUFSigla[0];
            n42MunicipioMicroMesoUFSigla = TBIBGE_MUN2_n42MunicipioMicroMesoUFSigla[0];
            O45MunicipioMicroMesoUFRegID = A45MunicipioMicroMesoUFRegID;
            n45MunicipioMicroMesoUFRegID = false;
            O43MunicipioMicroMesoUFNome = A43MunicipioMicroMesoUFNome;
            n43MunicipioMicroMesoUFNome = false;
            O42MunicipioMicroMesoUFSigla = A42MunicipioMicroMesoUFSigla;
            n42MunicipioMicroMesoUFSigla = false;
            A41MunicipioMicroMesoUFID = TBIBGE_MUN2_A41MunicipioMicroMesoUFID[0];
            n41MunicipioMicroMesoUFID = TBIBGE_MUN2_n41MunicipioMicroMesoUFID[0];
            A40MunicipioMicroMesoNome = TBIBGE_MUN2_A40MunicipioMicroMesoNome[0];
            n40MunicipioMicroMesoNome = TBIBGE_MUN2_n40MunicipioMicroMesoNome[0];
            O41MunicipioMicroMesoUFID = A41MunicipioMicroMesoUFID;
            n41MunicipioMicroMesoUFID = false;
            O40MunicipioMicroMesoNome = A40MunicipioMicroMesoNome;
            n40MunicipioMicroMesoNome = false;
            A47MunicipioMicroMesoUFRegNome = O47MunicipioMicroMesoUFRegNome;
            n47MunicipioMicroMesoUFRegNome = false;
            A46MunicipioMicroMesoUFRegSigla = O46MunicipioMicroMesoUFRegSigla;
            n46MunicipioMicroMesoUFRegSigla = false;
            A45MunicipioMicroMesoUFRegID = O45MunicipioMicroMesoUFRegID;
            n45MunicipioMicroMesoUFRegID = false;
            A43MunicipioMicroMesoUFNome = O43MunicipioMicroMesoUFNome;
            n43MunicipioMicroMesoUFNome = false;
            A42MunicipioMicroMesoUFSigla = O42MunicipioMicroMesoUFSigla;
            n42MunicipioMicroMesoUFSigla = false;
            A41MunicipioMicroMesoUFID = O41MunicipioMicroMesoUFID;
            n41MunicipioMicroMesoUFID = false;
            A40MunicipioMicroMesoNome = O40MunicipioMicroMesoNome;
            n40MunicipioMicroMesoNome = false;
            A39MunicipioMicroMesoID = O39MunicipioMicroMesoID;
            A38MunicipioMicroNome = O38MunicipioMicroNome;
            O47MunicipioMicroMesoUFRegNome = A47MunicipioMicroMesoUFRegNome;
            n47MunicipioMicroMesoUFRegNome = false;
            O46MunicipioMicroMesoUFRegSigla = A46MunicipioMicroMesoUFRegSigla;
            n46MunicipioMicroMesoUFRegSigla = false;
            O45MunicipioMicroMesoUFRegID = A45MunicipioMicroMesoUFRegID;
            n45MunicipioMicroMesoUFRegID = false;
            O43MunicipioMicroMesoUFNome = A43MunicipioMicroMesoUFNome;
            n43MunicipioMicroMesoUFNome = false;
            O42MunicipioMicroMesoUFSigla = A42MunicipioMicroMesoUFSigla;
            n42MunicipioMicroMesoUFSigla = false;
            O41MunicipioMicroMesoUFID = A41MunicipioMicroMesoUFID;
            n41MunicipioMicroMesoUFID = false;
            O40MunicipioMicroMesoNome = A40MunicipioMicroMesoNome;
            n40MunicipioMicroMesoNome = false;
            O39MunicipioMicroMesoID = A39MunicipioMicroMesoID;
            O38MunicipioMicroNome = A38MunicipioMicroNome;
            A44MunicipioMicroMesoUFSiglaNome = StringUtil.Trim( A42MunicipioMicroMesoUFSigla) + " - " + StringUtil.Trim( A43MunicipioMicroMesoUFNome);
            n44MunicipioMicroMesoUFSiglaNome = false;
            A48MunicipioMicroMesoUFRegSiglaNo = StringUtil.Trim( A46MunicipioMicroMesoUFRegSigla) + " - " + StringUtil.Trim( A47MunicipioMicroMesoUFRegNome);
            n48MunicipioMicroMesoUFRegSiglaNo = false;
            /* Using cursor TBIBGE_MUN3 */
            pr_default.execute(1, new Object[] {n47MunicipioMicroMesoUFRegNome, A47MunicipioMicroMesoUFRegNome, n46MunicipioMicroMesoUFRegSigla, A46MunicipioMicroMesoUFRegSigla, n45MunicipioMicroMesoUFRegID, A45MunicipioMicroMesoUFRegID, n43MunicipioMicroMesoUFNome, A43MunicipioMicroMesoUFNome, n42MunicipioMicroMesoUFSigla, A42MunicipioMicroMesoUFSigla, n41MunicipioMicroMesoUFID, A41MunicipioMicroMesoUFID, n40MunicipioMicroMesoNome, A40MunicipioMicroMesoNome, A39MunicipioMicroMesoID, A38MunicipioMicroNome, n44MunicipioMicroMesoUFSiglaNome, A44MunicipioMicroMesoUFSiglaNome, n48MunicipioMicroMesoUFRegSiglaNo, A48MunicipioMicroMesoUFRegSiglaNo, A35MunicipioID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("tbibge_municipio");
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         scmdbuf = "";
         TBIBGE_MUN2_A37MunicipioMicroID = new int[1] ;
         TBIBGE_MUN2_A47MunicipioMicroMesoUFRegNome = new string[] {""} ;
         TBIBGE_MUN2_n47MunicipioMicroMesoUFRegNome = new bool[] {false} ;
         TBIBGE_MUN2_A46MunicipioMicroMesoUFRegSigla = new string[] {""} ;
         TBIBGE_MUN2_n46MunicipioMicroMesoUFRegSigla = new bool[] {false} ;
         TBIBGE_MUN2_A45MunicipioMicroMesoUFRegID = new int[1] ;
         TBIBGE_MUN2_n45MunicipioMicroMesoUFRegID = new bool[] {false} ;
         TBIBGE_MUN2_A43MunicipioMicroMesoUFNome = new string[] {""} ;
         TBIBGE_MUN2_n43MunicipioMicroMesoUFNome = new bool[] {false} ;
         TBIBGE_MUN2_A42MunicipioMicroMesoUFSigla = new string[] {""} ;
         TBIBGE_MUN2_n42MunicipioMicroMesoUFSigla = new bool[] {false} ;
         TBIBGE_MUN2_A41MunicipioMicroMesoUFID = new int[1] ;
         TBIBGE_MUN2_n41MunicipioMicroMesoUFID = new bool[] {false} ;
         TBIBGE_MUN2_A40MunicipioMicroMesoNome = new string[] {""} ;
         TBIBGE_MUN2_n40MunicipioMicroMesoNome = new bool[] {false} ;
         TBIBGE_MUN2_A39MunicipioMicroMesoID = new int[1] ;
         TBIBGE_MUN2_A38MunicipioMicroNome = new string[] {""} ;
         TBIBGE_MUN2_A44MunicipioMicroMesoUFSiglaNome = new string[] {""} ;
         TBIBGE_MUN2_n44MunicipioMicroMesoUFSiglaNome = new bool[] {false} ;
         TBIBGE_MUN2_A48MunicipioMicroMesoUFRegSiglaNo = new string[] {""} ;
         TBIBGE_MUN2_n48MunicipioMicroMesoUFRegSiglaNo = new bool[] {false} ;
         TBIBGE_MUN2_A35MunicipioID = new int[1] ;
         A47MunicipioMicroMesoUFRegNome = "";
         A46MunicipioMicroMesoUFRegSigla = "";
         A43MunicipioMicroMesoUFNome = "";
         A42MunicipioMicroMesoUFSigla = "";
         A40MunicipioMicroMesoNome = "";
         A38MunicipioMicroNome = "";
         A44MunicipioMicroMesoUFSiglaNome = "";
         A48MunicipioMicroMesoUFRegSiglaNo = "";
         O47MunicipioMicroMesoUFRegNome = "";
         O46MunicipioMicroMesoUFRegSigla = "";
         O43MunicipioMicroMesoUFNome = "";
         O42MunicipioMicroMesoUFSigla = "";
         O40MunicipioMicroMesoNome = "";
         O38MunicipioMicroNome = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tbibge_municipioloadredundancy__default(),
            new Object[][] {
                new Object[] {
               TBIBGE_MUN2_A37MunicipioMicroID, TBIBGE_MUN2_A47MunicipioMicroMesoUFRegNome, TBIBGE_MUN2_n47MunicipioMicroMesoUFRegNome, TBIBGE_MUN2_A47MunicipioMicroMesoUFRegNome, TBIBGE_MUN2_n47MunicipioMicroMesoUFRegNome, TBIBGE_MUN2_A46MunicipioMicroMesoUFRegSigla, TBIBGE_MUN2_n46MunicipioMicroMesoUFRegSigla, TBIBGE_MUN2_A46MunicipioMicroMesoUFRegSigla, TBIBGE_MUN2_n46MunicipioMicroMesoUFRegSigla, TBIBGE_MUN2_A45MunicipioMicroMesoUFRegID,
               TBIBGE_MUN2_n45MunicipioMicroMesoUFRegID, TBIBGE_MUN2_A45MunicipioMicroMesoUFRegID, TBIBGE_MUN2_n45MunicipioMicroMesoUFRegID, TBIBGE_MUN2_A43MunicipioMicroMesoUFNome, TBIBGE_MUN2_n43MunicipioMicroMesoUFNome, TBIBGE_MUN2_A43MunicipioMicroMesoUFNome, TBIBGE_MUN2_n43MunicipioMicroMesoUFNome, TBIBGE_MUN2_A42MunicipioMicroMesoUFSigla, TBIBGE_MUN2_n42MunicipioMicroMesoUFSigla, TBIBGE_MUN2_A42MunicipioMicroMesoUFSigla,
               TBIBGE_MUN2_n42MunicipioMicroMesoUFSigla, TBIBGE_MUN2_A41MunicipioMicroMesoUFID, TBIBGE_MUN2_n41MunicipioMicroMesoUFID, TBIBGE_MUN2_A41MunicipioMicroMesoUFID, TBIBGE_MUN2_n41MunicipioMicroMesoUFID, TBIBGE_MUN2_A40MunicipioMicroMesoNome, TBIBGE_MUN2_n40MunicipioMicroMesoNome, TBIBGE_MUN2_A40MunicipioMicroMesoNome, TBIBGE_MUN2_n40MunicipioMicroMesoNome, TBIBGE_MUN2_A39MunicipioMicroMesoID,
               TBIBGE_MUN2_A39MunicipioMicroMesoID, TBIBGE_MUN2_A38MunicipioMicroNome, TBIBGE_MUN2_A38MunicipioMicroNome, TBIBGE_MUN2_A44MunicipioMicroMesoUFSiglaNome, TBIBGE_MUN2_n44MunicipioMicroMesoUFSiglaNome, TBIBGE_MUN2_A48MunicipioMicroMesoUFRegSiglaNo, TBIBGE_MUN2_n48MunicipioMicroMesoUFRegSiglaNo, TBIBGE_MUN2_A35MunicipioID
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A37MunicipioMicroID ;
      private int A45MunicipioMicroMesoUFRegID ;
      private int A41MunicipioMicroMesoUFID ;
      private int A39MunicipioMicroMesoID ;
      private int A35MunicipioID ;
      private int O45MunicipioMicroMesoUFRegID ;
      private int O41MunicipioMicroMesoUFID ;
      private int O39MunicipioMicroMesoID ;
      private string scmdbuf ;
      private bool n47MunicipioMicroMesoUFRegNome ;
      private bool n46MunicipioMicroMesoUFRegSigla ;
      private bool n45MunicipioMicroMesoUFRegID ;
      private bool n43MunicipioMicroMesoUFNome ;
      private bool n42MunicipioMicroMesoUFSigla ;
      private bool n41MunicipioMicroMesoUFID ;
      private bool n40MunicipioMicroMesoNome ;
      private bool n44MunicipioMicroMesoUFSiglaNome ;
      private bool n48MunicipioMicroMesoUFRegSiglaNo ;
      private string A47MunicipioMicroMesoUFRegNome ;
      private string A46MunicipioMicroMesoUFRegSigla ;
      private string A43MunicipioMicroMesoUFNome ;
      private string A42MunicipioMicroMesoUFSigla ;
      private string A40MunicipioMicroMesoNome ;
      private string A38MunicipioMicroNome ;
      private string A44MunicipioMicroMesoUFSiglaNome ;
      private string A48MunicipioMicroMesoUFRegSiglaNo ;
      private string O47MunicipioMicroMesoUFRegNome ;
      private string O46MunicipioMicroMesoUFRegSigla ;
      private string O43MunicipioMicroMesoUFNome ;
      private string O42MunicipioMicroMesoUFSigla ;
      private string O40MunicipioMicroMesoNome ;
      private string O38MunicipioMicroNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] TBIBGE_MUN2_A37MunicipioMicroID ;
      private string[] TBIBGE_MUN2_A47MunicipioMicroMesoUFRegNome ;
      private bool[] TBIBGE_MUN2_n47MunicipioMicroMesoUFRegNome ;
      private string[] TBIBGE_MUN2_A46MunicipioMicroMesoUFRegSigla ;
      private bool[] TBIBGE_MUN2_n46MunicipioMicroMesoUFRegSigla ;
      private int[] TBIBGE_MUN2_A45MunicipioMicroMesoUFRegID ;
      private bool[] TBIBGE_MUN2_n45MunicipioMicroMesoUFRegID ;
      private string[] TBIBGE_MUN2_A43MunicipioMicroMesoUFNome ;
      private bool[] TBIBGE_MUN2_n43MunicipioMicroMesoUFNome ;
      private string[] TBIBGE_MUN2_A42MunicipioMicroMesoUFSigla ;
      private bool[] TBIBGE_MUN2_n42MunicipioMicroMesoUFSigla ;
      private int[] TBIBGE_MUN2_A41MunicipioMicroMesoUFID ;
      private bool[] TBIBGE_MUN2_n41MunicipioMicroMesoUFID ;
      private string[] TBIBGE_MUN2_A40MunicipioMicroMesoNome ;
      private bool[] TBIBGE_MUN2_n40MunicipioMicroMesoNome ;
      private int[] TBIBGE_MUN2_A39MunicipioMicroMesoID ;
      private string[] TBIBGE_MUN2_A38MunicipioMicroNome ;
      private string[] TBIBGE_MUN2_A44MunicipioMicroMesoUFSiglaNome ;
      private bool[] TBIBGE_MUN2_n44MunicipioMicroMesoUFSiglaNome ;
      private string[] TBIBGE_MUN2_A48MunicipioMicroMesoUFRegSiglaNo ;
      private bool[] TBIBGE_MUN2_n48MunicipioMicroMesoUFRegSiglaNo ;
      private int[] TBIBGE_MUN2_A35MunicipioID ;
   }

   public class tbibge_municipioloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmTBIBGE_MUN2;
          prmTBIBGE_MUN2 = new Object[] {
          };
          Object[] prmTBIBGE_MUN3;
          prmTBIBGE_MUN3 = new Object[] {
          new ParDef("MunicipioMicroMesoUFRegNome",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("MunicipioMicroMesoUFRegSigla",GXType.VarChar,10,0){Nullable=true} ,
          new ParDef("MunicipioMicroMesoUFRegID",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("MunicipioMicroMesoUFNome",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("MunicipioMicroMesoUFSigla",GXType.VarChar,2,0){Nullable=true} ,
          new ParDef("MunicipioMicroMesoUFID",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("MunicipioMicroMesoNome",GXType.VarChar,80,0){Nullable=true} ,
          new ParDef("MunicipioMicroMesoID",GXType.Int32,9,0) ,
          new ParDef("MunicipioMicroNome",GXType.VarChar,80,0) ,
          new ParDef("MunicipioMicroMesoUFSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("MunicipioMicroMesoUFRegSiglaNo",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("MunicipioID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("TBIBGE_MUN2", "SELECT T1.MunicipioMicroID AS MunicipioMicroID, T1.MunicipioMicroMesoUFRegNome AS MunicipioMicroMesoUFRegNome, T3.RegiaoNome AS MunicipioMicroMesoUFRegNome, T1.MunicipioMicroMesoUFRegSigla AS MunicipioMicroMesoUFRegSigla, T3.RegiaoSigla AS MunicipioMicroMesoUFRegSigla, T1.MunicipioMicroMesoUFRegID AS MunicipioMicroMesoUFRegID, T4.UFRegID AS MunicipioMicroMesoUFRegID, T1.MunicipioMicroMesoUFNome AS MunicipioMicroMesoUFNome, T4.UFNome AS MunicipioMicroMesoUFNome, T1.MunicipioMicroMesoUFSigla AS MunicipioMicroMesoUFSigla, T4.UFSigla AS MunicipioMicroMesoUFSigla, T1.MunicipioMicroMesoUFID AS MunicipioMicroMesoUFID, T5.MesorregiaoUFID AS MunicipioMicroMesoUFID, T1.MunicipioMicroMesoNome AS MunicipioMicroMesoNome, T5.MesorregiaoNome AS MunicipioMicroMesoNome, T1.MunicipioMicroMesoID AS MunicipioMicroMesoID, T2.MicrorregiaoMesoID AS MunicipioMicroMesoID, T1.MunicipioMicroNome AS MunicipioMicroNome, T2.MicrorregiaoNome AS MunicipioMicroNome, T1.MunicipioMicroMesoUFSiglaNome AS MunicipioMicroMesoUFSiglaNome, T1.MunicipioMicroMesoUFRegSiglaNo AS MunicipioMicroMesoUFRegSiglaNo, T1.MunicipioID FROM ((((tbibge_municipio T1 INNER JOIN tbibge_microrregiao T2 ON T2.MicrorregiaoID = T1.MunicipioMicroID) LEFT JOIN tbibge_regiao T3 ON T3.RegiaoID = T1.MunicipioMicroMesoUFRegID) LEFT JOIN tbibge_uf T4 ON T4.UFID = T1.MunicipioMicroMesoUFID) INNER JOIN tbibge_mesorregiao T5 ON T5.MesorregiaoID = T1.MunicipioMicroMesoID) ORDER BY T1.MunicipioID  FOR UPDATE OF T1, T1, T1, T1, T1",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTBIBGE_MUN2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TBIBGE_MUN3", "UPDATE tbibge_municipio SET MunicipioMicroMesoUFRegNome=:MunicipioMicroMesoUFRegNome, MunicipioMicroMesoUFRegSigla=:MunicipioMicroMesoUFRegSigla, MunicipioMicroMesoUFRegID=:MunicipioMicroMesoUFRegID, MunicipioMicroMesoUFNome=:MunicipioMicroMesoUFNome, MunicipioMicroMesoUFSigla=:MunicipioMicroMesoUFSigla, MunicipioMicroMesoUFID=:MunicipioMicroMesoUFID, MunicipioMicroMesoNome=:MunicipioMicroMesoNome, MunicipioMicroMesoID=:MunicipioMicroMesoID, MunicipioMicroNome=:MunicipioMicroNome, MunicipioMicroMesoUFSiglaNome=:MunicipioMicroMesoUFSiglaNome, MunicipioMicroMesoUFRegSiglaNo=:MunicipioMicroMesoUFRegSiglaNo  WHERE MunicipioID = :MunicipioID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTBIBGE_MUN3)
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((int[]) buf[29])[0] = rslt.getInt(16);
                ((int[]) buf[30])[0] = rslt.getInt(17);
                ((string[]) buf[31])[0] = rslt.getVarchar(18);
                ((string[]) buf[32])[0] = rslt.getVarchar(19);
                ((string[]) buf[33])[0] = rslt.getVarchar(20);
                ((bool[]) buf[34])[0] = rslt.wasNull(20);
                ((string[]) buf[35])[0] = rslt.getVarchar(21);
                ((bool[]) buf[36])[0] = rslt.wasNull(21);
                ((int[]) buf[37])[0] = rslt.getInt(22);
                return;
       }
    }

 }

}
