using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace GoldenSparkMod.Status_Effects
{
    public class BattleUnitBuf_Gold_Spark : BattleUnitBuf
    {
        public BattleUnitBuf_Gold_Spark(int stack = 0)
        {
            this.stack = stack;
        }
    }
}
