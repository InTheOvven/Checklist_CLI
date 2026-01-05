namespace CheckList;

public class ChecklistEditor
{
    private string file;
    private List<string> tasks = new List<string>();
    
    public ChecklistEditor(string f)
    {
        file = f;
    }

    //Runs every time a checklist is loaded, and therefore loads tasks before every other function
    public void PrintChecklist()
    {
        StreamReader checklist = new StreamReader(file);
        int index = 1;
        tasks.Clear(); //Clears class level variable cuz that could be bad
        
        while (!checklist.EndOfStream)
        {
            string line = checklist.ReadLine();
            char firstChar = line[0];
            if (firstChar == '[') //If the line is a task (not title or other)
            {
                tasks.Add(line); //Populate task list
                Console.WriteLine(index + ". " + line); //Print task with its task number
                index++;
            }
            else
            {
                Console.WriteLine(line);
                //Adds space after any non-list item for viewing pleasure
                //DO NOT put a blank line in the actual file it will die
                Console.WriteLine();  
            }
        }
        checklist.Close();
    }

    public void CheckTasks()
    {
        Console.WriteLine("Enter the task you want to check off: ");
        string check = Console.ReadLine();
        try
        {
            int index = 1; //Location of the check char (Either [ ] or [X])
            int taskNumber = int.Parse(check);
            string taskChange = tasks[taskNumber - 1]; //Grabs task and stores it outside of list
            if (taskChange[1] == ' ') //If unchecked
            {
                string newTask = taskChange.Remove(index, 1);
                string checkedTask = newTask.Insert(index, "X");
                tasks[taskNumber - 1] = checkedTask; //Re-saves checked string
            }
            //Only other state is checked hopefully.
            //This isn't changing lives so as long as it doesn't break most of the time
            else 
            {
                string newTask = taskChange.Remove(index, 1);
                string checkedTask = newTask.Insert(index, " ");
                tasks[taskNumber - 1] = checkedTask;
            }
            
            SaveFile();
        }
        catch
        {
            return;
        }
    }

    public void AddTask()
    {
        StreamWriter checklist = new StreamWriter(file, append: true); //Always appends, yay!
        Console.WriteLine("What would you like to add to your list? ");
        string newTask = Console.ReadLine();
        
        checklist.WriteLine("[ ] " + newTask); //Every task begins with '[' (Important for PrintChecklist)
        checklist.Close();
    }

    public void DeleteTask()
    {
        Console.WriteLine("Enter the task you want to delete: ");
        string input = Console.ReadLine();
        try
        {
            int inputNumber = int.Parse(input);
            Console.Write("Are you sure you want to delete " + tasks[inputNumber - 1] + "? (y/n) ");
            string confirm = Console.ReadLine();

            while (confirm != "y" && confirm != "n")
            {
                Console.Write("Are you sure you want to delete \"" + tasks[inputNumber -1] + "\"? (y/n) ");
                confirm = Console.ReadLine();
            }

            if (confirm == "n")
            {
                return;
            }
            else
            {
                tasks.RemoveAt(inputNumber - 1);
                SaveFile();
                return;
            }
        }
        catch
        {
            Console.WriteLine("Delete failed, press enter to continue");
            Console.ReadLine();
            return;
        }
    }

    public void EditTask()
    {
        Console.WriteLine("Enter the task you want to edit: ");
        string input = Console.ReadLine();
        try
        {
            int inputNumber = int.Parse(input);
            Console.WriteLine("What would you like to change the task to? ");
            string newTask = Console.ReadLine();
            
            tasks[inputNumber - 1] = "[ ] " + newTask;
            SaveFile();
        }
        catch
        {
            Console.WriteLine("Edit failed, press enter to continue");
            Console.ReadLine();
            return;
        }
    }

    private void SaveFile() //Makes any changes to tasks list permanent
    {
        StreamWriter saveFile = new StreamWriter(file);
        saveFile.WriteLine(file);
        foreach (var task in tasks)
        {
            saveFile.WriteLine(task);
        }
        saveFile.Close();
    }
}