using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace youtubeLinkProject
{
    class DataHandler
    {
        public List<string> Links { get; }
        private string path;
        public  OutputHandler outputHandler;

        public DataHandler()
        {
            path = Directory.GetCurrentDirectory() + "\\SavedLinks";

        }

        public void AddLink(string type, string link, string comment)
        {
            string AddPath = path + "\\" +type;
            if (!File.Exists(AddPath))
            {
                File.WriteAllText(AddPath, "1ß" +link + "ß" + comment);
            }
            else
            {
                string lastLine = File.ReadAllLines(AddPath)[File.ReadAllLines(AddPath).Length - 1];
                int numb = int.Parse(lastLine.Split('ß')[0]);
                numb++;
                File.AppendAllText(AddPath, Environment.NewLine + numb.ToString() + "ß" + link + "ß" + comment);
            }
        }
        public string[] GetLinkTypes()
        {
            string[] LinkTypes = Directory.GetFiles(path);
            for (int i = 0; i < LinkTypes.Length; i++)
            {
                string[] curr = LinkTypes[i].Split('\\');
                LinkTypes[i] = curr[curr.Length - 1];
            }
            return LinkTypes;
        }


        public List<string> GetLinks(string type)
        {
            string typePath = path + "\\" + type;
            List<string> outp = new List<string>();
            StreamReader str = new StreamReader(typePath);
            while (!str.EndOfStream)
            {
                string currentLine = str.ReadLine();
                outp.Add(string.Join("    ",currentLine.Split('ß')));
            }
            str.Close();
            
            return outp;
        }

        public void DeleteLink(string type,int number)
        {
            string typePath = path + "\\" + type;
            StreamReader str = new StreamReader(typePath);
            int line = 0;
            bool exists = false;
            while (!str.EndOfStream)
            {
                string current = str.ReadLine();
                if (current.Split('ß')[0] == number.ToString())
                {
                    exists = true;
                    break;
                }
                line++;
            }
            if (exists)
            {
                string[] allLinks = File.ReadAllLines(typePath);
                for (int i = line; i < allLinks.Length-1; i++)
                {
                    string[] splittedcurrent = allLinks[i + 1].Split('ß');
                    int currentnumb = int.Parse(splittedcurrent[0]);
                    currentnumb--;
                    splittedcurrent[0] = currentnumb.ToString();
                    allLinks[i] = string.Join("ß",splittedcurrent);
                }
                allLinks[allLinks.Length - 1] = "";
                File.WriteAllLines(typePath, allLinks);
            }
            else
            {
                outputHandler?.Invoke("There is no link with that number.");
            }
            
        }
    }
}
