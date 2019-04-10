using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IronOcr;
using System.Web.Script.Serialization;
using System.Drawing;

namespace CIS4290_SeniorProject
{
	public partial class Page1 : System.Web.UI.Page
	{
		internal class Result
		{
			public string Text { get; set; }
			public double Confidence { get; set; }
		}

		protected void Page_Load(object sender, EventArgs e)
		{

			

		}

		protected void UploadButton_Click(object sender, EventArgs e)
		{
			int selectedIndexInt = DropDownList1.SelectedIndex;

			// file location
			var file = FileUpload1.FileContent;

			if (selectedIndexInt == 0)
			{
				if (FileUpload1.HasFile)
				{
					if (RadioButton1.Checked)
					{
						
						// initializes list to be serialized into JSON
						var OutputList = new List<Result>();

						var Ocr = new AdvancedOcr()
						{
							Language = IronOcr.Languages.English.OcrLanguagePack,
							ColorSpace = AdvancedOcr.OcrColorSpace.GrayScale,
							EnhanceResolution = true,
							EnhanceContrast = true,
							CleanBackgroundNoise = true,
							ColorDepth = 4,
							RotateAndStraighten = false,
							DetectWhiteTextOnDarkBackgrounds = false,
							ReadBarCodes = false,
							Strategy = AdvancedOcr.OcrStrategy.Fast,
							InputImageType = AdvancedOcr.InputTypes.Document
						};

						var Result = Ocr.ReadPdf(@file);
						var ResultText = Result.Text;
						TextBox1.Text = ResultText.ToString();

						foreach (var page in Result.Pages)
						{
							foreach (var paragraph in page.Paragraphs)
							{
								var paragraphText = paragraph.Text;
								//Console.WriteLine("Result paragraph: {0}", paragraphText);

								double paragraphConfidence = Math.Round(paragraph.Confidence, 2);
								//Console.WriteLine("Confidence score per paragraph: {0}\n", paragraphConfidence);

								// add values to list
								OutputList.Add(new Result() { Text = paragraphText, Confidence = paragraphConfidence });

								//foreach (var line in paragraph.Lines)
								//{
								//    double lineConfidence = line.Confidence;
								//    Console.WriteLine("Confidence score per line: {0}", lineConfidence);
								//}
							}
						}

						// serialize list into JSON
						var serializer = new JavaScriptSerializer();
						var serializedOutputList = serializer.Serialize(OutputList);

						TextBox1.Text = serializedOutputList;

						//foreach (list in serializedOutputList)
						//{
						//TextBox1.Text(list.Text);
						//TextBox1.Text(list.Confidence);
						//}

					}
					else if (RadioButton2.Checked)
					{
						var Ocr = new AdvancedOcr()
						{
							CleanBackgroundNoise = true,
							EnhanceContrast = true,
							EnhanceResolution = true,
							Language = IronOcr.Languages.English.OcrLanguagePack,
							Strategy = IronOcr.AdvancedOcr.OcrStrategy.Advanced,
							ColorSpace = AdvancedOcr.OcrColorSpace.Color,
							DetectWhiteTextOnDarkBackgrounds = true,
							InputImageType = AdvancedOcr.InputTypes.AutoDetect,
							RotateAndStraighten = true,
							ReadBarCodes = true,
							ColorDepth = 4
						};
						var testImage = @file;
						//var Results = Ocr.Read(testImage);
						//TextBox1.Text = Results.ToString();

						TextBox1.Text = "Image processing is unavailable at the moment.";
					}
					else
					{
						TextBox1.Text = "Please select a file type.";
					}
				}
				else
				{
					TextBox1.Text = "Please upload a file.";
				}
			}
			else if (selectedIndexInt == 1)
				//this is the ACORD 25 Form - these will be typed
			{
				TextBox1.Text = "Processing for ACORD 25 Forms is unavailable at the moment.";
			}

			else if (selectedIndexInt == 2)
				//this is the W9 Form - these will be handwritten
			{
				TextBox1.Text = "Processing for W9 Forms is unavailable at the moment.";
				if (FileUpload1.HasFile)
				{
					TextBox1.Text = "Processing for W9 Forms is unavailable at the moment.";
				}
				else
				{
					TextBox1.Text = "Please upload a file.";
				}
			}
		}

	}
}