using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Maggic.Projectiles.Friendly
{
    class Nightfall : ModProjectile
    {
        public override void SetDefaults()
        {
            //projectile.CloneDefaults(ProjectileID.cursed);
            projectile.width = 16;
            projectile.height = 16;
            projectile.alpha = 0;
            projectile.timeLeft = 300;
            projectile.aiStyle = 1;
            projectile.penetrate = 1;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.light = .8f;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            //projectile.alpha = (int)(Main.essScale*0.5f * 255);
            for (int x = 0; x < 2; x++)
            {
                var i = Dust.NewDustDirect(projectile.getRect().TopLeft(), projectile.getRect().Width, projectile.getRect().Height, 27, 0, 0, projectile.alpha, Color.White);
                i.shader = GameShaders.Armor.GetSecondaryShader(73, Main.LocalPlayer);
                i.fadeIn = 0.8f;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.Y != oldVelocity.Y)
                projectile.velocity.Y = -oldVelocity.Y;
            if (projectile.velocity.X != oldVelocity.X)
                projectile.velocity.X = -oldVelocity.X;
            return false;
        }

        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(projectile.Center, Vector2.Zero, mod.ProjectileType("NightfallEX"), projectile.damage, projectile.knockBack, projectile.owner);
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White * ((255 - projectile.alpha) / 255f);
        }
    }
    class NightfallEX : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 64;
            projectile.height = 64;
            projectile.alpha = 255;
            projectile.timeLeft = 90;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.light = 1.4f;
            projectile.tileCollide = false;
        }
        public override void AI()
        {
            for (float x = 0; x < MathHelper.TwoPi; x+=MathHelper.TwoPi/8)
            {
                //Vector2 vel = Main.rand.NextFloat(MathHelper.TwoPi).ToRotationVector2() * Main.rand.NextFloat(4, 6);
                Vector2 vel = x.ToRotationVector2() * Main.rand.NextFloat(4,6);
                var i = Dust.NewDustDirect(projectile.Center+vel*10, 0, 0, 27, -vel.X, -vel.Y, 0, Color.White);
                i.shader = GameShaders.Armor.GetSecondaryShader(73, Main.LocalPlayer);
                i.scale = 1.5f;
                i.alpha = 100;
                i.noGravity = true;
            }
        }
    }
}
