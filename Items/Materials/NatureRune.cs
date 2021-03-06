﻿using Terraria;
using Terraria.ModLoader;

namespace Maggic.Items.Materials
{
    public class NatureRune : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rune of Nature");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 24;
            item.rare = 5;
            item.maxStack = 99;
            item.value = Item.sellPrice(gold: 1);
        }
    }
}