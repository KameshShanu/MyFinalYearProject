using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailUtility.EmailHelpers
{
   public class TemplateHandler
    {
        public static string Create(TemplateCreateOptions options)
        {
            string templateFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates");
            templateFolderPath = Path.Combine(templateFolderPath, options.TemplateName + ".cshtml");
            string razorContent = File.ReadAllText(templateFolderPath);
            string htmlContent = RazorToHtmlConverter.Convert(razorContent, options.TemplateModel);
            return htmlContent;
        }
    }
}
