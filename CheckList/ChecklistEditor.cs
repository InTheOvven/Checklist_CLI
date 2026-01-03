namespace CheckList;

public class ChecklistEditor
{
    private string file;
    private List<string> tasks = new List<string>();
    
    public ChecklistEditor(string f)
    {
        file = f;
    }

    public void PrintChecklist()
    {
        StreamReader checklist = new StreamReader(file);
        int index = 1;
        
        while (!checklist.EndOfStream)
        {
            string line = checklist.ReadLine();
            char firstChar = line[0];
            if (firstChar == '[')
            {
                tasks.Append(line);
                Console.WriteLine(index + ". " + line);
            }
            else
            {
                Console.WriteLine(line);
                Console.WriteLine();
            }
        }
        checklist.Close();
    }

    public void CheckTasks()
    {
        Console.WriteLine("Enter the tasks you want to check off: ");
        string check = Console.ReadLine();
        try
        {
            int taskNumber = int.Parse(check);
            string taskChange = tasks[taskNumber - 1];
            if (taskChange[1] == ' ')
            {
                taskChange[1] = 'X';
            }
        }
        catch
        {
            return;
        }
    }

    public void AddTask()
    {
        StreamWriter checklist = new StreamWriter(file, append: true);
        Console.WriteLine("What would you like to add to your list? ");
        string newTask = Console.ReadLine();
        
        checklist.WriteLine("[ ]" + newTask);
        checklist.Close();
    }

    public void DeleteTask()
    {
        
    }

    public void EditTask()
    {
        
    }
}