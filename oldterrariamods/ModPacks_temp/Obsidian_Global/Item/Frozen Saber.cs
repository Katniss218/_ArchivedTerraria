

public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback){
if(Main.rand.Next(3)==0){
npc.AddBuff(32, 60, false);
}
}