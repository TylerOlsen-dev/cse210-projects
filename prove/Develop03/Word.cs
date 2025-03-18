using System;

public class Word : Scripture
{
    private string _myScripture;
    private string[] _words;
    private Reference _reference;
    private Random _random;

    public Word() : base()
    {
        GetRandomLine();
        _myScripture = GetScripture();
        _reference = GetScriptureReference();
        _words = _myScripture.Split(' ');
        _random = new Random();
    }

    public void RemoveWords(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int randomIndex = _random.Next(_words.Length);
            int attempts = 0;
            while (IsWordHidden(_words[randomIndex]) && attempts < 1000)
            {
                randomIndex = _random.Next(_words.Length);
                attempts++;
            }
            if (!IsWordHidden(_words[randomIndex]))
                _words[randomIndex] = HideWord(_words[randomIndex]);
        }
        _myScripture = string.Join(" ", _words);
        Console.Clear();
    }

    private bool IsWordHidden(string word)
    {
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] != '_')
                return false;
        }
        return true;
    }

    private string HideWord(string word)
    {
        string hidden = "";
        for (int i = 0; i < word.Length; i++)
            hidden += "_";
        return hidden;
    }

    public bool IsFullyHidden()
    {
        for (int i = 0; i < _words.Length; i++)
        {
            if (!IsWordHidden(_words[i]))
                return false;
        }
        return true;
    }

    public string GetModifiedScripture()
    {
        return _reference.ToString() + "  " + string.Join(" ", _words);
    }
}