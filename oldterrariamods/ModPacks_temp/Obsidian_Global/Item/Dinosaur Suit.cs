bool ok = false;
int cooldown = 90;

public void Effects(Player player) {
	player.lifeRegen += 2;
    cooldown --;
    if(cooldown <= 0){
    cooldown = 0;
    }
}

public void SetBonus(Player player) {


if(player.statMana > 0 && cooldown == 0){
if(Main.mouseRightRelease == false && ok==false){


player.velocity.X += 14*player.direction;
player.velocity.Y -= 5;

ok = true;
cooldown = 90;
player.statMana -= 10;
}
}

if(Main.mouseRightRelease == true && ok == true){
ok = false;
}



}

public void DealtPlayer(Player myPlayer, double damage, NPC npc){


}


public void Initialize(){


}

