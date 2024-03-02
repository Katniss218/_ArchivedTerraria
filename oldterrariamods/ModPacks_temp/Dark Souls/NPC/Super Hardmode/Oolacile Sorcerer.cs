float customAi1;


#region Spawn
public bool SpawnNPC(int x,int y,int PID)
{
      Player P = Main.player[PID]; //this shortens our code up from writing this line over and over.
      bool Meteor = P.zoneMeteor;
      bool Jungle = P.zoneJungle;
      bool Dungeon = P.zoneDungeon;
      bool Corruption = P.zoneEvil;
      bool Hallow = P.zoneHoly;
      bool AboveEarth  = P.position.Y < Main.worldSurface;
      bool InBrownLayer = P.position.Y >= Main.worldSurface && P.position.Y < Main.rockLayer;
      bool InGrayLayer = P.position.Y >= Main.rockLayer && P.position.Y < (Main.maxTilesY - 200)*16;
      bool InHell = P.position.Y >= (Main.maxTilesY - 200)*16;
      bool Ocean = P.position.X < 3600 || P.position.X > (Main.maxTilesX-100)*16;

      // these are all the regular stuff you get , now lets see......

    if(ModWorld.superHardmode && Jungle && !Dungeon && !Corruption && AboveEarth && !Ocean && Main.rand.Next(350)==1) return true;

	if(ModWorld.superHardmode && Main.bloodMoon && Jungle && !Dungeon && !Corruption && !AboveEarth && !Ocean && Main.rand.Next(2000)==1) return true;

	if(ModWorld.superHardmode && Dungeon && Main.rand.Next(70)==1) return true;	

	if(ModWorld.superHardmode && !Main.dayTime && Dungeon && !Corruption && !AboveEarth && Main.rand.Next(30)==1) return true;

	if(ModWorld.superHardmode && Main.bloodMoon && Dungeon && Main.rand.Next(20)==1) return true;


      return false;
}
#endregion


#region AI
public void AI()
{
 

#region check if standing on a solid tile
// warning: this section contains a return statement
	bool standing_on_solid_tile = false;
	if (npc.velocity.Y == 0f) // no jump/fall
	{
		int y_below_feet = (int)(npc.position.Y + (float)npc.height + 8f) / 16;
		int x_left_edge = (int)npc.position.X / 16;
		int x_right_edge = (int)(npc.position.X + (float)npc.width) / 16;
		for (int l = x_left_edge; l <= x_right_edge; l++) // check every block under feet
		{
			if (Main.tile[l, y_below_feet] == null) // null tile means ??
				return;

			if (Main.tile[l, y_below_feet].active && Main.tileSolid[(int)Main.tile[l, y_below_feet].type]) // tile exists and is solid
			{
				standing_on_solid_tile = true;
				break; // one is enough so stop checking
			}
		} // END traverse blocks under feet
	} // END no jump/fall
#endregion


        npc.netUpdate = false;
        npc.ai[0]++; // Timer Scythe
        npc.ai[1]++; // Timer Teleport
        // npc.ai[2]++; // Shots
 
        if (npc.life > 900)
        {
                int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, npc.velocity.X, npc.velocity.Y, 210, Color.Black, 2f);
                Main.dust[dust].noGravity = true;
        }
        else if (npc.life <= 900)
        {
                int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, npc.velocity.X, npc.velocity.Y, 140, Color.Black,3f);
                Main.dust[dust].noGravity = true;
        }
 
        if (Main.netMode != 2)
        {
               

		if (npc.ai[0] >= 12 && npc.ai[2] < 5) //2 was 12
                
            {
			    float num48 = 7f;
			    Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
			    float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
			    float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
			    if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
			    {
				    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
				    num51 = num48 / num51;
				    speedX *= num51;
				    speedY *= num51;
				    int damage = 80;
				    int type = Config.projectileID["Oolacile Dark Bead"];//44;//0x37; //14;
				    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				    Main.projectile[num54].timeLeft = 550;
                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				    npc.ai[0] = 0;
                        	    npc.ai[2]++;
                }
                npc.netUpdate=true;
            }
}
 
        if (npc.ai[1] >= 20) //20 was 35 for longer move time
        {
                npc.velocity.X *= 0.37f;
                npc.velocity.Y *= 0.17f;
        }
 
        if ((npc.ai[1] >= 200 && npc.life > 300) || (npc.ai[1] >= 120 && npc.life <= 300))
        {
                Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 8);
                for (int num36 = 0; num36 < 10; num36++)
                {
                        int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 27, npc.velocity.X+Main.rand.Next(-10,10), npc.velocity.Y+Main.rand.Next(-10,10), 200, Color.Purple, 1f);
                        Main.dust[dust].noGravity = true;
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
                                npc.timeLeft = 10;
                                return;
                        }
                }
                else
                {



//end of W1k's Death code


//region teleportation - can't believe I got this to work.. yayyyyy :D lol
	
		int target_x_blockpos = (int)Main.player[npc.target].position.X / 16; // corner not center
		int target_y_blockpos = (int)Main.player[npc.target].position.Y / 16; // corner not center
		int x_blockpos = (int)npc.position.X / 16; // corner not center
		int y_blockpos = (int)npc.position.Y / 16; // corner not center
		int tp_radius = 30; // radius around target(upper left corner) in blocks to teleport into
		int tp_counter = 0;
		bool flag7 = false;
		if (Math.Abs(npc.position.X - Main.player[npc.target].position.X) + Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 9000000f)
		{ // far away from target; 4000 pixels = 250 blocks
			tp_counter = 100;
			flag7 = false; // always telleport was true for no teleport
		}
		while (!flag7) // loop always ran full 100 time before I added "flag7 = true" below
		{
			if (tp_counter >= 100) // run 100 times
				break; //return;
			tp_counter++;

			int tp_x_target = Main.rand.Next(target_x_blockpos - tp_radius, target_x_blockpos + tp_radius);  //  pick random tp point (centered on corner)
			int tp_y_target = Main.rand.Next((target_y_blockpos - tp_radius)-62, (target_y_blockpos + tp_radius)-26);  //  pick random tp point (centered on corner)
			for (int m = tp_y_target; m < target_y_blockpos + tp_radius; m++) // traverse y downward to edge of radius
			{ // (tp_x_target,m) is block under its feet I think
				if ((m < target_y_blockpos - 21 || m > target_y_blockpos + 10 || tp_x_target < target_x_blockpos - 18 || tp_x_target > target_x_blockpos + 18) && (m < y_blockpos - 8 || m > y_blockpos + 8 || tp_x_target < x_blockpos - 8 || tp_x_target > x_blockpos + 8) && !Main.tile[tp_x_target, m].active)
				{ // over 21 blocks distant from player & over 5 block distant from old position & tile active(to avoid surface? want to tp onto a block?)
					bool safe_to_stand = true;
                    bool dark_caster = false; // not a fighter type AI...
					if (dark_caster && Main.tile[tp_x_target, m - 1].wall == 0) // Dark Caster & ?outdoors
						safe_to_stand = false;
					else if (Main.tile[tp_x_target, m - 1].lava) // feet submerged in lava
							safe_to_stand = false;

					if (safe_to_stand && !Collision.SolidTiles(tp_x_target - 1, tp_x_target + 1, m - 4, m - 1))
					{ //  3x4 tile region is clear; (tp_x_target,m) is below bottom middle tile
					  // safe_to_stand && Main.tileSolid[(int)Main.tile[tp_x_target, m].type] && // removed safe enviornment && solid below feet
						
			npc.TargetClosest(true);
			npc.position.X = (float)(tp_x_target * 16 - npc.width / 2); // center x at target
			npc.position.Y = (float)(m * 16 - npc.height); // y so block is under feet			
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y-5 + (npc.height / 2));
                        float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
                        npc.velocity.X = (float) (Math.Cos(rotation) * 4)*-1;
                        npc.velocity.Y = (float) (Math.Sin(rotation) * 2)*-1;

	




						
						npc.netUpdate = true;
						
						//npc.ai[3] = -120f; // -120 boredom is signal to display effects & reset boredom next tick in section "teleportation particle effects"
                        flag7 = true; // end the loop (after testing every lower point :/)
                        npc.ai[1] = 0;
					}
				} // END over 17 blocks distant from player...
			} // END traverse y down to edge of radius
		} // END try 100 times
	
    
                }
        }
       
       
 
        //beginning of Omnir's Ultima Weapon projectile code

         
        npc.ai[3]++; 
 
        if (npc.ai[3] >= 60) //how often the crystal attack can happen in frames per second
        {
                if (Main.rand.Next(20)==0) //1 in 2 chance boss will use attack when it flies down on top of you
                {
                   float num48 = 2f;
                   Vector2 vector9 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y-520 + (npc.height / 2));
                   float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector9.X) + Main.rand.Next(-20, 0x15);
                   float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector9.Y) + Main.rand.Next(-20, 0x15);
                   if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
                   {
                           float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
                           num51 = num48 / num51;
                           speedX *= num51;
                           speedY *= num51;
                           int damage = 127;//(int) (14f * npc.scale);
                           int type = Config.projectileID["Oolacile Dark Orb"];//44;//0x37; //14;
                           int num54 = Projectile.NewProjectile(vector9.X, vector9.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
                           Main.projectile[num54].timeLeft = 600;
                           Main.projectile[num54].aiStyle=4;
                           Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 25);
                           npc.ai[3] = 0;;
                   }

		npc.netUpdate=true;


                }

		
		if (Main.rand.Next(40)==1)
            {
			    float num48 = 8f;
			    Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
			    float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
			    float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
			    if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
			    {
				    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
				    num51 = num48 / num51;
				    speedX *= num51;
				    speedY *= num51;
				    int damage = 97;
				    int type = Config.projectileID["Oolacile Seeker"];//44;//0x37; //14;
				    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				    Main.projectile[num54].timeLeft = 750;
				    //Main.projectile[num54].aiStyle=1;
                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				    npc.ai[1] = 1f;
                }
                npc.netUpdate=true;
            }

		 




				if (Main.rand.Next(305)==0) //1 in 805 chance boss will summon an NPC
              			  {
					int Random = Main.rand.Next(80);
					int Paraspawn = 0;
				if (Random == 0) Paraspawn = NPC.NewNPC((int) Main.player[this.npc.target].position.X-636-this.npc.width/2, (int) Main.player[this.npc.target].position.Y-16-this.npc.width/2, "ParaspriteSpawner", 0);
				Main.npc[Paraspawn].velocity.X = npc.velocity.X;
				npc.active = true;

					}





        }
 
        npc.ai[3] += 1; // my attempt at adding the timer that switches back to the shadow orb
        if (npc.ai[3] >= 600)
        {
                if (npc.ai[1] == 0) npc.ai[1] = 1;
                else npc.ai[1] = 0;
        }
}
 
#endregion









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
	if ((npc.velocity.X > -1 && npc.velocity.X < 1) && (npc.velocity.Y > -1 && npc.velocity.Y < 1))
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









#region Gore
public void NPCLoot()
{
if (npc.life <= 0){
Main.NewText("The sorcerer of Oolacile has been defeated...", 150, 150, 150);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Oolacile Sorcerer Gore 1", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Oolacile Sorcerer Gore 2", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Oolacile Sorcerer Gore 3", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Oolacile Sorcerer Gore 2", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Oolacile Sorcerer Gore 3", 1f, -1);
}
}
#endregion