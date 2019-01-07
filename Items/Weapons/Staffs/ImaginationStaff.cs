using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Maggic.Items.Weapons.Staffs
{
    public class ImaginationStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.damage = 80;
            item.magic = true;
            item.noMelee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 16;
            item.useAnimation = item.useTime;
            item.useStyle = 5;
            item.knockBack = 6.5f;
            item.rare = 6;
            item.mana = 20;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("ImaginationCore");
            item.shootSpeed = 10f;
            item.value = 280000;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RainbowRod);
            recipe.AddIngredient(mod.ItemType("EnchantmentPiece"));
            recipe.AddIngredient(mod.ItemType("FireRune"));
            recipe.AddIngredient(mod.ItemType("IceRune"));
            recipe.AddIngredient(mod.ItemType("NatureRune"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}