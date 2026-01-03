namespace CheckList;

public class ChecklistEditor
{
    private string file;
    
    public ChecklistEditor(string f)
    {
        file = f;
    }

    public void PrintChecklist()
    {
        StreamReader checklist = new StreamReader(file);

        while (!checklist.EndOfStream)
        {
            Console.Write(checklist.ReadLine());
        }
        checklist.Close();
    }

    public void CheckTasks()
    {
        
    }

    public void AddTask()
    {
        
    }

    public void DeleteTask()
    {
        
    }

    public void EditTask()
    {
        
    }
}