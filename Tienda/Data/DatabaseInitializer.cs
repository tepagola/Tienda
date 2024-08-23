using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Data
{
    class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly InventarioContext _context;

        public DatabaseInitializer(InventarioContext context)
        {
            _context = context;
        }

        public async Task EnsureDatabaseCreatedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
        }
    }
}
