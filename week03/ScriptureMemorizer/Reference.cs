using System;

public class Reference
{
    // Attributes to hold the parts of a scripture reference
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    // Constructor for a single verse (e.g., John 3:16)
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse; // Since it's a single verse, the end verse is the same as the start verse
    }

    // Constructor for a range of verses (e.g., Proverbs 3:5-6)
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    // Returns a formatted string for the reference
    public string GetDisplayText()
    {
        // If the start and end verses are the same, just print one verse number
        if (_verse == _endVerse)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            // If they are different, print the range
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}
