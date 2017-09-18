using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneApp
{
    class Users
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Dni { get; set; }
        public string Drone { get; set; }
        public string Tel { get; set; }
        /*public float Lat { get; set; }
        public float Long { get; set; }*/
    }

    class UsersLoginResponse
    {
        public bool authenticated { get; set; }
        public string error { get; set; }
    }

    class UsersRegisterResponse
    {
        public bool success { get; set; }
        public string error { get; set; }
    }
}
