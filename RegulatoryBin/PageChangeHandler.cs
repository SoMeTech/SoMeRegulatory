using System;
using System.Data;
using System.Runtime.CompilerServices;

public delegate void PageChangeHandler(object send, string nstrselect, string cloname, string astrsql, DataSet dstable, DataSet dsclo);

