using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceLibrary.Models
{
    public class InsurancePolicy
    {
        public int PolicyId { get; set; }
        public string PolicyHolderName { get; set; }
        public string PolicyType { get; set; }
        public decimal PremiumAmount { get; set; }
        public int PolicyTerm { get; set; }
        public bool IsActive { get; set; }
        public InsurancePolicy()
        {
            IsActive = true;
        }
        public InsurancePolicy(int id, string name, string type,
                       decimal premium, int term)
        {

            PolicyId = id;
            PolicyHolderName = name;
            PolicyType = type;
            PremiumAmount = premium;
            PolicyTerm = term;
            IsActive = true;
        }
        public override string ToString()
        {
            return $"{PolicyId}\t{PolicyHolderName}\t{PolicyType}\t{PremiumAmount}\t{PolicyTerm}\t{IsActive}";
        }

    }
}
