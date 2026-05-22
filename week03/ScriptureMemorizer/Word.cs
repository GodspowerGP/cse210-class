using System;

public class Word
{
    // The text of the word (e.g., "God")
    private string _text;
    
    // Whether the word is currently hidden
    private bool _isHidden;

    // Constructor to set up the word
    public Word(string text)
    {
        _text = text;
        _isHidden = false; // By default, words are visible
    }

    // Hides the word
    public void Hide()
    {
        _isHidden = true;
    }

    // Shows the word (if needed)
    public void Show()
    {
        _isHidden = false;
    }

    // Returns true if the word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Gets the display text, which is either the word itself or underscores
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Create a string of underscores that is the same length as the word
            string underscores = "";
            foreach (char c in _text)
            {
                underscores += "_";
            }
            return underscores;
        }
        else
        {
            // If not hidden, return the actual word
            return _text;
        }
    }
}
