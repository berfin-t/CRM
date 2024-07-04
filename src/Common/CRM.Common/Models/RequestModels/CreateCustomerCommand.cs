﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Common.Models.RequestModels;

public class CreateCustomerCommand:IRequest<Guid>
{

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Company { get; set; }
    public string Notes { get; set; }

}
