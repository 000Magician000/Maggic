using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Maggic.Projectiles.Friendly
{
    class GlacialBoltPro : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.alpha = 255;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.timeLeft = 1800;
            projectile.tileCollide = true;
            projectile.penetrate = 12;
        }

        public override void AI()
        {

            for (int i = 0; i < 8; i++)
                DustHelper.CreateDust(new Vector2(projectile.Center.X + Main.rand.NextFloat(-2, 3), projectile.Center.Y + Main.rand.NextFloat(-2, 3)), 59, Color.AliceBlue, Vector2.Zero, noGrav: true, scale: 0.7f);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.Y != oldVelocity.Y)
                projectile.velocity.Y = -oldVelocity.Y;
            if (projectile.velocity.X != oldVelocity.X)
                projectile.velocity.X = -oldVelocity.X;
            return false;
        }
    }
}
