using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNet.Interface
{
    public interface IPassword
    {
        System.Security.SecureString Password { get; }
    }
}
