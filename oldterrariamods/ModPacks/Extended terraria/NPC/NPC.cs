public void NPCLoot()
{
    NPC N = npc;
    int NT = N.type;
    string NN = N.name;
    Vector2 NV = new Vector2(N.position.X, N.position.Y);
    int a = 0;
    if (ModWorld.deadUb && (NT == 42 || NT == 43 || NT == Config.npcDefs.byName["Jungle Mummy"].type || (NN == "Jungle Slime" && NV.Y > Main.rockLayer) || NT == Config.npcDefs.byName["Queen Hornet"].type || NT == 51 || NT == 52) && ModWorld.superHardmode)
    {
	if (Main.rand.Next(5) == 0)
	{
	    a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Soul of the Jungle"].type, Main.rand.Next(2) + 1, false, 0);
	}
    }
    if (NT <= 145 && (NT != 112 && NT != 25 && NT != 30 && NT != 33 && NT != 46 && NT != 74))
    {
        if (Main.rand.Next(31) == 0 && ModWorld.superHardmode && Main.xMas)
        {
            a = Item.NewItem((int)npc.position.X, (int)npc.position.Y, 16, 16, Config.itemDefs.byName["Red Present"].type, 1, false, 0);
        }
    }
    if (NT == Config.npcDefs.byName["Armored Wraith"].type || NT == Config.npcDefs.byName["Bloodshot Eye"].type || NT == Config.npcDefs.byName["Boom Slime"].type || NT == Config.npcDefs.byName["Corrupted Elemental"].type || NT == Config.npcDefs.byName["Salmon"].type || NT == Config.npcDefs.byName["Mime"].type || NT == Config.npcDefs.byName["Cursed Magma Skeleton"].type || NT == Config.npcDefs.byName["Dark Slime"].type || NT == Config.npcDefs.byName["Gargoyle"].type || NT == Config.npcDefs.byName["Hallowor"].type || NT == Config.npcDefs.byName["Heavy Zombie"].type || NT == Config.npcDefs.byName["Ice Skeleton"].type || NT == Config.npcDefs.byName["Juggernaut"].type || NT == Config.npcDefs.byName["Illuminant Eye"].type || NT == Config.npcDefs.byName["Magma Skeleton"].type || NT == Config.npcDefs.byName["Man of War"].type || NT == Config.npcDefs.byName["Mechanical Digger Head"].type || NT == Config.npcDefs.byName["Troll"].type || NT == Config.npcDefs.byName["Vampire Harpy"].type || NT == Config.npcDefs.byName["White Slime"].type)
    {
        if (Main.xMas)
	{
		int randomNum = Main.rand.Next(31);
		if (randomNum == 0)
		{
			if (ModWorld.superHardmode)
			{
				a = Item.NewItem((int)npc.position.X, (int)npc.position.Y, 16, 16, Config.itemDefs.byName["Red Present"].type, 1, false, 0);
			}
		}
		else if (randomNum >= 7 && randomNum < 10)
		{
			a = Item.NewItem((int)npc.position.X, (int)npc.position.Y, 16, 16, Config.itemDefs.byName["Yellow Present"].type, 1, false, 0);
		}
		else if (randomNum >= 17 && randomNum < 20)
		{
			a = Item.NewItem((int)npc.position.X, (int)npc.position.Y, 16, 16, Config.itemDefs.byName["Blue Present"].type, 1, false, 0);
		}
		else if (randomNum >= 27 && randomNum < 30)
		{
			a = Item.NewItem((int)npc.position.X, (int)npc.position.Y, 16, 16, Config.itemDefs.byName["Green Present"].type, 1, false, 0);
		}
	}
    }
    if (N.boss && ModWorld.superHardmode)
    {
        if (Main.rand.Next(3) == 1)
        {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Red Present"].type, 1, false, 0);
        }
    }
    if (NT == 102 || NT == 63 || NT == 57 || NT == 67 || NT == 103 || NT == 58 || NT == 65)
    {
        if (Main.rand.Next(5) == 1)
        {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Water Shard"].type, 1, false, 0);
        }
    }
    if (NT == 39)
    {
        if (Main.rand.Next(100) <= 85)
        {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Bone"].type, Main.rand.Next(2, 8), false, 0);
        }
    }
    if (NT == 31 || NT == 77 || NT == 34 || NT == 32 || NT == 78 || NT == 140 || NT == 110 || NT == 21 || NT == 45 || NT == 44 || NT == 82 || NT == 3)
    {
        if (Main.rand.Next(8) == 1)
        {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Undead Shard"].type, 1, false, 0);
        }
    }
    if (NT == 52 || NT == 53)
    {
        if (Main.rand.Next(2) == 1)
        {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Undead Shard"].type, 2, false, 0);
        }
    }
    if (NT == 29)
    {
        if (Main.rand.Next(30) == 1)
        {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Chaos Tome"].type, 1, false, 0);
        }
    }
    if (NT == 1 || NT == 138 || NT == 16 || NT == 81)
    {
        if (Main.rand.Next(150) == 1)
        {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Slime Talisman"].type, 1, false, -1);
        }
    }
    if (NT == 42 || NT == 52 || NT == 51 || NN == "Jungle Slime" || NT == 43 || NT == 56)
    {
        if (Main.rand.Next(7) == 1)
        {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Jungle Shard"].type, Main.rand.Next(1, 2), false, 0);
        }
    }
    if (NT == 42 || NT == 52 || NT == 49 || NT == 93 || NT == 48)
    {
        if (Main.rand.Next(7) == 1)
        {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Air Shard"].type, Main.rand.Next(1, 2), false, 0);
        }
    }
    if (NT == 62 || NT == 24 || NT == 60 || NT == 59 || NT == 66)
    {
        if (Main.rand.Next(6) == 1)
        {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Fire Shard"].type, Main.rand.Next(1, 2), false, 0);
        }
    }
    if (NT == 94)
    {
        if (Main.rand.Next(100) <= 40)
        {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Cursed Flame"].type, Main.rand.Next(1, 2), false, 0);
        }
    }
    if (NT == Config.npcDefs.byName["Ice Skeleton"].type)
    {
        if (Main.hardMode)
        {
            if (Main.rand.Next(2) == 0)
            {
                a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Soul of Ice"].type, 1, false, 0);
            }
        }
    }
    if (NT == Config.npcDefs.byName["White Slime"].type)
    {
        if (Main.hardMode)
        {
            if (Main.rand.Next(2) == 0)
            {
                a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Soul of Ice"].type, 1, false, 0);
            }
        }
    }
    if (NT == 65)
    {
        if (Main.rand.Next(50) == 0)
        {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Diving Suit"].type, 1, false, 0);
        }
        if (Main.rand.Next(40) == 0)
        {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Diving Pants"].type, 1, false, 0);
        }
    }
    if (NT == 69)
    {
        if (Main.rand.Next(100) <= 30)
        {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Antlion Mandible"].type, 1, false, 0);
        }
    }
    /*if (NT == 113)
    {
        if (Main.rand.Next(100) <= 75)
        {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Soul of Fire"].type, Main.rand.Next(4, 8), false, 0);
        }
    }*/
    if (NT == 60)
    {
        if (Main.rand.Next(200) == 1)
        {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Flamelash"].type, 1, false, -1);
        }
    }
    if (NT == 23 || NT == 43 || NT == 49 || NT == 93)
    {
        if (Main.rand.Next(6) == 1)
        {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Earth Shard"].type, 1, false, 0);
        }
    }
    if (NT == 142 || NT == 143 || NT == 144 || NT == 145 || NT == 67 || NT == 102 || NT == 103)
    {
        if (Main.rand.Next(9) == 1)
        {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Ice Shard"].type, Main.rand.Next(1, 2), false, 0);
        }
    }
    if (NT == 61)
    {
        if (Main.rand.Next(1) == 0)
        {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Beak"].type, Main.rand.Next(2) + 1, false, 0);
        }
    }
    if (NT == 24 || NT == 66 || NT == 62 || NT == 60 || NT == 59 || NT == Config.npcDefs.byName["Flame Bat"].type || NT == Config.npcDefs.byName["Blaze"].type || NT == Config.npcDefs.byName["Gargoyle"].type)
    {
	if (Main.hardMode && ModWorld.superHardmode)
	{
            if (Main.rand.Next(20) == 0)
	    {
		a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Soul of Fire"].type, 1, false, 0);
	    }
	}
    }
    if (NT == 75)
    {
        if (Main.rand.Next(100) <= 8)
        {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Crystal Shard"].type, 1, false, 0);
        }
    }
    if (NT == 94)
    {
        if (Main.rand.Next(10) == 1)
        {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Dark Shard"].type, 1, false, 0);
        }
    }
    if (NT == 120)
    {
        if (Main.rand.Next(10) == 1)
        {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Light Shard"].type, 1, false, 0);
        }
    }
    if (NT == 108)
    {
        a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["The Wizard's Hat"].type, 1, false, 0);
    }
    if (NT == 133)
    {
        if (Main.rand.Next(3) == 1) {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Lens"].type, 1, false, 0);
        }
        if (Main.rand.Next(50) == 1) {
            a = Item.NewItem((int)NV.X, (int)NV.Y, 16, 16, Config.itemDefs.byName["Black Lens"].type, 1, false, 0);
        }
    }
    if (Main.netMode == 0) {
        if (NT == Config.npcDefs.byName["Desert Beak"].type)
            Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_BOSS_BEAK", null});
        if (NT == Config.npcDefs.byName["King Sting"].type)
            Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_BOSS_STING", null});
        if (NT == Config.npcDefs.byName["Armageddon Slime"].type)
            Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_BOSS_SLIME", null});
        if (NT == Config.npcDefs.byName["Mechasting"].type)
            Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_BOSS_MECHASTING", null});
        if (NT == Config.npcDefs.byName["Steelfang"].type)
            Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_BOSS_STEELFANG", null});
        if (NT == Config.npcDefs.byName["Cataryst"].type)
            Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_BOSS_CATARYST", null});
        if (NT == Config.npcDefs.byName["Juggernaut"].type)
            Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_SHM_JUGGERNAUT", null});
        if (NT == Config.npcDefs.byName["Dragon Lord Head"].type)
            Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_SHM_BOSS_DRAGON", null});
        if (NT == Config.npcDefs.byName["Oblivion Head 1"].type)
            Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_SHM_BOSS_OBLIVION", null});
	if (NT == Config.npcDefs.byName["Ultrablivion Head"].type)
            Codable.RunGlobalMethod("ModPlayer", "ExternalAchieve", new object[] {"AVALON_SHM_BOSS_UO", null});
    }
    else {
        if (NT == Config.npcDefs.byName["Desert Beak"].type)
            Codable.RunGlobalMethod("ModPlayer", "ExternalAchieveAllPlayers", new object[] {"AVALON_BOSS_BEAK"});
        if (NT == Config.npcDefs.byName["King Sting"].type)
            Codable.RunGlobalMethod("ModPlayer", "ExternalAchieveAllPlayers", new object[] {"AVALON_BOSS_STING"});
        if (NT == Config.npcDefs.byName["Armageddon Slime"].type)
            Codable.RunGlobalMethod("ModPlayer", "ExternalAchieveAllPlayers", new object[] {"AVALON_BOSS_SLIME"});
        if (NT == Config.npcDefs.byName["Mechasting"].type)
            Codable.RunGlobalMethod("ModPlayer", "ExternalAchieveAllPlayers", new object[] {"AVALON_BOSS_MECHASTING"});
        if (NT == Config.npcDefs.byName["Steelfang"].type)
            Codable.RunGlobalMethod("ModPlayer", "ExternalAchieveAllPlayers", new object[] {"AVALON_BOSS_STEELFANG"});
        if (NT == Config.npcDefs.byName["Cataryst"].type)
            Codable.RunGlobalMethod("ModPlayer", "ExternalAchieveAllPlayers", new object[] {"AVALON_BOSS_CATARYST"});
        if (NT == Config.npcDefs.byName["Juggernaut"].type)
            Codable.RunGlobalMethod("ModPlayer", "ExternalAchievePlayer", new object[] {npc.target, "AVALON_SHM_JUGGERNAUT"});
        if (NT == Config.npcDefs.byName["Dragon Lord Head"].type)
            Codable.RunGlobalMethod("ModPlayer", "ExternalAchieveAllPlayers", new object[] {"AVALON_SHM_BOSS_DRAGON"});
        if (NT == Config.npcDefs.byName["Oblivion Head 1"].type)
            Codable.RunGlobalMethod("ModPlayer", "ExternalAchieveAllPlayers", new object[] {"AVALON_SHM_BOSS_OBLIVION"});
	if (NT == Config.npcDefs.byName["Ultrablivion Head"].type)
            Codable.RunGlobalMethod("ModPlayer", "ExternalAchieveAllPlayers", new object[] {"AVALON_SHM_BOSS_UO"});
    }
    for (int i = 0; i < N.buffType.Length; i++)
    {
	if(N.buffType[i] == Config.buffID["Wealth"])
	{
	    N.value *= 2;
	    N.DelBuff(i);
	    i=0;
	}
    }
}

// --------------------------------------------------------------------
    #region PreAI() : bool
    public bool PreAI()
    {
        return PoisonS(npc);
    }
    #endregion
    // --------------------------------------------------------------------
    #region PoisonS(NPC) : bool
    public bool PoisonS(NPC N)
    {
	if (N.noTileCollide || N.friendly) return true;
        int[] I = new int[] { Config.tileDefs.ID["Poison Spikes"] };
        if (ModPlayer.DetectTileCollision(N.position, N.width, N.height, 1, I))
	{
		N.StrikeNPC(30, 0f, 0);
		N.AddBuff(20, 540);
	}
	return true;
    }
    #endregion
    // --------------------------------------------------------------------