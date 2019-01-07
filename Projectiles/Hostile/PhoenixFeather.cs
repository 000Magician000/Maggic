using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Maggic.Projectiles.Hostile
{
    public class PhoenixFeather : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.timeLeft = 600;
            projectile.penetrate = -1;
            projectile.hostile = true;
            projectile.light = 0.6f;
        }

        public override void AI()
        {
            projectile.VelocityToRotation();
        }

        public override bool? CanCutTiles()
        {
            return false;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.OnFire,60);
        }
    }
}