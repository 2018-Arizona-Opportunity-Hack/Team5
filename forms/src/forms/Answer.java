import java.awt.Point;

public class Answer{
	private String ans;
	private boolean choice;
	private Point topL;
	private Point topR;
	private Point botL;
	private Point botR;

	public Answer(Point tl, Point tr, Point bl, Point br){
		topL = new Point(tl);
		topR = new Point(tr);
		botL = new Point(bl);
		botR = new Point(br);
	}
	public Answer(int tlX, int tlY, int trX, int trY, int blX, int blY, int brX, int brY){
		topL = new Point(tlX, tlY);
		topR = new Point(trX, trY);
		botL = new Point(blX, blY);
		botR = new Point(brX, brY);
	}
	public Answer(){
		topL = new Point();
		topR = new Point();
		botL = new Point();
		botR = new Point();
	}

	public void setAns(String a){
		ans = a;
	}

	public String getAns(){
		return ans;
	}

	public void setChoice(boolean c){
		choice = c;
	}

	public boolean getChoice(){
		return choice;
	}
}