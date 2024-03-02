int rebirthCount = 0;

public void AI()
{
	rebirthCount++;
	npc.life = 1;
	if (rebirthCount == 300)
	{
		npc.life = 0;
		npc.active = false;
		npc.NPCLoot();
	}
	//Main.musicBox = 13;
}
public void NPCLoot()
{
	NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, "Oblivion Head 1",0);
	Main.NewText("Oblivion has been reborn!", 175, 75, 255);
	//Main.musicBox = 13;
}