using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace DelegateLab001
{
    public class OpenDialog
    {
        static public string GetFile()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "d:\\";
            openFileDialog.Filter = "c_sharp files (*.cs)|*.cs|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                var fileStream = openFileDialog.OpenFile();
                StreamReader reader = new StreamReader(fileStream);
                fileContent = reader.ReadToEnd();
                reader.Close();
            }
            return fileContent;
        }
    }
    public class Finde 
    {
        string _fileContent;
        public Finde()
        {
            _fileContent = OpenDialog.GetFile();
        }
        public string FindeEmail()
        {
            Regex regex = new Regex(@"(\w*@\w*[.]\w*)|(\w*[.]\w*@\w*[.]\w*)", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(_fileContent);
            string str = "";
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    str += match.Value + '\n';
                }
                    
                return str;
            }
            else
            {
                return "Электронная почта не найдена!";
            }
        }
    }
}
