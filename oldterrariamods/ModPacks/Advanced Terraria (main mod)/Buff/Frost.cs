public void NPCEffects(NPC npc)
{
	npc.velocity.X = 0;
	npc.velocity.Y = 0;
	Color color = new Color(0, 144, 255, 100);
	npc.color = color;
}
public void NPCEffectsEnd(NPC npc)
{
	npc.color = default(Color);
}
