using RimWorld;
using Seg;

namespace PhosphorFire
{
    [DefOf]
    public static class SegmentumDefOf
    {
        public static PreceptDef RankDeathCounting;
        public static PreceptDef SurroundedByMachinery;
        public static ThoughtDef RankDeathCountingThought;
        public static RankDef Seg_COTO_AdeptProbatoris;

        static SegmentumDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(SegmentumDefOf));
        }
    }
}