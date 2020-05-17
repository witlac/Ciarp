using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Factory
{
    public class AcademicProductivityFactory
    {
        public AcademicProductivity CreateProductivity(string productivityType)
        {
            AcademicProductivity productivity;
            if (productivityType.Equals("Articulo"))
            {
                productivity = new Article();
                return productivity;
            }
            else if (productivityType.Equals("Ponencia"))
            {
                productivity = new Event();
                return productivity;

            }
            else if (productivityType.Equals("Libro"))
            {
                productivity = new Book();
                return productivity;

            }
            else if (productivityType.Equals("Software"))
            {
                productivity = new Software();
                return productivity;
            }
            else
            {
                return null;
            }
        }
    }
}
