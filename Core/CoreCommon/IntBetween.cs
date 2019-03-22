namespace iStore.Core.CoreCommon
{
    public class IntBetween : Between<int?>
    {
        public override bool IsBetween(int? value)
        {
            return value.HasValue && (From.HasValue && value >= From);
        }
    }
}
