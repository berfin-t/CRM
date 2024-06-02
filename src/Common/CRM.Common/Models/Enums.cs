using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Common.Models;

public enum ContactType
{
    None,
    Email,
    Phone,
    SocialMedia,
    Other

}

public enum Stage
{
    None,
    Prospect,
    Proposal,
    Negatiation,
    CloseWon,
    ClosedLost
}

public enum Status
{
    Pending,
    Completed,
    OnHole,
    Canceled
}

public enum Role
{
    Admin,
    SalesRep,
    Manager,
    Support
}

public enum InteractionType
{
    None,
    Email,
    PhoneCall,
    Meeting,
    SocialMedia,
    LiveChat,
    Other
}
