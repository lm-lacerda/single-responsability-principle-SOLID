// DEFINITION: A class should have one and only one reason to change,
// meaning that a class should have only one job.


// While "Journal" class is responsible for managing a specific journal,
// it is not reasonable that it also haves the responsability of tasks 
// such as exporting and importing new diaries. Instead, following this 
// principle, it is needed that the remaining actions be handled by 
// another entity, like a "Persistance" class object.

var journal = new Journal();
var persistence = new Persistence();

// Adding and removing entries on a journal
journal.AddEntry("I cried today");
journal.AddEntry("I ate a bug");
journal.RemoveEntry(2);

Console.WriteLine(journal);

// Exporting the journal to a text file
var path = @"C:\temp\journal.txt";
persistence.SaveToFile(journal, path);

public class Journal
{
    private readonly List<string> _entries = new List<string>();

    private static int count = 0;

    public int AddEntry(string text)
    {
        _entries.Add($"{++count}: {text}");
        return count;
    }

    public void RemoveEntry(int index)
    {
        _entries.RemoveAt(index - 1);
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, _entries);
    }
}

public class Persistence
{ 
    public void SaveToFile(Journal journal, string path, bool overwrite = false)
    {
        if (overwrite || !File.Exists(path))
        {
            File.WriteAllText(path, journal.ToString());
        }
    }
}