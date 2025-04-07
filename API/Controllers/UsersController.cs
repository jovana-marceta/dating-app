using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")] // /api/users
public class UsersController(DataContext context) : ControllerBase
{
    [HttpGet] 
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        // list of users from database
        var users =  await context.Users.ToListAsync();
        return users;
    }
 
    // get individual user by id of type integer
    [HttpGet("{id:int}")] // /api/users/1
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        // get user by id from database
        var user = await context.Users.FindAsync(id);
 
        if (user == null) return NotFound(); // 404 not found
 
        return user;
    }
} 