using Microsoft.VisualStudio.TextTemplating;
using Newtonsoft.Json;
using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Windows.Forms;
using TextTemplating;
using Utilities;

namespace CreateAngularAdminScreen
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void OutputDirectorySearchButton_Click(object sender, EventArgs e)
		{
			if (OutputDirectorySearchDialog.ShowDialog() == DialogResult.OK)
			{
				OutputDirectoryTextBox.Text = OutputDirectorySearchDialog.SelectedPath;
			}
		}

		private void TitleCaseNameTextBox_TextChanged(object sender, EventArgs e)
		{
			CamelCaseNameTextBox.Text = ConvertToCamelCase(TitleCaseNameTextBox.Text);
			LowerCamelCaseNameTextBox.Text = ConvertToLowerCamelCase(TitleCaseNameTextBox.Text);
			DashNameTextBox.Text = ConvertToDashCase(TitleCaseNameTextBox.Text);
		}

		private string ConvertToDashCase(string text)
		{
			string result = "";

			result = text.ToLower().Replace(" ", "-");

			return result;
		}

		private string ConvertToLowerCamelCase(string text)
		{
			string result = "";

			result = ConvertToCamelCase(text);
			result = result.Substring(0, 1).ToLower() + result.Substring(1);

			return result;
		}

		private string ConvertToCamelCase(string text)
		{
			string result = "";

			result = text.Replace(" ", "");

			return result;
		}

		private void GenerateCodeButton_Click(object sender, EventArgs e)
		{
			ProcessTemplates(OutputDirectorySearchDialog.SelectedPath, TitleCaseNameTextBox.Text, CamelCaseNameTextBox.Text, LowerCamelCaseNameTextBox.Text, DashNameTextBox.Text);
		}

		private void ProcessTemplates(string outputBasePath, string titleCaseName, string camelCaseName, string lowerCamelCaseName, string dashName)
		{
			string templatesDirectory = ".\\templates";

			Parameters parameters = new Parameters();
			parameters.CamelCaseName = camelCaseName;
			parameters.LowerCamelCaseName = lowerCamelCaseName;
			parameters.DashName = dashName;
			parameters.TitleCaseName = titleCaseName;
			string jsonParameters = JsonConvert.SerializeObject(parameters);
			File.WriteAllText("jsonParameters.json", jsonParameters);

			string[] fileNames = Directory.GetFileSystemEntries(templatesDirectory, "*", SearchOption.AllDirectories);

			foreach (string fileName in fileNames)
			{
				FileAttributes fileAttributes = File.GetAttributes(fileName);
				if ((fileAttributes & FileAttributes.Directory) != FileAttributes.Directory)
				{ // it's a file, so process it.
					CustomTextTemplatingHost host = new CustomTextTemplatingHost();
					Engine engine = new Engine();
					host.TemplateFile = fileName;
					string input = File.ReadAllText(fileName);
					string output = engine.ProcessTemplate(input, host);

					string outputFileName = Path.GetFileNameWithoutExtension(fileName);
					outputFileName = outputFileName.Replace("AdminTemplate", camelCaseName);

					string outputSubDirectory = Path.GetDirectoryName(fileName).Replace(templatesDirectory, "");
					if (outputSubDirectory.EndsWith("admin")) outputSubDirectory += "\\" + dashName;

					string outputPath = Path.Combine(outputBasePath + outputSubDirectory);
					if (!Directory.Exists(outputPath))
					{
						Directory.CreateDirectory(outputPath);
					}

					outputFileName = Path.Combine(outputPath, outputFileName);

					File.WriteAllText(outputFileName, output, host.FileEncoding);
				}
			}

			//CustomTextTemplatingHost host = new CustomTextTemplatingHost();
			//Engine engine = new Engine();
			//host.TemplateFile = templateFileName;
			//Read the text template.
			//string input = File.ReadAllText(templateFileName);
			//Transform the text template.
			//string output = engine.ProcessTemplate(input, host);
			//string outputFileName = Path.GetFileNameWithoutExtension(templateFileName);
			//outputFileName = Path.Combine(Path.GetDirectoryName(templateFileName), outputFileName);
			//outputFileName = outputFileName + host.FileExtension;
			//File.WriteAllText(outputFileName, output, host.FileEncoding);

			//foreach (CompilerError error in host.Errors)
			//{
			//	Console.WriteLine(error.ToString());
			//}
		}
	}
}
