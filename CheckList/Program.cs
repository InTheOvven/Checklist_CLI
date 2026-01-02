namespace CheckList;

class Program
{
    ChecklistManager manager = new ChecklistManager();
    
    static void Main(string[] args)
    {
        while (true)
        {
            Welcome();
        }
    }
    
    static void Welcome()
    {
        Console.WriteLine("Welcome to Checklist Manager");
        Console.WriteLine("(1) View/Manage saved checklists");
        Console.WriteLine("(2) Create a new checklist");
        Console.WriteLine("(3) Delete a checklist");
        string selection = Console.ReadLine();
    }
}