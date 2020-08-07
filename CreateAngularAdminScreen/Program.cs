using System;
using System.IO;
using System.CodeDom.Compiler;
using Microsoft.VisualStudio.TextTemplating;
using TextTemplating;
using Utilities;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace CreateAngularAdminScreen
{
    //This will accept the path of a text template as an argument.
    //It will create an instance of the custom host and an instance of the
    //text templating transformation engine, and will transform the
    //template to create the generated text output file.
    //-------------------------------------------------------------------------

    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}