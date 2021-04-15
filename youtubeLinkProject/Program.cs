using System;
using System.IO;

namespace youtubeLinkProject
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\SavedLinks"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\SavedLinks");
            }

            menuControl.datahandler.outputHandler += consoleWriter;

            Console.WriteLine("adding link: add typeName link comment");
            Console.WriteLine("delete link: delete typeName number");
            Console.WriteLine("To print out the types: ls");
            Console.WriteLine("To get all links in a type: getlinks type");

            menuControl.ChooseOption();
        }
        
        

        static void consoleWriter(string message)
        {
            Console.WriteLine(message);
        }
    }
}
