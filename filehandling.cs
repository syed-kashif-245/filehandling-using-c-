using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
class program
{
    public static void Main(string[] args)
    {
        try
        {
            Dictionary<string,string> dict=new Dictionary<string, string>();
            string[] lines=File.ReadAllLines("config.txt");
            foreach(string line in lines)
            {
                string[] parts=line.Split('=');
                if (part.Length != 2)
                {
                    throw new Exception("malformed line "+line);
                }git 
                if (string.IsNullOrWhiteSpace(parts[1]))
                    throw new Exception("Empty value: " + line);
                dict[parts[0]] = parts[1];
            }
            foreach(var item in dict)
            {
                Console.WriteLine(item.Key+" = "+item.Value);
            }
        }
        catch(FileNotFoundException ex)
        {
            Console.WriteLine("Config file not found.");
        }
        catch(Exception ex)
        {
             Console.WriteLine(ex.Message);
        }
        finally{
            Console.WriteLine("the program is executed");
        }
    }
}