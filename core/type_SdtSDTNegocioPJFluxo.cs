/*
				   File: type_SdtSDTNegocioPJFluxo
			Description: SDTNegocioPJFluxo
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
	[XmlRoot(ElementName="SDTNegocioPJFluxo")]
	[XmlType(TypeName="SDTNegocioPJFluxo" , Namespace="agl_tresorygroup" )]
	[Serializable]
	public class SdtSDTNegocioPJFluxo : GxUserType
	{
		public SdtSDTNegocioPJFluxo( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTNegocioPJFluxo_Nefchave = "";

			gxTv_SdtSDTNegocioPJFluxo_Neftexto = "";

			gxTv_SdtSDTNegocioPJFluxo_Nefinsdatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTNegocioPJFluxo_Nefinsdata = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTNegocioPJFluxo_Nefinshora = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTNegocioPJFluxo_Nefinsusuid = "";

			gxTv_SdtSDTNegocioPJFluxo_Nefinsusunome = "";

			gxTv_SdtSDTNegocioPJFluxo_Nefupddatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTNegocioPJFluxo_Nefupddata = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTNegocioPJFluxo_Nefupdhora = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTNegocioPJFluxo_Nefupdusuid = "";

			gxTv_SdtSDTNegocioPJFluxo_Nefupdusunome = "";

		}

		public SdtSDTNegocioPJFluxo(IGxContext context)
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
			AddObjectProperty("NegID", gxTpr_Negid, false);


			AddObjectProperty("NefChave", gxTpr_Nefchave, false);


			AddObjectProperty("NefConfirmado", gxTpr_Nefconfirmado, false);


			AddObjectProperty("NefTexto", gxTpr_Neftexto, false);


			datetime_STZ = gxTpr_Nefinsdatahora;
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
			AddObjectProperty("NefInsDataHora", sDateCnv, false);



			datetime_STZ = gxTpr_Nefinsdata;
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
			AddObjectProperty("NefInsData", sDateCnv, false);



			datetime_STZ = gxTpr_Nefinshora;
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
			AddObjectProperty("NefInsHora", sDateCnv, false);



			AddObjectProperty("NefInsUsuId", gxTpr_Nefinsusuid, false);


			AddObjectProperty("NefInsUsuNome", gxTpr_Nefinsusunome, false);


			datetime_STZ = gxTpr_Nefupddatahora;
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
			AddObjectProperty("NefUpdDataHora", sDateCnv, false);



			datetime_STZ = gxTpr_Nefupddata;
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
			AddObjectProperty("NefUpdData", sDateCnv, false);



			datetime_STZ = gxTpr_Nefupdhora;
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
			AddObjectProperty("NefUpdHora", sDateCnv, false);



			AddObjectProperty("NefUpdUsuId", gxTpr_Nefupdusuid, false);


			AddObjectProperty("NefUpdUsuNome", gxTpr_Nefupdusunome, false);


			AddObjectProperty("NefValor", gxTpr_Nefvalor, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="NegID")]
		[XmlElement(ElementName="NegID")]
		public Guid gxTpr_Negid
		{
			get {
				return gxTv_SdtSDTNegocioPJFluxo_Negid; 
			}
			set {
				gxTv_SdtSDTNegocioPJFluxo_Negid = value;
				SetDirty("Negid");
			}
		}




		[SoapElement(ElementName="NefChave")]
		[XmlElement(ElementName="NefChave")]
		public string gxTpr_Nefchave
		{
			get {
				return gxTv_SdtSDTNegocioPJFluxo_Nefchave; 
			}
			set {
				gxTv_SdtSDTNegocioPJFluxo_Nefchave = value;
				SetDirty("Nefchave");
			}
		}




		[SoapElement(ElementName="NefConfirmado")]
		[XmlElement(ElementName="NefConfirmado")]
		public bool gxTpr_Nefconfirmado
		{
			get {
				return gxTv_SdtSDTNegocioPJFluxo_Nefconfirmado; 
			}
			set {
				gxTv_SdtSDTNegocioPJFluxo_Nefconfirmado = value;
				SetDirty("Nefconfirmado");
			}
		}




		[SoapElement(ElementName="NefTexto")]
		[XmlElement(ElementName="NefTexto")]
		public string gxTpr_Neftexto
		{
			get {
				return gxTv_SdtSDTNegocioPJFluxo_Neftexto; 
			}
			set {
				gxTv_SdtSDTNegocioPJFluxo_Neftexto = value;
				SetDirty("Neftexto");
			}
		}



		[SoapElement(ElementName="NefInsDataHora")]
		[XmlElement(ElementName="NefInsDataHora" , IsNullable=true)]
		public string gxTpr_Nefinsdatahora_Nullable
		{
			get {
				if ( gxTv_SdtSDTNegocioPJFluxo_Nefinsdatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTNegocioPJFluxo_Nefinsdatahora).value ;
			}
			set {
				gxTv_SdtSDTNegocioPJFluxo_Nefinsdatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Nefinsdatahora
		{
			get {
				return gxTv_SdtSDTNegocioPJFluxo_Nefinsdatahora; 
			}
			set {
				gxTv_SdtSDTNegocioPJFluxo_Nefinsdatahora = value;
				SetDirty("Nefinsdatahora");
			}
		}


		[SoapElement(ElementName="NefInsData")]
		[XmlElement(ElementName="NefInsData" , IsNullable=true)]
		public string gxTpr_Nefinsdata_Nullable
		{
			get {
				if ( gxTv_SdtSDTNegocioPJFluxo_Nefinsdata == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTNegocioPJFluxo_Nefinsdata).value ;
			}
			set {
				gxTv_SdtSDTNegocioPJFluxo_Nefinsdata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Nefinsdata
		{
			get {
				return gxTv_SdtSDTNegocioPJFluxo_Nefinsdata; 
			}
			set {
				gxTv_SdtSDTNegocioPJFluxo_Nefinsdata = value;
				SetDirty("Nefinsdata");
			}
		}


		[SoapElement(ElementName="NefInsHora")]
		[XmlElement(ElementName="NefInsHora" , IsNullable=true)]
		public string gxTpr_Nefinshora_Nullable
		{
			get {
				if ( gxTv_SdtSDTNegocioPJFluxo_Nefinshora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTNegocioPJFluxo_Nefinshora).value ;
			}
			set {
				gxTv_SdtSDTNegocioPJFluxo_Nefinshora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Nefinshora
		{
			get {
				return gxTv_SdtSDTNegocioPJFluxo_Nefinshora; 
			}
			set {
				gxTv_SdtSDTNegocioPJFluxo_Nefinshora = value;
				SetDirty("Nefinshora");
			}
		}



		[SoapElement(ElementName="NefInsUsuId")]
		[XmlElement(ElementName="NefInsUsuId")]
		public string gxTpr_Nefinsusuid
		{
			get {
				return gxTv_SdtSDTNegocioPJFluxo_Nefinsusuid; 
			}
			set {
				gxTv_SdtSDTNegocioPJFluxo_Nefinsusuid = value;
				SetDirty("Nefinsusuid");
			}
		}




		[SoapElement(ElementName="NefInsUsuNome")]
		[XmlElement(ElementName="NefInsUsuNome")]
		public string gxTpr_Nefinsusunome
		{
			get {
				return gxTv_SdtSDTNegocioPJFluxo_Nefinsusunome; 
			}
			set {
				gxTv_SdtSDTNegocioPJFluxo_Nefinsusunome = value;
				SetDirty("Nefinsusunome");
			}
		}



		[SoapElement(ElementName="NefUpdDataHora")]
		[XmlElement(ElementName="NefUpdDataHora" , IsNullable=true)]
		public string gxTpr_Nefupddatahora_Nullable
		{
			get {
				if ( gxTv_SdtSDTNegocioPJFluxo_Nefupddatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTNegocioPJFluxo_Nefupddatahora).value ;
			}
			set {
				gxTv_SdtSDTNegocioPJFluxo_Nefupddatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Nefupddatahora
		{
			get {
				return gxTv_SdtSDTNegocioPJFluxo_Nefupddatahora; 
			}
			set {
				gxTv_SdtSDTNegocioPJFluxo_Nefupddatahora = value;
				SetDirty("Nefupddatahora");
			}
		}


		[SoapElement(ElementName="NefUpdData")]
		[XmlElement(ElementName="NefUpdData" , IsNullable=true)]
		public string gxTpr_Nefupddata_Nullable
		{
			get {
				if ( gxTv_SdtSDTNegocioPJFluxo_Nefupddata == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTNegocioPJFluxo_Nefupddata).value ;
			}
			set {
				gxTv_SdtSDTNegocioPJFluxo_Nefupddata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Nefupddata
		{
			get {
				return gxTv_SdtSDTNegocioPJFluxo_Nefupddata; 
			}
			set {
				gxTv_SdtSDTNegocioPJFluxo_Nefupddata = value;
				SetDirty("Nefupddata");
			}
		}


		[SoapElement(ElementName="NefUpdHora")]
		[XmlElement(ElementName="NefUpdHora" , IsNullable=true)]
		public string gxTpr_Nefupdhora_Nullable
		{
			get {
				if ( gxTv_SdtSDTNegocioPJFluxo_Nefupdhora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTNegocioPJFluxo_Nefupdhora).value ;
			}
			set {
				gxTv_SdtSDTNegocioPJFluxo_Nefupdhora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Nefupdhora
		{
			get {
				return gxTv_SdtSDTNegocioPJFluxo_Nefupdhora; 
			}
			set {
				gxTv_SdtSDTNegocioPJFluxo_Nefupdhora = value;
				SetDirty("Nefupdhora");
			}
		}



		[SoapElement(ElementName="NefUpdUsuId")]
		[XmlElement(ElementName="NefUpdUsuId")]
		public string gxTpr_Nefupdusuid
		{
			get {
				return gxTv_SdtSDTNegocioPJFluxo_Nefupdusuid; 
			}
			set {
				gxTv_SdtSDTNegocioPJFluxo_Nefupdusuid = value;
				SetDirty("Nefupdusuid");
			}
		}




		[SoapElement(ElementName="NefUpdUsuNome")]
		[XmlElement(ElementName="NefUpdUsuNome")]
		public string gxTpr_Nefupdusunome
		{
			get {
				return gxTv_SdtSDTNegocioPJFluxo_Nefupdusunome; 
			}
			set {
				gxTv_SdtSDTNegocioPJFluxo_Nefupdusunome = value;
				SetDirty("Nefupdusunome");
			}
		}




		[SoapElement(ElementName="NefValor")]
		[XmlElement(ElementName="NefValor")]
		public short gxTpr_Nefvalor
		{
			get {
				return gxTv_SdtSDTNegocioPJFluxo_Nefvalor; 
			}
			set {
				gxTv_SdtSDTNegocioPJFluxo_Nefvalor = value;
				SetDirty("Nefvalor");
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
			gxTv_SdtSDTNegocioPJFluxo_Nefchave = "";

			gxTv_SdtSDTNegocioPJFluxo_Neftexto = "";
			gxTv_SdtSDTNegocioPJFluxo_Nefinsdatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDTNegocioPJFluxo_Nefinsdata = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDTNegocioPJFluxo_Nefinshora = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDTNegocioPJFluxo_Nefinsusuid = "";
			gxTv_SdtSDTNegocioPJFluxo_Nefinsusunome = "";
			gxTv_SdtSDTNegocioPJFluxo_Nefupddatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDTNegocioPJFluxo_Nefupddata = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDTNegocioPJFluxo_Nefupdhora = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDTNegocioPJFluxo_Nefupdusuid = "";
			gxTv_SdtSDTNegocioPJFluxo_Nefupdusunome = "";

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

		protected Guid gxTv_SdtSDTNegocioPJFluxo_Negid;
		 

		protected string gxTv_SdtSDTNegocioPJFluxo_Nefchave;
		 

		protected bool gxTv_SdtSDTNegocioPJFluxo_Nefconfirmado;
		 

		protected string gxTv_SdtSDTNegocioPJFluxo_Neftexto;
		 

		protected DateTime gxTv_SdtSDTNegocioPJFluxo_Nefinsdatahora;
		 

		protected DateTime gxTv_SdtSDTNegocioPJFluxo_Nefinsdata;
		 

		protected DateTime gxTv_SdtSDTNegocioPJFluxo_Nefinshora;
		 

		protected string gxTv_SdtSDTNegocioPJFluxo_Nefinsusuid;
		 

		protected string gxTv_SdtSDTNegocioPJFluxo_Nefinsusunome;
		 

		protected DateTime gxTv_SdtSDTNegocioPJFluxo_Nefupddatahora;
		 

		protected DateTime gxTv_SdtSDTNegocioPJFluxo_Nefupddata;
		 

		protected DateTime gxTv_SdtSDTNegocioPJFluxo_Nefupdhora;
		 

		protected string gxTv_SdtSDTNegocioPJFluxo_Nefupdusuid;
		 

		protected string gxTv_SdtSDTNegocioPJFluxo_Nefupdusunome;
		 

		protected short gxTv_SdtSDTNegocioPJFluxo_Nefvalor;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"SDTNegocioPJFluxo", Namespace="agl_tresorygroup")]
	public class SdtSDTNegocioPJFluxo_RESTInterface : GxGenericCollectionItem<SdtSDTNegocioPJFluxo>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTNegocioPJFluxo_RESTInterface( ) : base()
		{	
		}

		public SdtSDTNegocioPJFluxo_RESTInterface( SdtSDTNegocioPJFluxo psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="NegID", Order=0)]
		public Guid gxTpr_Negid
		{
			get { 
				return sdt.gxTpr_Negid;

			}
			set { 
				sdt.gxTpr_Negid = value;
			}
		}

		[DataMember(Name="NefChave", Order=1)]
		public  string gxTpr_Nefchave
		{
			get { 
				return sdt.gxTpr_Nefchave;

			}
			set { 
				 sdt.gxTpr_Nefchave = value;
			}
		}

		[DataMember(Name="NefConfirmado", Order=2)]
		public bool gxTpr_Nefconfirmado
		{
			get { 
				return sdt.gxTpr_Nefconfirmado;

			}
			set { 
				sdt.gxTpr_Nefconfirmado = value;
			}
		}

		[DataMember(Name="NefTexto", Order=3)]
		public  string gxTpr_Neftexto
		{
			get { 
				return sdt.gxTpr_Neftexto;

			}
			set { 
				 sdt.gxTpr_Neftexto = value;
			}
		}

		[DataMember(Name="NefInsDataHora", Order=4)]
		public  string gxTpr_Nefinsdatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Nefinsdatahora);

			}
			set { 
				sdt.gxTpr_Nefinsdatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="NefInsData", Order=5)]
		public  string gxTpr_Nefinsdata
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Nefinsdata);

			}
			set { 
				sdt.gxTpr_Nefinsdata = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="NefInsHora", Order=6)]
		public  string gxTpr_Nefinshora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Nefinshora);

			}
			set { 
				sdt.gxTpr_Nefinshora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="NefInsUsuId", Order=7)]
		public  string gxTpr_Nefinsusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nefinsusuid);

			}
			set { 
				 sdt.gxTpr_Nefinsusuid = value;
			}
		}

		[DataMember(Name="NefInsUsuNome", Order=8)]
		public  string gxTpr_Nefinsusunome
		{
			get { 
				return sdt.gxTpr_Nefinsusunome;

			}
			set { 
				 sdt.gxTpr_Nefinsusunome = value;
			}
		}

		[DataMember(Name="NefUpdDataHora", Order=9)]
		public  string gxTpr_Nefupddatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Nefupddatahora);

			}
			set { 
				sdt.gxTpr_Nefupddatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="NefUpdData", Order=10)]
		public  string gxTpr_Nefupddata
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Nefupddata);

			}
			set { 
				sdt.gxTpr_Nefupddata = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="NefUpdHora", Order=11)]
		public  string gxTpr_Nefupdhora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Nefupdhora);

			}
			set { 
				sdt.gxTpr_Nefupdhora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="NefUpdUsuId", Order=12)]
		public  string gxTpr_Nefupdusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nefupdusuid);

			}
			set { 
				 sdt.gxTpr_Nefupdusuid = value;
			}
		}

		[DataMember(Name="NefUpdUsuNome", Order=13)]
		public  string gxTpr_Nefupdusunome
		{
			get { 
				return sdt.gxTpr_Nefupdusunome;

			}
			set { 
				 sdt.gxTpr_Nefupdusunome = value;
			}
		}

		[DataMember(Name="NefValor", Order=14)]
		public short gxTpr_Nefvalor
		{
			get { 
				return sdt.gxTpr_Nefvalor;

			}
			set { 
				sdt.gxTpr_Nefvalor = value;
			}
		}


		#endregion

		public SdtSDTNegocioPJFluxo sdt
		{
			get { 
				return (SdtSDTNegocioPJFluxo)Sdt;
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
				sdt = new SdtSDTNegocioPJFluxo() ;
			}
		}
	}
	#endregion
}