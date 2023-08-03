/*
				   File: type_SdtsdtTabelaDePreco
			Description: sdtTabelaDePreco
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
	[XmlRoot(ElementName="sdtTabelaDePreco")]
	[XmlType(TypeName="sdtTabelaDePreco" , Namespace="agl_tresorygroup" )]
	[Serializable]
	public class SdtsdtTabelaDePreco : GxUserType
	{
		public SdtsdtTabelaDePreco( )
		{
			/* Constructor for serialization */
			gxTv_SdtsdtTabelaDePreco_Tppcodigo = "";

			gxTv_SdtsdtTabelaDePreco_Tppnome = "";

			gxTv_SdtsdtTabelaDePreco_Tppinshora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtTabelaDePreco_Tppinsdatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtTabelaDePreco_Tppinsusuid = "";

			gxTv_SdtsdtTabelaDePreco_Tppinsusunome = "";

			gxTv_SdtsdtTabelaDePreco_Tppupdhora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtTabelaDePreco_Tppupddatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtTabelaDePreco_Tppupdusuid = "";

			gxTv_SdtsdtTabelaDePreco_Tppupdusunome = "";

			gxTv_SdtsdtTabelaDePreco_Tppdeldatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtTabelaDePreco_Tppdeldata = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtTabelaDePreco_Tppdelhora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtTabelaDePreco_Tppdelusuid = "";

			gxTv_SdtsdtTabelaDePreco_Tppdelusunome = "";

		}

		public SdtsdtTabelaDePreco(IGxContext context)
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
			AddObjectProperty("TppID", gxTpr_Tppid, false);


			AddObjectProperty("TppCodigo", gxTpr_Tppcodigo, false);


			AddObjectProperty("TppNome", gxTpr_Tppnome, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Tppinsdata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Tppinsdata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Tppinsdata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TppInsData", sDateCnv, false);



			datetime_STZ = gxTpr_Tppinshora;
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
			AddObjectProperty("TppInsHora", sDateCnv, false);



			datetime_STZ = gxTpr_Tppinsdatahora;
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
			AddObjectProperty("TppInsDataHora", sDateCnv, false);



			AddObjectProperty("TppInsUsuID", gxTpr_Tppinsusuid, false);


			AddObjectProperty("TppInsUsuNome", gxTpr_Tppinsusunome, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Tppupddata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Tppupddata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Tppupddata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TppUpdData", sDateCnv, false);



			datetime_STZ = gxTpr_Tppupdhora;
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
			AddObjectProperty("TppUpdHora", sDateCnv, false);



			datetime_STZ = gxTpr_Tppupddatahora;
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
			AddObjectProperty("TppUpdDataHora", sDateCnv, false);



			AddObjectProperty("TppUpdUsuID", gxTpr_Tppupdusuid, false);


			AddObjectProperty("TppUpdUsuNome", gxTpr_Tppupdusunome, false);


			AddObjectProperty("TppAtivo", gxTpr_Tppativo, false);


			AddObjectProperty("TppDel", gxTpr_Tppdel, false);


			datetime_STZ = gxTpr_Tppdeldatahora;
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
			AddObjectProperty("TppDelDataHora", sDateCnv, false);



			datetime_STZ = gxTpr_Tppdeldata;
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
			AddObjectProperty("TppDelData", sDateCnv, false);



			datetime_STZ = gxTpr_Tppdelhora;
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
			AddObjectProperty("TppDelHora", sDateCnv, false);



			AddObjectProperty("TppDelUsuId", gxTpr_Tppdelusuid, false);


			AddObjectProperty("TppDelUsuNome", gxTpr_Tppdelusunome, false);

			if (gxTv_SdtsdtTabelaDePreco_Produto != null)
			{
				AddObjectProperty("Produto", gxTv_SdtsdtTabelaDePreco_Produto, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TppID")]
		[XmlElement(ElementName="TppID")]
		public Guid gxTpr_Tppid
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_Tppid; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppid = value;
				SetDirty("Tppid");
			}
		}




		[SoapElement(ElementName="TppCodigo")]
		[XmlElement(ElementName="TppCodigo")]
		public string gxTpr_Tppcodigo
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_Tppcodigo; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppcodigo = value;
				SetDirty("Tppcodigo");
			}
		}




		[SoapElement(ElementName="TppNome")]
		[XmlElement(ElementName="TppNome")]
		public string gxTpr_Tppnome
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_Tppnome; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppnome = value;
				SetDirty("Tppnome");
			}
		}



		[SoapElement(ElementName="TppInsData")]
		[XmlElement(ElementName="TppInsData" , IsNullable=true)]
		public string gxTpr_Tppinsdata_Nullable
		{
			get {
				if ( gxTv_SdtsdtTabelaDePreco_Tppinsdata == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtsdtTabelaDePreco_Tppinsdata).value ;
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppinsdata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Tppinsdata
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_Tppinsdata; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppinsdata = value;
				SetDirty("Tppinsdata");
			}
		}


		[SoapElement(ElementName="TppInsHora")]
		[XmlElement(ElementName="TppInsHora" , IsNullable=true)]
		public string gxTpr_Tppinshora_Nullable
		{
			get {
				if ( gxTv_SdtsdtTabelaDePreco_Tppinshora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtTabelaDePreco_Tppinshora).value ;
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppinshora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Tppinshora
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_Tppinshora; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppinshora = value;
				SetDirty("Tppinshora");
			}
		}


		[SoapElement(ElementName="TppInsDataHora")]
		[XmlElement(ElementName="TppInsDataHora" , IsNullable=true)]
		public string gxTpr_Tppinsdatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtTabelaDePreco_Tppinsdatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtTabelaDePreco_Tppinsdatahora).value ;
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppinsdatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Tppinsdatahora
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_Tppinsdatahora; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppinsdatahora = value;
				SetDirty("Tppinsdatahora");
			}
		}



		[SoapElement(ElementName="TppInsUsuID")]
		[XmlElement(ElementName="TppInsUsuID")]
		public string gxTpr_Tppinsusuid
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_Tppinsusuid; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppinsusuid = value;
				SetDirty("Tppinsusuid");
			}
		}




		[SoapElement(ElementName="TppInsUsuNome")]
		[XmlElement(ElementName="TppInsUsuNome")]
		public string gxTpr_Tppinsusunome
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_Tppinsusunome; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppinsusunome = value;
				SetDirty("Tppinsusunome");
			}
		}



		[SoapElement(ElementName="TppUpdData")]
		[XmlElement(ElementName="TppUpdData" , IsNullable=true)]
		public string gxTpr_Tppupddata_Nullable
		{
			get {
				if ( gxTv_SdtsdtTabelaDePreco_Tppupddata == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtsdtTabelaDePreco_Tppupddata).value ;
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppupddata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Tppupddata
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_Tppupddata; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppupddata = value;
				SetDirty("Tppupddata");
			}
		}


		[SoapElement(ElementName="TppUpdHora")]
		[XmlElement(ElementName="TppUpdHora" , IsNullable=true)]
		public string gxTpr_Tppupdhora_Nullable
		{
			get {
				if ( gxTv_SdtsdtTabelaDePreco_Tppupdhora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtTabelaDePreco_Tppupdhora).value ;
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppupdhora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Tppupdhora
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_Tppupdhora; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppupdhora = value;
				SetDirty("Tppupdhora");
			}
		}


		[SoapElement(ElementName="TppUpdDataHora")]
		[XmlElement(ElementName="TppUpdDataHora" , IsNullable=true)]
		public string gxTpr_Tppupddatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtTabelaDePreco_Tppupddatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtTabelaDePreco_Tppupddatahora).value ;
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppupddatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Tppupddatahora
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_Tppupddatahora; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppupddatahora = value;
				SetDirty("Tppupddatahora");
			}
		}



		[SoapElement(ElementName="TppUpdUsuID")]
		[XmlElement(ElementName="TppUpdUsuID")]
		public string gxTpr_Tppupdusuid
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_Tppupdusuid; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppupdusuid = value;
				SetDirty("Tppupdusuid");
			}
		}




		[SoapElement(ElementName="TppUpdUsuNome")]
		[XmlElement(ElementName="TppUpdUsuNome")]
		public string gxTpr_Tppupdusunome
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_Tppupdusunome; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppupdusunome = value;
				SetDirty("Tppupdusunome");
			}
		}




		[SoapElement(ElementName="TppAtivo")]
		[XmlElement(ElementName="TppAtivo")]
		public bool gxTpr_Tppativo
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_Tppativo; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppativo = value;
				SetDirty("Tppativo");
			}
		}




		[SoapElement(ElementName="TppDel")]
		[XmlElement(ElementName="TppDel")]
		public bool gxTpr_Tppdel
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_Tppdel; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppdel = value;
				SetDirty("Tppdel");
			}
		}



		[SoapElement(ElementName="TppDelDataHora")]
		[XmlElement(ElementName="TppDelDataHora" , IsNullable=true)]
		public string gxTpr_Tppdeldatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtTabelaDePreco_Tppdeldatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtTabelaDePreco_Tppdeldatahora).value ;
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppdeldatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Tppdeldatahora
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_Tppdeldatahora; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppdeldatahora = value;
				SetDirty("Tppdeldatahora");
			}
		}


		[SoapElement(ElementName="TppDelData")]
		[XmlElement(ElementName="TppDelData" , IsNullable=true)]
		public string gxTpr_Tppdeldata_Nullable
		{
			get {
				if ( gxTv_SdtsdtTabelaDePreco_Tppdeldata == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtTabelaDePreco_Tppdeldata).value ;
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppdeldata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Tppdeldata
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_Tppdeldata; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppdeldata = value;
				SetDirty("Tppdeldata");
			}
		}


		[SoapElement(ElementName="TppDelHora")]
		[XmlElement(ElementName="TppDelHora" , IsNullable=true)]
		public string gxTpr_Tppdelhora_Nullable
		{
			get {
				if ( gxTv_SdtsdtTabelaDePreco_Tppdelhora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtTabelaDePreco_Tppdelhora).value ;
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppdelhora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Tppdelhora
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_Tppdelhora; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppdelhora = value;
				SetDirty("Tppdelhora");
			}
		}



		[SoapElement(ElementName="TppDelUsuId")]
		[XmlElement(ElementName="TppDelUsuId")]
		public string gxTpr_Tppdelusuid
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_Tppdelusuid; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppdelusuid = value;
				SetDirty("Tppdelusuid");
			}
		}




		[SoapElement(ElementName="TppDelUsuNome")]
		[XmlElement(ElementName="TppDelUsuNome")]
		public string gxTpr_Tppdelusunome
		{
			get {
				return gxTv_SdtsdtTabelaDePreco_Tppdelusunome; 
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Tppdelusunome = value;
				SetDirty("Tppdelusunome");
			}
		}




		[SoapElement(ElementName="Produto" )]
		[XmlArray(ElementName="Produto"  )]
		[XmlArrayItemAttribute(ElementName="ProdutoItem" , IsNullable=false )]
		public GXBaseCollection<SdtsdtTabelaDePreco_ProdutoItem> gxTpr_Produto
		{
			get {
				if ( gxTv_SdtsdtTabelaDePreco_Produto == null )
				{
					gxTv_SdtsdtTabelaDePreco_Produto = new GXBaseCollection<SdtsdtTabelaDePreco_ProdutoItem>( context, "sdtTabelaDePreco.ProdutoItem", "");
				}
				return gxTv_SdtsdtTabelaDePreco_Produto;
			}
			set {
				gxTv_SdtsdtTabelaDePreco_Produto_N = false;
				gxTv_SdtsdtTabelaDePreco_Produto = value;
				SetDirty("Produto");
			}
		}

		public void gxTv_SdtsdtTabelaDePreco_Produto_SetNull()
		{
			gxTv_SdtsdtTabelaDePreco_Produto_N = true;
			gxTv_SdtsdtTabelaDePreco_Produto = null;
		}

		public bool gxTv_SdtsdtTabelaDePreco_Produto_IsNull()
		{
			return gxTv_SdtsdtTabelaDePreco_Produto == null;
		}
		public bool ShouldSerializegxTpr_Produto_GxSimpleCollection_Json()
		{
			return gxTv_SdtsdtTabelaDePreco_Produto != null && gxTv_SdtsdtTabelaDePreco_Produto.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtsdtTabelaDePreco_Tppcodigo = "";
			gxTv_SdtsdtTabelaDePreco_Tppnome = "";

			gxTv_SdtsdtTabelaDePreco_Tppinshora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtTabelaDePreco_Tppinsdatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtTabelaDePreco_Tppinsusuid = "";
			gxTv_SdtsdtTabelaDePreco_Tppinsusunome = "";

			gxTv_SdtsdtTabelaDePreco_Tppupdhora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtTabelaDePreco_Tppupddatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtTabelaDePreco_Tppupdusuid = "";
			gxTv_SdtsdtTabelaDePreco_Tppupdusunome = "";
			gxTv_SdtsdtTabelaDePreco_Tppativo = true;

			gxTv_SdtsdtTabelaDePreco_Tppdeldatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtTabelaDePreco_Tppdeldata = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtTabelaDePreco_Tppdelhora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtTabelaDePreco_Tppdelusuid = "";
			gxTv_SdtsdtTabelaDePreco_Tppdelusunome = "";

			gxTv_SdtsdtTabelaDePreco_Produto_N = true;

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

		protected Guid gxTv_SdtsdtTabelaDePreco_Tppid;
		 

		protected string gxTv_SdtsdtTabelaDePreco_Tppcodigo;
		 

		protected string gxTv_SdtsdtTabelaDePreco_Tppnome;
		 

		protected DateTime gxTv_SdtsdtTabelaDePreco_Tppinsdata;
		 

		protected DateTime gxTv_SdtsdtTabelaDePreco_Tppinshora;
		 

		protected DateTime gxTv_SdtsdtTabelaDePreco_Tppinsdatahora;
		 

		protected string gxTv_SdtsdtTabelaDePreco_Tppinsusuid;
		 

		protected string gxTv_SdtsdtTabelaDePreco_Tppinsusunome;
		 

		protected DateTime gxTv_SdtsdtTabelaDePreco_Tppupddata;
		 

		protected DateTime gxTv_SdtsdtTabelaDePreco_Tppupdhora;
		 

		protected DateTime gxTv_SdtsdtTabelaDePreco_Tppupddatahora;
		 

		protected string gxTv_SdtsdtTabelaDePreco_Tppupdusuid;
		 

		protected string gxTv_SdtsdtTabelaDePreco_Tppupdusunome;
		 

		protected bool gxTv_SdtsdtTabelaDePreco_Tppativo;
		 

		protected bool gxTv_SdtsdtTabelaDePreco_Tppdel;
		 

		protected DateTime gxTv_SdtsdtTabelaDePreco_Tppdeldatahora;
		 

		protected DateTime gxTv_SdtsdtTabelaDePreco_Tppdeldata;
		 

		protected DateTime gxTv_SdtsdtTabelaDePreco_Tppdelhora;
		 

		protected string gxTv_SdtsdtTabelaDePreco_Tppdelusuid;
		 

		protected string gxTv_SdtsdtTabelaDePreco_Tppdelusunome;
		 
		protected bool gxTv_SdtsdtTabelaDePreco_Produto_N;
		protected GXBaseCollection<SdtsdtTabelaDePreco_ProdutoItem> gxTv_SdtsdtTabelaDePreco_Produto = null; 



		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"sdtTabelaDePreco", Namespace="agl_tresorygroup")]
	public class SdtsdtTabelaDePreco_RESTInterface : GxGenericCollectionItem<SdtsdtTabelaDePreco>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtsdtTabelaDePreco_RESTInterface( ) : base()
		{	
		}

		public SdtsdtTabelaDePreco_RESTInterface( SdtsdtTabelaDePreco psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="TppID", Order=0)]
		public Guid gxTpr_Tppid
		{
			get { 
				return sdt.gxTpr_Tppid;

			}
			set { 
				sdt.gxTpr_Tppid = value;
			}
		}

		[DataMember(Name="TppCodigo", Order=1)]
		public  string gxTpr_Tppcodigo
		{
			get { 
				return sdt.gxTpr_Tppcodigo;

			}
			set { 
				 sdt.gxTpr_Tppcodigo = value;
			}
		}

		[DataMember(Name="TppNome", Order=2)]
		public  string gxTpr_Tppnome
		{
			get { 
				return sdt.gxTpr_Tppnome;

			}
			set { 
				 sdt.gxTpr_Tppnome = value;
			}
		}

		[DataMember(Name="TppInsData", Order=3)]
		public  string gxTpr_Tppinsdata
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Tppinsdata);

			}
			set { 
				sdt.gxTpr_Tppinsdata = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="TppInsHora", Order=4)]
		public  string gxTpr_Tppinshora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Tppinshora);

			}
			set { 
				sdt.gxTpr_Tppinshora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="TppInsDataHora", Order=5)]
		public  string gxTpr_Tppinsdatahora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Tppinsdatahora);

			}
			set { 
				sdt.gxTpr_Tppinsdatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="TppInsUsuID", Order=6)]
		public  string gxTpr_Tppinsusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tppinsusuid);

			}
			set { 
				 sdt.gxTpr_Tppinsusuid = value;
			}
		}

		[DataMember(Name="TppInsUsuNome", Order=7)]
		public  string gxTpr_Tppinsusunome
		{
			get { 
				return sdt.gxTpr_Tppinsusunome;

			}
			set { 
				 sdt.gxTpr_Tppinsusunome = value;
			}
		}

		[DataMember(Name="TppUpdData", Order=8)]
		public  string gxTpr_Tppupddata
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Tppupddata);

			}
			set { 
				sdt.gxTpr_Tppupddata = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="TppUpdHora", Order=9)]
		public  string gxTpr_Tppupdhora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Tppupdhora);

			}
			set { 
				sdt.gxTpr_Tppupdhora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="TppUpdDataHora", Order=10)]
		public  string gxTpr_Tppupddatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Tppupddatahora);

			}
			set { 
				sdt.gxTpr_Tppupddatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="TppUpdUsuID", Order=11)]
		public  string gxTpr_Tppupdusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tppupdusuid);

			}
			set { 
				 sdt.gxTpr_Tppupdusuid = value;
			}
		}

		[DataMember(Name="TppUpdUsuNome", Order=12)]
		public  string gxTpr_Tppupdusunome
		{
			get { 
				return sdt.gxTpr_Tppupdusunome;

			}
			set { 
				 sdt.gxTpr_Tppupdusunome = value;
			}
		}

		[DataMember(Name="TppAtivo", Order=13)]
		public bool gxTpr_Tppativo
		{
			get { 
				return sdt.gxTpr_Tppativo;

			}
			set { 
				sdt.gxTpr_Tppativo = value;
			}
		}

		[DataMember(Name="TppDel", Order=14)]
		public bool gxTpr_Tppdel
		{
			get { 
				return sdt.gxTpr_Tppdel;

			}
			set { 
				sdt.gxTpr_Tppdel = value;
			}
		}

		[DataMember(Name="TppDelDataHora", Order=15)]
		public  string gxTpr_Tppdeldatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Tppdeldatahora);

			}
			set { 
				sdt.gxTpr_Tppdeldatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="TppDelData", Order=16)]
		public  string gxTpr_Tppdeldata
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Tppdeldata);

			}
			set { 
				sdt.gxTpr_Tppdeldata = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="TppDelHora", Order=17)]
		public  string gxTpr_Tppdelhora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Tppdelhora);

			}
			set { 
				sdt.gxTpr_Tppdelhora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="TppDelUsuId", Order=18)]
		public  string gxTpr_Tppdelusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tppdelusuid);

			}
			set { 
				 sdt.gxTpr_Tppdelusuid = value;
			}
		}

		[DataMember(Name="TppDelUsuNome", Order=19)]
		public  string gxTpr_Tppdelusunome
		{
			get { 
				return sdt.gxTpr_Tppdelusunome;

			}
			set { 
				 sdt.gxTpr_Tppdelusunome = value;
			}
		}

		[DataMember(Name="Produto", Order=20, EmitDefaultValue=false)]
		public GxGenericCollection<SdtsdtTabelaDePreco_ProdutoItem_RESTInterface> gxTpr_Produto
		{
			get {
				if (sdt.ShouldSerializegxTpr_Produto_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtsdtTabelaDePreco_ProdutoItem_RESTInterface>(sdt.gxTpr_Produto);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Produto);
			}
		}


		#endregion

		public SdtsdtTabelaDePreco sdt
		{
			get { 
				return (SdtsdtTabelaDePreco)Sdt;
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
				sdt = new SdtsdtTabelaDePreco() ;
			}
		}
	}
	#endregion
}