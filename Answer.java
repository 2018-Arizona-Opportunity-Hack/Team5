import java.awt.Point;

public class Answer{
	public String text;
	public boolean selected;
	public Point regionTopLeft;
	public Point regionBottomLeft;
	public Point regionTopRight;
	public Point regionBottonRight;

	public Answer(Point tl, Point tr, Point bl, Point br){
		regionTopLeft = new Point(tl);
		regionTopRight = new Point(tr);
		regionBottomLeft = new Point(bl);
		regionBottonRight = new Point(br);
	}
	public Answer(int tlX, int tlY, int trX, int trY, int blX, int blY, int brX, int brY){
		regionTopLeft = new Point(tlX, tlY);
		regionTopRight = new Point(trX, trY);
		regionBottomLeft = new Point(blX, blY);
		regionBottomRight = new Point(brX, brY);
	}
	public Answer(){
		regionTopLeft = new Point();
		regionTopRight = new Point();
		regionBottomLeft = new Point();
		regionBottomRight = new Point();
	}

	public void setText(String a){
		text = a;
	}

	public String getText(){
		return text;
	}

	public void setChoice(boolean c){
		selected = c;
	}

	public boolean getChoice(){
		return selected;
	}
}