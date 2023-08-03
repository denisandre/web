using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.core {
   public class gxdomainchavefluxo
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainchavefluxo ()
      {
         domain["DOCANALISE"] = "Análise da Documentação";
         domain["DOCREGISTRARENVIOCAF"] = "Regisrtrar Envio ao CAF";
         domain["DOCREGISTRARRETORNOCAF"] = "Registrar Retorno do CAF";
         domain["DOCANALISECREDITO"] = "Análise de Crédito";
         domain["PROPCONFECCIONAR"] = "Proposta Comercial Confeccionada";
         domain["PROPREGENVIOCLIENTE"] = "Registrar Envio da Proposta ao Cliente";
         domain["PROPREGRESPCLIENTE"] = "Registrar Resposta da Proposta pelo Cliente";
         domain["ASSCONENTREGAGARANTIA"] = "Entrega da Garantia";
         domain["ASSCONCOMPORGARANTIA"] = "Compor a Garantia";
         domain["ASSCONVERIFICACONTAATIVA"] = "Verifica existência de conta bancária ativa";
         domain["ASSCONCONTRATARPRODUTO"] = "Contratar Produto";
         domain["ASSCONCONFECCONTRATO"] = "Confeccionar Contrato";
         domain["ASSCONREGENVCONTCLIENTE"] = "Registrar Envio do Contrato ao Cliente";
         domain["ASSCONREGRESCONTCLIENTE"] = "Registrar Resposta do Contrato do Cliente";
         domain["ASSCONRECOLHERASSINATURA"] = "Recolher Assinaturas";
         domain["ENCREALIZADOONBOARD"] = "Realizado OnBoard?";
         domain["ENCPESQUISAAVALIACAO"] = "Pesquisa de Avaliação Realizada?";
      }

      public static string getDescription( IGxContext context ,
                                           string key )
      {
         string rtkey;
         string value;
         rtkey = ((key==null) ? "" : StringUtil.Trim( (string)(key)));
         value = (string)(domain[rtkey]==null?"":domain[rtkey]);
         return value ;
      }

      public static GxSimpleCollection<string> getValues( )
      {
         GxSimpleCollection<string> value = new GxSimpleCollection<string>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (string key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      public static string getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["DocAnalise"] = "DOCANALISE";
            domainMap["DocRegistrarEnvioCAF"] = "DOCREGISTRARENVIOCAF";
            domainMap["DocRegistrarRetornoCAF"] = "DOCREGISTRARRETORNOCAF";
            domainMap["DocAnaliseCredito"] = "DOCANALISECREDITO";
            domainMap["PropConfeccionar"] = "PROPCONFECCIONAR";
            domainMap["PropRegEnvioCliente"] = "PROPREGENVIOCLIENTE";
            domainMap["PropRegRespCliente"] = "PROPREGRESPCLIENTE";
            domainMap["AssConEntregaGarantia"] = "ASSCONENTREGAGARANTIA";
            domainMap["AssConComporGarantia"] = "ASSCONCOMPORGARANTIA";
            domainMap["AssConVerificaContaAtiva"] = "ASSCONVERIFICACONTAATIVA";
            domainMap["AssConContratarProduto"] = "ASSCONCONTRATARPRODUTO";
            domainMap["AssConConfecContrato"] = "ASSCONCONFECCONTRATO";
            domainMap["AssConRegEnvContCliente"] = "ASSCONREGENVCONTCLIENTE";
            domainMap["AssConRegResContCliente"] = "ASSCONREGRESCONTCLIENTE";
            domainMap["AssConRecolherAssinatura"] = "ASSCONRECOLHERASSINATURA";
            domainMap["EncRealizadoOnboard"] = "ENCREALIZADOONBOARD";
            domainMap["EncPesquisaAvaliacao"] = "ENCPESQUISAAVALIACAO";
         }
         return (string)domainMap[key] ;
      }

   }

}
