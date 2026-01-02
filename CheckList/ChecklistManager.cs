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
        string[] allChecklists = ListChecklists();
        string selection = Console.ReadLine();

        try
        {
            int selectionInt = int.Parse(selection);
            if (selection == "0")
            {
                return;
            }
            else
            {
                Console.Write("Are you sure you want to delete " + allChecklists[selectionInt - 1] + "? (y/n) ");
                string confirm = Console.ReadLine();

                while (confirm != "y" | confirm != "n")
                {
                    Console.Write("Are you sure you want to delete " + allChecklists[selectionInt - 1] + "? (y/n) ");
                    confirm = Console.ReadLine();
                }

                if (confirm == "n")
                {
                    return;
                }
                else
                {
                    string fileForDeletion = allChecklists[selectionInt - 1];
                    File.Delete(fileForDeletion);
                    return;
                }
            }
        }
        catch
        {
            Console.WriteLine("There was an error! The number inputted was most likely out of bounds. Press enter to reset and try again");
            string s = Console.ReadLine();
            return;
        }
        
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