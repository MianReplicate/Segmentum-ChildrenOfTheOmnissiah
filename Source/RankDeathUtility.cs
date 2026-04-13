using Core40k;
using Verse;
using System.Linq;

namespace PhosphorFire
{
    public class RankDeathUtility
    {
        public enum DeathCareLevel
        {
            Colonist,
            Rank,
            Nope,
        }
        public static DeathCareLevel ShouldCareAboutDeath(Pawn pawn, Pawn corpse)
        {
            if (pawn.ideo?.Ideo?.HasPrecept(SegmentumDefOf.RankDeathCounting) ?? false)
            {
                var requiredTier = SegmentumDefOf.Seg_COTO_AdeptProbatoris.rankTier;
                
                var pawnRankInfo = pawn.GetComp<CompRankInfo>();
                var deadPawnRankInfo = pawn.GetComp<CompRankInfo>();
                if ((pawnRankInfo.HighestRank() > requiredTier && deadPawnRankInfo.HighestRank() > requiredTier &&
                     pawnRankInfo.HighestRank() == deadPawnRankInfo.HighestRank()))
                    // || pawn.relations.RelatedPawns.Contains(corpse) 
                    // || pawn.relations.DirectRelations.Any(relation => relation.otherPawn == corpse) 
                    // || pawn.relations.OpinionOf(corpse) >= 20)
                {
                    return DeathCareLevel.Rank;
                }

                return DeathCareLevel.Nope;
            }

            return DeathCareLevel.Colonist;
        }
    }
}