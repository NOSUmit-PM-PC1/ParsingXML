using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GenerateXML
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xdoc = new XmlDocument();
            
            /*<?xml version="1.0" encoding="utf-8" ?> */
            //создание объявления (декларации) документа
            XmlDeclaration XmlDec = xdoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xdoc.AppendChild(XmlDec);
            XmlElement iphone6 = xdoc.CreateElement("phone");
            xdoc.AppendChild(iphone6);

            // создаем атрибут
            iphone6.SetAttribute("name", "iPhone 6");
            iphone6.AppendChild(xdoc.CreateElement("company", "Apple"));
            //сохраняем документ
            xdoc.Save("phones.xml");
        }
    }
}
