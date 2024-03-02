float customAi1;

#region Spawn
public static bool SpawnNPC(int x, int y, int playerID)
{
	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["Attraidies"].type)
	{
	return false;
	}
	
	bool nospecialbiome = !Main.player[playerID].zoneJungle && !Main.player[playerID].zoneEvil && !Main.player[playerID].zoneHoly && !Main.player[playerID].zoneMeteor && !Main.player[playerID].zoneDungeon; // Not necessary at all to use but needed to make all this work.

	bool sky = nospecialbiome && ((double)y < Main.worldSurface * 0.44999998807907104);
	bool surface = nospecialbiome && !sky && (y <= Main.worldSurface);
	bool underground = nospecialbiome && !surface && (y <= Main.rockLayer);
	bool underworld= (y > Main.maxTilesY-190);
	bool cavern = nospecialbiome && (y >= Main.rockLayer) && (y <= Main.rockLayer *25);
	bool undergroundJungle = (y >= Main.rockLayer) && (y <= Main.rockLayer *25) && Main.player[playerID].zoneJungle;
	bool undergroundEvil = (y >= Main.rockLayer) && (y <= Main.rockLayer *25) && Main.player[playerID].zoneEvil;
	bool undergroundHoly = (y >= Main.rockLayer) && (y <= Main.rockLayer *25) && Main.player[playerID].zoneHoly;
	if (Main.hardMode && Main.bloodMoon && surface && !ModWorld.superHardmode)
	{
	if (Main.rand.Next(38500)==0)
	{
	return true;
	}
	}
	}
	return false;
}
#endregion

#region Debuffs
public void DamagePlayer(Player player, ref int damage) //hook works!
{

	if (Main.rand.Next(2) == 0)
	{
        player.AddBuff("Fracturing Armor", 3600, false); //fracturing armor up to 30
	}

	if (Main.rand.Next(4) == 0)
	{
		player.AddBuff(36, 1200, false); //broken armor
        player.AddBuff(30, 1200, false); //bleeding     
	}
    
}
#endregion

#region AI
public void AI()
{
 
        npc.netUpdate = false;
        npc.ai[0]++; // Timer Scythe
        npc.ai[1]++; // Timer Teleport
        // npc.ai[2]++; // Shots
 
        if (npc.life > 6000)
        {
                int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 6, npc.velocity.X, npc.velocity.Y, 200, Color.Red, 1f);
                Main.dust[dust].noGravity = true;
        }
        else if (npc.life <= 6000)
        {
                int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, npc.velocity.X, npc.velocity.Y, 140, Color.Red,2f);
                Main.dust[dust].noGravity = true;
        }
 
        if (Main.netMode != 2)
        {
                if (npc.ai[0] >= 12 && npc.ai[2] < 5)
                {
                        float num48 = 0.5f;
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
                        int damage = 50;
                        int type = Config.projectileID["Shadow Orb"];
                        float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), type, damage, 0f, 0);
                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 20);
                        npc.ai[0] = 0;
                        npc.ai[2]++;
                }

				

        }
 
        if (npc.ai[1] >= 30)
        {
                npc.velocity.X *= 0.17f;
                npc.velocity.Y *= 0.17f;
        }
 
        if ((npc.ai[1] >= 200 && npc.life > 6000) || (npc.ai[1] >= 120 && npc.life <= 6000))
        {
                Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 8);
                for (int num36 = 0; num36 < 10; num36++)
                {
                        int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, npc.velocity.X+Main.rand.Next(-10,10), npc.velocity.Y+Main.rand.Next(-10,10), 200, Color.Red, 4f);
                        Main.dust[dust].noGravity = false;
                }
                npc.ai[3] = (float) (Main.rand.Next(360)*(Math.PI/180));
                npc.ai[2] = 0;
                npc.ai[1] = 0;
                if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
                {
                        npc.TargetClosest(true);
                }
                if (Main.player[npc.target].dead)
                {
                        npc.position.X = 0;
                        npc.position.Y = 0;
                        if (npc.timeLeft > 10)
                        {
                                npc.timeLeft = 0;
                                return;
                        }
                }
                else
                {





Player Pt = Main.player[npc.target];
        Vector2 NC = npc.position+new Vector2(npc.width/2,npc.height/2);
        Vector2 PtC = Pt.position+new Vector2(Pt.width/2,Pt.height/2);
        npc.position.X = Pt.position.X + (float) ((600* Math.Cos(npc.ai[3]))*-1);
        npc.position.Y = Pt.position.Y-35 + (float) ((30* Math.Sin(npc.ai[3]))*-1);

        float MinDIST = 310f;
        float MaxDIST = 400f;
        Vector2 Diff = npc.position-Pt.position;
        if(Diff.Length() > MaxDIST) 
        {
            Diff *= MaxDIST/Diff.Length();
        }
        if(Diff.Length() < MinDIST) 
        {
            Diff *= MinDIST/Diff.Length();
        }
        npc.position = Pt.position + Diff;

        NC = npc.position+new Vector2(npc.width/2,npc.height/2);

        float rotation = (float) Math.Atan2(NC.Y-PtC.Y, NC.X-PtC.X);
        npc.velocity.X = (float) (Math.Cos(rotation) * 8)*-1;
        npc.velocity.Y = (float) (Math.Sin(rotation) * 8)*-1;


                }
        }






                      
       
        //end of W1k's Death code
 
        //beginning of Omnir's Ultima Weapon projectile code
         
        npc.ai[3]++; 
 
        if (npc.ai[3] >= 45) //how often the crystal attack can happen in frames per second
        {







                if (Main.rand.Next(2)==0) //1 in 2 chance boss will use attack when it flies down on top of you
                {
                   float num48 = 8f;
                   Vector2 vector9 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y-520 + (npc.height / 2));
                   float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector9.X) + Main.rand.Next(-20, 0x15);
                   float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector9.Y) + Main.rand.Next(-20, 0x15);
                   if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
                   {
                           float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
                           num51 = num48 / num51;
                           speedX *= num51;
                           speedY *= num51;
                           int damage = 120;//(int) (14f * npc.scale);
                           int type = Config.projectileID["Massive Crystal Shards Spell"];//44;//0x37; //14;
                           int num54 = Projectile.NewProjectile(vector9.X, vector9.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
                           Main.projectile[num54].timeLeft = 100;
                           Main.projectile[num54].aiStyle=4;
                           Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 25);
                           npc.ai[3] = 0;;
                   }
                }




				if (Main.rand.Next(20)==0) //1 in 20 chance boss will summon an NPC
              			  {
					int Random = Main.rand.Next(100);
					int Paraspawn = 0;
				if (Random == 0) Paraspawn = NPC.NewNPC((int) Main.player[this.npc.target].position.X-206-this.npc.width/2, (int) Main.player[this.npc.target].position.Y-16-this.npc.width/2, "Chaos Elemental", 0);

				if (Random == 10) Paraspawn = NPC.NewNPC((int) Main.player[this.npc.target].position.X+500-this.npc.width/2, (int) Main.player[this.npc.target].position.Y-500-this.npc.width/2, "Mindflayer Illusion", 0);


				if (Random == 0) Paraspawn = NPC.NewNPC((int) Main.player[this.npc.target].position.X+206-this.npc.width/2, (int) Main.player[this.npc.target].position.Y-16-this.npc.width/2, "Chaos Elemental", 0);

				Main.npc[Paraspawn].velocity.X = npc.velocity.X;
				npc.active = true;

					}






if (Main.rand.Next(70)==0) //1 in 25 chance boss will summon an NPC
              			  {
					int Random = Main.rand.Next(200);
					int Paraspawn = 0;
			

				if (Random == 50) Paraspawn = NPC.NewNPC((int) Main.player[this.npc.target].position.X+500-this.npc.width/2, (int) Main.player[this.npc.target].position.Y-500-this.npc.width/2, "Attraidies Mimic", 0);
				

				Main.npc[Paraspawn].velocity.X = npc.velocity.X;
				npc.active = true;

					}


if (Main.rand.Next(80)==0) //1 in 60 chance boss will summon an NPC
              			  {
					int Random = Main.rand.Next(200);
					int Paraspawn = 0;
			

				if (Random == 5) Paraspawn = NPC.NewNPC((int) Main.player[this.npc.target].position.X+500-this.npc.width/2, (int) Main.player[this.npc.target].position.Y-500-this.npc.width/2, "Disciple of Attraidies", 0);

				

				Main.npc[Paraspawn].velocity.X = npc.velocity.X;
				npc.active = true;

					}






        }
 
        npc.ai[3] += 1; // my attempt at adding the timer that switches back to the shadow orb
        if (npc.ai[3] >= 700)
        {
                if (npc.ai[1] == 0) npc.ai[1] = 1;
                else npc.ai[1] = 0;
        }


				if (Main.rand.Next(100)==1)
                {
			        float num48 = 10f;
			        Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
			        float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
			        float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
			        if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
                    {
			            float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
		                num51 = num48 / num51;
			            speedX *= num51;
			            speedY *= num51;
			            int damage = 120;//(int) (14f * npc.scale);
			            int type = Config.projectileID["Enemy Spell Sudden Death Ball"];//44;//0x37; //14;
			            int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
                        Main.projectile[num54].timeLeft = 6;
			            Main.projectile[num54].aiStyle=1;
                            Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
                        customAi1 = 1f;
                    }
                    npc.netUpdate=true;
                }


if (Main.player[npc.target].dead)
	{
	npc.velocity.Y -= 0.04f;
	if (npc.timeLeft > 10)
	{
		npc.timeLeft = 0;
		return;
	}
	}



	





}
 
#endregion

#region FindFrame
public void FindFrame(int currentFrame)
{

if ((npc.velocity.X > -9 && npc.velocity.X < 9) && (npc.velocity.Y > -9 && npc.velocity.Y < 9))
{
    npc.frameCounter = 0;
    npc.frame.Y = 0;
    if (npc.position.X > Main.player[npc.target].position.X)
    {
        npc.spriteDirection = -1;
    }
    else
    {
        npc.spriteDirection = 1;
    }
}

	int num = 1;
	if (!Main.dedServ)
	{
		num = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
	}
	if ((npc.velocity.X > -2 && npc.velocity.X < 2) && (npc.velocity.Y > -2 && npc.velocity.Y < 2))
	{
	npc.frameCounter = 0;
	npc.frame.Y = 0;
	}
	else
	{
	npc.frameCounter += 1.0;
	}
	if (npc.frameCounter >= 1.0)
	{
		npc.frame.Y = npc.frame.Y + num;
		npc.frameCounter = 0.0;
	}
	if (npc.frame.Y >= num * Main.npcFrameCount[npc.type])
	{
		npc.frame.Y = 0;
	}
}
#endregion

#region Gore
public void NPCLoot()
{

if (npc.life <= 0){
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Mindflayer Gore 1", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Mindflayer Gore 2", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Mindflayer Gore 3", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Mindflayer Gore 2", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Mindflayer Gore 3", 1f, -1);
		  }

	ModWorld.attraidies++;
	
	ModWorld.Attraidies();
			
}
#endregion