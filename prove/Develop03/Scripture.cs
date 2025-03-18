using System;
using System.IO;

public class Scripture
{
    private string _scripture;
    private string _scriptureLine;
    private Reference _reference;
    private string _filePath;

    public Scripture()
    {
        _scripture = "";
        _scriptureLine = "";
        _reference = null;
        _filePath = "/Users/tylerolsen/Documents/cse210-projects/prove/Develop03/Scriptures.csv";
    }

    protected string GetRandomLine()
    {
        string[] lines = File.ReadAllLines(_filePath);
        Random random = new Random();
        int index = random.Next(lines.Length);
        _scriptureLine = lines[index];
        return _scriptureLine;
    }

    public string GetScripture()
    {
        if (string.IsNullOrEmpty(_scriptureLine))
            GetRandomLine();
        string[] parts = _scriptureLine.Split(new char[] {','}, 2);
        _scripture = parts.Length > 1 ? parts[1].Trim().Trim('"') : "";
        return _scripture;
    }

    protected Reference GetScriptureReference()
    {
        if (string.IsNullOrEmpty(_scriptureLine))
            GetRandomLine();
        string[] parts = _scriptureLine.Split(new char[] {','}, 2);
        _reference = new Reference(parts[0].Trim());
        return _reference;
    }

    public string DisplayScripture()
    {
        GetRandomLine();
        GetScripture();
        GetScriptureReference();
        return _reference.ToString() + " " + _scripture;
    }
}