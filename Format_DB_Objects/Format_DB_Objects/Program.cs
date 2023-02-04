using Format_DB_Objects;
using System;
using System.Text.RegularExpressions;
using WordsToUpperCase;

var fileName = "";
var directoryName = "";
var quit = false;
var ctr = 0;
if (args.Length == 0)
{
    do
    {
        fileName = "";
        Console.WriteLine("Enter Full Filename: ");
        fileName = Console.ReadLine();
        if (String.IsNullOrEmpty(fileName))
        {
            if(ctr==0)
            {
                Console.WriteLine("Enter Full Directory Name: ");
                directoryName = Console.ReadLine();
            }
            else
            {
                break;
            }
            ctr++;
        };
        if(!String.IsNullOrEmpty(string.Concat(fileName,directoryName))) Helper.FormatFile(fileName, directoryName);
    } while (true);
}
else
{
    fileName = args[0];
    Helper.FormatFile(fileName, directoryName);
}


Console.WriteLine("Run DB Script? ");
if (Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase)) Helper.ExecuteCommand(directoryName + "\\create run.sql.bat");







