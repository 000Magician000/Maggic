using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Maggic.Items.Accessories
{
    [AutoloadEquip(EquipType.Neck)]
    public class ExistenceAmulet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amulet of Existence Meanings");
            Tooltip.SetDefault("You can't pick up hearts or mana stars if your life/mana is at maximum");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.rare = 3;
            item.value = Item.sellPrice(gold: 2);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MaggicPlayer>(mod).ManaFullSpec = true;
            player.GetModPlayer<MaggicPlayer>(mod).LifeFullSpec = true;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("VitalityAmulet"));
            recipe.AddIngredient(mod.ItemType("ManapowerAmulet"));
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}