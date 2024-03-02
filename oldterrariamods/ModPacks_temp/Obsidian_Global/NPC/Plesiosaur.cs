public static bool SpawnNPC(int x, int y, int playerID) {
	if(Main.worldName == "Parallel World"){
if (Main.player[playerID].zoneMeteor)
					{
if(Main.rand.Next(50)==0){
return true;
    }
}
return false;
}
return false;
}

#region Gore

int k = 3;
string name = "Plesiosaur";

public void NPCLoot()
{
if (npc.life <= 0){
for(int i=1; i<k+1; i++){
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f),  name+" Gore "+i, 1f, -1);
}
}
}
#endregion