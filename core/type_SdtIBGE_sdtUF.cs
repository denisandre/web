/*
				   File: type_SdtIBGE_sdtUF
			Description: IBGE_sdtUF
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
	[XmlRoot(ElementName="IBGE_sdtUF")]
	[XmlType(TypeName="IBGE_sdtUF" , Namespace="agl_tresorygroup" )]
	[Serializable]
	public class SdtIBGE_sdtUF : GxUserType
	{
		public SdtIBGE_sdtUF( )
		{
			/* Constructor for serialization */
			gxTv_SdtIBGE_sdtUF_Sigla = "";

			gxTv_SdtIBGE_sdtUF_Nome = "";

		}

		public SdtIBGE_sdtUF(IGxContext context)
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

			if (gxTv_SdtIBGE_sdtUF_Regiao != null)
			{
				AddObjectProperty("regiao", gxTv_SdtIBGE_sdtUF_Regiao, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public string gxTpr_Id_double
		{
			get {
				return Convert.ToString(gxTv_SdtIBGE_sdtUF_Id, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtIBGE_sdtUF_Id = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Id
		{
			get {
				return gxTv_SdtIBGE_sdtUF_Id; 
			}
			set {
				gxTv_SdtIBGE_sdtUF_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="sigla")]
		[XmlElement(ElementName="sigla")]
		public string gxTpr_Sigla
		{
			get {
				return gxTv_SdtIBGE_sdtUF_Sigla; 
			}
			set {
				gxTv_SdtIBGE_sdtUF_Sigla = value;
				SetDirty("Sigla");
			}
		}




		[SoapElement(ElementName="nome")]
		[XmlElement(ElementName="nome")]
		public string gxTpr_Nome
		{
			get {
				return gxTv_SdtIBGE_sdtUF_Nome; 
			}
			set {
				gxTv_SdtIBGE_sdtUF_Nome = value;
				SetDirty("Nome");
			}
		}



		[SoapElement(ElementName="regiao")]
		[XmlElement(ElementName="regiao")]
		public GeneXus.Programs.core.SdtIBGE_sdtRegiao gxTpr_Regiao
		{
			get {
				if ( gxTv_SdtIBGE_sdtUF_Regiao == null )
				{
					gxTv_SdtIBGE_sdtUF_Regiao = new GeneXus.Programs.core.SdtIBGE_sdtRegiao(context);
				}
				return gxTv_SdtIBGE_sdtUF_Regiao; 
			}
			set {
				gxTv_SdtIBGE_sdtUF_Regiao = value;
				SetDirty("Regiao");
			}
		}
		public void gxTv_SdtIBGE_sdtUF_Regiao_SetNull()
		{
			gxTv_SdtIBGE_sdtUF_Regiao_N = true;
			gxTv_SdtIBGE_sdtUF_Regiao = null;
		}

		public bool gxTv_SdtIBGE_sdtUF_Regiao_IsNull()
		{
			return gxTv_SdtIBGE_sdtUF_Regiao == null;
		}
		public bool ShouldSerializegxTpr_Regiao_Json()
		{
			return gxTv_SdtIBGE_sdtUF_Regiao != null;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtIBGE_sdtUF_Sigla = "";
			gxTv_SdtIBGE_sdtUF_Nome = "";

			gxTv_SdtIBGE_sdtUF_Regiao_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected decimal gxTv_SdtIBGE_sdtUF_Id;
		 

		protected string gxTv_SdtIBGE_sdtUF_Sigla;
		 

		protected string gxTv_SdtIBGE_sdtUF_Nome;
		 

		protected GeneXus.Programs.core.SdtIBGE_sdtRegiao gxTv_SdtIBGE_sdtUF_Regiao = null;
		protected bool gxTv_SdtIBGE_sdtUF_Regiao_N;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"IBGE_sdtUF", Namespace="agl_tresorygroup")]
	public class SdtIBGE_sdtUF_RESTInterface : GxGenericCollectionItem<SdtIBGE_sdtUF>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtIBGE_sdtUF_RESTInterface( ) : base()
		{	
		}

		public SdtIBGE_sdtUF_RESTInterface( SdtIBGE_sdtUF psdt ) : base(psdt)
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

		[DataMember(Name="regiao", Order=3, EmitDefaultValue=false)]
		public GeneXus.Programs.core.SdtIBGE_sdtRegiao_RESTInterface gxTpr_Regiao
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Regiao_Json())
					return new GeneXus.Programs.core.SdtIBGE_sdtRegiao_RESTInterface(sdt.gxTpr_Regiao);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Regiao = value.sdt;
			}
		}


		#endregion

		public SdtIBGE_sdtUF sdt
		{
			get { 
				return (SdtIBGE_sdtUF)Sdt;
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
				sdt = new SdtIBGE_sdtUF() ;
			}
		}
	}
	#endregion
}