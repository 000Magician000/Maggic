using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;

namespace Maggic.Projectiles.Friendly
{
    public class LeafBunch : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 24;
            projectile.penetrate = 1;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.timeLeft = 45;
        }     
        
        public override void AI()
        {
            projectile.rotation-=0.4f;
        }

        public override void Kill(int timeLeft)
        {
            int count = 6;
            List<Vector2> vel = VectorHelper.Circle(count, 5f);
            if (projectile.owner == Main.myPlayer)
            {
                for (int i = 0; i < count; i++)
                {
                    Projectile.NewProjectileDirect(projectile.position, vel[i], ProjectileID.Leaf, projectile.damage, 0,
                        projectile.owner);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                DustHelper.CreateDust(new Vector2(projectile.Center.X+Main.rand.Next(-14,14),projectile.Center.Y+Main.rand.Next(-14,14)),DustID.GrassBlades,Color.White,Vector2.Zero,1f,0,1,true);
            }
        }
    }
}