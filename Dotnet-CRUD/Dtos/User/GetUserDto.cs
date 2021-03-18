using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_CRUD.Dtos.User
{
    public class GetUserDto
    {

        public int Id { get; set; }

        public string Name { get; set; } = "Mladen";

        public string LastName { get; set; } = "Bajic";

        public int Age { get; set; } = 21;

    }
}
