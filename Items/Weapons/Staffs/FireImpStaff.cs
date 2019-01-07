using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Maggic.Items.Weapons.Staffs
{
    class FireImpStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 20;
            item.magic = true;
            item.noMelee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 40;
            item.useAnimation = item.useTime;
            item.useStyle = 1;
            item.knockBack = 6f;
            item.rare = 4;
            item.mana = 20;
            item.UseSound = SoundID.Item100;
            item.shoot = mod.ProjectileType("FireWall");
            item.shootSpeed = 0f;
            item.value = 12000;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int t = type;
            foreach (Projectile p in Main.projectile.Where(v => v.active && v.type == t))
            {
                p.Kill();
            }
            if (WorldGen.SolidOrSlopedTile(Main.MouseWorld.ToTileCoordinates().X, Main.MouseWorld.ToTileCoordinates().Y))
            {
                return false;
            }
            Vector2 check = player.Center;
            Vector2 spd = VectorHelper.FromTo(player.Center,Main.MouseWorld,1);
            float checkRange = Vector2.Distance(player.Center,Main.MouseWorld);
            while (!WorldGen.SolidOrSlopedTile((int)check.X / 16, (int)check.Y / 16) && checkRange > 0)
            {
                check += spd;
                checkRange--;
            }
            if (checkRange > 0) return false;
            Vector2 start = Main.MouseWorld;
            int max = 4000;
            while(!WorldGen.SolidTile(Main.tile[start.ToTileCoordinates().X,start.ToTileCoordinates().Y]))
            {
                start.Y += 1;
                if (--max<=0)
                {
                    return false;
                }
            }
            position = start - new Vector2(0,80);
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
    }

    class FireWall : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 160;
            projectile.alpha = 255;
            projectile.penetrate = 15;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.timeLeft = 2700;
            projectile.tileCollide = false;
        }

        bool set = false;
        public void SetHeight()
        {
            Vector2 startPoint = projectile.Bottom-new Vector2(0,4);
            int fullHeight = projectile.height;
            int h = 0;
            while(!WorldGen.SolidTile(Main.tile[startPoint.ToTileCoordinates().X,startPoint.ToTileCoordinates().Y]))
            {
                startPoint.Y--;
                h++;
                if (--fullHeight<=0)
                {
                    return;
                }
            }
            projectile.position.Y = startPoint.Y;
            projectile.height = h;
        }

        public override void AI()
        {
            if (!set)
            {
                SetHeight();
                set = true;
            }

            for (int i = 0; i < 7; i++)
            {
                Dust d = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.Fire);
                d.noGravity = true;
                d.scale = 1.4f;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 60*5);
        }
    }
}
