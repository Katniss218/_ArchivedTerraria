public void Effects(Player P)
{
	P.moveSpeed += 0.15f;
	P.pStone = true;
}
public bool UseAmmo(Player P, int shoot, Item consumed) { return new Random().Next(20) != 0; }
public void DamagePlayer(Player P,ref int DMG,NPC N)
{
	if ((ModPlayer.HasItemInArmor(Config.itemDefs.byName["Slime Talisman"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Slime Talisman"].type)) && (N.type == 1 || N.type == 16 || N.type == 59 || N.type == 71 || N.type == 81 || N.type == 121 || N.type == 122 || N.type == 138 || N.type == 141 || N.type == Config.npcDefs.byName["White Slime"].type || N.type == Config.npcDefs.byName["Boom Slime"].type))
	{
		return;
	}
	if ((ModPlayer.HasItemInArmor(Config.itemDefs.byName["Dragon Stone"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Dragon Stone"].type)) && (N.type == 2 || N.type == 6 || N.type == 42 || N.type == 48 || N.type == 49 || N.type == 51 || N.type == 60 || N.type == 61 || N.type == 62 || N.type == 66 || N.type == 75 || N.type == 93 || N.type == 94 || N.type == 112 || N.type == 133 || N.type == 137 || N.type == Config.npcDefs.byName["Illuminant Eye"].type || N.type == Config.npcDefs.byName["Hallowor"].type || N.type == Config.npcDefs.byName["Bloodshot Eye"].type || N.type == Config.npcDefs.byName["Hallow Spit"].type || N.type == Config.npcDefs.byName["Cloud Bat"].type))
	{
		return;
	}
	if ((ModPlayer.HasItemInArmor(Config.itemDefs.byName["Undead Talisman"].type) || ModPlayer.HasItemInExtraSlots(Config.itemDefs.byName["Undead Talisman"].type)) && (N.type == 3 || N.type == 21 || N.type == 31 || N.type == 32 || N.type == 33 || N.type == 34 || N.type == 44 || N.type == 45 || N.type == 52 || N.type == 53 || N.type == 77 || N.type == 78 || N.type == 79 || N.type == 80 || N.type == 82 || N.type == 109 || N.type == 110 || N.type == 132 || N.type == 140 || N.type == Config.npcDefs.byName["Magma Skeleton"].type || N.type == Config.npcDefs.byName["Troll"].type || N.type == Config.npcDefs.byName["Heavy Zombie"].type || N.type == Config.npcDefs.byName["Ice Skeleton"].type || N.type == Config.npcDefs.byName["Irate Bones"].type))
	{
		return;
	}
	if (!P.immune)
        {
		Projectile.NewProjectile(P.position.X + (P.width * 0.5f), P.position.Y - 200, 0f, 4f, Config.projDefs.byName["Lightning Bolt"].type, 50, 6, Main.myPlayer);
		Main.PlaySound(2, (int)P.position.X, (int)P.position.Y - 200, SoundHandler.soundID["Thunder"]);
	}
}