public void HoldStyle(Player P)
{
    Main.chain3Texture = Main.goreTexture[Config.goreID["Diabolic Chain"]];
}

public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback)
{
    damage = (int) ((Main.rand.Next(26)) * (myPlayer.meleeDamage));
}

