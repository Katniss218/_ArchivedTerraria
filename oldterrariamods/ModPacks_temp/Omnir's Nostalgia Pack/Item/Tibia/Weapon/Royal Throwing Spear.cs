public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback)
{
    damage = (int) ((Main.rand.Next(50)) * (myPlayer.rangedDamage));
}