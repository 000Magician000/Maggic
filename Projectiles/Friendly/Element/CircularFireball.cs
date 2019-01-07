using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Maggic.Projectiles.Friendly.Element
{
    public class CircularFireball : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flame");
        }

        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 14;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.timeLeft = 300;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.light = .5f;
        }

        public override bool? CanCutTiles()
        {
            return false;
        }
        
        public override bool PreKill(int timeLeft)
        {
            for(int i=0;i<10;i++)
                DustHelper.CreateDust(new Vector2(projectile.Center.X + Main.rand.NextFloat(-4,4),
                        projectile.Center.Y + Main.rand.NextFloat(-4, 4)),DustID.Fire,Color.White,projectile.oldVelocity.ToRotation().ToRotationVector2()*Main.rand.NextFloat(2,6),1,0,1.4f,true);
            return base.PreKill(timeLeft);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 60);
        }

        public override void AI()
        {
            projectile.VelocityToRotation();

            for (int i = 0; i < 5; i++)
                DustHelper.CreateDust(new Vector2(projectile.Center.X + Main.rand.Next(-3, 3),
                        projectile.Center.Y + Main.rand.Next(-3, 3)), DustID.Fire, Color.White,
                    -projectile.oldVelocity.ToRotation().ToRotationVector2() * Main.rand.Next(2, 8), 1f, 0, 1, true);
        }
        
        public override Color? GetAlpha(Color lightColor) 
        { 
            return Color.White * ((255 - projectile.alpha) / 255f); 
        } 
    }
}