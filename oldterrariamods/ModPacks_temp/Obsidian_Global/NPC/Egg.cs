
int eclose = 900;

public void AI(){
eclose--;

if(eclose<0){
NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Mini Spider"].type, 0);
this.npc.active = false;
}
}

#region Gore
public void NPCLoot()
{
if (npc.life <= 0){
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Egg Gore 1", 1f, -1);
Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Egg Gore 2", 1f, -1);
}
}
#endregion