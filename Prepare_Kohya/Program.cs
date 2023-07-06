using System;
using System.IO;

public class FolderCreator
{
    public static void CreateModelFolder(string modelName, string version, string step)
    {
        string folderName = $"{modelName}_{version}";

        // Create the main folder
        Directory.CreateDirectory(folderName);

        // Create the subfolders
        string[] subfolders = { "images", "model", "config", "log" };
        foreach (string subfolder in subfolders)
        {
            string path = Path.Combine(folderName, subfolder);
            Directory.CreateDirectory(path);
        }

        // Create the nested train folder under the 'images' folder
        string trainFolderName = $"{step}_train";
        string trainFolderPath = Path.Combine(folderName, "images", trainFolderName);
        Directory.CreateDirectory(trainFolderPath);

        Console.WriteLine("Folder structure created successfully.");
    }

    public static void Main(string[] args)
    {
        string modelName;
        string version;
        string step;

        if (args.Length < 3)
        {
            Console.Write("Enter the model name: ");
            modelName = Console.ReadLine();

            Console.Write("Enter the version: ");
            version = Console.ReadLine();

            Console.Write("Enter the step per images : ");
            step = Console.ReadLine() ;
        }
        else
        {
            modelName = args[0];
            version = args[1];
            step = args[2];
        }

        CreateModelFolder(modelName, version, step);
    }
}