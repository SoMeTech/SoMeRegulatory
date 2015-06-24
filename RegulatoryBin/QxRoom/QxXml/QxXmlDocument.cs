namespace QxRoom.QxXml
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Xml;

    public class QxXmlDocument : IDisposable
    {
        private string _filepath;
        private string _nodename;
        private string _nodestring;
        private XmlDocument _xml;
        private string _xmlcontent;

        public QxXmlDocument()
        {
            this._xml = new XmlDocument();
        }

        public QxXmlDocument(string o_filepath)
        {
            this.Filepath = o_filepath;
            this._xml = new XmlDocument();
            this.OpenXml();
        }

        public void Dispose()
        {
            this._xml = null;
        }

        public bool EditElement(string o_nodename, string o_nodenewvalue)
        {
            this._xml.SelectSingleNode(o_nodename).InnerText = o_nodenewvalue;
            this._xml.Save(this.Filepath);
            return true;
        }

        public bool EditElement(string o_nodename, int o_nodeindex, string o_nodenewvalue)
        {
            this._xml.SelectNodes(o_nodename)[o_nodeindex].InnerText = o_nodenewvalue;
            this._xml.Save(this.Filepath);
            return true;
        }

        ~QxXmlDocument()
        {
            this.Dispose();
        }

        public Hashtable GetAttributes(string o_nodename, int o_nodeindex)
        {
            Hashtable hashtable = new Hashtable();
            XmlNode node = this._xml.SelectNodes(o_nodename).Item(o_nodeindex);
            if (node.Attributes.Count > 0)
            {
                foreach (XmlAttribute attribute in node.Attributes)
                {
                    hashtable.Add(attribute.Name, attribute.Value);
                }
            }
            return hashtable;
        }

        public int GetDepth(string o_nodestring)
        {
            return this._xml.SelectNodes(o_nodestring).Count;
        }

        public int GetDepth(XmlNode xn)
        {
            return xn.ChildNodes.Count;
        }

        public XmlElement GetDocument()
        {
            return this._xml.DocumentElement;
        }

        public XmlNode GetNode(int i)
        {
            return this._xml.ChildNodes[i];
        }

        public XmlNode GetNode(string o_nodestring, int i)
        {
            return this._xml.SelectNodes(o_nodestring)[i];
        }

        public string GetNodeString()
        {
            return this.GetNodeString(0);
        }

        public string GetNodeString(int o_nodeindex)
        {
            return this._xml.SelectNodes(this.NodeString)[o_nodeindex].InnerText;
        }

        public string GetNodeString(string o_allpath, int o_nodeindex)
        {
            this.NodeString = o_allpath;
            return this.GetNodeString(o_nodeindex);
        }

        public bool OpenUrlXml(string url)
        {
            if (this._xml == null)
            {
                this._xml = new XmlDocument();
            }
            this._xml.Load(url);
            return true;
        }

        public bool OpenXml()
        {
            return this.OpenXml(false);
        }

        public bool OpenXml(bool createfile)
        {
            if (!File.Exists(this.Filepath) && createfile)
            {
                new FileStream(this.Filepath, FileMode.Create).Close();
            }
            this._xml.Load(this.Filepath);
            return true;
        }

        public bool OpenXml(Stream o_stream)
        {
            this._xml.Load(o_stream);
            return true;
        }

        public bool OpenXml(TextReader o_tr)
        {
            this._xml.Load(o_tr);
            return true;
        }

        public bool OpenXml(string o_filepath)
        {
            this.Filepath = o_filepath;
            return this.OpenXml();
        }

        public bool OpenXml(XmlReader o_xr)
        {
            this._xml.Load(o_xr);
            return true;
        }

        public bool OpenXmlContent()
        {
            this._xml.LoadXml(this.XmlContent);
            return false;
        }

        public bool OpenXmlContent(string o_xmlcontent)
        {
            this.XmlContent = o_xmlcontent;
            return this.OpenXmlContent();
        }

        public string ReadNodeString()
        {
            return this.ReadNodeString(0);
        }

        public string ReadNodeString(int o_nodeindex)
        {
            return this._xml.GetElementsByTagName(this.NodeName).Item(o_nodeindex).InnerText;
        }

        public string ReadNodeString(string o_nodename, int o_nodeindex)
        {
            this.NodeName = o_nodename;
            return this.ReadNodeString(o_nodeindex);
        }

        public string ReadNodeXml()
        {
            return this.ReadNodeXml(0);
        }

        public string ReadNodeXml(int o_nodeindex)
        {
            return this._xml.GetElementsByTagName(this.NodeName).Item(o_nodeindex).InnerXml;
        }

        public string ReadNodeXml(string o_nodename, int o_nodeindex)
        {
            this.NodeName = o_nodename;
            return this.ReadNodeXml(o_nodeindex);
        }

        public string SearchAttribute(string nodestring, int iindex, XmlNamespaceManager namespaceing, string attribute)
        {
            string xpath = nodestring;
            if (namespaceing == null)
            {
                return this._xml.SelectNodes(xpath)[iindex].Attributes[attribute].Value;
            }
            return this._xml.SelectNodes(xpath, namespaceing)[iindex].Attributes[attribute].Value;
        }

        public XmlElement SearchElement(string nodestring, int iindex, XmlNamespaceManager namespaceing)
        {
            string xpath = nodestring;
            if (namespaceing == null)
            {
                return (XmlElement) this._xml.SelectNodes(xpath)[iindex];
            }
            return (XmlElement) this._xml.SelectNodes(xpath, namespaceing)[iindex];
        }

        public string SearchNodes(string nodestring, string[] strexp)
        {
            int iindex = 0;
            return this.SearchNodes(nodestring, strexp, iindex, null);
        }

        public string SearchNodes(string nodestring, string strexp)
        {
            int iindex = 0;
            return this.SearchNodes(nodestring, strexp, iindex, null);
        }

        public string SearchNodes(string nodestring, string[] strexp, int iindex)
        {
            return this.SearchNodes(nodestring, strexp, iindex, null);
        }

        public string SearchNodes(string nodestring, string strexp, int iindex)
        {
            return this.SearchNodes(nodestring, strexp, iindex, null);
        }

        public string SearchNodes(string nodestring, string[] strexp, int iindex, XmlNamespaceManager namespaceing)
        {
            string xpath = nodestring;
            for (int i = 0; i < strexp.Length; i++)
            {
                xpath = xpath + "[" + strexp[i] + "]";
            }
            if (namespaceing == null)
            {
                return this._xml.SelectNodes(xpath)[iindex].InnerXml;
            }
            return this._xml.SelectNodes(xpath, namespaceing)[iindex].InnerXml;
        }

        public string SearchNodes(string nodestring, string strexp, int iindex, XmlNamespaceManager namespaceing)
        {
            string[] strArray = new string[] { strexp };
            return this.SearchNodes(nodestring, strArray, iindex, namespaceing);
        }

        public string SearchSingleNode(string nodestring, string strexp)
        {
            return this.SearchSingleNode(nodestring, strexp, null);
        }

        public string SearchSingleNode(string nodestring, string[] strexp)
        {
            return this.SearchSingleNode(nodestring, strexp, null);
        }

        public string SearchSingleNode(string nodestring, string strexp, XmlNamespaceManager namespaceing)
        {
            string[] strArray = new string[] { strexp };
            return this.SearchSingleNode(nodestring, strArray, namespaceing);
        }

        public string SearchSingleNode(string nodestring, string[] strexp, XmlNamespaceManager namespaceing)
        {
            string xpath = nodestring;
            for (int i = 0; i < strexp.Length; i++)
            {
                xpath = xpath + "[" + strexp[i] + "]";
            }
            if (namespaceing == null)
            {
                return this._xml.SelectSingleNode(xpath).InnerXml;
            }
            return this._xml.SelectSingleNode(xpath, namespaceing).InnerXml;
        }

        public bool WriteNewElement(string o_parentnode, string o_childnodename, string o_childnodevalue)
        {
            XmlElement newChild = this._xml.CreateElement(o_childnodename);
            newChild.InnerText = o_childnodevalue;
            ((XmlElement) this._xml.SelectSingleNode(o_parentnode)).AppendChild(newChild);
            this._xml.Save(this.Filepath);
            return true;
        }

        public bool WriteNewElement(string o_parentnode, int o_parentindex, string o_childnodename, string o_childnodevalue)
        {
            XmlElement newChild = this._xml.CreateElement(o_childnodename);
            newChild.InnerText = o_childnodevalue;
            ((XmlElement) this._xml.SelectNodes(o_parentnode)[o_parentindex]).AppendChild(newChild);
            this._xml.Save(this.Filepath);
            return true;
        }

        public string Filepath
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

        public string NodeName
        {
            get
            {
                return this._nodename;
            }
            set
            {
                this._nodename = value;
            }
        }

        public string NodeString
        {
            get
            {
                return this._nodestring;
            }
            set
            {
                this._nodestring = value;
            }
        }

        public string XmlContent
        {
            get
            {
                return this._xmlcontent;
            }
            set
            {
                this._xmlcontent = value;
            }
        }
    }
}

