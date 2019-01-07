﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Maggic.Items.Weapons.Elements
{
    public class NatureFusion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[item.type] = true;
        }
        
        public override void SetDefaults()
        {
            item.damage = 65;
            item.magic = true;
            item.noMelee = true;
            item.width = 48;
            item.height = 44;
            item.useTime = 42;
            item.useAnimation = item.useTime;
            item.mana = 15;
            item.useStyle = 5;
            item.rare = 7;
            item.shoot = mod.ProjectileType("NatureFusionSphere");
            item.shootSpeed = 10f;
            item.autoReuse = true;
            item.value = 280000;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CrystalliteBar"),16);
            recipe.AddIngredient(mod.ItemType("NatureRune"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}