namespace MinartKidoWebDataAccess.Model.Dto
{
    public class PlacesDto
    {
        public int Id { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public double Altitude { get; set; }

        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }

    }
}
