using Microsoft.AspNetCore.Mvc;

namespace SpaceShop.Models.Spaceship
{
    public class SpaceshipsCreateViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Passagers { get; set; }
        public int EnginePower { get; set; }
        public string FuelType { get; set; }
        public int FuelCapacity { get; set; }
        public string Company { get; set; }

    }

}
