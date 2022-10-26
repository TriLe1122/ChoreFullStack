namespace ChoreFullStack.Controllers;

[ApiController]

[Route("api/[controller]")]
public class ChoresController : ControllerBase
{
  private readonly ChoresService _cs;
  private readonly Auth0Provider _auth0Provider;

  public ChoresController(ChoresService cs, Auth0Provider auth0Provider)
  {
    _cs = cs;
    _auth0Provider = auth0Provider;
  }

  [HttpGet]
  public async Task<ActionResult<List<ChoreToDo>>> Get()
  {
    try
    {
      var userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      var chores = _cs.GetChoresByCreatorId(userInfo?.Id);
      return Ok(chores);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<ChoreToDo>> Create([FromBody] ChoreToDo choreData)
  {
    try
    {
      ///.... how to get the user from the bearer token
      var userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      choreData.CreatorId = userInfo?.Id; // forced this character to belong to YOU!!!

      ChoreToDo choreToDo = _cs.AddChore(choreData);
      return Ok(choreToDo);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}