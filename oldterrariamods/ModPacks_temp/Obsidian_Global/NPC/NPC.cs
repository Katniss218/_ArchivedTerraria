// NPC variation file

public bool isParallel = false;

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



public void Initialize(){

if(this.npc.townNPC == true){ return; }
int playerX = (int) Main.player[Main.myPlayer].position.X;
int playerY =  (int) Main.player[Main.myPlayer].position.Y;

#region Normal
if(ModPlayer.currentWorld == "Normal"){
    int z = Main.rand.Next(100);


    if(this.npc.name=="Bunny"){

    }else if(this.npc.name=="Man Eater") {

        if(z>=0 && z<=30){
            this.npc.scale = 0.8f;
            this.npc.name = "Carnivor Flower";
            this.npc.lifeMax = 100;
            this.npc.life = 100;
            this.npc.defense = 10;
            this.npc.damage = 30;
            this.npc.value = 350;
        }
        if(z>30 && z<=60){
            this.npc.scale = 1f;
            this.npc.name ="Man Eater";
            this.npc.lifeMax = 130;
            this.npc.life = 130;
            this.npc.defense = 12;
            this.npc.damage = 42;
            this.npc.value = 650;
        }
        if(z>60){
            this.npc.scale = 1.2f;
            this.npc.name = "Hunter Killer";
            this.npc.lifeMax = 130;
            this.npc.life = 130;
            this.npc.defense = 16;
            this.npc.damage = 50;
            this.npc.value = 900;
        }
    }else if(this.npc.name=="Zombie"){

        if(z>=0 && z<=45){
            this.npc.scale = 0.85f;
            this.npc.name = "Zombie";
            this.npc.lifeMax = 45;
            this.npc.life = 45;
            this.npc.defense = 7;
            this.npc.damage = 14;
            this.npc.value = 60;
        }
        if(z>60 && z<=90){
            this.npc.scale = 0.95f;
            this.npc.name ="Ghoul";
            this.npc.lifeMax = 55;
            this.npc.life = 55;
            this.npc.defense = 9;
            this.npc.damage = 16;
            this.npc.value = 60;
        }
        if(z>90){
            this.npc.scale = 1.15f;
            this.npc.name = "Undead";
            this.npc.lifeMax = 65;
            this.npc.life = 65;
            this.npc.defense = 8;
            this.npc.damage = 18;
            this.npc.value = 60;
        }
    }else if(this.npc.name=="Yellow Slime"){
        if(z>=0 && z<=3 && Main.hardMode){
            this.npc.active=false;
            NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Minautor"].type, 0);
        }
        if(z>=3 && z<=45){
            this.npc.scale = 1.2f;
            this.npc.name = "Yellow Slime";
            this.npc.lifeMax = 25;
            this.npc.life = 25;
            this.npc.defense = 7;
            this.npc.damage = 15;
            this.npc.value = 500;
        }
        if(z>45 && z<=70){
            this.npc.scale = 1.25f;
            this.npc.name ="Armored Yellow Slime";
            this.npc.lifeMax = 35;
            this.npc.life = 35;
            this.npc.defense = 12;
            this.npc.damage = 15;
            this.npc.value = 500;
        }
        if(z>70){
            this.npc.scale = 1.25f;
            this.npc.name = "Acid Yellow Slime";
            this.npc.lifeMax = 30;
            this.npc.life = 30;
            this.npc.defense = 7;
            this.npc.damage = 25;
            this.npc.value = 500;
            this.npc.alpha = 187;
        }
    }else if(this.npc.name=="Wraith"){
        if(z>=0 && z<=65){
            this.npc.scale = 1f;
            this.npc.name = "Wraith";
            this.npc.lifeMax = 200;
            this.npc.life = 200;
            this.npc.defense = 18;
            this.npc.damage = 75;
            this.npc.value = 500;
        }
        if(z>65 && z<=85){
            this.npc.scale = 1.1f;
            this.npc.name ="Ghost";
            this.npc.lifeMax = 55;
            this.npc.life = 55;
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
            this.npc.lifeMax = 400;
            this.npc.life = 400;
            this.npc.defense = 40;
            this.npc.damage = 70;
            this.npc.value = 1000;
        }
        if(z>60 && z<=90){
            this.npc.scale = 1.1f;
            this.npc.name ="Great Werewolf";
            this.npc.lifeMax = 550;
            this.npc.life = 550;
            this.npc.defense = 45;
            this.npc.damage = 80;
            this.npc.value = 1000;
        }
        if(z>90){
            this.npc.scale = 1.3f;
            this.npc.name = "Night Beast";
            this.npc.lifeMax = 650;
            this.npc.life = 650;
            this.npc.defense = 48;
            this.npc.damage = 100;
            this.npc.value = 1500;
        }

    }else if(this.npc.name=="Vulture"){
        if(z>0 && z<=80){
            this.npc.scale = 1f;
            this.npc.name = "Vulture";
            this.npc.lifeMax = 40;
            this.npc.life = 40;
            this.npc.defense = 4;
            this.npc.damage = 15;
            this.npc.value = 60;
        }
        if(z>80 && z<=100){
            this.npc.scale = 1.2f;
            this.npc.name ="Death Eagle";
            this.npc.lifeMax = 60;
            this.npc.life = 60;
            this.npc.defense = 4;
            this.npc.damage = 25;
            this.npc.value = 75;
        }
    }else if(this.npc.name=="Unicorn"){
        if(z>0 && z<=70){
            this.npc.scale = 1f;
            this.npc.name = "Unicorn";
            this.npc.lifeMax = 400;
            this.npc.life = 400;
            this.npc.defense = 30;
            this.npc.damage = 65;
            this.npc.value = 1000;
        }
        if(z>70 && z<=80){
            this.npc.scale = 1f;
            this.npc.name = "Hallowed Horse";
            this.npc.lifeMax = 550;
            this.npc.life = 550;
            this.npc.defense = 30;
            this.npc.damage = 65;
            this.npc.value = 1000;
            this.npc.alpha= 150;
        }
        if(z>80 && z<=100){
            this.npc.scale = 0.8f;
            this.npc.name ="Angry Poney";
            this.npc.lifeMax = 350;
            this.npc.life = 350;
            this.npc.defense = 30;
            this.npc.damage = 85;
            this.npc.value = 1000;
        }
    }else if(this.npc.name=="Skeleton"){
        if(z>0 && z<=70){
            this.npc.scale = 1f;
            this.npc.name = "Skeleton";
            this.npc.lifeMax = 60;
            this.npc.life = 60;
            this.npc.defense = 8;
            this.npc.damage = 20;
            this.npc.value = 1000;
        }
        if(z>70 && z<=80){
            this.npc.scale = 1.1f;
            this.npc.name = "Dead Warrior";
            this.npc.lifeMax = 120;
            this.npc.life = 120;
            this.npc.defense = 20;
            this.npc.damage = 40;
            this.npc.value = 1000;
            this.npc.alpha= 30;
        }
        if(z>80 && z<=100){
            this.npc.scale = 1.2f;
            this.npc.name ="Menacing Skeleton";
            this.npc.lifeMax = 80;
            this.npc.life = 80;
            this.npc.defense = 20;
            this.npc.damage = 30;
            this.npc.value = 1000;
        }
    }else if(this.npc.name=="Shark"){
        int a = Main.rand.Next(5);
        if(a==0){
            this.npc.active=false;
            NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Black Shark"].type, 0);
        }
    }else if(this.npc.name=="Red Slime"){
        if(z>=0 && z<=60){
            this.npc.scale = 1.2f;
            this.npc.name = "Red Slime";
            this.npc.lifeMax = 25;
            this.npc.life = 25;
            this.npc.defense = 4;
            this.npc.damage = 12;
            this.npc.value = 15;
        }
        if(z>60 && z<=95){
            this.npc.scale = 1.1f;
            this.npc.name ="Armored Red Slime";
            this.npc.lifeMax = 35;
            this.npc.life = 35;
            this.npc.defense = 14;
            this.npc.alpha = 225;
            this.npc.damage = 12;
            this.npc.value = 25;
        }
    }else if(this.npc.name=="Purple Slime"){
        if(z>=0 && z<=60){
            this.npc.scale = 1.2f;
            this.npc.name = "Purple Slime";
            this.npc.lifeMax = 25;
            this.npc.life = 25;
            this.npc.defense = 0;
            this.npc.damage = 12;
            this.npc.value = 3;
        }
        if(z>60 && z<=90){
            this.npc.scale = 1.1f;
            this.npc.name ="Translusid Purple Slime";
            this.npc.lifeMax = 35;
            this.npc.life = 35;
            this.npc.defense = 2;
            this.npc.alpha = 225;
            this.npc.damage = 12;
            this.npc.value = 10;
        }
        if(z>90  && z<=95){
            this.npc.scale = 0.5f;
            this.npc.name = "Rich Slime";
            this.npc.lifeMax = 120;
            this.npc.life = 120;
            this.npc.defense = 4;
            this.npc.damage = 20;
            this.npc.value = 500000;
        }
        if(z>95){
            this.npc.active=false;
            NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Crawler"].type, 0);
        }
    }else if(this.npc.name=="Pixie"){
        if(z>=0 && z<=60){
            this.npc.scale = 1f;
            this.npc.name = "Pixie";
            this.npc.lifeMax = 150;
            this.npc.life = 150;
            this.npc.defense = 20;
            this.npc.damage = 55;
            this.npc.value = 350;
        }
        if(z>60 && z<=90){
            this.npc.scale = 0.8f;
            this.npc.name ="Nervous Pixie";
            this.npc.lifeMax = 200;
            this.npc.life = 200;
            this.npc.defense = 20;
            this.npc.damage = 75;
            this.npc.value = 900;
        }
        if(z>90){
            this.npc.scale = 1.4f;
            this.npc.name = "Queen Pixie";
            this.npc.lifeMax = 280;
            this.npc.life = 280;
            this.npc.defense = 34;
            this.npc.damage = 60;
            this.npc.value = 700;
        }
    }else if(this.npc.name=="Piranha"){
        if(z>=0 && z<=60){
            this.npc.scale = 1f;
            this.npc.name = "Piranha";
            this.npc.lifeMax = 25;
            this.npc.life = 25;
            this.npc.defense = 0;
            this.npc.damage = 25;
            this.npc.value = 50;
        }
        if(z>60 && z<=90){
            this.npc.scale = 1.1f;
            this.npc.name ="Great Piranha";
            this.npc.lifeMax = 30;
            this.npc.life = 30;
            this.npc.defense = 2;
            this.npc.damage = 25;
            this.npc.value = 50;
        }
        if(z>90){
            this.npc.scale = 1.2f;
            this.npc.name = "Swimming Teeth";
            this.npc.lifeMax = 50;
            this.npc.life = 50;
            this.npc.defense = 4;
            this.npc.damage = 35;
            this.npc.value = 50;
        }
    }else if(this.npc.name=="Meteor Head"){

        this.npc.scale = 1f;
        this.npc.name = "Meteor Head";
        this.npc.lifeMax = 26;
        this.npc.life = 26;
        this.npc.defense = 4;
        this.npc.damage = 6;
        this.npc.value = 80;

        if(z>80 && z<=100){
            this.npc.scale = 1.2f;
            this.npc.name ="Meteor Elemental";
            this.npc.lifeMax = 35;
            this.npc.life = 35;
            this.npc.defense = 6;
            this.npc.damage = 50;
            this.npc.value = 80;

}
        
    }else if(this.npc.name=="Lava Slime"){
        if(Main.hardMode){
            if(z>=0 && z<=60){
                this.npc.scale = 1f;
                this.npc.name = "Lava Slime";
                this.npc.lifeMax = 270;
                this.npc.life = 270;
                this.npc.defense = 35;
                this.npc.damage = 60;
                this.npc.value = 1000;
                //this.npc.light=1.2;
                this.npc.alpha=100;
            }
            if(z>60 && z<=100){
                this.npc.scale = 1.1f;
                this.npc.name ="Magma Elemental";
                this.npc.lifeMax = 290;
                this.npc.life = 290;
                this.npc.defense = 35;
                this.npc.damage = 30;
                this.npc.value = 6500;
            }
        }else{
            if(z>=0 && z<=60){
                this.npc.scale = 1f;
                this.npc.name = "Fire Slime";
                this.npc.lifeMax = 50;
                this.npc.life = 50;
                this.npc.defense = 10;
                this.npc.damage = 15;
                this.npc.value = 350;
            }
            if(z>60 && z<=90){
                this.npc.scale = 1.1f;
                this.npc.name ="Lava Slime";
                this.npc.lifeMax = 80;
                this.npc.life = 80;
                this.npc.defense = 12;
                this.npc.damage = 20;
                this.npc.value = 650;
            }
            if(z>90){
                this.npc.scale = 1.1f;
                this.npc.name = "Magma Slime";
                this.npc.lifeMax = 100;
                this.npc.life = 100;
                this.npc.defense = 16;
                this.npc.damage = 30;
                this.npc.value = 900;
            }
        }
    }else if(this.npc.name=="Jungle Slime"){
        if(z>=0 && z<=3 ){
            this.npc.active=false;
            NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Giant Spider"].type, 0);
        }
        if(z>=3 && z<=45){
            this.npc.scale = 1.1f;
            this.npc.name = "Jungle Slime";
            this.npc.lifeMax = 25;
            this.npc.life = 25;
            this.npc.defense = 6;
            this.npc.damage = 18;
            this.npc.value = 500;
        }
        if(z>45 && z<=70){
            this.npc.scale = 1.1f;
            this.npc.name ="Spiky Jungle Slime";
            this.npc.lifeMax = 35;
            this.npc.life = 35;
            this.npc.defense = 6;
            this.npc.damage = 18;
            this.npc.value = 500;
        }
        if(z>70){
            this.npc.scale = 1.2f;
            this.npc.name = "Cave Slime";
            this.npc.lifeMax = 40;
            this.npc.life = 40;
            this.npc.defense = 8;
            this.npc.damage = 18;
            this.npc.value = 500;
            this.npc.alpha=125;
        }
    }else if(this.npc.name=="Jungle Bat"){
        if(z>=0 && z<=80){
            this.npc.scale = 1f;
            this.npc.name = "Jungle Bat";
            this.npc.lifeMax = 34;
            this.npc.life = 34;
            this.npc.defense = 4;   
            this.npc.damage = 20;
            this.npc.value = 90;
        }
        if(z>80){
            this.npc.scale = 1.4f;
            this.npc.name ="Giant Jungle Bat";
            this.npc.lifeMax = 60;
            this.npc.life = 60;
            this.npc.defense = 4;
            this.npc.damage = 30;
            this.npc.value = 180;
        }
    }else if(this.npc.name=="Illuminant Slime"){
        if(z>=0 && z<=60){
            this.npc.scale = 1.05f;
            this.npc.name = "Illuminant Bat";
            this.npc.lifeMax = 180;
            this.npc.life = 180;
            this.npc.defense = 25;
            this.npc.damage = 70;
            this.npc.value = 400;
        }
        if(z>60 && z<=90){
            this.npc.scale = 1.1f;
            this.npc.name ="Phased Slime";
            this.npc.lifeMax = 200;
            this.npc.life = 200;
            this.npc.defense = 30;
            this.npc.damage = 70;
            this.npc.value = 750;
        }
        if(z>90){
            this.npc.scale = 1.3f;
            this.npc.name = "Chaos Slime";
            this.npc.lifeMax = 650;
            this.npc.life = 650;
            this.npc.defense = 30;
            this.npc.damage = 70;
            this.npc.value = 1500;
            this.npc.alpha = 150;
        }
    }else if(this.npc.name=="Illuminant Bat"){
        if(z>=0 && z<=60){
            this.npc.scale = 1f;
            this.npc.name = "Illuminant Bat";
            this.npc.lifeMax = 200;
            this.npc.life = 200;
            this.npc.defense = 25;
            this.npc.damage = 75;
            this.npc.value = 500;
        }
        if(z>60 && z<=90){
            this.npc.scale = 1.1f;
            this.npc.name ="Phased Bat";
            this.npc.lifeMax = 250;
            this.npc.life = 250;
            this.npc.defense = 60;
            this.npc.damage = 85;
            this.npc.value = 750;
        }
        if(z>90){
            this.npc.scale = 1.1f;
            this.npc.name = "Chaos Bat";
            this.npc.lifeMax = 350;
            this.npc.life = 350;
            this.npc.defense = 60;
            this.npc.damage = 95;
            this.npc.value = 1500;
        }
    }else if(this.npc.name=="Hellbat"){
        if(Main.hardMode){
            if(z>=0 && z<=45){
                this.npc.scale = 1.1f;
                this.npc.name = "Molten Wings";
                this.npc.lifeMax = 155;
                this.npc.life = 155;
                this.npc.defense = 28;
                this.npc.damage = 60;
                this.npc.value = 3500;
            }
            if(z>45 && z<=90){
                this.npc.scale = 1.1f;
                this.npc.name ="Phase Hellbat";
                this.npc.lifeMax = 220;
                this.npc.life = 220;
                this.npc.defense = 28;
                this.npc.damage = 60;
                this.npc.value = 6500;
                //this.npc.light=1.2;
                this.npc.alpha=100;
            }
            if(z>90){
                this.npc.scale = 1.3f;
                this.npc.name = "Armored Hellbat";
                this.npc.lifeMax = 255;
                this.npc.life = 255;
                this.npc.defense = 28;
                this.npc.damage = 30;
                this.npc.value = 12000;
            }
        }else{
            if(z>=0 && z<=60){
                this.npc.scale = 1.1f;
                this.npc.name = "Hellbat";
                this.npc.lifeMax = 46;
                this.npc.life = 46;
                this.npc.defense = 8;
                this.npc.damage = 35;
                this.npc.value = 350;
            }
            if(z>60 && z<=90){
                this.npc.scale = 1.2f;
                this.npc.name ="Fire Wings";
                this.npc.lifeMax = 55;
                this.npc.life = 55;
                this.npc.defense = 8;
                this.npc.damage = 60;
                this.npc.value = 650;
            }
            if(z>90){
                this.npc.scale = 1.1f;
                this.npc.name = "Molten Bat";
                this.npc.lifeMax = 120;
                this.npc.life = 120;
                this.npc.defense = 8;
                this.npc.damage = 35;
                this.npc.value = 900;
            }
        }
    }else if(this.npc.name=="Harpy"){
        if(z>=0 && z<=50){
            this.npc.scale = 1f;
            this.npc.name = "Harpy";
            this.npc.lifeMax = 100;
            this.npc.life = 100;
            this.npc.defense = 8;
            this.npc.damage = 25;
            this.npc.value = 300;
        }
        if(z>50 && z<=90){
            this.npc.scale = 0.8f;
            this.npc.name ="Young Harpy";
            this.npc.lifeMax = 80;
            this.npc.life = 80;
            this.npc.defense = 8;
            this.npc.damage = 20;
            this.npc.value = 300;
        }
        if(z>90){
            this.npc.scale = 1.3f;
            this.npc.name = "Harpy Mother";
            this.npc.lifeMax = 150;
            this.npc.life = 150;
            this.npc.defense = 14;
            this.npc.damage = 35;
            this.npc.value = 600;
        }
    }else if(this.npc.name=="Green Slime"){
        if(z>=0 && z<=60){
            this.npc.scale = 0.8f;
            this.npc.displayName = "Green Slime";
            this.npc.lifeMax = 25;
            this.npc.life = 25;
            this.npc.defense = 0;
            this.npc.damage = 6;
            this.npc.value = 3;
        }
        if(z>60 && z<=90){
            this.npc.scale = 1.1f;
            this.npc.displayName ="Armored Green Slime";
            this.npc.lifeMax = 35;
            this.npc.life = 35;
            this.npc.defense = 2;
            this.npc.damage = 7;
            this.npc.value = 10;
        }
        if(z>90){
            this.npc.scale = 1.8f;
            this.npc.displayName = "King Green Slime";
            this.npc.lifeMax = 50;
            this.npc.life = 50;
            this.npc.defense = 4;
            this.npc.damage = 8;
            this.npc.value = 15;
        }
    }else if(this.npc.name=="Fire Imp"){
        if(Main.hardMode){
            if(z>=0 && z<=60){
                this.npc.scale = 1f;
                this.npc.name = "Phase Imp";
                this.npc.lifeMax = 270;
                this.npc.life = 270;
                this.npc.defense = 35;
                this.npc.damage = 60;
                this.npc.value = 1000;
                //this.npc.light=1.2;
                this.npc.alpha=100;
            }
            if(z>60 && z<=90){
                this.npc.scale = 1f;
                this.npc.name ="Fire Elemental";
                this.npc.lifeMax = 290;
                this.npc.life = 290;
                this.npc.defense = 35;
                this.npc.damage = 30;
                this.npc.value = 6500;
            }
            if(z>90){
                this.npc.scale = 1.3f;
                this.npc.name = "Heavy Imp";
                this.npc.lifeMax = 250;
                this.npc.life = 250;
                this.npc.defense = 54;
                this.npc.damage = 30;
                this.npc.value = 12000;
            }
        }else{
            if(z>=0 && z<=60){
                this.npc.scale = 1f;
                this.npc.name = "Fire Imp";
                this.npc.lifeMax = 70;
                this.npc.life = 70;
                this.npc.defense = 16;
                this.npc.damage = 30;
                this.npc.value = 350;
            }
            if(z>60 && z<=90){
                this.npc.scale = 0.8f;
                this.npc.name ="Lava Imp";
                this.npc.lifeMax = 90;
                this.npc.life = 90;
                this.npc.defense = 26;
                this.npc.damage = 30;
                this.npc.value = 650;
            }
            if(z>90){
                this.npc.scale = 1.3f;
                this.npc.name = "Magma Imp";
                this.npc.lifeMax = 100;
                this.npc.life = 100;
                this.npc.defense = 16;
                this.npc.damage = 30;
                this.npc.value = 900;
            }
        }
    }else if(this.npc.name=="Dungeon Slime"){
        if(z>=0 && z<=60){
            this.npc.scale = 1.25f;
            this.npc.name = "Dungeon Slime";
            this.npc.lifeMax = 150;
            this.npc.life = 150;
            this.npc.defense = 0;
            this.npc.damage = 30;
            this.npc.value = 150;
        }
        if(z>60 && z<=90){
            this.npc.scale = 1.3f;
            this.npc.name ="Dungeon crawler";
            this.npc.lifeMax = 150;
            this.npc.life = 150;
            this.npc.defense = 2;
            this.npc.damage = 50;
            this.npc.value = 350;
        }
        if(z>90){
            this.npc.scale = 1.4f;
            this.npc.name = "Dungeon Shadow";
            this.npc.lifeMax = 200;
            this.npc.alpha=150;
            this.npc.life = 200;
            this.npc.defense = 4;
            this.npc.damage = 30;
            this.npc.value = 450;
            this.npc.alpha = 180;
        }
    }else if(this.npc.name=="Demon"){
        if(z>0 && z<=60){
            this.npc.scale = 1f;
            this.npc.name = "Demon";
            this.npc.lifeMax = 120;
            this.npc.life = 120;
            this.npc.defense = 8;
            this.npc.damage = 32;
            this.npc.value = 300;
        }
        if(z>60 && z<=90){
            this.npc.scale = 1.4f;
            this.npc.name ="Warp Demon";
            this.npc.lifeMax = 140;
            this.npc.life = 140;
            this.npc.defense = 28;
            this.npc.damage = 32;
            this.npc.value = 300;
            this.npc.alpha = 180;
        }
        if(z>90){
            this.npc.scale = 1.2f;
            this.npc.name = "Bloody Demon";
            this.npc.lifeMax = 120;
            this.npc.life = 120;
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
            this.npc.lifeMax = 60;
            this.npc.life = 60;
            this.npc.defense = 2;
            this.npc.damage = 18;
            this.npc.value = 75;
        }
        if(z>90){
            this.npc.scale = 1.5f;
            this.npc.name = "Evil look";
            this.npc.lifeMax = 110;
            this.npc.life = 110;
            this.npc.defense = 10;
            this.npc.damage = 25;
            this.npc.value = 275;
        }
    }else if(this.npc.name=="Crab"){
        if(z>=0 && z<=30){
            this.npc.scale = 1f;
            this.npc.lifeMax = 40;
            this.npc.life = 40;
            this.npc.defense = 10;
            this.npc.damage = 20;
            this.npc.value = 25;
        }
        if(z>30 && z<=60){
            this.npc.scale = 1.1f;
            this.npc.lifeMax = 55;
            this.npc.life = 55;
            this.npc.defense = 10;
            this.npc.damage = 20;
            this.npc.value = 35;
        }
        if(z>60){
            this.npc.scale = 1.5f;
            this.npc.lifeMax = 75;
            this.npc.life = 75;
            this.npc.defense = 24;
            this.npc.damage = 20;
            this.npc.value = 185;
        }
    }else if(this.npc.name=="Blue Slime"){
        if(z>=0 && z<=3){
            this.npc.active=false;
            NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Crawler"].type, 0);
        }
        if(z>3 && z<=50){
            this.npc.scale = 1f;
            this.npc.name = "Blue Slime";
            this.npc.lifeMax = 25;
            this.npc.life = 25;
            this.npc.defense = 2;
            this.npc.damage = 7;
            this.npc.value = 25;
        }
        if(z>50 && z<=90){
            this.npc.scale = 1.1f;
            this.npc.name ="Great Blue Slime";
            this.npc.lifeMax = 35;
            this.npc.life = 35;
            this.npc.defense = 4;
            this.npc.damage = 7;
            this.npc.value = 35;
        }
        if(z>90){
            this.npc.scale = 0.75f;
            this.npc.name = "Acid Blue Slime";
            this.npc.lifeMax = 25;
            this.npc.life = 25;
            this.npc.defense = 2;
            this.npc.damage = 15;
            this.npc.value = 45;
        }
    }else if(this.npc.name=="Black Slime"){
        if(z>=0 && z<=3){
            NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Minotaur"].type, 0);
        }
        if(z>3 && z<=60){
            this.npc.scale = 1f;
            this.npc.name = "Black Slime";
            this.npc.lifeMax = 25;
            this.npc.life = 25;
            this.npc.defense = 2;
            this.npc.damage = 7;
            this.npc.value = 25;
        }
        if(z>60 && z<=90){
            this.npc.scale = 1.1f;
            this.npc.name ="Great Black Slime";
            this.npc.lifeMax = 35;
            this.npc.life = 35;
            this.npc.defense = 4;
            this.npc.damage = 7;
            this.npc.value = 35;
        }
        if(z>90){
            this.npc.scale = 1.5f;
            this.npc.name = "Acid Black Slime";
            this.npc.lifeMax = 25;
            this.npc.life = 25;
            this.npc.defense = 2;
            this.npc.damage = 15;
            this.npc.value = 45;
        }
    }else if(this.npc.name=="Armored Skeleton"){
        if(z>=0 && z<=5){
            this.npc.active = false;
            NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Golem"].type, 0);
        }
        if(z>5 && z<=10){
            this.npc.active = false;
            NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Minotaur"].type, 0);
        }
        if(z>10 && z<=60){
            this.npc.scale = 1f;
            this.npc.name = "Dead Knight";
            this.npc.lifeMax = 340;
            this.npc.life = 340;
            this.npc.defense = 36;
            this.npc.damage = 80;
            this.npc.value = 600;
        }
        if(z>60 && z<=90){
            this.npc.scale = 1f;
            this.npc.name ="Armored Skeleton";
            this.npc.lifeMax = 340;
            this.npc.life = 340;
            this.npc.defense = 36;
            this.npc.damage = 60;
            this.npc.value = 400;
        }
        if(z>90){
            this.npc.scale = 1.1f;
            this.npc.name = "Ancient King";
            this.npc.lifeMax = 400;
            this.npc.life = 400;
            this.npc.defense = 40;
            this.npc.damage = 70;
            this.npc.value = 850;
        }
    }else if(this.npc.name=="Angler Fish"){
        if(z>=0 && z<=20){
            this.npc.scale = 0.7f;
            this.npc.lifeMax = 75;
            this.npc.life = 75;
            this.npc.defense = 18;
            this.npc.damage = 80;
            this.npc.value = 500;
        }
        if(z>20 && z<=40){
            this.npc.scale = 0.8f;
            this.npc.lifeMax = 85;
            this.npc.life = 85;
            this.npc.defense = 20;
            this.npc.damage = 80;
            this.npc.value = 500;
        }
        if(z>40 && z<=60){
            this.npc.scale = 0.9f;
            this.npc.lifeMax = 95;
            this.npc.life =95;
            this.npc.defense = 2;
            this.npc.damage = 22;
            this.npc.value = 500;
        }
        if(z>60 && z<=80){
            this.npc.scale = 1f;
            this.npc.lifeMax = 105;
            this.npc.life = 105;
            this.npc.defense = 2;
            this.npc.damage = 24;
            this.npc.value = 500;
        }
        if(z>80){
            this.npc.scale = 1.1f;
            this.npc.lifeMax = 115;
            this.npc.life = 115;
            this.npc.defense = 3;
            this.npc.damage = 26;
            this.npc.value = 750;
        }
    }else if(this.npc.name=="Cave Bat"){
        if(z>=0 && z<=80){
            this.npc.scale = 1f;
            this.npc.name = "Cave Bat";
            this.npc.lifeMax = 16;
            this.npc.life = 16;
            this.npc.defense = 2;
            this.npc.damage = 13;
            this.npc.value = 90;
        }
        if(z>80){
            this.npc.scale = 1.4f;
            this.npc.name ="Giant Cave Bat";
            this.npc.lifeMax = 32;
            this.npc.life = 32;
            this.npc.defense = 3;
            this.npc.damage = 15;
            this.npc.value = 90;
        }
    }
#endregion
#region Parallel
}else if(ModPlayer.currentWorld == "Parallel"){
    int z = Main.rand.Next(100);

    if(this.npc.name=="Bunny"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Chameleon"].type, 0); 
    }else if(this.npc.name=="Man Eater") {
        this.npc.active = false;
        //int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Chameleon"].type, 0); 
    }else if(this.npc.name=="Zombie"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Undead Raptor"].type, 0); 
    }else if(this.npc.name=="Yellow Slime"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Shield Rat"].type, 0); 
    }else if(this.npc.name=="Wraith"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Raptor"].type, 0); 
    }else if(this.npc.name=="Werewolf"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Chameleon"].type, 0); 
    }else if(this.npc.name=="Vulture"){
        this.npc.active = false;
        //int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Pterosaur"].type, 0); 
    }else if(this.npc.name=="Unicorn"){
        this.npc.active = false;
        //int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Shield Rat"].type, 0); 
    }else if(this.npc.name=="Skeleton"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Raptor"].type, 0); 
    }else if(this.npc.name=="Shark"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Plesiosaur"].type, 0); 
    }else if(this.npc.name=="Red Slime"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Rat"].type, 0); 
    }else if(this.npc.name=="Purple Slime"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Shield Rat"].type, 0); 
    }else if(this.npc.name=="Pixie"){
        this.npc.active = false;
        //int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Raptor"].type, 0); 
    }else if(this.npc.name=="Piranha"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Plesiosaur"].type, 0); 
        //npc.scale = Main.rand.Next(0.4f,1f);
    }else if(this.npc.name=="Meteor Head"){
        this.npc.active = false;
        int npc = NPC.NewNPC(playerX + Main.rand.Next(400,800) ,playerY - 700 , Config.npcDefs.byName["Microraptor"].type, 0); 
        int npc2 = NPC.NewNPC(playerX - Main.rand.Next(400,800),playerY - 700, Config.npcDefs.byName["Microraptor"].type, 0); 
    }else if(this.npc.name=="Lava Slime"){
        this.npc.active = false;
        //int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Chameleon"].type, 0); 
    }else if(this.npc.name=="Jungle Slime"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Raptor"].type, 0); 
    }else if(this.npc.name=="Jungle Bat"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Microraptor"].type, 0); 
    }else if(this.npc.name=="Illuminant Slime"){
        this.npc.active = false;
        //int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Microraptor"].type, 0); 
    }else if(this.npc.name=="Illuminant Bat"){
        this.npc.active = false;
        //int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Microraptor"].type, 0); 
    }else if(this.npc.name=="Hellbat"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Microraptor"].type, 0); 
    }else if(this.npc.name=="Harpy"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Pterosaur"].type, 0); 
    }else if(this.npc.name=="Green Slime"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Raptor"].type, 0); 
    }else if(this.npc.name=="Fire Imp"){
        //this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Microraptor"].type, 0); 
    }else if(this.npc.name=="Dungeon Slime"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Rat"].type, 0); 
    }else if(this.npc.name=="Demon"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Rat"].type, 0); 
    }else if(this.npc.name=="Demon Eye"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Pterosaur"].type, 0); 
    }else if(this.npc.name=="Crab"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Bullfrog"].type, 0); 
    }else if(this.npc.name=="Blue Slime"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Rat"].type, 0); 
    }else if(this.npc.name=="Black Slime"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Shield Rat"].type, 0); 
    }else if(this.npc.name=="Armored Skeleton"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Shield Rat"].type, 0); 
    }else if(this.npc.name=="Angler Fish"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Plesiosaur"].type, 0); 
    }else if(this.npc.name=="Cave Bat"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Microraptor"].type, 0); 
    }else if(this.npc.name=="Undead Miner"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Microraptor"].type, 0); 
    }else if(this.npc.name=="Goblin Peon"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Microraptor"].type, 0); 
    }else if(this.npc.name=="Goblin Warrior"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Microraptor"].type, 0); 
    }else if(this.npc.name=="Goblin Thief"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Microraptor"].type, 0); 
    }else if(this.npc.name=="Goblin Caster"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Microraptor"].type, 0); 
    }else if(this.npc.name=="Hornet"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Microraptor"].type, 0); 
    }else if(this.npc.name=="Jellyfish"){
        this.npc.active = false;
        //int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Microraptor"].type, 0); 
    }else if(this.npc.name=="Pink Jellyfish"){
        this.npc.active = false;
        //int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Microraptor"].type, 0); 
    }else if(this.npc.name=="Goblin Scout"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Bullfrog"].type, 0); 
    } else if(this.npc.name=="Bird"){
        this.npc.active = false;
        int npc = NPC.NewNPC((int)this.npc.position.X,(int) this.npc.position.Y, Config.npcDefs.byName["Microraptor"].type, 0); 
}
}
#endregion
}


