namespace MrApiDemo.Models
{
    public class VerifyCodeModel
    {
        public string PhoneNumber { get; set; }
        public string Code { get; set; }

        public VerifyCodeModel(string phoneNumber, string code)
        {
            PhoneNumber = phoneNumber;
            Code = code;
        }
    }
}
