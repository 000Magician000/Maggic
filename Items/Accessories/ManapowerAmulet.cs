using Terraria.ModLoader;
using Terraria;

namespace Maggic.Items.Accessories
{
    [AutoloadEquip(EquipType.Neck)]
    public class ManapowerAmulet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amulet of Manapower");
            Tooltip.SetDefault("You can't pick up mana stars if your mana is at maximum");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.rare = 2;
            item.value = Item.sellPrice(gold: 1);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MaggicPlayer>(mod).ManaFullSpec = true;
        }
    }
}