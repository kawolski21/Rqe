﻿namespace NechritoRiven.Event.OrbwalkingModes
{
    #region

    using Core;

    using LeagueSharp.Common;

    #endregion

    internal class JungleClearMode : Core
    {
        #region Public Methods and Operators

        public static void Jungleclear()
        {
            var mobs = MinionManager.GetMinions(
                Player.Position,
                Player.AttackRange + 240,
                MinionTypes.All,
                MinionTeam.Neutral);

            if (mobs == null) return;

            foreach (var m in mobs)
            {
                if (!m.IsValid
                    || !Spells.E.IsReady() 
                    || !MenuConfig.JnglE 
                    || Player.IsWindingUp)
                {
                    return;
                }

                Spells.E.Cast(m.Position);
                Utility.DelayAction.Add(10, Usables.CastHydra);
            }
        }

        #endregion
    }
}
