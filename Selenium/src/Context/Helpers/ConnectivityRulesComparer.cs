using System.Collections.Generic;

namespace FmsDbContext
{
    public class ConnectivityRulesComparer : IEqualityComparer<ConnectivityRules>
    {
        public bool Equals(ConnectivityRules x, ConnectivityRules y) => x.FromUser == y.FromUser && x.ToUser == y.ToUser;

        public int GetHashCode(ConnectivityRules obj) => (obj.FromUser.GetHashCode() + obj.ToUser.GetHashCode()).GetHashCode();
    }
}
