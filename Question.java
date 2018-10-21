import java.util.*;
import com.google.gson.Gson;


public class Question{
	private String q;
	private List<Answer> ans;
	public Question(){
		ans = new ArrayList<Answer>();
	}
	public void addAns(Answer a){
		ans.add(a);
	}

	public String[] getAns(){
		Gson gson = new Gson();
		String[] answer = new String[ans.size()];
		for (int i = 0; i < ans.size(); i++){
			answer [i] = gson.toJson(ans.get(i));
		}
	}
}

/*public class MultChoice extends Question{
	public MultChoice(){
	}
}

public class CheckBox extends Question{
	public CheckBox(){
	}
}

public class FreeResponse extends Question{
	public FreeResponse(){
	}
}
*/