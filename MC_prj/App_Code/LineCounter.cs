using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// AMC code sample for file counter
/// </summary>
public class LineCount
{
    private ListViewItemType name;

    public class LineCounter
    {
        //FileNames holds the names of files in the project directories
        protected ArrayList _fileNames = new ArrayList(200);

        public LineCounter() : this(@"c:", false) { }
        public LineCounter(string projectDirectory, bool searchSubDirectories)
        {
            this._projectDirectory = projectDirectory;
            this._seachSubDirectories = searchSubDirectories;
        }
        /// <summary>
        /// Returns a collection which contains objects of FileCodeCountInfo.  This CountLine method will fill the collection with the approaiate information
        /// </summary>
        public ArrayList FilesInProject
        {
            get
            {
                return _fileNames;
            }
        }
        protected bool _seachSubDirectories;
        /// <summary>
        /// seach the subdirectories of the specified Project Direcotry.  Intial value is set to false
        /// </summary>
        public bool SeachSubDirectories
        {
            get { return this._seachSubDirectories; }
            set { this._seachSubDirectories = value; }
        }
        protected string _projectDirectory;
        /// <summary>
        /// The directory in which to seach for code files.
        /// </summary>
        public string ProjectDirectory
        {
            get { return this._projectDirectory; }
            set { this._projectDirectory = value; }
        }
        protected string[] _fileTypes;
        /// <summary>
        /// File types that you wish to seach for. 
        /// </summary>
        public string[] files
        {
            get { return _fileTypes; }
            set { _fileTypes = value; }
        }

      
        protected int _lineCount;
        /// <summary>
        /// Returns the total line count for all files after the CountLine method has been called
        /// </summary>
        public int TotalLineCount
        {
            get { return this._lineCount; }
        }
        protected int _commentLineCount;
        /// <summary>
        /// Returns the total comment line count for all files after the CountLine method has been called
        /// </summary>
        public int CommentLineCount
        {
            get { return this._commentLineCount; }
        }
        protected int _emptyLinesCount;
        public int EmptyLineCount
        {
            get { return this._emptyLinesCount; }
        }
        /// <summary>
        /// Count the number of lines accoding to the parameters set in the constuctor or through their property methods
        /// </summary>
        public void CountLines()
        {
            this._lineCount = 0;
            this._commentLineCount = 0;
            this._emptyLinesCount = 0;
            this.GetLineCount(_projectDirectory);
            
            this._fileNames.TrimToSize();
        }


    
    string _comment = "//";
        private readonly ArrayList _allCodeFiles;

        /// <summary>
        /// Count the lines in the specified direcotry name
        /// </summary>
        /// <param name="directoryName"></param>
        private void GetLineCount(string directoryName)
        {
            int LineCount = 0;

            // This needs to be set to a valid directory
            string myProjectDirectory = directoryName;

            DirectoryInfo dir = new DirectoryInfo(directoryName);

            //string array for needed files
           string[] _fileTypes = { "*.cs", "*.aspx", "*.ascx", "*.css", "*.html", "*.htm", "*.js", "*.xsl", "*.xslt" };

            //uncomment to get all the files, returns to files collection
            //string[] _fileTypes = { "*.cs", "*.aspx", "*.ascx", "*.css", "*.html", "*.htm", "*.js", "*.xsl", "*.xslt", "*.txt", "*.xslts" };


            DirectoryInfo[] Directories = dir.GetDirectories();
            if (_seachSubDirectories)
            {
                foreach (DirectoryInfo directory in Directories)
                {
                    this.GetLineCount(directory.FullName);
                }

            }

            // Loops file types
            foreach (String sFileType in _fileTypes)
            {
                // Loops files
                foreach (FileInfo file in dir.GetFiles(sFileType))
                {

                    int fileLineCount = 0;
                    int fileCommentLineCount = 0;
                    int fileEmptyLineCount = 0;

                    // open files for streamreader
                    StreamReader sr = File.OpenText(file.FullName);

                    //loop until the end
                    bool keepReading = true;
                    while (keepReading)
                    {
                        string line = sr.ReadLine();

                        if (line != null)
                        {
                            line = line.Trim();
                            if (line == "")
                                fileEmptyLineCount++;
                            else if (line.StartsWith(_comment))
                                fileCommentLineCount++;

                            fileLineCount++;
                        }
                        else
                            keepReading = false;
                    }

                    // add the file info to the FileNames ArrayList
                    LineCount += fileLineCount;
                    _emptyLinesCount += fileEmptyLineCount;
                    _commentLineCount += fileCommentLineCount;

                    _fileNames.Add(new FileCodeCountInfo(file.Name, file.DirectoryName, fileLineCount, fileCommentLineCount, fileEmptyLineCount));
                    //close the streamreader
                    sr.Close();
                }
            }
                    _lineCount += LineCount;

        }
    }
    /// <summary>
    /// A struct to store information about the individual files. 
    /// To do: Implement to list view 
    /// </summary>
    public struct FileCodeCountInfo
    {
        public int LineCount;
        public int CommentLineCount;
        public int EmptyLineCount;
        public string FileName;
        public string Directory;
        public FileCodeCountInfo(string fileName, string directory, int lineCount, int commentLineCount, int emptyLineCount)
        {
            this.Directory = directory;
            this.FileName = fileName;
            this.LineCount = lineCount;
            this.CommentLineCount = commentLineCount;
            this.EmptyLineCount = emptyLineCount;
        }
    }
    
}
