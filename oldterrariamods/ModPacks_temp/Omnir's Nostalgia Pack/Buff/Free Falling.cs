public static void Effects(Player player, int buffIndex, int buffType, int buffTime) 
{
    ModWorld.CheckingMyCollision = true;
}

public static void NPCEffects(NPC npc) 
{
    npc.noTileCollide = true;
}