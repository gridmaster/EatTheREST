using System;
using System.IO;
using System.Net;
using System.Xml;

namespace EatTheREST
{
    class Program
    {
        static void Main(string[] args)
        {
            //code for xml Response consumption from WCF rest Service[Start]
            WebRequest req = WebRequest.Create(@"http://localhost:3030/Person?id=3");
            req.Method = "GET";
            req.ContentType = @"application/xml; charset=utf-8";
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                XmlDocument myXMLDocument = new XmlDocument();
                XmlReader myXMLReader = new XmlTextReader(resp.GetResponseStream());
                myXMLDocument.Load(myXMLReader);
                Console.WriteLine(myXMLDocument.InnerText);
            }
            //code for xml Response consumption from WCF rest Service[END]

            //****************************************************************************
            //code for json Response consumption from WCF rest Service[Start]
            WebRequest req2 = WebRequest.Create(@"http://localhost:3030/People");
            req2.Method = "GET";
            req2.ContentType = @"application/json; charset=utf-8";
            HttpWebResponse response = (HttpWebResponse)req2.GetResponse();
            string jsonResponse = string.Empty;
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                jsonResponse = sr.ReadToEnd();
                Console.WriteLine(jsonResponse);
            }
            //code for json Response consumption from WCF rest Service[END]

            Console.ReadKey();
        }
    }
}
