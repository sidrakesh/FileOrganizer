using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Media.Effects;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Log;

namespace FileOrganizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] videoExtensions = { ".mp4", ".avi", ".3g2", ".3gp", ".asf", ".asx", ".avi", ".flv",
                                       ".mov", ".mp4", ".mpg", ".rm", ".swf", ".vob", ".wmv", ".mts" };
        string[] imageExtensions = { ".bmp", ".jpg", ".jpeg", ".png", ".psd", ".pspimage", ".thm", 
                                       ".tif", ".yuv" };
        string[] audioExtensions = { ".aif", ".iff", ".m3u", ".m4a", ".mid", ".mp3", ".mpa", ".ra", 
                                       ".wav", ".wma" };
        string[] textFileExtensions = { ".doc", ".docx", ".log", ".msg", ".pages", ".rtf", ".txt", 
                                          ".wpd", ".wps", ".sublime-package", ".odt" };
        string[] dataFileExtensions = { ".csv", ".dat", ".efx", ".gbr", ".key", ".pps", ".ppt", ".pptx",
                                          ".sdf", ".tax2010", ".vcf", ".xml" };
        string[] developerExtensions = { ".c", ".class", ".cpp", ".cs", ".dtd", ".fla", ".java", ".m", 
                                           ".pl", ".py", ".pyc", ".in", ".out", ".h" };
        string[] diskImageExtensions = { ".dmg", ".iso", ".toast", ".vcd" };
        string[] compressedExtensions = { ".7z", ".deb", ".gz", ".pkg", ".rar", ".rpm", ".sit", ".sitx",
                                            ".tar.gz", ".zip", ".zipx", ".tar" };
        string[] webExtensions = { ".asp", ".cer", ".csr", ".css", ".htm", ".html", ".js", ".jsp", ".php",
                                     ".rss", ".xhtml" };
        string[] executableExtensions = { ".app", ".bat", ".cgi", ".com", ".exe", ".gadget", ".jar", 
                                            ".pif", ".vb", ".wsf" };
        string[] pageLayoutExtensions = { ".indd", ".pct", ".pdf", ".qxd", ".qxp", ".rels", ".mobi", ".epub"};
        string[] spreadSheetExtensions = { ".xls", ".xlr", ".xlsx" };
        string[] vectorImageExtensions = { ".ai", ".drw", ".eps", ".ps", ".svg"};
        string[] ignoreExtensions = { ".ini", ".db" };
        string[] cSharpProjectExtensions = { ".csproj"};
        string[] vsProjectExtensions = { ".sln" };

        string videoPath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
        string imagePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        string musicPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string pdfPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PDF documents");
        string dataDocPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Data documents");
        string codePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Codes");
        string compressedPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Compressed");
        string executablePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Programs and Executables");
        string textPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Text Documents");
        string webPagePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Web pages");
        string spreadSheetPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Spreadsheets");
        string vectorImagePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Vector images");
        
        string getFileString(System.IO.FileInfo fi)
        {
            string extension = fi.Extension.ToLower();
            string newFilePath = "";

            if (videoExtensions.Contains(extension))
            {
                newFilePath = System.IO.Path.Combine(videoPath, fi.Name);
            }
            else if (imageExtensions.Contains(extension))
            {
                newFilePath = System.IO.Path.Combine(imagePath, fi.Name);
            }
            else if (audioExtensions.Contains(extension))
            {
                newFilePath = System.IO.Path.Combine(musicPath, fi.Name);
            }
            else if (pageLayoutExtensions.Contains(extension))
            {
                newFilePath = System.IO.Path.Combine(pdfPath, fi.Name);
            }
            else if (dataFileExtensions.Contains(extension))
            {
                newFilePath = System.IO.Path.Combine(dataDocPath, fi.Name);
            }
            else if (developerExtensions.Contains(extension))
            {
                newFilePath = System.IO.Path.Combine(codePath, fi.Name);
            }
            else if (compressedExtensions.Contains(extension))
            {
                newFilePath = System.IO.Path.Combine(compressedPath, fi.Name);
            }
            else if (executableExtensions.Contains(extension))
            {
                newFilePath = System.IO.Path.Combine(executablePath, fi.Name);
            }
            else if (textFileExtensions.Contains(extension))
            {
                newFilePath = System.IO.Path.Combine(textPath, fi.Name);
            }
            else if (spreadSheetExtensions.Contains(extension))
            {
                newFilePath = System.IO.Path.Combine(spreadSheetPath, fi.Name);
            }
            else if (webExtensions.Contains(extension))
            {
                string webPageDir = System.IO.Path.Combine(webPagePath, System.IO.Path.GetFileNameWithoutExtension(fi.FullName));
                newFilePath = System.IO.Path.Combine(webPageDir, fi.Name);
            }
            else if(vectorImageExtensions.Contains(extension))
            {
                newFilePath = System.IO.Path.Combine(vectorImagePath, fi.Name);
            }
            else if(ignoreExtensions.Contains(extension))
            {
                newFilePath = "ignore";
            }
            else if(extension.Equals(".tex"))
            {
                newFilePath = System.IO.Path.Combine(System.IO.Path.Combine(documentPath, "LaTeX"), fi.Name);
            }
            //else if()

            return newFilePath;
        }

        Logger logger = new Logger();
        string selectedPath = "";

        public MainWindow()
        {
            InitializeComponent();

            logger.InfoLog("Initialization performed");
        }

        private void OpenTargetDirectory_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result.ToString().Equals("OK"))
            {
                DirectoryPath.Text = dialog.SelectedPath;
                selectedPath = dialog.SelectedPath;
                SortButton.IsEnabled = true;
                logger.SuccessLog("Directory " + dialog.SelectedPath + " selected");
            }
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the root directory
            System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(selectedPath);

            // Get the files in the directory
            System.IO.FileInfo[] fileInfos = dirInfo.GetFiles("*.*");

            string displayResult = "";

            foreach (System.IO.FileInfo fileInfo in fileInfos)
            {
                string newFilePath = getFileString(fileInfo);

                if (newFilePath.Equals("ignore"))
                {
                    logger.InfoLog("Ignoring file " + fileInfo.FullName);
                    continue;
                }

                string currentDirectory = fileInfo.Directory.FullName;
                string extension = fileInfo.Extension;
                string nameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fileInfo.Name);

                if (!newFilePath.Equals(""))
                {
                    string destDirectory = System.IO.Path.GetDirectoryName(newFilePath);

                    if (!System.IO.Directory.Exists(destDirectory))
                    {
                        System.IO.Directory.CreateDirectory(destDirectory);
                        logger.InfoLog("Destination directory " + destDirectory + " created");
                    }

                    if (!System.IO.File.Exists(newFilePath))
                    {
                        File.Move(fileInfo.FullName, newFilePath);

                        logger.InfoLog("Moved file " + fileInfo.FullName + " to " + newFilePath);

                        if (extension.Equals(".html"))
                        {
                            string resourceFolder = System.IO.Path.Combine(currentDirectory, nameWithoutExtension + "_files");
                            if (Directory.Exists(resourceFolder))
                            {
                                string destFolder = System.IO.Path.Combine(destDirectory, nameWithoutExtension + "_files");
                                Directory.Move(resourceFolder, destFolder);
                                logger.InfoLog("Moved resource directory " + destFolder + " for html page");
                            }
                        }
                    }
                    else
                    {
                        displayResult += "File '" + System.IO.Path.GetFileName(newFilePath) + "' already exists at destination '" + destDirectory + "'\n";
                        logger.FailureLog("File '" + System.IO.Path.GetFileName(newFilePath) + "' already exists at destination '" + destDirectory + "'");
                    }
                }
                else
                {
                    displayResult += "Encountered unresolved File " + fileInfo.Name + "\n";
                    logger.FailureLog("Encountered unresolved File " + fileInfo.Name);
                }
            }

            if (displayResult.Equals(""))
            {
                System.Windows.MessageBox.Show("All files moved successfully");
                logger.SuccessLog("All files moved successfully from " + selectedPath);
            }
            else
            {
                System.Windows.MessageBox.Show(displayResult + "Remaining files moved successfully!");
            }
            //System.Windows.MessageBox.Show(all);
        }
    }
}
