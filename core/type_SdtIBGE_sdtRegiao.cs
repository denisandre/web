/*
				   File: type_SdtIBGE_sdtRegiao
			Description: IBGE_sdtRegiao
				 Author: Nemo 🐠 for C# (.NET) version 18.0.4.173650
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using GeneXus.Programs;
namespace GeneXus.Programs.core
{
	[XmlRoot(ElementName="IBGE_sdtRegiao")]
	[XmlType(TypeName="IBGE_sdtRegiao" , Namespace="agl_tresorygroup" )]
	[Serializable]
	public class SdtIBGE_sdtRegiao : GxUserType
	{
		public SdtIBGE_sdtRegiao( )
		{
			/* Constructor for serialization */
			gxTv_SdtIBGE_sdtRegiao_Sigla = "";

			gxTv_SdtIBGE_sdtRegiao_Nome = "";

		}

		public SdtIBGE_sdtRegiao(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("id", gxTpr_Id, false);


			AddObjectProperty("sigla", gxTpr_Sigla, false);


			AddObjectProperty("nome", gxTpr_Nome, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public string gxTpr_Id_double
		{
			get {
				return Convert.ToString(gxTv_SdtIBGE_sdtRegiao_Id, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtIBGE_sdtRegiao_Id = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Id
		{
			get {
				return gxTv_SdtIBGE_sdtRegiao_Id; 
			}
			set {
				gxTv_SdtIBGE_sdtRegiao_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="sigla")]
		[XmlElement(ElementName="sigla")]
		public string gxTpr_Sigla
		{
			get {
				return gxTv_SdtIBGE_sdtRegiao_Sigla; 
			}
			set {
				gxTv_SdtIBGE_sdtRegiao_Sigla = value;
				SetDirty("Sigla");
			}
		}




		[SoapElement(ElementName="nome")]
		[XmlElement(ElementName="nome")]
		public string gxTpr_Nome
		{
			get {
				return gxTv_SdtIBGE_sdtRegiao_Nome; 
			}
			set {
				gxTv_SdtIBGE_sdtRegiao_Nome = value;
				SetDirty("Nome");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtIBGE_sdtRegiao_Sigla = "";
			gxTv_SdtIBGE_sdtRegiao_Nome = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected decimal gxTv_SdtIBGE_sdtRegiao_Id;
		 

		protected string gxTv_SdtIBGE_sdtRegiao_Sigla;
		 

		protected string gxTv_SdtIBGE_sdtRegiao_Nome;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"IBGE_sdtRegiao", Namespace="agl_tresorygroup")]
	public class SdtIBGE_sdtRegiao_RESTInterface : GxGenericCollectionItem<SdtIBGE_sdtRegiao>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtIBGE_sdtRegiao_RESTInterface( ) : base()
		{	
		}

		public SdtIBGE_sdtRegiao_RESTInterface( SdtIBGE_sdtRegiao psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Id, 10, 5));

			}
			set { 
				sdt.gxTpr_Id =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="sigla", Order=1)]
		public  string gxTpr_Sigla
		{
			get { 
				return sdt.gxTpr_Sigla;

			}
			set { 
				 sdt.gxTpr_Sigla = value;
			}
		}

		[DataMember(Name="nome", Order=2)]
		public  string gxTpr_Nome
		{
			get { 
				return sdt.gxTpr_Nome;

			}
			set { 
				 sdt.gxTpr_Nome = value;
			}
		}


		#endregion

		public SdtIBGE_sdtRegiao sdt
		{
			get { 
				return (SdtIBGE_sdtRegiao)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtIBGE_sdtRegiao() ;
			}
		}
	}
	#endregion
}