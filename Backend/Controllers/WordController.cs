using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("word")]
public class WordController : ControllerBase
{
    private static readonly string[] AllWords =
        System.IO.File.ReadAllLines("Data/words.txt");

    [HttpGet("{n:int}")]
    public string[] Get(int n)
    {
        return AllWords.Take(n).ToArray();
    }

    [HttpGet("startswith/{searchText}")]
    public string[] StartsWith(string searchText)
    {
        return AllWords
            .Where(word =>
                word.StartsWith(
                    searchText,
                    StringComparison.OrdinalIgnoreCase
                )
            )
            .ToArray();
    }

    [HttpGet("contains/{searchText}")]
    public string[] Contains(string searchText)
    {
        return AllWords
            .Where(word =>
                word.Contains(
                    searchText,
                    StringComparison.OrdinalIgnoreCase
                )
            )
            .ToArray();
    }

    [HttpGet("distanceone/{searchText}")]
    public string[] DistanceOne(string searchText)
    {
        return AllWords
            .Where(word =>
                HasDistanceOne(word.Trim(), searchText)
            )
            .ToArray();
    }

    private bool HasDistanceOne(
        string word,
        string searchText)
    {
        if (word.Length != searchText.Length)
        {
            return false;
        }

        int differences = 0;

        for (int i = 0; i < word.Length; i++)
        {
            if (char.ToLower(word[i]) !=
                char.ToLower(searchText[i]))
            {
                differences++;

                if (differences > 1)
                {
                    return false;
                }
            }
        }

        return true;
    }
}