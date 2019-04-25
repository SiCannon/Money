namespace Money.WebApp.ViewModel
{
    public class AccountVm
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Display => $"[{Id}] {Name}";
    }
}
