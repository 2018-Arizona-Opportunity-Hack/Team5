# A^2D^2 -- A.K.A. All About Dat Data
## Team 5 -- Opportunity Hack 2018, Data Analysis Problem Statement


Have you ever felt like a paper form drifting through the wind wanting to start again? Okay, probabaly not. But perhaps you've felt ovewhelmed by the sea of paper and paper cuts you've endured while manually entering data through Google Docs. If so, today is your lucky day. Dry your eyes, go for a nice walk and smell the roses because there's a light at the end of this tunnel! 

Introducing, A^2D^2 (A - skwerd - D skwerd, (A squared D squared)) otherwise known as All About Dat Data! This Web App is the answer you've been looking for--leading you to go through a quick, seamless process all resulting in empty filling cabinets and all the data you could dream of. 

### System Details

Time for the Tech Talk. Our system is a web-based application that takes in an empty paper form image and any filled images of that form and digitizes them so that all of your collected data is stored in a SQLite database, easily queryable for any of your data analysis needs. In our next update, we will be rolling out a data reporting dashboard allowing a more direct access point to your data with the ability to filter on specific data values and potentially visual representations. 

- Front-End: React.js 
- Form Input and Labeling: Java Applet
- Back-End: Python (Python2) Image Processing, .Net Core API with SQLite Database
  - Python Libararies: OpenCV (cv2), Numpy, ArgParse

For the best convenience possible, we plan to have this application deployable through Heroku, which is a one-click hosting platform allowing for minimal effort to run your own instance of our app for your NPO.

For Security, we plan to scan all files uploaded prior to acceptance for any signs of bad actors trying to gain access to the system. Also with future versions, we will look into implementing a possible sign in structure using Google Sign in as a authentication service. 

Lastly, we plan to have a CSV export function available through the Reporting functionality so that you can download any of the data stored from your forms for external use. 

### User Flow
Using A^2D^2 is easy! After completeing the one-click set-up of your heroku instance, you'll be ready to start processing your forms.

- To start, first upload an image of your form without any data entered (blank) through the "Add New Form" option. This image will then populate on the screen, leading you through an easy-to-use annotation process that allows us to capture the questions you are asking and the answers availble.
- Once complete, all you have to do is press submit which allows our back-end magic to get to work on deciphering your form for future use. This form will be stored for you by the name of the image that you uploaded. 
- When you have a completed versions of this form, you simply come back to our app and select the option to "Upload a Completed Form." 
- You then select the name of the form and upload the image. 
- Once you do this, we will compare your completed form with the form on file resulting in a complete set of the selections made on the completed form which is stored in a SQLite database for future use. 
- This database is tied to the Reporting funcitonality of the app and allows for a seamless integration with all of your data analysis needs. 

### Future Improvements
- Currently our system only handles one page forms as only one image can be uploaded at a time. We'd like to adjust this so that multiple page forms could be accepted without manual input. 
- In order to get accurate results for text extraction, we need more time to train and evaluate different OCR methods. Ideally, we would gather samples of questions and answers and look for a method that gives us the highest amount of accuracy without risking efficiency. 

