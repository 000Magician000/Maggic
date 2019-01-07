using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;

namespace Maggic.Projectiles.Friendly
{
    public class ImaginationCore : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.penetrate = 10;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.alpha = 255;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.timeLeft = 3000;
        }

        bool taken = true;
        int dust { get { return 264; } }
        public override void AI()
        {
            Lighting.AddLight(projectile.Center, Main.DiscoColor.ToVector3() * 0.5f);
            for (int i = 0; i < 5; i++)
                DustHelper.CreateDust(projectile.Center, dust, Main.DiscoColor, noGrav: true);
            Vector2 a = projectile.velocity.ToRotation().ToRotationVector2();
            Vector2 b = new Vector2(a.Y, -a.X);
            projectile.timeLeft++;

            if (Main.player[projectile.owner].whoAmI == Main.myPlayer)
            {
                if (taken && Vector2.Distance(projectile.Center, Main.MouseWorld) > 70f)
                {
                    projectile.velocity = VectorHelper.FromTo(projectile.Center, Main.MouseWorld, 50f) / 4;
                }
                if (!Main.player[projectile.owner].controlUseItem)
                {
                    taken = false;
                }
            }
            projectile.VelocityToRotation();
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            width = 4;
            height = 4;
            return base.TileCollideStyle(ref width, ref height, ref fallThrough);
        }

        public override void Kill(int timeLeft)
        {
            float len = projectile.oldVelocity.Length();
            float len2 = len * 0.3f;
            for (int i = 0; i < 20; i++)
            {
                DustHelper.CreateDust(projectile.Center, dust, Main.DiscoColor, velocity: Main.rand.NextFloat(MathHelper.TwoPi).ToRotationVector2() * Main.rand.NextFloat(len2,len), noGrav: true);
            }
        }
    }
}