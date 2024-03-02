public bool SpawnNPC(int x, int y, int PID)
{
	if (Main.player[PID].zone["Ice Cave"] && y > Main.rockLayer && Main.rand.Next(3) == 1)
	{
		return true;
	}
	else return false;
}
public void NPCLoot()
{
	Gore.NewGore(npc.position,npc.velocity,"Ice Skelly Head",1.1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Ice Skelly Vert",1.1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Ice Skelly Vert",1.1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Ice Skelly Piece",1.1f,-1);
	Gore.NewGore(npc.position,npc.velocity,"Ice Skelly Piece",1.1f,-1);
}

public void DamagePlayer(Player player, ref int damage)
{
	if (Main.rand.Next(5) == 0)
	{
		player.AddBuff("Frozen", 180, false);
		//player.AddBuff(23, 180, false);
	}
}