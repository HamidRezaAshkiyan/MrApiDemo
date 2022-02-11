namespace MrApiDemo.Models
{
    public class SendVerificationCodeModel
    {
        public string PhoneNumber { get; set; }
        public string PatternID { get; set; } = "5bc1f3e6-fd7b-4300-aa89-514a299a4e97";
        public string Token { get; set; } = "c2FuZGJveGFIUjBjRG92TDIxeVlYQnBMbWx5";
        public string ProjectType { get; set; } = "1";

        public SendVerificationCodeModel(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }
}
