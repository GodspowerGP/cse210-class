using System;
using System.Collections.Generic;

public class Scripture
{
    // The reference for the scripture (e.g., John 3:16)
    private Reference _reference;

    // A list containing all the Word objects in the scripture
    private List<Word> _words;

    // Constructor to set up the scripture
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split the text into individual words based on spaces
        string[] splitWords = text.Split(' ');
        foreach (string wordText in splitWords)
        {
            // Create a new Word object for each string and add it to the list
            _words.Add(new Word(wordText));
        }
    }

    // Hides a specified number of random words that are not already hidden
    public void HideRandomWords(int numberToHide)
    {
        // Find all words that are currently NOT hidden
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        // If we want to hide more words than are currently visible, just hide the rest
        if (visibleWords.Count < numberToHide)
        {
            numberToHide = visibleWords.Count;
        }

        Random random = new Random();

        // Loop until we have hidden the requested number of words
        for (int i = 0; i < numberToHide; i++)
        {
            // Pick a random word from the list of visible words
            int randomIndex = random.Next(visibleWords.Count);
            Word wordToHide = visibleWords[randomIndex];
            
            // Hide it
            wordToHide.Hide();
            
            // Remove it from the list of visible words so we don't pick it again
            visibleWords.RemoveAt(randomIndex);
        }
    }

    // Combines the reference and all words into a single string for display
    public string GetDisplayText()
    {
        // Start with the reference
        string displayText = _reference.GetDisplayText() + " ";

        // Add each word to the string
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }

        return displayText;
    }

    // Checks if all words in the scripture have been hidden
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            // If even one word is NOT hidden, the whole scripture is NOT completely hidden
            if (!word.IsHidden())
            {
                return false;
            }
        }

        // If we checked all words and none were visible, it is completely hidden
        return true;
    }
}
