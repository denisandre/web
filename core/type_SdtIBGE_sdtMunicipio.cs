/*
				   File: type_SdtIBGE_sdtMunicipio
			Description: IBGE_sdtMunicipio
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
	[XmlRoot(ElementName="IBGE_sdtMunicipio")]
	[XmlType(TypeName="IBGE_sdtMunicipio" , Namespace="agl_tresorygroup" )]
	[Serializable]
	public class SdtIBGE_sdtMunicipio : GxUserType
	{
		public SdtIBGE_sdtMunicipio( )
		{
			/* Constructor for serialization */
			gxTv_SdtIBGE_sdtMunicipio_Nome = "";

		}

		public SdtIBGE_sdtMunicipio(IGxContext context)
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


			AddObjectProperty("nome", gxTpr_Nome, false);

			if (gxTv_SdtIBGE_sdtMunicipio_Microrregiao != null)
			{
				AddObjectProperty("microrregiao", gxTv_SdtIBGE_sdtMunicipio_Microrregiao, false);
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
				return Convert.ToString(gxTv_SdtIBGE_sdtMunicipio_Id, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtIBGE_sdtMunicipio_Id = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Id
		{
			get {
				return gxTv_SdtIBGE_sdtMunicipio_Id; 
			}
			set {
				gxTv_SdtIBGE_sdtMunicipio_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="nome")]
		[XmlElement(ElementName="nome")]
		public string gxTpr_Nome
		{
			get {
				return gxTv_SdtIBGE_sdtMunicipio_Nome; 
			}
			set {
				gxTv_SdtIBGE_sdtMunicipio_Nome = value;
				SetDirty("Nome");
			}
		}



		[SoapElement(ElementName="microrregiao")]
		[XmlElement(ElementName="microrregiao")]
		public GeneXus.Programs.core.SdtIBGE_sdtMicrorregiao gxTpr_Microrregiao
		{
			get {
				if ( gxTv_SdtIBGE_sdtMunicipio_Microrregiao == null )
				{
					gxTv_SdtIBGE_sdtMunicipio_Microrregiao = new GeneXus.Programs.core.SdtIBGE_sdtMicrorregiao(context);
				}
				return gxTv_SdtIBGE_sdtMunicipio_Microrregiao; 
			}
			set {
				gxTv_SdtIBGE_sdtMunicipio_Microrregiao = value;
				SetDirty("Microrregiao");
			}
		}
		public void gxTv_SdtIBGE_sdtMunicipio_Microrregiao_SetNull()
		{
			gxTv_SdtIBGE_sdtMunicipio_Microrregiao_N = true;
			gxTv_SdtIBGE_sdtMunicipio_Microrregiao = null;
		}

		public bool gxTv_SdtIBGE_sdtMunicipio_Microrregiao_IsNull()
		{
			return gxTv_SdtIBGE_sdtMunicipio_Microrregiao == null;
		}
		public bool ShouldSerializegxTpr_Microrregiao_Json()
		{
			return gxTv_SdtIBGE_sdtMunicipio_Microrregiao != null;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtIBGE_sdtMunicipio_Nome = "";

			gxTv_SdtIBGE_sdtMunicipio_Microrregiao_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected decimal gxTv_SdtIBGE_sdtMunicipio_Id;
		 

		protected string gxTv_SdtIBGE_sdtMunicipio_Nome;
		 

		protected GeneXus.Programs.core.SdtIBGE_sdtMicrorregiao gxTv_SdtIBGE_sdtMunicipio_Microrregiao = null;
		protected bool gxTv_SdtIBGE_sdtMunicipio_Microrregiao_N;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"IBGE_sdtMunicipio", Namespace="agl_tresorygroup")]
	public class SdtIBGE_sdtMunicipio_RESTInterface : GxGenericCollectionItem<SdtIBGE_sdtMunicipio>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtIBGE_sdtMunicipio_RESTInterface( ) : base()
		{	
		}

		public SdtIBGE_sdtMunicipio_RESTInterface( SdtIBGE_sdtMunicipio psdt ) : base(psdt)
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

		[DataMember(Name="nome", Order=1)]
		public  string gxTpr_Nome
		{
			get { 
				return sdt.gxTpr_Nome;

			}
			set { 
				 sdt.gxTpr_Nome = value;
			}
		}

		[DataMember(Name="microrregiao", Order=2, EmitDefaultValue=false)]
		public GeneXus.Programs.core.SdtIBGE_sdtMicrorregiao_RESTInterface gxTpr_Microrregiao
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Microrregiao_Json())
					return new GeneXus.Programs.core.SdtIBGE_sdtMicrorregiao_RESTInterface(sdt.gxTpr_Microrregiao);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Microrregiao = value.sdt;
			}
		}


		#endregion

		public SdtIBGE_sdtMunicipio sdt
		{
			get { 
				return (SdtIBGE_sdtMunicipio)Sdt;
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
				sdt = new SdtIBGE_sdtMunicipio() ;
			}
		}
	}
	#endregion
}