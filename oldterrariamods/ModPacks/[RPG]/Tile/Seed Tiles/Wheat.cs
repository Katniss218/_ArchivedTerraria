int tileX;
int tileY;
int tickehs;
int tickehsNeeded3 = 36000; //10 minutes
int tickehsNeeded2 = 13000; //5 minutes
int tickehsNeeded = 6500; //2,5 minutes
	static int ticksn = 600;
	static int tickshere;
	
public void Initialize(int x, int y){
	tileX = x;
	tileY = y;
	tickshere = 0;
}

public void UseTile(Player player, int x, int y){
	if(Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type == Config.itemDefs.byName["Bone Meal"].type){
		if(Main.tile[x, y].type == (byte)Config.tileDefs.ID["Wheat"]){
				if(Main.rand.Next(3)==1){
					Main.tile[x, y].type = (byte)Config.tileDefs.ID["Wheat2"];
					tickehs = 0;
					Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].stack -= 1;
				}
		}
		if(Main.tile[x, y].type == (byte)Config.tileDefs.ID["Wheat2"]){
				if(Main.rand.Next(3)==1){
					Main.tile[x, y].type = (byte)Config.tileDefs.ID["Wheat3"];
					tickehs = 0;
					Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].stack -= 1;
				}
		}
	}
}

public void Update(){
	int x = tileX;
	int y = tileY;
	bool breakthis;
		tickshere ++;
	if(Main.tile[x, y].type == (byte)Config.tileDefs.ID["Wheat"]){
		if(tickehs == tickehsNeeded){
			if(Main.rand.Next(6)==1){
				Main.tile[x, y].type = (byte)Config.tileDefs.ID["Wheat2"];
				tickehs = 0;
			}
		}
		if(tickehs == tickehsNeeded2){
			if(Main.rand.Next(3)==1){
				Main.tile[x, y].type = (byte)Config.tileDefs.ID["Wheat2"];
				tickehs = 0;
			}
		}
		if(tickehs == tickehsNeeded3){
			Main.tile[x, y].type = (byte)Config.tileDefs.ID["Wheat2"];
			tickehs = 0;
		}
		else{
			tickehs ++;
		}
	}
	else if(Main.tile[x, y].type == (byte)Config.tileDefs.ID["Wheat2"]){
		if(tickehs == tickehsNeeded){
			if(Main.rand.Next(6)==1){
				Main.tile[x, y].type = (byte)Config.tileDefs.ID["Wheat3"];
				tickehs = 0;
			}
		}
		if(tickehs == tickehsNeeded2){
			if(Main.rand.Next(3)==1){
				Main.tile[x, y].type = (byte)Config.tileDefs.ID["Wheat3"];
				tickehs = 0;
			}
		}
		if(tickehs == tickehsNeeded3){
			Main.tile[x, y].type = (byte)Config.tileDefs.ID["Wheat3"];
			tickehs = 0;
		}
		else{
			tickehs ++;
		}
	}
	if (Main.tile[x, y+1].type != 109 && Main.tile[x, y+1].type != 2){
		breakthis = true;
	}
	else{
		breakthis = false;
	}
	if(breakthis){
		WorldGen.KillTile(x, y, false, false, false);
	}
}

public static void KillTile(int x, int y, Player player){
	int index = 0;
	if(Main.tile[x, y].type == (byte)Config.tileDefs.ID["Wheat"]){
		if(tickshere < ticksn){
			index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Wheat Seeds"].type);
			tickshere = 0;
		}
	}
	if(Main.tile[x, y].type == (byte)Config.tileDefs.ID["Wheat3"]){
	index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Wheat"].type);
	if(Main.rand.Next(2)==1){
		index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Wheat"].type);
	}
	if(Main.rand.Next(4)==1){
		index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Wheat"].type);
		index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Wheat Seeds"].type);
	}
	if(Main.rand.Next(8)==1){
		index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Wheat"].type);
	}
	if(Main.rand.Next(16)==1){
		index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Wheat"].type);
		index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Wheat Seeds"].type);
	}
	if(Main.rand.Next(32)==1){
		index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Wheat"].type);
	}
	if(Main.rand.Next(64)==1){
		index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Wheat"].type);
		index = Item.NewItem(x * 16, y * 16 - 10, 16, 16, (int)Config.itemDefs.byName["Wheat Seeds"].type);
	}
	}
}

public void Load(BinaryReader R){
	try{
		tickehs = R.ReadInt32();
	}
	catch{
	}
}
public void Save(BinaryWriter W){
	W.Write(tickehs);
}

	/*	public static void CheckAlch(int x, int y)
		{
			if (Main.tile[x, y] == null)
			{
				Main.tile[x, y] = new Tile();
			}
			if (Main.tile[x, y + 1] == null)
			{
				Main.tile[x, y + 1] = new Tile();
			}
			bool flag = false;
			if (!Main.tile[x, y + 1].active)
			{
				flag = true;
			}
			int num = (int)(Main.tile[x, y].frameX / 18);
			Main.tile[x, y].frameY = 0;
			if (!flag)
			{
				if (num == 0)
				{
					if (Main.tile[x, y + 1].type != 109 && Main.tile[x, y + 1].type != 2 && Main.tile[x, y + 1].type != 78)
					{
						flag = true;
					}
					if (Main.tile[x, y].liquid > 0 && Main.tile[x, y].lava)
					{
						flag = true;
					}
				}
				else
				{
					if (num == 1)
					{
						if (Main.tile[x, y + 1].type != 60 && Main.tile[x, y + 1].type != 78)
						{
							flag = true;
						}
						if (Main.tile[x, y].liquid > 0 && Main.tile[x, y].lava)
						{
							flag = true;
						}
					}
					else
					{
						if (num == 2)
						{
							if (Main.tile[x, y + 1].type != 0 && Main.tile[x, y + 1].type != 59 && Main.tile[x, y + 1].type != 78)
							{
								flag = true;
							}
							if (Main.tile[x, y].liquid > 0 && Main.tile[x, y].lava)
							{
								flag = true;
							}
						}
						else
						{
							if (num == 3)
							{
								if (Main.tile[x, y + 1].type != 23 && Main.tile[x, y + 1].type != 25 && Main.tile[x, y + 1].type != 78)
								{
									flag = true;
								}
								if (Main.tile[x, y].liquid > 0 && Main.tile[x, y].lava)
								{
									flag = true;
								}
							}
							else
							{
								if (num == 4)
								{
									if (Main.tile[x, y + 1].type != 53 && Main.tile[x, y + 1].type != 78 && Main.tile[x, y + 1].type != 116)
									{
										flag = true;
									}
									if (Main.tile[x, y].liquid > 0 && Main.tile[x, y].lava)
									{
										flag = true;
									}
									if (Main.tile[x, y].type != 82 && !Main.tile[x, y].lava && Main.netMode != 1)
									{
										if (Main.tile[x, y].liquid > 16)
										{
											if (Main.tile[x, y].type == 83)
											{
												Main.tile[x, y].type = 84;
												if (Main.netMode == 2)
												{
													NetMessage.SendTileSquare(-1, x, y, 1);
												}
											}
										}
										else
										{
											if (Main.tile[x, y].type == 84)
											{
												Main.tile[x, y].type = 83;
												if (Main.netMode == 2)
												{
													NetMessage.SendTileSquare(-1, x, y, 1);
												}
											}
										}
									}
								}
								else
								{
									if (num == 5)
									{
										if (Main.tile[x, y + 1].type != 57 && Main.tile[x, y + 1].type != 78)
										{
											flag = true;
										}
										if (Main.tile[x, y].liquid > 0 && !Main.tile[x, y].lava)
										{
											flag = true;
										}
										if (Main.tile[x, y].type != 82 && Main.tile[x, y].lava && Main.tile[x, y].type != 82 && Main.tile[x, y].lava && Main.netMode != 1)
										{
											if (Main.tile[x, y].liquid > 16)
											{
												if (Main.tile[x, y].type == 83)
												{
													Main.tile[x, y].type = 84;
													if (Main.netMode == 2)
													{
														NetMessage.SendTileSquare(-1, x, y, 1);
													}
												}
											}
											else
											{
												if (Main.tile[x, y].type == 84)
												{
													Main.tile[x, y].type = 83;
													if (Main.netMode == 2)
													{
														NetMessage.SendTileSquare(-1, x, y, 1);
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			if (flag)
			{
				WorldGen.KillTile(x, y, false, false, false);
			}
		}*/