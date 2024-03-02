public static void Effects(Player player) 
{
	player.controlUp = false;
	player.controlDown = false;
	player.controlLeft = false;
	player.controlRight = false;
	player.controlJump = false;
	player.noItems = true;
}

public static void NPCEffects(NPC npc)
{
	npc.velocity.X = 0;
	npc.velocity.Y = 0;
	Color color = new Color(255, 144, 255, 100);
	npc.color = color;
}
public static void NPCEffectsEnd(NPC npc)
{
	npc.color = default(Color);
}
