namespace QxRoom.QxFunctionLog
{
    using QxRoom.DataAccess;
    using System;
    using System.Data;
    using System.IO;

    [Serializable]
    public class QxLog : QxLogBase
    {
        protected byte[] functiondata;
        private string functionid = "";
        private string functionname = "";
        private string id = "";
        private string logcause = "";
        private string logdate = "";
        private string logip = "";
        private string logtable = "";
        private string logtableid = "";
        private string logtablekey = "";
        public static string Popedoms = "";
        private string userid = "";
        private string usertruename = "";

        ~QxLog()
        {
        }

        public void ReadLog(DataBase db)
        {
            if ((this.Id == null) || (this.Id.Trim() == ""))
            {
                throw new LogException("没有选择日志ID");
            }
            string commandText = "select id,webuser,type,nrstring,logip,nrstringdata,logtable,logtablekey,logtableid,logdelyy,webusername,logdate,name from " + GetAccessType.DataBaseName + "v_qx_log where id='" + this.Id + "'";
            try
            {
                DataSet set = db.ExecuteDataset(commandText);
                if ((set != null) && (set.Tables[0].Rows.Count > 0))
                {
                    this.Id = set.Tables[0].Rows[0]["id"].ToString();
                    this.UserId = Convert.IsDBNull(set.Tables[0].Rows[0]["webuser"]) ? "" : set.Tables[0].Rows[0]["webuser"].ToString();
                    this.UserName = Convert.IsDBNull(set.Tables[0].Rows[0]["webusername"]) ? "" : set.Tables[0].Rows[0]["webusername"].ToString();
                    this.FunctionId = Convert.IsDBNull(set.Tables[0].Rows[0]["type"]) ? "" : set.Tables[0].Rows[0]["type"].ToString();
                    this.FunctionName = Convert.IsDBNull(set.Tables[0].Rows[0]["name"]) ? "" : set.Tables[0].Rows[0]["name"].ToString();
                    this.LogIp = Convert.IsDBNull(set.Tables[0].Rows[0]["logip"]) ? "" : set.Tables[0].Rows[0]["logip"].ToString();
                    this.functiondata = Convert.IsDBNull(set.Tables[0].Rows[0]["nrstringdata"]) ? null : ((byte[]) set.Tables[0].Rows[0]["nrstringdata"]);
                    this.LogTable = Convert.IsDBNull(set.Tables[0].Rows[0]["logtable"]) ? "" : set.Tables[0].Rows[0]["logtable"].ToString();
                    this.LogTableKey = Convert.IsDBNull(set.Tables[0].Rows[0]["logtablekey"]) ? "" : set.Tables[0].Rows[0]["logtablekey"].ToString();
                    this.LogTableId = Convert.IsDBNull(set.Tables[0].Rows[0]["logtableid"]) ? "" : set.Tables[0].Rows[0]["logtableid"].ToString();
                    this.LogCause = Convert.IsDBNull(set.Tables[0].Rows[0]["logdelyy"]) ? "" : set.Tables[0].Rows[0]["logdelyy"].ToString();
                    this.LogDate = Convert.IsDBNull(set.Tables[0].Rows[0]["logdate"]) ? "" : set.Tables[0].Rows[0]["logdate"].ToString();
                }
            }
            catch (LogException)
            {
                throw new LogException("读取日志失败!");
            }
        }

        public static QxLog[] SearchLog(string strwhere, DataBase db)
        {
            QxLog[] logArray = null;
            string commandText = "select id,webuser,type,nrstring,logip,nrstringdata,logtable,logtablekey,logtableid,logdelyy,webusername,logdate,name from " + GetAccessType.DataBaseName + "v_qx_log";
            if ((strwhere != null) && (strwhere.Trim() != ""))
            {
                commandText = commandText + " where " + strwhere;
            }
            try
            {
                DataSet set = db.ExecuteDataset(commandText);
                if (set == null)
                {
                    return logArray;
                }
                logArray = new QxLog[set.Tables[0].Rows.Count];
                for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                {
                    logArray[i] = new QxLog();
                    logArray[i].Id = set.Tables[0].Rows[0]["id"].ToString();
                    logArray[i].UserId = Convert.IsDBNull(set.Tables[0].Rows[0]["webuser"]) ? "" : set.Tables[0].Rows[0]["webuser"].ToString();
                    logArray[i].UserName = Convert.IsDBNull(set.Tables[0].Rows[0]["webusername"]) ? "" : set.Tables[0].Rows[0]["webusername"].ToString();
                    logArray[i].FunctionId = Convert.IsDBNull(set.Tables[0].Rows[0]["type"]) ? "" : set.Tables[0].Rows[0]["type"].ToString();
                    logArray[i].FunctionName = Convert.IsDBNull(set.Tables[0].Rows[0]["name"]) ? "" : set.Tables[0].Rows[0]["name"].ToString();
                    logArray[i].LogIp = Convert.IsDBNull(set.Tables[0].Rows[0]["logip"]) ? "" : set.Tables[0].Rows[0]["logip"].ToString();
                    logArray[i].functiondata = Convert.IsDBNull(set.Tables[0].Rows[0]["nrstringdata"]) ? null : ((byte[]) set.Tables[0].Rows[0]["nrstringdata"]);
                    logArray[i].LogTable = Convert.IsDBNull(set.Tables[0].Rows[0]["logtable"]) ? "" : set.Tables[0].Rows[0]["logtable"].ToString();
                    logArray[i].LogTableKey = Convert.IsDBNull(set.Tables[0].Rows[0]["logtablekey"]) ? "" : set.Tables[0].Rows[0]["logtablekey"].ToString();
                    logArray[i].LogTableId = Convert.IsDBNull(set.Tables[0].Rows[0]["logtableid"]) ? "" : set.Tables[0].Rows[0]["logtableid"].ToString();
                    logArray[i].LogCause = Convert.IsDBNull(set.Tables[0].Rows[0]["logdelyy"]) ? "" : set.Tables[0].Rows[0]["logdelyy"].ToString();
                    logArray[i].LogDate = Convert.IsDBNull(set.Tables[0].Rows[0]["logdate"]) ? "" : set.Tables[0].Rows[0]["logdate"].ToString();
                }
            }
            catch (LogException)
            {
                throw new LogException("读取日志失败!");
            }
            return logArray;
        }

        public bool WriteLog(DataBase db)
        {
            if (Popedoms.Trim() != "")
            {
                int num = 0;
                string[] strArray = Popedoms.Split(",".ToCharArray());
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i].Trim() == this.FunctionId.Trim())
                    {
                        num = 1;
                        break;
                    }
                }
                if (num != 0)
                {
                    string commandText = "insert into " + GetAccessType.DataBaseName + "Qx_syslog(webuser,type,nrstring,logip,nrstringdata,logtable,logtablekey,logtableid,logdelyy,webusername) values('" + this.UserId + "','" + this.FunctionId + "','" + this.FunctionName + "','" + this.LogIp + "',";
                    ParameterCollection commandParameters = new ParameterCollection(1);
                    commandText = commandText + ":nrstringdata,";
                    commandParameters.Add(":nrstringdata", this.functiondata, MyDataType.UInt16, ParameterDirection.Input);
                    commandText = commandText + "'" + this.LogTable + "','" + this.LogTableKey + "','" + this.LogTableId + "','" + this.LogCause + "','" + this.UserName + "')";
                    try
                    {
                        db.ExecuteNonQuery(CommandType.Text, commandText, commandParameters);
                    }
                    catch (Exception)
                    {
                        throw new LogException("写入日志失败!");
                    }
                }
            }
            return true;
        }

        public DataSet FunctionData
        {
            get
            {
                if (this.functiondata != null)
                {
                    MemoryStream stream = new MemoryStream();
                    stream.Write(this.functiondata, 0, this.functiondata.Length);
                    stream.Position = 0L;
                    DataSet set = new DataSet();
                    set.ReadXml(stream);
                    stream.Close();
                    stream.Dispose();
                    return set;
                }
                return null;
            }
            set
            {
                if (value != null)
                {
                    MemoryStream stream = new MemoryStream();
                    value.WriteXml(stream);
                    this.functiondata = new byte[stream.Length];
                    stream.Position = 0L;
                    stream.Read(this.functiondata, 0, this.functiondata.Length);
                    stream.Close();
                    stream.Dispose();
                }
            }
        }

        public override string FunctionId
        {
            get
            {
                return this.functionid;
            }
            set
            {
                this.functionid = value;
            }
        }

        public string FunctionName
        {
            get
            {
                return this.functionname;
            }
            set
            {
                this.functionname = value;
            }
        }

        public override string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string LogCause
        {
            get
            {
                return this.logcause;
            }
            set
            {
                this.logcause = value;
            }
        }

        public string LogDate
        {
            get
            {
                return this.logdate;
            }
            set
            {
                this.logdate = value;
            }
        }

        public string LogIp
        {
            get
            {
                return this.logip;
            }
            set
            {
                this.logip = value;
            }
        }

        public string LogTable
        {
            get
            {
                return this.logtable;
            }
            set
            {
                this.logtable = value;
            }
        }

        public string LogTableId
        {
            get
            {
                return this.logtableid;
            }
            set
            {
                this.logtableid = value;
            }
        }

        public string LogTableKey
        {
            get
            {
                return this.logtablekey;
            }
            set
            {
                this.logtablekey = value;
            }
        }

        public override string UserId
        {
            get
            {
                return this.userid;
            }
            set
            {
                this.userid = value;
            }
        }

        public string UserName
        {
            get
            {
                return this.usertruename;
            }
            set
            {
                this.usertruename = value;
            }
        }
    }
}

