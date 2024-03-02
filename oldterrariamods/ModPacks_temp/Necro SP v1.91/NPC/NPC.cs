// NPC variation file
public bool isNightmare = false;

#region List string
 List<string> Slimes = new List<string>(new string[] { // Well... Slimes !
        "Baby Slime", "Black Slime", "Blue Slime", "Corrupt Slime", "Dungeon Slime",
        "Green Slime", "Illuminant Slime", "Jungle Slime", "Mother Slime", "Pinky", 
        "Purple Slime", "Red Slime", "Slimeling", "Slimer", "Slimer2", "Toxic Sludge",
        "Yellow Slime", "Lava Slime"});
 List<string> Defaults = new List<string>(new string[] { // All other monsters ^^
        "Antlion", "Bit Eater", "Clinger", "Clown", "Little Eater", "Man Eater", "Meteor Head",
        "Mimic", "Mister Stabby", "Shark", "Snatcher", "Snow Balla", "Snowman Gangsta",
        "Unicorn", "Vile Spit"});
 List<string> NotRenamed = new List<string>(new string[] { //Mobs stats are changed, but not renamed. An Elite Angler Fish doesn't make sense for example.
        "Angler Fish", "Blue Jellyfish", "Corrupt Bunny", "Corrupt Goldfish", "Crab",
        "Cursed Hammer", "Cursed Skull", "Enchanted Sword", "Green Jellyfish", "Pink Jellyfish",
        "Piranha"});
 List<string> BatLike = new List<string>(new string[] { // Bats & Flying monsters
        "Big Stinger", "Cave Bat", "Corruptor", "Demon Eye", "Gastropod", "Giant Bat", 
        "Harpy", "Hornet", "Illuminant Bat", "Jungle Bat", "Little Stinger", "Pixie",
        "Vulture", "Wandering Eye", "Demon", "Hellbat", "Voodoo Demon", "Eater of Soul"});
 List<string> Warriors = new List<string>(new string[] { // Warriors-typed monsters.
        "Angry Bones", "Armored Skeleton", "Bald Zombie", "Big Boned", "Chaos Elemental", 
        "Dark Caster", "Goblin Peon", "Goblin Archer", "Goblin Scout", "Goblin Sorcerer",
        "Goblin Thief", "Goblin Warrior", "Heavy Skeleton", "Possessed Armor", "Short Bones",
        "Skeleton Archer", "Skeleton", "Undead Miner", "Werewolf", "Wraith", "Zombie", "Fire Imp"});
#endregion

#region Initialize
public void Initialize(){

if(this.npc.townNPC == true){ return; }
int playerX = (int) Main.player[Main.myPlayer].position.X;
int playerY =  (int) Main.player[Main.myPlayer].position.Y;
#endregion

#region Normal
if(Main.worldName == "Nightmare"){
    int z = Main.rand.Next(20);


    if(this.npc.name=="Bunny"){

    }else if(this.npc.name=="Man Eater") {

        if(z>=0 && z<=30){
            this.npc.scale = 0.8f;
            this.npc.name = "Carnivor Flower";
            this.npc.lifeMax = 1100;
            this.npc.life = 1100;
            this.npc.defense = 10;
            this.npc.damage = 30;
            this.npc.value = 350;
        }
        if(z>30 && z<=60){
            this.npc.scale = 1f;
            this.npc.name ="Man Eater";
            this.npc.lifeMax = 1130;
            this.npc.life = 1130;
            this.npc.defense = 12;
            this.npc.damage = 42;
            this.npc.value = 650;
        }
        if(z>60){
            this.npc.scale = 1.2f;
            this.npc.name = "Hunter Killer";
            this.npc.lifeMax = 1130;
            this.npc.life = 1130;
            this.npc.defense = 16;
            this.npc.damage = 50;
            this.npc.value = 900;
        }
    }else if(this.npc.name=="Zombie"){

        if(z>=0 && z<=45){
            this.npc.scale = 0.85f;
            this.npc.name = "Zombie";
            this.npc.lifeMax = 545;
            this.npc.life = 545;
            this.npc.defense = 7;
            this.npc.damage = 14;
            this.npc.value = 60;
        }
        if(z>60 && z<=90){
            this.npc.scale = 0.95f;
            this.npc.name ="Ghoul";
            this.npc.lifeMax = 655;
            this.npc.life = 655;
            this.npc.defense = 9;
            this.npc.damage = 16;
            this.npc.value = 60;
        }
        if(z>90){
            this.npc.scale = 1.15f;
            this.npc.name = "Undead";
            this.npc.lifeMax = 765;
            this.npc.life = 765;
            this.npc.defense = 8;
            this.npc.damage = 18;
            this.npc.value = 60;
        }
    }else if(this.npc.name=="Yellow Slime"){
        if(z>=0 && z<=3 && Main.hardMode){
            this.npc.active=false;
            NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Demon Chief Assassin"].type, 0);
        }
        if(z>=3 && z<=45){
            this.npc.scale = 1.2f;
            this.npc.name = "Yellow Slime";
            this.npc.lifeMax = 425;
            this.npc.life = 425;
            this.npc.defense = 7;
            this.npc.damage = 15;
            this.npc.value = 500;
        }
        if(z>45 && z<=70){
            this.npc.scale = 1.25f;
            this.npc.name ="Armored Yellow Slime";
            this.npc.lifeMax = 535;
            this.npc.life = 535;
            this.npc.defense = 12;
            this.npc.damage = 15;
            this.npc.value = 500;
        }
        if(z>70){
            this.npc.scale = 1.25f;
            this.npc.name = "Acid Yellow Slime";
            this.npc.lifeMax = 630;
            this.npc.life = 630;
            this.npc.defense = 7;
            this.npc.damage = 25;
            this.npc.value = 500;
            this.npc.alpha = 187;
        }
    }else if(this.npc.name=="Wraith"){
        if(z>=0 && z<=65){
            this.npc.scale = 1f;
            this.npc.name = "Wraith";
            this.npc.lifeMax = 1200;
            this.npc.life = 1200;
            this.npc.defense = 18;
            this.npc.damage = 75;
            this.npc.value = 500;
        }
        if(z>65 && z<=85){
            this.npc.scale = 1.1f;
            this.npc.name ="Ghost";
            this.npc.lifeMax = 855;
            this.npc.life = 855;
            this.npc.defense = 44;
            this.npc.damage = 120;
            this.npc.alpha = 250;
            this.npc.value = 2500;
        }
        if(z>85){
             //NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Shadow"].type, 0);
            this.npc.active=false;
        }
    }else if(this.npc.name=="Werewolf"){
        if(z>=0 && z<=60){
            this.npc.scale = 0.9f;
            this.npc.name = "Werewolf";
            this.npc.lifeMax = 600;
            this.npc.life = 600;
            this.npc.defense = 40;
            this.npc.damage = 70;
            this.npc.value = 1000;
        }
        if(z>60 && z<=90){
            this.npc.scale = 1.1f;
            this.npc.name ="Great Werewolf";
            this.npc.lifeMax = 750;
            this.npc.life = 750;
            this.npc.defense = 45;
            this.npc.damage = 80;
            this.npc.value = 1000;
        }
        if(z>90){
            this.npc.scale = 1.3f;
            this.npc.name = "Night Beast";
            this.npc.lifeMax = 1650;
            this.npc.life = 1650;
            this.npc.defense = 48;
            this.npc.damage = 100;
            this.npc.value = 1500;
        }

    }else if(this.npc.name=="Vulture"){
        if(z>0 && z<=80){
            this.npc.scale = 1f;
            this.npc.name = "Vulture";
            this.npc.lifeMax = 440;
            this.npc.life = 440;
            this.npc.defense = 4;
            this.npc.damage = 15;
            this.npc.value = 60;
        }
        if(z>80 && z<=100){
            this.npc.scale = 1.2f;
            this.npc.name ="Death Eagle";
            this.npc.lifeMax = 660;
            this.npc.life = 660;
            this.npc.defense = 4;
            this.npc.damage = 25;
            this.npc.value = 75;
        }
    }else if(this.npc.name=="Unicorn"){
        if(z>0 && z<=70){
            this.npc.scale = 1f;
            this.npc.name = "Unicorn";
            this.npc.lifeMax = 800;
            this.npc.life = 800;
            this.npc.defense = 30;
            this.npc.damage = 65;
            this.npc.value = 1000;
        }
        if(z>70 && z<=80){
            this.npc.scale = 1f;
            this.npc.name = "Hallowed Horse";
            this.npc.lifeMax = 950;
            this.npc.life = 950;
            this.npc.defense = 30;
            this.npc.damage = 65;
            this.npc.value = 1000;
            this.npc.alpha= 150;
        }
        if(z>80 && z<=100){
            this.npc.scale = 0.8f;
            this.npc.name ="Angry Poney";
            this.npc.lifeMax = 1350;
            this.npc.life = 1350;
            this.npc.defense = 30;
            this.npc.damage = 85;
            this.npc.value = 1000;
        }
    }else if(this.npc.name=="Skeleton"){
        if(z>0 && z<=70){
            this.npc.scale = 1f;
            this.npc.name = "Skeleton";
            this.npc.lifeMax = 660;
            this.npc.life = 660;
            this.npc.defense = 8;
            this.npc.damage = 20;
            this.npc.value = 1000;
        }
        if(z>70 && z<=80){
            this.npc.scale = 1.1f;
            this.npc.name = "Dead Warrior";
            this.npc.lifeMax = 820;
            this.npc.life = 820;
            this.npc.defense = 20;
            this.npc.damage = 40;
            this.npc.value = 1000;
            this.npc.alpha= 30;
        }
        if(z>80 && z<=100){
            this.npc.scale = 1.2f;
            this.npc.name ="Menacing Skeleton";
            this.npc.lifeMax = 1680;
            this.npc.life = 1680;
            this.npc.defense = 20;
            this.npc.damage = 30;
            this.npc.value = 1000;
        }
    }else if(this.npc.name=="Shark"){
        int a = Main.rand.Next(5);
        if(a==0){
            this.npc.active=false;
            NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["JAWS"].type, 0);
        }
    }else if(this.npc.name=="Red Slime"){
        if(z>=0 && z<=60){
            this.npc.scale = 1.2f;
            this.npc.name = "Red Slime";
            this.npc.lifeMax = 425;
            this.npc.life = 425;
            this.npc.defense = 4;
            this.npc.damage = 12;
            this.npc.value = 15;
        }
        if(z>60 && z<=95){
            this.npc.scale = 1.1f;
            this.npc.name ="Armored Red Slime";
            this.npc.lifeMax = 635;
            this.npc.life = 635;
            this.npc.defense = 14;
            this.npc.alpha = 225;
            this.npc.damage = 12;
            this.npc.value = 25;
        }
    }else if(this.npc.name=="Purple Slime"){
        if(z>=0 && z<=60){
            this.npc.scale = 1.2f;
            this.npc.name = "Purple Slime";
            this.npc.lifeMax = 625;
            this.npc.life = 625;
            this.npc.defense = 0;
            this.npc.damage = 12;
            this.npc.value = 3;
        }
        if(z>60 && z<=90){
            this.npc.scale = 1.1f;
            this.npc.name ="Translusid Purple Slime";
            this.npc.lifeMax = 835;
            this.npc.life = 835;
            this.npc.defense = 2;
            this.npc.alpha = 225;
            this.npc.damage = 12;
            this.npc.value = 10;
        }
        if(z>90  && z<=95){
            this.npc.scale = 0.5f;
            this.npc.name = "Rich Slime";
            this.npc.lifeMax = 1120;
            this.npc.life = 1120;
            this.npc.defense = 4;
            this.npc.damage = 20;
            this.npc.value = 500000;
        }
        if(z>95){
            this.npc.active=false;
            NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Bloody Karie"].type, 0);
        }
    }else if(this.npc.name=="Pixie"){
        if(z>=0 && z<=60){
            this.npc.scale = 1f;
            this.npc.name = "Pixie";
            this.npc.lifeMax = 650;
            this.npc.life = 650;
            this.npc.defense = 20;
            this.npc.damage = 55;
            this.npc.value = 350;
        }
        if(z>60 && z<=90){
            this.npc.scale = 0.8f;
            this.npc.name ="Nervous Pixie";
            this.npc.lifeMax = 700;
            this.npc.life = 700;
            this.npc.defense = 20;
            this.npc.damage = 75;
            this.npc.value = 900;
        }
        if(z>90){
            this.npc.scale = 1.4f;
            this.npc.name = "Queen Pixie";
            this.npc.lifeMax = 1280;
            this.npc.life = 1280;
            this.npc.defense = 34;
            this.npc.damage = 60;
            this.npc.value = 700;
        }
    }else if(this.npc.name=="Piranha"){
        if(z>=0 && z<=60){
            this.npc.scale = 1f;
            this.npc.name = "Piranha";
            this.npc.lifeMax = 325;
            this.npc.life = 325;
            this.npc.defense = 0;
            this.npc.damage = 25;
            this.npc.value = 50;
        }
        if(z>60 && z<=90){
            this.npc.scale = 1.1f;
            this.npc.name ="Great Piranha";
            this.npc.lifeMax = 630;
            this.npc.life = 630;
            this.npc.defense = 2;
            this.npc.damage = 25;
            this.npc.value = 50;
        }
        if(z>90){
            this.npc.scale = 1.2f;
            this.npc.name = "Swimming Teeth";
            this.npc.lifeMax = 850;
            this.npc.life = 850;
            this.npc.defense = 4;
            this.npc.damage = 35;
            this.npc.value = 50;
        }
    }else if(this.npc.name=="Meteor Head"){

        this.npc.scale = 1f;
        this.npc.name = "Meteor Head";
        this.npc.lifeMax = 226;
        this.npc.life = 226;
        this.npc.defense = 4;
        this.npc.damage = 6;
        this.npc.value = 80;

        if(z>80 && z<=100){
            this.npc.scale = 1.2f;
            this.npc.name ="Meteor Elemental";
            this.npc.lifeMax = 635;
            this.npc.life = 635;
            this.npc.defense = 6;
            this.npc.damage = 50;
            this.npc.value = 80;

}
        
    }else if(this.npc.name=="Lava Slime"){
        if(Main.hardMode){
            if(z>=0 && z<=60){
                this.npc.scale = 1f;
                this.npc.name = "Lava Slime";
                this.npc.lifeMax = 1270;
                this.npc.life = 1270;
                this.npc.defense = 35;
                this.npc.damage = 60;
                this.npc.value = 1000;
                //this.npc.light=1.2;
                this.npc.alpha=100;
            }
            if(z>60 && z<=100){
                this.npc.scale = 1.1f;
                this.npc.name ="Magma Elemental";
                this.npc.lifeMax = 1290;
                this.npc.life = 1290;
                this.npc.defense = 35;
                this.npc.damage = 30;
                this.npc.value = 6500;
            }
        }else{
            if(z>=0 && z<=60){
                this.npc.scale = 1f;
                this.npc.name = "Fire Slime";
                this.npc.lifeMax = 450;
                this.npc.life = 450;
                this.npc.defense = 10;
                this.npc.damage = 15;
                this.npc.value = 350;
            }
            if(z>60 && z<=90){
                this.npc.scale = 1.1f;
                this.npc.name ="Lava Slime";
                this.npc.lifeMax = 680;
                this.npc.life = 680;
                this.npc.defense = 12;
                this.npc.damage = 20;
                this.npc.value = 650;
            }
            if(z>90){
                this.npc.scale = 1.1f;
                this.npc.name = "Magma Slime";
                this.npc.lifeMax = 1100;
                this.npc.life = 1100;
                this.npc.defense = 16;
                this.npc.damage = 30;
                this.npc.value = 900;
            }
        }
    }else if(this.npc.name=="Jungle Slime"){
        if(z>=0 && z<=3 ){
            this.npc.active=false;
            NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightshade"].type, 0);
        }
        if(z>=3 && z<=45){
            this.npc.scale = 1.1f;
            this.npc.name = "Jungle Slime";
            this.npc.lifeMax = 425;
            this.npc.life = 425;
            this.npc.defense = 6;
            this.npc.damage = 18;
            this.npc.value = 500;
        }
        if(z>45 && z<=70){
            this.npc.scale = 1.1f;
            this.npc.name ="Spiky Jungle Slime";
            this.npc.lifeMax = 835;
            this.npc.life = 835;
            this.npc.defense = 6;
            this.npc.damage = 18;
            this.npc.value = 500;
        }
        if(z>70){
            this.npc.scale = 1.2f;
            this.npc.name = "Cave Slime";
            this.npc.lifeMax = 540;
            this.npc.life = 540;
            this.npc.defense = 8;
            this.npc.damage = 18;
            this.npc.value = 500;
            this.npc.alpha=125;
        }
    }else if(this.npc.name=="Jungle Bat"){
        if(z>=0 && z<=80){
            this.npc.scale = 1f;
            this.npc.name = "Jungle Bat";
            this.npc.lifeMax = 434;
            this.npc.life = 434;
            this.npc.defense = 4;   
            this.npc.damage = 20;
            this.npc.value = 90;
        }
        if(z>80){
            this.npc.scale = 1.4f;
            this.npc.name ="Giant Jungle Bat";
            this.npc.lifeMax = 660;
            this.npc.life = 660;
            this.npc.defense = 4;
            this.npc.damage = 30;
            this.npc.value = 180;
        }
    }else if(this.npc.name=="Illuminant Slime"){
        if(z>=0 && z<=60){
            this.npc.scale = 1.05f;
            this.npc.name = "Illuminant Bat";
            this.npc.lifeMax = 1180;
            this.npc.life = 1180;
            this.npc.defense = 25;
            this.npc.damage = 70;
            this.npc.value = 400;
        }
        if(z>60 && z<=90){
            this.npc.scale = 1.1f;
            this.npc.name ="Phased Slime";
            this.npc.lifeMax = 700;
            this.npc.life = 700;
            this.npc.defense = 30;
            this.npc.damage = 70;
            this.npc.value = 750;
        }
        if(z>90){
            this.npc.scale = 1.3f;
            this.npc.name = "Chaos Slime";
            this.npc.lifeMax = 1650;
            this.npc.life = 1650;
            this.npc.defense = 30;
            this.npc.damage = 70;
            this.npc.value = 1500;
            this.npc.alpha = 150;
        }
    }else if(this.npc.name=="Illuminant Bat"){
        if(z>=0 && z<=60){
            this.npc.scale = 1f;
            this.npc.name = "Illuminant Bat";
            this.npc.lifeMax = 1200;
            this.npc.life = 1200;
            this.npc.defense = 25;
            this.npc.damage = 75;
            this.npc.value = 500;
        }
        if(z>60 && z<=90){
            this.npc.scale = 1.1f;
            this.npc.name ="Phased Bat";
            this.npc.lifeMax = 650;
            this.npc.life = 650;
            this.npc.defense = 60;
            this.npc.damage = 85;
            this.npc.value = 750;
        }
        if(z>90){
            this.npc.scale = 1.1f;
            this.npc.name = "Chaos Bat";
            this.npc.lifeMax = 1350;
            this.npc.life = 1350;
            this.npc.defense = 60;
            this.npc.damage = 95;
            this.npc.value = 1500;
        }
    }else if(this.npc.name=="Hellbat"){
        if(Main.hardMode){
            if(z>=0 && z<=45){
                this.npc.scale = 1.1f;
                this.npc.name = "Molten Wings";
                this.npc.lifeMax = 755;
                this.npc.life = 755;
                this.npc.defense = 28;
                this.npc.damage = 60;
                this.npc.value = 3500;
            }
            if(z>45 && z<=90){
                this.npc.scale = 1.1f;
                this.npc.name ="Phase Hellbat";
                this.npc.lifeMax = 820;
                this.npc.life = 820;
                this.npc.defense = 28;
                this.npc.damage = 60;
                this.npc.value = 6500;
                //this.npc.light=1.2;
                this.npc.alpha=100;
            }
            if(z>90){
                this.npc.scale = 1.3f;
                this.npc.name = "Armored Hellbat";
                this.npc.lifeMax = 1255;
                this.npc.life = 1255;
                this.npc.defense = 28;
                this.npc.damage = 30;
                this.npc.value = 12000;
            }
        }else{
            if(z>=0 && z<=60){
                this.npc.scale = 1.1f;
                this.npc.name = "Hellbat";
                this.npc.lifeMax = 646;
                this.npc.life = 646;
                this.npc.defense = 8;
                this.npc.damage = 35;
                this.npc.value = 350;
            }
            if(z>60 && z<=90){
                this.npc.scale = 1.2f;
                this.npc.name ="Fire Wings";
                this.npc.lifeMax = 655;
                this.npc.life = 655;
                this.npc.defense = 8;
                this.npc.damage = 60;
                this.npc.value = 650;
            }
            if(z>90){
                this.npc.scale = 1.1f;
                this.npc.name = "Molten Bat";
                this.npc.lifeMax = 1120;
                this.npc.life = 1120;
                this.npc.defense = 8;
                this.npc.damage = 35;
                this.npc.value = 900;
            }
        }
    }else if(this.npc.name=="Harpy"){
        if(z>=0 && z<=50){
            this.npc.scale = 1f;
            this.npc.name = "Harpy";
            this.npc.lifeMax = 600;
            this.npc.life = 600;
            this.npc.defense = 8;
            this.npc.damage = 25;
            this.npc.value = 300;
        }
        if(z>50 && z<=90){
            this.npc.scale = 0.8f;
            this.npc.name ="Young Harpy";
            this.npc.lifeMax = 580;
            this.npc.life = 580;
            this.npc.defense = 8;
            this.npc.damage = 20;
            this.npc.value = 300;
        }
        if(z>90){
            this.npc.scale = 1.3f;
            this.npc.name = "Harpy Mother";
            this.npc.lifeMax = 1150;
            this.npc.life = 1150;
            this.npc.defense = 14;
            this.npc.damage = 35;
            this.npc.value = 600;
        }
    }else if(this.npc.name=="Green Slime"){
        if(z>=0 && z<=60){
            this.npc.scale = 0.8f;
            this.npc.displayName = "Green Slime";
            this.npc.lifeMax = 425;
            this.npc.life = 425;
            this.npc.defense = 0;
            this.npc.damage = 6;
            this.npc.value = 3;
        }
        if(z>60 && z<=90){
            this.npc.scale = 1.1f;
            this.npc.displayName ="Armored Green Slime";
            this.npc.lifeMax = 535;
            this.npc.life = 535;
            this.npc.defense = 2;
            this.npc.damage = 7;
            this.npc.value = 10;
        }
        if(z>90){
            this.npc.scale = 1.8f;
            this.npc.displayName = "King Green Slime";
            this.npc.lifeMax = 850;
            this.npc.life = 850;
            this.npc.defense = 4;
            this.npc.damage = 8;
            this.npc.value = 15;
        }
    }else if(this.npc.name=="Fire Imp"){
        if(Main.hardMode){
            if(z>=0 && z<=60){
                this.npc.scale = 1f;
                this.npc.name = "Phase Imp";
                this.npc.lifeMax = 870;
                this.npc.life = 870;
                this.npc.defense = 35;
                this.npc.damage = 60;
                this.npc.value = 1000;
                //this.npc.light=1.2;
                this.npc.alpha=100;
            }
            if(z>60 && z<=90){
                this.npc.scale = 1f;
                this.npc.name ="Fire Elemental";
                this.npc.lifeMax = 1290;
                this.npc.life = 1290;
                this.npc.defense = 35;
                this.npc.damage = 30;
                this.npc.value = 6500;
            }
            if(z>90){
                this.npc.scale = 1.3f;
                this.npc.name = "Heavy Imp";
                this.npc.lifeMax = 1250;
                this.npc.life = 1250;
                this.npc.defense = 54;
                this.npc.damage = 30;
                this.npc.value = 12000;
            }
        }else{
            if(z>=0 && z<=60){
                this.npc.scale = 1f;
                this.npc.name = "Fire Imp";
                this.npc.lifeMax = 570;
                this.npc.life = 570;
                this.npc.defense = 16;
                this.npc.damage = 30;
                this.npc.value = 350;
            }
            if(z>60 && z<=90){
                this.npc.scale = 0.8f;
                this.npc.name ="Lava Imp";
                this.npc.lifeMax = 890;
                this.npc.life = 890;
                this.npc.defense = 26;
                this.npc.damage = 30;
                this.npc.value = 650;
            }
            if(z>90){
                this.npc.scale = 1.3f;
                this.npc.name = "Magma Imp";
                this.npc.lifeMax = 1100;
                this.npc.life = 1100;
                this.npc.defense = 16;
                this.npc.damage = 30;
                this.npc.value = 900;
            }
        }
    }else if(this.npc.name=="Dungeon Slime"){
        if(z>=0 && z<=60){
            this.npc.scale = 1.25f;
            this.npc.name = "Dungeon Slime";
            this.npc.lifeMax = 1150;
            this.npc.life = 1150;
            this.npc.defense = 0;
            this.npc.damage = 30;
            this.npc.value = 150;
        }
        if(z>60 && z<=90){
            this.npc.scale = 1.3f;
            this.npc.name ="Dungeon crawler";
            this.npc.lifeMax = 1150;
            this.npc.life = 1150;
            this.npc.defense = 2;
            this.npc.damage = 50;
            this.npc.value = 350;
        }
        if(z>90){
            this.npc.scale = 1.4f;
            this.npc.name = "Dungeon Shadow";
            this.npc.lifeMax = 1200;
            this.npc.alpha=150;
            this.npc.life = 1200;
            this.npc.defense = 4;
            this.npc.damage = 30;
            this.npc.value = 450;
            this.npc.alpha = 180;
        }
    }else if(this.npc.name=="Demon"){
        if(z>0 && z<=60){
            this.npc.scale = 1f;
            this.npc.name = "Demon";
            this.npc.lifeMax = 1120;
            this.npc.life = 1120;
            this.npc.defense = 8;
            this.npc.damage = 32;
            this.npc.value = 300;
        }
        if(z>60 && z<=90){
            this.npc.scale = 1.4f;
            this.npc.name ="Warp Demon";
            this.npc.lifeMax = 1140;
            this.npc.life = 1140;
            this.npc.defense = 28;
            this.npc.damage = 32;
            this.npc.value = 300;
            this.npc.alpha = 180;
        }
        if(z>90){
            this.npc.scale = 1.2f;
            this.npc.name = "Bloody Demon";
            this.npc.lifeMax = 1120;
            this.npc.life = 1120;
            this.npc.defense = 8;
            this.npc.damage = 45;
            this.npc.value = 600;
            //Color c1 = (32,178,170);
            //this.npc.color=255,30,0,100;
            //this.npc.color = red;
        }
    }else if(this.npc.name=="Demon Eye"){
        if(z>=0 && z<=90){
            this.npc.scale = 1f;
            this.npc.name = "Demon eye";
            this.npc.lifeMax = 560;
            this.npc.life = 560;
            this.npc.defense = 2;
            this.npc.damage = 18;
            this.npc.value = 75;
        }
        if(z>90){
            this.npc.scale = 1.5f;
            this.npc.name = "Evil look";
            this.npc.lifeMax = 610;
            this.npc.life = 610;
            this.npc.defense = 10;
            this.npc.damage = 25;
            this.npc.value = 275;
        }
    }else if(this.npc.name=="Crab"){
        if(z>=0 && z<=30){
            this.npc.scale = 1f;
            this.npc.lifeMax = 440;
            this.npc.life = 440;
            this.npc.defense = 10;
            this.npc.damage = 20;
            this.npc.value = 25;
        }
        if(z>30 && z<=60){
            this.npc.scale = 1.1f;
            this.npc.lifeMax = 555;
            this.npc.life = 555;
            this.npc.defense = 10;
            this.npc.damage = 20;
            this.npc.value = 35;
        }
        if(z>60){
            this.npc.scale = 1.5f;
            this.npc.lifeMax = 675;
            this.npc.life = 675;
            this.npc.defense = 24;
            this.npc.damage = 20;
            this.npc.value = 185;
        }
    }else if(this.npc.name=="Blue Slime"){
        if(z>=0 && z<=3){
            this.npc.active=false;
            NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Bloody Karie"].type, 0);
        }
        if(z>3 && z<=50){
            this.npc.scale = 1f;
            this.npc.name = "Blue Slime";
            this.npc.lifeMax = 425;
            this.npc.life = 425;
            this.npc.defense = 2;
            this.npc.damage = 7;
            this.npc.value = 25;
        }
        if(z>50 && z<=90){
            this.npc.scale = 1.1f;
            this.npc.name ="Great Blue Slime";
            this.npc.lifeMax = 535;
            this.npc.life = 535;
            this.npc.defense = 4;
            this.npc.damage = 7;
            this.npc.value = 35;
        }
        if(z>90){
            this.npc.scale = 0.75f;
            this.npc.name = "Acid Blue Slime";
            this.npc.lifeMax = 725;
            this.npc.life = 725;
            this.npc.defense = 2;
            this.npc.damage = 15;
            this.npc.value = 45;
        }
    }else if(this.npc.name=="Black Slime"){
        if(z>=0 && z<=3){
            NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Demon Chief Assassin"].type, 0);
        }
        if(z>3 && z<=60){
            this.npc.scale = 1f;
            this.npc.name = "Black Slime";
            this.npc.lifeMax = 625;
            this.npc.life = 625;
            this.npc.defense = 2;
            this.npc.damage = 7;
            this.npc.value = 25;
        }
        if(z>60 && z<=90){
            this.npc.scale = 1.1f;
            this.npc.name ="Great Black Slime";
            this.npc.lifeMax = 735;
            this.npc.life = 735;
            this.npc.defense = 4;
            this.npc.damage = 7;
            this.npc.value = 35;
        }
        if(z>90){
            this.npc.scale = 1.5f;
            this.npc.name = "Acid Black Slime";
            this.npc.lifeMax = 825;
            this.npc.life = 825;
            this.npc.defense = 2;
            this.npc.damage = 15;
            this.npc.value = 45;
        }
    }else if(this.npc.name=="Armored Skeleton"){
        if(z>=0 && z<=5){
            this.npc.active = false;
            NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Brain Slug"].type, 0);
        }
        if(z>5 && z<=10){
            this.npc.active = false;
            NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Demon Chief Assassin"].type, 0);
        }
        if(z>10 && z<=60){
            this.npc.scale = 1f;
            this.npc.name = "Dead Knight";
            this.npc.lifeMax = 840;
            this.npc.life = 840;
            this.npc.defense = 36;
            this.npc.damage = 80;
            this.npc.value = 600;
        }
        if(z>60 && z<=90){
            this.npc.scale = 1f;
            this.npc.name ="Armored Skeleton";
            this.npc.lifeMax = 940;
            this.npc.life = 940;
            this.npc.defense = 36;
            this.npc.damage = 60;
            this.npc.value = 400;
        }
        if(z>90){
            this.npc.scale = 1.1f;
            this.npc.name = "Ancient King";
            this.npc.lifeMax = 1400;
            this.npc.life = 1400;
            this.npc.defense = 40;
            this.npc.damage = 70;
            this.npc.value = 850;
        }
    }else if(this.npc.name=="Angler Fish"){
        if(z>=0 && z<=20){
            this.npc.scale = 0.7f;
            this.npc.lifeMax = 475;
            this.npc.life = 475;
            this.npc.defense = 18;
            this.npc.damage = 80;
            this.npc.value = 500;
        }
        if(z>20 && z<=40){
            this.npc.scale = 0.8f;
            this.npc.lifeMax = 585;
            this.npc.life = 585;
            this.npc.defense = 20;
            this.npc.damage = 80;
            this.npc.value = 500;
        }
        if(z>40 && z<=60){
            this.npc.scale = 0.9f;
            this.npc.lifeMax = 695;
            this.npc.life =695;
            this.npc.defense = 2;
            this.npc.damage = 22;
            this.npc.value = 500;
        }
        if(z>60 && z<=80){
            this.npc.scale = 1f;
            this.npc.lifeMax = 705;
            this.npc.life = 705;
            this.npc.defense = 2;
            this.npc.damage = 24;
            this.npc.value = 500;
        }
        if(z>80){
            this.npc.scale = 1.1f;
            this.npc.lifeMax = 815;
            this.npc.life = 815;
            this.npc.defense = 3;
            this.npc.damage = 26;
            this.npc.value = 750;
        }
    }else if(this.npc.name=="Cave Bat"){
        if(z>=0 && z<=80){
            this.npc.scale = 1f;
            this.npc.name = "Cave Bat";
            this.npc.lifeMax = 416;
            this.npc.life = 416;
            this.npc.defense = 2;
            this.npc.damage = 13;
            this.npc.value = 90;
        }
        if(z>80){
            this.npc.scale = 1.4f;
            this.npc.name ="Giant Cave Bat";
            this.npc.lifeMax = 732;
            this.npc.life = 732;
            this.npc.defense = 3;
            this.npc.damage = 15;
            this.npc.value = 90;
        }
    }
#endregion
#region Nightmare
}else if(Main.worldName == "Nightmare"){
    int z = Main.rand.Next(100);

    if(this.npc.name=="Bunny"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Angel Statue Mimic"].type, 0); 
    }else if(this.npc.name=="Man Eater") {
        this.npc.active = false;
        //int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Angel Statue Mimic"].type, 0); 
    }else if(this.npc.name=="Zombie"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Possessed Hammer"].type, 0); 
    }else if(this.npc.name=="Yellow Slime"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Mole Scout"].type, 0); 
    }else if(this.npc.name=="Wraith"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Mole Miner"].type, 0); 
    }else if(this.npc.name=="Werewolf"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Angel Statue Mimic"].type, 0); 
    }else if(this.npc.name=="Vulture"){
        this.npc.active = false;
        //int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Fallen Angel"].type, 0); 
    }else if(this.npc.name=="Unicorn"){
        this.npc.active = false;
        //int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Mole Scout"].type, 0); 
    }else if(this.npc.name=="Skeleton"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Mole Miner"].type, 0); 
    }else if(this.npc.name=="Shark"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Leech Eel"].type, 0); 
    }else if(this.npc.name=="Red Slime"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Night Terror"].type, 0); 
    }else if(this.npc.name=="Purple Slime"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Mole Scout"].type, 0); 
    }else if(this.npc.name=="Pixie"){
        this.npc.active = false;
        //int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Mole Miner"].type, 0); 
    }else if(this.npc.name=="Piranha"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Leech Eel"].type, 0); 
        //npc.scale = Main.rand.Next(0.4f,1f);
    }else if(this.npc.name=="Meteor Head"){
        this.npc.active = false;
        int npc = NPC.NewNPC(playerX + Main.rand.Next(400,800) ,playerY - 700 , Config.npcDefs.byName["Nightmare Rotten Mole"].type, 0); 
        int npc2 = NPC.NewNPC(playerX - Main.rand.Next(400,800),playerY - 700, Config.npcDefs.byName["Nightmare Rotten Mole"].type, 0); 
    }else if(this.npc.name=="Lava Slime"){
        this.npc.active = false;
        //int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Angel Statue Mimic"].type, 0); 
    }else if(this.npc.name=="Jungle Slime"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Mole Miner"].type, 0); 
    }else if(this.npc.name=="Jungle Bat"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Rotten Mole"].type, 0); 
    }else if(this.npc.name=="Illuminant Slime"){
        this.npc.active = false;
        //int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Rotten Mole"].type, 0); 
    }else if(this.npc.name=="Illuminant Bat"){
        this.npc.active = false;
        //int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Rotten Mole"].type, 0); 
    }else if(this.npc.name=="Hellbat"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Rotten Mole"].type, 0); 
    }else if(this.npc.name=="Harpy"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Fallen Angel"].type, 0); 
    }else if(this.npc.name=="Green Slime"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Mole Miner"].type, 0); 
    }else if(this.npc.name=="Fire Imp"){
        //this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Rotten Mole"].type, 0); 
    }else if(this.npc.name=="Dungeon Slime"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Night Terror"].type, 0); 
    }else if(this.npc.name=="Demon"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Night Terror"].type, 0); 
    }else if(this.npc.name=="Demon Eye"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Fallen Angel"].type, 0); 
    }else if(this.npc.name=="Crab"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Eye Of Lesser Known Villan"].type, 0); 
    }else if(this.npc.name=="Blue Slime"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Night Terror"].type, 0); 
    }else if(this.npc.name=="Black Slime"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Mole Scout"].type, 0); 
    }else if(this.npc.name=="Armored Skeleton"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Mole Scout"].type, 0); 
    }else if(this.npc.name=="Angler Fish"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Leech Eel"].type, 0); 
    }else if(this.npc.name=="Cave Bat"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Rotten Mole"].type, 0); 
    }else if(this.npc.name=="Undead Miner"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Rotten Mole"].type, 0); 
    }else if(this.npc.name=="Goblin Peon"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Rotten Mole"].type, 0); 
    }else if(this.npc.name=="Goblin Warrior"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Rotten Mole"].type, 0); 
    }else if(this.npc.name=="Goblin Thief"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Rotten Mole"].type, 0); 
    }else if(this.npc.name=="Goblin Caster"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Rotten Mole"].type, 0); 
    }else if(this.npc.name=="Hornet"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Rotten Mole"].type, 0); 
    }else if(this.npc.name=="Jellyfish"){
        this.npc.active = false;
        //int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Rotten Mole"].type, 0); 
    }else if(this.npc.name=="Pink Jellyfish"){
        this.npc.active = false;
        //int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Rotten Mole"].type, 0); 
    }else if(this.npc.name=="Goblin Scout"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Eye Of Lesser Known Villan"].type, 0); 
    } else if(this.npc.name=="Bird"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Nightmare Rotten Mole"].type, 0); 
}
}
}
#endregion


