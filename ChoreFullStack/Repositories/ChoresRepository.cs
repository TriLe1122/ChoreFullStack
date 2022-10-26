namespace ChoreFullStack.Repositories;

public class ChoresRepository : BaseRepository
{
  public ChoresRepository(IDbConnection db) : base(db)
  {
  }

  public List<ChoreToDo> Get()
  {
    var sql = "SELECT * FROM chores";
    return _db.Query<ChoreToDo>(sql).ToList();
  }

  public List<ChoreToDo> Get(string creatorId)
  {
    var sql = "SELECT * FROM chores WHERE creatorId = @creatorId";
    return _db.Query<ChoreToDo>(sql, new { creatorId }).ToList();
  }

  public ChoreToDo Create(ChoreToDo choreData)
  {
    var sql = @"
    INSERT INTO chores
    (name, difficulty, isComplete, day, creatorId)
    VALUES
    (@Name, @Difficulty, @IsComplete, @Day, @CreatorId);
    SELECT LAST_INSERT_ID();
    ";
    choreData.Id = _db.ExecuteScalar<int>(sql, choreData);
    return choreData;
  }
}
