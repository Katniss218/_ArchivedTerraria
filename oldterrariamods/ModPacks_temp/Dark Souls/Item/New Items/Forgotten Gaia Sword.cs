
public static void StatusNPC(Player P,NPC N, ref int DMG, ref float KB) 
{
        N.AddBuff("Dispel Shadow", 10000, false);
}


public void DamageNPC(Player myPlayer, NPC npc, ref int damage, ref float knockback)
{
    if(npc.name=="Witchking") damage *= 3;

if(npc.name == "Witchking")
    {
        npc.defense = 0; //0 is probably better here
        npc.AddBuff("Dispel Shadow", 10000, false);
        
    }
    
    
} 



public void UseItemEffect(Player player, Rectangle rectangle)
{
	Color color = new Color();
	//This is the same general effect done with the Fiery Greatsword
	int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 57, (player.velocity.X), player.velocity.Y, 200, color, 1f);
	Main.dust[dust].noGravity = false;
}



