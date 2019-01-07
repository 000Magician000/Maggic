using Terraria.ModLoader;
using Terraria;

namespace Maggic.Items.Accessories
{
    [AutoloadEquip(EquipType.Neck)]
    public class VitalityAmulet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amulet of Vitality");
            Tooltip.SetDefault("You can't pick up hearts if your health is at maximum");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.rare = 2;
            item.value = Item.sellPrice(gold: 1);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MaggicPlayer>(mod).LifeFullSpec = true;
        }
    }
}