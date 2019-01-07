using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Maggic.Items.Weapons.Book
{
    class Nightfall : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 40;
            item.magic = true;
            item.noMelee = true;
            item.width = 28;
            item.height = 32;
            item.useTime = 20;
            item.useAnimation = item.useTime;
            item.useStyle = 5;
            item.knockBack = 2;
            item.rare = 4;
            item.mana = 12;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Nightfall");
            item.shootSpeed = 8f;
            item.value = 560000;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CursedFlames);
            recipe.AddIngredient(ItemID.SoulofNight,20);
            recipe.AddIngredient(mod.ItemType("EnchantmentPiece"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldenShower);
            recipe.AddIngredient(ItemID.SoulofNight, 20);
            recipe.AddIngredient(mod.ItemType("EnchantmentPiece"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}