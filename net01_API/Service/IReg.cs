using net01_API.DataModels;
using System.Collections.Generic;

namespace net01_API.Service
{
    public interface IReg
    {
        IEnumerable<User> RegUser(User user);
        IEnumerable<User> RenderUsers();
    }
}
