/*
				   File: type_SdtIBGE_sdtMesorregiao
			Description: IBGE_sdtMesorregiao
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
	[XmlRoot(ElementName="IBGE_sdtMesorregiao")]
	[XmlType(TypeName="IBGE_sdtMesorregiao" , Namespace="agl_tresorygroup" )]
	[Serializable]
	public class SdtIBGE_sdtMesorregiao : GxUserType
	{
		public SdtIBGE_sdtMesorregiao( )
		{
			/* Constructor for serialization */
			gxTv_SdtIBGE_sdtMesorregiao_Nome = "";

		}

		public SdtIBGE_sdtMesorregiao(IGxContext context)
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

			if (gxTv_SdtIBGE_sdtMesorregiao_Uf != null)
			{
				AddObjectProperty("UF", gxTv_SdtIBGE_sdtMesorregiao_Uf, false);
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
				return Convert.ToString(gxTv_SdtIBGE_sdtMesorregiao_Id, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtIBGE_sdtMesorregiao_Id = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Id
		{
			get {
				return gxTv_SdtIBGE_sdtMesorregiao_Id; 
			}
			set {
				gxTv_SdtIBGE_sdtMesorregiao_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="nome")]
		[XmlElement(ElementName="nome")]
		public string gxTpr_Nome
		{
			get {
				return gxTv_SdtIBGE_sdtMesorregiao_Nome; 
			}
			set {
				gxTv_SdtIBGE_sdtMesorregiao_Nome = value;
				SetDirty("Nome");
			}
		}



		[SoapElement(ElementName="UF")]
		[XmlElement(ElementName="UF")]
		public GeneXus.Programs.core.SdtIBGE_sdtUF gxTpr_Uf
		{
			get {
				if ( gxTv_SdtIBGE_sdtMesorregiao_Uf == null )
				{
					gxTv_SdtIBGE_sdtMesorregiao_Uf = new GeneXus.Programs.core.SdtIBGE_sdtUF(context);
				}
				return gxTv_SdtIBGE_sdtMesorregiao_Uf; 
			}
			set {
				gxTv_SdtIBGE_sdtMesorregiao_Uf = value;
				SetDirty("Uf");
			}
		}
		public void gxTv_SdtIBGE_sdtMesorregiao_Uf_SetNull()
		{
			gxTv_SdtIBGE_sdtMesorregiao_Uf_N = true;
			gxTv_SdtIBGE_sdtMesorregiao_Uf = null;
		}

		public bool gxTv_SdtIBGE_sdtMesorregiao_Uf_IsNull()
		{
			return gxTv_SdtIBGE_sdtMesorregiao_Uf == null;
		}
		public bool ShouldSerializegxTpr_Uf_Json()
		{
			return gxTv_SdtIBGE_sdtMesorregiao_Uf != null;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtIBGE_sdtMesorregiao_Nome = "";

			gxTv_SdtIBGE_sdtMesorregiao_Uf_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected decimal gxTv_SdtIBGE_sdtMesorregiao_Id;
		 

		protected string gxTv_SdtIBGE_sdtMesorregiao_Nome;
		 

		protected GeneXus.Programs.core.SdtIBGE_sdtUF gxTv_SdtIBGE_sdtMesorregiao_Uf = null;
		protected bool gxTv_SdtIBGE_sdtMesorregiao_Uf_N;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"IBGE_sdtMesorregiao", Namespace="agl_tresorygroup")]
	public class SdtIBGE_sdtMesorregiao_RESTInterface : GxGenericCollectionItem<SdtIBGE_sdtMesorregiao>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtIBGE_sdtMesorregiao_RESTInterface( ) : base()
		{	
		}

		public SdtIBGE_sdtMesorregiao_RESTInterface( SdtIBGE_sdtMesorregiao psdt ) : base(psdt)
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

		[DataMember(Name="UF", Order=2, EmitDefaultValue=false)]
		public GeneXus.Programs.core.SdtIBGE_sdtUF_RESTInterface gxTpr_Uf
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Uf_Json())
					return new GeneXus.Programs.core.SdtIBGE_sdtUF_RESTInterface(sdt.gxTpr_Uf);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Uf = value.sdt;
			}
		}


		#endregion

		public SdtIBGE_sdtMesorregiao sdt
		{
			get { 
				return (SdtIBGE_sdtMesorregiao)Sdt;
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
				sdt = new SdtIBGE_sdtMesorregiao() ;
			}
		}
	}
	#endregion
}