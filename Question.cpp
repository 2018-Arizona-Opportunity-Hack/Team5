#include <string>
#include <vector>

using namespace std;

struct aBox {
	string aText;
	int aCoords[4];
};

//base class
class Question {
public:
	void setQ(string q) {
		qText = q;
	}

	string getQ() {
		return qText;
	}

	/*void setqCoords(int x1, int y1, int x2, int y2) {
		qCoords[0] = x1;
		qCoords[1] = y1;
		qCoords[2] = x2;
		qCoords[3] = y2;
	}
	*/

	virtual void chooseA(string a) {}

	virtual vector<string> getA() {
		return answer;
	}

protected:
	string qText;
	//int qCoords[4]; //x1,y1,x2,y2
	vector<string> answer;
};

//derived classes
class MultChoice : public Question {
private:
	vector<aBox> aVec;

public:
	//constructor
	MultChoice() {
	}

	void defineA(string a, int x1, int y1, int x2, int y2) { // a is answer text (usually letter like A, B, C...)
		aBox temp;
		temp.aText = a;
		temp.aCoords[0] = x1;
		temp.aCoords[1] = y1;
		temp.aCoords[2] = x2;
		temp.aCoords[3] = y2;
		aVec.push_back(temp);
	}

	virtual void chooseA(string a) { //"a" is the answer text you want to select (usually "A", "B", ...)
		//increment through aVec until you find answer text that matches a
		for (int i = 0; i < aVec.size(); i++) {
			//only add answer if no answer has been added yet
			if (answer.empty() && aVec[i].aText.compare(a) == 0)
				answer.push_back(aVec[i].aText);
		}
	}

	virtual vector<string> getA() {
		return answer;
	}
};

class CheckBox : public Question {
private:
	vector<aBox> aVec;

public:
	//constructor
	CheckBox() {
	}

	void defineA(string a, int x1, int y1, int x2, int y2) { // a is answer text (usually letter like A, B, C...)
		aBox temp;
		temp.aText = a;
		temp.aCoords[0] = x1;
		temp.aCoords[1] = y1;
		temp.aCoords[2] = x2;
		temp.aCoords[3] = y2;
		aVec.push_back(temp);
	}

	//call chooseA zero or more times; once for each answer that is checked
	virtual void chooseA(string a) { //"a" is the answer text you want to select (usually "A", "B", ...)
		//increment through aVec until you find answer text that matches a
		for (int i = 0; i < aVec.size(); i++) {
			if (aVec[i].aText.compare(a) == 0)
				answer.push_back(aVec[i].aText);
		}
	}

	virtual vector<string> getA() {
		return answer;
	}
};

class FreeResponse : public Question {
private:
	vector<aBox> aVec;

public:
	FreeResponse() {}

	void defineA(int x1, int y1, int x2, int y2) { // a is answer text (usually letter like A, B, C...)
		aBox temp;
		temp.aCoords[0] = x1;
		temp.aCoords[1] = y1;
		temp.aCoords[2] = x2;
		temp.aCoords[3] = y2;
		aVec.push_back(temp);
	}

	virtual void chooseA(string a) {
		//only add answer if havent added one yet
		if(answer.empty())
			answer.push_back(a);
	}

	virtual vector<string> getA() {
		return answer;
	}
};

int main() {

	vector<Question*> bing;

	MultChoice m = MultChoice();
	m.setQ("What is your favorite color?");
	m.defineA("Yellow", 0,1,2,3);
	m.defineA("Red", 0, 1, 2, 3);
	m.defineA("Green", 0, 1, 2, 3);
	m.defineA("Blue", 0, 1, 2, 3);
	bing.push_back(&m);

	FreeResponse f = FreeResponse();
	f.setQ("What do you think about the economy?");
	f.defineA(0, 1, 2, 3);
	bing.push_back(&f);

	CheckBox c = CheckBox();
	c.setQ("What do you like?");
	c.defineA("Puppies", 0, 1, 2, 3);
	c.defineA("Sunshine", 0, 1, 2, 3);
	c.defineA("Flowers", 0, 1, 2, 3);
	c.defineA("Monkeys", 0, 1, 2, 3);
	c.defineA("Birds", 0, 1, 2, 3);
	c.defineA("Rainbows", 0, 1, 2, 3);
	bing.push_back(&c);


	bing[0]->chooseA("Red");
	bing[1]->chooseA("I think the economy is very important.");
	bing[2]->chooseA("Puppies");
	bing[2]->chooseA("Birds");
	bing[2]->chooseA("Monkeys");


	vector<string> answer0 = bing[0]->getA();
	vector<string> answer1 = bing[1]->getA();
	vector<string> answer2 = bing[2]->getA();

	return 0;
}