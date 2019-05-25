using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllaBolag.BL.Models
{
    public class ProfileListItem : Result<ProfileListItem>
    {
        public string Header { get; set; }
        public string ProfileLink { get; set; }
        public string SubTitle { get; set; }
        public string OrganisationNumber { get; set; }
        public string BusinessArea { get; set; }
        public override string ToString()
        {
            return $"{this.Header?.Trim()}\t" +
         $"{this.ProfileLink?.Trim()}\t" +
         $"{this.SubTitle?.Trim()}\t" +
         $"{this.OrganisationNumber?.Trim()}\t" +
         $"{this.BusinessArea?.Trim()}";
        }
    }

}
