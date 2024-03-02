
//Globals
private NPC target = null;

//Methods

public void EffectsStart(Player p, int index, int type, int time) {
	//Find target
	if(Main.netMode == 2) {
		return;
	}
	int closest = -1;
	float x = Main.screenPosition.X + Main.mouseX;
	float y = Main.screenPosition.Y + Main.mouseY;
	float w = 256;
	float h = 256;
	for(int l=0;l<Main.npc.Length;l++) {
		NPC npc = Main.npc[l];
		if(!npc.active || npc.friendly) {
			continue;
		}
		if(npc.position.X > x-w && npc.position.X < x+w &&
		   npc.position.Y > y-h && npc.position.Y < y+h) {
			closest = l;
			w = x > npc.position.X ? x-npc.position.X : npc.position.X-x;
			h = y > npc.position.Y ? y-npc.position.Y : npc.position.Y-y;
		}
	}
	if(closest != -1) {
		target = Main.npc[closest];
	} else {
		p.DelBuff(index);
	}
}

public void Effects(Player p, int index, int type, int time) {
	//If target does not exist, disable Lock-on
	if(target == null || !target.active) {
		p.DelBuff(index);
		return;
	}
	//Set buffTime
	p.buffTime[index] += 30;
	p.buffTime[index] -= p.buffTime[index] % 60;
	//Buff Effects
	ModPlayer.skillGunslinger[p.whoAmi] = true;
	switch(p.buffTime[index]) {
		case 60:
			p.moveSpeed *= 1.05f;
			p.rangedDamage *= 1.05f;
			break;
		case 120:
			p.moveSpeed *= 1.1f;
			p.rangedDamage *= 1.1f;
			break;
		case 180:
			p.moveSpeed *= 1.2f;
			p.rangedDamage *= 1.2f;
			break;
	}
	//Change mouse position to target
	if(Main.netMode != 2) {
		Main.mouseX = (int)(target.position.X - Main.screenPosition.X + (target.width/2) + (target.velocity.X*10));
		Main.mouseY = (int)(target.position.Y - Main.screenPosition.Y + (target.height/2) + (target.velocity.Y*10));
	}
}

public void EffectsEnd(Player p, int index, int type, int time) {
	ModPlayer.skillGunslinger[p.whoAmi] = false;
}

public void FrameEffect(Player p) {
	//Fix mouse position
	if(Main.netMode == 2) {
		return;
	}
	Main.mouseX = Main.mouseState.X;
	Main.mouseY = Main.mouseState.Y;
	//Draw crosshair on target
	if(p.whoAmi == Main.myPlayer) {
		ModPlayer.crosshairX = (int)(target.position.X + (target.width/2) - 32);
		ModPlayer.crosshairY = (int)(target.position.Y + (target.height/2) - 32);
	}
}
