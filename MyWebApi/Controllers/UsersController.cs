using Microsoft.AspNetCore.HttpLogging;
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            int numberOfUsers = System.IO.File.ReadLines("E:\\יד\\API\\MyWebApi\\MyWebApi\\text.txt").Count();
            user.userId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText("E:\\יד\\API\\MyWebApi\\MyWebApi\\text.txt", userJson +
            Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.userId },
            user);
        }
        [HttpPost("login")]
        public ActionResult<User> PostLogin([FromBody] LoginUser loginUser)
        {
            using (StreamReader reader = System.IO.File.OpenText("E:\\יד\\API\\MyWebApi\\MyWebApi\\text.txt"))
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
            public void Put(int id, [FromBody] User user)
            {
                string textToReplace = string.Empty;
                using (StreamReader reader =
                System.IO.File.OpenText("E:\\יד\\API\\MyWebApi\\MyWebApi\\text.txt"))
                {
                    string currentUserInFile;
                    while ((currentUserInFile = reader.ReadLine()) != null)
                    {
                        User user1 =
                        JsonSerializer.Deserialize<User>(currentUserInFile);
                        if (user1.userId == id)
                            textToReplace = currentUserInFile;
                    }
                }
                if (textToReplace != string.Empty)
                {
                    string text = System.IO.File.ReadAllText("E:\\יד\\API\\MyWebApi\\MyWebApi\\text.txt");
                    text = text.Replace(textToReplace,
                    JsonSerializer.Serialize(user));
                    System.IO.File.WriteAllText("E:\\יד\\API\\MyWebApi\\MyWebApi\\text.txt", text);
                }
            }

            // DELETE api/<UserController>/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
            }
        
    }
}

