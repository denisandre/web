/*
				   File: type_SdtIBGE_sdtMicrorregiao
			Description: IBGE_sdtMicrorregiao
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
	[XmlRoot(ElementName="IBGE_sdtMicrorregiao")]
	[XmlType(TypeName="IBGE_sdtMicrorregiao" , Namespace="agl_tresorygroup" )]
	[Serializable]
	public class SdtIBGE_sdtMicrorregiao : GxUserType
	{
		public SdtIBGE_sdtMicrorregiao( )
		{
			/* Constructor for serialization */
			gxTv_SdtIBGE_sdtMicrorregiao_Nome = "";

		}

		public SdtIBGE_sdtMicrorregiao(IGxContext context)
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

			if (gxTv_SdtIBGE_sdtMicrorregiao_Mesorregiao != null)
			{
				AddObjectProperty("mesorregiao", gxTv_SdtIBGE_sdtMicrorregiao_Mesorregiao, false);
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
				return Convert.ToString(gxTv_SdtIBGE_sdtMicrorregiao_Id, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtIBGE_sdtMicrorregiao_Id = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Id
		{
			get {
				return gxTv_SdtIBGE_sdtMicrorregiao_Id; 
			}
			set {
				gxTv_SdtIBGE_sdtMicrorregiao_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="nome")]
		[XmlElement(ElementName="nome")]
		public string gxTpr_Nome
		{
			get {
				return gxTv_SdtIBGE_sdtMicrorregiao_Nome; 
			}
			set {
				gxTv_SdtIBGE_sdtMicrorregiao_Nome = value;
				SetDirty("Nome");
			}
		}



		[SoapElement(ElementName="mesorregiao")]
		[XmlElement(ElementName="mesorregiao")]
		public GeneXus.Programs.core.SdtIBGE_sdtMesorregiao gxTpr_Mesorregiao
		{
			get {
				if ( gxTv_SdtIBGE_sdtMicrorregiao_Mesorregiao == null )
				{
					gxTv_SdtIBGE_sdtMicrorregiao_Mesorregiao = new GeneXus.Programs.core.SdtIBGE_sdtMesorregiao(context);
				}
				return gxTv_SdtIBGE_sdtMicrorregiao_Mesorregiao; 
			}
			set {
				gxTv_SdtIBGE_sdtMicrorregiao_Mesorregiao = value;
				SetDirty("Mesorregiao");
			}
		}
		public void gxTv_SdtIBGE_sdtMicrorregiao_Mesorregiao_SetNull()
		{
			gxTv_SdtIBGE_sdtMicrorregiao_Mesorregiao_N = true;
			gxTv_SdtIBGE_sdtMicrorregiao_Mesorregiao = null;
		}

		public bool gxTv_SdtIBGE_sdtMicrorregiao_Mesorregiao_IsNull()
		{
			return gxTv_SdtIBGE_sdtMicrorregiao_Mesorregiao == null;
		}
		public bool ShouldSerializegxTpr_Mesorregiao_Json()
		{
			return gxTv_SdtIBGE_sdtMicrorregiao_Mesorregiao != null;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtIBGE_sdtMicrorregiao_Nome = "";

			gxTv_SdtIBGE_sdtMicrorregiao_Mesorregiao_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected decimal gxTv_SdtIBGE_sdtMicrorregiao_Id;
		 

		protected string gxTv_SdtIBGE_sdtMicrorregiao_Nome;
		 

		protected GeneXus.Programs.core.SdtIBGE_sdtMesorregiao gxTv_SdtIBGE_sdtMicrorregiao_Mesorregiao = null;
		protected bool gxTv_SdtIBGE_sdtMicrorregiao_Mesorregiao_N;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"IBGE_sdtMicrorregiao", Namespace="agl_tresorygroup")]
	public class SdtIBGE_sdtMicrorregiao_RESTInterface : GxGenericCollectionItem<SdtIBGE_sdtMicrorregiao>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtIBGE_sdtMicrorregiao_RESTInterface( ) : base()
		{	
		}

		public SdtIBGE_sdtMicrorregiao_RESTInterface( SdtIBGE_sdtMicrorregiao psdt ) : base(psdt)
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

		[DataMember(Name="mesorregiao", Order=2, EmitDefaultValue=false)]
		public GeneXus.Programs.core.SdtIBGE_sdtMesorregiao_RESTInterface gxTpr_Mesorregiao
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Mesorregiao_Json())
					return new GeneXus.Programs.core.SdtIBGE_sdtMesorregiao_RESTInterface(sdt.gxTpr_Mesorregiao);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Mesorregiao = value.sdt;
			}
		}


		#endregion

		public SdtIBGE_sdtMicrorregiao sdt
		{
			get { 
				return (SdtIBGE_sdtMicrorregiao)Sdt;
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
				sdt = new SdtIBGE_sdtMicrorregiao() ;
			}
		}
	}
	#endregion
}