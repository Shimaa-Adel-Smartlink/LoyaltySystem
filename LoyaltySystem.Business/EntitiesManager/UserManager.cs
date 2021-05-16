using LoyaltySystem.Business.DTOs;
using LoyaltySystem.Business.Entities;
using LoyaltySystem.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoyaltySystem.Business.EntitiesManager
{
    public interface IUserManager
    {
        public CustomerBalanceDTO GetCustomerBalance(Guid userId);
        public bool AddNumberOfPoints(int paidAmount, Guid userId);
        public RedeemPointsDTO RedeemPoints(int points, Guid userId);
    }
    public class UserManager : IUserManager
    {
        private readonly LoyaltyContext _context;
        public UserManager(LoyaltyContext context)
        {
            _context = context;
        }
        public CustomerBalanceDTO GetCustomerBalance(Guid userId)
        {
            // Get data of the current user 
            User user = _context.Users 
            .FirstOrDefault(u => u.Id == userId);
            Configuration configuration = _context.configurations.FirstOrDefault();
            CustomerBalanceDTO customerBalanceDTO = new CustomerBalanceDTO();
            // Returns the current redeemable number of points for a customer with their monetary value 

            if (user != null && configuration != null )
            {
               customerBalanceDTO.NumOfPoints = user.Points;
               customerBalanceDTO.ValueOfPoints = user.Points * configuration.PurchaseRewardForPoint;
                // add transaction log for current user 
                TransactionLog transactionLog = new TransactionLog()
                {
                    TransactionTimestamp = DateTime.Now,
                    CreatedBy = user.Id,
                    CreatedByNavigation = user,
                    Action = "GetCustomerBalance"
                };
                _context.transactionLogs.Add(transactionLog);
                _context.SaveChanges();
            }
            else
            {
                customerBalanceDTO.NumOfPoints = 0;
                customerBalanceDTO.ValueOfPoints =0;
            }
            return customerBalanceDTO;
         
          
        }
        public bool AddNumberOfPoints(int paidAmount , Guid userId)
        {
            // Get data of the current user 
            User user = _context.Users
                .FirstOrDefault(u => u.Id == userId);

            Configuration configuration = _context.configurations.First();

            // add an equal number of points to the customer’s balance
            if (user != null && configuration != null)
            {
                user.Points += paidAmount * configuration.PurchaseRewardPerPoint;
                _context.Update(user);
                _context.SaveChanges();
                // add transaction log for current user 
                TransactionLog transactionLog = new TransactionLog()
                {
                    TransactionTimestamp = DateTime.Now,
                    CreatedBy = user.Id,
                    CreatedByNavigation = user,
                    Action = "AddNumberOfPoints"
                };
                _context.transactionLogs.Add(transactionLog);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public RedeemPointsDTO RedeemPoints(int points, Guid userId)
        {
            // Get data of the current user 
            User user = _context.Users
                .FirstOrDefault(u => u.Id == userId);

            Configuration configuration = _context.configurations.First();
            RedeemPointsDTO redeemPointsDTO = new RedeemPointsDTO();
            // Redeem number of points equivalent to the given amount 
            if (user != null && configuration != null)
            {
                if (user.Points >= points && user.Points > 0)
                {
                    redeemPointsDTO.amount = points * configuration.PurchaseRewardForPoint;
                    redeemPointsDTO.redeemPointsEnum = RedeemPointsEnum.reedemSuccessfuly.ToString();
                    user.Points -= points;
                    _context.Update(user);
                    _context.SaveChanges();

                }
                else
                {
                    redeemPointsDTO.redeemPointsEnum = RedeemPointsEnum.noAvailablePoints.ToString();
                }
   
                // add transaction log for current user 
                TransactionLog transactionLog = new TransactionLog()
                {
                    TransactionTimestamp = DateTime.Now,
                    CreatedBy = user.Id,
                    CreatedByNavigation = user,
                    Action = "RedeemPoints"
                };
                _context.transactionLogs.Add(transactionLog);
                _context.SaveChanges();
            }
            else
            {
                redeemPointsDTO.redeemPointsEnum = RedeemPointsEnum.userNotExist.ToString();
            }
            return redeemPointsDTO;
        }
    }
}
