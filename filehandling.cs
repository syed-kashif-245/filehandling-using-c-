
using System;
using System.IO;
using System.Collections.Generic;

class MalformedLineException : Exception
{
    public MalformedLineException(string message) : base(message)
    {
    }
}

class EmptyValueException : Exception
{
    public EmptyValueException(string message) : base(message)
    {
    }
}

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            
            Dictionary<string, string> dict =
                new Dictionary<string, string>();

            string[] lines = File.ReadAllLines("config.txt");

            foreach (string line in lines)
            {
                
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                
                string[] parts = line.Split('=', 2);

                if (parts.Length != 2)
                {
                    throw new MalformedLineException(
                        "Malformed line: " + line
                    );
                }

                string key = parts[0].Trim();
                string value = parts[1].Trim();

                if (string.IsNullOrWhiteSpace(key) ||
                    string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyValueException(
                        "Empty key or value: " + line
                    );
                }

                dict[key] = value;
            }

            Console.WriteLine("Configuration Details:");

            foreach (var item in dict)
            {
                Console.WriteLine(item.Key + " = " + item.Value);
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Config file not found.");

            File.AppendAllText(
                "errors.log",
                DateTime.Now + " - " + ex.Message +
                Environment.NewLine
            );
        }
        catch (MalformedLineException ex)
        {
            Console.WriteLine("Invalid configuration format.");

            File.AppendAllText(
                "errors.log",
                DateTime.Now + " - " + ex.Message +
                Environment.NewLine
            );
        }
        catch (EmptyValueException ex)
        {
            Console.WriteLine("Configuration contains an empty key or value.");

            File.AppendAllText(
                "errors.log",
                DateTime.Now + " - " + ex.Message +
                Environment.NewLine
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred.");

            File.AppendAllText(
                "errors.log",
                DateTime.Now + " - " + ex.ToString() +
                Environment.NewLine
            );
        }
        finally
        {
            Console.WriteLine("The program has finished execution.");
        }
    }
}
