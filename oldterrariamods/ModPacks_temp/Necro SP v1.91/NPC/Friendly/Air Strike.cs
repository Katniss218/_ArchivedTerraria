bool SweepStart = false; // Whether or not the sweep has begun

#region AI
public void AI()
{
    Vector2 PTC = Main.player[npc.target].position+new Vector2(npc.width/2,npc.height/2); //Targetted Player's position
    Vector2 NPos = npc.position+new Vector2(npc.width/2,npc.height/2); //Center of NPC Location
    float SweepRight = PTC.X + 800; //Location to the far right of the player
    float SweepLeft = PTC.X - 800; // Location to the far left of the player
    npc.TargetClosest(true);


#region Sweep
    if (npc.ai[1] == 0) // First AI
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

#region Projectile
        if(SweepStart) //If the sweep has begun
        {
            npc.ai[3]++; //Increase shot counter
            if (npc.velocity.X > -5) //If it isn't at maximum speed
                npc.velocity.X -= 0.50f; // Increase speed
            if (npc.ai[3] >= 20) //Do this when shot counter reaches max, increase this number to increase time between shots
            {
                Main.PlaySound(12, (int) NPos.X, (int) NPos.Y, 12); 
                int RayShot = Projectile.NewProjectile(NPos.X, NPos.Y,0f,12f, "Heavy Round" , 50, 2f, 0);
                Main.projectile[RayShot].timeLeft = 120;//(npc's X, npc's Y, horizontal velocity X, vertical velocity Y, int Type, int Damage, float KnockBack, int Owner = 255)
                npc.ai[3] = 0; //Reset counter
            }
#endregion

            if (NPos.X <= SweepLeft) //When the NPC reaches or passes SweepLeft
            {
                SweepStart = false; //Turn off the sweep
                npc.ai[1] = 0; //Go back to normal AI
            }
        }
        if (PTC.Y < NPos.Y+100) //Like normal AI, maintain a distance to the player
        {
            if (npc.velocity.Y < 0)
            {
                if (npc.velocity.Y > -8) 
                    npc.velocity.Y -= 1.4f;
            }
            else npc.velocity.Y -= 0.8f;
        }
        if (PTC.Y > NPos.Y+100)
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
    if (npc.ai[2] >= 1400) // 1200 is 20 seconds
    {
        npc.ai[2] = 0; //resets counter
        if (npc.ai[1] == 0) 
            npc.ai[1] = 1; //toggles normal movement off
        else 
            npc.ai[1] = 0; //toggles normal movement on
    }
}
#endregion
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
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 54, 0, 0, 50, Color.White, 3f);
		Main.dust[dust].noGravity = true;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }
}
#endregion