//fix: Removed "using Microsoft.AspNetCore.HttpLogging;" - it was added by mistake and is not used
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        //Why isn't it implemented? It should read the file and return the user with this id (or NotFound / NoContent)
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            //fix: A relative path (the file is in the project folder). The full path E:\... works only on your computer.
            //A clearer file name would help, for example users.txt
            int numberOfUsers = System.IO.File.ReadLines("text.txt").Count();
            user.userId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            //fix: A relative path
            System.IO.File.AppendAllText("text.txt", userJson +
            Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.userId },
            user);
        }
        //The assignment asks a wrong login to return NoContent() (204)
        [HttpPost("login")]
        public ActionResult<User> PostLogin([FromBody] LoginUser loginUser)
        {
            //fix: A relative path
            using (StreamReader reader = System.IO.File.OpenText("text.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.email == loginUser.email && user.password ==
                    loginUser.password)
                        return user;
                }
                return NotFound();
            }
        }


            // PUT api/<UserController>/5
            [HttpPut("{id}")]
            //The assignment asks PUT to return Ok(): change void to IActionResult and return Ok() at the end
            public void Put(int id, [FromBody] User user)
            {
                string textToReplace = string.Empty;
                //fix: A relative path
                using (StreamReader reader =
                System.IO.File.OpenText("text.txt"))
                {
                    string currentUserInFile;
                    while ((currentUserInFile = reader.ReadLine()) != null)
                    {
                        User user1 =
                        JsonSerializer.Deserialize<User>(currentUserInFile);
                        if (user1.userId == id)
                        {
                            textToReplace = currentUserInFile;
                            //fix: Found- break
                            break;
                        }
                    }
                }
                if (textToReplace != string.Empty)
                {
                    //fix: Keep the id, otherwise the updated user is saved without it
                    user.userId = id;
                    //fix: A relative path
                    string text = System.IO.File.ReadAllText("text.txt");
                    text = text.Replace(textToReplace,
                    JsonSerializer.Serialize(user));
                    //fix: A relative path
                    System.IO.File.WriteAllText("text.txt", text);
                }
            }

            // DELETE api/<UserController>/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
            }
        
    }
}

