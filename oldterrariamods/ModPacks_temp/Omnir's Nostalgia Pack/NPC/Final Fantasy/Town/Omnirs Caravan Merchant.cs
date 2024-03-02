int townNPCTimer = 0;


#region AI
public void AI()
{
    townNPCTimer++;
    int num129 = (int)(this.npc.position.X + (float)(this.npc.width / 2)) / 16;
    int num130 = (int)(this.npc.position.Y + (float)this.npc.height + 1f) / 16;
    bool flag15 = false;
    this.npc.directionY = -1;
    if (this.npc.direction == 0)
    {
	    this.npc.direction = 1;
    }
    for (int num131 = 0; num131 < 255; num131++)
    {
	    if (Main.player[num131].active && Main.player[num131].talkNPC == this.npc.whoAmI)
	    {
		    flag15 = true;
		    if (this.npc.ai[0] != 0f)
		    {
			    this.npc.netUpdate = true;
		    }
		    this.npc.ai[0] = 0f;
		    this.npc.ai[1] = 300f;
		    this.npc.ai[2] = 100f;
		    if (Main.player[num131].position.X + (float)(Main.player[num131].width / 2) < this.npc.position.X + (float)(this.npc.width / 2))
		    {
			    this.npc.direction = -1;
		    }
		    else
		    {
			    this.npc.direction = 1;
		    }
	    }
    }
    if (this.npc.ai[3] > 0f)
    {
	    this.npc.life = -1;
	    this.npc.HitEffect(0, 10.0);
	    this.npc.active = false;
    }
    int num132 = this.npc.homeTileY;
    if (Main.netMode != 1 && this.npc.homeTileY > 0)
    {
	    while (!WorldGen.SolidTile(this.npc.homeTileX, num132) && num132 < Main.maxTilesY - 20)
	    {
		    num132++;
	    }
    }
    if (Main.netMode != 1 && this.npc.townNPC && (!Main.dayTime || Main.tileDungeon[(int)Main.tile[num129, num130].type]) && (num129 != this.npc.homeTileX || num130 != num132) && !this.npc.homeless)
    {
	    bool flag16 = true;
	    for (int num133 = 0; num133 < 2; num133++)
	    {
		    Rectangle rectangle3 = new Rectangle((int)(this.npc.position.X + (float)(this.npc.width / 2) - (float)(NPC.sWidth / 2) - (float)NPC.safeRangeX), (int)(this.npc.position.Y + (float)(this.npc.height / 2) - (float)(NPC.sHeight / 2) - (float)NPC.safeRangeY), NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
		    if (num133 == 1)
		    {
			    rectangle3 = new Rectangle(this.npc.homeTileX * 16 + 8 - NPC.sWidth / 2 - NPC.safeRangeX, num132 * 16 + 8 - NPC.sHeight / 2 - NPC.safeRangeY, NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
		    }
		    for (int num134 = 0; num134 < 255; num134++)
		    {
			    if (Main.player[num134].active)
			    {
				    Rectangle rectangle4 = new Rectangle((int)Main.player[num134].position.X, (int)Main.player[num134].position.Y, Main.player[num134].width, Main.player[num134].height);
				    if (rectangle4.Intersects(rectangle3))
				    {
					    flag16 = false;
					    break;
				    }
			    }
			    if (!flag16)
			    {
				    break;
			    }
		    }
	    }
	    if (flag16)
	    {
		    if (!Collision.SolidTiles(this.npc.homeTileX - 1, this.npc.homeTileX + 1, num132 - 3, num132 - 1))
		    {
			    this.npc.velocity.X = 0f;
			    this.npc.velocity.Y = 0f;
			    this.npc.position.X = (float)(this.npc.homeTileX * 16 + 8 - this.npc.width / 2);
			    this.npc.position.Y = (float)(num132 * 16 - this.npc.height) - 0.1f;
			    this.npc.netUpdate = true;
		    }
		    else
		    {
			    this.npc.homeless = true;
			    WorldGen.QuickFindHome(this.npc.whoAmI);
		    }
	    }
    }
    if (this.npc.ai[0] == 0f)
    {
	    if (this.npc.ai[2] > 0f)
	    {
		    this.npc.ai[2] -= 1f;
	    }
	    if (!Main.dayTime && !flag15)
	    {
		    if (Main.netMode != 1)
		    {
			    if (num129 == this.npc.homeTileX && num130 == num132)
			    {
				    if (this.npc.velocity.X != 0f)
				    {
					    this.npc.netUpdate = true;
				    }
				    if ((double)this.npc.velocity.X > 0.1)
				    {
					    this.npc.velocity.X = this.npc.velocity.X - 0.1f;
				    }
				    else
				    {
					    if ((double)this.npc.velocity.X < -0.1)
					    {
						    this.npc.velocity.X = this.npc.velocity.X + 0.1f;
					    }
					    else
					    {
						    this.npc.velocity.X = 0f;
					    }
				    }
			    }
			    else
			    {
				    if (!flag15)
				    {
					    if (num129 > this.npc.homeTileX)
					    {
						    this.npc.direction = -1;
					    }
					    else
					    {
						    this.npc.direction = 1;
					    }
					    this.npc.ai[0] = 1f;
					    this.npc.ai[1] = (float)(200 + Main.rand.Next(200));
					    this.npc.ai[2] = 0f;
					    this.npc.netUpdate = true;
				    }
			    }
		    }
	    }
	    else
	    {
		    if ((double)this.npc.velocity.X > 0.1)
		    {
			    this.npc.velocity.X = this.npc.velocity.X - 0.1f;
		    }
		    else
		    {
			    if ((double)this.npc.velocity.X < -0.1)
			    {
				    this.npc.velocity.X = this.npc.velocity.X + 0.1f;
			    }
			    else
			    {
				    this.npc.velocity.X = 0f;
			    }
		    }
		    if (Main.netMode != 1)
		    {
			    if (this.npc.ai[1] > 0f)
			    {
				    this.npc.ai[1] -= 1f;
			    }
			    if (this.npc.ai[1] <= 0f)
			    {
				    this.npc.ai[0] = 1f;
				    this.npc.ai[1] = (float)(200 + Main.rand.Next(200));
				    this.npc.ai[2] = 0f;
				    this.npc.netUpdate = true;
			    }
		    }
	    }
	    if (Main.netMode != 1 && (Main.dayTime || (num129 == this.npc.homeTileX && num130 == num132)))
	    {
		    if (num129 < this.npc.homeTileX - 25 || num129 > this.npc.homeTileX + 25)
		    {
			    if (this.npc.ai[2] == 0f)
			    {
				    if (num129 < this.npc.homeTileX - 50 && this.npc.direction == -1)
				    {
					    this.npc.direction = 1;
					    this.npc.netUpdate = true;
					    return;
				    }
				    if (num129 > this.npc.homeTileX + 50 && this.npc.direction == 1)
				    {
					    this.npc.direction = -1;
					    this.npc.netUpdate = true;
					    return;
				    }
			    }
		    }
		    else
		    {
			    if (Main.rand.Next(80) == 0 && this.npc.ai[2] == 0f)
			    {
				    this.npc.ai[2] = 200f;
				    this.npc.direction *= -1;
				    this.npc.netUpdate = true;
				    return;
			    }
		    }
	    }
    }
    else
    {
	    if (this.npc.ai[0] == 1f)
	    {
		    if (Main.netMode != 1 && !Main.dayTime && num129 == this.npc.homeTileX && num130 == this.npc.homeTileY)
		    {
			    this.npc.ai[0] = 0f;
			    this.npc.ai[1] = (float)(200 + Main.rand.Next(200));
			    this.npc.ai[2] = 60f;
			    this.npc.netUpdate = true;
			    return;
		    }
		    if (Main.netMode != 1 && !this.npc.homeless && !Main.tileDungeon[(int)Main.tile[num129, num130].type] && (num129 < this.npc.homeTileX - 35 || num129 > this.npc.homeTileX + 35))
		    {
			    if (this.npc.position.X < (float)(this.npc.homeTileX * 16) && this.npc.direction == -1)
			    {
				    this.npc.ai[1] -= 5f;
			    }
			    else
			    {
				    if (this.npc.position.X > (float)(this.npc.homeTileX * 16) && this.npc.direction == 1)
				    {
					    this.npc.ai[1] -= 5f;
				    }
			    }
		    }
		    this.npc.ai[1] -= 1f;
		    if (this.npc.ai[1] <= 0f)
		    {
			    this.npc.ai[0] = 0f;
			    this.npc.ai[1] = (float)(300 + Main.rand.Next(300));
			    this.npc.ai[2] = 60f;
			    this.npc.netUpdate = true;
		    }
		    if (this.npc.closeDoor && ((this.npc.position.X + (float)(this.npc.width / 2)) / 16f > (float)(this.npc.doorX + 2) || (this.npc.position.X + (float)(this.npc.width / 2)) / 16f < (float)(this.npc.doorX - 2)))
		    {
			    bool flag17 = WorldGen.CloseDoor(this.npc.doorX, this.npc.doorY, false);
			    if (flag17)
			    {
				    this.npc.closeDoor = false;
				    NetMessage.SendData(19, -1, -1, "", 1, (float)this.npc.doorX, (float)this.npc.doorY, (float)this.npc.direction, 0);
			    }
			    if ((this.npc.position.X + (float)(this.npc.width / 2)) / 16f > (float)(this.npc.doorX + 4) || (this.npc.position.X + (float)(this.npc.width / 2)) / 16f < (float)(this.npc.doorX - 4) || (this.npc.position.Y + (float)(this.npc.height / 2)) / 16f > (float)(this.npc.doorY + 4) || (this.npc.position.Y + (float)(this.npc.height / 2)) / 16f < (float)(this.npc.doorY - 4))
			    {
				    this.npc.closeDoor = false;
			    }
		    }
		    if (this.npc.velocity.X < -1f || this.npc.velocity.X > 1f)
		    {
			    if (this.npc.velocity.Y == 0f)
			    {
				    this.npc.velocity *= 0.8f;
			    }
		    }
		    else
		    {
			    if ((double)this.npc.velocity.X < 1.15 && this.npc.direction == 1)
			    {
				    this.npc.velocity.X = this.npc.velocity.X + 0.07f;
				    if (this.npc.velocity.X > 1f)
				    {
					    this.npc.velocity.X = 1f;
				    }
			    }
			    else
			    {
				    if (this.npc.velocity.X > -1f && this.npc.direction == -1)
				    {
					    this.npc.velocity.X = this.npc.velocity.X - 0.07f;
					    if (this.npc.velocity.X > 1f)
					    {
						    this.npc.velocity.X = 1f;
					    }
				    }
			    }
		    }
		    if (this.npc.velocity.Y == 0f)
		    {
			    if (this.npc.position.X == this.npc.ai[2])
			    {
				    this.npc.direction *= -1;
			    }
			    this.npc.ai[2] = -1f;
			    int num135 = (int)((this.npc.position.X + (float)(this.npc.width / 2) + (float)(15 * this.npc.direction)) / 16f);
			    int num136 = (int)((this.npc.position.Y + (float)this.npc.height - 16f) / 16f);
			    if (Main.tile[num135, num136] == null)
			    {
				    Main.tile[num135, num136] = new Tile();
			    }
			    if (Main.tile[num135, num136 - 1] == null)
			    {
				    Main.tile[num135, num136 - 1] = new Tile();
			    }
			    if (Main.tile[num135, num136 - 2] == null)
			    {
				    Main.tile[num135, num136 - 2] = new Tile();
			    }
			    if (Main.tile[num135, num136 - 3] == null)
			    {
				    Main.tile[num135, num136 - 3] = new Tile();
			    }
			    if (Main.tile[num135, num136 + 1] == null)
			    {
				    Main.tile[num135, num136 + 1] = new Tile();
			    }
			    if (Main.tile[num135 + this.npc.direction, num136 - 1] == null)
			    {
				    Main.tile[num135 + this.npc.direction, num136 - 1] = new Tile();
			    }
			    if (Main.tile[num135 + this.npc.direction, num136 + 1] == null)
			    {
				    Main.tile[num135 + this.npc.direction, num136 + 1] = new Tile();
			    }
			    if (this.npc.townNPC && Main.tile[num135, num136 - 2].active && Main.tile[num135, num136 - 2].type == 10 && (Main.rand.Next(10) == 0 || !Main.dayTime))
			    {
				    if (Main.netMode != 1)
				    {
					    bool flag18 = WorldGen.OpenDoor(num135, num136 - 2, this.npc.direction);
					    if (flag18)
					    {
						    this.npc.closeDoor = true;
						    this.npc.doorX = num135;
						    this.npc.doorY = num136 - 2;
						    NetMessage.SendData(19, -1, -1, "", 0, (float)num135, (float)(num136 - 2), (float)this.npc.direction, 0);
						    this.npc.netUpdate = true;
						    this.npc.ai[1] += 80f;
						    return;
					    }
					    if (WorldGen.OpenDoor(num135, num136 - 2, -this.npc.direction))
					    {
						    this.npc.closeDoor = true;
						    this.npc.doorX = num135;
						    this.npc.doorY = num136 - 2;
						    NetMessage.SendData(19, -1, -1, "", 0, (float)num135, (float)(num136 - 2), (float)(-(float)this.npc.direction), 0);
						    this.npc.netUpdate = true;
						    this.npc.ai[1] += 80f;
						    return;
					    }
					    this.npc.direction *= -1;
					    this.npc.netUpdate = true;
					    return;
				    }
			    }
			    else
			    {
				    if ((this.npc.velocity.X < 0f && this.npc.spriteDirection == -1) || (this.npc.velocity.X > 0f && this.npc.spriteDirection == 1))
				    {
					    if (Main.tile[num135, num136 - 2].active && Main.tileSolid[(int)Main.tile[num135, num136 - 2].type] && !Main.tileSolidTop[(int)Main.tile[num135, num136 - 2].type])
					    {
						    if ((this.npc.direction == 1 && !Collision.SolidTiles(num135 - 2, num135 - 1, num136 - 5, num136 - 1)) || (this.npc.direction == -1 && !Collision.SolidTiles(num135 + 1, num135 + 2, num136 - 5, num136 - 1)))
						    {
							    if (!Collision.SolidTiles(num135, num135, num136 - 5, num136 - 3))
							    {
								    this.npc.velocity.Y = -6f;
								    this.npc.netUpdate = true;
							    }
							    else
							    {
								    this.npc.direction *= -1;
								    this.npc.netUpdate = true;
							    }
						    }
						    else
						    {
							    this.npc.direction *= -1;
							    this.npc.netUpdate = true;
						    }
					    }
					    else
					    {
						    if (Main.tile[num135, num136 - 1].active && Main.tileSolid[(int)Main.tile[num135, num136 - 1].type] && !Main.tileSolidTop[(int)Main.tile[num135, num136 - 1].type])
						    {
							    if ((this.npc.direction == 1 && !Collision.SolidTiles(num135 - 2, num135 - 1, num136 - 4, num136 - 1)) || (this.npc.direction == -1 && !Collision.SolidTiles(num135 + 1, num135 + 2, num136 - 4, num136 - 1)))
							    {
								    if (!Collision.SolidTiles(num135, num135, num136 - 4, num136 - 2))
								    {
									    this.npc.velocity.Y = -5f;
									    this.npc.netUpdate = true;
								    }
								    else
								    {
									    this.npc.direction *= -1;
									    this.npc.netUpdate = true;
								    }
							    }
							    else
							    {
								    this.npc.direction *= -1;
								    this.npc.netUpdate = true;
							    }
						    }
						    else
						    {
							    if (Main.tile[num135, num136].active && Main.tileSolid[(int)Main.tile[num135, num136].type] && !Main.tileSolidTop[(int)Main.tile[num135, num136].type])
							    {
								    if ((this.npc.direction == 1 && !Collision.SolidTiles(num135 - 2, num135, num136 - 3, num136 - 1)) || (this.npc.direction == -1 && !Collision.SolidTiles(num135, num135 + 2, num136 - 3, num136 - 1)))
								    {
									    this.npc.velocity.Y = -3.6f;
									    this.npc.netUpdate = true;
								    }
								    else
								    {
									    this.npc.direction *= -1;
									    this.npc.netUpdate = true;
								    }
							    }
						    }
					    }
					    try
					    {
						    if (Main.tile[num135, num136 + 1] == null)
						    {
							    Main.tile[num135, num136 + 1] = new Tile();
						    }
						    if (Main.tile[num135 - this.npc.direction, num136 + 1] == null)
						    {
							    Main.tile[num135 - this.npc.direction, num136 + 1] = new Tile();
						    }
						    if (Main.tile[num135, num136 + 2] == null)
						    {
							    Main.tile[num135, num136 + 2] = new Tile();
						    }
						    if (Main.tile[num135 - this.npc.direction, num136 + 2] == null)
						    {
							    Main.tile[num135 - this.npc.direction, num136 + 2] = new Tile();
						    }
						    if (Main.tile[num135, num136 + 3] == null)
						    {
							    Main.tile[num135, num136 + 3] = new Tile();
						    }
						    if (Main.tile[num135 - this.npc.direction, num136 + 3] == null)
						    {
							    Main.tile[num135 - this.npc.direction, num136 + 3] = new Tile();
						    }
						    if (Main.tile[num135, num136 + 4] == null)
						    {
							    Main.tile[num135, num136 + 4] = new Tile();
						    }
						    if (Main.tile[num135 - this.npc.direction, num136 + 4] == null)
						    {
							    Main.tile[num135 - this.npc.direction, num136 + 4] = new Tile();
						    }
						    else
						    {
							    if (num129 >= this.npc.homeTileX - 35 && num129 <= this.npc.homeTileX + 35 && (!Main.tile[num135, num136 + 1].active || !Main.tileSolid[(int)Main.tile[num135, num136 + 1].type]) && (!Main.tile[num135 - this.npc.direction, num136 + 1].active || !Main.tileSolid[(int)Main.tile[num135 - this.npc.direction, num136 + 1].type]) && (!Main.tile[num135, num136 + 2].active || !Main.tileSolid[(int)Main.tile[num135, num136 + 2].type]) && (!Main.tile[num135 - this.npc.direction, num136 + 2].active || !Main.tileSolid[(int)Main.tile[num135 - this.npc.direction, num136 + 2].type]) && (!Main.tile[num135, num136 + 3].active || !Main.tileSolid[(int)Main.tile[num135, num136 + 3].type]) && (!Main.tile[num135 - this.npc.direction, num136 + 3].active || !Main.tileSolid[(int)Main.tile[num135 - this.npc.direction, num136 + 3].type]) && (!Main.tile[num135, num136 + 4].active || !Main.tileSolid[(int)Main.tile[num135, num136 + 4].type]) && (!Main.tile[num135 - this.npc.direction, num136 + 4].active || !Main.tileSolid[(int)Main.tile[num135 - this.npc.direction, num136 + 4].type]))
							    {
								    this.npc.direction *= -1;
								    this.npc.velocity.X = this.npc.velocity.X * -1f;
								    this.npc.netUpdate = true;
							    }
						    }
					    }
					    catch
					    {
					    }
					    if (this.npc.velocity.Y < 0f)
					    {
						    this.npc.ai[2] = this.npc.position.X;
					    }
				    }
				    if (this.npc.velocity.Y < 0f && this.npc.wet)
				    {
					    this.npc.velocity.Y = this.npc.velocity.Y * 1.2f;
				    }
			    }
		    }
	    }
    }
    if (Main.player[npc.target].dead || townNPCTimer >= 4000)
	{
        npc.townNPC = false;
	    if (npc.timeLeft > 10)
	    {
		    npc.timeLeft = 10;
		    return;
	    }
    }
}
#endregion

#region Names
public static string SetName() 
{
    int x=Main.rand.Next(5);
    if(x==0)
    {
        return "Underhill";
    }
    if(x==1)
    {
        return "Underhill";// >.>
    }
    if(x==2)
    {
        return "Underhill";// >.>
    }
    if(x==3)
    {
        return "Underhill";// >.>
    }
	return "Underhill";//shhhhh
}
#endregion

#region Chat
public static string Chat() 
{
    int x=Main.rand.Next(5);
	if(x==0)
    {
		return "Welcome! Interested in exotic wears?";
    }
    if(x==1)
    {
        return "I have a magic bottle for sale -- interested?";
    }
    if(x==2)
    {
        return "What do you want to buy?";
    }
    if(x==3)
    {
        return "What are ya buyin'!?";
    }
    if(x==4)
    {
        return "What are ya sellin'!? ";
    }
	return "It sure is hot, isn't it?";
}
#endregion

#region Setup Shop
public static void SetupShop(Chest chest) 
{
	int index=0;
	chest.item[index].SetDefaults("Fairy in a Bottle");
	index++;
}
#endregion