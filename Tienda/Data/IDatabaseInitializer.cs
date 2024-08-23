using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Data
{
    interface IDatabaseInitializer
    {
        Task EnsureDatabaseCreatedAsync();
    }
}
