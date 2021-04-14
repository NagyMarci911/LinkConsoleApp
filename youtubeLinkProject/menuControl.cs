using System;
using System.Collections.Generic;
using System.Text;

namespace youtubeLinkProject
{
    delegate void OutputHandler(string message);
    static class menuControl
    {   
        static public DataHandler datahandler;
        

        static menuControl()
        {
            datahandler = new DataHandler();
        }
        static public void ChooseOption()
        {
            do
            {
                string input = Console.ReadLine().ToLower();
                if (input == "ls")
                {
                    string[] outp =datahandler.GetLinkTypes();

                    foreach(string item in outp)
                    {
                        datahandler.outputHandler?.Invoke(item);                       
                    }
                }
                else if (input.Substring(0,4) == "add ")
                {
                    try
                    {
                        string[] inputArray = input.Split(' ');
                        string comment = null;
                        for (int i = 3; i < inputArray.Length; i++)
                        {
                            comment += inputArray[i] + " ";
                        }
                        datahandler.AddLink(inputArray[1], inputArray[2], comment);
                    }
                    catch (Exception ex)
                    {
                        datahandler.outputHandler?.Invoke("The input was not valid. You can add new link with: add typeName link comment");                      
                    }

                }
                else if (input.Substring(6) == "delete")
                {
                    try
                    {
                        string[] inputArray = input.Split(' ');
                        datahandler.DeleteLink(inputArray[1], int.Parse(inputArray[2]));
                    }
                    catch (Exception ex)
                    {
                        datahandler.outputHandler?.Invoke("There was an error. You can delete link with: delete typeName number");
                    }
                }
            } while (true);
        }
    }
}
