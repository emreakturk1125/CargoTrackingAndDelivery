using System;
using System.Collections.Generic;
using System.Text;

namespace TekhnelogosInterviewProject.Entity.DTOs
{
    public class CargoWithCustAndPerDto : CargoDto
    {
        public CustomerDto Customer { get; set; }
        public PersonalDto Personal { get; set; }

    }
}
