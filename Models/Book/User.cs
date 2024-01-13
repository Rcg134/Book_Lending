﻿using System;
using System.Collections.Generic;

namespace Book_Lending.Context;

public partial class User
{
    public long UserId { get; set; }

    public string? Name { get; set; }

    public string? MiddleName { get; set; }

    public string? Surname { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool? Active { get; set; }
}
