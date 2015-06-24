using System;

public class StateInfo
{
    private string _hotelid;
    private string _info;
    private int _roleid;
    private int _state;
    public static string StrHotelIds = "";

    public StateInfo()
    {
    }

    public StateInfo(int state, string info)
    {
        this._state = state;
        this._info = info;
    }

    public string Hotelid
    {
        get
        {
            return this._hotelid;
        }
        set
        {
            this._hotelid = value;
        }
    }

    public string Info
    {
        get
        {
            return this._info;
        }
        set
        {
            this._info = value;
        }
    }

    public int RoleId
    {
        get
        {
            return this._roleid;
        }
        set
        {
            this._roleid = value;
        }
    }

    public int State
    {
        get
        {
            return this._state;
        }
        set
        {
            this._state = value;
        }
    }
}

