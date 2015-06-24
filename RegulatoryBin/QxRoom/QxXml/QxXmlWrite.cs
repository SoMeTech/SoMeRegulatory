namespace QxRoom.QxXml
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    public class QxXmlWrite
    {
        private string _filepath;
        private string _rootdocument;
        private XmlDocument _xml;
        private XmlTextWriter _xtw;

        public QxXmlWrite()
        {
            this._rootdocument = "root";
            this._xml = new XmlDocument();
        }

        public QxXmlWrite(string o_filepath)
        {
            this._rootdocument = "root";
            this.FilePath = o_filepath;
            this._xml = new XmlDocument();
            this.OpenXml();
        }

        public bool CreateEndRootDocument()
        {
            this._xtw.WriteEndDocument();
            return true;
        }

        public void CreateStartElement(string o_element)
        {
            this._xtw.WriteStartElement(o_element);
        }

        public bool CreateStartRootDocument()
        {
            this._xtw.WriteStartDocument();
            return true;
        }

        public void Dispose()
        {
            if ((this._xtw != null) && (this._xtw.WriteState != WriteState.Closed))
            {
                this.Save();
            }
        }

        public bool EditElement(string o_nodename, string o_nodenewvalue)
        {
            this._xml.Load(this._filepath);
            this._xml.SelectSingleNode(o_nodename).InnerText = o_nodenewvalue;
            this._xml.Save(this.FilePath);
            return true;
        }

        public bool EditElement(string o_nodename, int o_nodeindex, string o_nodenewvalue)
        {
            this._xml.Load(this._filepath);
            this._xml.SelectNodes(o_nodename)[o_nodeindex].InnerText = o_nodenewvalue;
            this._xml.Save(this.FilePath);
            return true;
        }

        ~QxXmlWrite()
        {
            this.Dispose();
        }

        public bool OpenXml()
        {
            if (!File.Exists(this._filepath))
            {
                new FileStream(this._filepath, FileMode.Create).Close();
            }
            this._xtw = new XmlTextWriter(this._filepath, Encoding.GetEncoding("GB2312"));
            this._xtw.Formatting = Formatting.Indented;
            return true;
        }

        public bool OpenXml(string o_filepath)
        {
            this.FilePath = o_filepath;
            return this.OpenXml();
        }

        public void Save()
        {
            this._xtw.Flush();
            this._xtw.Close();
        }

        public bool WriteNewElement(string o_parentnode, string o_childnodename, string o_childnodevalue)
        {
            this._xml.Load(this._filepath);
            XmlElement newChild = this._xml.CreateElement(o_childnodename);
            newChild.InnerText = o_childnodevalue;
            ((XmlElement) this._xml.SelectSingleNode(o_parentnode)).AppendChild(newChild);
            this._xml.Save(this.FilePath);
            return true;
        }

        public bool WriteNewElement(string o_parentnode, int o_parentindex, string o_childnodename, string o_childnodevalue)
        {
            this._xml.Load(this._filepath);
            XmlElement newChild = this._xml.CreateElement(o_childnodename);
            newChild.InnerText = o_childnodevalue;
            ((XmlElement) this._xml.SelectNodes(o_parentnode)[o_parentindex]).AppendChild(newChild);
            this._xml.Save(this.FilePath);
            return true;
        }

        public void WriteTextEndXml()
        {
            this._xtw.WriteEndElement();
        }

        public bool WriteTextStartXml(string o_element, string o_value)
        {
            this._xtw.WriteElementString(o_element, o_value);
            return true;
        }

        public string FilePath
        {
            get
            {
                return this._filepath;
            }
            set
            {
                this._filepath = value;
            }
        }

        public string RootDocument
        {
            get
            {
                return this._rootdocument;
            }
            set
            {
                this._rootdocument = value;
            }
        }
    }
}

