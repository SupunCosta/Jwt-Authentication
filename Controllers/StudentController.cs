using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Dapper;
using JwtAuthentication.Areas.Identity.Data.User;
using JwtAuthentication.Data;


namespace JwtAuthentication.Controllers;

[Route("api/[controller]")]
[ApiController]

public class StudentController:Controller
{
    private readonly ApplicationContext _context;
    private readonly IConfiguration Configuration;
    
    public StudentController( ApplicationContext context, IConfiguration configuration)
    {
       
        _context = context;
        Configuration = configuration;
    }
    
    [Route("CreateStudent")]
    [HttpPost]
    public async Task<ActionResult> CreateStudent([FromBody] Students student)
    {
        try
        {

            if (student != null)
            {
                student.Id = Guid.NewGuid().ToString();

                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
            }

            return Ok(student);


        }
        catch (Exception ex)
        {
            return BadRequest( ex.Message);

        }
    }
    
    [Route("GetAllStudents")]
    [HttpGet]
    public async Task<ActionResult> GetAllStudents()
    {
        try
        {
             using var connection = new SqlConnection(Configuration.GetConnectionString("ApplicationContextConnection"));
           // await connection.OpenAsync();
            var students = connection.Query<Students>("Select * from Students");
              // var students =   _context.Students.Include(x => x.Address).Include(c =>c.PhoneNumber).ToList();
            

            return Ok(students);


        }
        catch (Exception ex)
        {
            return BadRequest( ex.Message);

        }
    }
    
    [Route("Exercise")]
    [HttpGet]
    public async Task<ActionResult> Exercise()
    {
        try
        {
           
            var nums = new int[]
            {
                10, 3, 5, 200, 6, 20
            };
            
            if (nums == null || nums.Length == 0)
            {
                return Ok(0);
            }

            HashSet<int> numSet = new HashSet<int>(nums);
            int longestSequenceLength = 0;

            foreach (int num in nums)
            {
                if (!numSet.Contains(num - 1))
                {
                    int currentNum = num;
                    int currentSequenceLength = 1;

                    while (numSet.Contains(currentNum + 1))
                    {
                        currentNum++;
                        currentSequenceLength++;
                    }

                    longestSequenceLength = Math.Max(longestSequenceLength, currentSequenceLength);
                }
            }



            return Ok(longestSequenceLength);


        }
        catch (Exception ex)
        {
            return BadRequest( ex.Message);

        }
    }

    
}