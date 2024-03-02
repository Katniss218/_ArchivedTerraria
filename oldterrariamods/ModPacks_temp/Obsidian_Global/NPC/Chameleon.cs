
    public static bool SpawnNPC(int x, int y, int playerID) {
	bool nospecialbiome = !Main.player[Main.myPlayer].zoneJungle && !Main.player[Main.myPlayer].zoneEvil && !Main.player[Main.myPlayer].zoneHoly && !Main.player[Main.myPlayer].zoneMeteor && !Main.player[Main.myPlayer].zoneDungeon;
	bool sky = nospecialbiome && ((double)y < Main.worldSurface * 0.44999998807907104); // Not necessary at all to use but needed to make all this work.
	bool surface = nospecialbiome && !sky && (y <= Main.worldSurface);
	bool underground = nospecialbiome && !surface && (y <= Main.rockLayer);
	bool underworld= (y > Main.maxTilesY-190);
	bool cavern = nospecialbiome && !sky && !surface && !underground && !underworld && (y <= Main.rockLayer *25) && !Main.player[Main.myPlayer].zoneJungle;
	bool undergroundJungle = (y >= Main.rockLayer) && !underworld && (y <= Main.rockLayer *25) && Main.player[Main.myPlayer].zoneJungle;
	bool undergroundEvil = (y >= Main.rockLayer) && !underworld && (y <= Main.rockLayer *25) && Main.player[Main.myPlayer].zoneEvil;
	bool undergroundHoly = (y >= Main.rockLayer) && !underworld && (y <= Main.rockLayer *25) && Main.player[Main.myPlayer].zoneHoly;
    

	if(Main.worldName == "Parallel World"){
if (Main.dayTime && surface)
					{
if(Main.rand.Next(15)==0){
return true;
    }
}
return false;
}
return false;
}

#region Gore

int k = 2;
string name = "Chameleon";

public void NPCLoot()
{
if (npc.life <= 0){
for(int i=1; i<k+1; i++){
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f),  name+" Gore "+i, 1f, -1);
}
}
}
#endregion

