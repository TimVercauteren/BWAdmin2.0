using System;
using System.Collections.Generic;
using System.Text;
using Models.Post;

namespace Models.Read
{
    public class UserWithInfoDto
    {
        public string UserId { get; set; }
        public PersonInfoDto UserInfo { get; set; }
    }
}
