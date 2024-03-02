public bool InvRightClicked(Player P, int PID, int slot) {
    if (Main.rand.Next(4) <= 2) {
        P.inventory[slot].SetDefaults(73);
        P.inventory[slot].stack = Main.rand.Next(2, 7);
    }
    else if (Main.rand.Next(3) <= 1) {
        P.inventory[slot].SetDefaults(499);
        P.inventory[slot].stack = Main.rand.Next(2, 6);
    }
    else  {
        P.inventory[slot].SetDefaults(Config.itemDefs.byName["Ghost Bait"].type);
        P.inventory[slot].stack = 1;
    }
    return true;
}
