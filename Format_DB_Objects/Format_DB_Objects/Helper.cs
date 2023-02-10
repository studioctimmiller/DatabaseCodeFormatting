using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using WordsToUpperCase;
using System.IO;
using System.Text.Json.Nodes;
using System.Diagnostics;

namespace Format_DB_Objects
{
    internal static class Helper
    {
        internal static void FormatFile(string fileName, string directoryName)
        {
            List<string> files = new List<string>();
            if (String.IsNullOrEmpty(fileName))
            {
                files.AddRange(Directory.GetFiles(directoryName));
            }
            else
            {
                files.Add(fileName);
            }
            foreach (var file in files)
            {
                StreamReader f = new StreamReader(file);
                var onlyFN = file.Substring(file.LastIndexOf('\\') + 1, file.Length - file.LastIndexOf('\\') - 1);
                var newfile = $"C:\\temp\\{onlyFN}";
                var newFile = new StreamWriter(newfile);

                while (f.Peek() > 0)
                {
                    var line = f.ReadLine();

                    if (line != string.Empty)
                    {
                        foreach (var word in Formatting.Words)
                        {
                            if(word=="create_date")
                            {
                                var stop = true;
                            }
                            line = Regex.Replace(line, word, word, RegexOptions.IgnoreCase);
                        }
                    }
                    newFile.WriteLine(line);
                }

                newFile.Close();
                f.Close();
                File.Delete(file);
                File.Copy(newfile, file);
                File.Delete(newfile);
            }

        }

        public static void ExecuteCommand(string command)
        {
            int ExitCode;
            ProcessStartInfo ProcessInfo;
            Process Process;

            if (File.Exists(command))
            {
                var stop = true;
            }

            ProcessInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;

            Process = Process.Start(ProcessInfo);
            Process.WaitForExit();

            ExitCode = Process.ExitCode;
            Process.Close();
        }
    }
}
