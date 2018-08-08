using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LinkerPad.Data;

namespace LinkerPad.DataAccess.Mapping
{
    public class UserDataMap : ClassMap<UserData>
    {
        public UserDataMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Username).Nullable();
            Map(x => x.Password).Nullable();
            Table("Tbl_User");
        }
    }
}
