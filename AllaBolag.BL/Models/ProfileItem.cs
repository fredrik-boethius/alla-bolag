using AllaBolag.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllaBolag.BL.Models
{
    public class ProfileItem : Result<ProfileItem>
    {
        public string OrganisationNumber { get; set; }
        public string CompanyName { get; set; }
        public CompanyInformation CompanyInformation { get; set; }
        public CompanyFinances CompanyFinances { get; set; }

        public override string ToString()
        {
            return $"{this.CompanyName?.Trim().Split(new string[] { "\n" }, StringSplitOptions.None)[0]}\t" +
                $"{this.OrganisationNumber?.Trim().Split(new string[] { "\n" }, StringSplitOptions.None)[0].Transform((s)=> s.TrimStart())}\t" +
                $"{this.CompanyInformation?.CEO?.Trim().Split(new string[] { "\n" }, StringSplitOptions.None)[0].Transform((s) => s.TrimStart())}\t" +
                $"{this.CompanyInformation?.Phone?.Trim().Split(new string[] { "\n" }, StringSplitOptions.None)[0]}\t" +
                $"{this.CompanyFinances?.NumberOfEmployees?.Trim().Transform((s) => s.Replace("\n",""))}\t" +
                $"{this.CompanyFinances?.AnnualRevenue?.Trim().Transform((s) => s.Replace("\n", ""))}\t" +
                $"{this.CompanyFinances?.BottomLine?.Trim().Split(new string[] { "\n" }, StringSplitOptions.None)[0]}\t" +
                $"{this.CompanyFinances?.NetEarnings?.Trim().Split(new string[] { "\n" }, StringSplitOptions.None)[0]}\t" +
                $"{this.CompanyFinances?.Liquidity?.Trim().Split(new string[] { "\n" }, StringSplitOptions.None)[0]}\t" +
                $"{this.CompanyFinances?.Solidity?.Trim().Split(new string[] { "\n" }, StringSplitOptions.None)[0]}";
        }
    }
    public class CompanyInformation
    {
        public string OrganisationNumber { get; set; }
        public string CEO { get; set; }
        public string Phone { get; set; }
    }
    public class CompanyFinances
    {
        public string OrganisationNumber { get; set; }
        public string NumberOfEmployees { get; set; }
        public string AnnualRevenue { get; set; }
        public string NetEarnings { get; set; }
        public string BottomLine { get; set; }
        public string Solidity { get; set; }
        public string Liquidity { get; set; }

    }


}
