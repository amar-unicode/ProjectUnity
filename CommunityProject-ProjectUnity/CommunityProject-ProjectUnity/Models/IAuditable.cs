﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityProject_ProjectUnity.Models
{
    internal interface IAuditable
    {
        string CreatedBy { get; set; }
        DateTime? CreatedOn { get; set; }
        string UpdatedBy { get; set; }
        DateTime? UpdatedOn { get; set; }
    }
}