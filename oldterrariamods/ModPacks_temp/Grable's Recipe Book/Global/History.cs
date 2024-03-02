

/*
 * recipe history handling
 */
private struct HistoryItem {
	public bool availmode;
	public int toppage;
	public int pagesize;
	public int lastpagesize;	
	public bool[] filterinclude;
	public bool[] typeinclude;
	public Item filteritem;
	public List<Recipe> recipes;
};

private static List<HistoryItem> history = new List<HistoryItem>();
private static int historyindex = -1;
private static bool haspushedlasthistory = false;

public static void PushHistory() {
	// keep the list small
	if(history.Count > cfg_max_history_count) {
		history.RemoveAt(1); // leave the first (home) still on the stack
	}

	// remove left over history items	
	if( historyindex >= 0 && historyindex < history.Count) {
		int count = history.Count - historyindex;
		if( count <= 0) count = 1;
		history.RemoveRange( historyindex, count);
	}
	
	HistoryItem h = new HistoryItem();
	h.availmode = availmode;
	h.recipes = allrecipes;
	h.toppage = toppage;
	h.pagesize = pagesize;
	h.lastpagesize = lastpagesize ;	
	h.filterinclude = (bool[])filterinclude.Clone();
	h.typeinclude = (bool[])typeinclude.Clone();
	h.filteritem = filteritem;
	
	history.Add(h);
	historyindex = history.Count;
	haspushedlasthistory = false;
}

public static void HomeHistory() {
	if(history.Count == 0) return;
	
	historyindex = 0;
	
	HistoryItem h = history[historyindex];
	allrecipes = new List<Recipe>(h.recipes);
	availmode = h.availmode;
	toppage = h.toppage;
	pagesize = h.pagesize;
	lastpagesize = h.lastpagesize;
	filterinclude = (bool[])h.filterinclude.Clone();
	typeinclude = (bool[])h.typeinclude.Clone();
	filteritem = h.filteritem;
	
	history.Clear();
	historyindex = -1;
	
	if(toppage > 0) {
		toppage = 0;
		pagesize = FindPageSize( toppage);
	}
}

public static void PrevHistory() {
	if(history.Count == 0) return;
	
	if(historyindex < 0) return;
	
	if( history.Count < 0 || /* history.Count == 1 || */ historyindex <= 0) {
		return;
	}
	
	// if in last position push current and skip it
	if(history.Count > 0 && historyindex == history.Count) {
		if(!haspushedlasthistory) {
			PushHistory();
			historyindex--;
			haspushedlasthistory = true;
		}
	}
	
	historyindex--;
	if(historyindex < 0) return;
		
	HistoryItem h = history[historyindex];
	allrecipes = new List<Recipe>(h.recipes);
	availmode = h.availmode;
	toppage = h.toppage;
	pagesize = h.pagesize;
	lastpagesize = h.lastpagesize;
	filterinclude = (bool[])h.filterinclude.Clone();
	typeinclude = (bool[])h.typeinclude.Clone();
	filteritem = h.filteritem;
}

public static void NextHistory() {
	if(history.Count == 0) return;

	if(historyindex >= history.Count - 1) return;
	historyindex++;
	
	HistoryItem h = history[historyindex];
	allrecipes = new List<Recipe>(h.recipes);
	availmode = h.availmode;
	toppage = h.toppage;
	pagesize = h.pagesize;		
	lastpagesize = h.lastpagesize;
	filterinclude = (bool[])h.filterinclude.Clone();
	typeinclude = (bool[])h.typeinclude.Clone();
	filteritem = h.filteritem;
}
