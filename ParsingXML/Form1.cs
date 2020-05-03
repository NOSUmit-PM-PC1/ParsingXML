using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ParsingXML
{
    public partial class Form1 : Form
    {
        Dictionary<string, XmlElement> xmlNodes = new Dictionary<string, XmlElement>();
        public Form1()
        {
            InitializeComponent();
            loadXml();
        }

        void loadXml()
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load("book.xml");
                // загрузить название
                XmlNode node = xmlDoc.DocumentElement.SelectSingleNode("title");
                string book = node.InnerText;
                string author = node.Attributes.GetNamedItem("authors").InnerText;
                string klass = node.Attributes.GetNamedItem("class").InnerText;
                label1.Text = string.Format("{0} {1} {2} класс", author, book.Trim(), klass);

                // загрузить обложку
                string fileName = "Picture/" + xmlDoc.DocumentElement.Attributes["cover"].Value;
                pictureBox1.Load(fileName);

                XmlNodeList subjects = xmlDoc.GetElementsByTagName("subject");
                foreach (XmlElement sub in subjects)
                {
                    string text = sub.GetAttribute("title");
                    listBox1.Items.Add(text);
                    xmlNodes.Add(text, sub);
                }
                listBox1.SelectedIndex = 0;
            }
            catch (Exception mess)
            {
                MessageBox.Show(mess.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), listBox1.Font, Brushes.Green, e.Bounds);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { 
                string text = listBox1.SelectedItem.ToString();
                listBox2.Items.Clear();
                /*foreach (XmlElement child in xmlNodes[text].ChildNodes)
                {
                    //listBox2.Items.Add(child.Name);
                   
                }*/
                XmlNodeList childss = xmlNodes[text].ChildNodes;
                listBox2.Items.Add("страница учебника " + childss[0].ChildNodes[0].Attributes["page"].Value.ToString());
                int k = childss[1].ChildNodes.Count;
                if (k > 0)
                {
                    MessageBox.Show(childss[1].ChildNodes[0].Name);
                    string videoName = childss[1].ChildNodes[0].Attributes["filename"].Value.ToString().Split()[0];
                    MessageBox.Show(videoName);
                    MediaPlayer1.URL = "Video/" + videoName;
                    
                   // MediaPlayer1.play
                }
               //     var qwe = childs[1];

                    //    .Split()[0];
                
            }
            catch 
            { }
        }
    }
}
