public static void Effects(Player player) 
{
	player.velocity.X = 0.3f;
	player.velocity.Y = 0.3f;
}

public static void NPCEffects(NPC npc) 
{
	npc.velocity.X = 0.3f;
	npc.velocity.Y = 0.3f;
}

//Color C = Color.White;
//public void NPCEffectsStart(NPC N,int buffindex,int bufftype,int bufftime)
//{
//      C = N.color;
//      N.color = new Color(200, 0, 255, 150); //purple transparentish
//}
//public void NPCEffectsEnd(NPC N,int buffindex,int bufftype,int bufftime)
//{
//    N.color = C;
//}
//public void NPCEffects(NPC N,int buffindex,int bufftype,int bufftime)
//{
//      if(N.dontTakeDamage) return;
//      N.lifeRegen-=10; //on fire reduces 8 , poison reduces 4 , cursed fire reduces 12
//}
