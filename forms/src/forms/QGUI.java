package forms;
 
import java.applet.*;
import javax.swing.*;

import java.awt.*;
import java.awt.event.*;
import java.io.File;
import java.io.IOException;
import java.net.URL;
import javax.imageio.ImageIO;

public class QGUI extends JApplet {

    ImageIcon img;
    Color rec;
    
    //DECLARE FILE
  	File file;
  	
  	//DECLARE PARAMETERS
  	int errInt = 1; //0 means no error (the input file is valid). 1 means an error
  	int jusInt = 0; //0 is left, 1 is right
  	int openInt = 0; //0 means dont open upon completion. 1 means yes open
  	
  		
  	//DECLARE COMPONENTS				
  	//labels
  	JLabel iFileLab = new JLabel("File Selected:");
  	JLabel error = new JLabel();
  		
  	//buttons etc for main panel
  	JButton choose = new JButton("Choose Input File");
  	JTextField iFile = new JTextField();
  	JFileChooser fileChooser = new JFileChooser();
  	JButton go = new JButton("Format Document");
  	
  	//edit panel
  	JButton multChoice = new JButton("Single Answer");
  	JButton checkBox = new JButton("Checkbox");
  	JButton freeResponse = new JButton("Free Response");
  	ButtonGroup editButtons = new ButtonGroup(); //will be pair of above radio buttons
  	JLabel help = new JLabel("<html>Pick the type of question<br>you want to highlight, or<br>press 'done'.</html>");
  	JButton done = new JButton("Done");
  	
  	//define form
  	JLabel newForm = new JLabel("", img, JLabel.CENTER);
  	//END DEFINING VARIABLES
  	
  	JPanel newFormPanel(){
  		JPanel p = new JPanel();
  		p.setLayout(new BoxLayout(p,BoxLayout.X_AXIS));
  		p.setBorder(BorderFactory.createEmptyBorder(10,10,10,10));
  		p.add(uploadNewPanel());
  		p.add(editPanel());
  		p.add(defineForm());
  		
  		return p;
  	}
  	
  	
  	
  	//DEFINE ALL PANELS. MANY PANELS ONLY NEED TWO COMPONENTS
  	JPanel uploadNewPanel(){
  		JPanel p = new JPanel();
  		p.setLayout(new BoxLayout(p,BoxLayout.Y_AXIS));
  		p.setBorder(BorderFactory.createBevelBorder(1));
  		//add components and other panels
		p.add(Box.createRigidArea(new Dimension(0,20))); //add empty space between components
  		p.add(choose);
  		p.add(Box.createRigidArea(new Dimension(0,20))); //add empty space between components
  		p.add(iFilePanel());
  		p.add(error);
  		p.add(Box.createRigidArea(new Dimension(250,200)));
  		p.add(go);
  		p.add(Box.createVerticalGlue());
  		
  		
  		//align some elements to center
  		choose.setAlignmentX(Component.CENTER_ALIGNMENT);
  		error.setAlignmentX(Component.CENTER_ALIGNMENT);
  		go.setAlignmentX(Component.CENTER_ALIGNMENT);
  		
  		//change the font of the error message
  		error.setFont(new Font(error.getFont().getName(), Font.ITALIC, error.getFont().getSize())); //changes only to italic; maintain font name and size
  		error.setForeground(Color.red); //make it red
  				
  		//make the "choose" open the file directory
  		choose.addActionListener(new ActionListener() {
  			//Override inherited actionPerformed() and define it to open the file directory dialog box
  			@Override
  			public void actionPerformed(ActionEvent e) {
  				int returnVal = fileChooser.showOpenDialog(choose); //the "choose" is arbitrary. this means the dialog box will open over the "choose" button
  				
  				//load file and update input file name
  				if (returnVal == JFileChooser.APPROVE_OPTION){
  					file = fileChooser.getSelectedFile();
  					iFile.setText(file.getName());
  					
  					//detect the error if file is not a .txt file
  					if(!file.getName().substring(file.getName().length()-4).equalsIgnoreCase(".jpg") && !file.getName().substring(file.getName().length()-4).equalsIgnoreCase(".png")){
  						errInt = 1;
  						error.setText("Error: input must be a .jpg or .png file");
  					}
  					else{
  						errInt = 0;
  						error.setText("");
  					}//end detect error
  					
  				}//end load file
  			}
  		}
  		); //end defining "choose" button
  		
  		//make the "format document" button call the format method
  		go.addActionListener(new ActionListener() {
  			//Override inherited actionPerformed() and define it to run the format method
  			@Override
  			public void actionPerformed(ActionEvent e) {				
  				if(errInt == 0){
  					img = new ImageIcon(file.getName());
  					newForm.setIcon(img);
  				}
  				else{
  					if(file == null)
  						error.setText("Error: You must choose a .txt file to format");
  				}
  			}
  		}
  		); //end defining "format document" button

  		return p;
  	}

	JPanel iFilePanel(){
		JPanel p = new JPanel();
		p.setLayout(new BoxLayout(p,BoxLayout.X_AXIS));
		p.setMaximumSize(new Dimension(250,30));
		
		//input file is not directly editable, it relies on the file selected from the directory
		iFile.setEditable(false);
		p.add(Box.createRigidArea(new Dimension(10,0))); //add empty space between components
		p.add(iFileLab);
		p.add(Box.createRigidArea(new Dimension(5,0))); //add empty space between components
		p.add(iFile);
		p.add(Box.createRigidArea(new Dimension(10,0))); //add empty space between components
		return p;
	}
	
	JPanel editPanel(){
		JPanel p = new JPanel();
		p.setLayout(new BoxLayout(p,BoxLayout.Y_AXIS));
		p.setBorder(BorderFactory.createBevelBorder(1));  		
		
		editButtons.add(multChoice);
		editButtons.add(checkBox);
		editButtons.add(freeResponse);
		p.add(Box.createRigidArea(new Dimension(0,20))); //add empty space between components
		p.add(multChoice);
		p.add(Box.createRigidArea(new Dimension(0,20))); //add empty space between components
		p.add(checkBox);
		p.add(Box.createRigidArea(new Dimension(0,20))); //add empty space between components
		p.add(freeResponse);
		p.add(Box.createRigidArea(new Dimension(0,20))); //add empty space between components		
		p.add(help);
		help.setMaximumSize(new Dimension(175, 200));
		p.add(Box.createRigidArea(new Dimension(200,0)));
		p.add(Box.createVerticalGlue());
  		p.add(done);
  		p.add(Box.createVerticalGlue());
  		
		multChoice.setAlignmentX(CENTER_ALIGNMENT);
		checkBox.setAlignmentX(CENTER_ALIGNMENT);
		freeResponse.setAlignmentX(CENTER_ALIGNMENT);
		help.setAlignmentX(CENTER_ALIGNMENT);
		done.setAlignmentX(CENTER_ALIGNMENT);
		
		multChoice.addActionListener(new ActionListener() {
			//Override inherited actionPerformed() and define it to run the format method
			@Override
			public void actionPerformed(ActionEvent e) {				
				help.setText("<html>Selecting single-answer<br>question. Drag to mark field.</html>");
				rec = new Color(1,0,1);
			}
		}
		); //end defining "format document" button
		
		checkBox.addActionListener(new ActionListener() {
			//Override inherited actionPerformed() and define it to run the format method
			@Override
			public void actionPerformed(ActionEvent e) {				
				help.setText("<html>Selecting checkbox question.<br>Drag to mark field.</html>");
				rec = new Color(1,0,1);
			}
		}
		); //end defining "format document" button
		
		freeResponse.addActionListener(new ActionListener() {
			//Override inherited actionPerformed() and define it to run the format method
			@Override
			public void actionPerformed(ActionEvent e) {				
				help.setText("<html>Selecting free-response<br>question. Drag to mark field.</html>");
				rec = new Color(1,0,1);
			}
		}
		); //end defining "format document" button
		
		return p;
	}
	
	/*	newForm.setLayout(new BorderLayout());
				RectangleComponent rc = new RectangleComponent(0, 0);
		        newForm.add(rc);
		        newForm.revalidate();
		        newForm.repaint();
		        help.setText("bu");
	*/
	@Override
	public void paintComponent(Graphics g)
	{
	    super.paintComponent(g);
	}
	
	public class RectangleComponent extends JComponent
	{
	    int x, y;

	    RectangleComponent(int x, int y)
	    {
	        this.x = x;
	        this.y = y;
	    }

	    @Override
	    public void paintComponent(Graphics g)
	    {
	        super.paintComponent(g);

	        Color c = new Color(1.0F,0.0F,1.0F);
	        g.setColor(c);

	        g.drawRect(x, y, 50, 50);
	    }
	}
	
	JPanel defineForm(){		
		JPanel p = new JPanel();
		p.setLayout(new BoxLayout(p,BoxLayout.Y_AXIS));
		p.setBorder(BorderFactory.createBevelBorder(1));
		p.add(Box.createVerticalGlue());
		p.add(Box.createHorizontalGlue());
		p.add(newForm);		
		p.add(Box.createVerticalGlue());
		newForm.setAlignmentX(CENTER_ALIGNMENT);
		return p;
	}
	
    public void init() {
       /* try {
            URL pic = new URL(getDocumentBase(), "surveyExample.jpg");
            aang = ImageIO.read(pic);
        } catch(Exception e) {
            // tell us if anything goes wrong!
            e.printStackTrace();
        }
        */
        
        Container pane = this.getContentPane();
		pane.setLayout(new BoxLayout(pane,BoxLayout.X_AXIS));
		
		pane.add(newFormPanel());
		pane.setVisible(true);
        
    }

    /*public void paint(Graphics g) {
        super.paint(g);
        if (aang!=null) {
            g.drawImage(aang, 100, 100, this);
        }
    }*/
}