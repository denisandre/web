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
   public class gxdomainibge_endpointlocalidades
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainibge_endpointlocalidades ()
      {
         domain["https://servicodados.ibge.gov.br/api/v1/localidades/regioes"] = "Região";
         domain["https://servicodados.ibge.gov.br/api/v1/localidades/estados"] = "UF";
         domain["https://servicodados.ibge.gov.br/api/v1/localidades/mesorregioes"] = "Mesorregião";
         domain["https://servicodados.ibge.gov.br/api/v1/localidades/microrregioes"] = "Microrregião";
         domain["https://servicodados.ibge.gov.br/api/v1/localidades/municipios"] = "Município";
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
            domainMap["REGIAO"] = "https://servicodados.ibge.gov.br/api/v1/localidades/regioes";
            domainMap["UF"] = "https://servicodados.ibge.gov.br/api/v1/localidades/estados";
            domainMap["MESORREGIAO"] = "https://servicodados.ibge.gov.br/api/v1/localidades/mesorregioes";
            domainMap["MICRORREGIAO"] = "https://servicodados.ibge.gov.br/api/v1/localidades/microrregioes";
            domainMap["MUNICIPIO"] = "https://servicodados.ibge.gov.br/api/v1/localidades/municipios";
         }
         return (string)domainMap[key] ;
      }

   }

}
