using Chore.Enums;
namespace ChoreFullStack.Models;


public class ChoreToDo
{
  // public ChoreToDo(int id, string name, int difficulty, bool isComplete, ChoreDays day)
  // {
  //   Id = id;
  //   Name = name;
  //   Difficulty = difficulty;
  //   IsComplete = isComplete;
  //   Day = day;

  // }

  public int Id { get; set; }

  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

  public string Name { get; set; }

  public int Difficulty { get; set; }

  public bool IsComplete { get; set; }

  public ChoreDays Day { get; set; }

  public string CreatorId { get; set; }

}


