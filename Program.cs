// See https://aka.ms/new-console-template for more information
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string input1 = "[BE][FE][Urgent] there is error";
        string input2 = "[BE][QA][HAHA][Urgent] there is error";

        Console.WriteLine(ParseNotificationChannels(input1));
        Console.WriteLine(ParseNotificationChannels(input2));
    }

    static string ParseNotificationChannels(string input)
    {
        var validChannels = new List<string>{ "BE", "FE", "QA", "Urgent" };
        var channelsFound = new List<string>();

        //Use regex to find all tags enclosed in square brackets
        MatchCollection matches = Regex.Matches(input, @"\[([^]]+)\]");

        foreach (Match match in matches)
        {
            string tag = match.Groups[1].Value;
            if (validChannels.Contains(tag))
            {
                channelsFound.Add(tag);
            }
        }
        // Remove duplicates and create a comma-separated list
        string result = "Receive channels: " + string.Join(", ", channelsFound.Distinct());

        return result;
    }
}
