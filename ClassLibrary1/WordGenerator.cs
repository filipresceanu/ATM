﻿using Functii;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;


namespace ClassLibrary1
{
    public class WordGenerator
    {
        //public void ToCsV(GridView dGV, string filename)
        //{
        //    string stOutput = "";
        //    // Export titles:
        //    string sHeaders = "";

        //    for (int j = 0; j < dGV.Columns.Count; j++)
        //        sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
        //    stOutput += sHeaders + "\r\n";
        //    // Export data.
        //    for (int i = 0; i < dGV.Rows.Count - 1; i++)
        //    {
        //        string stLine = "";
        //        for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
        //            stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
        //        stOutput += stLine + "\r\n";
        //    }
        //    Encoding utf16 = Encoding.GetEncoding(1254);
        //    byte[] output = utf16.GetBytes(stOutput);
        //    FileStream fs = new FileStream(filename, FileMode.Create);
        //    BinaryWriter bw = new BinaryWriter(fs);
        //    bw.Write(output, 0, output.Length); //write the encoded file
        //    bw.Flush();
        //    bw.Close();
        //    fs.Close();
        //}


    }
}
