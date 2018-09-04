using bffishold;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xml2CSharp;

namespace bffisholdlister
{
    class Program
    {
        static void Main(string[] args)
        {
            // string doc = @"C:\Users\Michael\Dropbox\BFFIS\2017\HoldOversigt-ver1.xls";
            string doc = "..\\HoldOversigt-ver1.xls";
            if (args.Length != 2)
            {
                Console.WriteLine("Usage is bffisApp.exe [fuld sti til excel fil] - e.g. bffisApp.exe c:\\dropbox\\bffis\\HoldOversigt-ver1.xls");
                Console.WriteLine("Defaulter til : " + doc);
            }
            else
            {
                doc = args[1];
            }
            var path = Path.GetDirectoryName(doc);
            var file = Path.GetFileName(doc);
            // split into path and filename
            Directory.SetCurrentDirectory(path);

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            DocumentReader reader = new DocumentReader();
            var teams = reader.Read(file);

            Directory.CreateDirectory("Afkrydsningslister");

            GetAllTeams(teams).GetAwaiter().GetResult();
            string year = DateTime.Now.Year + " - " + DateTime.Now.AddYears(1).Year;

            foreach (var t in teams)
            {
                DocumentBuilder builder = new DocumentBuilder();
                builder.Build(t, "Afkrydsningslister\\"+t.Name+".pdf");
            }
        }

        private static async Task GetAllTeams(List<Hold> teams)
        {
            var hd = new HoldDownloader();
            var serializer = new XmlSerializer(typeof(Conventus));
            foreach (var t in teams)
            {
                var xml = await hd.DownloadHold(t.HoldNo);
                t.XmlText = xml;
                File.WriteAllText("c:\\temp\\" + t.Name + "1.xml", xml);
                using (var reader = new StringReader(xml))
                {
                    t.Medlemmer = (Conventus)serializer.Deserialize(reader);
                }
            }
        }
    }
}
