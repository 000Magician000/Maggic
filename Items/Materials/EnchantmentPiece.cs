using Terraria;
using Terraria.ModLoader;

namespace Maggic.Items.Materials
{
    class EnchantmentPiece : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 20;
            item.rare = 4;
            item.maxStack = 99;
            item.value = Item.sellPrice(gold: 5);
        }
    }
}
