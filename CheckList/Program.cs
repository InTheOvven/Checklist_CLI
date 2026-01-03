namespace CheckList;

class Program
{
    
    static void Main(string[] args)
    {
        while (true)
        {
            Welcome();
        }
    }
    
    static void Welcome()
    {
        ChecklistManager manager = new ChecklistManager();
        
        Console.WriteLine("Welcome to Checklist Manager");
        Console.WriteLine("(1) View/Manage saved checklists");
        Console.WriteLine("(2) Create a new checklist");
        Console.WriteLine("(3) Delete a checklist");
        string selection = Console.ReadLine();

        if (selection == "1")
        {
            Console.Clear();
            manager.ManageChecklist();
        }
        else if (selection == "2")
        {
            Console.Clear();
            manager.ChecklistCreate();
        }
        else if (selection == "3")
        {
            Console.Clear();
            manager.ChecklistDelete();
        }
        else
        {
            Console.WriteLine("Please enter a valid option");
            Console.WriteLine();
            Welcome();
            return;
        }
    }
}