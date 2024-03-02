bool TailSpawned = false;

int breathCD = 110;
//int previous = 0;
bool breath = false;
//bool tailD = false;

public static bool SpawnNPC(int x, int y, int playerID)
{
	bool nospecialbiome = !Main.player[playerID].zoneJungle && !Main.player[playerID].zoneEvil && !Main.player[playerID].zoneHoly && !Main.player[playerID].zoneMeteor && !Main.player[playerID].zoneDungeon; // Not necessary at all to use but needed to make all this work.

	bool sky = nospecialbiome && ((double)y < Main.worldSurface * 0.44999998807907104);
	bool surface = nospecialbiome && !sky && (y <= Main.worldSurface);
	bool underground = nospecialbiome && !surface && (y <= Main.rockLayer);
	bool underworld= (y > Main.maxTilesY-190);
	bool cavern = nospecialbiome && (y >= Main.rockLayer) && (y <= Main.rockLayer *25);
	bool undergroundJungle = (y >= Main.rockLayer) && (y <= Main.rockLayer *25) && Main.player[playerID].zoneJungle;
	bool undergroundEvil = (y >= Main.rockLayer) && (y <= Main.rockLayer *25) && Main.player[playerID].zoneEvil;
	bool undergroundHoly = (y >= Main.rockLayer) && (y <= Main.rockLayer *25) && Main.player[playerID].zoneHoly;
	bool BeforeThreeAfterSeven = (x < Main.maxTilesX*0.3f) || (x > Main.maxTilesX*0.7f); //Before 3/10ths or after 7/10ths width (a little wider than ocean bool?)

	if (ModWorld.superHardmode) 
	{
	if (underworld)
	{
	if (Main.rand.Next(80) == 0) return true;
    if (Main.bloodMoon && Main.rand.Next(20) == 0) return true;
	if (BeforeThreeAfterSeven && Main.rand.Next(20) == 0) return true;
    if (BeforeThreeAfterSeven && Main.bloodMoon && Main.rand.Next(10) == 0) return true;
	
	}
	}
	return false;
}

public void DamagePlayer(Player player, ref int damage) //hook works!
{
	if (Main.rand.Next(2) == 0)
	{
		player.AddBuff("Slowed Life Regeneration", 3600, false); //slowed life regen
                player.AddBuff(39, 600, false); //cursed inferno
	}
    
}








public void Initialize(){
 npc.name="Serpent of the Abyss";
}


public void AI()
{
	npc.AI(true);
	if (!TailSpawned)
	{
	int Previous = npc.whoAmI;
	for (int num36 = 0; num36 < 44; num36++)
	{
		int lol = 0;
		if (num36 >= 0 && num36 < 43)
		{
		lol = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.width/2), "Serpent of the Abyss Body", npc.whoAmI);
		}
		else
		{
		lol = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.width/2), "Serpent of the Abyss Tail", npc.whoAmI);
		}
		Main.npc[lol].realLife = npc.whoAmI;
		Main.npc[lol].ai[2] = (float)npc.whoAmI;
		Main.npc[lol].ai[1] = (float)Previous;
		Main.npc[Previous].ai[0] = (float)lol;
		NetMessage.SendData(23, -1, -1, "", lol, 0f, 0f, 0f, 0);
		Previous = lol;
	}
	TailSpawned = true;
	}

Player nT = Main.player[npc.target];

	//if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))           
	//		{
				if (Main.rand.Next(90) == 0) 
				{
					breath = true;
					Main.PlaySound(2, -1, -1, 20);
				}
			//}


    if (breath) {
        
            float num48 = 5f;
				float rotation = (float) Math.Atan2(npc.Center.Y-Main.player[npc.target].Center.Y, npc.Center.X-Main.player[npc.target].Center.X);
				int num54 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y+(20f*npc.direction), npc.velocity.X * 3f + (float)Main.rand.Next(-2, 3), npc.velocity.Y * 3f + (float)Main.rand.Next(-2, 3), "Cursed Dragon's Breath", 80, 0f, Main.myPlayer);
				Main.projectile[num54].timeLeft = 50;
				npc.netUpdate=true;
		
        
        breathCD--;
        
    }
    if (breathCD <= 0) {
        breath = false;
        breathCD = 120;
        Main.PlaySound(2, -1, -1, 20);
    }
    if (Main.rand.Next(940) == 0) {
        for (int pcy = 0; pcy < 10; pcy++) {
	        Projectile.NewProjectile((float)nT.position.X - 100 + Main.rand.Next(200), (float)nT.position.Y - 400f, (float)(-80 + Main.rand.Next(160)) / 10, 10.9f, Config.projDefs.byName["Poison Flamess"].type, 94, 2f, 255); //9.9f was 14.9f
            Main.PlaySound(2, -1, -1, 20);

        }
    }
    if (Main.rand.Next(2760) == 0) {
        for (int pcy = 0; pcy < 10; pcy++) {
	        Projectile.NewProjectile((float)nT.position.X - 100 + Main.rand.Next(1600), (float)nT.position.Y - 300f, (float)(-40 + Main.rand.Next(80)) / 10, 9.5f, Config.projDefs.byName["Dragon Meteor"].type, 100, 2f, 255); //9.5f was 14.9f
            Main.PlaySound(2, -1, -1, 20);
        }
    }
    if (Main.rand.Next(60) == 0) {
        int d = Dust.NewDust(npc.position, npc.width, npc.height, 6, npc.velocity.X / 4f, npc.velocity.Y / 4f, 100, default(Color), 1f);
        Main.dust[d].noGravity = true;
    }


}

    







public void NPCLoot()
{
Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
if (npc.life <= 0){
Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Lich King Serpent Head Gore", 1f, -1);

}
}
