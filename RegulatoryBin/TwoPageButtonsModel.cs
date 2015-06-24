using System;

public class TwoPageButtonsModel
{
    private string ibtaddurltwo;
    private string ibtdeleteurltwo;
    private string ibtupdateurltwo;
    private bool ifaddtwo;
    private bool ifdeletetwo;
    private bool ifupdatetwo;

    public TwoPageButtonsModel()
    {
        this.ibtaddurltwo = "images/按钮/anniuxinzeng.jpg";
        this.ibtupdateurltwo = "images/按钮/anniuxiugai.jpg";
        this.ibtdeleteurltwo = "images/按钮/anniushanchu.jpg";
    }

    public TwoPageButtonsModel(string UserName)
    {
        this.ibtaddurltwo = "images/按钮/anniuxinzeng.jpg";
        this.ibtupdateurltwo = "images/按钮/anniuxiugai.jpg";
        this.ibtdeleteurltwo = "images/按钮/anniushanchu.jpg";
        if (UserName == "admin")
        {
            this.IfAddTwo = true;
            this.IfUpdateTwo = true;
            this.IfDeleteTwo = true;
        }
    }

    public string IbtAddUrlTwo
    {
        get
        {
            return this.ibtaddurltwo;
        }
        set
        {
            this.ibtaddurltwo = value;
        }
    }

    public string IbtDeleteUrlTwo
    {
        get
        {
            return this.ibtdeleteurltwo;
        }
        set
        {
            this.ibtdeleteurltwo = value;
        }
    }

    public string IbtUpdateUrlTwo
    {
        get
        {
            return this.ibtupdateurltwo;
        }
        set
        {
            this.ibtupdateurltwo = value;
        }
    }

    public bool IfAddTwo
    {
        get
        {
            return this.ifaddtwo;
        }
        set
        {
            this.ifaddtwo = value;
        }
    }

    public bool IfDeleteTwo
    {
        get
        {
            return this.ifdeletetwo;
        }
        set
        {
            this.ifdeletetwo = value;
        }
    }

    public bool IfUpdateTwo
    {
        get
        {
            return this.ifupdatetwo;
        }
        set
        {
            this.ifupdatetwo = value;
        }
    }
}

