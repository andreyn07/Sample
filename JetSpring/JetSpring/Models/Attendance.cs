using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JetSpring.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public string EventJoined { get; set; }
    }
}