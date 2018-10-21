#include <string>
#include <vector>

using namespace std;

//base class
class Question {
public:
	void setQ(string q) {
		qText = q;
	}

	string getQ() {
		return qText;
	}

	virtual void chooseA(string a) {}

	virtual vector<string> getA() {
		return answer;
	}

protected:
	string rawA; //raw string indicating answer. handle differently for each question

	string qText;
	vector<string> answer;
};

//derived classes
class MultChoice : public Question {
private:
	vector<string> aVec;

public:
	//constructor
	MultChoice(int n) {
		vector<string> temp(n);
		aVec = temp;
	}

	void defineA(int i, string a) { //i is index of aVec; a is answer text (usually letter like A, B, C...)
		aVec[i] = a;
	}

	virtual void chooseA(string a) { //"a" is the answer text you want to select (usually "A", "B", ...)
		//increment through aVec until you find answer text that matches a
		for (int i = 0; i < aVec.size(); i++) {
			//only add answer if no answer has been added yet
			if (answer.empty() && aVec[i].compare(a) == 0)
				answer.push_back(aVec[i]);
		}
	}

	virtual vector<string> getA() {
		return answer;
	}
};

class CheckBox : public Question {
private:
	vector<string> aVec;

public:
	//constructor
	CheckBox(int n) {
		vector<string> temp(n);
		aVec = temp;
	}

	void defineA(int i, string a) { //i is index of aVec; a is answer text (usually letter like A, B, C...)
		aVec[i] = a;
	}

	//call chooseA zero or more times; once for each answer that is checked
	virtual void chooseA(string a) { //"a" is the answer text you want to select (usually "A", "B", ...)
									 //increment through aVec until you find answer text that matches a
		for (int i = 0; i < aVec.size(); i++) {
			if (aVec[i].compare(a) == 0)
				answer.push_back(aVec[i]);
		}
	}

	virtual vector<string> getA() {
		return answer;
	}
};

class FreeResponse : public Question {
public:
	FreeResponse() {}

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
	MultChoice m = MultChoice(4);
	m.setQ("What is your favorite color?");
	m.defineA(0, "Yellow");
	m.defineA(1, "Red");
	m.defineA(2, "Green");
	m.defineA(3, "Blue");
	bing.push_back(&m);

	FreeResponse f = FreeResponse();
	f.setQ("What do you think about the economy?");
	bing.push_back(&f);

	CheckBox c = CheckBox(6);
	c.setQ("What do you like?");
	c.defineA(0, "Puppies");
	c.defineA(1, "Sunshine");
	c.defineA(2, "Flowers");
	c.defineA(3, "Monkeys");
	c.defineA(4, "Birds");
	c.defineA(5, "Rainbows");
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