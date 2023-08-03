/*
				   File: type_SdtsdtTabelaDePreco_ProdutoItem
			Description: Produto
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
	[XmlRoot(ElementName="sdtTabelaDePreco.ProdutoItem")]
	[XmlType(TypeName="sdtTabelaDePreco.ProdutoItem" , Namespace="agl_tresorygroup" )]
	[Serializable]
	public class SdtsdtTabelaDePreco_ProdutoItem : GxUserType
	{
		public SdtsdtTabelaDePreco_ProdutoItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtsdtTabelaDePreco_ProdutoItem_Prdcodigo = "";

			gxTv_SdtsdtTabelaDePreco_ProdutoItem_Prdnome = "";

			gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1deldatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1deldata = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1delhora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1delusuid = "";

			gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1delusunome = "";

		}

		public SdtsdtTabelaDePreco_ProdutoItem(IGxContext context)
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
			AddObjectProperty("PrdID", gxTpr_Prdid, false);


			AddObjectProperty("PrdCodigo", gxTpr_Prdcodigo, false);


			AddObjectProperty("PrdNome", gxTpr_Prdnome, false);


			AddObjectProperty("PrdTipoID", gxTpr_Prdtipoid, false);


			AddObjectProperty("PrdAtivo", gxTpr_Prdativo, false);


			AddObjectProperty("Tpp1Preco", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Tpp1preco, 16, 2)), false);


			AddObjectProperty("Tpp1Del", gxTpr_Tpp1del, false);


			datetime_STZ = gxTpr_Tpp1deldatahora;
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
			AddObjectProperty("Tpp1DelDataHora", sDateCnv, false);



			datetime_STZ = gxTpr_Tpp1deldata;
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
			AddObjectProperty("Tpp1DelData", sDateCnv, false);



			datetime_STZ = gxTpr_Tpp1delhora;
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
			AddObjectProperty("Tpp1DelHora", sDateCnv, false);



			AddObjectProperty("Tpp1DelUsuId", gxTpr_Tpp1delusuid, false);


			AddObjectProperty("Tpp1DelUsuNome", gxTpr_Tpp1delusunome, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PrdID")]
		[XmlElement(ElementName="PrdID")]
		public Guid gxTpr_Prdid
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_ProdutoItem_Prdid; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_ProdutoItem_Prdid = value;
				SetDirty("Prdid");
			}
		}




		[SoapElement(ElementName="PrdCodigo")]
		[XmlElement(ElementName="PrdCodigo")]
		public string gxTpr_Prdcodigo
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_ProdutoItem_Prdcodigo; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_ProdutoItem_Prdcodigo = value;
				SetDirty("Prdcodigo");
			}
		}




		[SoapElement(ElementName="PrdNome")]
		[XmlElement(ElementName="PrdNome")]
		public string gxTpr_Prdnome
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_ProdutoItem_Prdnome; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_ProdutoItem_Prdnome = value;
				SetDirty("Prdnome");
			}
		}




		[SoapElement(ElementName="PrdTipoID")]
		[XmlElement(ElementName="PrdTipoID")]
		public int gxTpr_Prdtipoid
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_ProdutoItem_Prdtipoid; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_ProdutoItem_Prdtipoid = value;
				SetDirty("Prdtipoid");
			}
		}




		[SoapElement(ElementName="PrdAtivo")]
		[XmlElement(ElementName="PrdAtivo")]
		public bool gxTpr_Prdativo
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_ProdutoItem_Prdativo; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_ProdutoItem_Prdativo = value;
				SetDirty("Prdativo");
			}
		}



		[SoapElement(ElementName="Tpp1Preco")]
		[XmlElement(ElementName="Tpp1Preco")]
		public string gxTpr_Tpp1preco_double
		{
			get {
				return Convert.ToString(gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1preco, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1preco = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tpp1preco
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1preco; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1preco = value;
				SetDirty("Tpp1preco");
			}
		}




		[SoapElement(ElementName="Tpp1Del")]
		[XmlElement(ElementName="Tpp1Del")]
		public bool gxTpr_Tpp1del
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1del; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1del = value;
				SetDirty("Tpp1del");
			}
		}



		[SoapElement(ElementName="Tpp1DelDataHora")]
		[XmlElement(ElementName="Tpp1DelDataHora" , IsNullable=true)]
		public string gxTpr_Tpp1deldatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1deldatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1deldatahora).value ;
			}
			set {
				gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1deldatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Tpp1deldatahora
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1deldatahora; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1deldatahora = value;
				SetDirty("Tpp1deldatahora");
			}
		}


		[SoapElement(ElementName="Tpp1DelData")]
		[XmlElement(ElementName="Tpp1DelData" , IsNullable=true)]
		public string gxTpr_Tpp1deldata_Nullable
		{
			get {
				if ( gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1deldata == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1deldata).value ;
			}
			set {
				gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1deldata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Tpp1deldata
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1deldata; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1deldata = value;
				SetDirty("Tpp1deldata");
			}
		}


		[SoapElement(ElementName="Tpp1DelHora")]
		[XmlElement(ElementName="Tpp1DelHora" , IsNullable=true)]
		public string gxTpr_Tpp1delhora_Nullable
		{
			get {
				if ( gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1delhora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1delhora).value ;
			}
			set {
				gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1delhora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Tpp1delhora
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1delhora; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1delhora = value;
				SetDirty("Tpp1delhora");
			}
		}



		[SoapElement(ElementName="Tpp1DelUsuId")]
		[XmlElement(ElementName="Tpp1DelUsuId")]
		public string gxTpr_Tpp1delusuid
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1delusuid; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1delusuid = value;
				SetDirty("Tpp1delusuid");
			}
		}




		[SoapElement(ElementName="Tpp1DelUsuNome")]
		[XmlElement(ElementName="Tpp1DelUsuNome")]
		public string gxTpr_Tpp1delusunome
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1delusunome; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1delusunome = value;
				SetDirty("Tpp1delusunome");
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
			gxTv_SdtsdtTabelaDePreco_ProdutoItem_Prdcodigo = "";
			gxTv_SdtsdtTabelaDePreco_ProdutoItem_Prdnome = "";

			gxTv_SdtsdtTabelaDePreco_ProdutoItem_Prdativo = true;


			gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1deldatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1deldata = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1delhora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1delusuid = "";
			gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1delusunome = "";
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

		protected Guid gxTv_SdtsdtTabelaDePreco_ProdutoItem_Prdid;
		 

		protected string gxTv_SdtsdtTabelaDePreco_ProdutoItem_Prdcodigo;
		 

		protected string gxTv_SdtsdtTabelaDePreco_ProdutoItem_Prdnome;
		 

		protected int gxTv_SdtsdtTabelaDePreco_ProdutoItem_Prdtipoid;
		 

		protected bool gxTv_SdtsdtTabelaDePreco_ProdutoItem_Prdativo;
		 

		protected decimal gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1preco;
		 

		protected bool gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1del;
		 

		protected DateTime gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1deldatahora;
		 

		protected DateTime gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1deldata;
		 

		protected DateTime gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1delhora;
		 

		protected string gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1delusuid;
		 

		protected string gxTv_SdtsdtTabelaDePreco_ProdutoItem_Tpp1delusunome;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"sdtTabelaDePreco.ProdutoItem", Namespace="agl_tresorygroup")]
	public class SdtsdtTabelaDePreco_ProdutoItem_RESTInterface : GxGenericCollectionItem<SdtsdtTabelaDePreco_ProdutoItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtsdtTabelaDePreco_ProdutoItem_RESTInterface( ) : base()
		{	
		}

		public SdtsdtTabelaDePreco_ProdutoItem_RESTInterface( SdtsdtTabelaDePreco_ProdutoItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="PrdID", Order=0)]
		public Guid gxTpr_Prdid
		{
			get { 
				return sdt.gxTpr_Prdid;

			}
			set { 
				sdt.gxTpr_Prdid = value;
			}
		}

		[DataMember(Name="PrdCodigo", Order=1)]
		public  string gxTpr_Prdcodigo
		{
			get { 
				return sdt.gxTpr_Prdcodigo;

			}
			set { 
				 sdt.gxTpr_Prdcodigo = value;
			}
		}

		[DataMember(Name="PrdNome", Order=2)]
		public  string gxTpr_Prdnome
		{
			get { 
				return sdt.gxTpr_Prdnome;

			}
			set { 
				 sdt.gxTpr_Prdnome = value;
			}
		}

		[DataMember(Name="PrdTipoID", Order=3)]
		public  string gxTpr_Prdtipoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Prdtipoid, 9, 0));

			}
			set { 
				sdt.gxTpr_Prdtipoid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="PrdAtivo", Order=4)]
		public bool gxTpr_Prdativo
		{
			get { 
				return sdt.gxTpr_Prdativo;

			}
			set { 
				sdt.gxTpr_Prdativo = value;
			}
		}

		[DataMember(Name="Tpp1Preco", Order=5)]
		public  string gxTpr_Tpp1preco
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tpp1preco, 16, 2));

			}
			set { 
				sdt.gxTpr_Tpp1preco =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Tpp1Del", Order=6)]
		public bool gxTpr_Tpp1del
		{
			get { 
				return sdt.gxTpr_Tpp1del;

			}
			set { 
				sdt.gxTpr_Tpp1del = value;
			}
		}

		[DataMember(Name="Tpp1DelDataHora", Order=7)]
		public  string gxTpr_Tpp1deldatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Tpp1deldatahora);

			}
			set { 
				sdt.gxTpr_Tpp1deldatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="Tpp1DelData", Order=8)]
		public  string gxTpr_Tpp1deldata
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Tpp1deldata);

			}
			set { 
				sdt.gxTpr_Tpp1deldata = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="Tpp1DelHora", Order=9)]
		public  string gxTpr_Tpp1delhora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Tpp1delhora);

			}
			set { 
				sdt.gxTpr_Tpp1delhora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="Tpp1DelUsuId", Order=10)]
		public  string gxTpr_Tpp1delusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tpp1delusuid);

			}
			set { 
				 sdt.gxTpr_Tpp1delusuid = value;
			}
		}

		[DataMember(Name="Tpp1DelUsuNome", Order=11)]
		public  string gxTpr_Tpp1delusunome
		{
			get { 
				return sdt.gxTpr_Tpp1delusunome;

			}
			set { 
				 sdt.gxTpr_Tpp1delusunome = value;
			}
		}


		#endregion

		public SdtsdtTabelaDePreco_ProdutoItem sdt
		{
			get { 
				return (SdtsdtTabelaDePreco_ProdutoItem)Sdt;
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
				sdt = new SdtsdtTabelaDePreco_ProdutoItem() ;
			}
		}
	}
	#endregion
}