public static void Effects(Player player) {
    

if(player.statLife <= 80) {
				player.lifeRegen += 8;

int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 21, (player.velocity.X) + (player.direction * 1), player.velocity.Y, 245, Color.Violet, 2.0f);
 Main.dust[dust].noGravity = true;

				}
				else { player.lifeRegen += 1;
					}

}

public static void SetBonus(Player player) {
	player.setBonus = "+10% Melee Damage, +27% Melee Speed";
    
    player.meleeDamage += 0.10f;
	player.meleeSpeed += 0.27f;
	
    
}





    public void PlayerFrame(Player player){
if (Main.rand.Next(7)==0)
{
     int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 21, (player.velocity.X) + (player.direction * 1), player.velocity.Y, 200, Color.Violet, 1.0f);
 Main.dust[dust].noGravity = true;
	
        Main.dust[dust].noGravity = true;
    }
}


