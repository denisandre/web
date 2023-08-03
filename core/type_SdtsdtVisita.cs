/*
				   File: type_SdtsdtVisita
			Description: sdtVisita
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
	[XmlRoot(ElementName="sdtVisita")]
	[XmlType(TypeName="sdtVisita" , Namespace="agl_tresorygroup" )]
	[Serializable]
	public class SdtsdtVisita : GxUserType
	{
		public SdtsdtVisita( )
		{
			/* Constructor for serialization */
			gxTv_SdtsdtVisita_Vispaihora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtVisita_Vispaidatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtVisita_Vispaiassunto = "";

			gxTv_SdtsdtVisita_Visinshora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtVisita_Visinsdatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtVisita_Visinsusuid = "";

			gxTv_SdtsdtVisita_Visinsusunome = "";

			gxTv_SdtsdtVisita_Visupdhora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtVisita_Visupddatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtVisita_Visupdusuid = "";

			gxTv_SdtsdtVisita_Visupdusunome = "";

			gxTv_SdtsdtVisita_Vishora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtVisita_Visdatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtVisita_Vishorafim = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtVisita_Visdatahorafim = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtVisita_Vistiposigla = "";

			gxTv_SdtsdtVisita_Vistiponome = "";

			gxTv_SdtsdtVisita_Visnegassunto = "";

			gxTv_SdtsdtVisita_Visnegclinomefamiliar = "";

			gxTv_SdtsdtVisita_Visnegcpjnomfan = "";

			gxTv_SdtsdtVisita_Visnegcpjrazsocial = "";

			gxTv_SdtsdtVisita_Visngfitenome = "";

			gxTv_SdtsdtVisita_Visassunto = "";

			gxTv_SdtsdtVisita_Visdescricao = "";

			gxTv_SdtsdtVisita_Vislink = "";

			gxTv_SdtsdtVisita_Vissituacao = "";

			gxTv_SdtsdtVisita_Visdeldatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtVisita_Visdeldata = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtVisita_Visdelhora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtVisita_Visdelusuid = "";

			gxTv_SdtsdtVisita_Visdelusunome = "";

		}

		public SdtsdtVisita(IGxContext context)
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
			AddObjectProperty("VisID", gxTpr_Visid, false);


			AddObjectProperty("VisPaiID", gxTpr_Vispaiid, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Vispaidata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Vispaidata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Vispaidata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("VisPaiData", sDateCnv, false);



			datetime_STZ = gxTpr_Vispaihora;
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
			AddObjectProperty("VisPaiHora", sDateCnv, false);



			datetime_STZ = gxTpr_Vispaidatahora;
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
			AddObjectProperty("VisPaiDataHora", sDateCnv, false);



			AddObjectProperty("VisPaiAssunto", gxTpr_Vispaiassunto, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Visinsdata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Visinsdata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Visinsdata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("VisInsData", sDateCnv, false);



			datetime_STZ = gxTpr_Visinshora;
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
			AddObjectProperty("VisInsHora", sDateCnv, false);



			datetime_STZ = gxTpr_Visinsdatahora;
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
			AddObjectProperty("VisInsDataHora", sDateCnv, false);



			AddObjectProperty("VisInsUsuID", gxTpr_Visinsusuid, false);


			AddObjectProperty("VisInsUsuNome", gxTpr_Visinsusunome, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Visupddata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Visupddata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Visupddata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("VisUpdData", sDateCnv, false);



			datetime_STZ = gxTpr_Visupdhora;
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
			AddObjectProperty("VisUpdHora", sDateCnv, false);



			datetime_STZ = gxTpr_Visupddatahora;
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
			AddObjectProperty("VisUpdDataHora", sDateCnv, false);



			AddObjectProperty("VisUpdUsuID", gxTpr_Visupdusuid, false);


			AddObjectProperty("VisUpdUsuNome", gxTpr_Visupdusunome, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Visdata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Visdata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Visdata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("VisData", sDateCnv, false);



			datetime_STZ = gxTpr_Vishora;
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
			AddObjectProperty("VisHora", sDateCnv, false);



			datetime_STZ = gxTpr_Visdatahora;
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
			AddObjectProperty("VisDataHora", sDateCnv, false);



			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Visdatafim)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Visdatafim)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Visdatafim)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("VisDataFim", sDateCnv, false);



			datetime_STZ = gxTpr_Vishorafim;
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
			AddObjectProperty("VisHoraFim", sDateCnv, false);



			datetime_STZ = gxTpr_Visdatahorafim;
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
			AddObjectProperty("VisDataHoraFim", sDateCnv, false);



			AddObjectProperty("VisTipoID", gxTpr_Vistipoid, false);


			AddObjectProperty("VisTipoSigla", gxTpr_Vistiposigla, false);


			AddObjectProperty("VisTipoNome", gxTpr_Vistiponome, false);


			AddObjectProperty("VisNegID", gxTpr_Visnegid, false);


			AddObjectProperty("VisNegCodigo", gxTpr_Visnegcodigo, false);


			AddObjectProperty("VisNegAssunto", gxTpr_Visnegassunto, false);


			AddObjectProperty("VisNegValor", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Visnegvalor, 16, 2)), false);


			AddObjectProperty("VisNegCliID", gxTpr_Visnegcliid, false);


			AddObjectProperty("VisNegCliNomeFamiliar", gxTpr_Visnegclinomefamiliar, false);


			AddObjectProperty("VisNegCpjID", gxTpr_Visnegcpjid, false);


			AddObjectProperty("VisNegCpjNomFan", gxTpr_Visnegcpjnomfan, false);


			AddObjectProperty("VisNegCpjRazSocial", gxTpr_Visnegcpjrazsocial, false);


			AddObjectProperty("VisNgfSeq", gxTpr_Visngfseq, false);


			AddObjectProperty("VisNgfIteID", gxTpr_Visngfiteid, false);


			AddObjectProperty("VisNgfIteNome", gxTpr_Visngfitenome, false);


			AddObjectProperty("VisAssunto", gxTpr_Visassunto, false);


			AddObjectProperty("VisDescricao", gxTpr_Visdescricao, false);


			AddObjectProperty("VisLink", gxTpr_Vislink, false);


			AddObjectProperty("VisSituacao", gxTpr_Vissituacao, false);


			AddObjectProperty("VisDel", gxTpr_Visdel, false);


			datetime_STZ = gxTpr_Visdeldatahora;
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
			AddObjectProperty("VisDelDataHora", sDateCnv, false);



			datetime_STZ = gxTpr_Visdeldata;
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
			AddObjectProperty("VisDelData", sDateCnv, false);



			datetime_STZ = gxTpr_Visdelhora;
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
			AddObjectProperty("VisDelHora", sDateCnv, false);



			AddObjectProperty("VisDelUsuID", gxTpr_Visdelusuid, false);


			AddObjectProperty("VisDelUsuNome", gxTpr_Visdelusunome, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="VisID")]
		[XmlElement(ElementName="VisID")]
		public Guid gxTpr_Visid
		{
			get {
				return gxTv_SdtsdtVisita_Visid; 
			}
			set {
				gxTv_SdtsdtVisita_Visid = value;
				SetDirty("Visid");
			}
		}




		[SoapElement(ElementName="VisPaiID")]
		[XmlElement(ElementName="VisPaiID")]
		public Guid gxTpr_Vispaiid
		{
			get {
				return gxTv_SdtsdtVisita_Vispaiid; 
			}
			set {
				gxTv_SdtsdtVisita_Vispaiid = value;
				SetDirty("Vispaiid");
			}
		}



		[SoapElement(ElementName="VisPaiData")]
		[XmlElement(ElementName="VisPaiData" , IsNullable=true)]
		public string gxTpr_Vispaidata_Nullable
		{
			get {
				if ( gxTv_SdtsdtVisita_Vispaidata == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtsdtVisita_Vispaidata).value ;
			}
			set {
				gxTv_SdtsdtVisita_Vispaidata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Vispaidata
		{
			get {
				return gxTv_SdtsdtVisita_Vispaidata; 
			}
			set {
				gxTv_SdtsdtVisita_Vispaidata = value;
				SetDirty("Vispaidata");
			}
		}


		[SoapElement(ElementName="VisPaiHora")]
		[XmlElement(ElementName="VisPaiHora" , IsNullable=true)]
		public string gxTpr_Vispaihora_Nullable
		{
			get {
				if ( gxTv_SdtsdtVisita_Vispaihora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtVisita_Vispaihora).value ;
			}
			set {
				gxTv_SdtsdtVisita_Vispaihora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Vispaihora
		{
			get {
				return gxTv_SdtsdtVisita_Vispaihora; 
			}
			set {
				gxTv_SdtsdtVisita_Vispaihora = value;
				SetDirty("Vispaihora");
			}
		}


		[SoapElement(ElementName="VisPaiDataHora")]
		[XmlElement(ElementName="VisPaiDataHora" , IsNullable=true)]
		public string gxTpr_Vispaidatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtVisita_Vispaidatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtVisita_Vispaidatahora).value ;
			}
			set {
				gxTv_SdtsdtVisita_Vispaidatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Vispaidatahora
		{
			get {
				return gxTv_SdtsdtVisita_Vispaidatahora; 
			}
			set {
				gxTv_SdtsdtVisita_Vispaidatahora = value;
				SetDirty("Vispaidatahora");
			}
		}



		[SoapElement(ElementName="VisPaiAssunto")]
		[XmlElement(ElementName="VisPaiAssunto")]
		public string gxTpr_Vispaiassunto
		{
			get {
				return gxTv_SdtsdtVisita_Vispaiassunto; 
			}
			set {
				gxTv_SdtsdtVisita_Vispaiassunto = value;
				SetDirty("Vispaiassunto");
			}
		}



		[SoapElement(ElementName="VisInsData")]
		[XmlElement(ElementName="VisInsData" , IsNullable=true)]
		public string gxTpr_Visinsdata_Nullable
		{
			get {
				if ( gxTv_SdtsdtVisita_Visinsdata == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtsdtVisita_Visinsdata).value ;
			}
			set {
				gxTv_SdtsdtVisita_Visinsdata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Visinsdata
		{
			get {
				return gxTv_SdtsdtVisita_Visinsdata; 
			}
			set {
				gxTv_SdtsdtVisita_Visinsdata = value;
				SetDirty("Visinsdata");
			}
		}


		[SoapElement(ElementName="VisInsHora")]
		[XmlElement(ElementName="VisInsHora" , IsNullable=true)]
		public string gxTpr_Visinshora_Nullable
		{
			get {
				if ( gxTv_SdtsdtVisita_Visinshora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtVisita_Visinshora).value ;
			}
			set {
				gxTv_SdtsdtVisita_Visinshora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Visinshora
		{
			get {
				return gxTv_SdtsdtVisita_Visinshora; 
			}
			set {
				gxTv_SdtsdtVisita_Visinshora = value;
				SetDirty("Visinshora");
			}
		}


		[SoapElement(ElementName="VisInsDataHora")]
		[XmlElement(ElementName="VisInsDataHora" , IsNullable=true)]
		public string gxTpr_Visinsdatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtVisita_Visinsdatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtVisita_Visinsdatahora).value ;
			}
			set {
				gxTv_SdtsdtVisita_Visinsdatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Visinsdatahora
		{
			get {
				return gxTv_SdtsdtVisita_Visinsdatahora; 
			}
			set {
				gxTv_SdtsdtVisita_Visinsdatahora = value;
				SetDirty("Visinsdatahora");
			}
		}



		[SoapElement(ElementName="VisInsUsuID")]
		[XmlElement(ElementName="VisInsUsuID")]
		public string gxTpr_Visinsusuid
		{
			get {
				return gxTv_SdtsdtVisita_Visinsusuid; 
			}
			set {
				gxTv_SdtsdtVisita_Visinsusuid = value;
				SetDirty("Visinsusuid");
			}
		}




		[SoapElement(ElementName="VisInsUsuNome")]
		[XmlElement(ElementName="VisInsUsuNome")]
		public string gxTpr_Visinsusunome
		{
			get {
				return gxTv_SdtsdtVisita_Visinsusunome; 
			}
			set {
				gxTv_SdtsdtVisita_Visinsusunome = value;
				SetDirty("Visinsusunome");
			}
		}



		[SoapElement(ElementName="VisUpdData")]
		[XmlElement(ElementName="VisUpdData" , IsNullable=true)]
		public string gxTpr_Visupddata_Nullable
		{
			get {
				if ( gxTv_SdtsdtVisita_Visupddata == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtsdtVisita_Visupddata).value ;
			}
			set {
				gxTv_SdtsdtVisita_Visupddata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Visupddata
		{
			get {
				return gxTv_SdtsdtVisita_Visupddata; 
			}
			set {
				gxTv_SdtsdtVisita_Visupddata = value;
				SetDirty("Visupddata");
			}
		}


		[SoapElement(ElementName="VisUpdHora")]
		[XmlElement(ElementName="VisUpdHora" , IsNullable=true)]
		public string gxTpr_Visupdhora_Nullable
		{
			get {
				if ( gxTv_SdtsdtVisita_Visupdhora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtVisita_Visupdhora).value ;
			}
			set {
				gxTv_SdtsdtVisita_Visupdhora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Visupdhora
		{
			get {
				return gxTv_SdtsdtVisita_Visupdhora; 
			}
			set {
				gxTv_SdtsdtVisita_Visupdhora = value;
				SetDirty("Visupdhora");
			}
		}


		[SoapElement(ElementName="VisUpdDataHora")]
		[XmlElement(ElementName="VisUpdDataHora" , IsNullable=true)]
		public string gxTpr_Visupddatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtVisita_Visupddatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtVisita_Visupddatahora).value ;
			}
			set {
				gxTv_SdtsdtVisita_Visupddatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Visupddatahora
		{
			get {
				return gxTv_SdtsdtVisita_Visupddatahora; 
			}
			set {
				gxTv_SdtsdtVisita_Visupddatahora = value;
				SetDirty("Visupddatahora");
			}
		}



		[SoapElement(ElementName="VisUpdUsuID")]
		[XmlElement(ElementName="VisUpdUsuID")]
		public string gxTpr_Visupdusuid
		{
			get {
				return gxTv_SdtsdtVisita_Visupdusuid; 
			}
			set {
				gxTv_SdtsdtVisita_Visupdusuid = value;
				SetDirty("Visupdusuid");
			}
		}




		[SoapElement(ElementName="VisUpdUsuNome")]
		[XmlElement(ElementName="VisUpdUsuNome")]
		public string gxTpr_Visupdusunome
		{
			get {
				return gxTv_SdtsdtVisita_Visupdusunome; 
			}
			set {
				gxTv_SdtsdtVisita_Visupdusunome = value;
				SetDirty("Visupdusunome");
			}
		}



		[SoapElement(ElementName="VisData")]
		[XmlElement(ElementName="VisData" , IsNullable=true)]
		public string gxTpr_Visdata_Nullable
		{
			get {
				if ( gxTv_SdtsdtVisita_Visdata == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtsdtVisita_Visdata).value ;
			}
			set {
				gxTv_SdtsdtVisita_Visdata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Visdata
		{
			get {
				return gxTv_SdtsdtVisita_Visdata; 
			}
			set {
				gxTv_SdtsdtVisita_Visdata = value;
				SetDirty("Visdata");
			}
		}


		[SoapElement(ElementName="VisHora")]
		[XmlElement(ElementName="VisHora" , IsNullable=true)]
		public string gxTpr_Vishora_Nullable
		{
			get {
				if ( gxTv_SdtsdtVisita_Vishora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtVisita_Vishora).value ;
			}
			set {
				gxTv_SdtsdtVisita_Vishora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Vishora
		{
			get {
				return gxTv_SdtsdtVisita_Vishora; 
			}
			set {
				gxTv_SdtsdtVisita_Vishora = value;
				SetDirty("Vishora");
			}
		}


		[SoapElement(ElementName="VisDataHora")]
		[XmlElement(ElementName="VisDataHora" , IsNullable=true)]
		public string gxTpr_Visdatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtVisita_Visdatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtVisita_Visdatahora).value ;
			}
			set {
				gxTv_SdtsdtVisita_Visdatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Visdatahora
		{
			get {
				return gxTv_SdtsdtVisita_Visdatahora; 
			}
			set {
				gxTv_SdtsdtVisita_Visdatahora = value;
				SetDirty("Visdatahora");
			}
		}


		[SoapElement(ElementName="VisDataFim")]
		[XmlElement(ElementName="VisDataFim" , IsNullable=true)]
		public string gxTpr_Visdatafim_Nullable
		{
			get {
				if ( gxTv_SdtsdtVisita_Visdatafim == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtsdtVisita_Visdatafim).value ;
			}
			set {
				gxTv_SdtsdtVisita_Visdatafim = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Visdatafim
		{
			get {
				return gxTv_SdtsdtVisita_Visdatafim; 
			}
			set {
				gxTv_SdtsdtVisita_Visdatafim = value;
				SetDirty("Visdatafim");
			}
		}


		[SoapElement(ElementName="VisHoraFim")]
		[XmlElement(ElementName="VisHoraFim" , IsNullable=true)]
		public string gxTpr_Vishorafim_Nullable
		{
			get {
				if ( gxTv_SdtsdtVisita_Vishorafim == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtVisita_Vishorafim).value ;
			}
			set {
				gxTv_SdtsdtVisita_Vishorafim = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Vishorafim
		{
			get {
				return gxTv_SdtsdtVisita_Vishorafim; 
			}
			set {
				gxTv_SdtsdtVisita_Vishorafim = value;
				SetDirty("Vishorafim");
			}
		}


		[SoapElement(ElementName="VisDataHoraFim")]
		[XmlElement(ElementName="VisDataHoraFim" , IsNullable=true)]
		public string gxTpr_Visdatahorafim_Nullable
		{
			get {
				if ( gxTv_SdtsdtVisita_Visdatahorafim == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtVisita_Visdatahorafim).value ;
			}
			set {
				gxTv_SdtsdtVisita_Visdatahorafim = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Visdatahorafim
		{
			get {
				return gxTv_SdtsdtVisita_Visdatahorafim; 
			}
			set {
				gxTv_SdtsdtVisita_Visdatahorafim = value;
				SetDirty("Visdatahorafim");
			}
		}



		[SoapElement(ElementName="VisTipoID")]
		[XmlElement(ElementName="VisTipoID")]
		public int gxTpr_Vistipoid
		{
			get {
				return gxTv_SdtsdtVisita_Vistipoid; 
			}
			set {
				gxTv_SdtsdtVisita_Vistipoid = value;
				SetDirty("Vistipoid");
			}
		}




		[SoapElement(ElementName="VisTipoSigla")]
		[XmlElement(ElementName="VisTipoSigla")]
		public string gxTpr_Vistiposigla
		{
			get {
				return gxTv_SdtsdtVisita_Vistiposigla; 
			}
			set {
				gxTv_SdtsdtVisita_Vistiposigla = value;
				SetDirty("Vistiposigla");
			}
		}




		[SoapElement(ElementName="VisTipoNome")]
		[XmlElement(ElementName="VisTipoNome")]
		public string gxTpr_Vistiponome
		{
			get {
				return gxTv_SdtsdtVisita_Vistiponome; 
			}
			set {
				gxTv_SdtsdtVisita_Vistiponome = value;
				SetDirty("Vistiponome");
			}
		}




		[SoapElement(ElementName="VisNegID")]
		[XmlElement(ElementName="VisNegID")]
		public Guid gxTpr_Visnegid
		{
			get {
				return gxTv_SdtsdtVisita_Visnegid; 
			}
			set {
				gxTv_SdtsdtVisita_Visnegid = value;
				SetDirty("Visnegid");
			}
		}




		[SoapElement(ElementName="VisNegCodigo")]
		[XmlElement(ElementName="VisNegCodigo")]
		public long gxTpr_Visnegcodigo
		{
			get {
				return gxTv_SdtsdtVisita_Visnegcodigo; 
			}
			set {
				gxTv_SdtsdtVisita_Visnegcodigo = value;
				SetDirty("Visnegcodigo");
			}
		}




		[SoapElement(ElementName="VisNegAssunto")]
		[XmlElement(ElementName="VisNegAssunto")]
		public string gxTpr_Visnegassunto
		{
			get {
				return gxTv_SdtsdtVisita_Visnegassunto; 
			}
			set {
				gxTv_SdtsdtVisita_Visnegassunto = value;
				SetDirty("Visnegassunto");
			}
		}



		[SoapElement(ElementName="VisNegValor")]
		[XmlElement(ElementName="VisNegValor")]
		public string gxTpr_Visnegvalor_double
		{
			get {
				return Convert.ToString(gxTv_SdtsdtVisita_Visnegvalor, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtsdtVisita_Visnegvalor = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Visnegvalor
		{
			get {
				return gxTv_SdtsdtVisita_Visnegvalor; 
			}
			set {
				gxTv_SdtsdtVisita_Visnegvalor = value;
				SetDirty("Visnegvalor");
			}
		}




		[SoapElement(ElementName="VisNegCliID")]
		[XmlElement(ElementName="VisNegCliID")]
		public Guid gxTpr_Visnegcliid
		{
			get {
				return gxTv_SdtsdtVisita_Visnegcliid; 
			}
			set {
				gxTv_SdtsdtVisita_Visnegcliid = value;
				SetDirty("Visnegcliid");
			}
		}




		[SoapElement(ElementName="VisNegCliNomeFamiliar")]
		[XmlElement(ElementName="VisNegCliNomeFamiliar")]
		public string gxTpr_Visnegclinomefamiliar
		{
			get {
				return gxTv_SdtsdtVisita_Visnegclinomefamiliar; 
			}
			set {
				gxTv_SdtsdtVisita_Visnegclinomefamiliar = value;
				SetDirty("Visnegclinomefamiliar");
			}
		}




		[SoapElement(ElementName="VisNegCpjID")]
		[XmlElement(ElementName="VisNegCpjID")]
		public Guid gxTpr_Visnegcpjid
		{
			get {
				return gxTv_SdtsdtVisita_Visnegcpjid; 
			}
			set {
				gxTv_SdtsdtVisita_Visnegcpjid = value;
				SetDirty("Visnegcpjid");
			}
		}




		[SoapElement(ElementName="VisNegCpjNomFan")]
		[XmlElement(ElementName="VisNegCpjNomFan")]
		public string gxTpr_Visnegcpjnomfan
		{
			get {
				return gxTv_SdtsdtVisita_Visnegcpjnomfan; 
			}
			set {
				gxTv_SdtsdtVisita_Visnegcpjnomfan = value;
				SetDirty("Visnegcpjnomfan");
			}
		}




		[SoapElement(ElementName="VisNegCpjRazSocial")]
		[XmlElement(ElementName="VisNegCpjRazSocial")]
		public string gxTpr_Visnegcpjrazsocial
		{
			get {
				return gxTv_SdtsdtVisita_Visnegcpjrazsocial; 
			}
			set {
				gxTv_SdtsdtVisita_Visnegcpjrazsocial = value;
				SetDirty("Visnegcpjrazsocial");
			}
		}




		[SoapElement(ElementName="VisNgfSeq")]
		[XmlElement(ElementName="VisNgfSeq")]
		public int gxTpr_Visngfseq
		{
			get {
				return gxTv_SdtsdtVisita_Visngfseq; 
			}
			set {
				gxTv_SdtsdtVisita_Visngfseq = value;
				SetDirty("Visngfseq");
			}
		}




		[SoapElement(ElementName="VisNgfIteID")]
		[XmlElement(ElementName="VisNgfIteID")]
		public Guid gxTpr_Visngfiteid
		{
			get {
				return gxTv_SdtsdtVisita_Visngfiteid; 
			}
			set {
				gxTv_SdtsdtVisita_Visngfiteid = value;
				SetDirty("Visngfiteid");
			}
		}




		[SoapElement(ElementName="VisNgfIteNome")]
		[XmlElement(ElementName="VisNgfIteNome")]
		public string gxTpr_Visngfitenome
		{
			get {
				return gxTv_SdtsdtVisita_Visngfitenome; 
			}
			set {
				gxTv_SdtsdtVisita_Visngfitenome = value;
				SetDirty("Visngfitenome");
			}
		}




		[SoapElement(ElementName="VisAssunto")]
		[XmlElement(ElementName="VisAssunto")]
		public string gxTpr_Visassunto
		{
			get {
				return gxTv_SdtsdtVisita_Visassunto; 
			}
			set {
				gxTv_SdtsdtVisita_Visassunto = value;
				SetDirty("Visassunto");
			}
		}




		[SoapElement(ElementName="VisDescricao")]
		[XmlElement(ElementName="VisDescricao")]
		public string gxTpr_Visdescricao
		{
			get {
				return gxTv_SdtsdtVisita_Visdescricao; 
			}
			set {
				gxTv_SdtsdtVisita_Visdescricao = value;
				SetDirty("Visdescricao");
			}
		}




		[SoapElement(ElementName="VisLink")]
		[XmlElement(ElementName="VisLink")]
		public string gxTpr_Vislink
		{
			get {
				return gxTv_SdtsdtVisita_Vislink; 
			}
			set {
				gxTv_SdtsdtVisita_Vislink = value;
				SetDirty("Vislink");
			}
		}




		[SoapElement(ElementName="VisSituacao")]
		[XmlElement(ElementName="VisSituacao")]
		public string gxTpr_Vissituacao
		{
			get {
				return gxTv_SdtsdtVisita_Vissituacao; 
			}
			set {
				gxTv_SdtsdtVisita_Vissituacao = value;
				SetDirty("Vissituacao");
			}
		}




		[SoapElement(ElementName="VisDel")]
		[XmlElement(ElementName="VisDel")]
		public bool gxTpr_Visdel
		{
			get {
				return gxTv_SdtsdtVisita_Visdel; 
			}
			set {
				gxTv_SdtsdtVisita_Visdel = value;
				SetDirty("Visdel");
			}
		}



		[SoapElement(ElementName="VisDelDataHora")]
		[XmlElement(ElementName="VisDelDataHora" , IsNullable=true)]
		public string gxTpr_Visdeldatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtVisita_Visdeldatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtVisita_Visdeldatahora).value ;
			}
			set {
				gxTv_SdtsdtVisita_Visdeldatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Visdeldatahora
		{
			get {
				return gxTv_SdtsdtVisita_Visdeldatahora; 
			}
			set {
				gxTv_SdtsdtVisita_Visdeldatahora = value;
				SetDirty("Visdeldatahora");
			}
		}


		[SoapElement(ElementName="VisDelData")]
		[XmlElement(ElementName="VisDelData" , IsNullable=true)]
		public string gxTpr_Visdeldata_Nullable
		{
			get {
				if ( gxTv_SdtsdtVisita_Visdeldata == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtVisita_Visdeldata).value ;
			}
			set {
				gxTv_SdtsdtVisita_Visdeldata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Visdeldata
		{
			get {
				return gxTv_SdtsdtVisita_Visdeldata; 
			}
			set {
				gxTv_SdtsdtVisita_Visdeldata = value;
				SetDirty("Visdeldata");
			}
		}


		[SoapElement(ElementName="VisDelHora")]
		[XmlElement(ElementName="VisDelHora" , IsNullable=true)]
		public string gxTpr_Visdelhora_Nullable
		{
			get {
				if ( gxTv_SdtsdtVisita_Visdelhora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtVisita_Visdelhora).value ;
			}
			set {
				gxTv_SdtsdtVisita_Visdelhora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Visdelhora
		{
			get {
				return gxTv_SdtsdtVisita_Visdelhora; 
			}
			set {
				gxTv_SdtsdtVisita_Visdelhora = value;
				SetDirty("Visdelhora");
			}
		}



		[SoapElement(ElementName="VisDelUsuID")]
		[XmlElement(ElementName="VisDelUsuID")]
		public string gxTpr_Visdelusuid
		{
			get {
				return gxTv_SdtsdtVisita_Visdelusuid; 
			}
			set {
				gxTv_SdtsdtVisita_Visdelusuid = value;
				SetDirty("Visdelusuid");
			}
		}




		[SoapElement(ElementName="VisDelUsuNome")]
		[XmlElement(ElementName="VisDelUsuNome")]
		public string gxTpr_Visdelusunome
		{
			get {
				return gxTv_SdtsdtVisita_Visdelusunome; 
			}
			set {
				gxTv_SdtsdtVisita_Visdelusunome = value;
				SetDirty("Visdelusunome");
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
			gxTv_SdtsdtVisita_Vispaihora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtVisita_Vispaidatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtVisita_Vispaiassunto = "";

			gxTv_SdtsdtVisita_Visinshora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtVisita_Visinsdatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtVisita_Visinsusuid = "";
			gxTv_SdtsdtVisita_Visinsusunome = "";

			gxTv_SdtsdtVisita_Visupdhora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtVisita_Visupddatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtVisita_Visupdusuid = "";
			gxTv_SdtsdtVisita_Visupdusunome = "";

			gxTv_SdtsdtVisita_Vishora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtVisita_Visdatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtVisita_Vishorafim = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtVisita_Visdatahorafim = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtVisita_Vistiposigla = "";
			gxTv_SdtsdtVisita_Vistiponome = "";


			gxTv_SdtsdtVisita_Visnegassunto = "";


			gxTv_SdtsdtVisita_Visnegclinomefamiliar = "";

			gxTv_SdtsdtVisita_Visnegcpjnomfan = "";
			gxTv_SdtsdtVisita_Visnegcpjrazsocial = "";


			gxTv_SdtsdtVisita_Visngfitenome = "";
			gxTv_SdtsdtVisita_Visassunto = "";
			gxTv_SdtsdtVisita_Visdescricao = "";
			gxTv_SdtsdtVisita_Vislink = "";
			init_Vissituacao();

			gxTv_SdtsdtVisita_Visdeldatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtVisita_Visdeldata = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtVisita_Visdelhora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtVisita_Visdelusuid = "";
			gxTv_SdtsdtVisita_Visdelusunome = "";
			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}

		private void init_Vissituacao()
		{
			string gxeval;
			gxeval = "PEN";

			gxTv_SdtsdtVisita_Vissituacao = gxeval;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected Guid gxTv_SdtsdtVisita_Visid;
		 

		protected Guid gxTv_SdtsdtVisita_Vispaiid;
		 

		protected DateTime gxTv_SdtsdtVisita_Vispaidata;
		 

		protected DateTime gxTv_SdtsdtVisita_Vispaihora;
		 

		protected DateTime gxTv_SdtsdtVisita_Vispaidatahora;
		 

		protected string gxTv_SdtsdtVisita_Vispaiassunto;
		 

		protected DateTime gxTv_SdtsdtVisita_Visinsdata;
		 

		protected DateTime gxTv_SdtsdtVisita_Visinshora;
		 

		protected DateTime gxTv_SdtsdtVisita_Visinsdatahora;
		 

		protected string gxTv_SdtsdtVisita_Visinsusuid;
		 

		protected string gxTv_SdtsdtVisita_Visinsusunome;
		 

		protected DateTime gxTv_SdtsdtVisita_Visupddata;
		 

		protected DateTime gxTv_SdtsdtVisita_Visupdhora;
		 

		protected DateTime gxTv_SdtsdtVisita_Visupddatahora;
		 

		protected string gxTv_SdtsdtVisita_Visupdusuid;
		 

		protected string gxTv_SdtsdtVisita_Visupdusunome;
		 

		protected DateTime gxTv_SdtsdtVisita_Visdata;
		 

		protected DateTime gxTv_SdtsdtVisita_Vishora;
		 

		protected DateTime gxTv_SdtsdtVisita_Visdatahora;
		 

		protected DateTime gxTv_SdtsdtVisita_Visdatafim;
		 

		protected DateTime gxTv_SdtsdtVisita_Vishorafim;
		 

		protected DateTime gxTv_SdtsdtVisita_Visdatahorafim;
		 

		protected int gxTv_SdtsdtVisita_Vistipoid;
		 

		protected string gxTv_SdtsdtVisita_Vistiposigla;
		 

		protected string gxTv_SdtsdtVisita_Vistiponome;
		 

		protected Guid gxTv_SdtsdtVisita_Visnegid;
		 

		protected long gxTv_SdtsdtVisita_Visnegcodigo;
		 

		protected string gxTv_SdtsdtVisita_Visnegassunto;
		 

		protected decimal gxTv_SdtsdtVisita_Visnegvalor;
		 

		protected Guid gxTv_SdtsdtVisita_Visnegcliid;
		 

		protected string gxTv_SdtsdtVisita_Visnegclinomefamiliar;
		 

		protected Guid gxTv_SdtsdtVisita_Visnegcpjid;
		 

		protected string gxTv_SdtsdtVisita_Visnegcpjnomfan;
		 

		protected string gxTv_SdtsdtVisita_Visnegcpjrazsocial;
		 

		protected int gxTv_SdtsdtVisita_Visngfseq;
		 

		protected Guid gxTv_SdtsdtVisita_Visngfiteid;
		 

		protected string gxTv_SdtsdtVisita_Visngfitenome;
		 

		protected string gxTv_SdtsdtVisita_Visassunto;
		 

		protected string gxTv_SdtsdtVisita_Visdescricao;
		 

		protected string gxTv_SdtsdtVisita_Vislink;
		 

		protected string gxTv_SdtsdtVisita_Vissituacao;
		 

		protected bool gxTv_SdtsdtVisita_Visdel;
		 

		protected DateTime gxTv_SdtsdtVisita_Visdeldatahora;
		 

		protected DateTime gxTv_SdtsdtVisita_Visdeldata;
		 

		protected DateTime gxTv_SdtsdtVisita_Visdelhora;
		 

		protected string gxTv_SdtsdtVisita_Visdelusuid;
		 

		protected string gxTv_SdtsdtVisita_Visdelusunome;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"sdtVisita", Namespace="agl_tresorygroup")]
	public class SdtsdtVisita_RESTInterface : GxGenericCollectionItem<SdtsdtVisita>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtsdtVisita_RESTInterface( ) : base()
		{	
		}

		public SdtsdtVisita_RESTInterface( SdtsdtVisita psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="VisID", Order=0)]
		public Guid gxTpr_Visid
		{
			get { 
				return sdt.gxTpr_Visid;

			}
			set { 
				sdt.gxTpr_Visid = value;
			}
		}

		[DataMember(Name="VisPaiID", Order=1)]
		public Guid gxTpr_Vispaiid
		{
			get { 
				return sdt.gxTpr_Vispaiid;

			}
			set { 
				sdt.gxTpr_Vispaiid = value;
			}
		}

		[DataMember(Name="VisPaiData", Order=2)]
		public  string gxTpr_Vispaidata
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Vispaidata);

			}
			set { 
				sdt.gxTpr_Vispaidata = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="VisPaiHora", Order=3)]
		public  string gxTpr_Vispaihora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Vispaihora);

			}
			set { 
				sdt.gxTpr_Vispaihora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="VisPaiDataHora", Order=4)]
		public  string gxTpr_Vispaidatahora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Vispaidatahora);

			}
			set { 
				sdt.gxTpr_Vispaidatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="VisPaiAssunto", Order=5)]
		public  string gxTpr_Vispaiassunto
		{
			get { 
				return sdt.gxTpr_Vispaiassunto;

			}
			set { 
				 sdt.gxTpr_Vispaiassunto = value;
			}
		}

		[DataMember(Name="VisInsData", Order=6)]
		public  string gxTpr_Visinsdata
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Visinsdata);

			}
			set { 
				sdt.gxTpr_Visinsdata = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="VisInsHora", Order=7)]
		public  string gxTpr_Visinshora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Visinshora);

			}
			set { 
				sdt.gxTpr_Visinshora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="VisInsDataHora", Order=8)]
		public  string gxTpr_Visinsdatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Visinsdatahora);

			}
			set { 
				sdt.gxTpr_Visinsdatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="VisInsUsuID", Order=9)]
		public  string gxTpr_Visinsusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Visinsusuid);

			}
			set { 
				 sdt.gxTpr_Visinsusuid = value;
			}
		}

		[DataMember(Name="VisInsUsuNome", Order=10)]
		public  string gxTpr_Visinsusunome
		{
			get { 
				return sdt.gxTpr_Visinsusunome;

			}
			set { 
				 sdt.gxTpr_Visinsusunome = value;
			}
		}

		[DataMember(Name="VisUpdData", Order=11)]
		public  string gxTpr_Visupddata
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Visupddata);

			}
			set { 
				sdt.gxTpr_Visupddata = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="VisUpdHora", Order=12)]
		public  string gxTpr_Visupdhora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Visupdhora);

			}
			set { 
				sdt.gxTpr_Visupdhora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="VisUpdDataHora", Order=13)]
		public  string gxTpr_Visupddatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Visupddatahora);

			}
			set { 
				sdt.gxTpr_Visupddatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="VisUpdUsuID", Order=14)]
		public  string gxTpr_Visupdusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Visupdusuid);

			}
			set { 
				 sdt.gxTpr_Visupdusuid = value;
			}
		}

		[DataMember(Name="VisUpdUsuNome", Order=15)]
		public  string gxTpr_Visupdusunome
		{
			get { 
				return sdt.gxTpr_Visupdusunome;

			}
			set { 
				 sdt.gxTpr_Visupdusunome = value;
			}
		}

		[DataMember(Name="VisData", Order=16)]
		public  string gxTpr_Visdata
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Visdata);

			}
			set { 
				sdt.gxTpr_Visdata = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="VisHora", Order=17)]
		public  string gxTpr_Vishora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Vishora);

			}
			set { 
				sdt.gxTpr_Vishora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="VisDataHora", Order=18)]
		public  string gxTpr_Visdatahora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Visdatahora);

			}
			set { 
				sdt.gxTpr_Visdatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="VisDataFim", Order=19)]
		public  string gxTpr_Visdatafim
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Visdatafim);

			}
			set { 
				sdt.gxTpr_Visdatafim = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="VisHoraFim", Order=20)]
		public  string gxTpr_Vishorafim
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Vishorafim);

			}
			set { 
				sdt.gxTpr_Vishorafim = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="VisDataHoraFim", Order=21)]
		public  string gxTpr_Visdatahorafim
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Visdatahorafim);

			}
			set { 
				sdt.gxTpr_Visdatahorafim = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="VisTipoID", Order=22)]
		public  string gxTpr_Vistipoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Vistipoid, 9, 0));

			}
			set { 
				sdt.gxTpr_Vistipoid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="VisTipoSigla", Order=23)]
		public  string gxTpr_Vistiposigla
		{
			get { 
				return sdt.gxTpr_Vistiposigla;

			}
			set { 
				 sdt.gxTpr_Vistiposigla = value;
			}
		}

		[DataMember(Name="VisTipoNome", Order=24)]
		public  string gxTpr_Vistiponome
		{
			get { 
				return sdt.gxTpr_Vistiponome;

			}
			set { 
				 sdt.gxTpr_Vistiponome = value;
			}
		}

		[DataMember(Name="VisNegID", Order=25)]
		public Guid gxTpr_Visnegid
		{
			get { 
				return sdt.gxTpr_Visnegid;

			}
			set { 
				sdt.gxTpr_Visnegid = value;
			}
		}

		[DataMember(Name="VisNegCodigo", Order=26)]
		public  string gxTpr_Visnegcodigo
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Visnegcodigo, 12, 0));

			}
			set { 
				sdt.gxTpr_Visnegcodigo = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="VisNegAssunto", Order=27)]
		public  string gxTpr_Visnegassunto
		{
			get { 
				return sdt.gxTpr_Visnegassunto;

			}
			set { 
				 sdt.gxTpr_Visnegassunto = value;
			}
		}

		[DataMember(Name="VisNegValor", Order=28)]
		public  string gxTpr_Visnegvalor
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Visnegvalor, 16, 2));

			}
			set { 
				sdt.gxTpr_Visnegvalor =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="VisNegCliID", Order=29)]
		public Guid gxTpr_Visnegcliid
		{
			get { 
				return sdt.gxTpr_Visnegcliid;

			}
			set { 
				sdt.gxTpr_Visnegcliid = value;
			}
		}

		[DataMember(Name="VisNegCliNomeFamiliar", Order=30)]
		public  string gxTpr_Visnegclinomefamiliar
		{
			get { 
				return sdt.gxTpr_Visnegclinomefamiliar;

			}
			set { 
				 sdt.gxTpr_Visnegclinomefamiliar = value;
			}
		}

		[DataMember(Name="VisNegCpjID", Order=31)]
		public Guid gxTpr_Visnegcpjid
		{
			get { 
				return sdt.gxTpr_Visnegcpjid;

			}
			set { 
				sdt.gxTpr_Visnegcpjid = value;
			}
		}

		[DataMember(Name="VisNegCpjNomFan", Order=32)]
		public  string gxTpr_Visnegcpjnomfan
		{
			get { 
				return sdt.gxTpr_Visnegcpjnomfan;

			}
			set { 
				 sdt.gxTpr_Visnegcpjnomfan = value;
			}
		}

		[DataMember(Name="VisNegCpjRazSocial", Order=33)]
		public  string gxTpr_Visnegcpjrazsocial
		{
			get { 
				return sdt.gxTpr_Visnegcpjrazsocial;

			}
			set { 
				 sdt.gxTpr_Visnegcpjrazsocial = value;
			}
		}

		[DataMember(Name="VisNgfSeq", Order=34)]
		public  string gxTpr_Visngfseq
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Visngfseq, 8, 0));

			}
			set { 
				sdt.gxTpr_Visngfseq = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="VisNgfIteID", Order=35)]
		public Guid gxTpr_Visngfiteid
		{
			get { 
				return sdt.gxTpr_Visngfiteid;

			}
			set { 
				sdt.gxTpr_Visngfiteid = value;
			}
		}

		[DataMember(Name="VisNgfIteNome", Order=36)]
		public  string gxTpr_Visngfitenome
		{
			get { 
				return sdt.gxTpr_Visngfitenome;

			}
			set { 
				 sdt.gxTpr_Visngfitenome = value;
			}
		}

		[DataMember(Name="VisAssunto", Order=37)]
		public  string gxTpr_Visassunto
		{
			get { 
				return sdt.gxTpr_Visassunto;

			}
			set { 
				 sdt.gxTpr_Visassunto = value;
			}
		}

		[DataMember(Name="VisDescricao", Order=38)]
		public  string gxTpr_Visdescricao
		{
			get { 
				return sdt.gxTpr_Visdescricao;

			}
			set { 
				 sdt.gxTpr_Visdescricao = value;
			}
		}

		[DataMember(Name="VisLink", Order=39)]
		public  string gxTpr_Vislink
		{
			get { 
				return sdt.gxTpr_Vislink;

			}
			set { 
				 sdt.gxTpr_Vislink = value;
			}
		}

		[DataMember(Name="VisSituacao", Order=40)]
		public  string gxTpr_Vissituacao
		{
			get { 
				return sdt.gxTpr_Vissituacao;

			}
			set { 
				 sdt.gxTpr_Vissituacao = value;
			}
		}

		[DataMember(Name="VisDel", Order=41)]
		public bool gxTpr_Visdel
		{
			get { 
				return sdt.gxTpr_Visdel;

			}
			set { 
				sdt.gxTpr_Visdel = value;
			}
		}

		[DataMember(Name="VisDelDataHora", Order=42)]
		public  string gxTpr_Visdeldatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Visdeldatahora);

			}
			set { 
				sdt.gxTpr_Visdeldatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="VisDelData", Order=43)]
		public  string gxTpr_Visdeldata
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Visdeldata);

			}
			set { 
				sdt.gxTpr_Visdeldata = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="VisDelHora", Order=44)]
		public  string gxTpr_Visdelhora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Visdelhora);

			}
			set { 
				sdt.gxTpr_Visdelhora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="VisDelUsuID", Order=45)]
		public  string gxTpr_Visdelusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Visdelusuid);

			}
			set { 
				 sdt.gxTpr_Visdelusuid = value;
			}
		}

		[DataMember(Name="VisDelUsuNome", Order=46)]
		public  string gxTpr_Visdelusunome
		{
			get { 
				return sdt.gxTpr_Visdelusunome;

			}
			set { 
				 sdt.gxTpr_Visdelusunome = value;
			}
		}


		#endregion

		public SdtsdtVisita sdt
		{
			get { 
				return (SdtsdtVisita)Sdt;
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
				sdt = new SdtsdtVisita() ;
			}
		}
	}
	#endregion
}