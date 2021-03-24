using UnityEngine;
using System;
using System.IO;
using System.Diagnostics;

public class Dzip
{
    public void reloadConfig()
    {
        string configPath = Application.streamingAssetsPath + "\\config.dcl";
        if (File.Exists(configPath))
        {
            File.Delete(configPath);
        }

        StreamWriter configWriter = new StreamWriter(configPath);
        configWriter.WriteLine("archive .\\output\\output.dz");
        configWriter.WriteLine("basedir .\\input\\");

        FileInfo[] inputFiles = new DirectoryInfo(Application.streamingAssetsPath + "\\input\\").GetFiles();
        for (int i = 0; i < inputFiles.Length; i++)
        {
            if (inputFiles[i].Extension != ".meta")
            {
                configWriter.WriteLine("file " + inputFiles[i].Name + " 0 dz");
            }
        }
        configWriter.Close();
    }

    public void compressInput()
    {
        reloadConfig();
        ProcessStartInfo dzipStartInfo = new ProcessStartInfo();
        dzipStartInfo.FileName = Application.streamingAssetsPath + "\\dzip.exe";
        dzipStartInfo.WorkingDirectory = Application.streamingAssetsPath;
        dzipStartInfo.UseShellExecute = false;
        dzipStartInfo.CreateNoWindow = false;
        dzipStartInfo.Arguments = "config.dcl";
        try
        {
            using (Process dzip = Process.Start(dzipStartInfo))
            {
                dzip.WaitForExit();
            }
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError(e);
        }
    }

    public string decompressFile(string filename)
    {
        ProcessStartInfo dzipStartInfo = new ProcessStartInfo();
        dzipStartInfo.FileName = Application.streamingAssetsPath + "\\dzip.exe";
        dzipStartInfo.WorkingDirectory = Application.streamingAssetsPath;
        dzipStartInfo.UseShellExecute = false;
        dzipStartInfo.CreateNoWindow = false;
        dzipStartInfo.Arguments = "-d .\\input\\" + filename;
        try
        {
            using (Process dzip = Process.Start(dzipStartInfo))
            {
                dzip.WaitForExit();
                string folderName = filename.Replace(".dz", "");
                Directory.Move(Application.streamingAssetsPath + "\\input\\" + folderName, Application.streamingAssetsPath + "\\output\\" + folderName);
                return folderName;
            }
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError(e);
            return null;
        }
    }
}
