namespace lr3ASPnet.Services
{
    public class TimeService
    {
        public string GetTimeOfDay()
        {
            var hour = DateTime.Now.Hour;
            return hour switch
            {
                >= 6 and < 12 => "Зараз ранок (6-12)",
                >= 12 and < 18 => "Зараз день (12-18)",
                >= 18 and < 20 => "Зараз вечір (18-20)",
                _ => "Зараз ніч (20-00,00-6)"
            };
        }
    }
}
