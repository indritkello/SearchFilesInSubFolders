using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Auth: Indrit Kello
/// Arguments are written in SearchForAFile.csproj,Debug Section, Command line arguments
/// </summary>
namespace SearchForAFile
{
  class Program
  {
    public static void GetFiles(string parentFolder, List<string> filePatterns, string outputFile)
    {
      Console.WriteLine("Number of files = {0}", filePatterns.Count());
      long count = 0;
      using (System.IO.StreamWriter file = new System.IO.StreamWriter(outputFile))
      {
        Console.WriteLine("Searching...");
        foreach (var item in filePatterns)
        {
          Console.WriteLine("Processing file index:" + count++);

          var listFound = Directory.GetFiles(parentFolder, item, SearchOption.AllDirectories).ToList();
          if (listFound.Count() > 0)
          {
            foreach (var listItem in listFound)
            {
              file.Write(item + "-> ");
              file.WriteLine(listItem);
            }

          }
          else
          {
            file.Write(item + "-> ");
            file.WriteLine("Not found!");
          }

        }
        Console.WriteLine("Thank you for your patience! Paths are written in the output file.");
      }

    }
    static void Main(string[] args)
    {
      //args[0]->folder's path where the we will search 
      //args[1]->text file where all the names will be listed
      //args[2]->text file where the output will be added

      string folderPath = args[0];
      string namesFile = args[1];
      string outputFile = args[2];
      List<string> fileNames = File.ReadAllLines(namesFile).ToList();


      GetFiles(folderPath, fileNames, outputFile);
      Console.ReadLine();
    }
  }
}
