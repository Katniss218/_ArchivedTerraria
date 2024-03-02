bool SweepStart = false; // Whether or not the sweep has begun

#region AI
public void AI()
{
    Vector2 PTC = Main.player[npc.target].position+new Vector2(npc.width/2,npc.height/2); //Targetted Player's position
    Vector2 NPos = npc.position+new Vector2(npc.width/2,npc.height/2); //Center of NPC Location
    float SweepRight = PTC.X + 600; //Location to the far right of the player
    float SweepLeft = PTC.X - 600; // Location to the far left of the player
    npc.TargetClosest(true);
    if (npc.ai[1] == 0) // First AI
    {
        if (PTC.X < NPos.X)
        {
            if (npc.velocity.X > -12)
                npc.velocity.X -= 0.22f;
        }
        if (PTC.X > NPos.X)
        {
            if (npc.velocity.X < 12) 
                npc.velocity.X += 0.22f;
        }
        if (PTC.Y < NPos.Y+200)
        {
            if (npc.velocity.Y < 0)
            {
                if (npc.velocity.Y > -6) 
                    npc.velocity.Y -= 0.7f;
            }
            else 
                npc.velocity.Y -= 0.8f;
        }
        if (PTC.Y > NPos.Y+300)
        {
            if (npc.velocity.Y > 0)
            {
                if (npc.velocity.Y < 6) 
                    npc.velocity.Y += 0.7f;
            }
            else npc.velocity.Y += 0.8f;
        }
#endregion

#region Projectile
        npc.ai[0]++;
        if (npc.ai[0] >= 280)
        {
            int damage = 62;
            float Angle = (float) Math.Atan2(NPos.Y-PTC.Y, NPos.X-PTC.X);
            int RayShot1 = Projectile.NewProjectile(NPos.X, NPos.Y,(float)((Math.Cos(Angle) * 22f)*-1),(float)((Math.Sin(Angle) * 22f)*-1), "Ice Shot", 50, 0f, 0);
            Main.projectile[RayShot1].timeLeft = 120;
            npc.ai[0] = 0;
        }
        if (Main.rand.Next(6) == 0)
        {
            int dust = Dust.NewDust(npc.position, npc.width, npc.height, 255, 0f, 0f, 200, npc.color, 4f);
            Main.dust[dust].velocity *= 0.3f;
        }
        if (Main.rand.Next(40) == 0)
            Main.PlaySound(16, (int)npc.position.X, (int)npc.position.Y, 1);
    }
#endregion

#region Sweep
    if (npc.ai[1] == 1) // Second AI
    {
        if (!SweepStart) //If the Sweep hasn't started yet, move into position
        {
            if (NPos.X >= SweepRight) //If the NPC's X is greater than or equal to SweepRight position
                SweepStart = true; //Start Sweeping
            if (NPos.X < SweepRight) //If the NPC's X is less
            {
                if (npc.velocity.X < 8) //If it isn't at maximum speed
                    npc.velocity.X += 1f; //Increase speed 
            }
        }
        if(SweepStart) //If the sweep has begun
        {
            npc.ai[3]++; //Increase shot counter
            if (npc.velocity.X > -5) //If it isn't at maximum speed
                npc.velocity.X -= 0.50f; // Increase speed
            if (npc.ai[3] >= 10) //Do this when shot counter reaches max, increase this number to increase time between shots
            {
                int RayShot = Projectile.NewProjectile(NPos.X, NPos.Y,0f,12f, "Ice Blast" , 50, 2f, 0);
                Main.projectile[RayShot].timeLeft = 120;//(npc's X, npc's Y, horizontal velocity X, vertical velocity Y, int Type, int Damage, float KnockBack, int Owner = 255)
                npc.ai[3] = 0; //Reset counter
            }
            if (NPos.X <= SweepLeft) //When the NPC reaches or passes SweepLeft
            {
                SweepStart = false; //Turn off the sweep
                npc.ai[1] = 0; //Go back to normal AI
            }
        }
        if (PTC.Y < NPos.Y+300) //Like normal AI, maintain a distance to the player
        {
            if (npc.velocity.Y < 0)
            {
                if (npc.velocity.Y > -4) 
                    npc.velocity.Y -= 0.7f;
            }
            else npc.velocity.Y -= 0.8f;
        }
        if (PTC.Y > NPos.Y+300)
        {
            if (npc.velocity.Y > 0)
            {
                if (npc.velocity.Y < 4) 
                    npc.velocity.Y += 0.7f;
            }
            else npc.velocity.Y += 0.8f;
        }
    }

    npc.ai[2]++; //this is your time interval between sweeps
    if (npc.ai[2] >= 1200) // 1200 is 20 seconds
    {
        npc.ai[2] = 0; //resets counter
        if (npc.ai[1] == 0) 
            npc.ai[1] = 1; //toggles normal movement off
        else 
            npc.ai[1] = 0; //toggles normal movement on
   }
                    {
					Lighting.addLight((int)((this.npc.position.X + (float)(this.npc.width / 2)) / 16f), (int)((this.npc.position.Y + (float)(this.npc.height / 2)) / 16f), 1f, 0.3f, 0.1f);
					Vector2 arg_1394_0 = new Vector2(this.npc.position.X, this.npc.position.Y);
					int arg_1394_1 = this.npc.width;
					int arg_1394_2 = this.npc.height;
					int arg_1394_3 = 15;
			        float arg_1394_4 = 0f;
			        float arg_1394_5 = 0f;
			        int arg_1394_6 = 100;
			        Color newColor = default(Color);
			        int num41 = Dust.NewDust(arg_1394_0, arg_1394_1, arg_1394_2, arg_1394_3, arg_1394_4, arg_1394_5, arg_1394_6, newColor, 2f);
			        Main.dust[num41].noGravity = true;
                    }
}
#endregion

#region Loot
public void NPCLoot()
{
	//generate particle effect
	Color color = new Color();
	Rectangle rectangle = new Rectangle((int)npc.position.X,(int)(npc.position.Y + ((npc.height - npc.width)/2)),npc.width,npc.width);//npc.frame;
	int count = 50;
	float vectorReduce = .4f;
	for (int i = 1; i <= count; i++)
	    {
		//int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 6, (npc.velocity.X * 0.2f) + (npc.direction * 3), npc.velocity.Y * 0.2f, 100, color, 1.9f);
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 59, 0, 0, 50, Color.White, 2.0f);
		Main.dust[dust].noGravity = false;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }

        NPC.NewNPC((int)npc.position.X,(int)npc.position.Y,"Frost King Left Arm Broken",0);
}
#endregion

