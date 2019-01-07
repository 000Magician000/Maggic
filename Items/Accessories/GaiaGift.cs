using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Maggic.Items.Accessories
{
    [AutoloadEquip(EquipType.Face)]
    public class GaiaGift : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gaia's Gift");
            Tooltip.SetDefault("10% reduced mana usage" + "\nAutomatically use mana potions when needed" +
                               "\n+40 mana" + "\nImmunity to Mana Sickness");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = item.height = 28;
            item.rare = 7;
            item.value = Item.sellPrice(gold: 2, silver: 50);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaFlower = true;
            player.buffImmune[BuffID.ManaSickness] = true;
            player.statManaMax2 += 40;
            player.manaCost *= 0.9f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ManaFlower);
            recipe.AddIngredient(mod.ItemType("NatureRune"),2);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}