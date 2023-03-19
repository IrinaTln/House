namespace MyHermitage.Models.House
{
    public class HouseListViewModel
    {
        public Guid? Id { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }
        public string Architecture { get; set; }
        public int Size { get; set; }
        public int NumberOfStoreys { get; set; }
        public DateTime DateOfBildingPermition { get; set; }
    }
}
