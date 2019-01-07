using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Maggic.Projectiles.Friendly
{
    class CrystalMagicDaggerPro : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.MagicDagger);
            projectile.aiStyle = 2;
            projectile.width = 18;
            projectile.height = 28;
            projectile.alpha = 50;
            projectile.timeLeft = 600;
            projectile.penetrate = 2;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.scale = 1f;
            projectile.light = .2f;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            width = 12;
            height = 12;
            return base.TileCollideStyle(ref width, ref height, ref fallThrough);
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White * ((255 - projectile.alpha) / 255f);
        }

        public override void Kill(int timeLeft)
        {
            for (int i=0;i<Main.rand.Next(6,12);i++)
            {
                int t = DustID.CrystalPulse2;
                DustHelper.CreateDust(projectile.Center, t, velocity: Main.rand.NextFloat(MathHelper.TwoPi).ToRotationVector2() * Main.rand.NextFloat(4, 8), scale: 0.8f, noGrav: true, alpha: 50);
            }
        }
    }
}