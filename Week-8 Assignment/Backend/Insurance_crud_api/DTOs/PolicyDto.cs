namespace Insurance_crud_api.DTOs
{
    public class PolicyDto
    {
        public string PolicyName { get; set; } = "";
        public string Provider { get; set; } = "";
        public decimal Premium { get; set; }
        public decimal CoverageAmount { get; set; }
    }
}