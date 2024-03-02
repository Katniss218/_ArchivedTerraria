public static bool SpawnNPC(int x, int y, int playerID) {
	if (Main.player[playerID].zoneJungle && Main.hardMode)
    {
	   if( Main.rand.Next(15)==1) return true;
    return false;
    }
return false;
}

public void Initialize(){
int x = Main.rand.Next(100);
this.npc.damage = 45+x;
this.npc.defense = 10+(int)Math.Round((double)(x/5));
this.npc.lifeMax = 280+((int)Math.Round((double)(x/10))*5);
this.npc.scale = 0.7f + (x/100);
this.npc.height = 34 + (int)Math.Round((double)(x/50));
this.npc.width = 24 + (int)Math.Round((double)(x/50));
this.npc.value = x*600;
}

#region Gore
public void NPCLoot()
{
if (npc.life <= 0){
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Cave Harpy Gore 1", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Cave Harpy Gore 2", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Cave Harpy Gore 3", 1f, -1);
}
}
#endregion