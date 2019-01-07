using System.Security.Cryptography;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Shaders;

namespace Maggic.Items.Weapons.Elements
{
    internal class NatureSphere : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nature Field");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 54;
            item.magic = true;
            item.noMelee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 30;
            item.useAnimation = item.useTime;
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.knockBack = 0;
            item.rare = 7;
            item.mana = 12;
            item.useTurn = true;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("CircularLeaf");
            item.shootSpeed = 12f;
            item.value = 260000;
        }

        const float Circle = (float) Math.PI * 2;

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY,
            ref int type, ref int damage,
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
                    Vector2 vel = VectorHelper.FromTo(position, Main.MouseWorld, item.shootSpeed);

                    Projectile.NewProjectileDirect(position, vel, type, item.damage, item.knockBack, item.owner);
                }
            }

            return false;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CrystalliteBar"),10);
            recipe.AddIngredient(mod.ItemType("NatureRune"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}