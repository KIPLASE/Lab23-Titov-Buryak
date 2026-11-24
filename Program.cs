using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        
        Console.Write("Сколько задач добавить сначала: ");
        int count = Convert.ToInt32(Console.ReadLine());

        List<string> tasks = new List<string>();

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Задача {i + 1}: ");
            string title = Console.ReadLine() ?? "";
            tasks.Add(title);
        }

        
        PrintTasks(tasks);

        
        Console.Write("Новая задача для добавления в конец: ");
        string newTask = Console.ReadLine() ?? "";
        tasks.Add(newTask);
        Console.WriteLine("Задача добавлена");

        
        Console.Write("Задача для вставки: ");
        string insertTask = Console.ReadLine() ?? "";

        Console.Write("Индекс вставки: ");
        int insertIndex = Convert.ToInt32(Console.ReadLine());

        if (InsertTaskSafe(tasks, insertIndex, insertTask))
        {
            Console.WriteLine("Задача вставлена");
        }
        else
        {
            Console.WriteLine("Недопустимый индекс вставки");
        }

        
        Console.Write("Название задачи для удаления: ");
        string removeTask = Console.ReadLine() ?? "";

        bool removed = tasks.Remove(removeTask);
        if (removed)
        {
            Console.WriteLine("Первое совпадение удалено");
        }
        else
        {
            Console.WriteLine("Задача не найдена");
        }

        
        Console.Write("Индекс задачи для удаления: ");
        int removeIndex = Convert.ToInt32(Console.ReadLine());

        if (RemoveTaskAtSafe(tasks, removeIndex))
        {
            Console.WriteLine("Задача по индексу удалена");
        }
        else
        {
            Console.WriteLine("Недопустимый индекс удаления");
        }

        
        Console.Write("Название задачи для поиска: ");
        string searchTask = Console.ReadLine() ?? "";

        int index = tasks.IndexOf(searchTask);
        if (index >= 0)
        {
            Console.WriteLine($"Первый индекс: {index}");
        }
        else
        {
            Console.WriteLine("Задача не найдена");
        }

        
        Console.WriteLine();
        Console.WriteLine(">>> Итоговый список дел <<<");
        Console.WriteLine();

        Console.WriteLine($"Количество задач: {tasks.Count}");
        PrintTasks(tasks);

        
        Console.WriteLine();
        Console.Write("Введите название задачи для подсчёта совпадений: ");
        string countTaskName = Console.ReadLine() ?? "";

        int matches = CountTask(tasks, countTaskName);
        Console.WriteLine($"Количество совпадений \"{countTaskName}\": {matches}");

        PrintTasks(tasks); 
    }

    
    static void PrintTasks(List<string> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Список пуст");
            return;
        }

        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i}: {tasks[i]}");
        }
    }

   
    static bool InsertTaskSafe(List<string> tasks, int index, string title)
    {
        if (index < 0 || index > tasks.Count)
        {
            return false;
        }

        tasks.Insert(index, title);
        return true;
    }

    
    static bool RemoveTaskAtSafe(List<string> tasks, int index)
    {
        if (index < 0 || index >= tasks.Count)
        {
            return false;
        }

        tasks.RemoveAt(index);
        return true;
    }

  
    static int CountTask(List<string> tasks, string title)
    {
        int counter = 0;
        foreach (var task in tasks)
        {
            if (task == title) 
            {
                counter++;
            }
        }
        return counter;
    }
}
