using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static LineCount;

public partial class _Default : Page
{
    // string[] fileArray = Directory.GetFiles(@"c:\DistributionPortal bkup 8.27\", "*.cs", SearchOption.AllDirectories);
    private Hashtable _FileExtensionInfoTable;
    private bool error;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Files["GetAllFiles"] != null)
        {
            string[] fileArray = Directory.GetFiles(@"c:\DistributionPortal bkup 8.27\", "*.cs", SearchOption.AllDirectories);
        }

        }
    private void ListView1_SizeChanged(object sender, EventArgs e)
    {
       // ListView1.Columns[0].Width = listView1.Columns[1].Width = (listView1.Width - listView1.Columns[2].Width - widthFix) / 2;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        //gets all directories of specified path
        List<string> directories = Directory.GetDirectories(txtDirectory.Text, "*", SearchOption.AllDirectories).ToList();
        //gets all files of specified path
        List<string> files = Directory.GetFiles(txtDirectory.Text, "*.*", SearchOption.AllDirectories).ToList();

        try
        {
            LineCount.LineCounter counter = new LineCount.LineCounter(this.txtDirectory.Text, this.cbSearchSubDiretories.Checked);
            //string[] filesArray = txtFileTypes.Text.Split(new Char[] { ',' });

            // do the counting
            counter.CountLines();

            int comment = counter.CommentLineCount;
            int empty = counter.EmptyLineCount;
            int total = counter.TotalLineCount;

            this.txtcomments.Text = comment.ToString();
            txtempty.Text = empty.ToString();
            txtresult.Text = total.ToString();
            txtlinecount.Text = (total - empty - comment).ToString();

            ICollection collection = counter.FilesInProject;
           
            this.txtfilescounted.Text = collection.Count.ToString();

            txtfilecount.Text = (files.Count.ToString());


        }
        catch
        {
            
        }

    }


}