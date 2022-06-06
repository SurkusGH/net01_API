using net01_API.DataModels;
using System.Collections.Generic;

namespace net01_API.Service
{
    public class Reg : IReg
    {
        private static readonly List<User> _regList = new();

        public IEnumerable<User> RegUser(User user)
        {
            _regList.Add(user);
            return _regList;
        }

        public IEnumerable<User> RenderUsers()
        {
            return _regList;
        }
    }
}
