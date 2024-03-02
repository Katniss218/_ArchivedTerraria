public void Initialize(){
	Main.itemTexture[31] = Main.goreTexture[Config.goreID["Item_31"]];
	Main.itemTexture[126] = Main.goreTexture[Config.goreID["Item_126"]];
}

public void PreDrawInterface(SpriteBatch SP)
{
	if (Main.player[Main.myPlayer].dead && !Main.player[Main.myPlayer].pvpDeath) ModPlayer.Hunger = 100;
	SP.Draw(Main.goreTexture[Config.goreID["Apple Icon 1"]],
	new Vector2(Main.screenWidth-45, 90), // 
	new Rectangle?(new Rectangle(0, 0, 162, 18)),
	Color.Black, //Keep this white
	0.0f, //Angle
	new Vector2(162, 0),//Center point, for an NPC it should be 0,0
	2f*Main.inventoryScale, //Scale
	SpriteEffects.None,
	0f);
	
	int Sprite = Config.goreID["Apple Icon 1"];
	if ((int)ModPlayer.Hunger <= 95 && (int)ModPlayer.Hunger > 90) Sprite = Config.goreID["Apple Icon 2"];
	if ((int)ModPlayer.Hunger <= 90 && (int)ModPlayer.Hunger > 85) Sprite = Config.goreID["Apple Icon 3"];
	if ((int)ModPlayer.Hunger <= 85 && (int)ModPlayer.Hunger > 80) Sprite = Config.goreID["Apple Icon 4"];
	if ((int)ModPlayer.Hunger <= 80 && (int)ModPlayer.Hunger > 75) Sprite = Config.goreID["Apple Icon 5"];
	if ((int)ModPlayer.Hunger <= 75 && (int)ModPlayer.Hunger > 70) Sprite = Config.goreID["Apple Icon 6"];
	if ((int)ModPlayer.Hunger <= 70 && (int)ModPlayer.Hunger > 65) Sprite = Config.goreID["Apple Icon 7"];
	if ((int)ModPlayer.Hunger <= 65 && (int)ModPlayer.Hunger > 60) Sprite = Config.goreID["Apple Icon 8"];
	if ((int)ModPlayer.Hunger <= 60 && (int)ModPlayer.Hunger > 55) Sprite = Config.goreID["Apple Icon 9"];
	if ((int)ModPlayer.Hunger <= 55 && (int)ModPlayer.Hunger > 50) Sprite = Config.goreID["Apple Icon 10"];
	if ((int)ModPlayer.Hunger <= 50 && (int)ModPlayer.Hunger > 45) Sprite = Config.goreID["Apple Icon 11"];
	if ((int)ModPlayer.Hunger <= 45 && (int)ModPlayer.Hunger > 40) Sprite = Config.goreID["Apple Icon 12"];
	if ((int)ModPlayer.Hunger <= 40 && (int)ModPlayer.Hunger > 35) Sprite = Config.goreID["Apple Icon 13"];
	if ((int)ModPlayer.Hunger <= 35 && (int)ModPlayer.Hunger > 30) Sprite = Config.goreID["Apple Icon 14"];
	if ((int)ModPlayer.Hunger <= 30 && (int)ModPlayer.Hunger > 25) Sprite = Config.goreID["Apple Icon 15"];
	if ((int)ModPlayer.Hunger <= 25 && (int)ModPlayer.Hunger > 20) Sprite = Config.goreID["Apple Icon 16"];
	if ((int)ModPlayer.Hunger <= 20 && (int)ModPlayer.Hunger > 15) Sprite = Config.goreID["Apple Icon 17"];
	if ((int)ModPlayer.Hunger <= 15 && (int)ModPlayer.Hunger > 10) Sprite = Config.goreID["Apple Icon 18"];
	if ((int)ModPlayer.Hunger <= 10 && (int)ModPlayer.Hunger > 5) Sprite = Config.goreID["Apple Icon 19"];
	if ((int)ModPlayer.Hunger <= 5 && (int)ModPlayer.Hunger > 0) Sprite = Config.goreID["Apple Icon 20"];
	if ((int)ModPlayer.Hunger == 0) Sprite = Config.goreID["Apple Icon 21"];
	SP.Draw(Main.goreTexture[Sprite],
	new Vector2(Main.screenWidth-45, 90), // 
	new Rectangle?(new Rectangle(0, 0, 162, 18)),
	Color.White, //Keep this white
	0.0f, //Angle
	new Vector2(162, 0),//Center point, for an NPC it should be 0,0
	2f*Main.inventoryScale, //Scale
	SpriteEffects.None,
	0f);
	
	if (Main.mouseX < Main.screenWidth-45 && Main.mouseX > Main.screenWidth-45-(162*Main.inventoryScale*2) && Main.mouseY > 90 && Main.mouseY < 90+(18*Main.inventoryScale*2)) Config.mainInstance.MouseText("Food: "+((int)ModPlayer.Hunger)+"/100");
}

public  void KillTile(int x, int y, Player player) 
{
	int index = -1;
	
	if(Main.rand.Next(10) < 3)//there is a 20% chance that
	{
		if ( (int)Main.tile[x,y].type == 5 && ((int)Main.tile[x,y+1].type != 5) && player != null)//if a player chops down a tree
		{
			if(!player.zoneEvil && !player.zoneJungle)//and isnt in the corruption or the jungle
				index=Item.NewItem(x * 16, y * 16, 16, 18, "Apple");//an apple falls out
				if(ModPlayer.AppleQuest){
					if(ModPlayer.AppleCount < ModPlayer.AppleNeeded){
						ModPlayer.AppleCount += 1;
						Main.NewText("[Quest] My cider brings all the boys to the yard: "+ModPlayer.AppleCount+"/"+ModPlayer.AppleNeeded+" apples collected.");
					}
				}
			else if(player.zoneJungle)//and is in the jungle
				index=Item.NewItem(x * 16, y * 16, 16, 18, "Cacao Beans");//a cacao bean falls out
				
			if(Main.netMode == 1)
			{
				NetMessage.SendData(21, -1, -1, "", index, 0f, 0f, 0f, 0);
			}
		}
	}
}