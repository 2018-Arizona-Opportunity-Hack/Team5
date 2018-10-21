import java.util.*;

public class FormDetails{
	public String filename;
	public boolean isTemplate;
	public List<Question> questions;

	public FormDetails(String file, boolean t){
		filename = file;
		isTemplate = t;
		questions = new ArrayList<Question>;
	}
	public FormDetails(){
		filename = "UnknownFile";
		isTemplate = false;
		questions = new ArrayList<Question>;
	}

	public void addQ(Question q){
		questions.add(q);
	}
}