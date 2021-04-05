using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApplication5.Business
{
    public class MemberClaimBusiness
    {
        private const string claimsPath = @"../WebApplication5/CSVs/Claim.csv";
        private const string membersPath = @"../WebApplication5/CSVs/Member.csv";

        public async Task<string> GetClaimsByDate(string claimDate)
        {
            var claimRecords = new MemberClaimConversion<Claim, ClaimMap>();
            var memberRecords = new MemberClaimConversion<Member, MemberMap>();
            List<Claim> claims = claimRecords.ReadCSVFile(claimsPath);
            List<Member> members = memberRecords.ReadCSVFile(membersPath);
            var filteredClaimByClaimDate = claims.Where(x => x.ClaimDate == claimDate).ToList();
            var claimArrayList = new List<ClaimArray>();
            foreach (var filteredClaim in filteredClaimByClaimDate)
            {
                var claimArray = new ClaimArray();
                var member = members.Where(x => x.ID == filteredClaim.MemberID).SingleOrDefault();
                claimArray.Member = member;
                claimArray.Claim = filteredClaim;
                claimArrayList.Add(claimArray);
            }
            string claimsArray = JsonSerializer.Serialize(claimArrayList);
            return claimsArray;
        }
    }
}
