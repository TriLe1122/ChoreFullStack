namespace ChoreFullStack.Services;


public class ChoresService
{
  private readonly ChoresRepository _choresRepo;

  public ChoresService(ChoresRepository choresRepository )
  {
    _choresRepo = choresRepository;
  }

  public List<ChoreToDo> GetChores()
  {
    return _choresRepo.Get();
  }

  public  List<ChoreToDo> GetChoresByCreatorId(string creatorId)
  {
    return _choresRepo.Get(creatorId);
  }

  public ChoreToDo AddChore(ChoreToDo choreData)
  {
    return _choresRepo.Create(choreData);
  }

}