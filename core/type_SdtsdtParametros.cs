/*
				   File: type_SdtsdtParametros
			Description: sdtParametros
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
	[XmlRoot(ElementName="sdtParametros")]
	[XmlType(TypeName="sdtParametros" , Namespace="agl_tresorygroup" )]
	[Serializable]
	public class SdtsdtParametros : GxUserType
	{
		public SdtsdtParametros( )
		{
			/* Constructor for serialization */
			gxTv_SdtsdtParametros_Parametrochave = "";

			gxTv_SdtsdtParametros_Parametrodescricao = "";

			gxTv_SdtsdtParametros_Parametrovalor = "";

			gxTv_SdtsdtParametros_Parametrodeldatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtParametros_Parametrodeldata = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtParametros_Parametrodelhora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtParametros_Parametrodelusuid = "";

			gxTv_SdtsdtParametros_Parametrodelusunome = "";

		}

		public SdtsdtParametros(IGxContext context)
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
			AddObjectProperty("ParametroChave", gxTpr_Parametrochave, false);


			AddObjectProperty("ParametroDescricao", gxTpr_Parametrodescricao, false);


			AddObjectProperty("ParametroValor", gxTpr_Parametrovalor, false);


			AddObjectProperty("ParametroDel", gxTpr_Parametrodel, false);


			datetime_STZ = gxTpr_Parametrodeldatahora;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("ParametroDelDataHora", sDateCnv, false);



			datetime_STZ = gxTpr_Parametrodeldata;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("ParametroDelData", sDateCnv, false);



			datetime_STZ = gxTpr_Parametrodelhora;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("ParametroDelHora", sDateCnv, false);



			AddObjectProperty("ParametroDelUsuId", gxTpr_Parametrodelusuid, false);


			AddObjectProperty("ParametroDelUsuNome", gxTpr_Parametrodelusunome, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ParametroChave")]
		[XmlElement(ElementName="ParametroChave")]
		public string gxTpr_Parametrochave
		{
			get {
				return gxTv_SdtsdtParametros_Parametrochave; 
			}
			set {
				gxTv_SdtsdtParametros_Parametrochave = value;
				SetDirty("Parametrochave");
			}
		}




		[SoapElement(ElementName="ParametroDescricao")]
		[XmlElement(ElementName="ParametroDescricao")]
		public string gxTpr_Parametrodescricao
		{
			get {
				return gxTv_SdtsdtParametros_Parametrodescricao; 
			}
			set {
				gxTv_SdtsdtParametros_Parametrodescricao = value;
				SetDirty("Parametrodescricao");
			}
		}




		[SoapElement(ElementName="ParametroValor")]
		[XmlElement(ElementName="ParametroValor")]
		public string gxTpr_Parametrovalor
		{
			get {
				return gxTv_SdtsdtParametros_Parametrovalor; 
			}
			set {
				gxTv_SdtsdtParametros_Parametrovalor = value;
				SetDirty("Parametrovalor");
			}
		}




		[SoapElement(ElementName="ParametroDel")]
		[XmlElement(ElementName="ParametroDel")]
		public bool gxTpr_Parametrodel
		{
			get {
				return gxTv_SdtsdtParametros_Parametrodel; 
			}
			set {
				gxTv_SdtsdtParametros_Parametrodel = value;
				SetDirty("Parametrodel");
			}
		}



		[SoapElement(ElementName="ParametroDelDataHora")]
		[XmlElement(ElementName="ParametroDelDataHora" , IsNullable=true)]
		public string gxTpr_Parametrodeldatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtParametros_Parametrodeldatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtParametros_Parametrodeldatahora).value ;
			}
			set {
				gxTv_SdtsdtParametros_Parametrodeldatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Parametrodeldatahora
		{
			get {
				return gxTv_SdtsdtParametros_Parametrodeldatahora; 
			}
			set {
				gxTv_SdtsdtParametros_Parametrodeldatahora = value;
				SetDirty("Parametrodeldatahora");
			}
		}


		[SoapElement(ElementName="ParametroDelData")]
		[XmlElement(ElementName="ParametroDelData" , IsNullable=true)]
		public string gxTpr_Parametrodeldata_Nullable
		{
			get {
				if ( gxTv_SdtsdtParametros_Parametrodeldata == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtParametros_Parametrodeldata).value ;
			}
			set {
				gxTv_SdtsdtParametros_Parametrodeldata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Parametrodeldata
		{
			get {
				return gxTv_SdtsdtParametros_Parametrodeldata; 
			}
			set {
				gxTv_SdtsdtParametros_Parametrodeldata = value;
				SetDirty("Parametrodeldata");
			}
		}


		[SoapElement(ElementName="ParametroDelHora")]
		[XmlElement(ElementName="ParametroDelHora" , IsNullable=true)]
		public string gxTpr_Parametrodelhora_Nullable
		{
			get {
				if ( gxTv_SdtsdtParametros_Parametrodelhora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtParametros_Parametrodelhora).value ;
			}
			set {
				gxTv_SdtsdtParametros_Parametrodelhora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Parametrodelhora
		{
			get {
				return gxTv_SdtsdtParametros_Parametrodelhora; 
			}
			set {
				gxTv_SdtsdtParametros_Parametrodelhora = value;
				SetDirty("Parametrodelhora");
			}
		}



		[SoapElement(ElementName="ParametroDelUsuId")]
		[XmlElement(ElementName="ParametroDelUsuId")]
		public string gxTpr_Parametrodelusuid
		{
			get {
				return gxTv_SdtsdtParametros_Parametrodelusuid; 
			}
			set {
				gxTv_SdtsdtParametros_Parametrodelusuid = value;
				SetDirty("Parametrodelusuid");
			}
		}




		[SoapElement(ElementName="ParametroDelUsuNome")]
		[XmlElement(ElementName="ParametroDelUsuNome")]
		public string gxTpr_Parametrodelusunome
		{
			get {
				return gxTv_SdtsdtParametros_Parametrodelusunome; 
			}
			set {
				gxTv_SdtsdtParametros_Parametrodelusunome = value;
				SetDirty("Parametrodelusunome");
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
			gxTv_SdtsdtParametros_Parametrochave = "";
			gxTv_SdtsdtParametros_Parametrodescricao = "";
			gxTv_SdtsdtParametros_Parametrovalor = "";

			gxTv_SdtsdtParametros_Parametrodeldatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtParametros_Parametrodeldata = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtParametros_Parametrodelhora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtParametros_Parametrodelusuid = "";
			gxTv_SdtsdtParametros_Parametrodelusunome = "";
			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected string gxTv_SdtsdtParametros_Parametrochave;
		 

		protected string gxTv_SdtsdtParametros_Parametrodescricao;
		 

		protected string gxTv_SdtsdtParametros_Parametrovalor;
		 

		protected bool gxTv_SdtsdtParametros_Parametrodel;
		 

		protected DateTime gxTv_SdtsdtParametros_Parametrodeldatahora;
		 

		protected DateTime gxTv_SdtsdtParametros_Parametrodeldata;
		 

		protected DateTime gxTv_SdtsdtParametros_Parametrodelhora;
		 

		protected string gxTv_SdtsdtParametros_Parametrodelusuid;
		 

		protected string gxTv_SdtsdtParametros_Parametrodelusunome;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"sdtParametros", Namespace="agl_tresorygroup")]
	public class SdtsdtParametros_RESTInterface : GxGenericCollectionItem<SdtsdtParametros>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtsdtParametros_RESTInterface( ) : base()
		{	
		}

		public SdtsdtParametros_RESTInterface( SdtsdtParametros psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ParametroChave", Order=0)]
		public  string gxTpr_Parametrochave
		{
			get { 
				return sdt.gxTpr_Parametrochave;

			}
			set { 
				 sdt.gxTpr_Parametrochave = value;
			}
		}

		[DataMember(Name="ParametroDescricao", Order=1)]
		public  string gxTpr_Parametrodescricao
		{
			get { 
				return sdt.gxTpr_Parametrodescricao;

			}
			set { 
				 sdt.gxTpr_Parametrodescricao = value;
			}
		}

		[DataMember(Name="ParametroValor", Order=2)]
		public  string gxTpr_Parametrovalor
		{
			get { 
				return sdt.gxTpr_Parametrovalor;

			}
			set { 
				 sdt.gxTpr_Parametrovalor = value;
			}
		}

		[DataMember(Name="ParametroDel", Order=3)]
		public bool gxTpr_Parametrodel
		{
			get { 
				return sdt.gxTpr_Parametrodel;

			}
			set { 
				sdt.gxTpr_Parametrodel = value;
			}
		}

		[DataMember(Name="ParametroDelDataHora", Order=4)]
		public  string gxTpr_Parametrodeldatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Parametrodeldatahora);

			}
			set { 
				sdt.gxTpr_Parametrodeldatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="ParametroDelData", Order=5)]
		public  string gxTpr_Parametrodeldata
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Parametrodeldata);

			}
			set { 
				sdt.gxTpr_Parametrodeldata = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="ParametroDelHora", Order=6)]
		public  string gxTpr_Parametrodelhora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Parametrodelhora);

			}
			set { 
				sdt.gxTpr_Parametrodelhora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="ParametroDelUsuId", Order=7)]
		public  string gxTpr_Parametrodelusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Parametrodelusuid);

			}
			set { 
				 sdt.gxTpr_Parametrodelusuid = value;
			}
		}

		[DataMember(Name="ParametroDelUsuNome", Order=8)]
		public  string gxTpr_Parametrodelusunome
		{
			get { 
				return sdt.gxTpr_Parametrodelusunome;

			}
			set { 
				 sdt.gxTpr_Parametrodelusunome = value;
			}
		}


		#endregion

		public SdtsdtParametros sdt
		{
			get { 
				return (SdtsdtParametros)Sdt;
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
				sdt = new SdtsdtParametros() ;
			}
		}
	}
	#endregion
}