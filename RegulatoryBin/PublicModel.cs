using System;

public class PublicModel
{
    private string _pk_code;
    private string _pk_name;

    public string PK_CODE
    {
        get
        {
            return this._pk_code;
        }
        set
        {
            this._pk_code = value;
        }
    }

    public string PK_NAME
    {
        get
        {
            return this._pk_name;
        }
        set
        {
            this._pk_name = value;
        }
    }
}

