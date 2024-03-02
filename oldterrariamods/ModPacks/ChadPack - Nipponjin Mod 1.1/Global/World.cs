public void ModifyWorld()
    {
        foreach (Chest C in Main.chest)
        {
            if (C != null)
            {
                foreach (Item I in C.item)
                {
                    if (I != null && I.type == Config.itemDefs.byName["The Book of Wisdom"].type)
                    {
                        int random8 = WorldGen.genRand.Next(1);
                        if (random8 == 0)
                            I.SetDefaults("The Book of Wisdom");
                        I.Prefix(-1);
                    }
				}
			}
		}
	}