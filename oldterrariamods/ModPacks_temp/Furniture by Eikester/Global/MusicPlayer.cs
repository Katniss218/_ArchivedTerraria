public class MusicPlayer
{
	int currentSong = 0;
	float volume = 1.0f;
	public bool play = false;
	public bool walkman = false;
	
	int idWalkman = -1;
	
	public Vector2 radioPosition = new Vector2(-1, -1);
	
	List<string> songs = new List<string>();
	Microsoft.Xna.Framework.Media.Song song;
	Microsoft.Xna.Framework.Media.MediaState mediaState;
	
	public float tick = 0.0f;
	
	public int CurrentSong
	{
		set { currentSong = value; }
		get { return currentSong; }
	}
	
	public float Volume
	{
		set 
		{ 
			volume = value; 
		
			if(value <= 0.0f)
				volume = 0f;
			else if(value > 1.0f)
				volume = 1.0f;
		}
		get { return volume; }
	}
	
	public void TogglePlay()
	{
		play = !play;
		
		if(play)
			Main.NewText("Radio On", 200, 200, 200);
		else
			Main.NewText("Radio Off", 200, 200, 200);
	}

	public MusicPlayer()
	{
		songs.Clear();
		
		string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "My Games", "Terraria", "Music");
		
		if(!Directory.Exists(path))
			Directory.CreateDirectory(path);
			
		string[] files = Directory.GetFiles(path, "*.mp3", SearchOption.AllDirectories);
		
		foreach(string s in files)
		{
			songs.Add(s);
			
			//ModWorld.Log(s);
		}
		
		volume = Main.musicVolume;
		
		Microsoft.Xna.Framework.Media.MediaPlayer.MediaStateChanged += new EventHandler<EventArgs>(MediaPlayer_MediaStateChanged);
		
		idWalkman = Config.itemDefs.byName["Walkman"].type;
	}
	
	void MediaPlayer_MediaStateChanged(object sender, EventArgs e)
    {
		mediaState = Microsoft.Xna.Framework.Media.MediaPlayer.State;
    }
	
	public void PlayMusic()
	{
		StopMusic();
		
		int rnd = Main.rand.Next(songs.Count);
		//ModWorld.Log(rnd.ToString());
		PlayMusic(rnd);
	}

	public void PlayMusic(int id)
	{
		if(id < 0  || id > songs.Count)
		{
			StopMusic();
			return;
		}
		
		string name = songs[id];
		//ModWorld.Log(name);
	
		volume = Main.musicVolume;
		Main.musicVolume = 0.0f;
		
		if(volume != 0.0f)
		{
   			var ctor = typeof(Microsoft.Xna.Framework.Media.Song).GetConstructor(
        		System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance, null,
        		new[] { typeof(string), typeof(string), typeof(int) }, null);
				
   			song = (Microsoft.Xna.Framework.Media.Song)ctor.Invoke(new object[] { "song", @name, 0 });
			
			Microsoft.Xna.Framework.Media.MediaPlayer.IsRepeating = false;
 			Microsoft.Xna.Framework.Media.MediaPlayer.Play(song);
			Microsoft.Xna.Framework.Media.MediaPlayer.Volume = volume;
			
			FileInfo fi = new FileInfo(name);
			Main.NewText("Now Playing: " + fi.Name, 200, 200, 200);
		}
		else
		{
			StopMusic();
		}
	}
	
	public void StopMusic()
	{
		Microsoft.Xna.Framework.Media.MediaPlayer.IsRepeating = false;
		Microsoft.Xna.Framework.Media.MediaPlayer.Stop();
		song = null;
		Main.musicVolume = volume;
	}
	
	bool FindWalkman()
	{
		foreach(Item i in Main.player[Main.myPlayer].armor)
		{
			if(i.type == idWalkman)
			{
				return true;
			}
		}
		
		return false;
	}
	
	public void Update()
	{
		walkman = FindWalkman();
	
		if(walkman)
		{
			if(mediaState == Microsoft.Xna.Framework.Media.MediaState.Stopped)
			{
				if(Microsoft.Xna.Framework.Media.MediaState.Playing == mediaState)
					StopMusic(); 
					
				PlayMusic();
			}
		
			return;
		}
	
		if(!play)
		{
			if(song != null)
				StopMusic();
			return;
		}
	
		float distance = Vector2.Distance(ModWorld.currentPlayerPosition, radioPosition);
	
		if(distance < 10)
		{
			Microsoft.Xna.Framework.Media.MediaPlayer.Volume = volume;
		}
		else if(distance > 100.0f)
		{
			Main.musicVolume = volume;
			Microsoft.Xna.Framework.Media.MediaPlayer.Volume = 0.0f;
		}
		else if(distance < 100.0f)
		{
			Main.musicVolume = 0.0f;
			
			Microsoft.Xna.Framework.Media.MediaPlayer.Volume = volume - (distance / 100.0f);
		}
		
		if(mediaState == Microsoft.Xna.Framework.Media.MediaState.Stopped)
		{
			if(Microsoft.Xna.Framework.Media.MediaState.Playing == mediaState)
                StopMusic(); 
				
			PlayMusic();
		}
	}
}