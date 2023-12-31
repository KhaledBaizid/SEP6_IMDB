﻿using Backend.DataAccessObjects.User;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
   private IUserInterface _userInterface;
   

   public UserController(IUserInterface userInterface)
   {
      _userInterface = userInterface;
   }
   [EnableCors] 
   [HttpPost]
   public async Task<ActionResult<User>> CreateUserAccountAsync(User user)
   {
      try
      {
         return StatusCode(200,await _userInterface.CreateUserAccountAsync(user)); 
      }
      catch (Exception e)
      {
         return   StatusCode(500, e.Message);
      }
   }
   [EnableCors] 
   [HttpGet]
   [Route("username/{username}")]
   public async Task<ActionResult<long>> GetLoginUserIdByUsername(string username)
   {
      try
      {
         return StatusCode(200,await _userInterface.GetUserIdByUsername(username)); 
      }
      catch (Exception e)
      {
         return   StatusCode(500, e.Message);
      }
   }
   
   [EnableCors] 
   [HttpGet]
   public async Task<ActionResult<User>> GetLoginUserId(string mail, string password)
   {
      try
      {
         return StatusCode(200,await _userInterface.GetLoginUserIdAsync(mail,password)); 
      }
      catch (Exception e)
      {
         return   StatusCode(500, e.Message);
      }
   }
}