using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;
using System.Xml.Xsl;
using System.Xml;

namespace GoFruity.Pages
{
    public class UsersModel : PageModel
    {
        public string usersData;
        public void OnGet()
        {
            XslCompiledTransform xslt = new();
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyName = assembly.GetName().Name;
            var xslResourcePath = $"{assemblyName}.Pages.users.xslt";
            var xmlResourcePath = $"{assemblyName}.Pages.users.xml";
            using var stream = assembly.GetManifestResourceStream(xslResourcePath);
            using var styleReader = XmlReader.Create(stream);
            xslt.Load(styleReader);

            using var dataStream = assembly.GetManifestResourceStream(xmlResourcePath);
            using var dataReader = XmlReader.Create(dataStream);
            using var sw = new StringWriter();
            xslt.Transform(dataReader, null, sw);
            usersData = sw.ToString();
        }
    }
}
