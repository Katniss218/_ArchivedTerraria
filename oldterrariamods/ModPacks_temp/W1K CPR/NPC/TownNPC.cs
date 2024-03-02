public int chatLine = -1;

public void Initialize()
{
	SetName();
}

public string KindChatFuncName()
{
	if (chatLine != -1) return "Next";
	return "Talk";
}

public bool KindChatFunc()
{
	chatLine++;
	Main.npcChatText = npc.GetChat();
	return true;
}

public void PostAI() 
{
	for (int num36 = 0; num36 < 200; num36++)
	{
		if (Main.npc[num36].active && num36 != npc.whoAmI && Main.npc[num36].type == Config.npcDefs.byName["TownNPC"].type)
		{
			npc.active = false;
		}
	}
	if (npc.Distance(Main.player[Main.myPlayer].Center) > 100)
	{
		chatLine = -1;
	}
	//Main.NewText(""+npc.Distance(Main.player[Main.myPlayer].Center));
}

public bool TownSpawn()
{
	for (int num36 = 0; num36 < 200; num36++)
	{
		if (Main.npc[num36].active && Main.npc[num36].type == Config.npcDefs.byName["TownNPC"].type)
		{
		return false;
		}
	}
	if (Main.hardMode) return true;
	return false;
}

public static string SetName()
{
	return "Cronshade Scourdevor";
}

public string DominantChat()
{
	if (chatLine != -1)
	{
	string text = "...";
	if (chatLine == 0) text = "Welcome to your house, apprentice dolls killer. Or, at least, I am supposed to think this is your house. My AI is not smart enough to define that.";
	if (chatLine == 1) text = "I am Cronshade Scourdevor. If you think that's a bad name, same could be said for "+Main.player[Main.myPlayer].name+". I do not even know what your character name is, I can just write it but I can't really think about it, all that really matters is that I am programmed to think your name sucks.";
	if (chatLine == 2) text = "You might wonder why I am here. That is a really simple question to answer. Probably not quite simple to understand, but that's not my job as an NPC to make sure you're smart enough for what's to come.";
	if (chatLine == 3) text = "In the beginning, Terraria was made. From your side, you could define Terraria as the universe we actually live in. Unlike popular beliefs, said universe is not a Minecraft rip-off. Do not wonder too much about this last part, people who know, will understand.";
	if (chatLine == 4) text = "The gods who gave life to said universe kept looking over it and contributing to its evolution. The creatures these gods gave life to followed the course of their world's evolution, as long as their owns.";
	if (chatLine == 5) text = "As said evolution kept on going, some of these creatures started earning incredible powers over the control of reality. Particularly talented ones were even able to create their owns. At some point, said creatures started becoming gods themselves. Or, lesser gods we could say.";
	if (chatLine == 6) text = "One particularly talented creature was even able to create an universe where other beings could alter reality at their own will. Normally every iteration of any universe is supposed to follow the base of their originating gods, but this one was different.";
	if (chatLine == 7) text = "This universe had one great exception on its side. It was called tConfig. Lesser gods can, by nature, define their own sets of reality alterations. Every iteration of said universe shows different sets of said alterations.";
	if (chatLine == 8) text = "In simple terms, tConfig works as the base universe, every universe has infinite iterations with similiar realities but different parameters. tConfig shows different realities too aslong with different gods managing said reality.";
	if (chatLine == 9) text = "There is a number of 'Minor Gods' who, at every iteration, are selected to look over it. Each one of these gods changes the universe's reality at their own will. The one who created me is one of these 'Minor Gods'";
	if (chatLine == 10) text = "To explain further, I am a sort of demi-god. Gods generally can't interfere with the lifes of the beings living in their universe iteration. That's why I'm here. I am a sort of alter-ego of one of this iteration's god."; 
	if (chatLine == 11) text = "Actually, you might get surprised to know I've been thrown into this world like a piece of garbage even thou' I'm like a child of a god or some similiar thing. That's the main reason why I'm here. I am broke and a sort of stray dog.";
	if (chatLine == 12) text = "I have also heard you were able to defeat the doll of darkness, Okiku. Congratulations, you have leveled up to the second top tier of my 'beings I appreciate' list, right below my hat. Okiku is one sort of an elusive target and incredibly strong for being just a stupid doll, so well done.";
	if (chatLine == 13) text = "Also, you might be able to take control of the Shadow Dragon now that you have purified the doll. The dragon is actually part of the doll itself, so you might be able to use the doll's power to summon it and move around. It was once a great friend of mine, so treat it well.";
	if (chatLine == 14) text = "Now, I have one favor to ask you. One great favor. One favor that will probably save this whole world actually. There is this 'friend' of mine who, for whatever weird reason, had been threatening various times to take over the whole world.";
	if (chatLine == 15) text = "I thought she was just playing around. It was, 'till the bitch somehow drained off all my powers. Now, she has been looking for the 'souls' of some of the most threatening creatures my god/master had created.";
	if (chatLine == 16) text = "I'm not sure what her plans are, but it would be lovelly if you could give her a lesson and also help me get my powers back. It will be totally worth it, seriously. I can use my powers to create items originally generated by outer gods. I'm sure you'd love it.";
	if (chatLine == 17) text = "Sadly, I have no idea how to obtain said souls. Just let me research into it for some time and I might be able to come to a solution. In a fourth-wall breaking way, it means you should wait for some next modpack's update.";
	if (chatLine == 18) text = "Now, I've been talking long enough. I have some weird items you could buy. They are useless pieces of junk I somehow made using my 'nerfed powers'. You might find them interesting. I'm pretty sure the merchant doesn't.";
	if (chatLine == 19) text = "Seriously, buy my stuffs, people say money don't make you happy, but I'm pretty sure they can let you live a way less pathetic life without being forced to go hunting for annoying slimes for some jelly. I think I might have a slime jellies disease or something. Or it could be the Vile Mushroom. You should build a bathroom before I puke on your carpet.";
	if (chatLine == 20)
	{
		text = "I think there's nothing else of important to say. Be safe on your way. Also buy my stuffs. I beg you. I double beg you. Thanks and good bye, for now.";
		chatLine = -1;
	}
	return text;
	}
	return "";
}

public string Chat()
{
	//chatLine = -1;
	string text = "...";
	if (!Main.bloodMoon)
	{
		int x=Config.syncedRand.Next(8);
		if(x==0)
		{
			text = "I know what you did there. I am scripted to know what you did there.";
		}
		if(x==1)
		{
			text = "Whoever coded the underworld's worldgen surelly did one one hell of a job.";
		}
		if(x==2)
		{
			text = "I never look at the bright side. Too much light can hurt your eyes.";
		}
		if(x==3)
		{
			text = "What's a purple spiky thing.";
		}
		if(x==4)
		{
			text = "By the way, if you are a woman, I have to inform you that my master is incredibly handsome. I would totally hit on him, given I was real that is.";
		}
		if(x==5)
		{
			text = "By the way, being a gods emissary or something, you could say I'm kind of similiar to the Zoodletec dude. Ironically enough I think the gods who made us both are quite good friends.";
		}
		if (x==6)
		{
			text = "Don't think too much about that Zoodletec guy. He's kind of a weirdo. He might give you the weirdness disease.";
		}
		if (x==7)
		{
			text = "I am forced to inform you that you shouldn't touch my hat. Every living being should be at least 10 meters away from my hat. I am serious. Last time someone took my hat, many people died.";
		}
	}
	else
	{
		int x=Config.syncedRand.Next(2);
		if(x==0)
		{
			text = "2spooky4me";
		}
		if(x==1)
		{
			text = "God fuck damnit is my hat bleeding.";
		}
	}
	text = text+" (Use the 'Talk' button for the dialog)";
	return text;
}

public void SetupShop(Chest chest)
{
	chest.item[0].SetDefaults("Dr.S");	
	chest.item[1].SetDefaults("Le Melon Head");
}