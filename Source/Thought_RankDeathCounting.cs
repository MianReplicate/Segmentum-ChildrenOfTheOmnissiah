using System.Linq;
using Core40k;
using RimWorld;
using Verse;

namespace PhosphorFire
{
    public class Thought_RankDeathCounting : Thought_Memory
    {
        public override int CurStageIndex
        {
            get
            {
                return 0;
            }
        }
    }
}