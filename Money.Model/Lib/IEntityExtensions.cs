namespace Money.Model.Lib
{
    public static class IEntityExtensions
    {
        public static bool IsNew(this IEntity entity)
        {
            return entity.Id <= 0;
        }

        public static void MakeNew(this IEntity entity)
        {
            entity.Id = 0;
        }
    }
}
