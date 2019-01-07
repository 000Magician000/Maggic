using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Maggic.Projectiles.Friendly.Element
{
    public class NatureFusionSphere : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 46;
            projectile.height = 51;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 15;
            projectile.light = 0.8f;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            width = 10;
            height = 10;
            return base.TileCollideStyle(ref width, ref height, ref fallThrough);
        }

        public override void AI()
        {
            if (projectile.rotation < MathHelper.TwoPi)
                projectile.rotation += MathHelper.TwoPi / 8;
            else
            {
                projectile.rotation = 0;
            }

            for (int i = 0; i < 5; i++)
            {
                Dust d = Dust.NewDustDirect(
                    new Vector2(projectile.Center.X + Main.rand.NextFloat(-10, 10),
                        projectile.Center.Y + Main.rand.NextFloat(-10, 10)), 0, 0, 75);
                d.noGravity = true;
            }
        }

        public override void Kill(int timeLeft)
        {
            Explode(6);
            for (int i = 0; i < 30; i++)
            {
                int rnd = 20;
                Vector2 pos = new Vector2(projectile.Center.X + Main.rand.NextFloat(-rnd, rnd),
                    projectile.Center.Y + Main.rand.NextFloat(-rnd, rnd));
                DustHelper.CreateDust(pos,75,Color.White,Vector2.Zero,scale:1.4f,noGrav:true);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Helper.TryChance(0.5f))
                target.AddBuff(BuffID.Poisoned, 60);
        }

        private void Explode(int count)
        {
            Vector2 projVel = projectile.velocity;
            const float cir = MathHelper.TwoPi;
            float one = cir / (count * 12);
            for (int i = -count / 2; i < count / 2; i++)
            {
                Vector2 vel = (projVel.ToRotation() + (one * i)).ToRotationVector2() * 12;
                Projectile p = Projectile.NewProjectileDirect(projectile.Center, vel,
                    mod.ProjectileType("NatureFusionSphere2"),
                    projectile.damage, 0f, projectile.owner);
                p.alpha = 255;
            }
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White * ((255 - projectile.alpha) / 255f);
        }
    }
    
    public class NatureFusionSphere2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Leaf");
            Main.projFrames[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 16;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 300;
            projectile.light = 0.5f;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            width = 10;
            height = 10;
            return base.TileCollideStyle(ref width, ref height, ref fallThrough);
        }

        private int t = 30;
        private bool a = false;

        public override void AI()
        {
            projectile.VelocityToRotation();

            for (int i = 0; i < 5; i++)
                DustHelper.CreateDust(projectile.Center, 75, Color.White,
                    -projectile.velocity.ToRotation().ToRotationVector2() * Main.rand.NextFloat(2, 8), noGrav: true,
                    shader: GameShaders.Armor.GetSecondaryShader(102, Main.LocalPlayer));

            if (--t == 0 && !a)
            {
                projectile.velocity *= 1.3f;
                a = true;
            }

            if (projectile.alpha > 0)
            {
                projectile.alpha -= 255 / 25;
            }

            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
        }

        public override bool PreKill(int timeLeft)
        {
            for (int i = 0; i < 20; i++)
                DustHelper.CreateDust(new Vector2(projectile.Center.X + Main.rand.NextFloat(-4, 4),
                        projectile.Center.Y + Main.rand.NextFloat(-4, 4)), 75, Color.White,
                    projectile.oldVelocity.ToRotation().ToRotationVector2() * Main.rand.NextFloat(2, 6), 1, 0, 1.4f,
                    true, shader: GameShaders.Armor.GetSecondaryShader(102, Main.LocalPlayer));
            return base.PreKill(timeLeft);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Helper.TryChance(0.5f))
                target.AddBuff(BuffID.Poisoned, 60);
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White * ((255 - projectile.alpha) / 255f);
        }
    }
}