namespace CheckList;

public class ChecklistManager
{
    public void ChecklistCreate()
    {
        Console.WriteLine("Enter the name of your new list. This will appear at the top of your checklist: ");
        string checklistName = Console.ReadLine();
        
        StreamWriter newFile = new StreamWriter(checklistName + ".txt");
        newFile.WriteLine(checklistName);
        newFile.WriteLine("");
        newFile.Close();
    }

    public void ChecklistDelete()
    {
        Console.WriteLine("Select a checklist to delete: ");
        //File.Delete(fileForDeletion);
        
        string[] allChecklists = ListChecklists();
        string selection = Console.ReadLine();
    }

    private string[] ListChecklists()
    {
        int index = 1;
        string[] files = Directory.GetFiles("", "*.txt");
        
        Console.WriteLine("[0] Return to Main Menu");
        foreach (string file in files)
        {
            Console.WriteLine("[" + index + "] " + file);
            index++;
        }
        
        return files;
    }
}