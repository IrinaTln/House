using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHermitage.Core.Dto
{
    public class HouseDto
    {
        public Guid? Id { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }
        public string Architecture { get; set; }
        public string TypeOfBuilding { get; set; }
        public int Size { get; set; }
        public int NumberOfStoreys { get; set; }
        public string BildingMaterial { get; set; }
        public DateTime DateOfBildingPermition { get; set; }
    }
}
