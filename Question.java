import java.util.*;

public class Question{
	public String text;
	public Point regionTopLeft;
	public Point regionBottomLeft;
	public Point regionTopRight;
	public Point regionBottonRight;
	public List<Answer> answers;

	public Question(Point tl, Point tr, Point bl, Point br){
		regionTopLeft = new Point(tl);
		regionTopRight = new Point(tr);
		regionBottomLeft = new Point(bl);
		regionBottonRight = new Point(br);
		answers = new ArrayList<Answer>();
	}
	public Question(int tlX, int tlY, int trX, int trY, int blX, int blY, int brX, int brY){
		regionTopLeft = new Point(tlX, tlY);
		regionTopRight = new Point(trX, trY);
		regionBottomLeft = new Point(blX, blY);
		regionBottomRight = new Point(brX, brY);
		answers = new ArrayList<Answer>();
	}
	public Answer(){
		regionTopLeft = new Point();
		regionTopRight = new Point();
		regionBottomLeft = new Point();
		regionBottomRight = new Point();
		answers = new ArrayList<Answer>();
	}

	public void addAns(Answer a){
		answers.add(a);
	}
}