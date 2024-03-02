#region debuff
public void DamagePlayer(Player player, ref int damage) //hook works!
{
	if (Main.rand.Next(2) == 0)
	{
				player.AddBuff(36, 180, false); //broken armor
                player.AddBuff(24, 180, false); //on fire
				
    }
}
#endregion

public void AI()
{
	npc.AI(true);

}