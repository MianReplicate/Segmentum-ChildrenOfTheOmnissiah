using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using RimWorld;
using Verse;

namespace PhosphorFire
{
    public static class RemoveOrReplaceDeathThoughts
    {
        [HarmonyPatch(typeof(PawnDiedOrDownedThoughtsUtility), nameof(PawnDiedOrDownedThoughtsUtility.GetThoughts))]
        [HarmonyPostfix]
        static void ReplaceDeathThoughts(    
            Pawn victim,
            DamageInfo? dinfo,
            PawnDiedOrDownedThoughtsKind thoughtsKind,
            ref List<IndividualThoughtToAdd> outIndividualThoughts,
            List<ThoughtToAddToAll> outAllColonistsThoughts)
        {
            outIndividualThoughts =
                outIndividualThoughts
                    .Where(thought => RankDeathUtility.ShouldCareAboutDeath(thought.addTo, victim) != RankDeathUtility.DeathCareLevel.Nope)
                    .ToList();
            outIndividualThoughts.ForEach(thought =>
            {
                if (RankDeathUtility.ShouldCareAboutDeath(thought.addTo, victim) ==
                    RankDeathUtility.DeathCareLevel.Rank)
                {
                    thought.thought.def = SegmentumDefOf.RankDeathCountingThought;
                }
            });
        }
    }
}