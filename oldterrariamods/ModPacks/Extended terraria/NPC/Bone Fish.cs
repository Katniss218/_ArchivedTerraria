public bool SpawnNPC(int x, int y, int playerID)
{
	if (y > (Main.maxTilesY - 170) && y < Main.maxTilesY && Main.rand.Next(5) == 0)
	{
		return true;
	}
	else return false;
}
public void NPCLoot()
{
	int dust = Dust.NewDust(npc.position, npc.height, npc.width, 4, 0f, 0f, 100, new Color(), 1f);
	Main.dust[dust].noGravity = true;
	Main.dust[dust].velocity.X *= 0.5f;
	Main.dust[dust].velocity.Y *= 0.5f;
	Gore.NewGore(npc.position,npc.velocity,"Bone Fish Gore 1",1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Bone Fish Gore 2",1f,-1);
}