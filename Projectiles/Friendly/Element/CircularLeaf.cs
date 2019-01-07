using Terraria.Graphics.Shaders;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Maggic.Projectiles.Friendly.Element
{
    public class CircularLeaf : ModProjectile
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
            projectile.timeLeft = 300;
            projectile.penetrate = 3;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.light = .5f;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            projectile.VelocityToRotation();
            for (int i = 0; i < 5; i++)
                DustHelper.CreateDust(projectile.Center, 75, Color.White,
                    -projectile.velocity.ToRotation().ToRotationVector2() * Main.rand.NextFloat(2, 8), noGrav: true,shader:GameShaders.Armor.GetSecondaryShader(102, Main.LocalPlayer));            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
        }

        public override bool? CanCutTiles()
        {
            return false;
        }
        
        public override bool PreKill(int timeLeft)
        {
            for(int i=0;i<10;i++)
                DustHelper.CreateDust(new Vector2(projectile.Center.X + Main.rand.NextFloat(-4,4),
                        projectile.Center.Y + Main.rand.NextFloat(-4, 4)),75,Color.White,projectile.oldVelocity.ToRotation().ToRotationVector2()*Main.rand.NextFloat(2,6),1,0,1.4f,true,shader:GameShaders.Armor.GetSecondaryShader(102, Main.LocalPlayer));
            return base.PreKill(timeLeft);
        }
        
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Poisoned,60);
        }
        
        public override Color? GetAlpha(Color lightColor) 
        { 
            return Color.White * ((255 - projectile.alpha) / 255f); 
        } 
    }
}