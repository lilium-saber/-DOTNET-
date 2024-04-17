using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Project1.Modal;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Project1
{
    public class CheckUserResult
    {
        public bool _hasUser { get; set; }
        public string message { get; set; }
    }        

    public class UserPost
    {
        public string UserName { get; set; }
        public string UserPassWord { get; set; }
    }

    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class Datause : ControllerBase
    {
        private readonly SqlNetWork _context;

        public Datause(SqlNetWork context)
        {
            _context = context;
        }

        public async Task PutUpEssay(string title, string text)
        {
            if(_context.CheckEssayName(title))
            {
            }
            else
            {
                await _context.CreateEssay0(title, text);
            }
        }

        public async Task<bool> Checkess(string title)
        {
            if(_context.CheckEssayName(title))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task AddPL(string username, string essayname, string text)
        {
            await _context.CreatePL(username, essayname, text);
        }

        public async Task<string> GetEssay(string name)
        {
            return _context.GetEssay(name);
        }

        public async Task<bool> GetCheckPL(string essayname)
        {
            return await _context.CheckPL(essayname);
        }

        public async Task<ICollection<PingLun>> SendPL(string essayname)
        {
            return await _context.GetAllPL(essayname);
        }

        //[HttpPost("CreateUser")]
        public async Task CreateUser(string name, string pw)
        {
            if (_context.CheckUser(name))
            {
            }
            else
            {
                await _context.CreateUser(name, pw);
            }
        }

        public async Task<bool> CheckUser(string name, string pw)
        {
            if (_context.CheckUser(name))
            {
                if(_context.CheckPw(pw))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Essay>> GetTop5Essay()
        {
            return await _context.Essays.Take(5).ToListAsync();
        }

    }
}
