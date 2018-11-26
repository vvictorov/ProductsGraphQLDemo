using GraphQL.Types;

namespace RestaurantGraphQL.Api.Models
{
    public class UnitEnumType : EnumerationGraphType
    {

        public UnitEnumType()
        {
            Name = "Unit";
            Description = "The stock unit measure";
            AddValue("Kg", "Килограми", Core.Enums.UnitEnum.Kg);
            AddValue("G", "Грамове", Core.Enums.UnitEnum.G);
            AddValue("L", "Килограми", Core.Enums.UnitEnum.L);
            AddValue("Ml", "Милилитри", Core.Enums.UnitEnum.Ml);
            AddValue("Q", "Броя", Core.Enums.UnitEnum.Q);
        }
    }
}