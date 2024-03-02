public static int starveTimer;
public static int ValueOne = 1; //Raw Rabbit
public static int ValueTwo = 2; //Raw Porkchop
public static int ValueThree = 3; //Vile Mushroom, Mushroom, Raw Beef
public static int ValueFour = 4;
public static int ValueFive = 5; //Glowing Mushroom, Apple, Sugar
public static int ValueSix = 6; //Ale
public static int ValueSeven = 7; //Milk, Goldfish
public static int ValueEight = 8;
public static int ValueNine = 9; //Cooked Rabbit
public static int ValueTen = 10; //Pot of Honey
public static int ValueEleven = 11;//Apple Cider
public static int ValueTwelve = 12; //Beer
public static int ValueThirteen = 13; //Cooked Porkchop, Pure Chocolate Bar
public static int ValueFourteen = 14; //Steak, Milk Chocolate Bar
public static int ValueFifteen = 15; //Bowl of Soup, Apple Crumble Pie
public static int ValueSixteen = 16;
public static int ValueSeventeen = 17;
public static int ValueEightteen = 18;
public static int ValueNineteen = 19;
public static int ValueTwenty = 20; //Cheese
public static int ValueTwentyone = 21;
public static int ValueTwentytwo = 22;
public static int ValueTwentythree = 23;
public static int ValueTwentyfour = 24;
public static int ValueTwentyfive = 25; //Chocolate Pie
public static float Hunger = 100;
public static float ReductionMultiplier = 1;
public static bool piglet = false;
public static bool hasPet = false;
public static NPC pet = null;
//public static string pigCode = "";
public static bool AppleQuest;
public static bool sellAppleCider;
public static int AppleCount = 0;
public static int AppleNeeded = 0;

public void Load(BinaryReader R) 
{
    ModPlayer.Hunger = R.ReadSingle();
	ModPlayer.AppleQuest = R.ReadBoolean();
	ModPlayer.AppleCount = R.ReadInt32();
	ModPlayer.AppleNeeded = R.ReadInt32();
	ModPlayer.sellAppleCider = R.ReadBoolean();
	/*ModPlayer.piglet = R.ReadBoolean();
	ModPlayer.hasPet = R.ReadBoolean();*/
}

public void Initialize(){
//	pigCode = Settings.GetString("pigCode");
	AppleQuest = false;
	sellAppleCider = false;
}

public void PreUpdatePlayer(Player player){
	if (player.whoAmi == Main.myPlayer){
	if (player.position.X != player.oldPosition.X && (player.controlLeft||player.controlRight)){
	if (Hunger > 0) Hunger -= 0.0015f * ReductionMultiplier; //0.0015f (18 Min)
	}
	if (Hunger < 0) Hunger = 0;
	if (Hunger > 100) Hunger = 100;
	
	if ((int) Hunger >= 81){
		player.AddBuff (26, 600);
		player.magicDamage -= 0.05f;
		player.rangedDamage += 0.05f;
	}
	else{
		for(int num36 = 0; num36 < 10; num36++)
		{
			if (player.buffType[num36] == 26)
			{
			player.buffType[num36] = 0;
			player.buffTime[num36] = 0;
			break;
			}
		}
	}
	
	if ((int) Hunger <= 19)
	{
		player.AddBuff (33, 600);
		player.bleed = true;
	}
	else
	{
		for(int num36 = 0; num36 < 10; num36++)
		{
			if (player.buffType[num36] == 33)
			{
			player.buffType[num36] = 0;
			player.buffTime[num36] = 0;
			break;
			}
		}
	}
	
	if ((int) ModPlayer.Hunger == 0)
	{
		starveTimer++;
		if (starveTimer >= 20)
		{
			//if(!ModWorld.Winter){
				player.statLife -= (int) Math.Round(1f*(player.statLifeMax/100f));
				starveTimer = 0;
				if (player.statLife <= 0) player.Hurt(1, 0, false, true, " starved to death...", false);
			//}
			/*else{
				player.statLife -= (int) Math.Round(3f*(player.statLifeMax/100f));
				starveTimer = 0;
				if (player.statLife <= 0) player.Hurt(1, 0, false, true, " starved to death...", false);
			}*/
		}
	}
	else starveTimer = 0;
	
	ReductionMultiplier = 1;
	/*-----------------------------*/
			ValueOne = 1;
			ValueTwo = 2;
			ValueThree = 3;
			ValueFour = 4;
			ValueFive = 5;
			ValueSix = 6;
			ValueSeven = 7;
			ValueEight = 8;
			ValueNine = 9;
			ValueTen = 10;
			ValueEleven = 11;
			ValueTwelve = 12;
			ValueThirteen = 13;
			ValueFourteen = 14;
			ValueFifteen = 15;
			ValueSixteen = 16;
			ValueSeventeen = 17;
			ValueEightteen = 18;
			ValueNineteen = 19;
			ValueTwenty = 20;
			ValueTwentyone = 21;
			ValueTwentytwo = 22;
			ValueTwentythree = 23;
			ValueTwentyfour = 24;
			ValueTwentyfive = 25;
	}
}
//initialize

public void Save(BinaryWriter W) 
{
    W.Write(ModPlayer.Hunger);
	W.Write(ModPlayer.sellAppleCider);
	W.Write(ModPlayer.AppleCount);
	W.Write(ModPlayer.AppleNeeded);
	W.Write(ModPlayer.AppleQuest);
	/*W.Write(ModPlayer.piglet);
	W.Write(ModPlayer.hasPet);*/
}