namespace EmployeeManagerDomain.Requests
{
    public class UpdateEmployeeRequest
    {
        public string ReferenceNo { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
    }
}