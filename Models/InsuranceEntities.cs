using System.Data.Entity;

namespace CarInsurance.Models
{
    public class InsuranceEntities : DbContext
    {
        public InsuranceEntities() : base("name=InsuranceEntities") { }

        public DbSet<Insuree> Insurees { get; set; }
    }
}
