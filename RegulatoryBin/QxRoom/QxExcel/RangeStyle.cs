namespace QxRoom.QxExcel
{
    using excel;
    using System;
    using System.Drawing;

    public class RangeStyle
    {
        private QxBordersIndex borderindex;
        private QxBordersType bordertype;
        private int columnwidth = 5;
        private bool fontbold;
        private Color fontcolor = Color.Black;
        private int fontsize = 9;
        private QxHorizontalAlignment qha = QxHorizontalAlignment.Left;
        private QxVerticalAlignment qva = QxVerticalAlignment.Top;
        private int rowheight = 20;

        public void SetStyle(ref Range _range)
        {
            XlBordersIndex index = (XlBordersIndex) 1;
            _range.HorizontalAlignment = this.qha.GetHashCode();
            _range.VerticalAlignment = this.qva.GetHashCode();
            _range.Borders[index].LineStyle = this.bordertype.GetHashCode();
            _range.RowHeight = this.rowheight;
            _range.ColumnWidth = this.columnwidth;
            _range.Font.Color = ColorTranslator.ToOle(this.fontcolor);
            _range.Font.Size = this.fontsize;
            _range.Font.Bold = this.fontbold;
        }

        public QxBordersIndex BorderIndex
        {
            set
            {
                this.borderindex = value;
            }
        }

        public QxBordersType BorderType
        {
            set
            {
                this.bordertype = value;
            }
        }

        public int ColnumWidth
        {
            set
            {
                this.columnwidth = value;
            }
        }

        public bool FontBold
        {
            set
            {
                this.fontbold = value;
            }
        }

        public Color FontColor
        {
            set
            {
                this.fontcolor = value;
            }
        }

        public int FontSize
        {
            set
            {
                this.fontsize = value;
            }
        }

        public QxHorizontalAlignment HorizontalAlignment
        {
            set
            {
                this.qha = value;
            }
        }

        public int RowHeight
        {
            set
            {
                this.rowheight = value;
            }
        }

        public QxVerticalAlignment VerticalAlignment
        {
            set
            {
                this.qva = value;
            }
        }
    }
}

