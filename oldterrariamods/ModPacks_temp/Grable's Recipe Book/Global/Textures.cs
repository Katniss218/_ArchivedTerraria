// textures

public static bool isloaded = false;

public static Texture2D formTexture, formTextureN, formTextureL;
public static Texture2D titleTexture;
public static Texture2D areaTexture, areaTextureN, areaTextureL;
public static Texture2D socketTexture, nsocketTexture, wsocketTexture;
public static Texture2D prevTexture, prevTextureON, prevTextureHL;
public static Texture2D nextTexture, nextTextureON, nextTextureHL;
public static Texture2D homeTexture, homeTextureON, homeTextureHL;
public static Texture2D buttonTexture, buttonTextureHL;
public static Texture2D smallbtnTexture, smallbtnTextureHL;
public static Texture2D filterbtnTexture, filterbtnTextureON, filterbtnTextureHL;
public static Texture2D typesbtnTexture, typesbtnTextureON, typesbtnTextureHL;
public static Texture2D availbtnTexture, availbtnTextureON, availbtnTextureHL;
public static Texture2D searchTexture, searchTextureON, searchTextureHL;
public static Texture2D allbtnTexture;
public static Texture2D nonebtnTexture;
public static Texture2D hlineTexture, hlineTextureN, hlineTextureL;
public static Texture2D vlineTexture, vlineTextureN, vlineTextureL;
public static Texture2D bookTexture;


public static void LoadTextures() {
	if(Main.dedServ) return;
	
	formTexture = formTextureN = Main.goreTexture[Config.goreID["Recipe Book_Form"]];
	formTextureL = Main.goreTexture[Config.goreID["Recipe Book_FormL"]];	
	titleTexture = Main.goreTexture[Config.goreID["Recipe Book_Title"]];	
	areaTexture = areaTextureN = Main.goreTexture[Config.goreID["Recipe Book_Area"]];
	areaTextureL = Main.goreTexture[Config.goreID["Recipe Book_AreaL"]];
	
	nsocketTexture = Main.goreTexture[Config.goreID["Recipe Book_Socket"]];
	wsocketTexture = Main.goreTexture[Config.goreID["Recipe Book_WideSocket"]];
	socketTexture = nsocketTexture;
	
	prevTexture = Main.goreTexture[Config.goreID["Recipe Book_PrevArrow"]];
	prevTextureON = Main.goreTexture[Config.goreID["Recipe Book_PrevArrowON"]];
	prevTextureHL = Main.goreTexture[Config.goreID["Recipe Book_PrevArrowHL"]];
	
	nextTexture = Main.goreTexture[Config.goreID["Recipe Book_NextArrow"]];
	nextTextureON = Main.goreTexture[Config.goreID["Recipe Book_NextArrowON"]];
	nextTextureHL = Main.goreTexture[Config.goreID["Recipe Book_NextArrowHL"]];
	
	homeTexture = Main.goreTexture[Config.goreID["Recipe Book_Home"]];
	homeTextureON = Main.goreTexture[Config.goreID["Recipe Book_HomeON"]];	
	homeTextureHL = Main.goreTexture[Config.goreID["Recipe Book_HomeHL"]];
	
	buttonTexture = Main.goreTexture[Config.goreID["Recipe Book_Button"]];
	buttonTextureHL = Main.goreTexture[Config.goreID["Recipe Book_ButtonHL"]];
	
	smallbtnTexture = Main.goreTexture[Config.goreID["Recipe Book_SmallButton"]];
	smallbtnTextureHL = Main.goreTexture[Config.goreID["Recipe Book_SmallButtonHL"]];
	
	filterbtnTexture = Main.goreTexture[Config.goreID["Recipe Book_FilterButton"]];
	filterbtnTextureON = Main.goreTexture[Config.goreID["Recipe Book_FilterButtonON"]];
	filterbtnTextureHL = Main.goreTexture[Config.goreID["Recipe Book_FilterButtonHL"]];
	
	typesbtnTexture = Main.goreTexture[Config.goreID["Recipe Book_TypesButton"]];
	typesbtnTextureON = Main.goreTexture[Config.goreID["Recipe Book_TypesButtonON"]];	
	typesbtnTextureHL = Main.goreTexture[Config.goreID["Recipe Book_TypesButtonHL"]];
	
	availbtnTexture = Main.goreTexture[Config.goreID["Recipe Book_AvailButton"]];
	availbtnTextureON = Main.goreTexture[Config.goreID["Recipe Book_AvailButtonON"]];	
	availbtnTextureHL = Main.goreTexture[Config.goreID["Recipe Book_AvailButtonHL"]];	
	
	searchTexture = Main.goreTexture[Config.goreID["Recipe Book_Search"]];
	searchTextureON = Main.goreTexture[Config.goreID["Recipe Book_SearchON"]];	
	searchTextureHL = Main.goreTexture[Config.goreID["Recipe Book_SearchHL"]];	
	
	allbtnTexture = Main.goreTexture[Config.goreID["Recipe Book_AllButton"]];
	nonebtnTexture = Main.goreTexture[Config.goreID["Recipe Book_NoneButton"]];
	
	hlineTexture = hlineTextureN = Main.goreTexture[Config.goreID["Recipe Book_HLine"]];
	hlineTextureL = Main.goreTexture[Config.goreID["Recipe Book_HLineL"]];
	
	vlineTexture = vlineTextureN = Main.goreTexture[Config.goreID["Recipe Book_VLine"]];
	vlineTextureL = Main.goreTexture[Config.goreID["Recipe Book_VLineL"]];
	
	bookTexture = Main.itemTexture[Config.itemDefs.byName["Recipe Book"].type];
	
	isloaded =	formTextureN != null && formTextureL != null 
						&& titleTexture != null
						&& areaTextureN != null && areaTextureL != null
						&& nsocketTexture != null
						&& wsocketTexture != null
						&& prevTexture != null && prevTextureON != null && prevTextureHL != null 
						&& nextTexture != null && nextTextureON != null && nextTextureHL != null 
						&& homeTexture != null && homeTextureON != null && homeTextureHL != null 
						&& buttonTexture != null && buttonTextureHL != null 
						&& smallbtnTexture != null && smallbtnTextureHL != null 
						&& filterbtnTexture != null && filterbtnTextureON != null && filterbtnTextureHL != null 
						&& typesbtnTexture != null && typesbtnTextureON != null && typesbtnTextureHL != null 
						&& availbtnTexture != null && availbtnTextureON != null && availbtnTextureHL != null 
						&& searchTexture != null && searchTextureON != null && searchTextureHL != null 
						&& allbtnTexture != null 
						&& nonebtnTexture != null 
						&& hlineTextureN != null && hlineTextureL != null 
						&& vlineTextureN != null && vlineTextureL != null
						&& bookTexture != null
						;
}
