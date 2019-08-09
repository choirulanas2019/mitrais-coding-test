using MitraisCodingTest.Core.Models;
using MitraisCodingTest.Core.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MitraisCodingTest.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMitraisCodingTestContext _context;

        public UserRepository(IMitraisCodingTestContext context)
        {
            _context = context;
        }

        public User Add(User item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            _context.Users.Add(item);
            _context.SaveChanges();
            return item;
        }

        public bool Delete(int id)
        {
            var existingItem = _context.Users.FirstOrDefault(p => p.Id == id);
            if (existingItem == null)
            {
                return false;
            }

            _context.Users.Remove(existingItem);
            _context.SaveChanges();

            return true;
        }

        public User Get(int id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public bool Update(User item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            var existingItem = _context.Users.FirstOrDefault(p => p.Id == item.Id);
            if (existingItem == null)
            {
                return false;
            }

            _context.SaveChanges();
            return true;
        }

        public bool IsExistByEmail(string email)
        {
            var item = _context.Users.FirstOrDefault(x => x.Email == email);
            return item != null;
        }

        public bool IsExistByMobileNumber(string mobileNumber)
        {
            var item = _context.Users.FirstOrDefault(x => x.MobileNumber == mobileNumber);
            return item != null;
        }
    }
}
