public static bool TownSpawn()
{
    if(ModWorld.PlacedMyHolyTombstone)
    {
        return true;
    }
      return false;
}


public static string SetName() {
    int x = Main.rand.Next(4);
    if(x==0){   return "Jackson"; }
    if(x==1){   return "Max";    }
    if(x==2){   return "Jack"; }
    if(x==3){   return "Frederick";  }
return "test";
}

public void Initialize(){
	//npc.name="Gravedigger";
}

public static string Chat() {
    int x=Main.rand.Next(4);
    if(x==0){   return "I have blocks, many blocks.";   }
    if(x==1){   return "It is a pretty grave.";  }
    if(x==2){   return "Death is just the beginning.";  }
    if(x==3){   return "I'll sell you mine spoil.";  }
return "test";
}

public static void SetupShop(Chest chest) {
	int index=0;
	chest.item[index].SetDefaults("Dirt Block");
	chest.item[index].value = 10;
	index++;
	chest.item[index].SetDefaults("Stone Block");
	chest.item[index].value = 25;
	index++;
	chest.item[index].SetDefaults("Mud Block");
	chest.item[index].value = 10;
	index++;
	chest.item[index].SetDefaults("Clay Block");
	chest.item[index].value = 40;
	index++;
	chest.item[index].SetDefaults("Sand Block");
	chest.item[index].value = 45;
	index++;
	chest.item[index].SetDefaults("Silt Block");
	chest.item[index].value = 10;
	index++;
	chest.item[index].SetDefaults("Tombstone");
	chest.item[index].value = 800;
	index++;
}
