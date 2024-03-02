public static void UseItemEffect(Player player, Rectangle rectangle) 
{
    int dust = Dust.NewDust(
    new Vector2((float) rectangle.X, (float) rectangle.Y),      //position
    rectangle.Width,                                            //box width
    rectangle.Height,                                           //box height
    35,                                                         //type
    (player.velocity.X * 0.2f) + (player.direction * 3),        //X velocity
    player.velocity.Y * 0.2f,                                   //Y velocity
    100,                                                        //alpha
    new Color(),                                                //Color override
    1.8f                                                        //scale
    );
    Main.dust[dust].noGravity = true;
}




            public void UseItem(Player player, int playerID) {
        {
        {
        {

                    int spread = 30;
             
                    float num48 = 14f;
                    float speedX = ((Main.mouseX + Main.screenPosition.X) - (player.position.X + 

player.width * 0.5f))+Main.rand.Next(-spread, spread);
                    float speedY = ((Main.mouseY + Main.screenPosition.Y) - (player.position.Y + 

player.height * 0.5f))+Main.rand.Next(-spread, spread);
		    float speedX1 = ((Main.mouseX + Main.screenPosition.X) - (player.position.X + 

player.width * 0.5f))+Main.rand.Next(-spread, spread);
                    float speedY1 = ((Main.mouseY + Main.screenPosition.Y) - (player.position.Y + 

player.height * 0.5f))+Main.rand.Next(-spread, spread);
		    float speedX2 = ((Main.mouseX + Main.screenPosition.X) - (player.position.X + 

player.width * 0.5f))+Main.rand.Next(-spread, spread);
                    float speedY2 = ((Main.mouseY + Main.screenPosition.Y) - (player.position.Y + 

player.height * 0.5f))+Main.rand.Next(-spread, spread);
		    float speedX3 = ((Main.mouseX + Main.screenPosition.X) - (player.position.X + 

player.width * 0.5f))+Main.rand.Next(-spread, spread);
                    float speedY3 = ((Main.mouseY + Main.screenPosition.Y) - (player.position.Y + 

player.height * 0.5f))+Main.rand.Next(-spread, spread);
                    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
                    num51 = num48 / num51;
                    speedX *= num51;
                    speedY *= num51;
                    speedX1 *= num51;
                    speedY1 *= num51;
                    speedX2 *= num51;
                    speedY2 *= num51;
                    speedX3 *= num51;
                    speedY3 *= num51;
             
                 if ((player.direction == -1) && ((Main.mouseX + Main.screenPosition.X) > 

(player.position.X + player.width * 0.5f)))
                    {
                            player.direction = 1;
                    }
                    if ((player.direction == 1) && ((Main.mouseX + Main.screenPosition.X) < 

(player.position.X + player.width * 0.5f)))
                    {
                            player.direction = -1;
                    }
             
                    if (player.direction == 1) player.itemRotation = (float) Math.Atan2((Main.mouseY + 

Main.screenPosition.Y)-(player.position.Y + player.height * 0.5f),
     
    (Main.mouseX + Main.screenPosition.X) - (player.position.X + player.width * 0.5f));
                    else player.itemRotation = (float) Math.Atan2((player.position.Y + player.height * 

0.5f)-(Main.mouseY + Main.screenPosition.Y),(player.position.X +
     
    player.width * 0.5f)-(Main.mouseX + Main.screenPosition.X));   
                   
             
	Projectile.NewProjectile(
                    (float) player.position.X + (player.width * 0.5f),
                    (float) player.position.Y + (player.height * 0.5f),
                    (float) speedX,
                    (float) speedY,
                    "UFB",
                    (int) (item.damage*player.magicDamage),
                    player.inventory[player.selectedItem].knockBack,
                    playerID
                    );
     
	Projectile.NewProjectile(
                    (float) player.position.X + (player.width * 0.5f),
                    (float) player.position.Y + (player.height * 0.5f),
                    (float) speedX1,
                    (float) speedY1,
                    "UFB",
                    (int) (item.damage*player.magicDamage),
                    player.inventory[player.selectedItem].knockBack,
                    playerID
                    );

	Projectile.NewProjectile(
                    (float) player.position.X + (player.width * 0.5f),
                    (float) player.position.Y + (player.height * 0.5f),
                    (float) speedX2,
                    (float) speedY2,
                    "UFB",
                    (int) (item.damage*player.magicDamage),
                    player.inventory[player.selectedItem].knockBack,
                    playerID
                    );
                    
	Projectile.NewProjectile(
                    (float) player.position.X + (player.width * 0.5f),
                    (float) player.position.Y + (player.height * 0.5f),
                    (float) speedX3,
                    (float) speedY3,
                    "UFB",
                    (int) (item.damage*player.magicDamage),
                    player.inventory[player.selectedItem].knockBack,
                    playerID
                    );
     
    }
}
}
}