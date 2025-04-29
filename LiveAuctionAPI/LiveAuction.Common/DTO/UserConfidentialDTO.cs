namespace LiveAuction.Common.DTO
{
    public class UserConfidentialDTO : UserInfoDTO
    {
        public string Password { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
