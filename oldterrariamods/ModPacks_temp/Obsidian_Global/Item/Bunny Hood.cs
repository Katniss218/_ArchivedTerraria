bool ok = false;
int cooldown = 110;

public void SetBonus(Player player) {


if( cooldown == 0){
if(Main.mouseRightRelease == false && ok==false){


player.velocity.Y -= 5;

ok = true;
cooldown = 110;
}
}

if(Main.mouseRightRelease == true && ok == true){
ok = false;
}



}


public void Effects(Player player) {
	player.lifeRegen += 1;
}