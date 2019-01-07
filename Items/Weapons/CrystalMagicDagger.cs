using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Maggic.Items.Weapons
{
    public class CrystalMagicDagger : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A crystal magical returning dagger");
        }
        public override void SetDefaults()
        {
            item.damage = 48;
            item.magic = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.width = 18;
            item.height = 28;
            item.useTime = 7;
            item.useAnimation = item.useTime;
            item.useStyle = 1;
            item.knockBack = 4f;
            item.rare = 5;
            item.mana = 7;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("CrystalMagicDaggerPro");
            item.shootSpeed = 14f;
            item.value = 300000;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicDagger);
            recipe.AddIngredient(ItemID.CrystalShard,30);
            recipe.AddIngredient(ItemID.SoulofNight,10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}