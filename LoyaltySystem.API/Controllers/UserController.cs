using LoyaltySystem.Business.DTOs;
using LoyaltySystem.Business.Entities;
using LoyaltySystem.Business.EntitiesManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LoyaltyContext _ctx;
        private readonly IUserManager _userManager;
        private readonly IConfiguration _configuration;
        public UserController
           (LoyaltyContext context, IUserManager userManager, IConfiguration iConfig)
        {
            _ctx = context;
            _userManager = userManager;
            _configuration = iConfig;
        }

        [HttpPost("GetCustomerBalance")]
        public CustomerBalanceDTO GetCustomerBalance(Guid userId)
        {
                return _userManager.GetCustomerBalance(userId);

        }

        [HttpPost("AddNumberOfPoints")]
        public string AddNumberOfPoints(int paidAmount, Guid userId)
        {
            if(_userManager.AddNumberOfPoints(paidAmount, userId))
            {
                return "Done Successfuly";
            }
            else
            {
                return "Something Wrong";

            }

        }
        [HttpPost("RedeemPoints")]
        public RedeemPointsDTO RedeemPoints(int points, Guid userId)
        {
            RedeemPointsDTO redeemPointsDTO= _userManager.RedeemPoints(points,userId);
            return redeemPointsDTO;
        }
    }
}
