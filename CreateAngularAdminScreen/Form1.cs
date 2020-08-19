using Microsoft.VisualStudio.TextTemplating;
using Newtonsoft.Json;
using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
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
			GenerateCodeButton.Enabled = false;
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

			// get db columns
			using (SqlConnection db = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=NikeaaDesignDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;"))
			{
				db.Open();

				String[] tableRestrictions = new String[4];
				tableRestrictions[2] = "AdminTemplate";
				DataTable schema = db.GetSchema("Columns", tableRestrictions);
				var selectedRows = (from info in schema.AsEnumerable()
								   select new Column
								   {
									   ColumnName = info["COLUMN_NAME"].ToString(),
									   DataType = info["DATA_TYPE"].ToString()
								   }).ToArray();
				parameters.DbColumns = selectedRows;

				db.Close();
			}

			string jsonParameters = JsonConvert.SerializeObject(parameters);
			File.WriteAllText("jsonParameters.json", jsonParameters);

			string[] fileNames = Directory.GetFileSystemEntries(templatesDirectory, "*", SearchOption.AllDirectories);

			workingFilesStaticLabel.Visible = true;
			workingFileLabel.Visible = true;
			foreach (string fileName in fileNames)
			{
				workingFileLabel.Text = fileName;
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

			// Add new route to app.module.ts file
			string whereToAddNewRoute = "/*** Add New Paths Here ***/";
			string newRouteTemplate = "{ path: 'admin/admin-template', loadChildren: () => import('./admin/admin-template/index.module').then(m => m.AdminTemplateIndexModule) },\r\n      ";
			string appModulePath = outputBasePath + "\\ClientApp\\src\\app\\app.module.ts";
			if (File.Exists(appModulePath)) {
				string appModuleCode = File.ReadAllText(appModulePath);
				if (appModuleCode.IndexOf(whereToAddNewRoute) > -1) {
					string newRoute = newRouteTemplate.Replace("admin-template", dashName).Replace("AdminTemplate", camelCaseName);
					appModuleCode = appModuleCode.Replace(whereToAddNewRoute, newRoute + whereToAddNewRoute);
					File.WriteAllText(appModulePath, appModuleCode);
				}
			}

			workingFileLabel.Visible = false;
			workingFilesStaticLabel.Visible = false;
			GenerateCodeButton.Enabled = true;
		}
	}
}
