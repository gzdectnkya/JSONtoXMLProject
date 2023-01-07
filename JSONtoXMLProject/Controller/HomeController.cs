using JSONtoXMLProject.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace JSONtoXMLProject.Controller
{
    [Route("api/[controller]/[action]")]
    public class HomeController : ControllerBase
    {

        [HttpPost]
        public string CreateXml([FromBody] User obj)
        {
            try
            {
                if (obj == null)
                {
                    return "Gönderilen Json değeri hatalı ya da eksik gönderildi. Kontrol ediniz.";
                }
                string path = ConfigurationManager.AppSettings["FilePath"].ToString();

                if (string.IsNullOrEmpty(path))
                {
                    return "Konfigürasyon dosyasına (app.config) girdiğiniz dosya yolu eksik!";
                }

                string xmlValue = "";
                XmlSerializer xsSubmit = new XmlSerializer(typeof(User));

                using (var sww = new StringWriter())
                {
                    using (XmlTextWriter writer = new XmlTextWriter(sww))
                    {
                        xsSubmit.Serialize(writer, obj);
                        xmlValue = sww.ToString();
                    }
                }
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlValue);
                doc.Save(path);

                return "Kaydetme İşlemi tamamlandı. Dosya " + path + " yoluna kaydedildi.";
            }
            catch (Exception ex)
            {
                return "Bir hata oluştu. Hata mesajı:" + ex.Message;
            }
        }
    }
}
