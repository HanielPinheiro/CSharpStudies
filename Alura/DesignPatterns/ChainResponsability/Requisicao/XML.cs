using DesignPatterns.Interfaces;
using DesignPatterns.Investimentos;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DesignPatterns.FormatosExportar
{
    public class XML : IFormato
    {
        public IFormato FormatoSeguinte { get; set; } = null;

        public XML(IFormato formatoSeguinte)
        {
            FormatoSeguinte = formatoSeguinte;
        }
        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
        public string Requisicao(Conta conta, Formato formato)
        {
            if (formato == Formato.XML)
            {
                return MontaXMLPartindoDoObjeto(conta);
            }

            if (FormatoSeguinte != null)
                return FormatoSeguinte.Requisicao(conta, formato);

            return "Falha em obter requisição!";
        }

        private string MontaXMLPartindoDoObjeto(object objeto)
        {
            string xml = null;

            try
            {
                using (StringWriter sww = new Utf8StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(sww))
                    {
                        Type tipo = objeto.GetType();
                        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                        namespaces.Add("", "");

                        XmlSerializer xsSubmit = new XmlSerializer(tipo);
                        xsSubmit.Serialize(writer, objeto, namespaces);
                        xml = sww.ToString();
                    }
                }
            }
            catch { xml = "Falha em obter xml!"; }

            return xml;
        }
    }
}
