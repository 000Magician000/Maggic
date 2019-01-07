using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.ID;

namespace Maggic.Items.Weapons.Elements
{
    public class IceSphere : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Field");
        }
        public override void SetDefaults()
        {
            item.damage = 55;
            item.magic = true;
            item.noMelee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 40;
            item.mana = 12;
            item.noUseGraphic = true;
            item.useAnimation = item.useTime;
            item.useStyle = 5;
            item.rare = 7;
            item.shoot = mod.ProjectileType("CircularIce");
            item.shootSpeed = 12f;
            item.value = 260000;
        }
        
        const float Circle = (float)Math.PI*2;

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                int ProjCount = 5;
                int ProjRange = 50;
                Vector2 pPosition = player.Center;
                float angle = Main.rand.NextFloat(MathHelper.TwoPi);

                for (int i = 0; i < ProjCount; i++)
                {
                    position = pPosition + (angle + Circle / ProjCount * i).ToRotationVector2() * ProjRange;
                    Vector2 vel = VectorHelper.FromTo(position,Main.MouseWorld,item.shootSpeed);

                    Projectile.NewProjectileDirect(position, vel, type, item.damage, item.knockBack, item.owner);
                }
            }

            return false;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CrystalliteBar"),10);
            recipe.AddIngredient(mod.ItemType("IceRune"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}