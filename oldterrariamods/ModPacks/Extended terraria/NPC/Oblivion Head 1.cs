#region stuff
int counter = 0;
bool arm1Spawned = false; // left grabbing arm
bool arm2Spawned = false; // right grabbing arm
bool arm3Spawned = false; // saw-like arm
bool cannonSpawned = false; // cannon
bool laserSpawned = false; // laser
bool viceSpawned = false; // vice
bool sawSpawned = false; // saw
bool head2Spawned = false; // second head
bool isInfernaspazSpawned = false;
int oblivionValue = Config.npcDefs.byName["Oblivion Head 1"].type;
int arm1 = 0;
int arm2 = 0;
int arm3 = 0;
int cannon = 0;
int laser = 0;
int vice = 0;
int saw = 0;
int head2 = 0;
int inferna = 0;
bool daynight = false;
bool arm1Gore = false;
bool arm2Gore = false;
bool arm3Gore = false;
bool head2Gore = false;
#endregion

public bool PreAI()
{
	daynight = Main.dayTime;
	Main.dayTime = false;
	return true;
}
public void PostAI()
{
	Main.dayTime = daynight;
}
public void Initialize()
{
	npc.TargetClosest(true);
	npc.ai[0] = 1;
}

#region AI()
public void AI()
{
	if (ModWorld.isOblivionSpawned)
	{
		npc.type = 127;
		ModWorld.isOblivionSpawned = false;
	}

	if (!cannonSpawned)
	{
		cannon = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Oblivion Cannon", npc.whoAmI);
		Main.npc[cannon].ai[1] = npc.whoAmI;
		Main.npc[cannon].target = npc.target;
		cannonSpawned = true;
	}

	if (!sawSpawned)
	{
		saw = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Oblivion Saw", npc.whoAmI);
		Main.npc[saw].ai[1] = npc.whoAmI;
		Main.npc[saw].target = npc.target;
		sawSpawned = true;
	}

	if (!viceSpawned)
	{
		vice = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Oblivion Vice", npc.whoAmI);
		Main.npc[vice].ai[1] = npc.whoAmI;
		Main.npc[vice].target = npc.target;
		viceSpawned = true;
	}

	if (!laserSpawned)
	{
		laser = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "Oblivion Laser", npc.whoAmI);
		Main.npc[laser].ai[1] = npc.whoAmI;
		Main.npc[laser].target = npc.target;
		laserSpawned = true;
	}

	if (!arm1Spawned)
	{
		arm1 = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "arm1", npc.whoAmI);
		Main.npc[arm1].ai[1] = npc.whoAmI;
		Main.npc[arm1].target = npc.target;
		arm1Spawned = true;
	}

	if (!arm2Spawned)
	{
		arm2 = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "arm2", npc.whoAmI);
		Main.npc[arm2].ai[1] = npc.whoAmI;
		Main.npc[arm2].target = npc.target;
		arm2Spawned = true;
	}

	if (!arm3Spawned)
	{
		arm3 = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), "arm3", npc.whoAmI);
		Main.npc[arm3].ai[1] = npc.whoAmI;
		Main.npc[arm3].target = npc.target;
		arm3Spawned = true;
	}
	
	if (!head2Spawned)
	{
		head2 = NPC.NewNPC((int) npc.position.X+(npc.width*2), (int) npc.position.Y+(npc.height/2), "Oblivion Head 2", 0);
		Main.npc[head2].ai[3] = npc.whoAmI;
		Main.npc[head2].target = npc.target;
		head2Spawned = true;
	}

	npc.AI(true); // copies ini aiStyle
	if (Main.dayTime)
	{
		Main.dayTime = false;
		counter++;
		if (counter >= 0 && counter < 600) npc.ai[1] = 1f;
		if (counter >= 600)
		{
			npc.ai[1] = 3f;
			if (counter >= 1200) counter = 0;
		}
	}
			
	if (Main.rand.Next(75) == 1)
	{
		float Speed = 12f;
		Vector2 vector8 = new Vector2(npc.position.X + 70, npc.position.Y + 112);
		int damage = 50;
		int type = 96;
		float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
		int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * Speed)*-1),(float)((Math.Sin(rotation) * Speed)*-1), type, damage, 0f, 0);
	}
	if (npc.life < (int)(npc.lifeMax / 2))
	{
		if (!isInfernaspazSpawned)
		{
			inferna = NPC.NewNPC((int) npc.position.X+(npc.width*2), (int) npc.position.Y+(npc.height/2), "Infernaspaz", 0);
			Main.npc[inferna].target = npc.target;
			isInfernaspazSpawned = true;
		}
	}
}
#endregion

public static void RemoveSkellyPrimeArms()
{
	foreach (NPC N in Main.npc)
	{
		if (N.type == 128 || N.type == 129 || N.type == 130 || N.type == 131)
		{
			N.active = false;
			N.life = 0;
			N.checkDead();
		}
	}
}

#region DamagePlayer(Player P)
public void DamagePlayer(Player P, ref int damage)
{
	if (Main.rand.Next(5) == 1)
	{
		P.AddBuff(31, 600);
	} // buff
}
#endregion

#region NPCLoot()
public void NPCLoot()
{
	ModWorld.DeadUB();
	//npc.type = oblivionValue;
	Gore.NewGore(npc.position, npc.velocity, "Oblivion Gore 1", 1f, -1);
	Gore.NewGore(npc.position, npc.velocity, "Oblivion Gore 2", 1f, -1);
}
#endregion